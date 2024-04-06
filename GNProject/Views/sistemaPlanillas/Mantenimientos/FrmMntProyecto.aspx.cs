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
    public partial class FrmMntProyecto : System.Web.UI.Page
    {
        Ent_Proyecto objEProyecto;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Carga_Estados();
                Lista_Proyecto();
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

            Lista_Proyecto();
        }

        void Lista_Proyecto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objEProyecto = new Ent_Proyecto();
                DataTable dtProyecto = new DataTable();
                dtProyecto = Log_Proyecto.Lista_Proyecto(objEProyecto);
                Utils.fc_Adecua_GridView(grvProyecto, dtProyecto.Rows.Count);
                grvProyecto.DataSource = dtProyecto;
                grvProyecto.DataBind();
                dtProyecto.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvProyecto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvProyecto.PageIndex = e.NewPageIndex;
            Lista_Proyecto();
        }

        protected void grvProyecto_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        Estado_Id_Seleccionado = grvProyecto.DataKeys[e.Row.RowIndex].Values["Estado_Id"].ToString();

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

        protected void grvProyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (e.CommandName == "Insert")
            {
                try
                {
                    objEProyecto = new Ent_Proyecto();
                    objEProyecto.Descripcion = ((TextBox)grvProyecto.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objEProyecto.Estado_Id = ((DropDownList)grvProyecto.FooterRow.FindControl("cboEstadoNew")).SelectedValue;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Proyecto.Inserta_Proyecto(objEProyecto);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Proyecto();
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
        protected void grvProyecto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Proyecto_Id;
                Proyecto_Id = grvProyecto.DataKeys[e.RowIndex].Values["Proyecto_Id"].ToString();
                objEProyecto = new Ent_Proyecto();
                objEProyecto.Proyecto_Id = Proyecto_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Proyecto.Elimina_Proyecto(objEProyecto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Proyecto();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvProyecto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvProyecto.EditIndex = e.NewEditIndex;
            Lista_Proyecto();
        }

        protected void grvProyecto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvProyecto.EditIndex = -1;
            Lista_Proyecto();
        }
        protected void grvProyecto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Proyecto_Id;
                Proyecto_Id = grvProyecto.DataKeys[e.RowIndex].Values["Proyecto_Id"].ToString();
                objEProyecto = new Ent_Proyecto();
                objEProyecto.Proyecto_Id = Proyecto_Id;
                objEProyecto.Descripcion = ((TextBox)grvProyecto.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objEProyecto.Estado_Id = ((DropDownList)grvProyecto.Rows[e.RowIndex].FindControl("cboEstado")).SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Proyecto.Actualiza_Proyecto(objEProyecto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvProyecto.EditIndex = -1;
                    Lista_Proyecto();
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
                objEProyecto = new Ent_Proyecto();
                objEProyecto.Descripcion = txtDescripcionNuevo.Text.ToUpper();
                objEProyecto.Estado_Id = cboEstadoNuevo.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Proyecto.Inserta_Proyecto(objEProyecto);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    txtDescripcionNuevo.Text = "";
                    cboEstadoNuevo.SelectedIndex = 0;
                    Lista_Proyecto();
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