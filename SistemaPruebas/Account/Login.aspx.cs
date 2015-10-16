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
            if (Account.CambiarContrasena.cambiado == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Cambio de contraseña hecho." + "');", true);
                Account.CambiarContrasena.cambiado = 0;
            }
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        /*
         * Requiere: Nombre de Usuario ingresado en la caja de texto correspondiente
         * y presión del botón de Aceptar, además de la contraseña ingresada.
         * Modifica: Se realiza la validación de los datos ingresados, conforme a la información
         * que se posee de la base de datos. Se hace la operación de loggear al usuario.
         * Retorna: N/A.
         */
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
                    //int temp = controladoraRH.proyectosDelLoggeado();
                    //int temp2 = controladoraRH.idDelLoggeado();
                    //string temp3 = controladoraRH.perfilDelLoggeado();
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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Está loggeado en otro lado. Será cerrará la sesión." + "');", true);
                controladoraRH.estadoLoggeado(datos[0].ToString(), "0");


            }

        }

    }
}