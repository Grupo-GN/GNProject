using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmConfigBoletaCubo : System.Web.UI.Page
    {
        Ent_Conceptos objEConceptos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    if (Request.QueryString["block"] == null)
            //        Response.Redirect("~/Default.aspx?block=1");
            //}

            if (!Page.IsPostBack)
            {
                Carga_combo_ColumnasBoleta();
                Carga_combo_Procesos();
                Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
                Carga_combo_TipoAtributosConcepto();
                Carga_combo_Conceptos();
            }
        }

        void Carga_combo_ColumnasBoleta()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboColumnaBoleta.DataSource = Log_Conceptos.Lista_Columnas_Boleta();
            cboColumnaBoleta.DataTextField = "Descripcion";
            cboColumnaBoleta.DataValueField = "Columna_Id";
            cboColumnaBoleta.DataBind();
        }

        void Carga_combo_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Procesos objEProcesos = new Ent_Procesos();
            //objEProcesos.Estado_Id = "01"; /*Solo activos*/
            DataTable dtProcesos = Log_Procesos.Lista_Procesos(objEProcesos);
            cboProceso.DataSource = dtProcesos;
            cboProceso.DataTextField = "Proceso";
            cboProceso.DataValueField = "Proceso_Id";
            cboProceso.DataBind();

            cboProceso_Atributo.DataSource = dtProcesos;
            cboProceso_Atributo.DataTextField = "Proceso";
            cboProceso_Atributo.DataValueField = "Proceso_Id";
            cboProceso_Atributo.DataBind();
            dtProcesos.Dispose();
        }

        void Carga_combo_TipoAtributosConcepto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboTipoAtributosConcepto.DataSource = Log_Conceptos.Lista_TipoAtributosConcepto();
            cboTipoAtributosConcepto.DataTextField = "Descripcion";
            cboTipoAtributosConcepto.DataValueField = "Codigo";
            cboTipoAtributosConcepto.DataBind();
        }

        void Carga_combo_Conceptos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEConceptos = new Ent_Conceptos();
            Ent_Procesos objEProcesos = new Ent_Procesos();
            cboConceptos.DataSource = Log_Conceptos.Lista_Conceptos(objEConceptos, objEProcesos);
            cboConceptos.DataTextField = "Descripcion";
            cboConceptos.DataValueField = "Concepto_Id";
            cboConceptos.DataBind();
        }

        private void Lista_Ordenamiento_Conceptos(String columna_Id, String proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEConceptos = new Ent_Conceptos();
                if (cboDistribución.SelectedValue == "1") /*Distribucion por Boleta*/
                    objEConceptos.Boleta_Columna = cboColumnaBoleta.SelectedValue;
                else /*Distribucion por Cubo*/
                    objEConceptos.Cubo_Columna = cboColumnaBoleta.SelectedValue;
                objEConceptos.Boleta_Proceso = cboProceso.SelectedValue; /*Para guardar el Proceso_Id*/
                DataTable dtConceptos = new DataTable();
                dtConceptos = Log_Conceptos.Lista_Ordenamiento_Conceptos(objEConceptos);
                Utils.fc_Adecua_GridView(grvLista, dtConceptos.Rows.Count);
                grvLista.DataSource = dtConceptos;
                grvLista.DataBind();

                dtConceptos.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }

        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtBoleta_nro_orden = (TextBox)e.Row.FindControl("txtBoleta_nro_orden");
                if (txtBoleta_nro_orden != null)
                    txtBoleta_nro_orden.Attributes.Add("OnKeyPress", "return SoloNumeros(event)");
            }
        }

        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grvLista.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No se encontró ningún registro.");
                return;
            }
            try
            {
                /*//Valida que no se repite el numero de orden
                bool repite = false;
                Int32 nro;
                Int32 nro_aux;
                Int32 count;
                foreach (GridViewRow row in grvLista.Rows)
                {
                    count = 0;
                    nro = Convert.ToInt32(((TextBox)row.FindControl("txtBoleta_nro_orden")).Text);
                    foreach (GridViewRow row2 in grvLista.Rows)
                    {
                        nro_aux = Convert.ToInt32(((TextBox)row.FindControl("txtBoleta_nro_orden")).Text);
                        if (nro == nro_aux)
                            count++;
                        if (count > 1)
                        {
                            repite = true;
                            break;
                        }
                    }
                }
                if (repite == true)
                {
                    Utils.fc_DisplayAlert(this, "El Nro. de Orden no puede repetir. \nPor favor verificar.");
                    return;
                }
                */
                string concepto_Id;
                string detalle;
                Int32 boleta_nro_orden;

                DataTable dtRpta = new DataTable();
                string msj_rpta = "";
                foreach (GridViewRow row in grvLista.Rows)
                {
                    concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    detalle = ((TextBox)row.FindControl("txtDetalle")).Text;
                    if (((TextBox)row.FindControl("txtBoleta_nro_orden")).Text.Trim() == String.Empty)
                        boleta_nro_orden = 0;
                    else
                        boleta_nro_orden = Convert.ToInt32(((TextBox)row.FindControl("txtBoleta_nro_orden")).Text);

                    objEConceptos = new Ent_Conceptos();
                    objEConceptos.Concepto_Id = concepto_Id;
                    if (cboDistribución.SelectedValue.ToString() == "1") /*Distribucion por Boleta*/
                        objEConceptos.LMostrar_En_Boleta = 1;
                    else if (cboDistribución.SelectedValue.ToString() == "2") /*Distribucion por Cubo*/
                        objEConceptos.LMostrar_En_Cubo = true;

                    objEConceptos.Detalle = detalle.ToUpper();
                    objEConceptos.Boleta_nro_orden = boleta_nro_orden;

                    //20190503
                    objEConceptos.FlagAfecto = ((CheckBox)row.FindControl("chkafecto")).Checked;

                    dtRpta = Log_Conceptos.Actualiza_Conceptos_x_Distribucion(cboDistribución.SelectedValue, objEConceptos);
                    if (Convert.ToInt32(dtRpta.Rows[0][0]) <= 0)
                    {
                        msj_rpta = "Algunos registros no se actualizaron correctamente";
                    }
                }
                if (msj_rpta == String.Empty)
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                dtRpta.Dispose();

                Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvLista_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string concepto_Id;
            concepto_Id = grvLista.DataKeys[e.RowIndex].Values["Concepto_Id"].ToString();

            objEConceptos = new Ent_Conceptos();
            objEConceptos.Concepto_Id = concepto_Id;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Conceptos.Quitar_Conceptos_x_Distribucion(cboDistribución.SelectedValue, objEConceptos);

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }

        protected void cboDistribución_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
        protected void cboColumnaBoleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }
        protected void cboProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEConceptos = new Ent_Conceptos();
            objEConceptos.Origen = cboDistribución.SelectedValue; /*Se guarda el tipo de distribucion*/
            objEConceptos.Concepto_Id = txtFiltro_Concepto_Id.Text;
            objEConceptos.Detalle = txtFiltro_Detalle.Text;
            grvConceptos.DataSource = Log_Conceptos.Lista_Ordenamiento_Conceptos_x_Tipo_Agregar(objEConceptos);
            grvConceptos.DataBind();

            mpAgregar.Show();
        }
        protected void btnFiltro_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEConceptos = new Ent_Conceptos();
            objEConceptos.Origen = cboDistribución.SelectedValue; /*Se guarda el tipo de distribucion*/
            objEConceptos.Concepto_Id = txtFiltro_Concepto_Id.Text;
            objEConceptos.Detalle = txtFiltro_Detalle.Text;
            grvConceptos.DataSource = Log_Conceptos.Lista_Ordenamiento_Conceptos_x_Tipo_Agregar(objEConceptos);
            grvConceptos.DataBind();
        }
        protected void grvConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                Int32 nro_orden;
                nro_orden = grvLista.Rows.Count + 1;

                string concepto_Id;
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                concepto_Id = grvConceptos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();

                objEConceptos = new Ent_Conceptos();
                objEConceptos.Concepto_Id = concepto_Id;
                if (cboDistribución.SelectedValue == "1") /*Distribucion por Boleta*/
                    objEConceptos.Boleta_Columna = cboColumnaBoleta.SelectedValue;
                else /*Distribucion por Cubo*/
                    objEConceptos.Cubo_Columna = cboColumnaBoleta.SelectedValue;
                objEConceptos.Boleta_nro_orden = nro_orden;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Conceptos.Agregar_Conceptos_x_Distribucion(cboDistribución.SelectedValue, objEConceptos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

                Lista_Ordenamiento_Conceptos(cboColumnaBoleta.SelectedValue, cboProceso.SelectedValue);

                mpAgregar.Hide();
            }
        }

        protected void btnAtributos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblCompania.Text = Utils.fc_obtiene_Compania_Id_Nombre(this);
            lblPlanilla.Text = Utils.fc_obtiene_Planilla_Id_Nombre(this);
            cboProceso_Atributo.SelectedValue = cboProceso.SelectedValue;

            cboProceso_Atributo.Enabled = false;
            cboTipoAtributosConcepto.Enabled = false;
            txtAtributo_Boleta.Text = string.Empty;
            btnAgregarAtributo.Enabled = true;

            Lista_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue);

            mpAtributos.Show();
        }

        private void Lista_Conceptos_Atributos(String compania_Id, String planilla_Id, String proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                DataTable dtAtributos = new DataTable();
                dtAtributos = Log_Conceptos.Lista_Conceptos_Atributos(compania_Id, planilla_Id, proceso_Id);

                genera_Tabla_dtAtributos_Tmp();
                DataTable dtAtributos_Tmp = new DataTable();
                dtAtributos_Tmp = (DataTable)ViewState["dtAtributos_Tmp"];
                foreach (DataRow dr in dtAtributos.Rows)
                {
                    DataRow fila = dtAtributos_Tmp.NewRow();
                    fila["Concepto_Id"] = dr["Concepto_Id"];
                    fila["Descripcion"] = dr["Descripcion"];
                    fila["Atributo_Boleta"] = dr["Atributo_Boleta"];
                    dtAtributos_Tmp.Rows.Add(fila);
                }
                ViewState["dtAtributos_Tmp"] = dtAtributos_Tmp;
                grvAtributos.DataSource = dtAtributos_Tmp;
                grvAtributos.DataBind();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        void genera_Tabla_dtAtributos_Tmp()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtAtributos_Tmp = new DataTable();
            dtAtributos_Tmp.Columns.Add("Concepto_Id", Type.GetType("System.String"));
            dtAtributos_Tmp.Columns.Add("Descripcion", Type.GetType("System.String"));
            dtAtributos_Tmp.Columns.Add("Atributo_Boleta", Type.GetType("System.String"));
            ViewState["dtAtributos_Tmp"] = dtAtributos_Tmp;
        }

        protected void btnMostrarAtributos_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAgregarAtributo.Enabled = true;
            Lista_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue);
        }

        protected void btnAgregarAtributo_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string concepto_Id = cboConceptos.SelectedValue;
            string concepto_Id_Grid;
            foreach (GridViewRow row in grvAtributos.Rows)
            {
                concepto_Id_Grid = grvAtributos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                if (concepto_Id == concepto_Id_Grid)
                {
                    Utils.fc_DisplayAlert(this, "El concepto ya se encuentra registrado.");
                    return;
                }
            }
            DataTable dtAtributos_Tmp = new DataTable();
            dtAtributos_Tmp = (DataTable)ViewState["dtAtributos_Tmp"];
            DataRow fila = dtAtributos_Tmp.NewRow();
            fila["Concepto_Id"] = cboConceptos.SelectedValue;
            fila["Descripcion"] = cboConceptos.SelectedItem.Text;
            fila["Atributo_Boleta"] = txtAtributo_Boleta.Text;
            dtAtributos_Tmp.Rows.Add(fila);
            grvAtributos.DataSource = dtAtributos_Tmp;
            grvAtributos.DataBind();

            txtAtributo_Boleta.Text = string.Empty;
            btnAgregarAtributo.Enabled = false;
        }

        protected void btnGrabarAtributo_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grvAtributos.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No se encontró ningún registro.");
                return;
            }
            try
            {
                /*Valida que todos los registros tengan datos.*/
                string concepto_Id;
                string atributo_Boleta;

                foreach (GridViewRow row in grvAtributos.Rows)
                {
                    atributo_Boleta = ((TextBox)row.FindControl("txtAtributo_Boleta")).Text;
                    if (atributo_Boleta.Trim() == string.Empty)
                    {
                        Utils.fc_DisplayAlert(this, "Todos los Atributos deben tener valor.");
                        return;
                    }
                }

                DataTable dtRpta = new DataTable();
                string msj_rpta = "";
                foreach (GridViewRow row in grvAtributos.Rows)
                {
                    concepto_Id = grvAtributos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    atributo_Boleta = ((TextBox)row.FindControl("txtAtributo_Boleta")).Text;

                    dtRpta = Log_Conceptos.Graba_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue, concepto_Id, atributo_Boleta);
                    if (Convert.ToInt32(dtRpta.Rows[0][0]) <= 0)
                    {
                        msj_rpta = "Algunos registros no se grabaron correctamente";
                    }
                }

                if (msj_rpta == String.Empty)
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                dtRpta.Dispose();

                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    Lista_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue);

                btnAgregarAtributo.Enabled = true;
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvAtributos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string concepto_Id;
            concepto_Id = grvAtributos.DataKeys[e.RowIndex].Values["Concepto_Id"].ToString();

            objEConceptos = new Ent_Conceptos();
            objEConceptos.Concepto_Id = concepto_Id;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Conceptos.Elimina_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue, concepto_Id);

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            btnAgregarAtributo.Enabled = true;

            if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                Lista_Conceptos_Atributos(Utils.fc_obtiene_Compania_Id(this), Utils.fc_obtiene_Planilla_Id(this), cboProceso_Atributo.SelectedValue);
            dtRpta.Dispose();
        }
    }
}