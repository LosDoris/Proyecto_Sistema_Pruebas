using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaPruebas.Account
{
    public partial class CambiarContrasena : System.Web.UI.Page
    {
        Controladoras.ControladoraRecursosHumanos controladoraRH = new Controladoras.ControladoraRecursosHumanos();
        public string g;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cambiarContrasena(object sender, EventArgs e)
        {
            Object[] datos = new Object[2];
            datos[0] = this.UserName.Text;
            datos[1] = this.PasswordOld.Text;

            if (controladoraRH.loggeado(datos[0].ToString()) == false)
            {
                if (controladoraRH.usuarioMiembroEquipo(datos))
                {
                    //llamar metodo con confirmacion de modificacion de contrasena exitosa
                    Object[] datos1 = new Object[2];
                    datos1[0] = this.UserName.Text;
                    datos1[1] = this.PasswordNew.Text;
                    controladoraRH.modificaContrasena(datos1);

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cambio de contraseña exitoso" + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Contraseña y usuario no coinciden" + "');", true);
                }
            }
        }
    }
}