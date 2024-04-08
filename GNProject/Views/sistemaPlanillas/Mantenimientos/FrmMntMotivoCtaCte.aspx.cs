using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntMotivoCtaCte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                ListarMotivosCtaCte();
            }
        }

        void ListarMotivosCtaCte()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string buscar = txtbuscar.Text.Trim();
                dgvMotivo.DataSource = controllerMotivoCtaCte.getinstance().ListarMotivosCtaCte(buscar);
                dgvMotivo.DataBind();
                dgvMotivo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void dgvMotivo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList cboconceptonew = (DropDownList)e.Row.FindControl("cboconceptoNew");
                    if (cboconceptonew != null)
                    {
                        cboconceptonew.DataSource = controllerMotivoCtaCte.getinstance().ListarMotivosCtaCte_Conceptos();
                        cboconceptonew.DataTextField = "NConcepto";
                        cboconceptonew.DataValueField = "ConceptoId";
                        cboconceptonew.DataBind();
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList cboconcepto = (DropDownList)e.Row.FindControl("cboconcepto");
                    if (cboconcepto != null)
                    {
                        cboconcepto.DataSource = controllerMotivoCtaCte.getinstance().ListarMotivosCtaCte_Conceptos();
                        cboconcepto.DataTextField = "NConcepto";
                        cboconcepto.DataValueField = "ConceptoId";
                        cboconcepto.DataBind();

                        string Concepto_Id_Seleccionado = "";
                        Concepto_Id_Seleccionado = dgvMotivo.DataKeys[e.Row.RowIndex].Values["ConceptoId"].ToString();

                        if (Concepto_Id_Seleccionado.Trim() != "" || Concepto_Id_Seleccionado != null)
                        {
                            Boolean rpta = false;
                            foreach (ListItem list in cboconcepto.Items)
                            {
                                if (Concepto_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                                cboconcepto.SelectedValue = Concepto_Id_Seleccionado;
                            else
                                cboconcepto.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void dgvMotivo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    string Descripcion = ((TextBox)dgvMotivo.FooterRow.FindControl("txtmotivonew")).Text.ToUpper();
                    string ConceptoId = ((DropDownList)dgvMotivo.FooterRow.FindControl("cboconceptoNew")).SelectedValue;

                    string msj_rpta = "";
                    msj_rpta = controllerMotivoCtaCte.getinstance().InsertarMotivosCtaCte(Descripcion, ConceptoId);
                    if (msj_rpta.Split('#')[0] == "true")
                    {
                        ListarMotivosCtaCte();
                    }
                    Utils.fc_DisplayAlert(this, msj_rpta.Split('#')[1]);
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void dgvMotivo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string MotivoId;
                MotivoId = dgvMotivo.DataKeys[e.RowIndex].Values["MotivoId"].ToString();

                string msj_rpta = "";
                msj_rpta = controllerMotivoCtaCte.getinstance().EliminarMotivosCtaCte(MotivoId);

                if (msj_rpta.Split('#')[0] == "true")
                {
                    ListarMotivosCtaCte();
                }
                Utils.fc_DisplayAlert(this, msj_rpta.Split('#')[1]);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void dgvMotivo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            dgvMotivo.EditIndex = e.NewEditIndex;
            ListarMotivosCtaCte();
        }
        protected void dgvMotivo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            dgvMotivo.EditIndex = -1;
            ListarMotivosCtaCte();
        }
        protected void dgvMotivo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string MotivoId;
                MotivoId = dgvMotivo.DataKeys[e.RowIndex].Values["MotivoId"].ToString();

                string Descripcion = ((TextBox)dgvMotivo.Rows[e.RowIndex].FindControl("txtmotivo")).Text.ToUpper();
                string ConceptoId = ((DropDownList)dgvMotivo.Rows[e.RowIndex].FindControl("cboconcepto")).SelectedValue;

                string msj_rpta = "";
                msj_rpta = controllerMotivoCtaCte.getinstance().ActualizarMotivosCtaCte(MotivoId, Descripcion, ConceptoId);

                if (msj_rpta.Split('#')[0] == "true")
                {
                    dgvMotivo.EditIndex = -1;
                    ListarMotivosCtaCte();
                }
                Utils.fc_DisplayAlert(this, msj_rpta.Split('#')[1]);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            ListarMotivosCtaCte();
        }
    }
}