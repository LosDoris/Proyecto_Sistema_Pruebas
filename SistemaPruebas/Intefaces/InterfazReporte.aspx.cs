﻿using System;
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
                //volverAlOriginal();
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
        }
        protected void llenarGridPP()
        {

            DataTable Requerimiento = crearTablaPP();
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
            Object[] datos = new Object[3];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    int id = Convert.ToInt32(dr[4]);
                    String nomp="" ;//= controladoraGR.solicitarNombreProyecto(id);
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
            //gridRequerimiento.DataSource = Requerimiento;
            //gridRequerimiento.DataBind();
            
        }
        /*
         * Requiere: N/A.
         * Modifica: Vuelve al inicio de generar reportes.
         * Retorna: N/A.
         */
        protected void volverAlOriginal()
        {
            //deshabilitarCampos();
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
            
    }
}
