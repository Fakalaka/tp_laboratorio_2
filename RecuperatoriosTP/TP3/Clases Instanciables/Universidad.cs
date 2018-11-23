using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        /// <summary>
        /// Inicializa las listas
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
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
        /// Lee o escribe el campo jornada
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Lee o escribe el el elemento i de jornada
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }

        /// <summary>
        /// Guarda los datos de la universidad en un txt
        /// </summary>
        /// <param name="universidad">universidad a guardar</param>
        /// <returns>True si se pudo guardar con éxito</returns>
        public static bool Guardar(Universidad universidad)
        {
            return ((IArchivo<Universidad>)new Xml<Universidad>()).Guardar("Universidad.xml", universidad);
        }

        /// <summary>
        /// Arma un texto con los datos de todas las jornadas de la universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns></returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada j in uni.jornada)
            {
                sb.Append(j.ToString());
                sb.Append("< ------------------------------------------------>");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Agrega una jornada a la universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            List<Alumno> alumnos = new List<Alumno>();
            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                    alumnos.Add(a);
            }
            jornada.Alumnos = alumnos;
            g.jornada.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad si no está repetido
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Universidad con el alumno en su lista</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Agrega un profesor a la universidad si no está repetido
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>Universidad con el profesor en su lista</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
                return u;
            }
            return u;
        }

        /// <summary>
        /// Verifica si un alumno está en la universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>True si está, false si no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno p in g.Alumnos)
            {
                if (p == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si un alumno no está en la universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>True si no está, false si está</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            foreach (Alumno p in g.Alumnos)
            {
                if (p == a)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica si un profesor está en la universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>True si está, false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si un profesor no está en la universidad
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor</param>
        /// <returns>True si no está, false si está</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Asigna un profesor a la clase dada
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>Profesor para dar la clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == clase)
                    return p;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Devuelve un profesor que no dé la clase
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>Profesor que no dé la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p != clase)
                    return p;
            }
            throw new SinProfesorException();
        }
    }
}
