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

namespace SistemaPruebas.Controladoras
{
    public class ControladoraReportes
    {
        ControladoraProyecto controlProy;
        ControladoraDisenno controlDis;
        ControladoraCasosPrueba controlCasos;
        ControladoraEjecucionPrueba controlEjec;

        public ControladoraReportes()
        {
            controlProy = new ControladoraProyecto();
            controlDis = new ControladoraDisenno();
            controlCasos = new ControladoraCasosPrueba();
            controlEjec = new ControladoraEjecucionPrueba();
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

        private string reporteProyecto(EntidadProyecto entidad, bool[] campos)
        {
            string retorno = "";
            if (campos[0])
                retorno += "El nombre del sistema es: " + "\t" + entidad.Nombre_sistema;
            return retorno;
        }
        public int generarReporte(string nombreP, string nombreD, string idC)
        {

            return 0;
        }
        public int generarReporte(string nombreP, bool[] camposP)
        {
            Document doc = new Document(PageSize.LETTER);
            var output = new System.IO.FileStream(Server.MapPath("MyFirstPDF.pdf"), System.IO.FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);
            doc.Open();
            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/orderedList5.png"));
            logo.SetAbsolutePosition(430, 770);
            logo.ScaleAbsoluteHeight(30);
            logo.ScaleAbsoluteWidth(70);
            doc.Add(logo);
            doc.Add(new Paragraph("Hello World"));
            doc.Close();
            //Response.Redirect("~/MyFirstPDF.pdf");           
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('MyFirstPDF.pdf','_newtab');", true);

            return 0;
        }

    }
}