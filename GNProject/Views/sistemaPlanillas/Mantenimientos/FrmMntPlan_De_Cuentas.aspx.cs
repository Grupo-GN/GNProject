using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntPlan_De_Cuentas : BasePage
    {
        Ent_Plan_De_Cuentas objEPlan_De_Cuentas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                ckPartida_Presupuestaria.Enabled = false;
                Carga_Companias();
                Carga_Ejercicios();
                Carga_TipoAgrupacionAsientoCta();
                Carga_Centro_Costos(); /*demora muxo por el centro de costo*/
                Carga_Localidades();
                Carga_Tipo_Trabajador();

                Lista_Plan_De_Cuentas(txtFindDescrip.Text);
                lblCuenta.Visible = false;
            }
            HighlightGridLine();
        }

        void Carga_Companias()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Compania objECompania = new Ent_Compania();
            cboCompania.DataSource = Log_Compania.Lista_Compania(objECompania);
            cboCompania.DataTextField = "Descripcion";
            cboCompania.DataValueField = "Compania_Id";
            cboCompania.DataBind();
        }

        void Carga_Ejercicios()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Ejercicio objEEjercicio = new Ent_Ejercicio();
            cboEjercicio.DataSource = Log_Ejercicio.Lista_Ejercicio(objEEjercicio);
            cboEjercicio.DataTextField = "Descripcion";
            cboEjercicio.DataValueField = "Ejercicio_Id";
            cboEjercicio.DataBind();
        }
        void Carga_TipoAgrupacionAsientoCta()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboTipoAgrupacionAsientoCta.DataSource = Log_Asiento_Cuentas.Lista_TipoAgrupacionAsientoCta();
            cboTipoAgrupacionAsientoCta.DataTextField = "no_tipo_agrupacion_asiento_cta";
            cboTipoAgrupacionAsientoCta.DataValueField = "co_tipo_agrupacion_asiento_cta";
            cboTipoAgrupacionAsientoCta.DataBind();
        }
        void Carga_Centro_Costos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Ccosto objECCosto = new Ent_Ccosto();
            cboCentro_Costo.DataSource = Log_Ccosto.Lista_Ccosto(objECCosto);
            cboCentro_Costo.DataTextField = "no_Ccosto";
            cboCentro_Costo.DataValueField = "Ccosto_Id";
            cboCentro_Costo.DataBind();
            cboCentro_Costo.Items.Insert(0, new ListItem("--Ninguno--", "000"));
        }
        void Carga_Localidades()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_RH_Area objELocalidad = new Ent_RH_Area();
            cboArea.DataSource = Log_RH_Area.Lista_RH_Area(objELocalidad);
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Area_Id";
            cboArea.DataBind();
            cboArea.Items.Insert(0, new ListItem("--Ninguno--", "000"));
        }
        void Carga_Tipo_Trabajador()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Tipo_Trabajador objETipTrabajador = new Ent_Tipo_Trabajador();
            cboTipo_Trabajador.DataSource = Log_Tipo_Trabajador.Lista_Tipo_Trabajador(objETipTrabajador);
            cboTipo_Trabajador.DataTextField = "Descripcion";
            cboTipo_Trabajador.DataValueField = "Tipo_Trabajador_Id";
            cboTipo_Trabajador.DataBind();
            cboTipo_Trabajador.Items.Insert(0, new ListItem("--Ninguno--", ""));
        }

        void Lista_Plan_De_Cuentas(string no_Plan_De_Cuentas)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            string Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
            // Utils.fc_Adecua_GridView(grvPlan_De_Cuentas, Log_Plan_De_Cuentas.Lista_Plan_De_Cuentas(Compania_Id, Ejercicio_Id, "", no_Plan_De_Cuentas).Count);
            grvPlan_De_Cuentas.DataSource = Log_Plan_De_Cuentas.Lista_Plan_De_Cuentas(Compania_Id, Ejercicio_Id, "", no_Plan_De_Cuentas);
            grvPlan_De_Cuentas.DataBind();
        }

        protected void grvPlan_De_Cuentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPlan_De_Cuentas.PageIndex = e.NewPageIndex;
            Lista_Plan_De_Cuentas(txtFindDescrip.Text);
        }


        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboCompania.SelectedIndex = 0;
            cboEjercicio.SelectedIndex = 0;
            lblCuenta.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cboTipoAgrupacionAsientoCta.SelectedIndex = 0;
            ckCentro_Costo.Checked = false;
            cboCentro_Costo.SelectedIndex = 0;
            ckPartida_Presupuestaria.Checked = false;
            ckAnalitica.Checked = false;
            ckArea.Checked = false;
            cboArea.SelectedIndex = 0;
            ckTipo_Trabajador.Checked = false;
            cboTipo_Trabajador.SelectedIndex = 0;
        }

        protected void grvPlan_De_Cuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {

                string compania_Id;
                string ejercicio_Id;
                string cuenta;

                string Ccosto_Id;
                string area_Id;
                string tipo_Trabajador_Id;

                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                compania_Id = grvPlan_De_Cuentas.DataKeys[row.RowIndex].Values["Compania_Id"].ToString();
                ejercicio_Id = grvPlan_De_Cuentas.DataKeys[row.RowIndex].Values["Ejercicio_Id"].ToString();
                cuenta = grvPlan_De_Cuentas.DataKeys[row.RowIndex].Values["Cuenta"].ToString();

                //LimpiarCajasTexto();

                objEPlan_De_Cuentas = new Ent_Plan_De_Cuentas();
                objEPlan_De_Cuentas.Compania_Id = compania_Id;
                objEPlan_De_Cuentas.Ejercicio_Id = ejercicio_Id;
                objEPlan_De_Cuentas.Cuenta = cuenta;
                DataTable dtPlan_De_Cuentas = new DataTable();
                dtPlan_De_Cuentas = Log_Plan_De_Cuentas.Lista_Plan_De_Cuentas(objEPlan_De_Cuentas);

                cboCompania.SelectedValue = compania_Id;
                cboEjercicio.SelectedValue = ejercicio_Id;
                lblCuenta.Text = cuenta;
                txtCuenta.Text = cuenta;
                txtDescripcion.Text = dtPlan_De_Cuentas.Rows[0]["Descripcion"].ToString().Trim();
                cboTipoAgrupacionAsientoCta.SelectedValue = dtPlan_De_Cuentas.Rows[0]["co_tipo_agrupacion_asiento_cta"].ToString().Trim();

                ckCentro_Costo.Checked = Convert.ToBoolean(dtPlan_De_Cuentas.Rows[0]["lCentro_De_Costo"]);
                Ccosto_Id = dtPlan_De_Cuentas.Rows[0]["CCosto_Id"].ToString();
                if (!string.IsNullOrEmpty(Ccosto_Id.Trim()))
                    cboCentro_Costo.SelectedValue = Ccosto_Id;
                else
                    cboCentro_Costo.SelectedIndex = 0;
                ckPartida_Presupuestaria.Checked = Convert.ToBoolean(dtPlan_De_Cuentas.Rows[0]["lPartida_Presupuestaria"]);
                ckAnalitica.Checked = Convert.ToBoolean(dtPlan_De_Cuentas.Rows[0]["lAnalitica"]);
                ckArea.Checked = Convert.ToBoolean(dtPlan_De_Cuentas.Rows[0]["lArea"]);
                area_Id = dtPlan_De_Cuentas.Rows[0]["Area_Id"].ToString();
                if (!string.IsNullOrEmpty(area_Id.Trim()))
                    cboArea.SelectedValue = area_Id;
                else
                    cboArea.SelectedIndex = 0;
                ckTipo_Trabajador.Checked = Convert.ToBoolean(dtPlan_De_Cuentas.Rows[0]["lTipo_Trabajador"]);
                tipo_Trabajador_Id = dtPlan_De_Cuentas.Rows[0]["Tipo_Trabajador_Id"].ToString();
                if (!string.IsNullOrEmpty(tipo_Trabajador_Id.Trim()))
                    cboTipo_Trabajador.SelectedValue = tipo_Trabajador_Id;
                else
                    cboTipo_Trabajador.SelectedIndex = 0;

                txtCuenta.Visible = false;
                lblCuenta.Visible = true;
                enableTabPanel(true);

                enableAdd(false);
                enableUpdate(true);
                enableCancel(true);
                enableNew(false);
                //btnGrabar.Visible = false;
                //btnActualizar.Visible = true;
                TabContainer1.ActiveTabIndex = 1;
                txtDescripcion.Focus();


            }
        }
        protected void grvPlan_De_Cuentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string compania_Id;
                string ejercicio_Id;
                string cuenta;

                compania_Id = grvPlan_De_Cuentas.DataKeys[e.RowIndex].Values["Compania_Id"].ToString();
                ejercicio_Id = grvPlan_De_Cuentas.DataKeys[e.RowIndex].Values["Ejercicio_Id"].ToString();
                cuenta = grvPlan_De_Cuentas.DataKeys[e.RowIndex].Values["Cuenta"].ToString();

                objEPlan_De_Cuentas = new Ent_Plan_De_Cuentas();
                objEPlan_De_Cuentas.Compania_Id = compania_Id;
                objEPlan_De_Cuentas.Ejercicio_Id = ejercicio_Id;
                objEPlan_De_Cuentas.Cuenta = cuenta;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Plan_De_Cuentas.Elimina_Plan_De_Cuentas(objEPlan_De_Cuentas);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    //btnActualizar.Visible = false;
                    Lista_Plan_De_Cuentas(txtFindDescrip.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Plan_De_Cuentas(txtFindDescrip.Text);
        }

        protected void grvPlan_De_Cuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPlan_De_Cuentas = new Ent_Plan_De_Cuentas();
                objEPlan_De_Cuentas.Compania_Id = cboCompania.SelectedValue;
                objEPlan_De_Cuentas.Ejercicio_Id = cboEjercicio.SelectedValue;
                objEPlan_De_Cuentas.Cuenta = txtCuenta.Text;
                objEPlan_De_Cuentas.Descripcion = txtDescripcion.Text.ToUpper();
                objEPlan_De_Cuentas.co_tipo_agrupacion_asiento_cta = cboTipoAgrupacionAsientoCta.SelectedValue;

                objEPlan_De_Cuentas.LPartida_Presupuestaria = ckPartida_Presupuestaria.Checked;
                objEPlan_De_Cuentas.LCentro_De_Costo = ckCentro_Costo.Checked;
                objEPlan_De_Cuentas.LAnalitica = ckAnalitica.Checked;
                objEPlan_De_Cuentas.Anexo = string.Empty;
                objEPlan_De_Cuentas.Subanexo = string.Empty;
                if (cboCentro_Costo.SelectedIndex == 0)
                    objEPlan_De_Cuentas.CCosto_id = string.Empty;
                else
                    objEPlan_De_Cuentas.CCosto_id = cboCentro_Costo.SelectedValue;
                if (cboArea.SelectedIndex == 0)
                    objEPlan_De_Cuentas.Area_Id = string.Empty;
                else
                    objEPlan_De_Cuentas.Area_Id = cboArea.SelectedValue;
                if (cboTipo_Trabajador.SelectedIndex == 0)
                    objEPlan_De_Cuentas.Tipo_Trabajador_Id = string.Empty;
                else
                    objEPlan_De_Cuentas.Tipo_Trabajador_Id = cboTipo_Trabajador.SelectedValue;
                objEPlan_De_Cuentas.LArea = ckArea.Checked;
                objEPlan_De_Cuentas.LTipo_Trabajador = ckTipo_Trabajador.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Plan_De_Cuentas.Inserta_Plan_De_Cuentas(objEPlan_De_Cuentas);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCuenta.Text = txtCuenta.Text;
                    //Lista_Plan_De_Cuentas(txtFindDescrip.Text);
                    txtCuenta.Visible = false;
                    lblCuenta.Visible = true;
                    enableCancel(false);
                    enableAdd(false);
                    enableUpdate(false);
                    enableNew(true);
                    LimpiarCajasTexto();
                    enableTabPanel(false);
                    TabContainer1.ActiveTabIndex = 0;
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableCancel(true);
            enableNew(false);
            enableAdd(true);
            enableTabPanel(true);
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            cboCompania.SelectedValue = Utils.fc_obtiene_Compania_Id(this);
            cboEjercicio.SelectedValue = Utils.fc_obtiene_Ejercicio_Id(this);
            lblCuenta.Visible = false;
            txtCuenta.Visible = true;
            txtCuenta.Focus();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblCuenta.Text.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Una Cuenta.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEPlan_De_Cuentas = new Ent_Plan_De_Cuentas();
                objEPlan_De_Cuentas.Compania_Id = cboCompania.SelectedValue;
                objEPlan_De_Cuentas.Ejercicio_Id = cboEjercicio.SelectedValue;
                objEPlan_De_Cuentas.Cuenta = lblCuenta.Text;
                objEPlan_De_Cuentas.Descripcion = txtDescripcion.Text.ToUpper();
                objEPlan_De_Cuentas.co_tipo_agrupacion_asiento_cta = cboTipoAgrupacionAsientoCta.SelectedValue;

                objEPlan_De_Cuentas.LPartida_Presupuestaria = ckPartida_Presupuestaria.Checked;
                objEPlan_De_Cuentas.LCentro_De_Costo = ckCentro_Costo.Checked;
                objEPlan_De_Cuentas.LAnalitica = ckAnalitica.Checked;
                //////objEPlan_De_Cuentas.Anexo = string.Empty;
                //////objEPlan_De_Cuentas.Subanexo = string.Empty;
                if (cboCentro_Costo.SelectedIndex == 0)
                    objEPlan_De_Cuentas.CCosto_id = string.Empty;
                else
                    objEPlan_De_Cuentas.CCosto_id = cboCentro_Costo.SelectedValue;
                if (cboArea.SelectedIndex == 0)
                    objEPlan_De_Cuentas.Area_Id = string.Empty;
                else
                    objEPlan_De_Cuentas.Area_Id = cboArea.SelectedValue;
                if (cboTipo_Trabajador.SelectedIndex == 0)
                    objEPlan_De_Cuentas.Tipo_Trabajador_Id = string.Empty;
                else
                    objEPlan_De_Cuentas.Tipo_Trabajador_Id = cboTipo_Trabajador.SelectedValue;
                objEPlan_De_Cuentas.LArea = ckArea.Checked;
                objEPlan_De_Cuentas.LTipo_Trabajador = ckTipo_Trabajador.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Plan_De_Cuentas.Actualiza_Plan_De_Cuentas(objEPlan_De_Cuentas);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Plan_De_Cuentas(txtFindDescrip.Text);
                    enableTabPanel(false);
                    enableCancel(false);
                    enableAdd(false);
                    enableUpdate(false);
                    enableNew(true);
                    TabContainer1.ActiveTabIndex = 0;
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        #region barraHerramientas
        private void enableAdd(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = opcion;
        }
        private void enableUpdate(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpdate.Enabled = opcion;
        }
        private void enableDelete(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnDelete.Enabled = opcion;
        }
        private void enableNew(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnNew.Enabled = opcion;
        }
        private void enableCancel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnCancel.Enabled = opcion;
        }
        private void enableTabPanel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            TabPanel2.Enabled = opcion;
        }

        #endregion


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableNew(true);
            enableAdd(false);
            enableUpdate(false);
            enableCancel(false);
            enableDelete(false);
            enableTabPanel(false);
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 0;
            txtFindDescrip.Focus();
        }
    }
}