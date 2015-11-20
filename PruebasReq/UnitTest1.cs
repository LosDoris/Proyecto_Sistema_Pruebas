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
<<<<<<< HEAD
<<<<<<< HEAD
           // int i = controlReq.consultarModulos(id_req);
=======
            int i = controlReq.consultarReqPorNombre("Curso", "19");
>>>>>>> origin/master
=======
            //int i = controlReq.consultarReqPorNombre("Curso", "19");
>>>>>>> origin/master
        }
    }
}
