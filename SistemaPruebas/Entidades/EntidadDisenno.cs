﻿using System;
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
        private int nivel;
        private int tecnica;
        private int tipo;
        private String ambiente;
        private String procedimiento;
        private String fechaDeDisenno;
        private String criterioAceptacion;
        private int responsable;
        private int proyAsociado;
       // private String IdConsulta;



        public EntidadDisenno(Object[] datos)
        {
         //   this.id = datos[0].ToString();
            this.proposito = datos[0].ToString();
            this.nivel = Convert.ToInt32(datos[1].ToString());
            this.tecnica = Convert.ToInt32(datos[2].ToString());
            //this.tipo = Convert.ToInt32(datos[3].ToString());
            this.ambiente = datos[3].ToString();
            this.procedimiento = datos[4].ToString();
            this.fechaDeDisenno = datos[5].ToString();            
            this.criterioAceptacion = datos[6].ToString();
            this.responsable = Convert.ToInt32(datos[7].ToString());
            this.proyAsociado = Convert.ToInt32(datos[8].ToString());
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
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        //Metodos set y get para la variable tecnica
        public int Tecnica
        {
            get { return tecnica; }
            set { tecnica = value; }
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
        public int ProyAsociado
        {
            get { return proyAsociado; }
            set { proyAsociado = value; }
        }

        //Metodos set y get para la variable responsable
        public int Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}