using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraProyecto
    {
       
        public List<string> ConsultarRHSinProyecto()
        {
            List<String> listaNombre = new List<string>();

            return null;
        }

        public void IngresaProyecto(string id_proyecto, string nombre_sistema, string objetivo_general, string fecha_asignacion, string estado, string nombre_resp, string telefono_resp, string oficina_resp)
        {
            EntidadProyecto objProyecto = new EntidadProyecto(id_proyecto,  nombre_sistema,  objetivo_general,  fecha_asignacion,  estado,  nombre_resp,  telefono_resp,  oficina_resp);


        }
    }
}