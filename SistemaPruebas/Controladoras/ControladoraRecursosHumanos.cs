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
		ControladoraBDRecursosHumanos controladoraBDrh = new ControladoraBDRecursosHumanos();
        public bool usuarioMiembroEquipo(Object[] datos)
        {
            string[] nombresYContrasenas= controladoraBDrh.nombresContrasenas();
            if (nombresYContrasenas != null) {
                string nombreIngresado = datos[0].ToString();
                string contrasenaIngresada = datos[1].ToString();

                if (nombresYContrasenas[0].Contains(nombreIngresado)
                    && nombresYContrasenas[1].Contains(contrasenaIngresada))
                {
                    return true;
                }
            }
            return false;
        }
		public bool modificaContrasena(Object[] datos)
        {
            return controladoraBDrh.modificaContrasena(datos[0].ToString(), datos[1].ToString()); 
        }

        public bool loggeado(string nombre)
        {
            return controladoraBDrh.loggeado(nombre);
        }

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