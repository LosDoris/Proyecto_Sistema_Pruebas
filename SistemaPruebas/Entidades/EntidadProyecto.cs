﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPruebas.Controladoras
{
    public class EntidadProyecto
    {
//<<<<<<< HEAD
//<<<<<<< HEAD
        // Variables correspondientes a la entidad cliente
        private String id_proyecto;
        private String nombre_sistema;
        private String objetivo_general;
        private String fecha_asignacion;
        private String estado;
        private String nombre_representante;
        private String telefono_representante;
        private String oficina_representante;

        public EntidadProyecto(string id, string nombre, string obj, string fecha, string est, string nomb_rep, string tel_rep, string of_rep)
        {
            id_proyecto = id;
            Nombre_sistema = nombre;
            objetivo_general = obj;
            fecha_asignacion = fecha;
            estado = est;
            Nombre_representante = nomb_rep;
            telefono_representante = tel_rep;
            oficina_representante = of_rep;
        }

        public EntidadProyecto(Object[] datos)
        { // Constructor donde se inicializan las variables de la clase
            this.id_proyecto = datos[0].toString();
            this.nombre_sistema = datos[1].toString();
            this.objetivo_general = datos[2].toString();
            this.fecha_asignacion = datos[3].toString();
            this.estado = datos[4].toString();
            this.nombre_representante = datos[5].toString();
            this.telefono_representante = datos[6].toString();
            this.oficina_representante = datos[7].toString();
        }

        //Metodos set y get para la variable id_proyecto
        public String Id_proyecto
        {
            get { return id_proyecto; }
            set { id_proyecto = value; }
        }

        //Metodos set y get para la variable nombre_sistema
        public String Nombre_sistema
        {
            get { return nombre_sistema; }
            set { nombre_sistema = value; }
        }

        //Metodos set y get para la variable objetivo_general
        public String Objetivo_general
        {
            get { return objetivo_general; }
            set { objetivo_general = value; }
        }

        //Metodos set y get para la variable fecha_asignacion
        public String Fecha_asignacion
        {
            get { return fecha_asignacion; }
            set { fecha_asignacion = value; }
        }

        //Metodos set y get para la variable estado
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        //Metodos set y get para la variable telefono_representante
        public String Nombre_representante
        {
            get { return nombre_representante; }
            set { nombre_representante = value; }
        }

        public String Telefono_representante
        {
            get { return telefono_representante; }
            set { telefono_representante = value; }
        }

        //Metodos set y get para la variable oficina_representante
        public String Oficina_representante
        {
            get { return oficina_representante; }
            set { oficina_representante = value; }
        }
//=======
//=======

//>>>>>>> origin/master
//        String conexion = "Data Source=eccibdisw; Initial Catalog=g2inge; Integrated Security=SSPI";

//        public SqlDataReader ejecutarConsulta(String consulta)
//        {
//            SqlConnection sqlConnection = new SqlConnection(conexion);
//            sqlConnection.Open();

//            SqlDataReader datos = null;
//            SqlCommand comando = null;

//            try
//            {
//                comando = new SqlCommand(consulta, sqlConnection);
//                datos = comando.ExecuteReader();
//            }
//            catch (SqlException ex)
//            {
//                string mensajeError = ex.ToString();
//             //   MessageBox.Show(mensajeError);
//            }

//            return datos;
//        }

//        public void insertarConsulta_puesto(String id_proyecto, String nombre_sistema, String objetivo_general, String fecha_asignacion, String estado, String nombre_representante, String telefono_representante, String oficina_representante)
//        {
//            SqlConnection sqlConnection = new SqlConnection(conexion);
//            sqlConnection.Open();

//            // Consulta(Codigo_Oficio, Tema, Descripcion, Fecha_Consulta, Fecha_Resp)
//            // Sobre_Puesto(Numero_Gaceta, Numero_Decreto, Codigo_Oficio)

//            /**/
//            String instruccion_consulta = "insert into Proyecto(Codigo_Oficio, Tema, Descripcion, Fecha_Consulta, Fecha_Resp)" +
//            "values(@Codigo_Oficio, @Tema, @Descripcion, @Fecha_Consulta, @Fecha_Resp)";


//            SqlCommand comando_consulta = null;

//            SqlParameter codigo_oficio = new SqlParameter("@Codigo_Oficio", SqlDbType.VarChar);
//            codigo_oficio.Value = Codigo_OficioR;
//            SqlParameter tema = new SqlParameter("@Id", SqlDbType.VarChar);
//            if (TemaR == "")
//            {
//                tema.Value = DBNull.Value;
//            }
//            else
//            {
//                tema.Value = TemaR;
//            }
//            SqlParameter descripcion = new SqlParameter("@Nombre", SqlDbType.VarChar);
//            if (DescripcionR == "")
//            {
//                descripcion.Value = DBNull.Value;
//            }
//            else
//            {
//                descripcion.Value = DescripcionR;
//            }
//            SqlParameter fecha_consulta = new SqlParameter("@Objetivo", SqlDbType.Date);
//            fecha_consulta.Value = Fecha_ConsultaR;
//            SqlParameter fecha_respuesta = new SqlParameter("@Fecha", SqlDbType.Date);
//            fecha_respuesta.Value = Fecha_RespR;
//            SqlParameter tema = new SqlParameter("@Estado", SqlDbType.VarChar);
//            if (TemaR == "")
//            {
//                tema.Value = DBNull.Value;
//            }
//            else
//            {
//                tema.Value = TemaR;
//            }
//            SqlParameter descripcion = new SqlParameter("@Nombre_Rep", SqlDbType.VarChar);
//            if (DescripcionR == "")
//            {
//                descripcion.Value = DBNull.Value;
//            }
//            else
//            {
//                descripcion.Value = DescripcionR;
//            }
//            SqlParameter tema = new SqlParameter("@Tel_Rep", SqlDbType.VarChar);
//            if (TemaR == "")
//            {
//                tema.Value = DBNull.Value;
//            }
//            else
//            {
//                tema.Value = TemaR;
//            }
//            SqlParameter descripcion = new SqlParameter("@Ofic_Rep", SqlDbType.VarChar);
//            if (DescripcionR == "")
//            {
//                descripcion.Value = DBNull.Value;
//            }
//            else
//            {
//                descripcion.Value = DescripcionR;
//            }

//            try
//            {
//                //CONSULTA
//                comando_consulta = new SqlCommand(instruccion_consulta, sqlConnection);

//                comando_consulta.Parameters.Add(codigo_oficio);
//                comando_consulta.Parameters.Add(tema);
//                comando_consulta.Parameters.Add(descripcion);
//                comando_consulta.Parameters.Add(fecha_consulta);
//                comando_consulta.Parameters.Add(fecha_respuesta);

//                comando_consulta.ExecuteNonQuery();
//                comando_consulta.Parameters.Clear();

//            }
//            catch (SqlException ex)
//            {
//                string mensajeError = ex.ToString();
//              //  MessageBox.Show(mensajeError);
//            }

//            try
//            {
//                sqlConnection.Close();
//            }
//            catch (SqlException e)
//            {
//                string mensajeError = e.ToString();
//            //    MessageBox.Show(mensajeError);
//            }

//>>>>>>> origin/master
        }

    }