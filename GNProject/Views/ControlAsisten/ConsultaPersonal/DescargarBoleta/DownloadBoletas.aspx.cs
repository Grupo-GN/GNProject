using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using BusienssLogic.ConsultaPersonal.oDescargarBoleta;
namespace Presentacion.ConsultaPersonal.DescargarBoleta
{
    public partial class DownloadBoletas : System.Web.UI.Page
    {
        ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {            
            

            #region PERSONAL

            string url = Request.QueryString["downloadid"];


            string Personal_Id = "";
            string Periodo_Id = "";
            string Proceso_Id = "";
            int i=0;
            while(i<=16){
                Personal_Id += url.Substring(i, 1);
                i = i + 3;
            }            
            while (i <= 29)
            {
                Periodo_Id += url.Substring(i, 1);
                i = i + 3;
            }
            while (i <= 35)
            {
                Proceso_Id += url.Substring(i, 1);
                i = i + 3;
            }
            #endregion

            DataTable dtBoletaPago = new DataTable();
            dtBoletaPago = controller_DownloadBoleta.Get_Instance().Get_Boleta_By_Personal(Personal_Id, Periodo_Id, Proceso_Id);
            rptSource = new ReportDocument();
            rptSource.Load(Server.MapPath("../crpBoletaPago.rpt"));
            rptSource.SetDataSource(dtBoletaPago);
            
            CrystalReportViewer1.ReportSource = rptSource;
            dtBoletaPago.Dispose();
        }
         void Page_PreRenderComplete(object sender, EventArgs e)
          {
              System.IO.Stream streamPDF;
              streamPDF = rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
              System.IO.MemoryStream stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
              Response.Buffer = false;
              Response.Clear();
              Response.AddHeader("content-disposition", "attachment;filename=BoletadePago.pdf");
              Response.ContentType = "application/pdf";

              Response.BinaryWrite(stream.ToArray());

              Response.End();
            string script = "window.close();";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true) ;

          }
         protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
         {
             /*rptSource.Close();
             rptSource.Dispose();*/
         }

    }
}