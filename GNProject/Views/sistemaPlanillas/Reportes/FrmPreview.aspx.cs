using CAPA_ENTIDAD;
using CAPA_LOGICO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class FrmPreview : System.Web.UI.Page
    {
        ReportDocument rptSource;
        //ReportDocument rptSource2;


        Ent_PptoPersonal objEPptoPersonal;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.Dispose();
            //if (!Page.IsPostBack)
            //{
            if (Request.QueryString["fl_Print"] == null)
            {
                string reporte_Id = Request.QueryString["Reporte_Id"].ToString();
                string personal_Id_Masivo, personal_Id, periodo_Id, proceso_Id;
                Int32 cantPersonal;
                string ordenid;
                //ReportDocument rptSource;
                DataTable dt;

                string usuario_Id;
                string rutaLogoEmpresa;
                //////, razonSocialEmpresa, RUCEmpresa;
                rutaLogoEmpresa = Parametros.FileServer_RutaEmpresa + "LogoEmpresa.png";
                String rutaImgFirma = Parametros.FileServer_RutaEmpresa + "Firma.png";
                //Response.Write(rutaLogoEmpresa); return; //Para probar la ruta
                //////razonSocialEmpresa = "LIMA GAS SA";
                //////RUCEmpresa = "20100007348";
                switch (reporte_Id)
                {
                    case "1": /*Reporte de Boletas*/
                        personal_Id_Masivo = (String)Session["Personal_Id_Masivo"];
                        cantPersonal = Convert.ToInt32(Request.QueryString["cantPersonal"].ToString());
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        //20190122
                        ordenid = Request.QueryString["orden_id"].ToString();
                        //int result = Log_PptoPersonal.Lista_ActivarLevel80();

                        DataTable dtBoletaPago = new DataTable();


                        dtBoletaPago = Log_Reportes.Lista_Boleta_Pago_Masivo(personal_Id_Masivo, periodo_Id, proceso_Id, cantPersonal, ordenid, "", "", "");

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpBoletaPago.rpt"));
                        rptSource.SetDataSource(dtBoletaPago);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        //rptSource.PrintToPrinter(1, false, 1, 1);
                        dtBoletaPago.Dispose();
                        break;
                    case "1_Disenio": /*Reporte de Boletas con diseño*/
                        personal_Id_Masivo = (String)Session["Personal_Id_Masivo"];
                        cantPersonal = Convert.ToInt32(Request.QueryString["cantPersonal"].ToString());
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();

                        //int result2 = Log_PptoPersonal.Lista_ActivarLevel80();
                        //20190122
                        ordenid = Request.QueryString["orden_id"].ToString();

                        DataTable dtBoletaPago2 = new DataTable();

                        dtBoletaPago2 = Log_Reportes.Lista_Boleta_Pago_Masivo(personal_Id_Masivo, periodo_Id, proceso_Id, cantPersonal, ordenid, "", "", "");

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpBoletaPago2.rpt"));
                        rptSource.SetDataSource(dtBoletaPago2);
                        //20181025
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        //rptSource.PrintToPrinter(1, false, 1, 1);
                        dtBoletaPago2.Dispose();
                        break;
                    case "1b": /*Reporte de Boletas*/
                        personal_Id_Masivo = (String)Session["Personal_Id_Masivo"];
                        cantPersonal = Convert.ToInt32(Request.QueryString["cantPersonal"].ToString());
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();

                        //int resultpv = Log_PptoPersonal.Lista_ActivarLevel80();

                        DataTable dtBoletaPagopv = new DataTable();

                        //20190122
                        ordenid = Request.QueryString["orden_id"].ToString();
                        dtBoletaPago = Log_Reportes.Lista_Boleta_Pago_Masivo(personal_Id_Masivo, periodo_Id, proceso_Id, cantPersonal, ordenid, "", "", "");

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpBoletaPagoPreview.rpt"));
                        rptSource.SetDataSource(dtBoletaPagopv);
                        //20181025
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        //rptSource.PrintToPrinter(1, false, 1, 1);
                        dtBoletaPago.Dispose();
                        break;
                    case "0039": /*Reporte de CARTA CTS A BANCO*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = ""; //Para TODOS
                        DataTable dtCartaCTSBanco = new DataTable();
                        dtCartaCTSBanco = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        dt = new DataTable();
                        dt.Columns.Add("Nro", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecFin", System.Type.GetType("System.String"));
                        dt.Columns.Add("Banco", System.Type.GetType("System.String"));
                        dt.Columns.Add("Trabajador", System.Type.GetType("System.String"));
                        dt.Columns.Add("NroDoc", System.Type.GetType("System.String"));
                        dt.Columns.Add("Telefono", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecIni", System.Type.GetType("System.String"));
                        dt.Columns.Add("DistritoEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("Cargo", System.Type.GetType("System.String"));
                        dt.Columns.Add("LogoEmpresa", System.Type.GetType("System.Byte[]"));
                        dt.Columns.Add("RazonSocialEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("RucEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("NroCuenta_CTS", System.Type.GetType("System.String"));
                        dt.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        dt.Columns.Add("RepresentanteLegal", System.Type.GetType("System.String"));

                        foreach (DataRow fila in dtCartaCTSBanco.Rows)
                        {
                            DataRow row = dt.NewRow();
                            row["Nro"] = fila["Nro"].ToString();
                            row["FecFin"] = Convert.ToDateTime(fila["FecFin"]).ToString("dd/MM/yyyy");
                            row["Banco"] = fila["Banco"].ToString();
                            row["Trabajador"] = fila["Trabajador"].ToString();
                            row["NroDoc"] = fila["NroDoc"].ToString();
                            row["Telefono"] = fila["Telefono"].ToString();
                            row["FecIni"] = Convert.ToDateTime(fila["FecIni"]).ToString("dd/MM/yyyy");
                            row["DistritoEmpresa"] = fila["DistritoEmpresa"].ToString();
                            row["Cargo"] = fila["Cargo"].ToString();
                            row["LogoEmpresa"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            row["RazonSocialempresa"] = fila["EMPLEADOR"];
                            row["RucEmpresa"] = fila["RUC"];
                            row["NroCuenta_CTS"] = fila["NroCuenta_CTS"];
                            row["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                            row["RepresentanteLegal"] = fila["RepresentanteLegal"];
                            dt.Rows.Add(row);
                        }

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpCartaCTSBanco.rpt"));

                        rptSource.SetDataSource(dt);
                        //20180822
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dt.Dispose();
                        dtCartaCTSBanco.Dispose();
                        break;

                    case "0004": /*Reporte de CERTIFICADO DE RETENCION DE 5TA*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtCertifRetencion5ta = new DataTable();
                        //dtCertifRetencion5ta = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
                        dtCertifRetencion5ta = Log_Reportes.GenerarCertificadoQuinta(periodo_Id, personal_Id);
                        //dtCertifRetencion5ta = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        //20190703
                        dtCertifRetencion5ta.Columns.Add("LogoEmp", System.Type.GetType("System.Byte[]"));
                        dtCertifRetencion5ta.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        DataTable dtresp = new DataTable();


                        foreach (DataRow fila in dtCertifRetencion5ta.Rows)
                        {
                            dtresp = Log_Reportes.List_Report_desc(periodo_Id, fila["DNI"].ToString());
                            fila["LogoEmp"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            fila["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                            fila["Mes"] = dtresp.Rows[0]["DES"].ToString();
                        }

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpCertifRetencion5ta.rpt"));
                        rptSource.SetDataSource(dtCertifRetencion5ta);
                        //20181025
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtCertifRetencion5ta.Dispose();
                        break;

                    case "0038": /*Reporte de CERTIFICADO DE TRABAJO*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtCertifTrabajo = new DataTable();
                        dtCertifTrabajo = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        dt = new DataTable();
                        dt.Columns.Add("Nro", System.Type.GetType("System.String"));
                        dt.Columns.Add("Trabajador", System.Type.GetType("System.String"));
                        dt.Columns.Add("Cargo", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecIni", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecFin", System.Type.GetType("System.String"));
                        dt.Columns.Add("Contrato", System.Type.GetType("System.String"));
                        dt.Columns.Add("CIA", System.Type.GetType("System.String"));
                        dt.Columns.Add("DistritoEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("LogoEmpresa", System.Type.GetType("System.Byte[]"));
                        //20190703
                        dt.Columns.Add("RazonSocialEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        dt.Columns.Add("RepresentanteLegal", System.Type.GetType("System.String"));
                        dt.Columns.Add("FechaDocumento", System.Type.GetType("System.String"));
                        dt.Columns.Add("Estado_Id", System.Type.GetType("System.String"));
                        dt.Columns.Add("Apellido_Paterno", System.Type.GetType("System.String"));
                        dt.Columns.Add("RucEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("Direccion", System.Type.GetType("System.String"));
                        dt.Columns.Add("NroDoc", System.Type.GetType("System.String"));
                        foreach (DataRow fila in dtCertifTrabajo.Rows)
                        {
                            DataRow row = dt.NewRow();
                            row["Nro"] = fila["Nro"].ToString();
                            row["Trabajador"] = fila["Trabajador"].ToString();
                            row["Cargo"] = fila["Cargo"].ToString();
                            row["FecIni"] = Convert.ToDateTime(fila["FecIni"]).ToString("dd/MM/yyyy");
                            row["FecFin"] = Convert.ToDateTime(fila["FecFin"]).ToString("dd/MM/yyyy");
                            row["Contrato"] = fila["Contrato"].ToString();
                            row["CIA"] = fila["CIA"].ToString();
                            row["DistritoEmpresa"] = fila["DistritoEmpresa"].ToString().Substring(0, 1).ToUpper() + fila["DistritoEmpresa"].ToString().Substring(1).ToLower();
                            row["LogoEmpresa"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            row["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                            row["RepresentanteLegal"] = fila["RepresentanteLegal"];
                            row["RazonSocialempresa"] = fila["EMPLEADOR"];
                            row["Direccion"] = fila["Direc"];
                            row["RucEmpresa"] = fila["RUC"];
                            row["NroDoc"] = fila["NRODOC"];
                            row["FechaDocumento"] = (fila["Estado_Id"].ToString() == "01" /*Activo*/ ? DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy") : Convert.ToDateTime(fila["FecFin"]).ToString("dd 'de' MMMM 'de' yyyy"));
                            row["Estado_Id"] = fila["Estado_Id"];
                            row["Apellido_Paterno"] = fila["Apellido_Paterno"];
                            dt.Rows.Add(row);
                        }

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpCertifTrabajo.rpt"));
                        rptSource.SetDataSource(dt);
                        //20180822
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        //20180827
                        //rptSource.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Imgs/ArchivoPDF.pdf"));

                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dt.Dispose();
                        dtCertifTrabajo.Dispose();
                        break;
                    case "0042": /*Reporte de CERTIFICADO DE TRABAJOv2*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        reporte_Id = "0038";
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtCertifTrabajov2 = new DataTable();
                        dtCertifTrabajov2 = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        dt = new DataTable();
                        dt.Columns.Add("Nro", System.Type.GetType("System.String"));
                        dt.Columns.Add("Trabajador", System.Type.GetType("System.String"));
                        dt.Columns.Add("Cargo", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecIni", System.Type.GetType("System.String"));
                        dt.Columns.Add("FecFin", System.Type.GetType("System.String"));
                        dt.Columns.Add("Contrato", System.Type.GetType("System.String"));
                        dt.Columns.Add("CIA", System.Type.GetType("System.String"));
                        dt.Columns.Add("DistritoEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("LogoEmpresa", System.Type.GetType("System.Byte[]"));
                        //20190703
                        dt.Columns.Add("RazonSocialEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        dt.Columns.Add("RepresentanteLegal", System.Type.GetType("System.String"));
                        dt.Columns.Add("FechaDocumento", System.Type.GetType("System.String"));
                        dt.Columns.Add("Estado_Id", System.Type.GetType("System.String"));
                        dt.Columns.Add("Apellido_Paterno", System.Type.GetType("System.String"));
                        dt.Columns.Add("RucEmpresa", System.Type.GetType("System.String"));
                        dt.Columns.Add("Direccion", System.Type.GetType("System.String"));
                        dt.Columns.Add("NroDoc", System.Type.GetType("System.String"));
                        foreach (DataRow fila in dtCertifTrabajov2.Rows)
                        {
                            DataRow row = dt.NewRow();
                            row["Nro"] = fila["Nro"].ToString();
                            row["Trabajador"] = fila["Trabajador"].ToString();
                            row["Cargo"] = fila["Cargo"].ToString();
                            row["FecIni"] = Convert.ToDateTime(fila["FecIni"]).ToString("dd/MM/yyyy");
                            row["FecFin"] = Convert.ToDateTime(fila["FecFin"]).ToString("dd/MM/yyyy");
                            row["Contrato"] = fila["Contrato"].ToString();
                            row["CIA"] = fila["CIA"].ToString();
                            row["DistritoEmpresa"] = fila["DistritoEmpresa"].ToString().Substring(0, 1).ToUpper() + fila["DistritoEmpresa"].ToString().Substring(1).ToLower();
                            row["LogoEmpresa"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            row["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                            row["RepresentanteLegal"] = fila["RepresentanteLegal"];
                            row["RazonSocialempresa"] = fila["EMPLEADOR"];
                            row["Direccion"] = fila["Direc"];
                            row["RucEmpresa"] = fila["RUC"];
                            row["NroDoc"] = fila["NRODOC"];
                            row["FechaDocumento"] = (fila["Estado_Id"].ToString() == "01" /*Activo*/ ? DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy") : Convert.ToDateTime(fila["FecFin"]).ToString("dd 'de' MMMM 'de' yyyy"));
                            row["Estado_Id"] = fila["Estado_Id"];
                            row["Apellido_Paterno"] = fila["Apellido_Paterno"];
                            dt.Rows.Add(row);
                        }

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpCertifTrabajoV2.rpt"));
                        rptSource.SetDataSource(dt);
                        //20180822
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        //20180827
                        //rptSource.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath("../Imgs/ArchivoPDF.pdf"));

                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dt.Dispose();
                        dtCertifTrabajov2.Dispose();
                        break;
                    case "0026": /*Reporte de DETERMINACION DE LA DEUDA - PDT 601*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtDeterminacionDeudaPDT = new DataTable();
                        dtDeterminacionDeudaPDT = Log_Reportes.Lista_rpt_Reportes_Mensual(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpDeterminacionDeudaPDT.rpt"));
                        rptSource.SetDataSource(dtDeterminacionDeudaPDT);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtDeterminacionDeudaPDT.Dispose();
                        break;

                    case "0002": /*Reporte de LIQUIDACION CTS*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtLiquidacionCTS = new DataTable();
                        dtLiquidacionCTS = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
                        //20190703
                        dtLiquidacionCTS.Columns.Add("LogoEmp", System.Type.GetType("System.Byte[]"));
                        dtLiquidacionCTS.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        dtLiquidacionCTS.Columns.Add("TotalComp_FormaCalc", System.Type.GetType("System.String"));
                        foreach (DataRow fila in dtLiquidacionCTS.Rows)
                        {
                            fila["LogoEmp"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            fila["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);

                            Int32 Regimen_Laboral_Id = Convert.ToInt32(fila["REGIMEN_LABORAL_ID"].ToString());
                            string txFormaCalulo = String.Format("({0}) / 360 * {1} =", decimal.Parse(fila["TOTALCOMP"].ToString()).ToString("###,##0.00"), decimal.Parse(fila[21].ToString()).ToString("###,##0.00"));
                            if (Regimen_Laboral_Id == 16 || Regimen_Laboral_Id == 17) /*Microempresa o Pequeña empresa*/
                            {
                                txFormaCalulo = String.Format("({0} / 2) / 360 * {1} =", decimal.Parse(fila["TOTALCOMP"].ToString()).ToString("###,##0.00"), decimal.Parse(fila[21].ToString()).ToString("###,##0.00"));
                            }
                            fila["TotalComp_FormaCalc"] = txFormaCalulo;
                        }
                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpLiquidacionCTS.rpt"));
                        rptSource.SetDataSource(dtLiquidacionCTS);

                        //@001 I
                        DataTable dtRemComputable_CTS = new DataTable();
                        #region "Agrega Tabla de Rem Computable"
                        dtRemComputable_CTS.Columns.Add("NomTrabajador", typeof(String));
                        dtRemComputable_CTS.Columns.Add("Concepto", typeof(String));
                        dtRemComputable_CTS.Columns.Add("Valor", typeof(Decimal));

                        foreach (DataRow row in dtLiquidacionCTS.Rows)
                        {
                            DataRow dr;
                            if (Convert.ToDecimal(row["RemComp"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Básico";
                                dr["Valor"] = Convert.ToDecimal(row["RemComp"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["AsigFam"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Asignación Familiar";
                                dr["Valor"] = Convert.ToDecimal(row["AsigFam"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["SobreTiempo"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Sobretiempo (Promedio Semestral)";
                                dr["Valor"] = Convert.ToDecimal(row["SobreTiempo"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["BonifNocturna"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Bonificación Nocturna (Promedio Semestral)";
                                dr["Valor"] = Convert.ToDecimal(row["BonifNocturna"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["ComVenta"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Comisión Venta (Promedio Semestral)";
                                dr["Valor"] = Convert.ToDecimal(row["ComVenta"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["BonifProduc"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Bonificación Trabajo";
                                dr["Valor"] = Convert.ToDecimal(row["BonifProduc"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["Refrigerio"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "Refrigerio";
                                dr["Valor"] = Convert.ToDecimal(row["Refrigerio"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                            if (Convert.ToDecimal(row["SextoGrati"]) != 0)
                            {
                                dr = dtRemComputable_CTS.NewRow();
                                dr["NomTrabajador"] = row["NomTrabajador"].ToString();
                                dr["Concepto"] = "1/6 Gratificación";
                                dr["Valor"] = Convert.ToDecimal(row["SextoGrati"]).ToString("###,###,##0.00");
                                dtRemComputable_CTS.Rows.Add(dr);
                            }
                        }
                        #endregion "Agrega Tabla de Rem Computable"
                        rptSource.Database.Tables["RemComputable"].SetDataSource(dtRemComputable_CTS);
                        //@001 F

                        //20181025
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtLiquidacionCTS.Dispose();
                        break;

                    case "0005": /*Reporte de LIQUIDACION DE BENEFICIOS SOCIALES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtLiquidaBenefSociales = new DataTable();
                        dtLiquidaBenefSociales = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
                        //20190703
                        dtLiquidaBenefSociales.Columns.Add("LogoEmpresa", System.Type.GetType("System.Byte[]"));
                        dtLiquidaBenefSociales.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        foreach (DataRow fila in dtLiquidaBenefSociales.Rows)
                        {
                            fila["LogoEmpresa"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            fila["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                        }

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpLiquidaBenefSociales.rpt"));
                        //rptSource.SetDatabaseLogon("sa", "123456", "FRANK-PC", "SCIRERH");
                        rptSource.SetDataSource(dtLiquidaBenefSociales);
                        //20181025
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtLiquidaBenefSociales.Dispose();
                        break;

                    case "0041": /*Reporte de LIQUIDACION DE BENEFICIOS SOCIALES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        //proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        proceso_Id = "08";
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        String Planilla_Id = Request.QueryString["Planilla_Id"].ToString();

                        //objEPptoPersonal = new Ent_PptoPersonal();
                        //int result1 = Log_PptoPersonal.Lista_ActivarLevel80(objEPptoPersonal);

                        DataTable dtLiquidaBeneSociales = new DataTable();
                        DataTable dtBoletaPagos = new DataTable();
                        dtLiquidaBeneSociales = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
                        dtBoletaPagos = Log_Reportes.Lista_Boleta_Pago(personal_Id, periodo_Id, proceso_Id);

                        //20190703
                        dtLiquidaBeneSociales.Columns.Add("LogoEmp", System.Type.GetType("System.Byte[]"));
                        dtLiquidaBeneSociales.Columns.Add("imgFirma", System.Type.GetType("System.Byte[]"));
                        dtLiquidaBeneSociales.Columns.Add("Razon_Social", System.Type.GetType("System.String"));
                        dtLiquidaBeneSociales.Columns.Add("RUC", System.Type.GetType("System.String"));
                        foreach (DataRow fila in dtLiquidaBeneSociales.Rows)
                        {
                            fila["LogoEmp"] = Utils.fc_ConversionImagen(rutaLogoEmpresa);
                            fila["imgFirma"] = Utils.fc_ConversionImagen(rutaImgFirma);
                            if (dtBoletaPagos.Rows.Count > 0)
                            {
                                fila["Razon_Social"] = dtBoletaPagos.Rows[0]["Razon_Social"].ToString();
                                fila["RUC"] = dtBoletaPagos.Rows[0]["RUC"].ToString();
                            }
                        }

                        DataTable dtotrosdatos = new DataTable();
                        dtotrosdatos = Log_Reportes.Lista_DatosTruncos_Liquidacion(personal_Id, periodo_Id);

                        //20181216
                        string oval1 = "", oval2 = "", oval3 = "", oval4 = "";
                        for (int c = 0; c <= dtotrosdatos.Rows.Count - 1; c++)
                        {
                            string cod = dtotrosdatos.Rows[c][1].ToString();
                            switch (cod)
                            {
                                case "000248": oval1 = dtotrosdatos.Rows[c][2].ToString(); break;
                                case "000905": oval2 = dtotrosdatos.Rows[c][2].ToString(); break;
                                case "001243": oval3 = dtotrosdatos.Rows[c][2].ToString(); break;
                                case "001325": oval4 = dtotrosdatos.Rows[c][2].ToString(); break;
                            }
                        }
                        for (int xi = 0; xi <= dtBoletaPagos.Rows.Count - 1; xi++)
                        {
                            string xconcepto = dtBoletaPagos.Rows[xi][36].ToString().Trim();
                            switch (xconcepto)
                            {
                                case "CTS":
                                    if (oval1 != "")
                                    {
                                        string valor = dtBoletaPagos.Rows[xi][36].ToString().Trim();
                                        dtBoletaPagos.Rows[xi][36] = valor + " ( " + oval1.Split('.')[0] + " DÍAS TRUNCOS)";
                                    }; break;
                                case "VACACIONES TRUNCAS":
                                    if (oval2 != "")
                                    {
                                        string valor = dtBoletaPagos.Rows[xi][36].ToString().Trim();
                                        dtBoletaPagos.Rows[xi][36] = valor + " ( " + oval2.Split('.')[0] + " DÍAS TRUNCOS)";
                                    }; break;
                                case "GRATIFICACION ORDINARIA":
                                    if (oval3 != "")
                                    {
                                        string valor = dtBoletaPagos.Rows[xi][36].ToString().Trim();
                                        dtBoletaPagos.Rows[xi][36] = valor + " ( " + oval3.Split('.')[0] + " DÍAS TRUNCOS)";
                                    }; break;
                            }
                        }
                        //20181216 END

                        DataSet ds = new DataSet();
                        rptSource = new ReportDocument();

                        if (Planilla_Id == "02") /*Obreros*/
                        {
                            rptSource.Load(Server.MapPath("crpLiquidaBeneSociales_Obreros.rpt"));
                        }
                        else
                        { rptSource.Load(Server.MapPath("crpLiquidaBeneSociales.rpt")); }

                        rptSource.Database.Tables[0].SetDataSource(dtBoletaPagos);
                        rptSource.Database.Tables[1].SetDataSource(dtLiquidaBeneSociales);
                        if (Planilla_Id == "02") /*Obreros como no esta implementado en el reporte se comento esta seccion 09-03-2021*/
                        {
                            DataTable dtDetalleLiquida = Log_Reportes.Lista_rpt_LiquidaBeneSociales_Detalle(periodo_Id, personal_Id);
                            rptSource.Database.Tables["DetalleLiquida"].SetDataSource(dtDetalleLiquida);
                        }
                        else
                        {
                            DataTable dtRemComputable = new DataTable();
                            #region "Agrega Tabla de Rem Computable"
                            dtRemComputable.Columns.Add("Trabajador", typeof(String));
                            dtRemComputable.Columns.Add("Descripcion", typeof(String));
                            dtRemComputable.Columns.Add("CTS", typeof(String));
                            dtRemComputable.Columns.Add("Vacacion", typeof(String));
                            dtRemComputable.Columns.Add("Gratificacion", typeof(String));

                            foreach (DataRow row in dtLiquidaBeneSociales.Rows)
                            {
                                DataRow dr;
                                if (Convert.ToDecimal(row["RemPermanente"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Remuneración Permanente";
                                    dr["CTS"] = Convert.ToDecimal(row["RemPermanente"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["RemPermanente"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = Convert.ToDecimal(row["RemPermanente"]).ToString("###,###,##0.00");
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["STiempoCTS"]) != 0 && Convert.ToDecimal(row["PromHE"]) != 0 && Convert.ToDecimal(row["LiqPromSobre"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Sobretiempo";
                                    dr["CTS"] = Convert.ToDecimal(row["STiempoCTS"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["PromHE"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = Convert.ToDecimal(row["LiqPromSobre"]).ToString("###,###,##0.00");
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["ComVenCTS"]) != 0 && Convert.ToDecimal(row["PromCV"]) != 0 && Convert.ToDecimal(row["LiqPromComis"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Comisiones";
                                    dr["CTS"] = Convert.ToDecimal(row["ComVenCTS"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["PromCV"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = Convert.ToDecimal(row["LiqPromComis"]).ToString("###,###,##0.00");
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["RefrigerioCTS"]) != 0 && Convert.ToDecimal(row["Refrigerio"]) != 0 && Convert.ToDecimal(row["LiqRefrigerio"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Refrigerio";
                                    dr["CTS"] = Convert.ToDecimal(row["RefrigerioCTS"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["Refrigerio"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = Convert.ToDecimal(row["LiqRefrigerio"]).ToString("###,###,##0.00");
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["BonNoctCTS"]) != 0 && Convert.ToDecimal(row["PromBN"]) != 0 && Convert.ToDecimal(row["LiqBonifTrab"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Bonificación Nocturna";
                                    dr["CTS"] = Convert.ToDecimal(row["BonNoctCTS"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["PromBN"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = Convert.ToDecimal(row["LiqBonifTrab"]).ToString("###,###,##0.00");
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["BonProdCTS"]) != 0 && Convert.ToDecimal(row["PromBP"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Bonificación Producción";
                                    dr["CTS"] = Convert.ToDecimal(row["BonProdCTS"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["PromBP"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = "";
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["BonifTrab"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "Promedio Bonificación Trabajo";
                                    dr["CTS"] = Convert.ToDecimal(row["BonifTrab"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = Convert.ToDecimal(row["BonifTrab"]).ToString("###,###,##0.00");
                                    dr["Gratificacion"] = "";
                                    dtRemComputable.Rows.Add(dr);
                                }

                                if (Convert.ToDecimal(row["PromGrati"]) != 0)
                                {
                                    dr = dtRemComputable.NewRow();
                                    dr["Trabajador"] = row["Trabajador"].ToString();
                                    dr["Descripcion"] = "1/6 Gratificación Semestral Percibida";
                                    dr["CTS"] = Convert.ToDecimal(row["PromGrati"]).ToString("###,###,##0.00");
                                    dr["Vacacion"] = "";
                                    dr["Gratificacion"] = "";
                                    dtRemComputable.Rows.Add(dr);
                                }
                            }
                            #endregion "Agrega Tabla de Rem Computable"
                            rptSource.Database.Tables["RemComputable"].SetDataSource(dtRemComputable);
                        }


                        //20180822
                        //rptSource.SetParameterValue("logoRuta", rutaLogoEmpresa);

                        CrystalReportViewer1.ReportSource = rptSource;
                        CrystalReportViewer1.DataBind();

                        break;
                    case "0020": /*Reporte de LISTADO DE DIAS Y HORAS TRABAJADAS*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtListaDiasyHorasTrab = new DataTable();
                        dtListaDiasyHorasTrab = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpListaDiasyHorasTrab.rpt"));
                        rptSource.SetDataSource(dtListaDiasyHorasTrab);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtListaDiasyHorasTrab.Dispose();
                        break;

                    case "0024": /*Reporte de LISTADO DE INGRESOS*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtListaIngresos = new DataTable();
                        dtListaIngresos = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpListadoIngresos.rpt"));
                        rptSource.SetDataSource(dtListaIngresos);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtListaIngresos.Dispose();
                        break;

                    case "0013": /*Reporte de LISTADO DE NETOS - Planilla Mensual*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtListadoNetos = new DataTable();
                        dtListadoNetos = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("crpListadoNetos.rpt"));
                        rptSource.SetDataSource(dtListadoNetos);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtListadoNetos.Dispose();
                        break;

                    case "0015": /*Reporte de LISTADO DE PERSONAL EN ONP*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtListadoPersonalONP = new DataTable();
                        dtListadoPersonalONP = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        //rptSource.Load(Server.MapPath("crpListadoPersonalONP.rpt"));
                        rptSource.Load(Server.MapPath("Listado_ONP.rpt"));


                        rptSource.SetDataSource(dtListadoPersonalONP);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtListadoPersonalONP.Dispose();
                        break;
                    case "0036": /*Reporte de LISTAR 6 ULTIMAS REMUNERACION CTS - LEY 29352*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtListadoRemuneracionCTSLey = new DataTable();
                        dtListadoRemuneracionCTSLey = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("LISTAR_CTS_LEY.rpt"));

                        rptSource.SetDataSource(dtListadoRemuneracionCTSLey);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtListadoRemuneracionCTSLey.Dispose();
                        break;
                    case "0012": /*Reporte de PLANILLA DE PAGO DE APORTES PREVISIONALES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtPlaAportesPrevis = new DataTable();
                        dtPlaAportesPrevis = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("Plla_Aport_Previs_adic.rpt"));

                        rptSource.SetDataSource(dtPlaAportesPrevis);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtPlaAportesPrevis.Dispose();
                        break;


                    case "0009": /*Reporte de PLANILLA DE VACACIONES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtPlanillaVacaciones = new DataTable();
                        dtPlanillaVacaciones = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("Planilla_Vacaciones.rpt"));

                        rptSource.SetDataSource(dtPlanillaVacaciones);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtPlanillaVacaciones.Dispose();
                        break;
                    case "0032": /*Reporte de PROVISION ESSALUD*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtProvisionESSALUD = new DataTable();
                        dtProvisionESSALUD = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("Provision_Essalud.rpt"));

                        rptSource.SetDataSource(dtProvisionESSALUD);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtProvisionESSALUD.Dispose();
                        break;
                    case "0033": /*Reporte de PROVISION EXTORNO*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtProvisionEX = new DataTable();
                        dtProvisionEX = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("Provision_EXTORNO.rpt"));

                        rptSource.SetDataSource(dtProvisionEX);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtProvisionEX.Dispose();
                        break;
                    case "0034": /*Reporte de ASIENTOS CONTABLES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtAContables = new DataTable();
                        dtAContables = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("REPORTE_ASIENTO_CONTABLES.rpt"));

                        rptSource.SetDataSource(dtAContables);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtAContables.Dispose();
                        break;

                    case "0037": /*Reporte de RESUMEN PLANILLA POR PROCESO*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtRPProceso = new DataTable();
                        dtRPProceso = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("RESUMEN_PLANILLA_DINAMICA.rpt"));

                        rptSource.SetDataSource(dtRPProceso);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtRPProceso.Dispose();
                        break;
                    case "0035": /*Reporte de TRABAJADORES CUENTAS CORRIENTES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtTCCorrientes = new DataTable();
                        dtTCCorrientes = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("TRAB_CUENTAS_CORRIENTES.rpt"));

                        rptSource.SetDataSource(dtTCCorrientes);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtTCCorrientes.Dispose();
                        break;

                    case "0003": /*Reporte de UTILIDADES*/
                        personal_Id = Request.QueryString["personal_Id"].ToString();
                        periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        usuario_Id = "";
                        if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        DataTable dtUtilidades = new DataTable();
                        dtUtilidades = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        rptSource = new ReportDocument();
                        rptSource.Load(Server.MapPath("Utilidades.rpt"));

                        rptSource.SetDataSource(dtUtilidades);
                        CrystalReportViewer1.DisplayGroupTree = false;
                        CrystalReportViewer1.ReportSource = rptSource;
                        dtUtilidades.Dispose();
                        break;


                        //case "0040": /*Reporte de PERSONAL CONTRATADO*/
                        //    personal_Id = Request.QueryString["personal_Id"].ToString();
                        //    periodo_Id = Request.QueryString["periodo_Id"].ToString();
                        //    proceso_Id = Request.QueryString["proceso_Id"].ToString();
                        // //   ejercicio_Id = Request.QueryString["ejercicio_Id"].ToString();
                        //    usuario_Id = "";
                        //    if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                        //    DataTable dtPerContratado = new DataTable();
                        //    dtPerContratado = Log_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);

                        //    rptSource = new ReportDocument();
                        //    rptSource.Load(Server.MapPath("PersonalContratado.rpt"));

                        //    rptSource.SetDataSource(dtPerContratado);
                        //    CrystalReportViewer1.DisplayGroupTree = false;
                        //    CrystalReportViewer1.ReportSource = rptSource;
                        //    dtPerContratado.Dispose();
                        //    break;

                        //default:
                        //    Utils.fc_DisplayAlert(this, "No Se Encontró Reporte, consultar con el Administrador del Sistema.");
                        //    Utils.fc_JavaScript(this, "window.close();");
                        //    break;


                }
            }
            else
            {
                CrystalReportViewer1.Visible = false;
                //rptSource.PrintToPrinter(1, false, 1, 1);
            }
            ////}
        }
        void Page_PreRenderComplete(object sender, EventArgs e)
        {

            //System.IO.Stream streamPDF;
            //streamPDF = rptSource.ExportToStream(ExportFormatType.PortableDocFormat);

            //System.IO.MemoryStream stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.PortableDocFormat);


            //Response.Buffer = false;
            //Response.Clear();

            //Response.AddHeader("content-disposition", "attachment;filename=Exportacion.pdf");
            //Response.ContentType = "application/pdf";

            //Response.BinaryWrite(stream.ToArray());

            //Response.End();

        }


        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
            rptSource.Close();
            rptSource.Dispose();
        }
        protected void btnExporta_Click(object sender, EventArgs e)
        {
            string reporte_Id = Request.QueryString["Reporte_Id"].ToString();
            String no_archivo = "Reporte";
            switch (reporte_Id)
            {
                case "1": no_archivo = "Boleta"; break;
                case "1_Disenio": no_archivo = "Boleta"; break;
                case "1b": no_archivo = "Boleta"; break;
                case "0039": no_archivo = "Reporte CTS"; break;
                case "0004": no_archivo = "Certificado de Retencion 5ta"; break;
                case "0038": no_archivo = "Certificado de Trabajo"; break;
                case "0026": no_archivo = "Determinacion de la Deuda PDT 601"; break;
                case "0002": no_archivo = "Liquidacion CTS"; break;
                case "0005": no_archivo = "Liquidacion de Beneficios Sociales"; break;
                case "0041": no_archivo = "Liquidacion de Beneficios Sociales"; break;
                case "0020": no_archivo = "Listado de dias y horas trabajadas"; break;
                case "0024": no_archivo = "Listado de ingresos"; break;
                case "0013": no_archivo = "Listado de Netos - Planilla Mensual"; break;
                case "0015": no_archivo = "Listado de personal en ONPE"; break;
                case "0036": no_archivo = "6 Ultimas Remuneracion CTS - LEY 29352"; break;
                case "0012": no_archivo = "Planilla de pago de aportes previsionales"; break;
                case "0009": no_archivo = "Planilla de vacaciones"; break;
                case "0032": no_archivo = "Provision ESSALUD"; break;
                case "0033": no_archivo = "Provision Extorno"; break;
                case "0034": no_archivo = "Asientos contables"; break;
                case "0037": no_archivo = "Resumen planilla por proceso"; break;
                case "0035": no_archivo = "Trabajadores con cuentas corrientes"; break;
                case "0003": no_archivo = "Reporte de Utilidades"; break;
            }

            string typeExport = cboTipeExport.SelectedValue.ToString();
            Response.Buffer = false;
            Response.Clear();

            //////if (rptSource.IsLoaded) Response.Write("CARGADO");
            //////else Response.Write("SIN CARGA");
            if (typeExport == "02") { rptSource.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, no_archivo); }
            else if (typeExport == "03") { rptSource.ExportToHttpResponse(ExportFormatType.Excel, Response, true, no_archivo); }
            else if (typeExport == "04") { rptSource.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, no_archivo); }


            return;


            System.IO.Stream streamPDF;
            System.IO.MemoryStream stream;
            if (typeExport == "01")
            {
                streamPDF = rptSource.ExportToStream(ExportFormatType.CrystalReport);
                stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.CrystalReport);

                Response.Buffer = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Exportacion.rpt");
                Response.ContentType = "application/rpt";
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }

            if (typeExport == "02")
            {
                streamPDF = rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
                stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
                Response.Buffer = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Exportacion.pdf");
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            if (typeExport == "03")
            {
                streamPDF = rptSource.ExportToStream(ExportFormatType.Excel);
                stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.Excel);
                Response.Buffer = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Exportacion.xls");
                Response.ContentType = "application/xls";
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            if (typeExport == "04")
            {
                streamPDF = rptSource.ExportToStream(ExportFormatType.WordForWindows);
                stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.WordForWindows);
                Response.Buffer = false;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Exportacion.doc");
                Response.ContentType = "application/doc";
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            //////if (typeExport == "05")
            //////{
            //////    streamPDF = rptSource.ExportToStream(ExportFormatType.EditableRTF);
            //////    stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.EditableRTF);
            //////    Response.Buffer = false;
            //////    Response.Clear();
            //////    Response.AddHeader("content-disposition", "attachment;filename=Exportacion.rtf");
            //////    Response.ContentType = "application/rtf";
            //////    Response.BinaryWrite(stream.ToArray());
            //////    Response.End();
            //////}
            //////if (typeExport == "06")
            //////{
            //////    streamPDF = rptSource.ExportToStream(ExportFormatType.CharacterSeparatedValues);
            //////    stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.CharacterSeparatedValues);
            //////    Response.Buffer = false;
            //////    Response.Clear();
            //////    Response.AddHeader("content-disposition", "attachment;filename=Exportacion.csv");
            //////    Response.ContentType = "application/csv";
            //////    Response.BinaryWrite(stream.ToArray());
            //////    Response.End();
            //////}
            //////if (typeExport == "07")
            //////{
            //////    streamPDF = rptSource.ExportToStream(ExportFormatType.Xml);
            //////    stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.Xml);
            //////    Response.Buffer = false;
            //////    Response.Clear();
            //////    Response.AddHeader("content-disposition", "attachment;filename=Exportacion.xml");
            //////    Response.ContentType = "application/xml";
            //////    Response.BinaryWrite(stream.ToArray());
            //////    Response.End();
            //////}
        }
    }
}