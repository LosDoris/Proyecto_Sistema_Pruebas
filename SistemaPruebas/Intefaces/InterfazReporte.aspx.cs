using System;
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

            llenarGridPP();

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


        }
        protected bool[] datosProy()
        {
            bool[] proyecto = new bool[10];
            proyecto[0] = CheckBoxNombreProyecto.Checked;
            proyecto[1] = CheckBoxFechAsignacionProyecto.Checked;
            proyecto[2] = CheckBoxOficinaProyecto.Checked;
            proyecto[3] = CheckBoxResponsableProyecto.Checked;
            proyecto[4] = CheckBoxObjetivoProyecto.Checked;
            proyecto[5] = CheckBoxEstadoProyecto.Checked;
            proyecto[6] = CheckBoxMiembrosProyecto.Checked;
            proyecto[7] = CheckBoxExitos.Checked;
            proyecto[8] = CheckBoxTipoNoConf.Checked;
            proyecto[9] = CheckBoxCantNoConf.Checked;

            return proyecto;
        }

        protected void BotonGE_Click(object sender, EventArgs e)
        {
            //revisar como se llaman los metodos de la controladora.

            bool[] proyecto = datosProy();
            CheckBox[] checks = { CheckBoxNombreProyecto, CheckBoxObjetivoProyecto, CheckBoxFechAsignacionProyecto, CheckBoxEstadoProyecto, CheckBoxOficinaProyecto, CheckBoxResponsableProyecto, CheckBoxResponsableProyecto, CheckBoxExitos, CheckBoxCantNoConf, CheckBoxTipoNoConf };        


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
            //    // ** bottom** yPos of the table
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

            ///*Se agregan datos de proyecto, en caso de ser seleccionado*/

            if (proyectoActualGR != "")
            {

                //PdfPTable retorno = controladoraGR.reporteProyecto(proyecto);
                //doc.Add(controladoraGR.reporteProyecto(controladoraGR.consultarProyecto(proyectoActualGR), retorno, proyecto));

                DataTable dt = headerPreGrid(checks);
                object[] proyectoDatos = controladoraGR.reporteProyecto(controladoraGR.consultarProyecto(proyectoActualGR));
                ProyectoPreGrid(proyectoDatos, dt, checks);




            }

          

            ///*Se cierra documento*/
            //doc.Close();
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + nombreReporte + "','_newtab');", true);
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

        protected DataTable ProyectoPreGrid(object[] objeto, DataTable dt, CheckBox[] checks)
        {

            int count = 0;
            foreach(CheckBox check in checks)
            {
                if (check.Checked)
                    count++;
            }


            
            object[] datos = new object[count];
            DataRow row = dt.NewRow();
            int i = 0;
            int j = 0;
            foreach (CheckBox check in checks)
            {
                if (check.Checked)
                {
                    datos[i] = objeto[j].ToString();
                    row[i] = datos[i].ToString();
                    datos[i] = row[i];
                    i++;
                }
                j++;
            }


            dt.Rows.Add(datos);          
            preGrid.DataSource = dt;
            preGrid.DataBind();
            return dt;

        }
    }

}