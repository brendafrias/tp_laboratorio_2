using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTestIDRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingRepetidoException))]
        public void TestMethodIDRepetido()
        {
            Paquete p1 = new Paquete("prueba1", "123");
            Paquete p2 = new Paquete("prueba2", "123");
            Correo c1 = new Correo();
            c1 += p1;
            c1 += p2;
            Assert.Fail();
        }
    }
}