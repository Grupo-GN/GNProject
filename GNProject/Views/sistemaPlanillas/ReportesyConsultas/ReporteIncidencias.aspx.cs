using CAPA_DATOS;
using CAPA_DATOS.oFormulas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class ReporteIncidencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controller_RepGeneral.Get_Instance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controller_RepGeneral.Get_Instance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList ListaProyecto()
        {
            return controller_RepGeneral.Get_Instance().ListaProyecto();
        }
        [WebMethod]
        public static ArrayList ListarPersonal(string Periodo, string Localidad, string Area, string Proyecto)
        {
            return controller_ReporteIncidencias.getInstance().ListarPersonal(Periodo, Localidad, Area, Proyecto);
        }
        [WebMethod]
        public static ArrayList ListarReporteIncidenciasDatosFijos(string Periodo, string Localidad, string Area, string Proyecto, string Personal)
        {
            return controller_ReporteIncidencias.getInstance().ListarReporteIncidenciasDatosFijos(Periodo, Localidad, Area, Proyecto, Personal);
        }
    }
}