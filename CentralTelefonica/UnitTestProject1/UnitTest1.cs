using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CentralitaHerencia;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InstanciaLaLista()
        {
            Centralita centralita = new Centralita();
            Assert.AreNotEqual(null, centralita.Llamadas);
        }

        [TestMethod]
        public void InstanciaLaLista2()
        {
            Centralita centralita = new Centralita("UTN");
            Assert.AreNotEqual(null, centralita.Llamadas);
        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void TestCentralitaExceptionLocal()
        {
            Centralita centralita = new Centralita("Prueba Exception");
            Llamada ll1 = new Local("Bernal", 15, "Merlo", 28.5f);
            Llamada ll2 = new Local("Bernal", 39, "Merlo", 88.15f);
            centralita += ll1;
            centralita += ll2;
        }

        [TestMethod]
        [ExpectedException(typeof(CentralitaException))]
        public void TestCentralitaExceptionProvincial()
        {
            Centralita centralita = new Centralita("Prueba Exception");
            Llamada ll1 = new Provincial("Claypole", Franja.Franja_1, 50, "San Luis");
            Llamada ll2 = new Provincial("Claypole", Franja.Franja_3, 22, "San Luis");
            centralita += ll1;
            centralita += ll2;
        }

        [TestMethod]
        public void TestEquals()
        {
            Llamada local1 = new Local("Floresta", 14, "Avellaneda", 34.25f);
            Llamada prov1 = new Provincial("Floresta", Franja.Franja_1, 23, "Avellaneda");
            Llamada local2 = new Local("Floresta", 14, "Avellaneda", 34.25f);
            Llamada prov2 = new Provincial("Floresta", Franja.Franja_2, 41, "Avellaneda");

            Assert.AreEqual(false, local1 == prov1);
            Assert.AreEqual(true, local1 == local2);
            Assert.AreEqual(false, local1 == prov2);
            Assert.AreEqual(false, prov1 == local2);
            Assert.AreEqual(true, prov1 == prov2);
            Assert.AreEqual(false, local2 == prov2);
        }
    }
}
