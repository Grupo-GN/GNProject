using BusinessLogic.oRepPendientes;
using PersistenceInci;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pRealizarAccionADM
{
    public partial class sRealizarAccionADM : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Acciones_Reporte(string Incidente_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_Acciones_Reporte(Incidente_Id);
        }

        [WebMethod]
        public static string Get_RealizarAccion(string Incidente_Id, string Accion_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_RealizarAccion(Incidente_Id, Accion_Id);
        }


        [WebMethod]
        public static string Get_Aprobar_Accion_ADM(string Incidente_Id, string Accion_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_Aprobar_Accion_ADM(Incidente_Id, Accion_Id);
        }

        [WebMethod]
        public static string Get_Desaprobar_Accion_ADM(string Incidente_Id, string Accion_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_Desaprobar_Accion_ADM(Incidente_Id, Accion_Id);
        }

        [WebMethod]
        public static List<File_Accion> Get_FilesAccion_List(string Incidente_Id, string Accion_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_FilesAccion_List(Incidente_Id, Accion_Id);
        }
    }
}