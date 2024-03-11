using BusinessLogic.oSendOsigermin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pSendOsigermin
{
    public partial class sSendOsigermin : System.Web.UI.Page
    {
        [WebMethod]
        public static List<string> Get_Datos_Osigermin(string Incidencia_Id)
        {
            return controller_SenOsigermin.Get_Instance().Get_Datos_Osigermin(Incidencia_Id);
        }

        [WebMethod]
        public static string Get_Enviar_Correo_Osigermin(string Incidencia_Id, string Tipo, string Asunto, string Comentario)
        {
            string servermath = "";
            if (Tipo == "01")
            {
                servermath = HttpContext.Current.Server.MapPath("../../ArchivosOsigermin/Preliminar/" + Incidencia_Id + "/");
            }
            else if (Tipo == "02")
            {
                servermath = HttpContext.Current.Server.MapPath("../../ArchivosOsigermin/Final/" + Incidencia_Id + "/");
            }
            return controller_SenOsigermin.Get_Instance().Get_Enviar_Correo_Osigermin(Incidencia_Id, Tipo, Asunto, Comentario, servermath);
        }
    }
}