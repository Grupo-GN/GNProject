using BusinessLogic.oListReportes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pRepPendientes
{
    public partial class sRepPendientes : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Reportes_List_PEND(string Per_Registro)
        {
            return controller_ListarReporte.Get_Instance().Get_Reportes_List_PEND(Per_Registro);
        }
    }
}