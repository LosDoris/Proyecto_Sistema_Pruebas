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
        private int button;
        private static int id_Proyecto = -1;
        Controladoras.ControladoraProyecto controladoraProyecto = new Controladoras.ControladoraProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Restricciones_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
           // llenarGrid();

        }
        protected void Restricciones_Campos()
        {
            
            nombre_proyecto.MaxLength = 10;
            obj_general.MaxLength = 50;
            nombre_rep.MaxLength = 30;
            tel_rep.MaxLength = 17;
            of_rep.MaxLength = 17;
            obj_general.Rows = 5;

        }
        protected void Habilitar_Campos()
        {
            nombre_proyecto.Enabled = true;
            obj_general.Enabled = true;
            estado.Enabled = true;
            nombre_rep.Enabled = true;
            tel_rep.Enabled = true;
            of_rep.Enabled = true;
            //datetimepicker('disable');


        }
        protected void Deshabilitar_Campos()
        {
            nombre_proyecto.Enabled = false;
            obj_general.Enabled = false;
            estado.Enabled = false;
            nombre_rep.Enabled = false;
            tel_rep.Enabled = false;
            of_rep.Enabled = false; 
        }
        protected void Limpiar_Campos()
        {
            nombre_proyecto.Text = "";
            obj_general.Text = "";            
            nombre_rep.Text = "";
            tel_rep.Text = "";
            of_rep.Text = ""; 
        }
        protected void Insertar_button(object sender, EventArgs e)
        {
            button = 1;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            Habilitar_Campos();
            
        }
        protected void aceptar_Click(object sender, EventArgs e)
        {
            if (nombre_proyecto.Text != "" && obj_general.Text != "" && nombre_rep.Text != "" && tel_rep.Text != "" && of_rep.Text != "")
            {
                // switch (button)
                //{
                //  case 1://Insertar
                //    {
                            string text = Page.Request.Form["datepickernm"];
                            object[] datos = new object[7]{nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text};
                            
                            int a= controladoraProyecto.IngresaProyecto(datos);
                if (a == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),"err_msg","alert('El proyecto ha sido insertado con éxito');", true);

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);

                }

                //    Limpiar_Campos();
                //  }
                //break;
                //case 2:
                //{

                //        }
                //        break;
                //        case 3:
                //        {

                //        }
                //        break;
                //}
            }
        }
        protected void cancelar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
        }
        protected void gridProyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "seleccionarProyecto":
                    {
                        GridViewRow filaSeleccionada = this.gridProyecto.Rows[Convert.ToInt32(e.CommandArgument)];
                        id_Proyecto = Convert.ToInt32(filaSeleccionada.Cells[1].Text);
                        Llenar_Datos_Conultados(id_Proyecto);
                    };
                    break;
            }

        }
        protected void gridProyecto_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected DataTable crearTablaProyecto()
        {
            DataTable dt = new DataTable();
            DataColumn columna;

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "ID_Proyecto";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Objetivo";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Fecha Asignación";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Estado";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Nombre Representante";
            dt.Columns.Add(columna);
/*
            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Tel Representante";
            dt.Columns.Add(columna);

            columna = new DataColumn();
            columna.DataType = System.Type.GetType("System.String");
            columna.ColumnName = "Oficina Representante";
            dt.Columns.Add(columna);
*/
            return dt;
        }

        protected void llenarGrid()
        {
            DataTable dt = crearTablaProyecto();
            DataTable ventas = controladoraProyecto.ConsultarProyecto();
            Object[] datos = new Object[5];
            if (ventas.Rows.Count > 0)
            {
                foreach (DataRow fila in ventas.Rows)
                {
                    datos[0] = fila[0].ToString();
                    datos[1] = fila[1].ToString();
                    datos[2] = fila[2].ToString();
                    datos[3] = fila[3].ToString();
                    datos[4] = fila[4].ToString();
                    datos[5] = fila[5].ToString();
               /*   datos[6] = fila[6].ToString();
                    datos[7] = fila[7].ToString();
                    */
                    dt.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                datos[4] = "-";
                datos[5] = "-";
        /*        datos[6] = "-";
                datos[7] = "-";

    */
                dt.Rows.Add(datos);
            }
            this.gridProyecto.DataSource = dt;
            this.gridProyecto.DataBind();
        }

        public void Llenar_Datos_Conultados(int idVenta)
        {
            DataTable datosFila = controladoraProyecto.ConsultarProyecto(idVenta);
            if (datosFila.Rows.Count == 1)
            {
                this.nombre_proyecto.Text = datosFila.Rows[0][1].ToString();
                this.obj_general.Text = datosFila.Rows[0][2].ToString();
            //    this.Text = datosFila.Rows[0][3].ToString();
               
                if (this.estado.Items.FindByText(datosFila.Rows[0][4].ToString()) != null)
                {
                    ListItem aux = this.estado.Items.FindByText(datosFila.Rows[0][4].ToString());
                    this.estado.SelectedValue = aux.Value;
                }

                this.nombre_rep.Text = datosFila.Rows[0][5].ToString();
                this.tel_rep.Text = datosFila.Rows[0][6].ToString();
                this.of_rep.Text = datosFila.Rows[0][7].ToString();

            }
        }

        protected void gridProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}