using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraDisenno
    {
        ControladoraBDDisenno controlBD;

        public ControladoraDisenno()
        {
            controlBD = new ControladoraBDDisenno();            
        } 

        public int ingresaProyecto(object[] datos)
        {
            EntidadDisenno objDisenno = new EntidadDisenno(datos);
            int a = controlBD.insertarDisennoBD(objDisenno);
            return a;
        }
    }
}