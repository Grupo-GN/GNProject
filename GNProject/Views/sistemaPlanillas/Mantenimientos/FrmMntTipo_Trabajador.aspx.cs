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
    public partial class FrmMntTipo_Trabajador : System.Web.UI.Page
    {
        Ent_Tipo_Trabajador objETipo_Trabajador;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Trabajador();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Trabajador();
        }

        void Lista_Tipo_Trabajador()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Trabajador = new Ent_Tipo_Trabajador();
                DataTable dtTipo_Trabajador = new DataTable();
                dtTipo_Trabajador = Log_Tipo_Trabajador.Lista_Tipo_Trabajador(objETipo_Trabajador);
                Utils.fc_Adecua_GridView(grvTipo_Trabajador, dtTipo_Trabajador.Rows.Count);
                grvTipo_Trabajador.DataSource = dtTipo_Trabajador;
                grvTipo_Trabajador.DataBind();
                dtTipo_Trabajador.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTipo_Trabajador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Trabajador.PageIndex = e.NewPageIndex;
            Lista_Tipo_Trabajador();
        }

        protected void grvTipo_Trabajador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Trabajador = new Ent_Tipo_Trabajador();
                    objETipo_Trabajador.Descripcion = ((TextBox)grvTipo_Trabajador.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objETipo_Trabajador.Abreviatura = ((TextBox)grvTipo_Trabajador.FooterRow.FindControl("txtAbreviaturaNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Trabajador.Inserta_Tipo_Trabajador(objETipo_Trabajador);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Trabajador();
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
        protected void grvTipo_Trabajador_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Trabajador_Id;
                Tipo_Trabajador_Id = grvTipo_Trabajador.DataKeys[e.RowIndex].Values["Tipo_Trabajador_Id"].ToString();
                objETipo_Trabajador = new Ent_Tipo_Trabajador();
                objETipo_Trabajador.Tipo_Trabajador_Id = Tipo_Trabajador_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Trabajador.Elimina_Tipo_Trabajador(objETipo_Trabajador);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Trabajador();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Trabajador_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Trabajador.EditIndex = e.NewEditIndex;
            Lista_Tipo_Trabajador();
        }

        protected void grvTipo_Trabajador_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Trabajador.EditIndex = -1;
            Lista_Tipo_Trabajador();
        }
        protected void grvTipo_Trabajador_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Trabajador_Id;
                Tipo_Trabajador_Id = grvTipo_Trabajador.DataKeys[e.RowIndex].Values["Tipo_Trabajador_Id"].ToString();
                objETipo_Trabajador = new Ent_Tipo_Trabajador();
                objETipo_Trabajador.Tipo_Trabajador_Id = Tipo_Trabajador_Id;
                objETipo_Trabajador.Descripcion = ((TextBox)grvTipo_Trabajador.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objETipo_Trabajador.Abreviatura = ((TextBox)grvTipo_Trabajador.Rows[e.RowIndex].FindControl("txtAbreviatura")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Trabajador.Actualiza_Tipo_Trabajador(objETipo_Trabajador);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Trabajador.EditIndex = -1;
                    Lista_Tipo_Trabajador();
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
                objETipo_Trabajador = new Ent_Tipo_Trabajador();
                objETipo_Trabajador.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objETipo_Trabajador.Abreviatura = txtAbreviaturaNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Trabajador.Inserta_Tipo_Trabajador(objETipo_Trabajador);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    txtAbreviaturaNuevo.Text = "";
                    Lista_Tipo_Trabajador();
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