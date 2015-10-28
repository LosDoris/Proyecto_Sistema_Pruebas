using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SistemaPruebas.Controladoras;
using System.Text.RegularExpressions;

namespace SistemaPruebas.Intefaces
{
    public partial class CasosDePrueba : System.Web.UI.Page
    {
        ControladoraCasosPrueba controladoraCasosPrueba = new ControladoraCasosPrueba();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                inicializarModo();
                estadoInicial();
            }

            llenarGridEntradaDatos();
            errorID.Visible = false;
        }


        protected void estadoInicial()
        {
            ocultarErroresDeOperacion();
            botonesInicio();
            deshabilitarCampos();
            limpiarCampos();
        }

        protected void inicializarModo()
        {
            if(ViewState["modo"] == null)
            {
                ViewState["modo"] = 0;
            }
        }

        protected void ocultarErroresDeOperacion()
        {
            EtiqErrorInsertar.Visible  = false;
            EtiqErrorConsultar.Visible = false;
            EtiqErrorModificar.Visible = false;
            EtiqErrorEliminar.Visible  = false;
        }

        protected void botonesInicio()
        {
            BotonCPInsertar.Enabled  = true;
            BotonCPModificar.Enabled = false;
            BotonCPEliminar.Enabled  = false;
            BotonCPAceptar.Enabled   = false;
            BotonCPCancelar.Enabled  = false;
        }

        protected void habilitarCampos()
        {
            TextBoxID.Enabled = true;
            TextBoxPropositoCP.Enabled = true;
            TextBoxResultadoCP.Enabled = true;
            TextBoxFlujoCentral.Enabled = true;
            habilitarCamposEntrada();
        }
        protected void deshabilitarCampos()
        {
            TextBoxID.Enabled = false;
            TextBoxPropositoCP.Enabled  = false;
            TextBoxResultadoCP.Enabled  = false;
            TextBoxFlujoCentral.Enabled = false;
            deshabilitarCamposEntrada();
            //deshabilitarGrid principal aún no programado
        }
        protected void deshabilitarCamposEntrada()
        {
            TextBoxDatos.Enabled = false;
            TextBoxDescripcion.Enabled = false;
            TipoEntrada.Enabled = false;
            AgregarEntrada.Enabled = false;
            EliminarEntrada.Enabled = false;

            //deshabilitarGrid todavía no programado
        }
        protected void habilitarCamposEntrada()
        {
            TextBoxDatos.Enabled = true;
            TextBoxDescripcion.Enabled = true;
            TipoEntrada.Enabled = true;
            AgregarEntrada.Enabled = true;
            EliminarEntrada.Enabled = true;
            //habilitarGrid todavía no programado
        }

        protected void limpiarCampos()
        {
            TextBoxPropositoCP.Text  = "";
            TextBoxResultadoCP.Text  = "";
            TextBoxFlujoCentral.Text = "";
            TextBoxDescripcion.Text = "";
            TextBoxDatos.Text = "";
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

        protected void marcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.BackColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.ForeColor = System.Drawing.Color.White;
        }

        protected void desmarcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.Color.LightGray;
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.Black;
        }

        protected void BotonCPInsertar_Click(object sender, EventArgs e)
        {
            ViewState["modo"] = 1;
            estadoInsertar();
        }

        protected void estadoInsertar()
        {
            marcarBoton(ref BotonCPInsertar);
            limpiarCampos();
            habilitarCampos();
            BotonCPAceptar.Enabled = true;
            BotonCPCancelar.Enabled = true;
            //deshabilitar grid principal, aún no programado
        }

        protected void BotonCPModificar_Click(object sender, EventArgs e)
        {
            ViewState["modo"] = 2;
        }

        protected void DECP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BotonCPCancelar_Click(object sender, EventArgs e)
        {
            if( (int) ViewState["modo"] == 1)
            {
                estadoInicial();
            }
            else if ((int)ViewState["modo"] == 2)
            {

            }
        }

        protected void BotonCPAceptar_Click(object sender, EventArgs e)
        {
            Object[] datosNuevos = new Object[7];
            datosNuevos[0] = this.TextBoxID.Text;
            datosNuevos[1] = this.TextBoxPropositoCP.Text;
            datosNuevos[2] = datosEntrada();
            datosNuevos[3] = this.TextBoxResultadoCP.Text;
            datosNuevos[4] = this.TextBoxFlujoCentral.Text;
            datosNuevos[5] = 1;
        }

        protected string datosEntrada()
        {

            return null;
        }
    }
}