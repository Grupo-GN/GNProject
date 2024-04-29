using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class PrintAsiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string reporte_Id = Request.QueryString["Reporte_Id"].ToString();

                String str_parametros = String.Empty;
                String[] arr_parametros = null;
                str_parametros = Request.QueryString["prm"].ToString();
                arr_parametros = new String[str_parametros.Split(':').Length];
                arr_parametros = str_parametros.Split(':');
                DataTable dt = new DataTable();
                dt = CAPA_DATOS.controller_ConcarReport.get_Instance().Get_ExportacionPlanilas_General_Ms(arr_parametros[0], arr_parametros[1]);
                gridAsiento.DataSource = dt;
                gridAsiento.DataBind();
            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            exportaExcel_n1(gridAsiento);
        }
        #region exportarExcel
        void exportaExcel_n1(GridView migv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            migv.EnableViewState = false;

            //// Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            //// Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(migv);

            for (int i = 0; i < migv.Rows.Count; i++)
            {
                GridViewRow row = migv.Rows[i];
                row.Cells[1].Attributes.Add("class", "text");
                row.Cells[2].Attributes.Add("class", "text");
                row.Cells[3].Attributes.Add("class", "text");
                row.Cells[4].Attributes.Add("class", "text");
                row.Cells[5].Attributes.Add("class", "text");
            }



            Response.Clear();
            page.RenderControl(htw);
            string style = @"<style> .text { mso-number-format:\@; } </style>";
            Response.Write(style);

            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=AsientoContable.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }
        #endregion
    }
}