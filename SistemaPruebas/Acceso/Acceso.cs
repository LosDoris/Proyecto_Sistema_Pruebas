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
        String conexion = "Data Source=eccibdisw; Initial Catalog=g2inge; Integrated Security=SSPI";


        public int Insertar(string consulta)

        {


         SqlConnection sqlConnection = new SqlConnection(conexion);
            sqlConnection.Open();
            int a = 0;
       
            SqlCommand comando = null;

            try
            {
                comando = new SqlCommand(consulta, sqlConnection);
                a=comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string mensajeError = ex.ToString();
                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>")               
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
                // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Hello this is an Alert")</SCRIPT>")                            
            }
            return datos;
        }
                  
    }
