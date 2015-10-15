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
        Acceso.Acceso acceso_BD = new Acceso.Acceso();

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
        public DataTable ConsultarProyecto(int id_Proyecto)
        {
            string id= id_Proyecto.ToString();
            DataTable dt = new DataTable();
            dt = acceso_BD.ejecutarConsultaTabla("select * from Proyecto where id_proyecto= "+id);
            return dt;
        }

        public DataTable ConsultarProyecto()
        {
            DataTable dt = new DataTable();
            dt= acceso_BD.ejecutarConsultaTabla("select id_proyecto, nombre_sistema, fecha_asignacion, estado, nombre_rep from Proyecto");
            return dt;
        }
        public DataTable ConsultarProyectoIdNombre()
        {
            DataTable dt = new DataTable();
            dt = acceso_BD.ejecutarConsultaTabla("select id_proyecto, nombre_sistema from Proyecto ORDER BY id_proyecto");
            return dt;
        }
        public DataTable ConsultarProyectoIdNombre(int id_Proyecto)
        {
            DataTable dt = new DataTable();
            dt = acceso_BD.ejecutarConsultaTabla("select id_proyecto, nombre_sistema from Proyecto where id_proyecto = " + id_Proyecto + " ORDER BY id_proyecto");
            return dt;
        }
        public int ConsultarProyectoIdPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            dt = acceso_BD.ejecutarConsultaTabla("select id_proyecto from proyecto where nombre_sistema = '"+nombre+"'");
            return Int32.Parse(dt.Rows[0][0].ToString());
        }


        public int EliminarProyecto(string id)
        {
            return acceso_BD.EliminarProyecto("update Proyecto set estado = 5 where id_proyecto =" + id);
        }

        public int ActualizarProyecto(EntidadProyecto datos)
        {
            using (SqlCommand comando = new SqlCommand("dbo.Modificar_Proyecto"))
            {
                //  comando.CommandText = "Insertar_Proyecto";
                comando.CommandType = CommandType.StoredProcedure;

                //  comando.Parameters.Add(new SqlParameter("@id_proyecto", datos.Id_proyecto));

                comando.Parameters.Add(new SqlParameter("@id", datos.Id_proyecto));

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

        public int ConsultarUsoProyecto(int id)
        {
            DataTable dt = new DataTable();
            dt = acceso_BD.ejecutarConsultaTabla("select Use from proyecto where id_proyecto =" + id);
            return Int32.Parse(dt.Rows[0][0].ToString());
        }
        public int UpdateUsoProyecto(int id, int use)
        {
            return acceso_BD.EliminarProyecto("update Proyecto set Uso = "+use+" where id_proyecto =" + id);            
        }
    }
}