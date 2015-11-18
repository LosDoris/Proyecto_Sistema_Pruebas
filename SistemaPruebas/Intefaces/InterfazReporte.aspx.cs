using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
        public static string disennoActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["disennoActualGR"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["disennoActualGR"] = value;
            }
        }
        public static string CPActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["CPActualGR"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["CPActualGR"] = value;
            }
        }
        public static string EPActualGR
        {
            get
            {
                object value = HttpContext.Current.Session["EPActualGR"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["EPActualGR"] = value;
            }
        }

        //Variables:
        //Metodos:
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restricciones_Campos();
            if (!IsPostBack)// ES SOLO LA PRIMERA VEZ
            {
                esAdminGR = Convert.ToString(true);
                llenarGridPP();
                llenarGridDP("");
                //llenarGridCP("");
                //llenarGridEP();
                //esAdminGR = controladoraGR.PerfilDelLogeado().ToString();
                if (Convert.ToBoolean(esAdminGR))
                {
                    //proyectoActual = controladoraGR.consultarIDProyMinimo().ToString();
                }
                else
                {
                    //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
                }
                volverAlOriginal();
            }
            if (Convert.ToBoolean(esAdminGR))
            {
                //proyectoActual = this.ProyectoAsociado.SelectedValue.ToString();
            }
            else
            {
                //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
            }
            //llenarGridPP();
            //llenarGridDP();
            //llenarGridCP();
            //llenarGridEP();
        }
        /*
         * Requiere: N/A.
         * Modifica: Vuelve al inicio de generar reportes.
         * Retorna: N/A.
         */
        protected void volverAlOriginal()
        {
            //deshabilitarCampos();

            /*
            deshabilitarPP();
            deshabilitarDP();
            deshabilitarCP();
            deshabilitarEP();
            */
            modoGR = Convert.ToString(0);
            if (!Convert.ToBoolean(esAdminGR))
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((controladoraRequerimiento.proyectosDelLoggeado()).ToString()).Selected = true;
            }
            else
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((proyectoActual).ToString()).Selected = true;
            }
            llenarGridPP();
            if (!Convert.ToBoolean(esAdminGR))
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((controladoraRequerimiento.proyectosDelLoggeado()).ToString()).Selected = true;
            }
            else
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((proyectoActual).ToString()).Selected = true;
            }
            llenarGridPP();
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
        protected void llenarGridDP(string nombProyecto)
        {
            DataTable disennoPrueba = crearTablaDP();
            DataTable dt = controladoraGR.consultarDisennos("Cursos");
            Object[] datos = new Object[4];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    datos[3] = dr[3];
                    disennoPrueba.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                disennoPrueba.Rows.Add(datos);
            }
            GridDP.DataSource = disennoPrueba;
            GridDP.DataBind();
        }
        protected void llenarGridCP(String idDisenno)
        {
            DataTable casosPrueba = crearTablaCP();
            DataTable dt =new DataTable();//= controladoraGR.consultarCasosPrueba(idDisenno);

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
            GridCP.DataSource = casosPrueba;
            GridCP.DataBind();
        }
        protected void llenarGridEP()
        {
            DataTable ejecicionPrueba = crearTablaEP();
            DataTable dt = controladoraGR.consultarDisennos("");

            Object[] datos = new Object[3];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    ejecicionPrueba.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                ejecicionPrueba.Rows.Add(datos);
            }
            GridEP.DataSource = ejecicionPrueba;
            GridEP.DataBind();
        }







        
        protected DataTable crearTablaPP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre del Proyecto.", typeof(String));
            dt.Columns.Add("Líder.", typeof(String));
            return dt;
        }
        protected DataTable crearTablaDP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Propósito", typeof(String));
            dt.Columns.Add("Nivel.", typeof(String));
            dt.Columns.Add("Tecnica.", typeof(String));
            dt.Columns.Add("Responsable.", typeof(String));
            return dt;
        }
        protected DataTable crearTablaCP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("Propósito", typeof(String));
            return dt;
        }
        protected DataTable crearTablaEP()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Diseño.", typeof(String));
            dt.Columns.Add("Responsable.", typeof(String));
            dt.Columns.Add("Fecha.", typeof(String));
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
        protected void deshabilitarDP()
        {
            CheckBoxCriteriosAceptacionDisenno.Enabled = false;
            CheckBoxFechAsignacionDisenno.Enabled = false;
            CheckBoxNivelDisenno.Enabled = false;
            CheckBoxProcedimientoDisenno.Enabled = false;
            CheckBoxPropositoDisenno.Enabled = false;
            CheckBoxReqDisenno.Enabled = false;
            CheckBoxResponsableDisenno.Enabled = false;
        }
        protected void deshabilitarCP()
        {
            CheckBoxEntraDatosCP.Enabled = false;
            CheckBoxFlujoCentralCP.Enabled = false;
            CheckBoxIDCP.Enabled = false;
            CheckBoxPropositoCP.Enabled = false;
            CheckBoxResultadoEsperadoCP.Enabled = false;
        }
        protected void deshabilitarEP()
        {
            CheckBoxEntraDatosEP.Enabled = false;
            CheckBoxFlujoCentralEP.Enabled = false;
            CheckBoxIDEP.Enabled = false;
            CheckBoxPropositoEP.Enabled = false;
            CheckBoxResultadoEsperadoEP.Enabled = false;
        }
        protected bool [] datosProy()
        {
            bool [] proyecto= new bool [7];
            proyecto [0]=CheckBoxNombreProyecto.Checked;
            proyecto [1]=CheckBoxFechAsignacionProyecto.Checked;
            proyecto [2]=CheckBoxOficinaProyecto.Checked;
            proyecto [3]=CheckBoxResponsableProyecto.Checked;
            proyecto [4]=CheckBoxObjetivoProyecto.Checked;
            proyecto [5]=CheckBoxEstadoProyecto.Checked;
            proyecto [6]=CheckBoxMiembrosProyecto.Checked;

            return proyecto;
        }
        protected bool[] datosDisenno()
        {
            bool[] disenno = new bool[7];
            disenno[0] = CheckBoxReqDisenno.Checked;
            disenno[1] = CheckBoxNivelDisenno.Checked;
            disenno[2] = CheckBoxCriteriosAceptacionDisenno.Checked;
            disenno[3] = CheckBoxFechAsignacionDisenno.Checked;
            disenno[4] = CheckBoxPropositoDisenno.Checked;
            disenno[5] = CheckBoxProcedimientoDisenno.Checked;
            disenno[6] = CheckBoxResponsableDisenno.Checked;

            return disenno;
        }
        protected bool[] datosCasos()
        {
            bool[] casos = new bool[7];
            casos[0] = CheckBoxReqDisenno.Checked;
            casos[1] = CheckBoxNivelDisenno.Checked;
            casos[2] = CheckBoxCriteriosAceptacionDisenno.Checked;
            casos[3] = CheckBoxFechAsignacionDisenno.Checked;
            casos[4] = CheckBoxPropositoDisenno.Checked;
            casos[5] = CheckBoxProcedimientoDisenno.Checked;
            casos[6] = CheckBoxResponsableDisenno.Checked;

            return casos;
        }
        protected bool[] datosEjecucion()
        {
            bool[] ejecucion = new bool[7];
            ejecucion[0] = CheckBoxReqDisenno.Checked;
            ejecucion[1] = CheckBoxNivelDisenno.Checked;
            ejecucion[2] = CheckBoxCriteriosAceptacionDisenno.Checked;
            ejecucion[3] = CheckBoxFechAsignacionDisenno.Checked;
            ejecucion[4] = CheckBoxPropositoDisenno.Checked;
            ejecucion[5] = CheckBoxProcedimientoDisenno.Checked;
            ejecucion[6] = CheckBoxResponsableDisenno.Checked;

            return ejecucion;
        }
        protected void BotonGE_Click(object sender, EventArgs e)
        {
            //revisar como se llaman los metodos de la controladora.
            bool[] ejecucion = datosEjecucion();
            bool[] disenno = datosDisenno();
            bool[] proyecto = datosProy();
            bool[] casos = datosCasos();
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
            ///llenarDatosRequerimiento(ced);
            //habilitarGrid();
        }




        protected void DP_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridDP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
        */
        protected void DP_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDP.PageIndex = e.NewPageIndex;
            this.llenarGridDP("");//PONER EL PROYECTO SELECCIONADO
        }
        protected void DP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridDP.SelectedRow.RowIndex;
            String ced = GridDP.SelectedRow.Cells[0].Text;
            ///llenarDatosRequerimiento(ced);
            //habilitarGrid();
        }
        protected void CP_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridCP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
        */
        protected void CP_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridCP.PageIndex = e.NewPageIndex;
            this.llenarGridCP("");
        }
        protected void CP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridCP.SelectedRow.RowIndex;
            String ced = GridCP.SelectedRow.Cells[0].Text;
            ///llenarDatosRequerimiento(ced);
            //habilitarGrid();
        }
        protected void EP_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridEP, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
        */
        protected void EP_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridEP.PageIndex = e.NewPageIndex;
            this.llenarGridEP();
        }
        protected void EP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridEP.SelectedRow.RowIndex;
            String ced = GridEP.SelectedRow.Cells[0].Text;
            ///llenarDatosRequerimiento(ced);
            //habilitarGrid();
        }
    }
    
}












