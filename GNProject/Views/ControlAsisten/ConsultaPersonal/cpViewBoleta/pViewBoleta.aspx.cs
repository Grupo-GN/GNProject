using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusienssLogic.ConsultaPersonal.oDescargarBoleta;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Presentacion.ConsultaPersonal.cpViewBoleta
{
    public partial class pViewBoleta : System.Web.UI.Page
    {
        ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {

            string Personal_Id = Request.QueryString["perso"];
            string Periodo_Id = Request.QueryString["per"];
            string Proceso_Id = Request.QueryString["pro"];
            int cant = int.Parse(Request.QueryString["cant"].ToString()); 

            DataTable dtBoletaPago = new DataTable();
            dtBoletaPago = controller_DownloadBoleta.Get_Instance().Get_Boleta_By_Persona_Masivo(Personal_Id, Periodo_Id, Proceso_Id, cant);
            rptSource = new ReportDocument();
            rptSource.Load(Server.MapPath("../crpBoletaPago.rpt"));
            rptSource.SetDataSource(dtBoletaPago);

            CrystalReportViewer1.ReportSource = rptSource;
            dtBoletaPago.Dispose();

            //Exporta a PDF
            Response.Buffer = false;
            Response.Clear();
            rptSource.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "BoletaPago.pdf");

            //using (var mStream = (MemoryStream)rptSource.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
            //{
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.ContentType = "application/pdf";
            //    Response.BinaryWrite(mStream.ToArray());
            //}
            //Response.End();
               
        }
    }
}