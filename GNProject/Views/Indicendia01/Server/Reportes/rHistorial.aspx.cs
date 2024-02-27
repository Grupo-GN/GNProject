using BusinessLogic.oReportes;
using BusinessLogic.oSendEmail;
using PersistenceInci;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.Reportes
{
    public partial class rHistorial : System.Web.UI.Page
    {
        [WebMethod]
        public static ArrayList GENERAR_REPORTE_HISTORIAL_MULTIPLE_WPP(string select, string joins, string where)
        {
            return controller_HistorialMultiple.Get_Instance().GENERAR_REPORTE_HISTORIAL_MULTIPLE_WPP(select, joins, where);
        }

        [WebMethod]
        public static string SendMail_SMTP(string emailDestino, string Asunto, string HTMLcont)
        {
            return controller_SendEmail.Get_Instance().SendMail_SMTP(emailDestino, Asunto, HTMLcont);
        }

        #region FILTROS

        [WebMethod]
        public static List<RH_Area> Get_Localidad()
        {
            return controller_Filtros.Get_Instance().Get_Localidad();
        }

        [WebMethod]
        public static List<Categoria_Auxiliar> Get_Categoria_Auxiliar()
        {
            return controller_Filtros.Get_Instance().Get_Categoria_Auxiliar();
        }

        [WebMethod]
        public static List<Categoria_Auxiliar2> Get_Categoria_Auxiliar2(string Cate1)
        {
            return controller_Filtros.Get_Instance().Get_Categoria_Auxiliar2(Cate1);
        }
        [WebMethod]
        public static List<Intensidad> Get_Intensidad()
        {
            return controller_Filtros.Get_Instance().Get_Intensidad();
        }
        [WebMethod]
        public static List<Severidad> Get_Severidad()
        {
            return controller_Filtros.Get_Instance().Get_Severidad();
        }

        [WebMethod]
        public static List<Tipo> Get_Tipo()
        {
            return controller_Filtros.Get_Instance().Get_Tipo();
        }

        [WebMethod]
        public static List<Origen> Get_Origen()
        {
            return controller_Filtros.Get_Instance().Get_Origen();
        }

        #endregion
    }
}