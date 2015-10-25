using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class EntidadDisenno
    {

        //(" + Disenno.Id + ",'" + Disenno.Proposito + "','" + Disenno.Nivel + "','" + Disenno.Tecnica + "','" + Disenno.Tipo + "','" + Disenno.Ambiente + "','" + Disenno.Procedimiento + "','" + Disenno.FechaDeDisenno + "','" + Disenno.CriterioAceptacion + "'," + Disenno.Responsable + "'," + Disenno.ProyAsociado + ", getDate()" + ")";
        private String id;
        private String proposito;
        private String nivel;
        private String tecnica;
        private String tipo;
        private String ambiente;
        private String procedimiento;
        private String fechaDeDisenno;
        private String criterioAceptacion;
        private String responsable;
        private String proyAsociado;
       // private String IdConsulta;



        public EntidadDisenno(Object[] datos)
        {
            this.id = Convert.ToInt32(datos[0].ToString());
            this.proposito = datos[1].ToString();
            this.nivel = datos[2].ToString();
            this.tecnica = datos[3].ToString();
            this.tipo = datos[4].ToString();
            this.ambiente = datos[5].ToString();
            this.procedimiento = datos[6].ToString();
            this.fechaDeDisenno = datos[7].ToString();
            
            this.criterioAceptacion = datos[8].ToString();
            this.responsable = datos[9].ToString();
            this.proyAsociado = datos[10].ToString();
           // this.IdConsulta = Convert.ToInt32(datos[10].ToString());
        }

        //Metodos set y get para la variable Id
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

      /*  //Metodos set y get para la variable IdVieja
        public String IdViejo
        {
            get { return idConsulta; }
            set { id = value; }

        }*/

        //Metodos set y get para la variable proposito
        public String Proposito
        {
            get { return proposito; }
            set { proposito = value; }
        }

        //Metodos set y get para la variable nivel
        public String Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        //Metodos set y get para la variable tecnica
        public String Tecnica
        {
            get { return tecnica; }
            set { tecnica = value; }
        }

        //Metodos set y get para la variable Correo
        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        //Metodos set y get para la variable ambiente
        public String Ambiente
        {
            get { return ambiente; }
            set { ambiente = value; }
        }

        //Metodos set y get para la variable procedimiento
        public String Procedimiento
        {
            get { return procedimiento; }
            set { procedimiento = value; }
        }

        //Metodos set y get para la variable fechaDeDisenno
        public String FechaDeDisenno
        {
            get { return fechaDeDisenno; }
            set { fechaDeDisenno = value; }
        }

        //Metodos set y get para la variable criterioAceptacion
        public String CriterioAceptacion
        {
            get { return criterioAceptacion; }
            set { criterioAceptacion = value; }
        }

        //Metodos set y get para la variable ProyAsociado
        public String ProyAsociado
        {
            get { return proyAsociado; }
            set { proyAsociado = value; }
        }

        //Metodos set y get para la variable responsable
        public String Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}