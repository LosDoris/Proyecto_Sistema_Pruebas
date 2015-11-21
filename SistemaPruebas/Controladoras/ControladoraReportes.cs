using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace SistemaPruebas.Controladoras
{
    public class ControladoraReportes
    {
        ControladoraProyecto controlProy;
        ControladoraDisenno controlDis;
        ControladoraCasosPrueba controlCasos;
        ControladoraEjecucionPrueba controlEjec;
        ControladoraRecursosHumanos controlRH;
        ControladoraRequerimiento controlReq;

        public ControladoraReportes()
        {
            controlProy = new ControladoraProyecto();
            controlDis = new ControladoraDisenno();
            controlCasos = new ControladoraCasosPrueba();
            controlEjec = new ControladoraEjecucionPrueba();
            controlRH = new ControladoraRecursosHumanos();
            controlReq = new ControladoraRequerimiento();
        }

        public string PerfilDelLogeado()
        {
            return controlRH.perfilDelLoggeado();
        }
        public int proyectosDelLoggeado()
        {
            return controlRH.proyectosDelLoggeado();
        }

        public DataTable consultarProyecto()
        {
            return controlProy.ConsultarProyectoIdNombre();
        }
        public EntidadProyecto consultarProyecto(string nombre)
        {
            return controlProy.ConsultarProyecto(controlProy.ConsultarIdProyectoPorNombre(nombre));
        }
        public DataTable consultarDisennos(string nombre)
        {
            return controlDis.consultarDisenoGrid(controlProy.ConsultarIdProyectoPorNombre(nombre));
        }
        public EntidadDisenno consultarDisenno(string nombre)
        {
            return controlDis.consultarDisenno(controlDis.consultarId_Disenno(nombre));           
        }
        public string consultarCasosPrueba(string nombre)
        {
            return controlCasos.solicitarCasosdePrueba(controlDis.consultarId_Disenno(nombre));
        }

        public DataTable consultarCasoPrueba(string id)
        {
            return controlCasos.consultarCasosPrueba(2, id);
        }

        public DataTable consultarModulos(string nombre)
        {
            return controlReq.consultarModulos(controlProy.ConsultarIdProyectoPorNombre(nombre).ToString());
        }

        public DataTable consultarRequerimientos(string nombre, string modulo)
        {
            return controlReq.consultarReqPorNombre (modulo, controlProy.ConsultarIdProyectoPorNombre(nombre).ToString());
        }

        public EntidadRequerimientos consultarRequerimiento(string nombre, string idProyeto)
        {
            return controlReq.consultarReqUnico(nombre, idProyeto);
        }

        public PdfPTable reporteProyecto(bool[] campos)
        {
            int i, j;
            i = j = 0;
            int count = 0;
            for (int k = 0; k < campos.Length; k++)
            {
                if (campos[k])
                    count++;
            }
            if (campos[2])
                count += 2;
            PdfPTable retorno = new PdfPTable(count);

            //Se colocan encabezados
            if (campos[0])
                retorno.AddCell("Nombre del Sistema");
            if (campos[1])
                retorno.AddCell("Fecha de asignación");
            if (campos[2])
            {
                retorno.AddCell("Oficina del representate");
                retorno.AddCell("Teléfono del representante");
                retorno.AddCell("Nombre del usuario representate");
            }
            if (campos[3])
                retorno.AddCell("Nombre del lider del proyecto");
            if (campos[4])
                retorno.AddCell("Objetivo general");
            if (campos[5])            
                retorno.AddCell("Estado");            
            if (campos[6])            
                retorno.AddCell("Miembros del equipo");

            return retorno;           
        }

        public PdfPTable reporteProyecto(EntidadProyecto entidad, PdfPTable retorno, bool[] campos)
        {                      
            if (campos[0])
                retorno.AddCell(entidad.Nombre_sistema);
            if (campos[1])
                retorno.AddCell(entidad.Fecha_asignacion);
            if (campos[2])
            {
                retorno.AddCell(entidad.Oficina_representante);
                retorno.AddCell(entidad.Telefono_representante);
                retorno.AddCell(entidad.Nombre_representante);
            }
            if (campos[3])
                retorno.AddCell(entidad.LiderProyecto);
            if (campos[4])
                retorno.AddCell(entidad.Objetivo_general);
            if (campos[5])
            {
                string estado = "";
                switch (Int32.Parse(entidad.Estado))
                {

                    case 1:
                        {
                            estado = "Pendiente";
                        }
                        break;
                    case 2:
                        {
                            estado = "Asignado";
                        }
                        break;
                    case 3:
                        {
                            estado = "En ejecución";
                        }
                        break;
                    case 4:
                        {
                            estado = "Finalizado";
                        }
                        break;
                    case 5:
                        {
                            estado = "Cerrado";
                        }
                        break;
                }
                retorno.AddCell(estado);
            }

            if (campos[6])
            { }
            //  retorno.AddCell(entidad.Nombre_sistema);
            return retorno;
        }


        public int generarReporte(string nombreP, string nombreD, string idC)
        {

            return 0;
        }

        public object[] medicionRequerimiento(string idReq)
        {
            object []retorno = new object[5];

            int exitosCant = 0;
            int sinEnvaluarCant = 0;
            List<string> idCasosExitosos = new List<string>();
            List<string> idCasosSinEvaluar = new List<string>();
            Dictionary<string, int> noConformidad = new Dictionary<string, int>();

            string[] casosPrueba = controlCasos.consultarCasoPorRequerimiento(idReq);

            foreach (string casito in casosPrueba)
            {
                if (true)//Aún no se ha terminado, hay que realizar una consulta en ejecución.//Se supone caso exitoso
                {
                    exitosCant++;
                    idCasosExitosos.Add(casito);
                }
                else if (true)//Se supone caso de no conformidad
                {
                    string key = "";
                    if (noConformidad.ContainsKey(key))//Se suma una nueva no conformidad
                    {
                        noConformidad[key]++;
                    }
                    else//Se agrega nueva no conformidad
                    {
                        noConformidad.Add(key, 1);
                    }
                }
                else//casos de prueba que no han sido evaluados aún
                {
                    sinEnvaluarCant++;
                    idCasosSinEvaluar.Add(casito);
                }
            }

            retorno[0] = exitosCant;
            retorno[1] = idCasosExitosos;
            retorno[2] = noConformidad;
            retorno[3] = sinEnvaluarCant;
            retorno[4] = idCasosSinEvaluar;

            return retorno;
        }
    }
}