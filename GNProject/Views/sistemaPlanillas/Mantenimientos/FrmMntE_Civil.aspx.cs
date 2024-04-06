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
    public partial class FrmMntE_Civil : System.Web.UI.Page
    {
        Ent_E_Civil objEE_Civil;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_E_Civil();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_E_Civil();
        }

        void Lista_E_Civil()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEE_Civil = new Ent_E_Civil();
                DataTable dtE_Civil = new DataTable();
                dtE_Civil = Log_E_Civil.Lista_E_Civil(objEE_Civil);
                Utils.fc_Adecua_GridView(grvE_Civil, dtE_Civil.Rows.Count);
                grvE_Civil.DataSource = dtE_Civil;
                grvE_Civil.DataBind();
                dtE_Civil.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvE_Civil_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvE_Civil.PageIndex = e.NewPageIndex;
            Lista_E_Civil();
        }

        protected void grvE_Civil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objEE_Civil = new Ent_E_Civil();
                    objEE_Civil.Descripcion = ((TextBox)grvE_Civil.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_E_Civil.Inserta_E_Civil(objEE_Civil);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_E_Civil();
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
        protected void grvE_Civil_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string E_Civil_Id;
                E_Civil_Id = grvE_Civil.DataKeys[e.RowIndex].Values["E_Civil_Id"].ToString();
                objEE_Civil = new Ent_E_Civil();
                objEE_Civil.E_Civil_Id = E_Civil_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_E_Civil.Elimina_E_Civil(objEE_Civil);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_E_Civil();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvE_Civil_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvE_Civil.EditIndex = e.NewEditIndex;
            Lista_E_Civil();
        }

        protected void grvE_Civil_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvE_Civil.EditIndex = -1;
            Lista_E_Civil();
        }
        protected void grvE_Civil_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string E_Civil_Id;
                E_Civil_Id = grvE_Civil.DataKeys[e.RowIndex].Values["E_Civil_Id"].ToString();
                objEE_Civil = new Ent_E_Civil();
                objEE_Civil.E_Civil_Id = E_Civil_Id;
                objEE_Civil.Descripcion = ((TextBox)grvE_Civil.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_E_Civil.Actualiza_E_Civil(objEE_Civil);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvE_Civil.EditIndex = -1;
                    Lista_E_Civil();
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
                objEE_Civil = new Ent_E_Civil();
                objEE_Civil.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_E_Civil.Inserta_E_Civil(objEE_Civil);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_E_Civil();
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