using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmImprimirBoleta : BasePage
    {
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            chkAcumMontos.Checked = false;
            chkAcumMontos_CheckedChanged(null, null);
        }
        //@001 F

        Ent_PptoPersonal objEPptoPersonal;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Master.UcFiltros_PostBackPeriodoChangedEventHandler += new EventHandler(MasterUcFiltros_PeriodoChangedEvent); //@001 I/F
                                                                                                                               //if (!Utils.fc_ValidaFiltros(this.Page))
                                                                                                                               //{
                                                                                                                               //    if (Request.QueryString["block"] == null)
                                                                                                                               //        Response.Redirect("~/Default.aspx?block=1");
                                                                                                                               //}

            if (!Page.IsPostBack)
            {
                cargarArea();
                Carga_combo_Procesos();
                Carga_combo_Proyecto();
                objEPptoPersonal = new Ent_PptoPersonal();
                //int result = Log_PptoPersonal.Lista_ActivarLevel80();

                cboPeriodo_Desde.Items.Clear();
                cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));

                if (Session["Periodo_Id"] != null)
                {
                    string periodo = "";
                    if (Session["Periodo_Id"] != null)
                    {
                        periodo = Session["Periodo_Id"].ToString();
                    }
                    else
                    {
                        periodo = Utils.fc_obtiene_Periodo_Id(this);
                    }
                    Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, periodo);
                    Session["Periodo_Id_Seleccionado"] = Session["Periodo_Id"].ToString();
                }
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            if (Session["Periodo_Id_Seleccionado"] == null)
                Session["Periodo_Id_Seleccionado"] = periodo_Id;
            else if (periodo_Id != Session["Periodo_Id_Seleccionado"].ToString())
            {
                Session["Periodo_Id_Seleccionado"] = periodo_Id;
                Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, periodo_Id);
                upPersonal.Update();
            }

            HighlightGridLine();

        }

        void Carga_combo_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Procesos objEProcesos = new Ent_Procesos();
            objEProcesos.Estado_Id = "01"; /*Solo Activos*/
            DataTable dtProcesos = new DataTable();
            dtProcesos = Log_Procesos.Lista_Procesos(objEProcesos);
            cboProcesos.DataSource = dtProcesos;
            cboProcesos.DataTextField = "Proceso";
            cboProcesos.DataValueField = "Proceso_Id";
            cboProcesos.DataBind();

            dtProcesos.Dispose();
        }
        //20190116
        void Carga_combo_Proyecto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Proyecto obj = new Ent_Proyecto();
            //obj.Estado_Id = "01"; /*Solo Activos*/
            DataTable dt = new DataTable();
            dt = Log_Proyecto.Lista_Proyecto(obj);
            cboProyecto.DataSource = dt;
            cboProyecto.DataTextField = "Descripcion";
            cboProyecto.DataValueField = "Proyecto_Id";
            cboProyecto.DataBind();

            cboProyecto.Items.Insert(0, new ListItem("-TODOS-", ""));
            dt.Dispose();
        }
        void Lista_Personal_Boleta(String area_Id, String nombre_Completo, String periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Personal_Activo objEPersonal = new Ent_Personal_Activo();
            objEPersonal.Periodo_Id = periodo_Id;
            if (cboArea.SelectedIndex != 0)
                objEPersonal.Area_Id = area_Id;
            if (nombre_Completo.Trim() != string.Empty)
                objEPersonal.Nombre_Completo = nombre_Completo;

            if (cboProyecto.SelectedIndex != 0)
                objEPersonal.Proyecto_Id = cboProyecto.SelectedValue.ToString();


            if (chkorden.Items.Count > 0)
            {
                for (int i = 0; i <= chkorden.Items.Count - 1; i++)
                {
                    objEPersonal.Direccion += chkorden.Items[i].Value + ",";
                }
                objEPersonal.Direccion = objEPersonal.Direccion.Remove(objEPersonal.Direccion.Length - 1, 1);
            }
            else
            {
                objEPersonal.Direccion = "";
            }

            DataTable dtPersonal = new DataTable();
            dtPersonal = Log_Personal.Lista_Personal_Boleta(objEPersonal);
            grvPersonal.DataSource = dtPersonal;
            grvPersonal.DataBind();

            lblTotPersonal.Text = dtPersonal.Rows.Count.ToString();
            dtPersonal.Dispose();
        }

        protected void grvPersonal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                string personal_Id;
                string nombre_Completo;
                personal_Id = grvPersonal.DataKeys[e.Row.RowIndex].Values["Personal_Id"].ToString();
                nombre_Completo = grvPersonal.DataKeys[e.Row.RowIndex].Values["Nombre_Completo"].ToString();
                e.Row.Attributes.Add("onclick", "fc_seleccion_Personal('" + personal_Id + "','" + nombre_Completo + "');");
                e.Row.Attributes["style"] = "cursor:pointer";

            }

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string personal_Id = "";
            ArrayList listPersonal = new ArrayList();
            string personal_Id_Masivo = "";
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    listPersonal.Add(personal_Id);
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                }
            }

            if (listPersonal.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }
            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            Session["listPersonalImprimir"] = listPersonal;
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);

            string parametros = "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id;
            string script;
            script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1&fl_Print=1" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string personal_Id = "";
            string personal_Id_Masivo = "";
            ArrayList listPersonal = new ArrayList();
            Int32 cantPersonal = 0;
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    listPersonal.Add(personal_Id);
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    cantPersonal++;
                }
            }

            if (listPersonal.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            Session["listPersonalImprimir"] = listPersonal;
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);

            string parametros = "&cantPersonal=" + cantPersonal.ToString() + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id;
            string script;
            script = "window.open('../Reportes/FrmPreview.aspx?Reporte_Id=1b" + parametros + "','Reportes','width=790,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
            /*
            string personal_Id = string.Empty;
            personal_Id = hdfPersonal_Id.Value;

            if (personal_Id.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }


            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;

            string parametros = "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id;
            string script;
            script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);*/
        }

        protected void btnImprimirPDF_AYN_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string personal_Id = string.Empty;
            string personal_Id_Masivo = "";
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    //break; //Sale del For
                }
            }

            if (personal_Id.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);

            string parametros = "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id + "&planilla_Id=" + Planilla_Id;
            string script;
            script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1_Disenio_AYN&fl_Imprimir_PDF=1" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
        }
        protected void btnImprimirPDF_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Boolean flPorPersonal = chkPorPersonal.Checked;
            List<String> lstPersonal = new List<string>();

            string personal_Id = string.Empty;
            string personal_Id_Masivo = "";
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    //break; //Sale del For

                    if (flPorPersonal)
                    {
                        lstPersonal.Add(personal_Id);
                    }
                }
            }

            if (flPorPersonal && lstPersonal.Count > 50)
            {
                Utils.fc_DisplayAlert(this, "Solo puede seleccionar 50 registros como máximo");
                return;
            }

            if (personal_Id.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            string Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);
            String Periodo_Id_Desde = cboPeriodo_Desde.SelectedValue;
            String fl_dolares = (chkDolares.Checked ? "1" : "0");
            String fl_add_tot_dolares = (chkAddTotalUSD.Checked ? "1" : "0");
            string parametros = "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id + "&planilla_Id=" + Planilla_Id + "&Periodo_Id_Desde=" + Periodo_Id_Desde + "&fl_dolares=" + fl_dolares + "&fl_add_tot_usd=" + fl_add_tot_dolares;
            string script;
            if (flPorPersonal)
            {
                string script_2 = "";
                foreach (string per in lstPersonal)
                {
                    Session["flPorPersonal"] = "1";
                    parametros = "&personal_Id=" + per + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id + "&planilla_Id=" + Planilla_Id + "&Periodo_Id_Desde=" + Periodo_Id_Desde + "&fl_dolares=" + fl_dolares + "&fl_add_tot_usd=" + fl_add_tot_dolares;
                    //script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1_Disenio&fl_Imprimir_PDF=1" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
                    //Utils.fc_JavaScript(this, script);

                    String titleWindows = "Reportes_" + Guid.NewGuid();
                    //script_2 += "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1_Disenio&fl_Imprimir_PDF=1" + parametros + "','" + titleWindows + "','width=900,height=800,scrollbars=yes');";
                    script_2 += "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1_Disenio&fl_Imprimir_PDF=1" + parametros + "','" + titleWindows + "');";
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('" + pagina + "', '_blank');", true);

                    //String key = "OpenWindow_" + DateTime.Now.ToString("yymmddHHmmss") + "_" + per;

                }
                string key = "OpenWindow";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), key, script_2, true);
            }
            else
            {
                Session["flPorPersonal"] = "0";
                script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=1_Disenio&fl_Imprimir_PDF=1" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
                Utils.fc_JavaScript(this, script);
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string personal_Id = "";
            string personal_Id_Masivo = "";
            ArrayList listPersonal = new ArrayList();
            Int32 cantPersonal = 0;
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    listPersonal.Add(personal_Id);
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    cantPersonal++;
                }
            }

            if (listPersonal.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            //20190122
            string ordenid = "";
            if (chkorden.Items.Count > 0)
            {
                for (int i = 0; i <= chkorden.Items.Count - 1; i++)
                {
                    switch (chkorden.Items[i].Value)
                    {
                        case "A.DESCRIPCION": ordenid += "Area,"; break;
                        case "PR.Descripcion": ordenid += "Proyecto,"; break;
                        default: ordenid += chkorden.Items[i].Value + ","; break;
                    }
                }
                ordenid = ordenid.Remove(ordenid.Length - 1, 1);
            }
            else
            {
                ordenid = "";
            }


            Session["listPersonalImprimir"] = listPersonal;
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);

            string parametros = "&cantPersonal=" + cantPersonal.ToString() + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id + "&orden_id=" + ordenid;
            string script;
            script = "window.open('../Reportes/FrmPreview.aspx?Reporte_Id=1" + parametros + "','Reportes','width=790,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
        }
        protected void btnPreview_Disenio_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string personal_Id = "";
            string personal_Id_Masivo = "";
            ArrayList listPersonal = new ArrayList();
            Int32 cantPersonal = 0;
            foreach (GridViewRow fila in grvPersonal.Rows)
            {
                CheckBox ck = (CheckBox)fila.FindControl("ck");
                if (ck.Checked == true)
                {
                    personal_Id = grvPersonal.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    listPersonal.Add(personal_Id);
                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    cantPersonal++;
                }
            }

            if (listPersonal.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Personal");
                return;
            }

            string periodo_Id = "";
            if (Session["Periodo_Id"] != null)
            {
                periodo_Id = Session["Periodo_Id"].ToString();
            }
            else
            {
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            }
            string proceso_Id = cboProcesos.SelectedValue;
            Session["listPersonalImprimir"] = listPersonal;
            Session["Personal_Id_Masivo"] = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);

            //20190122
            string ordenid = "";
            if (chkorden.Items.Count > 0)
            {
                for (int i = 0; i <= chkorden.Items.Count - 1; i++)
                {
                    switch (chkorden.Items[i].Value)
                    {
                        case "A.DESCRIPCION": ordenid += "Area,"; break;
                        case "PR.Descripcion": ordenid += "Proyecto,"; break;
                        default: ordenid += chkorden.Items[i].Value + ","; break;
                    }
                }
                ordenid = ordenid.Remove(ordenid.Length - 1, 1);
            }
            else
            {
                ordenid = "";
            }

            string parametros = "&cantPersonal=" + cantPersonal.ToString() + "&periodo_Id=" + periodo_Id + "&proceso_Id=" + proceso_Id + "&orden_id=" + ordenid;
            string script;
            script = "window.open('../Reportes/FrmPreview.aspx?Reporte_Id=1_Disenio" + parametros + "','Reportes','width=790,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void elLink_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }


        protected void cboorden_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void bpasar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (chkorden.Items.IndexOf(cboorden.SelectedItem) > -1)
            {
                Utils.fc_DisplayAlert(this, "El campo ya está agregado");
            }
            else
            {
                chkorden.Items.Add(cboorden.SelectedItem);
                chkorden.DataBind();
            }
        }

        protected void bborrar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            int cant = chkorden.Items.Count;
            for (int i = 0; i <= cant - 1; i++)
            {
                if (chkorden.Items[i].Selected == true)
                {
                    chkorden.Items.RemoveAt(i);
                    cant = chkorden.Items.Count;
                }
            }
        }

        protected void cboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Boleta(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }
        void cargarArea()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtArea = new DataTable();
            Ent_RH_Area objEArea = new Ent_RH_Area();
            dtArea = Log_RH_Area.Lista_RH_Area(objEArea);
            cboArea.DataSource = dtArea;
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Area_Id";
            cboArea.DataBind();

            this.cboArea.Items.Insert(0, new ListItem("Todos", String.Empty));
        }

        protected void chkPorPersonal_CheckedChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            chkAcumMontos.Checked = false;
            Mostrar_PeriodoDesde();
        }

        protected void chkAcumMontos_CheckedChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            chkPorPersonal.Checked = false;
            Mostrar_PeriodoDesde();
            //return;
            //String Periodo_Id_Selected = Utils.fc_obtiene_Periodo_Id(this);

            //Boolean fl_visible = chkAcumMontos.Checked;
            //lblPeriodo_Desde.Visible = fl_visible;
            //cboPeriodo_Desde.Visible = fl_visible;
            //lblNotaAcum.Visible = fl_visible;
            //if (chkAcumMontos.Checked && !String.IsNullOrEmpty(Periodo_Id_Selected))
            //{
            //    Ent_Periodo objEPeriodo = new Ent_Periodo();
            //    objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            //    objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
            //    objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            //    objEPeriodo.Mes_Id = "";
            //    objEPeriodo.Estado_Id = "02";
            //    DataTable dtPeriodos = Log_Periodo.Lista_Periodo(objEPeriodo);

            //    Int32 qt_periodos = dtPeriodos.Rows.Count;
            //    Int32 index_inicio = qt_periodos - 12; //Para que muestre los últimos 11 periodos
            //    List<Ent_Periodo> oLista_Periodos = new List<Ent_Periodo>();
            //    Int32 index = 0;
            //    foreach (DataRow row in dtPeriodos.Rows)
            //    {
            //        if (Convert.ToInt32(row["Periodo_Id"].ToString()) >= Convert.ToInt32(Periodo_Id_Selected))
            //        {
            //            break;
            //        }

            //        if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= index_inicio)
            //        {
            //            oLista_Periodos.Add(new Ent_Periodo
            //            {
            //                Periodo_Id = row["Periodo_Id"].ToString(),
            //                Descripcion = row["Descripcion"].ToString()
            //            });
            //        }

            //        index++;
            //    }

            //    cboPeriodo_Desde.DataSource = oLista_Periodos;
            //    cboPeriodo_Desde.DataTextField = "Descripcion";
            //    cboPeriodo_Desde.DataValueField = "Periodo_Id";
            //    cboPeriodo_Desde.DataBind();
            //    cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            //}
            //else
            //{
            //    cboPeriodo_Desde.Items.Clear();
            //    cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            //}
        }

        void Mostrar_PeriodoDesde()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Boolean flPorPersonal = chkPorPersonal.Checked;
            Boolean flAcumMontos = chkAcumMontos.Checked;

            String Periodo_Id_Selected = Utils.fc_obtiene_Periodo_Id(this);

            Boolean fl_visible = false;
            if (chkAcumMontos.Checked) { fl_visible = true; }
            else if (chkPorPersonal.Checked) { fl_visible = true; }
            lblPeriodo_Desde.Visible = fl_visible;
            cboPeriodo_Desde.Visible = fl_visible;
            lblNotaAcum.Visible = chkAcumMontos.Checked; //Solo se muestra si está habilitado la acumulacion de montos
            if ((chkAcumMontos.Checked || chkPorPersonal.Checked) && !String.IsNullOrEmpty(Periodo_Id_Selected))
            {
                Ent_Periodo objEPeriodo = new Ent_Periodo();
                objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                objEPeriodo.Mes_Id = "";
                objEPeriodo.Estado_Id = "02";
                DataTable dtPeriodos = Log_Periodo.Lista_Periodo(objEPeriodo);

                DataRow[] drowFind = dtPeriodos.Select("Periodo_Id = " + Periodo_Id_Selected);
                Int32 inx_Selected_fin = dtPeriodos.Rows.IndexOf(drowFind[0]);
                Int32 inx_inicio = inx_Selected_fin - 11; //Para que muestre los últimos 11 periodos

                //Int32 qt_periodos = dtPeriodos.Rows.Count;
                //Int32 index_inicio = qt_periodos - 12; //Para que muestre los últimos 11 periodos
                List<Ent_Periodo> oLista_Periodos = new List<Ent_Periodo>();
                Int32 index = 0;
                foreach (DataRow row in dtPeriodos.Rows)
                {
                    //if (Convert.ToInt32(row["Periodo_Id"].ToString()) >= Convert.ToInt32(Periodo_Id_Selected))
                    //{
                    //    break;
                    //}

                    //if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= index_inicio)
                    if (row["Periodo_Id"].ToString() != Periodo_Id_Selected && index >= inx_inicio && index <= inx_Selected_fin)
                    {
                        oLista_Periodos.Add(new Ent_Periodo
                        {
                            Periodo_Id = row["Periodo_Id"].ToString(),
                            Descripcion = row["Descripcion"].ToString()
                        });
                    }

                    index++;
                }

                cboPeriodo_Desde.DataSource = oLista_Periodos;
                cboPeriodo_Desde.DataTextField = "Descripcion";
                cboPeriodo_Desde.DataValueField = "Periodo_Id";
                cboPeriodo_Desde.DataBind();
                cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            }
            else
            {
                cboPeriodo_Desde.Items.Clear();
                cboPeriodo_Desde.Items.Insert(0, new ListItem("-Seleccione-", ""));
            }
        }

        protected void chkDolares_CheckedChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Boolean flMostrarTotalUSD = chkDolares.Checked;
            chkAddTotalUSD.Visible = !flMostrarTotalUSD;
            chkAddTotalUSD.Checked = false;
        }
    }
}