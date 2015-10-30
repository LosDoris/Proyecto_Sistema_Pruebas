﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDCasosPrueba
    {
        Acceso.Acceso acceso = new Acceso.Acceso();

        public int ingresarCasosPrueba(EntidadCasosPrueba casoPrueba)
        {
            String consulta =
                "INSERT INTO Caso_Prueba(id_caso_prueba, proposito, entrada_de_datos, resultado_esperado, flujo_central, id_disenno, fechaUltimo) values('" +
                casoPrueba.Id_caso_prueba + "','" + casoPrueba.Proposito + "','" + casoPrueba.Entrada_datos + "','" + casoPrueba.Resultado_esperado + "','" +
                casoPrueba.Flujo_central + "'," + casoPrueba.Id_disenno +
                ", getDate()" + ")";
            int ret = acceso.Insertar(consulta);
            return ret;
        }

        public int modificarCasosPrueba(EntidadCasosPrueba entidad)
        {
            String consulta = "UPDATE Caso_prueba SET id_caso_prueba =" + entidad.Id_caso_prueba +
                                ", proposito = '" + entidad.Proposito +
                                "', entrada_de_datos = '" + entidad.Entrada_datos +
                                "', resultado_esperado = '" + entidad.Resultado_esperado +
                                "', flujo_central = '" + entidad.Flujo_central +
                                "', id_requerimiento = '" + entidad.Id_disenno +
                                 "', fechaUltimo=getDate()" +
                                " WHERE id_caso_prueba = " + entidad.Id_caso_prueba + ";";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public int eliminarCasosPrueba(string id)
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