﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;

//using System.IO;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.IO;


//using Spire.Doc;
//using Spire.Doc.Fields;
//using System.Drawing;
//using Spire.Doc.Documents;
//using Microsoft.Office.Interop;
//using Microsoft.Office.Interop.Word;

//using System.Configuration;


namespace SistemaPruebas.Intefaces
{
    public partial class InterfazReporte : System.Web.UI.Page
    {
        Controladoras.ControladoraReportes controladoraGR = new Controladoras.ControladoraReportes();
        DataTable dtGR = new DataTable();
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
            proyectoActualGR = "";
            modActualGR = "";
            reqActualGR = "";
            proyectoSeleccionado.Text = "";
            modSeleccionado.Text = "";
            reqSeleccionado.Text = "";

            //barraProgreso.Visible = false;

            // llenarGridPP();
        }
        /*
        dgExport.DataSource = ds;
dgExport.DataBind();
System.Web.HttpContext.Current.Response.Clear();
System.Web.HttpContext.Current.Response.Buffer = true;
System.Web.HttpContext.Current.Response.Charset = "";
System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=report.aspx" );

            dgExport.DataMember = dsResults.Tables[0].TableName;
dgExport.DataBind();
System.Web.HttpContext.Current.Response.Clear();
System.Web.HttpContext.Current.Response.Buffer = true;
//add line below
System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8 ;
//
System.Web.HttpContext.Current.Response.Charset = "";
System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=report.xls");
        */
        /*      private void ExportToWord()
              {
                  DataTable dt = GridGR.DataSource as DataTable;
                  if (dt.Rows.Count > 0)
                  {
                      string filename = "DownloadReport.docx";
                      System.IO.StringWriter tw = new System.IO.StringWriter();
                      System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                      DataGrid dgGrid = new DataGrid();
                      dgGrid.DataSource = dt;
                      dgGrid.DataBind();

                      dgGrid.RenderControl(hw);
                      Response.ContentType = "application/msword";
                      Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");

                      this.EnableViewState = false;
                      Response.Write(tw.ToString());
                      Response.End();
                  }
              }*/

