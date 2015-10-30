﻿using System;
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

        public int eliminarCasosPrueba(string id)
        {
            int ret = controladoraBDCasosPrueba.eliminarCasosPrueba(id);
            return ret;
        }

        public DataTable consultarCasosPrueba()
        {
            DataTable dt = controladoraBDCasosPrueba.consultarCasosPrueba();
            return dt;

        }
    }
}