using CAPA_DATOS;
using CAPA_LOGICO;
using GNProject.Assets.ctrlDoc.resources;
using GNProject.Views.sistemaPlanillas.code;
using Microsoft.Reporting.WebForms;
using OfficeOpenXml;
using OfficeOpenXml.Table.PivotTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GNProject.Assets.ctrlDoc.resources.ReportPrintHelper;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class FrmPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["fl_Print"] == null)
                {
                    string reporte_Id = Request.QueryString["Reporte_Id"].ToString();

                    string personal_Id, periodo_Id, proceso_Id;
                    ReportDataSource rptsource;

                    string usuario_Id;
                    //////string rutaLogoEmpresa, razonSocialEmpresa, RUCEmpresa;
                    //////rutaLogoEmpresa = "";
                    //////razonSocialEmpresa = "LIMA GAS SA";
                    //////RUCEmpresa = "20100007348";

                    String str_parametros = String.Empty;
                    String[] arr_parametros = null;
                    switch (reporte_Id)
                    {
                        case "REP_PLANILLA_GENERAL": /*Reporte de Planilla General*/
                            //personal_Id = Request.QueryString["personal_Id"].ToString();

                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPlanillaGeneral.rdlc";

                            code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaIngresoUnid = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaIngresoUnid);
                            SetAllCommandTimeouts(tablaIngresoUnid, 120); //120 seg = 2 min
                            dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneral =
                                tablaIngresoUnid.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                            //oParam = new ReportParameter("prmFecDesde", arr_parametros[3].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);
                            //oParam = new ReportParameter("prmFecHasta", arr_parametros[4].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtReportePlanillaGeneral", datosReportePlanillaGeneral.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_PLANILLA_COMPLETA_RESUMEN":

                            List<string> sheetNames = new List<string>
                        {
                            "Planilla Empleados",
                            "Planilla Obreros",
                            "Planilla Unificada",
                            "DETALLE PLAME Y AFPNET SEMANAL",
                            "DETALLE PLAME Y AFPNET MENSUAL"
                        };
                            string path1 = HttpContext.Current.Server.MapPath("~/Views/sistemaPlanillas/Reportes/Report1.xlsx");
                            string path2 = HttpContext.Current.Server.MapPath("~/Views/sistemaPlanillas/Reportes/Report2.xlsx");
                            string path3 = HttpContext.Current.Server.MapPath("~/Views/sistemaPlanillas/Reportes/Report3.xlsx");
                            string path4 = HttpContext.Current.Server.MapPath("~/Views/sistemaPlanillas/Reportes/Report4.xlsx");
                            string path5 = HttpContext.Current.Server.MapPath("~/Views/sistemaPlanillas/Reportes/Report5.xlsx");
                            // Generate each report
                            GenerateExcelReport("Views/sistemaPlanillas/Reportes/rptPlanillaGeneralDetalle.rdlc", "dtReportePlanillaGeneral", path1, "01");
                            GenerateExcelReport("Views/sistemaPlanillas/Reportes/rptPlanillaGeneralDetalle.rdlc", "dtReportePlanillaGeneral", path2, "02");
                            GenerateExcelReport("Views/sistemaPlanillas/Reportes/rptPlanillaGeneralUnificada.rdlc", "dtReportePlanillaGeneral", path3, "00");
                            GenerateExcelReport("Views/sistemaPlanillas/Reportes/rptPlanillaGeneralUnificada.rdlc", "dtReportePlanillaGeneral", path4, "03");
                            GenerateExcelReport("Views/sistemaPlanillas/Reportes/rptPlanillaPlameAFPMensual.rdlc", "dtReportePlanillaGeneral", path5, "04");
                            // Combine Excel files into one
                            CombineExcelFilesAndDownload(new List<string> { path1, path2, path3, path4, path5 }, sheetNames, "CombinedReports.xlsx");

                            break;

                        case "REP_PLANILLA_GENERAL_DETALLE": /*Reporte de Planilla General*/
                            //personal_Id = Request.QueryString["personal_Id"].ToString();

                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPlanillaGeneralDetalle.rdlc";

                            code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet);
                            SetAllCommandTimeouts(tablaPlanillaDet, 120); //120 seg = 2 min
                            dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet =
                                tablaPlanillaDet.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                            //oParam = new ReportParameter("prmFecDesde", arr_parametros[3].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);
                            //oParam = new ReportParameter("prmFecHasta", arr_parametros[4].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtReportePlanillaGeneral", datosReportePlanillaGeneralDet.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        case "REP_PLANILLA_GENERAL_CENTROS": /*Reporte de Planilla General*/
                            //personal_Id = Request.QueryString["personal_Id"].ToString();

                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPlanillaGeneralCentros.rdlc";

                            code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneral_CentrosTableAdapter tablaIngresoUnid_cc = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneral_CentrosTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaIngresoUnid_cc);
                            dsReportePlanillaGeneral.dtReportePlanillaGeneral_CentrosDataTable datosReportePlanillaGeneral_cc =
                                tablaIngresoUnid_cc.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10]);

                            rptsource = new ReportDataSource("dtReportePlanillaGeneralCentros", datosReportePlanillaGeneral_cc.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_ASIENTOCONTABLE_CONCARSQL_CAB": /*Reporte de Planilla General*/
                            //personal_Id = Request.QueryString["personal_Id"].ToString();

                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsientoContableCab_ConcarSql.rdlc";

                            code.dsAsientoContableCab_ConcarSqlTableAdapters.dtAsientoContableCab_ConcarSqlTableAdapter tablaAsientoContableCab_ConcarSql = new code.dsAsientoContableCab_ConcarSqlTableAdapters.dtAsientoContableCab_ConcarSqlTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaAsientoContableCab_ConcarSql);
                            dsAsientoContableCab_ConcarSql.dtAsientoContableCab_ConcarSqlDataTable datosAsientoContableCab_ConcarSql =
                                tablaAsientoContableCab_ConcarSql.GetData(arr_parametros[0], arr_parametros[1]);

                            //oParam = new ReportParameter("prmFecDesde", arr_parametros[3].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);
                            //oParam = new ReportParameter("prmFecHasta", arr_parametros[4].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtAsientoContableCab_ConcarSql", datosAsientoContableCab_ConcarSql.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_ASIENTOCONTABLE_CONCARSQL_DET": /*Reporte de Planilla General*/
                            //personal_Id = Request.QueryString["personal_Id"].ToString();

                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsientoContableDet_ConcarSql.rdlc";

                            code.dsAsientoContableDet_ConcarSqlTableAdapters.dtAsientoContableDet_ConcarSqlTableAdapter tablaAsientoContableDet_ConcarSql = new code.dsAsientoContableDet_ConcarSqlTableAdapters.dtAsientoContableDet_ConcarSqlTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaAsientoContableDet_ConcarSql);
                            dsAsientoContableDet_ConcarSql.dtAsientoContableDet_ConcarSqlDataTable datosAsientoContableDet_ConcarSql =
                                tablaAsientoContableDet_ConcarSql.GetData(arr_parametros[0], arr_parametros[1]);

                            //oParam = new ReportParameter("prmFecDesde", arr_parametros[3].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);
                            //oParam = new ReportParameter("prmFecHasta", arr_parametros[4].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtAsientoContableDet_ConcarSql", datosAsientoContableDet_ConcarSql.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "1":
                        case "1_Disenio":
                        case "1_Disenio_AYN": /*Reporte de Boletas de Pago*/
                            personal_Id = Request.QueryString["personal_Id"].ToString();
                            periodo_Id = Request.QueryString["periodo_Id"].ToString();
                            proceso_Id = Request.QueryString["proceso_Id"].ToString();
                            String personal_Id_Masivo = (String)Session["Personal_Id_Masivo"];
                            String Periodo_Id_Desde = (Request.QueryString["Periodo_Id_Desde"] == null ? "" : Request.QueryString["Periodo_Id_Desde"].ToString());
                            String fl_dolares = (Request.QueryString["fl_dolares"] == null ? "" : Request.QueryString["fl_dolares"].ToString());
                            String fl_add_tot_usd = (Request.QueryString["fl_add_tot_usd"] == null ? "" : Request.QueryString["fl_add_tot_usd"].ToString());

                            DataTable dtBoletaPago = new DataTable();
                            //dtBoletaPago = Log_Reportes.Lista_Boleta_Pago(personal_Id, periodo_Id, proceso_Id);
                            Int32 cantPersonal = 0; String ordenid = ""; //no se usa en el SP

                            String fl_por_personal_periodo;
                            if (Session["flPorPersonal"] != null && Session["flPorPersonal"].ToString() == "1") { personal_Id_Masivo = personal_Id; fl_por_personal_periodo = "1"; }
                            else { fl_por_personal_periodo = "0"; }
                            dtBoletaPago = Log_Reportes.Lista_Boleta_Pago_Masivo(personal_Id_Masivo, periodo_Id, proceso_Id, cantPersonal, ordenid, Periodo_Id_Desde, fl_dolares, fl_por_personal_periodo);

                            if (Session["flPorPersonal"] != null && dtBoletaPago.Rows.Count > 0)
                            {
                                Session["NombreBoleta_" + personal_Id] = dtBoletaPago.Rows[0]["Nombre_Completo"].ToString();
                            }

                            if (reporte_Id == "1_Disenio")
                            {
                                string planilla_id = proceso_Id = Request.QueryString["planilla_Id"].ToString();
                                if (planilla_id == "02") //Obrero
                                {
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago_Disenio_Obrero.rdlc");
                                }
                                else
                                {
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago_Disenio.rdlc");
                                }
                            }
                            else if (reporte_Id == "1_Disenio_AYN")
                            {
                                string planilla_id = proceso_Id = Request.QueryString["planilla_Id"].ToString();
                                if (planilla_id == "02") //Obrero
                                {
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago_Disenio_AYN_obrero.rdlc");
                                }
                                else
                                {
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago_Disenio_AYN.rdlc");
                                }
                            }
                            else { ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago.rdlc"); }

                            String simboloMoneda = "S/";
                            if (fl_dolares == "1") { simboloMoneda = "$"; }

                            ReportParameter oParam = new ReportParameter("prmSimboloMoneda", simboloMoneda);
                            ReportViewer1.LocalReport.SetParameters(oParam);

                            ReportParameter oParam2 = new ReportParameter("prmAddTotUSD", fl_add_tot_usd);
                            ReportViewer1.LocalReport.SetParameters(oParam2);

                            //ReportDataSource rptsource = new ReportDataSource("dsBoletaPago_BoletaPago", dtBoletaPago);
                            rptsource = new ReportDataSource("dsBoletaPago_BoletaPago", dtBoletaPago);
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        case "0039": /*Reporte de CARTA CTS A BANCO*/
                            personal_Id = Request.QueryString["personal_Id"].ToString();
                            periodo_Id = Request.QueryString["periodo_Id"].ToString();
                            proceso_Id = Request.QueryString["proceso_Id"].ToString();
                            usuario_Id = "";
                            DataTable dtCartaCTSBanco = new DataTable();
                            dtCartaCTSBanco = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptCartaCTSBanco.rdlc");
                            rptsource = new ReportDataSource("dsCartaCTSBanco_CartaCTSBanco", dtCartaCTSBanco);
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "cuentasval":
                            periodo_Id = Request.QueryString["p1"].ToString();
                            code.dsasienoscuentasTableAdapters.dtcuentasvalidarTableAdapter tblp = new code.dsasienoscuentasTableAdapters.dtcuentasvalidarTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tblp);
                            dsasienoscuentas.dtcuentasvalidarDataTable data = tblp.GetData(periodo_Id);
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptcuentasfindconceptos.rdlc");
                            rptsource = new ReportDataSource("DataSet1", data.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_PLANILLA_GENERAL_RESUMEN":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPlanillaResumen.rdlc";

                            code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaresumen = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaresumen);
                            SetAllCommandTimeouts(tablaresumen, 120); //120 seg = 2 min
                            dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReporteResumen =
                                tablaresumen.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                            rptsource = new ReportDataSource("dtReportePlanillaGeneral", datosReporteResumen.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_PLANILLA_GENERAL_COMPARATIVO":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPlanillaComparativo.rdlc";

                            code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablacompara = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablacompara);
                            dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReporteCompara =
                                tablacompara.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                            rptsource = new ReportDataSource("dtReportePlanillaGeneral", datosReporteCompara.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_VACACIONES_DETALLADO":
                            //str_parametros = Request.QueryString["prm"].ToString();
                            str_parametros = Request.Form["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptVacacionesDet.rdlc";

                            code.dsReporteVacacionesDetTableAdapters.dtReporteVacacionesDetTableAdapter tabla = new code.dsReporteVacacionesDetTableAdapters.dtReporteVacacionesDetTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla);
                            dsReporteVacacionesDet.dtReporteVacacionesDetDataTable datos =
                                tabla.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5]);

                            rptsource = new ReportDataSource("dtReporteVacacionesDet", datos.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_EXCEL_GEN":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptGenExcel.rdlc";

                            code.dsGenExcelTableAdapters.uspGenerarPlanillaExcelTableAdapter tablexcel = new code.dsGenExcelTableAdapters.uspGenerarPlanillaExcelTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablexcel);
                            dsGenExcel.uspGenerarPlanillaExcelDataTable tablaexcel2 = tablexcel.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7]);

                            rptsource = new ReportDataSource("dsdatos", tablaexcel2.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_EXCEL_GEN_ACUM":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptGenExcelAcum.rdlc";

                            code.dsGenExcelTableAdapters.uspGenerarPlanillaExcel_AcumuladosTableAdapter tablexcel_acum = new code.dsGenExcelTableAdapters.uspGenerarPlanillaExcel_AcumuladosTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablexcel_acum);
                            dsGenExcel.uspGenerarPlanillaExcel_AcumuladosDataTable tablaexcel2_acum = tablexcel_acum.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4]);

                            rptsource = new ReportDataSource("dsdatos", tablaexcel2_acum.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_CTAS_CTES":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptCtasCtes.rdlc";

                            code.dsReporteCtasCtesTableAdapters.dtReporteCtasCtesTableAdapter tabla_ctacte = new code.dsReporteCtasCtesTableAdapters.dtReporteCtasCtesTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla_ctacte);
                            dsReporteCtasCtes.dtReporteCtasCtesDataTable datos_ctacte =
                                tabla_ctacte.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6]);

                            rptsource = new ReportDataSource("dtReporteCtasCtes", datos_ctacte.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        //20180715
                        case "REPDATAIMPORTPERSONAL":

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/RepDatosImporPersonal.rdlc";

                            code.dsGenExcelTableAdapters.uspListarDatosParaImportPersonalTableAdapter tablinfo = new code.dsGenExcelTableAdapters.uspListarDatosParaImportPersonalTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablinfo);
                            dsGenExcel.uspListarDatosParaImportPersonalDataTable tablinfo2 = tablinfo.GetData();

                            rptsource = new ReportDataSource("DataSet1", tablinfo2.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        //20180715
                        case "REPDATAEXPORTPERSONAL":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptPersonalExport.rdlc";

                            code.dsGenExcelTableAdapters.usp_ListarPersonalToExportTableAdapter tapexportp = new code.dsGenExcelTableAdapters.usp_ListarPersonalToExportTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tapexportp);
                            dsGenExcel.usp_ListarPersonalToExportDataTable tapexportp2 = tapexportp.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3]);

                            rptsource = new ReportDataSource("DataSet1", tapexportp2.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REPASIENTOEXCEL":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptGenerarAsientosEx.rdlc";

                            code.dsGenerarAsientosTableAdapters.uspGenerarAsientoFormatoExcelTableAdapter tabex = new code.dsGenerarAsientosTableAdapters.uspGenerarAsientoFormatoExcelTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabex);
                            dsGenerarAsientos.uspGenerarAsientoFormatoExcelDataTable tabex2 = tabex.GetData(arr_parametros[0], arr_parametros[1]);

                            ReportParameter p1 = new ReportParameter("pAsiento", CAPA_DATOS.controller_GenerarAsientos.getInstance().GetNombreAsiento(arr_parametros[0]));
                            ReportParameter p2 = new ReportParameter("pPeriodo", CAPA_DATOS.controller_GenerarAsientos.getInstance().GetNombrePeriodo(arr_parametros[1]));
                            ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });

                            rptsource = new ReportDataSource("DataSet1", tabex2.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "TREGISTROE4":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptTRegistroE4.rdlc";

                            code.dsTRegistroTableAdapters.uspGenerarFormatoE4TRegistroTableAdapter tabe4 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE4TRegistroTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe4);
                            dsTRegistro.uspGenerarFormatoE4TRegistroDataTable tabe4b = tabe4.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("DataSet1", tabe4b.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "TREGISTROE5":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptTRegistroE5.rdlc";

                            code.dsTRegistroTableAdapters.uspGenerarFormatoE5TRegistroTableAdapter tabe5 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE5TRegistroTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe5);
                            dsTRegistro.uspGenerarFormatoE5TRegistroDataTable tabe5b = tabe5.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("DataSet1", tabe5b.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "TREGISTROE11":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptTRegistroE11.rdlc";

                            code.dsTRegistroTableAdapters.uspGenerarFormatoE11TRegistroTableAdapter tabe11 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE11TRegistroTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe11);
                            dsTRegistro.uspGenerarFormatoE11TRegistroDataTable tabe11b = tabe11.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("DataSet1", tabe11b.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "TREGISTROE17":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptTRegistroE17.rdlc";

                            code.dsTRegistroTableAdapters.uspGenerarFormatoE17TRegistroTableAdapter tabe17 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE17TRegistroTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe17);
                            dsTRegistro.uspGenerarFormatoE17TRegistroDataTable tabe17b = tabe17.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("DataSet1", tabe17b.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "TREGISTROE29":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptTRegistroE29.rdlc";

                            code.dsTRegistroTableAdapters.uspGenerarFormatoE29TRegistroTableAdapter tabe29 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE29TRegistroTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe29);
                            dsTRegistro.uspGenerarFormatoE29TRegistroDataTable tabe29b = tabe29.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("DataSet1", tabe29b.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        case "RepAsiento_General2": /*Reporte de Asiento General 2*/
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsiento_General2.rdlc";

                            code.dsAsiento_General2TableAdapters.dtAsiento_General2TableAdapter tablaAsiento_General2 = new code.dsAsiento_General2TableAdapters.dtAsiento_General2TableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaAsiento_General2);
                            dsAsiento_General2.dtAsiento_General2DataTable datosAsiento_General2 =
                                tablaAsiento_General2.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2]);

                            rptsource = new ReportDataSource("dtAsiento_General2", datosAsiento_General2.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        case "REPASIENTO_CONSISAT": /*Reporte de Asiento Consisat*/
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsiento_Consisat.rdlc";

                            code.dsAsiento_ConsisatTableAdapters.dtAsiento_ConsisatTableAdapter tablaAsiento_Consisat = new code.dsAsiento_ConsisatTableAdapters.dtAsiento_ConsisatTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaAsiento_Consisat);
                            dsAsiento_Consisat.dtAsiento_ConsisatDataTable datosAsiento_Consisat =
                                tablaAsiento_Consisat.GetData(arr_parametros[0], arr_parametros[1]);

                            rptsource = new ReportDataSource("dtAsiento_Consisat", datosAsiento_Consisat.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        case "REPASIENTO_TIPOGROUP": /*Reporte de Asiento Cta x Tipo de Agrupación*/
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsientoCtaxTipoAgrupacion.rdlc";

                            code.dsAsientoCtaxTipoAgrupacionTableAdapters.dtAsientoCtaxTipoAgrupacionTableAdapter tablaAsientoCtaxTipoAgrupacion = new code.dsAsientoCtaxTipoAgrupacionTableAdapters.dtAsientoCtaxTipoAgrupacionTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaAsientoCtaxTipoAgrupacion);
                            dsAsientoCtaxTipoAgrupacion.dtAsientoCtaxTipoAgrupacionDataTable datosAsientoCtaxTipoAgrupacion =
                                tablaAsientoCtaxTipoAgrupacion.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2]);

                            //oParam = new ReportParameter("prmFecDesde", arr_parametros[3].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);
                            //oParam = new ReportParameter("prmFecHasta", arr_parametros[4].ToString());
                            //ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtAsientoCtaxTipoAgrupacion", datosAsientoCtaxTipoAgrupacion.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        //20190302
                        case "REPASIENTOSAP":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/RepAsientoSap.rdlc";

                            rptsource = new ReportDataSource("DataSet1", CAPA_DATOS.controller_GenerarAsientoSap.getInstance().GenerarAsientosAgrupadoSap(arr_parametros[0]).ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;

                        //20190304
                        case "REPASIENTOSTAR":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/RepAsientoStarSoft.rdlc";

                            rptsource = new ReportDataSource("DataSet1", CAPA_DATOS.controller_GenerarAsientoSap.getInstance().GenerarAsientosAgrupadoStarSoft(arr_parametros[0]).ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        //20190417
                        case "REPASIENTOEXCELDETALLE":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptAsientosExDetalle.rdlc";

                            code.dsGenerarAsientosTableAdapters.uspGenerarAsientoFormatoExcel_DetalleTableAdapter tabexdet = new code.dsGenerarAsientosTableAdapters.uspGenerarAsientoFormatoExcel_DetalleTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabexdet);
                            dsGenerarAsientos.uspGenerarAsientoFormatoExcel_DetalleDataTable tabex2det = tabexdet.GetData(arr_parametros[0], arr_parametros[1]);

                            //ReportParameter p1det = new ReportParameter("pAsiento", CAPA_DATOS.controller_GenerarAsientos.getInstance().GetNombreAsiento(arr_parametros[0]));
                            //ReportParameter p2det = new ReportParameter("pPeriodo", CAPA_DATOS.controller_GenerarAsientos.getInstance().GetNombrePeriodo(arr_parametros[1]));
                            //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1det, p2det });

                            rptsource = new ReportDataSource("DataSet1", tabex2det.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        //20190710
                        case "REP_REM_VARIABLE":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/RemuneracionVariable.rdlc";

                            code.dsReportesTableAdapters.uspReporteRemuneracionVariableTableAdapter tabla1 = new code.dsReportesTableAdapters.uspReporteRemuneracionVariableTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla1);
                            dsReportes.uspReporteRemuneracionVariableDataTable tabla1a = tabla1.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9]);

                            rptsource = new ReportDataSource("dsDatos", tabla1a.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_ING_CCOSTO":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/ResumenIngresosCentroCosto2.rdlc";

                            code.dsReportesTableAdapters.uspReporteResumenIngresoPorCentroCostoTableAdapter tabla2 = new code.dsReportesTableAdapters.uspReporteResumenIngresoPorCentroCostoTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla2);
                            dsReportes.uspReporteResumenIngresoPorCentroCostoDataTable tabla2a = tabla2.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6]);

                            rptsource = new ReportDataSource("dsDatos", tabla2a.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_ING_LOCALIDAD":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/ResumenIngresosLocalidad2.rdlc";

                            code.dsReportesTableAdapters.uspReporteResumenIngresoPorLocalidadTableAdapter tabla3 = new code.dsReportesTableAdapters.uspReporteResumenIngresoPorLocalidadTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla3);
                            dsReportes.uspReporteResumenIngresoPorLocalidadDataTable tabla3a = tabla3.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6]);

                            rptsource = new ReportDataSource("dsDatos", tabla3a.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_INCIDENCIASDF":
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/RepIncDatosFijos.rdlc";

                            code.dsReportesTableAdapters.uspReporteIncidenciasDatosFijosTableAdapter tabla4 = new code.dsReportesTableAdapters.uspReporteIncidenciasDatosFijosTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabla4);
                            dsReportes.uspReporteIncidenciasDatosFijosDataTable tabla4a = tabla4.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4]);

                            rptsource = new ReportDataSource("DataSet1", tabla4a.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                        case "REP_DOCUMENTO_ENVIO": /*Reporte de Envío de Documentos*/
                            str_parametros = Request.QueryString["prm"].ToString();
                            arr_parametros = new String[str_parametros.Split(':').Length];
                            arr_parametros = str_parametros.Split(':');

                            ReportViewer1.LocalReport.ReportPath = "Views/sistemaPlanillas/Reportes/rptHistorialDocumento.rdlc";

                            code.dsRepDocumentosEnvioTableAdapters.dtRepDocumentosEnvioTableAdapter tablaDocEnvio = new code.dsRepDocumentosEnvioTableAdapters.dtRepDocumentosEnvioTableAdapter();
                            ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaDocEnvio);
                            dsRepDocumentosEnvio.dtRepDocumentosEnvioDataTable datosRepDocEnvio =
                                tablaDocEnvio.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9]);

                            oParam = new ReportParameter("prmFecDesde", arr_parametros[8].ToString());
                            ReportViewer1.LocalReport.SetParameters(oParam);
                            oParam = new ReportParameter("prmFecHasta", arr_parametros[9].ToString());
                            ReportViewer1.LocalReport.SetParameters(oParam);

                            rptsource = new ReportDataSource("dtRepDocumentosEnvio", datosRepDocEnvio.ToList());
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            break;
                    }
                }
                else
                {
                    ReportViewer1.Visible = false;
                }
            }
        }

        //Aumenta el tiempo de respuesta de un RDL (para que no salga error TimeOut)
        protected void SetAllCommandTimeouts(object adapter, int timeout)
        {
            var commands = adapter.GetType().InvokeMember(
                    "CommandCollection",
                    System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, adapter, new object[0]);
            var sqlCommand = (System.Data.SqlClient.SqlCommand[])commands;
            foreach (var cmd in sqlCommand)
            {
                cmd.CommandTimeout = timeout;
            }
        }

        void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (Request.QueryString["fl_Imprimir_PDF"] != null)
            {
                bool fl_Imprimir = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_Imprimir_PDF"]));
                if (fl_Imprimir == true)
                {
                    String namePDF = "FrmPrint.pdf";
                    if (Session["flPorPersonal"] != null && Session["flPorPersonal"].ToString() == "1")
                    {
                        string reporte_Id = Request.QueryString["Reporte_Id"].ToString();
                        string personal_Id = Request.QueryString["personal_Id"].ToString();
                        if (reporte_Id == "1_Disenio" && Session["NombreBoleta_" + personal_Id] != null)
                        {
                            namePDF = Session["NombreBoleta_" + personal_Id].ToString() + ".pdf";
                            Session.Remove("NombreBoleta_" + personal_Id);
                        }
                        ReportViewer1.Attributes["title"] = namePDF;
                        ReportPrintHelper oPrint = new ReportPrintHelper();
                        oPrint.RenderToPDF(ref ReportViewer1, EXPORT_TYPE.TYPE_PDF, this.Context, true);
                    }
                    else
                    {
                        ReportViewer1.Attributes["title"] = namePDF;
                        ReportPrintHelper oPrint = new ReportPrintHelper();
                        oPrint.RenderToPDF(ref ReportViewer1, EXPORT_TYPE.TYPE_PDF, this.Context, false);
                        //oPrint.RenderToExcel(ref ReportViewer1, EXPORT_TYPE.TYPE_XLS, this.Context, true);
                    }
                }
            }
            else if (Request.QueryString["fl_Print"] != null)
            {
                bool fl_Print = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_Print"]));
                if (fl_Print == true)
                {
                    Boolean fl_Lista_Array = true;
                    Imprimir(fl_Lista_Array, "");
                }
                Utils.fc_JavaScript(this, "window.close();");
            }
        }

        /*Para Imprimir*/
        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Boolean fl_Lista_Array = false;
            if (Request.QueryString["fl_Print"] != null)
            {
                bool fl_Print = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_Print"]));
                if (fl_Print == true)
                {
                    fl_Lista_Array = true;
                    Imprimir(fl_Lista_Array, "");
                }
            }
            else
            {
                string personal_Id = Request.QueryString["personal_Id"].ToString();
                Imprimir(fl_Lista_Array, personal_Id);
            }
        }

        public void Imprimir(Boolean fl_lista_Array, String personal_Id)
        {
            if (fl_lista_Array == true)
            {
                ArrayList listPersonal = new ArrayList();
                listPersonal = (ArrayList)Session["listPersonalImprimir"];
                foreach (String Id in listPersonal)
                {
                    RunImprime(Id);
                }
            }
            else
            {
                RunImprime(personal_Id);
            }
        }

        private int m_currentPageIndex;
        private System.Collections.Generic.IList<System.IO.Stream> m_streams;

        /*Método para imprimir directo en el Servidor*/
        private void RunImprime(String personal_Id)
        {
            string periodo_Id = Request.QueryString["periodo_Id"].ToString();
            string proceso_Id = Request.QueryString["proceso_Id"].ToString();
            DataTable dtBoletaPago = new DataTable();
            dtBoletaPago = Log_Reportes.Lista_Boleta_Pago(personal_Id, periodo_Id, proceso_Id);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptBoletaPago.rdlc");
            ReportDataSource rptsource = new ReportDataSource("dsBoletaPago_BoletaPago", dtBoletaPago);

            /******************************/
            LocalReport report = new LocalReport();
            //report.ReportPath = ReportViewer1.LocalReport.ReportPath;
            //report.DataSources.Add(ReportViewer1.LocalReport.DataSources[0]);
            report.ReportPath = Server.MapPath("rptBoletaPago.rdlc");
            report.DataSources.Add(rptsource);
            Export(report);
            m_currentPageIndex = 0;
            Print();
        }
        private void Export(LocalReport report)
        {
            string deviceInfo = "<DeviceInfo>"
                + "  <OutputFormat>EMF</OutputFormat>"
                + "  <PageWidth>8.5in</PageWidth>"
                + "  <PageHeight>11in</PageHeight>"
                + "  <MarginTop>0.25in</MarginTop>"
                + "  <MarginLeft>0.25in</MarginLeft>"
                + "  <MarginRight>0.25in</MarginRight>"
                + "  <MarginBottom>0.25in</MarginBottom>"
                + "</DeviceInfo>";
            Warning[] warnings = null;
            m_streams = new List<System.IO.Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
            }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(Server.MapPath("../archivosImprimir/") + name + "." + fileNameExtension, FileMode.Create);
            //Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Print()
        {
            string val = "";
            foreach (string print in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                val += "- " + print + "\\n";
            }
            try
            {
                //If PrinterSettings.InstalledPrinters.Count = 0 Then
                //string printerName = "\\\\srvlpvprint01.La_Positiva.com.pe\\nombre_Impresora";
                string printerName = "\\\\WIN-ZYO5T2LGDYV\\Canon MF3200 Series_";
                //\\srvlpvprint01.La_Positiva.com.pe\HEDE01
                if (m_streams == null | m_streams.Count == 0)
                {
                    //throw new Exception("Error: no stream to print.");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "alert('No hay flujo para imprimir');", true);
                    return;
                }

                System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
                printDoc.PrinterSettings.PrinterName = printerName;

                string impresoraDefecto = printDoc.PrinterSettings.PrinterName;
                printDoc.PrinterSettings.PrinterName = impresoraDefecto;

                if (!printDoc.PrinterSettings.IsValid)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "alert('No se encuentra la impresora, configure una de la siguiente lista:\\n\\n" + val + "');", true);
                    return;
                }

                printDoc.PrintPage += new PrintPageEventHandler(this.PrintPage);
                printDoc.Print();
                Limpiar();
                //Else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "alert('Imprimió Correctamente.');", true);
                //End If
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "alert('" + ex.Message + "');", true);
                //ImageButton1.Visible = False
            }
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            m_currentPageIndex += 1;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        public void Limpiar()
        {
            if ((m_streams != null))
            {
                foreach (Stream stream in m_streams)
                {
                    stream.Close();
                }
                m_streams = null;
            }
        }
        public void GenerateExcelReport(string reportPath, string dataSourceName, string outputPath, string tplanilla)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = reportPath;
            String str_parametros = String.Empty;
            String[] arr_parametros = null;
            String[] arr_parametros2 = null;
            str_parametros = Request.QueryString["prm"].ToString();
            arr_parametros = new String[str_parametros.Split(':').Length];
            arr_parametros = str_parametros.Split(':');

            string mesini, mesfin, primerPeriodoId, ultimoPeriodoId;
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                cn.Open();
                // Obtener mes_id para periodoini
                mesini = GetMesId(cn, arr_parametros[0]);

                // Obtener mes_id para periodofin
                mesfin = GetMesId(cn, arr_parametros[1]);

                // Obtener el primer periodo_id
                primerPeriodoId = GetPrimerPeriodoId(cn, mesini);

                // Obtener el último periodo_id
                ultimoPeriodoId = GetUltimoPeriodoId(cn, mesfin);


            }
            if (reportPath == "Views/sistemaPlanillas/Reportes/rptPlanillaGeneralDetalle.rdlc" && tplanilla == "01")
            {
                ReportViewer1.LocalReport.ReportPath = reportPath;

                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet);
                SetAllCommandTimeouts(tablaPlanillaDet, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet =
                    tablaPlanillaDet.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                report.DataSources.Add(new ReportDataSource(dataSourceName, datosReportePlanillaGeneralDet.ToList()));
            }
            if (reportPath == "Views/sistemaPlanillas/Reportes/rptPlanillaGeneralDetalle.rdlc" && tplanilla == "02")
            {
                arr_parametros2 = arr_parametros;
                arr_parametros2[0] = primerPeriodoId;
                arr_parametros2[1] = ultimoPeriodoId;
                ReportViewer1.LocalReport.ReportPath = reportPath;

                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet);
                SetAllCommandTimeouts(tablaPlanillaDet, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet =
                    tablaPlanillaDet.GetData(primerPeriodoId, ultimoPeriodoId, arr_parametros2[2], arr_parametros2[3], arr_parametros2[4], arr_parametros2[5], arr_parametros2[6], arr_parametros2[7], arr_parametros2[8], arr_parametros2[9], arr_parametros2[10], arr_parametros2[11]);

                report.DataSources.Add(new ReportDataSource(dataSourceName, datosReportePlanillaGeneralDet.ToList()));
            }
            if (reportPath == "Views/sistemaPlanillas/Reportes/rptPlanillaGeneralUnificada.rdlc" && tplanilla == "00" || tplanilla == "03")
            {
                if (tplanilla == "03" && !arr_parametros[2].Contains("09"))
                {
                    arr_parametros[2] += ",09";
                }

                ReportViewer1.LocalReport.ReportPath = reportPath;
                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet);
                SetAllCommandTimeouts(tablaPlanillaDet, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet1 =
                    tablaPlanillaDet.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                arr_parametros2 = arr_parametros;
                arr_parametros2[0] = primerPeriodoId;
                arr_parametros2[1] = ultimoPeriodoId;

                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet2 = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet2);
                SetAllCommandTimeouts(tablaPlanillaDet2, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet2 =
                    tablaPlanillaDet2.GetData(primerPeriodoId, ultimoPeriodoId, arr_parametros2[2], arr_parametros2[3], arr_parametros2[4], arr_parametros2[5], arr_parametros2[6], arr_parametros2[7], arr_parametros2[8], arr_parametros2[9], arr_parametros2[10], arr_parametros2[11]);

                DataTable c1 = datosReportePlanillaGeneralDet1;
                DataTable c2 = datosReportePlanillaGeneralDet2;
                c1.Columns.Add("Planilla", typeof(string)).SetOrdinal(0);
                foreach (DataRow row in c1.Rows)
                {
                    row["Planilla"] = "EMPLEADO";
                }
                c2.Columns.Add("Planilla", typeof(string)).SetOrdinal(0);
                foreach (DataRow row in c2.Rows)
                {
                    row["Planilla"] = "OBRERO";
                }
                DataTable combinedDataTable = CombineDataTables(c1, c2);

                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable dataTableEspecífico = new dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable();

                // Copiar la estructura si es necesario (generalmente no lo es, ya que dataTableEspecífico ya debería tener la estructura correcta)
                foreach (DataColumn column in combinedDataTable.Columns)
                {
                    if (!dataTableEspecífico.Columns.Contains(column.ColumnName))
                    {
                        dataTableEspecífico.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                    }
                }

                // Copiar los datos
                foreach (DataRow row in combinedDataTable.Rows)
                {
                    dataTableEspecífico.ImportRow(row);
                }
                report.DataSources.Add(new ReportDataSource(dataSourceName, dataTableEspecífico.ToList()));
            }
            if (reportPath == "Views/sistemaPlanillas/Reportes/rptPlanillaPlameAFPMensual.rdlc" && tplanilla == "04")
            {
                if (!arr_parametros[2].Contains("09"))
                {
                    arr_parametros[2] += ",09";
                }
                ReportViewer1.LocalReport.ReportPath = reportPath;
                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet);
                SetAllCommandTimeouts(tablaPlanillaDet, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet1 =
                    tablaPlanillaDet.GetData(arr_parametros[0], arr_parametros[1], arr_parametros[2], arr_parametros[3], arr_parametros[4], arr_parametros[5], arr_parametros[6], arr_parametros[7], arr_parametros[8], arr_parametros[9], arr_parametros[10], arr_parametros[11]);

                arr_parametros2 = arr_parametros;
                arr_parametros2[0] = primerPeriodoId;
                arr_parametros2[1] = ultimoPeriodoId;

                code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter tablaPlanillaDet2 = new code.dsReportePlanillaGeneralTableAdapters.dtReportePlanillaGeneralTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tablaPlanillaDet2);
                SetAllCommandTimeouts(tablaPlanillaDet2, 120); //120 seg = 2 min
                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable datosReportePlanillaGeneralDet2 =
                    tablaPlanillaDet2.GetData(primerPeriodoId, ultimoPeriodoId, arr_parametros2[2], arr_parametros2[3], arr_parametros2[4], arr_parametros2[5], arr_parametros2[6], arr_parametros2[7], arr_parametros2[8], arr_parametros2[9], arr_parametros2[10], arr_parametros2[11]);

                DataTable c1 = datosReportePlanillaGeneralDet1;
                DataTable c2 = datosReportePlanillaGeneralDet2;

                DataTable combinedDataTable = CombineDataTables(c1, c2);

                dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable dataTableEspecífico = new dsReportePlanillaGeneral.dtReportePlanillaGeneralDataTable();

                // Copiar la estructura si es necesario (generalmente no lo es, ya que dataTableEspecífico ya debería tener la estructura correcta)
                foreach (DataColumn column in combinedDataTable.Columns)
                {
                    if (!dataTableEspecífico.Columns.Contains(column.ColumnName))
                    {
                        dataTableEspecífico.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
                    }
                }

                // Copiar los datos
                foreach (DataRow row in combinedDataTable.Rows)
                {
                    dataTableEspecífico.ImportRow(row);
                }
                report.DataSources.Add(new ReportDataSource(dataSourceName, dataTableEspecífico.ToList()));
            }

            string mimeType, encoding, fileNameExtension;
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;


            renderedBytes = report.Render(
                "EXCELOPENXML",
                null,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
            );

            File.WriteAllBytes(outputPath, renderedBytes);
        }
        public void CombineExcelFilesAndDownload(List<string> filePaths, List<string> sheetNames, string outputFilePath)
        {
            using (var package = new ExcelPackage())
            {
                for (int i = 0; i < filePaths.Count; i++)
                {
                    var path = filePaths[i];
                    var sheetName = sheetNames[i];

                    using (var tempPackage = new ExcelPackage(new FileInfo(path)))
                    {
                        foreach (var sheet in tempPackage.Workbook.Worksheets)
                        {
                            if (!package.Workbook.Worksheets.Any(ws => ws.Name == sheetName))
                            {
                                var ws = package.Workbook.Worksheets.Add(sheetName, sheet);
                            }
                            else
                            {
                                var newName = sheetName + "_" + (i + 1).ToString();
                                var ws = package.Workbook.Worksheets.Add(newName, sheet);
                            }
                        }
                    }

                    File.Delete(path);
                }


                // Asegúrate de que hay al menos una hoja en la lista de nombres de hojas y que existe en el paquete
                if (sheetNames.Count > 4 && package.Workbook.Worksheets.Any(ws => ws.Name == sheetNames[4]))
                {
                    var dataWorksheet = package.Workbook.Worksheets[sheetNames[4]];
                    var pivotWorksheet = package.Workbook.Worksheets.Add("Resumen");

                    // Definir el rango de datos a usar en la tabla dinámica
                    var startRow = 7;
                    var endRow = dataWorksheet.Dimension.End.Row;
                    var startCell = "A" + startRow;
                    var endCell = "AR" + endRow;
                    var dataRange = dataWorksheet.Cells[startCell + ":" + endCell];

                    // Rellenar celdas vacías con cadena vacía
                    for (int row = startRow; row <= endRow; row++)
                    {
                        for (int col = 1; col <= 44; col++)
                        {
                            if (string.IsNullOrEmpty(dataWorksheet.Cells[row, col].Text))
                            {
                                dataWorksheet.Cells[row, col].Value = "  ";
                            }
                        }
                    }

                    // Asegúrate de que la primera fila contiene encabezados válidos
                    var headerRange = dataWorksheet.Cells["A7:AR7"];
                    foreach (var cell in headerRange)
                    {
                        if (string.IsNullOrEmpty(cell.Text))
                        {
                            throw new ArgumentException("First row of source range should contain the field headers and can't have blank cells.");
                        }
                    }


                    var pivotTable = pivotWorksheet.PivotTables.Add(pivotWorksheet.Cells["A7"], dataRange, "PivotTableResumen");


                    pivotTable.DataOnRows = false;

                    pivotTable.RowFields.Add(pivotTable.Fields["PLANILLA"]);
                    pivotTable.RowFields.Add(pivotTable.Fields["PROYECTO"]);
                    //ExcelPivotTableDataField dataField;
                    //dataField = pivotTable.DataFields.Add(pivotTable.Fields["RETENCION 5TA"]);
                    //dataField = pivotTable.DataFields.Add(pivotTable.Fields["PRIMA DE SEGURO AFP"]);

                    var dataField1 = pivotTable.DataFields.Add(pivotTable.Fields["RETENCION 5TA"]);
                    dataField1.Name = "Total Retención 5TA";
                    dataField1.Function = DataFieldFunctions.Sum;

                    var dataField2 = pivotTable.DataFields.Add(pivotTable.Fields["PRIMA DE SEGURO AFP"]);
                    dataField2.Name = "Total Prima de Seguro AFP";
                    dataField2.Function = DataFieldFunctions.Sum;

                    //pivotTable.ColumnFields.Add(pivotTable.Fields["_Values"]);

                    //pivotTable.DataFields.Add(pivotTable.Fields["RETENCION 5TA"]);
                    //pivotTable.ColumnFields.Add(pivotTable.Fields["RETENCION 5TA"]);

                }


                var ms = new MemoryStream();
                package.SaveAs(ms);
                ms.Position = 0;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + outputFilePath);
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
        private static string GetMesId(SqlConnection connection, string periodoId)
        {
            string mesId = "";
            using (SqlCommand command = new SqlCommand("SELECT mes_id FROM periodo WHERE periodo_id = @periodoId", connection))
            {
                command.Parameters.AddWithValue("@periodoId", periodoId);
                mesId = (string)command.ExecuteScalar();
            }
            return mesId;
        }

        private static string GetPrimerPeriodoId(SqlConnection connection, string mesId)
        {
            string periodoId = "";
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 periodo_id FROM periodo WHERE Mes_Id = @mesId AND Planilla_Id = '02' ORDER BY periodo_id ASC", connection))
            {
                command.Parameters.AddWithValue("@mesId", mesId);
                periodoId = (string)command.ExecuteScalar();
            }
            return periodoId;
        }

        private static string GetUltimoPeriodoId(SqlConnection connection, string mesId)
        {
            string periodoId = "";
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 periodo_id FROM periodo WHERE Mes_Id = @mesId AND Planilla_Id = '02' ORDER BY Periodo_Id DESC", connection))
            {
                command.Parameters.AddWithValue("@mesId", mesId);
                periodoId = (string)command.ExecuteScalar();
            }
            return periodoId;
        }
        private DataTable CombineDataTables(DataTable dt1, DataTable dt2)
        {
            // Crear un nuevo DataTable para el resultado combinado
            DataTable combinedDataTable = new DataTable("CombinedDataTable");

            // Suponiendo que ambos DataTables tienen la misma estructura
            foreach (DataColumn column in dt1.Columns)
            {
                combinedDataTable.Columns.Add(column.ColumnName, column.DataType);
            }

            // Agregar filas de dt1
            foreach (DataRow row in dt1.Rows)
            {
                combinedDataTable.ImportRow(row);
            }

            // Agregar filas de dt2
            foreach (DataRow row in dt2.Rows)
            {
                combinedDataTable.ImportRow(row);
            }

            return combinedDataTable;
        }
    }
}