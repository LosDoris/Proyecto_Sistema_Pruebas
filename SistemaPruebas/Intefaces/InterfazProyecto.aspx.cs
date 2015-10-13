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
        private static int id_Proyecto = -1;
        private static int button = 0;
        Controladoras.ControladoraProyecto controladoraProyecto = new Controladoras.ControladoraProyecto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Restricciones_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            Modificar.Enabled = false;
            Eliminar.Enabled = false;
            llenarGrid();

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
            gridProyecto.Enabled = true;
            Insertar.Enabled = true;
            cancelar.Enabled = false;
            Modificar.Enabled = false;
        }
        protected void Insertar_button(object sender, EventArgs e)
        {
            button = 1;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            gridProyecto.Enabled = false;
            Habilitar_Campos();

        }
        protected void aceptar_Click(object sender, EventArgs e)
        {
           
                llenarGrid();
                switch (button)
                {
                    case 1://Insertar
                        {
                            if (nombre_proyecto.Text != "" && obj_general.Text != "" && nombre_rep.Text != "" && tel_rep.Text != "" && of_rep.Text != "")
                            {
                                Console.WriteLine("Insertar");
                                string text = Page.Request.Form["datepickernm"];
                                object[] datos = new object[8] { 0,nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text };

                                int a = controladoraProyecto.IngresaProyecto(datos);
                                if (a == 1)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido insertado con éxito');", true);

                                }

                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);

                                }

                                Limpiar_Campos();
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Modificar");
                            string text = Page.Request.Form["datepickernm"];
                            object[] datos = new object[8] {id_Proyecto, nombre_proyecto.Text, obj_general.Text, text, estado.SelectedValue, nombre_rep.Text, tel_rep.Text, of_rep.Text };

                            int a = controladoraProyecto.ActualizarProyecto(datos);
                            if (a == 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido insertado con éxito');", true);

                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);

                            }

                            Limpiar_Campos();

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Eliminar");
                            int a = controladoraProyecto.EliminarProyecto(id_Proyecto.ToString());
                            if (a == 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('El proyecto ha sido insertado con éxito');", true);

                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert('Ha ocurrido un problema, el proyecto no fue insertado');", true);

                            }

                            Limpiar_Campos();
                        }
                        break;
              
            }
        }
        protected void cancelar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
            Deshabilitar_Campos();
            aceptar.Enabled = false;
            cancelar.Enabled = false;
            gridProyecto.Enabled = true;
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
        protected DataTable crearTablaProyecto()
        {//Sólo se carga la info del ID y el nombre del sistema
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

            //columna = new DataColumn();
            //columna.DataType = System.Type.GetType("System.String");
            //columna.ColumnName = "Objetivo";
            //dt.Columns.Add(columna);

            //columna = new DataColumn();
            //columna.DataType = System.Type.GetType("System.String");
            //columna.ColumnName = "Fecha Asignación";
            //dt.Columns.Add(columna);

            //columna = new DataColumn();
            //columna.DataType = System.Type.GetType("System.String");
            //columna.ColumnName = "Estado";
            //dt.Columns.Add(columna);

            //columna = new DataColumn();
            //columna.DataType = System.Type.GetType("System.String");
            //columna.ColumnName = "Nombre Representante";
            //dt.Columns.Add(columna);
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
            DataTable dt = new DataTable();//crearTablaProyecto();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("conteo"), new DataColumn("Id Proyecto"), new DataColumn("Nombre del Sistema") });
            DataTable proyecto = controladoraProyecto.ConsultarProyectoIdNombre();
            Object[] datos = new Object[5];
            if (proyecto.Rows.Count > 0)
            {
                foreach (DataRow fila in proyecto.Rows)
                {
                   // DataRow dr = dt.NewRow();
                    dt.Rows.Add(fila[0].ToString(), fila[0].ToString(), fila[1].ToString());
                    //dr[0] = fila[0].ToString();
                    //dr[1] = fila[0].ToString();
                    //dr[2] = fila[1].ToString();
                    //datos[2] = fila[2].ToString();
                    //datos[3] = fila[3].ToString();
                    //datos[4] = fila[4].ToString();
                    //datos[5] = fila[5].ToString();
                    /*   datos[6] = fila[6].ToString();
                         datos[7] = fila[7].ToString();
                         */
                    //dt.Rows.Add(dr);
                }
            }
            else
            {
                //DataRow dr = dt.NewRow();
                //dt = new DataTable();
                dt.Rows.Add("-", "-", "*");
                //dr[0] = "3";
                //dr[1] = "4";
                //dr[2] = "-";
                //datos[2] = "-";
                //datos[3] = "-";
                //datos[4] = "-";
                //datos[5] = "-";
                /*        datos[6] = "-";
                        datos[7] = "-";

            */
               // dt.Rows.Add(dr);
            }
            this.gridProyecto.DataSource = dt;
            this.gridProyecto.DataBind();
        }

        public void Llenar_Datos_Conultados(int idProyecto)
        {
            Controladoras.EntidadProyecto entidadP = controladoraProyecto.ConsultarProyecto(idProyecto);
            this.nombre_proyecto.Text = entidadP.Nombre_sistema;
            this.obj_general.Text = entidadP.Objetivo_general;
            DateTime Text = Convert.ToDateTime(entidadP.Fecha_asignacion);
            if (this.estado.Items.FindByText(entidadP.Estado) != null)
            {
                this.estado.Items.FindByText(entidadP.Estado).Selected = true;
                //this.estado.SelectedValue = aux.Value;
            }
            this.nombre_rep.Text = entidadP.Nombre_representante;
            this.tel_rep.Text = entidadP.Telefono_representante;
            this.of_rep.Text = entidadP.Oficina_representante;
        }

        protected void gridProyecto_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            Modificar.Enabled = true;
            Eliminar.Enabled = true;
            Insertar.Enabled = false;
            GridViewRow filaSeleccionada = this.gridProyecto.Rows[Convert.ToInt32(e.CommandArgument)];
            id_Proyecto = Convert.ToInt32(filaSeleccionada.Cells[0].Text);
            Llenar_Datos_Conultados(id_Proyecto);

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            button = 2;
            gridProyecto.Enabled = false;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
            Habilitar_Campos();

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            button = 3;
            aceptar.Enabled = true;
            cancelar.Enabled = true;
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing BoundField Column
            try
            {
                id_Proyecto = Int32.Parse(gridProyecto.SelectedRow.Cells[0].Text);
                Llenar_Datos_Conultados(id_Proyecto);
                Modificar.Enabled = true;
                Eliminar.Enabled = true;
                aceptar.Enabled = true;
                cancelar.Enabled = true;
                Insertar.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}