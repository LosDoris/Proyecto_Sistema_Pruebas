using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazDiseno : System.Web.UI.Page
    {

        Controladoras.ControladoraDisenno controlDiseno = new Controladoras.ControladoraDisenno();
        protected void Page_Load(object sender, EventArgs e)
        {
            restriccionesCampos();
            deshabilitarCampos();
        }


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


        protected void insertarClick(object sender, EventArgs e)
        {
            limpiarCampos();
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
            habilitarCampos();
            deshabilitarGrid();
            marcarBoton(ref Insertar);
            button = "1";
            cancelar.Enabled = true;
            aceptar.Enabled = true;

        }

        protected void modificarClick(object sender, EventArgs e)
        {
        }

        protected void eliminarClick(object sender, EventArgs e)
        {
        }

        protected void restriccionesCampos()
        {
            nombreReqTxtbox.MaxLength = 30;
            precondicionReqTxtbox.MaxLength = 150;
            reqEspecialesReqTxtbox.MaxLength = 150;
            propositoTxtbox.MaxLength = 80;
            ambienteTxtbox.MaxLength = 150;
            procedimientoTxtbox.MaxLength = 150;
            criteriosTxtbox.MaxLength = 150;

        }

        protected void habilitarCampos()
        {
            nombreReqTxtbox.Enabled = true;
            precondicionReqTxtbox.Enabled = true;
            reqEspecialesReqTxtbox.Enabled = true;
            propositoTxtbox.Enabled = true;
            ambienteTxtbox.Enabled = true;
            procedimientoTxtbox.Enabled = true;
            criteriosTxtbox.Enabled = true;
            proyectoAsociado.Enabled = true;
            Nivel.Enabled = true;
            Tecnica.Enabled = true;
            Tipo.Enabled = true;
            responsable.Enabled = true;

        }

        protected void deshabilitarCampos()
        {
            nombreReqTxtbox.Enabled = false;
            precondicionReqTxtbox.Enabled = false;
            reqEspecialesReqTxtbox.Enabled = false;
            propositoTxtbox.Enabled = false;
            ambienteTxtbox.Enabled = false;
            procedimientoTxtbox.Enabled = false;
            criteriosTxtbox.Enabled = false;
            proyectoAsociado.Enabled = false;
            Nivel.Enabled = false;
            Tecnica.Enabled = false;
            Tipo.Enabled = false;
            responsable.Enabled = false;
        }

        protected void limpiarCampos()
        {
            nombreReqTxtbox.Text = "";
            precondicionReqTxtbox.Text = "";
            reqEspecialesReqTxtbox.Text = "";
            propositoTxtbox.Text = "";
            ambienteTxtbox.Text = "";
            procedimientoTxtbox.Text = "";
            criteriosTxtbox.Text = "";
            proyectoAsociado.ClearSelection();
            ListItem selectedListItem = proyectoAsociado.Items.FindByValue("1");
            Nivel.ClearSelection();
            ListItem selectedListItem1 = Nivel.Items.FindByValue("1");
            Tecnica.ClearSelection();
            ListItem selectedListItem2 = Tecnica.Items.FindByValue("1");
            Tipo.ClearSelection();
            ListItem selectedListItem3 = Tipo.Items.FindByValue("1");
            responsable.ClearSelection();
            ListItem selectedListItem4 = responsable.Items.FindByValue("1");
            cancelar.Enabled = false;
            Modificar.Enabled = false;

        }

        protected void aceptarClick(object sender, EventArgs e)
        {
            
            switch (Int32.Parse(button))
            {
                case 1://Insertar
                    {

                        string fecha = Page.Request.Form["txt_date"];
                        object[] datos = new object[7] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, Tipo.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha };
                        int a = controlDiseno.ingresaProyecto(datos);
                        if (a == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El diseño ha sido insertado con éxito');", true); //CAMBIAR ALERTA
                            llenarGridDisenos();
                            habilitarGrid();
                            deshabilitarCampos();
                            desmarcarBoton(ref Insertar);
                        }
                        else
                        {
                            //completar
                        }
                    }
                    break;
                case 2://Modificar
                    {
                    }
                    break;
                case 3://Eliminar
                    {
                    }
                    break;

            };
        }

        protected void cancelarClick()
        {

        }

        protected void llenarGridRequerimientos()
        {

        }

        protected void llenarGridDisenos()
        {

        }

        protected void habilitarGrid()
        {

        }

        protected void deshabilitarGrid()
        {

        }

        protected void habilitarProyectoMiembro()
        {

        }

        protected void deshabilitarProyectoMiembro()
        {

        }

        protected void obtenerDatosInsertados()
        {

            string fecha = Page.Request.Form["txt_date"];
            object[] datos = new object[7] { propositoTxtbox.Text, Nivel.SelectedValue, Tecnica.SelectedValue, Tipo.SelectedValue, ambienteTxtbox.Text, procedimientoTxtbox.Text, fecha};

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
    }
}
