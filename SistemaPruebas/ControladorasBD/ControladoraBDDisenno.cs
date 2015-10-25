using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDDisenno
    {
        Acceso.Acceso acceso = new Acceso.Acceso();
        /*
         * Requiere: Entidad de Recursos Humanos
         * Modifica: Inserta un nuevo recurso humano en el sistema.
         * Retorna: int.
         */
        public int insertarDisennoBD(EntidadDisenno Disenno)
        {
            //String consulta = "INSERT INTO Recurso_Humano(cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto,fechaUltimo) values(" + Disenno.Cedula + ",'" + Disenno.Nombre_Completo + "','" + Disenno.Tel1 + "','" + Disenno.Tel2 + "','" + Disenno.Correo + "','" + Disenno.Usuario + "','" + Disenno.Clave + "','" + Disenno.PerfilAcceso + "','" + Disenno.Rol + "'," + Disenno.ProyAsociado + ", getDate()" + ")";
            int ret = acceso.Insertar(""/*consulta*/);
            return ret;

        }

        /*
         * Requiere: Entidad de Recursos Humanos
         * Modifica: Modifica un recurso humano previamente ingresado al sistema.
         * Retorna: int.
         */
        public int modificarDisennoBD(EntidadDisenno Disenno)
        {
            //String consulta = "UPDATE Recurso_Humano SET cedula =" + Disenno.Cedula + ", nombre_completo = '" + Disenno.Nombre_Completo + "', telefono1 = '" + Disenno.Tel1 + "', telefono2 = '" + Disenno.Tel2 + "', correo_electronico = '" + Disenno.Correo + "', usuario = '" + Disenno.Usuario + "', contrasenna = '" + Disenno.Clave + "', perfil_acceso = '" + Disenno.PerfilAcceso + "', rol = '" + Disenno.Rol + "', id_proyecto = '" + Disenno.ProyAsociado + "', fechaUltimo=getDate()" + " WHERE cedula = " + Disenno.CedulaVieja + ";";
            int ret = acceso.Insertar(""/*consulta*/);
            return ret;

        }

        /*
         * Requiere: Cédula
         * Modifica: Elimina un recurso humano del sistema.
         * Retorna: int.
         */

        public int eliminarDisennoBD(int cedula)
        {
            return 0; //acceso.Insertar("DELETE FROM Recurso_Humano WHERE cedula = " + cedula + ";");

        }

        /*
         * Requiere: tipo de consulta y cédula.
         * Modifica: N/A.
         * Retorna: DataTable.
         */
        public DataTable consultarDisennoBD(int tipo, int cedula)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)//consulta para llenar grid, no ocupa la cedula pues los consulta a todos
            {
                //consulta = "SELECT cedula, nombre_completo, rol, id_proyecto FROM Recurso_Humano ORDER BY fechaUltimo desc;";//BY perfil_acceso";
            }
            else if (tipo == 2)
            {
                //consulta = "SELECT cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto FROM Recurso_Humano WHERE cedula =" + cedula;
                // dt = acceso.ejecutarConsultaTabla(consulta);
            }

            dt = acceso.ejecutarConsultaTabla(""/*consulta*/);

            return dt;

        }
    }
}