using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntSituacion : System.Web.UI.Page
    {
        Ent_Situacion objESituacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Lista_Situacion();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Situacion();
        }

        void Lista_Situacion()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objESituacion = new Ent_Situacion();
                DataTable dtSituacion = new DataTable();
                dtSituacion = Log_Situacion.Lista_Situacion(objESituacion);
                Utils.fc_Adecua_GridView(grvSituacion, dtSituacion.Rows.Count);
                grvSituacion.DataSource = dtSituacion;
                grvSituacion.DataBind();
                dtSituacion.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvSituacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvSituacion.PageIndex = e.NewPageIndex;
            Lista_Situacion();
        }

        protected void grvSituacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (e.CommandName == "Insert")
            {
                try
                {
                    objESituacion = new Ent_Situacion();
                    objESituacion.Descripcion = ((TextBox)grvSituacion.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Situacion.Inserta_Situacion(objESituacion);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Situacion();
                    }
                    dtRpta.Dispose();
                    Utils.fc_DisplayAlert(this, msj_rpta);
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvSituacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Situacion_Id;
                Situacion_Id = grvSituacion.DataKeys[e.RowIndex].Values["Situacion_Id"].ToString();
                objESituacion = new Ent_Situacion();
                objESituacion.Situacion_Id = Situacion_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Situacion.Elimina_Situacion(objESituacion);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Situacion();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvSituacion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvSituacion.EditIndex = e.NewEditIndex;
            Lista_Situacion();
        }

        protected void grvSituacion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvSituacion.EditIndex = -1;
            Lista_Situacion();
        }
        protected void grvSituacion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Situacion_Id;
                Situacion_Id = grvSituacion.DataKeys[e.RowIndex].Values["Situacion_Id"].ToString();
                objESituacion = new Ent_Situacion();
                objESituacion.Situacion_Id = Situacion_Id;
                objESituacion.Descripcion = ((TextBox)grvSituacion.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Situacion.Actualiza_Situacion(objESituacion);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvSituacion.EditIndex = -1;
                    Lista_Situacion();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objESituacion = new Ent_Situacion();
                objESituacion.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Situacion.Inserta_Situacion(objESituacion);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Situacion();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

    }
}