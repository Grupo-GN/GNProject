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
    public partial class FrmConfig_Asiento : BasePage
    {
        Ent_Asiento objEAsiento;
        Ent_Asiento_Cuentas objEAsiento_Cuentas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_combo_Planilla();
                Carga_combo_Estados();
                Lista_Asiento(txtAsientoBuscar.Text);

            }
            HighlightGridLine();
        }

        #region "CARGA_COMBOS"

        void Carga_combo_Planilla()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Planilla objEPlanilla = new Ent_Planilla();
            objEPlanilla.Estado_Id = "01"; /*Solo Activos*/
            cboPlanilla.DataSource = Log_Planilla.Lista_Planilla(objEPlanilla);
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
        }

        void Carga_combo_Estados()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }

        #endregion

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Asiento(txtAsientoBuscar.Text);
        }

        void Lista_Asiento(String no_Asiento)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEAsiento = new Ent_Asiento();
                objEAsiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEAsiento.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEAsiento.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                if (no_Asiento.Trim() != String.Empty)
                    objEAsiento.Descripcion = no_Asiento;
                DataTable dtAsiento = new DataTable();
                dtAsiento = Log_Asiento.Lista_Asiento(objEAsiento);
                Utils.fc_Adecua_GridView(grvAsiento, dtAsiento.Rows.Count);
                grvAsiento.DataSource = dtAsiento;
                grvAsiento.DataBind();
                dtAsiento.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvAsiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvAsiento.PageIndex = e.NewPageIndex;
            Lista_Asiento(txtAsientoBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto_Cabecera();
            grvAsiento_Cuentas.DataBind();
            TabContainer1.ActiveTabIndex = 1;
            cboPlanilla.SelectedValue = Utils.fc_obtiene_Planilla_Id(this);
            txtDescripcion.Focus();

        }

        protected void grvAsiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {

                    string Asiento_Id, Descripcion, Libro, Glosa, Planilla_Id, Estado_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Asiento_Id = grvAsiento.DataKeys[row.RowIndex].Values["Asiento_Id"].ToString();
                    Descripcion = grvAsiento.DataKeys[row.RowIndex].Values["Descripcion"].ToString();
                    Libro = grvAsiento.DataKeys[row.RowIndex].Values["Libro"].ToString();
                    Glosa = grvAsiento.DataKeys[row.RowIndex].Values["Glosa"].ToString();
                    Planilla_Id = grvAsiento.DataKeys[row.RowIndex].Values["Planilla_Id"].ToString();
                    Estado_Id = grvAsiento.DataKeys[row.RowIndex].Values["Estado_Id"].ToString();

                    LimpiarCajasTexto_Cabecera();
                    //LimpiarCajasTexto_Detalle();

                    lblAsiento_Id.Text = Asiento_Id;
                    txtDescripcion.Text = Descripcion;
                    txtLibro.Text = Libro;
                    txtGlosa.Text = Glosa;
                    cboPlanilla.SelectedValue = Planilla_Id;
                    cboEstado.SelectedValue = Estado_Id;

                    /*Lista Datos del Detalle => Asiento_Cuenta*/
                    objEAsiento_Cuentas = new Ent_Asiento_Cuentas();
                    objEAsiento_Cuentas.Asiento_Id = Asiento_Id;
                    Lista_Asiento_Cuentas(Asiento_Id, txtAsientoCuentasBuscar.Text);
                    TabContainer1.ActiveTabIndex = 1;
                    pnlDetalle.Visible = true;

                    enableNew(false);
                    enableCancel(true);
                    enableAdd(false);
                    enableUpdate(true);
                    enableTabPanel(true);

                    txtDescripcion.Focus();

                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        protected void grvAsiento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Asiento_Id;
                Asiento_Id = grvAsiento.DataKeys[e.RowIndex].Values["Asiento_Id"].ToString();

                objEAsiento = new Ent_Asiento();
                objEAsiento.Asiento_Id = Asiento_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento.Elimina_Asiento(objEAsiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto_Cabecera();
                    grvAsiento_Cuentas.DataBind();
                    //LimpiarCajasTexto_Detalle();
                    //btnGrabarDet.Visible = false;
                    //btnActualizar.Visible = false;
                    Lista_Asiento(txtAsientoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEAsiento = new Ent_Asiento();
                objEAsiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEAsiento.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEAsiento.Planilla_Id = cboPlanilla.SelectedValue;
                objEAsiento.Descripcion = txtDescripcion.Text.ToUpper();
                objEAsiento.Glosa = txtGlosa.Text.ToUpper();
                objEAsiento.Libro = txtLibro.Text;
                objEAsiento.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento.Inserta_Asiento(objEAsiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblAsiento_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Asiento(txtAsientoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblAsiento_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Un Asiento.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEAsiento = new Ent_Asiento();
                objEAsiento.Asiento_Id = lblAsiento_Id.Text;
                objEAsiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEAsiento.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEAsiento.Planilla_Id = cboPlanilla.SelectedValue;
                objEAsiento.Descripcion = txtDescripcion.Text.ToUpper();
                objEAsiento.Glosa = txtGlosa.Text.ToUpper();
                objEAsiento.Libro = txtLibro.Text;
                objEAsiento.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento.Actualiza_Asiento(objEAsiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Asiento(txtAsientoBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        /*Metodos del Detalle (Asiento cuentas)*/
        protected void btnBuscar_AsientoCuenta_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Asiento_Cuentas(lblAsiento_Id.Text, txtAsientoCuentasBuscar.Text);
        }

        void Lista_Asiento_Cuentas(String Asiento_Id, String no_Asiento_Cuenta)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblAsiento_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Por Favor Volver a Seleccionar Un Asiento.");

                return;
            }
            try
            {
                objEAsiento_Cuentas = new Ent_Asiento_Cuentas();
                objEAsiento_Cuentas.Asiento_Id = Asiento_Id;
                if (no_Asiento_Cuenta.Trim() != String.Empty)
                    objEAsiento_Cuentas.Glosa = no_Asiento_Cuenta;
                DataTable dtAsiento_Cuentas = new DataTable();
                dtAsiento_Cuentas = Log_Asiento_Cuentas.Lista_Asiento_Cuentas(objEAsiento_Cuentas);
                Utils.fc_Adecua_GridView(grvAsiento_Cuentas, dtAsiento_Cuentas.Rows.Count);
                grvAsiento_Cuentas.DataSource = dtAsiento_Cuentas;
                grvAsiento_Cuentas.DataBind();
                grvAsiento_Cuentas.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvAsiento_Cuentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvAsiento_Cuentas.PageIndex = e.NewPageIndex;
            Lista_Asiento_Cuentas(lblAsiento_Id.Text, txtAsientoCuentasBuscar.Text);
        }

        void LimpiarCajasTexto_Cabecera()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblAsiento_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtLibro.Text = String.Empty;
            txtGlosa.Text = String.Empty;
            cboPlanilla.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;
        }


        protected void grvAsiento_Cuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Asiento_Cuenta_Id;

                    string PeriodoIds = Utils.fc_obtiene_Ejercicio_Id(this);
                    string planillaId = Utils.fc_obtiene_Planilla_Id(this);
                    Session["Ejercicio_Id"] = Utils.fc_obtiene_Ejercicio_Id(this);
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Asiento_Cuenta_Id = grvAsiento_Cuentas.DataKeys[row.RowIndex].Values["Asiento_Cuenta_Id"].ToString();
                    string lblasientoId = lblAsiento_Id.Text;

                    string FileStrean = "AddDetalleAsiento.aspx";
                    string Clientscript = "AbrirModal('" + FileStrean + "?Asiento_Cuenta_Id=" + Asiento_Cuenta_Id + "&Periodo_Ids=" + PeriodoIds + "&Planilla_Ids=" + planillaId + "&lblasientoId=" + lblasientoId + "&pTipo_Proceso=2')";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);

                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        protected void grvAsiento_Cuentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblAsiento_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Por Favor Volver a Seleccionar Un Asiento.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                string Asiento_Cuenta_Id;
                Asiento_Cuenta_Id = grvAsiento_Cuentas.DataKeys[e.RowIndex].Values["Asiento_Cuenta_Id"].ToString();

                objEAsiento_Cuentas = new Ent_Asiento_Cuentas();
                objEAsiento_Cuentas.Asiento_Cuenta_Id = Asiento_Cuenta_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento_Cuentas.Elimina_Asiento_Cuentas(objEAsiento_Cuentas);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Asiento_Cuentas(lblAsiento_Id.Text, txtAsientoCuentasBuscar.Text);
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
            enableAdd(true);
            btnAdd.Enabled = true;
            enableCancel(true);
            enableNew(false);
            LimpiarCajasTexto_Cabecera();
            enableTabPanel(true);
            grvAsiento_Cuentas.DataBind();
            TabContainer1.ActiveTabIndex = 1;
            cboPlanilla.SelectedValue = Utils.fc_obtiene_Planilla_Id(this);
            txtDescripcion.Focus();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEAsiento = new Ent_Asiento();
                objEAsiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEAsiento.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEAsiento.Planilla_Id = cboPlanilla.SelectedValue;
                objEAsiento.Descripcion = txtDescripcion.Text.ToUpper();
                objEAsiento.Glosa = txtGlosa.Text.ToUpper();
                objEAsiento.Libro = txtLibro.Text;
                objEAsiento.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento.Inserta_Asiento(objEAsiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblAsiento_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Asiento(txtAsientoBuscar.Text);
                    //btnGrabar.Visible = false;
                    //btnActualizar.Visible = true;
                }
                dtRpta.Dispose();
                LimpiarCajasTexto_Cabecera();
                enableTabPanel(false);
                pnlDetalle.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblAsiento_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Un Asiento.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEAsiento = new Ent_Asiento();
                objEAsiento.Asiento_Id = lblAsiento_Id.Text;
                objEAsiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objEAsiento.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                objEAsiento.Planilla_Id = cboPlanilla.SelectedValue;
                objEAsiento.Descripcion = txtDescripcion.Text.ToUpper();
                objEAsiento.Glosa = txtGlosa.Text.ToUpper();
                objEAsiento.Libro = txtLibro.Text;
                objEAsiento.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Asiento.Actualiza_Asiento(objEAsiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Asiento(txtAsientoBuscar.Text);
                }
                dtRpta.Dispose();
                LimpiarCajasTexto_Cabecera();
                enableTabPanel(false);
                pnlDetalle.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
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
            Lista_Asiento(txtAsientoBuscar.Text);
        }
        protected void btnFindAsientoCuenta_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Asiento_Cuentas(lblAsiento_Id.Text, txtAsientoCuentasBuscar.Text);
        }

        protected void lkRefresacar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Asiento(txtAsientoBuscar.Text);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableNew(true);
            enableAdd(false);
            enableUpdate(false);
            enableCancel(false);
            enableDelete(false);
            enableTabPanel(false);
            LimpiarCajasTexto_Cabecera();
            TabContainer1.ActiveTabIndex = 0;
            pnlDetalle.Visible = false;
            txtAsientoBuscar.Focus();
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

        protected void grvAsiento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvAsiento_Cuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }


        protected void btnNewCC_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Asiento_Cuenta_Id = "01";

            string PeriodoIds = Utils.fc_obtiene_Ejercicio_Id(this);
            string planillaId = Utils.fc_obtiene_Planilla_Id(this);
            string lblasientoId = lblAsiento_Id.Text;
            Session["Ejercicio_Id"] = Utils.fc_obtiene_Ejercicio_Id(this);
            string FileStrean = "AddDetalleAsiento.aspx";
            string Clientscript = "AbrirModal('" + FileStrean + "?Asiento_Cuenta_Id=" + Asiento_Cuenta_Id + "&Periodo_Ids=" + PeriodoIds + "&Planilla_Ids=" + planillaId + "&lblasientoId=" + lblasientoId + "&pTipo_Proceso=1')";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
        }


        protected void grvAsiento_Cuentas_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Asiento_Cuentas(lblAsiento_Id.Text, txtAsientoCuentasBuscar.Text);
        }

    }
}