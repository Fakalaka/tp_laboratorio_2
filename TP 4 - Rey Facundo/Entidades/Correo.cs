using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        /// <summary>
        /// Constructor público. Inicializa las listas.
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Lee o escribe paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Cierra los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            Thread.CurrentThread.Abort();
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = ((Correo)elementos).paquetes;
            string s = "";
            foreach (Paquete p in l)
            {
                s += String.Format("{0} para {1} ({2})",p.TrackingID,p.DireccionEntrega,p.Estado.ToString());
                s += "\n";
            }
            return s;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete v in c.paquetes)
            {
                if (v == p)
                    throw new TrackingIdRepetidoException();
            }
            c.paquetes.Add(p);
            Thread mock = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(mock);
            mock.Start();
            return c;
        }       
    }
}
