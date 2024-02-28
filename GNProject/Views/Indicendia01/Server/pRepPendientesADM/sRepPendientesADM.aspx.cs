using BusinessLogic.oListReportes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;

namespace GNProject.Views.Indicendia01.Server.pRepPendientesADM
{
    public partial class sRepPendientesADM : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Reportes_List_PEND_ADM(string Area_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_ListarReporte.Get_Instance().Get_Reportes_List_PEND_ADM(Area_Id, FechaIni, FechaFin);
        }
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List()
        {
            return controller_ListarReporte.Get_Instance().Get_Licalidad_List();
        }

        [WebMethod]
        public static string Aprobar_Reporte_ADM(string Incidencia_Id)
        {
            return controller_ListarReporte.Get_Instance().Aprobar_Reporte_ADM(Incidencia_Id);
        }
    }
}