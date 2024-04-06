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
    public partial class FrmMntRegimen_Laboral : System.Web.UI.Page
    {
        Ent_Regimen_Laboral objERegimen_Laboral;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Lista_Regimen_Laboral();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Regimen_Laboral();
        }

        void Lista_Regimen_Laboral()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objERegimen_Laboral = new Ent_Regimen_Laboral();
                DataTable dtRegimen_Laboral = new DataTable();
                dtRegimen_Laboral = Log_Regimen_Laboral.Lista_Regimen_Laboral(objERegimen_Laboral);
                Utils.fc_Adecua_GridView(grvRegimen_Laboral, dtRegimen_Laboral.Rows.Count);
                grvRegimen_Laboral.DataSource = dtRegimen_Laboral;
                grvRegimen_Laboral.DataBind();
                dtRegimen_Laboral.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvRegimen_Laboral_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvRegimen_Laboral.PageIndex = e.NewPageIndex;
            Lista_Regimen_Laboral();
        }

        protected void grvRegimen_Laboral_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

                try
                {
                    objERegimen_Laboral = new Ent_Regimen_Laboral();
                    objERegimen_Laboral.Descripcion = ((TextBox)grvRegimen_Laboral.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objERegimen_Laboral.Abreviatura = ((TextBox)grvRegimen_Laboral.FooterRow.FindControl("txtAbreviaturaNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Regimen_Laboral.Inserta_Regimen_Laboral(objERegimen_Laboral);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Regimen_Laboral();
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
        protected void grvRegimen_Laboral_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Regimen_Laboral_Id;
                Regimen_Laboral_Id = grvRegimen_Laboral.DataKeys[e.RowIndex].Values["Regimen_Laboral_Id"].ToString();
                objERegimen_Laboral = new Ent_Regimen_Laboral();
                objERegimen_Laboral.Regimen_Laboral_Id = Regimen_Laboral_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Regimen_Laboral.Elimina_Regimen_Laboral(objERegimen_Laboral);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Regimen_Laboral();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvRegimen_Laboral_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvRegimen_Laboral.EditIndex = e.NewEditIndex;
            Lista_Regimen_Laboral();
        }

        protected void grvRegimen_Laboral_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvRegimen_Laboral.EditIndex = -1;
            Lista_Regimen_Laboral();
        }
        protected void grvRegimen_Laboral_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Regimen_Laboral_Id;
                Regimen_Laboral_Id = grvRegimen_Laboral.DataKeys[e.RowIndex].Values["Regimen_Laboral_Id"].ToString();
                objERegimen_Laboral = new Ent_Regimen_Laboral();
                objERegimen_Laboral.Regimen_Laboral_Id = Regimen_Laboral_Id;
                objERegimen_Laboral.Descripcion = ((TextBox)grvRegimen_Laboral.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objERegimen_Laboral.Abreviatura = ((TextBox)grvRegimen_Laboral.Rows[e.RowIndex].FindControl("txtAbreviatura")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Regimen_Laboral.Actualiza_Regimen_Laboral(objERegimen_Laboral);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvRegimen_Laboral.EditIndex = -1;
                    Lista_Regimen_Laboral();
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
                objERegimen_Laboral = new Ent_Regimen_Laboral();
                objERegimen_Laboral.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objERegimen_Laboral.Abreviatura = txtAbreviaturaNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Regimen_Laboral.Inserta_Regimen_Laboral(objERegimen_Laboral);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtAbreviaturaNuevo.Text = "";
                    Lista_Regimen_Laboral();
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