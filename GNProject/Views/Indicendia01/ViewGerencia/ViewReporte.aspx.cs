using BusinessLogic.oReporteIncidente;
using BusinessLogic.oViewReporte;
using PersistenceI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.ViewGerencia
{
    public partial class ViewReporte : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_Find_ReporteIncidente(Incidente_Id);
        }

        [WebMethod]
        public static ArrayList Get_AccionCorrectiva_List(string Incidente_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_AccionCorrectiva_List(Incidente_Id);
        }

        [WebMethod]
        public static List<File_Incidencia> Get_Files_Incidencia_List(string Incidente_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_Files_Incidencia_List(Incidente_Id);
        }

        [WebMethod]
        public static AccionCorrectiva Get_Find_AccionCorrectiva(string Incidente_Id, string Accion_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_Find_AccionCorrectiva(Incidente_Id, Accion_Id);
        }


        [WebMethod]
        public static List<Personal> Get_DataList_Responsable(string Nombres, string Usuario, string Area_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_DataList_Responsable(Nombres, Usuario, Area_Id);
        }

        [WebMethod]
        public static ArrayList Get_Reg_CausaReporte_Detalle_List(string Incidente_Id, string Tipo)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo);
        }
        //20190215
        [WebMethod]
        public static List<File_Accion> Get_Files_Accion_List(string Incidente_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_Files_Accion_List(Incidente_Id);
        }
    }
}