using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraRecursosHumanos
    {
        ControladoraBDRecursosHumanos controladoraBDRecursosHumanos = new ControladoraBDRecursosHumanos();

        public int insertarRecursoHumano(Object[] datos)
        {
            //datos[0];
            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            controladoraBDRecursosHumanos.insertarRecursoHumanoBD(recursoHumano);

            return 0;
        }

        /* public int modificarRescursoHumano(Object[] nuevosDatos)
         {
             //EntidadRecursosHumanos 

             return 0;
         }*/
        public int modificarRecursoHumano(Object[] datos)
        {
            //datos[0];

            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            controladoraBDRecursosHumanos.modificarRecursoHumanoBD(recursoHumano);
            return 0;
        }

        public DataTable consultarRecursoHumano(int tipo, int cedula)
        {
            DataTable dt;//dummy       
            dt = controladoraBDRecursosHumanos.consultarRecursoHumanoBD(tipo, cedula);
            return dt;

        }

        public int eliminarRecursoHumano(int cedula)
        {
            controladoraBDRecursosHumanos.eliminarRecursoHumano(cedula);
            return 1;
        }


    }
}