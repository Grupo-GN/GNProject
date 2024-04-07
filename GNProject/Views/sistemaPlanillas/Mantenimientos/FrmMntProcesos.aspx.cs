using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntProcesos : BasePage
    {
        Ent_Procesos objEProcesos;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Procesos();
            }
            HighlightGridLine();
        }

        /*void Carga_Estados()
          {
              cboEstadoNuevo.DataSource = Log_General.Lista_Estados();
              cboEstadoNuevo.DataTextField = "Descripcion";
              cboEstadoNuevo.DataValueField = "Codigo";
              cboEstadoNuevo.DataBind();
          }*/
        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Procesos();
        }

        void Lista_Procesos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                grvProcesos.DataSource = Log_Procesos.Lista_Procesos(txtProcesoNuevo.Text);
                grvProcesos.DataBind();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvProcesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvProcesos.PageIndex = e.NewPageIndex;
            Lista_Procesos();
        }

        protected void grvProcesos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }

        protected void grvProcesos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Edit")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string Permiso_Id = grvProcesos.DataKeys[row.RowIndex].Values["Proceso_Id"].ToString();

                string FileStrean = "ModalProceso.aspx";
                string Clientscript = "AbrirModal('" + FileStrean + "?Proceso_Id=" + Permiso_Id + "&pTipo_Proceso=2')";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
            }
        }
        protected void grvProcesos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Proceso_Id;
                Proceso_Id = grvProcesos.DataKeys[e.RowIndex].Values["Proceso_Id"].ToString();
                objEProcesos = new Ent_Procesos();
                objEProcesos.Proceso_Id = Proceso_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Procesos.Elimina_Procesos(objEProcesos);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Procesos();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvProcesos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //try
            //{
            //    string Proceso_Id;
            //    Proceso_Id = grvProcesos.DataKeys[e.RowIndex].Values["Proceso_Id"].ToString();
            //    objEProcesos = new Ent_Procesos();
            //    objEProcesos.Proceso_Id = Proceso_Id;
            //    objEProcesos.Proceso = ((TextBox)grvProcesos.Rows[e.RowIndex].FindControl("txtProceso")).Text.ToUpper();
            //    objEProcesos.Estado_Id = ((DropDownList)grvProcesos.Rows[e.RowIndex].FindControl("cboEstado")).SelectedValue;

            //    DataTable dtRpta = new DataTable();
            //    dtRpta = Log_Procesos.Actualiza_Procesos(objEProcesos);

            //    string msj_rpta;
            //    msj_rpta = dtRpta.Rows[0][1].ToString();
            //    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            //    {
            //        grvProcesos.EditIndex = -1;
            //        Lista_Procesos();
            //    }
            //    dtRpta.Dispose();
            //    Utils.fc_DisplayAlert(this, msj_rpta);
            //}
            //catch (Exception ex)
            //{
            //    Utils.fc_DisplayAlert(this, ex.Message);
            //}
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    objEProcesos = new Ent_Procesos();
            //    objEProcesos.Proceso = txtProcesoNuevo.Text.ToUpper();
            // //   objEProcesos.Estado_Id = cboEstadoNuevo.SelectedValue;

            //    DataTable dtRpta = new DataTable();
            //    dtRpta = Log_Procesos.Inserta_Procesos(objEProcesos);

            //    string msj_rpta;
            //    msj_rpta = dtRpta.Rows[0][1].ToString();
            //    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
            //    {
            //        txtProcesoNuevo.Text = "";
            //      //  cboEstadoNuevo.SelectedIndex = 0;
            //        Lista_Procesos();
            //    }
            //    dtRpta.Dispose();
            //    Utils.fc_DisplayAlert(this, msj_rpta);
            //}
            //catch (Exception ex)
            //{
            //    Utils.fc_DisplayAlert(this, ex.Message);
            //}
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string Permiso_Id = "01";
            string FileStrean = "ModalProceso.aspx";
            string Clientscript = "AbrirModal('" + FileStrean + "?Proceso_Id=" + Permiso_Id + "&pTipo_Proceso=1')";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
        }

        protected void grvProcesos_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void grvProcesos_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Procesos();
        }
    }
}