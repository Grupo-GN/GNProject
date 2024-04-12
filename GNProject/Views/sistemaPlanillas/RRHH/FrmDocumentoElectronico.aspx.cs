using CAPA_DATOS.oRRHH;
using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.RRHH
{
    public partial class FrmDocumentoElectronico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static object Get_Combos()
        {
            return controllerDocumentoElectronico.getinstance().Get_Combos();
        }
        [WebMethod]
        public static object Get_Periodo(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_Periodo(strParametros);
        }

        [WebMethod]
        public static object Get_Periodo_Desde(object strParametros)
        {
            Dictionary<string, object> prms = (Dictionary<string, object>)strParametros;

            String Periodo_Id_Selected = prms["co_periodo_selected"].ToString();

            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = prms["co_cia"].ToString();
            objEPeriodo.Ejercicio_Id = prms["co_ejercicio"].ToString();
            objEPeriodo.Planilla_Id = prms["co_planilla"].ToString();
            objEPeriodo.Mes_Id = "";
            objEPeriodo.Estado_Id = "02";
            DataTable dtPeriodos = Log_Periodo.Lista_Periodo(objEPeriodo);

            DataRow[] drowFind = dtPeriodos.Select("Periodo_Id = " + Periodo_Id_Selected);
            Int32 inx_Selected_fin = dtPeriodos.Rows.IndexOf(drowFind[0]);
            Int32 inx_inicio = inx_Selected_fin - 11; //Para que muestre los últimos 11 periodos

            //Int32 qt_periodos = dtPeriodos.Rows.Count;
            //Int32 index_inicio = qt_periodos - 12; //Para que muestre los últimos 11 periodos
            ArrayList oLista_Periodos = new ArrayList();

            Int32 index = 0;
            foreach (DataRow row in dtPeriodos.Rows)
            {
                //if (Convert.ToInt32(row["Periodo_Id"].ToString()) >= Convert.ToInt32(Periodo_Id_Selected))
                //{
                //    break;
                //}

                //if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= index_inicio)
                if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= inx_inicio && index <= inx_Selected_fin)
                {
                    var xitem = new { value = row["Periodo_Id"].ToString(), nombre = row["Descripcion"].ToString() };
                    oLista_Periodos.Add(xitem);
                }

                index++;
            }

            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(oLista_Periodos);
            return serializedResult;
        }

        [WebMethod]
        public static object Get_CatAuxiliar2(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_CatAuxiliar2(strParametros);
        }

        [WebMethod]
        public static object Get_Personal(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_Personal(strParametros);
        }
        [WebMethod]
        public static object Get_GrillaPersonal(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_GrillaPersonal(strParametros);
        }
        [WebMethod]
        public static object Get_GrillaHistorialEnvio(object strParametros)
        {
            return controllerDocumentoElectronico.getinstance().Get_GrillaHistorialEnvio(strParametros);
        }

        [WebMethod]
        public static string Get_ImprimeBoleta(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeBoleta(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeBoleta_HTML(strParametros, encryptRUC);
        }
        [WebMethod]
        public static string Get_ImprimeCTS(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeCTS(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeCTS_HTML(strParametros, encryptRUC);
        }
        [WebMethod]
        public static string Get_ImprimeUtilidad(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeUtilidad(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeUtilidad_HTML(strParametros, encryptRUC);
        }
        [WebMethod]
        public static string Get_ImprimeQuinta(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeQuinta(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeQuinta_HTML(strParametros, encryptRUC);
        }
        // bancocts
        [WebMethod]
        public static string Get_ImprimeBancoCTS(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeBancoCTS(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeBancoCTS_HTML(strParametros, encryptRUC);
        }
        // certificado de trabajo

        [WebMethod]
        public static string Get_ImprimeCertTrabajo(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            //return controllerDocumentoElectronico.getinstance().Get_ImprimeCertTrabajo(strParametros, encryptRUC);
            return controllerDocumentoElectronico.getinstance().Get_ImprimeCertTrabajo_HTML(strParametros, encryptRUC);
        }
        // liquidacion 2
        [WebMethod]
        public static string Get_ImprimeLiquida2(object strParametros)
        {
            String encryptRUC = Encryptar.Encripta(ClaseGlobal.getRUCEmpresa());
            return controllerDocumentoElectronico.getinstance().Get_ImprimeLiquida2(strParametros, encryptRUC);
        }
    }
}