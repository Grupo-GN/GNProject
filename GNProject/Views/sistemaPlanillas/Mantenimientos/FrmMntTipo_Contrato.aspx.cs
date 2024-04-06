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
    public partial class FrmMntTipo_Contrato : System.Web.UI.Page
    {
        Ent_Tipo_Contrato objETipo_Contrato;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Contrato();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Contrato();
        }

        void Lista_Tipo_Contrato()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Contrato = new Ent_Tipo_Contrato();
                DataTable dtTipo_Contrato = new DataTable();
                dtTipo_Contrato = Log_Tipo_Contrato.Lista_Tipo_Contrato(objETipo_Contrato);
                Utils.fc_Adecua_GridView(grvTipo_Contrato, dtTipo_Contrato.Rows.Count);
                grvTipo_Contrato.DataSource = dtTipo_Contrato;
                grvTipo_Contrato.DataBind();
                dtTipo_Contrato.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTipo_Contrato_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Contrato.PageIndex = e.NewPageIndex;
            Lista_Tipo_Contrato();
        }

        protected void grvTipo_Contrato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Contrato = new Ent_Tipo_Contrato();
                    objETipo_Contrato.Descripcion = ((TextBox)grvTipo_Contrato.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objETipo_Contrato.Abreviatura = ((TextBox)grvTipo_Contrato.FooterRow.FindControl("txtAbreviaturaNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Contrato.Inserta_Tipo_Contrato(objETipo_Contrato);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Contrato();
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
        protected void grvTipo_Contrato_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Contrato_Id;
                Tipo_Contrato_Id = grvTipo_Contrato.DataKeys[e.RowIndex].Values["Tipo_Contrato_Id"].ToString();
                objETipo_Contrato = new Ent_Tipo_Contrato();
                objETipo_Contrato.Tipo_Contrato_Id = Tipo_Contrato_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Contrato.Elimina_Tipo_Contrato(objETipo_Contrato);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Contrato();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Contrato_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Contrato.EditIndex = e.NewEditIndex;
            Lista_Tipo_Contrato();
        }

        protected void grvTipo_Contrato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Contrato.EditIndex = -1;
            Lista_Tipo_Contrato();
        }
        protected void grvTipo_Contrato_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Contrato_Id;
                Tipo_Contrato_Id = grvTipo_Contrato.DataKeys[e.RowIndex].Values["Tipo_Contrato_Id"].ToString();
                objETipo_Contrato = new Ent_Tipo_Contrato();
                objETipo_Contrato.Tipo_Contrato_Id = Tipo_Contrato_Id;
                objETipo_Contrato.Descripcion = ((TextBox)grvTipo_Contrato.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objETipo_Contrato.Abreviatura = ((TextBox)grvTipo_Contrato.Rows[e.RowIndex].FindControl("txtAbreviatura")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Contrato.Actualiza_Tipo_Contrato(objETipo_Contrato);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Contrato.EditIndex = -1;
                    Lista_Tipo_Contrato();
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
                objETipo_Contrato = new Ent_Tipo_Contrato();
                objETipo_Contrato.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objETipo_Contrato.Abreviatura = txtAbreviaturaNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Contrato.Inserta_Tipo_Contrato(objETipo_Contrato);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtAbreviaturaNuevo.Text = "";
                    Lista_Tipo_Contrato();
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