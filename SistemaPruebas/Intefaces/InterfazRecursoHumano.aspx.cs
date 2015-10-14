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
    public partial class InterfazRecursoHumano : System.Web.UI.Page
    {

        ControladoraRecursosHumanos controladoraRecursosHumanos = new ControladoraRecursosHumanos();

        int modo;  //Numero para identificar accion del boton Aceptar
        //Opciones: 1. Insertar, 2. Modificar, 3. Eliminar, 4. Consultar
        static String cedulaConsulta = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Restricciones_Campos();
            if (!IsPostBack)
            {
                volverAlOriginal();
            }
            llenarGrid();
            
        }

        protected void Restricciones_Campos()
        {


            TextBoxCedulaRH.MaxLength = 9;
            TextBoxNombreRH.MaxLength = 50;
            TextBoxEmail.MaxLength = 30;
            TextBoxTel1.MaxLength = 8;
            TextBoxTel2.MaxLength = 8;
            TextBoxUsuario.MaxLength = 30;
            TextBoxClave.MaxLength = 12;

        }

        protected void llenarGrid()        //se encarga de llenar el grid cada carga de pantalla
        {
            DataTable recursosHumanos = crearTablaRH();
            DataTable dt = controladoraRecursosHumanos.consultarRecursoHumano(1, 0); // en consultas tipo 1, no se necesita la cédula

            Object[] datos = new Object[4];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    datos[3] = dr[3];
                    recursosHumanos.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                recursosHumanos.Rows.Add(datos);
            }
            RH.DataSource = recursosHumanos;
            RH.DataBind();

        }


        void llenarDatosRecursoHumano(int cedula)
        {
            DataTable dt = controladoraRecursosHumanos.consultarRecursoHumano(2, cedula); // Consulta tipo 2, para llenar los campos de un recurso humano

            BotonRHEliminar.Enabled = true;
            BotonRHModificar.Enabled = true;

            TextBoxCedulaRH.Text = dt.Rows[0].ItemArray[0].ToString();
            TextBoxNombreRH.Text = dt.Rows[0].ItemArray[1].ToString();
            TextBoxTel1.Text = dt.Rows[0].ItemArray[2].ToString();
            TextBoxTel2.Text = dt.Rows[0].ItemArray[3].ToString();
            TextBoxEmail.Text = dt.Rows[0].ItemArray[4].ToString();
            TextBoxUsuario.Text = dt.Rows[0].ItemArray[5].ToString();
            TextBoxClave.Text = dt.Rows[0].ItemArray[6].ToString();
            PerfilAccesoComboBox.ClearSelection();
            PerfilAccesoComboBox.Items.FindByText(dt.Rows[0].ItemArray[7].ToString()).Selected = true;
            RolComboBox.ClearSelection();
            RolComboBox.Items.FindByText(dt.Rows[0].ItemArray[8].ToString()).Selected = true;
            ProyectoAsociado.ClearSelection();
            ProyectoAsociado.Items.FindByValue(dt.Rows[0].ItemArray[9].ToString()).Selected = true;



            //Response.Write(dt.Rows.Co)

        }

        protected void PerfilAccesoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PerfilAccesoComboBox.SelectedItem.Text == "Administrador")
            {
                RolComboBox.Enabled = false;
                RolComboBox.Items.Clear();
                RolComboBox.Items.Add(new ListItem("Administrador"));
                ProyectoAsociado.Enabled = false;

                //RolComboBox.Items.FindByText("No aplica").Selected = true;
                //ProyectoAsociado.Items.FindByValue("-1").Selected = true;
            }
            else
            {
                RolComboBox.Items.Clear();
                llenarDDRol();
                RolComboBox.Enabled = true;
                ProyectoAsociado.Enabled = true;
            }
        }/*

        protected void PerfilAccesoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PerfilAccesoComboBox.SelectedItem.Text == "Administrador")
            {
                RolComboBox.Enabled = false;
                ProyectoAsociado.Enabled = false;
                //RolComboBox.Items.FindByText("No aplica").Selected = true;
                //ProyectoAsociado.Items.FindByValue("-1").Selected = true;
            }
            else
            {
                RolComboBox.Enabled = true;
                ProyectoAsociado.Enabled = true;
            }
        }
        */
        //metodo para llenar dropdown list de los perfiles de acceso

        protected void BotonRHInsertar_Click(object sender, EventArgs e)
        {
            //Etiqueta1.Visible = false;
            RH.Enabled = false;
            habilitarCampos();
            llenarDDPerfil();
            llenarDDRol();
            llenarDDProyecto();
            desactivarErrores();
            //deshabilitarCampos();
            //botonesInicio();
            BotonRHAceptar.Visible = true;
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
            BotonRHInsertar.Enabled = false;
            
            // RH.SelectedIndex = -1;
            //RH.ReadOnly = true; 
            TextBoxCedulaRH.Text = "";
            TextBoxNombreRH.Text = "";
            TextBoxEmail.Text = "";
            TextBoxTel1.Text = "";
            TextBoxTel2.Text = "";
            TextBoxUsuario.Text = "";
            TextBoxClave.Text = "";

            marcarInsertar();
            

        }

        

        protected void BotonRHCancelar_Click(object sender, EventArgs e)
        {
            desmarcarBotones();
            volverAlOriginal();
           // botonesCancelar();
        }

        protected void volverAlOriginal()
        {
            botonesInicio();
            desactivarErrores();
            deshabilitarCampos();
            TextBoxCedulaRH.Text = ".";
            TextBoxNombreRH.Text = ".";
            TextBoxEmail.Text = "";
            TextBoxTel1.Text = "";
            TextBoxTel2.Text = "";
            TextBoxUsuario.Text = "";
            TextBoxClave.Text = "";
            llenarDDPerfil();
            llenarDDRol();
            llenarDDProyecto();
            BotonRHAceptarModificar.Visible = false;
            BotonRHAceptar.Visible = true;
            BotonRHAceptarModificar.Enabled = false;
            BotonRHEliminar.Enabled = false;




        }

        
             //si se inserto o modif exitosamente entonces aparece como la primera tupla del grid
             //enviar la info a la controladora
             //Ver el resultado. Si se realizo exitosamente
         
        protected void BotonRHAceptar_Click(object sender, EventArgs e)
        {
            //desactivarErrores();
            if (validarCampos())
            {


                Object[] datosNuevos = new Object[11];
                datosNuevos[0] = this.TextBoxCedulaRH.Text;//cedula
                datosNuevos[1] = this.TextBoxNombreRH.Text;//nombre
                datosNuevos[2] = this.TextBoxTel1.Text;
                datosNuevos[3] = this.TextBoxTel2.Text;
                datosNuevos[4] = this.TextBoxEmail.Text;
                datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
                datosNuevos[6] = this.TextBoxClave.Text;
                datosNuevos[7] = this.PerfilAccesoComboBox.SelectedItem.Text.ToString();
                datosNuevos[8] = this.ProyectoAsociado.SelectedValue;
                datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();
                datosNuevos[10] = 1;

                if (controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos) == 1)
                {
                    deshabilitarCampos();
                    BotonRHInsertar.Enabled = true;
                    BotonRHModificar.Enabled = true;
                    BotonRHEliminar.Enabled = true;
                    BotonRHCancelar.Enabled = false;
                    BotonRHAceptar.Enabled = false;
                    RH.Enabled = true;
                    llenarGrid();

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido insertado con éxito');", true);
                    desmarcarBotones();
                }
                else
                {
                    EtiqErrorInsertar.Visible = true;
                }
            }
            //si se inserto o modif exitosamente entonces aparece como la primera tupla del grid
            //enviar la info a la controladora
            //Ver el resultado. Si se realizo exitosamente
        }

        protected void ProyectoAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //jlkjlkjlkj
        }

        protected void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Response.Write("lkjlkjl");
        }


        protected void llenarDDProyecto()
        {

            this.ProyectoAsociado.Items.Clear();
            this.ProyectoAsociado.Items.Add(new ListItem("No aplica", "-1"));

            String proyectos = controladoraRecursosHumanos.solicitarProyectos();
            String[] pr = proyectos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split(' ');
                this.ProyectoAsociado.Items.Add(new ListItem(p2[0], p2[1]));
            }

        }

        protected void llenarDDPerfil()
        {
            this.PerfilAccesoComboBox.Items.Clear();
            string[] tipos = new string[] { "Miembro de equipo", "Administrador" };

            // Object[] perfiles = new Object[tipos.Length];

            for (int i = 0; i < tipos.Length; i++)
            {
                this.PerfilAccesoComboBox.Items.Add(new ListItem(tipos[i]));
            }

        }

        //líder de pruebas, tester, líder de desarrollo, usuario,soporte
        protected void llenarDDRol()
        {
            this.RolComboBox.Items.Clear();
            string[] tipos = new string[] { "No aplica", "Líder de desarrollo", "Líder de pruebas", "Programador", "Tester" };

            // Object[] roles = new Object[tipos.Length];

            for (int i = 0; i < tipos.Length; i++)
            {
                this.RolComboBox.Items.Add(new ListItem(tipos[i]));
            }

        }

        protected void habilitarCampos()
        {
            TextBoxClave.Enabled = true;
            TextBoxEmail.Enabled = true;
            TextBoxTel1.Enabled = true;
            TextBoxTel2.Enabled = true;
            TextBoxUsuario.Enabled = true;
            RH.Enabled = true;
            TextBoxCedulaRH.Enabled = true;
            TextBoxNombreRH.Enabled = true;
            RolComboBox.Enabled = true;
            PerfilAccesoComboBox.Enabled = true;
            ProyectoAsociado.Enabled = true;
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
        }

        protected void deshabilitarCampos()
        {
            TextBoxClave.Enabled = false;
            TextBoxEmail.Enabled = false;
            TextBoxTel1.Enabled = false;
            TextBoxTel2.Enabled = false;
            TextBoxUsuario.Enabled = false;
            TextBoxCedulaRH.Enabled = false;
            TextBoxNombreRH.Enabled = false;
            RolComboBox.Enabled = false;
            PerfilAccesoComboBox.Enabled = false;
            ProyectoAsociado.Enabled = false;
            BotonRHAceptar.Enabled = false;
            BotonRHCancelar.Enabled = false;
            //RH.Enabled = false;
        }

        protected void botonesInicio()
        {
            BotonRHEliminar.Enabled = false;
            BotonRHModificar.Enabled = false;
            BotonRHAceptar.Enabled = false;
            BotonRHCancelar.Enabled = false;
            BotonRHInsertar.Enabled = true;
        }
        protected void botonesCancelar() //Estado de los botones después de apretar 
             
        {
            desmarcarBotones();
            BotonRHInsertar.Enabled = true;
            if(RH.Rows.Count > 0)
            {
                BotonRHModificar.Enabled = true;
                BotonRHEliminar.Enabled = true;
            }
               // RH.Enabled = true;

        }

        protected void habilitarBotonesME()
        {
            BotonRHEliminar.Enabled = true;
            BotonRHModificar.Enabled = true;
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
        }
        protected bool validarCampos()
        {
            desactivarErrores();
            bool todosValidos = true;

            Regex emailRE = new Regex("(([a-zA-z,.-_#%]+@[a-zA-z,.-_#%]+.[a-zA-z,.-_#%]+)?){0,29}");
            if ((TextBoxEmail.Text != "") &&
                (!Regex.IsMatch(TextBoxEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)))//emailRE.IsMatch(TextBoxEmail.Text))
            {
                todosValidos = false;
                EmailVal.Visible = true;
                //poner mensaje de no valido
            }

            return todosValidos;
        }
        protected void desactivarErrores()
        {

            CedVal.Visible = false;
            NombVal.Visible = false;
            TelVal1.Visible = false;
            TelVal2.Visible = false;
            EmailVal.Visible = false;
            UserVal.Visible = false;
            ClaveVal.Visible = false;
            EtiqErrorEliminar.Visible = false;
            EtiqErrorInsertar.Visible = false;
            EtiqErrorModificar.Visible = false;
        }


        protected void BotonRHAceptarModificar_Click(object sender, EventArgs e)
        {
            {
                if (validarCampos())
                {
                    Object[] datosNuevos = new Object[11];
                    datosNuevos[0] = this.TextBoxCedulaRH.Text;//cedula
                    datosNuevos[1] = this.TextBoxNombreRH.Text;//nombre
                    datosNuevos[2] = this.TextBoxTel1.Text;
                    datosNuevos[3] = this.TextBoxTel2.Text;
                    datosNuevos[4] = this.TextBoxEmail.Text;
                    datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
                    datosNuevos[6] = this.TextBoxClave.Text;
                    datosNuevos[7] = this.PerfilAccesoComboBox.SelectedItem.Text.ToString();
                    datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
                    datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();
                    datosNuevos[10] = cedulaConsulta;

                    if (controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos) == 1)
                    {
                        desmarcarBotones();
                        RH.Enabled = true;
                        deshabilitarCampos();
                        BotonRHInsertar.Enabled = true;
                        BotonRHModificar.Enabled = true;
                        BotonRHEliminar.Enabled = true;
                        //habilitar consulta
                        BotonRHCancelar.Enabled = false;
                        BotonRHAceptar.Enabled = false;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido modificado con éxito');", true);
                    }
                    else
                    {
                        EtiqErrorModificar.Visible = true;
                        //mensaje de error
                    }
                }
                //si se inserto o modif exitosamente entonces aparece como la primera tupla del grid
                //enviar la info a la controladora
                //Ver el resultado. Si se realizo exitosamente
            }
        }


        protected void BotonRHModificar_Click(object sender, EventArgs e)
        {
            marcarModificar();
           // RH.Enabled = true;
            cedulaConsulta = TextBoxCedulaRH.Text;
            BotonRHAceptarModificar.Visible = true;
            BotonRHAceptar.Visible = false;
            desactivarErrores();
            BotonRHAceptarModificar.Enabled = true;
            BotonRHModificar.Enabled = false;
            BotonRHCancelar.Enabled = true;
            BotonRHInsertar.Enabled = false;
            BotonRHEliminar.Enabled = false;
            habilitarCampos();
            PerfilAccesoComboBox.Enabled = false;
        }

        protected DataTable crearTablaRH()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Cedula", typeof(int));
            dt.Columns.Add("Nombre Completo", typeof(String));
            dt.Columns.Add("Rol", typeof(String));
            dt.Columns.Add("Id Proyecto");
            return dt;
        }

        protected void RH_SelectedIndexChanged(object sender, EventArgs e)
        {
                int index = RH.SelectedRow.RowIndex;
                String ced = RH.SelectedRow.Cells[0].Text;
                int cedula = Convert.ToInt32(ced);
                llenarDatosRecursoHumano(cedula);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + cedula + "');", true);
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            GridView gr = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.DataRow && RH.Enabled == true)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#3260a0';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='black'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(RH, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
           
        }

        protected void BotonRHEliminar_Click(object sender, EventArgs e)
        {
            RH.Enabled = true;
            if (controladoraRecursosHumanos.eliminarRecursoHumano(Convert.ToInt32(this.TextBoxCedulaRH.Text.ToString())) == 1)
            {
                //marcarEliminar();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El recurso humano ha sido eliminado con éxito');", true);
                volverAlOriginal();
            }
            else
            {
                EtiqErrorEliminar.Visible = true;
            }
            //this.cedula = Convert.ToInt32(datos[0].ToString());
        }


        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RH.PageIndex = e.NewPageIndex;
            this.llenarGrid();
        }

        protected Object[] nombresProyectoGrid()
        {
            String proyectos = controladoraRecursosHumanos.solicitarProyectos();
            Object[] ids = null;
            String [] p = proyectos.Split(';');

            int i = 0;
            foreach (String p1 in p)
            {
                i++;
                String[] p2 = p1.Split(' ');
                ids[i] = p2[1];
            }

            return ids;

        }

        protected void marcarInsertar()
        {
            BotonRHInsertar.BorderColor = System.Drawing.Color.Black;
            BotonRHInsertar.BackColor = System.Drawing.Color.Black;
            BotonRHInsertar.ForeColor = System.Drawing.Color.White;
        }
        protected void desmarcarInsertar()
        {
            BotonRHInsertar.BorderColor = System.Drawing.Color.LightGray;
            BotonRHInsertar.BackColor = System.Drawing.Color.White;
            BotonRHInsertar.ForeColor = System.Drawing.Color.Black;
        }
        protected void marcarModificar()
        {

            BotonRHModificar.BorderColor = System.Drawing.Color.Black;
            BotonRHModificar.BackColor = System.Drawing.Color.Black;
            BotonRHModificar.ForeColor = System.Drawing.Color.White;
        }
        protected void desmarcarModificar()
        {
            BotonRHModificar.BorderColor = System.Drawing.Color.LightGray;
            BotonRHModificar.BackColor = System.Drawing.Color.White;
            BotonRHModificar.ForeColor = System.Drawing.Color.Black;
        }
        protected void marcarEliminar()
        {
            BotonRHEliminar.BorderColor = System.Drawing.Color.Black;
            BotonRHEliminar.BackColor = System.Drawing.Color.Black;
            BotonRHEliminar.ForeColor = System.Drawing.Color.White;
        }
        protected void desmarcarEliminar()
        {
            BotonRHEliminar.BorderColor = System.Drawing.Color.LightGray;
            BotonRHEliminar.BackColor = System.Drawing.Color.White;
            BotonRHEliminar.ForeColor = System.Drawing.Color.Black;
        }
        protected void desmarcarBotones()
        {
            desmarcarInsertar();
            desmarcarModificar();
            desmarcarEliminar();
        }
    }
}