using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega del paquete.</param>
        /// <param name="trackingID">ID del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Lee o escribe DireccionEntrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Lee o escribe Estado.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Lee o escribe TrackingID.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Simula el envío del paquete. 
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado = (EEstado)(this.estado + 1);
                InformaEstado.Invoke(this.estado,EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Arma un string con el id y la direccion del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Info del elemento</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            string s = String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
            return s;
        }

        /// <summary>
        /// Devuelve los datos a través de MostrarDatos.
        /// </summary>
        /// <returns>Info del elemento</returns>
        public override string ToString()
        {
            return MostrarDatos((IMostrar<Paquete>)this);
        }

        /// <summary>
        /// Compara si dos paquetes son iguales a través de su trackingID.
        /// </summary>
        /// <param name="p1">Pquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// Compara si dos paquetes son distintos a través de su trackingID.
        /// </summary>
        /// <param name="p1">Paquete 1</param>
        /// <param name="p2">Paquete 2</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (p1.trackingID != p2.trackingID);
        }
    }
}
