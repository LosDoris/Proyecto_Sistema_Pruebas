﻿using System;
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

using System.Text.RegularExpressions;
using SistemaPruebas.Controladoras;


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
        /*
         * Requiere: N/A
         * Modifica: Inicializa las controladoras.
         * Retorna: N/A.
         */
        public ControladoraReportes()
        {
            controlProy = new ControladoraProyecto();
            controlDis = new ControladoraDisenno();
            controlCasos = new ControladoraCasosPrueba();
            controlEjec = new ControladoraEjecucionPrueba();
            controlRH = new ControladoraRecursosHumanos();
            controlReq = new ControladoraRequerimiento();
        }
        /*
         * Requiere: N/A
         * Modifica: N/A.
         * Retorna: El tipo de perfil del loggeado.
         */
        public string PerfilDelLogeado()
        {
            return controlRH.perfilDelLoggeado();
        }
        /*
         * Requiere: N/A
         * Modifica: N/A.
         * Retorna: El id de los proyectos del loggeado.
         */
        public int proyectosDelLoggeado()
        {
            return controlRH.proyectosDelLoggeado();
        }
        /*
         * Requiere: N/A
         * Modifica: N/A.
         * Retorna: Un DataTable con los proyectos del loggeado.
         */
        public DataTable consultarProyecto()
        {
            return controlProy.ConsultarProyectoIdNombre();
        }

        /*
         * Requiere: String del nombre del proyecto
         * Modifica: N/A.
         * Retorna: Un String con los miembros del proyecto seleccionado.
         */
        public String consultarMiembrosProyecto(String nombProy)
        {
            DataTable dt = controlRH.consultarMiembrosProyecto(nombProy);
            String miembros = "";
            foreach (DataRow dr in dt.Rows)
            {
                miembros = miembros + "\n " + dr[0] + ",\n ";
                // dtGrid.Rows.Add(datos);
            }
            return miembros;
        }
        /*
         * Requiere: String nombreProyecto
         * Modifica: N/A.
         * Retorna: Entidad proyecto.
         */
        public EntidadProyecto consultarProyecto(string nombre)
        {
            return controlProy.ConsultarProyecto(controlProy.ConsultarIdProyectoPorNombre(nombre));
        }
        /*
        public DataTable consultarDisennos(string nombre)
        {
            return controlDis.consultarDisenoGrid(controlProy.ConsultarIdProyectoPorNombre(nombre));
        }
        public EntidadDisenno consultarDisenno(string nombre)
        {
            return controlDis.consultarDisenno(controlDis.consultarId_Disenno(nombre));
        }
         * */
        /*
         * Requiere: String nombre del requerimiento
         * Modifica: N/A.
         * Retorna: String de casos de prueba.
         */
        public string consultarCasosPrueba(string nombre)
        {
            return controlCasos.solicitarCasosdePrueba(controlDis.consultarId_Disenno(nombre));
        }
        /*
        public DataTable consultarCasoPrueba(string id)
        {
            return controlCasos.consultarCasosPrueba(2, id);
        }
        */

        /*
         * Requiere: String nombreProyecto
         * Modifica: N/A.
         * Retorna: DataTable con los modulos asociados a ese proyecto.
         */
        public DataTable consultarModulos(string nombre)
        {
            return controlReq.consultarModulos(controlProy.ConsultarIdProyectoPorNombre(nombre).ToString());
        }
        /*
         * Requiere: String nombreProyecto y nombre del modulo
         * Modifica: N/A.
         * Retorna: DataTable con los requerimientos asociados a ese modulo.
         */
        public DataTable consultarRequerimientos(string nombre, string modulo)
        {
            return controlReq.consultarReqPorNombre(modulo, controlProy.ConsultarIdProyectoPorNombre(nombre).ToString());
        }
        /*
        public EntidadRequerimientos consultarRequerimiento(string nombre, string idProyeto)
        {
            return controlReq.consultarReqUnico(nombre, idProyeto);
        }
        */

        /*
         * Requiere: String nombreProyecto y nombre del modulo
         * Modifica: N/A.
         * Retorna: List<object> con los datos del proyecto solicitado.
         */
        public List<object> reporteProyecto(EntidadProyecto entidad)
        {

            List<Object> retorno = new List<object>();

            retorno.Add(entidad.Nombre_sistema);
            retorno.Add(entidad.Objetivo_general);
            retorno.Add(entidad.Fecha_asignacion);
            string estado = "";
            if (entidad.Estado != "")
            {
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
            }
            retorno.Add(estado);
            retorno.Add(entidad.Oficina_representante);
            retorno.Add(entidad.Telefono_representante);
            retorno.Add(entidad.Nombre_representante);
            retorno.Add(entidad.LiderProyecto);
            retorno.Add(controlRH.solicitarNombreRecursosPorProyecto(Int32.Parse(entidad.Id_proyecto)));

            return retorno;
        }


        /*
         * Requiere: String nombreProyecto y nombre del modulo
         * Modifica: N/A.
         * Retorna: List<object> con los datos de las mediciones del requerimiento solicitado.
         */
        public List<Object> medicionRequerimiento(List<Object> retorno, string idReq)
        {
            int exitosCant = 0;
            int sinEnvaluarCant = 0;
            List<string> idCasosExitosos = new List<string>();
            List<string> idCasosSinEvaluar = new List<string>();
            Dictionary<string, int> noConformidad = new Dictionary<string, int>();
            string[] casosPrueba = controlCasos.consultarCasoPorRequerimiento(idReq);
            retorno.Add(idReq);
            try
            {
                if (casosPrueba[0] != "")
                {
                    foreach (string casito in casosPrueba)
                    {
                        string[] estado = controlEjec.retornarEstado(casito).Split(';');
                        if (estado[0] != "")
                        {
                            foreach (string estadito in estado)
                            {

                                if (estadito.Split(',')[0] == "Satisfactorio")//Aún no se ha terminado, hay que realizar una consulta en ejecución.//Se supone caso exitoso
                                {
                                    exitosCant++;
                                    idCasosExitosos.Add(casito);
                                }
                                else if (estado.Length > 1 && estadito.Split(',')[1] == "Fallido")//Se supone caso de no conformidad
                                {
                                    string key = estadito.Split(',')[0];
                                    if (noConformidad.ContainsKey(key))//Se suma una nueva no conformidad
                                    {
                                        noConformidad[key]++;
                                    }
                                    else//Se agrega nueva no conformidad
                                    {
                                        noConformidad.Add(key, 1);
                                    }
                                }
                                else if (estadito.Split(',')[0] == "Pendiente")//casos de prueba que no han sido evaluados aún
                                {
                                    sinEnvaluarCant++;
                                    idCasosSinEvaluar.Add(casito);
                                }
                            }
                        }                        
                    }
                    string CasosEx = "";
                    if (exitosCant > 0)
                    {
                        CasosEx = "Cantidad de casos exitosos: " + exitosCant.ToString() + "\nCasos que son exitosos:";
                        foreach (string rr in idCasosExitosos){
                            CasosEx += "\n\t" + rr+", ";
                        }
                    }
                        
                    else
                        CasosEx = "No hay casos de prueba exitosos.";
                    retorno.Add(CasosEx);

                    string noConf = "";
                    
                    double[] fallidosInt = new double[noConformidad.Count];
                    double[] fallidosPorc = new double[noConformidad.Count];
                    string[] fallidosString = new string[noConformidad.Count];
                    double total = 0;

                    int i = 0;
                    foreach (KeyValuePair<string, int> entry in noConformidad)
                    {

                        fallidosInt[i] = entry.Value;
                        total += entry.Value;
                        fallidosString[i] = entry.Key;
                        i++;
                    }

                    if (total > 0)
                    {
                        i = 0;
                        foreach (double d in fallidosInt)
                        {
                            fallidosPorc[i] = (d / total) * 100;
                            i++;
                        }

                        noConf = "Tipos de no conformidad:\n";
                        for (int j = 0; j < fallidosInt.Length; j++)
                        {
                            noConf += "\t" + fallidosString[j] + ": " + fallidosInt[j] + " - " + fallidosPorc[j] + "%, \n";
                        }                      
                    }
                    else
                        noConf = "No hay casos de prueba con no conformidades.";
                    retorno.Add(noConf);
                    string sinEv = "";
                    if (sinEnvaluarCant > 0)
                    {
                        sinEv = "Casos de prueba pendientes:";
                        foreach (string sin in idCasosSinEvaluar)
                        {
                            sinEv += "\n\t" + sin+",";
                        }                        
                    }
                    else
                        sinEv = "No hay casos de prueba pendientes.";
                    retorno.Add(sinEv);
                }
                else
                {
                    retorno.Add("");
                    retorno.Add("");
                    retorno.Add("");
                }
            }
            catch {
                retorno.Add("");
                retorno.Add("");
                retorno.Add("");
            }
            return retorno;

        }
        /*
        public DataTable crearDT(bool[] campos)
        {
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


        /*
        public DataTable dtReporte(bool[] campos, String proy, String mod, String req)
        {
            EntidadProyecto entidad = consultarProyecto(proy);
            int k = 0;
            for (int j = 0; j < 12; ++j)
            {
                if (campos[j] == true)
                {
                    k = k + 1;
                }
            }
            Object[] datos = new Object[k];

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
                datos[i] = entidad.Oficina_representante + "\n" + entidad.Nombre_representante + "\n" + entidad.Telefono_representante;
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
        }*/
    }
}