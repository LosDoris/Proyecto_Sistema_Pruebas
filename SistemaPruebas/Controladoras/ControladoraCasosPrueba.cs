using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraCasosPrueba
    {
        ControladoraBDCasosPrueba controlBD;
        ControladoraProyecto controlProyecto;
        //ControladoraBDDisenno controlDisenno;

        public ControladoraCasosPrueba()
        {
            controlBD = new ControladoraBDCasosPrueba();
        }

        public int IngresaCasosPrueba(object[] datos)
        {
            EntidadCasosPrueba objCasoPrueba = new EntidadCasosPrueba(datos);
            int a = controlBD.ingresarCasosPrueba(objCasoPrueba);
            return a;
        }

        public int modificarCasosPrueba(Object[] datos)
        {
            EntidadCasosPrueba objCasoPrueba = new EntidadCasosPrueba(datos);
            int ret = controlBD.modificarCasosPrueba(objCasoPrueba);
            return ret;
        }

        public int eliminarCasosPrueba(int id)
        {
            int ret = controlBD.eliminarCasosPrueba(id);
            return ret;
        }

        public DataTable consultarCasosPrueba()
        {
            DataTable dt = controlBD.consultarCasosPrueba(id);
            return dt;

        }
    }
}