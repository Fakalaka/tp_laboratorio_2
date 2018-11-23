using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestValorNumérico
    {
        [TestMethod]
        public void CantidadDeAlumnos()
        {
            Alumno a1 = new Alumno(1,"Manny","Rivera","12345678",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Frida", "Suárez", "91000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Profesor p = new Profesor();
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);            
            int expected = 2;

            j += a1;
            j += a2;

            Assert.AreEqual(expected, j.Alumnos.Count);
        }
    }
}
