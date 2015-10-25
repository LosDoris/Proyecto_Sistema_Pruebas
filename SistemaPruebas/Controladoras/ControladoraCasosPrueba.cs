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

        public int eliminarCasosPrueba(string id)
        {
            int ret = controlBD.eliminarCasosPrueba(id);
            return ret;
        }

        public DataTable consultarCasosPrueba(int id)
        {
            DataTable dt = controlBD.consultarCasosPrueba(id);
            return dt;

        }

        public String solicitarProyectos()
        {
            controlProyecto = new ControladoraProyecto();
            String proyectos = controlProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

        public String solicitarDisennos(string id_proyecto)
        {

            return null;
        }

        public String solicitarRequerimientos(string id_disenno)
        {

            return null;
        }
    }
}