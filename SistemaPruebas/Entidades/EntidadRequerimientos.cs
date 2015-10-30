using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras//.Entidades
{
    public class EntidadRequerimientos
    {
        private String id;
        private String precondiciones;
        private String requerimientosEspeciales;
        private String idViejo;
        public EntidadRequerimientos(Object[] datos)
        {
            this.id = datos[0].ToString();
            this.precondiciones = datos[1].ToString();
            this.requerimientosEspeciales = datos[2].ToString();
            this.requerimientosEspeciales = datos[3].ToString();
        }

        //Metodos set y get para la variable Id
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String IdViejo
        {
            get { return idViejo; }
            set { idViejo = value; }
        }

        //Metodos set y get para la variable proposito
        public String Precondiciones
        {
            get { return precondiciones; }
            set { precondiciones = value; }
        }

        //Metodos set y get para la variable ambiente
        public String RequerimientosEspeciales
        {
            get { return requerimientosEspeciales; }
            set { requerimientosEspeciales = value; }
        }
    }
}


