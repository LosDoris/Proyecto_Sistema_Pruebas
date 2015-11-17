using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraEjecucionPrueba
    {
        ControladoraBDEjecucionPrueba controladoraBDEjecucionPrueba = new ControladoraBDEjecucionPrueba();
        ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
        ControladoraDisenno  controladoraDisenno  = new ControladoraDisenno();
        ControladoraCasosPrueba controladoraCasosPrueba = new ControladoraCasosPrueba();
        ControladoraRecursosHumanos controladoraRecursosHumanos = new ControladoraRecursosHumanos();

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
    }
}