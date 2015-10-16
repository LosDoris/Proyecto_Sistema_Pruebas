using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDRecursosHumanos
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        /*
         * Requiere: Nombre de Usuario.
         * Modifica: Se hace el chequeo en la base de datos sobre si el usuario está loggeado
           en algún servidor. Regresa el estado de loggeo del mismo, dentro del sistema.
         * Retorna: booleano.
         */
        public bool loggeado(string nombre)
        {
            bool regresa = false;
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT usuario, esta_loggeado FROM Recurso_Humano");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    if (row["usuario"].ToString() == nombre
                        && (int)row["esta_loggeado"] == 1)
                    {
                        regresa = true;
                    }

                }
            }
            catch (System.InvalidOperationException)
            {
                regresa = false;
            }


            return regresa;
        }

        /*
         * Requiere: N/A.
         * Modifica: Se regresan todos los nombres y Contraseñas dentro de la base de datos,
           para luego hacer la comparación con los datos ingresados por el usuario.
         * Retorna: vector de hileras.
         */
        public string[] nombresContrasenas()
        {
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT * FROM Recurso_Humano");
            string[] regresa = new string[2];
            string nombres = "";
            string contrasenas = "";

            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    if (nombres != "")
                        nombres += ";";
                    nombres += row["usuario"].ToString();

                    if (contrasenas != "")
                        contrasenas += ";";
                    contrasenas += row["contrasenna"].ToString();

                }
                regresa[0] = nombres;
                regresa[1] = contrasenas;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }


            return regresa;
        }

        /*
         * Requiere: Nombre de usuario y la contraseña nueva que se le va a asociar a este.
         * Modifica: Se hace el cambio en la base de datos sobre un usuario,
           para la contraseña nueva que haya puesto, tras haber hecho la validación
           sobre la contraseña anterior.
         * Retorna: booleano.
         */
        public bool modificaContrasena(string nombre, string nuevaContrasena)
        {
            bool regresa = false;
            if (acceso.Insertar("UPDATE Recurso_Humano SET contrasenna = '" + nuevaContrasena +
                        "' WHERE usuario = '" + nombre + "'") == 1)
            {
                regresa = true;
            }
            else
            {
                regresa = false;
            }

            return regresa;

        }

        /*
         * Requiere: Nombre de un usuario
         * Modifica: Hace chequeo para ver si un usuario está loggeado o con una sesión abierta
           en algún lugar. Regresa el estado de sesión abierta de este, haciendo comparación
           en la Base de Datos.
         * Retorna: booleano.
         */
        public bool estadoLoggeado(string nombre, string estado)
        {
            bool regresa = false;
            if (acceso.Insertar("UPDATE Recurso_Humano SET esta_loggeado = '" + estado +
                        "' WHERE usuario = '" + nombre + "'") == 1)
            {
                regresa = true;
            }
            else
            {
                regresa = false;
            }

            return regresa;

        }


        /**/

        /*
         * Requiere: Nombre de usuario loggeado
         * Modifica: Accede a la base de datos y busca el proyecto al que pertenece
           la persona que ha iniciado sesión. Regresa el número correspondiente
           al identificador del proyecto.
         * Retorna: número.
         */
        public int proyectosDelLoggeado(string elLoggeado)
        {
            int regresa = -3;
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT id_proyecto FROM Recurso_Humano WHERE usuario = '" + elLoggeado + "'");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    if (row["id_proyecto"] == null)
                    {
                        regresa = 0;
                    }
                    else
                    {
                        regresa = (int)row["id_proyecto"];
                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                regresa = -3;
            }


            return regresa;
        }

        /*
         * Requiere:  Nombre de usuario loggeado
         * Modifica: Accede a la base de datos y busca la cédula 
           de la persona que ha iniciado sesión. Regresa el número correspondiente a esta.
         * Retorna: número
         */
        public int idDelLoggeado(string elLoggeado)
        {
            int regresa = -1;
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT cedula FROM Recurso_Humano WHERE usuario = '" + elLoggeado + "'");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    regresa = (int)row["cedula"];
                }
            }
            catch (System.InvalidOperationException)
            {
                regresa = -1;
            }


            return regresa;
        }

        /*
         * Requiere:  Nombre de usuario loggeado
         * Modifica: Accede a la base de datos y busca el perfil de la persona que ha iniciado sesión.
           Regresa el nombre del perfil del usuario.
         * Retorna: hilera.
         */
        public string perfilDelLoggeado(string elLoggeado)
        {
            string regresa = null;
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT perfil_acceso FROM Recurso_Humano WHERE usuario = '" + elLoggeado + "'");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    regresa = row["perfil_acceso"].ToString();
                }
            }
            catch (System.InvalidOperationException)
            {
                regresa = null;
            }


            return regresa;
        }


        
        /**/





        public int insertarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {
            String consulta = "INSERT INTO Recurso_Humano(cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto) values(" + recursoHumano.Cedula + ",'" + recursoHumano.Nombre_Completo + "','" + recursoHumano.Tel1 + "','" + recursoHumano.Tel2 + "','" + recursoHumano.Correo + "','" + recursoHumano.Usuario + "','" + recursoHumano.Clave + "','" + recursoHumano.PerfilAcceso + "','" + recursoHumano.Rol + "'," + recursoHumano.ProyAsociado + ")";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public int modificarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {
            String consulta = "UPDATE Recurso_Humano SET cedula =" + recursoHumano.Cedula + ", nombre_completo = '" + recursoHumano.Nombre_Completo + "', telefono1 = '" + recursoHumano.Tel1 + "', telefono2 = '" + recursoHumano.Tel2 + "', correo_electronico = '" + recursoHumano.Correo + "', usuario = '" + recursoHumano.Usuario + "', contrasenna = '" + recursoHumano.Clave + "', perfil_acceso = '" + recursoHumano.PerfilAcceso + "', rol = '" + recursoHumano.Rol + "', id_proyecto = '" + recursoHumano.ProyAsociado + "' WHERE cedula = " + recursoHumano.CedulaVieja + ";";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public int eliminarRecursoHumanoBD(int cedula)
        {
            return acceso.Insertar("DELETE FROM Recurso_Humano WHERE cedula = " + cedula + ";");

        }

        public DataTable consultarRecursoHumanoBD(int tipo, int cedula)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)//consulta para llenar grid, no ocupa la cedula pues los consulta a todos
            {
                consulta = "SELECT cedula, nombre_completo, rol, id_proyecto FROM Recurso_Humano";
            }
            else if (tipo == 2)
            {
                consulta = "SELECT cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto FROM Recurso_Humano WHERE cedula =" + cedula;
                // dt = acceso.ejecutarConsultaTabla(consulta);
            }

            dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;

        }





    }
}