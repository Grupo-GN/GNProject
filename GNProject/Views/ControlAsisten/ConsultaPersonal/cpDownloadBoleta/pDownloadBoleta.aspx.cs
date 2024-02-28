using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using BusienssLogic.ConsultaPersonal.oDescargarBoleta;
using CrystalDecisions.Shared;

namespace Presentacion.ConsultaPersonal.cpDownloadBoleta
{
    public partial class pDownloadBoleta : System.Web.UI.Page
    {
        ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Personal_Id = Request.QueryString["perso"]; 
            string Periodo_Id = Request.QueryString["per"]; 
            string Proceso_Id = Request.QueryString["pro"];
            int cant =int.Parse(Request.QueryString["cant"].ToString()); 
            DataTable dtBoletaPago = new DataTable();
            dtBoletaPago = controller_DownloadBoleta.Get_Instance().Get_Boleta_By_Persona_Masivo(Personal_Id, Periodo_Id, Proceso_Id, cant);
            rptSource = new ReportDocument();
            rptSource.Load(Server.MapPath("../crpBoletaPago.rpt"));
            rptSource.SetDataSource(dtBoletaPago);

            CrystalReportViewer1.ReportSource = rptSource;
            dtBoletaPago.Dispose();
        }
        void Page_PreRenderComplete(object sender, EventArgs e)
        {
            //Exporta a PDF
            Response.Buffer = false;
            Response.Clear();
            rptSource.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "BoletaPago.pdf");

            //////System.IO.Stream streamPDF;
            //////streamPDF = rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
            //////System.IO.MemoryStream stream = (System.IO.MemoryStream)rptSource.ExportToStream(ExportFormatType.PortableDocFormat);
            //////Response.Buffer = false;
            //////Response.Clear();
            //////Response.AddHeader("content-disposition", "attachment;filename=BoletadePago.pdf");
            //////Response.ContentType = "application/pdf";

            //////Response.BinaryWrite(stream.ToArray());

            Response.End();
            string script = "window.close();";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);

        }
    }
}