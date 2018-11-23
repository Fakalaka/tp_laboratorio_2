using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestNulo
    {
        [TestMethod]
        public void Alumno_NotNull()
        {
            Alumno a = new Alumno(1,"Facundo","Rey","39063872",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.AlDia);

            Assert.IsNotNull(a.Apellido);
        }

        [TestMethod]
        public void Jornada_NotNull()
        {
            Profesor p = new Profesor();
            Jornada j = new Jornada(Universidad.EClases.Laboratorio, p);

            Assert.IsNotNull(j.Alumnos);
        }
    }
}
