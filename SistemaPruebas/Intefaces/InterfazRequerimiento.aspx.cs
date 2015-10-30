using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using SistemaPruebas.Controladoras;


namespace SistemaPruebas.Intefaces
{
    public partial class InterfazRequerimiento : System.Web.UI.Page
    {

        ControladoraRequerimiento controladoraRequerimiento = new ControladoraRequerimiento();

        private static int modo=0;  //Numero para identificar accion del boton Aceptar
        //Opciones: 1. Insertar, 2. Modificar, 3. Eliminar, 4. Consultar
        static String idViejo = "";
        private static bool esAdmin = true;
        //private static int cedulaLoggeado;


        /*
         * Requiere: Que suceda el evento de refrescar la pagina
         * Modifica: Refresca la pagina.
         * Retorna: N/A.
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            Restricciones_Campos();
            if (!IsPostBack)
            {
                //esAdmin = controladoraRequerimiento.loggeadoEsAdmin();
                //cedulaLoggeado = controladoraRequerimiento.idDelLoggeado();
                volverAlOriginal();
                if (!esAdmin)
                {
                    gridRequerimiento.Visible = false;
                }
                else
                {

                }
            }
            if (!esAdmin)
            {

            }
            else
            {
                llenarGrid();
            }

           // gridRequerimiento.Enabled = false;
        }

        /*
         * Requiere: N/A
         * Modifica: Designa un maximo de caracteres aceptados en los espacios.
         * Retorna: N/A.
         */
        protected void Restricciones_Campos()
        {
            TextBoxNombreREQ.MaxLength = 6;
            TextBoxPrecondicionesREQ.MaxLength = 150;
            TextBoxRequerimientosEspecialesREQ.MaxLength = 150;
        }

        /*
         * Requiere: N/A
         * Modifica: Carga el grid de consultar recursos humanos.
         * Retorna: N/A.
         */
        protected void llenarGrid()        //se encarga de llenar el grid cada carga de pantalla
        {
            DataTable Requerimiento = crearTablaREQ();
            DataTable dt = controladoraRequerimiento.consultarRequerimiento(1, ""); // en consultas tipo 1, no se necesita la cédula

            Object[] datos = new Object[4];
        

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    int id = Convert.ToInt32(dr[3]);
                    String nomp = controladoraRequerimiento.solicitarNombreProyecto(id);
                    datos[3] = nomp;
                    Requerimiento.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                Requerimiento.Rows.Add(datos);
            }
            gridRequerimiento.DataSource = Requerimiento;
            gridRequerimiento.DataBind();
            
        }

        /*
         * Requiere: Cédula
         * Modifica: Carga los datos del recurso humano consultado en sus respectivas posisiones en la pantalla.
         * Retorna: N/A.
         */
        void llenarDatosRequerimiento(String cedula)
        {
            DataTable dt = controladoraRequerimiento.consultarRequerimiento(2, cedula); // Consulta tipo 2, para llenar los campos de un recurso humano

            BotonREQEliminar.Enabled = true;
            BotonREQModificar.Enabled = true;
            try
            {
                TextBoxNombreREQ.Text = dt.Rows[0].ItemArray[0].ToString();
                TextBoxPrecondicionesREQ.Text = dt.Rows[0].ItemArray[1].ToString();
                TextBoxRequerimientosEspecialesREQ.Text = dt.Rows[0].ItemArray[2].ToString();
                //ProyectoAsociado.ClearSelection();
                //ProyectoAsociado.Items.FindByValue(dt.Rows[0].ItemArray[4].ToString()).Selected = true;
                ProyectoAsociado.ClearSelection();
                ProyectoAsociado.Items.FindByValue(dt.Rows[0].ItemArray[3].ToString()).Selected = true;
            }
            catch
            {
                EtiqErrorConsultar.Visible = true;
            }
            //Response.Write(dt.Rows.Co)

        }

        /*
         * Requiere: evento click en el boton insertar.
         * Modifica: Intenta insertar una tupla y despliega el respectivo mensaje de exito u error
         * Retorna: N/A.
         */

