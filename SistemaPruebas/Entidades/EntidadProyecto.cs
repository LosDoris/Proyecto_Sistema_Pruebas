using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Controladoras
{
    public class EntidadProyecto
    {
        String conexion = "Data Source=eccibdisw; Initial Catalog=g2inge; Integrated Security=SSPI";

        public SqlDataReader ejecutarConsulta(String consulta)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            SqlDataReader datos = null;
            SqlCommand comando = null;

            try
            {
                comando = new SqlCommand(consulta, sqlConnection);
                datos = comando.ExecuteReader();
            }
            catch (SqlException ex)
            {
                string mensajeError = ex.ToString();
             //   MessageBox.Show(mensajeError);
            }

            return datos;
        }

        public void insertarConsulta_puesto(String id_proyecto, String nombre_sistema, String objetivo_general, String fecha_asignacion, String estado, String nombre_representante, String telefono_representante, String oficina_representante)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            // Consulta(Codigo_Oficio, Tema, Descripcion, Fecha_Consulta, Fecha_Resp)
            // Sobre_Puesto(Numero_Gaceta, Numero_Decreto, Codigo_Oficio)

            /**/
            String instruccion_consulta = "insert into Proyecto(Codigo_Oficio, Tema, Descripcion, Fecha_Consulta, Fecha_Resp)" +
            "values(@Codigo_Oficio, @Tema, @Descripcion, @Fecha_Consulta, @Fecha_Resp)";


            SqlCommand comando_consulta = null;

            SqlParameter codigo_oficio = new SqlParameter("@Codigo_Oficio", SqlDbType.VarChar);
            codigo_oficio.Value = Codigo_OficioR;
            SqlParameter tema = new SqlParameter("@Id", SqlDbType.VarChar);
            if (TemaR == "")
            {
                tema.Value = DBNull.Value;
            }
            else
            {
                tema.Value = TemaR;
            }
            SqlParameter descripcion = new SqlParameter("@Nombre", SqlDbType.VarChar);
            if (DescripcionR == "")
            {
                descripcion.Value = DBNull.Value;
            }
            else
            {
                descripcion.Value = DescripcionR;
            }
            SqlParameter fecha_consulta = new SqlParameter("@Objetivo", SqlDbType.Date);
            fecha_consulta.Value = Fecha_ConsultaR;
            SqlParameter fecha_respuesta = new SqlParameter("@Fecha", SqlDbType.Date);
            fecha_respuesta.Value = Fecha_RespR;
            SqlParameter tema = new SqlParameter("@Estado", SqlDbType.VarChar);
            if (TemaR == "")
            {
                tema.Value = DBNull.Value;
            }
            else
            {
                tema.Value = TemaR;
            }
            SqlParameter descripcion = new SqlParameter("@Nombre_Rep", SqlDbType.VarChar);
            if (DescripcionR == "")
            {
                descripcion.Value = DBNull.Value;
            }
            else
            {
                descripcion.Value = DescripcionR;
            }
            SqlParameter tema = new SqlParameter("@Tel_Rep", SqlDbType.VarChar);
            if (TemaR == "")
            {
                tema.Value = DBNull.Value;
            }
            else
            {
                tema.Value = TemaR;
            }
            SqlParameter descripcion = new SqlParameter("@Ofic_Rep", SqlDbType.VarChar);
            if (DescripcionR == "")
            {
                descripcion.Value = DBNull.Value;
            }
            else
            {
                descripcion.Value = DescripcionR;
            }

            try
            {
                //CONSULTA
                comando_consulta = new SqlCommand(instruccion_consulta, sqlConnection);

                comando_consulta.Parameters.Add(codigo_oficio);
                comando_consulta.Parameters.Add(tema);
                comando_consulta.Parameters.Add(descripcion);
                comando_consulta.Parameters.Add(fecha_consulta);
                comando_consulta.Parameters.Add(fecha_respuesta);

                comando_consulta.ExecuteNonQuery();
                comando_consulta.Parameters.Clear();

            }
            catch (SqlException ex)
            {
                string mensajeError = ex.ToString();
              //  MessageBox.Show(mensajeError);
            }

            try
            {
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                string mensajeError = e.ToString();
            //    MessageBox.Show(mensajeError);
            }

        }

    }
}