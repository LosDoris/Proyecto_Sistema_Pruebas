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

        public int ingresarCasosPrueba(EntidadCasosPrueba casoPrueba)
        {
            String consulta =
                "INSERT INTO Caso_Prueba(id_caso_prueba, proposito, entrada_de_datos, resultado_esperado, flujo_central, id_disenno, fechaUltimo) values('" +
                casoPrueba.Id_caso_prueba + "','" + casoPrueba.Proposito + "','" + casoPrueba.Entrada_datos + "','" + casoPrueba.Resultado_esperado + "','" +
                casoPrueba.Flujo_central + "'," + casoPrueba.Id_disenno +
                ", getDate()" + ");";
            int ret = acceso.Insertar(consulta);
            return ret;
        }

        public int modificarCasosPrueba(EntidadCasosPrueba casoPrueba)
        {
            String consulta = "UPDATE Caso_Prueba SET id_caso_prueba ='" + casoPrueba.Id_caso_prueba +
                                "', proposito = '" + casoPrueba.Proposito +
                                "', entrada_de_datos = '" + casoPrueba.Entrada_datos +
                                "', resultado_esperado = '" + casoPrueba.Resultado_esperado +
                                "', flujo_central = '" + casoPrueba.Flujo_central +
                                "', fechaUltimo=getDate()" +
                                " WHERE id_caso_prueba = '" + casoPrueba.IdConsulta + "';";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public int eliminarCasosPrueba(String id)
        {
            return acceso.Insertar("DELETE FROM Caso_Prueba WHERE id_caso_prueba = '" + id + "';");
        }

        public DataTable consultarCasosPrueba(int tipo, String id)
        {
            DataTable dt = null;
            String consulta = "";
            if (tipo == 1)//consulta para llenar grid, no ocupa la cedula pues los consulta a todos
            {
                consulta = "SELECT id_caso_prueba, proposito FROM Caso_Prueba ORDER BY fechaUltimo DESC;";
            }
            else if (tipo == 2)
            {
                consulta = "SELECT id_caso_prueba, proposito, entrada_de_datos, resultado_esperado, flujo_central FROM Caso_Prueba WHERE id_caso_prueba = '" + id + "';";
         
            }
            dt = acceso.ejecutarConsultaTabla(consulta);

            return dt;
        }
    }
}