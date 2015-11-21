using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraCasosPrueba
    {
        ControladoraBDCasosPrueba controladoraBDCasosPrueba;
        //ControladoraBDDisenno controlDisenno;

        public ControladoraCasosPrueba()
        {
            controladoraBDCasosPrueba = new ControladoraBDCasosPrueba();
        }

        public int insertarCasosPrueba(object[] datos)
        {
            EntidadCasosPrueba casoPrueba = new EntidadCasosPrueba(datos);
            int ret = controladoraBDCasosPrueba.ingresarCasosPrueba(casoPrueba);
            return ret;
        }

        public int modificarCasosPrueba(Object[] datos)
        {
            EntidadCasosPrueba objCasoPrueba = new EntidadCasosPrueba(datos);
            int ret = controladoraBDCasosPrueba.modificarCasosPrueba(objCasoPrueba);
            return ret;
        }

        public int eliminarCasosPrueba(String id)
        {
            int ret = controladoraBDCasosPrueba.eliminarCasosPrueba(id);
            return ret;
        }

        public DataTable consultarCasosPrueba(int tipo, String id)
        {
            DataTable dt = controladoraBDCasosPrueba.consultarCasosPrueba(tipo, id);
            return dt;

        }

        public String solicitarCasosdePrueba(int idDiseno)
        {
            String casosDePrueba = controladoraBDCasosPrueba.solicitarCasosdePrueba(idDiseno);
            return casosDePrueba;
        }

        public string[] consultarCasoPorRequerimiento(string idReq)
        {
            string[] retorno = null;
            DataTable dt = controladoraBDCasosPrueba.consultarCasoPorRequerimiento(idReq);
            int i = 0;
            retorno = new string[dt.Rows.Count];
            foreach (DataRow dr in dt.Rows)
            {
                retorno[i] = dr[0].ToString();
                i++;
            }
            return retorno;
        }
    }
}