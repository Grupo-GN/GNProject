using GNProject.Acceso;
using GNProject.Assets.ctrlDoc.resources;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GNProject.Assets.ctrlDoc.resources.ReportPrintHelper;

namespace GNProject.Views.ctrlDoc.Reportes
{
    public partial class FrmPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = Page.User.Identity.Name;
            if (String.IsNullOrEmpty(user) == true)
            {
                displayAlert("No ha iniciado sesión");
                String strKey = "__keyClose__";
                String Script = "<script languaje='javascript' type='text/javascript'>window.close();</script>";
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), strKey, Script, false);
                return;
            }
            if (!Page.IsPostBack)
            {
                String cod_reporte = String.Empty;
                String str_parametros = String.Empty;
                String[] arr_parametros = null;
                cod_reporte = Request.QueryString["cod"].ToString();
                cod_reporte = Encryptar.Desencripta(cod_reporte);
                if (Request.QueryString["prm"] != null)
                {
                    str_parametros = Request.QueryString["prm"].ToString();

                    /*
                     * Si se envía en la URL un simbolo "+" el QueryString lo interpreta como espacio, por eso se vuelve a reemplazar el espacio por "+"
                     * Esto sucede ya que la funcion encriptar puede generar como parte de los códigos un simbolo "+" y cuando desencripta sale error
                    */
                    str_parametros = str_parametros.Replace(" ", "+");

                    str_parametros = Encryptar.Desencripta(str_parametros);
                    arr_parametros = new String[str_parametros.Split('|').Length];
                    arr_parametros = str_parametros.Split('|');
                }

                ReportDataSource dataSource = null;
                ReportParameter oParam = null;

                //INICIO - Para mostrar Logo de Empresa
                //String imagefilePath = Parametros.CDOC_Ruta_LogoEmpresa;
                //System.Drawing.Image image = System.Drawing.Image.FromFile(imagefilePath);
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                //image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //Byte[] imageByte = ms.ToArray();
                //ms.Dispose();
                //ms.Close();
                //
                DataTable dtEmpresa = new DataTable();
                //dtEmpresa.Columns.Add("logo_empresa", Type.GetType("System.Byte[]"));
                //DataRow dr = dtEmpresa.NewRow();
                //dr["logo_empresa"] = imageByte;
                //dtEmpresa.Rows.Add(dr);

                ReportDataSource dataSourceEmpresa;
                //FIN - Para mostrar Logo de Empresa

                switch (cod_reporte)
                {
                    case Parametros.CDOC_Reportes.RepSegDocumentos:
                        //////hdf_ind_pdf.Value = "0";
                        ReportViewer1.LocalReport.ReportPath = "Views/ctrlDoc/Reportes/rptSegDocumentos.rdlc";

                        Assets.ctrlDoc.resources.dsSegDocumentosTableAdapters.dtSegDocumentosTableAdapter tablaSegDocumentos = new Assets.ctrlDoc.resources.dsSegDocumentosTableAdapters.dtSegDocumentosTableAdapter();
                        dsSegDocumentos.dtSegDocumentosDataTable datosReporteSegDocumentos = tablaSegDocumentos.GetData(0, arr_parametros[6], arr_parametros[7], Convert.ToInt32(arr_parametros[8]), arr_parametros[9]
                            , arr_parametros[10], arr_parametros[11]
                            , arr_parametros[12], arr_parametros[13], arr_parametros[14]
                            , arr_parametros[15], Convert.ToInt32(arr_parametros[16]), Convert.ToInt32(arr_parametros[17])
                            , ClaseGlobal.Get_IdUsuario_usuario()
                        );

                        oParam = new ReportParameter("prmNomUsuario", ClaseGlobal.Get_login_usuario());
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        oParam = new ReportParameter("prmTextoArea", Parametros.CDOC_Texto_Area);
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        oParam = new ReportParameter("prmTextoSeccion", Parametros.CDOC_Texto_Seccion);
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        dataSource = new ReportDataSource("dtSegDocumentos", datosReporteSegDocumentos.ToList());
                        ReportViewer1.LocalReport.DataSources.Add(dataSource);

                        dataSourceEmpresa = new ReportDataSource("dtEmpresa", dtEmpresa);
                        ReportViewer1.LocalReport.DataSources.Add(dataSourceEmpresa);
                        break;
                    case Parametros.CDOC_Reportes.RepSegDocumentos_Det:
                        ReportViewer1.LocalReport.ReportPath = "Views/ctrlDoc/Reportes/rptSegDocumentos_Det.rdlc";
                        ReportViewer1.LocalReport.EnableHyperlinks = true;
                        Assets.ctrlDoc.resources.dsSegDocumentos_DetTableAdapters.dtSegDocumentos_DetTableAdapter tablaSegDocumentos_Det = new Assets.ctrlDoc.resources.dsSegDocumentos_DetTableAdapters.dtSegDocumentos_DetTableAdapter();
                        dsSegDocumentos_Det.dtSegDocumentos_DetDataTable datosReporteSegDocumentos_Det = tablaSegDocumentos_Det.GetData(0, arr_parametros[6], arr_parametros[7], Convert.ToInt32(arr_parametros[8]), arr_parametros[9]
                            , arr_parametros[10], arr_parametros[11]
                            , arr_parametros[12], arr_parametros[13], arr_parametros[14]
                            , arr_parametros[15], Convert.ToInt32(arr_parametros[16]), Convert.ToInt32(arr_parametros[17])
                            , ClaseGlobal.Get_IdUsuario_usuario()
                        );

                        oParam = new ReportParameter("prmNomUsuario", ClaseGlobal.Get_login_usuario());
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        oParam = new ReportParameter("prmTextoArea", Parametros.CDOC_Texto_Area);
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        oParam = new ReportParameter("prmTextoSeccion", Parametros.CDOC_Texto_Seccion);
                        ReportViewer1.LocalReport.SetParameters(oParam);

                        dataSource = new ReportDataSource("dtSegDocumentos_Det", datosReporteSegDocumentos_Det.ToList());
                        ReportViewer1.LocalReport.DataSources.Add(dataSource);

                        dataSourceEmpresa = new ReportDataSource("dtEmpresa", dtEmpresa);
                        ReportViewer1.LocalReport.DataSources.Add(dataSourceEmpresa);

                        //--
                        //dsSegDocumentos_DetTableAdapters.dtSegDocumentos_Det_FileTableAdapter tablaSegDocumentos_Det_File = new dsSegDocumentos_DetTableAdapters.dtSegDocumentos_Det_FileTableAdapter();
                        //dsSegDocumentos_Det.dtSegDocumentos_Det_FileDataTable datosReporteSegDocumentos_Det_File = tablaSegDocumentos_Det_File.GetData(0, arr_parametros[5], Convert.ToInt32(arr_parametros[6]), arr_parametros[7]
                        //    , arr_parametros[8], Convert.ToInt32(arr_parametros[9])
                        //    , arr_parametros[10], arr_parametros[11], arr_parametros[12], 0
                        //    , "1"
                        //);
                        //dataSource = new ReportDataSource("dtSegDocumentos_Det_File", datosReporteSegDocumentos_Det_File.ToList());
                        //ReportViewer1.LocalReport.DataSources.Add(dataSource);

                        //dsSegDocumentos_DetTableAdapters.dtSegDocumentos_Det_CaracteristicaTableAdapter tablaSegDocumentos_Det_Caracteristica = new dsSegDocumentos_DetTableAdapters.dtSegDocumentos_Det_CaracteristicaTableAdapter();
                        //dsSegDocumentos_Det.dtSegDocumentos_Det_CaracteristicaDataTable datosReporteSegDocumentos_Det_Caracteristica = tablaSegDocumentos_Det_Caracteristica.GetData(0, arr_parametros[5], Convert.ToInt32(arr_parametros[6]), arr_parametros[7]
                        //    , arr_parametros[8], Convert.ToInt32(arr_parametros[9])
                        //    , arr_parametros[10], arr_parametros[11], arr_parametros[12], 0
                        //    , "2"
                        //);
                        //dataSource = new ReportDataSource("dtSegDocumentos_Det_Caracteristica", datosReporteSegDocumentos_Det_Caracteristica.ToList());
                        //ReportViewer1.LocalReport.DataSources.Add(dataSource);
                        //--
                        break;

                    default:
                        displayAlert("No se encuetra el reporte. Consultar con el Administrador del Sistema.");
                        String strKey = "__keyClose__";
                        String Script = "<script languaje='javascript' type='text/javascript'>window.close();</script>";
                        ScriptManager.RegisterStartupScript(this.Page, typeof(Page), strKey, Script, false);
                        break;
                }

                return;

            }
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            if (Request.QueryString["fl_print_PDF"] != null)
            {
                bool fl_Imprimir = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_print_PDF"]));
                if (fl_Imprimir == true)
                {
                    ReportPrintHelper oPrint = new ReportPrintHelper();
                    oPrint.RenderToPDF(ref ReportViewer1, EXPORT_TYPE.TYPE_PDF, this.Context, false);
                    //oPrint.RenderToExcel(ref ReportViewer1, EXPORT_TYPE.TYPE_XLS, this.Context, true);
                    //oPrint.RenderToWord(ref ReportViewer1, EXPORT_TYPE.TYPE_WORD, this.Context, true);
                }
            }
            else if (Request.QueryString["fl_print_EXCEL"] != null)
            {
                bool fl_Imprimir = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_print_EXCEL"]));
                if (fl_Imprimir == true)
                {
                    ReportPrintHelper oPrint = new ReportPrintHelper();
                    oPrint.RenderToExcel(ref ReportViewer1, EXPORT_TYPE.TYPE_XLS, this.Context, true);
                }
            }
            else if (Request.QueryString["fl_print_WORD"] != null)
            {
                bool fl_Imprimir = Convert.ToBoolean(Convert.ToInt32(Request.QueryString["fl_print_WORD"]));
                if (fl_Imprimir == true)
                {
                    ReportPrintHelper oPrint = new ReportPrintHelper();
                    oPrint.RenderToWord(ref ReportViewer1, EXPORT_TYPE.TYPE_WORD, this.Context, true);
                }
            }
        }

        private void displayAlert(String msg_alerta)
        {
            String strKey = "__keyAlert__";
            String Script = "<script languaje='javascript' type='text/javascript'>alert('" + msg_alerta + "');</script>";
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), strKey, Script, false);
        }
    }
}