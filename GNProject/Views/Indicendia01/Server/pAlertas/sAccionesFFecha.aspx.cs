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
    public partial class sAccionesFFecha : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList Get_Acciones_FFecha_ADM()
        {
            return controller_Alertas.Get_Instance().Get_Acciones_FFecha_ADM();
        }
        [WebMethod]
        public static ArrayList Get_Acciones_FFecha_PLANT(string Per_Registro)
        {
            return controller_Alertas.Get_Instance().Get_Acciones_FFecha_PLANT(Per_Registro);
        }
    }
}