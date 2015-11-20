using System;
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

namespace SistemaPruebas.Intefaces
{
    public partial class InterfazEjecucion : System.Web.UI.Page
    {

        ControladoraEjecucionPrueba controladoraEjecucionPrueba = new ControladoraEjecucionPrueba();
        /*
         * Requiere: N/A
         * Modifica: Declara variable global de modo (tipo de operación en ejecución)
         * Retorna: entero.
         */
        public static int modo
        {
            get
            {
                object value = HttpContext.Current.Session["modo"];
                return value == null ? 0 : (int)value;
            }
            set
            {
                HttpContext.Current.Session["modo"] = value;
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
        public static List <Object []> listaNC
        {
            get
            {
                object value = HttpContext.Current.Session["listaNC"];
                return value == null ? null : (List<Object[]>) value;
            }
            set
            {
                HttpContext.Current.Session["listaNC"] = value;
            }
        }


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
                inicializarDTnoConformidades();
                gridNoConformidades.DataBind();
                
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


        /*
         * Requiere: N/A
         * Modifica: Establece el valor por defecto de la variable "modo" a 0.
         * Retorna: N/A
         */
        protected void inicializarModo()
        {
            modo = 0;
        }

        protected void estadoInicial()
        {
            DatosEjecucion.Enabled = false;
            llenarDDProyectoAdmin();
        }

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
            DropDownResponsable.Items.Add(new ListItem("Seleccionar"));
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

        protected void BotonEPInsertar_Click(object sender, EventArgs e)
        {

        }

        protected void Subir_Click(object sender, EventArgs e)
        {
            string strCon = "Data Source=RICARDO;Initial Catalog=PruebaInge;Integrated Security=True";
            if (FileUploadControl.HasFile)
            {
                try
                {
                    int length = FileUploadControl.PostedFile.ContentLength;
                    byte[] imgbyte = new byte[length];
                    HttpPostedFile img = FileUploadControl.PostedFile;
                    img.InputStream.Read(imgbyte, 0, length);
                    string base64String = Convert.ToBase64String(imgbyte, 0, imgbyte.Length);
                    ImagenResultado.ImageUrl = "data:image/png;base64," + base64String;
                    ImagenResultado.Visible = true;
                    String filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "insert into Image_Sample(imagename,imgdata) values(@Name,@Data)";
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@Data", imgbyte);
                            cmd.Connection = con;
                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            Response.Write("lkjlkjlk" + a);
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void DropDownDiseno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownDiseno.SelectedItem.Text != "Seleccionar")
            {
                DatosEjecucion.Enabled = true;
                llenarGridDisennos(DropDownDiseno.SelectedItem.Text.ToString());
            }
            else
            {
                DatosEjecucion.Enabled = false;
                
            }
            
        }

        protected void DropDownCasoDePrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridNoConformidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList dropDownCasos = (e.Row.FindControl("ddlIdCaso") as DropDownList);
                llenarDDCasoPrueba(ref dropDownCasos);

            }
        }

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
                drRow["Tipo"]          = String.Empty;
                drRow["IdCaso"]        = String.Empty;
                drRow["Descripcion"]   = String.Empty;
                drRow["Justificacion"] = String.Empty;
                drRow["Resultado"]     = String.Empty;
                drRow["Estado"]        = string.Empty;

                dt.Rows.Add(drRow);
                dtNoConformidades = dt;
                gridNoConformidades.DataSource = dtNoConformidades;
                //gridNoConformidades.DataBind();

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
                            DropDownList ddl1 = gridNoConformidades.Rows[indiceFila].FindControl("ddlTipo")          as DropDownList;
                            DropDownList ddl2 = gridNoConformidades.Rows[indiceFila].FindControl("ddlIdCaso")        as DropDownList;
                            TextBox      txt1 = gridNoConformidades.Rows[indiceFila].FindControl("txtDescripcion")   as TextBox;
                            TextBox      txt2 = gridNoConformidades.Rows[indiceFila].FindControl("txtJustificacion") as TextBox;
                            System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[indiceFila].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                            DropDownList ddl3 = gridNoConformidades.Rows[indiceFila].FindControl("ddlEstado")        as DropDownList;
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
                            DropDownList ddl1 = gridNoConformidades.Rows[indiceFila].FindControl("ddlTipo")     as DropDownList;
                            DropDownList ddl2 = gridNoConformidades.Rows[indiceFila].FindControl("ddlIdCaso")   as DropDownList;
                            TextBox txt1 = gridNoConformidades.Rows[indiceFila].FindControl("txtDescripcion")   as TextBox;
                            TextBox txt2 = gridNoConformidades.Rows[indiceFila].FindControl("txtJustificacion") as TextBox;
                            System.Web.UI.WebControls.Image imagenRes = gridNoConformidades.Rows[indiceFila].FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                            DropDownList ddl3 = gridNoConformidades.Rows[indiceFila].FindControl("ddlEstado")   as DropDownList;

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
                    //String filename = Path.GetFileName(FileUploadControl.PostedFile.FileName);
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

        protected void OnGridEjecucionPageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void OnGridEjecucionRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }

        protected void GridEjecucion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void llenarGridDisennos(string id_diseno)
        {
            DataTable ejecuciones = crearTablaGridEjecuciones();
            DataTable dt = controladoraEjecucionPrueba.consultarEjecucion(1, id_diseno);

            Object[] datos = new Object[4];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    datos[0] = dr[0];
                    datos[1] = dr[1];
                    datos[2] = dr[2];
                    datos[3] = dr[3];
                    ejecuciones.Rows.Add(datos);
                }
            }
            else
            {
                datos[0] = "-";
                datos[1] = "-";
                datos[2] = "-";
                datos[3] = "-";
                ejecuciones.Rows.Add(datos);
            }
            gridEjecucion.DataSource = ejecuciones;
            gridEjecucion.DataBind();
        }

        protected DataTable crearTablaGridEjecuciones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id Diseño", typeof(String));
            dt.Columns.Add("Responsable", typeof(String));
            dt.Columns.Add("Fecha", typeof(String));
            dt.Columns.Add("Estado", typeof(String));
            return dt;
        }

        protected void recuperarNoConformidades()
        {
            foreach(GridViewRow row in gridNoConformidades.Rows)
            {
                Object[] noConformidad = new Object[6];

                DropDownList ddl1 = row.FindControl("ddlTipo")           as DropDownList;
                DropDownList ddl2 = row.FindControl("ddlIdCaso")         as DropDownList;
                TextBox      txt1 = row.FindControl("txtDescripcion")    as TextBox;
                TextBox      txt2 = row.FindControl("txtJustificacion")  as TextBox;
                System.Web.UI.WebControls.Image imagenRes = row.FindControl("imagenSubida") as System.Web.UI.WebControls.Image;
                DropDownList ddl3 = row.FindControl("ddlEstado")         as DropDownList;

                noConformidad[0] = ddl1.SelectedItem.Text;
                noConformidad[1] = ddl2.SelectedItem.Text;
                noConformidad[2] = txt1.Text;
                noConformidad[3] = txt2.Text;
                noConformidad[4] = ddl2.SelectedItem.Text;
            }
        }


    }
}
