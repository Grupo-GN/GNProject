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
    public partial class FrmCalculos_Perm : BasePage
    {
        Ent_Calculos_Perm objECalculos_Perm;

        string Planilla_IdAntes;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //if (!Utils.fc_ValidaFiltros(this.Page))
            //{
            //    //if (Request.QueryString["block"] == null)
            //        Utils.fc_DisplayAlert(this, "No Se Puede Realizar Ninguna Operación, Debe Seleccionar Todos Los Filtros");
            //    Response.Redirect("~/Default.aspx");
            //     //   return;
            //}

            if (!IsPostBack)
            {
                string periodoActual = (Session["Periodo_Id"] == null ? Utils.fc_obtiene_Periodo_Id(this) : Session["Periodo_Id"].ToString());
                //Planilla_IdAntes = Utils.fc_obtiene_Planilla_Id(this);
                Carga_combo_Personal(periodoActual);
                // Lista_Calculos_Perm(periodoActual, cboPersonal.SelectedValue);
            }
            //string j = (Session["Periodo_Id"] == null ? Utils.fc_obtiene_Periodo_Id(this) : Session["Periodo_Id"].ToString());
            //string anio = Utils.fc_obtiene_Ejercicio_Id(this);
            //string planilla = Utils.fc_obtiene_Planilla_Id(this);

            //if (ControlMantenimientos.nPosback != 2)
            //{
            //    string periodoActual = (Session["Periodo_Id"] == null ? Utils.fc_obtiene_Periodo_Id(this) : Session["Periodo_Id"].ToString());
            //    if (cboPersonal.SelectedIndex <= 0)
            //        Carga_combo_Personal(periodoActual);      
            //    else if(Planilla_IdAntes != Session["Planilla_Id"].ToString())
            //        Carga_combo_Personal(periodoActual);

            //    Lista_Calculos_Perm(periodoActual, cboPersonal.SelectedValue);
            //}
            HighlightGridLine();
        }

        void Carga_combo_Personal(String Periodo_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Personal objEPersonal = new Ent_Personal();
            objEPersonal._Periodo_Id = Periodo_Id;
            cboPersonal.DataSource = Log_Personal.Lista_Personal(objEPersonal);
            cboPersonal.DataTextField = "Nombre_Completo-Personal_Id";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
        }

        private void Lista_Calculos_Perm(String Periodo_Id, String Personal_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECalculos_Perm = new Ent_Calculos_Perm();
                objECalculos_Perm.Periodo_Id = Periodo_Id;
                objECalculos_Perm.Personal_Id = Personal_Id;
                DataTable dtCalculos_Perm = new DataTable();
                dtCalculos_Perm = Log_Calculos_Perm.Lista_Calculos_Perm(objECalculos_Perm);
                Utils.fc_Adecua_GridView(grvLista, dtCalculos_Perm.Rows.Count);
                grvLista.DataSource = dtCalculos_Perm;
                grvLista.DataBind();

                if (dtCalculos_Perm.Rows.Count <= 0)
                {
                    Utils.fc_DisplayAlert(this, "No se Encontraron Registros.");
                }
                dtCalculos_Perm.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void cboPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ControlMantenimientos.nPosback = 2;
            Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ControlMantenimientos.nPosback = 2;
            Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
        }

        protected void grvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvLista.PageIndex = e.NewPageIndex;
            Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
        }

        protected void grvLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

                TextBox txtValor = (TextBox)e.Row.FindControl("txtValor");

                if (txtValor != null)
                    txtValor.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                double algo = double.Parse(txtValor.Text);
                txtValor.Text = algo.ToString("F", CultureInfo.InvariantCulture);


                TextBox txtValor_Anterior = (TextBox)e.Row.FindControl("txtValor_Anterior");

                if (txtValor_Anterior != null)
                    txtValor_Anterior.Attributes.Add("OnKeyPress", "return SoloDecimales(event)");

                double algoNuevo = double.Parse(txtValor_Anterior.Text);
                txtValor_Anterior.Text = algoNuevo.ToString("F", CultureInfo.InvariantCulture);

                e.Row.Cells[2].Style.Add("cursor", "pointer");
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
            try
            {
                string Personal_Id;
                string periodo_Id = "";
                string concepto_Id;
                string proceso_Id;
                //Decimal valor;
                //Decimal valor_Anterior;

                string uhm = "";
                string uhmuevo = "";

                String concepto_Id_Masivo = "";
                String proceso_Id_Masivo = "";
                String valor_Masivo = "";
                String valor_Anterior_Masivo = "";
                Int32 cont = 0;

                Personal_Id = cboPersonal.SelectedValue;
                DataTable dtRpta;
                foreach (GridViewRow row in grvLista.Rows)
                {
                    periodo_Id = grvLista.DataKeys[row.RowIndex].Values["Periodo_Id"].ToString();
                    concepto_Id = grvLista.DataKeys[row.RowIndex].Values["Concepto_Id"].ToString();
                    proceso_Id = grvLista.DataKeys[row.RowIndex].Values["Proceso_Id"].ToString();
                    if (((TextBox)row.FindControl("txtValor")).Text.Trim() == String.Empty)
                        uhm = "0.00"; //valor = 0;
                    else
                        uhm = ((TextBox)row.FindControl("txtValor")).Text; //valor = Convert.ToDecimal(((TextBox)row.FindControl("txtValor")).Text);
                    if (((TextBox)row.FindControl("txtValor_Anterior")).Text.Trim() == String.Empty)
                        uhmuevo = "0.00"; //valor_Anterior = 0;
                    else
                        uhmuevo = ((TextBox)row.FindControl("txtValor_Anterior")).Text; //valor_Anterior = Convert.ToDecimal(((TextBox)row.FindControl("txtValor_Anterior")).Text);

                    concepto_Id_Masivo = concepto_Id_Masivo + concepto_Id + "|";
                    proceso_Id_Masivo = proceso_Id_Masivo + proceso_Id + "|";
                    valor_Masivo = valor_Masivo + uhm + "|";
                    valor_Anterior_Masivo = valor_Anterior_Masivo + uhmuevo + "|";
                    cont = cont + 1;
                }

                concepto_Id_Masivo = concepto_Id_Masivo.Substring(0, concepto_Id_Masivo.Length - 1);
                proceso_Id_Masivo = proceso_Id_Masivo.Substring(0, proceso_Id_Masivo.Length - 1);
                valor_Masivo = valor_Masivo.Substring(0, valor_Masivo.Length - 1);
                valor_Anterior_Masivo = valor_Anterior_Masivo.Substring(0, valor_Anterior_Masivo.Length - 1);

                //Utils.fc_DisplayAlert(this, cont.ToString() + "\n" + concepto_Id_Masivo + "\n" + valor_Masivo);

                string delimitador = "|";

                dtRpta = new DataTable();
                objECalculos_Perm = new Ent_Calculos_Perm();
                objECalculos_Perm.Periodo_Id = periodo_Id;
                objECalculos_Perm.Personal_Id = Personal_Id;
                objECalculos_Perm.Concepto_Id_Masivo = concepto_Id_Masivo;
                objECalculos_Perm.Proceso_Id_Masivo = proceso_Id_Masivo;
                objECalculos_Perm.Valor_Masivo = valor_Masivo;
                objECalculos_Perm.Valor_Anterior_Masivo = valor_Anterior_Masivo;
                dtRpta = Log_Calculos_Perm.Actualiza_Calculos_Perm_Masivo(objECalculos_Perm, delimitador, cont);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);

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
                string Personal_Id;
                string periodo_Id;
                Personal_Id = cboPersonal.SelectedValue;
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                objECalculos_Perm = new Ent_Calculos_Perm();
                objECalculos_Perm.Periodo_Id = periodo_Id;
                objECalculos_Perm.Personal_Id = Personal_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Calculos_Perm.Inserta_Calculos_Perm_Genera(objECalculos_Perm);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
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
            Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
        }
        protected void cboPersonal_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //  Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
        }
        protected void elLink_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Carga_combo_Personal(Utils.fc_obtiene_Periodo_Id(this));
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

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                Boolean fileOK = false;
                String path = Parametros.FileServerPath;
                string filename = "";
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
                cmd.CommandText = "SELECT * FROM [rptGenExcelAcum$]";

                oleda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                oleda.Fill(ds, "dt");
                DataTable dt = ds.Tables[0];
                oledbConn.Close();
                int error = 0;
                for (int y = 3; y <= dt.Rows.Count - 1; y++)
                {
                    string personalid = dt.Rows[y][0].ToString().Trim();
                    if (personalid != "")
                    {
                        for (int x = 3; x <= dt.Columns.Count - 1; x++)
                        {
                            string conceptoid = dt.Rows[1][x].ToString();
                            conceptoid = conceptoid.PadLeft(6, '0');
                            if ((x % 2) > 0 && conceptoid != "000000")
                            {
                                string val = dt.Rows[y][x].ToString();
                                string val_ant = dt.Rows[y][x + 1].ToString();
                                decimal valor = 0, valor_ant = 0;

                                if (decimal.TryParse(val, out valor) && decimal.TryParse(val_ant, out valor_ant))
                                {
                                    DataTable dtresp = new DataTable();
                                    dtresp = Log_D_Fijos.ActualizarDatoPorPersona_Acumulados(xPeriodoId, personalid, conceptoid, valor, valor_ant);
                                    if (dtresp.Rows[0][0].ToString() == "1")
                                    {

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
                File.Delete(path2);
                Utils.fc_DisplayAlert(this, "Información procesada.\n" + error.ToString() + " errores.");
            }
            catch (Exception ex)
            {
                lblmensajefile.Text = "Error: " + ex.Message.ToString();
            }
        }

        protected void btnGenerarTodos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Personal_Id;
                string periodo_Id;
                Personal_Id = cboPersonal.SelectedValue;
                periodo_Id = Utils.fc_obtiene_Periodo_Id(this);

                objECalculos_Perm = new Ent_Calculos_Perm();
                objECalculos_Perm.Periodo_Id = periodo_Id;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Calculos_Perm.Inserta_Calculos_Perm_Genera(objECalculos_Perm);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);
                if (Convert.ToInt32(dtRpta.Rows[0][0]) > 0)
                {
                    Lista_Calculos_Perm(Utils.fc_obtiene_Periodo_Id(this), cboPersonal.SelectedValue);
                }
                dtRpta.Dispose();

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
    }
}