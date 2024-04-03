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
    public partial class FrmMntPersonalxEstablecimiento : BasePage
    {
        Ent_Personal_Establecimientos objEPer_Establecimiento;

        DataTable dtPersonalOrigen = new DataTable();
        DataTable dtPersonalDestino = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                txtTasa.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                Carga_Establecimientos();
                CargaPersonal(Utils.fc_obtiene_Periodo_Id(this));
                Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
                lblPeriodo.Text = Utils.fc_obtiene_Periodo_Id_Nombre(this);
                btnGrabar.Visible = false;
                btnActualizar.Visible = false;

                dtPersonalOrigen.Columns.Add("Personal_Id", Type.GetType("System.String"));
                dtPersonalOrigen.Columns.Add("Nombre_Completo", Type.GetType("System.String"));
                ViewState["dtPersonalOrigen"] = dtPersonalOrigen;
                dtPersonalDestino.Columns.Add("Personal_Id", Type.GetType("System.String"));
                dtPersonalDestino.Columns.Add("Nombre_Completo", Type.GetType("System.String"));
                ViewState["dtPersonalDestino"] = dtPersonalDestino;
                pnlAsignacionMasiva.Visible = false;
            }
            HighlightGridLine();
        }

        void Carga_Establecimientos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtEstablecimientos = new DataTable();
            Ent_Compania_Establecimiento objECompania_Establecimiento = new Ent_Compania_Establecimiento();
            objECompania_Establecimiento.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            dtEstablecimientos = Log_Compania_Establecimiento.Lista_Compania_Establecimiento(objECompania_Establecimiento);
            cboEstablecimiento.DataSource = dtEstablecimientos;
            cboEstablecimiento.DataTextField = "Descripcion";
            cboEstablecimiento.DataValueField = "Establecimiento_Id";
            cboEstablecimiento.DataBind();
            cboEstablecimiento.Items.Insert(0, "-Todos-");

            cboEstablecimientoNew.DataSource = dtEstablecimientos;
            cboEstablecimientoNew.DataTextField = "Descripcion";
            cboEstablecimientoNew.DataValueField = "Establecimiento_Id";
            cboEstablecimientoNew.DataBind();

            cboEstablecimientoOrigen.DataSource = dtEstablecimientos;
            cboEstablecimientoOrigen.DataTextField = "Descripcion";
            cboEstablecimientoOrigen.DataValueField = "Establecimiento_Id";
            cboEstablecimientoOrigen.DataBind();
            cboEstablecimientoOrigen.Items.Insert(0, "-Personal Sin Establecimiento-");

            cboEstablecimientoDestino.DataSource = dtEstablecimientos;
            cboEstablecimientoDestino.DataTextField = "Descripcion";
            cboEstablecimientoDestino.DataValueField = "Establecimiento_Id";
            cboEstablecimientoDestino.DataBind();

            dtEstablecimientos.Dispose();
        }

        void CargaPersonal(String Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal.DataTextField = "Nombre_Completo";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
            cboPersonal.Items.Insert(0, "-Seleccione-");
        }

        protected void cboEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                lblPeriodo.Text = Utils.fc_obtiene_Periodo_Id_Nombre(this);
                btnGrabar.Visible = false;
                btnActualizar.Visible = false;
                CargaPersonal(Utils.fc_obtiene_Periodo_Id(this));
                Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        void Lista_PersonalEstablecimiento(String Establecimiento_Id, String Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEPer_Establecimiento = new Ent_Personal_Establecimientos();
            if (Establecimiento_Id != "-Todos-")
                objEPer_Establecimiento.Establecimiento_Id = Establecimiento_Id;
            objEPer_Establecimiento.Periodo_Id = Periodo_Id;
            DataTable dtPersonal = new DataTable();
            dtPersonal = Log_Personal_Establecimientos.Lista_Personal_Establecimientos(objEPer_Establecimiento);
            grvPersonal.DataSource = dtPersonal;
            grvPersonal.DataBind();
            lblTotEstablecimiento.Text = dtPersonal.Rows.Count.ToString();

            dtPersonal.Dispose();
        }

        protected void grvPersonal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            if (e.CommandName == "Select")
            {
                if (!Utils.fc_ValidaFiltros(this))
                {
                    Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                    return;
                }
                try
                {
                    string Personal_Id;
                    string Periodo_Id;
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    Personal_Id = grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    Periodo_Id = grvPersonal.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    objEPer_Establecimiento = new Ent_Personal_Establecimientos();

                    objEPer_Establecimiento.Periodo_Id = Periodo_Id;
                    objEPer_Establecimiento.Personal_Id = Personal_Id;
                    DataTable dtPersonal = new DataTable();
                    dtPersonal = Log_Personal_Establecimientos.Lista_Personal_Establecimientos(objEPer_Establecimiento);

                    lblPeriodo.Text = dtPersonal.Rows[0]["no_Periodo"].ToString();
                    cboPersonal.SelectedValue = dtPersonal.Rows[0]["Personal_Id"].ToString();
                    cboPersonal.Enabled = false;
                    cboEstablecimiento.SelectedValue = dtPersonal.Rows[0]["Establecimiento_Id"].ToString();
                    txtTasa.Text = dtPersonal.Rows[0]["Tasa"].ToString();
                    ckDestacaOtraEmpresa.Checked = Convert.ToBoolean(dtPersonal.Rows[0]["Destacado_Enviado"]);
                    ckDestacaDesdeOtraEmpresa.Checked = Convert.ToBoolean(dtPersonal.Rows[0]["Destacado_Recibido"]);
                    dtPersonal.Dispose();

                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        protected void grvPersonal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                string Personal_Id;
                string Periodo_Id;

                Personal_Id = grvPersonal.DataKeys[e.RowIndex].Values["Personal_Id"].ToString();
                Periodo_Id = grvPersonal.DataKeys[e.RowIndex].Values["Periodo_Id"].ToString();
                objEPer_Establecimiento = new Ent_Personal_Establecimientos();

                objEPer_Establecimiento.Personal_Id = Personal_Id;
                objEPer_Establecimiento.Periodo_Id = Periodo_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Establecimientos.Elimina_Personal_Establecimientos(objEPer_Establecimiento);
                string msj_Rpta;
                msj_Rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
                    btnGrabar.Visible = false;
                    btnActualizar.Visible = false;
                    cboPersonal.Enabled = false;
                    cboPersonal.SelectedIndex = 0;
                    cboEstablecimientoNew.SelectedIndex = 0;
                    txtTasa.Text = "";
                    ckDestacaOtraEmpresa.Checked = true;
                    ckDestacaDesdeOtraEmpresa.Checked = false;
                }
                Utils.fc_DisplayAlert(this, msj_Rpta);

                dtRpta.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            cboPersonal.Enabled = true;
            cboPersonal.SelectedIndex = 0;
            cboEstablecimientoNew.SelectedIndex = 0;
            txtTasa.Text = "";
            ckDestacaOtraEmpresa.Checked = true;
            ckDestacaDesdeOtraEmpresa.Checked = false;
            btnGrabar.Visible = true;
            btnActualizar.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                objEPer_Establecimiento = new Ent_Personal_Establecimientos();

                objEPer_Establecimiento.Personal_Id = cboPersonal.SelectedValue;
                objEPer_Establecimiento.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                objEPer_Establecimiento.Establecimiento_Id = cboEstablecimientoNew.SelectedValue;
                objEPer_Establecimiento.Tasa = Convert.ToDecimal(txtTasa.Text);
                objEPer_Establecimiento.Destacado_Enviado = ckDestacaOtraEmpresa.Checked;
                objEPer_Establecimiento.Destacado_Recibido = ckDestacaDesdeOtraEmpresa.Checked;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Establecimientos.Inserta_Personal_Establecimientos(objEPer_Establecimiento);
                string msj_Rpta;
                msj_Rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
                    cboPersonal.Enabled = false;
                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                }
                Utils.fc_DisplayAlert(this, msj_Rpta);

                dtRpta.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                objEPer_Establecimiento = new Ent_Personal_Establecimientos();

                objEPer_Establecimiento.Personal_Id = cboPersonal.SelectedValue;
                objEPer_Establecimiento.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                objEPer_Establecimiento.Establecimiento_Id = cboEstablecimientoNew.SelectedValue;
                objEPer_Establecimiento.Tasa = Convert.ToDecimal(txtTasa.Text);
                objEPer_Establecimiento.Destacado_Enviado = ckDestacaOtraEmpresa.Checked;
                objEPer_Establecimiento.Destacado_Recibido = ckDestacaDesdeOtraEmpresa.Checked;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Establecimientos.Actualiza_Personal_Establecimientos(objEPer_Establecimiento);
                string msj_Rpta;
                msj_Rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
                    //////btnGrabar.Visible = false;
                    //////btnActualizar.Visible = true;
                }
                Utils.fc_DisplayAlert(this, msj_Rpta);

                dtRpta.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnAsignacionMasiva_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (btnAsignacionMasiva.Text == "Asignación Masiva")
            {
                btnAsignacionMasiva.Text = "Volver A La Asignación Normal";
                pnlAsignacionNormal.Visible = false;
                pnlAsignacionMasiva.Visible = true;
                btnNuevo.Visible = false;
            }
            else
            {
                btnAsignacionMasiva.Text = "Asignación Masiva";
                pnlAsignacionNormal.Visible = true;
                pnlAsignacionMasiva.Visible = false;
                btnNuevo.Visible = true;
            }
        }

        protected void cboEstablecimientoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                Limpia_PersonalEstablecimientoDestino();
                Lista_PersonalEstablecimientoOrigen(cboEstablecimientoOrigen.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        void Lista_PersonalEstablecimientoOrigen(String Establecimiento_Origen_Id, String Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEPer_Establecimiento = new Ent_Personal_Establecimientos();
            if (Establecimiento_Origen_Id == "-Personal Sin Establecimiento-")
                objEPer_Establecimiento.Establecimiento_Id = "0000"; /*Personal Sin Establecimiento*/
            else
                objEPer_Establecimiento.Establecimiento_Id = Establecimiento_Origen_Id;
            objEPer_Establecimiento.Periodo_Id = Periodo_Id;

            //DataTable dt = new DataTable();
            dtPersonalOrigen = Log_Personal_Establecimientos.Lista_Personal_Establecimientos(objEPer_Establecimiento);
            grvPersonalOrigen.DataSource = dtPersonalOrigen;
            grvPersonalOrigen.DataBind();

            ViewState["dtPersonalOrigen"] = dtPersonalOrigen;

            dtPersonalOrigen.Dispose();
        }

        void Limpia_PersonalEstablecimientoDestino()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            /*Limpia El GridView de Destino*/
            grvPersonalDestino.DataBind();
            dtPersonalDestino.Rows.Clear();
            dtPersonalDestino.Columns.Add("Personal_Id", Type.GetType("System.String"));
            dtPersonalDestino.Columns.Add("Nombre_Completo", Type.GetType("System.String"));
            ViewState["dtPersonalDestino"] = dtPersonalDestino;
            /*Fin Limpia El GridView de Destino*/
        }

        protected void cboEstablecimientoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                Limpia_PersonalEstablecimientoDestino();
                Lista_PersonalEstablecimientoOrigen(cboEstablecimientoOrigen.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            if (cboEstablecimientoOrigen.SelectedValue == cboEstablecimientoDestino.SelectedValue)
            {
                Utils.fc_DisplayAlert(this, "El Establecimiento De Destino Debe Ser Diferente al Origen.");
                return;
            }
            try
            {

                dtPersonalOrigen = (DataTable)ViewState["dtPersonalOrigen"];
                dtPersonalDestino = (DataTable)ViewState["dtPersonalDestino"];
                Boolean ck;
                Boolean sinSeleccionar = true;
                string Personal_Id;
                string Nombre_Completo;
                /*Se recorre las filas del GridView en forma descendente para que no afecte los Index*/
                for (int i = grvPersonalOrigen.Rows.Count - 1; i >= 0; i--)
                {
                    ck = ((CheckBox)grvPersonalOrigen.Rows[i].FindControl("ckOrigen")).Checked;
                    if (ck == true)
                    {
                        sinSeleccionar = false;
                        Personal_Id = grvPersonalOrigen.DataKeys[i].Values["Personal_Id"].ToString();
                        Nombre_Completo = grvPersonalOrigen.DataKeys[i].Values["Nombre_Completo"].ToString();
                        DataRow row = dtPersonalDestino.NewRow();
                        row["Personal_Id"] = Personal_Id;
                        row["Nombre_Completo"] = Nombre_Completo;
                        dtPersonalDestino.Rows.Add(row);
                        dtPersonalOrigen.Rows.RemoveAt(i);
                    }
                }
                if (sinSeleccionar == false)
                {
                    grvPersonalDestino.DataSource = dtPersonalDestino;
                    grvPersonalDestino.DataBind();
                    ViewState["dtPersonalOrigen"] = dtPersonalOrigen;
                    ViewState["dtPersonalDestino"] = dtPersonalDestino;

                    grvPersonalOrigen.DataSource = dtPersonalOrigen;
                    grvPersonalOrigen.DataBind();
                }
                else
                    Utils.fc_DisplayAlert(this, "No Se Selecciono Ningun Personal");
                if (grvPersonalDestino.Rows.Count > 0)
                    btnGrabarMasivo.Visible = true;
                else
                    btnGrabarMasivo.Visible = false;
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            if (cboEstablecimientoOrigen.SelectedValue == cboEstablecimientoDestino.SelectedValue)
            {
                Utils.fc_DisplayAlert(this, "El Establecimiento De Destino Debe Ser Diferente al Origen.");
                return;
            }
            try
            {
                dtPersonalOrigen = (DataTable)ViewState["dtPersonalOrigen"];
                dtPersonalDestino = (DataTable)ViewState["dtPersonalDestino"];
                Boolean ck;
                Boolean sinSeleccionar = true;
                string Personal_Id;
                string Nombre_Completo;
                /*Se recorre las filas del GridView en forma descendente para que no afecte los Index*/
                for (int i = grvPersonalDestino.Rows.Count - 1; i >= 0; i--)
                {
                    ck = ((CheckBox)grvPersonalDestino.Rows[i].FindControl("ckDestino")).Checked;
                    if (ck == true)
                    {
                        sinSeleccionar = false;
                        Personal_Id = grvPersonalDestino.DataKeys[i].Values["Personal_Id"].ToString();
                        Nombre_Completo = grvPersonalDestino.DataKeys[i].Values["Nombre_Completo"].ToString();
                        DataRow row = dtPersonalOrigen.NewRow();
                        row["Personal_Id"] = Personal_Id;
                        row["Nombre_Completo"] = Nombre_Completo;
                        dtPersonalOrigen.Rows.Add(row);
                        dtPersonalDestino.Rows.RemoveAt(i);
                    }
                }
                if (sinSeleccionar == false)
                {
                    grvPersonalOrigen.DataSource = dtPersonalOrigen;
                    grvPersonalOrigen.DataBind();
                    ViewState["dtPersonalOrigen"] = dtPersonalOrigen;
                    ViewState["dtPersonalDestino"] = dtPersonalDestino;

                    grvPersonalDestino.DataSource = dtPersonalDestino;
                    grvPersonalDestino.DataBind();
                }
                else
                    Utils.fc_DisplayAlert(this, "No Se Selecciono Ningun Personal");
                if (grvPersonalDestino.Rows.Count > 0)
                    btnGrabarMasivo.Visible = true;
                else
                    btnGrabarMasivo.Visible = false;
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabarMasivo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Utils.fc_ValidaFiltros(this))
            {
                Utils.fc_DisplayAlert(this, "Por Favor Seleccionar Un Periodo");
                return;
            }
            try
            {
                string Establecimiento_Id;
                string Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                string Personal_Id;
                Int32 cant_Personal;
                cant_Personal = 0;
                Establecimiento_Id = cboEstablecimientoDestino.SelectedValue;
                DataTable dtRpta = new DataTable();
                string msj_Rpta = "";
                foreach (GridViewRow fila in grvPersonalDestino.Rows)
                {
                    Personal_Id = grvPersonalDestino.DataKeys[fila.RowIndex].Values["Personal_Id"].ToString();
                    cant_Personal = cant_Personal + 1;

                    objEPer_Establecimiento = new Ent_Personal_Establecimientos();
                    objEPer_Establecimiento.Personal_Id = Personal_Id;
                    objEPer_Establecimiento.Periodo_Id = Periodo_Id;
                    objEPer_Establecimiento.Establecimiento_Id = Establecimiento_Id;

                    dtRpta = Log_Personal_Establecimientos.Inserta_Masivo_Personal_Establecimientos(objEPer_Establecimiento);
                    msj_Rpta = dtRpta.Rows[0][1].ToString();
                }

                //////objEPer_Establecimiento = new Ent_Personal_Establecimientos();
                //////objEPer_Establecimiento.Personal_Id = Personal_Id;
                //////objEPer_Establecimiento.Periodo_Id = Periodo_Id;
                //////objEPer_Establecimiento.Establecimiento_Id = Establecimiento_Id;
                //////DataTable dtRpta = new DataTable();
                //////dtRpta = Log_Personal_Establecimientos.Inserta_Masivo_Personal_Establecimientos(objEPer_Establecimiento);
                //////string msj_Rpta;
                //////msj_Rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_PersonalEstablecimiento(cboEstablecimiento.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));

                    Limpia_PersonalEstablecimientoDestino();
                    Lista_PersonalEstablecimientoOrigen(cboEstablecimientoOrigen.SelectedValue, Utils.fc_obtiene_Periodo_Id(this));
                    btnGrabarMasivo.Visible = false;
                }
                Utils.fc_DisplayAlert(this, msj_Rpta);
                dtRpta.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvPersonal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
    }
}