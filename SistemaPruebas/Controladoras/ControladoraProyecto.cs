using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraProyecto
    {
        ControladoraBDProyecto controlBD;
        public ControladoraProyecto()
        {
            controlBD = new ControladoraBDProyecto();
        }
        public List<string> ConsultarRHSinProyecto()
        {
            List<String> listaNombre = new List<string>();

            return null;
        }

        public void IngresaProyecto(object[] datos)
        {
            EntidadProyecto objProyecto = new EntidadProyecto(datos);
            int resultado = controlBD.InsertarProyecto(objProyecto);

        }

        public List<string> ConsultarIdProyecto()
        {
            List<string> retorno = controlBD.ConsultaIdProyecto();
            return retorno;
        }
        public int EliminarProyecto(string id)
        {
            int retorno = controlBD.EliminarProyecto(id);
            return retorno;
        }


    }
}