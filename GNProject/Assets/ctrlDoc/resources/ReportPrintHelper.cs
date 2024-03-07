using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GNProject.Assets.ctrlDoc.resources
{
    public class ReportPrintHelper
    {
        public enum EXPORT_TYPE
        {
            TYPE_PDF = 1,
            TYPE_XLS = 2,
            TYPE_WORD = 3
        }
        public ReportPrintHelper()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void RenderToPDF(ref Microsoft.Reporting.WebForms.ReportViewer oViewer, EXPORT_TYPE ExportType, System.Web.HttpContext oContext, bool bDownloadAttachment)
        {
            string deviceInfo = null;
            deviceInfo = "<DeviceInfo><SimplePageHeaders>True</SimplePageHeaders></DeviceInfo>";
            Microsoft.Reporting.WebForms.ReportViewer viewer = default(Microsoft.Reporting.WebForms.ReportViewer);
            viewer = oViewer;

            if (ExportType == EXPORT_TYPE.TYPE_PDF)
            {
                //Export to PDF
                //byte[] pdfContent = viewer.LocalReport.Render("PDF", deviceInfo, null, null, null, null, null);
                string mimeType = String.Empty;
                string encoding = String.Empty;
                string extension = String.Empty;
                string[] streamIDs = null;
                Microsoft.Reporting.WebForms.Warning[] warnings = null;
                byte[] pdfContent = viewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding,
                    out extension, out streamIDs, out warnings);

                //Return PDF
                oContext.Response.Clear();
                oContext.Response.ContentType = "application/pdf";

                if (bDownloadAttachment == true)
                {
                    String noReporte = oViewer.LocalReport.ReportPath;
                    string[] arrResult = noReporte.Split('/');
                    String result = arrResult[arrResult.GetUpperBound(0)];
                    arrResult = result.Split('.');
                    result = arrResult[arrResult.GetLowerBound(0)];
                    noReporte = result;

                    String fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    noReporte = String.Format("{0}_{1}", noReporte, fecha);

                    //oContext.Response.AddHeader("Content-disposition", "attachment; filename=ExpenseReport.pdf");
                    oContext.Response.AddHeader("Content-disposition", "attachment; filename=" + noReporte + ".pdf");
                }

                oContext.Response.BinaryWrite(pdfContent);
                oContext.Response.End();
            }

            //TODO: ADD EXCEL RENDERING
        }

        public void RenderToExcel(ref Microsoft.Reporting.WebForms.ReportViewer oViewer, EXPORT_TYPE ExportType, System.Web.HttpContext oContext, bool bDownloadAttachment)
        {
            Microsoft.Reporting.WebForms.ReportViewer viewer = default(Microsoft.Reporting.WebForms.ReportViewer);
            viewer = oViewer;

            if (ExportType == EXPORT_TYPE.TYPE_XLS)
            {
                //byte[] XLSContent = viewer.LocalReport.Render("EXCEL", null, null, null, null, null, null);
                string deviceInfo = null;
                string mimeType = String.Empty;
                string encoding = String.Empty;
                string extension = String.Empty;
                string[] streamIDs = null;
                Microsoft.Reporting.WebForms.Warning[] warnings = null;
                byte[] XLSContent = viewer.LocalReport.Render("EXCEL", deviceInfo, out mimeType, out encoding,
                    out extension, out streamIDs, out warnings);
                //Return EXCEL
                oContext.Response.Clear();
                oContext.Response.ContentType = "application/vnd.ms-excel";

                if (bDownloadAttachment == true)
                {
                    String noReporte = oViewer.LocalReport.ReportPath;
                    string[] arrResult = noReporte.Split('/');
                    String result = arrResult[arrResult.GetUpperBound(0)];
                    arrResult = result.Split('.');
                    result = arrResult[arrResult.GetLowerBound(0)];
                    noReporte = result;

                    String fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    noReporte = String.Format("{0}_{1}", noReporte, fecha);

                    //oContext.Response.AddHeader("Content-disposition", "attachment; filename=ExpenseReport.xls");
                    oContext.Response.AddHeader("Content-disposition", "attachment; filename=" + noReporte + ".xls");
                }

                oContext.Response.BinaryWrite(XLSContent);
                oContext.Response.End();
            }
        }

        public void RenderToWord(ref Microsoft.Reporting.WebForms.ReportViewer oViewer, EXPORT_TYPE ExportType, System.Web.HttpContext oContext, bool bDownloadAttachment)
        {
            Microsoft.Reporting.WebForms.ReportViewer viewer = default(Microsoft.Reporting.WebForms.ReportViewer);
            viewer = oViewer;

            if (ExportType == EXPORT_TYPE.TYPE_WORD)
            {
                //byte[] XLSContent = viewer.LocalReport.Render("EXCEL", null, null, null, null, null, null);
                string deviceInfo = null;
                string mimeType = String.Empty;
                string encoding = String.Empty;
                string extension = String.Empty;
                string[] streamIDs = null;
                Microsoft.Reporting.WebForms.Warning[] warnings = null;
                byte[] XLSContent = viewer.LocalReport.Render("WORD", deviceInfo, out mimeType, out encoding,
                    out extension, out streamIDs, out warnings);
                //Return WORD
                oContext.Response.Clear();
                oContext.Response.ContentType = "application/msword";

                //////switch (FileExtension.ToLower())
                //////{
                //////    case "pdf":
                //////        Response.ContentType = "application/pdf";
                //////        break;
                //////    case "doc":
                //////        Response.ContentType = "application/msword";
                //////        break;
                //////    case "docx":
                //////        Response.ContentType = "application/vnd.ms-word.document.12";
                //////        break;
                //////    case "xls":
                //////        Response.ContentType = "application/vnd.ms-excel";
                //////        break;
                //////    case "xlsx":
                //////        Response.ContentType = "application/vnd.ms-excel.12";
                //////        break;
                //////    default:
                //////        Response.ContentType = "image/jpeg";
                //////        break;
                //////}

                if (bDownloadAttachment == true)
                {
                    String noReporte = oViewer.LocalReport.ReportPath;
                    string[] arrResult = noReporte.Split('/');
                    String result = arrResult[arrResult.GetUpperBound(0)];
                    arrResult = result.Split('.');
                    result = arrResult[arrResult.GetLowerBound(0)];
                    noReporte = result;

                    String fecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    noReporte = String.Format("{0}_{1}", noReporte, fecha);

                    //oContext.Response.AddHeader("Content-disposition", "attachment; filename=ExpenseReport.doc");
                    oContext.Response.AddHeader("Content-disposition", "attachment; filename=" + noReporte + ".doc");
                }

                oContext.Response.BinaryWrite(XLSContent);
                oContext.Response.End();
            }
        }
    }
}