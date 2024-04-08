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
    public partial class FrmSaldoVacacional : System.Web.UI.Page
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

        private ArrayList obtieneListaPersonal()
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

            //var lstPersonal = from object[] obj in arrPersonal
            //                  select new
            //                  {
            //                      Personal_Id = obj[0],
            //                      Nombres = obj[1]
            //                  };
            //lstPersonal.

            return arrPersonal;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                String Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                String Periodo_Id = Utils.fc_obtiene_Periodo_Id(this);
                String Area_Id = cboLocalidad.SelectedValue;
                String CatAuxiliar_Id = cboCategoria_Auxiliar.SelectedValue;
                DateTime FechaProceso = Convert.ToDateTime(txtFechaProceso.Text);

                DataTable dt = Log_Vacaciones.SaldoVacacionxPeriodo(Planilla_Id, Periodo_Id, Area_Id, CatAuxiliar_Id, FechaProceso);
                grvBandeja.DataSource = dt;
                grvBandeja.DataBind();

                if (dt.Rows.Count > 0)
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                else
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                //lblMensaje.Text = dtPersonal.Rows.Count.ToString() + " Registros Encontrados";
                lblMensaje.Text = dt.Rows.Count.ToString() + " registro(s) encontrado(s).";

                
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al procesar la solicitud: <br>" + ex.Message;
            }
        }

        private int s_derecho = 0;
        private int s_tomados = 0;
        private int s_saldo = 0;
        private double s_truncas = 0;
        private double s_total = 0;
        private int s_indem = 0;
        private int s_indem_c = 0;
        private int s_indem_s = 0;
        private double s_ene = 0;
        private double s_feb = 0;
        private double s_mar = 0;
        private double s_abri = 0;
        private double s_mayo = 0;
        private double s_junio = 0;
        private double s_julio = 0;
        private double s_agos = 0;
        private double s_seti = 0;
        private double s_oct = 0;
        private double s_nov = 0;
        private double s_dic = 0;
        protected void grvBandeja_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    s_derecho = s_derecho + Convert.ToInt32(e.Row.Cells[3].Text);
                    s_tomados = s_tomados + Convert.ToInt32(e.Row.Cells[4].Text);
                    s_saldo = s_saldo + Convert.ToInt32(e.Row.Cells[5].Text);
                    s_truncas = s_truncas + Convert.ToDouble(e.Row.Cells[6].Text);
                    s_total = s_total + Convert.ToDouble(e.Row.Cells[7].Text);
                    s_indem = s_indem + Convert.ToInt32(e.Row.Cells[8].Text);

                    s_indem_c = s_indem_c + (e.Row.Cells[9].Text.Trim() == "&nbsp;" ? 0 : Convert.ToInt32(e.Row.Cells[9].Text));
                    s_indem_s = s_indem_s + (e.Row.Cells[10].Text.Trim() == "&nbsp;" ? 0 : Convert.ToInt32(e.Row.Cells[10].Text));

                    s_ene = s_ene + (e.Row.Cells[11].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[11].Text));
                    s_feb = s_feb + (e.Row.Cells[12].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[12].Text));
                    s_mar = s_mar + (e.Row.Cells[13].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[13].Text));
                    s_abri = s_abri + (e.Row.Cells[14].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[14].Text));
                    s_mayo = s_mayo + (e.Row.Cells[15].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[15].Text));
                    s_junio = s_junio + (e.Row.Cells[16].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[16].Text));
                    s_julio = s_julio + (e.Row.Cells[17].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[17].Text));
                    s_agos = s_agos + (e.Row.Cells[18].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[18].Text));
                    s_seti = s_seti + (e.Row.Cells[19].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[19].Text));
                    s_oct = s_oct + (e.Row.Cells[20].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[20].Text));
                    s_nov = s_nov + (e.Row.Cells[21].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[21].Text));
                    s_dic = s_dic + (e.Row.Cells[22].Text.Trim() == "&nbsp;" ? 0 : Convert.ToDouble(e.Row.Cells[22].Text));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[2].Text = "Total : ";
                    e.Row.Cells[3].Text = s_derecho.ToString();
                    e.Row.Cells[4].Text = s_tomados.ToString();
                    e.Row.Cells[5].Text = s_saldo.ToString();
                    e.Row.Cells[6].Text = s_truncas.ToString();
                    e.Row.Cells[7].Text = s_total.ToString();
                    e.Row.Cells[8].Text = s_indem.ToString();

                    e.Row.Cells[9].Text = s_indem_c.ToString();
                    e.Row.Cells[10].Text = s_indem_s.ToString();

                    e.Row.Cells[11].Text = s_ene.ToString();
                    e.Row.Cells[12].Text = s_feb.ToString();
                    e.Row.Cells[13].Text = s_mar.ToString();
                    e.Row.Cells[14].Text = s_abri.ToString();
                    e.Row.Cells[15].Text = s_mayo.ToString();
                    e.Row.Cells[16].Text = s_junio.ToString();
                    e.Row.Cells[17].Text = s_julio.ToString();
                    e.Row.Cells[18].Text = s_agos.ToString();
                    e.Row.Cells[19].Text = s_seti.ToString();
                    e.Row.Cells[20].Text = s_oct.ToString();
                    e.Row.Cells[21].Text = s_nov.ToString();
                    e.Row.Cells[22].Text = s_dic.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al procesar la solicitud: <br>Databound " + ex.Message;
            }
        }
    }
}