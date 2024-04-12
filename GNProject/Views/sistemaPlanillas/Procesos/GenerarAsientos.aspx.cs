using CAPA_DATOS;
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
    public partial class GenerarAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static ArrayList GetAsientosSelect(string xEjercicio, string xPlanilla)
        {
            return controller_GenerarAsientos.getInstance().GetAsientosSelect(xEjercicio, xPlanilla);
        }
        [WebMethod]
        public static ArrayList GetVerificarConceptosNoIncluidos(string xAsiento, string xEjercicio, string xPlanilla, string xPeriodo)
        {
            return controller_GenerarAsientos.getInstance().GetVerificarConceptosNoIncluidos(xAsiento, xEjercicio, xPlanilla, xPeriodo);
        }

        [WebMethod]
        public static string RegistrarAsientos(string xPeriodoId, string xAsientoId, string xCodTipoAsiento)
        {
            return controller_GenerarAsientos.getInstance().RegistrarAsientos(xPeriodoId, xAsientoId, xCodTipoAsiento);
        }
        //[WebMethod]
        //public static string RegistrarAsientosSap(string xPeriodoId)
        //{
        //    return controller_GenerarAsientos.getInstance().RegistrarAsientosSap(xPeriodoId);
        //}
        //[WebMethod]
        //public static string RegistrarAsientosStarSoft(string xPeriodoId)
        //{
        //    return controller_GenerarAsientos.getInstance().RegistrarAsientosStarSoft(xPeriodoId);
        //}
        //[WebMethod]
        //public static string RegistrarAsientosGeneral(string xPeriodoId, string xAsientoId)
        //{
        //    return controller_GenerarAsientos.getInstance().RegistrarAsientosGeneral(xPeriodoId, xAsientoId);
        //}
    }
}