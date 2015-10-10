using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SistemaPruebas.Controladoras;


namespace SistemaPruebas.Intefaces
{
    public partial class InterfazRecursoHumano : System.Web.UI.Page
    {

        ControladoraRecursosHumanos controladoraRecursosHumanos = new ControladoraRecursosHumanos();

        int modo = 0;  //Numero para identificar accion del boton Aceptar
                       //Opciones: 1. Insertar, 2. Modificar, 3. Eliminar, 4. Consultar

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDDPerfil();
                llenarDDRol();
                deshabilitarCampos();
                botonesInicio();
            }
        }

        protected void llenarGrid()        //se encarga de llenar el grid cada carga de pantalla
        {
            // RH.SelectedRow.
        }


        protected void PerfilAccesoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PerfilAccesoComboBox.SelectedItem.Text == "Administrador")
            {
                RolComboBox.Enabled = false;
                ProyectoAsociado.Enabled = false;
            }
            else
            {
                RolComboBox.Enabled = true;
                ProyectoAsociado.Enabled = true;
            }
        }

        //metodo para llenar dropdown list de los perfiles de acceso

        /*protected void BotonRHInsertar_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos();
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
            BotonRHInsertar.Enabled = false;

            Object[] datosNuevos = new Object[11];
            datosNuevos[0] = this.UserName.Text;//cedula
            datosNuevos[1] = this.Password.Text;//nombre
            datosNuevos[2] = this.TextBoxTel1.Text;
            datosNuevos[3] = this.TextBoxTel2.Text;
            datosNuevos[4] = this.TextBoxEmail.Text;
            datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
            datosNuevos[6] = this.TextBoxClave.Text;
            datosNuevos[7] = this.PerfilAccesoComboBox.SelectedValue.ToString();
            datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
            datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();
            datosNuevos[10] = 0; //default pues al crearse la cuenta aún no loggea a la persona
            controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos);
          
            //UserName.Text = "";
            //Password.Text = "";
        }*/
        protected void BotonRHInsertar_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos();
            volverAlOriginal();
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
            BotonRHInsertar.Enabled = false;
            // -------Esto va en Aceptar modo Insertar---------------------------------------
            // ------------------------------------------------------------------------------
            // ------------------------------------------------------------------------------
            /*Object[] datosNuevos = new Object[7];
            datosNuevos[0] = this.UserName.Text;//cedula
            datosNuevos[1] = this.Password.Text;//nombre
            datosNuevos[2] = this.TextBoxTel1.Text;
            datosNuevos[3] = this.TextBoxTel2.Text;
            datosNuevos[4] = this.TextBoxEmail.Text;
            datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
            datosNuevos[6] = this.TextBoxClave.Text;
            datosNuevos[7] = this.PerfilAccesoComboBox.SelectedValue.ToString();
            datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
            datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();
            controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos);
            */
            // ------------------------------------------------------------------------------
            // ------------------------------------------------------------------------------
            // ------------------------------------------------------------------------------


            //UserName.Text = "";
            //Password.Text = "";
        }

        protected void BotonRHCancelar_Click(object sender, EventArgs e)
        {
            volverAlOriginal();
        }

        protected void volverAlOriginal()
        {
            deshabilitarCampos();
            BotonRHAceptar.Enabled = false;
            BotonRHCancelar.Enabled = false;
            BotonRHInsertar.Enabled = true;
            UserName.Text = ".";
            Password.Text = ".";
        }

        /* protected void BotonRHAceptar_Click(object sender, EventArgs e)
         {
             deshabilitarCampos();
             //enviar la info a la controladora
             //Ver el resultado. Si se realizo exitosamente
         }*/
        protected void BotonRHAceptar_Click(object sender, EventArgs e)
        {
            deshabilitarCampos();
            BotonRHInsertar.Enabled = true;
            //habilitar consulta

            Object[] datosNuevos = new Object[7];
            datosNuevos[0] = this.UserName.Text;//cedula
            datosNuevos[1] = this.Password.Text;//nombre
            datosNuevos[2] = this.TextBoxTel1.Text;
            datosNuevos[3] = this.TextBoxTel2.Text;
            datosNuevos[4] = this.TextBoxEmail.Text;
            datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
            datosNuevos[6] = this.TextBoxClave.Text;
            //datosNuevos[7] = this.PerfilAccesoComboBox.SelectedValue.ToString();
            //datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
            //datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();
            if (modo == 1)
            {
                controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos);
            }
            else if (modo == 2)
            {
                controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos);
            }
            else if (modo == 3)
            {
                controladoraRecursosHumanos.eliminarRecursoHumano(Convert.ToInt32(this.UserName.Text.ToString()));
            }
            //si se inserto o modif exitosamente entonces aparece como la primera tupla del grid
            //enviar la info a la controladora
            //Ver el resultado. Si se realizo exitosamente
        }

        protected void ProyectoAsociado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("lkjlkjl");
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
            string[] tipos = new string[] { "Líder de desarrollo", "Líder de pruebas", "Programador", "Tester" };

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
            UserName.Enabled = true;
            Password.Enabled = true;
            RolComboBox.Enabled = true;
            PerfilAccesoComboBox.Enabled = true;
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
            UserName.Enabled = false;
            Password.Enabled = false;
            RolComboBox.Enabled = false;
            PerfilAccesoComboBox.Enabled = false;
            BotonRHAceptar.Enabled = false;
            BotonRHCancelar.Enabled = false;
        }

        protected void botonesInicio()
        {
            BotonRHEliminar.Enabled = false;
            BotonRHModificar.Enabled = false;
            BotonRHAceptar.Enabled = false;
            BotonRHCancelar.Enabled = false;
        }
        protected void habilitarBotonesME()
        {
            BotonRHEliminar.Enabled = true;
            BotonRHModificar.Enabled = true;
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
        }


    }
}