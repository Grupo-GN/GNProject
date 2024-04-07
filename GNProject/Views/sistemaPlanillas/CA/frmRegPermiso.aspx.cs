using CAPA_DATOS.oCA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.CA
{
    public partial class frmRegPermiso : System.Web.UI.Page
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
            ArrayList oComboArea = CAPA_DATOS.ControllerMaestroPersonal.GetInstance().ListaArea();
            ArrayList oComboCatAuxiliar = CAPA_DATOS.ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();
            ArrayList oComboProyecto = CAPA_DATOS.ControllerMaestroPersonal.GetInstance().ListaProyecto();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            String js = String.Format("fc_FillComboArray('cboLocalidad1', {0}, '--TODOS--');", serializer.Serialize(oComboArea));
            js += String.Format("fc_FillComboArray('cboArea1', {0}, '--TODOS--');", serializer.Serialize(oComboCatAuxiliar));
            js += String.Format("fc_FillComboArray('cboProyecto1', {0}, '--TODOS--');", serializer.Serialize(oComboProyecto));
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
        public static ArrayList ListaArea()
        {
            return CAPA_DATOS.ControllerMaestroPersonal.GetInstance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return CAPA_DATOS.ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList ListarPersonalPermisosPlanilla(string xperiodo, string xlocalidad, string xcategoria, string xproyecto)
        {
            return controllerPermisos.getInstance().ListarPersonalPermisosPlanilla(xperiodo, xlocalidad, xcategoria, xproyecto);
        }
        [WebMethod]
        public static ArrayList GetFechaPorPeriodo(string xperiodo)
        {
            return controllerPermisos.getInstance().GetFechaPorPeriodo(xperiodo);
        }
        [WebMethod]
        public static ArrayList Get_Permisos_Fecha_By_Personal(string Planilla_Id, string Personal_Id, DateTime FechaIni, DateTime FechaFin, string PeriodoId, string LocalidadId, string AreaId, string ProyectoId)
        {
            return controllerPermisos.getInstance().Get_Permisos_Fecha_By_Personal(Planilla_Id, Personal_Id, FechaIni, FechaFin, PeriodoId, LocalidadId, AreaId, ProyectoId);
        }
        [WebMethod]
        public static ArrayList Get_Tipo_Permisos()
        {
            return controllerPermisos.getInstance().Get_Tipo_Permisos();
        }

        [WebMethod]
        public static string Get_AM_Permisos_Fechas(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif, string PeriodoId)
        {
            //return controllerPermisos.getInstance().Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif);
            return controllerPermisos.getInstance().ProcesarRegistroPermisos(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif, PeriodoId);
        }

        [WebMethod]
        public static ArrayList Get_Permiso_Fechas_Find(int PermisoD_Id)
        {
            return controllerPermisos.getInstance().Get_Permiso_Fechas_Find(PermisoD_Id);
        }

        [WebMethod]
        public static string Get_Cancelar_SolicitudPermisoDias(int PermisoD_Id, string PersoModif, string PeriodoId, string Personal_ID)
        {
            return controllerPermisos.getInstance().Get_Cancelar_SolicitudPermisoDias(PermisoD_Id, PersoModif, PeriodoId, Personal_ID);
        }
    }
}