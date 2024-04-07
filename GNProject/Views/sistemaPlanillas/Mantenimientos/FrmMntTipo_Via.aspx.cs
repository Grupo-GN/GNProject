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
    public partial class FrmMntTipo_Via : System.Web.UI.Page
    {
        Ent_Tipo_Via objETipo_Via;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Via();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Via();
        }

        void Lista_Tipo_Via()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Via = new Ent_Tipo_Via();
                DataTable dtTipo_Via = new DataTable();
                dtTipo_Via = Log_Tipo_Via.Lista_Tipo_Via(objETipo_Via);
                Utils.fc_Adecua_GridView(grvTipo_Via, dtTipo_Via.Rows.Count);
                grvTipo_Via.DataSource = dtTipo_Via;
                grvTipo_Via.DataBind();
                dtTipo_Via.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTipo_Via_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Via.PageIndex = e.NewPageIndex;
            Lista_Tipo_Via();
        }

        protected void grvTipo_Via_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Via = new Ent_Tipo_Via();
                    objETipo_Via.Descripcion = ((TextBox)grvTipo_Via.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Via.Inserta_Tipo_Via(objETipo_Via);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Via();
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
        protected void grvTipo_Via_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Via_Id;
                Tipo_Via_Id = grvTipo_Via.DataKeys[e.RowIndex].Values["Tipo_Via_Id"].ToString();
                objETipo_Via = new Ent_Tipo_Via();
                objETipo_Via.Tipo_Via_Id = Tipo_Via_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Via.Elimina_Tipo_Via(objETipo_Via);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Via();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Via_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Via.EditIndex = e.NewEditIndex;
            Lista_Tipo_Via();
        }

        protected void grvTipo_Via_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Via.EditIndex = -1;
            Lista_Tipo_Via();
        }
        protected void grvTipo_Via_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Via_Id;
                Tipo_Via_Id = grvTipo_Via.DataKeys[e.RowIndex].Values["Tipo_Via_Id"].ToString();
                objETipo_Via = new Ent_Tipo_Via();
                objETipo_Via.Tipo_Via_Id = Tipo_Via_Id;
                objETipo_Via.Descripcion = ((TextBox)grvTipo_Via.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Via.Actualiza_Tipo_Via(objETipo_Via);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Via.EditIndex = -1;
                    Lista_Tipo_Via();
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
                objETipo_Via = new Ent_Tipo_Via();
                objETipo_Via.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Via.Inserta_Tipo_Via(objETipo_Via);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Tipo_Via();
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