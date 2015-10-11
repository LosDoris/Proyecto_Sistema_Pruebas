using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SistemaPruebas.Controladoras
{
    public class ControladoraBDProyecto
    {
        Acceso.Acceso acceso_BD= new Acceso.Acceso();

        public ControladoraBDProyecto()
        {

        }

        public int InsertarProyecto(EntidadProyecto datos)
        {
            using (SqlCommand comando = new SqlCommand("dbo.Insertar_Proyecto"))
            {
                //  comando.CommandText = "Insertar_Proyecto";
                comando.CommandType = CommandType.StoredProcedure;

                //  comando.Parameters.Add(new SqlParameter("@id_proyecto", datos.Id_proyecto));

                comando.Parameters.Add(new SqlParameter("@nombre_sistema", datos.Nombre_sistema));

                comando.Parameters.Add(new SqlParameter("@objetivo_general", datos.Objetivo_general));

                comando.Parameters.Add(new SqlParameter("@fecha_asignacion", datos.Fecha_asignacion));

                comando.Parameters.Add(new SqlParameter("@estado", datos.Estado));

                comando.Parameters.Add(new SqlParameter("@nombre_rep", datos.Nombre_representante));

                comando.Parameters.Add(new SqlParameter("@telefono_rep", datos.Telefono_representante));

                comando.Parameters.Add(new SqlParameter("@oficina_rep", datos.Oficina_representante));

               return acceso_BD.Insertar_Proced_Almacenado(comando);
                // return comando;


            }
        }

        /*    public int InsertarProyecto(EntidadProyecto datos)
            {
          /*     sqlconnection sqlconnection = new sqlconnection(conexion);
                                sqlconnection.open();

                string consulta = "insert into proyecto values(@id_proyecto, @nombre_sistema, @objetivo_general,  @fecha_asignacion, @estado, @nombre_rep, @telefono_rep, @oficina_rep)";
                sqlcommand comando = null;
                int a = 0;

                            string consulta = "insert into proyecto values('"+datos.id+"', '" @nombre_sistema, @objetivo_general,  @fecha_asignacion, @estado, @nombre_rep, @telefono_rep, @oficina_rep)";


                sqlparameter id_proyecto = new sqlparameter("@id_proyecto", sqldbtype.varchar);
                id_proyecto.value = datos.id_proyecto;

                sqlparameter nombre_sistema = new sqlparameter("@nombre_sistema", sqldbtype.varchar);
                nombre_sistema.value = datos.nombre_sistema;

                sqlparameter objetivo_general = new sqlparameter("@objetivo_general", sqldbtype.varchar);
                objetivo_general.value = datos.objetivo_general;


                sqlparameter fecha_asignacion = new sqlparameter("@fecha_asignacion", sqldbtype.date);
                fecha_asignacion.value = datos.fecha_asignacion;

                sqlparameter estado = new sqlparameter("@estado", sqldbtype.tinyint,1);
                estado.value = datos.estado;

                sqlparameter nombre_rep = new sqlparameter("@nombre_rep", sqldbtype.varchar);
                nombre_rep.value = datos.nombre_representante;


                sqlparameter telefono_rep = new sqlparameter("@telefono_rep", sqldbtype.varchar);
                telefono_rep.value = datos.telefono_representante;


                sqlparameter oficina_rep = new sqlparameter("@oficina_rep", sqldbtype.varchar);
                oficina_rep.value = datos.oficina_representante;
          try
                {
                    comando = new sqlcommand(consulta, sqlconnection);


                    comando.parameters.add(id_proyecto);
                    comando.parameters.add(nombre_sistema);
                    comando.parameters.add(objetivo_general);
                    comando.parameters.add(fecha_asignacion);
                    comando.parameters.add(estado);
                    comando.parameters.add(nombre_rep);
                    comando.parameters.add(telefono_rep);
                    comando.parameters.add(oficina_rep);

                    a = comando.executenonquery();
          }
            
                catch (sqlexception ex)
                {
                    string mensajeerror = ex.tostring();
                    system.web.httpcontext.current.response.write("<script language=""javascript"">alert("error de conexion con la ")</script>")
                }

                try
                {
                    sqlconnection.close();
                }
                catch (sqlexception e)
                {
                    string mensajeerror = e.tostring();
                    messagebox.show(mensajeerror);
                }
                return a;

         
            }
       */
        public List<string> ConsultarProyectoUsuario(string msg)
        {
            return null;
        }

        public List<string> ConsultarProyectoAdm(string msg)
        {
            return null;
        }

        public List<string> ConsultaIdProyecto()
        {
            List<string> retorno = new List<string>();
            return retorno;
        }
        public List<string> ConsultarProyecto(string msg)
        {
            return null;
        }


        public int EliminarProyecto(string msg)
        {

            return 0;
        }

        public int ActualizarProycto(string msg)
        {
            return 0;
        }
    }
}