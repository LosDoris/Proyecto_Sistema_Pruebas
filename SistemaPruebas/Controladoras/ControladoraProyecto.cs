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
        ControladoraRecursosHumanos controlRH;
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
        public int ActualizarProyecto(object[] datos)
        {
            EntidadProyecto objProyecto = new EntidadProyecto(datos);
            int a = controlBD.ActualizarProyecto(objProyecto);
            return a;
        }
        
        public string Consultar_ID_Nombre_Proyecto()
        {

            return controlBD.Consultar_ID_Nombre_Proyecto();
        }
        public EntidadProyecto ConsultarProyecto(int id_Proyecto)
        {

            DataTable dt = controlBD.ConsultarProyecto(id_Proyecto);
            if (dt.Rows.Count == 1)
            {
                Object[] datos = new Object[8];
                EntidadProyecto retorno;

                datos[0] = dt.Rows[0][0].ToString();
                datos[1] = dt.Rows[0][1].ToString();
                datos[2] = dt.Rows[0][2].ToString();
                datos[3] = dt.Rows[0][3].ToString();
                datos[4] = dt.Rows[0][4].ToString();
                datos[5] = dt.Rows[0][5].ToString();
                datos[6] = dt.Rows[0][6].ToString();
                datos[7] = dt.Rows[0][7].ToString();
                retorno = new EntidadProyecto(datos);
                return retorno;
            }
            else return null;
        }

        public DataTable ConsultarProyectoIdNombre()
        {
            controlRH = new ControladoraRecursosHumanos();
            int id = controlRH.proyectosDelLoggeado();
            if (id == 0)
            {
                return controlBD.ConsultarProyectoIdNombre();
            }
            else
            {
                return controlBD.ConsultarProyectoIdNombre(id);
            }            
        }
        public int ConsultarIdProyectoPorNombre(string nombre)
        {
            int retorno = -1;
            controlBD.ConsultarProyectoIdPorNombre(nombre);
            return retorno;
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
        public int ConsultarUsoProyecto(int id)
        {
            return controlBD.ConsultarUsoProyecto(id);
        }

        public void UpdateUsoProyecto(int id, int use)
        {
             controlBD.UpdateUsoProyecto(id, use);
        }

        public string ConsultarNombreProyectoPorId(int id)
        {
            string retorno="";
            controlBD.ConsultarNombreProyectoPorId(id);
            return retorno;
        }
    }
}