﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazReporte : System.Web.UI.Page
    {
        Controladoras.ControladoraReportes controladoraGR = new Controladoras.ControladoraReportes();
        public static string modoGR
        {
            get
            {
                object value = HttpContext.Current.Session["modoGR"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["modoGR"] = value;
            }
        }

        public static string idViejoGR
        {
            get
            {
                object value = HttpContext.Current.Session["idViejoGR"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["idViejoGR"] = value;
            }
        }

        public static string esAdminGR
        {
            get
            {
                object value = HttpContext.Current.Session["esAdminGR"];
                return value == null ? "false" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["esAdminGR"] = value;
            }
        }

        public static string proyectoActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["proyectoActualGR"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["proyectoActualGR"] = value;
            }
        }
        public static string modActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["modActualGR"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["modActualGR"] = value;
            }
        }
        public static string reqActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["reqActualGR"];
                return value == null ? "" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["reqActualGR"] = value;
            }
        }
        public static string PPindexViejo
        {
            get
            {
                object value = HttpContext.Current.Session["PPindexViejo"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["PPindexViejo"] = value;
            }
        }
        //Variables:
        //Metodos:
        protected void Page_Load(object sender, EventArgs e)
        {
            //GridPP.ControlStyle.
            //Restricciones_Campos();
            if (!IsPostBack)// ES SOLO LA PRIMERA VEZ
            {
                volverAlOriginal();
                llenarGridPP();
                llenarGridMod("");
                llenarGridReq("", "");
                DataTable dt = new DataTable();
                dt.Columns.Add("Nombre del Requerimiento.", typeof(String));
                //llenarGridGR(dt);
                llenarDDArchivo();
            }
        }
        /*
         * Requiere: N/A.
         * Modifica: Vuelve al inicio de generar reportes.
         * Retorna: N/A.
         */
        protected void volverAlOriginal()
        {

            modoGR = Convert.ToString(0);
            CheckBoxNombReq.Checked = true;
            CheckBoxNombModulo.Checked = true;
            CheckBoxNombreProyecto.Checked = true;
            llenarGridPP();
            //barraProgreso.Visible = false;

            // llenarGridPP();
        }
        protected void llenarGridPP()
        {

            DataTable dtGrid = crearTablaPP();
            DataTable dt = controladoraGR.consultarProyecto();
            Object[] datos = new Object[2];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[1];
                    datos[1] = dr[2];
                    dtGrid.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                dtGrid.Rows.Add(datos);
            }
            GridPP.DataSource = dtGrid;
            GridPP.DataBind();
        }
        protected DataTable crearTablaPP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre del Proyecto.", typeof(String));
            dt.Columns.Add("        Líder.      ", typeof(String));
            //Nombre del Proyecto.
            //"        Líder.      "
            return dt;
        }



        protected void llenarGridMod(String nomProyecto)
        {

            DataTable dtGrid = crearTablaMod();
            DataTable dt = controladoraGR.consultarModulos(nomProyecto);
            Object[] datos = new Object[1];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    dtGrid.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                dtGrid.Rows.Add(datos);
            }
            GridMod.DataSource = dtGrid;
            GridMod.DataBind();
        }
        /*
         * Requiere: N/A.
         * Modifica: Llena el dropdownlist del tipo de Archivo.
         * Retorna: N/A.
         */
        protected void llenarDDArchivo()
        {
            this.DDLTipoArchivo.Items.Clear();

            try
            {
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("Tipo de Archivo", Convert.ToString( 0)));
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("Excel", Convert.ToString(1)));
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("PDF", Convert.ToString(2)));
            }
            catch (Exception e)
            {
            }

            }
        
        protected DataTable crearTablaMod()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("       Módulo.      ", typeof(String));
            //"        Líder.      "
            //"       Módulo.      "
            return dt;
        }



        protected void llenarGridReq(String nomProyecto, String nomModulo)
        {

            DataTable dtGrid = crearTablaReq();
            DataTable dt = controladoraGR.consultarRequerimientos(nomProyecto, nomModulo);
            //Object[] datos = new Object[2];
            Object[] datos = new Object[1];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    // datos[1] = dr[2];
                    dtGrid.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                // datos[1] = "-";
                dtGrid.Rows.Add(datos);
            }
            GridReq.DataSource = dtGrid;
            GridReq.DataBind();
        }

        protected void llenarGridGR(DataTable dt)
        {

            //DataTable dtGrid = crearTablaReq();
            //DataTable dt = controladoraGR.consultarRequerimientos(nomProyecto, nomModulo);
            //Object[] datos = new Object[2];
            Object[] datos = new Object[1];


            if (dt.Rows.Count > 0)
            {
               /* foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    // datos[1] = dr[2];
                    dt.Rows.Add(datos);
                }*/
            }
            else
            {
                datos[0] = "-";
                // datos[1] = "-";
                dt.Rows.Add(datos);
            }
            GridGR.DataSource = dt;
            GridGR.DataBind();
        }

        protected DataTable crearTablaReq()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre del Requerimiento.", typeof(String));
            return dt;
        }

        protected void deshabilitarPP()
        {
            CheckBoxEstadoProyecto.Enabled = false;
            CheckBoxFechAsignacionProyecto.Enabled = false;
            CheckBoxMiembrosProyecto.Enabled = false;
            CheckBoxNombreProyecto.Enabled = false;
            CheckBoxObjetivoProyecto.Enabled = false;
            CheckBoxOficinaProyecto.Enabled = false;
            CheckBoxResponsableProyecto.Enabled = false;
            CheckBoxCantNoConf.Enabled = false;
            CheckBoxExitos.Enabled = false;
            CheckBoxNombModulo.Enabled = false;
            CheckBoxTipoNoConf.Enabled = false;
            CheckBoxNombReq.Enabled = false;
        }


        protected bool[] datosProy()
        {/*
                    &nbsp;<asp:CheckBox ID="CheckBoxNombreProyecto" runat="server" Text="Nombre sistema."/>

                    &nbsp;<asp:CheckBox ID="CheckBoxNombModulo" runat="server" Text="Nombre módulo."/>

                    &nbsp;<asp:CheckBox ID="CheckBoxNombReq" runat="server" Text="Nombre requerimiento."/>

                            &nbsp;<asp:CheckBox ID="CheckBoxFechAsignacionProyecto" runat="server" Text="Fecha de asignacion." />

                        &nbsp;<asp:CheckBox ID="CheckBoxOficinaProyecto" runat="server" Text="Datos de oficina usuaria." />

                        &nbsp;<asp:CheckBox ID="CheckBoxResponsableProyecto" runat="server" Text="Líder." />

                            &nbsp;<asp:CheckBox ID="CheckBoxObjetivoProyecto" runat="server" Text="Objetivo general." />

                        &nbsp;<asp:CheckBox ID="CheckBoxEstadoProyecto" runat="server" Text="Estado" />

                        &nbsp;<asp:CheckBox ID="CheckBoxMiembrosProyecto" runat="server" Text="Miembros de equipo asociados." />

                            &nbsp;<asp:CheckBox ID="CheckBoxExitos" runat="server" Text="Cantidad éxitos." />

                        &nbsp;<asp:CheckBox ID="CheckBoxTipoNoConf" runat="server" Text="Tipos no conformidades." />

                        &nbsp;<asp:CheckBox ID="CheckBoxCantNoConf" runat="server" Text="Cantidad no conformidades." />

            
            
            */
            bool[] proyecto = new bool[12];
            proyecto[0] = CheckBoxNombreProyecto.Checked;
            proyecto[1]= CheckBoxNombModulo.Checked;
            proyecto[2]= CheckBoxNombReq.Checked;
            proyecto[3] = CheckBoxFechAsignacionProyecto.Checked;
            proyecto[4] = CheckBoxOficinaProyecto.Checked;
            proyecto[5] = CheckBoxResponsableProyecto.Checked;
            proyecto[6] = CheckBoxObjetivoProyecto.Checked;
            proyecto[7] = CheckBoxEstadoProyecto.Checked;
            proyecto[8] = CheckBoxMiembrosProyecto.Checked;
            proyecto[9] = CheckBoxExitos.Checked;
            proyecto[10] = CheckBoxTipoNoConf.Checked;
            proyecto[11] = CheckBoxCantNoConf.Checked;

            return proyecto;
        }

        protected void BotonGE_Click(object sender, EventArgs e)
        {
            //revisar como se llaman los metodos de la controladora.

            bool[] proyecto = datosProy();
            CheckBox[] checks = { CheckBoxNombreProyecto, CheckBoxObjetivoProyecto, CheckBoxFechAsignacionProyecto, CheckBoxEstadoProyecto, CheckBoxOficinaProyecto, CheckBoxResponsableProyecto, CheckBoxMiembrosProyecto, CheckBoxNombModulo, CheckBoxNombReq, CheckBoxExitos, CheckBoxCantNoConf, CheckBoxTipoNoConf };



            //string nombreReporte = "Reporte Doroteos.pdf";
            //Document doc = new Document(PageSize.LETTER);
            //var output = new System.IO.FileStream(Server.MapPath(nombreReporte), System.IO.FileMode.Create);
            //var writer = PdfWriter.GetInstance(doc, output);
            //doc.Open();

            //Rectangle page = doc.PageSize;
            //PdfPTable head = new PdfPTable(1);
            //head.TotalWidth = page.Width;
            //Phrase phrase = new Phrase("Reporte generado el: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " GMT", new Font(Font.COURIER, 8));
            //PdfPCell c = new PdfPCell(phrase);
            //c.Border = Rectangle.NO_BORDER;
            //c.VerticalAlignment = Element.ALIGN_TOP;
            //c.HorizontalAlignment = Element.ALIGN_CENTER;
            //head.AddCell(c);
            //head.WriteSelectedRows(
            //    // first/last row; -1 writes all rows
            //  0, -1,
            //    // left offset
            //  0,
            //    / bottom** yPos of the table
            //  page.Height - doc.TopMargin + head.TotalHeight + 20,
            //  writer.DirectContent
            //);
            //doc.AddCreationDate();

            ///** Logo del reporte**/
            ////var logo = iTextSharp.text.Image.GetInstance(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/orderedList5.png"));
            ////logo.SetAbsolutePosition(430, 770);
            ////logo.ScaleAbsoluteHeight(30);
            ////logo.ScaleAbsoluteWidth(70);
            ////doc.Add(logo);

            //Se agregan datos de proyecto, en caso de ser seleccionado*/


            if (proyectoActualGR != "")
            {
                DataTable dt = headerPreGrid(checks);
                List<Object> proyectoDatos = controladoraGR.reporteProyecto(controladoraGR.consultarProyecto(proyectoActualGR));
                if (GridMod.SelectedIndex != -1)//Un módulo
                {
                    proyectoDatos.Add(modActualGR);
                    if (GridReq.SelectedIndex != -1)//Un solo requerimiento
                    {
                        proyectoDatos = controladoraGR.medicionRequerimiento(proyectoDatos, reqActualGR);
                        ProyectoPreGrid(proyectoDatos, dt, checks);
                    }

                    else//Todos los requerimientos de un módulo
                    {
                        if (checks[7].Checked || checks[8].Checked || checks[9].Checked || checks[10].Checked)
                        {
                           
                            foreach (GridViewRow id in GridReq.Rows)
                            {
                                List<Object> comodin = new List<object>(proyectoDatos);
                                comodin = controladoraGR.medicionRequerimiento(comodin, id.Cells[0].Text);
                                ProyectoPreGrid(comodin, dt, checks);
                                //comodin.Clear();
                            }
                        }
                        else
                            ProyectoPreGrid(proyectoDatos, dt, checks);
                    }
                }

                else//Todos los módulos de un proyecto
                {
                    foreach (GridViewRow dr in GridMod.Rows)                    
                    {
                        List<Object> comodin = new List<object>(proyectoDatos);
                        comodin.Add(dr.Cells[0].Text);
                        if (checks[7].Checked || checks[8].Checked || checks[9].Checked || checks[10].Checked)
                        {
                            if (controladoraGR.consultarRequerimientos(proyectoActualGR, dr.Cells[0].Text) = null)
                            {
 
                            }
                            else
                            {
                                foreach (DataRow id in controladoraGR.consultarRequerimientos(proyectoActualGR, dr.Cells[0].Text).Rows)
                                {
                                    List<Object> comodinReq = new List<object>(comodin);
                                    comodinReq = controladoraGR.medicionRequerimiento(comodinReq, id[0].ToString());
                                    ProyectoPreGrid(comodinReq, dt, checks);
                                }
                            }
                        }
                        else
                            ProyectoPreGrid(comodin, dt, checks);
                    }
                }

               // DataTable dtr = controladoraGR.dtReporte(proyecto, proyectoActualGR, modActualGR, reqActualGR);
                //llenarGridGR(dtr);


                ///*Se cierra documento*/
                //doc.Close();

                //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + nombreReporte + "','_newtab');", true);
            }
        }




        /*
         * Requiere: El evento de enlazar información de un datatable con el grid
         * Modifica: Establece el comportamiento del grid ante los diferentes eventos.
         * Retorna: N/A.
         */
        protected void PP_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridPP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
        */
        protected void PP_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridPP.PageIndex = e.NewPageIndex;
            this.llenarGridPP();
        }
        protected void PP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridPP.SelectedRow.RowIndex;
            String ced = GridPP.SelectedRow.Cells[0].Text;
            if (ced != "-")
            {
                if (proyectoActualGR != ced.ToString())
                {
                    proyectoActualGR = ced.ToString();
                    reqActualGR = "";
                    modActualGR = "";
                    llenarGridMod(ced);
                    llenarGridReq("", "");
                    proyectoSeleccionado.Text = " El proyecto seleccionado es:  " + ced;
                }
            }
        }
        /*
         * Requiere: El evento de enlazar información de un datatable con el grid
         * Modifica: Establece el comportamiento del grid ante los diferentes eventos.
         * Retorna: N/A.
         */
        protected void Mod_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridMod, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
         */
        protected void Mod_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridMod.PageIndex = e.NewPageIndex;
            //this.llenarGridMod();
        }





        protected void Mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ced = GridMod.SelectedRow.Cells[0].Text;
            if (ced != "-")
            {
                if (modActualGR != ced.ToString())
                {
                    modActualGR = ced.ToString();
                    reqActualGR = "";
                    llenarGridReq(proyectoActualGR, modActualGR);
                    modSeleccionado.Text = " El módulo seleccionado es:  " + ced;
                }
            }
        }




        /*
         * Requiere: El evento de enlazar información de un datatable con el grid
         * Modifica: Establece el comportamiento del grid ante los diferentes eventos.
         * Retorna: N/A.
         */
        protected void Req_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridReq, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
         */
        protected void Req_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridReq.PageIndex = e.NewPageIndex;
            //this.llenarGridMod();
        }


        /*
        * Requiere: El evento de enlazar información de un datatable con el grid
        * Modifica: Establece el comportamiento del grid ante los diferentes eventos.
        * Retorna: N/A.
        */
        protected void Reporte_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridGR, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
         */
        protected void Reporte_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridGR.PageIndex = e.NewPageIndex;
            //this.llenarGridMod();
        }




        protected void Reporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridGR.SelectedRow.RowIndex;
            String ced = GridGR.SelectedRow.Cells[0].Text;
        }






        protected void Req_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridReq.SelectedRow.RowIndex;
            String ced = GridReq.SelectedRow.Cells[0].Text;
            if (ced != "-")
            {

                if (reqActualGR != ced.ToString())
                {
                    reqActualGR = ced.ToString();
                    reqSeleccionado.Text = "El requerimiento seleccionado es:  " + ced;
                }
            }
        }

        protected void CheckBoxNombreProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxNombreProyecto.Checked)
            {
                BoundField test = new BoundField();
                test.DataField = sender.ToString();
                test.HeaderText = sender.ToString();
                preGrid.Columns.Add(test);
                

            }
        }

        protected DataTable headerPreGrid(CheckBox[] checks)
        {
             DataTable dt = new DataTable();
             foreach (CheckBox check in checks)
             {
                 if (check.Checked)
                 {
                     if (check.ID != "CheckBoxOficinaProyecto")
                         dt.Columns.Add(check.Text, typeof(String));
                     else
                     {
                         dt.Columns.Add("Oficina del representate", typeof(String));
                         dt.Columns.Add("Teléfono del representante", typeof(String));
                         dt.Columns.Add("Nombre del usuario representate", typeof(String));
                     }
                 }
                    
             }
           
            return dt;
        }

        protected DataTable ProyectoPreGrid(List<Object> objeto, DataTable dt, CheckBox[] checks)
        {
           
            object[] datos = new object[dt.Columns.Count];

           

            DataRow row = dt.NewRow();
            int i = 0;
            int j = 0;
            foreach (CheckBox check in checks)
            {
                if (check.Checked)
                {
                    if (check.ID != "CheckBoxOficinaProyecto")
                    {
                    datos[i] = objeto[j].ToString();
                    row[i] = datos[i].ToString();
                    datos[i] = row[i];
                    i++;
                    }
                    else
                    {
                        datos[i] = objeto[j].ToString();
                        row[i] = datos[i].ToString();
                        datos[i] = row[i];
                        datos[i+1] = objeto[j+1].ToString();
                        row[i+1] = datos[i+1].ToString();
                        datos[i+1] = row[i+1];
                        datos[i+2] = objeto[j+2].ToString();
                        row[i+2] = datos[i+2].ToString();
                        datos[i+2] = row[i+2];                    
                        i += 3;                       
                    }
                }
                 if (check.ID == "CheckBoxOficinaProyecto")
                     j+=2;
                j++;
            }


            dt.Rows.Add(datos);          
            preGrid.DataSource = dt;
            preGrid.DataBind();
            return dt;

        }
    }

}