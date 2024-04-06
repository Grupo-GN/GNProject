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
    public partial class FrmMntMotivo_Fin_Per_Lab : System.Web.UI.Page
    {
        Ent_Motivo_Fin_Per_Lab objEMotivo_Fin_Per_Lab;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Motivo_Fin_Per_Lab();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Motivo_Fin_Per_Lab();
        }

        void Lista_Motivo_Fin_Per_Lab()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objEMotivo_Fin_Per_Lab = new Ent_Motivo_Fin_Per_Lab();
                DataTable dtMotivo_Fin_Per_Lab = new DataTable();
                dtMotivo_Fin_Per_Lab = Log_Motivo_Fin_Per_Lab.Lista_Motivo_Fin_Per_Lab(objEMotivo_Fin_Per_Lab);
                Utils.fc_Adecua_GridView(grvMotivo_Fin_Per_Lab, dtMotivo_Fin_Per_Lab.Rows.Count);
                grvMotivo_Fin_Per_Lab.DataSource = dtMotivo_Fin_Per_Lab;
                grvMotivo_Fin_Per_Lab.DataBind();
                dtMotivo_Fin_Per_Lab.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvMotivo_Fin_Per_Lab_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvMotivo_Fin_Per_Lab.PageIndex = e.NewPageIndex;
            Lista_Motivo_Fin_Per_Lab();
        }

        protected void grvMotivo_Fin_Per_Lab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objEMotivo_Fin_Per_Lab = new Ent_Motivo_Fin_Per_Lab();
                    objEMotivo_Fin_Per_Lab.Descripcion = ((TextBox)grvMotivo_Fin_Per_Lab.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objEMotivo_Fin_Per_Lab.Abreviatura = ((TextBox)grvMotivo_Fin_Per_Lab.FooterRow.FindControl("txtAbreviaturaNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Motivo_Fin_Per_Lab.Inserta_Motivo_Fin_Per_Lab(objEMotivo_Fin_Per_Lab);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Motivo_Fin_Per_Lab();
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
        protected void grvMotivo_Fin_Per_Lab_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Motivo_Fin_Per_Lab_Id;
                Motivo_Fin_Per_Lab_Id = grvMotivo_Fin_Per_Lab.DataKeys[e.RowIndex].Values["Motivo_Fin_Per_Lab_Id"].ToString();
                objEMotivo_Fin_Per_Lab = new Ent_Motivo_Fin_Per_Lab();
                objEMotivo_Fin_Per_Lab.Motivo_Fin_Per_Lab_Id = Motivo_Fin_Per_Lab_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Motivo_Fin_Per_Lab.Elimina_Motivo_Fin_Per_Lab(objEMotivo_Fin_Per_Lab);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Motivo_Fin_Per_Lab();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvMotivo_Fin_Per_Lab_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvMotivo_Fin_Per_Lab.EditIndex = e.NewEditIndex;
            Lista_Motivo_Fin_Per_Lab();
        }

        protected void grvMotivo_Fin_Per_Lab_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvMotivo_Fin_Per_Lab.EditIndex = -1;
            Lista_Motivo_Fin_Per_Lab();
        }
        protected void grvMotivo_Fin_Per_Lab_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Motivo_Fin_Per_Lab_Id;
                Motivo_Fin_Per_Lab_Id = grvMotivo_Fin_Per_Lab.DataKeys[e.RowIndex].Values["Motivo_Fin_Per_Lab_Id"].ToString();
                objEMotivo_Fin_Per_Lab = new Ent_Motivo_Fin_Per_Lab();
                objEMotivo_Fin_Per_Lab.Motivo_Fin_Per_Lab_Id = Motivo_Fin_Per_Lab_Id;
                objEMotivo_Fin_Per_Lab.Descripcion = ((TextBox)grvMotivo_Fin_Per_Lab.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objEMotivo_Fin_Per_Lab.Abreviatura = ((TextBox)grvMotivo_Fin_Per_Lab.Rows[e.RowIndex].FindControl("txtAbreviatura")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Motivo_Fin_Per_Lab.Actualiza_Motivo_Fin_Per_Lab(objEMotivo_Fin_Per_Lab);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvMotivo_Fin_Per_Lab.EditIndex = -1;
                    Lista_Motivo_Fin_Per_Lab();
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
                objEMotivo_Fin_Per_Lab = new Ent_Motivo_Fin_Per_Lab();
                objEMotivo_Fin_Per_Lab.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objEMotivo_Fin_Per_Lab.Abreviatura = txtAbreviaturaNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Motivo_Fin_Per_Lab.Inserta_Motivo_Fin_Per_Lab(objEMotivo_Fin_Per_Lab);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtAbreviaturaNuevo.Text = "";
                    Lista_Motivo_Fin_Per_Lab();
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