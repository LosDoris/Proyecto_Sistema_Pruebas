using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SistemaPruebas.Controladoras;

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
        protected void deshabilitarCampos()
        {
            TextBoxPropositoCP.Enabled  = false;
            TextBoxResultadoCP.Enabled  = false;
            TextBoxFlujoCentral.Enabled = false;
            deshabilitarCamposEntrada();
            //deshabilitarGrid principal aún no programado
        }

        protected void limpiarCampos()
        {
            TextBoxPropositoCP.Text  = "";
            TextBoxResultadoCP.Text  = "";
            TextBoxFlujoCentral.Text = "";
            TextBoxEntradaDatos.Text = "";
        }

        protected void deshabilitarDropDowns()
        {
            ProyectoComboBox.Enabled      = false;
            DisenoComboBox.Enabled        = false;
            RequerimientoComboBox.Enabled = false;
        }

        protected void deshabilitarCamposEntrada()
        {
            TextBoxEntradaDatos.Enabled = false;
            TipoEntrada.Enabled     = false;
            AgregarEntrada.Enabled  = false;
            EliminarEntrada.Enabled = false;
            //deshabilitarGrid todavía no programado
        }

        protected void habilitarCamposEntrada()
        {
            TextBoxEntradaDatos.Enabled = true;
            TipoEntrada.Enabled = true;
            AgregarEntrada.Enabled = true;
            EliminarEntrada.Enabled = true;
            //habilitarGrid todavía no programado
        }


        protected void estadoInicial()
        {
            ocultarErroresDeOperacion();
            botonesInicio();
            deshabilitarCampos();
            limpiarCampos();
            deshabilitarDropDowns();
        }

        protected void habilitarCampos()
        {
            TextBoxPropositoCP.Enabled  = true;
            TextBoxResultadoCP.Enabled  = true;
            TextBoxFlujoCentral.Enabled = true;
            habilitarCamposEntrada();
            ProyectoComboBox.Enabled    = true;
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

        protected void llenarDDProyecto()
        {
            this.ProyectoComboBox.Items.Clear();
            String proyectos = controladoraCasosPrueba.solicitarProyectos();
            Console.Write(proyectos);

            String[] pr = proyectos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split('_');
               
                this.ProyectoComboBox.Items.Add(new ListItem(p2[0]));
               

            }

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
            llenarDDProyecto();
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

        protected void ProyectoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProyectoComboBox.Items.FindByText("Seleccionar").Enabled = false;
        }
    }
}