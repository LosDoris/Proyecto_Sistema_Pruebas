using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDEjecucionPrueba
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        public int insertarBDEjecucion(EntidadEjecucionPrueba ejecucion)
        {
            String consulta =
                "INSERT INTO Ejecucion(id_ejecucion, fecha, responsable, incidencias, estado, id_disenno, fechaUltimo) values(" +
                ejecucion.Id_ejecucion + ",'" + ejecucion.Fecha + "','" + ejecucion.Responsable + "','" + ejecucion.Incidencias + "','" +
                ejecucion.Estado + "'," + ejecucion.Id_disenno + ", getDate()" + ");";
            int ret = acceso.Insertar(consulta);
            return acceso.Insertar("select id_disenno from Ejecucion where fechaUltimo = (select max(e.fechaUltimo) from Ejecucion e)");
        }

        public int insertarNoConformidad(EntidadNoConformidad noConformidad)
        {
            
        }

        public int modificarEjecucionPrueba(EntidadEjecucionPrueba ejecucion)
        {
            String consulta = "UPDATE ejecucion SET id_ejecucion ='" + ejecucion.Id_ejecucion +
                                "', fecha = '" + ejecucion.Fecha +
                                "', responsable = '" + ejecucion.Responsable +
                                "', incidencias = '" + ejecucion.Incidencias +
                                "', estado = '" + ejecucion.Estado +
                                "', id_disenno = '" + ejecucion.Id_disenno +
                                "', fechaUltimo=getDate()" +
                                " WHERE id_caso_prueba = '" + ejecucion.Id_ejecucion + "';";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public int eliminarEjecucionPrueba(String id)
        {
            return acceso.Insertar("DELETE FROM ejecucion WHERE id_ejecucion = '" + id + "';");
        }

        public DataTable consultarEjecucionPrueba(int tipo, String id)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)//consulta para llenar grid, no ocupa la cedula pues los consulta a todos
            {
                consulta = "SELECT id_ejecucion, responsable,fecha, estado FROM Ejecucion ORDER BY fechaUltimo DESC;";
            }
            else if (tipo == 2)
            {
                consulta = "SELECT id_caso_prueba, fecha, responsable, incidencias, estado, id_disenno FROM Ejecucion WHERE id_ejecucion = '" + id + "';";

            }
            dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;
        }

    }
}