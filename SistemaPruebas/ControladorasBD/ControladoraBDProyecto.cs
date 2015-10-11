using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDProyecto
    {
        Acceso.Acceso acceso_BD= new Acceso.Acceso();

        public ControladoraBDProyecto()
        {

        }

        public int InsertarProyecto(EntidadProyecto datos)
        {
            using (SqlCommand comando = new SqlCommand("dbo.Insertar_Proyecto"))
            {
                //  comando.CommandText = "Insertar_Proyecto";
                comando.CommandType = CommandType.StoredProcedure;

                //  comando.Parameters.Add(new SqlParameter("@id_proyecto", datos.Id_proyecto));

                comando.Parameters.Add(new SqlParameter("@nombre_sistema", datos.Nombre_sistema));

                comando.Parameters.Add(new SqlParameter("@objetivo_general", datos.Objetivo_general));

                comando.Parameters.Add(new SqlParameter("@fecha_asignacion", datos.Fecha_asignacion));

                comando.Parameters.Add(new SqlParameter("@estado", datos.Estado));

                comando.Parameters.Add(new SqlParameter("@nombre_rep", datos.Nombre_representante));

                comando.Parameters.Add(new SqlParameter("@telefono_rep", datos.Telefono_representante));

                comando.Parameters.Add(new SqlParameter("@oficina_rep", datos.Oficina_representante));

               return acceso_BD.Insertar_Proced_Almacenado(comando);

            }
        }

        public string Consultar_ID_Nombre_Proyecto()
        {
            using (SqlCommand comando = new SqlCommand("dbo.Consultar_ID_Nombre_Proyecto"))
            {
                //  comando.CommandText = "Insertar_Proyecto";
                comando.CommandType = CommandType.StoredProcedure;

                //  comando.Parameters.Add(new SqlParameter("@id_proyecto", datos.Id_proyecto));

                return acceso_BD.Consultar_Proced_Almacenado(comando);

            }
        }
        public List<string> ConsultarProyectoUsuario(string msg)
        {
            return null;
        }

        public List<string> ConsultarProyectoAdm(string msg)
        {
            return null;
        }

        public List<string> ConsultaIdProyecto()
        {
            List<string> retorno = new List<string>();
            return retorno;
        }
        public List<string> ConsultarProyecto(string msg)
        {
            return null;
        }


        public int EliminarProyecto(string msg)
        {

            return 0;
        }

        public int ActualizarProycto(string msg)
        {
            return 0;
        }
    }
}