using CAPA_DATOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmAsignarcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<PersonalCentro> ListaPersonalCentroCosto(string PeriodoId, string LocalidadId, string ProyectoId, string AreaId, int inicio)
        {
            return controllerAsignarCentroCosto.getInstance().ListaPersonalCentroCosto(PeriodoId, LocalidadId, ProyectoId, AreaId, inicio);
        }
        [WebMethod]
        public static int ListaPersonalCentroCosto_MaxRows(string PeriodoId, string LocalidadId, string ProyectoId, string AreaId, int inicio)
        {
            return controllerAsignarCentroCosto.getInstance().ListaPersonalCentroCosto_MaxRows(PeriodoId, LocalidadId, ProyectoId, AreaId, inicio);
        }
        [WebMethod]
        public static List<PersonalCentro> FindPersonalCentroCosto(string PeriodoId, string PersonalId)
        {
            return controllerAsignarCentroCosto.getInstance().FindPersonalCentroCosto(PeriodoId, PersonalId);
        }
        [WebMethod]
        public static ArrayList ListaLocalidad()
        {
            return controllerAsignarCentroCosto.getInstance().ListaLocalidad();
        }
        [WebMethod]
        public static ArrayList ListaProyecto()
        {
            return controllerAsignarCentroCosto.getInstance().ListaProyecto();
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controllerAsignarCentroCosto.getInstance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCentroCosto(string PeriodoId, string PersonalId)
        {
            return controllerAsignarCentroCosto.getInstance().ListaCentroCosto(PeriodoId, PersonalId);
        }
        [WebMethod]
        public static string ActualizarPersonalCentroCosto(List<PersonalCentroPrm> datos)
        {
            return controllerAsignarCentroCosto.getInstance().ActualizarPersonalCentroCosto(datos);
        }
    }
}