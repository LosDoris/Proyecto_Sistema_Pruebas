using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class EntidadEjecucionPrueba
    {
        /* 
         * Variables correspondientes a la entidad cliente
         */
        private int id_ejecucion;
        private String fecha;
        private String responsable;
        private String incidencias;
        private String estado;
        private int id_disenno;

        /*
         * Requiere: Recibir un objeto con los datos de todos atributos de un Caso de Pruebas
         * Modifica: Encapsula los datos recibidos
         * Retorna: N/A
        */
        public EntidadEjecucionPrueba(Object[] datos)
        {
            this.id_ejecucion = Convert.ToInt32(datos[0]);
            this.fecha = datos[1].ToString();
            this.responsable = datos[2].ToString();
            this.incidencias = datos[3].ToString();
            this.estado = datos[4].ToString();
        }

        /*
        * Implementación de los metodos get() y set() de este atributo
        * get();
        * Requiere: el atributo id_ejecucion
        * Modifica: N/A
        * Retorna: el valor del atributo id_ejecucion en un int
        * set();
        * Requiere: el atributo id_ejecucion
        * Modifica: el valor del atributo id_ejecucion
        * Retorna: N/A
        */
        public int Id_ejecucion
        {
            get { return id_ejecucion; }
            set { id_ejecucion = value; }
        }

        /*
        * Implementación de los metodos get() y set() de este atributo
        * get();
        * Requiere: el atributo fecha
        * Modifica: N/A
        * Retorna: el valor del atributo fecha en un string
        * set();
        * Requiere: el atributo fecha
        * Modifica: el valor del atributo fecha
        * Retorna: N/A
        */
        public String Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /*
        * Implementación de los metodos get() y set() de este atributo
        * get();
        * Requiere: el atributo responsable
        * Modifica: N/A
        * Retorna: el valor del atributo responsable en un string
        * set();
        * Requiere: el atributo responsable
        * Modifica: el valor del atributo responsable
        * Retorna: N/A
        */
        public String Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }

        /*
         * Implementación de los metodos get() y set() de este atributo
         * get();
         * Requiere: el atributo incidencias
         * Modifica: N/A
         * Retorna: el valor del atributo incidencias en un string
         * set();
         * Requiere: el atributo incidencias
         * Modifica: el valor del atributo incidencias
         * Retorna: N/A
         */
        public String Incidencias
        {
            get { return incidencias; }
            set { incidencias = value; }
        }

        /* 
         * Implementación de los metodos get() y set() de este atributo
         * get();
         * Requiere: el atributo estado
         * Modifica: N/A
         * Retorna: el valor del atributo estado en un string
         * set();
         * Requiere: el atributo estado
         * Modifica: el valor del atributo estado
         * Retorna: N/A
         */
        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /*
         * Implementación de los metodos get() y set() de este atributo
         * get();
         * Requiere: el atributo Id_disenno
         * Modifica: N/A
         * Retorna: el valor del atributo Id_disenno en un int
         * set();
         * Requiere: el atributo Id_disenno
         * Modifica: el valor del atributo Id_disenno
         * Retorna: N/A
         */
        public int Id_disenno
        {
            get { return id_disenno; }
            set { id_disenno = value; }
        }
    }
}