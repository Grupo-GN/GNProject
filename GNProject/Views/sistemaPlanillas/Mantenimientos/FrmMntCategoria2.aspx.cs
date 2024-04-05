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
    public partial class FrmMntCategoria2 : System.Web.UI.Page
    {
        Ent_Categoria2 objECategoria2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Lista_Categoria2();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Categoria2();
        }

        void Lista_Categoria2()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objECategoria2 = new Ent_Categoria2();
                DataTable dtCategoria2 = new DataTable();
                dtCategoria2 = Log_Categoria2.Lista_Categoria2(objECategoria2);
                Utils.fc_Adecua_GridView(grvCategoria2, dtCategoria2.Rows.Count);
                grvCategoria2.DataSource = dtCategoria2;
                grvCategoria2.DataBind();
                dtCategoria2.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCategoria2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvCategoria2.PageIndex = e.NewPageIndex;
            Lista_Categoria2();
        }

        protected void grvCategoria2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (e.CommandName == "Insert")
            {
                try
                {
                    objECategoria2 = new Ent_Categoria2();
                    objECategoria2.Descripcion = ((TextBox)grvCategoria2.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Categoria2.Inserta_Categoria2(objECategoria2);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Categoria2();
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
        protected void grvCategoria2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Categoria2_Id;
                Categoria2_Id = grvCategoria2.DataKeys[e.RowIndex].Values["Categoria2_Id"].ToString();
                objECategoria2 = new Ent_Categoria2();
                objECategoria2.Categoria2_Id = Categoria2_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria2.Elimina_Categoria2(objECategoria2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Categoria2();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCategoria2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvCategoria2.EditIndex = e.NewEditIndex;
            Lista_Categoria2();
        }

        protected void grvCategoria2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvCategoria2.EditIndex = -1;
            Lista_Categoria2();
        }
        protected void grvCategoria2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Categoria2_Id;
                Categoria2_Id = grvCategoria2.DataKeys[e.RowIndex].Values["Categoria2_Id"].ToString();
                objECategoria2 = new Ent_Categoria2();
                objECategoria2.Categoria2_Id = Categoria2_Id;
                objECategoria2.Descripcion = ((TextBox)grvCategoria2.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria2.Actualiza_Categoria2(objECategoria2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvCategoria2.EditIndex = -1;
                    Lista_Categoria2();
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
                objECategoria2 = new Ent_Categoria2();
                objECategoria2.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria2.Inserta_Categoria2(objECategoria2);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Categoria2();
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