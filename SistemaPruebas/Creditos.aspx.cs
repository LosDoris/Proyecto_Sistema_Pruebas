﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace SistemaPruebas
{
    public partial class Creditos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ricardoClick(object sender, ImageClickEventArgs e)
        {
            PanelRicardo.Visible = true;
            PanelAndrea.Visible = false;
            PanelCarolina.Visible = false;
            PanelDaniel.Visible = false;
            PanelHelena.Visible = false;
        }

        protected void danielClick(object sender, ImageClickEventArgs e)
        {
            PanelDaniel.Visible = true;

            PanelRicardo.Visible = false;
            PanelAndrea.Visible = false;
            PanelCarolina.Visible = false;
            PanelHelena.Visible = false;
        }

        protected void carolinaClick(object sender, ImageClickEventArgs e)
        {
            PanelCarolina.Visible = true;
            PanelRicardo.Visible = false;
            PanelAndrea.Visible = false;
            PanelDaniel.Visible = false;
            PanelHelena.Visible = false;
        }

        protected void helenaClick(object sender, ImageClickEventArgs e)
        {
            PanelHelena.Visible = true;
            PanelRicardo.Visible = false;
            PanelAndrea.Visible = false;
            PanelCarolina.Visible = false;
            PanelDaniel.Visible = false;
        }

        protected void andreaClick(object sender, ImageClickEventArgs e)
        {
            PanelAndrea.Visible = true;
            PanelRicardo.Visible = false;
            PanelCarolina.Visible = false;
            PanelDaniel.Visible = false;
            PanelHelena.Visible = false;
        }
    }
}