using BusinessLogic.oListReportes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Persistence;

namespace GNProject.Views.Indicendia01.Server.pListReportesPlanta
{
    public partial class sListReportesPlanta : System.Web.UI.Page
    {
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List()
        {
            return controller_ListarReporte.Get_Instance().Get_Licalidad_List();
        }

        [WebMethod]
        public static ArrayList Get_Reportes_List_PLANT(string Area_Id, string Per_Registro, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_ListarReporte.Get_Instance().Get_Reportes_List_PLANT(Area_Id, Per_Registro, FechaIni, FechaFin);
        }
    }
}