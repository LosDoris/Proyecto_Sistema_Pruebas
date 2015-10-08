using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazProyecto : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre_proyecto.Enabled = false;
            obj_general.Enabled = false;
            estado.Enabled = false;
            nombre_rep.Enabled = false;
            tel_rep.Enabled = false;
                of_rep.Enabled = false;
        }

        protected void Insertar_button(object sender, EventArgs e)
        {
            nombre_proyecto.Enabled = true;
            obj_general.Enabled = true;
            estado.Enabled = true;
            nombre_rep.Enabled = true;
            tel_rep.Enabled = true;
            of_rep.Enabled = true;
        }

 

    }
}