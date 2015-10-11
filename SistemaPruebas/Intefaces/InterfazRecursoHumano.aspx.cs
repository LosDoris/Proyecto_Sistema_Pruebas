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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                volverAlOriginal();
                //modo = 0;
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
            //Etiqueta1.Visible = false;
            modo = 1;
            habilitarCampos();
            llenarDDPerfil();
            llenarDDRol();
            desactivarErrores();
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
            /*if (modo == 1)
            {
                EtiqErrorInsertar.Visible = true;
            }
            else
            {
                EtiqErrorModificar.Visible = true;
            }*/

        }

        protected void BotonRHCancelar_Click(object sender, EventArgs e)
        {
            volverAlOriginal();
            //modo = 0;
        }

        protected void volverAlOriginal()
        {
            botonesInicio();
            desactivarErrores();
            deshabilitarCampos();
            UserName.Text = ".";
            Password.Text = ".";
            TextBoxEmail.Text = "";
            TextBoxTel1.Text = "";
            TextBoxTel2.Text = "";
            TextBoxUsuario.Text = "";
            TextBoxClave.Text = "";
            llenarDDPerfil();
            llenarDDRol();
            BotonRHAceptarModificar.Visible = false;

        }

        /* protected void BotonRHAceptar_Click(object sender, EventArgs e)
         {
             //desactivarErrores();
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
                     EtiqErrorEliminar.Visible = true;
                 }
                 else
                 {
                     EtiqErrorModificar.Visible = true;
                 }
                 if (modo == 1)
                 {
                     deshabilitarCampos();
                     if (controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos) != -1)
                     {
                         deshabilitarCampos();
                         BotonRHInsertar.Enabled = true;
                         BotonRHModificar.Enabled = true;
                         BotonRHEliminar.Enabled = true;
                         //habilitar consulta
                         BotonRHCancelar.Enabled = false;
                         BotonRHAceptar.Enabled = false;
                     }
                     else
                     {
                         EtiqErrorInsertar.Visible = true;
                         //mensaje de error
                     }
                 }
                 else if (modo == 2)
                 {
                    // controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos);
                     if (controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos) != -1)
                     {
                         deshabilitarCampos();
                         BotonRHInsertar.Enabled = true;
                         BotonRHModificar.Enabled = true;
                         BotonRHEliminar.Enabled = true;
                         //habilitar consulta
                         BotonRHCancelar.Enabled = false;
                         BotonRHAceptar.Enabled = false;
                     }
                     else
                     {
                         EtiqErrorModificar.Visible = true;
                         //mensaje de error
                     }
                 }
                 else if (modo == 3)
                 {
                     //controladoraRecursosHumanos.eliminarRecursoHumano(Convert.ToInt32(this.UserName.Text.ToString()));
                     if (controladoraRecursosHumanos.eliminarRecursoHumano(Convert.ToInt32(this.UserName.Text.ToString())) != -1)
                     {
                         volverAlOriginal();
                     }
                     else
                     {
                         EtiqErrorModificar.Visible = true;
                         //mensaje de error
                     }
                 }
             }
             //si se inserto o modif exitosamente entonces aparece como la primera tupla del grid
             //enviar la info a la controladora
             //Ver el resultado. Si se realizo exitosamente
         }*/
        protected void BotonRHAceptar_Click(object sender, EventArgs e)
        {
            //desactivarErrores();
            if (validarCampos())
            {


                Object[] datosNuevos = new Object[10];
                datosNuevos[0] = this.UserName.Text;//cedula
                datosNuevos[1] = this.Password.Text;//nombre
                datosNuevos[2] = this.TextBoxTel1.Text;
                datosNuevos[3] = this.TextBoxTel2.Text;
                datosNuevos[4] = this.TextBoxEmail.Text;
                datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
                datosNuevos[6] = this.TextBoxClave.Text;
                datosNuevos[7] = this.PerfilAccesoComboBox.SelectedItem.Text.ToString();
                datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
                datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();

                if (controladoraRecursosHumanos.insertarRecursoHumano(datosNuevos) != -1)
                {
                    deshabilitarCampos();
                    BotonRHInsertar.Enabled = true;
                    BotonRHModificar.Enabled = true;
                    BotonRHEliminar.Enabled = true;
                    //habilitar consulta
                    BotonRHCancelar.Enabled = false;
                    BotonRHAceptar.Enabled = false;
                }
                else
                {
                    EtiqErrorInsertar.Visible = true;
                    //mensaje de error
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
            BotonRHInsertar.Enabled = true;
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

            Regex cedula = new Regex("[0-9]{1,11}");
            if (!cedula.IsMatch(UserName.Text))
            {
                todosValidos = false;
                CedVal.Visible = true;
                //poner mensaje de no valido
            }
            Regex nomb = new Regex("[a-zA-Z ]{1,49}");
            if (!nomb.IsMatch(Password.Text))
            {
                todosValidos = false;
                NombVal.Visible = true;
                //poner mensaje de no valido
            }
            // Regex tel = new Regex("^[0 - 9][0 - 9][0 - 9][0 - 9][0 - 9][0 - 9][0 - 9][0 - 9]$");
            //bool telef1 = (!Regex.IsMatch(TextBoxTel1.Text, "\b[0 - 9.,-] +{8,20}\b", RegexOptions.IgnoreCase));
            //bool telf2 = (!Regex.IsMatch(TextBoxTel1.Text, @"\A((?:[0-9,-]?){0,29})\Z", RegexOptions.IgnoreCase));
            Regex tel = new Regex(@"\d[0-9]{8,11}");
            bool telef1 = tel.IsMatch(TextBoxTel1.Text);
            bool telef2 = tel.IsMatch(TextBoxTel2.Text);
            if ((TextBoxTel1.Text != "") && (TextBoxTel2.Text != "")&&(!telef1||!telef2))//((!tel.IsMatch(TextBoxTel1.Text)) || (!tel.IsMatch(TextBoxTel2.Text)))
              {
                  todosValidos = false;
                  if (telef1)
                  {
                      TelVal1.Visible = true;
                  }
                  else {
                      TelVal2.Visible = true;
                  }
                  //poner mensaje de no valido
              }
            Regex emailRE = new Regex("(([a-zA-z,.-_#%]+@[a-zA-z,.-_#%]+.[a-zA-z,.-_#%]+)?){0,29}");
            if ((TextBoxEmail.Text != "") &&
                (!Regex.IsMatch(TextBoxEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)))//emailRE.IsMatch(TextBoxEmail.Text))
            {
                todosValidos = false;
                EmailVal.Visible = true;
                //poner mensaje de no valido
            }
            Regex user = new Regex("([a-zA-z0-9,.-_]*){0,29}");
            Regex clave = new Regex("([a-zA-z0-9,.-_]*){0,12}");
            if ((!user.IsMatch(TextBoxUsuario.Text)) || (!clave.IsMatch(TextBoxClave.Text)))
            {
                todosValidos = false;
                if ((!user.IsMatch(TextBoxUsuario.Text)))
                {
                    UserVal.Visible = true;
                }
                else
                {
                    ClaveVal.Visible = true;
                }
                //poner mensaje de no valido
            }
            /*    if (todosValidos == true)
                {
                    EtiqErrorInsertar.Visible = true;
                }
                else {
                    EtiqErrorModificar.Visible = true;
                }*/

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

        protected void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BotonRHAceptarModificar_Click(object sender, EventArgs e)
        {
            //desactivarErrores();
            {
                //desactivarErrores();
                if (validarCampos())
                {


                    Object[] datosNuevos = new Object[10];
                    datosNuevos[0] = this.UserName.Text;//cedula
                    datosNuevos[1] = this.Password.Text;//nombre
                    datosNuevos[2] = this.TextBoxTel1.Text;
                    datosNuevos[3] = this.TextBoxTel2.Text;
                    datosNuevos[4] = this.TextBoxEmail.Text;
                    datosNuevos[5] = this.TextBoxUsuario.Text;//nombre de usuario
                    datosNuevos[6] = this.TextBoxClave.Text;
                    datosNuevos[7] = this.PerfilAccesoComboBox.SelectedItem.Text.ToString();
                    datosNuevos[8] = this.ProyectoAsociado.SelectedValue.ToString();
                    datosNuevos[9] = this.RolComboBox.SelectedValue.ToString();

                    if (controladoraRecursosHumanos.modificarRecursoHumano(datosNuevos) != -1)
                    {
                        deshabilitarCampos();
                        BotonRHInsertar.Enabled = true;
                        BotonRHModificar.Enabled = true;
                        BotonRHEliminar.Enabled = true;
                        //habilitar consulta
                        BotonRHCancelar.Enabled = false;
                        BotonRHAceptar.Enabled = false;
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
            BotonRHAceptarModificar.Visible = true;
            BotonRHAceptar.Visible = false;
        }
    }
}