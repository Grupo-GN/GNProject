using CAPA_DATOS.oCA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.PermisosSubisdio
{
    public partial class MPermiso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                this.Inicializa();
            }
        }
        private void Inicializa()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ArrayList oComboDVariables = controllerMantPermisos.getInstance().ListarDatosVariables();
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            String js = String.Format("fc_FillComboArray('cboConcepto', {0}, '--SELECCIONE--');", serializer.Serialize(oComboDVariables));
            this.fc_JavaScript(this.Page, js);
        }
        public void fc_JavaScript(Page c, String script, String strKey = "__Script__")
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            /*Dentro de un ScriptManager*/
            //script = script.Replace("\'", "\\'");
            //script = script.Replace("\r", "\\r");
            //script = script.Replace("\n", "\\n");
            String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, Script, false);
        }
        [WebMethod]
        public static object Get_Permiso_MS_Listar(string descripcion, int inicio)
        {
            Int32 qt_registros;
            List<CAPA_ENTIDAD.EntMs.Permisos> oBandeja = controllerMantPermisos.getInstance().Get_Permiso_MS_Listar(descripcion, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }
        [WebMethod]
        public static string Get_Permiso_MS_Mantenimiento(int tipoProceso, int Permiso_Id, string descripcion, string fechaAcumulado, int ejecutaAcumulado, string ConceptoId)
        {
            return controllerMantPermisos.getInstance().Get_Permiso_MS_Mantenimiento(tipoProceso, Permiso_Id, descripcion, fechaAcumulado, ejecutaAcumulado, ConceptoId);
        }
        [WebMethod]
        public static ArrayList Get_Permiso_MS_Buscar(int Permiso_Id)
        {
            return controllerMantPermisos.getInstance().Get_Permiso_MS_Buscar(Permiso_Id);
        }
    }
}