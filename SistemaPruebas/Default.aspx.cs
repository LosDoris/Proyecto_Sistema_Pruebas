﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaPruebas
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Account.Login.loggeado == 1)
            {
                Timeline.Visible = true;
            }
            else
            {
                Timeline.Visible = false;
            }
        }

    }
}