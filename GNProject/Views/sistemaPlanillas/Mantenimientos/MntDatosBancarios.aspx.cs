using CAPA_DATOS;
using CAPA_ENTIDAD.EntMs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class MntDatosBancarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Inicializa();
            }
        }
        private void Inicializa()
        {
            ArrayList oComboArea = ControllerMaestroPersonal.GetInstance().ListaArea();
            ArrayList oComboProyecto = ControllerMaestroPersonal.GetInstance().ListaProyecto();
            ArrayList oComboCatAuxiliar = ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            String js = String.Format("fc_FillComboArray('cboLocalidad', {0}, '--TODOS--');", serializer.Serialize(oComboArea));
            js += String.Format("fc_FillComboArray('cboProyecto', {0}, '--TODOS--');", serializer.Serialize(oComboProyecto));
            js += String.Format("fc_FillComboArray('cboArea', {0}, '--TODOS--');", serializer.Serialize(oComboCatAuxiliar));
            this.fc_JavaScript(this.Page, js);
        }
        public void fc_JavaScript(Page c, String script, String strKey = "__Script__")
        {
            /*Dentro de un ScriptManager*/
            //script = script.Replace("\'", "\\'");
            //script = script.Replace("\r", "\\r");
            //script = script.Replace("\n", "\\n");
            String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, Script, false);
        }
        [WebMethod]
        public static object Lista_Personal_DatosBancarios(string Periodo_Id, string NPersonal, string Localidad, string Proyecto, string Area, int inicio)
        {
            //return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id,Periodo_Id,NomColumna,Param,inicio);
            Int32 qt_registros;
            List<ListaPersonal> oBandeja = controller_datosbancarios.getInstance().Lista_Personal_DatosBancarios(Periodo_Id, NPersonal, Localidad, Proyecto, Area, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }
        [WebMethod]
        public static object Lista_SelectsMantDatosBancarios()
        {
            List<ListaPersonal> oBandeja = controller_datosbancarios.getInstance().Lista_SelectsMantDatosBancarios();
            object response = new { oBandeja = oBandeja, qt_registros = 0 };
            return response;
        }
        [WebMethod]
        public static string GuardarDatosBancarios(string PersonalId, string TipoCta, string Banco, string Moneda, string NroCta, string NroCtaInter)
        {
            return controller_datosbancarios.getInstance().GuardarDatosBancarios(PersonalId, TipoCta, Banco, Moneda, NroCta, NroCtaInter);
        }
    }
}