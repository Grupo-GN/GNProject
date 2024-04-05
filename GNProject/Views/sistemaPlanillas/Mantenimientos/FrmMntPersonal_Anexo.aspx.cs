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
    public partial class FrmMntPersonal_Anexo : System.Web.UI.Page
    {
        Ent_Personal_Anexo objEPersonal_Anexo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Personal_Anexo();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Anexo();
        }

        void Lista_Personal_Anexo()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPersonal_Anexo = new Ent_Personal_Anexo();
                DataTable dtPersonal_Anexo = new DataTable();
                dtPersonal_Anexo = Log_Personal_Anexo.Lista_Personal_Anexo(objEPersonal_Anexo);
                Utils.fc_Adecua_GridView(grvPersonal_Anexo, dtPersonal_Anexo.Rows.Count);
                grvPersonal_Anexo.DataSource = dtPersonal_Anexo;
                grvPersonal_Anexo.DataBind();
                dtPersonal_Anexo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvPersonal_Anexo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo.PageIndex = e.NewPageIndex;
            Lista_Personal_Anexo();
        }

        protected void grvPersonal_Anexo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objEPersonal_Anexo = new Ent_Personal_Anexo();
                    objEPersonal_Anexo.Descripcion = ((TextBox)grvPersonal_Anexo.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Personal_Anexo.Inserta_Personal_Anexo(objEPersonal_Anexo);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Personal_Anexo();
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
        protected void grvPersonal_Anexo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Personal_Anexo_Id;
                Personal_Anexo_Id = grvPersonal_Anexo.DataKeys[e.RowIndex].Values["Personal_Anexo_Id"].ToString();
                objEPersonal_Anexo = new Ent_Personal_Anexo();
                objEPersonal_Anexo.Personal_Anexo_Id = Personal_Anexo_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo.Elimina_Personal_Anexo(objEPersonal_Anexo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Personal_Anexo();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvPersonal_Anexo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo.EditIndex = e.NewEditIndex;
            Lista_Personal_Anexo();
        }

        protected void grvPersonal_Anexo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo.EditIndex = -1;
            Lista_Personal_Anexo();
        }
        protected void grvPersonal_Anexo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Personal_Anexo_Id;
                Personal_Anexo_Id = grvPersonal_Anexo.DataKeys[e.RowIndex].Values["Personal_Anexo_Id"].ToString();
                objEPersonal_Anexo = new Ent_Personal_Anexo();
                objEPersonal_Anexo.Personal_Anexo_Id = Personal_Anexo_Id;
                objEPersonal_Anexo.Descripcion = ((TextBox)grvPersonal_Anexo.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo.Actualiza_Personal_Anexo(objEPersonal_Anexo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvPersonal_Anexo.EditIndex = -1;
                    Lista_Personal_Anexo();
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
                objEPersonal_Anexo = new Ent_Personal_Anexo();
                objEPersonal_Anexo.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo.Inserta_Personal_Anexo(objEPersonal_Anexo);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Personal_Anexo();
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