using BusinessLogic.oAlertas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pAlertas
{
    public partial class sAlertOsigermin : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Reportes_Osigermin_ADM()
        {
            return controller_Alertas.Get_Instance().Get_Reportes_Osigermin_ADM();
        }
    }
}