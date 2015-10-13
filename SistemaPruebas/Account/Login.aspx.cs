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
        static public string el_logeado = "";
        static public int loggeado = 0;
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
                    el_logeado = datos[0].ToString();

                    controladoraRH.estadoLoggeado(datos[0].ToString(), "1");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Loggeo correcto" + "');", true);
                    loggeado = 1;
                    Response.Redirect("~/Default");

                }
                else
                {
                    //regreso false
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Usuario no coincide con contraseña" + "');", true);
                }
            }
            else
            {
                //esta loggeado en otro lado
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Esta loggeado en otro lado. Desloggeo se hará." + "');", true);
                controladoraRH.estadoLoggeado(datos[0].ToString(), "0");


            }

        }

    }
}