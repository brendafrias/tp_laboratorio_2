using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTestListaInstanciada
    {
        [TestMethod]
        public void TestMethodListaInstanciada()
        {
            Correo c1 = new Correo();
            if (c1.Paquetes.Equals(null))
            {
                Assert.Fail();
            }
        }
    }
}