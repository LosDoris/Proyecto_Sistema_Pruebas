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
        public static string modoREQ
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

        public static string idViejoREQ
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

        public static string esAdminREQ
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

        public static string proyectoActual
        {
            get
            {
                object value = HttpContext.Current.Session["proyectoActual"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["proyectoActual"] = value;
            }
        }
        //Variables:
        //Metodos:
        protected void Page_Load(object sender, EventArgs e)
        {
            //Restricciones_Campos();
            if (!IsPostBack)
            {
                //esAdminREQ = controladoraGR.PerfilDelLogeado().ToString();
                if (Convert.ToBoolean(esAdminREQ))
                {
                    //proyectoActual = controladoraGR.consultarIDProyMinimo().ToString();
                }
                else
                {
                    //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
                }
                //volverAlOriginal();
            }
            if (Convert.ToBoolean(esAdminREQ))
            {
                //proyectoActual = this.ProyectoAsociado.SelectedValue.ToString();
            }
            else
            {
                //proyectoActual = ((controladoraGR.proyectosDelLoggeado()).ToString()).ToString();
            }
            llenarGridPP();
        }
        protected void llenarGridPP()
        {
/*
            DataTable Requerimiento = crearTablaREQ();
            DataTable dt;
            if (Convert.ToBoolean(esAdminREQ))
            {
                //dt = controladoraGR.consultarRequerimiento(1, ""); // en consultas tipo 1, no se necesita el id del proyecto asociado al usuario.
                //proyectoActual = this.ProyectoAsociado.SelectedValue.ToString();
                dt = controladoraGR.consultarRequerimiento(3, Convert.ToString(proyectoActual));
            }
            else
            {
                dt = controladoraGR.consultarRequerimiento(3, Convert.ToString(controladoraGR.proyectosDelLoggeado()));
            }
            Object[] datos = new Object[3];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    int id = Convert.ToInt32(dr[4]);
                    String nomp = controladoraGR.solicitarNombreProyecto(id);
                    datos[0] = dr[3];
                    datos[2] = nomp;
                    Requerimiento.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                Requerimiento.Rows.Add(datos);
            }
            gridRequerimiento.DataSource = Requerimiento;
            gridRequerimiento.DataBind();
            */
        }
        /*
         * Requiere: N/A.
         * Modifica: Vuelve al inicio de generar reportes.
         * Retorna: N/A.
         */
        protected void volverAlOriginal()
        {
            //botonesInicio();
            //desactivarErrores();
            deshabilitarCampos();
            //llenarDDProyecto();
            modoREQ = Convert.ToString(0);
            if (!Convert.ToBoolean(esAdminREQ))
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((controladoraRequerimiento.proyectosDelLoggeado()).ToString()).Selected = true;
            }
            else
            {
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue((proyectoActual).ToString()).Selected = true;
            }
            //TextBoxNombreREQ.Text = ".";
            //TextBoxPrecondicionesREQ.Text = "";
            //TextBoxRequerimientosEspecialesREQ.Text = "";
            //NombreTxtbox.Text = "";
            //BotonREQAceptarModificar.Visible = false;
            //BotonREQAceptar.Visible = true;
            //BotonREQAceptarModificar.Enabled = false;
            //BotonREQEliminar.Enabled = false;
            //habilitarGrid();
            llenarGridPP();
            if (!Convert.ToBoolean(esAdminREQ))
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
            
    }
}
