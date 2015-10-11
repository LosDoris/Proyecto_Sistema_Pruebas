using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDRecursosHumanos
    {
		Acceso.Acceso a = new Acceso.Acceso();

        public bool loggeado(string nombre)
        {
            bool regresa = false;
            DataTable DR = a.ejecutarConsultaTabla("select nombre, loggeado from persona");
            try
            {
                foreach (DataRow row in DR.Rows)
                {
                    if (row["nombre"].ToString() == nombre
                        && (int)row["loggeado"]==1) {
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
            DataTable DR = a.ejecutarConsultaTabla("select * from persona");
            string[] regresa = new string[2];
            string nombres = "";
            string contrasenas = "";

            try {
                foreach (DataRow row in DR.Rows)
                {
                    if (nombres != "")
                        nombres += ";";
                    nombres += row["nombre"].ToString();

                    if (contrasenas != "")
                        contrasenas += ";";
                    contrasenas += row["contrasena"].ToString();

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
            if (a.Insertar("update persona set contrasena = '" + nuevaContrasena +
                        "' where nombre = '" + nombre + "'") == 1)
            {
                regresa = true;
            }
            else {
                regresa = false;
            }
                
            return regresa;

        }
		/**/
		
		
		
		
		
        public void insertarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {
            //conexion y la inserta


        }
        public void modificarRecursoHumanoBD(EntidadRecursosHumanos recursoHumano)
        {



        }

        public void eliminarRecursoHumano(int cedula)
        {


        }

        public DataTable consultarRecursoHumanoBD(int tipo, int cedula)
        {
            DataTable dt = new DataTable();
            return dt;

        }



    }
}