using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraDisenno
    {
        ControladoraBDDisenno controlBD;
        ControladoraProyecto controlProyecto = new ControladoraProyecto();
        ControladoraRecursosHumanos controlRH = new ControladoraRecursosHumanos();
        ControladoraRequerimiento controlReq = new ControladoraRequerimiento();
        public ControladoraDisenno()
        {
            controlBD = new ControladoraBDDisenno();            
        }

        public int ingresaDiseno(object[] datos)
        {
            EntidadDisenno objDisenno = new EntidadDisenno(datos);
            int a = controlBD.InsertarDiseno(objDisenno);
            return a;
        }


        public String solicitarProyectos()
        {
            
            String proyectos = controlProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

        public String solicitarNombreProyectoMiembro(int id_proyecto)
        {

            String proyectos = controlProyecto.ConsultarNombreProyectoPorId(id_proyecto);
            return proyectos;

        }


        public String solicitarResponsanles(int id_proyecto)
        {
            String responsables = controlRH.solicitarNombreRecursoPorProyecto(id_proyecto);
            return responsables;

        }

        public int solicitarProyecto_Id(string nomb_proyecto)
        {
            int proyectos = controlProyecto.ConsultarIdProyectoPorNombre2(nomb_proyecto);
            return proyectos;

        }

        public int solicitarResponsableCedula(string responsable)
        {
            int cedula = controlRH.solicitarCedulaRecurso(responsable);               
            return cedula;

        }

        public bool loggeadoEsAdmin()
        {
            return controlRH.loggeadoEsAdmin();
        }

        public int solicitarProyecto_IdMiembro()
        {
            return controlRH.proyectosDelLoggeado();

        }

        public DataTable consultarReqNoenDiseno(int id_proyecto, int id_diseno)
        {
            return controlReq.consultarRequerimientoNoEnDiseno(id_proyecto, id_diseno);
        }

        public DataTable consultarReqEnDiseno(int id_proyecto, int id_diseno)
        {
            return controlReq.consultarRequerimientoEnDiseno(id_proyecto, id_diseno);
        }
    }
}