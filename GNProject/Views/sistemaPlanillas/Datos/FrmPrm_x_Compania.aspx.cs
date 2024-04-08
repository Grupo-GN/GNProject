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
    public partial class FrmPrm_x_Compania : BasePage
    {
        Ent_Prm_Cia objEPrm_Cia;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //   // if (Request.QueryString["block"] == null)
            //        Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //    Response.Redirect("~/Default.aspx");
            //  //      return;
            //}

            if (!Page.IsPostBack)
            {
                Carga_combo_Compania();
                cboCompania.SelectedValue = Utils.fc_obtiene_Compania_Id(this);
                //Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
            }
            HighlightGridLine();
        }

        void Carga_combo_Compania()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Compania objECompania = new Ent_Compania();
            cboCompania.DataSource = Log_Compania.Lista_Compania(objECompania);
            cboCompania.DataTextField = "Descripcion";
            cboCompania.DataValueField = "Compania_Id";
            cboCompania.DataBind();
        }

        private void Lista_Prm_Cia(String Periodo_Id, String Compania_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPrm_Cia = new Ent_Prm_Cia();
                objEPrm_Cia.Periodo_Id = Periodo_Id;
                objEPrm_Cia.Compania_Id = Compania_Id;
                DataTable dtPrm_Cia = new DataTable();
                dtPrm_Cia = Log_Prm_Cia.Lista_Prm_Cia(objEPrm_Cia);
                Utils.fc_Adecua_GridView(grvLista, dtPrm_Cia.Rows.Count);
                grvLista.DataSource = dtPrm_Cia;
                grvLista.DataBind();

                if (dtPrm_Cia.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtPrm_Cia.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboCompania_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
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
                string compania_Id;
                string periodo_Id = "";
                string concepto_Id;
                //Decimal valor;
                string uhm = "";

                String concepto_Id_Masivo = "";
                String valor_Masivo = "";
                Int32 cont = 0;

                compania_Id = cboCompania.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grvLista.Rows)
                {
                    periodo_Id = grvLista.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == String.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text;//valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    /*Inicio--por mientras hasta que se desarrole masivamente*/
                    //dtRpta = new DataTable();
                    //objEPrm_Cia = new Ent_Prm_Cia();
                    //objEPrm_Cia.Periodo_Id = periodo_Id;
                    //objEPrm_Cia.Concepto_Id = concepto_Id;
                    //objEPrm_Cia.Valor = valor;
                    //dtRpta = Log_Prm_Cia.Actualiza_Prm_Cia(objEPrm_Cia);
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
                objEPrm_Cia = new Ent_Prm_Cia();
                objEPrm_Cia.Periodo_Id = periodo_Id;
                objEPrm_Cia.Compania_Id = compania_Id;
                objEPrm_Cia.Concepto_Id_Masivo = concepto_Id_Masivo;
                objEPrm_Cia.Valor_Masivo = valor_Masivo;
                dtRpta = Log_Prm_Cia.Actualiza_Prm_Cia_Masivo(objEPrm_Cia, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
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
                string compania_Id;
                string periodo_Id;
                compania_Id = cboCompania.SelectedValue;
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                objEPrm_Cia = new Ent_Prm_Cia();
                objEPrm_Cia.Periodo_Id = periodo_Id;
                objEPrm_Cia.Compania_Id = compania_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Prm_Cia.Inserta_Prm_Cia_Genera(objEPrm_Cia);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
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
            Lista_Prm_Cia(Utils.fc_obtiene_Periodo_Id(this), cboCompania.SelectedValue);
        }

    }
}