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
       * Modifica: Maneja los eventos a ocurrir cada vez que se carga la página
       * Retorna: N/A.
       */
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                estadoInicial();
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
            // Response.Write(proyectos);
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
            int idProyecto = Convert.ToInt32( DropDownProyecto.SelectedItem.Value);
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

        protected void llenarDDCasoPrueba()
        {
            this.DropDownCasoDePrueba.Items.Clear();
            DropDownCasoDePrueba.Items.Add(new ListItem("Seleccionar"));
            int idDiseno = Convert.ToInt32(DropDownDiseno.SelectedItem.Value);
            String casosPrueba = controladoraEjecucionPrueba.solicitarCasosdePrueba(idDiseno);
            String[] pr = casosPrueba.Split(';');
            foreach (String p1 in pr)
            {
                try
                {  
                    this.DropDownCasoDePrueba.Items.Add(new ListItem(p1));               
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
            if(DropDownProyecto.SelectedItem.Text != "Seleccionar")
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
                            Response.Write("lkjlkjlk"+a);
                            con.Close();
                        }
                    }
                }
                catch(Exception ex)
                {

                }
            }
        }

        protected void DropDownDiseno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownDiseno.SelectedItem.Text != "Seleccionar")
            {
                DatosEjecucion.Enabled = true;
                llenarDDCasoPrueba();
            }
            else
            {
                DatosEjecucion.Enabled = false;
            }
        }

        protected void DropDownCasoDePrueba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}