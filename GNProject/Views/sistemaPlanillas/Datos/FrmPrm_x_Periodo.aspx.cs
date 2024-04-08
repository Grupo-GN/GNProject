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
    public partial class FrmPrm_x_Periodo : BasePage
    {
        Ent_Prm_Periodo objEPrm_Periodo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    //if (Request.QueryString["block"] == null)
            //        Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //    Response.Redirect("~/Default.aspx");
            //        //return;
            //}

            if (!Page.IsPostBack)
            {
                Carga_combo_Periodo();
                cboPeriodo.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);
                //Lista_Prm_Periodo(cboPeriodo.SelectedValue);
            }
            HighlightGridLine();
        }

        void Carga_combo_Periodo()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
            cboPeriodo.DataSource = Log_Periodo.Lista_Periodo(objEPeriodo);
            cboPeriodo.DataTextField = "Descripcion";
            cboPeriodo.DataValueField = "Periodo_Id";
            cboPeriodo.DataBind();
        }

        private void Lista_Prm_Periodo(string Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPrm_Periodo = new Ent_Prm_Periodo();
                objEPrm_Periodo.Periodo_Id = Periodo_Id;
                DataTable dtPrm_Periodo = new DataTable();
                dtPrm_Periodo = Log_Prm_Periodo.Lista_Prm_Periodo(objEPrm_Periodo);
                //Utils.fc_Adecua_GridView(grvLista, dtPrm_Periodo.Rows.Count);
                grvLista.DataSource = dtPrm_Periodo;
                grvLista.DataBind();

                if (dtPrm_Periodo.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtPrm_Periodo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Periodo(cboPeriodo.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Periodo(cboPeriodo.SelectedValue);
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Prm_Periodo(cboPeriodo.SelectedValue);
        }

        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");

                if (txtValor != null)
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                double algo = double.Parse(txtValor.Text);
                txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture);

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            //    e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            //}

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
                string periodo_Id = "";
                string concepto_Id;
                //Decimal valor;
                string uhm = "";

                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                DataTable dtRpta;
                foreach (GridViewRow row in grvLista.Rows)
                {
                    periodo_Id = grvLista.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text; //valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    /*Inicio--por mientras hasta que se desarrole masivamente*/
                    //dtRpta = new DataTable();
                    //objEPrm_Periodo = new Ent_Prm_Periodo();
                    //objEPrm_Periodo.Periodo_Id = periodo_Id;
                    //objEPrm_Periodo.Concepto_Id = concepto_Id;
                    //objEPrm_Periodo.Valor = valor;
                    //dtRpta = Log_Prm_Periodo.Actualiza_Prm_Periodo(objEPrm_Periodo);
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
                objEPrm_Periodo = new Ent_Prm_Periodo();
                objEPrm_Periodo.Periodo_Id = periodo_Id;
                objEPrm_Periodo.Concepto_Id_Masivo = concepto_Id_Masivo;
                objEPrm_Periodo.Valor_Masivo = valor_Masivo;
                dtRpta = Log_Prm_Periodo.Actualiza_Prm_Periodo_Masivo(objEPrm_Periodo, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Periodo(cboPeriodo.SelectedValue);
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
                string periodo_Id;
                periodo_Id = cboPeriodo.SelectedValue;

                objEPrm_Periodo = new Ent_Prm_Periodo();
                objEPrm_Periodo.Periodo_Id = periodo_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Prm_Periodo.Inserta_Prm_Periodo_Genera(objEPrm_Periodo);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Periodo(cboPeriodo.SelectedValue);
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
            Lista_Prm_Periodo(cboPeriodo.SelectedValue);
        }
    }
}