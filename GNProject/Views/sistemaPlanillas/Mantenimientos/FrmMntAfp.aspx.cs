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
    public partial class FrmMntAfp : System.Web.UI.Page
    {
        Ent_AFP objEAfp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Carga_Estados();
                Lista_Afp();
            }
        }

        void Carga_Estados()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            cboEstadoNuevo.DataSource = Log_General.Lista_Estados();
            cboEstadoNuevo.DataTextField = "Descripcion";
            cboEstadoNuevo.DataValueField = "Codigo";
            cboEstadoNuevo.DataBind();
        }
        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Afp();
        }

        void Lista_Afp()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objEAfp = new Ent_AFP();
                DataTable dtAfp = new DataTable();
                dtAfp = Log_AFP.Lista_Afp(objEAfp);
                Utils.fc_Adecua_GridView(grvAfp, dtAfp.Rows.Count);
                grvAfp.DataSource = dtAfp;
                grvAfp.DataBind();
                dtAfp.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvAfp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvAfp.PageIndex = e.NewPageIndex;
            Lista_Afp();
        }

        protected void grvAfp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList cboEstadoNew = (DropDownList)e.Row.FindControl("cboEstadoNew");
                    if (cboEstadoNew != null)
                    {
                        cboEstadoNew.DataSource = Log_General.Lista_Estados();
                        cboEstadoNew.DataTextField = "Descripcion";
                        cboEstadoNew.DataValueField = "Codigo";
                        cboEstadoNew.DataBind();
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList cboEstado = (DropDownList)e.Row.FindControl("cboEstado");
                    if (cboEstado != null)
                    {
                        cboEstado.DataSource = Log_General.Lista_Estados();
                        cboEstado.DataTextField = "Descripcion";
                        cboEstado.DataValueField = "Codigo";
                        cboEstado.DataBind();

                        string Estado_Id_Seleccionado;
                        Estado_Id_Seleccionado = grvAfp.DataKeys[e.Row.RowIndex].Values["Estado_Id"].ToString();

                        if (Estado_Id_Seleccionado.Trim() != "" || Estado_Id_Seleccionado != null)
                        {
                            Boolean rpta = false;
                            foreach (ListItem list in cboEstado.Items)
                            {
                                if (Estado_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                                cboEstado.SelectedValue = Estado_Id_Seleccionado;
                            else
                                cboEstado.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvAfp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (e.CommandName == "Insert")
            {
                try
                {
                    objEAfp = new Ent_AFP();
                    objEAfp.Descripcion = ((TextBox)grvAfp.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objEAfp.Estado_id = ((DropDownList)grvAfp.FooterRow.FindControl("cboEstadoNew")).SelectedValue;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_AFP.Inserta_Afp(objEAfp);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Afp();
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
        protected void grvAfp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Afp_Id;
                Afp_Id = grvAfp.DataKeys[e.RowIndex].Values["Afp_Id"].ToString();
                objEAfp = new Ent_AFP();
                objEAfp.Afp_Id = Afp_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_AFP.Elimina_Afp(objEAfp);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Afp();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvAfp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvAfp.EditIndex = e.NewEditIndex;
            Lista_Afp();
        }

        protected void grvAfp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvAfp.EditIndex = -1;
            Lista_Afp();
        }
        protected void grvAfp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Afp_Id;
                Afp_Id = grvAfp.DataKeys[e.RowIndex].Values["Afp_Id"].ToString();
                objEAfp = new Ent_AFP();
                objEAfp.Afp_Id = Afp_Id;
                objEAfp.Descripcion = ((TextBox)grvAfp.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objEAfp.Estado_id = ((DropDownList)grvAfp.Rows[e.RowIndex].FindControl("cboEstado")).SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_AFP.Actualiza_Afp(objEAfp);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvAfp.EditIndex = -1;
                    Lista_Afp();
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
                objEAfp = new Ent_AFP();
                objEAfp.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objEAfp.Estado_id = cboEstadoNuevo.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_AFP.Inserta_Afp(objEAfp);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    cboEstadoNuevo.SelectedIndex = 0;
                    Lista_Afp();
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