        private void ExportToWord(DataTable dtGR)
        {
            //System.Data.DataTable dt = GridGR.DataSource as System.Data.DataTable;
            DataTable dt = dtGR;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    /*   string filename = "DownloadReport.docx";
                       System.IO.StringWriter tw = new System.IO.StringWriter();
                       System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                       DataGrid dgGrid = new DataGrid();
                       dgGrid.DataSource = dt;
                       dgGrid.DataBind();

                       //Get the HTML for the control.
                       dgGrid.RenderControl(hw);
                       //Write the HTML back to the browser.
                       Response.ContentType = "application/msword";
                       //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                       Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                       //Response.AddHeader("content-disposition", "attachment;  filename=Reporte.docx");
                       this.EnableViewState = false;

                       Response.Clear();
                       Response.Write(tw.ToString());
                       //WordPackage package = new ExcelPackage();
                       //Response.Buffer = true;
                       //Response.BinaryWrite(package.GetAsByteArray());
                       Response.Flush();
                       Response.End();*/
                    string filename = "Connectivity.doc";
                    if (filename != "")
                    {
                        string path = Server.MapPath("~/Downloads/" + filename);
                        System.IO.FileInfo file = new System.IO.FileInfo(path);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }
                        else
                        {
                            EtiqErrorGR.Text = "*Archivo no existe. ";
                            EtiqErrorGR.ForeColor = System.Drawing.Color.Salmon;
                            EtiqErrorGR.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
                        }
                    }
                }
            }
            else
            {
                EtiqErrorGR.Text = "*Si era null. ";
                EtiqErrorGR.ForeColor = System.Drawing.Color.Salmon;
                EtiqErrorGR.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
            }
        }


       /* public void crearDocTabla(System.Data.DataTable dt)
        {
            //Create Table
            int filas = dt.Rows.Count;// > 0;//System.Web.UI.WebControls.DataGridColumn row in GridPP.Rows)
            int columnas = dt.Columns.Count;
            Spire.Doc.Document doc = new Spire.Doc.Document();
            Spire.Doc.Section s = doc.AddSection();
            Spire.Doc.Table table = s.AddTable(true);

            //Create Header and Data
            String[] Header = new String[columnas];
            int count = 0;
            // foreach (System.Data.DataColumn dc in dt.Columns)
             //{
               //  Header[count]= Convert.ToString(dc[count]);
             //}
            String[][] data = new String[filas][];
            for (int x = 0; x < data.Length; x++)
            {
                data[x] = new String[columnas];
            }
            int cont1 = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int cont2 = 0;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (cont1 == 0)
                    {
                        Header[cont2] = Convert.ToString(dr[cont2]);
                        cont2 = cont2 + 1;
                    }
                    else if (cont1 != 0)
                    {
                        data[cont1][cont2] = Convert.ToString(dr[cont2]);
                        cont2 = cont2 + 1;
                    }
                }
                cont1 = cont1 + 1;
            }
            //Add Cells
            table.ResetCells(filas + 1, columnas);

            //Header Row
            Spire.Doc.TableRow FRow = table.Rows[0];
            FRow.IsHeader = true;

            //Row Height
            FRow.Height = 3;

            //Header Format
            FRow.RowFormat.BackColor = System.Drawing.Color.AliceBlue;

            for (int i = 0; i < Header.Length; i++)
            {
                //Cell Alignment
                Spire.Doc.Documents.Paragraph p = FRow.Cells[i].AddParagraph();
                FRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;

                //Data Format
                TextRange TR = p.AppendText(Header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 14;
                TR.CharacterFormat.TextColor = System.Drawing.Color.Teal;
                TR.CharacterFormat.Bold = true;
            }

            //Data Row
            Spire.Doc.TableRow DataRow = table.Rows[0];
            for (int r = 0; r < data.Length; r++)
            {
                DataRow = table.Rows[r];

                //Row Height
                DataRow.Height = 20;

                //C Represents Column.
                for (int c = 0; c < data[r].Length; c++)
                {

                    //Cell Alignment  
                    DataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;

                    //Fill Data in Rows
                    Spire.Doc.Documents.Paragraph p2 = DataRow.Cells[c].AddParagraph();
                    TextRange TR2 = p2.AppendText(data[r][c]);

                    //Format Cells  
                    p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                    TR2.CharacterFormat.FontName = "Calibri";
                    TR2.CharacterFormat.FontSize = 12;
                    TR2.CharacterFormat.TextColor = System.Drawing.Color.Brown;
                }
            }

            //Save and Launch
            doc.SaveToFile("C:\\Users\\b32896\\Downloads\\WordTable.docx");
            System.Diagnostics.Process.Start("C:\\Users\\b32896\\Downloads\\WordTable.docx");
        }
        */
        // Genera el reporte en Excel.
        protected void generarReporteExcel(object sender, EventArgs e)
        {

            ExcelPackage package = new ExcelPackage();
            package.Workbook.Worksheets.Add("Proyectos");
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            worksheet.Cells.Style.Font.Size = 12;
            worksheet.Cells.Style.Font.Name = "Calibri";

            // Poner un titulo.
            worksheet.Cells[1, 1].Value = "Reporte de proyectos " + DateTime.Today.ToString("(dd/MM/yyyy).");
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Font.Size = 14;

            // Rellenar los datos.
            int c = 1;
            int r = 2;
            // Poner el header.
            foreach (System.Web.UI.WebControls.TableCell cell in GridGR.HeaderRow.Cells)
            {
                worksheet.Cells[r, c++].Value = cell.Text;
            }
            // Dar formato al header.
            worksheet.Row(r).Style.Font.Bold = true;
            worksheet.Row(r).Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Row(r).Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
            r++;
            // Poner el resto de los datos.
            foreach (System.Web.UI.WebControls.TableRow row in GridGR.Rows)
            {
                c = 1;
                foreach (System.Web.UI.WebControls.TableCell cell in row.Cells)
                {
                    worksheet.Cells[r, c++].Value = HttpUtility.HtmlDecode(cell.Text);
                }
                // Coloreamos las filas.
                if (0 == r % 2)
                {
                    worksheet.Row(r).Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Row(r).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }
                r++;
            }

            // Ajustamos el ancho de las columnas.
            worksheet.DefaultColWidth = 10;
            worksheet.Cells.AutoFitColumns();

            Response.Clear();
            Response.Buffer = true;
            Response.BinaryWrite(package.GetAsByteArray());
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Reporte.xlsx");
            Response.Flush();
            Response.End();
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
            llenarGridMod("");
            llenarGridReq("", "");
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
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("Tipo de Archivo", Convert.ToString(0)));
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("Excel", Convert.ToString(1)));
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("Word", Convert.ToString(2)));
                this.DDLTipoArchivo.Items.Add(new System.Web.UI.WebControls.ListItem("PDF", Convert.ToString(3)));
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
        {
            bool[] proyecto = new bool[12];
            proyecto[0] = CheckBoxNombreProyecto.Checked;
            proyecto[1] = CheckBoxNombModulo.Checked;
            proyecto[2] = CheckBoxNombReq.Checked;
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






            if (proyectoActualGR != "")
            {
                modoGR = Convert.ToString(1);
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
                            if (controladoraGR.consultarRequerimientos(proyectoActualGR, dr.Cells[0].Text).Rows.Count > 0)
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





            }
            //DataTable dtr = controladoraGR.dtReporte(proyecto, proyectoActualGR, modActualGR, reqActualGR);
            //dtGR = dtr;
            //llenarGridGR(dtr);
            //modoGR = Convert.ToString(1);
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
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#D3F3EB';;this.style.color='black'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#84878e'";
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
                    proyectoSeleccionado.Text = ced;
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
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#D3F3EB';;this.style.color='black'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#84878e'";
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
                    modSeleccionado.Text = ced;
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
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#D3F3EB';;this.style.color='black'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#84878e'";
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
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#D3F3EB';;this.style.color='black'";
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
                    reqSeleccionado.Text = ced;
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
                        datos[i + 1] = objeto[j + 1].ToString();
                        row[i + 1] = datos[i + 1].ToString();
                        datos[i + 1] = row[i + 1];
                        datos[i + 2] = objeto[j + 2].ToString();
                        row[i + 2] = datos[i + 2].ToString();
                        datos[i + 2] = row[i + 2];
                        i += 3;
                    }
                }
                if (check.ID == "CheckBoxOficinaProyecto")
                    j += 2;
                j++;
            }


            dt.Rows.Add(datos);
            preGrid.DataSource = dt;
            preGrid.DataBind();
            dtGR = dt;
            return dt;

        }

        protected void BotonDescGR_Click(object sender, EventArgs e)
        {
            if (modoGR == Convert.ToString(1))
            {
                if (DDLTipoArchivo.SelectedItem.Text == "Tipo de Archivo")
                {

                }
                else if (DDLTipoArchivo.SelectedItem.Text == "Excel")
                {

                    generarReporteExcel(sender, e);


                }
                else if (DDLTipoArchivo.SelectedItem.Text == "Word")
                {
                    //System.Data.DataTable dtGR = GridGR.DataSource as System.Data.DataTable;
                    if (dtGR != null)
                    {
                        //ExportToWord(dtGR);
                        //crearDocTabla(dtGR);
                    }
                    else
                    {
                        EtiqErrorGR.Text = "*Es null !! ";
                        EtiqErrorGR.ForeColor = System.Drawing.Color.Salmon;
                        EtiqErrorGR.Visible = true;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
                    }


                }
                else if (DDLTipoArchivo.SelectedItem.Text == "PDF")
                {

                    exportarToPdf();
                }
            }
            else
            {
                EtiqErrorGR.Text = "*Antes de descargar el reporte, debe hacer la vista previa. ";
                EtiqErrorGR.ForeColor = System.Drawing.Color.Salmon;
                EtiqErrorGR.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
            }
        }

        /*
 * Requiere: Que el usuario de clic en el cancelar cuando le aparece el modal.
 * Modifica: Vuelve al estado en el que estaba antes de que el usuario haya intentado eliminar, modificar o insertar.
 * Retorna: N/A.      
*/
        protected void cancelarModal_Click(object sender, EventArgs e)
        {
            volverAlOriginal();
        }
        /*
         * Requiere: N/A. 
         * Modifica: N/A. 
         * Retorna: N/A.      
        */
        protected void siModalCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void exportarToPdf()
        {
            string nombreReporte = "Reporte Doroteos.pdf";


            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            var output = new System.IO.FileStream(Server.MapPath(nombreReporte), System.IO.FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();

            iTextSharp.text.Rectangle page = doc.PageSize;
            PdfPTable head = new PdfPTable(1);
            head.TotalWidth = page.Width;
            Phrase phrase = new Phrase("Reporte generado el: " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + " GMT", new iTextSharp.text.Font(iTextSharp.text.Font.COURIER, 8));
            PdfPCell c = new PdfPCell(phrase);
            c.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c.VerticalAlignment = Element.ALIGN_TOP;
            c.HorizontalAlignment = Element.ALIGN_CENTER;
            head.AddCell(c);
            //head.WriteSelectedRows(
            //     first/last row; -1 writes all rows
            //  0, -1,
            //     left offset
            //  0,
            //    / bottom** yPos of the table
            //  page.Height - doc.TopMargin + head.TotalHeight + 20,
            //  writer.DirectContent
            //);
            doc.Add(head);
            doc.AddCreationDate();

            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 24, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font boldFontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font normalCell = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL);

            doc.Add(new iTextSharp.text.Paragraph("Reporte de proyectos", boldFont));
            doc.Add(new iTextSharp.text.Paragraph(" ", boldFont));
            doc.Add(new iTextSharp.text.Paragraph(" ", boldFont));

            BaseFont fieldFontRoman = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font ff = new iTextSharp.text.Font(fieldFontRoman, 12, iTextSharp.text.Font.NORMAL);

            //pdfStamper.AcroFields.SetFieldProperty("PYN", "textfont", fieldFontRoman, null);

            /** Logo del reporte**/
            //var logo = iTextSharp.text.Image.GetInstance(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/orderedList5.png"));
            //logo.SetAbsolutePosition(430, 770);
            //logo.ScaleAbsoluteHeight(30);
            //logo.ScaleAbsoluteWidth(70);
            //doc.Add(logo);

            /*Se agregan datos de proyecto, en caso de ser seleccionado*/

            PdfPTable table = new PdfPTable(preGrid.Rows[0].Cells.Count);

            for (int i = 0; i < preGrid.Rows[0].Cells.Count; i++)
            {
                Phrase p = new Phrase(preGrid.HeaderRow.Cells[i].Text, ff);
                table.AddCell(p);
            }

            foreach (GridViewRow row in preGrid.Rows)
            {
                for (int i = 0; i < preGrid.Rows[0].Cells.Count; i++)
                {
                    Phrase p = new Phrase(row.Cells[i].Text, normalCell);
                    table.AddCell(p);
                }

            }

            doc.Add(table);

            //Se cierra documento
            doc.Close();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + nombreReporte + "','_newtab');", true);
        }
    }

}







/*
private void ExportGridToword()  
{  
Response.Clear();  
Response.Buffer = true;  
Response.ClearContent();  
Response.ClearHeaders();  
Response.Charset = "";  
string FileName = "Vithal" + DateTime.Now +".doc";  
StringWriter strwritter = new StringWriter();  
HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);        
Response.Cache.SetCacheability(HttpCacheability.NoCache);  
Response.ContentType ="application/msword";  
Response.AddHeader("Content-Disposition","attachment;filename=" + FileName);  
GridGR.GridLines = GridLines.Both;  
GridGR.HeaderStyle.Font.Bold = true;  
GridGR.RenderControl(htmltextwrtter);  
Response.Write(strwritter.ToString());  
Response.End();      

}  */
