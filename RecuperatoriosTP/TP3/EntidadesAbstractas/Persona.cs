using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;

        /// <summary>
        /// Constructor básico
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor público
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona en string</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        /// <summary>
        /// Lee o escribe el campo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Lee o escribe el campo nombre, validándolo
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Escribe el dni luego de ser validado
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Arma un string con el nombre y la nacionalidad de la persona
        /// </summary>
        /// <returns>Info de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}",
                this.Apellido, this.Nombre, this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el dni concuerde con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni</param>
        /// <returns>dni</returns>
        static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999)) ||
                (nacionalidad == ENacionalidad.Extranjero && (dato < 90000000 || dato > 99999999)))
                throw new NacionalidadInvalidaException();
            return dato;
        }

        /// <summary>
        /// Valida que el formate del dni sea correcto
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni</param>
        /// <returns>dni validado</returns>
        static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (int.TryParse(dato, out dni) && dni > 0 && dni <= 999999999)
                return ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException();
        }

        /// <summary>
        /// Valida el que el nombre sólo posea letras
        /// </summary>
        /// <param name="dato">nombre a validar</param>
        /// <returns>Nombre si es correcto, vacío si no</returns>
        static string ValidarNombreApellido(string dato)
        {
            foreach(char c in dato)
            {
                if (!char.IsLetter(c))
                    return "";
            }
            return dato;
        }
    }
}
