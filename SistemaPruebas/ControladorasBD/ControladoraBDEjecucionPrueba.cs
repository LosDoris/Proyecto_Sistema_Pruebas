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

        public string insertarBDEjecucion(EntidadEjecucionPrueba ejecucion)
        {
            String consulta =
                "INSERT INTO Ejecucion(fecha, responsable, incidencias, id_disenno, fechaUltimo) values('" +
                ejecucion.Fecha + "','" + ejecucion.Responsable + "','" + ejecucion.Incidencias + "'," +
                ejecucion.Id_disenno + ", getDate()" + ");";
            int ret = acceso.Insertar(consulta);
            DataTable dt=acceso.ejecutarConsultaTabla("select fecha from Ejecucion where fechaUltimo = (select max(e.fechaUltimo) from Ejecucion e)");

            string fecha_regresa = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    fecha_regresa = dr[0].ToString();
                }
            }
            return fecha_regresa;
        }

        public int insertarNoConformidad(EntidadNoConformidad noConformidad)
        {
            return 0;
        }

        public int modificarEjecucionPrueba(EntidadEjecucionPrueba ejecucion)
        {
            String consulta = "UPDATE ejecucion SET fecha = '" + ejecucion.Fecha +
                                "', responsable = '" + ejecucion.Responsable +
                                "', incidencias = '" + ejecucion.Incidencias +
                                "', id_disenno = '" + ejecucion.Id_disenno +
                                "', fechaUltimo=getDate()" +
                                " WHERE fecha = '" + ejecucion.FechaConsulta + "';";
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
                consulta = "SELECT fecha, responsable, '"+id+"' AS Diseño"+" FROM Ejecucion WHERE id_disenno=(select id_disenno from Disenno_Prueba where proposito='"+id+"')";
            }
            else if (tipo == 2)
            {
                consulta = "SELECT fecha, responsable, incidencias, id_disenno FROM Ejecucion WHERE fecha = '" + id + "';";

            }
            dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;
        }

    }
}