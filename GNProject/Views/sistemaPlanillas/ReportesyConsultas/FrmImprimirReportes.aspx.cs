using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmImprimirReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    if (Request.QueryString["block"] == null)
            //        Response.Redirect("~/Default.aspx?block=1");
            //}

            if (!Page.IsPostBack)
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
                //cboArea.cargarCombo("", "Todos");
                Carga_combo_Personal(periodo);
                //Lista_Personal(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
                Lista_Reportes();
                Session["Periodo_Id_Seleccionado"] = periodo;
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

            //string periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            if (Session["Periodo_Id_Seleccionado"] == null)
                Session["Periodo_Id_Seleccionado"] = periodo_Id;
            else if (periodo_Id != Session["Periodo_Id_Seleccionado"].ToString())
            {
                Session["Periodo_Id_Seleccionado"] = periodo_Id;
                Carga_combo_Personal(periodo_Id);
                //Lista_Personal(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
                //updPersonal.Update();
                //updPersonalCombo.Update();
            }
        }

        void Carga_combo_Personal(String periodo_Id)
        {
            Ent_Personal_Activo objEPersonal_Activo = new Ent_Personal_Activo();
            objEPersonal_Activo.Periodo_Id = periodo_Id;
            DataTable dtPersonal = new DataTable();
            dtPersonal = Log_Personal.Lista_Personal_ImprimirReporte(objEPersonal_Activo);
            cboPersonal.DataSource = dtPersonal;
            cboPersonal.DataTextField = "Nombre_Completo";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
            dtPersonal.Dispose();
            cboPersonal.Items.Insert(0, new ListItem("--Todos--", "0"));
        }

        //void Lista_Personal(String area_Id, String nombre_Completo, String periodo_Id)
        //{
        //    Ent_Personal objEPersonal = new Ent_Personal();
        //    objEPersonal._Periodo_Id = periodo_Id;
        //    if (cboArea.SelectedIndex != 0)
        //        objEPersonal._Area_Id = area_Id;
        //    if (nombre_Completo.Trim() != string.Empty)
        //        objEPersonal.Nombre_Completo = nombre_Completo;

        //    DataTable dtPersonal = new DataTable();
        //    dtPersonal = Log_Personal.Lista_Personal(objEPersonal);
        //    grvPersonal.DataSource = dtPersonal;
        //    grvPersonal.DataBind();

        //    lblTotPersonal.Text = dtPersonal.Rows.Count.ToString();
        //    dtPersonal.Dispose();
        //}

        void Lista_Reportes()
        {
            DataTable dtReportes = new DataTable();
            dtReportes = Log_Reportes.Lista_Reportes();

            // tvwReportes.ForeColor = System.Drawing.Color.Black;

            TreeNode nodoReportes = new TreeNode("<font color = red>" + "REPORTES" + "</font>");
            nodoReportes.SelectAction = TreeNodeSelectAction.Expand;
            nodoReportes.Expanded = true;
            TreeNode nodo1 = new TreeNode();
            TreeNode nodo2 = new TreeNode();
            string categoria;
            string titulo;
            categoria = string.Empty;
            titulo = string.Empty;
            foreach (DataRow dr in dtReportes.Rows)
            {
                if (categoria != dr["Categoria"].ToString())
                {
                    titulo = dr["Titulo"].ToString();
                    //nodo2 = new TreeNode(titulo, dr["Reporte_Id"].ToString());
                    nodo2 = new TreeNode("<font color = black>" + titulo + " - " + dr["Reporte_Id"].ToString() + "</font>", dr["Reporte_Id"].ToString());
                    // nodo2 = new TreeNode("<font color = black>" + titulo + " - " + dr["Reporte_Id"].ToString() + "</font>", dr["Reporte_Id"].ToString());

                    categoria = dr["Categoria"].ToString();
                    //nodo1 = new TreeNode("<font color = black>" + categoria + "</font>", "");

                    nodo1 = new TreeNode("<font color = blue>" + categoria + "</font>", "");
                    //nodo1 = new TreeNode(categoria, "");

                    //nodo2.ChildNodes.Add(new TreeNode("text", "value", "imageURL", "navigateURL", "_self"));
                    nodo1.ChildNodes.Add(nodo2);
                    nodoReportes.ChildNodes.Add(nodo1);
                    //tvwReportes.Nodes.Add(nodo1);

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.Select;

                }
                else
                {
                    if (titulo != dr["Titulo"].ToString())
                    {
                        titulo = dr["Titulo"].ToString();
                        nodo2 = new TreeNode("<font color = black>" + titulo + "</font>", dr["Reporte_Id"].ToString());
                        //nodo2 = new TreeNode("<font color = black>" + titulo + " - " + dr["Reporte_Id"].ToString() + "</font>", dr["Reporte_Id"].ToString());
                        nodo1.ChildNodes.Add(nodo2);
                    }
                    //nodo2.ChildNodes.Add(new TreeNode("text", "value", "imageURL", "navigateURL", "_self"));

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.Select;
                }
            }
            tvwReportes.Nodes.Add(nodoReportes);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //Lista_Personal(cboArea.SelectedValue, txtNombre_Completo.Text, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            if (tvwReportes.SelectedNode == null)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Reporte.");
            }
            else
            {
                string reporte_Id;
                reporte_Id = tvwReportes.SelectedNode.Value.ToString();
                //Utils.fc_DisplayAlert(this, idReporte);
                string personal_Id;
                personal_Id = cboPersonal.SelectedValue;
                string ejercicio_Id;
                ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                string periodo_Id = "";
                if (Session["Periodo_Id"] != null)
                {
                    periodo_Id = Session["Periodo_Id"].ToString();
                }
                else
                {
                    periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                }

                string parametros = "?Reporte_Id=" + reporte_Id + "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=01";
                string script;
                script = "window.open('../Reportes/FrmPrint.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=900,height=800,scrollbars=yes');";
                Utils.fc_JavaScript(this, script);
            }
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {

            if (tvwReportes.SelectedNode == null)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Reporte.");
            }
            else
            {
                string reporte_Id;
                reporte_Id = tvwReportes.SelectedNode.Value.ToString();
                string personal_Id;
                personal_Id = cboPersonal.SelectedValue;
                string ejercicio_Id;
                ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                string periodo_Id = "";
                //if (Session["Periodo_Id"] != null)
                //{
                //    periodo_Id = Session["Periodo_Id"].ToString();
                //}
                //else
                //{
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                //}

                String Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);

                if (reporte_Id == "0040")
                {
                    string parametros = "?Reporte_Id=" + reporte_Id + "&ejercicio_Id=" + ejercicio_Id + "&proceso_Id=01";
                    string script;
                    script = "window.open('../Reportes/FrmRptContratados.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=900,height=800,scrollbars=yes');";
                    Utils.fc_JavaScript(this, script);
                    //string FileStrean = "../Reportes/frmRptContratados.aspx";
                    //string Clientscript = "AbrirModal('" + FileStrean + "?Reporte_Id=" + reporte_Id  + "&Ejercicio_Id=" + ejercicio_Id + "&pTipo_Proceso=2')";
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
                }
                //if (reporte_Id == "0005")
                //{
                //    string parametros = "?Reporte_Id=" + reporte_Id + "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=08";
                //    string script;
                //    script = "window.open('../Reportes/FrmRptContratados.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=900,height=800,scrollbars=yes');";
                //    Utils.fc_JavaScript(this, script);
                //    //string FileStrean = "../Reportes/frmRptContratados.aspx";
                //    //string Clientscript = "AbrirModal('" + FileStrean + "?Reporte_Id=" + reporte_Id  + "&Ejercicio_Id=" + ejercicio_Id + "&pTipo_Proceso=2')";
                //    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
                //}
                if (reporte_Id == "0029" || reporte_Id == "0030" || reporte_Id == "0031")
                {

                    string FileStrean = "../Reportes/frmProvisiones.aspx";
                    string Clientscript = "AbrirModal('" + FileStrean + "?Reporte_Id=" + reporte_Id + "&Periodo_Id=" + periodo_Id + "&Personal_Id=" + personal_Id + "&pTipo_Proceso=2')";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
                }
                else if (reporte_Id == "0010" || reporte_Id == "0007" || reporte_Id == "0001" || reporte_Id == "0008")
                {

                    string FileStrean = "../Reportes/frmPlanillas.aspx";
                    string Clientscript = "AbrirModal('" + FileStrean + "?Reporte_Id=" + reporte_Id + "&Periodo_Id=" + periodo_Id + "&Personal_Id=" + personal_Id + "&pTipo_Proceso=2')";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
                }
                else
                {
                    string parametros = "?Reporte_Id=" + reporte_Id + "&personal_Id=" + personal_Id + "&periodo_Id=" + periodo_Id + "&proceso_Id=01&Planilla_Id=" + Planilla_Id;
                    string script;
                    if (reporte_Id == "0024") /*Reporte Horizontal*/
                        script = "window.open('../Reportes/FrmPreview.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=1170,height=800,scrollbars=yes');";
                    else
                        script = "window.open('../Reportes/FrmPreview.aspx" + parametros + "&fl_Imprimir_PDF=0','Reportes','width=790,height=800,scrollbars=yes');";
                    Utils.fc_JavaScript(this, script);
                }
            }
        }

        protected void tvwReportes_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {


        }
        protected void tvwReportes_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}