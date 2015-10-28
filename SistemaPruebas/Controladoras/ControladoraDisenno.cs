using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraDisenno
    {
        ControladoraBDDisenno controlBD;
        ControladoraProyecto controlProyecto = new ControladoraProyecto();
        ControladoraRecursosHumanos controlRH = new ControladoraRecursosHumanos();

        public ControladoraDisenno()
        {
            controlBD = new ControladoraBDDisenno();            
        } 

        public int ingresaProyecto(object[] datos)
        {
            EntidadDisenno objDisenno = new EntidadDisenno(datos);
            int a = controlBD.insertarDisennoBD(objDisenno);
            return a;
        }


        public String solicitarProyectos()
        {
            String proyectos = controlProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

        public String solicitarResponsanles(int id_proyecto)
        {
            String responsables = controlRH.solicitarNombreRecursoPorProyecto(id_proyecto);
            return responsables;

        }

        public int solicitarProyecto_Id(string nomb_proyecto)
        {
            int proyectos = controlProyecto.ConsultarIdProyectoPorNombre(nomb_proyecto);
            return proyectos;

        }
    }
}