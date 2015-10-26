using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Intefaces
{
    public partial class CasosDePrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGridEntradaDatos();
        }

        protected void BotonCPInsertar_Click(object sender, EventArgs e)
        {

        }

        protected void DECP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void llenarGridEntradaDatos()
        {
            //String conexion = "Data Source=RICARDO;Initial Catalog=PruebaInge;Integrated Security=True";
            //DataTable table = new DataTable();
            //using (SqlConnection con = new SqlConnection(conexion))
            //{
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM Dummy", con);
            //    con.Open();
            //    DECP.DataSource = cmd.ExecuteReader();
            //    DECP.DataBind();
            //}
        }
    }
}