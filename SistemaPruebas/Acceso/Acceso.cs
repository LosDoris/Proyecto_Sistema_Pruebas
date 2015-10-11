using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Acceso
{
    public class Acceso
    {


        //  String conexion = "Data Source=eccibdisw; Initial Catalog=g2inge; Integrated Security=SSPI";
        string conexion = "Data Source=(localdb)\\SQLOne; Initial Catalog=Sistema_Pruebas; Integrated Security=SSPI";
        public DataTable ejecutarConsultaTabla(String consulta)
        {
            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            SqlCommand comando = new SqlCommand(consulta, sqlConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();

            dataAdapter.Fill(table);

            return table;
        }

        public int Insertar(string consulta)

        {


            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int a = 0;

            SqlCommand comando = null;

            try
            {
                comando = new SqlCommand(consulta, sqlConnection);
                a = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string mensajeError = ex.ToString();
                throw new Exception("Error al insertar. " + ex.Message);

                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>")               
            }

            try
                        {
                            sqlConnection.Close();
                        }
                        catch (SqlException e)
                        {
                            string mensajeError = e.ToString();
                throw new Exception("Error al cerrar la conexión con la base de datos. " + e.Message);

                //    MessageBox.Show(mensajeError);
            }

            return a;
        }


        public int Insertar_Proced_Almacenado(SqlCommand comando)

        {

            SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();

            int a = 0;

            comando.Connection = sqlConnection;

            try
            {
                a = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string mensajeError = ex.ToString();
                throw new Exception("Error al insertar. " + ex.Message);
                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>")               
            }

            try
            {
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                string mensajeError = e.ToString();
                throw new Exception("Error al cerrar la conexión con la base de datos. " + e.Message);

                //    MessageBox.Show(mensajeError);
            }

            return a;
        }


        public SqlDataReader Consultar(String consulta)
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
                throw new Exception("Error al consultar. " + ex.Message);

                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>")                            
            }

            try
            {
                sqlConnection.Close();
            }
            catch (SqlException e)
            {
                string mensajeError = e.ToString();
                throw new Exception("Error al cerrar la conexión con la base de datos. " + e.Message);

                //    MessageBox.Show(mensajeError);
            }
            return datos;
        }

    }
}
