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
        public static string modoGE
        {
            get
            {
                object value = HttpContext.Current.Session["modoREQ"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["modoREQ"] = value;
            }
        }

        public static string idViejoGE
        {
            get
            {
                object value = HttpContext.Current.Session["id_modificando"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_modificando"] = value;
            }
        }

        public static string esAdminGE
        {
            get
            {
                object value = HttpContext.Current.Session["esAdminREQ"];
                return value == null ? "false" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["esAdminREQ"] = value;
            }
        }

        //Variables:
        //Metodos:
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restricciones_Campos();
            if (!IsPostBack)
            {
                //esAdminGE = controladoraGR.PerfilDelLogeado().ToString();
                if (Convert.ToBoolean(esAdminGE))
                {
                    //proyectoActual = controladoraGR.consultarIDProyMinimo().ToString();
                }
                else
                {
                    //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
                }
                volverAlOriginal();
            }
            if (Convert.ToBoolean(esAdminGE))
            {
                //proyectoActual = this.ProyectoAsociado.SelectedValue.ToString();
            }
            else
            {
                //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
            }
            llenarGridPP();
            llenarGridDP();
            llenarGridCP();
            llenarGridEP();
        }
        protected void llenarGridPP()
        {

            DataTable dtGrid = crearTablaPP();
            DataTable dt=new DataTable();
            if (Convert.ToBoolean(esAdminGE))
            {
                //dt = controladoraGR.consultarRequerimiento(1, ""); // en consultas tipo 1, no se necesita el id del proyecto asociado al usuario.
                //proyectoActual = this.ProyectoAsociado.SelectedValue.ToString();
                //dt = controladoraGR.consultarRequerimiento(3, Convert.ToString(proyectoActual));
            }
            else
            {
                //dt = controladoraGR.consultarRequerimiento(3, Convert.ToString(controladoraGR.proyectosDelLoggeado()));
            }
            Object[] datos = new Object[2];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    int id = Convert.ToInt32(dr[4]);
                    String nomp="" ;//= controladoraGR.solicitarNombreProyecto(id);
                    datos[0] = dr[3];
                    datos[1] = nomp;
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
        protected void llenarGridDP()
        {
            DataTable disennoPrueba = crearTablaDP();
            DataTable dt = new DataTable();//= controladoraGR.consultarCasosPrueba(1, "");

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
        protected void llenarGridCP()
        {
            DataTable casosPrueba = crearTablaCP();
            DataTable dt = new DataTable();//= controladoraGR.consultarCasosPrueba(1, "");

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
            DataTable dt = new DataTable();//= controladoraGR.consultarCasosPrueba(1, "");

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
            modoGE = Convert.ToString(0);
            if (!Convert.ToBoolean(esAdminGE))
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
            if (!Convert.ToBoolean(esAdminGE))
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
            
    }
    
}
