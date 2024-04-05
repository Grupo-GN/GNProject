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
    public partial class FrmMntFamiliares : BasePage
    {
        Ent_Familiares objEFamiliares;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                //Utils.fc_JavaScript(this, "fc_ActivaPanelAcreditacion(" + cboVinculo_Familiar.SelectedValue + ");");
                //Utils.fc_JavaScript(this, "fc_ActivaPanelDomicilio(false);");
                Utils.fc_JavaScript(this, "fc_Load();");

                cboPersonal.cargarCombo(Utils.fc_obtiene_Periodo_Id(this), "Todos");
                cboTipoDocumento.cargarCombo("Seleccione");
                cboSexos.cargarCombo("Seleccione");
                carga_Combo_Vinculo_Familiar();
                carga_Combo_Tipo_Doc_Paternidad();
                cboEstados.cargarCombo("");
                cboTipo_Via.cargarCombo("");
                cboTipo_Zona.cargarCombo("");
                cboDepartamentos.cargarCombo("Seleccione");

                pnlAcreditacionDePaternidad.Enabled = false;
                pnlUbicacion.Enabled = false;
                pnlUbigeo.Enabled = false;

                Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);

                //btnActualizar.Visible = false;
            }
            HighlightGridLine();
        }

        void carga_Combo_Vinculo_Familiar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboVinculo_Familiar.DataSource = Log_Familiares.Lista_Vinculo_Familiar();
            cboVinculo_Familiar.DataTextField = "Descripcion";
            cboVinculo_Familiar.DataValueField = "T_vinculo_Id";
            cboVinculo_Familiar.DataBind();
        }

        void carga_Combo_Tipo_Doc_Paternidad()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboTipo_Doc_Paternidad.DataSource = Log_Familiares.Lista_Tipo_Doc_Paternidad();
            cboTipo_Doc_Paternidad.DataTextField = "Descripcion";
            cboTipo_Doc_Paternidad.DataValueField = "Tipo_Doc_Paternidad_Id";
            cboTipo_Doc_Paternidad.DataBind();
        }

        protected void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
            enableTabPanel(true);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            //Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
        }

        void Lista_Familiares(String no_Familiares, String Personal_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEFamiliares = new Ent_Familiares();
                if (no_Familiares.Trim() != String.Empty)
                    objEFamiliares.Apellido_Paterno = no_Familiares; /*apellido paterno guarda el nombre completo*/
                if (Personal_Id.Trim() != String.Empty)
                    objEFamiliares.Personal_Id = Personal_Id;
                DataTable dtFamiliares = new DataTable();
                dtFamiliares = Log_Familiares.Lista_Familiares(objEFamiliares);
                Utils.fc_Adecua_GridView(grvFamiliares, dtFamiliares.Rows.Count);
                grvFamiliares.DataSource = dtFamiliares;
                grvFamiliares.DataBind();
                dtFamiliares.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvFamiliares_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvFamiliares.PageIndex = e.NewPageIndex;
            Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
        }



        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            /*Datos Principales*/
            lblFamiliar_Id.Text = string.Empty;
            lblPersonal.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellido_Paterno.Text = string.Empty;
            txtApellido_Materno.Text = string.Empty;
            cboTipoDocumento.SelectedIndex = 0;
            txtNro_Documento.Text = string.Empty;
            cboSexos.SelectedIndex = 0;
            txtFecha_Nacimiento.Text = string.Empty;
            cboVinculo_Familiar.SelectedIndex = 0;
            pnlAcreditacionDePaternidad.Enabled = false;
            ckAfiliado_EPS.Checked = false;
            cboTipo_Doc_Paternidad.SelectedIndex = 0;
            txtNro_Doc_Paternidad.Text = string.Empty;
            cboEstados.SelectedIndex = 0;
            txtFecha_Alta.Text = string.Empty;
            txtNro_RD_Incapacidad.Text = string.Empty;

            /*Datos Complementarios*/
            ckDomicilio_Propio.Checked = false;
            pnlUbicacion.Enabled = false;
            pnlUbigeo.Enabled = false;
            cboTipo_Via.SelectedIndex = 0;
            txtNombre_Via.Text = string.Empty;
            txtNumero_Via.Text = string.Empty;
            txtInterior_Via.Text = string.Empty;
            cboTipo_Zona.SelectedIndex = 0;
            txtNombre_Zona.Text = string.Empty;
            txtReferencia.Text = string.Empty;
            cboDepartamentos.SelectedIndex = 0;
            cboProvincias.Items.Clear();
            cboDistritos.Items.Clear();
        }

        protected void grvFamiliares_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Familiar_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Familiar_Id = grvFamiliares.DataKeys[row.RowIndex].Values["Familiar_Id"].ToString();

                    //LimpiarCajasTexto();

                    objEFamiliares = new Ent_Familiares();
                    objEFamiliares.Familiar_Id = Familiar_Id;
                    DataTable dtFamiliares = new DataTable();
                    dtFamiliares = Log_Familiares.Lista_Familiares(objEFamiliares);

                    /*Datos Principales*/
                    lblFamiliar_Id.Text = Familiar_Id;
                    lblPersonal.Text = dtFamiliares.Rows[0]["Nombre_Completo_Personal"].ToString();
                    txtNombres.Text = dtFamiliares.Rows[0]["Nombres"].ToString();
                    txtApellido_Paterno.Text = dtFamiliares.Rows[0]["Apellido_Paterno"].ToString();
                    txtApellido_Materno.Text = dtFamiliares.Rows[0]["Apellido_Materno"].ToString();
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Tipo_Doc_Id"].ToString().Trim()))
                        cboTipoDocumento.SelectedValue = dtFamiliares.Rows[0]["Tipo_Doc_Id"].ToString();
                    txtNro_Documento.Text = dtFamiliares.Rows[0]["Nro_Doc"].ToString();
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Sexo_Id"].ToString().Trim()))
                        cboSexos.SelectedValue = dtFamiliares.Rows[0]["Sexo_Id"].ToString();
                    if (Convert.ToDateTime(dtFamiliares.Rows[0]["Fecha_Nacimiento"]).ToString("dd/MM/yyyy") != "01/01/1900")
                        txtFecha_Nacimiento.Text = Convert.ToDateTime(dtFamiliares.Rows[0]["Fecha_Nacimiento"]).ToString("dd/MM/yyyy");
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Tipo_Vinculo_Id"].ToString().Trim()))
                        cboVinculo_Familiar.SelectedValue = dtFamiliares.Rows[0]["Tipo_Vinculo_Id"].ToString();
                    ckAfiliado_EPS.Checked = Convert.ToBoolean(dtFamiliares.Rows[0]["afiliado_eps"]);
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Tipo_Doc_Paternidad_Id"].ToString().Trim()))
                        cboTipo_Doc_Paternidad.SelectedValue = dtFamiliares.Rows[0]["Tipo_Doc_Paternidad_Id"].ToString();
                    txtNro_Doc_Paternidad.Text = dtFamiliares.Rows[0]["Nro_Doc_Paternidad"].ToString();
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Estado_Id"].ToString().Trim()))
                        cboEstados.SelectedValue = dtFamiliares.Rows[0]["Estado_Id"].ToString();
                    if (Convert.ToDateTime(dtFamiliares.Rows[0]["Fecha_Alta"]).ToString("dd/MM/yyyy") != "01/01/1900")
                        txtFecha_Alta.Text = Convert.ToDateTime(dtFamiliares.Rows[0]["Fecha_Alta"]).ToString("dd/MM/yyyy");
                    txtNro_RD_Incapacidad.Text = dtFamiliares.Rows[0]["Nro_RD_Incapacidad"].ToString();
                    /*Datos Complementarios*/
                    ckDomicilio_Propio.Checked = Convert.ToBoolean(dtFamiliares.Rows[0]["Domicilio_Propio"]);
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Tipo_Via_Id"].ToString().Trim()))
                        cboTipo_Via.SelectedValue = dtFamiliares.Rows[0]["Tipo_Via_Id"].ToString();
                    txtNombre_Via.Text = dtFamiliares.Rows[0]["Nombre_Via"].ToString();
                    txtNumero_Via.Text = dtFamiliares.Rows[0]["Numero_Via"].ToString();
                    txtInterior_Via.Text = dtFamiliares.Rows[0]["Interior_Via"].ToString();
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Tipo_Zona_Id"].ToString().Trim()))
                        cboTipo_Zona.SelectedValue = dtFamiliares.Rows[0]["Tipo_Zona_Id"].ToString();
                    txtNombre_Zona.Text = dtFamiliares.Rows[0]["Nombre_Zona"].ToString();
                    txtReferencia.Text = dtFamiliares.Rows[0]["Referencia"].ToString();
                    if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Dpto"].ToString().Trim()))
                    {
                        cboDepartamentos.SelectedValue = dtFamiliares.Rows[0]["Dpto"].ToString();
                        cboProvincias.cargarCombo(cboDepartamentos.SelectedValue, "Seleccione");
                        if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Prov"].ToString().Trim()))
                        {
                            cboProvincias.SelectedValue = dtFamiliares.Rows[0]["Prov"].ToString();
                            cboDistritos.cargarCombo(cboDepartamentos.SelectedValue, cboProvincias.SelectedValue, "Seleccione");
                            if (!String.IsNullOrEmpty(dtFamiliares.Rows[0]["Dist"].ToString().Trim()))
                                cboDistritos.SelectedValue = dtFamiliares.Rows[0]["Dist"].ToString();
                            else
                                cboDistritos.Items.Clear();
                        }
                        else
                            cboDistritos.Items.Clear();
                    }
                    else
                    {
                        cboProvincias.Items.Clear();
                        cboDistritos.Items.Clear();
                    }

                    if (cboVinculo_Familiar.SelectedValue != "04")
                        pnlAcreditacionDePaternidad.Enabled = false;
                    else
                        pnlAcreditacionDePaternidad.Enabled = true;
                    if (ckDomicilio_Propio.Checked == true)
                    {
                        pnlUbicacion.Enabled = true;
                        pnlUbigeo.Enabled = true;
                    }
                    else
                    {
                        pnlUbicacion.Enabled = false;
                        pnlUbigeo.Enabled = false;
                    }

                    //btnGrabar.Visible = false;
                    //btnActualizar.Visible = true;
                    enableAdd(false);
                    enableUpdate(true);
                    enableNew(false);
                    enableCancel(true);
                    TabContainer1.ActiveTabIndex = 1;
                    txtNombres.Focus();
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvFamiliares_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Familiar_Id;
                Familiar_Id = grvFamiliares.DataKeys[e.RowIndex].Values["Familiar_Id"].ToString();
                objEFamiliares = new Ent_Familiares();
                objEFamiliares.Familiar_Id = Familiar_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Familiares.Elimina_Familiares(objEFamiliares);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    //btnActualizar.Visible = false;
                    enableAdd(false);
                    enableUpdate(false);
                    enableNew(true);
                    enableCancel(false);
                    Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        #region BotonesAnterior

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!Utils.fc_ValidaFiltros(this))
            //    {
            //        Utils.fc_DisplayAlert(this, "Seleccionar un Periodo");
            //        return;
            //    }

            //    objEFamiliares = new Ent_Familiares();
            //    objEFamiliares.Personal_Id = cboPersonal.SelectedValue;
            //    objEFamiliares.Apellido_Paterno = txtApellido_Paterno.Text.ToUpper();
            //    objEFamiliares.Apellido_Materno = txtApellido_Materno.Text.ToUpper();
            //    objEFamiliares.Nombres = txtNombres.Text.ToUpper();
            //    objEFamiliares.Sexo_Id = cboSexos.SelectedValue;
            //    objEFamiliares.Tipo_Vinculo_Id = cboVinculo_Familiar.SelectedValue;
            //    objEFamiliares.Fecha_Nacimiento = Convert.ToDateTime(txtFecha_Nacimiento.Text);
            //    objEFamiliares.Tipo_Doc_Id = cboTipoDocumento.SelectedValue;
            //    objEFamiliares.Nro_Doc = txtNro_Documento.Text;
            //    //objEFamiliares.Tipo_Carta_Id = 
            //    //objEFamiliares.Nro_Carta_Atencion =
            //    objEFamiliares.Domicilio_Propio = ckDomicilio_Propio.Checked;
            //    objEFamiliares.Dpto = cboDepartamentos.SelectedValue;
            //    objEFamiliares.Prov = cboProvincias.SelectedValue;
            //    objEFamiliares.Dist = cboDistritos.SelectedValue;
            //    //objEFamiliares.Motivo_Baja_Id =
            //    objEFamiliares.Estado_Id = cboEstados.SelectedValue;
            //    objEFamiliares.Tipo_Doc_Paternidad_Id = cboTipo_Doc_Paternidad.SelectedValue;
            //    objEFamiliares.Nro_Doc_Paternidad = txtNro_Doc_Paternidad.Text;
            //    if (txtFecha_Alta.Text.Trim() != string.Empty)
            //        objEFamiliares.Fecha_Alta = Convert.ToDateTime(txtFecha_Alta.Text);
            //    else
            //        objEFamiliares.Fecha_Alta = Convert.ToDateTime("1900/01/01");
            //    objEFamiliares.Fecha_Baja = Convert.ToDateTime("1900/01/01");
            //    //objEFamiliares.Tipo_Baja_DH_Id =
            //    objEFamiliares.Nro_RD_Incapacidad = txtNro_RD_Incapacidad.Text;
            //    objEFamiliares.Tipo_Via_Id = cboTipo_Via.SelectedValue;
            //    objEFamiliares.Nombre_Via = txtNombre_Via.Text.ToUpper();
            //    objEFamiliares.Numero_Via = txtNumero_Via.Text;
            //    objEFamiliares.Interior_Via = txtInterior_Via.Text;
            //    objEFamiliares.Tipo_Zona_Id = cboTipo_Zona.SelectedValue;
            //    objEFamiliares.Nombre_Zona = txtNombre_Zona.Text.ToUpper();
            //    objEFamiliares.Referencia = txtReferencia.Text.ToUpper();
            //    objEFamiliares.Afiliado_eps = ckAfiliado_EPS.Checked;
            //    //objEFamiliares.PAIS_EMISOR_DOC_ID =
            //    objEFamiliares.MES_CONCEPCION = Convert.ToDateTime("1900/01/01");
            //    //objEFamiliares.DEPARTAMENTO =
            //    //objEFamiliares.MANZANA =
            //    //objEFamiliares.LOTE =
            //    //objEFamiliares.KILOMETRO =
            //    //objEFamiliares.BLOCK =
            //    //objEFamiliares.ETAPA =
            //    //objEFamiliares.LDISTANCIA_ID =
            //    //objEFamiliares.TELEFONO =
            //    //objEFamiliares.CORREO =

            //    DataTable dtRpta = new DataTable();
            //    dtRpta = Log_Familiares.Inserta_Familiares(objEFamiliares);

            //    string msj_rpta;
            //    msj_rpta = dtRpta.Rows[0][1].ToString();
            //    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            //    {
            //        lblFamiliar_Id.Text = dtRpta.Rows[0][2].ToString();
            //        Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
            //        btnGrabar.Visible = false;
            //        btnActualizar.Visible = true;
            //    }
            //    dtRpta.Dispose();
            //    Utils.fc_DisplayAlert(this, msj_rpta);
            //}
            //catch (Exception ex)
            //{
            //    Utils.fc_DisplayAlert(this, ex.Message);
            //}
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //LimpiarCajasTexto();
            //TabContainer1.ActiveTabIndex = 1;
            //lblFamiliar_Id.Text = string.Empty;
            //lblPersonal.Text = cboPersonal.SelectedText;
            //txtNombres.Focus();
            //btnActualizar.Visible = false;
            //btnGrabar.Visible = true;
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //if (lblFamiliar_Id.Text.Trim() == String.Empty)
            //{
            //    Utils.fc_DisplayAlert(this, "Seleccionar un Familiar.");
            //    TabContainer1.ActiveTabIndex = 0;
            //    return;
            //}
            //try
            //{
            //    objEFamiliares = new Ent_Familiares();
            //    objEFamiliares.Familiar_Id = lblFamiliar_Id.Text;
            //    objEFamiliares.Personal_Id = cboPersonal.SelectedValue;
            //    objEFamiliares.Apellido_Paterno = txtApellido_Paterno.Text.ToUpper();
            //    objEFamiliares.Apellido_Materno = txtApellido_Materno.Text.ToUpper();
            //    objEFamiliares.Nombres = txtNombres.Text.ToUpper();
            //    objEFamiliares.Sexo_Id = cboSexos.SelectedValue;
            //    objEFamiliares.Tipo_Vinculo_Id = cboVinculo_Familiar.SelectedValue;
            //    objEFamiliares.Fecha_Nacimiento = Convert.ToDateTime(txtFecha_Nacimiento.Text);
            //    objEFamiliares.Tipo_Doc_Id = cboTipoDocumento.SelectedValue;
            //    objEFamiliares.Nro_Doc = txtNro_Documento.Text;
            //    //objEFamiliares.Tipo_Carta_Id = 
            //    //objEFamiliares.Nro_Carta_Atencion =
            //    objEFamiliares.Domicilio_Propio = ckDomicilio_Propio.Checked;
            //    objEFamiliares.Dpto = cboDepartamentos.SelectedValue;
            //    objEFamiliares.Prov = cboProvincias.SelectedValue;
            //    objEFamiliares.Dist = cboDistritos.SelectedValue;
            //    //objEFamiliares.Motivo_Baja_Id =
            //    objEFamiliares.Estado_Id = cboEstados.SelectedValue;
            //    objEFamiliares.Tipo_Doc_Paternidad_Id = cboTipo_Doc_Paternidad.SelectedValue;
            //    objEFamiliares.Nro_Doc_Paternidad = txtNro_Doc_Paternidad.Text;
            //    if (txtFecha_Alta.Text.Trim() != string.Empty)
            //        objEFamiliares.Fecha_Alta = Convert.ToDateTime(txtFecha_Alta.Text);
            //    else
            //        objEFamiliares.Fecha_Alta = Convert.ToDateTime("1900/01/01");
            //    objEFamiliares.Fecha_Baja = Convert.ToDateTime("1900/01/01");
            //    //objEFamiliares.Tipo_Baja_DH_Id =
            //    objEFamiliares.Nro_RD_Incapacidad = txtNro_RD_Incapacidad.Text;
            //    objEFamiliares.Tipo_Via_Id = cboTipo_Via.SelectedValue;
            //    objEFamiliares.Nombre_Via = txtNombre_Via.Text.ToUpper();
            //    objEFamiliares.Numero_Via = txtNumero_Via.Text;
            //    objEFamiliares.Interior_Via = txtInterior_Via.Text;
            //    objEFamiliares.Tipo_Zona_Id = cboTipo_Zona.SelectedValue;
            //    objEFamiliares.Nombre_Zona = txtNombre_Zona.Text.ToUpper();
            //    objEFamiliares.Referencia = txtReferencia.Text.ToUpper();
            //    objEFamiliares.Afiliado_eps = ckAfiliado_EPS.Checked;
            //    //objEFamiliares.PAIS_EMISOR_DOC_ID =
            //    objEFamiliares.MES_CONCEPCION = Convert.ToDateTime("1900/01/01");
            //    //objEFamiliares.DEPARTAMENTO =
            //    //objEFamiliares.MANZANA =
            //    //objEFamiliares.LOTE =
            //    //objEFamiliares.KILOMETRO =
            //    //objEFamiliares.BLOCK =
            //    //objEFamiliares.ETAPA =
            //    //objEFamiliares.LDISTANCIA_ID =
            //    //objEFamiliares.TELEFONO =
            //    //objEFamiliares.CORREO =

            //    DataTable dtRpta = new DataTable();
            //    dtRpta = Log_Familiares.Actualiza_Familiares(objEFamiliares);

            //    string msj_rpta;
            //    msj_rpta = dtRpta.Rows[0][1].ToString();
            //    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            //    {
            //        Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
            //    }
            //    dtRpta.Dispose();
            //    Utils.fc_DisplayAlert(this, msj_rpta);
            //}
            //catch (Exception ex)
            //{
            //    Utils.fc_DisplayAlert(this, ex.Message);
            //}
        }
        #endregion


        protected void cboDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (cboDepartamentos.SelectedIndex == 0)
            {
                cboDistritos.Items.Clear();

                cboProvincias.Items.Clear();
            }
            else
            {
                cboProvincias.cargarCombo(cboDepartamentos.SelectedValue, "Seleccione");
                cboDistritos.Items.Clear();
            }
        }

        protected void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (cboProvincias.SelectedIndex == 0)
                cboDistritos.Items.Clear();
            else
                cboDistritos.cargarCombo(cboDepartamentos.SelectedValue, cboProvincias.SelectedValue, "Seleccione");
        }

        protected void ckDomicilio_Propio_CheckedChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            bool fl_check;
            fl_check = ckDomicilio_Propio.Checked;

            pnlUbicacion.Enabled = fl_check;
            pnlUbigeo.Enabled = fl_check;
        }
        protected void cboVinculo_Familiar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (cboVinculo_Familiar.SelectedValue == "04")
                pnlAcreditacionDePaternidad.Enabled = true;
            else
            {
                cboTipo_Doc_Paternidad.SelectedIndex = 0;
                txtNro_Doc_Paternidad.Text = string.Empty;
                pnlAcreditacionDePaternidad.Enabled = false;
            }
        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblFamiliar_Id.Text = string.Empty;
            lblPersonal.Text = cboPersonal.SelectedText;
            txtNombres.Focus();
            //btnActualizar.Visible = false;
            //btnGrabar.Visible = true;
            enableAdd(true);
            enableUpdate(false);
            enableNew(false);
            enableCancel(true);
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (!Utils.fc_ValidaFiltros(this))
                {
                    Utils.fc_DisplayAlert(this, "Seleccionar un Periodo");
                    return;
                }

                objEFamiliares = new Ent_Familiares();
                objEFamiliares.Personal_Id = cboPersonal.SelectedValue;
                objEFamiliares.Apellido_Paterno = txtApellido_Paterno.Text.ToUpper();
                objEFamiliares.Apellido_Materno = txtApellido_Materno.Text.ToUpper();
                objEFamiliares.Nombres = txtNombres.Text.ToUpper();
                objEFamiliares.Sexo_Id = cboSexos.SelectedValue;
                objEFamiliares.Tipo_Vinculo_Id = cboVinculo_Familiar.SelectedValue;
                objEFamiliares.Fecha_Nacimiento = Convert.ToDateTime(txtFecha_Nacimiento.Text);
                objEFamiliares.Tipo_Doc_Id = cboTipoDocumento.SelectedValue;
                objEFamiliares.Nro_Doc = txtNro_Documento.Text;
                //objEFamiliares.Tipo_Carta_Id = 
                //objEFamiliares.Nro_Carta_Atencion =
                objEFamiliares.Domicilio_Propio = ckDomicilio_Propio.Checked;
                objEFamiliares.Dpto = cboDepartamentos.SelectedValue;
                objEFamiliares.Prov = cboProvincias.SelectedValue;
                objEFamiliares.Dist = cboDistritos.SelectedValue;
                //objEFamiliares.Motivo_Baja_Id =
                objEFamiliares.Estado_Id = cboEstados.SelectedValue;
                objEFamiliares.Tipo_Doc_Paternidad_Id = cboTipo_Doc_Paternidad.SelectedValue;
                objEFamiliares.Nro_Doc_Paternidad = txtNro_Doc_Paternidad.Text;
                if (txtFecha_Alta.Text.Trim() != string.Empty)
                    objEFamiliares.Fecha_Alta = Convert.ToDateTime(txtFecha_Alta.Text);
                else
                    objEFamiliares.Fecha_Alta = Convert.ToDateTime("1900/01/01");
                objEFamiliares.Fecha_Baja = Convert.ToDateTime("1900/01/01");
                //objEFamiliares.Tipo_Baja_DH_Id =
                objEFamiliares.Nro_RD_Incapacidad = txtNro_RD_Incapacidad.Text;
                objEFamiliares.Tipo_Via_Id = cboTipo_Via.SelectedValue;
                objEFamiliares.Nombre_Via = txtNombre_Via.Text.ToUpper();
                objEFamiliares.Numero_Via = txtNumero_Via.Text;
                objEFamiliares.Interior_Via = txtInterior_Via.Text;
                objEFamiliares.Tipo_Zona_Id = cboTipo_Zona.SelectedValue;
                objEFamiliares.Nombre_Zona = txtNombre_Zona.Text.ToUpper();
                objEFamiliares.Referencia = txtReferencia.Text.ToUpper();
                objEFamiliares.Afiliado_eps = ckAfiliado_EPS.Checked;
                //objEFamiliares.PAIS_EMISOR_DOC_ID =
                objEFamiliares.MES_CONCEPCION = Convert.ToDateTime("1900/01/01");
                //objEFamiliares.DEPARTAMENTO =
                //objEFamiliares.MANZANA =
                //objEFamiliares.LOTE =
                //objEFamiliares.KILOMETRO =
                //objEFamiliares.BLOCK =
                //objEFamiliares.ETAPA =
                //objEFamiliares.LDISTANCIA_ID =
                //objEFamiliares.TELEFONO =
                //objEFamiliares.CORREO =

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Familiares.Inserta_Familiares(objEFamiliares);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblFamiliar_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);

                    //btnGrabar.Visible = false;
                    //btnActualizar.Visible = true;
                    enableAdd(false);
                    enableUpdate(false);
                    enableNew(true);
                    enableCancel(false);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
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
            LimpiarCajasTexto();
            cboPersonal.SelectedIndex = -1;
            Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
            TabContainer1.ActiveTabIndex = 0;
            txtFamiliaresBuscar.Focus();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblFamiliar_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Familiar.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEFamiliares = new Ent_Familiares();
                objEFamiliares.Familiar_Id = lblFamiliar_Id.Text;
                objEFamiliares.Personal_Id = cboPersonal.SelectedValue;
                objEFamiliares.Apellido_Paterno = txtApellido_Paterno.Text.ToUpper();
                objEFamiliares.Apellido_Materno = txtApellido_Materno.Text.ToUpper();
                objEFamiliares.Nombres = txtNombres.Text.ToUpper();
                objEFamiliares.Sexo_Id = cboSexos.SelectedValue;
                objEFamiliares.Tipo_Vinculo_Id = cboVinculo_Familiar.SelectedValue;
                objEFamiliares.Fecha_Nacimiento = Convert.ToDateTime(txtFecha_Nacimiento.Text);
                objEFamiliares.Tipo_Doc_Id = cboTipoDocumento.SelectedValue;
                objEFamiliares.Nro_Doc = txtNro_Documento.Text;
                //objEFamiliares.Tipo_Carta_Id = 
                //objEFamiliares.Nro_Carta_Atencion =
                objEFamiliares.Domicilio_Propio = ckDomicilio_Propio.Checked;
                objEFamiliares.Dpto = cboDepartamentos.SelectedValue;
                objEFamiliares.Prov = cboProvincias.SelectedValue;
                objEFamiliares.Dist = cboDistritos.SelectedValue;
                //objEFamiliares.Motivo_Baja_Id =
                objEFamiliares.Estado_Id = cboEstados.SelectedValue;
                objEFamiliares.Tipo_Doc_Paternidad_Id = cboTipo_Doc_Paternidad.SelectedValue;
                objEFamiliares.Nro_Doc_Paternidad = txtNro_Doc_Paternidad.Text;
                if (txtFecha_Alta.Text.Trim() != string.Empty)
                    objEFamiliares.Fecha_Alta = Convert.ToDateTime(txtFecha_Alta.Text);
                else
                    objEFamiliares.Fecha_Alta = Convert.ToDateTime("1900/01/01");
                objEFamiliares.Fecha_Baja = Convert.ToDateTime("1900/01/01");
                //objEFamiliares.Tipo_Baja_DH_Id =
                objEFamiliares.Nro_RD_Incapacidad = txtNro_RD_Incapacidad.Text;
                objEFamiliares.Tipo_Via_Id = cboTipo_Via.SelectedValue;
                objEFamiliares.Nombre_Via = txtNombre_Via.Text.ToUpper();
                objEFamiliares.Numero_Via = txtNumero_Via.Text;
                objEFamiliares.Interior_Via = txtInterior_Via.Text;
                objEFamiliares.Tipo_Zona_Id = cboTipo_Zona.SelectedValue;
                objEFamiliares.Nombre_Zona = txtNombre_Zona.Text.ToUpper();
                objEFamiliares.Referencia = txtReferencia.Text.ToUpper();
                objEFamiliares.Afiliado_eps = ckAfiliado_EPS.Checked;
                //objEFamiliares.PAIS_EMISOR_DOC_ID =
                objEFamiliares.MES_CONCEPCION = Convert.ToDateTime("1900/01/01");
                //objEFamiliares.DEPARTAMENTO =
                //objEFamiliares.MANZANA =
                //objEFamiliares.LOTE =
                //objEFamiliares.KILOMETRO =
                //objEFamiliares.BLOCK =
                //objEFamiliares.ETAPA =
                //objEFamiliares.LDISTANCIA_ID =
                //objEFamiliares.TELEFONO =
                //objEFamiliares.CORREO =

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Familiares.Actualiza_Familiares(objEFamiliares);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        //protected void cboDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboDepartamentos.SelectedIndex == 0)
        //    {
        //        cboDistritos.Items.Clear();
        //        cboProvincias.Items.Clear();
        //    }
        //    else
        //    {
        //        cboProvincias.cargarCombo(cboDepartamentos.SelectedValue, "Seleccione");
        //        cboDistritos.Items.Clear();
        //    }
        //}

        protected void btnFind_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Familiares(txtFamiliaresBuscar.Text, cboPersonal.SelectedValue);
        }
        protected void grvFamiliares_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }


        #region barraHerramientas
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
        private void enableTabPanel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            TabPanel2.Enabled = opcion;
            TabPanel3.Enabled = opcion;
            //TabPanel4.Enabled = opcion;
        }

        #endregion

    }
}