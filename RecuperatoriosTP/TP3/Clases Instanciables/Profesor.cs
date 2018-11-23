using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        /// <summary>
        /// Inicializa el random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Inicializa las clases del día y las agrega
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="id">id del profesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Agrega dos clases al azar
        /// </summary>
        void _randomClases()
        {
            int clase = random.Next(4);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase);
            clase = random.Next(4);
            this.clasesDelDia.Enqueue((Universidad.EClases)clase);
        }

        /// <summary>
        /// Crea un texto conlos datos del profesor y sus clases del día
        /// </summary>
        /// <returns>Info del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la info del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Arma un texto con las clases del día del profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases c in this.clasesDelDia)
                sb.AppendFormat("{0}\n", c);
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un profesor da cierta clase
        /// </summary>
        /// <param name="profesor">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>True si se encuentra en sus clases del día, false si no</returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            return (profesor.clasesDelDia.Contains(clase));
        }

        /// <summary>
        /// Verifica si un profesor no da cierta clase
        /// </summary>
        /// <param name="profesor">profesor</param>
        /// <param name="clase">clase</param>
        /// <returns>True si no se encuentra en sus clases del día, false si se encuentra</returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return (!profesor.clasesDelDia.Contains(clase));
        }

    }
}
