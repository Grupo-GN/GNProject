using BusinessLogic.oRepPendientes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pRealizarAccion
{
    public partial class sRealizarAccion : System.Web.UI.Page
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
    }
}