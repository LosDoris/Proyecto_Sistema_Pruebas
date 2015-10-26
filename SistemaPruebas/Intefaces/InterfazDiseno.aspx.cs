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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void insertarClick(object sender, EventArgs e)
        {
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

        protected void aceptarClick()
        {

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
    }
}