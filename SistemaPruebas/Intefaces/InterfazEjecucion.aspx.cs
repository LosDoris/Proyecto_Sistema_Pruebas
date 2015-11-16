using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazEjecucion : System.Web.UI.Page
    {

      /*
       * Requiere: N/A
       * Modifica: Declara variable global de modo (tipo de operación en ejecución)
       * Retorna: entero.
       */
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

      /*
       * Requiere: N/A
       * Modifica: Declara variable global que guarda el id del caso de prueba siendo modificado
       * Retorna: hilera.
       */
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

       /*
       * Requiere: N/A
       * Modifica: Maneja los eventos a ocurrir cada vez que se carga la página
       * Retorna: N/A.
       */
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
         * Requiere: N/A
         * Modifica: Establece el valor por defecto de la variable "modo" a 0.
         * Retorna: N/A
         */
        protected void inicializarModo()
        {
            modo = 0;
        }

        protected void estadoInicial()
        {
            DatosEjecucion.Enabled = false;
        }

        protected void llenarDDProyecto()
        {
            

        }

        protected void BotonEPInsertar_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownProyecto.SelectedItem.Text != "Seleccionar")
            {

            }
        }
    }
}