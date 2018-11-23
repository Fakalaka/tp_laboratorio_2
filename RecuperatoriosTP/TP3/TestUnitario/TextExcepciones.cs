using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TextExcepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Dni_FormatoErroneo()
        {
            Alumno a = new Alumno(0, "Pepe", "Sánchez", "1234567A", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void Clase_SinProfesor()
        {
            Universidad u = new Universidad();
            u += Universidad.EClases.Laboratorio;
        }
    }
}
