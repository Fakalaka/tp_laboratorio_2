using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor básico
        /// </summary>
        public Alumno() : base()
        {
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Arma un string con los datos de la persona, el estado de cuenta y la clase del alumno
        /// </summary>
        /// <returns>Info del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devlueve un texto con la clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return $"\nTOMA CLASES DE {this.claseQueToma}";
        }

        /// <summary>
        /// Llama a MostrarDatos()
        /// </summary>
        /// <returns>Info del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="c">clase</param>
        /// <returns>True si toma la clase y no es deudor</returns>
        public static bool operator ==(Alumno a, Universidad.EClases c)
        {
            return (a.claseQueToma == c && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Compara un alumno con una clase
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="c">clase</param>
        /// <returns>False si no toma la clase</returns>
        public static bool operator !=(Alumno a, Universidad.EClases c)
        {
            return (a.claseQueToma != c);
        }
    }
}
