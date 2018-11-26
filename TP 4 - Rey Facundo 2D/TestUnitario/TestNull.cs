using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class TestNull
    {
        [TestMethod]
        public void ListaCorreoNotNull()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }
    }
}
