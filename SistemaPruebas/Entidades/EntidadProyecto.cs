using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class EntidadProyecto
    {
        // Variables correspondientes a la entidad cliente
        private String id_proyecto;
        private String nombre_sistema;
        private String objetivo_general;
        private String fecha_asignacion;
        private String estado;
        private String nombre_representante;
        private String telefono_representante;
        private String oficina_representante;

        public Obj_Proyecto(Object[] datos)
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

    }
}