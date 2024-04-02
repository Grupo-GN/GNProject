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
    public partial class FrmMntConceptos : BasePage
    {
        Ent_Conceptos objEConceptos;
        InterfacesExportacion objInt = new InterfacesExportacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

                Carga_combo_Estados();
                Carga_combo_Grupo();
                Carga_combo_Columna_Boleta();
                Carga_combo_Procesos();
                Lista_Conceptos(txtConceptosBuscar.Text);
                Carga_combo_Concepto_Remunerativo(0);
                //////cargaEstructuraPlame();

                //btnActualizar.Visible = false;
                //btnGrabar.Visible = false;
                //btnNuevo.Visible = false;
            }
            HighlightGridLine();
        }

        //////private void cargaEstructuraPlame() {
        //////    ListItem elItem= new ListItem();
        //////    elItem.Value="00";
        //////    elItem.Text="--Seleccione--";
        //////    cboEstructura.DataSource = objInt.GetListaPlame_Listar();
        //////    cboEstructura.DataTextField = "ms_ms_EstructuraPlame_Descripcion";
        //////    cboEstructura.DataValueField = "ms_EstructuraPlame_Id";
        //////    cboEstructura.DataBind();
        //////    cboEstructura.Items.Insert(0, elItem);
        //////}

        void Carga_combo_Estados()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }
        void Carga_combo_Grupo()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboGrupo_Concepto.DataSource = Log_Conceptos.Lista_Grupo_Conceptos();
            cboGrupo_Concepto.DataTextField = "Descripcion";
            cboGrupo_Concepto.DataValueField = "Grupocpt_ID";
            cboGrupo_Concepto.DataBind();
            cboGrupo_Concepto.Items.Insert(0, new ListItem("--Ninguno--", ""));
        }
        void Carga_combo_Columna_Boleta()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtColumnBoleta = new DataTable();
            dtColumnBoleta = Log_Conceptos.Lista_Columnas_Boleta();
            cboBoleta_Columna.DataSource = dtColumnBoleta;
            cboBoleta_Columna.DataTextField = "Descripcion";
            cboBoleta_Columna.DataValueField = "Columna_Id";
            cboBoleta_Columna.DataBind();
            cboBoleta_Columna.Items.Insert(0, new ListItem("--Ninguno--", ""));

            cboCubo_Columna.DataSource = dtColumnBoleta;
            cboCubo_Columna.DataTextField = "Descripcion";
            cboCubo_Columna.DataValueField = "Columna_Id";
            cboCubo_Columna.DataBind();
            cboCubo_Columna.Items.Insert(0, new ListItem("--Ninguno--", ""));

            dtColumnBoleta.Dispose();
        }

        void Carga_combo_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Procesos objEProc = new Ent_Procesos();
            DataTable dtProcesos = new DataTable();
            dtProcesos = Log_Procesos.Lista_Procesos(objEProc);
            cboBoleta_Proceso.DataSource = dtProcesos;
            cboBoleta_Proceso.DataTextField = "Proceso";
            cboBoleta_Proceso.DataValueField = "Proceso_Id";
            cboBoleta_Proceso.DataBind();
            cboBoleta_Proceso.Items.Insert(0, new ListItem("--Ninguno--", ""));

            cboCubo_Proceso.DataSource = dtProcesos;
            cboCubo_Proceso.DataTextField = "Proceso";
            cboCubo_Proceso.DataValueField = "Proceso_Id";
            cboCubo_Proceso.DataBind();
            cboCubo_Proceso.Items.Insert(0, new ListItem("--Ninguno--", ""));
            dtProcesos.Dispose();
        }

        void Carga_combo_Concepto_Remunerativo(int flag)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboConcepto_Remunerativo.DataSource = Log_Concepto_Remunerativo.Lista_Concepto_Remunerativo(flag);
            cboConcepto_Remunerativo.DataTextField = "Descripcion";
            cboConcepto_Remunerativo.DataValueField = "Concepto_Remunerativo_Id";
            cboConcepto_Remunerativo.DataBind();
            cboConcepto_Remunerativo.Items.Insert(0, new ListItem("--Ninguno--", "00"));
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Conceptos(txtConceptosBuscar.Text);
        }

        void Lista_Conceptos(string no_Conceptos)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEConceptos = new Ent_Conceptos();
                if (no_Conceptos.Trim() != string.Empty)
                    objEConceptos.Descripcion = no_Conceptos;
                Ent_Procesos objEProc = new Ent_Procesos();
                DataTable dtConceptos = new DataTable();
                dtConceptos = Log_Conceptos.Lista_Conceptos(objEConceptos, objEProc);
                Utils.fc_Adecua_GridView(grvConceptos, dtConceptos.Rows.Count);
                grvConceptos.DataSource = dtConceptos;
                grvConceptos.DataBind();
                dtConceptos.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvConceptos.PageIndex = e.NewPageIndex;
            Lista_Conceptos(txtConceptosBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            //btnActualizar.Visible = false;
            //btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            /*Datos Principales*/
            lblConcepto_Id.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtNombre_Abrev.Text = string.Empty;
            cboEstado.SelectedIndex = 0;
            rbParamExterno.Checked = false;
            rbDatoGeneral.Checked = false;
            rbFormulaStandard.Checked = false;
            rbFormulaAcumulable.Checked = false;
            rbDatoFijo.Checked = false;
            rbDatoVariable.Checked = false;
            rbFuncionInterna.Checked = false;
            rbTablaDelSistema.Checked = false;

            rbPorAFP.Checked = false;
            rbPorPeriodo.Checked = false;
            rbPorSituacion.Checked = false;
            rbPorCtaCte.Checked = false;
            rbPorCompania.Checked = false;
            rbPorTipoPlanilla.Checked = false;
            rbPorEPS.Checked = false;
            rbPorPersonal.Checked = false;
            rbPorCatAux.Checked = false;
            rbPorCatAux2.Checked = false;
            rbPorCatDinamica.Checked = false;
            /*Datos Secundarios*/
            txtValor_Defecto.Text = string.Empty;
            txtNro_Decimales.Text = string.Empty;
            cboGrupo_Concepto.SelectedIndex = 0;
            txtComentario.Text = string.Empty;
            ckMostrar_En_Boleta.Checked = false;
            cboBoleta_Columna.SelectedIndex = 0;
            txtBoleta_nro_orden.Text = string.Empty;
            cboBoleta_Proceso.SelectedIndex = 0;
            ckMostrar_En_Cubo.Checked = false;
            cboCubo_Columna.SelectedIndex = 0;
            cboCubo_Proceso.SelectedIndex = 0;
            //cboConcepto_Remunerativo.SelectedIndex = 0;
            /*Otros*/
            txtCodigo_Auxiliar.Text = string.Empty;
            ckTotal.Checked = false;
            ckMostrarEnAsiento.Checked = false;
            ckMostrar_TotalizadoAnual.Checked = false;
            ckMostrar_TotalizadoAnualMinus.Checked = false;
            ckMostrar_TotalizadoAnualDias.Checked = false;
            ckMostrar_TotalizadoAnualDiasMinus.Checked = false;
            ckMostrar_UtilidadesRemuVigente.Checked = false;
            ckMostrar_UtilidadesRemuVigenteMinus.Checked = false;
            ckI_Acumulados.Checked = false;
            ckDoble_FF.Checked = false;
            chkCero.Checked = false;
            //////cboInterfaz.SelectedValue = "00";
            //////cboEstructura.SelectedValue = "00";
        }

        private void rb_Tipo_Dato_SelectedValue(string Tipo_Dato)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            rbParamExterno.Checked = false;
            rbDatoGeneral.Checked = false;
            rbFormulaStandard.Checked = false;
            rbFormulaAcumulable.Checked = false;
            rbDatoFijo.Checked = false;
            rbDatoVariable.Checked = false;
            rbFuncionInterna.Checked = false;
            rbTablaDelSistema.Checked = false;
            switch (Tipo_Dato)
            {
                case "00": rbParamExterno.Checked = true; break;
                case "05": rbDatoGeneral.Checked = true; break;
                case "03": rbFormulaStandard.Checked = true; break;
                case "04": rbFormulaAcumulable.Checked = true; break;
                case "01": rbDatoFijo.Checked = true; break;
                case "02": rbDatoVariable.Checked = true; break;
                case "06": rbFuncionInterna.Checked = true; break;
                case "07": rbTablaDelSistema.Checked = true; break;
            }
        }
        private string fc_rb_Tipo_Dato_SelectedValue()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Tipo_Dato;
            if (rbParamExterno.Checked == true)
                Tipo_Dato = "00";
            else if (rbDatoGeneral.Checked == true)
                Tipo_Dato = "05";
            else if (rbFormulaStandard.Checked == true)
                Tipo_Dato = "03";
            else if (rbFormulaAcumulable.Checked == true)
                Tipo_Dato = "04";
            else if (rbDatoFijo.Checked == true)
                Tipo_Dato = "01";
            else if (rbDatoVariable.Checked == true)
                Tipo_Dato = "02";
            else if (rbFuncionInterna.Checked == true)
                Tipo_Dato = "06";
            else if (rbTablaDelSistema.Checked == true)
                Tipo_Dato = "07";
            else Tipo_Dato = "";
            return Tipo_Dato;
        }
        void rb_Origen_Concepto_SelectedValue(string Origen)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            rbPorAFP.Checked = false;
            rbPorPeriodo.Checked = false;
            rbPorSituacion.Checked = false;
            rbPorCtaCte.Checked = false;
            rbPorCompania.Checked = false;
            rbPorTipoPlanilla.Checked = false;
            rbPorEPS.Checked = false;
            rbPorPersonal.Checked = false;
            rbPorCatAux.Checked = false;
            rbPorCatAux2.Checked = false;
            rbPorCatDinamica.Checked = false;
            switch (Origen)
            {

                case "02": rbPorAFP.Checked = true; break;
                case "07": rbPorPeriodo.Checked = true; break;
                case "08": rbPorSituacion.Checked = true; break;
                case "10": rbPorCtaCte.Checked = true; break;
                case "03": rbPorCompania.Checked = true; break;
                case "04": rbPorTipoPlanilla.Checked = true; break;
                case "11": rbPorEPS.Checked = true; break;
                case "01": rbPorPersonal.Checked = true; break;
                    /*Para estos casos no se selecciona ninguno*/
                    //////case "": rbPorCatAux.Checked = true; break;
                    //////case "": rbPorCatAux2.Checked = true; break;
                    //////case "": rbPorCatDinamica.Checked = true; break;
            }
        }
        private string fc_rb_Origen_Concepto_SelectedValue()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Origen;
            if (rbPorAFP.Checked == true)
                Origen = "02";
            else if (rbPorPeriodo.Checked == true)
                Origen = "07";
            else if (rbPorSituacion.Checked == true)
                Origen = "08";
            else if (rbPorCtaCte.Checked == true)
                Origen = "10";
            else if (rbPorCompania.Checked == true)
                Origen = "03";
            else if (rbPorTipoPlanilla.Checked == true)
                Origen = "04";
            else if (rbPorEPS.Checked == true)
                Origen = "11";
            else if (rbPorPersonal.Checked == true)
                Origen = "01";
            /*Para estos casos no se selecciona ninguno*/
            //////else if (rbPorCatAux.Checked == true)
            //////    Origen = "";
            //////else if (rbPorCatAux2.Checked == true)
            //////    Origen = "";
            //////else if (rbPorCatDinamica.Checked == true)
            //////    Origen = "";
            else
                Origen = "";

            return Origen;
        }

        protected void grvConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                string Concepto_Id;
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Concepto_Id = grvConceptos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();

                LimpiarCajasTexto();

                objEConceptos = new Ent_Conceptos();
                objEConceptos.Concepto_Id = Concepto_Id;
                Ent_Procesos objEProc = new Ent_Procesos();
                DataTable dtConceptos = new DataTable();
                dtConceptos = Log_Conceptos.Lista_Conceptos(objEConceptos, objEProc);

                /*Datos Principales*/
                lblConcepto_Id.Text = Concepto_Id;
                txtDescripcion.Text = dtConceptos.Rows[0]["Descripcion"].ToString();
                txtDetalle.Text = dtConceptos.Rows[0]["Detalle"].ToString();
                txtNombre_Abrev.Text = dtConceptos.Rows[0]["Nombre_Abrev"].ToString();
                cboEstado.SelectedValue = dtConceptos.Rows[0]["Estado_Id"].ToString();

                rb_Tipo_Dato_SelectedValue(dtConceptos.Rows[0]["Tipo_Dato"].ToString().Trim());
                //////rbParamExterno.Checked = false;
                //////rbDatoGeneral.Checked = false;
                //////rbFormulaStandard.Checked = false;
                //////rbFormulaAcumulable.Checked = false;
                //////rbDatoFijo.Checked = false;
                //////rbDatoVariable.Checked = false;
                //////rbFuncionInterna.Checked = false;
                //////rbTablaDelSistema.Checked = false;

                rb_Origen_Concepto_SelectedValue(dtConceptos.Rows[0]["Origen"].ToString().Trim());
                //////rbPorAFP.Checked = false;
                //////rbPorPeriodo.Checked = false;
                //////rbPorSituacion.Checked = false;
                //////rbPorCtaCte.Checked = false;
                //////rbPorCompania.Checked = false;
                //////rbPorTipoPlanilla.Checked = false;
                //////rbPorEPS.Checked = false;
                //////rbPorPersonal.Checked = false;
                //////rbPorCatAux.Checked = false;
                //////rbPorCatAux2.Checked = false;
                //////rbPorCatDinamica.Checked = false;

                /*Datos Secundarios*/
                txtValor_Defecto.Text = dtConceptos.Rows[0]["Valor_defecto"].ToString();
                txtNro_Decimales.Text = dtConceptos.Rows[0]["Nro_Decimales"].ToString();
                if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Grupo_Id"].ToString().Trim()))
                    cboGrupo_Concepto.SelectedValue = dtConceptos.Rows[0]["Grupo_Id"].ToString().Trim();
                txtComentario.Text = dtConceptos.Rows[0]["Comentario"].ToString().Trim();
                ckMostrar_En_Boleta.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_En_Boleta"]);

                if (dtConceptos.Rows[0]["Boleta_Columna"].ToString().Trim() == "00")
                    cboBoleta_Columna.SelectedValue = "";
                else if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Boleta_Columna"].ToString().Trim()))
                    cboBoleta_Columna.SelectedValue = dtConceptos.Rows[0]["Boleta_Columna"].ToString().Trim();

                txtBoleta_nro_orden.Text = dtConceptos.Rows[0]["Boleta_nro_orden"].ToString();
                if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Boleta_Proceso"].ToString().Trim()))
                    cboBoleta_Proceso.SelectedValue = dtConceptos.Rows[0]["Boleta_Proceso"].ToString().Trim();
                ckMostrar_En_Cubo.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_En_Cubo"]);
                //20160618
                string xcubocol = dtConceptos.Rows[0]["Cubo_Columna"].ToString().Trim();
                string xcuboproc = dtConceptos.Rows[0]["Cubo_Proceso"].ToString().Trim();
                if (xcubocol != null && xcubocol != "" && xcubocol != "00")
                {
                    cboCubo_Columna.SelectedValue = dtConceptos.Rows[0]["Cubo_Columna"].ToString().Trim();
                }

                if (xcuboproc != null && xcuboproc != "" && xcuboproc != "00")
                {
                    cboCubo_Proceso.SelectedValue = dtConceptos.Rows[0]["Cubo_Proceso"].ToString().Trim();
                }
                //if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim()))
                //    cboConcepto_Remunerativo.SelectedValue = dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim();
                /*Otros*/
                txtCodigo_Auxiliar.Text = dtConceptos.Rows[0]["Codigo_Auxiliar"].ToString();
                ckTotal.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lTotal"]);
                ckMostrarEnAsiento.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_En_Asiento"]);
                ckMostrar_TotalizadoAnual.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_TotalizadoAnual"]);
                ckMostrar_TotalizadoAnualMinus.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_TotalizadoAnualMinus"]);
                ckMostrar_TotalizadoAnualDias.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_TotalizadoAnualDias"]);
                ckMostrar_TotalizadoAnualDiasMinus.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_TotalizadoAnualDiasMinus"]);
                ckMostrar_UtilidadesRemuVigente.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_UtilidadesRemuVigente"]);
                ckMostrar_UtilidadesRemuVigenteMinus.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lMostrar_UtilidadesRemuVigenteMinus"]);
                ckI_Acumulados.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lI_Acumulados"]);
                ckDoble_FF.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["lDoble_FF"]);

                chkCero.Checked = Convert.ToBoolean(dtConceptos.Rows[0]["FlagValorCero"]);

                if (string.IsNullOrEmpty(dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim()))
                {
                    //////cboInterfaz.SelectedValue = "00";
                    //////cboEstructura.SelectedValue = "00";
                }
                //////else if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim()))
                //////{
                //////    int miEstructura;
                //////    if (dtConceptos.Rows[0]["ms_EstructuraPlame_Id"] == null) miEstructura = 0;
                //////    else int.TryParse(dtConceptos.Rows[0]["ms_EstructuraPlame_Id"].ToString(), out miEstructura);
                //////    if (miEstructura != 0)
                //////    {
                //////        //////cboEstructura.SelectedValue = dtConceptos.Rows[0]["ms_EstructuraPlame_Id"].ToString();
                //////        cboInterfaz.SelectedValue = "01";
                //////        cboEstructura.Enabled = true;
                //////    }
                //////    else
                //////    {
                //////        cboInterfaz.SelectedValue = "00";
                //////        cboEstructura.SelectedValue = "00";
                //////        cboEstructura.Enabled = false;
                //////    }
                //////}

                //////int idRemunerativo = int.Parse(cboEstructura.SelectedValue);
                ////////////if (idRemunerativo == 1)
                ////////////{
                //////    Carga_combo_Concepto_Remunerativo(idRemunerativo);
                ////////////}
                ////////////else
                ////////////    Carga_combo_Concepto_Remunerativo(0);

                if (!string.IsNullOrEmpty(dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim()))
                    cboConcepto_Remunerativo.SelectedValue = dtConceptos.Rows[0]["Concepto_Remunerativo_Id"].ToString().Trim();
                enableAdd(false);
                enableUpdate(true);
                enableCancel(true);
                enableNew(false);
                enableTabPanel(true);
                TabContainer1.ActiveTabIndex = 1;
                txtDescripcion.Focus();

            }
        }

        protected void grvConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Concepto_Id;
                Concepto_Id = grvConceptos.DataKeys[e.RowIndex].Values["Concepto_Id"].ToString();
                objEConceptos = new Ent_Conceptos();
                objEConceptos.Concepto_Id = Concepto_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Conceptos.Elimina_Conceptos(objEConceptos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    //btnActualizar.Visible = false;
                    enableUpdate(false);
                    Lista_Conceptos(txtConceptosBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            TabContainer1.ActiveTabIndex = 0;
            Lista_Conceptos(txtConceptosBuscar.Text);
            txtConceptosBuscar.Focus();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableAdd(true);
            btnAdd.Enabled = true;
            enableCancel(true);
            enableNew(false);
            LimpiarCajasTexto();
            enableTabPanel(true);

            //////cboInterfaz.SelectedValue = "00";
            //////cboEstructura.SelectedValue = "00";
            cboConcepto_Remunerativo.SelectedValue = "00";

            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            //btnActualizar.Visible = false;
            //btnGrabar.Visible = true;
        }

        #region barraHerramientas
        private void backgroundButton(Button btn)
        {
            if (btn.Enabled)
                btn.BackColor = System.Drawing.Color.White;
            else
                btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#DCDCDC");
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
        private void enableTabPanel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            TabPanel2.Enabled = opcion;
            TabPanel3.Enabled = opcion;
            TabPanel4.Enabled = opcion;
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
            txtConceptosBuscar.Focus();
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
                objEConceptos = new Ent_Conceptos();
                objEConceptos.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                objEConceptos.Detalle = txtDetalle.Text.Trim().ToUpper();
                objEConceptos.Origen = fc_rb_Origen_Concepto_SelectedValue();
                objEConceptos.Tipo_Dato = fc_rb_Tipo_Dato_SelectedValue();
                objEConceptos.Comentario = txtComentario.Text.Trim().ToUpper();
                objEConceptos.Nombre_Abrev = txtNombre_Abrev.Text.Trim().ToUpper();
                if (txtValor_Defecto.Text.Trim() == string.Empty)
                    objEConceptos.Valor_defecto = 0;
                else
                    objEConceptos.Valor_defecto = Convert.ToDecimal(txtValor_Defecto.Text);
                objEConceptos.LMostrar_En_Boleta = Convert.ToInt32(ckMostrar_En_Boleta.Checked);
                objEConceptos.Boleta_Columna = cboBoleta_Columna.SelectedValue;
                objEConceptos.Boleta_Proceso = cboBoleta_Proceso.SelectedValue;
                objEConceptos.Cubo_Columna = cboCubo_Columna.SelectedValue;
                objEConceptos.Cubo_Proceso = cboCubo_Proceso.SelectedValue;
                objEConceptos.Grupo_Id = cboGrupo_Concepto.SelectedValue;
                if (txtNro_Decimales.Text.Trim() == string.Empty)
                    objEConceptos.Nro_Decimales = 4;
                else
                    objEConceptos.Nro_Decimales = Convert.ToInt32(txtNro_Decimales.Text);
                if (txtBoleta_nro_orden.Text.Trim() == string.Empty)
                    objEConceptos.Boleta_nro_orden = 0;
                else
                    objEConceptos.Boleta_nro_orden = Convert.ToInt32(txtBoleta_nro_orden.Text);
                objEConceptos.LMostrar_En_Cubo = ckMostrar_En_Cubo.Checked;

                //////objEConceptos.LMostrar_Totalizado = false;
                //////objEConceptos.LMostrar_TotalizadoComplete = false;
                objEConceptos.LMostrar_TotalizadoAnual = ckMostrar_TotalizadoAnual.Checked;
                objEConceptos.Estado_Id = cboEstado.SelectedValue;
                objEConceptos.Fecha_Modif = DateTime.Now.Date;
                objEConceptos.Concepto_Remunerativo_Id = cboConcepto_Remunerativo.SelectedValue;
                objEConceptos.LTotal = ckTotal.Checked;
                objEConceptos.LMOSTRAR_EN_ASIENTO = ckMostrarEnAsiento.Checked;
                objEConceptos.Codigo_Auxiliar = txtCodigo_Auxiliar.Text.Trim().ToUpper();
                objEConceptos.LDoble_FF = ckDoble_FF.Checked;
                objEConceptos.LI_Acumulados = ckI_Acumulados.Checked;

                objEConceptos.LMostrar_TotalizadoAnualMinus = ckMostrar_TotalizadoAnualMinus.Checked;
                objEConceptos.LMostrar_TotalizadoAnualDias = ckMostrar_TotalizadoAnualDias.Checked;
                objEConceptos.LMostrar_TotalizadoAnualDiasMinus = ckMostrar_TotalizadoAnualDiasMinus.Checked;
                objEConceptos.LMostrar_UtilidadesRemuVigente = ckMostrar_UtilidadesRemuVigente.Checked;
                objEConceptos.LMostrar_UtilidadesRemuVigenteMinus = ckMostrar_UtilidadesRemuVigenteMinus.Checked;
                //////objEConceptos.Afecto_5ta = false;
                //////objEConceptos.Base_Conceptos_Id = "";
                //////objEConceptos.LMostrar_Base = false;
                ///
                objEConceptos.FlagValorCero = chkCero.Checked;

                Ent_Periodo objEPeriodo = new Ent_Periodo();
                objEPeriodo.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                int estr = 0;
                //////if (cboEstructura.SelectedValue != "00")
                //////{
                //////    estr = int.Parse(cboEstructura.SelectedValue);
                //////}

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Conceptos.Inserta_Conceptos(objEConceptos, objEPeriodo, estr);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblConcepto_Id.Text = dtRpta.Rows[0][2].ToString();
                    Lista_Conceptos(txtConceptosBuscar.Text);

                    enableCancel(false);
                    enableAdd(false);
                    enableUpdate(false);
                    enableNew(true);

                    txtConceptosBuscar.Text = "";
                    Lista_Conceptos(txtConceptosBuscar.Text);
                    LimpiarCajasTexto();
                    cboConcepto_Remunerativo.SelectedValue = "00";
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblConcepto_Id.Text.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar un Concepto.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                objEConceptos = new Ent_Conceptos();
                objEConceptos.Concepto_Id = lblConcepto_Id.Text;
                objEConceptos.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                objEConceptos.Detalle = txtDetalle.Text.Trim().ToUpper();
                objEConceptos.Origen = fc_rb_Origen_Concepto_SelectedValue();
                objEConceptos.Tipo_Dato = fc_rb_Tipo_Dato_SelectedValue();
                objEConceptos.Comentario = txtComentario.Text.Trim().ToUpper();
                objEConceptos.Nombre_Abrev = txtNombre_Abrev.Text.Trim().ToUpper();
                if (txtValor_Defecto.Text.Trim() == string.Empty)
                    objEConceptos.Valor_defecto = 0;
                else
                    objEConceptos.Valor_defecto = Convert.ToDecimal(txtValor_Defecto.Text);
                objEConceptos.LMostrar_En_Boleta = Convert.ToInt32(ckMostrar_En_Boleta.Checked);
                objEConceptos.Boleta_Columna = cboBoleta_Columna.SelectedValue;
                objEConceptos.Boleta_Proceso = cboBoleta_Proceso.SelectedValue;
                objEConceptos.Cubo_Columna = cboCubo_Columna.SelectedValue;
                objEConceptos.Cubo_Proceso = cboCubo_Proceso.SelectedValue;
                objEConceptos.Grupo_Id = cboGrupo_Concepto.SelectedValue;
                if (txtNro_Decimales.Text.Trim() == string.Empty)
                    objEConceptos.Nro_Decimales = 0;
                else
                    objEConceptos.Nro_Decimales = Convert.ToInt32(txtNro_Decimales.Text);
                if (txtBoleta_nro_orden.Text.Trim() == string.Empty)
                    objEConceptos.Boleta_nro_orden = 0;
                else
                    objEConceptos.Boleta_nro_orden = Convert.ToInt32(txtBoleta_nro_orden.Text);
                objEConceptos.LMostrar_En_Cubo = ckMostrar_En_Cubo.Checked;

                //////objEConceptos.LMostrar_Totalizado = false;
                //////objEConceptos.LMostrar_TotalizadoComplete = false;
                objEConceptos.LMostrar_TotalizadoAnual = ckMostrar_TotalizadoAnual.Checked;
                objEConceptos.Estado_Id = cboEstado.SelectedValue;
                objEConceptos.Fecha_Modif = DateTime.Now.Date;
                objEConceptos.Concepto_Remunerativo_Id = cboConcepto_Remunerativo.SelectedValue;
                objEConceptos.LTotal = ckTotal.Checked;
                objEConceptos.LMOSTRAR_EN_ASIENTO = ckMostrarEnAsiento.Checked;
                objEConceptos.Codigo_Auxiliar = txtCodigo_Auxiliar.Text.Trim().ToUpper();
                objEConceptos.LDoble_FF = ckDoble_FF.Checked;
                objEConceptos.LI_Acumulados = ckI_Acumulados.Checked;

                objEConceptos.LMostrar_TotalizadoAnualMinus = ckMostrar_TotalizadoAnualMinus.Checked;
                objEConceptos.LMostrar_TotalizadoAnualDias = ckMostrar_TotalizadoAnualDias.Checked;
                objEConceptos.LMostrar_TotalizadoAnualDiasMinus = ckMostrar_TotalizadoAnualDiasMinus.Checked;
                objEConceptos.LMostrar_UtilidadesRemuVigente = ckMostrar_UtilidadesRemuVigente.Checked;
                objEConceptos.LMostrar_UtilidadesRemuVigenteMinus = ckMostrar_UtilidadesRemuVigenteMinus.Checked;
                //////objEConceptos.Afecto_5ta = false;
                //////objEConceptos.Base_Conceptos_Id = "";
                //////objEConceptos.LMostrar_Base = false;
                int estr = 0;
                //////if (cboEstructura.SelectedValue != "00") {
                //////    estr = int.Parse(cboEstructura.SelectedValue);
                //////}
                ///
                objEConceptos.FlagValorCero = chkCero.Checked;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Conceptos.Actualiza_Conceptos(objEConceptos, estr);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Conceptos(txtConceptosBuscar.Text);
                }
                dtRpta.Dispose();
                enableCancel(false);
                enableAdd(false);
                enableUpdate(false);
                enableNew(true);

                LimpiarCajasTexto();
                cboConcepto_Remunerativo.SelectedValue = "00";

                txtConceptosBuscar.Text = "";
                Lista_Conceptos(txtConceptosBuscar.Text);
                TabContainer1.ActiveTabIndex = 0;
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }

        }
        //////protected void cboEstructura_SelectedIndexChanged(object sender, EventArgs e)
        //////{
        //////    int idRemunerativo = int.Parse(cboEstructura.SelectedValue);

        //////    //if (idRemunerativo == 1) {
        //////        Carga_combo_Concepto_Remunerativo(idRemunerativo);
        //////    //}else
        //////    //    Carga_combo_Concepto_Remunerativo(0);    
        //////    //    cboEstructura.Enabled = true;
        //////    //    TabContainer1.ActiveTabIndex = 3;
        //////}


    }
}