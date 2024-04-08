using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Datos
{
    public partial class FrmPrm_x_Planilla : BasePage
    {
        Ent_Prm_Planilla objEPrm_Planilla;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //   // if (Request.QueryString["block"] == null)
            //        Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //        return;
            //    //Response.Redirect("~/Default.aspx");
            //}

            if (!Page.IsPostBack)
            {
                //Carga_combo_Planilla(Utils.fc_obtiene_Compania_Id(this));
                // Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
            }
            HighlightGridLine();
        }

        void Carga_combo_Planilla(string compania_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Planilla objEPlanilla = new Ent_Planilla();
            objEPlanilla.Compania_Id = compania_Id;
            objEPlanilla.Estado_Id = "01"; /*Solo Activos*/
            cboPlanilla.DataSource = Log_Planilla.Lista_Planilla(objEPlanilla);
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
        }

        private void Lista_Prm_Planilla(string Periodo_Id, string Planilla_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPrm_Planilla = new Ent_Prm_Planilla();
                objEPrm_Planilla.Periodo_Id = Periodo_Id;
                objEPrm_Planilla.Planilla_Id = Planilla_Id;
                DataTable dtPrm_Planilla = new DataTable();
                dtPrm_Planilla = Log_Prm_Planilla.Lista_Prm_Planilla(objEPrm_Planilla);
                Utils.fc_Adecua_GridView(grvLista, dtPrm_Planilla.Rows.Count);
                grvLista.DataSource = dtPrm_Planilla;
                grvLista.DataBind();

                if (dtPrm_Planilla.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtPrm_Planilla.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
        }

        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");

                if (txtValor != null)
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                double algo = double.Parse(txtValor.Text);
                txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture);

            }
        }

        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grvLista.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string Planilla_Id;
                string periodo_Id = "";
                string concepto_Id;
                //Decimal valor;
                string uhm = "";

                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                Planilla_Id = cboPlanilla.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grvLista.Rows)
                {
                    periodo_Id = grvLista.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text;//valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    /*Inicio--por mientras hasta que se desarrole masivamente*/
                    //dtRpta = new DataTable();
                    //objEPrm_Planilla = new Ent_Prm_Planilla();
                    //objEPrm_Planilla.Periodo_Id = periodo_Id;
                    //objEPrm_Planilla.Concepto_Id = concepto_Id;
                    //objEPrm_Planilla.Valor = valor;
                    //dtRpta = Log_Prm_Planilla.Actualiza_Prm_Planilla(objEPrm_Planilla);
                    /*Fin--por mientras hasta que se desarrole masivamente*/

                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + uhm + "|";
                    cont = cont + 1;
                }

                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objEPrm_Planilla = new Ent_Prm_Planilla();
                objEPrm_Planilla.Periodo_Id = periodo_Id;
                objEPrm_Planilla.Planilla_Id = Planilla_Id;
                objEPrm_Planilla.Concepto_Id_Masivo = concepto_Id_Masivo;
                objEPrm_Planilla.Valor_Masivo = valor_Masivo;
                dtRpta = Log_Prm_Planilla.Actualiza_Prm_Planilla_Masivo(objEPrm_Planilla, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Planilla_Id;
                string periodo_Id;
                Planilla_Id = cboPlanilla.SelectedValue;
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                objEPrm_Planilla = new Ent_Prm_Planilla();
                objEPrm_Planilla.Periodo_Id = periodo_Id;
                objEPrm_Planilla.Planilla_Id = Planilla_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Prm_Planilla.Inserta_Prm_Planilla_Genera(objEPrm_Planilla);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
                }
                dtRpta.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvLista_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Planilla(Utils.fc_obtiene_Periodo_Id(this), cboPlanilla.SelectedValue);
        }
        protected void cboPlanilla_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_combo_Planilla(Utils.fc_obtiene_Compania_Id(this));
            cboPlanilla.SelectedValue = Utils.fc_obtiene_Planilla_Id(this);
        }
    }
}