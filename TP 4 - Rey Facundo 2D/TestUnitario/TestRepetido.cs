using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void IDRepetido()
        {
            Correo c = new Correo();
            Paquete p = new Paquete("", "123-456-7890");
            c += p;
            c += p;
        }
    }
}
