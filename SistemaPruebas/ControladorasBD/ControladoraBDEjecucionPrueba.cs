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

        public String insertarBDEjecucion(EntidadEjecucionPrueba ejecucion)
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
            String consulta = "INSERT INTO noConformidad (tipo, idCaso, descripcion, justificacion,imagen, estado, fecha) VALUES ('" + noConformidad.Tipo               + "','"
                                                                                                                                     + noConformidad.Caso               + "','"
                                                                                                                                     + noConformidad.Descripcion        + "','"
                                                                                                                                     + noConformidad.Justificacion      + "', @img, '"
                                                                                                                                     + noConformidad.Estado             + "','"
                                                                                                                                     + noConformidad.Id_ejecucion       + "');";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = consulta;
                cmd.Parameters.Add("@img", SqlDbType.Image, noConformidad.Imagen.Length).Value = noConformidad.Imagen;
                acceso.Insertar_Proced_Almacenado(cmd);
            }
            return 0;
        }

        public String modificarEjecucionPrueba(EntidadEjecucionPrueba ejecucion)
        {
            String consulta = "UPDATE ejecucion SET fecha = '" + ejecucion.Fecha +
                                "', responsable = '" + ejecucion.Responsable +
                                "', incidencias = '" + ejecucion.Incidencias +
                                "', id_disenno = '" + ejecucion.Id_disenno +
                                "', fechaUltimo=getDate()" +
                                " WHERE fecha = '" + ejecucion.FechaConsulta + "';";
            int ret = acceso.Insertar(consulta);

            String fecha_regresa = "";
            if (ret != 2627)
            {
                DataTable dt = acceso.ejecutarConsultaTabla("select fecha from Ejecucion where fechaUltimo = (select max(e.fechaUltimo) from Ejecucion e)");
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

        public int modificarBDNoConformidad(EntidadNoConformidad noConformidad)
        {
            DataTable dt = acceso.ejecutarConsultaTabla("if ((select id_noConformidad from noConformidad where id_noConformidad = '" + noConformidad.Id_noConformidad +
                                                        "' and  fecha = '" + noConformidad.Id_ejecucion +"')is null) select 0 else select 1");
            String consulta="";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr[0])==0){
                        consulta="INSERT INTO noConformidad (tipo, idCaso, descripcion, justificacion,imagen, estado, fecha) VALUES ('"+ noConformidad.Tipo + "','"
                                                                                                                                    +noConformidad.Caso + "','"
                                                                                                                                    +noConformidad.Descripcion + "','"
                                                                                                                                    +noConformidad.Justificacion + "', @img, '"
                                                                                                                                    +noConformidad.Estado  + "','"
                                                                                                                                    + noConformidad.Id_ejecucion + "');";
                    }
                    else if (Convert.ToInt32(dr[0]) == 1)
                    {
                        consulta = "UPDATE noConformidad SET " + "tipo = '" + noConformidad.Tipo + "', " +
                                                           "idCaso = '" + noConformidad.Caso + "', " +
                                                           "descripcion = '" + noConformidad.Descripcion + "', " +
                                                           "justificacion = '" + noConformidad.Justificacion + "', " +
                                                           "estado = '" + noConformidad.Estado + "' " +
                                                           "WHERE fecha = '" + noConformidad.Id_ejecucion + "'  " +
                                                           "AND id_noConformidad = '" + noConformidad.Id_noConformidad + "';";
                    }
                }
            }

            

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = consulta;
                cmd.Parameters.Add("@img", SqlDbType.Image, noConformidad.Imagen.Length).Value = noConformidad.Imagen;
                acceso.Insertar_Proced_Almacenado(cmd);
            }
            return 0;
        }

        public int eliminarEjecucionPrueba(String id)
        {
            return acceso.Insertar("DELETE FROM ejecucion WHERE fecha = '" + id + "';");
        }

        public DataTable consultarEjecucionPrueba(int tipo, String id)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)//consulta para llenar grid, no ocupa la cedula pues los consulta a todos
            {
                consulta = "SELECT fecha, responsable, '" + id + "' AS Diseño" + " FROM Ejecucion WHERE id_disenno=(select id_disenno from Disenno_Prueba where proposito='" + id + "') order by fechaUltimo desc";
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
            String consulta = "SELECT tipo, idCaso, descripcion, justificacion, imagen, estado, id_noConformidad FROM noConformidad WHERE fecha = '" + fecha + "';";
            dt = acceso.ejecutarConsultaTabla(consulta);
            return dt;
        }

        public String retornarEstado(String casoPrueba)
        {
            DataTable retorno = acceso.ejecutarConsultaTabla("if ((select count(g.estado) from (select estado from noConformidad where fecha= (select max(fecha) from noConformidad)"+
                                                            " and idCaso='"+ casoPrueba+"') g) =1)(select estado from noConformidad where fecha= (select max(fecha) from noConformidad) "+
                                                            " and idCaso='"+casoPrueba+"') else select tipo, estado from noConformidad where fecha= (select max(fecha) from noConformidad)"+
                                                            " and idCaso='"+casoPrueba+"'");
            string hilera = "";

            if (retorno.Rows.Count == 1)
            {
                return retorno.Rows[0].ItemArray[0].ToString();
            }
            else if (retorno.Rows.Count > 1)
            {
                for (int i = 0; i < retorno.Rows.Count; i++)
                {
                    hilera += retorno.Rows[i].ItemArray[0].ToString()+",";
                    if (i == retorno.Rows.Count - 1)
                    {
                        hilera += retorno.Rows[i].ItemArray[1].ToString();
                    }
                    else
                    {
                        hilera += retorno.Rows[i].ItemArray[1].ToString() + ";";
                    }
                    
                }
                //controladoraEjecucionPrueba.retornarEstado("Curso-RQ1-1");
                //controladoraEjecucionPrueba.retornarEstado("REQ-1520");
            }
            return hilera;
        }

        public int eliminarBDNoConformidad(string id_noConformidad)
        {
            return acceso.Insertar("DELETE FROM noConformidad WHERE id_noConformidad = '" + id_noConformidad + "';");
        }

        public int cantidadNoConformidades(string id_ejecucion)
        {
            DataTable dt = acceso.ejecutarConsultaTabla("select count(*) from noConformidad where fecha='" + id_ejecucion + "'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return Convert.ToInt32(dr[0]);
                }
            }
            return 0;
        }

    }
}