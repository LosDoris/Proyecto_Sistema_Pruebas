using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraRecursosHumanos
    {
        ControladoraBDRecursosHumanos controladoraBDRecursosHumanos = new ControladoraBDRecursosHumanos();

        ControladoraProyecto controladoraProyecto = new ControladoraProyecto();

        /*
         * Requiere: Los datos de Nombre de Usuario y la contraseña ingresada para un usuario específico.
         * Modifica: Manda los datos a la Controladora Base de Datos para hacer el cambio
           sobre el estado de sesión abierta de un usuario. Regresa la confirmación del loggeo.
         * Retorna: booleano.
         */
        public bool usuarioMiembroEquipo(Object[] datos)
        {
            string[] nombresYContrasenas = controladoraBDRecursosHumanos.nombresContrasenas();

            if (nombresYContrasenas != null)
            {
                string nombreIngresado = datos[0].ToString();
                string contrasenaIngresada = datos[1].ToString();

                if (nombresYContrasenas[0].Contains(nombreIngresado)
                    && nombresYContrasenas[1].Contains(contrasenaIngresada))
                {
                    return true;
                }
            }
            return false;
        }

        /*
         * Requiere: El conjunto de Datos de un usuario,
           incluyendo el nombre del usuario y la contraseñapor la que va a cambiar.
         * Modifica: Hace el llamado al método que hará el cambio en la base de datos
           para la contraseña asociada a un usuario. Esto después de validar los datos de un usuario,
           con la contraseña anterior.
         * Retorna: booleano.
         */
        public bool modificaContrasena(Object[] datos)
        {
            return controladoraBDRecursosHumanos.modificaContrasena(datos[0].ToString(), datos[1].ToString());
        }

        /*
         * Requiere: El nombre de un usuario.
         * Modifica: Se hace el llamado a la Controladora de la Base de Datos correspondiente,
           de manera que se pueda ver si un usuario está loggeado, según la información guardada.
         * Retorna: booleano.
         */
        public bool loggeado(string nombre)
        {
            return controladoraBDRecursosHumanos.loggeado(nombre);
        }

        /*
         * Requiere: El nombre de usuario y el estado de sesión abierta o cerrada que va a cambiarse.
         * Modifica: Se hace el cambio en el estado de loggeo para un usuario,
           llamando al método que modifica los datos dentro de la base de datos.
         * Retorna: booleano.
         */
        public bool estadoLoggeado(string nombre, string estado)
        {
            return controladoraBDRecursosHumanos.estadoLoggeado(nombre, estado);
        }
        
        
        
        /**/

        /*
         * Requiere: N/A.
         * Modifica: Hace el llamado al método que accede a la base de datos para regresar
           los proyectos de quien tiene sesión abierta actualmente.
         * Retorna: número.
         */
        public int proyectosDelLoggeado()
        {
            return controladoraBDRecursosHumanos.proyectosDelLoggeado(Account.Login.el_logeado);
        }

        /*
         * Requiere: N/A.
         * Modifica: Hace el llamado al método que accede a la base de datos para regresar
           la cédula de quien tiene sesión abierta actualmente.
         * Retorna: número.
         */
        public int idDelLoggeado()
        {
            return controladoraBDRecursosHumanos.idDelLoggeado(Account.Login.el_logeado);
        }

        /*
         * Requiere: N/A.
         * Modifica: Hace el llamado al método que accede a la base de datos para regresar
           el perfil de quien tiene sesión abierta actualmente.
         * Retorna: hilera.
         */
        public string perfilDelLoggeado()
        {
            return controladoraBDRecursosHumanos.perfilDelLoggeado(Account.Login.el_logeado);
        }

        /**/


        public int insertarRecursoHumano(Object[] datos)
        {
            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            int ret = controladoraBDRecursosHumanos.insertarRecursoHumanoBD(recursoHumano);
            return ret;
        }

        public int modificarRecursoHumano(Object[] datos)
        {
            //datos[0];

            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            int ret = controladoraBDRecursosHumanos.modificarRecursoHumanoBD(recursoHumano);
            return ret;
        }

        public int eliminarRecursoHumano(int cedula)
        {
            //datos[0];
            //EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            int ret = controladoraBDRecursosHumanos.eliminarRecursoHumanoBD(cedula);
            return ret;
        }

        public DataTable consultarRecursoHumano(int tipo, int cedula)
        {
            DataTable dt = controladoraBDRecursosHumanos.consultarRecursoHumanoBD(tipo, cedula);
            return dt;

        }

        /*public int eliminarRecursoHumano(int cedula)
        {
            int regresa = 0;
            if (controladoraBDRecursosHumanos.eliminarRecursoHumano(cedula))
            {
                regresa = 0;
            }
            else
            {
                regresa = 1;
            }
            return regresa;
        }*/

        public String solicitarProyectos()
        {
            String proyectos = controladoraProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

    }
}