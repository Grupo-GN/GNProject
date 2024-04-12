using CAPA_ENTIDAD;
using CAPA_LOGICO;
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

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmReporteIncidencias : System.Web.UI.Page
    {
        Ent_D_Fijos objED_Fijos;
        Ent_Reporte_Incidencias objE_RIncidencias;
        protected void cboPersonal_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LlenaGrilla_Incidencias_d_fijos(cboPersonal.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
                Carga_combo_Personal2(Utils.fc_obtiene_Periodo_Id(this));
                Carga_combo_PersonalActivo(Utils.fc_obtiene_Periodo_Id(this));
            }
        }
        void Carga_combo_Personal(string Periodo_Id)
        {
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal.DataTextField = "Nombre_Completo-Personal_Id";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void elLink_Click(object sender, EventArgs e)
        {
            Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
        }
        protected void grv_Incidencias_d_fijos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            grv_In_d_fijos.PageIndex = e.NewSelectedIndex;
            LlenaGrilla_Incidencias_d_fijos(cboPersonal.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));

        }

        void LlenaGrilla_Incidencias_d_fijos(string personal, string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("concepto", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));

            objE_RIncidencias = new Ent_Reporte_Incidencias();
            objE_RIncidencias.Personal_id = personal;
            objE_RIncidencias.Periodo_Id = periodo;
            dt = Log_Reportes_Incidencias.Lista_Conceptos(objE_RIncidencias);

            for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
            {
                objE_RIncidencias.Concepto_Id = dt.Rows[i][0].ToString();
                dt1 = Log_Reportes_Incidencias.Lista_Incidencias_Personal_d_fijos(objE_RIncidencias);
                if (dt1.Rows.Count != 0)
                {

                    DataRow dr = dt2.NewRow();
                    dr["Fecha"] = dt1.Rows[0][0];
                    dr["Usuario"] = dt1.Rows[0][1];
                    dr["Proceso"] = dt1.Rows[0][2];
                    dr["concepto"] = dt.Rows[i][1];
                    dr["campo"] = dt1.Rows[0][3];
                    dr["DatoHistorio"] = dt1.Rows[0][4];
                    dr["DatoActual"] = dt1.Rows[0][5];

                    dt2.Rows.Add(dr);


                }
                dt1.Rows.Clear();
            }
            grv_In_d_fijos.DataSource = dt2;
            grv_In_d_fijos.DataBind();

        }
        protected void cboPersonal2_SelectedIndexChanged(object sender, EventArgs e)
        {
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            objE_RIncidencias.Personal_id = cboPersonal2.SelectedValue;
            grv_Inc_personal.DataSource = Log_Reportes_Incidencias.Lista_Incidencias_Personal(objE_RIncidencias);
            grv_Inc_personal.DataBind();

        }
        void Carga_combo_Personal2(string Periodo_Id)
        {
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal2.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal2.DataTextField = "Nombre_Completo-Personal_Id";
            cboPersonal2.DataValueField = "Personal_Id";
            cboPersonal2.DataBind();
        }
        void Carga_combo_PersonalActivo(string Periodo_Id)
        {
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal_activo.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal_activo.DataTextField = "Nombre_Completo-Personal_Id";
            cboPersonal_activo.DataValueField = "Personal_Id";
            cboPersonal_activo.DataBind();
        }
        protected void cboPersonal_activo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenaGrilla_Incidencias_Personal_activo(cboPersonal_activo.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));

        }
        void LlenaGrilla_Incidencias_Personal_activo(string personal, string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("Periodo", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));

            objE_RIncidencias = new Ent_Reporte_Incidencias();
            objE_RIncidencias.Personal_id = personal;
            objE_RIncidencias.Periodo_Id = periodo;
            dt = Log_Reportes_Incidencias.Lista_Incidencias_Personal_Activo(objE_RIncidencias);

            for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
            {
                DataRow dr = dt2.NewRow();
                dr["Fecha"] = dt.Rows[i][0];
                dr["Usuario"] = dt.Rows[i][1];
                dr["Proceso"] = dt.Rows[i][2];
                dr["Periodo"] = periodo;
                dr["campo"] = dt.Rows[i][3];
                dr["DatoHistorio"] = dt.Rows[i][4];
                dr["DatoActual"] = dt.Rows[i][5];
                dt2.Rows.Add(dr);
            }
            grvPersonalActivo.DataSource = dt2;
            grvPersonalActivo.DataBind();
            dt2.Clear();
            dt.Clear();

        }

        protected void cboMostrarPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMostrarPersonal.SelectedValue.ToString() == "0")
            {
                Carga_combo_PersonalActivo(Utils.fc_obtiene_Periodo_Id(this));
            }
            else
            {
                filtrar_Personal("Personal_activo", cboPersonal_activo);

            }
        }
        void filtrar_Personal(string tabla, DropDownList cbo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Personal_Id", typeof(string));
            dt2.Columns.Add("Nombre_Completo-Personal_Id", typeof(string));

            Ent_Personal objEPersonal = new Ent_Personal();
            objE_RIncidencias = new Ent_Reporte_Incidencias();

            objE_RIncidencias.Tabla = tabla;

            dt1 = Log_Reportes_Incidencias.Filtar_Personal(objE_RIncidencias);
            for (Int32 i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                objEPersonal._Personal_Id = dt1.Rows[i][0].ToString();
                dt = Log_Personal.Lista_Personal(objEPersonal);
                if (dt.Rows.Count != 0)
                {
                    DataRow dr = dt2.NewRow();
                    dt = Log_Personal.Lista_Personal(objEPersonal);
                    dr["Personal_Id"] = dt.Rows[0][0];
                    dr["Nombre_Completo-Personal_Id"] = dt.Rows[0][5];
                    dt2.Rows.Add(dr);

                }
            }
            cbo.DataTextField = "Nombre_Completo-Personal_Id";
            cbo.DataValueField = "Personal_Id";
            cbo.DataSource = dt2;
            cbo.DataBind();
            dt2.Clear();
            dt.Clear();
        }
        protected void cboFiltrarPersonal_P_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltrarPersonal_P.SelectedValue.ToString() == "0")
            {
                Carga_combo_Personal2(Utils.fc_obtiene_Periodo_Id(this));
            }
            else
            {
                filtrar_Personal("Personal", cboPersonal2);

            }
        }
        protected void cboMostarPersonal_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMostarPersonal_D.SelectedValue.ToString() == "0")
            {
                Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
            }
            else
            {
                filtrar_Personal("D_fijos", cboPersonal);

            }
        }
        protected void cboPersonal_activo_PreRender(object sender, EventArgs e)
        {
            LlenaGrilla_Incidencias_Personal_activo(cboPersonal_activo.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void cboPersonal_PreRender(object sender, EventArgs e)
        {
            LlenaGrilla_Incidencias_d_fijos(cboPersonal.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }
        protected void cboPersonal2_PreRender(object sender, EventArgs e)
        {
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            objE_RIncidencias.Personal_id = cboPersonal2.SelectedValue;
            grv_Inc_personal.DataSource = Log_Reportes_Incidencias.Lista_Incidencias_Personal(objE_RIncidencias);
            grv_Inc_personal.DataBind();
        }
        protected void TabIncidencias_PreRender(object sender, EventArgs e)
        {

        }
        protected void grv_In_d_fijos_PreRender(object sender, EventArgs e)
        {
            if (grv_In_d_fijos.Rows.Count != 0)
            {
                btnExportar1.Enabled = true;
            }
            else
            {
                btnExportar1.Enabled = false;
            }
        }
        protected void grvPersonalActivo_PreRender(object sender, EventArgs e)
        {
            if (grvPersonalActivo.Rows.Count != 0)
            {
                btnExportar3.Enabled = true;
            }
            else
            {
                btnExportar3.Enabled = false;
            }
        }
        protected void grv_Inc_personal_PreRender(object sender, EventArgs e)
        {
            if (grv_Inc_personal.Rows.Count != 0)
            {
                btnexportar2.Enabled = true;
            }
            else
            {
                btnexportar2.Enabled = false;
            }
        }
        protected void btnexportar2_Click(object sender, EventArgs e)
        {

            //exportaExcel(grv_Inc_personal, "IncidenciasPersonal");
            LlenaGrillaExportar_Personal(cboPersonal2.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));

        }

        void LlenaGrillaExportar_D_Fijos(string PersonalId, string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Personal_ID", typeof(string));
            dt2.Columns.Add("Nombres-Apellidos", typeof(string));
            dt2.Columns.Add("Periodo", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("concepto", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            Ent_Personal objEPersonal = new Ent_Personal();
            if (PersonalId.ToString() != "")
            {

                objE_RIncidencias.Personal_id = PersonalId;
                objE_RIncidencias.Periodo_Id = periodo;
                dt = Log_Reportes_Incidencias.Lista_Conceptos(objE_RIncidencias);
                objEPersonal._Personal_Id = PersonalId;
                DataTable dtp = new DataTable();
                dtp = Log_Personal.Lista_Personal(objEPersonal);
                for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    objE_RIncidencias.Concepto_Id = dt.Rows[i][0].ToString();
                    dt1 = Log_Reportes_Incidencias.Lista_Incidencias_Personal_d_fijos(objE_RIncidencias);
                    if (dt1.Rows.Count != 0)
                    {

                        DataRow dr = dt2.NewRow();
                        dr["Fecha"] = dt1.Rows[0][0];
                        dr["Personal_ID"] = PersonalId;
                        dr["Nombres-Apellidos"] = dtp.Rows[0][4];
                        dr["Periodo"] = periodo;
                        dr["Usuario"] = dt1.Rows[0][1];
                        dr["Proceso"] = dt1.Rows[0][2];
                        dr["concepto"] = dt.Rows[i][1];
                        dr["campo"] = dt1.Rows[0][3];
                        dr["DatoHistorio"] = dt1.Rows[0][4];
                        dr["DatoActual"] = dt1.Rows[0][5];

                        dt2.Rows.Add(dr);


                    }

                }
                // GridExportar.DataSource = dt2;
                // GridExportar.DataBind();
                //exportaExcel(GridExportar, "Incidencias-Datos-Fijos-" + PersonalId);
                exportaExcel2(dt2, "Incidencias-Datos-Fijos-" + PersonalId);
            }
            else
            {
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();

                objE_RIncidencias.Tabla = "D_fijos";
                dt1 = Log_Reportes_Incidencias.Filtar_Personal(objE_RIncidencias);
                for (Int32 i = 0; i <= dt1.Rows.Count - 1; i++)
                {
                    objEPersonal._Personal_Id = dt1.Rows[i][0].ToString();
                    dt = Log_Personal.Lista_Personal(objEPersonal);

                    objE_RIncidencias.Periodo_Id = periodo;
                    objE_RIncidencias.Personal_id = objEPersonal._Personal_Id;
                    dt3 = Log_Reportes_Incidencias.Lista_Conceptos(objE_RIncidencias);
                    for (Int32 x = 0; x <= dt3.Rows.Count - 1; x++)
                    {
                        objE_RIncidencias.Concepto_Id = dt3.Rows[x][0].ToString();
                        dt4 = Log_Reportes_Incidencias.Lista_Incidencias_Personal_d_fijos(objE_RIncidencias);
                        if (dt4.Rows.Count != 0)
                        {
                            DataRow dr = dt2.NewRow();
                            dr["Fecha"] = dt4.Rows[0][0];
                            dr["Personal_ID"] = dt.Rows[0][0].ToString();
                            dr["Nombres-Apellidos"] = dt.Rows[0][4];
                            dr["Periodo"] = periodo;
                            dr["Usuario"] = dt4.Rows[0][1];
                            dr["Proceso"] = dt4.Rows[0][2];
                            dr["concepto"] = dt3.Rows[i][1];
                            dr["campo"] = dt4.Rows[0][3];
                            dr["DatoHistorio"] = dt4.Rows[0][4];
                            dr["DatoActual"] = dt4.Rows[0][5];

                            dt2.Rows.Add(dr);
                        }

                    }

                }

                //GridExportar.DataSource = dt2;
                //GridExportar.DataBind();
                exportaExcel2(dt2, "Incidencias-Datos_fijos-Perido-" + periodo);


            }



        }
        //#region exportarExcel1
        //void exportaExcel(GridView migv,string titulo)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    StringWriter sw = new StringWriter(sb);
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);

        //    Page page = new Page();
        //    HtmlForm form = new HtmlForm();

        //    migv.EnableViewState = false;

        //    //// Deshabilitar la validación de eventos, sólo asp.net 2
        //    page.EnableEventValidation = false;

        //    //// Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        //    page.DesignerInitialize();

        //    page.Controls.Add(form);
        //    form.Controls.Add(migv);

        //    page.RenderControl(htw);

        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.ContentType = "application/vnd.ms-excel";
        //    Response.AddHeader("Content-Disposition", "attachment;filename=" + titulo + ".xls");
        //    Response.Charset = "UTF-8";
        //    Response.ContentEncoding = Encoding.Default;
        //    Response.Write(sb.ToString());
        //    Response.End();

        //}
        //#endregion
        protected void btnExportar1_Click(object sender, EventArgs e)
        {

            //exportaExcel(grv_In_d_fijos, "IncidenciasDatosFijos");
            LlenaGrillaExportar_D_Fijos(cboPersonal.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            //exportaExcel(GridExportar, "Incidencias-Datos-Fijos-Periodo-" + Utils.fc_obtiene_Periodo_Id(this));

        }
        protected void btnExportar3_Click(object sender, EventArgs e)
        {
            //exportaExcel(grvPersonalActivo, "IncidenciasPersonalActivo");
            LlenaGrillaExportar_Personal_Activo(cboPersonal_activo.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }
        void exportaExcel2(DataTable dt, string titulo)
        {
            GridView migv = new GridView();

            migv.DataSource = dt;
            migv.DataBind();
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

            page.RenderControl(htw);

            Response.Clear();

            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + titulo + ".xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }
        protected void btnExportarTodo_Click(object sender, EventArgs e)
        {
            LlenaGrillaExportar_D_Fijos("", Utils.fc_obtiene_Periodo_Id(this));
        }
        void LlenaGrillaExportar_Personal(string PersonalId, string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Personal_ID", typeof(string));
            dt2.Columns.Add("Nombres-Apellidos", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            Ent_Personal objEPersonal = new Ent_Personal();
            if (PersonalId.ToString() != "")
            {

                objE_RIncidencias.Personal_id = PersonalId;
                objE_RIncidencias.Periodo_Id = periodo;
                objEPersonal._Personal_Id = PersonalId;
                DataTable dtp = new DataTable();
                dtp = Log_Personal.Lista_Personal(objEPersonal);
                dt = Log_Reportes_Incidencias.Lista_Incidencias_Personal(objE_RIncidencias);
                for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow dr = dt2.NewRow();
                    dr["Fecha"] = dt.Rows[i][0];
                    dr["Personal_ID"] = PersonalId;
                    dr["Nombres-Apellidos"] = dtp.Rows[0][4];
                    dr["Usuario"] = dt.Rows[i][1];
                    dr["Proceso"] = dt.Rows[i][2];
                    dr["campo"] = dt.Rows[i][3];
                    dr["DatoHistorio"] = dt.Rows[i][4];
                    dr["DatoActual"] = dt.Rows[i][5];
                    dt2.Rows.Add(dr);

                }
                // GridExportar.DataSource = dt2;
                // GridExportar.DataBind();
                //exportaExcel(GridExportar, "Incidencias-Datos-Fijos-" + PersonalId);
                exportaExcel2(dt2, "Incidencias-Personal-ID-" + PersonalId);
            }
            else
            {
                DataTable dt3 = new DataTable();


                objE_RIncidencias.Tabla = "Personal";
                dt = Log_Reportes_Incidencias.Filtar_Personal(objE_RIncidencias);
                for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    objEPersonal._Personal_Id = dt.Rows[i][0].ToString();
                    dt3 = Log_Personal.Lista_Personal(objEPersonal);

                    objE_RIncidencias.Personal_id = objEPersonal._Personal_Id;

                    dt1 = Log_Reportes_Incidencias.Lista_Incidencias_Personal(objE_RIncidencias);
                    for (Int32 x = 0; x <= dt1.Rows.Count - 1; x++)
                    {


                        DataRow dr = dt2.NewRow();
                        dr["Fecha"] = dt1.Rows[x][0];
                        dr["Personal_ID"] = dt.Rows[i][0].ToString();
                        dr["Nombres-Apellidos"] = dt3.Rows[0][4];
                        dr["Usuario"] = dt1.Rows[x][1];
                        dr["Proceso"] = dt1.Rows[x][2];
                        dr["campo"] = dt1.Rows[x][3];
                        dr["DatoHistorio"] = dt1.Rows[x][4];
                        dr["DatoActual"] = dt1.Rows[x][5];

                        dt2.Rows.Add(dr);

                    }

                }

                //GridExportar.DataSource = dt2;
                //GridExportar.DataBind();
                exportaExcel2(dt2, "Incidencias-Personal");


            }



        }
        protected void btnExportarTodoPersonal_Click(object sender, EventArgs e)
        {
            LlenaGrillaExportar_Personal("", Utils.fc_obtiene_Periodo_Id(this));
        }
        void LlenaGrillaExportar_Personal_Activo(string PersonalId, string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Personal_ID", typeof(string));
            dt2.Columns.Add("Nombres-Apellidos", typeof(string));
            dt2.Columns.Add("Periodo", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            Ent_Personal objEPersonal = new Ent_Personal();
            if (PersonalId.ToString() != "")
            {

                objE_RIncidencias.Personal_id = PersonalId;
                objE_RIncidencias.Periodo_Id = periodo;
                objEPersonal._Personal_Id = PersonalId;
                DataTable dtp = new DataTable();
                dtp = Log_Personal.Lista_Personal(objEPersonal);
                dt = Log_Reportes_Incidencias.Lista_Incidencias_Personal_Activo(objE_RIncidencias);
                for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow dr = dt2.NewRow();
                    dr["Fecha"] = dt.Rows[i][0];
                    dr["Personal_ID"] = PersonalId;
                    dr["Nombres-Apellidos"] = dtp.Rows[0][4];
                    dr["Periodo"] = periodo;
                    dr["Usuario"] = dt.Rows[i][1];
                    dr["Proceso"] = dt.Rows[i][2];
                    dr["campo"] = dt.Rows[i][3];
                    dr["DatoHistorio"] = dt.Rows[i][4];
                    dr["DatoActual"] = dt.Rows[i][5];
                    dt2.Rows.Add(dr);

                }
                // GridExportar.DataSource = dt2;
                // GridExportar.DataBind();
                //exportaExcel(GridExportar, "Incidencias-Datos-Fijos-" + PersonalId);
                exportaExcel2(dt2, "Incidencias-Personal-Activo-ID-" + PersonalId);
            }
            else
            {
                DataTable dt3 = new DataTable();


                objE_RIncidencias.Tabla = "Personal";
                dt = Log_Reportes_Incidencias.Filtar_Personal(objE_RIncidencias);
                for (Int32 i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    objEPersonal._Personal_Id = dt.Rows[i][0].ToString();
                    dt3 = Log_Personal.Lista_Personal(objEPersonal);

                    objE_RIncidencias.Personal_id = objEPersonal._Personal_Id;
                    objE_RIncidencias.Periodo_Id = periodo;
                    dt1 = Log_Reportes_Incidencias.Lista_Incidencias_Personal_Activo(objE_RIncidencias);
                    for (Int32 x = 0; x <= dt1.Rows.Count - 1; x++)
                    {
                        DataRow dr = dt2.NewRow();
                        dr["Fecha"] = dt1.Rows[x][0];
                        dr["Personal_ID"] = dt.Rows[i][0].ToString();
                        dr["Nombres-Apellidos"] = dt3.Rows[0][4];
                        dr["Periodo"] = periodo;
                        dr["Usuario"] = dt1.Rows[i][1];
                        dr["Proceso"] = dt1.Rows[x][2];
                        dr["campo"] = dt1.Rows[x][3];
                        dr["DatoHistorio"] = dt1.Rows[x][4];
                        dr["DatoActual"] = dt1.Rows[x][5];

                        dt2.Rows.Add(dr);

                    }

                }

                //GridExportar.DataSource = dt2;
                //GridExportar.DataBind();
                exportaExcel2(dt2, "Incidencias-Personal-Activo-Periodo-" + periodo);


            }



        }
        protected void btnExportarTodoActivo_Click(object sender, EventArgs e)
        {
            LlenaGrillaExportar_Personal_Activo("", Utils.fc_obtiene_Periodo_Id(this));
        }
    }
}