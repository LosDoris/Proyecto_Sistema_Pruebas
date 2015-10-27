using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDCasosPrueba
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        //public int ingresarCasosPrueba(EntidadCasosPrueba entidad)
        //{
        //    String consulta = 
        //        "INSERT INTO Caso_prueba(id_caso_prueba, proposito, entrada_de_datos, resultado_esperado, flujo_central, id_requerimiento) values(" + 
        //        entidad.Id_caso_prueba + ",'" + entidad.Proposito + "','" + entidad.Entrada_datos+ "','" + entidad.Resultado_esperado + "','" +
        //        entidad.Flujo_central + "','" + entidad.Id_requerimiento +
        //        ", getDate()"+  ")";
        //    int ret = acceso.Insertar(consulta);
        //    return ret;
        //}

        //public int modificarCasosPrueba(EntidadCasosPrueba entidad)
        //{
        //    String consulta = "UPDATE Caso_prueba SET id_caso_prueba =" + entidad.Id_caso_prueba + 
        //                        ", proposito = '" + entidad.Proposito +
        //                        "', entrada_de_datos = '" + entidad.Entrada_datos+
        //                        "', resultado_esperado = '" + entidad.Resultado_esperado+
        //                        "', flujo_central = '" + entidad.Flujo_central+
        //                        "', id_requerimiento = '" + entidad.Id_requerimiento+
        //                         "', fechaUltimo=getDate()"+
        //                        " WHERE id_caso_prueba = " + entidad.Id_caso_prueba + ";";
        //    int ret = acceso.Insertar(consulta);
        //    return ret;

        //}

        public int eliminarCasosPrueba(int id)
        {
            return acceso.Insertar("DELETE FROM Caso_prueba WHERE id_caso_prueba = " + id + ";");
        }

        public DataTable consultarCasosPrueba()
        {
            DataTable dt = null;
            String consulta = "";
            consulta = "SELECT * FROM Caso_prueba ORDER BY fechaUltimo desc;";
            dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;
        }
    }
}