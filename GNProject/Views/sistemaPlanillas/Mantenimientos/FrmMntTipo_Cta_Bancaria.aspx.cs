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
    public partial class FrmMntTipo_Cta_Bancaria : System.Web.UI.Page
    {
        Ent_Tipo_Cta_Bancaria objETipo_Cta_Bancaria;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Cta_Bancaria();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Cta_Bancaria();
        }

        void Lista_Tipo_Cta_Bancaria()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Cta_Bancaria = new Ent_Tipo_Cta_Bancaria();
                DataTable dtTipo_Cta_Bancaria = new DataTable();
                dtTipo_Cta_Bancaria = Log_Tipo_Cta_Bancaria.Lista_Tipo_Cta_Bancaria(objETipo_Cta_Bancaria);
                Utils.fc_Adecua_GridView(grvTipo_Cta_Bancaria, dtTipo_Cta_Bancaria.Rows.Count);
                grvTipo_Cta_Bancaria.DataSource = dtTipo_Cta_Bancaria;
                grvTipo_Cta_Bancaria.DataBind();
                dtTipo_Cta_Bancaria.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }


        protected void grvTipo_Cta_Bancaria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Cta_Bancaria.PageIndex = e.NewPageIndex;
            Lista_Tipo_Cta_Bancaria();
        }

        protected void grvTipo_Cta_Bancaria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Cta_Bancaria = new Ent_Tipo_Cta_Bancaria();
                    objETipo_Cta_Bancaria.Descripcion = ((TextBox)grvTipo_Cta_Bancaria.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Cta_Bancaria.Inserta_Tipo_Cta_Bancaria(objETipo_Cta_Bancaria);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Cta_Bancaria();
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
        protected void grvTipo_Cta_Bancaria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string TCB_Id;
                TCB_Id = grvTipo_Cta_Bancaria.DataKeys[e.RowIndex].Values["TCB_Id"].ToString();
                objETipo_Cta_Bancaria = new Ent_Tipo_Cta_Bancaria();
                objETipo_Cta_Bancaria.TCB_Id = TCB_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Cta_Bancaria.Elimina_Tipo_Cta_Bancaria(objETipo_Cta_Bancaria);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Cta_Bancaria();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Cta_Bancaria_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Cta_Bancaria.EditIndex = e.NewEditIndex;
            Lista_Tipo_Cta_Bancaria();
        }

        protected void grvTipo_Cta_Bancaria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Cta_Bancaria.EditIndex = -1;
            Lista_Tipo_Cta_Bancaria();
        }
        protected void grvTipo_Cta_Bancaria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string TCB_Id;
                TCB_Id = grvTipo_Cta_Bancaria.DataKeys[e.RowIndex].Values["TCB_Id"].ToString();
                objETipo_Cta_Bancaria = new Ent_Tipo_Cta_Bancaria();
                objETipo_Cta_Bancaria.TCB_Id = TCB_Id;
                objETipo_Cta_Bancaria.Descripcion = ((TextBox)grvTipo_Cta_Bancaria.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Cta_Bancaria.Actualiza_Tipo_Cta_Bancaria(objETipo_Cta_Bancaria);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Cta_Bancaria.EditIndex = -1;
                    Lista_Tipo_Cta_Bancaria();
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
                objETipo_Cta_Bancaria = new Ent_Tipo_Cta_Bancaria();
                objETipo_Cta_Bancaria.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Cta_Bancaria.Inserta_Tipo_Cta_Bancaria(objETipo_Cta_Bancaria);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Tipo_Cta_Bancaria();
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