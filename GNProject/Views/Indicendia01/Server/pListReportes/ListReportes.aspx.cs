using BusinessLogic.oEditReporteIncidente;
using BusinessLogic.oListReportes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersistenceInci;

namespace GNProject.Views.Indicendia01.Server.pListReportes
{
    public partial class ListReportes : System.Web.UI.Page
    {
        [WebMethod]
        public static List<RH_Area> Get_Localidad_List()
        {
            return controller_ListarReporte.Get_Instance().Get_Licalidad_List();
        }

        [WebMethod]
        public static ArrayList Get_Reportes_List_ADM(string Area_Id, DateTime FechaIni, DateTime FechaFin)
        {
            return controller_ListarReporte.Get_Instance().Get_Reportes_List_ADM(Area_Id, FechaIni, FechaFin);
        }


        //VALIDAR ACCIONES

        [WebMethod]
        public static ArrayList Get_AccionCorrectiva_List(string Incidente_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_AccionCorrectiva_List(Incidente_Id);
        }

        [WebMethod]
        public static string Get_Aprobrar_Accion(string Incidente_Id, string Accion_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_Aprobrar_Accion(Incidente_Id, Accion_Id);
        }

        [WebMethod]
        public static string Get_Desaprobrar_Accion(string Incidente_Id, string Accion_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_Desaprobrar_Accion(Incidente_Id, Accion_Id);
        }
        [WebMethod]
        public static string Get_Estado_Reporte(string Incidencia_Id)
        {
            return controller_EditReporteIncidente.Get_Instance().Get_Estado_Reporte(Incidencia_Id);
        }
    }
}