using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraEjecucionPrueba
    {
        ControladoraBDEjecucionPrueba controladoraBDEjecucionPrueba = new ControladoraBDEjecucionPrueba();
        ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
        ControladoraDisenno  controladoraDisenno  = new ControladoraDisenno();
        ControladoraCasosPrueba controladoraCasosPrueba = new ControladoraCasosPrueba();
        ControladoraRecursosHumanos controladoraRecursosHumanos = new ControladoraRecursosHumanos();


        public string insertarEjecucion(Object[] datosEjecucion)
        {
            EntidadEjecucionPrueba ejecucionPrueba = new EntidadEjecucionPrueba(datosEjecucion);
            string ret = controladoraBDEjecucionPrueba.insertarBDEjecucion(ejecucionPrueba);
            return ret;
        }

        public int insertarNoConformidades(List <Object []> datosNoConformidades, int idEjecucion)
        {
            List<EntidadNoConformidad> listaNoConformidades = null;
            foreach (Object[] dato in datosNoConformidades)
            {
                EntidadNoConformidad noConformidad = new EntidadNoConformidad(dato);
                listaNoConformidades.Add(noConformidad);
            }
            return 0;
        }

        public String solicitarProyectos()
        {
            String proyectos = controladoraProyecto.consultarProyectosConCaso();
            return proyectos;

        }

        public String solicitarPropositoDiseno(int idProyecto)
        {
            String disenos = controladoraDisenno.solicitarPropositoDiseno(idProyecto);
            return disenos;

        }

        public String solicitarCasosdePrueba(int idDisenno)
        {
            String casosDePrueba = controladoraCasosPrueba.solicitarCasosdePrueba(idDisenno);
            return casosDePrueba;
        }

        public String solicitarResponsables(int idProyecto)
        {
            return controladoraRecursosHumanos.solicitarNombreRecursoPorProyecto(idProyecto);
        }

        public int modificarEjecucion(Object[] datos)
        {
            EntidadEjecucionPrueba objEjecucion = new EntidadEjecucionPrueba(datos);
            int ret = controladoraBDEjecucionPrueba.modificarEjecucionPrueba(objEjecucion);
            return ret;
        }

        public int eliminarCasosPrueba(String id)
        {
            int ret = controladoraBDEjecucionPrueba.eliminarEjecucionPrueba(id);
            return ret;
        }

        public DataTable consultarEjecucion(int tipo, String id)
        {
            DataTable dt = controladoraBDEjecucionPrueba.consultarEjecucionPrueba(tipo, id);
            return dt;

        }
    }
}