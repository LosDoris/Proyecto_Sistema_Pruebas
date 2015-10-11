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

        protected void BotonRHInsertar_Click(object sender, EventArgs e)
        {
            modo = 1;
            habilitarCampos();
            llenarDDPerfil();
            llenarDDRol();
            //deshabilitarCampos();
            //botonesInicio();
            BotonRHAceptar.Enabled = true;
            BotonRHCancelar.Enabled = true;
            BotonRHInsertar.Enabled = false;
            UserName.Text = "";
            Password.Text = "";
            TextBoxEmail.Text = "";
            TextBoxTel1.Text = "";
            TextBoxTel2.Text = "";
            TextBoxUsuario.Text = "";
            TextBoxClave.Text = "";

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
            TextBoxEmail.Text = "";
            TextBoxTel1.Text = "";
            TextBoxTel2.Text = "";
            TextBoxUsuario.Text = "";
            TextBoxClave.Text = "";
            llenarDDPerfil();
            llenarDDRol();

        }

        protected void BotonRHAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {

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
                    if (controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos) != -1)
                    {
                        deshabilitarCampos();
                        BotonRHInsertar.Enabled = true;
                        //habilitar consulta
                        BotonRHCancelar.Enabled = false;
                        BotonRHAceptar.Enabled = false;
                    }
                    else
                    {
                        //mensaje de error
                    }
                }
                else if (modo == 2)
                {
                    controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos);
                }
                else if (modo == 3)
                {
                    controladoraRecursosHumanos.eliminarRecursoHumano(Convert.ToInt32(this.UserName.Text.ToString()));
                }
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
        protected bool validarCampos()
        {
            bool todosValidos = true;

            Regex cedula = new Regex("[0-9]{1,11}");
            if (!cedula.IsMatch(UserName.Text))
            {
                todosValidos = false;
                //poner mensaje de no valido
            }
            Regex nomb = new Regex("[a-zA-Z ]{1,49}");
            if (!nomb.IsMatch(Password.Text))
            {
                todosValidos = false;
                //poner mensaje de no valido
            }
            Regex tel = new Regex("(([0-9][0-9][0-9][0-9]-?[0-9][0-9][0-9][0-9])?)");
            if ((!tel.IsMatch(TextBoxTel1.Text)) || (!tel.IsMatch(TextBoxTel2.Text)))
            {
                todosValidos = false;
                //poner mensaje de no valido
            }
            Regex emailRE = new Regex("(([a-zA-z,.-_#%]*@[a-zA-z,.-_#%]*.[a-zA-z,.-_#%]*)?)");
            if (!emailRE.IsMatch(TextBoxEmail.Text))
            {
                todosValidos = false;
                //poner mensaje de no valido
            }
            return todosValidos;
        }

    }
}