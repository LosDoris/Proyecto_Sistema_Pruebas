﻿using System;
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

        public String solicitarProyectos()
        {
            String proyectos = controladoraProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

        public String solicitarPropositoDiseno(int idProyecto)
        {
            String disenos = controladoraDisenno.solicitarPropositoDiseno(idProyecto);
            return disenos;

        }
    }
}