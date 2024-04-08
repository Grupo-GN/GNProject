using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Vacaciones
{
    public partial class FrmVacPorVencerIndemnizacion : System.Web.UI.Page
    {
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnBuscar_Click(null, null);
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
                cargaLocalidad();
                cargaCategoria_Auxiliar();
                txtFechaFin_Desde.Text = DateTime.Now.ToShortDateString();
                txtFechaFin_Hasta.Text = DateTime.Now.AddDays(30).ToShortDateString();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dt = getDataTable_Bandeja();
            if (dt.Rows.Count == 0)
            {
                Utils.fc_DisplayAlert(this, "No se encontraron registros.");
            }

            grvBandeja.DataSource = dt;
            grvBandeja.DataBind();
            lblMensaje.Text = dt.Rows.Count.ToString() + " registro(s) encontrado(s).";

            grvBandeja.Columns[6].ItemStyle.ForeColor = System.Drawing.Color.Red;
            grvBandeja.Columns[9].ItemStyle.ForeColor = System.Drawing.Color.Red;
        }

        private DataTable getDataTable_Bandeja()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Vacaciones ent = new Ent_Vacaciones();
            ent.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            ent.Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
            ent.Area_Id = cboLocalidad.SelectedValue;
            ent.CatAuxiliar_Id = cboCategoria_Auxiliar.SelectedValue;
            ent.fe_fin_desde = Convert.ToDateTime(txtFechaFin_Desde.Text);
            ent.fe_fin_hasta = Convert.ToDateTime(txtFechaFin_Hasta.Text);
            return Log_Vacaciones.getProgVacaciones(ent);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dt = getDataTable_Bandeja();
            Utils.exportDataTableToExcel(dt, "VacacionesPorVencer");
        }
    }
}