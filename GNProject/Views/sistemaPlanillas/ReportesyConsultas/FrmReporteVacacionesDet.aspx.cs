using CAPA_DATOS.oFormulas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmReporteVacacionesDet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static ArrayList ListaPlanilla()
        {
            return controller_RepGeneral.Get_Instance().ListaPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controller_RepGeneral.Get_Instance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controller_RepGeneral.Get_Instance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList getPersonal(String Planilla_Ids, String Area_Ids, String CatAuxiliar_Id, String Estado_Id)
        {
            //return controller_RepGeneral.Get_Instance().ListaPersonalActivoReporteGeneral(PlanillaId, PeriodoIni, PeriodoFin);
            String xml_parametros = String.Format("<prm Planilla_Ids='{0}' Area_Ids='{1}' CatAuxiliar_Id='{2}' Estado_Id='{3}' />", Planilla_Ids, Area_Ids, CatAuxiliar_Id, Estado_Id);
            return controller_RepGeneral.Get_Instance().getCombo("PERSONAL_ULT_PERIODO", xml_parametros);
        }
    }
}