using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class EntidadCasosPrueba
    {
        // Variables correspondientes a la entidad cliente
        private int id_caso_prueba;
        private String proposito;
        private String entrada_datos;
        private String resultado_esperado;
        private String flujo_central;
        private int id_disenno;
        private int id_requerimiento;

        public EntidadCasosPrueba(Object[] datos)
        { // Constructor donde se inicializan las variables de la clase
            this.id_caso_prueba = Convert.ToInt32(datos[0].ToString());
            this.proposito = datos[1].ToString();
            this.entrada_datos = datos[2].ToString();
            this.resultado_esperado = datos[3].ToString();
            this.flujo_central = datos[4].ToString();
            this.id_requerimiento = Convert.ToInt32(datos[5].ToString());
        }

        //Metodos set y get para la variable id_caso_prueba
        public int Id_caso_prueba
        {
            get { return id_caso_prueba; }
            set { id_caso_prueba = value; }
        }

        //Metodos set y get para la variable proposito
        public String Proposito
        {
            get { return proposito; }
            set { proposito = value; }
        }

        //Metodos set y get para la variable entrada_datos
        public String Entrada_datos
        {
            get { return entrada_datos; }
            set { entrada_datos = value; }
        }

        //Metodos set y get para la variable resultado_esperado
        public String Resultado_esperado
        {
            get { return resultado_esperado; }
            set { resultado_esperado = value; }
        }

        //Metodos set y get para la variable flujo_central
        public String Flujo_central
        {
            get { return flujo_central; }
            set { flujo_central = value; }
        }

        //Metodos set y get para la variable id_requerimiento
        public int Id_disenno
        {
            get { return id_disenno; }
            set { id_disenno = value; }
        }
        
    }
}