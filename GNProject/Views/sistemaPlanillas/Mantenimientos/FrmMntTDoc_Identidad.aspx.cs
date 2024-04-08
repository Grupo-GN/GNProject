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
    public partial class FrmMntTDoc_Identidad : System.Web.UI.Page
    {
        Ent_TDoc_Identidad objETDoc_Identidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_TDoc_Identidad();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_TDoc_Identidad();
        }

        void Lista_TDoc_Identidad()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETDoc_Identidad = new Ent_TDoc_Identidad();
                DataTable dtTDoc_Identidad = new DataTable();
                dtTDoc_Identidad = Log_TDoc_Identidad.Lista_TDoc_Identidad(objETDoc_Identidad);
                Utils.fc_Adecua_GridView(grvTDoc_Identidad, dtTDoc_Identidad.Rows.Count);
                grvTDoc_Identidad.DataSource = dtTDoc_Identidad;
                grvTDoc_Identidad.DataBind();
                dtTDoc_Identidad.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTDoc_Identidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTDoc_Identidad.PageIndex = e.NewPageIndex;
            Lista_TDoc_Identidad();
        }

        protected void grvTDoc_Identidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETDoc_Identidad = new Ent_TDoc_Identidad();
                    objETDoc_Identidad.Descripcion = ((TextBox)grvTDoc_Identidad.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objETDoc_Identidad.Abreviatura = ((TextBox)grvTDoc_Identidad.FooterRow.FindControl("txtAbreviaturaNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_TDoc_Identidad.Inserta_TDoc_Identidad(objETDoc_Identidad);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_TDoc_Identidad();
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
        protected void grvTDoc_Identidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Doc_Id;
                Tipo_Doc_Id = grvTDoc_Identidad.DataKeys[e.RowIndex].Values["Tipo_Doc_Id"].ToString();
                objETDoc_Identidad = new Ent_TDoc_Identidad();
                objETDoc_Identidad.Tipo_Doc_Id = Tipo_Doc_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_TDoc_Identidad.Elimina_TDoc_Identidad(objETDoc_Identidad);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_TDoc_Identidad();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTDoc_Identidad_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTDoc_Identidad.EditIndex = e.NewEditIndex;
            Lista_TDoc_Identidad();
        }

        protected void grvTDoc_Identidad_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTDoc_Identidad.EditIndex = -1;
            Lista_TDoc_Identidad();
        }
        protected void grvTDoc_Identidad_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Doc_Id;
                Tipo_Doc_Id = grvTDoc_Identidad.DataKeys[e.RowIndex].Values["Tipo_Doc_Id"].ToString();
                objETDoc_Identidad = new Ent_TDoc_Identidad();
                objETDoc_Identidad.Tipo_Doc_Id = Tipo_Doc_Id;
                objETDoc_Identidad.Descripcion = ((TextBox)grvTDoc_Identidad.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objETDoc_Identidad.Abreviatura = ((TextBox)grvTDoc_Identidad.Rows[e.RowIndex].FindControl("txtAbreviatura")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_TDoc_Identidad.Actualiza_TDoc_Identidad(objETDoc_Identidad);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTDoc_Identidad.EditIndex = -1;
                    Lista_TDoc_Identidad();
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
                objETDoc_Identidad = new Ent_TDoc_Identidad();
                objETDoc_Identidad.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objETDoc_Identidad.Abreviatura = txtAbreviaturaNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_TDoc_Identidad.Inserta_TDoc_Identidad(objETDoc_Identidad);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtAbreviaturaNuevo.Text = "";
                    Lista_TDoc_Identidad();
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