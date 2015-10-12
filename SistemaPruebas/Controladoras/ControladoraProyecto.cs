using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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

        public int IngresaProyecto(object[] datos)
        {
            EntidadProyecto objProyecto = new EntidadProyecto(datos);
            int a= controlBD.InsertarProyecto(objProyecto);
            return a;            
        }
        
        public string Consultar_ID_Nombre_Proyecto()
        {

            return controlBD.Consultar_ID_Nombre_Proyecto();
        }
        public DataTable ConsultarProyecto(int id_Proyecto)
        {
            return controlBD.ConsultarProyecto(id_Proyecto);
        }

        public DataTable ConsultarProyectoIdNombre()
        {
            return controlBD.ConsultarProyectoIdNombre();

        }

        //public List<string> ConsultarIdProyecto()
        //{
        //    List<string> retorno = controlBD.ConsultaIdProyecto();
        //    return retorno;
        //}
        public int EliminarProyecto(string id)
        {
            int retorno = controlBD.EliminarProyecto(id);
            return retorno;
        }


    }
}