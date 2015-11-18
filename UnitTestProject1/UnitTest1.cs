using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pruebReportes
{
    [TestClass]
    public class Reportes
    {
        SistemaPruebas.Controladoras.ControladoraReportes controlRep = new SistemaPruebas.Controladoras.ControladoraReportes();
        [TestMethod]
        public void testReporte()
        {
            string esperado = "";
            bool[] checks = {true, false};
            string resultado = controlRep.generarReporte("Cursos", checks);

            Assert.AreEqual(esperado, resultado);
        }

        /*
        public void testProyecto()
        {
            string date = null;
            controlRep.consultarProyecto();
        }
        */
    }
}
