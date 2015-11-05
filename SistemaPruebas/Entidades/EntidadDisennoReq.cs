using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Entidades
{
    public class EntidadDisennoReq
    {

        private int idProyecto;
        private string idReq;
        private int idDisenno;

        public EntidadDisennoReq (object []datos)
        {
            this.idProyecto = Int32.Parse(datos[0].ToString());
            this.idReq = datos[1].ToString();
            this.idDisenno = Int32.Parse(datos[2].ToString());
        }


        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        public string IdReq
        {
            get { return idReq; }
            set { idReq = value; }
        }
        public int IdDisenno
        {
            get { return idDisenno; }
            set { idDisenno = value; }
        }

    }
}