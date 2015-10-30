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
using System.Drawing;

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
                inicializarDTDatosEntrada();
                estadoInicial();
            }
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

        public static DataTable dtDatosEntrada
        {
            get
            {
                object value = HttpContext.Current.Session["datosEntrada"];
                return value == null ? null : (DataTable)value;
            }
            set
            {
                HttpContext.Current.Session["datosEntrada"] = value;
            }
        }

        protected void inicializarDTDatosEntrada()
        {
            dtDatosEntrada = new DataTable();
            dtDatosEntrada.Clear();
            dtDatosEntrada.Columns.Add("Tipo", typeof(String));
            dtDatosEntrada.Columns.Add("Datos", typeof(String));
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
            this.DECP.DataSource = null;
            this.DECP.DataBind();
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
           // EliminarEntrada.Enabled = true;
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

        protected void agregarGridEntradaDatos()
        {
            DataRow row = dtDatosEntrada.NewRow();
            row["Tipo"] = TipoEntrada.SelectedItem.Text.ToString();
            row["Datos"] = TextBoxDatos.Text;
            dtDatosEntrada.Rows.Add(row);
            DECP.DataSource = dtDatosEntrada;
            DECP.DataBind();
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
            foreach (GridViewRow row in DECP.Rows)
            {
                if (row.RowIndex == DECP.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#2e8e9e");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                   // row.ToolTip = "Click to select this row.";
                }
            }

            EliminarEntrada.Enabled = true;
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
            String datosEntrada = "";
            String tipo = TipoEntrada.SelectedItem.Text;
            if (tipo == "No Aplica")
            {
                datosEntrada = "N/A";
            }
            else
            {
                int index = 0;
                DECP.AllowPaging = false;
                DECP.DataBind();
                foreach (GridViewRow row in DECP.Rows)
                {
                    if (index != 0)
                        datosEntrada += ",";

                    datosEntrada += "[";
                    datosEntrada += row.Cells[0].Text[0];
                    if(Regex.IsMatch(row.Cells[1].Text, @"\d+"))
                    {
                        datosEntrada += "," + row.Cells[1].Text + "]";
                    }
                    else
                    {
                        datosEntrada += "]";
                        datosEntrada += "\""+row.Cells[1].Text+"\"";
                    }
                    index++;
                }
                if(DECP.Rows.Count > 1)
                {
                    datosEntrada = "[" + datosEntrada + "]";
                }

                datosEntrada += "_" + TextBoxDescripcion.Text;

            }
            DECP.AllowPaging = true;
            DECP.DataBind();
            //Response.Write(datosEntrada);
            return datosEntrada;
        }

        protected void AgregarEntrada_Click(object sender, EventArgs e)
        {
            agregarGridEntradaDatos();
            datosEntrada();
        }

        protected void OnDECPPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DECP.PageIndex = e.NewPageIndex;
            DECP.DataSource = dtDatosEntrada;
            DECP.DataBind();
        }

        protected void OnDECPRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DECP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void TipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoEntrada.SelectedItem.Text == "No Aplica")
            {
                AgregarEntrada.Enabled = false;
            }
            else
            {
                AgregarEntrada.Enabled = true;
            }
        }

        protected void EliminarEntrada_Click(object sender, EventArgs e)
        {

        }
    }
}