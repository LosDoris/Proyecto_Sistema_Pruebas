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

        ControladoraProyecto controladoraProyecto = new ControladoraProyecto();

        public bool usuarioMiembroEquipo(Object[] datos)
        {
            string[] nombresYContrasenas= controladoraBDRecursosHumanos.nombresContrasenas();
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
            return controladoraBDRecursosHumanos.modificaContrasena(datos[0].ToString(), datos[1].ToString()); 
        }

        public bool loggeado(string nombre)
        {
            return controladoraBDRecursosHumanos.loggeado(nombre);
        }

        public bool estadoLoggeado(string nombre, string estado)
        {
            return controladoraBDRecursosHumanos.estadoLoggeado(nombre, estado);
        }

        public int insertarRecursoHumano(Object[] datos)
        {
            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            int ret =controladoraBDRecursosHumanos.insertarRecursoHumanoBD(recursoHumano);
            return ret;
        }

        public int modificarRecursoHumano(Object[] datos)
        {
            //datos[0];

            EntidadRecursosHumanos recursoHumano = new EntidadRecursosHumanos(datos);
            controladoraBDRecursosHumanos.modificarRecursoHumanoBD(recursoHumano);
            return 0;
        }

        public DataTable consultarRecursoHumano(int tipo, int cedula)
        {
            DataTable dt = controladoraBDRecursosHumanos.consultarRecursoHumanoBD(tipo, cedula);
            return dt;

        }

        public int eliminarRecursoHumano(int cedula)
        {
            int regresa = 0;
            if (controladoraBDRecursosHumanos.eliminarRecursoHumano(cedula))
            {
                regresa = 0;
            }
            else
            {
                regresa = 1;
            }
            return regresa;
        }

        public String solicitarProyectos()
        {
            String proyectos = controladoraProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

    }
}