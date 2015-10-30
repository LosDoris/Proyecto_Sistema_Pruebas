using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SistemaPruebas.Controladoras
{
    public class ControladoraRequerimiento
    {
        

        //ControladoraRequerimiento controladoraRequerimiento = new ControladoraRequerimiento();
        ControladoraBDRequerimiento controladoraBDRequerimiento = new ControladoraBDRequerimiento();
        ControladoraProyecto controladoraProyecto = new ControladoraProyecto();
        ControladoraRecursosHumanos controladoraRecursosHumanos = new ControladoraRecursosHumanos();

       

        /*
         * Requiere: El nombre de usuario y el estado de sesión abierta o cerrada que va a cambiarse.
         * Modifica: Se hace el cambio en el estado de loggeo para un usuario,
           llamando al método que modifica los datos dentro de la base de datos.
         * Retorna: booleano.
         */
        /*public bool estadoLoggeado(string nombre, string estado)
        {
            if (estado == "0")
                controladoraProyecto.LimpiarModificaciones(nombre);
            return true; controladoraBDRequerimiento.estadoLoggeado(nombre, estado);
        }*/


        /*
         * Requiere: N/A.
         * Modifica: Hace el llamado al método que accede a la base de datos para regresar
           la cédula de quien tiene sesión abierta actualmente.
         * Retorna: número.
         */
        public int idDelLoggeado()
        {
            return 0;// controladoraRequerimiento.idDelLoggeado(Account.Login.id_logeado);
        }

        /*
         * Requiere: N/A.
         * Modifica: Hace el llamado al método que accede a la base de datos para regresar
           el perfil de quien tiene sesión abierta actualmente.
         * Retorna: hilera.
         */
        public string perfilDelLoggeado()
        {
            return "";// controladoraRecursosHumanos.perfilDelLoggeado(Account.Login.id_logeado);
        }

        /*
         *Requiere:  N/A.
         *Modifica: Hace llamado a método que consulta si la persona loggeada
          es un administrador, según el sistema y los datos dentro de él, o no.
         *Retorna: booleano.
        */
        public bool loggeadoEsAdmin()
        {
            //controlREQ = new ControladoraRequerimiento();
            bool retorno;
            string perfil = this.perfilDelLoggeado();
            if (perfil == "Administrador")
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return retorno;

        }


        /**/

        /*
         *Requiere:  Número de cédula.
         *Modifica: Hace llamado al método que accede a la base de datos
          para hacer confirmación del uso del Recurso Humano.
          Regresa verdadero si está en uso o falso si no.
         *Retorna: booleano.
         */
        public bool ConsultarUsoREQ(int id)		
        {		
            return controladoraBDRequerimiento.ConsultarUsoREQ(id);		
        }

        /*
         *Requiere:  Número de cédula y el estado del Uso actual.
         *Modifica: Se encarga de hacer el llamado al método que accede a la
          base de datos para cambiar el uso asociado al número de cédula.
         *Retorna: entero.
         */
        public int UpdateUsoREQ(int id, int use)		
        {		
            return controladoraBDRequerimiento.UpdateUsoREQ(id, use);		
        }

        /**/

        /*
         * Requiere: Object[] datos
         * Modifica: Inserta un nuevo recurso humano en el sistema.
         * Retorna: int.
         */
        public int insertarRequerimiento(Object[] datos)
        {
            EntidadRequerimientos Requerimiento = new EntidadRequerimientos(datos);
            int ret = controladoraBDRequerimiento.insertarRequerimientoBD(Requerimiento);
            return ret;
        }

        /*
         * Requiere: Object[] datos
         * Modifica: Modifica un recurso humano en el sistema.
         * Retorna: int.
         */
        public int modificarRequerimiento(Object[] datos)
        {
            //datos[0];

            EntidadRequerimientos requerimiento = new EntidadRequerimientos(datos);
            int ret = controladoraBDRequerimiento.modificarRequerimientoBD(requerimiento);
            return ret;
        }
        /*
         * Requiere: Cédula
         * Modifica: Elimina un recurso humano del sistema.
         * Retorna: int.
         */
        public int eliminarRequerimiento(int cedula)
        {
            //datos[0];
            //EntidadRequerimientos Requerimiento = new EntidadRequerimientos(datos);
            int ret = controladoraBDRequerimiento.eliminarRequerimientoBD(cedula);
            return ret;
        }

        /*
         * Requiere: tipo de consulta y cédula.
         * Modifica: N/A.
         * Retorna: DataTable.
         */
        public DataTable consultarRequerimiento(int tipo, int cedula)
        {
            DataTable dt = controladoraBDRequerimiento.consultarRequerimientoBD(tipo, cedula);
            return dt;

        }

        /*
         * Requiere: N/A.
         * Modifica: N/A.
         * Retorna: String.
         */
        public String solicitarProyectos()
        {
            String proyectos = controladoraProyecto.Consultar_ID_Nombre_Proyecto();
            return proyectos;

        }

        /*
         * Requiere: N/A.
         * Modifica: N/A.
         * Retorna: String.
         */
        public String solicitarNombreProyecto(int id)
        {
            String proyecto = controladoraProyecto.ConsultarNombreProyectoPorId(id);
            return proyecto;
        }

    }
}