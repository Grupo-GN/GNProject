using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Contrato_RRHH
{
    public partial class FrmMntFunciones : System.Web.UI.Page
    {
        Ent_Cargo objECargo;
        Ent_Cargo_Funciones objECargoFun;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (!Page.IsPostBack)
            {
                Carga_Categoria_Auxiliar();
                // Lista_Funciones();
            }
        }

        void Carga_Categoria_Auxiliar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            objECargo = new Ent_Cargo();

            Ent_Cargo ent = new Ent_Cargo();
            cboCargoNuevo.DataSource = Log_Cargo.Lista_Cargo(ent);
            cboCargoNuevo.DataTextField = "no_cargo";
            cboCargoNuevo.DataValueField = "Cargo_id";
            cboCargoNuevo.DataBind();
            cboCargoNuevo.Items.Insert(0, "-Seleccione-");
        }

        void Lista_Funciones()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                //  objECargoFun = new Ent_Cargo_Funciones();
                // objECargoFun.Cargo_Id = cboCargoNuevo.SelectedValue.ToString();
                string Cargo_Id = cboCargoNuevo.SelectedValue.ToString();
                DataTable dtCargo_Funciones = new DataTable();
                dtCargo_Funciones = Log_Cargo_Funciones.Lista_Cargo_Funciones(Cargo_Id);
                //    Utils.fc_Adecua_GridView(grvFunciones, dtCargo_Funciones.Rows.Count);
                grvFunciones.DataSource = dtCargo_Funciones;
                grvFunciones.DataBind();
                //   grvFunciones.Dispose();
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
                objECargoFun = new Ent_Cargo_Funciones();
                objECargoFun.Funcion = txtFuncionNuevo.Text.ToUpper();
                objECargoFun.Cargo_Id = cboCargoNuevo.SelectedValue;


                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo_Funciones.Inserta_Cargo_Funciones(objECargoFun);
                Lista_Funciones();
                txtFuncionNuevo.Text = "";

            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Funciones();
        }
        protected void grvFunciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvFunciones.PageIndex = e.NewPageIndex;
            Lista_Funciones();
        }
        protected void grvFunciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvFunciones.EditIndex = -1;
            Lista_Funciones();
        }
        protected void grvFunciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            if (e.CommandName == "Insert")
            {
                try
                {
                    objECargoFun = new Ent_Cargo_Funciones();
                    objECargoFun.Funcion = ((TextBox)grvFunciones.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objECargoFun.Cargo_Id = ((DropDownList)grvFunciones.FooterRow.FindControl("cboCargoNew")).SelectedValue;

                    DataTable dtRpta = new DataTable();
                    dtRpta = Log_Cargo_Funciones.Inserta_Cargo_Funciones(objECargoFun);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Funciones();
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

        protected void grvFunciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                objECargo = new Ent_Cargo();
                DataTable dtCargo = new DataTable();

                CAPA_LOGICO.BUSPersonal objNegPersonal = new BUSPersonal();
                dtCargo = objNegPersonal.ListaCargo();

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList cboCargoNew = (DropDownList)e.Row.FindControl("cboCargoNew");
                    if (cboCargoNew != null)
                    {
                        cboCargoNew.DataSource = dtCargo;
                        cboCargoNew.DataTextField = "Descripcion";
                        cboCargoNew.DataValueField = "Cargo_Id";
                        cboCargoNew.DataBind();
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList cboCargo = (DropDownList)e.Row.FindControl("cboCargo");
                    if (cboCargo != null)
                    {
                        cboCargo.DataSource = dtCargo;
                        cboCargo.DataTextField = "Descripcion";
                        cboCargo.DataValueField = "Cargo_Id";
                        cboCargo.DataBind();

                        string Cargo_Id_Seleccionado;
                        Cargo_Id_Seleccionado = grvFunciones.DataKeys[e.Row.RowIndex].Values["Cargo_Id"].ToString();

                        if (Cargo_Id_Seleccionado.Trim() != "" || Cargo_Id_Seleccionado != null)
                        {
                            Boolean rpta = false;
                            foreach (ListItem list in cboCargo.Items)
                            {
                                if (Cargo_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                                cboCargo.SelectedValue = Cargo_Id_Seleccionado;
                            else
                                cboCargo.SelectedIndex = 0;
                        }
                    }
                }
                dtCargo.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvFunciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {
                string Cargo_Funcion_Id;
                Cargo_Funcion_Id = Convert.ToString(grvFunciones.DataKeys[e.RowIndex].Values["Cargo_Funcion_Id"].ToString());
                objECargoFun = new Ent_Cargo_Funciones();
                objECargoFun.Cargo_Funcion_Id = Convert.ToInt32(Cargo_Funcion_Id);

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo_Funciones.Elimina_Cargo_Funciones(objECargoFun);


                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Funciones();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvFunciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            grvFunciones.EditIndex = e.NewEditIndex;
            Lista_Funciones();
        }
        protected void grvFunciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            try
            {

                string Cargo_Funcion_Id;
                Cargo_Funcion_Id = Convert.ToString(grvFunciones.DataKeys[e.RowIndex].Values["Cargo_Funcion_Id"].ToString());
                objECargoFun = new Ent_Cargo_Funciones();
                objECargoFun.Cargo_Funcion_Id = Convert.ToInt32(Cargo_Funcion_Id);
                objECargoFun.Cargo_Id = ((DropDownList)grvFunciones.Rows[e.RowIndex].FindControl("cboCargo")).SelectedValue;
                objECargoFun.Funcion = ((TextBox)grvFunciones.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();


                DataTable dtRpta = new DataTable();
                dtRpta = Log_Cargo_Funciones.Actualiza_Cargo_Funciones(objECargoFun);


                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvFunciones.EditIndex = -1;
                    Lista_Funciones();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void cboCargoNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            Lista_Funciones();
        }
    }
}