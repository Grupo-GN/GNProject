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
    public partial class FrmMntTipo_Zona : System.Web.UI.Page
    {
        Ent_Tipo_Zona objETipo_Zona;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Zona();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Zona();
        }

        void Lista_Tipo_Zona()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Zona = new Ent_Tipo_Zona();
                DataTable dtTipo_Zona = new DataTable();
                dtTipo_Zona = Log_Tipo_Zona.Lista_Tipo_Zona(objETipo_Zona);
                Utils.fc_Adecua_GridView(grvTipo_Zona, dtTipo_Zona.Rows.Count);
                grvTipo_Zona.DataSource = dtTipo_Zona;
                grvTipo_Zona.DataBind();
                dtTipo_Zona.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTipo_Zona_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Zona.PageIndex = e.NewPageIndex;
            Lista_Tipo_Zona();
        }

        protected void grvTipo_Zona_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Zona = new Ent_Tipo_Zona();
                    objETipo_Zona.Descripcion = ((TextBox)grvTipo_Zona.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Zona.Inserta_Tipo_Zona(objETipo_Zona);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Zona();
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
        protected void grvTipo_Zona_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Zona_Id;
                Tipo_Zona_Id = grvTipo_Zona.DataKeys[e.RowIndex].Values["Tipo_Zona_Id"].ToString();
                objETipo_Zona = new Ent_Tipo_Zona();
                objETipo_Zona.Tipo_Zona_Id = Tipo_Zona_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Zona.Elimina_Tipo_Zona(objETipo_Zona);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Zona();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Zona_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Zona.EditIndex = e.NewEditIndex;
            Lista_Tipo_Zona();
        }

        protected void grvTipo_Zona_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Zona.EditIndex = -1;
            Lista_Tipo_Zona();
        }
        protected void grvTipo_Zona_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Zona_Id;
                Tipo_Zona_Id = grvTipo_Zona.DataKeys[e.RowIndex].Values["Tipo_Zona_Id"].ToString();
                objETipo_Zona = new Ent_Tipo_Zona();
                objETipo_Zona.Tipo_Zona_Id = Tipo_Zona_Id;
                objETipo_Zona.Descripcion = ((TextBox)grvTipo_Zona.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Zona.Actualiza_Tipo_Zona(objETipo_Zona);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Zona.EditIndex = -1;
                    Lista_Tipo_Zona();
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
                objETipo_Zona = new Ent_Tipo_Zona();
                objETipo_Zona.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Zona.Inserta_Tipo_Zona(objETipo_Zona);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Tipo_Zona();
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