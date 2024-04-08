using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Contrato_RRHH
{
    public partial class FrmSeguimientoContrato : System.Web.UI.Page
    {
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Master.UcFiltros_PostBackPeriodoChangedEventHandler += new EventHandler(MasterUcFiltros_PeriodoChangedEvent);
            if (!Utils.fc_ValidaFiltros(this.Page))
            {
                if (Request.QueryString["block"] == null)
                    Response.Redirect("~/Default.aspx?block=1");
            }

            if (!Page.IsPostBack)
            {
                Carga_combo_Categoria_Auxiliar();
                Lista_Personal();
            }
        }
        void Carga_combo_Categoria_Auxiliar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Categoria_Auxiliar objECat_Aux = new Ent_Categoria_Auxiliar();
            cboCategoria_Auxiliar.DataSource = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECat_Aux);
            cboCategoria_Auxiliar.DataTextField = "Descripcion";
            cboCategoria_Auxiliar.DataValueField = "Categoria_Auxiliar_Id";
            cboCategoria_Auxiliar.DataBind();
            cboCategoria_Auxiliar.Items.Insert(0, new ListItem("TODOS"));
        }
        protected void cboCategoriaAuxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal();
        }
        private void Lista_Personal()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                String PeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                String Area = cboCategoria_Auxiliar.SelectedValue;

                string Areas = "";
                if (cboCategoria_Auxiliar.SelectedValue == "TODOS")
                { Areas = "0"; }
                else
                { Areas = (cboCategoria_Auxiliar.SelectedValue); }

                Ent_Contratos objEContratos = new Ent_Contratos();
                objEContratos.PeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                objEContratos.Area = Areas;
                DataTable dt = new DataTable();
                dt = Log_Contratos.Lista_Seguimiento_Contratos_Renovados(objEContratos);

                if (dt.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se encontraron datos");
                }

                GrvListaPersonal.DataSource = dt;
                GrvListaPersonal.DataBind();

                grv.DataSource = dt;
                grv.DataBind();
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
                if (GrvListaPersonal.Rows.Count == 0)
                {
                    Utils.fc_DisplayAlert(this, "No existen registros en la bandeja.");
                    return;
                }

                string Usuario = ClaseGlobal.Get_nombrecompleto_usuario();

                var cont = 0;
                foreach (GridViewRow row in GrvListaPersonal.Rows)
                {
                    CheckBox chkGuardar = (CheckBox)grv.Rows[row.RowIndex].FindControl("chkGuardar");
                    if (chkGuardar.Checked)
                    {
                        string Personal_Id = GrvListaPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                        string Periodo_Id = GrvListaPersonal.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();

                        CheckBox chkboxEntrega = (CheckBox)row.FindControl("chkboxEntrega");
                        Boolean EntregaFirmaRepresentanteLegal = chkboxEntrega.Checked;

                        CheckBox chkboxCesado = (CheckBox)row.FindControl("chkboxCesado");
                        Boolean Cesado = chkboxCesado.Checked;

                        CheckBox chkboxRetornado = (CheckBox)row.FindControl("chkboxRetornado");
                        Boolean RetornadoFirmadoRepresentanteLegal = chkboxRetornado.Checked;

                        TextBox txtNumeroEnvio = (TextBox)row.FindControl("txtNumeroEnvio");
                        String NumeroEnvioMinisterioTrabajo = txtNumeroEnvio.Text.Trim();

                        CheckBox chkboxRenovado = (CheckBox)row.FindControl("chkboxRenovado");
                        Boolean Renovado = chkboxRenovado.Checked;

                        CheckBox chkboxFirmado = (CheckBox)row.FindControl("chkboxFirmado");
                        Boolean Firmado = chkboxFirmado.Checked;

                        Log_Contratos.Actualiza_Seguimiento_Contratos_Renovados(Personal_Id, Periodo_Id
                            , EntregaFirmaRepresentanteLegal, Cesado, RetornadoFirmadoRepresentanteLegal
                            , NumeroEnvioMinisterioTrabajo, Renovado, Firmado, Usuario);

                        cont++;
                    }
                }
                if (cont > 0)
                {
                    Utils.fc_DisplayAlert(this, "Se guardaron correctamente los registros.");

                    Lista_Personal();
                }
                else
                {
                    Utils.fc_DisplayAlert(this, "Debe seleccionar al menos un registro.");
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se guardaron los registros. " + ex.Message;
            }
        }
    }
}