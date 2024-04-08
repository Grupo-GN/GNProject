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
    public partial class FrmMntPersonal_Anexo2 : System.Web.UI.Page
    {
        Ent_Personal_Anexo2 objEPersonal_Anexo2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Personal_Anexo2();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Personal_Anexo2();
        }

        void Lista_Personal_Anexo2()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEPersonal_Anexo2 = new Ent_Personal_Anexo2();
                DataTable dtPersonal_Anexo2 = new DataTable();
                dtPersonal_Anexo2 = Log_Personal_Anexo2.Lista_Personal_Anexo2(objEPersonal_Anexo2);
                Utils.fc_Adecua_GridView(grvPersonal_Anexo2, dtPersonal_Anexo2.Rows.Count);
                grvPersonal_Anexo2.DataSource = dtPersonal_Anexo2;
                grvPersonal_Anexo2.DataBind();
                dtPersonal_Anexo2.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvPersonal_Anexo2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo2.PageIndex = e.NewPageIndex;
            Lista_Personal_Anexo2();
        }

        protected void grvPersonal_Anexo2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objEPersonal_Anexo2 = new Ent_Personal_Anexo2();
                    objEPersonal_Anexo2.Descripcion = ((TextBox)grvPersonal_Anexo2.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Personal_Anexo2.Inserta_Personal_Anexo2(objEPersonal_Anexo2);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Personal_Anexo2();
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

        protected void grvPersonal_Anexo2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Personal_Anexo2_Id;
                Personal_Anexo2_Id = grvPersonal_Anexo2.DataKeys[e.RowIndex].Values["Personal_Anexo2_Id"].ToString();
                objEPersonal_Anexo2 = new Ent_Personal_Anexo2();
                objEPersonal_Anexo2.Personal_Anexo2_Id = Personal_Anexo2_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo2.Elimina_Personal_Anexo2(objEPersonal_Anexo2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Personal_Anexo2();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvPersonal_Anexo2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo2.EditIndex = e.NewEditIndex;
            Lista_Personal_Anexo2();
        }

        protected void grvPersonal_Anexo2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvPersonal_Anexo2.EditIndex = -1;
            Lista_Personal_Anexo2();
        }
        protected void grvPersonal_Anexo2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Personal_Anexo2_Id;
                Personal_Anexo2_Id = grvPersonal_Anexo2.DataKeys[e.RowIndex].Values["Personal_Anexo2_Id"].ToString();
                objEPersonal_Anexo2 = new Ent_Personal_Anexo2();
                objEPersonal_Anexo2.Personal_Anexo2_Id = Personal_Anexo2_Id;
                objEPersonal_Anexo2.Descripcion = ((TextBox)grvPersonal_Anexo2.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo2.Actualiza_Personal_Anexo2(objEPersonal_Anexo2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvPersonal_Anexo2.EditIndex = -1;
                    Lista_Personal_Anexo2();
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
                objEPersonal_Anexo2 = new Ent_Personal_Anexo2();
                objEPersonal_Anexo2.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Personal_Anexo2.Inserta_Personal_Anexo2(objEPersonal_Anexo2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Personal_Anexo2();
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