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
                }
                llenarProyecto = false.ToString();
            }

            else
            {
                if (llenarProyecto == true.ToString())
                {
                    llenarComboboxProyectoMiembro();
                    llenarGridDisenos();
                    cargarResponsablesMiembro();
                    deshabilitarCampos();
                }
                llenarProyecto = false.ToString();

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
            //llenarGridsReq(1);
            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;

        }

        protected void modificarClick(object sender, EventArgs e)
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

            RequiredFieldValidator1.Enabled = true;
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;

        }

        protected void eliminarClick(object sender, EventArgs e)
        {
            marcarBoton(ref Eliminar);
            Modificar.Enabled = false;
            Insertar.Enabled = false;
            deshabilitarGridDiseno();
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
            //proyectoAsociado.Enabled = true;
            Nivel.Enabled = true;
            Tecnica.Enabled = true;
          //  Tipo.Enabled = true;
            responsable.Enabled = true;
            aceptar.Enabled = true;
            cancelar.Enabled = true;


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
           // Tipo.Enabled = false;
            responsable.Enabled = false;
            aceptar.Enabled = false;
            cancelar.Enabled = false;
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

        }

        protected void aceptarClick(object sender, EventArgs e)
        {
            deshabilitarCampos();
            switch (Int32.Parse(buttonDisenno))
            {
                case 1://Insertar
                    {

                        string fecha = Page.Request.Form["txt_date"];
                        int cedula = controlDiseno.solicitarResponsableCedula(responsable.SelectedValue);
                        int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
                        object[] datos = new object[9] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha, criteriosTxtbox.Text, cedula, proyecto};
                        int a = controlDiseno.ingresaDiseno(datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido insertado con éxito');", true); //CAMBIAR ALERTA
                            llenarGridDisenos();
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

                        string fecha = Page.Request.Form["txt_date"];
                        int cedula = controlDiseno.solicitarResponsableCedula(responsable.SelectedValue);                       
                        int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);

                        object[] datos = new object[9] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha, criteriosTxtbox.Text, cedula, proyecto };

                        int a = controlDiseno.modificarDiseno(Int32.Parse(id_diseno_cargado), datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido modificado con éxito');", true); //CAMBIAR ALERTA
                            llenarGridDisenos();
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
        }

        protected void llenarGridsReq(int tipo)
        {
            DataTable req = solicitarReqs(tipo);
            if (tipo==1)
            {
                // this.gridNoAsociado.DataSource = req;
                // this.gridNoAsociado.DataBind();
            }
            else 
            {


            }

        }


        protected DataTable solicitarReqs(int tipo)
        {
            int proyecto = controlDiseno.solicitarProyecto_Id(proyectoAsociado.SelectedItem.Text);
            int diseno = -1;
            if (Int32.Parse(buttonDisenno) == 2)
            {
                // diseno = controlDiseno. CREAR METODO
            }
            DataTable dt = new DataTable();
            DataTable req = new DataTable();
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("Id Requerimiento") });

            if (tipo == 1)
            {
                req = controlDiseno.consultarReqNoenDiseno(proyecto, diseno);
            }
            else
            {
                req = controlDiseno.consultarReqEnDiseno(proyecto, diseno);

            }
            if (req.Rows.Count > 0)
            {
                foreach (DataRow fila in req.Rows)
                {
                    dt.Rows.Add(fila[0].ToString());
                }
            }
            else
            {

                dt.Rows.Add("-");

            }

            return dt;
        }

        protected void OnSelectedIndexChangedNoAsoc(object sender, EventArgs e)
        {

        }

        protected void OnPageIndexChangingNoAsoc(object sender, GridViewPageEventArgs e)
        {
          //  gridNoAsociado.PageIndex = e.NewPageIndex;
            this.llenarGridsReq(1);
        }

        protected void OnRowDataBoundNoAsoc(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

         /*   if (gridNoAsociado.Enabled && e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridNoAsociado, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
            */
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

        protected void obtenerDatosInsertados()
        {

            string fecha = Page.Request.Form["txt_date"];
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
                    this.proyectoAsociado.Items.Add(new ListItem(p2[0], p2[1]));
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
                llenarGridDisenos();
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
            //txt_date.Text
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

    }

    }

