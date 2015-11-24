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
        public String consultarMiembrosProyecto(String nombProy)
        {
            DataTable dt=controlRH.consultarMiembrosProyecto(nombProy);
            String miembros="";
            foreach (DataRow dr in dt.Rows)
            {
                miembros = miembros+ "\n "+dr[0] + ",\n ";
               // dtGrid.Rows.Add(datos);
            }
            return miembros;

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
            return controlReq.consultarReqPorNombre(modulo, controlProy.ConsultarIdProyectoPorNombre(nombre).ToString());
        }

        public EntidadRequerimientos consultarRequerimiento(string nombre, string idProyeto)
        {
            return controlReq.consultarReqUnico(nombre, idProyeto);
        }

        //public PdfPTable reporteProyecto(bool[] campos)
        //{
        //    int i, j;
        //    i = j = 0;
        //    int count = 0;
        //    for (int k = 0; k < campos.Length; k++)
        //    {
        //        if (campos[k])
        //            count++;
        //    }
        //    if (campos[2])
        //        count += 2;
        //    PdfPTable retorno = new PdfPTable(count);

        //    //Se colocan encabezados
        //    if (campos[0])
        //        retorno.AddCell("Nombre del Sistema");
        //    if (campos[1])
        //        retorno.AddCell("Fecha de asignación");
        //    if (campos[2])
        //    {
        //        retorno.AddCell("Oficina del representate");
        //        retorno.AddCell("Teléfono del representante");
        //        retorno.AddCell("Nombre del usuario representate");
        //    }
        //    if (campos[3])
        //        retorno.AddCell("Nombre del lider del proyecto");
        //    if (campos[4])
        //        retorno.AddCell("Objetivo general");
        //    if (campos[5])
        //        retorno.AddCell("Estado");
        //    if (campos[6])
        //        retorno.AddCell("Miembros del equipo");

        //    return retorno;
        //}

        public object[] reporteProyecto(EntidadProyecto entidad)
        {

            

            object[] retorno = new object[9];

            retorno[0] = entidad.Nombre_sistema;

            retorno[2] = entidad.Fecha_asignacion;

            retorno[4] = entidad.Oficina_representante;
            retorno[5] = entidad.Telefono_representante;
            retorno[6] = entidad.Nombre_representante;

            retorno[7] = entidad.LiderProyecto;

            retorno[1] = entidad.Objetivo_general;

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
            retorno[3] = estado;

            //retorno[8] = controlRH.consultarMiembros(entidad.Id_proyecto);
      
            return retorno;
        }

     

        public object[] medicionRequerimiento(string idReq)
        {
            object[] retorno = new object[6];

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

            retorno[0] = idReq;
            retorno[1] = exitosCant;
            retorno[2] = idCasosExitosos;
            retorno[3] = noConformidad;
            retorno[4] = sinEnvaluarCant;
            retorno[5] = idCasosSinEvaluar;

            return retorno;
        }
        /*
            bool[] proyecto = new bool[12];
            proyecto[0] = CheckBoxNombreProyecto.Checked;
            proyecto[1]= CheckBoxNombModulo.Checked;
            proyecto[2]= CheckBoxNombReq.Checked;
            proyecto[3] = CheckBoxFechAsignacionProyecto.Checked;
            proyecto[4] = CheckBoxOficinaProyecto.Checked;
            proyecto[5] = CheckBoxResponsableProyecto.Checked;
            proyecto[6] = CheckBoxObjetivoProyecto.Checked;
            proyecto[7] = CheckBoxEstadoProyecto.Checked;
            proyecto[8] = CheckBoxMiembrosProyecto.Checked;
            proyecto[9] = CheckBoxExitos.Checked;
            proyecto[10] = CheckBoxTipoNoConf.Checked;
            proyecto[11] = CheckBoxCantNoConf.Checked;
        */
        public DataTable crearDT(bool [] campos) {
            DataTable dt = new DataTable();
            if (campos[0])
            {
                dt.Columns.Add("Nombre del Proyecto.", typeof(String));
            }
            if (campos[1])
            {
                dt.Columns.Add("Nombre del Módulo.", typeof(String));
            }
            if (campos[2])
            {
                dt.Columns.Add("Nombre del Requerimiento.", typeof(String));
            }
            if (campos[3])
            {
                dt.Columns.Add("Fecha de asignación.", typeof(String));
            }
            if (campos[4])
            {
                dt.Columns.Add("Oficina usuaria.", typeof(String));
            }
            if (campos[5])
            {
                dt.Columns.Add("Líder.", typeof(String));
            }
            if (campos[6])
            {
                dt.Columns.Add("Objetivo.", typeof(String));
            }
            if (campos[7])
            {
                dt.Columns.Add("Estado del Proyecto.", typeof(String));
            }
            if (campos[8])
            {
                dt.Columns.Add("Miembros del equipo.", typeof(String));
            }
            if (campos[9])
            {
                dt.Columns.Add("Cantidad de éxitos.", typeof(String));
            }
            if (campos[10])
            {
                dt.Columns.Add("Tipos de no conformidad.", typeof(String));
            }
            if (campos[11])
            {
                dt.Columns.Add("Cantidad de no conformidades.", typeof(String));
            }
            return dt;
        }
        public DataTable dtReporte(bool [] campos, String proy, String mod, String req)
        {
            EntidadProyecto entidad = consultarProyecto(proy);
            int k = 0;
            for (int j = 0; j < 12; ++j) {
                if (campos[j] == true) {
                    k = k + 1;
                }
            }
            Object [] datos= new Object[k];
            /*
            bool[] proyecto = new bool[12];
            proyecto[0] = CheckBoxNombreProyecto.Checked;
            proyecto[1]= CheckBoxNombModulo.Checked;
            proyecto[2]= CheckBoxNombReq.Checked

            proyecto[3] = CheckBoxFechAsignacionProyecto.Checked;
            proyecto[4] = CheckBoxOficinaProyecto.Checked;
            proyecto[5] = CheckBoxResponsableProyecto.Checked;//lider

            proyecto[6] = CheckBoxObjetivoProyecto.Checked;
            proyecto[7] = CheckBoxEstadoProyecto.Checked;
            proyecto[8] = CheckBoxMiembrosProyecto.Checked;

            proyecto[9] = CheckBoxExitos.Checked;
            proyecto[10] = CheckBoxTipoNoConf.Checked;
            proyecto[11] = CheckBoxCantNoConf.Checked;
        */
            int i = 0;
            DataTable dt = crearDT(campos);
            if (campos[0])
            {
                datos[i] = entidad.Nombre_sistema;
                i = i + 1;
            }
            else
            {
                //datos[0] = "-";
            }
            if (campos[1])
            {
                datos[i] = mod;
                i = i + 1;
            }
            
            if (campos[2])
            {
                datos[i] = req;
                i = i + 1;
            }
            
            if (campos[3])
            {
                datos[i] = entidad.Fecha_asignacion;
                i = i + 1;
            }
            
            if (campos[4])
            {
                datos[i] = entidad.Oficina_representante+ "\n"+ entidad.Nombre_representante + "\n" + entidad.Telefono_representante;
                i = i + 1;

            }
            
            if (campos[5])
            {
                datos[i] = entidad.LiderProyecto;
                i = i + 1;
            }
            
            if (campos[6])
            {
                datos[i] = entidad.Objetivo_general;
                i = i + 1;
            }
            
            if (campos[7])
            {
                string estado = "";
                if (entidad.Estado != "")
                {
                    switch (Convert.ToInt32(entidad.Estado))
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
                }

                datos[i] = estado;
                i = i + 1;
                //= entidad.Nombre_sistema;
            }
            
            if (campos[8])//miembros
            {
                String miembros = consultarMiembrosProyecto(proy);
                datos[i] = miembros;// entidad.Nombre_sistema;
                i = i + 1;
            }
            
            if (campos[9])//exitos
            {
                datos[i] = "-";//entidad.Nombre_sistema;
                i = i + 1;
            }
            
            if (campos[10])//tipo
            {
                datos[i] = "-";//entidad.Nombre_sistema;
                i = i + 1;
            }
            
            if (campos[11])//cant no conf
            {
                datos[i] = "-";//entidad.Nombre_sistema;
                i = i + 1;
            }
            
            dt.Rows.Add(datos);

            return dt;
        }
    }
}