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
         * Requiere: Entidad de Disenno
         * Modifica: Inserta un nuevo disenno en el sistema.
         * Retorna: int.
         */
        public int insertarDisennoBD(EntidadDisenno Disenno)
        {
            String consulta = "INSERT INTO Disenno_Prueba(id_disenno,proposito,nivel,tecnica,tipo,ambiente,procedimiento,fecha_de_disenno,criterio_aceptacion,responsable,id_proyecto,fechaUltimo) values('" + Disenno.Id + "','" + Disenno.Proposito + "'," + Disenno.Nivel + "," + Disenno.Tecnica + "," + Disenno.Tipo + ",'" + Disenno.Ambiente + "','" + Disenno.Procedimiento + "'," + Disenno.FechaDeDisenno + ",'" + Disenno.CriterioAceptacion + "','" + Disenno.Responsable + "'," + Disenno.ProyAsociado + ", getDate()" + ")";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        /*
         * Requiere: Entidad de Requerimiento
         * Modifica: Inserta un nuevo disenno en el sistema.
         * Retorna: int.
         */
        public int insertarRequerimientoBD(EntidadRequerimientos Requerimiento)
        {
            String consulta = "INSERT INTO Requerimiento(id_requerimiento,precondiciones,Requerimientos_especiales) values('" + Requerimiento.Id + "','" + Requerimiento.Precondiciones + "','" + Requerimiento.Precondiciones + "', getDate())";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        /*
         * Requiere: Entidad de Disenno
         * Modifica: Modifica un disenno previamente ingresado al sistema.
         * Retorna: int.
         */
        public int modificarDisennoBD(EntidadDisenno Disenno)
        {
            String consulta = "UPDATE Disenno_Prueba SET id_disenno ='"+ Disenno.Id + "',proposito ='"+ Disenno.Proposito + "',nivel ="+ Disenno.Nivel + ",tecnica ="+ Disenno.Tecnica + ",tipo ="+ Disenno.Tipo + ",ambiente ='"+ Disenno.Ambiente + "',procedimiento ='"+ Disenno.Procedimiento + "',fecha_de_disenno ="+ Disenno.FechaDeDisenno + ",criterio_aceptacion ='"+ Disenno.CriterioAceptacion + "',responsable ="+ Disenno.Responsable + ",id_proyecto ="+ Disenno.ProyAsociado + ",fechaUltimo =getDate();";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        /*
         * Requiere: Cédula
         * Modifica: Elimina un disenno del sistema.
         * Retorna: int.
         */

        public int eliminarDisennoBD(String id)
        {
            return acceso.Insertar("DELETE FROM Disenno_Prueba WHERE id_disenno = " + id + ";");

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
                //consulta = "SELECT cedula, nombre_completo, rol, id_proyecto FROM Disenno_Prueba ORDER BY fechaUltimo desc;";//BY perfil_acceso";
            }
            else if (tipo == 2)
            {
                //consulta = "SELECT cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto FROM Disenno_Prueba WHERE cedula =" + cedula;
                // dt = acceso.ejecutarConsultaTabla(consulta);
            }

            dt = acceso.ejecutarConsultaTabla(""/*consulta*/);

            return dt;

        }
    }
}