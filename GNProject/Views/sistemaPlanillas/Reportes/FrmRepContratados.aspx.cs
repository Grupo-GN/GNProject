using CAPA_LOGICO;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class FrmRepContratados : System.Web.UI.Page
    {
        // ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.Dispose();
            if (Request.QueryString["fl_Print"] == null)
            {
                string reporte_Id = Request.QueryString["Reporte_Id"].ToString();
                string personal_Id_Masivo, personal_Id, periodo_Id, proceso_Id, ejercicio_Id;
                Int32 cantPersonal;
                //ReportDocument rptSource;
                DataTable dt;
                ReportDataSource rptsource;

                string usuario_Id;
                //////string rutaLogoEmpresa, razonSocialEmpresa, RUCEmpresa;
                //////rutaLogoEmpresa = Server.MapPath("../Imgs/LogoEmpresa.png");
                //////razonSocialEmpresa = "Lima Gas";
                //////RUCEmpresa = "20100007348";
                switch (reporte_Id)
                {
                    //case "0040": /*Reporte de PERSONAL CONTRATADO*/

                    //    //personal_Id = Request.QueryString["personal_Id"].ToString();
                    //    ejercicio_Id = Request.QueryString["ejercicio_Id"].ToString();
                    //    //   ejercicio_Id = Request.QueryString["ejercicio_Id"].ToString();
                    //    usuario_Id = "";
                    //  //  if (personal_Id == "0") personal_Id = "%"; //Para TODOS
                    //    DataTable dtPerContratado = new DataTable();
                    //    dtPerContratado = Log_Reportes.Lista_rpt_Reporte(ejercicio_Id);

                    //    rptSource = new ReportDocument();
                    //   // rptSource.Load(Server.MapPath("PersonalContratado.rpt"));
                    //    rptSource.Load(Server.MapPath("rptPerContratado.rdlc"));
                    //    rptSource.SetDataSource(dtPerContratado);
                    //    CrystalReportViewer1.DisplayGroupTree = false;
                    //    CrystalReportViewer1.ReportSource = rptSource;
                    //    dtPerContratado.Dispose();
                    //    break;


                    case "0040": /*Reporte de CARTA CTS A BANCO*/
                        ejercicio_Id = Request.QueryString["ejercicio_Id"].ToString();
                        DataTable dtPerContratado = new DataTable();

                        dtPerContratado = Log_Reportes.Lista_rpt_Reporte(ejercicio_Id);

                        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptPerContratado.rdlc");
                        rptsource = new ReportDataSource("dsCartaCTSBanco_CartaCTSBanco", dtPerContratado);
                        //   ReportViewer1.LocalReport.DataSources.Add(rptsource);
                        break;

                    default:
                        Utils.fc_DisplayAlert(this, "No Se Encontró Reporte, consultar con el Administrador del Sistema.");
                        Utils.fc_JavaScript(this, "window.close();");
                        break;
                }
            }
            else
            {
                CrystalReportViewer1.Visible = false;
                //rptSource.PrintToPrinter(1, false, 1, 1);
            }

        }
    }
}