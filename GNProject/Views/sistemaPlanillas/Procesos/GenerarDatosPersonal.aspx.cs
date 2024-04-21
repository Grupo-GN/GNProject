using CAPA_DATOS;
using CAPA_ENTIDAD.EntMs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class GenerarDatosPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //GET COLUMNAS FILTRO PERSONAL
        [WebMethod]
        public static ArrayList ListaColumnPersonal()
        {
            return ControllerMaestroPersonal.GetInstance().ListaColumnPersonal();
        }
        //GET PERSONAL X FILTRO
        //public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        //{
        //    return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio);
        //}
        [WebMethod]
        public static object Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        {
            //return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id,Periodo_Id,NomColumna,Param,inicio);
            Int32 qt_registros;
            List<ListaPersonal> oBandeja = ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }
        //GET  MAX ROWS
        [WebMethod]
        public static int Lista_Personal_x_Filtro_Columna_MaxRows(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        {
            return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
        }

        //ListarPersonal
        [WebMethod]
        public static List<ListaPersonal> Lista_Personal_x_GenerarDatos(string Compania_Id, string Periodo_Id, string NomColumna, string Param, string PersonalId)
        {
            return controllerGenerarDatosPersonal.getInstance().Lista_Personal_x_GenerarDatos(Compania_Id, Periodo_Id, NomColumna, Param, PersonalId);
        }

        /*
        [WebMethod]
        public static List<string> Inserta_D_Fijos_Genera(string Periodo_Id, string Personal_Id)
        {
            string[] codigos = Personal_Id.Split(',');
            return controllerGenerarDatosPersonal.getInstance().Inserta_D_Fijos_Genera(Periodo_Id, codigos);
        }
        [WebMethod]
        public static List<string> Inserta_D_Variables_Genera(string Periodo_Id, string Personal_Id)
        {
            string[] codigos = Personal_Id.Split(',');
            return controllerGenerarDatosPersonal.getInstance().Inserta_D_Variables_Genera(Periodo_Id, codigos);
        }
        [WebMethod]
        public static List<string> Inserta_D_Directos_Genera(string Periodo_Id, string Personal_Id)
        {
            string[] codigos = Personal_Id.Split(',');
            return controllerGenerarDatosPersonal.getInstance().Inserta_D_Directos_Genera(Periodo_Id, codigos);
        }
        */

        //Generar datos
        [WebMethod]
        public static String generaDatos(string Periodo_Id, string Personal_Ids
            , Boolean flGenDFijos, Boolean flGenDVariables, Boolean flGenDDirectos, Boolean flGenAcumulativos)
        {
            Int32 retorno; String msg_retorno;
            try
            {
                if (Personal_Ids == "all") { Personal_Ids = ""; }

                controllerGenerarDatosPersonal.getInstance().generaDatos_AllConceptos(Periodo_Id, Personal_Ids
                    , flGenDFijos, flGenDVariables, flGenDDirectos, flGenAcumulativos, out retorno, out msg_retorno);

                if (retorno > 0)
                {
                    //OK 
                }

                return msg_retorno;
            }
            catch (Exception ex)
            {
                msg_retorno = "Ocurrió un error al procesar: " + ex.Message;
                return msg_retorno;
            }
        }
    }
}