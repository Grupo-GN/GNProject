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
    public partial class FrmMntEPS : System.Web.UI.Page
    {
        Ent_EPS objEEPS;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_EPS();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_EPS();
        }

        void Lista_EPS()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEEPS = new Ent_EPS();
                DataTable dtEPS = new DataTable();
                dtEPS = Log_EPS.Lista_EPS(objEEPS);
                Utils.fc_Adecua_GridView(grvEPS, dtEPS.Rows.Count);
                grvEPS.DataSource = dtEPS;
                grvEPS.DataBind();
                dtEPS.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvEPS_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvEPS.PageIndex = e.NewPageIndex;
            Lista_EPS();
        }

        protected void grvEPS_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objEEPS = new Ent_EPS();
                    objEEPS.Descripcion = ((TextBox)grvEPS.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objEEPS.Ruc = ((TextBox)grvEPS.FooterRow.FindControl("txtRucNew")).Text;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_EPS.Inserta_EPS(objEEPS);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_EPS();
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
        protected void grvEPS_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string EPS_Id;
                EPS_Id = grvEPS.DataKeys[e.RowIndex].Values["EPS_Id"].ToString();
                objEEPS = new Ent_EPS();
                objEEPS.EPS_Id = EPS_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_EPS.Elimina_EPS(objEEPS);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_EPS();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvEPS_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvEPS.EditIndex = e.NewEditIndex;
            Lista_EPS();
        }

        protected void grvEPS_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvEPS.EditIndex = -1;
            Lista_EPS();
        }
        protected void grvEPS_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string EPS_Id;
                EPS_Id = grvEPS.DataKeys[e.RowIndex].Values["EPS_Id"].ToString();
                objEEPS = new Ent_EPS();
                objEEPS.EPS_Id = EPS_Id;
                objEEPS.Descripcion = ((TextBox)grvEPS.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objEEPS.Ruc = ((TextBox)grvEPS.Rows[e.RowIndex].FindControl("txtRuc")).Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_EPS.Actualiza_EPS(objEEPS);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvEPS.EditIndex = -1;
                    Lista_EPS();
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
                objEEPS = new Ent_EPS();
                objEEPS.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objEEPS.Ruc = txtRucNuevo.Text;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_EPS.Inserta_EPS(objEEPS);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtRucNuevo.Text = "";
                    Lista_EPS();
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