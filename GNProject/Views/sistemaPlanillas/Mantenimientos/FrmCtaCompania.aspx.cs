using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmCtaCompania : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                TabGeneral.ActiveTabIndex = 0;
                TabGeneral.Tabs[1].Enabled = false;
                TabMant.Enabled = false;
                CargarCuentas();
                cargarbanco();
                cargaMoneda();
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            CodigoCta.Value = "";
            cboBanco.SelectedIndex = 0;
            cboMoneda.SelectedIndex = 0;
            txtnrocta.Text = "";
            TabGeneral.Tabs[1].Enabled = true;
            TabGeneral.ActiveTabIndex = 1;
            enableNew(false);
            enableAdd(true);
            enableCancel(true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (cboBanco.SelectedValue == null)
            {
                Utils.fc_DisplayAlert(this, "El Banco no ha sido definido.");
                return;
            }
            if (cboMoneda.SelectedValue == null)
            {
                Utils.fc_DisplayAlert(this, "La Moneda no ha sido definido.");
                return;
            }
            if (txtnrocta.Text.Trim() == "")
            {
                Utils.fc_DisplayAlert(this, "El número de cuenta no ha sido definido.");
                return;
            }

            string result = controllerCtaCompania.getinstance().RegistrarNumeroCta(Utils.fc_obtiene_Compania_Id(this), cboBanco.SelectedValue.ToString(), cboMoneda.SelectedValue.ToString(), txtnrocta.Text.Trim());
            if (result.Split('#')[0] == "true")
            {
                Utils.fc_DisplayAlert(this, result.Split('#')[1]);
                enableUpdate(false);
                enableNew(true);
                enableCancel(false);
                enableAdd(false);
                TabGeneral.ActiveTabIndex = 0;
                TabGeneral.Tabs[1].Enabled = false;
                CodigoCta.Value = "";
                CargarCuentas();

            }
            else
            {
                Utils.fc_DisplayAlert(this, result.Split('#')[1]);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableUpdate(false);
            enableNew(true);
            enableCancel(false);
            enableAdd(false);
            TabGeneral.ActiveTabIndex = 0;
            TabGeneral.Tabs[1].Enabled = false;
            CodigoCta.Value = "";
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (CodigoCta.Value == "")
            {
                Utils.fc_DisplayAlert(this, "No ha seleccionado ningún registro.");
                return;
            }
            if (cboBanco.SelectedValue == null)
            {
                Utils.fc_DisplayAlert(this, "El Banco no ha sido definido.");
                return;
            }
            if (cboMoneda.SelectedValue == null)
            {
                Utils.fc_DisplayAlert(this, "La Moneda no ha sido definido.");
                return;
            }
            if (txtnrocta.Text.Trim() == "")
            {
                Utils.fc_DisplayAlert(this, "El número de cuenta no ha sido definido.");
                return;
            }
            string cod = CodigoCta.Value;
            string a = cod.Split('|')[0].ToString(), b = cod.Split('|')[1].ToString(), c = cod.Split('|')[2].ToString();
            string result = controllerCtaCompania.getinstance().ActualizarNumeroCta(a, b, c, txtnrocta.Text.Trim());
            if (result.Split('#')[0] == "true")
            {
                Utils.fc_DisplayAlert(this, result.Split('#')[1]);
                enableUpdate(false);
                enableNew(true);
                enableCancel(false);
                enableAdd(false);
                TabGeneral.ActiveTabIndex = 0;
                TabGeneral.Tabs[1].Enabled = false;
                CodigoCta.Value = "";
                CargarCuentas();
            }
            else
            {
                Utils.fc_DisplayAlert(this, result.Split('#')[1]);
            }
        }
        void CargarCuentas()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string xcompania = Utils.fc_obtiene_Compania_Id(this);
            dgvdetalle.DataSource = null;
            dgvdetalle.DataSource = controllerCtaCompania.getinstance().ListarCtasCompania(xcompania);
            dgvdetalle.DataBind();

        }
        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            CodigoCta.Value = "";
            enableNew(false);
            enableAdd(false);
            enableCancel(true);
            enableUpdate(true);
            string vCodigo;
            ImageButton ibtn = new ImageButton();
            ibtn = (ImageButton)sender;
            vCodigo = ibtn.CommandArgument.ToString();
            if (vCodigo.IndexOf('|') > 0)
            {
                CodigoCta.Value = vCodigo;
                string a = vCodigo.Split('|')[0].ToString(), b = vCodigo.Split('|')[1].ToString(), c = vCodigo.Split('|')[2].ToString();
                var oitem = controllerCtaCompania.getinstance().GetCuentaEdit(a, b, c);
                if (oitem != null)
                {
                    cboBanco.SelectedValue = oitem.Banco_Id;
                    cboMoneda.SelectedValue = oitem.Moneda_Id;
                    txtnrocta.Text = oitem.NroCta;
                    TabGeneral.Tabs[1].Enabled = true;
                    TabGeneral.ActiveTabIndex = 1;
                }
            }
        }
        void cargarbanco()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Dictionary<string, string> source = new Dictionary<string, string>();
            source = controllerCtaCompania.getinstance().ListarBancos();
            cboBanco.DataTextField = "Value";
            cboBanco.DataValueField = "Key";
            cboBanco.DataSource = source;
            cboBanco.DataBind();
        }
        void cargaMoneda()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Dictionary<string, string> source = new Dictionary<string, string>();
            source = controllerCtaCompania.getinstance().ListarMoneda();
            cboMoneda.DataTextField = "Value";
            cboMoneda.DataValueField = "Key";
            cboMoneda.DataSource = source;
            cboMoneda.DataBind();
        }
        private void enableAdd(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = opcion;
            // backgroundButton(btnAdd);
        }
        private void enableUpdate(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpdate.Enabled = opcion;
            // backgroundButton(btnUpdate);
        }
        private void enableDelete(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnDelete.Enabled = opcion;
            //backgroundButton(btnDelete);
        }
        private void enableNew(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnNew.Enabled = opcion;
            // backgroundButton(btnNew);
        }
        private void enableCancel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnCancel.Enabled = opcion;
            //backgroundButton(btnCancel);
        }

    }
}