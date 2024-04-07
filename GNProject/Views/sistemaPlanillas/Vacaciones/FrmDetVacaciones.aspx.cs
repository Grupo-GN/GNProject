using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Vacaciones
{
    public partial class FrmDetVacaciones : System.Web.UI.Page
    {
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargarPersonal();
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
                PanelModalVaca.Visible = false;
                pnlAgregarVacaciones.Visible = false;

                cargaLocalidad();
                cargaCategoria_Auxiliar();
                cargarPersonal();
                txtFechaProceso.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void cargaLocalidad()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_RH_Area ent = new Ent_RH_Area();
            cboLocalidad.DataSource = Log_RH_Area.Lista_RH_Area(ent);
            cboLocalidad.DataTextField = "Descripcion";
            cboLocalidad.DataValueField = "Area_Id";
            cboLocalidad.DataBind();
            cboLocalidad.Items.Insert(0, new ListItem("TODOS", ""));
        }

        private void cargaCategoria_Auxiliar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Categoria_Auxiliar objECat_Aux = new Ent_Categoria_Auxiliar();
            cboCategoria_Auxiliar.DataSource = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECat_Aux);
            cboCategoria_Auxiliar.DataTextField = "Descripcion";
            cboCategoria_Auxiliar.DataValueField = "Categoria_Auxiliar_Id";
            cboCategoria_Auxiliar.DataBind();
            cboCategoria_Auxiliar.Items.Insert(0, new ListItem("TODOS", ""));
        }

        private void cargarPersonal()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            String Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            String Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            String Area_Id = cboLocalidad.SelectedValue;
            String CatAuxiliar_Id = cboCategoria_Auxiliar.SelectedValue;
            //---------
            String Planilla_Ids = Planilla_Id;
            String Area_Ids = Area_Id;
            String Estado_Id = "";

            String xml_parametros = String.Format("<prm Planilla_Ids='{0}' Area_Ids='{1}' CatAuxiliar_Id='{2}' Estado_Id='{3}' Periodo_Id='{4}' />", Planilla_Ids, Area_Ids, CatAuxiliar_Id, Estado_Id, Periodo_Id);
            ArrayList arrPersonal = CAPA_DATOS.oFormulas.controller_RepGeneral.Get_Instance().getCombo("PERSONAL_PERIODO", xml_parametros);

            var lstPersonal = from object[] obj in arrPersonal
                              select new
                              {
                                  Personal_Id = obj[0],
                                  Nombres = obj[1]
                              };

            cboPersonal.DataSource = lstPersonal;
            cboPersonal.DataTextField = "Nombres";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
            cboPersonal.Items.Insert(0, new ListItem("-Seleccione-", ""));
        }

        protected void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargarPersonal();
        }

        protected void cboCategoria_Auxiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargarPersonal();
        }

        protected void btnBuscar_Click(object sender, System.EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            String Personal_Id = cboPersonal.SelectedValue;

            if (cboPersonal.SelectedValue == "")
            {
                PanelModalVaca.Visible = false;
                pnlAgregarVacaciones.Visible = false;

                Utils.fc_DisplayAlert(this, "Debe seleccionar un personal.");
                return;
            }

            PanelModalVaca.Visible = true;
            pnlAgregarVacaciones.Visible = true;

            DataTable dtVacaciones = new DataTable();
            dtVacaciones = Log_Vacaciones.getVacacionesxId(Personal_Id);

            lblMensaje.Text = "";
            if (dtVacaciones.Rows.Count > 0)
            {
                DataTable dtVaca = new DataTable();
                dtVaca.Columns.Add("Vacaciones_Id", Type.GetType("System.String"));
                dtVaca.Columns.Add("Nombres", Type.GetType("System.String"));
                dtVaca.Columns.Add("FechaInicio", Type.GetType("System.String"));
                dtVaca.Columns.Add("FechaFin", Type.GetType("System.String"));
                dtVaca.Columns.Add("DerechoVac", Type.GetType("System.String"));
                dtVaca.Columns.Add("DiasTomados", Type.GetType("System.String"));
                dtVaca.Columns.Add("DiasSaldo", Type.GetType("System.String"));
                dtVaca.Columns.Add("Indemnizacion", Type.GetType("System.String"));

                dtVaca.Columns.Add("Cancelado", Type.GetType("System.String"));
                dtVaca.Columns.Add("SaldoIndemnizacion", Type.GetType("System.String"));
                foreach (DataRow fila in dtVacaciones.Rows)
                {
                    var VacacionesId = fila["Vacaciones_Id"].ToString();
                    // If dt.Rows.Count > 0 Then
                    DataRow dr = dtVaca.NewRow();
                    dr["Vacaciones_Id"] = VacacionesId;
                    dr["Nombres"] = fila["Nombres"].ToString();
                    dr["FechaInicio"] = fila["FechaInicio"].ToString();
                    dr["FechaFin"] = fila["FechaFin"].ToString();
                    dr["DerechoVac"] = fila["DerechoVac"].ToString();

                    DataTable dt = new DataTable();
                    dt = Log_Vacaciones.ListaVacacionCantDias(VacacionesId, Convert.ToDateTime(txtFechaProceso.Text));

                    dr["DiasTomados"] = dt.Rows[0]["DiasTomados"].ToString();
                    dr["DiasSaldo"] = Convert.ToInt32(dr["DerechoVac"].ToString()) - Convert.ToInt32(dr["DiasTomados"].ToString());

                    DataTable dt2 = new DataTable();
                    dt2 = Log_Vacaciones.ListaVacacionIndemnizacion(VacacionesId);
                    int Indemnizacion = 30;
                    bool Activo;
                    foreach (DataRow drr in dt2.Rows)
                    {
                        if ((drr["Activo"].ToString() == "0"))
                            Activo = false;
                        else
                            Indemnizacion = Indemnizacion - Convert.ToInt32(drr["Indemnizacion"]);
                    }

                    //////// Si es Gaslac Tenorio, Jose Victor:
                    //////// No se le pone indemnizacion hasta la fecha Octubre 2010 porque se le ha pagado sus vacaciones
                    //////if ((cboPersonal.SelectedValue == "000026"))
                    //////    Indemnizacion = 0;

                    dr["Indemnizacion"] = Indemnizacion;

                    dtVaca.Rows.Add(dr);
                }

                //String UnAnioMas_;
                DateTime UnAnioMas_;
                // Agregar las Vacaciones Canceladas
                foreach (DataRow row in dtVaca.Rows)
                {
                    //UnAnioMas_ = Left(row["FechaFin"], 6) + ((Convert.ToDateTime(row["FechaFin"]).Year) + 1).ToString();
                    UnAnioMas_ = (Convert.ToDateTime(row["FechaFin"])).AddYears(1);

                    var Vacacion_id = row["Vacaciones_Id"].ToString();
                    var dtVacCan = Log_Vacaciones.ListaIndemnizacionCanceladaDetalle(Vacacion_id);
                    if (dtVacCan.Rows.Count == 0)
                        row["Cancelado"] = " 0";
                    else
                    {
                        Int32 Cancelado = 0;
                        foreach (DataRow rowC in dtVacCan.Rows)
                            Cancelado += Convert.ToInt32(rowC["Dias"]);
                        row["Cancelado"] = Cancelado.ToString();
                    }
                    if (Convert.ToDateTime(row["FechaFin"]) < Convert.ToDateTime(txtFechaProceso.Text))
                        row["SaldoIndemnizacion"] = (Convert.ToInt32(row["Indemnizacion"]) - Convert.ToInt32(row["Cancelado"])).ToString();
                    else
                        row["SaldoIndemnizacion"] = (0 - Convert.ToInt32(row["Cancelado"])).ToString();// row["SaldoIndemnizacion"] = (Convert.ToInt32(row["Indemnizacion"]) - Convert.ToInt32(row["Cancelado"])).ToString()

                    if (UnAnioMas_ < Convert.ToDateTime(txtFechaProceso.Text))
                    {
                    }
                    else
                        row["SaldoIndemnizacion"] = (0 - Convert.ToInt32(row["Cancelado"])).ToString();
                }

                grvBandeja.DataSource = dtVaca;
                grvBandeja.DataBind();

                int acum = new int(), acum1 = new int(), acumS = new int(), acumI = new int();
                acum = 0;
                acum1 = 0;
                acumS = 0;
                acumI = 0;

                Int32 acumdic = new Int32(), acumsi = new Int32();
                acumdic = 0;
                acumsi = 0;

                //string UnAnioMas;
                DateTime UnAnioMas;
                int i = 0;
                foreach (DataRow f in dtVaca.Rows)
                {
                    //UnAnioMas = "";
                    //UnAnioMas = Left(f["FechaFin"], 6) + ((Convert.ToDateTime(f["FechaFin"]).Year) + 1).ToString();
                    UnAnioMas = (Convert.ToDateTime(f["FechaFin"])).AddYears(1);

                    if (Convert.ToDateTime(f["FechaFin"]) < Convert.ToDateTime(txtFechaProceso.Text))
                    {
                        acum = acum + Convert.ToInt32(f["DerechoVac"].ToString());
                        acum1 = acum1 + Convert.ToInt32(f["DiasTomados"].ToString());
                        acumS += Convert.ToInt32(f["DiasSaldo"].ToString());

                        acumdic += Convert.ToInt32(f["Cancelado"].ToString());
                        acumsi += Convert.ToInt32(f["SaldoIndemnizacion"].ToString());
                    }
                    else
                    {
                        grvBandeja.Rows[i].Cells[3].ForeColor = System.Drawing.Color.Red;
                        grvBandeja.Rows[i].Cells[4].ForeColor = System.Drawing.Color.Red;
                        grvBandeja.Rows[i].Cells[5].ForeColor = System.Drawing.Color.Red;

                        grvBandeja.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        grvBandeja.Rows[i].Cells[9].ForeColor = System.Drawing.Color.Red;
                    }

                    if (UnAnioMas < Convert.ToDateTime(txtFechaProceso.Text))
                        acumI += Convert.ToInt32(f["Indemnizacion"].ToString());
                    else
                    {
                        grvBandeja.Rows[i].Cells[7].ForeColor = System.Drawing.Color.Red;
                        grvBandeja.Rows[i].Cells[8].ForeColor = System.Drawing.Color.Red;
                        grvBandeja.Rows[i].Cells[9].ForeColor = System.Drawing.Color.Red;
                    }
                    i = i + 1;
                }

                // Si son Gerentes no tienen indemnizacion
                // ''If (cboPersonal.SelectedValue = "000312" Or cboPersonal.SelectedValue = "000134" Or cboPersonal.SelectedValue = "000056" Or cboPersonal.SelectedValue = "000138") Then
                // ''    acumI = 0
                // ''ElseIf (cboPersonal.SelectedValue = "000037") Then
                // ''    acumI = 137
                // ''ElseIf (cboPersonal.SelectedValue = "000048") Then
                // ''    acumI = 60
                // ''End If
                // ---

                grvBandeja.FooterRow.Cells[2].Text = "Total Dias:";
                grvBandeja.FooterRow.Cells[2].Font.Bold = true;
                grvBandeja.FooterRow.Cells[3].Text = acum.ToString();
                grvBandeja.FooterRow.Cells[3].Font.Bold = true;
                grvBandeja.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[4].Text = acum1.ToString();
                grvBandeja.FooterRow.Cells[4].Font.Bold = true;
                grvBandeja.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[5].Text = acumS.ToString();
                grvBandeja.FooterRow.Cells[5].Font.Bold = true;
                grvBandeja.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[5].ForeColor = System.Drawing.Color.DarkBlue;
                grvBandeja.FooterRow.Cells[7].Text = acumI.ToString();
                grvBandeja.FooterRow.Cells[7].Font.Bold = true;
                grvBandeja.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[7].ForeColor = System.Drawing.Color.DarkBlue;

                grvBandeja.FooterRow.Cells[8].Text = acumdic.ToString();
                grvBandeja.FooterRow.Cells[8].Font.Bold = true;
                grvBandeja.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[8].ForeColor = System.Drawing.Color.DarkBlue;

                grvBandeja.FooterRow.Cells[9].Text = acumsi.ToString();
                grvBandeja.FooterRow.Cells[9].Font.Bold = true;
                grvBandeja.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                grvBandeja.FooterRow.Cells[9].ForeColor = System.Drawing.Color.DarkBlue;
            }
            else
            {
                grvBandeja.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, System.EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            lblDias.Text = "";
            grvVacacionesCanceladas.DataBind();

            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            AjaxControlToolkit.ModalPopupExtender mpe = (AjaxControlToolkit.ModalPopupExtender)row.FindControl("btnAgregar_ModalPopupExtender");
            Session["pu"] = mpe;
            Button button = (Button)row.FindControl("btnAgregar");
            string Vacacion_Id = button.CommandName;
            Session["Vacacion_Id"] = Vacacion_Id;
            //////DataTable dtDet = new DataTable();
            //////dtDet = cl.tabla("SELECT * FROM Vacaciones WHERE Vacaciones_id='" + Vacacion_Id + "'"); 
            //////lblPeriodoVac.Text = string.Format("{0:dd/MM/yyyy}", dtDet.Rows[0]["Fecha_Ini"]) + " - " + string.Format("{0:dd/MM/yyyy}", dtDet.Rows[0]["Fecha_Fin"]);
            lblPeriodoVac.Text = row.Cells[1].Text + " - " + row.Cells[2].Text;
            mpe.Show();

            DataTable dtVacPag = new DataTable();
            dtVacPag = Log_Vacaciones.ListaIndemnizacionCanceladaDetalle(Vacacion_Id);
            grvVacacionesCanceladas.DataSource = dtVacPag;
            grvVacacionesCanceladas.DataBind();
        }

        protected void grvBandeja_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // btnAddToCart.OnClientClick = String.Format("functionPostback('{0}','{1}')", btnAddToCart.UniqueID, ""); 
                GridViewRow row = e.Row;
                ImageButton button = (ImageButton)e.Row.FindControl("ImageButton1");
                button.OnClientClick = string.Format("fnClickPostBack('{0}','{1}')", button.UniqueID, "");
                // If Not button Is Nothing Then
                // button.OnClientClick = "javascript:(AbrirVentana(‘EditCandidatos.aspx?Codigow=" & e.Row.Cells(1).Text & "‘));"
                // End If
                Button buttonAdd = (Button)e.Row.FindControl("btnAgregar");
                buttonAdd.OnClientClick = string.Format("fnClickPostBack('{0}','{1}')", buttonAdd.UniqueID, "");
            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            GrvVacacionDet.DataBind();

            GridViewRow row = (GridViewRow)((ImageButton)sender).NamingContainer;
            AjaxControlToolkit.ModalPopupExtender mpe = (AjaxControlToolkit.ModalPopupExtender)row.FindControl("ImageButton1_ModalPopupExtender");

            ImageButton button1 = (ImageButton)row.FindControl("ImageButton1");
            string IdVacacion = button1.CommandName.ToString();

            lblPeriodoDetVaca.Text = "";

            DataTable dtDeta = new DataTable();
            dtDeta = Log_Vacaciones.ListaVacacionDet(IdVacacion);

            if (dtDeta.Rows.Count > 0)
            {
                GrvVacacionDet.DataSource = dtDeta;
                GrvVacacionDet.DataBind();

                int acum = 0;
                foreach (DataRow fila in dtDeta.Rows)
                    acum = acum + Convert.ToInt32(fila["DiasTomados"]);

                lblMensajeDetVaca.Text = "";
                lblPeriodoDetVaca.Text = dtDeta.Rows[0]["PeriodoInicio"].ToString() + " - " + dtDeta.Rows[0]["PeriodoFin"].ToString();

                GrvVacacionDet.FooterRow.Cells[5].Text = "Total Dias:";
                GrvVacacionDet.FooterRow.Cells[5].Font.Bold = true;
                GrvVacacionDet.FooterRow.Cells[6].Text = acum.ToString();
                GrvVacacionDet.FooterRow.Cells[6].Font.Bold = true;
            }
            else
            {
                lblMensajeDetVaca.Text = "No Se Encontraron Datos...";
                GrvVacacionDet.DataBind();
            }

            mpe.Show();
        }

    }
}