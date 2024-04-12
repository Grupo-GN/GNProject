using CAPA_DATOS;
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
    public partial class FrmPlanillaGenDet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        [WebMethod]
        public static ArrayList ConfigFormulaGetConceptosByTipoList(string Tipo)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetConceptosByTipoList(Tipo);
        }

        [WebMethod]
        public static ArrayList ListaArea()
        {
            return ControllerMaestroPersonal.GetInstance().ListaArea();
        }

        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();
        }
    }
}