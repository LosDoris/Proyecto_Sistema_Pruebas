﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDRecursosHumanos
    {
		Acceso.Acceso acceso = new Acceso.Acceso();

        public bool loggeado(string nombre)
        {
            bool regresa = false;
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT nombre_completo, esta_loggeado FROM Recurso_Humano");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    if (row["nombre_completo"].ToString() == nombre
                        && (int)row["esta_loggeado"]==1) {
                        regresa = true;
                    }
                        
                }
            }
            catch (System.InvalidOperationException)
            {
                regresa = false;
            }


            return regresa;
        }

        public string[] nombresContrasenas()
        {
            DataTable DR = acceso.ejecutarConsultaTabla("SELECT * FROM Recurso_Humano");
            string[] regresa = new string[2];
            string nombres = "";
            string contrasenas = "";

            try {
                foreach (DataRow row in DR.Rows)
                {
                    if (nombres != "")
                        nombres += ";";
                    nombres += row["nombre_completo"].ToString();

                    if (contrasenas != "")
                        contrasenas += ";";
                    contrasenas += row["contrasenna"].ToString();

                }
                regresa[0] = nombres;
                regresa[1] = contrasenas;
            }
            catch (System.InvalidOperationException) {
                return null;
            }


            return regresa;
        }

        public bool modificaContrasena(string nombre, string nuevaContrasena) {
            bool regresa = false;
            if (acceso.Insertar("UPDATE Recurso_Humano SET contrasenna = '" + nuevaContrasena +
                        "' WHERE nombre_completo = '" + nombre + "'") == 1)
            {
                regresa = true;
            }
            else {
                regresa = false;
            }
                
            return regresa;

        }

        public bool estadoLoggeado(string nombre, string estado)
        {
            bool regresa = false;
            if (acceso.Insertar("UPDATE Recurso_Humano SET esta_loggeado = '" + estado +
                        "' WHERE nombre_completo = '" + nombre + "'") == 1)
            {
                regresa = true;
            }
            else
            {
                regresa = false;
            }

            return regresa;

        }
        /**/





        public int insertarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {
            String consulta = "INSERT INTO Recurso_Humano(cedula, nombre_completo, telefono1, telefono2, correo_electronico, usuario, contrasenna, perfil_acceso, rol, id_proyecto) values(" + recursoHumano.Cedula + "','" + recursoHumano.Nombre_Completo + "','" + recursoHumano.Tel1 + "','" + recursoHumano.Tel2 + "','" + recursoHumano.Correo + "','" + recursoHumano.Usuario + "','" + recursoHumano.Clave + "','" + recursoHumano.PerfilAcceso + "','" + recursoHumano.Rol + "'," + recursoHumano.ProyAsociado+")";
            int ret = acceso.Insertar(consulta);
            return ret;

        }

        public void modificarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {



        }

        public void eliminarRecursoHumano(int cedula)
        {


        }

        public DataTable consultarRecursoHumanoBD(int tipo, int cedula)
        {
            String consulta = "SELECT cedula, nombre_completo, usuario FROM Recurso_Humano";
            DataTable dt = acceso.ejecutarConsultaTabla(consulta);
            return dt;

        }



    }
}