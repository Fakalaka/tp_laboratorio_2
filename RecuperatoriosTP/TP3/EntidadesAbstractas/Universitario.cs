using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        /// <summary>
        /// Constructor básico
        /// </summary>
        public Universitario() : base()
        {
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="legajo">legajo del universitario</param>
        /// <param name="nombre">nombre del universitario</param>
        /// <param name="apellido">apellido del universitario</param>
        /// <param name="dni">dni del universitario</param>
        /// <param name="nacionalidad">nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Arma un string con los datos de la persona y su legajo
        /// </summary>
        /// <returns>Info del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NÚMERO: {0}", this.legajo);
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara un universitario con otro
        /// </summary>
        /// <param name="obj">objeto con el cual comparar</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Universitario u = (Universitario)obj;
            return (GetType() == u.GetType() && (DNI == u.DNI || legajo == u.legajo));
        }

        /// <summary>
        /// Verifica si dos universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Verifica si dos universitarios son distintos
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !pg1.Equals(pg2);
        }
    }
}