        protected void BotonREQInsertar_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos();
            llenarDDProyecto();
            desactivarErrores();
            BotonREQAceptar.Visible = true;
            BotonREQAceptar.Enabled = true;
            BotonREQCancelar.Enabled = true;
            BotonREQInsertar.Enabled = false;
            BotonREQModificar.Enabled = false;
            BotonREQInsertar.Enabled = false;
            BotonREQEliminar.Enabled = false;
            TextBoxNombreREQ.Text = "";
            TextBoxPrecondicionesREQ.Text = "";
            TextBoxRequerimientosEspecialesREQ.Text = "";
            marcarBoton(ref BotonREQInsertar);
            deshabilitarGrid();
        }

        /*
         * Requiere: Evento de click en boton cancelar.
         * Modifica: Borra los cambios que el usuario hizo y vuelve a como estaba antes de que el usuario intentara insertar o modificar una tupla de recursos humanos
         * Retorna: N/A.
         */
        protected void BotonREQCancelar_Click(object sender, EventArgs e)
        {
            if(modo == 2)
                controladoraRequerimiento.UpdateUsoREQ(idViejo, 0);    //ya no está en uso
            desmarcarBotones();
            deshabilitarCampos();
            if (modo==2)
            {
                if (esAdmin)
                {
                    volverAlOriginal();
                    BotonREQEliminar.Enabled = true;
                    BotonREQModificar.Enabled = true;
                    llenarDatosRequerimiento(idViejo);

                }
                else
                {
                    volverAlOriginal();
                }
            }
            else if (modo==1)
            {
                volverAlOriginal();
            }
            modo=0;
           
        }


        /*
         * Requiere: N/A.
         * Modifica: Vuelve al inicio de Recursos Humanos.
         * Retorna: N/A.
         */
        protected void volverAlOriginal()
        {
            botonesInicio();
            desactivarErrores();
            deshabilitarCampos();
            llenarDDProyecto();
            if (esAdmin) {
                TextBoxNombreREQ.Text = ".";
                TextBoxPrecondicionesREQ.Text = "";
                TextBoxRequerimientosEspecialesREQ.Text = "";
                BotonREQAceptarModificar.Visible = false;
                BotonREQAceptar.Visible = true;
                BotonREQAceptarModificar.Enabled = false;
                BotonREQEliminar.Enabled = false;
                habilitarGrid();
                llenarGrid();
            }
            else
            {
                //consulta y cargar datos del usuario actual
                this.llenarDatosRequerimiento(controladoraRequerimiento.idDelLoggeado());
                BotonREQModificar.Enabled = true;
                BotonREQAceptarModificar.Visible = true;
                BotonREQAceptarModificar.Enabled = false;
                BotonREQCancelar.Enabled = false;
                BotonREQAceptar.Visible = false;
                BotonREQEliminar.Enabled = false;
                BotonREQEliminar.Visible = false;
                BotonREQInsertar.Visible = false;
                gridRequerimiento.Visible = false;
            } 




        }

        /*
         * Requiere: Evento click en boton aceptar de insertar.
         * Modifica: Intenta insertar una tupla de recurso humano en la base de datos y despliega el respectivo mensaje de error o exito.
         * Retorna: N/A.
         */
        protected void BotonREQAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Object[] datosNuevos = new Object[5];
                datosNuevos[0] = this.TextBoxNombreREQ.Text;
                datosNuevos[1] = this.TextBoxPrecondicionesREQ.Text;
                datosNuevos[2] = this.TextBoxRequerimientosEspecialesREQ.Text;
                datosNuevos[3] = this.ProyectoAsociado.SelectedValue;
                datosNuevos[4] = "1";

                int insercion = controladoraRequerimiento.insertarRequerimiento(datosNuevos);
                if (insercion == 1)
                {
                    modo = 0;
                    desmarcarBotones();
                    deshabilitarCampos();
                    BotonREQInsertar.Enabled = true;
                    BotonREQModificar.Enabled = true;
                    BotonREQEliminar.Enabled = true;
                    BotonREQCancelar.Enabled = false;
                    BotonREQAceptar.Enabled = false;
                    habilitarGrid();
                    llenarGrid();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido insertado con éxito');", true);
                    desmarcarBotones();
                    resaltarNuevo(this.TextBoxNombreREQ.Text);
                }
                else if(insercion == 2627)
                {
                    EtiqErrorLlaves.Visible = true;
                }
                else
                {
                    EtiqErrorInsertar.Visible = true;
                }
            }
    
        }

        /*
        * Requiere: Evento click en boton aceptar de modificar.
        * Modifica: Intenta insertar una tupla de recurso humano en la base de datos y despliega el respectivo mensaje de error o exito.
        * Retorna: N/A.
        */
        protected void BotonREQAceptarModificar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {

                Object[] datosNuevos = new Object[5];
                datosNuevos[0] = this.TextBoxNombreREQ.Text;//id_Req
                datosNuevos[1] = this.TextBoxPrecondicionesREQ.Text;
                datosNuevos[2] = this.TextBoxRequerimientosEspecialesREQ.Text;
                datosNuevos[3] = this.ProyectoAsociado.SelectedValue;
                datosNuevos[4] = idViejo;
                if (controladoraRequerimiento.modificarRequerimiento(datosNuevos) == 1)
                {
                    desmarcarBotones();
                    deshabilitarCampos();
                    BotonREQModificar.Enabled = true;
                    BotonREQCancelar.Enabled = false;
                    BotonREQAceptarModificar.Enabled = false;
                    modo = 0;
                    if (esAdmin)
                    {
                        habilitarGrid();
                        BotonREQInsertar.Enabled = true;
                        BotonREQEliminar.Enabled = true;
                        llenarGrid();
                        controladoraRequerimiento.UpdateUsoREQ(TextBoxNombreREQ.Text.ToString(), 0);//ya fue modificado el REQ
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido modificado con éxito');", true);
                        resaltarNuevo(this.TextBoxNombreREQ.Text);

                    }
                    else
                    {
                        controladoraRequerimiento.UpdateUsoREQ(TextBoxNombreREQ.Text.ToString(), 0);//ya fue modificado el REQ
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Su informacion ha sido actualizada exitosamente');", true);
                    }
                    //habilitar consulta
                }
                else
                {
                    EtiqErrorModificar.Visible = true;
                    //mensaje de error
                }
            }
        }

        protected void ProyectoAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        /*
        protected void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }*/

        /*
         * Requiere: N/A.
         * Modifica: Llena el dropdownlist de proyecto.
         * Retorna: N/A.
         */
        protected void llenarDDProyecto()
        {

            this.ProyectoAsociado.Items.Clear();
            //this.ProyectoAsociado.Items.Add(new ListItem("No aplica", "-1"));

            String proyectos = controladoraRequerimiento.solicitarProyectos();
            String[] pr = proyectos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split('_');
                try
                {
                    this.ProyectoAsociado.Items.Add(new ListItem(p2[0], p2[1]));
                }
                catch (Exception e)
                {

                }
                
            }
        }



        /*
         * Requiere: N/A.
         * Modifica: Habilita los campos para que el usuario pueda editar la informacion.
         * Retorna: N/A.
         */
        protected void habilitarCampos()
        {
            TextBoxNombreREQ.Enabled = true;
            TextBoxPrecondicionesREQ.Enabled = true;
            TextBoxRequerimientosEspecialesREQ.Enabled = true;
            BotonREQCancelar.Enabled = true;
            if (esAdmin)
            {
                ProyectoAsociado.Enabled = true;
                BotonREQAceptar.Enabled = true;
            } else
            {
                BotonREQAceptarModificar.Enabled = true;
            }

        }

        /*
         * Requiere: N/A.
         * Modifica: Deshabilita los campos para que el usuario pueda no editar la informacion.
         * Retorna: N/A.
         */
        protected void deshabilitarCampos()
        {

            TextBoxNombreREQ.Enabled = false;
            TextBoxPrecondicionesREQ.Enabled = false;
            TextBoxRequerimientosEspecialesREQ.Enabled = false;
            BotonREQCancelar.Enabled = false;
            ProyectoAsociado.Enabled = false;
            BotonREQAceptar.Enabled = false;
            BotonREQAceptarModificar.Enabled = false;
            
        }

        /*
         * Requiere: N/A.
         * Modifica: Resetea los botones para que vuelvan a estar como al inicio de todo.
         * Retorna: N/A.
         */
        protected void botonesInicio()
        {
            BotonREQCancelar.Enabled = false;
            if (esAdmin)
            {
                BotonREQEliminar.Enabled = false;
                BotonREQModificar.Enabled = false;
                BotonREQAceptar.Enabled = false;
                BotonREQInsertar.Enabled = true;
            }
            else
            {
                BotonREQAceptarModificar.Enabled = false;
                BotonREQModificar.Enabled = true;
            }
        }

        /*
         * Requiere: N/A.
         * Modifica: Activa y desactiva los botones al cancelar.
         * Retorna: N/A.
         */
        protected void botonesCancelar() //Estado de los botones después de apretar 
        {
            desmarcarBotones();
            if (esAdmin)
            {
                BotonREQInsertar.Enabled = true;
                if (gridRequerimiento.Rows.Count > 0)
                {
                    BotonREQModificar.Enabled = true;
                    BotonREQEliminar.Enabled = true;
                }
            }
            else
            {
                BotonREQModificar.Enabled = true;
            }
              
        }

        /*
         * Requiere: N/A.
         * Modifica: Habilita los botones de Modificar y Eiminar.
         * Retorna: N/A.
         */
        protected void habilitarBotonesME()
        {
            BotonREQEliminar.Enabled = true;
            BotonREQModificar.Enabled = true;
            BotonREQAceptar.Enabled = false;
            BotonREQCancelar.Enabled = false;
        }

        /*
         * Requiere: N/A.
         * Modifica: Valida el campo de email.
         * Retorna: N/A.
         */
        protected bool validarCampos()
        {
            desactivarErrores();
            bool todosValidos = true;

            /*Regex emailRE = new Regex("(([a-zA-z,.-_#%]+@[a-zA-z,.-_#%]+.[a-zA-z,.-_#%]+)?){0,29}");
            if ((TextBoxEmail.Text != "") &&
                (!Regex.IsMatch(TextBoxEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)))//emailRE.IsMatch(TextBoxEmail.Text))
            {
                todosValidos = false;
                EmailVal.Visible = true;
            }*/

            return todosValidos;
        }

        /*
         * Requiere: N/A.
         * Modifica: Desactiva todos los errores.
         * Retorna: N/A.
         */
        protected void desactivarErrores()
        {

            EtiqErrorPrecondiciones.Visible = false;
            EtiqErrorReqEsp.Visible = false;
            EtiqErrorNombre.Visible = false;
            EtiqErrorEliminar.Visible = false;
            EtiqErrorInsertar.Visible = false;
            EtiqErrorModificar.Visible = false;
            EtiqErrorLlaves.Visible = false;
            EtiqErrorConsultar.Visible = false;
        }

        /*
         * Requiere: Evento click en boton aceptar de modificar.
         * Modifica: Intenta insertar una tupla de recurso humano en la base de datos y despliega el respectivo mensaje de error o exito.
         * Retorna: N/A.
         */
        /*
        protected void BotonREQAceptarModificar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {

                Object[] datosNuevos = new Object[5];
                datosNuevos[0] = this.TextBoxNombreREQ.Text;//id_Req
                datosNuevos[1] = this.TextBoxPrecondicionesREQ.Text;
                datosNuevos[2] = this.TextBoxRequerimientosEspecialesREQ.Text;
                datosNuevos[3] = this.ProyectoAsociado.SelectedValue;
                datosNuevos[4] = idViejo;

            if (controladoraRequerimiento.modificarRequerimiento(datosNuevos) == 1)
            {
                desmarcarBotones();
                deshabilitarCampos();
                BotonREQModificar.Enabled = true;
                BotonREQCancelar.Enabled = false;
                BotonREQAceptarModificar.Enabled = false;
                modo = 0;
                if (esAdmin)
                {
                    habilitarGrid();
                    BotonREQInsertar.Enabled = true;
                    BotonREQEliminar.Enabled = true;
                    llenarGrid();
					controladoraRequerimiento.UpdateUsoREQ(TextBoxNombreREQ.Text.ToString(), 0);//ya fue modificado el REQ
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido modificado con éxito');", true);
                    resaltarNuevo(this.TextBoxNombreREQ.Text);
     
                }
                else
                {
					controladoraRequerimiento.UpdateUsoREQ(TextBoxNombreREQ.Text.ToString(), 0);//ya fue modificado el REQ
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Su informacion ha sido actualizada exitosamente');", true);
                }
                //habilitar consulta
            }
            else
            {
                EtiqErrorModificar.Visible = true;
                //mensaje de error
            }
            }
        } */

        /*
         * Requiere: Evento click en boton eliminar.
         * Modifica: Habilita y deshabilita los espacios y botones que se requieren para que el usuario sea capaz de modificar segun el tipo de perfil que tiene.
         * Retorna: N/A.
         */
        protected void BotonREQModificar_Click(object sender, EventArgs e)
        {
			if (controladoraRequerimiento.ConsultarUsoREQ(TextBoxNombreREQ.Text.ToString()) == false)
			{
				controladoraRequerimiento.UpdateUsoREQ(TextBoxNombreREQ.Text.ToString(), 1);//está siendo modificado el recurso humano
				
				modo = 2;
				marcarBoton(ref BotonREQModificar);
				BotonREQModificar.Enabled = false;
				desactivarErrores();
				BotonREQAceptarModificar.Visible = true;
				BotonREQAceptarModificar.Enabled = true;
				idViejo = TextBoxNombreREQ.Text;
				BotonREQAceptar.Visible = false;
				BotonREQCancelar.Enabled = true;
				BotonREQInsertar.Enabled = false;
				BotonREQEliminar.Enabled = false;
				if (esAdmin)
				{
					deshabilitarGrid();
					//PerfilAccesoComboBox.Enabled = false;
					//if (PerfilAccesoComboBox.SelectedItem.Text == "Administrador")
					//{
					//	RolComboBox.Enabled = false;
					//	ProyectoAsociado.Enabled = false;
					//}
				}
				habilitarCampos();
				//PerfilAccesoComboBox.Enabled = false;
				
			} else {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El Recurso Humano consultado se encuentra actualmente en uso');", true);		            
	        } 
        }

        /*
         * Requiere: N/A.
         * Modifica: Inicializa y llena el grid de recursos humanos.
         * Retorna: N/A.
         */
        protected DataTable crearTablaREQ()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Requerimiento", typeof(String));
            dt.Columns.Add("Precondiciones", typeof(String));
            dt.Columns.Add("Req. Especiales", typeof(String));
            dt.Columns.Add("Nombre Proyecto");
            //dt.
            return dt;
        }

        /*
         * Requiere: Evento seleccionar un recurso humano.
         * Modifica: Carga los datos del REQ seleccionado en pantalla.
         * Retorna: N/A.
         */
        protected void gridRequerimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gridRequerimiento.SelectedRow.RowIndex;
            String ced = gridRequerimiento.SelectedRow.Cells[0].Text;
            //int cedula = Convert.ToInt32(ced);
            llenarDatosRequerimiento(ced);
            habilitarGrid();
        }

        /*
         * Requiere: El evento de enlazar información de un datatable con el grid
         * Modifica: Establece el comportamiento del grid ante los diferentes eventos.
         * Retorna: N/A.
         */
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {   
        
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                e.Row.Attributes["onmouseout"]  = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridRequerimiento, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"]       = "cursor:pointer";
            }
               
        }

        /*
         * Requiere: Evento click en boton eliminar.
         * Modifica: Intenta insertar una tupla de recurso humano en la base de datos y despliega el respectivo mensaje de error o exito.
         * Retorna: N/A.
         */
        protected void BotonREQEliminar_Click(object sender, EventArgs e)
        {
            if (controladoraRequerimiento.ConsultarUsoREQ(TextBoxNombreREQ.Text.ToString()) == false){
				if (controladoraRequerimiento.eliminarRequerimiento(this.TextBoxNombreREQ.Text.ToString()) == 1)
				{
					ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido eliminado con éxito');", true);
					volverAlOriginal();
					llenarGrid();
					llenarGrid();
				}
				else
				{
					EtiqErrorEliminar.Visible = true;
				}
			}
            else
            {		
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El Recurso Humano consultado se encuentra actualmente en uso');", true);		
	        }
        }

        /*
         * Requiere: Evento de pasar de página en el grid.
         * Modifica: Pasa de página y llena el grid con las n tuplas que siguen, siendo n el tamaño de la página.
         * Retorna: N/A. 
        */
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRequerimiento.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }

        /*
         * Requiere: ref Button.
         * Modifica: Marca un boton.
         * Retorna: N/A.
         */
        protected void marcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.BackColor = System.Drawing.ColorTranslator.FromHtml("#2e8e9e");
            b.ForeColor = System.Drawing.Color.White;
        }

        /*
         * Requiere: ref Button.
         * Modifica: Desmarca un boton.
         * Retorna: N/A.
         */
        protected void desmarcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.Color.LightGray;
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.Black;

        }

        /*
         * Requiere: N/A..
         * Modifica: Desmarca todos los botones.
         * Retorna: N/A.
         */
        protected void desmarcarBotones()
        {
            desmarcarBoton(ref BotonREQInsertar);
            desmarcarBoton(ref BotonREQModificar);
            desmarcarBoton(ref BotonREQEliminar);
        }

        /*
         * Requiere: N/A.
         * Modifica: Deshabilita el grid de ser seleccionado.
         * Retorna: N/A.
         */
        protected void deshabilitarGrid()
        {
            gridRequerimiento.Enabled = false;
            foreach(GridViewRow row in gridRequerimiento.Rows)
            {
                row.Attributes.Remove("onclick");
                row.Attributes.Remove("onmouseover");
                row.Attributes.Remove("style");
                row.Attributes.Remove("onmouseout");
            }
        }

        /*
         * Requiere: N/A.
         * Modifica: Habilita la seleccion del grid.
         * Retorna: N/A.
         */
        protected void habilitarGrid()
        {
            gridRequerimiento.Enabled = true;
            foreach (GridViewRow row in gridRequerimiento.Rows)
            {
                row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridRequerimiento, "Select$" + row.RowIndex);
                row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#2e8e9e';;this.style.color='white'";
                row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";           
                row.Attributes["style"] = "cursor:pointer";
            }
        }

        /*
         * Requiere: Cedula del recurso humano más recientemente insertado o modificado.
         * Modifica: Mueve el grid para que se seleccione inmediatamente la página donde está la tupla agregada o modificada.
         * Retorna: N/A.      
        */

        protected void resaltarNuevo(String cedulaNuevo)
        {
            gridRequerimiento.AllowPaging = false;
            gridRequerimiento.DataBind();
            int i = 0;
            foreach (GridViewRow row in gridRequerimiento.Rows)
            {
                if (row.Cells[0].Text == cedulaNuevo)
                {
                    int pos = i / gridRequerimiento.PageSize;
                    gridRequerimiento.PageIndex = pos;
                    row.BackColor = System.Drawing.Color.Crimson;
                }
                i++;
            }
            gridRequerimiento.AllowPaging = true;
            gridRequerimiento.DataBind();
        }
    }
}