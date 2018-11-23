using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        /// <summary>
        /// Constructor básico. Inicializa la lista de alumnos
        /// </summary>
        Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Lee o escribe el campo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Guarda los datos de la jornada en un txt
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>True si se pudo guardar con éxito</returns>
        public static bool Guardar(Jornada jornada)
        {
            return ((IArchivo<string>)new Texto()).Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee los datos de una jornada de un txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datos;
            ((IArchivo<string>)new Texto()).Leer("Jornada.txt", out datos);
            return datos;
        }

        /// <summary>
        /// Arma un texto con los datos de la jornada y sus alumnos
        /// </summary>
        /// <returns>Info de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nCLASE DE {0} POR ", this.clase);
            sb.Append(this.instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in this.alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Verifica si un alumno está en una jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>True si está, false si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno p in j.Alumnos)
            {
                if (p == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no está en una jornada
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>True si no está, false si está</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            foreach (Alumno p in j.Alumnos)
            {
                if (p == a)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Agrega un alumno a una jornada si no está ya en la misma
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>Jornada con alumno en su lista</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
                return j;
            }
            throw new AlumnoRepetidoException();
        }
    }
}
