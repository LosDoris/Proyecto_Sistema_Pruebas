using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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
            //reporteProyecto(consultarProyecto(nombreP), camposP);
            //Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            //Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
            //using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            //{
            //    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            //    Phrase phrase = null;
            //    PdfPCell cell = null;
            //    PdfPTable table = null;
            //    System.Drawing.Color color = null;

            //    document.Open();

            //    //Header Table
            //    table = new PdfPTable(2);
            //    table.TotalWidth = 500f;
            //    table.LockedWidth = true;
            //    table.SetWidths(new float[] { 0.3f, 0.7f });


            //    //Company Name and Address
            //    phrase = new Phrase();
            //    phrase.Add(new Chunk("Microsoft Northwind Traders Company\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.RED)));
            //    phrase.Add(new Chunk("107, Park site,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //    phrase.Add(new Chunk("Salt Lake Road,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //    phrase.Add(new Chunk("Seattle, USA", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
            //    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            //    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            //    table.AddCell(cell);
            //}
            return 0;
        }

    }
}