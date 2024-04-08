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
    public partial class FrmPrm_x_Afp : BasePage
    {
        Ent_Prm_Afp objEPrm_Afp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //   // if (Request.QueryString["block"] == null)
            //        Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //    Response.Redirect("~/Default.aspx");
            //      //  return;
            //}

            if (!Page.IsPostBack)
            {
                Carga_combo_Afp();

                // Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            }
            HighlightGridLine();
        }

        void Carga_combo_Afp()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_AFP objEAfp = new Ent_AFP();
            cboAfp.DataSource = Log_AFP.Lista_Afp(objEAfp);
            cboAfp.DataTextField = "Descripcion";
            cboAfp.DataValueField = "Afp_Id";
            cboAfp.DataBind();
        }

        private void Lista_Prm_Afp(string Afp_Id, string Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPrm_Afp = new Ent_Prm_Afp();
                objEPrm_Afp.Afp_Id = Afp_Id;
                objEPrm_Afp.Periodo_Id = Periodo_Id;
                DataTable dtPrm_Afp = new DataTable();
                dtPrm_Afp = Log_Prm_Afp.Lista_Prm_Afp(objEPrm_Afp);
                Utils.fc_Adecua_GridView(grvLista, dtPrm_Afp.Rows.Count);
                grvLista.DataSource = dtPrm_Afp;
                grvLista.DataBind();

                if (dtPrm_Afp.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtPrm_Afp.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboAfp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");

                if (txtValor != null)
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                //if (txtValor != null)
                //    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                //txtValor.Text = string.Format("{0:#,##0.##}", Convert.ToDouble(txtValor.Text));
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

            string afp_Id;
            string periodo_Id = "";
            string concepto_Id;
            //Decimal valor;
            //double valor;
            //string nuevoValorM="";
            string uhm = "";

            string concepto_Id_Masivo = "";
            string valor_Masivo = "";
            Int32 cont = 0;

            afp_Id = cboAfp.SelectedValue;
            DataTable dtRpta;
            foreach (GridViewRow row in grvLista.Rows)
            {
                periodo_Id = grvLista.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                    //valor = 0;
                    uhm = "0.00";
                else
                {
                    //valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);
                    uhm = ((TextBox)row.FindControl("txtValor")).Text;
                    //valor =Convert.ToDouble(uhm);
                    //nuevoValorM = valor.ToString("F", CultureInfo.InvariantCulture);
                }
                /*Inicio--por mientras hasta que se desarrole masivamente*/
                //dtRpta = new DataTable();
                //objEPrm_Afp = new Ent_Prm_Afp();
                //objEPrm_Afp.Periodo_Id = periodo_Id;
                //objEPrm_Afp.Concepto_Id = concepto_Id;
                //objEPrm_Afp.Valor = valor;
                //dtRpta = Log_Prm_Afp.Actualiza_Prm_Afp(objEPrm_Afp);
                /*Fin--por mientras hasta que se desarrole masivamente*/

                concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                //valor_Masivo = valor_Masivo + valor.ToString() + "|";
                valor_Masivo = valor_Masivo + uhm + "|";
                cont = cont + 1;
            }

            concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
            valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

            //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

            string delimitador = "|";

            dtRpta = new DataTable();
            objEPrm_Afp = new Ent_Prm_Afp();
            objEPrm_Afp.Afp_Id = afp_Id;
            objEPrm_Afp.Periodo_Id = periodo_Id;
            objEPrm_Afp.Concepto_Id_Masivo = concepto_Id_Masivo;
            objEPrm_Afp.Valor_Masivo = valor_Masivo;
            dtRpta = Log_Prm_Afp.Actualiza_Prm_Afp_Masivo(objEPrm_Afp, delimitador, cont);
            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
            {
                Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            }
            dtRpta.Dispose();
            Utils.fc_DisplayAlert(this, msj_rpta);

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string afp_Id;
                string periodo_Id;
                afp_Id = cboAfp.SelectedValue;
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                objEPrm_Afp = new Ent_Prm_Afp();
                objEPrm_Afp.Afp_Id = afp_Id;
                objEPrm_Afp.Periodo_Id = periodo_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Prm_Afp.Inserta_Prm_Afp_Genera(objEPrm_Afp);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
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
            Lista_Prm_Afp(cboAfp.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
        }
    }
}