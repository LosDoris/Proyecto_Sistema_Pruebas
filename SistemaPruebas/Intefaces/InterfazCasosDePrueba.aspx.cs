﻿using System;
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

        public static String idMod
        {
            get
            {
                object value = HttpContext.Current.Session["idmod"];
                return value == null ? "" : (String)value;
            }
            set
            {
                HttpContext.Current.Session["idmod"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                inicializarModo();
                inicializarDTDatosEntrada();
                estadoInicial();
            }
                llenarGrid();
        }

        protected void estadoInicial()
        {
            ocultarErroresDeOperacion();
            botonesInicio();
            deshabilitarCampos();
            limpiarCampos();
        }

        protected void estadoPostOperacion()
        {
            modo = 0;
            deshabilitarCampos();
            habilitarGrid(ref CP);
            BotonCPInsertar.Enabled = true;
            BotonCPModificar.Enabled = true;
            BotonCPEliminar.Enabled = true;
            BotonCPCancelar.Enabled = false;
            BotonCPAceptar.Enabled = false;
        }

        protected void estadoInsertar()
        {
            marcarBoton(ref BotonCPInsertar);
            limpiarCampos();
            habilitarCampos();
            BotonCPAceptar.Enabled = true;
            BotonCPCancelar.Enabled = true;
            BotonCPModificar.Enabled = false;
            BotonCPEliminar.Enabled = false;
            deshabilitarGrid(ref CP);
        }

        protected void estadoModificar()
        {
            marcarBoton(ref BotonCPModificar);
            habilitarCampos();
            BotonCPAceptar.Enabled = true;
            BotonCPCancelar.Enabled = true;
            BotonCPInsertar.Enabled = false;
            BotonCPEliminar.Enabled = false;
            deshabilitarGrid(ref CP);
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
            habilitarGrid(ref CP);
        }

        protected void deshabilitarCampos()
        {
            TextBoxID.Enabled = false;
            TextBoxPropositoCP.Enabled  = false;
            TextBoxResultadoCP.Enabled  = false;
            TextBoxFlujoCentral.Enabled = false;
            deshabilitarCamposEntrada();
          //  deshabilitarGrid(ref CP);
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
            deshabilitarGrid(ref DECP);
        }

        protected void habilitarCamposEntrada()
        {
            TextBoxDatos.Enabled = true;
            TextBoxDescripcion.Enabled = true;
            TipoEntrada.Enabled = true;
            AgregarEntrada.Enabled = true;
            habilitarGrid(ref DECP);
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

        protected void llenarGrid()        //se encarga de llenar el grid cada carga de pantalla
        {
            DataTable casosPrueba = crearTablaCP();
            DataTable dt = controladoraCasosPrueba.consultarCasosPrueba(1,""); // en consultas tipo 1, no se necesita la cédula
            
            Object[] datos = new Object[2];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    casosPrueba.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
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
            return dt;
        }

        void llenarDatosCasoPrueba(String id)
        {
            DataTable dt = controladoraCasosPrueba.consultarCasosPrueba(2, id); // Consulta tipo 2, para llenar los campos de un recurso humano
           // Response.Write("Longitud = " + dt.Rows.Count);
            BotonCPEliminar.Enabled = true;
            BotonCPModificar.Enabled = true;
            try
            {
                TextBoxID.Text = dt.Rows[0].ItemArray[0].ToString();
                TextBoxPropositoCP.Text = dt.Rows[0].ItemArray[1].ToString();            
                TextBoxResultadoCP.Text = dt.Rows[0].ItemArray[3].ToString();
                TextBoxFlujoCentral.Text = dt.Rows[0].ItemArray[4].ToString();
                String datosEntrada = dt.Rows[0].ItemArray[2].ToString();
                //datosEntrada = datosEntrada.Replace("_"," ");
                llenarGridEntradaDatos(transformarDatosEntrada(datosEntrada));
          
            }
            catch
            {
                EtiqErrorConsultar.Visible = true;
            }
            //Response.Write(dt.Rows.Co)

        }

        protected  List<String> transformarDatosEntrada(String hilera)
        {
            if (hilera=="N/A"){
                List<String> regresa = new List<String>();
                regresa.Add(hilera);
                return regresa;
            }
            else
            {
                String[] descripcion = hilera.Split(new[] { "_" }, StringSplitOptions.None);
                String[] primeraDivision = descripcion[0].Split(new[] { ",[" }, StringSplitOptions.None);

                for (int i = 0; i < primeraDivision.Length; i++)
                {
                    primeraDivision[i] = primeraDivision[i].Replace("[", "");
                    primeraDivision[i] = primeraDivision[i].Replace("]", "");
                }
                List<String> regresa = new List<String>();
                for (int i = 0; i < primeraDivision.Length; i++)
                {
                    if (primeraDivision[i].Contains("\""))
                    {
                        String[] temp = primeraDivision[i].Split(new[] { "\"" }, StringSplitOptions.None);
                        regresa.Add(temp[0]);
                        regresa.Add(temp[1]);
                    }
                    else
                    {
                        String[] temp = primeraDivision[i].Split(new[] { "," }, StringSplitOptions.None);
                        regresa.Add(temp[0]);
                        regresa.Add(temp[1]);
                    }
                }

                regresa.Add(descripcion[1]);
                return regresa;
            }

            
        }

        protected void llenarGridEntradaDatos(List<String> lista_datos)
        {
            dtDatosEntrada.Clear();
            DECP.DataSource = dtDatosEntrada;
            DECP.DataBind();
            for (int i = 0; i < lista_datos.Count - 1; i+=2)
            {
                DataRow row = dtDatosEntrada.NewRow();
                if (lista_datos[i] == "V")
                {
                    row["Tipo"] = "Válido";
                }
                else if (lista_datos[i] == "I")
                {
                    row["Tipo"] = "Inválido";
                }
                //row["Tipo"] = lista_datos[i];

                if (Regex.IsMatch(lista_datos[i + 1], @"\d+"))
                {
                    row["Datos"] = lista_datos[i + 1];
                }
                else
                {
                    row["Datos"] = "\"" + lista_datos[i + 1] + "\"";
                }
                
                //row["Datos"] = lista_datos[i + 1];
                dtDatosEntrada.Rows.Add(row);
                DECP.DataSource = dtDatosEntrada;
                DECP.DataBind();
            }
            TextBoxDescripcion.Text = lista_datos[lista_datos.Count - 1];
        }

        protected void deshabilitarGrid(ref GridView grid)
        {
            grid.Enabled = false;
            foreach (GridViewRow row in grid.Rows)
            {
                row.Attributes.Remove("onclick");
                row.Attributes.Remove("onmouseover");
                row.Attributes.Remove("style");
                row.Attributes.Remove("onmouseout");
            }
        }

        protected void habilitarGrid(ref GridView grid)
        {
            grid.Enabled = true;
            foreach (GridViewRow row in grid.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grid, "Select$" + row.RowIndex);
                row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                row.Attributes["style"] = "cursor:pointer";
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
            modo = 1;
            estadoInsertar();
        }

        protected void BotonCPModificar_Click(object sender, EventArgs e)
        {
            modo = 2;
            idMod = TextBoxID.Text;
            estadoModificar();
        }

        protected void BotonCPEliminar_Click(object sender, EventArgs e)
        {
            int eliminacion = controladoraCasosPrueba.eliminarCasosPrueba(TextBoxID.Text);

            if (eliminacion == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido eliminado con éxito');", true);//esto es temporal hasta aprender a usar los modales
                estadoPostOperacion();
            }
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
                desmarcarBoton(ref BotonCPModificar);
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
            datosNuevos[5] = 1; //recordar modificar cuando se tenga el id del diseño

            int operacion = -1;
            if(modo == 1)
            {
                datosNuevos[6] = "";
                operacion = controladoraCasosPrueba.insertarCasosPrueba(datosNuevos);
            }
            else if( modo == 2)
            {
                datosNuevos[6] = idMod;
                operacion = controladoraCasosPrueba.modificarCasosPrueba(datosNuevos);
            }
            if (operacion == 1)
            {
                Response.Write("Se insertó con éxito"); //temporal hasta que haya modal
                llenarGrid();
                estadoPostOperacion();
            }


            Response.Write("Resultado "+operacion);
            Response.Write(modo);

        }

        protected void AgregarEntrada_Click(object sender, EventArgs e)
        {
            agregarGridEntradaDatos();
            Response.Write( datosEntrada());
            TextBoxDatos.Text = "";
        }

        protected void EliminarEntrada_Click(object sender, EventArgs e)
        {
            for (int i = dtDatosEntrada.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtDatosEntrada.Rows[i];
                if (i == DECP.SelectedIndex)
                {
                    dr.Delete();
                }
                DECP.DataSource = dtDatosEntrada;
                DECP.DataBind();
            }
            EliminarEntrada.Enabled = false;
        }

        protected void CP_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = CP.SelectedRow.Cells[0].Text;
            llenarDatosCasoPrueba(id);
        }

        protected void OnCPRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(CP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnCPPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CP.PageIndex = e.NewPageIndex;
            this.llenarGrid();
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

        protected void OnDECPPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DECP.PageIndex = e.NewPageIndex;
            DECP.DataSource = dtDatosEntrada;
            DECP.DataBind();
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

        protected void aceptarModal_Click(object sender, EventArgs e)
        {

        }

        protected void cancelarModal_Click(object sender, EventArgs e)
        {

        }
    }
}