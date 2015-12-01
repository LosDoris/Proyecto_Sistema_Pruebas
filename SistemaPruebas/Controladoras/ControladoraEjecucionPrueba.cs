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


        public String insertarEjecucion(Object[] datosEjecucion, List<Object[]> datosNoConformidades)
        {
            EntidadEjecucionPrueba ejecucionPrueba = new EntidadEjecucionPrueba(datosEjecucion);
            string ret = controladoraBDEjecucionPrueba.insertarBDEjecucion(ejecucionPrueba);
            insertarNoConformidades(datosNoConformidades, ret);
            return ret;
        }

        public int insertarNoConformidades(List <Object []> datosNoConformidades, String idEjecucion)
        {
            foreach (Object[] dato in datosNoConformidades)
            {
                if (dato[0] != "Seleccionar" && dato[1] != "Seleccionar" && dato[2]!="" && dato[3]!=""
                    && dato[5] != "Seleccionar" && dato[6] != null && dato[7] != "0")
                {
                    dato[6] = idEjecucion;
                    EntidadNoConformidad noConformidad = new EntidadNoConformidad(dato);
                    controladoraBDEjecucionPrueba.insertarBDnoConformidad(noConformidad);
                }
                
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

        public String modificarEjecucion(Object[] datos, List<Object[]> datosNoConformidades)
        {
            EntidadEjecucionPrueba objEjecucion = new EntidadEjecucionPrueba(datos);
            String ret = controladoraBDEjecucionPrueba.modificarEjecucionPrueba(objEjecucion);
            modificarNoConformidades(datosNoConformidades, ret);
            return ret;
        }

        public int modificarNoConformidades(List<Object[]> datosNoConformidades, String idEjecucion)
        {
            foreach (Object[] dato in datosNoConformidades)
            {
                dato[6] = idEjecucion;
                EntidadNoConformidad noConformidad = new EntidadNoConformidad(dato);
                controladoraBDEjecucionPrueba.modificarBDNoConformidad(noConformidad);
            }
            return 0;
        }

        public int eliminarEjecucionPrueba(String id)
        {
            int ret = controladoraBDEjecucionPrueba.eliminarEjecucionPrueba(id);
            return ret;
        }

        public DataTable consultarEjecucion(int tipo, String id)
        {
            DataTable dt = controladoraBDEjecucionPrueba.consultarEjecucionPrueba(tipo, id);
            return dt;

        }

        public DataTable consultarNoConformidades(String fecha)
        {
            DataTable dt = controladoraBDEjecucionPrueba.consultarBDNoConformidad(fecha);
            return dt;
        }

        public string retornarEstado(String idCasoPrueba)
        {
            return controladoraBDEjecucionPrueba.retornarEstado(idCasoPrueba);
        }

        public int eliminarBDNoConformidad(string id_noConformidad)
        {
            return controladoraBDEjecucionPrueba.eliminarBDNoConformidad(id_noConformidad);
        }

        public int cantidadNoConformidades(string id_ejecucion)
        {
            return controladoraBDEjecucionPrueba.cantidadNoConformidades(id_ejecucion);
        }
    }
}