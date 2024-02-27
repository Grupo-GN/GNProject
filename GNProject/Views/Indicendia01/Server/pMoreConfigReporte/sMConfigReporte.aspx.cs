using BusinessLogic.oConfigReporte;
using PersistenceInci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pMoreConfigReporte
{
    public partial class sMConfigReporte : System.Web.UI.Page
    {
        #region CAUSAS DEL INCIDENTE
        [WebMethod]
        public static List<CausaIncidente> Get_Causas_Incidentes_List(string Name, string Tipo, string Estado, int inicio)
        {
            return controller_CofigReporte.Get_Instance().Get_Causas_Incidentes_List(Name, Tipo, Estado, inicio);
        }
        [WebMethod]
        public static int Get_Causas_Incidentes_MaxRows(string Name, string Tipo, string Estado)
        {
            return controller_CofigReporte.Get_Instance().Get_Causas_Incidentes_MaxRows(Name, Tipo, Estado);
        }
        [WebMethod]
        public static string Get_Causas_Add(string Causa_Name, string Descripcion, string Tipo, string Estado)
        {
            return controller_CofigReporte.Get_Instance().Get_Causas_Add(Causa_Name, Descripcion, Tipo, Estado);
        }
        [WebMethod]
        public static string Get_Causas_Update(string Causa_Id, string Causa_Name, string Descripcion, string Tipo, string Estado)
        {
            return controller_CofigReporte.Get_Instance().Get_Causas_Update(Causa_Id, Causa_Name, Descripcion, Tipo, Estado);
        }
        [WebMethod]
        public static string Get_Causas_Delete(string Causa_Id, string Estado)
        {
            return controller_CofigReporte.Get_Instance().Get_Causas_Delete(Causa_Id, Estado);
        }
        [WebMethod]
        public static CausaIncidente Get_Causa_Find(string Causa_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Causa_Find(Causa_Id);
        }
        #endregion

        #region TIPO DE INCIDENTE

        [WebMethod]
        public static List<TipoIncidente> Get_TipoIncidente_List()
        {
            return controller_CofigReporte.Get_Instance().Get_TipoIncidente_List();
        }
        [WebMethod]
        public static string Get_Add_TipoIncidente(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_TipoIncidente(Descripcion);
        }
        [WebMethod]
        public static string Get_Update_TipoIncidente(string TipoI_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_TipoIncidente(TipoI_Id, Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_TipoIncidente(string TipoI_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_TipoIncidente(TipoI_Id);
        }
        #endregion

        #region AFECTADO EN EL INCIDENTE

        [WebMethod]
        public static List<AfectadoInc> Get_AfectadoInc_List()
        {
            return controller_CofigReporte.Get_Instance().Get_AfectadoInc_List();
        }
        [WebMethod]
        public static string Get_Add_AfectadoInc(string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Add_AfectadoInc(Descripcion);
        }
        [WebMethod]
        public static string Get_Update_AfectadoInc(string Afec_Id, string Descripcion)
        {
            return controller_CofigReporte.Get_Instance().Get_Update_AfectadoInc(Afec_Id, Descripcion);
        }
        [WebMethod]
        public static string Get_Delete_AfectadoInc(string Afec_Id)
        {
            return controller_CofigReporte.Get_Instance().Get_Delete_AfectadoInc(Afec_Id);
        }
        #endregion
    }
}