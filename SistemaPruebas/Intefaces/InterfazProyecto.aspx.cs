using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazProyecto : System.Web.UI.Page
    {
        private int button;
        Controladoras.ControladoraProyecto controladoraProyecto = new Controladoras.ControladoraProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Restricciones_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
        }
        protected void Restricciones_Campos()
        {
            
            nombre_proyecto.MaxLength = 10;
            obj_general.MaxLength = 50;
            nombre_rep.MaxLength = 30;
            tel_rep.MaxLength = 17;
            of_rep.MaxLength = 17;
            obj_general.Rows = 5;

        }
        protected void Habilitar_Campos()
        {
            nombre_proyecto.Enabled = true;
            obj_general.Enabled = true;
            estado.Enabled = true;
            nombre_rep.Enabled = true;
            tel_rep.Enabled = true;
            of_rep.Enabled = true;
            //datetimepicker('disable');


        }
        protected void Deshabilitar_Campos()
        {
            nombre_proyecto.Enabled = false;
            obj_general.Enabled = false;
            estado.Enabled = false;
            nombre_rep.Enabled = false;
            tel_rep.Enabled = false;
            of_rep.Enabled = false; 
        }

        protected void Limpiar_Campos()
        {
            nombre_proyecto.Text = "";
            obj_general.Text = "";            
            nombre_rep.Text = "";
            tel_rep.Text = "";
            of_rep.Text = ""; 
        }


        protected void Insertar_button(object sender, EventArgs e)
        {
            button = 1;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            Habilitar_Campos();
            
        }

        protected void aceptar_Click(object sender, EventArgs e)
        {
            if (nombre_proyecto.Text != "" && obj_general.Text != "" && nombre_rep.Text != "" && tel_rep.Text != "" && of_rep.Text != "")
            {
                // switch (button)
                //{
                //  case 1://Insertar
                //    {
                            string text = Page.Request.Form["datepickernm"];
                            object[] datos = new object[7]{nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text};
                            
                            int a= controladoraProyecto.IngresaProyecto(datos);
                if (a == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"err_msg","alert('El proyecto ha sido insertado con éxito');", true);

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);

                }

                //    Limpiar_Campos();
                //  }
                //break;
                //case 2:
                //{

                //        }
                //        break;
                //        case 3:
                //        {

                //        }
                //        break;
                //}
            }
        }

        protected void cancelar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
        }

        // <asp:RequiredFieldValidator runat="server" ControlToValidate="nombre_proyecto"
        //                      CssClass="text-danger" ErrorMessage="El campo de Nombre del Proyecto es obligatorio." />*/

    }
}