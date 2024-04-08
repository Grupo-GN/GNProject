using CAPA_DATOS.oFormulas;
using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Acceso;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Datos
{
    public partial class FrmDatos_x_Persona : BasePage
    {
        Ent_D_Fijos objED_Fijos;
        Ent_D_Variables objED_Variables;
        Ent_D_Directos objED_Directos;
        Ent_Procesos objEProcesos;
        ///raymundo salas
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    if (Request.QueryString["block"] == null)
            //      Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //      Response.Redirect("~/Default.aspx");
            //   // return;
            //}

            if (!Page.IsPostBack)
            {
                txtValorReemp_D_Fijos.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                txtValorReemp_D_Variables.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                txtValorReemp_D_Directos.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");


                Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));

                Carga_combo_Procesos();
                Carga_combo_Tipo_Concepto();
                lblnoProceso.Visible = false;
                cboProcesos_2.Visible = false;
                Carga_combo_Conceptos(cboTipo_Dato.SelectedValue, cboProcesos_2.SelectedValue);

                pnlFiltroxConceptos.Visible = true;
                pnlFiltroxPersonal.Visible = false;

                //Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                //            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                //Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
            }
            HighlightGridLine();
        }

        void Carga_combo_Personal(string Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal.DataTextField = "Nombre_Completo-Personal_Id";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
        }
        void Carga_combo_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEProcesos = new Ent_Procesos();
            objEProcesos.Estado_Id = "01"; /*Solo Activos*/
            DataTable dtProcesos = new DataTable();
            dtProcesos = Log_Procesos.Lista_Procesos(objEProcesos);
            cboProcesos.DataSource = dtProcesos;
            cboProcesos.DataTextField = "Proceso";
            cboProcesos.DataValueField = "Proceso_Id";
            cboProcesos.DataBind();

            cboProcesos_2.DataSource = dtProcesos;
            cboProcesos_2.DataTextField = "Proceso";
            cboProcesos_2.DataValueField = "Proceso_Id";
            cboProcesos_2.DataBind();
            dtProcesos.Dispose();
        }
        void Carga_combo_Tipo_Concepto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboTipo_Dato.DataSource = Log_Conceptos.Lista_Tipo_Concepto();
            cboTipo_Dato.DataTextField = "Tipo_Concepto";
            cboTipo_Dato.DataValueField = "TC_Id";
            cboTipo_Dato.DataBind();
            /*Se recorre los Items del combo en forma descendente para que no afecte los Index*/
            for (int i = cboTipo_Dato.Items.Count - 1; i >= 0; i--)
            {
                if (cboTipo_Dato.Items[i].Value.ToString() != "01"
                    && cboTipo_Dato.Items[i].Value.ToString() != "02"
                    && cboTipo_Dato.Items[i].Value.ToString() != "03") /*Solo se deja Fijo, Variable y Directo*/
                    cboTipo_Dato.Items.RemoveAt(i);
                else
                {
                    if (cboTipo_Dato.Items[i].Value.ToString() == "01")
                        cboTipo_Dato.Items[i].Text = "Datos Fijos";
                    else if (cboTipo_Dato.Items[i].Value.ToString() == "02")
                        cboTipo_Dato.Items[i].Text = "Datos Variables";
                    else if (cboTipo_Dato.Items[i].Value.ToString() == "03")
                        cboTipo_Dato.Items[i].Text = "Datos Directos";
                }
            }
            cboTipo_Dato.Items.Insert(0, new ListItem("--Todos--", ""));
        }
        void Carga_combo_Conceptos(string Tipo_Dato, string Proceso_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Conceptos objEConceptos = new Ent_Conceptos();
            if (!string.IsNullOrEmpty(Tipo_Dato.Trim()))
                objEConceptos.Tipo_Dato = Tipo_Dato;
            else
                objEConceptos.Tipo_Dato = "--"; /*01, 02 y 03*//*Fijos, Variables y Directos*/
            objEConceptos.Estado_Id = "01"; /*Solo Activos*/

            Ent_Procesos objEProceso = new Ent_Procesos();
            objEProceso.Proceso_Id = Proceso_Id;
            cboConceptos.DataSource = Log_Conceptos.Lista_Conceptosv2(objEConceptos, objEProceso);
            cboConceptos.DataTextField = "Concepto_Id-Descripcion";
            cboConceptos.DataValueField = "Concepto_Id";
            cboConceptos.DataBind();
        }

        protected void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        protected void rbMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (rbMostrar.SelectedValue.ToUpper() == "CONCEPTOS")
            {
                pnlFiltroxConceptos.Visible = true;
                pnlFiltroxPersonal.Visible = false;

                Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);

                btnGenerar_D_Fijos.Visible = true;
                btnGenerar_D_Variables.Visible = true;
                btnGenerar_D_Directos.Visible = true;
            }
            else
            {
                pnlFiltroxConceptos.Visible = false;
                pnlFiltroxPersonal.Visible = true;

                Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
                Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
                Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);

                btnGenerar_D_Fijos.Visible = false;
                btnGenerar_D_Variables.Visible = false;
                btnGenerar_D_Directos.Visible = false;
            }
        }
        protected void cboMostrarConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (rbMostrar.SelectedValue.ToUpper() == "CONCEPTOS")
            {
                //////pnlFiltroxConceptos.Visible = true;
                //////pnlFiltroxPersonal.Visible = false;

                Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
            }
            else
            {
                //////pnlFiltroxConceptos.Visible = false;
                //////pnlFiltroxPersonal.Visible = true;

                Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
                Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
                Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);
            }
        }
        protected void cboPersonal_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        protected void cboProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        //Genera todos los datos fijos, variables y directos
        protected void btnGenerarConceptosAll_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string periodo_Id;
                string Personal_Id;

                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = ""; //Para todo el personal

                //Datos Fijos
                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id = Personal_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_D_Fijos.Inserta_D_Fijos_Genera(objED_Fijos);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();
                //Datos Variables
                objED_Variables = new Ent_D_Variables();
                objED_Variables.Periodo_Id = periodo_Id;
                objED_Variables.Personal_Id = Personal_Id;
                dtRpta = new DataTable();
                dtRpta = Log_D_Variables.Inserta_D_Variables_Genera(objED_Variables);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();
                //Datos Directos
                objED_Directos = new Ent_D_Directos();
                objED_Directos.Periodo_Id = periodo_Id;
                objED_Directos.Personal_Id = Personal_Id;
                dtRpta = new DataTable();
                dtRpta = Log_D_Directos.Inserta_D_Directos_Genera(objED_Directos);
                //string msj_rpta;
                //msj_rpta = dtRpta.Rows[0][1].ToString();
                //Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Fijos, Variables y Directos.");
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        /*Metodos de Datos Fijos*/
        #region "METODOS DE DATOS FIJOS"
        void fc_calcula_Total_Fijos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Int32 contador = 0;
            string valor;
            string valor_acum = "0";
            foreach (GridViewRow row in grv_D_Fijos.Rows)
            {
                if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                    valor = "0";
                else
                    valor = ((TextBox)row.FindControl("txtValor")).Text;

                valor_acum = (double.Parse(valor_acum) + double.Parse(valor)).ToString();
                contador = contador + 1;
            }
            lblCantFijos.Text = "Cant.: " + contador.ToString();
            lblTotFijos.Text = string.Format("{0:0.0000}", valor_acum);
        }

        private void Lista_D_Fijos(string Periodo_Id, string Personal_Id, string Concepto_Id, string fl_Sin_Valor)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = Periodo_Id;
                if (!string.IsNullOrEmpty(Personal_Id.Trim()))
                    objED_Fijos.Personal_Id = Personal_Id;
                if (!string.IsNullOrEmpty(Concepto_Id.Trim()))
                    objED_Fijos.Concepto_Id = Concepto_Id;
                DataTable dtD_Fijos = new DataTable();
                dtD_Fijos = Log_D_Fijos.Lista_D_Fijosv2(objED_Fijos, fl_Sin_Valor);
                Utils.fc_Adecua_GridView(grv_D_Fijos, dtD_Fijos.Rows.Count);
                grv_D_Fijos.DataSource = dtD_Fijos;
                grv_D_Fijos.DataBind();

                if (dtD_Fijos.Rows.Count <= 0)
                {
                    /////Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtD_Fijos.Dispose();
                fc_calcula_Total_Fijos();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grv_D_Fijos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grv_D_Fijos.PageIndex = e.NewPageIndex;
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
        }

        protected void grv_D_Fijos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");
                //double algo = double.Parse(txtValor.Text);
                //txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture); //se formatea los decimales en eval de gridview

                if (txtValor != null)
                {
                    txtValor.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                }
                e.Row.Cells[4].Style.Add("cursor", "pointer");
            }
        }

        protected void btnReempValor_D_Fijos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (txtValorReemp_D_Fijos.Text.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Ingresar Un Valor.");
                txtValorReemp_D_Fijos.Focus();
                return;
            }
            if (grv_D_Fijos.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string Personal_Id;
                string concepto_Id;
                Decimal valor;

                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                valor = Convert.ToDecimal(txtValorReemp_D_Fijos.Text);

                Personal_Id = cboPersonal.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Fijos.Rows)
                {
                    periodo_Id = grv_D_Fijos.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grv_D_Fijos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();

                    ((TextBox)row.FindControl("txtValor")).Text = string.Format("{0:0.00}", valor);


                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + valor.ToString() + "|";
                    cont = cont + 1;
                }
                txtValorReemp_D_Fijos.Text = string.Format("{0:0.00}", valor);
                fc_calcula_Total_Fijos();
                /*Luego se le dará GUARDAR TODO*/
                return;
                /*
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id = Personal_Id;
                objED_Fijos.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Fijos.Valor_Masivo = valor_Masivo;
                dtRpta = Log_D_Fijos.Actualiza_D_Fijos_Masivo(objED_Fijos, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    //////Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                */
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_D_Fijos_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grv_D_Fijos.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string personal_Id = "";
                string concepto_Id;
                Decimal valor;
                string uhm = "";

                string personal_Id_Masivo = "";
                string comentarioValor_Masivo = "";
                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Fijos.Rows)
                {
                    periodo_Id = grv_D_Fijos.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    personal_Id = grv_D_Fijos.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    concepto_Id = grv_D_Fijos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text;//valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    comentarioValor_Masivo = comentarioValor_Masivo + ((TextBox)row.FindControl("txtComentarioValor")).Text + "|";
                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + uhm + "|";
                    cont = cont + 1;
                }

                personal_Id_Masivo = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);
                comentarioValor_Masivo = comentarioValor_Masivo.Substring(0, comentarioValor_Masivo.Length - 1);
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id_Masivo = personal_Id_Masivo;
                objED_Fijos.ComentarioValor_Masivo = comentarioValor_Masivo;
                objED_Fijos.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Fijos.Valor_Masivo = valor_Masivo;

                //20190809
                objED_Fijos.Usuario = ClaseGlobal.Get_nombrecompleto_usuario().ToString();

                dtRpta = Log_D_Fijos.Actualiza_D_Fijos_Masivo(objED_Fijos, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGenerar_D_Fijos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string periodo_Id;
                string Personal_Id;
                int sum = 0;


                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = cboPersonal.SelectedValue.ToString();

                objED_Fijos = new Ent_D_Fijos();
                objED_Fijos.Periodo_Id = periodo_Id;
                objED_Fijos.Personal_Id = Personal_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_D_Fijos.Inserta_D_Fijos_Genera(objED_Fijos);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                //if (cboPersonal.Items.Count == sum)
                //{
                //Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Fijos.");
                //}
                /*else {
                    Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Fijos. Pero ocurrio errores.");
                }*/


            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        #endregion

        /*Metodos de Datos Variables*/
        #region "METODOS DE DATOS VARIABLES"
        void fc_calcula_Total_Variables()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Int32 contador = 0;
            string valor;
            string valor_acum = "0";
            foreach (GridViewRow row in grv_D_Variables.Rows)
            {
                if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                    valor = "0";
                else
                    valor = ((TextBox)row.FindControl("txtValor")).Text;

                valor_acum = (double.Parse(valor_acum) + double.Parse(valor)).ToString();
                contador = contador + 1;
            }
            lblCantVariables.Text = "Cant.: " + contador.ToString();
            lblTotVariables.Text = string.Format("{0:0.0000}", valor_acum);

        }

        private void Lista_D_Variables(string Periodo_Id, string Personal_Id, string Concepto_Id, string fl_Sin_Valor)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objED_Variables = new Ent_D_Variables();
                objED_Variables.Periodo_Id = Periodo_Id;
                if (!string.IsNullOrEmpty(Personal_Id.Trim()))
                    objED_Variables.Personal_Id = Personal_Id;
                if (!string.IsNullOrEmpty(Concepto_Id.Trim()))
                    objED_Variables.Concepto_Id = Concepto_Id;
                DataTable dtD_Variables = new DataTable();
                dtD_Variables = Log_D_Variables.Lista_D_Variablesv2(objED_Variables, fl_Sin_Valor);
                Utils.fc_Adecua_GridView(grv_D_Variables, dtD_Variables.Rows.Count);
                grv_D_Variables.DataSource = dtD_Variables;
                grv_D_Variables.DataBind();

                if (dtD_Variables.Rows.Count <= 0)
                {
                    //////Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtD_Variables.Dispose();
                fc_calcula_Total_Variables();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grv_D_Variables_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grv_D_Variables.PageIndex = e.NewPageIndex;
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
        }

        protected void grv_D_Variables_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");
                double algo = double.Parse(txtValor.Text);
                txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture);

                if (txtValor != null)
                {
                    txtValor.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                }
                e.Row.Cells[4].Style.Add("cursor", "pointer");
            }
        }

        protected void btnReempValor_D_Variables_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (txtValorReemp_D_Variables.Text.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Ingresar Un Valor.");
                txtValorReemp_D_Variables.Focus();
                return;
            }
            if (grv_D_Variables.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string Personal_Id;
                string concepto_Id;
                Decimal valor;
                //string uhm = "";

                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                valor = Convert.ToDecimal(txtValorReemp_D_Variables.Text);

                Personal_Id = cboPersonal.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Variables.Rows)
                {
                    periodo_Id = grv_D_Variables.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grv_D_Variables.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();

                    ((TextBox)row.FindControl("txtValor")).Text = string.Format("{0:0.0000}", valor);

                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + valor.ToString() + "|";
                    cont = cont + 1;
                }
                txtValorReemp_D_Variables.Text = string.Format("{0:0.0000}", valor);
                fc_calcula_Total_Variables();
                /*Luego se le dará GUARDAR TODO*/
                return;
                /*
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Variables = new Ent_D_Variables();
                objED_Variables.Periodo_Id = periodo_Id;
                objED_Variables.Personal_Id = Personal_Id;
                objED_Variables.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Variables.Valor_Masivo = valor_Masivo;
                dtRpta = Log_D_Variables.Actualiza_D_Variables_Masivo(objED_Variables, delimitador, cont);
                string msj_rpta;
                Utils.fc_DisplayAlert(this, msj_rpta);
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    //////Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                */
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_D_Variables_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grv_D_Variables.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string personal_Id = "";
                string concepto_Id;
                //Decimal valor;
                string uhm = "";

                string personal_Id_Masivo = "";
                string comentarioValor_Masivo = "";
                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Variables.Rows)
                {
                    periodo_Id = grv_D_Variables.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    personal_Id = grv_D_Variables.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    concepto_Id = grv_D_Variables.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text; //valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    comentarioValor_Masivo = comentarioValor_Masivo + ((TextBox)row.FindControl("txtComentarioValor")).Text + "|";
                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + uhm + "|";
                    cont = cont + 1;
                }

                personal_Id_Masivo = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);
                comentarioValor_Masivo = comentarioValor_Masivo.Substring(0, comentarioValor_Masivo.Length - 1);
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Variables = new Ent_D_Variables();
                objED_Variables.Periodo_Id = periodo_Id;
                objED_Variables.Personal_Id_Masivo = personal_Id_Masivo;
                objED_Variables.ComentarioValor_Masivo = comentarioValor_Masivo;
                objED_Variables.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Variables.Valor_Masivo = valor_Masivo;
                dtRpta = Log_D_Variables.Actualiza_D_Variables_Masivo(objED_Variables, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGenerar_D_Variables_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string periodo_Id;
                string Personal_Id;
                int sum = 0;


                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = cboPersonal.SelectedValue.ToString();
                objED_Variables = new Ent_D_Variables();
                objED_Variables.Periodo_Id = periodo_Id;
                objED_Variables.Personal_Id = Personal_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_D_Variables.Inserta_D_Variables_Genera(objED_Variables);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                //if (cboPersonal.Items.Count == sum)
                //{
                //Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Variables.");
                //}
                /*else
                {
                    Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Variables. Pero ocurrio errores.");
                }*/


            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        #endregion

        /*Metodos de Datos Directos*/
        #region "METODOS DE DATOS DIRECTOS"
        void fc_calcula_Total_Directos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Int32 contador = 0;
            string valor;
            string valor_acum = "0";
            foreach (GridViewRow row in grv_D_Directos.Rows)
            {
                if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                    valor = "0";
                else
                    valor = ((TextBox)row.FindControl("txtValor")).Text;

                valor_acum = (double.Parse(valor_acum) + double.Parse(valor)).ToString();
                contador = contador + 1;
            }
            lblCantDirectos.Text = "Cant.: " + contador.ToString();
            lblTotDirectos.Text = string.Format("{0:0.0000}", valor_acum);
        }

        private void Lista_D_Directos(string Periodo_Id, string Personal_Id, string Concepto_Id, string Proceso_Id, string fl_Sin_Valor)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objED_Directos = new Ent_D_Directos();
                objED_Directos.Periodo_Id = Periodo_Id;
                if (!string.IsNullOrEmpty(Personal_Id.Trim()))
                    objED_Directos.Personal_Id = Personal_Id;
                if (!string.IsNullOrEmpty(Concepto_Id.Trim()))
                    objED_Directos.Concepto_Id = Concepto_Id;

                objEProcesos = new Ent_Procesos();
                objEProcesos.Proceso_Id = Proceso_Id;

                DataTable dtD_Directos = new DataTable();
                dtD_Directos = Log_D_Directos.Lista_D_Directos(objED_Directos, objEProcesos, fl_Sin_Valor);
                Utils.fc_Adecua_GridView(grv_D_Directos, dtD_Directos.Rows.Count);
                grv_D_Directos.DataSource = dtD_Directos;
                grv_D_Directos.DataBind();

                if (dtD_Directos.Rows.Count <= 0)
                {
                    //////Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtD_Directos.Dispose();
                fc_calcula_Total_Directos();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grv_D_Directos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grv_D_Directos.PageIndex = e.NewPageIndex;
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        protected void grv_D_Directos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");
                double algo = double.Parse(txtValor.Text);
                //txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture);
                txtValor.Text = String.Format("{0:0.000}", algo);

                if (txtValor != null)
                {
                    txtValor.Attributes.Add("onkeydown", "return (event.keyCode!=13);");
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");
                }
                e.Row.Cells[4].Style.Add("cursor", "pointer");
            }
        }

        protected void btnReempValor_D_Directos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (txtValorReemp_D_Directos.Text.Trim() == string.Empty)
            {
                Utils.fc_DisplayAlert(this, "Ingresar Un Valor.");
                txtValorReemp_D_Directos.Focus();
                return;
            }
            if (grv_D_Directos.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string Personal_Id;
                string concepto_Id;
                Decimal valor;

                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;

                valor = Convert.ToDecimal(txtValorReemp_D_Directos.Text);

                Personal_Id = cboPersonal.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Directos.Rows)
                {
                    periodo_Id = grv_D_Directos.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grv_D_Directos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();

                    ((TextBox)row.FindControl("txtValor")).Text = string.Format("{0:0.0000}", valor);

                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + valor.ToString() + "|";
                    cont = cont + 1;
                }
                txtValorReemp_D_Directos.Text = string.Format("{0:0.0000}", valor);
                fc_calcula_Total_Directos();
                /*Luego se le dará GUARDAR TODO*/
                return;
                /*
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Directos = new Ent_D_Directos();
                objED_Directos.Periodo_Id = periodo_Id;
                objED_Directos.Personal_Id = Personal_Id;
                objED_Directos.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Directos.Valor_Masivo = valor_Masivo;
                dtRpta = Log_D_Directos.Actualiza_D_Directos_Masivo(objED_Directos, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    //////Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

                */
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_D_Directos_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (grv_D_Directos.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encuentra Ningun Registro.");
                return;
            }
            try
            {
                string periodo_Id = "";
                string personal_Id = "";
                string concepto_Id;
                //Decimal valor;
                string uhm = "";

                string personal_Id_Masivo = "";
                string comentarioValor_Masivo = "";
                string concepto_Id_Masivo = "";
                string valor_Masivo = "";
                Int32 cont = 0;


                DataTable dtRpta;
                foreach (GridViewRow row in grv_D_Directos.Rows)
                {
                    periodo_Id = grv_D_Directos.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    personal_Id = grv_D_Directos.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    concepto_Id = grv_D_Directos.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == string.Empty)
                        uhm = "0.00";//valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text; //valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);

                    personal_Id_Masivo = personal_Id_Masivo + personal_Id + "|";
                    comentarioValor_Masivo = comentarioValor_Masivo + ((TextBox)row.FindControl("txtComentarioValor")).Text + "|";
                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    valor_Masivo = valor_Masivo + uhm + "|";
                    cont = cont + 1;
                }

                personal_Id_Masivo = personal_Id_Masivo.Substring(0, personal_Id_Masivo.Length - 1);
                comentarioValor_Masivo = comentarioValor_Masivo.Substring(0, comentarioValor_Masivo.Length - 1);
                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objED_Directos = new Ent_D_Directos();
                objED_Directos.Periodo_Id = periodo_Id;
                objED_Directos.Personal_Id_Masivo = personal_Id_Masivo;
                objED_Directos.ComentarioValor_Masivo = comentarioValor_Masivo;
                objED_Directos.Concepto_Id_Masivo = concepto_Id_Masivo;
                objED_Directos.Valor_Masivo = valor_Masivo;
                dtRpta = Log_D_Directos.Actualiza_D_Directos_Masivo(objED_Directos, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
                }
                dtRpta.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGenerar_D_Directos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string periodo_Id;
                string Personal_Id;
                /**  int sum = 0;
                  for (int i = 0; i < cboPersonal.Items.Count - 1; i++)
                  {
                      periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                      Personal_Id = cboPersonal.Items[i].Value;
                      if (Personal_Id == "000037") {
                      string go = "a";
                      go = "adasdasd";
                      }
                      objED_Directos = new Ent_D_Directos();
                      objED_Directos.Periodo_Id = periodo_Id;
                      objED_Directos.Personal_Id = Personal_Id;
                      DataTable dtRpta = new DataTable();
                      dtRpta = Log_D_Directos.Inserta_D_Directos_Genera(objED_Directos);
                      string msj_rpta;
                      msj_rpta = dtRpta.Rows[0][1].ToString();
                      //Utils.fc_DisplayAlert(this, msj_rpta);
                      if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                      {
                          sum += 1;
                      }
                      dtRpta.Dispose();
                  }
                  if (cboPersonal.Items.Count == sum)
                  {
                      Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Directos.");
                  }
                  else
                  {
                      Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Directos. Pero ocurrio errores.");
                  }*/

                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                Personal_Id = cboPersonal.SelectedValue.ToString();
                if (Personal_Id == "000037")
                {
                    string go = "a";
                    go = "adasdasd";
                }
                objED_Directos = new Ent_D_Directos();
                objED_Directos.Periodo_Id = periodo_Id;
                objED_Directos.Personal_Id = Personal_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_D_Directos.Inserta_D_Directos_Genera(objED_Directos);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue, "", cboProcesos.SelectedValue, cboMostrarConceptos.SelectedValue);
                }
                else
                {
                    Utils.fc_DisplayAlert(this, "Se Generaron Todos los Conceptos de Datos Directos. Pero ocurrio errores.");
                }
                dtRpta.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        #endregion

        public string formatNumber(double number)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = ".";
            return number.ToString(nfi);
        }


        /*Mostrar por Personal*/
        protected void cboTipo_Dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (cboTipo_Dato.SelectedValue.ToString() == "03") /*Directos*/
            {
                lblnoProceso.Visible = true;
                cboProcesos_2.Visible = true;
            }
            else
            {
                lblnoProceso.Visible = false;
                cboProcesos_2.Visible = false;
            }
            Carga_combo_Conceptos(cboTipo_Dato.SelectedValue, cboProcesos_2.SelectedValue);

            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);
        }
        protected void cboProcesos_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_combo_Conceptos(cboTipo_Dato.SelectedValue, cboProcesos_2.SelectedValue);

            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);
        }

        protected void cboConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);
        }
        protected void btnBuscar_x_Concepto_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_D_Fijos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Variables(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboMostrarConceptos.SelectedValue);
            Lista_D_Directos(Utils.fc_obtiene_Periodo_Id(this), "", cboConceptos.SelectedValue, cboProcesos_2.SelectedValue, cboMostrarConceptos.SelectedValue);
        }
        protected void elLink_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Boolean fileOK = false;
                String path = Parametros.FileServerPath;
                string filename = "";
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (FileUpload1.HasFile)
                {
                    String fileExtension =
                        System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                    String[] allowedExtensions = { ".xls" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }
                if (fileOK)
                {
                    FileUpload1.PostedFile.SaveAs(path + FileUpload1.FileName);
                    lblmensajefile.Text = "File uploaded!";
                    filename = FileUpload1.FileName;
                }

                if (filename == "")
                {
                    lblmensajefile.Text = "No ha definido ningún archivo.";
                    return;
                }

                string xPeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                OleDbConnection oledbConn;
                string path2 = path + @"\" + filename;
                oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + path2 + ";Extended Properties =\"Excel 8.0;HDR=No;IMEX=2\"");
                oledbConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                cmd.Connection = oledbConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [rptGenExcel$]";

                oleda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                oleda.Fill(ds, "dt");
                DataTable dt = ds.Tables[0];
                oledbConn.Close();
                int error = 0; try
                {
                    for (int y = 2; y <= dt.Rows.Count - 1; y++)
                    {

                        string personalid = dt.Rows[y][0].ToString().Trim();
                        for (int x = 5; x <= dt.Columns.Count - 1; x++)
                        {
                            string conceptoid = dt.Rows[0][x].ToString();
                            conceptoid = conceptoid.PadLeft(6, '0');
                            string val = dt.Rows[y][x].ToString();
                            if (conceptoid == "000000" && String.IsNullOrEmpty(val))
                            {
                                //No se considera ya que probablemente se lee la última columna como vacía
                            }
                            else
                            {
                                decimal valor = 0;
                                if (decimal.TryParse(val, out valor))
                                {
                                    DataTable dtresp = new DataTable();
                                    dtresp = Log_D_Fijos.ActualizarDatoPorPersonaV2(xPeriodoId, personalid, conceptoid, valor);

                                    if (dtresp.Rows[0][0].ToString() == "1")
                                    {
                                        string mensajeresult = dtresp.Rows[0][1].ToString();
                                    }
                                }
                                else
                                {
                                    error++;
                                }
                            }
                        }

                    }
                }
                catch (Exception ex) { string ddddd = ex.Message; }
                File.Delete(path2);
                Utils.fc_DisplayAlert(this, "Información procesada.\n" + error.ToString() + " errores.");
            }
            catch (Exception ex)
            {
                lblmensajefile.Text = "Error: " + ex.Message.ToString();
            }
        }

        [WebMethod]
        public static ArrayList ListaPlanilla()
        {
            return controller_RepGeneral.Get_Instance().ListaPlanilla();
        }
        [WebMethod]
        public static ArrayList ListaEjercicio()
        {
            return controller_RepGeneral.Get_Instance().ListaEjercicio();
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return controller_RepGeneral.Get_Instance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return controller_RepGeneral.Get_Instance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            return controller_RepGeneral.Get_Instance().Get_Periodo_Combo(Compania_Id, Anio, Planilla_Id);
        }

        [WebMethod]
        public static ArrayList ListaPersonalActivoReporteGeneral(string PlanillaId, string PeriodoIni, string PeriodoFin)
        {
            return controller_RepGeneral.Get_Instance().ListaPersonalActivoReporteGeneral(PlanillaId, PeriodoIni, PeriodoFin);
        }
        [WebMethod]
        public static ArrayList ConfigFormulaGetConceptosByTipoList(string Tipo)
        {
            return controller_ConfigFormula.Get_Instance().ConfigFormulaGetConceptosByTipoList(Tipo);
        }

        [WebMethod]
        public static ArrayList ListaProyecto()
        {
            return controller_RepGeneral.Get_Instance().ListaProyecto();
        }
    }
}