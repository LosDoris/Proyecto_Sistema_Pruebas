﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using SistemaPruebas.Controladoras;
using System.Data;
using System.Net;

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazEjecucion : System.Web.UI.Page
    {


        //variables de sesion
        ControladoraEjecucionPrueba controladoraEjecucionPrueba = new ControladoraEjecucionPrueba();
        /*
         * Requiere: N/A
         * Modifica: Declara variable global de modoEP (tipo de operación en ejecución)
         * Retorna: entero.
         */
        public static int modoEP
        {
            get
            {
                object value = HttpContext.Current.Session["modoEP"];
                return value == null ? 0 : (int)value;
            }
            set
            {
                HttpContext.Current.Session["modoEP"] = value;
            }
        }

        /*
         * Requiere: N/A
         * Modifica: Declara variable global que guarda el id del caso de prueba siendo modificado
         * Retorna: hilera.
         */
        public static String idMod
        {
            get
            {
                object value = HttpContext.Current.Session["idmod"];
                return value == null ? "" : (String)value;
            }
            set
            {
                HttpContext.Current.Session["idmod"] = value;
            }
        }

        /*
         * Requiere: N/A
         * Modifica: Variable global que guarda las no conformidades
         * Retorna: Lista de objetos.
         */
        public static List<Object[]> listaNC
        {
            get
            {
                object value = HttpContext.Current.Session["listaNC"];
                return value == null ? null : (List<Object[]>)value;
            }
            set
            {
                HttpContext.Current.Session["listaNC"] = value;
            }
        }


        public static List<int> filasEliminar
        {
            get
            {
                object value = HttpContext.Current.Session["filasEliminar"];
                return value == null ? null : (List<int >)value;
            }
            set
            {
                HttpContext.Current.Session["filasEliminar"] = value;
            }
        }

        public static DataTable dtNoConformidades
        {
            get
            {
                object value = HttpContext.Current.Session["noConformidades"];
                return value == null ? null : (DataTable)value;
            }
            set
            {
                HttpContext.Current.Session["noConformidades"] = value;
            }
        }


        //Page load
        /*
        * Requiere: N/A
        * Modifica: Maneja los eventos a ocurrir cada vez que se carga la página
        * Retorna: N/A.
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                estadoInicial();
                inicializarListaNC();
                inicializarDTnoConformidades();
                //gridNoConformidades.DataBind();
                gridEjecucion.Enabled = true;

            }
        }

        protected void inicializarListaNC()
        {
            listaNC = new List<Object[]>();
        }

        //inicializaciones
        /*
         * Requiere: N/A
         * Modifica: Establece el valor por defecto de la variable "modo" a 0.
         * Retorna: N/A
         */
        protected void inicializarModo()
        {
            modoEP = 0;
        }

        protected void estadoInicial()
        {
            DatosEjecucion.Enabled = false;
            llenarDDProyectoAdmin();
            inicializarModo();
        }


        //dropdowns
        protected void llenarDDProyectoAdmin()
        {

            this.DropDownProyecto.Items.Clear();
            DropDownProyecto.Items.Add(new ListItem("Seleccionar"));
            String proyectos = controladoraEjecucionPrueba.solicitarProyectos();
            String[] pr = proyectos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split('_');
                try
                {
                    if (Convert.ToInt32(p2[1]) > -1)
                    {
                        this.DropDownProyecto.Items.Add(new ListItem(p2[0], p2[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        protected void llenarDDDisseno()
        {
            this.DropDownDiseno.Items.Clear();
            DropDownDiseno.Items.Add(new ListItem("Seleccionar"));
            int idProyecto = Convert.ToInt32(DropDownProyecto.SelectedItem.Value);
            String disenos = controladoraEjecucionPrueba.solicitarPropositoDiseno(idProyecto);
            //Response.Write(disenos);
            String[] pr = disenos.Split(';');

            foreach (String p1 in pr)
            {
                String[] p2 = p1.Split('_');
                try
                {
                    if (Convert.ToInt32(p2[1]) > -1)
                    {
                        this.DropDownDiseno.Items.Add(new ListItem(p2[0], p2[1]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }

        protected void llenarDDCasoPrueba(ref DropDownList dd)
        {
            dd.Items.Clear();
            dd.Items.Add(new ListItem("Seleccionar"));
            int idDiseno = Convert.ToInt32(DropDownDiseno.SelectedItem.Value);
            String casosPrueba = controladoraEjecucionPrueba.solicitarCasosdePrueba(idDiseno);
            String[] pr = casosPrueba.Split(';');
            foreach (String p1 in pr)
            {
                try
                {
                    dd.Items.Add(new ListItem(p1));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

        }

        protected void llenarDDResponsables()
        {
            this.DropDownResponsable.Items.Clear();
            DropDownResponsable.Items.Add(new ListItem("Seleccionar", "1"));
            int idProyecto = Convert.ToInt32(DropDownProyecto.SelectedItem.Value);
            String responsables = controladoraEjecucionPrueba.solicitarResponsables(idProyecto);

            if (responsables != null)
            {
                String[] pr = responsables.Split(';');

                foreach (String p1 in pr)
                {
                    try
                    {
                        if (p1 != pr[pr.Length - 1])
                            this.DropDownResponsable.Items.Add(new ListItem(p1));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            else
            {
                this.DropDownResponsable.Items.Clear();
                DropDownResponsable.Items.Add(new ListItem("No Disponible"));
            }
        }

        protected void DropDownProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownProyecto.SelectedItem.Text != "Seleccionar")
            {
                DropDownDiseno.Enabled = true;
                llenarDDDisseno();
                llenarDDResponsables();
            }
            else
            {
                DropDownDiseno.Enabled = false;
            }
        }

        protected void DropDownDiseno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownDiseno.SelectedItem.Text != "Seleccionar")
            {
                BotonesPrincipales.Enabled = true;
                llenarGridEjecucion(DropDownDiseno.SelectedItem.Text.ToString());
            }
            else
            {
                BotonesPrincipales.Enabled = false;
                DatosEjecucion.Enabled = false;

            }

        }

        protected void DropDownCasoDePrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //botones insertar, modificar, eliminar
        protected void BotonEPInsertar_Click(object sender, EventArgs e)
        {
            modoEP = 1;
            estadoInsertar();
        }

        protected void estadoInsertar()
        {
            marcarBoton(ref BotonEPInsertar);
            limpiarCampos();
            habilitarCampos();
            BotonEPAceptar.Enabled = true;
            BotonEPCancelar.Enabled = true;
            BotonEPModificar.Enabled = false;
            BotonEPEliminar.Enabled = false;
            //deshabilitarGrid(ref gridEjecucion);
        }

        protected void estadoModificar()
        {
            marcarBoton(ref BotonEPModificar);
            limpiarCampos();
            habilitarCampos();
            BotonEPAceptar.Enabled = true;
            BotonEPCancelar.Enabled = true;
            BotonEPInsertar.Enabled = false;
            BotonEPModificar.Enabled = true;
            BotonEPEliminar.Enabled = false;
            //deshabilitarGrid(ref gridEjecucion);
        }

        protected void limpiarCampos()
        {

            DropDownResponsable.SelectedValue = "1";
            FechaEP.Text = "";
            TextBoxIncidencias.Text = "";
            inicializarDTnoConformidades();

        }

        protected void habilitarCampos()
        {
            DatosEjecucion.Enabled = true;
            //habilitarGrid(ref gridEjecucion);
        }

        /*
         * Requiere: Botón.
         * Modifica: Se encarga de marcar el botón pasado por parámetro.
         * Retorna: N/A
         */
        protected void marcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.ColorTranslator.FromHtml("#18c0a8");
            b.BackColor = System.Drawing.ColorTranslator.FromHtml("#18c0a8");
            b.ForeColor = System.Drawing.Color.White;
        }

        /*
         * Requiere: Botón.
         * Modifica: Se encarga de desmarcar el botón pasado por parámetro.
         * Retorna: N/A
         */
        protected void desmarcarBoton(ref Button b)
        {
            b.BorderColor = System.Drawing.Color.LightGray;
            b.BackColor = System.Drawing.Color.White;
            b.ForeColor = System.Drawing.Color.Black;
        }

        //protected void Subir_Click(object sender, EventArgs e)
        //{
        //    string strCon = "Data Source=RICARDO;Initial Catalog=PruebaInge;Integrated Security=True";
        //    if (FileUploadControl.HasFile)
        //    {
        //        try
        //        {
        //            int length = FileUploadControl.PostedFile.ContentLength;
        //            byte[] imgbyte = new byte[length];
        //            HttpPostedFile img = FileUploadControl.PostedFile;
        //            img.InputStream.Read(imgbyte, 0, length);
        //            string base64String = Convert.ToBase64String(imgbyte, 0, imgbyte.Length);
        //            ImagenResultado.ImageUrl = "data:image/png;base64," + base64String;
        //            ImagenResultado.Visible = true;
        //            String filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
        //            using (SqlConnection con = new SqlConnection(strCon))
        //            {
        //                using (SqlCommand cmd = new SqlCommand())
        //                {
        //                    cmd.CommandText = "insert into Image_Sample(imagename,imgdata) values(@Name,@Data)";
        //                    cmd.Parameters.AddWithValue("@Name", filename);
        //                    cmd.Parameters.AddWithValue("@Data", imgbyte);
        //                    cmd.Connection = con;
        //                    con.Open();
        //                    int a = cmd.ExecuteNonQuery();
        //                    Response.Write("lkjlkjlk" + a);
        //                    con.Close();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}



        //grid no conformidades
        protected void gridNoConformidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList dropDownCasos = (e.Row.FindControl("ddlIdCaso") as DropDownList);
                llenarDDCasoPrueba(ref dropDownCasos);
            }
        }

        //no conformidades
        protected void inicializarDTnoConformidades()
        {
            try
            {
                dtNoConformidades = null;
                DataTable dt = new DataTable();

                dt.Columns.AddRange(

                   new DataColumn[]
                   {

                        new DataColumn("Id", typeof(int)),
                        new DataColumn("Tipo", typeof(String)),
                        new DataColumn("IdCaso",typeof(String)),
                        new DataColumn("Descripcion", typeof(String)),
                        new DataColumn("Justificacion", typeof(String)),
                        new DataColumn("Resultado", typeof(String)),
                        new DataColumn("Estado", typeof(String))
                   }
                 );

                DataRow drRow = dt.NewRow();

                drRow["Id"] = 1;
                drRow["Tipo"] = String.Empty;
                drRow["IdCaso"] = String.Empty;
                drRow["Descripcion"] = String.Empty;
                drRow["Justificacion"] = String.Empty;
                drRow["Resultado"] = String.Empty;
                drRow["Estado"] = string.Empty;

                dt.Rows.Add(drRow);
                dtNoConformidades = dt;
                gridNoConformidades.DataSource = dtNoConformidades;
                gridNoConformidades.DataBind();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void AgregarFIla_Click(object sender, EventArgs e)
        {
            try
            {
                agregarFilaGridNC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void agregarFilaGridNC()
        {
            try
            {
                int indiceFila = 0;
                if (dtNoConformidades != null)
                {
                    DataTable dtCurrentTable = dtNoConformidades;

                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            DropDownList ddl1 = gridNoConformidades.Rows[indiceFila].FindControl("ddlTipo") as DropDownList;
                            DropDownList ddl2 = gridNoConformidades.Rows[indiceFila].FindControl("ddlIdCaso") as DropDownList;
                            TextBox txt1 = gridNoConformidades.Rows[indiceFila].FindControl("txtDescripcion") as TextBox;
                            TextBox txt2 = gridNoConformidades.Rows[indiceFila].FindControl("txtJustificacion") as TextBox;
                            System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[indiceFila].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                            DropDownList ddl3 = gridNoConformidades.Rows[indiceFila].FindControl("ddlEstado") as DropDownList;
                            drCurrentRow = dtCurrentTable.NewRow();
                            // drCurrentRow["RowNumber"] = i + 1;

                            dtCurrentTable.Rows[i - 1]["Tipo"] = ddl1.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["IdCaso"] = ddl2.SelectedValue;
                            dtCurrentTable.Rows[i - 1]["Descripcion"] = txt1.Text;
                            dtCurrentTable.Rows[i - 1]["Justificacion"] = txt2.Text;
                            dtCurrentTable.Rows[i - 1]["Resultado"] = imagenRes.ImageUrl.ToString();
                            dtCurrentTable.Rows[i - 1]["Estado"] = ddl3.SelectedValue;
                            indiceFila++;
                        }

                        dtCurrentTable.Rows.Add(drCurrentRow);
                        dtNoConformidades = dtCurrentTable;
                        gridNoConformidades.DataSource = dtCurrentTable;
                        gridNoConformidades.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                conservarEstado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void conservarEstado()
        {
            try
            {
                int indiceFila = 0;
                if (dtNoConformidades != null)
                {
                    DataTable dtCurrentTable = dtNoConformidades;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            DropDownList ddl1 = gridNoConformidades.Rows[indiceFila].FindControl("ddlTipo") as DropDownList;
                            DropDownList ddl2 = gridNoConformidades.Rows[indiceFila].FindControl("ddlIdCaso") as DropDownList;
                            TextBox txt1 = gridNoConformidades.Rows[indiceFila].FindControl("txtDescripcion") as TextBox;
                            TextBox txt2 = gridNoConformidades.Rows[indiceFila].FindControl("txtJustificacion") as TextBox;
                            System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[indiceFila].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                            DropDownList ddl3 = gridNoConformidades.Rows[indiceFila].FindControl("ddlEstado") as DropDownList;

                            ddl1.SelectedValue = dtCurrentTable.Rows[i]["Tipo"].ToString();
                            ddl2.SelectedValue = dtCurrentTable.Rows[i]["IdCaso"].ToString();
                            txt1.Text = dtCurrentTable.Rows[i]["Descripcion"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["Justificacion"].ToString();
                            imagenRes.ImageUrl = dtCurrentTable.Rows[i]["Resultado"].ToString();
                            ddl3.SelectedValue = dtCurrentTable.Rows[i]["Estado"].ToString();
                            indiceFila++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void subirImagen_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent.Parent;
            int index = gvRow.RowIndex;

            FileUpload fu = gridNoConformidades.Rows[index].FindControl("Uploader") as FileUpload;
            System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[index].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;

            if (fu.HasFile)
            {

                try
                {
                    int length = fu.PostedFile.ContentLength;
                    byte[] imgbyte = new byte[length];
                    HttpPostedFile img = fu.PostedFile;
                    img.InputStream.Read(imgbyte, 0, length);
                    string base64String = Convert.ToBase64String(imgbyte, 0, imgbyte.Length);
                    imagenRes.ImageUrl = "data:image/png;base64," + base64String;
                    imagenRes.Visible = true;
                    String base64 = imagenRes.ImageUrl.Replace("data:image/png;base64,", "");
                    String filename = Path.GetFileName(fu.PostedFile.FileName);
                    //byte[] bytes = Convert.FromBase64String(base64String);
                    //Response.Write(imagenRes.ImageUrl);
                    //using (SqlConnection con = new SqlConnection(strCon))
                    //{
                    //    using (SqlCommand cmd = new SqlCommand())
                    //    {
                    //        cmd.CommandText = "insert into Image_Sample(imagename,imgdata) values(@Name,@Data)";
                    //        cmd.Parameters.AddWithValue("@Name", filename);
                    //        cmd.Parameters.AddWithValue("@Data", imgbyte);
                    //        cmd.Connection = con;
                    //        con.Open();
                    //        int a = cmd.ExecuteNonQuery();
                    //        Response.Write("lkjlkjlk" + a);
                    //        con.Close();
                    //    }

                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void gridNoConformidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = gridNoConformidades.Rows[index];

            //if (e.CommandName == "pasarFila")
            //{
            //    // Retrieve the row index stored in the 
            //    // CommandArgument property.
            //    int index = Convert.ToInt32(e.CommandArgument);

            //    // Retrieve the row that contains the button 
            //    // from the Rows collection.
            //    GridViewRow row = gridNoConformidades.Rows[index];

            //    // Add code here to add the item to the shopping cart.
            //}
        }

        protected void recuperarNoConformidades()
        {
            foreach (GridViewRow row in gridNoConformidades.Rows)
            {
                Object[] noConformidad = new Object[8];

                DropDownList ddl1 = row.FindControl("ddlTipo") as DropDownList;
                DropDownList ddl2 = row.FindControl("ddlIdCaso") as DropDownList;
                TextBox txt1 = row.FindControl("txtDescripcion") as TextBox;
                TextBox txt2 = row.FindControl("txtJustificacion") as TextBox;
                System.Web.UI.WebControls.
                Image imagenRes = row.FindControl("imagenSubida") as System.Web.UI.WebControls.
                                                                     Image;
                DropDownList ddl3 = row.FindControl("ddlEstado") as DropDownList;
                Label lbl = row.FindControl("lblIDNC") as Label;

                String base64 = imagenRes.ImageUrl.Replace("data:image/png;base64,", "");
                byte[] imgbyte = Convert.FromBase64String(base64);

                noConformidad[0] = ddl1.SelectedItem.Text;
                noConformidad[1] = ddl2.SelectedItem.Text;
                noConformidad[2] = txt1.Text;
                noConformidad[3] = txt2.Text;
                noConformidad[4] = imgbyte;
                noConformidad[5] = ddl3.SelectedItem.Text;
                noConformidad[7] = lbl.Text;
                listaNC.Add(noConformidad);
            }
        }


        //grid ejecucion
        protected void OnGridEjecucionPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEjecucion.PageIndex = e.NewPageIndex;
            this.llenarGridEjecucion(DropDownDiseno.SelectedValue.ToString());
            gridEjecucion.DataBind();
        }

        protected void OnGridEjecucionRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.background='#18c0a8';;this.style.color='white'";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.background='white';this.style.color='#154b67'";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridEjecucion, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void GridEjecucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //SELECT fecha, responsable, incidencias, id_disenno FROM Ejecucion WHERE fecha = '" + id + "';";
                string fecha = gridEjecucion.SelectedRow.Cells[0].Text;
                llenarDatosEjecucionPrueba(fecha);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        protected void llenarDatosEjecucionPrueba(String fecha)
        {
            DataTable dtEjecucion = controladoraEjecucionPrueba.consultarEjecucion(2, fecha);
            this.ControlFecha.Text = dtEjecucion.Rows[0].ItemArray[0].ToString();
            this.DropDownResponsable.Text = dtEjecucion.Rows[0].ItemArray[1].ToString();
            this.TextBoxIncidencias.Text = dtEjecucion.Rows[0].ItemArray[2].ToString();
            this.DropDownDiseno.Text = dtEjecucion.Rows[0].ItemArray[3].ToString();
            llenarGridNCConsulta(fecha);

        }

        protected void limpiarNC()
        {
            dtNoConformidades = new DataTable();
            dtNoConformidades.Columns.AddRange
            (
                new DataColumn[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("Tipo", typeof(String)),
                    new DataColumn("IdCaso",typeof(String)),
                    new DataColumn("Descripcion", typeof(String)),
                    new DataColumn("Justificacion", typeof(String)),
                    new DataColumn("Resultado", typeof(String)),
                    new DataColumn("Estado", typeof(String))
                }
            );

        }

        protected void llenarGridNCConsulta(String fecha)
        {
            DataTable dtNC = controladoraEjecucionPrueba.consultarNoConformidades(fecha);
            limpiarNC();

            if (dtNC.Rows.Count > 0)
            {
                int numRow = dtNC.Rows.Count;
                for (int i = 0; i < numRow; i++)
                {
                    DataRow drCurrentRow = dtNoConformidades.NewRow();
                    dtNoConformidades.Rows.Add(drCurrentRow);
                    gridNoConformidades.DataSource = dtNoConformidades;
                    gridNoConformidades.DataBind();
                   // ddl3.Items.FindByText(dtNC.Rows[i].ItemArray[5].ToString()).Selected = true;
                }
                leerNC(dtNC);
                
            }
            // dtNoConformidades = dtNC;

        }

        protected void leerNC(DataTable dtNC)
        {
            for( int i = 0; i < gridNoConformidades.Rows.Count; i++ )
            {
                DropDownList ddl1 = gridNoConformidades.Rows[i].FindControl("ddlTipo") as DropDownList;
                DropDownList ddl2 = gridNoConformidades.Rows[i].FindControl("ddlIdCaso") as DropDownList;
                TextBox txt1 = gridNoConformidades.Rows[i].FindControl("txtDescripcion") as TextBox;
                TextBox txt2 = gridNoConformidades.Rows[i].FindControl("txtJustificacion") as TextBox;
                System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[i].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                DropDownList ddl3 = gridNoConformidades.Rows[i].FindControl("ddlEstado") as DropDownList;
                Label lbl = gridNoConformidades.Rows[i].FindControl("lblIDNC") as Label;

                dtNoConformidades.Rows[i]["Tipo"] = ddl1.SelectedValue;
                dtNoConformidades.Rows[i]["IdCaso"] = ddl2.SelectedValue;
                dtNoConformidades.Rows[i]["Descripcion"] = txt1.Text;
                dtNoConformidades.Rows[i]["Justificacion"] = txt2.Text;
                dtNoConformidades.Rows[i]["Resultado"] = imagenRes.ImageUrl.ToString();
                dtNoConformidades.Rows[i]["Estado"] = ddl3.SelectedValue;

                ddl1.ClearSelection();
                ddl1.Items.FindByText(dtNC.Rows[i].ItemArray[0].ToString()).Selected = true;
                ddl2.ClearSelection();
                ddl2.Items.FindByText(dtNC.Rows[i].ItemArray[1].ToString()).Selected = true;
                txt1.Text = dtNC.Rows[i].ItemArray[2].ToString();
                txt2.Text = dtNC.Rows[i].ItemArray[3].ToString();
                byte[] imgbyte = (byte[])dtNC.Rows[i].ItemArray[4];
                String base64String = Convert.ToBase64String(imgbyte, 0, imgbyte.Length);
                String B64 = base64String.Substring(36);
                imagenRes.ImageUrl = "data:image/png;base64," + B64;
                ddl3.ClearSelection();
                ddl3.Items.FindByText(dtNC.Rows[i].ItemArray[5].ToString()).Selected = true;
                lbl.Text = dtNC.Rows[i].ItemArray[6].ToString();
                
            }
        }

        protected void llenarGridEjecucion(string id_diseno)
        {
            DataTable ejecuciones = crearTablaGridEjecuciones();
            DataTable dt = controladoraEjecucionPrueba.consultarEjecucion(1, id_diseno);

            Object[] datos = new Object[3];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    ejecuciones.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                ejecuciones.Rows.Add(datos);
            }
            gridEjecucion.DataSource = ejecuciones;
            gridEjecucion.DataBind();
        }

        protected DataTable crearTablaGridEjecuciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(String));
            dt.Columns.Add("Responsable", typeof(String));
            dt.Columns.Add("Propósito Diseño", typeof(String));
            return dt;
        }



        //aceptarsh
        protected void BotonEPAceptar_Click(object sender, EventArgs e)
        {
            //private int id_disenno;
            //private String fechaConsulta;

            Object[] datosNuevos = new Object[5];
            datosNuevos[0] = this.ControlFecha.Text;
            datosNuevos[1] = this.DropDownResponsable.SelectedValue.ToString();
            datosNuevos[2] = this.TextBoxIncidencias.Text;
            datosNuevos[3] = this.DropDownDiseno.SelectedItem.Value.ToString();
            recuperarNoConformidades();

            int operacion = -1;

            String res = "";
            if (modoEP == 1)
            {
                datosNuevos[4] = "";
                 res = controladoraEjecucionPrueba.insertarEjecucion(datosNuevos, listaNC);
               
            }
            else if (modoEP == 2)
            {
                datosNuevos[4] = idMod;
                res = controladoraEjecucionPrueba.modificarEjecucion(datosNuevos, listaNC);
            }
            if (res != "-") operacion = 1;

            if (operacion == 1)
            {
                switch (modoEP)
                {
                    case 1:
                        {
                            EtiqMensajeOperacion.Text = "La ejecución de prueba ha sido insertada con éxito";
                            desmarcarBoton(ref BotonEPInsertar);
                            break;
                        }
                    case 2:
                        {
                            EtiqMensajeOperacion.Text = "La ejecución de prueba ha sido modificada con éxito";
                            desmarcarBoton(ref BotonEPModificar);
                            break;
                        }
                }
                EtiqMensajeOperacion.ForeColor = System.Drawing.Color.DarkSeaGreen;
                llenarGridEjecucion(DropDownDiseno.SelectedItem.Text.ToString());
               // estadoPostOperacion();
            }
            else
            {
                switch (operacion)
                {
                    case 2627:
                        {
                            EtiqMensajeOperacion.Text = "Ya se hizo una ejecución asociada al diseño elegido en esta fecha.";
                            //TextBoxID.BorderColor = System.Drawing.Color.Red;
                            break;
                        }
                    default:
                        {
                            EtiqMensajeOperacion.Text = "Ocurrió un problema en la operación.";
                            break;
                        }
                }
                EtiqMensajeOperacion.ForeColor = System.Drawing.Color.Salmon;
            }
            EtiqMensajeOperacion.Visible = true;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "HideLabel();", true);
        }

        protected void BotonEPModificar_Click(object sender, EventArgs e)
        {
            modoEP = 2;
            idMod = ControlFecha.Text;
            estadoModificar();

        }

       
        protected void btnEliminarFila_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            dtNoConformidades.Rows[index].Delete();
            for (int i = 0; i < gridNoConformidades.Rows.Count; i++)
            {
                DropDownList ddl1 = gridNoConformidades.Rows[i].FindControl("ddlTipo") as DropDownList;
                DropDownList ddl2 = gridNoConformidades.Rows[i].FindControl("ddlIdCaso") as DropDownList;
                TextBox txt1 = gridNoConformidades.Rows[i].FindControl("txtDescripcion") as TextBox;
                TextBox txt2 = gridNoConformidades.Rows[i].FindControl("txtJustificacion") as TextBox;
                System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[i].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                DropDownList ddl3 = gridNoConformidades.Rows[i].FindControl("ddlEstado") as DropDownList;
                int pos = i;
                if( pos != index )
                {
                    if(pos > index)
                    {
                        pos--;
                    }
                        dtNoConformidades.Rows[pos]["Tipo"] = ddl1.SelectedValue;
                        dtNoConformidades.Rows[pos]["IdCaso"] = ddl2.SelectedValue;
                        dtNoConformidades.Rows[pos]["Descripcion"] = txt1.Text;
                        dtNoConformidades.Rows[pos]["Justificacion"] = txt2.Text;
                        dtNoConformidades.Rows[pos]["Resultado"] = imagenRes.ImageUrl.ToString();
                        dtNoConformidades.Rows[pos]["Estado"] = ddl3.SelectedValue;
                }
               
            }
            gridNoConformidades.DataSource = dtNoConformidades;
            gridNoConformidades.DataBind();
            conservarEstado();
        }
    }
}
