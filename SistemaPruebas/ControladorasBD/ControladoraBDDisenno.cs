using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDDisenno
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        //Requiere: Recibir la información de proyecto encapsulado
        //Modifica: Inserta un  nuevo proyecto en la base de datos
        //Retorna: N/A
        public int InsertarDiseno(EntidadDisenno datos)
        {
            using (SqlCommand comando = new SqlCommand("dbo.Insertar_Disenno"))
            {
     
                comando.CommandType = CommandType.StoredProcedure;
               
                comando.Parameters.Add(new SqlParameter("@proposito", datos.Proposito));

                comando.Parameters.Add(new SqlParameter("@nivel", datos.Nivel));

                comando.Parameters.Add(new SqlParameter("@tecnica", datos.Tecnica));

                comando.Parameters.Add(new SqlParameter("@ambiente", datos.Ambiente));

                comando.Parameters.Add(new SqlParameter("@procedimiento", datos.Procedimiento));

                comando.Parameters.Add(new SqlParameter("@fecha_de_disenno", datos.FechaDeDisenno));

                comando.Parameters.Add(new SqlParameter("@criterio_aceptacion", datos.CriterioAceptacion));

                comando.Parameters.Add(new SqlParameter("@cedula", datos.Responsable));

                comando.Parameters.Add(new SqlParameter("@id_proyecto", datos.ProyAsociado));
                return acceso.Insertar_Proced_Almacenado(comando);

            }
        }


        /*
         * Requiere: Entidad de Disenno
         * Modifica: Inserta un nuevo disenno en el sistema.
         * Retorna: int.
         

        public int insertarDisennoBD(EntidadDisenno Disenno)
        {
            String consulta = "INSERT INTO Disenno_Prueba(id_disenno,proposito,nivel,tecnica,tipo,ambiente,procedimiento,fecha_de_disenno,criterio_aceptacion,responsable,id_proyecto,fechaUltimo) values('" + Disenno.Id + "','" + Disenno.Proposito + "'," + Disenno.Nivel + "," + Disenno.Tecnica + "," + Disenno.Tipo + ",'" + Disenno.Ambiente + "','" + Disenno.Procedimiento + "'," + Disenno.FechaDeDisenno + ",'" + Disenno.CriterioAceptacion + "','" + Disenno.Responsable + "'," + Disenno.ProyAsociado + ", getDate()" + ")";
            int ret = acceso.Insertar(consulta);
            return ret;

        }
        */
        /*
         * Requiere: Entidad de Requerimiento
         * Modifica: Inserta un nuevo requerimiento de un disenno en el sistema.
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
        
        public int modificarDisennoBD(EntidadDisenno Disenno)
        {
            String consulta = "UPDATE Disenno_Prueba SET id_disenno ='"+ Disenno.Id + "',proposito ='"+ Disenno.Proposito + "',nivel ="+ Disenno.Nivel + ",tecnica ="+ Disenno.Tecnica + ",tipo ="+ Disenno.Tipo + ",ambiente ='"+ Disenno.Ambiente + "',procedimiento ='"+ Disenno.Procedimiento + "',fecha_de_disenno ="+ Disenno.FechaDeDisenno + ",criterio_aceptacion ='"+ Disenno.CriterioAceptacion + "',responsable ="+ Disenno.Responsable + ",id_proyecto ="+ Disenno.ProyAsociado + ",fechaUltimo =getDate();";
            int ret = acceso.Insertar(consulta);
            return ret;

        }
         */
        /*
         * Requiere: Id del diseño
         * Modifica: Elimina un disenno del sistema.
         * Retorna: int.
         */

        public int eliminarDisennoBD(String id)
        {
            return acceso.Insertar("DELETE FROM Disenno_Prueba WHERE id_disenno = '" + id + "';");

        }

        /*
         * Requiere: Id requerimiento.
         * Modifica: Elimina un requerimiento de un disenno del sistema.
         * Retorna: int.
         */

        public int eliminarRequerimientoBD(String id)
        {
            return acceso.Insertar("DELETE FROM Requerimiento WHERE id_requerimiento = '" + id + "';");
        }

        /*
         * Requiere: Id diseño.
         * Modifica: Elimina un requerimiento de un disenno del sistema.
         * Retorna: int.
         

        public int eliminarRequerimientosProyectoBD(String id_disenno)
        {
            return acceso.Insertar("DELETE FROM Requerimiento WHERE id_disenno = '" + id_disenno + "';");
        }
        */

        /*
         * Requiere: tipo de consulta y cédula.
         * Modifica: N/A.
         * Retorna: DataTable.
         */
        public DataTable consultarDisennoBD(int tipo, int id)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)
            {
                consulta = "select proposito, nivel, tecnica, ambiente, procedimiento, fecha_de_disenno, criterio_aceptacion, cedula, id_proyecto from Disenno_Prueba where id_disenno= " + id;             
                    }
            else if (tipo == 2)//consulta para llenar grid
            {
                consulta = "select D.proposito, D.nivel, D.tecnica, R.nombre_completo from Disenno_Prueba D, Recurso_Humano R where D.cedula=R.cedula AND D.id_proyecto=" + id;
                    }

                dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;

        }

        public int consultarId_Disenno(String proposito)
        {
            DataTable dt = new DataTable();
            dt = acceso.ejecutarConsultaTabla("select id_disenno from Disenno_Prueba where proposito = '" + proposito + "'");
            return Int32.Parse(dt.Rows[0][0].ToString());
        }
    }
}