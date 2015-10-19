using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazProyecto : System.Web.UI.Page
    {

        public static string button
        {
            get
            {
                object value = HttpContext.Current.Session["button"];
                return value == null ? "0" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["button"] = value;
            }
        }
        public static string id_logeado
        {
            get
            {
                object value = HttpContext.Current.Session["id_logeado"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_logeado"] = value;
            }
        }
        public static string id_Proyecto
        {
            get
            {
                object value = HttpContext.Current.Session["id_Proyecto"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_Proyecto"] = value;
            }
        }

        public static string adm
        {
            get
            {
                object value = HttpContext.Current.Session["adm"];
                return value == null ? "false" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["adm"] = value;
            }
        }
        public static string modificando
        {
            get
            {
                object value = HttpContext.Current.Session["modificando"];
                return value == null ? "false" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["modificando"] = value;
            }
        }

        public static string id_modificando
        {
            get
            {
                object value = HttpContext.Current.Session["id_modificando"];
                return value == null ? "-1" : (string)value;
            }
            set
            {
                HttpContext.Current.Session["id_modificando"] = value;
            }
        }

        //private static int id_Proyecto = -1; 
        //private static int button = 0;
        //private static bool adm = true;
        //private bool modificando = false;
        //private int id_modificando = -1;
        Controladoras.ControladoraProyecto controladoraProyecto = new Controladoras.ControladoraProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            EtiqErrorLlaves.Visible = false;
            id_logeado = controladoraProyecto.IdLogeado();
            adm = controladoraProyecto.PerfilDelLogeado().ToString();
            Restricciones_Campos();
            Deshabilitar_Campos();
            if (!Convert.ToBoolean(adm))
                Insertar.Enabled = false;
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
            //datepicker.Disabled = true;
            llenarGrid();
        }

        protected void Restricciones_Campos()
        {

            nombre_proyecto.MaxLength = 10;
            obj_general.MaxLength = 50;
            nombre_rep.MaxLength = 30;
            tel_rep.MaxLength = 8;
            of_rep.MaxLength = 17;
            obj_general.Rows = 5;

        }

        //        Habilitar_Campos(); 
        //Requiere: El usuario ha presionado el botón de Insertar dentro de la pestaña de Proyecto
        //Modifica: Habilita  y despliega los campos de Nombre del Sistema, Objetivo General, Fecha de asignación, estado, Nombre de Oficina Usuaria, Teléfonos Oficina Usuaria, Representante, Líder de proyecto, botones de: asignar recurso, des-asignar recurso, aceptar, cancelar.
        //Retorna: N/A.

        protected void Habilitar_Campos()
        {
            nombre_proyecto.Enabled = true;
            obj_general.Enabled = true;
            estado.Enabled = true;
            nombre_rep.Enabled = true;
            tel_rep.Enabled = true;
            of_rep.Enabled = true;
            //datepicker.Disabled = false;
        }
        protected void Deshabilitar_Campos()
        {
            nombre_proyecto.Enabled = false;
            obj_general.Enabled = false;
            estado.Enabled = false;
            nombre_rep.Enabled = false;
            tel_rep.Enabled = false;
            of_rep.Enabled = false;
            //datepicker.Enabled = false;
        }
        protected void Limpiar_Campos()
        {
            nombre_proyecto.Text = "";
            obj_general.Text = "";
            nombre_rep.Text = "";
            tel_rep.Text = "";
            of_rep.Text = "";
            llenarGrid();
            gridProyecto.Enabled = true;
            if (Convert.ToBoolean(adm))
                Insertar.Enabled = true;
            cancelar.Enabled = false;
            Modificar.Enabled = false;
            estado.ClearSelection();
            ListItem selectedListItem = estado.Items.FindByValue("1");
        }
        protected void Insertar_button(object sender, EventArgs e)
        {
            marcarBoton(ref Insertar);
            button = "1";
            Limpiar_Campos();
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            gridProyecto.Enabled = false;
            Habilitar_Campos();
            UnenabledButtons();
            deshabilitarGrid();
        }
        protected void aceptar_Click(object sender, EventArgs e)
        {

            llenarGrid();
            habilitarGrid();
            switch (Int32.Parse(button))
            {
                case 1://Insertar
                    {
                        if (nombre_proyecto.Text != "" && obj_general.Text != "" && nombre_rep.Text != "" && tel_rep.Text != "" && of_rep.Text != "" && Convert.ToBoolean(adm))
                        {
                            desmarcarBoton(ref Insertar);
                            Console.WriteLine("Insertar");
                            string text = "";//= txtDate.Text;
                            object[] datos = new object[8] { 0, nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text };
                            int a = controladoraProyecto.IngresaProyecto(datos);
                            if (a == 1)
                            {
                                id_Proyecto = controladoraProyecto.ConsultarIdProyectoPorNombre(nombre_proyecto.Text).ToString();
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido insertado con éxito');", true);
                                llenarGrid();
                                Deshabilitar_Campos();
                                gridProyecto.Enabled = true;
                                EnabledButtons();
                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);
                                if (a == 2627)
                                {
                                    EtiqErrorLlaves.Visible = true;
                                }
                                else
                                {
                                    EtiqErrorLlaves.Visible = true;
                                }
                            }                            
                        }
                    }
                    break;
                case 2:
                    {
                        desmarcarBoton(ref Modificar);
                        Console.WriteLine("Modificar");
                        string text = "";//= txtDate.Text;
                        object[] datos = new object[8] { id_Proyecto, nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text };
                        int a = controladoraProyecto.ActualizarProyecto(datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido modificado con éxito');", true);
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);
                        }
                        controladoraProyecto.UpdateUsoProyecto(Int32.Parse(id_Proyecto), 0);
                        Deshabilitar_Campos();
                        gridProyecto.Enabled = true;
                        EnabledButtons();

                        controladoraProyecto.QuitarEliminacion(Int32.Parse(id_modificando));
                        int i = -1;
                        id_modificando = i.ToString();
                        modificando = false.ToString();

                    }
                    break;
                case 3:
                    {
                        desmarcarBoton(ref Eliminar);
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "confirm('¿Está seguro que desea eliminar?');", true);
                        Console.WriteLine("Eliminar");
                        int a = 0;
                        if (Convert.ToBoolean(adm))
                        {
                            a = controladoraProyecto.EliminarProyecto(id_Proyecto.ToString());
                        }
                        else
                        {
                            a = controladoraProyecto.CancelarProyecto(id_Proyecto.ToString());
                        }
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido insertado con éxito');", true);
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);
                        }

                        Limpiar_Campos();
                        controladoraProyecto.QuitarEliminacion(Int32.Parse(id_modificando));
                        int i = -1;
                        id_modificando = i.ToString();
                        modificando = false.ToString();
                    }
                    break;

            }
        }
        protected void cancelar_Click(object sender, EventArgs e)
        {
            switch (Int32.Parse(button))
            {
                case 1://Insertar
                    {

                    }
                    break;
                case 2:
                    {
                        controladoraProyecto.QuitarEliminacion(Int32.Parse(id_modificando));
                        int i = -1;
                        id_modificando = i.ToString();
                        modificando = false.ToString();
                        controladoraProyecto.UpdateUsoProyecto(Int32.Parse(id_Proyecto), 0);

                    }
                    break;
                case 3:
                    {
                        controladoraProyecto.QuitarEliminacion(Int32.Parse(id_modificando));
                        int i = -1;
                        id_modificando = i.ToString();
                        modificando = false.ToString();
                        controladoraProyecto.UpdateUsoProyecto(Int32.Parse(id_Proyecto), 0);
                    }
                    break;
            }

            Limpiar_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            gridProyecto.Enabled = true;
            desmarcarBoton(ref Insertar);
            desmarcarBoton(ref Modificar);
            desmarcarBoton(ref Eliminar);
            habilitarGrid();
        }

        //protected void gridProyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    switch (e.CommandName)
        //    {
        //        case "seleccionarProyecto":
        //            {
        //                GridViewRow filaSeleccionada = this.gridProyecto.Rows[Convert.ToInt32(e.CommandArgument)];
        //                try
        //                {
        //                    id_Proyecto = Convert.ToInt32(filaSeleccionada.Cells[1].Text);
        //                    Llenar_Datos_Conultados(id_Proyecto);
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine(ex);
        //                }
        //            };
        //            break;
        //    }

        //}


        protected void llenarGrid()
        {
            DataTable dt = new DataTable();//crearTablaProyecto();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("conteo"), new DataColumn("Id Proyecto"), new DataColumn("Nombre del Sistema") });
            DataTable proyecto = controladoraProyecto.ConsultarProyectoIdNombre();
            Object[] datos = new Object[5];
            if (proyecto.Rows.Count > 0)
            {
                foreach (DataRow fila in proyecto.Rows)
                {
                    dt.Rows.Add(fila[0].ToString(), fila[0].ToString(), fila[1].ToString());
                }
            }
            else
            {

                dt.Rows.Add("-", "-", "*");

            }
            this.gridProyecto.DataSource = dt;
            this.gridProyecto.DataBind();
        }

        public void Llenar_Datos_Conultados(int idProyecto)
        {
            Controladoras.EntidadProyecto entidadP = controladoraProyecto.ConsultarProyecto(idProyecto);
            this.nombre_proyecto.Text = entidadP.Nombre_sistema;
            this.obj_general.Text = entidadP.Objetivo_general;
            //txtDate.Text = entidadP.Fecha_asignacion;
            estado.ClearSelection();
            ListItem selectedListItem = estado.Items.FindByValue(entidadP.Estado);
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
            };
            this.nombre_rep.Text = entidadP.Nombre_representante;
            this.tel_rep.Text = entidadP.Telefono_representante;
            this.of_rep.Text = entidadP.Oficina_representante;
        }

        //protected void gridProyecto_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        //{
        //    if (controladoraProyecto.ConsultarUsoProyecto(id_Proyecto) == 0)
        //    {
        //        Modificar.Enabled = true;
        //        Eliminar.Enabled = true;
        //        Insertar.Enabled = false;
        //        GridViewRow filaSeleccionada = this.gridProyecto.Rows[Convert.ToInt32(e.CommandArgument)];
        //        id_Proyecto = Convert.ToInt32(filaSeleccionada.Cells[0].Text);
        //        Llenar_Datos_Conultados(id_Proyecto);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto consultado se encuentra actualmente en uso, se muestra solo con fines de lectura');", true);
        //        GridViewRow filaSeleccionada = this.gridProyecto.Rows[Convert.ToInt32(e.CommandArgument)];
        //        id_Proyecto = Convert.ToInt32(filaSeleccionada.Cells[0].Text);
        //        Llenar_Datos_Conultados(id_Proyecto);
        //        cancelar.Enabled = true;                
        //    }
        //}

        protected void Modificar_Click(object sender, EventArgs e)
        {
            deshabilitarGrid();
            if (controladoraProyecto.ConsultarUsoProyecto(Int32.Parse(id_Proyecto)) == 0)
            {
                marcarBoton(ref Modificar);
                controladoraProyecto.UpdateUsoProyecto(Int32.Parse(id_Proyecto), 1);
                button = "2";
                Habilitar_Campos();
                UnenabledButtons();
                gridProyecto.Enabled = false;
                aceptar.Enabled = true;
                cancelar.Enabled = true;
                modificando = true.ToString();
                id_modificando = id_Proyecto;
                controladoraProyecto.AgregarModificacion(Int32.Parse(id_modificando), id_logeado);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto consultado se encuentra actualmente en uso');", true);

            }

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            if (controladoraProyecto.ConsultarUsoProyecto(Int32.Parse(id_Proyecto)) == 0)
            {
                deshabilitarGrid();
                marcarBoton(ref Eliminar);
                button = "3";
                UnenabledButtons();
                aceptar.Enabled = true;
                cancelar.Enabled = true;
                modificando = true.ToString();
                id_modificando = id_Proyecto;
                controladoraProyecto.AgregarModificacion(Int32.Parse(id_modificando), id_logeado);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto consultado se encuentra actualmente en uso');", true);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing BoundField Column
            if (Int32.Parse(id_Proyecto) >= 0 && id_modificando == id_Proyecto)
            {
                //modificando = false.ToString();
                int i = -1;
                id_modificando = i.ToString();
                controladoraProyecto.UpdateUsoProyecto(Int32.Parse(id_Proyecto), 0);
            }
            try
            {
                id_Proyecto = gridProyecto.SelectedRow.Cells[0].Text;
                if (controladoraProyecto.ConsultarUsoProyecto(Int32.Parse(id_Proyecto)) == 0 && !Convert.ToBoolean(modificando))
                {
                    Modificar.Enabled = true;
                    Eliminar.Enabled = true;
                    aceptar.Enabled = true;
                }
                else
                {
                    if (Convert.ToBoolean(modificando))
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Actualmente usted se encuentra modificando/elimiando otro proyecto');", true);
                    if (controladoraProyecto.ConsultarUsoProyecto(Int32.Parse(id_Proyecto)) == 0)
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto consultado se encuentra actualmente en uso, se muestra sólo con fines de lectura');", true);
                }
                Llenar_Datos_Conultados(Int32.Parse(id_Proyecto));
                cancelar.Enabled = true;
                if (!Convert.ToBoolean(adm))
                    Insertar.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProyecto.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }
        protected void EnabledButtons()
        {
            Modificar.Enabled = true;
            Eliminar.Enabled = true;
            if (Convert.ToBoolean(adm))
                Insertar.Enabled = true;
        }
        protected void UnenabledButtons()
        {
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
            if (Convert.ToBoolean(adm))
                Insertar.Enabled = false;
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

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (gridProyecto.Enabled && e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridProyecto, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void deshabilitarGrid()
        {
            gridProyecto.Enabled = false;
            foreach (GridViewRow row in gridProyecto.Rows)
            {
                row.Attributes.Remove("onclick");
                row.Attributes.Remove("onmouseover");
                row.Attributes.Remove("style");
                row.Attributes.Remove("onmouseout");
            }
        }

        protected void habilitarGrid()
        {
            gridProyecto.Enabled = true;
            foreach (GridViewRow row in gridProyecto.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridProyecto, "Select$" + row.RowIndex);
                row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                row.Attributes["style"] = "cursor:pointer";
            }
        }
    }

}
