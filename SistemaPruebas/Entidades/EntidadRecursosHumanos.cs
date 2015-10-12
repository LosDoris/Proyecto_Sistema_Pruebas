using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPruebas.Controladoras
{

    public class EntidadRecursosHumanos
    {
        private int cedula;
        private String nombre_completo;
        private String tel1;
        private String tel2;
        private String correo_electronico;
        private String usuario;
        private String clave;
        private String perfilAcceso;
        private String proyAsociado;
        private String rol;



        public EntidadRecursosHumanos(Object[] datos)
        {
            this.cedula = Convert.ToInt32(datos[0].ToString());
            this.nombre_completo = datos[1].ToString();
            this.tel1 = datos[2].ToString();
            this.tel2 = datos[3].ToString();
            this.correo_electronico = datos[4].ToString();
            this.usuario = datos[5].ToString();
            this.clave = datos[6].ToString();
            this.perfilAcceso = datos[7].ToString();
            this.proyAsociado = datos[8].ToString();
            this.rol = datos[9].ToString();
        }

        public int Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }



        public String Nombre_Completo
        {
            get { return nombre_completo; }
            set { nombre_completo = value; }
        }

        public String Tel1
        {
            get { return tel1; }
            set { tel1 = value; }
        }
        public String Tel2
        {
            get { return tel2; }
            set { tel2 = value; }
        }

        public String Correo
        {
            get { return correo_electronico; }
            set { correo_electronico = value; }
        }

        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public String Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public String PerfilAcceso
        {
            get { return perfilAcceso; }
            set { perfilAcceso = value; }
        }
        public String ProyAsociado
        {
            get { return proyAsociado; }
            set { proyAsociado = value; }
        }
        public String Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }


}