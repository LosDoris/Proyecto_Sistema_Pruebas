using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SistemaPruebas.Models;


namespace SistemaPruebas.Account
{
    public partial class Login : Page
    {
        static public bool logeado = false;
        Controladoras.ControladoraRecursosHumanos controladoraRH = new Controladoras.ControladoraRecursosHumanos();

        protected void Page_Load(object sender, EventArgs e)
        {
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LogIn(object sender, EventArgs e)
        {
            Object[] datos = new Object[2];
            datos[0] = this.UserName.Text;
            datos[1] = this.Password.Text;
            if (controladoraRH.loggeado(datos[0].ToString()) == false)
            {
                if (controladoraRH.usuarioMiembroEquipo(datos))
                {
                    //regreso true
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "TRU" + "');", true);
                    logeado = true;

                }
                else
                {
                    //regreso false
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "FALSE" + "');", true);
                }
            }
            
        }
    }
}