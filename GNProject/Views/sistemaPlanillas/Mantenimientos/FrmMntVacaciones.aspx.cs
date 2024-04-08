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
    public partial class FrmMntVacaciones : BasePage
    {
        Ent_Personal objEPersonal;

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
                pnlNuevoDetalle.Visible = false;
                // Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), "");
            }
            //Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), "");
            HighlightGridLine();
        }

        public void CargaPeriodos_Vacacion()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtPeriodoVac = new DataTable();
            Ent_Periodo objEPeriodo = new Ent_Periodo();
            objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
            objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
            objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
            dtPeriodoVac = Log_Periodo.Lista_Periodo(objEPeriodo);

            cboPeriodoVacacion.DataSource = dtPeriodoVac;
            cboPeriodoVacacion.DataTextField = "Descripcion";
            cboPeriodoVacacion.DataValueField = "Periodo_Id";
            cboPeriodoVacacion.DataBind();

            cboPeriodoVacacion.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);

            dtPeriodoVac.Dispose();
        }

        private void Lista_Personal(String Periodo_Id, String Apellidos_y_Nombres)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                lblNomPersonal.Text = "";
                hdnPersonal_Id.Value = "";
                grvVacaciones.DataBind();

                //pnlNuevoDetalle.Visible = false;
                grvVacaciones_Pagadas.DataBind();
                //hdnVacaciones_Id.Value = "";
                lblNomPeriodoVac.Text = "";

                objEPersonal = new Ent_Personal();
                objEPersonal._Periodo_Id = Periodo_Id;
                //if (Apellidos_y_Nombres.Trim() != "")
                //    objEPersonal._Nombres = Apellidos_y_Nombres;
                objEPersonal._Nombres = Apellidos_y_Nombres;

                DataTable dtPersonal = new DataTable();
                dtPersonal = Log_Personal.Lista_Personal(objEPersonal);
                grvPersonal.DataSource = dtPersonal;
                grvPersonal.DataBind();

                if (dtPersonal.Rows.Count <= 0)
                {
                    lblError.Text = "No se Encontraron Registros...";
                    return;
                }
                lblError.Text = "";
                TabContainer1.ActiveTabIndex = 0;

                Session["cambiaTab"] = null;
                Session["idPerson"] = null;
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvPersonal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    /*Muestra las Vacaciones del Personal Seleccionado*/
                    string Personal_Id;
                    string nombre_Personal;
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Personal_Id = grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
                    nombre_Personal = grvPersonal.DataKeys[row.RowIndex].Values["Nombre_Completo"].ToString();
                    Session["idPerson"] = grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();

                    hdnPersonal_Id.Value = Personal_Id;
                    lblNomPersonal.Text = nombre_Personal;
                    Lista_Vacaciones(Personal_Id);

                    CargaPeriodos_Vacacion();

                    //grvVacaciones_Pagadas.DataBind();
                    hdnVacaciones_Id.Value = "";
                    lblNomPeriodoVac.Text = "";
                    pnlNuevoDetalle.Visible = false;
                    TabPanel3.Enabled = true;
                    TabContainer1.ActiveTabIndex = 1;
                    Session["cambiaTab"] = nombre_Personal;
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        private void Lista_Vacaciones(String Personal_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DataTable dtVacaciones = new DataTable();
            Ent_Vacaciones objEVac = new Ent_Vacaciones();
            objEVac.Personal_Id = Personal_Id;
            dtVacaciones = Log_Vacaciones.Lista_Vacaciones(objEVac);
            grvVacaciones.DataSource = dtVacaciones;
            grvVacaciones.DataBind();
            if (dtVacaciones.Rows.Count <= 0)
            {
                Utils.fc_DisplayAlert(this, "No Se Encontraron Registros.");
            }

            //Limpia detalle
            pnlNuevoDetalle.Visible = false;
            cboPeriodoVacacion.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);
            txtFec_Inicio.Text = "";
            txtFec_Fin.Text = "";
            cboDetalle_Vac.SelectedIndex = 0;
            grvVacaciones_Pagadas.DataBind();
        }


        protected void grvVacaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Vacaciones_Id;
                    string no_Periodo_Vacacion;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    Vacaciones_Id = grvVacaciones.DataKeys[row.RowIndex].Values["Vacaciones_Id"].ToString();
                    no_Periodo_Vacacion = Convert.ToDateTime(grvVacaciones.DataKeys[row.RowIndex].Values["Fecha_Ini"]).ToString("dd/MM/yyyy")
                        + " - " + Convert.ToDateTime(grvVacaciones.DataKeys[row.RowIndex].Values["Fecha_Fin"]).ToString("dd/MM/yyyy");

                    /*Muestra el Detalla de las Vacaciones*/
                    hdnVacaciones_Id.Value = Vacaciones_Id;
                    lblNomPeriodoVac.Text = "Periodo: " + no_Periodo_Vacacion;
                    Lista_Vacaciones_Pagadas(Vacaciones_Id);
                    TabPanel3.Enabled = true;
                    pnlNuevoDetalle.Visible = true;
                    //////TabContainer1.ActiveTabIndex = 1;
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }

        private void Lista_Vacaciones_Pagadas(String Vacaciones_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                DataTable dtVacaciones_Pagadas = new DataTable();
                Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();
                objEVacPag.Vacaciones_id = Vacaciones_Id;
                dtVacaciones_Pagadas = Log_Vacaciones_Pagadas.Lista_Vacaciones_Pagadas(objEVacPag);

                if (dtVacaciones_Pagadas.Rows.Count <= 0)
                {
                    //Limpia detalle
                    cboPeriodoVacacion.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);
                    txtFec_Inicio.Text = "";
                    txtFec_Fin.Text = "";
                    cboDetalle_Vac.SelectedIndex = 0;
                    grvVacaciones_Pagadas.DataBind();

                    //Utils.fc_DisplayAlert(this, "No Se Encontraron Registros.");
                    pnlNuevoDetalle.Visible = true;
                    cboPeriodoVacacion.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);
                    txtFec_Inicio.Text = "";
                    txtFec_Fin.Text = "";
                }
                else
                {
                    grvVacaciones_Pagadas.DataSource = dtVacaciones_Pagadas;
                    grvVacaciones_Pagadas.DataBind();
                }
                pnlNuevoDetalle.Visible = true;
                dtVacaciones_Pagadas.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvVacaciones_Pagadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                //////if (e.Row.RowType == DataControlRowType.Footer)
                //////{
                //////    DropDownList cboPeriodoVacNew = (DropDownList)e.Row.FindControl("cboPeriodoVacNew");
                //////    if (cboPeriodoVacNew != null)
                //////    {
                //////        DataTable dtPeriodoVacNew = new DataTable();
                //////        Ent_Periodo objEPeriodo = new Ent_Periodo();
                //////        objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                //////        objEPeriodo.Mes_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                //////        objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                //////        dtPeriodoVacNew = Log_Periodo.Lista_Periodo(objEPeriodo);

                //////        cboPeriodoVacNew.DataSource = dtPeriodoVacNew;
                //////        cboPeriodoVacNew.DataTextField = "Descripcion";
                //////        cboPeriodoVacNew.DataValueField = "Periodo_Id";
                //////        cboPeriodoVacNew.DataBind();

                //////        cboPeriodoVacNew.SelectedValue = Utils.fc_obtiene_Periodo_Id(this);
                //////    }
                //////}
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList cboPeriodoVac = (DropDownList)e.Row.FindControl("cboPeriodoVac");
                    if (cboPeriodoVac != null)
                    {
                        DataTable dtPeriodoVac = new DataTable();
                        Ent_Periodo objEPeriodo = new Ent_Periodo();
                        objEPeriodo.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                        objEPeriodo.Ejercicio_Id = Utils.fc_obtiene_Ejercicio_Id(this);
                        objEPeriodo.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                        dtPeriodoVac = Log_Periodo.Lista_Periodo(objEPeriodo);

                        cboPeriodoVac.DataSource = dtPeriodoVac;
                        cboPeriodoVac.DataTextField = "Descripcion";
                        cboPeriodoVac.DataValueField = "Periodo_Id";
                        cboPeriodoVac.DataBind();

                        cboPeriodoVac.SelectedIndex = cboPeriodoVac.Items.Count - 1;

                        string Vacaciones_Pagadas_Id;
                        Vacaciones_Pagadas_Id = grvVacaciones_Pagadas.DataKeys[e.Row.RowIndex].Values["Vacaciones_Pagadas_Id"].ToString();

                        string Periodo_Id_Seleccionado;
                        Periodo_Id_Seleccionado = grvVacaciones_Pagadas.DataKeys[e.Row.RowIndex].Values["Periodo_Id"].ToString();

                        //Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();
                        //objEVacPag.Vacaciones_id = Vacaciones_Pagadas_Id;
                        //Periodo_Id_Seleccionado = Log_Vacaciones_Pagadas.Lista_Vacaciones_Pagadas(objEVacPag).Rows[0]["Periodo_id"].ToString();
                        if (Periodo_Id_Seleccionado.Trim() != "" || Periodo_Id_Seleccionado != null)
                        {
                            Boolean rpta = false;
                            foreach (ListItem list in cboPeriodoVac.Items)
                            {
                                if (Periodo_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                           //continue; //quiere decir que no continua haciendo lo que sigue debajo del if pero si sigue dentro del bucle (for)
                                }
                            }
                            if (rpta == true)
                            {
                                cboPeriodoVac.SelectedValue = Periodo_Id_Seleccionado;
                            }
                            else
                            {
                                cboPeriodoVac.SelectedIndex = 0;
                            }
                        }

                        dtPeriodoVac.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvVacaciones_Pagadas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvVacaciones_Pagadas.EditIndex = e.NewEditIndex;
            Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);
        }

        protected void grvVacaciones_Pagadas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvVacaciones_Pagadas.EditIndex = -1;
            Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);
        }

        protected void grvVacaciones_Pagadas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Vacaciones_Pagadas_Id;
            Vacaciones_Pagadas_Id = grvVacaciones_Pagadas.DataKeys[e.RowIndex].Value.ToString();

            Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();
            objEVacPag.Vacaciones_pagadas_id = Vacaciones_Pagadas_Id;
            objEVacPag.Periodo_id = ((DropDownList)grvVacaciones_Pagadas.Rows[e.RowIndex].FindControl("cboPeriodoVac")).SelectedValue;
            objEVacPag.Fecha_Ini = Convert.ToDateTime(((TextBox)grvVacaciones_Pagadas.Rows[e.RowIndex].FindControl("txtFecha_Inicio")).Text);
            objEVacPag.Fecha_Fin = Convert.ToDateTime(((TextBox)grvVacaciones_Pagadas.Rows[e.RowIndex].FindControl("txtFecha_Fin")).Text);
            objEVacPag.Lvendido = ((DropDownList)grvVacaciones_Pagadas.Rows[e.RowIndex].FindControl("cboNomDetalle_Vac")).SelectedValue;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Vacaciones_Pagadas.Actualiza_Vacaciones_Pagadas(objEVacPag).Tables[0];

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            grvVacaciones_Pagadas.EditIndex = -1;
            Lista_Vacaciones(hdnPersonal_Id.Value);
            Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);
        }
        protected void grvVacaciones_Pagadas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Vacaciones_Pagadas_Id;
            Vacaciones_Pagadas_Id = grvVacaciones_Pagadas.DataKeys[e.RowIndex].Value.ToString();

            Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();
            objEVacPag.Vacaciones_pagadas_id = Vacaciones_Pagadas_Id;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Vacaciones_Pagadas.Elimina_Vacaciones_Pagadas(objEVacPag).Tables[0];

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Vacaciones(hdnPersonal_Id.Value);
            Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);
        }
        //////protected void grvVacaciones_Pagadas_RowCommand(object sender, GridViewCommandEventArgs e)
        //////{
        //////    if (e.CommandName == "Insert")
        //////    {

        //////        if (((TextBox)grvVacaciones_Pagadas.FooterRow.FindControl("txtFecha_InicioNew")).Text == ""
        //////            || ((TextBox)grvVacaciones_Pagadas.FooterRow.FindControl("txtFecha_FinNew")).Text == "")
        //////        {
        //////            Utils.fc_DisplayAlert(this, "Es Obligatorio Ingresar La Fecha De Inicio y Fin.");
        //////            return;
        //////        }

        //////        Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();

        //////        objEVacPag.Vacaciones_id = hdnVacaciones_Id.Value;
        //////        objEVacPag.Periodo_id = ((DropDownList)grvVacaciones_Pagadas.FooterRow.FindControl("cboPeriodoVacNew")).SelectedValue;
        //////        objEVacPag.Fecha_Ini = Convert.ToDateTime(((TextBox)grvVacaciones_Pagadas.FooterRow.FindControl("txtFecha_InicioNew")).Text);
        //////        objEVacPag.Fecha_Fin = Convert.ToDateTime(((TextBox)grvVacaciones_Pagadas.FooterRow.FindControl("txtFecha_FinNew")).Text);
        //////        objEVacPag.Lvendido = ((DropDownList)grvVacaciones_Pagadas.FooterRow.FindControl("cboNomDetalle_VacNew")).SelectedValue;

        //////        DataTable dtRpta = new DataTable();
        //////        dtRpta = Log_Vacaciones_Pagadas.Inserta_Vacaciones_Pagadas(objEVacPag).Tables[0];

        //////        string msj_rpta;
        //////        msj_rpta = dtRpta.Rows[0][1].ToString();
        //////        Utils.fc_DisplayAlert(this, msj_rpta);

        //////        Lista_Vacaciones(hdnPersonal_Id.Value);
        //////        Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);

        //////    }
        //////}
        protected void grvVacaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Vacaciones_Id;
            Vacaciones_Id = grvVacaciones.DataKeys[e.RowIndex].Value.ToString();

            Ent_Vacaciones objEVac = new Ent_Vacaciones();
            objEVac.Vacaciones_Id = Vacaciones_Id;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Vacaciones.Elimina_Vacaciones(objEVac).Tables[0];

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            Lista_Vacaciones(hdnPersonal_Id.Value);

            if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            {
                hdnVacaciones_Id.Value = "";
                lblNomPeriodoVac.Text = "";
                //pnlNuevoDetalle.Visible = false;
            }

        }

        protected void ibtnNuevo_DetalleVac_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_Vacaciones_Pagadas objEVacPag = new Ent_Vacaciones_Pagadas();

            objEVacPag.Vacaciones_id = hdnVacaciones_Id.Value;
            objEVacPag.Periodo_id = cboPeriodoVacacion.SelectedValue;
            objEVacPag.Fecha_Ini = Convert.ToDateTime(txtFec_Inicio.Text);
            objEVacPag.Fecha_Fin = Convert.ToDateTime(txtFec_Fin.Text);
            objEVacPag.Lvendido = cboDetalle_Vac.SelectedValue;

            DataTable dtRpta = new DataTable();
            dtRpta = Log_Vacaciones_Pagadas.Inserta_Vacaciones_Pagadas(objEVacPag).Tables[0];

            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);

            //if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            //   pnlNuevoDetalle.Visible = false;

            dtRpta.Dispose();
            Lista_Vacaciones(hdnPersonal_Id.Value);
            Lista_Vacaciones_Pagadas(hdnVacaciones_Id.Value);
        }
        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (hdnPersonal_Id.Value.Trim() == "")
            {
                Utils.fc_DisplayAlert(this, "Debe seleccionar un personal");
            }
            else
            {
                DataTable dtRpta = new DataTable();
                Ent_Vacaciones objVac = new Ent_Vacaciones();
                objVac.Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                objVac.Planilla_Id = Utils.fc_obtiene_Planilla_Id(this);
                objVac.Personal_Id = hdnPersonal_Id.Value;
                dtRpta = Log_Vacaciones.Genera_Vacaciones_Masivo(objVac).Tables[0];

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

                Lista_Vacaciones(hdnPersonal_Id.Value);
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), txtNombrePersonal.Text);
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
        protected void grvVacaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }
        protected void grvPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal.PageIndex = e.NewPageIndex;
            Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), txtNombrePersonal.Text);
        }
        //////protected void grvPersonal_PreRender(object sender, EventArgs e)
        //////{
        //////    //////Lista_Personal(Utils.fc_obtiene_Periodo_Id(this), txtNombrePersonal.Text);
        //////    if (Session["cambiaTab"] != null)
        //////    {
        //////        if (Session["cambiaTab"].ToString() != "")
        //////        {
        //////            TabContainer1.ActiveTabIndex = 1;
        //////            lblNomPersonal.Text = Session["cambiaTab"].ToString();
        //////            //Session["cambiaTab"] = null;
        //////        }
        //////    }
        //////}
        //////protected void grvVacaciones_PreRender(object sender, EventArgs e)
        //////{
        //////    if (Session["idPerson"] != null)
        //////    {
        //////        //////Lista_Vacaciones(Session["idPerson"].ToString());
        //////    }
        //////}
    }
}