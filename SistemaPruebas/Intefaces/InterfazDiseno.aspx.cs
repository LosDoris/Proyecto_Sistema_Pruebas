using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazDiseno : System.Web.UI.Page
    {
        static DataTable dtNoAsociados;
        static DataTable dtSiasociados;
        Controladoras.ControladoraDisenno controlDiseno = new Controladoras.ControladoraDisenno();
        protected void Page_Load(object sender, EventArgs e)
        {

            restriccionesCampos();
            if (controlDiseno.loggeadoEsAdmin())
            {
                if (llenarProyecto == true.ToString())
                {
                    llenarComboboxProyectoAdmin();
                    deshabilitarCampos();
                    deshabilitarGridReq(1);
                    deshabilitarGridReq(2);

                }
                llenarProyecto = false.ToString();
            }

            else
            {
                if (llenarProyecto == true.ToString())
                {
                    llenarComboboxProyectoMiembro();
                    llenarGridDisenos();                   
                    llenarGridsReq(1);
                    llenarGridsReq(2);
                    cargarResponsablesMiembro();
                    deshabilitarCampos();
                }
                llenarProyecto = false.ToString();

            }
        }

        public static List<string> infDisenno
        {
            get
            {
                object value = HttpContext.Current.Session["infDisenno"];
                List<string> ids = HttpContext.Current.Session["infDisenno"] != null ? (List<string>)HttpContext.Current.Session["infDisenno"] : null;
                return ids;
            }
            set
            {
                HttpContext.Current.Session["infDisenno"] = value;
            }
        }

        public static string el_proyecto
        {
            get
            {
                object value = HttpContext.Current.Session["el_proyecto"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["el_proyecto"] = value;
            }
        }

        public static string id_req_asoc
        {
            get
            {
                object value = HttpContext.Current.Session["id_req_asoc"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_req_asoc"] = value;
            }
        }

        public static string id_req_noAsoc
        {
            get
            {
                object value = HttpContext.Current.Session["id_req_noAsoc"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_req_noAsoc"] = value;
            }
        }


        public static string id_diseno_cargado
        {
            get
            {
                object value = HttpContext.Current.Session["id_diseno_cargado"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_diseno_cargado"] = value;
            }
        }


        public static string llenarProyecto
        {
            get
            {
                object value = HttpContext.Current.Session["llenarProyecto"];
                return value == null ? "True" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["llenarProyecto"] = value;
            }
        }

        public static string buttonDisenno
        {
            get
            {
                object value = HttpContext.Current.Session["buttonDisenno"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["buttonDisenno"] = value;
            }
        }

        protected void irAReq(object sender, EventArgs e)
        {
            Response.Redirect("InterfazRequerimiento.aspx");
        }

        protected void insertarClick(object sender, EventArgs e)
        {
            buttonDisenno = "1";
            limpiarCampos();
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
            Insertar.Enabled = false;
            habilitarCampos();
            deshabilitarGridDiseno();
            marcarBoton(ref Insertar);
            cancelar.Enabled = true;
            aceptar.Enabled = true;
            botonCP.Enabled = false;
            
        }

        protected void modificarClick(object sender, EventArgs e)
        {
            if (proyectoAsociado.SelectedItem.Text != "Seleccionar")
            {
                marcarBoton(ref Modificar);
                buttonDisenno = "2";
                habilitarCampos();
                Modificar.Enabled = false;
                Eliminar.Enabled = false;
                Insertar.Enabled = false;
                deshabilitarGridDiseno();
                aceptar.Enabled = true;
                cancelar.Enabled = true;
                if (this.proyectoAsociado.SelectedIndex == 0)
                {
                    labelSeleccioneProyecto.Visible = true;
                }
                else
                {
                    labelSeleccioneProyecto.Visible = false;
                }

                botonCP.Enabled = true;
                el_proyecto = proyectoAsociado.SelectedItem.Text;
            }
            if (proyectoAsociado.Items.Count == 1)
            {
                labelSeleccioneProyecto.Visible = false;
            }
        }

        protected void eliminarClick(object sender, EventArgs e)
        {
            marcarBoton(ref Eliminar);
            Modificar.Enabled = false;
            Insertar.Enabled = false;
            deshabilitarGridDiseno();
            labelSeleccioneProyecto.Visible = true;
            if (this.proyectoAsociado.SelectedIndex == 0)
            {
                labelSeleccioneProyecto.Visible = true;
            }
            else
            {
                labelSeleccioneProyecto.Visible = false;
            }
            botonCP.Enabled = false;
        }

        protected void restriccionesCampos()
        {
            //nombreReqTxtbox.MaxLength = 30;
            //precondicionReqTxtbox.MaxLength = 150;
            //reqEspecialesReqTxtbox.MaxLength = 150;
            propositoTxtbox.MaxLength = 80;
            ambienteTxtbox.MaxLength = 150;
            procedimientoTxtbox.MaxLength = 150;
            criteriosTxtbox.MaxLength = 150;

        }

        protected void aceptarModal_ClickEliminar(object sender, EventArgs e)
        {
           int a= controlDiseno.eliminarDisenno(Int32.Parse(id_diseno_cargado));
           if (a == 1)
           {
               ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido eliminado con éxito');", true); //CAMBIAR ALERTA
               llenarGridDisenos();
               habilitarGridDiseno();
               deshabilitarCampos();
               desmarcarBoton(ref Eliminar);
               Modificar.Enabled = true;
               Eliminar.Enabled = true;
               Insertar.Enabled = true;
           }
           else
           {
               //completar
           }

        }

        protected void cancelarModal_ClickEliminar(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido eliminado con éxito');", true);
            desmarcarBoton(ref Eliminar);
            Modificar.Enabled = true;
            Eliminar.Enabled = true;
            Insertar.Enabled = true;


        }

        protected void habilitarCampos()
        {
            //nombreReqTxtbox.Enabled = true;
            // precondicionReqTxtbox.Enabled = true;
            //reqEspecialesReqTxtbox.Enabled = true;
            iraRequerimientoBtn.Enabled = true;
            propositoTxtbox.Enabled = true;
            ambienteTxtbox.Enabled = true;
            procedimientoTxtbox.Enabled = true;
            criteriosTxtbox.Enabled = true;
            txt_date.Enabled = true;
            //proyectoAsociado.Enabled = true;
            Nivel.Enabled = true;
            Tecnica.Enabled = true;
          //  Tipo.Enabled = true;
            responsable.Enabled = true;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            habilitarGridReq(1);
            habilitarGridReq(2);


        }

        protected void deshabilitarCampos()
        {
            // nombreReqTxtbox.Enabled = false;
            // precondicionReqTxtbox.Enabled = false;
            // reqEspecialesReqTxtbox.Enabled = false;
            iraRequerimientoBtn.Enabled = false;
             propositoTxtbox.Enabled = false;
            ambienteTxtbox.Enabled = false;
            procedimientoTxtbox.Enabled = false;
            criteriosTxtbox.Enabled = false;
            //proyectoAsociado.Enabled = false;
            Nivel.Enabled = false;
            Tecnica.Enabled = false;
            txt_date.Enabled = false;
           // Tipo.Enabled = false;
            responsable.Enabled = false;
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            deshabilitarGridReq(1);
            deshabilitarGridReq(2);
            botonCP.Enabled = false;
        }

        protected void limpiarCampos()
        {
           // nombreReqTxtbox.Text = "";
           // precondicionReqTxtbox.Text = "";
            //reqEspecialesReqTxtbox.Text = "";
            propositoTxtbox.Text = "";
            ambienteTxtbox.Text = "";
            procedimientoTxtbox.Text = "";
            criteriosTxtbox.Text = "";
            txt_date.Text = "";
            //proyectoAsociado.ClearSelection();
            //ListItem selectedListItem = proyectoAsociado.Items.FindByValue("1");
            Nivel.ClearSelection();
            ListItem selectedListItem1 = Nivel.Items.FindByValue("1");
            Tecnica.ClearSelection();
            ListItem selectedListItem2 = Tecnica.Items.FindByValue("1");
          //  Tipo.ClearSelection();
           // ListItem selectedListItem3 = Tipo.Items.FindByValue("1");
            responsable.ClearSelection();
            ListItem selectedListItem4 = responsable.Items.FindByValue("1");
            cancelar.Enabled = false;
            Modificar.Enabled = false;
            habilitarGridReq(1);
            habilitarGridReq(2);

        }

        protected void aceptarClick(object sender, EventArgs e)
        {

            deshabilitarCampos();
            switch (Int32.Parse(buttonDisenno))
            {
                case 1://Insertar
                    {

                        string fecha = txt_date.Text;
                        int cedula = controlDiseno.solicitarResponsableCedula(responsable.SelectedValue);
                        int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
                        el_proyecto = proyecto.ToString();
                        object[] datos = new object[9] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha, criteriosTxtbox.Text, cedula, proyecto};
                        int a = controlDiseno.ingresaDiseno(datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido insertado con éxito');", true); //CAMBIAR ALERTA
                            llenarGridDisenos();
                            llenarGridsReq(1);
                            llenarGridsReq(2);
                            habilitarGridDiseno();
                            deshabilitarCampos();
                            desmarcarBoton(ref Insertar);
                            Modificar.Enabled = true;
                            Eliminar.Enabled = true;
                            Insertar.Enabled = true;
                        }
                        else
                        {
                            //completar
                        }
                    }
                    break;
                case 2://Modificar
                    {

                        string fecha = txt_date.Text;
                        int cedula = controlDiseno.solicitarResponsableCedula(responsable.SelectedValue);                       
                        int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);

                        object[] datos = new object[9] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha, criteriosTxtbox.Text, cedula, proyecto };

                        int a = controlDiseno.modificarDiseno(Int32.Parse(id_diseno_cargado), datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido modificado con éxito');", true); //CAMBIAR ALERTA
                            llenarGridDisenos();
                            llenarGridsReq(1);
                            llenarGridsReq(2);
                            habilitarGridDiseno();
                            deshabilitarCampos();
                            desmarcarBoton(ref Modificar);
                            Modificar.Enabled = true;
                            Eliminar.Enabled = true;
                            Insertar.Enabled = true;
                        }
                        else
                        {
                            //completar
                        }
                    }
                    break;
            };
        }

        protected void cancelarClick(object sender, EventArgs e)
        {
            deshabilitarCampos();
            limpiarCampos();
            habilitarGridDiseno();
            desmarcarBoton(ref Insertar);
            desmarcarBoton(ref Modificar);
            desmarcarBoton(ref Eliminar);
            labelSeleccioneProyecto.Visible = false;

        }

        protected void llenarGridsReq(int tipo)
        {
            DataTable req = solicitarReqs(tipo);
            if (tipo == 1)
            {
                //dtNoAsociados = req;
                gridNoAsociados.DataSource = req;
                gridNoAsociados.DataBind();
            }
            else
            {
                //dtSiasociados = req;
                gridAsociados.DataSource = req;
                gridAsociados.DataBind();
            }
        }
        


        protected DataTable solicitarReqs(int tipo)
        {
            DataTable req = new DataTable();
            DataTable dt = new DataTable();

            req.Columns.Add("Id de Requerimiento");

            int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
            int diseno = -1;

            if (Int32.Parse(buttonDisenno) == 2)
            {
                diseno = Int32.Parse(id_diseno_cargado);
            }

            if (tipo == 1)
            {
                
                dt = controlDiseno.consultarReqNoenDiseno(proyecto, diseno);
                dtNoAsociados = dt;
            }
            else
            {
                dt = controlDiseno.consultarReqEnDiseno(proyecto, diseno);
                dtSiasociados = dt;

            }

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    req.Rows.Add(dr[0].ToString());

                }
            }
            else
            {

                req.Rows.Add('-');
            }
            return req;       
        }
        protected void llenarGridsReqModificar(int tipo, DataTable req)
        {
            //DataTable req = solicitarReqs(tipo);
            if (tipo == 1)
            {
                dtNoAsociados = req;
                if (req.Rows.Count > 0)
                {

                }
                else
                {
                    Object[] datos = new Object[1];
                    datos[0] = "-";
                    req.Rows.Add(datos);
                }
                gridNoAsociados.DataSource = req;
                gridNoAsociados.DataBind();
            }
            else
            {
                dtSiasociados = req;
                if (req.Rows.Count > 0)
                {

                }
                else
                {
                    Object[] datos = new Object[1];
                    datos[0] = "-";
                    req.Rows.Add(datos);
                }
                gridAsociados.DataSource = req;
                gridAsociados.DataBind();
            }
        }

        protected DataTable crearTablaREQ(/*int tipo*/)
        {
            DataTable dt = new DataTable();
            //if (tipo == 1) { }
            dt.Columns.Add("ID Requerimiento", typeof(String));
        //}
            //dt.Columns.Add("Precondiciones", typeof(String));
            //dt.Columns.Add("Req. Especiales", typeof(String));
            //dt.Columns.Add("Nombre Proyecto");
            //dt.
            return dt;
        }
        /*protected DataTable crearTablaREQNoAso()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Requerimiento", typeof(String));
            //dt.Columns.Add("Precondiciones", typeof(String));
            //dt.Columns.Add("Req. Especiales", typeof(String));
            //dt.Columns.Add("Nombre Proyecto");
            //dt.
            return dt;
        }*/
        protected void OnSelectedIndexChangedNoAsoc(object sender, EventArgs e)
        {
            try
            {
                //EtiqErrorLlaves.Text = "Entro a no asociados";
                //EtiqErrorLlaves.ForeColor = System.Drawing.Color.DarkSeaGreen;
                //EtiqErrorLlaves.Visible = true;
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
                id_req_noAsoc = gridNoAsociados.SelectedRow.Cells[0].Text;
                dtNoAsociados = quitarElemento(dtNoAsociados, id_req_noAsoc);
                dtSiasociados = ponerElemento(dtSiasociados, id_req_noAsoc);
                llenarGridsReqModificar(1, dtNoAsociados);
                llenarGridsReqModificar(2, dtSiasociados);
                /*
                dtNoAsociados = quitarElemento(dtSiasociados, id_req_asoc);
                dtSiasociados= ponerElemento(dtNoAsociados, id_req_asoc);
                llenarGridsReqModificar(1, dtNoAsociados);
                llenarGridsReqModificar(2, dtSiasociados);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void OnSelectedIndexChangedAsoc(object sender, EventArgs e)
        {
            try
            {
                //EtiqErrorLlaves.Text = "Entro a asociados";
                //EtiqErrorLlaves.ForeColor = System.Drawing.Color.DarkSeaGreen;
                //EtiqErrorLlaves.Visible = true;
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "HideLabel();", true);
                id_req_asoc = gridAsociados.SelectedRow.Cells[0].Text;
                dtSiasociados = quitarElemento(dtSiasociados, id_req_asoc);
                dtNoAsociados = ponerElemento(dtNoAsociados, id_req_asoc);
                llenarGridsReqModificar(1, dtNoAsociados);
                llenarGridsReqModificar(2, dtSiasociados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected DataTable quitarElemento(DataTable dtVieja, String id)
        {

            DataTable dtNueva = crearTablaREQ();
            //DataTable req = solicitarReqs(tipo);
            Object[] datos = new Object[1];


                if (dtVieja.Rows.Count > (0-1))
                {
                    foreach (DataRow dr in dtVieja.Rows)
                    {
                        
                        datos[0] = dr[0];
                        if (Convert.ToString(datos[0]) != Convert.ToString(id))
                        {
                            dtNueva.Rows.Add(datos);
                        }
                    }
                

            }
                else
                {
                    datos[0] = "-";
                    dtNueva.Rows.Add(datos);
                }
                
            return dtNueva;
        }
        protected DataTable ponerElemento(DataTable dtVieja, String id)
        {


            DataTable dtNueva = crearTablaREQ();
            Object[] datos = new Object[1];

            datos[0] = id;
            dtNueva.Rows.Add(datos);
            foreach (DataRow dr in dtVieja.Rows)
                {

                    datos[0] = dr[0];
                    dtNueva.Rows.Add(datos);
                    
                }
            

            return dtNueva;
        }

        protected void OnPageIndexChangingNoAsoc(object sender, GridViewPageEventArgs e)
        {
            gridNoAsociados.PageIndex = e.NewPageIndex;
            this.llenarGridsReq(1);
        }

        protected void OnPageIndexChangingAsoc(object sender, GridViewPageEventArgs e)
        {
            gridAsociados.PageIndex = e.NewPageIndex;
            this.llenarGridsReq(2);
        }

        protected void OnRowDataBoundNoAsoc(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridNoAsociados, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void OnRowDataBoundAsoc(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridAsociados, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void llenarGridDisenos()
        {

            DataTable disennos = new DataTable();

            disennos.Columns.Add("Propósito");
            disennos.Columns.Add("Nivel");
            disennos.Columns.Add("Técnica");
            disennos.Columns.Add("Responsable");

            int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
            DataTable dt = controlDiseno.consultarDisenoGrid(proyecto);
            Object[] datos = new Object[4];


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = Nivel.Items.FindByValue(dr[1].ToString());
                    datos[2] = Tecnica.Items.FindByValue(dr[2].ToString());
                    datos[3] = dr[3];
                    disennos.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                disennos.Rows.Add(datos);
            }
            gridDisenos.DataSource = disennos;
            gridDisenos.DataBind();

        }

        protected void habilitarGridDiseno()
        {
            gridDisenos.Enabled = true;
            foreach (GridViewRow row in gridDisenos.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridDisenos, "Select$" + row.RowIndex);
                row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void habilitarGridReq(int tipo)
        {
            if (tipo == 1)
            {
                gridNoAsociados.Enabled = true;
                foreach (GridViewRow row in gridNoAsociados.Rows)
                {
                    row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridNoAsociados, "Select$" + row.RowIndex);
                    row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                    row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                    row.Attributes["style"] = "cursor:pointer";
                }
            }

            else
            {
                gridAsociados.Enabled = true;
                foreach (GridViewRow row in gridAsociados.Rows)
                {
                    row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridAsociados, "Select$" + row.RowIndex);
                    row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                    row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                    row.Attributes["style"] = "cursor:pointer";
                }
            }
        }


        protected void deshabilitarGridDiseno()
        {
            gridDisenos.Enabled = false;
            foreach (GridViewRow row in gridDisenos.Rows)
            {
                row.Attributes.Remove("onclick");
                row.Attributes.Remove("onmouseover");
                row.Attributes.Remove("style");
                row.Attributes.Remove("onmouseout");
            }
        }

        protected void deshabilitarGridReq(int tipo)
        {

            if (tipo == 1)
            {
                gridNoAsociados.Enabled = false;
                foreach (GridViewRow row in gridNoAsociados.Rows)
            {
                row.Attributes.Remove("onclick");
                row.Attributes.Remove("onmouseover");
                row.Attributes.Remove("style");
                row.Attributes.Remove("onmouseout");
            }
            }

            else
            {
                gridAsociados.Enabled = false;
                foreach (GridViewRow row in gridAsociados.Rows)
                {
                    row.Attributes.Remove("onclick");
                    row.Attributes.Remove("onmouseover");
                    row.Attributes.Remove("style");
                    row.Attributes.Remove("onmouseout");
                }
            }
        }

        protected void obtenerDatosInsertados()
        {

            string fecha = txt_date.Text;
            object[] datos = new object[6] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha };

        }

        protected void marcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.BackColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.ForeColor = System.Drawing.Color.White;
        }

        protected void desmarcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.Color.LightGray;
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.Black;

        }

        protected void llenarComboboxProyectoAdmin()
        {

            this.proyectoAsociado.Items.Clear();
            proyectoAsociado.Items.Add(new ListItem("Seleccionar"));
            String proyectos = controlDiseno.solicitarProyectos();
            String[] pr = proyectos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split('_');
                try
                {
                    if (Convert.ToInt32(p2[1]) > -1)
                    {
                        this.proyectoAsociado.Items.Add(new ListItem(p2[0], p2[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        protected void llenarComboboxProyectoMiembro()
        {
                      
            this.proyectoAsociado.Items.Clear();

                try
                {
                //hay que ver que hacemos con los miembros que no tienen un proyecto asociado.
                    this.proyectoAsociado.Items.Add(new ListItem(controlDiseno.solicitarNombreProyectoMiembro(controlDiseno.solicitarProyecto_IdMiembro())));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            
        }

        protected void cargarResponsablesMiembro()
        {
            int id_proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
            this.responsable.Items.Clear();
            responsable.Items.Add(new ListItem("Seleccionar"));
            String responsables = controlDiseno.solicitarResponsanles(id_proyecto);

            if (responsables != null)
            {
                String[] pr = responsables.Split(';');

                foreach (String p1 in pr)
                {
                    //String[] p2 = p1.Split(';');
                    try
                    {
                        if (p1 != pr[pr.Length - 1])
                            this.responsable.Items.Add(new ListItem(p1));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            else
            {
                this.responsable.Items.Clear();
                responsable.Items.Add(new ListItem("No Disponible"));
            }
        }

        protected void proyectoAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (proyectoAsociado.SelectedItem.Text != "Seleccionar")
            {
                el_proyecto = proyectoAsociado.SelectedItem.Text;

                llenarGridDisenos();
                llenarGridsReq(1);
                llenarGridsReq(2);
                int id_proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
                this.responsable.Items.Clear();
                responsable.Items.Add(new ListItem("Seleccionar"));
                String responsables = controlDiseno.solicitarResponsanles(id_proyecto);

                if (responsables != null)
                {
                    String[] pr = responsables.Split(';');

                    foreach (String p1 in pr)
                    {
                        //String[] p2 = p1.Split(';');
                        try
                        {
                            if (p1 != pr[pr.Length - 1])
                                this.responsable.Items.Add(new ListItem(p1));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                else
                {
                    this.responsable.Items.Clear();
                    responsable.Items.Add(new ListItem("No Disponible"));
                }
            }
        }

        protected int desasociarRequerimientoEnDiseno(int id_req, int id_diseno)
        {
            return 1;//resultado de la eliminacion 

        }

        protected int asociarRequerimientoEnDiseno(int id_req, int id_diseno)
        {
            return 1;//resultado de la insersion

        }

        protected void Llenar_Datos_Conultados(int id_diseno)
        {

            Controladoras.EntidadDisenno entidad = controlDiseno.consultarDisenno(id_diseno);
            this.propositoTxtbox.Text = entidad.Proposito;

            Nivel.ClearSelection();
            ListItem selectedListItem = Nivel.Items.FindByValue(entidad.Nivel.ToString());
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
            };

            Tecnica.ClearSelection();
            ListItem selectedListItem2 = Tecnica.Items.FindByValue(entidad.Tecnica.ToString());
            if (selectedListItem2 != null)
            {
                selectedListItem2.Selected = true;
            };
            this.ambienteTxtbox.Text = entidad.Ambiente;
            this.procedimientoTxtbox.Text = entidad.Procedimiento;
            this.txt_date.Text = entidad.FechaDeDisenno;
            this.criteriosTxtbox.Text = entidad.CriterioAceptacion;

            cargarResponsablesMiembro();
            responsable.ClearSelection();
            ListItem selectedListItem3 = responsable.Items.FindByText(controlDiseno.solicitarNombreResponsable(entidad.Responsable));
            if (selectedListItem3 != null)
            {
                selectedListItem3.Selected = true;
            };

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string proposito_Diseno = gridDisenos.SelectedRow.Cells[0].Text;
                int id_diseno = controlDiseno.consultarId_Disenno(proposito_Diseno);
                id_diseno_cargado = id_diseno.ToString();
                Insertar.Enabled = true;
                Modificar.Enabled = true;
                Eliminar.Enabled = true;
                aceptar.Enabled = true;

                Llenar_Datos_Conultados(id_diseno);
                cancelar.Enabled = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDisenos.PageIndex = e.NewPageIndex;
            this.llenarGridDisenos();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridDisenos, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void aceptarModal_ClickCancelar(object sender, EventArgs e)
        {
            deshabilitarCampos();
            limpiarCampos();
            habilitarGridDiseno();
            desmarcarBoton(ref Insertar);
            desmarcarBoton(ref Modificar);
            desmarcarBoton(ref Eliminar);
            Insertar.Enabled = true;
            Modificar.Enabled = true;
            Eliminar.Enabled = true;
            labelSeleccioneProyecto.Visible = false;

        }

        protected void cancelarModal_ClickCancelar(object sender, EventArgs e)
        {

        }

        protected void irACasoPrueba(object sender, EventArgs e){
            List<string> lista=new List<string>();
            lista.Add(propositoTxtbox.Text.ToString());
            lista.Add(Nivel.SelectedValue.ToString());
            lista.Add(Tecnica.SelectedValue.ToString());
            lista.Add(ambienteTxtbox.Text.ToString());
            lista.Add(procedimientoTxtbox.Text.ToString());
            lista.Add(txt_date.Text.ToString());
            lista.Add(criteriosTxtbox.Text.ToString());
            lista.Add(controlDiseno.solicitarResponsableCedula(responsable.SelectedValue).ToString());
            lista.Add(controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text).ToString());
            infDisenno = lista;

            Response.Redirect("~/Intefaces/InterfazCasosDePrueba.aspx");
        }

        public List<string> infoDisenno()
        {
            return infDisenno;
        }
        
    }

}

