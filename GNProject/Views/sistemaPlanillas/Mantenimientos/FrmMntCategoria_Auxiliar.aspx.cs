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
    public partial class FrmMntCategoria_Auxiliar : System.Web.UI.Page
    {
        Ent_Categoria_Auxiliar objECategoria_Auxiliar;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Categoria_Auxiliar();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Categoria_Auxiliar();
        }

        void Lista_Categoria_Auxiliar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                DataTable dtCategoria_Auxiliar = new DataTable();
                dtCategoria_Auxiliar = Log_Categoria_Auxiliar.Lista_Categoria_Auxiliar(objECategoria_Auxiliar);
                Utils.fc_Adecua_GridView(grvCategoria_Auxiliar, dtCategoria_Auxiliar.Rows.Count);
                grvCategoria_Auxiliar.DataSource = dtCategoria_Auxiliar;
                grvCategoria_Auxiliar.DataBind();
                dtCategoria_Auxiliar.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCategoria_Auxiliar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar.PageIndex = e.NewPageIndex;
            Lista_Categoria_Auxiliar();
        }

        protected void grvCategoria_Auxiliar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                    objECategoria_Auxiliar.Descripcion = ((TextBox)grvCategoria_Auxiliar.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Categoria_Auxiliar.Inserta_Categoria_Auxiliar(objECategoria_Auxiliar);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Categoria_Auxiliar();
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
        protected void grvCategoria_Auxiliar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = grvCategoria_Auxiliar.DataKeys[e.RowIndex].Values["Categoria_Auxiliar_Id"].ToString();
                objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                objECategoria_Auxiliar.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria_Auxiliar.Elimina_Categoria_Auxiliar(objECategoria_Auxiliar);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Categoria_Auxiliar();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCategoria_Auxiliar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar.EditIndex = e.NewEditIndex;
            Lista_Categoria_Auxiliar();
        }

        protected void grvCategoria_Auxiliar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar.EditIndex = -1;
            Lista_Categoria_Auxiliar();
        }
        protected void grvCategoria_Auxiliar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = grvCategoria_Auxiliar.DataKeys[e.RowIndex].Values["Categoria_Auxiliar_Id"].ToString();
                objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                objECategoria_Auxiliar.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;
                objECategoria_Auxiliar.Descripcion = ((TextBox)grvCategoria_Auxiliar.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria_Auxiliar.Actualiza_Categoria_Auxiliar(objECategoria_Auxiliar);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvCategoria_Auxiliar.EditIndex = -1;
                    Lista_Categoria_Auxiliar();
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
                objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                objECategoria_Auxiliar.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Categoria_Auxiliar.Inserta_Categoria_Auxiliar(objECategoria_Auxiliar);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Categoria_Auxiliar();
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