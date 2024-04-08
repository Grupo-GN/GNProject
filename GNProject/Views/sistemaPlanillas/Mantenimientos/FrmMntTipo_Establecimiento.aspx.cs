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
    public partial class FrmMntTipo_Establecimiento : System.Web.UI.Page
    {
        Ent_Tipo_Establecimiento objETipo_Establecimiento;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Tipo_Establecimiento();
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Tipo_Establecimiento();
        }

        void Lista_Tipo_Establecimiento()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Establecimiento = new Ent_Tipo_Establecimiento();
                DataTable dtTipo_Establecimiento = new DataTable();
                dtTipo_Establecimiento = Log_Tipo_Establecimiento.Lista_Tipo_Establecimiento(objETipo_Establecimiento);
                Utils.fc_Adecua_GridView(grvTipo_Establecimiento, dtTipo_Establecimiento.Rows.Count);
                grvTipo_Establecimiento.DataSource = dtTipo_Establecimiento;
                grvTipo_Establecimiento.DataBind();
                dtTipo_Establecimiento.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvTipo_Establecimiento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Establecimiento.PageIndex = e.NewPageIndex;
            Lista_Tipo_Establecimiento();
        }

        protected void grvTipo_Establecimiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    objETipo_Establecimiento = new Ent_Tipo_Establecimiento();
                    objETipo_Establecimiento.Descripcion = ((TextBox)grvTipo_Establecimiento.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Tipo_Establecimiento.Inserta_Tipo_Establecimiento(objETipo_Establecimiento);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Tipo_Establecimiento();
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
        protected void grvTipo_Establecimiento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Establecimiento_Id;
                Tipo_Establecimiento_Id = grvTipo_Establecimiento.DataKeys[e.RowIndex].Values["Tipo_Establecimiento_Id"].ToString();
                objETipo_Establecimiento = new Ent_Tipo_Establecimiento();
                objETipo_Establecimiento.Tipo_Establecimiento_Id = Tipo_Establecimiento_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Establecimiento.Elimina_Tipo_Establecimiento(objETipo_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Tipo_Establecimiento();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvTipo_Establecimiento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Establecimiento.EditIndex = e.NewEditIndex;
            Lista_Tipo_Establecimiento();
        }

        protected void grvTipo_Establecimiento_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvTipo_Establecimiento.EditIndex = -1;
            Lista_Tipo_Establecimiento();
        }
        protected void grvTipo_Establecimiento_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Tipo_Establecimiento_Id;
                Tipo_Establecimiento_Id = grvTipo_Establecimiento.DataKeys[e.RowIndex].Values["Tipo_Establecimiento_Id"].ToString();
                objETipo_Establecimiento = new Ent_Tipo_Establecimiento();
                objETipo_Establecimiento.Tipo_Establecimiento_Id = Tipo_Establecimiento_Id;
                objETipo_Establecimiento.Descripcion = ((TextBox)grvTipo_Establecimiento.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Establecimiento.Actualiza_Tipo_Establecimiento(objETipo_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvTipo_Establecimiento.EditIndex = -1;
                    Lista_Tipo_Establecimiento();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objETipo_Establecimiento = new Ent_Tipo_Establecimiento();
                objETipo_Establecimiento.Descripcion = txtDescripcionNuevo.Text.ToUpper();

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Tipo_Establecimiento.Inserta_Tipo_Establecimiento(objETipo_Establecimiento);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    Lista_Tipo_Establecimiento();
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