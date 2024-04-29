using CAPA_ENTIDAD;
using CAPA_LOGICO;
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

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class FrmRptContratados : System.Web.UI.Page
    {
        Ent_PptoPersonal objEPptoPersonal;
        //Log_PptoPersonal objLPptoPersonal;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                //ReportViewer1.ShowExportControls = false;
                //ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                // this can be set with control itself.
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri(@"http://localhost/reportserver");
                //ReportViewer1.ServerReport.ReportPath = @"/Report Project1/Report2";

                DropDownList1.Items.Add(new ListItem("Word", "Word"));
                DropDownList1.Items.Add(new ListItem("Excel", "Excel"));
                DropDownList1.Items.Add(new ListItem("Acrobat (PDF) file", "PDF"));


                if (Request.QueryString["fl_Print"] == null)
                {

                    string reporte_Id = Request.QueryString["Reporte_Id"].ToString();

                    string ejercicio_Id, periodo_Id, proceso_Id, personal_Id;
                    ReportDataSource rptsource;
                    ReportDataSource rptsource2;
                    ReportDataSource rptsourceR;

                    ReportDataSource rptsource3;
                    ReportDataSource rptsource4;

                    string usuario_Id;
                    string rutaLogoEmpresa, razonSocialEmpresa, RUCEmpresa;
                    rutaLogoEmpresa = "";
                    razonSocialEmpresa = "Lima Gas";
                    RUCEmpresa = "20100007348";
                    switch (reporte_Id)
                    {


                        case "0040": /*Reporte de Contratados*/
                            ejercicio_Id = Request.QueryString["ejercicio_Id"].ToString();
                            DataTable dtPerContratado = new DataTable();
                            DataTable dtPerCant = new DataTable();
                            DataTable dtPerContratadoR = new DataTable();

                            objEPptoPersonal = new Ent_PptoPersonal();

                            int result = Log_PptoPersonal.Lista_ActivarPivot(objEPptoPersonal);
                            Log_Sustentos.SET_COMPATIBILITY_LEVEL(90);
                            dtPerContratado = Log_Reportes.Lista_rpt_Reporte(ejercicio_Id);

                            dtPerCant = Log_Reportes.Lista_rpt_ReporteCant(ejercicio_Id);
                            dtPerContratadoR = Log_Reportes.Lista_rpt_Reporte_Resumen(ejercicio_Id);
                            Log_Sustentos.SET_COMPATIBILITY_LEVEL(80);


                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptPerContratado.rdlc");

                            rptsource = new ReportDataSource("dsPerContratado_PerContratado", dtPerContratado);
                            rptsource2 = new ReportDataSource("dsPerContratado_PerCant", dtPerCant);
                            rptsourceR = new ReportDataSource("dsPerContratado_PerContratadoRes", dtPerContratadoR);
                            ReportViewer1.LocalReport.DataSources.Add(rptsource);
                            ReportViewer1.LocalReport.DataSources.Add(rptsource2);
                            ReportViewer1.LocalReport.DataSources.Add(rptsourceR);
                            //Log_PptoPersonal.Lista_ActivarLevel80();
                            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptGraficaPptoPersonal.rdlc");
                            break;





                    }
                }
                else
                {
                    ReportViewer1.Visible = false;
                }
            }
        }


        void Page_PreRenderComplete(object sender, EventArgs e)
        {


            ReportPrintHelper oPrint = new ReportPrintHelper();
            //oPrint.RenderToPDF(ref ReportViewer1, EXPORT_TYPE.TYPE_XLS, this.Context, false);
            oPrint.RenderToExcel(ref ReportViewer1, EXPORT_TYPE.TYPE_XLS, this.Context, true);


        }
        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}