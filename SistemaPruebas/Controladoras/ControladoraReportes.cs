using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
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

        public ControladoraReportes()
        {
            controlProy = new ControladoraProyecto();
            controlDis = new ControladoraDisenno();
            controlCasos = new ControladoraCasosPrueba();
            controlEjec = new ControladoraEjecucionPrueba();
            controlRH = new ControladoraRecursosHumanos();
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

        public PdfPTable reporteProyecto(EntidadProyecto entidad, bool[] campos)
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



            //Se añaden datos a la tabla
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
        public string generarReporte(string nombreP, bool[] camposP)
        {
            //Document doc = new Document(PageSize.LETTER);
            //var output = new System.IO.FileStream(Server.MapPath("MyFirstPDF.pdf"), System.IO.FileMode.Create);
            //var writer = PdfWriter.GetInstance(doc, output);
            //doc.Open();

            ///** Logo del reporte**/
            ////var logo = iTextSharp.text.Image.GetInstance(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/orderedList5.png"));
            ////logo.SetAbsolutePosition(430, 770);
            ////logo.ScaleAbsoluteHeight(30);
            ////logo.ScaleAbsoluteWidth(70);
            ////doc.Add(logo);

            ///*Se agregan datos de proyecto, en caso de ser seleccionado*/
            //if (nombreP != "")           
            //    doc.Add(new Paragraph(reporteProyecto(consultarProyecto(nombreP), camposP)));

            ///*Se cierra documento*/
            //doc.Close();
            ////Response.Redirect("~/MyFirstPDF.pdf");           
            //Page.ClientScript.RegisterStartupScript(
            //   this.GetType(), "OpenWindow", "window.open('MyFirstPDF.pdf','_newtab');", true);
            return "";
        }
    }
}