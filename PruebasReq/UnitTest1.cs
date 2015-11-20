using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaPruebas;
using SistemaPruebas.Controladoras;

namespace PruebasReq
{
    [TestClass]
    public class UnitTest1
    {
       


        [TestMethod]
        public void TestMethod1()
        {
            ControladoraRequerimiento controlReq = new ControladoraRequerimiento();
            string id_req = "19";
            //int i = controlReq.consulReq("");
        }
    }
}
