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
                llenarGrid();
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
        public static int modo
        {
            get
            {
                object value = HttpContext.Current.Session["modo"];
                return value == null ? 0 : (int)value;
            }
            set
            {
                HttpContext.Current.Session["modo"] = value;
            }
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
            modo = 0;
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
            llenarGridEntradaDatos(edDelGreggGrandeAlChiquitito(@"[[V]""hilera"",[I]""hilera"",[V,1]]_h"));
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
            modo = 1;
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

        protected void llenarGrid()        //se encarga de llenar el grid cada carga de pantalla
        {
            DataTable casosPrueba = crearTablaCP();
            DataTable dt = controladoraCasosPrueba.consultarCasosPrueba(1,""); // en consultas tipo 1, no se necesita la cédula
            
            Object[] datos = new Object[5];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    datos[3] = dr[3];
                    datos[4] = dr[4];
                    casosPrueba.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                datos[4] = "-";
                casosPrueba.Rows.Add(datos);
            }
            CP.DataSource = casosPrueba;
            CP.DataBind();
        }


        protected DataTable crearTablaCP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("Propósito", typeof(String));
            dt.Columns.Add("Entrada de Datos", typeof(String));
            dt.Columns.Add("Resultado", typeof(String));
            dt.Columns.Add("Flujo Central", typeof(String));
            return dt;
        }

        protected void OnCPPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CP.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }

        protected void BotonCPModificar_Click(object sender, EventArgs e)
        {
            modo = 2;
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
            if( modo == 1)
            {
                estadoInicial();
                desmarcarBoton(ref BotonCPInsertar);
            }
            else if (modo == 2)
            {

            }
        }

        protected void BotonCPAceptar_Click(object sender, EventArgs e)
        {
            Object[] datosNuevos = new Object[6];
            datosNuevos[0] = this.TextBoxID.Text;
            datosNuevos[1] = this.TextBoxPropositoCP.Text;
            datosNuevos[2] = datosEntrada();
            datosNuevos[3] = this.TextBoxResultadoCP.Text;
            datosNuevos[4] = this.TextBoxFlujoCentral.Text;
            datosNuevos[5] = 1; //recordar modificar cuando se tenga el id del diseño

            int operacion = -1;
            if(modo == 1)
            {
                //Response.Write("Modo es 1");
                operacion = controladoraCasosPrueba.insertarCasosPrueba(datosNuevos);
            }
            else if( modo == 2)
            {

            }
            if (operacion == 1)
            {
                Response.Write("Se insertó con éxito"); //temporal hasta que halla modal
            }
            Response.Write(operacion);
            Response.Write(modo);

        }

        protected String datosEntrada()
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
                foreach (DataRow row in dtDatosEntrada.Rows)
                {
                    if (index != 0)
                        datosEntrada += ",";

                    datosEntrada += "[";
                    datosEntrada += row["Tipo"].ToString()[0];
                    if(Regex.IsMatch(row["Datos"].ToString(), @"\d+"))
                    {
                        datosEntrada += "," + row["Datos"].ToString() + "]";
                    }
                    else
                    {
                        datosEntrada += "]";
                        datosEntrada += "\""+ row["Datos"].ToString() + "\"";
                    }
                    index++;
                }
                if(DECP.Rows.Count > 1)
                {
                   datosEntrada = "[" + datosEntrada + "]";
                }

                datosEntrada = datosEntrada + "_" + TextBoxDescripcion.Text;

            }
         
            return datosEntrada;
        }

        protected void AgregarEntrada_Click(object sender, EventArgs e)
        {
            agregarGridEntradaDatos();
            Response.Write( datosEntrada());
            TextBoxDatos.Text = "";
        }

        protected void OnDECPPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DECP.PageIndex = e.NewPageIndex;
            DECP.DataSource = dtDatosEntrada;
            DECP.DataBind();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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


        public static List<string> edDelGreggGrandeAlChiquitito(string hilera)
        {

            string[] descripcion = hilera.Split(new[] { "_" }, StringSplitOptions.None);
            string[] primeraDivision = descripcion[0].Split(new[] { ",[" }, StringSplitOptions.None);

            for (int i = 0; i < primeraDivision.Length; i++)
            {
                primeraDivision[i] = primeraDivision[i].Replace("[", "");
                primeraDivision[i] = primeraDivision[i].Replace("]", "");
            }
            List<string> regresa = new List<string>();
            for (int i = 0; i < primeraDivision.Length; i++)
            {
                if (primeraDivision[i].Contains("\""))
                {
                    string[] temp = primeraDivision[i].Split(new[] { "\"" }, StringSplitOptions.None);
                    regresa.Add(temp[0]);
                    regresa.Add(temp[1]);
                }
                else
                {
                    string[] temp = primeraDivision[i].Split(new[] { "," }, StringSplitOptions.None);
                    regresa.Add(temp[0]);
                    regresa.Add(temp[1]);
                }
            }

            //regresa.Add(descripcion[1]);
            return regresa;
        }
        public static string deLaBaseAGreggGrande(string hilera)
        {
            hilera = hilera.Replace("_", "");
            return hilera;
        }

        protected void llenarGridEntradaDatos(List<string> lista_datos)
        {
            // ejemplo de uso:
            //llenarGridEntradaDatos(edDelGreggGrandeAlChiquitito(@"[[V]""hilera"",[I]""hilera"",[V,1]]_h"));
            for (int i = 0; i < lista_datos.Count; i+=2)
            {
                DataRow row = dtDatosEntrada.NewRow();
                row["Tipo"] = lista_datos[i];
                row["Datos"] = lista_datos[i + 1];
                dtDatosEntrada.Rows.Add(row);
                DECP.DataSource = dtDatosEntrada;
                DECP.DataBind();
            }

        }


    }
}