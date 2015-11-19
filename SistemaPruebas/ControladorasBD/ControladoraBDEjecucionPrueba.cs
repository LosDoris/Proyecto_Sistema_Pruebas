using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDEjecucionPrueba
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        public int ingresarCasosPrueba(EntidadEjecucionPrueba ejecucion)
        {
            String consulta =
                "INSERT INTO Ejecucion(id_ejecucion, fecha, responsable, incidencias, estado, id_disenno, fechaUltimo) values(" +
                ejecucion.Id_ejecucion + ",'" + ejecucion.Fecha + "','" + ejecucion.Responsable + "','" + ejecucion.Incidencias + "','" +
                ejecucion.Estado + "'," + ejecucion.Id_disenno + ", getDate()" + ");";
            int ret = acceso.Insertar(consulta);
            return acceso.Insertar("select id_disenno from Ejecucion where fechaUltimo = (select max(e.fechaUltimo) from Ejecucion e)");
        }
    }
}