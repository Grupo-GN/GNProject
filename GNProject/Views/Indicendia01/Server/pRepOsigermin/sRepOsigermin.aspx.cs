using BusinessLogic.oViewReporte;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;

namespace GNProject.Views.Indicendia01.Server.pRepOsigermin
{
    public partial class sRepOsigermin : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Find_ReporteIncidente(string Incidente_Id)
        {
            return controller_ViewReporte.Get_Instance().Get_Find_ReporteIncidente(Incidente_Id);
        }
    }
}