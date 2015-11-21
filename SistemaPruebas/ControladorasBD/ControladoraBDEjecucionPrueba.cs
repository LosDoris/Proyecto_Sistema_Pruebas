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

            String fecha_regresa = "";
            if(ret != 2627)
            {
                DataTable dt=acceso.ejecutarConsultaTabla("select fecha from Ejecucion where fechaUltimo = (select max(e.fechaUltimo) from Ejecucion e)");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        fecha_regresa = dr[0].ToString();
                    }
                }
            }
            else
            {
                fecha_regresa = "-";
            }
            return fecha_regresa;
        }

       
        public int insertarBDnoConformidad(EntidadNoConformidad noConformidad)
        {
            String consulta = "INSERT INTO noConformidad (tipo, idCaso, descripcion, justificacion,imagen, fecha) VALUES ('" + noConformidad.Tipo + "','"
                                                                                                                             + noConformidad.Caso + "','"
                                                                                                                             + noConformidad.Descripcion +"','"
                                                                                                                             + noConformidad.Justificacion + "', @img, '"
                                                                                                                             + noConformidad.Id_ejecucion + "');";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = consulta;
                cmd.Parameters.Add("@img", SqlDbType.Image, noConformidad.Imagen.Length).Value = noConformidad.Imagen;
                acceso.Insertar_Proced_Almacenado(cmd);
            }
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

        public DataTable consultarBDNoConformidad(String fecha)
        {
            DataTable dt = null;
            String consulta = "SELECT tipo, idCaso, descripcion, justificacion, imagen, id_noConformidad FROM noConformidad WHERE fecha = '" + fecha + "';";
            dt = acceso.ejecutarConsultaTabla(consulta);
            return dt;
        }

    }
}