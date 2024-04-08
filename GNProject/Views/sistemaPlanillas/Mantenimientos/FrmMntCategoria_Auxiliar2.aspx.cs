using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntCategoria_Auxiliar2 : System.Web.UI.Page
    {
        //Ent_Categoria_Auxiliar objECategoria_Auxiliar;
        //Ent_Categoria_Auxiliar2 objECategoria_Auxiliar2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_Categoria_Auxiliar();
                Lista_Categoria_Auxiliar2();
            }
        }

        void Carga_Categoria_Auxiliar()
        {
            //objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
            //cboCategoria_AuxiliarNuevo.DataSource = controller_MntSeccion.getInstance().Lista_Categoria_Auxiliar("");
            //cboCategoria_AuxiliarNuevo.DataTextField = "Descripcion";
            //cboCategoria_AuxiliarNuevo.DataValueField = "Categoria_Auxiliar_Id";
            //cboCategoria_AuxiliarNuevo.DataBind();
        }
        protected void btnListar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Categoria_Auxiliar2();
        }

        void Lista_Categoria_Auxiliar2()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                //20190312
                //objECategoria_Auxiliar2 = new Ent_Categoria_Auxiliar2();
                DataTable dtCategoria_Auxiliar2 = new DataTable();

                //dtCategoria_Auxiliar2 = Log_Categoria_Auxiliar2.Lista_Categoria_Auxiliar2(objECategoria_Auxiliar2);
                dtCategoria_Auxiliar2 = controller_MntSeccion.getInstance().Lista_Categoria_Auxiliar2("", "");

                Utils.fc_Adecua_GridView(grvCategoria_Auxiliar2, dtCategoria_Auxiliar2.Rows.Count);
                grvCategoria_Auxiliar2.DataSource = dtCategoria_Auxiliar2;
                grvCategoria_Auxiliar2.DataBind();
                dtCategoria_Auxiliar2.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCategoria_Auxiliar2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar2.PageIndex = e.NewPageIndex;
            Lista_Categoria_Auxiliar2();
        }

        protected void grvCategoria_Auxiliar2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                //objECategoria_Auxiliar = new Ent_Categoria_Auxiliar();
                DataTable dtCategoria_Auxiliar = new DataTable();
                dtCategoria_Auxiliar = controller_MntSeccion.getInstance().Lista_Categoria_Auxiliar("");

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList cboCategoria_AuxiliarNew = (DropDownList)e.Row.FindControl("cboCategoria_AuxiliarNew");
                    if (cboCategoria_AuxiliarNew != null)
                    {
                        cboCategoria_AuxiliarNew.DataSource = dtCategoria_Auxiliar;
                        cboCategoria_AuxiliarNew.DataTextField = "Descripcion";
                        cboCategoria_AuxiliarNew.DataValueField = "Categoria_Auxiliar_Id";
                        cboCategoria_AuxiliarNew.DataBind();
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList cboCategoria_Auxiliar = (DropDownList)e.Row.FindControl("cboCategoria_Auxiliar");
                    if (cboCategoria_Auxiliar != null)
                    {
                        cboCategoria_Auxiliar.DataSource = dtCategoria_Auxiliar;
                        cboCategoria_Auxiliar.DataTextField = "Descripcion";
                        cboCategoria_Auxiliar.DataValueField = "Categoria_Auxiliar_Id";
                        cboCategoria_Auxiliar.DataBind();

                        string Categoria_Auxiliar_Id_Seleccionado;
                        Categoria_Auxiliar_Id_Seleccionado = grvCategoria_Auxiliar2.DataKeys[e.Row.RowIndex].Values["Categoria_Auxiliar_Id"].ToString();

                        if (Categoria_Auxiliar_Id_Seleccionado.Trim() != "" || Categoria_Auxiliar_Id_Seleccionado != null)
                        {
                            Boolean rpta = false;
                            foreach (ListItem list in cboCategoria_Auxiliar.Items)
                            {
                                if (Categoria_Auxiliar_Id_Seleccionado == list.Value.ToString())
                                {
                                    rpta = true;
                                    break; //salir del for
                                }
                            }
                            if (rpta == true)
                                cboCategoria_Auxiliar.SelectedValue = Categoria_Auxiliar_Id_Seleccionado;
                            else
                                cboCategoria_Auxiliar.SelectedIndex = 0;
                        }
                    }
                }
                dtCategoria_Auxiliar.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCategoria_Auxiliar2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Insert")
            {
                try
                {
                    /*objECategoria_Auxiliar2 = new Ent_Categoria_Auxiliar2();
                    objECategoria_Auxiliar2.Descripcion = ((TextBox)grvCategoria_Auxiliar2.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    objECategoria_Auxiliar2.Categoria_Auxiliar_Id = ((DropDownList)grvCategoria_Auxiliar2.FooterRow.FindControl("cboCategoria_AuxiliarNew")).SelectedValue;*/
                    string Descripcion = ((TextBox)grvCategoria_Auxiliar2.FooterRow.FindControl("txtDescripcionNew")).Text.ToUpper();
                    string Categoria_Auxiliar_Id = ((DropDownList)grvCategoria_Auxiliar2.FooterRow.FindControl("cboCategoria_AuxiliarNew")).SelectedValue;

                    DataTable dtRpta = new DataTable();
                    //20190312
                    //dtRpta = Log_Categoria_Auxiliar2.Inserta_Categoria_Auxiliar2(objECategoria_Auxiliar2);
                    dtRpta = controller_MntSeccion.getInstance().Inserta_Categoria_Auxiliar2(Descripcion, Categoria_Auxiliar_Id);

                    string msj_rpta;
                    msj_rpta = dtRpta.Rows[0][1].ToString();
                    if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                    {
                        Lista_Categoria_Auxiliar2();
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
        protected void grvCategoria_Auxiliar2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Categoria_Auxiliar2_Id;
                Categoria_Auxiliar2_Id = grvCategoria_Auxiliar2.DataKeys[e.RowIndex].Values["Categoria_Auxiliar2_Id"].ToString();
                /*objECategoria_Auxiliar2 = new Ent_Categoria_Auxiliar2();
                objECategoria_Auxiliar2.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;*/

                DataTable dtRpta = new DataTable();
                //20190312
                //dtRpta = Log_Categoria_Auxiliar2.Elimina_Categoria_Auxiliar2(objECategoria_Auxiliar2);
                dtRpta = controller_MntSeccion.getInstance().Elimina_Categoria_Auxiliar2(Categoria_Auxiliar2_Id);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    Lista_Categoria_Auxiliar2();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void grvCategoria_Auxiliar2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar2.EditIndex = e.NewEditIndex;
            Lista_Categoria_Auxiliar2();
        }

        protected void grvCategoria_Auxiliar2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCategoria_Auxiliar2.EditIndex = -1;
            Lista_Categoria_Auxiliar2();
        }
        protected void grvCategoria_Auxiliar2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Categoria_Auxiliar2_Id;
                Categoria_Auxiliar2_Id = grvCategoria_Auxiliar2.DataKeys[e.RowIndex].Values["Categoria_Auxiliar2_Id"].ToString();
                /*objECategoria_Auxiliar2 = new Ent_Categoria_Auxiliar2();
                objECategoria_Auxiliar2.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;
                objECategoria_Auxiliar2.Descripcion = ((TextBox)grvCategoria_Auxiliar2.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                objECategoria_Auxiliar2.Categoria_Auxiliar_Id = ((DropDownList)grvCategoria_Auxiliar2.Rows[e.RowIndex].FindControl("cboCategoria_Auxiliar")).SelectedValue;*/

                string Descripcion = ((TextBox)grvCategoria_Auxiliar2.Rows[e.RowIndex].FindControl("txtDescripcion")).Text.ToUpper();
                string Categoria_Auxiliar_Id = ((DropDownList)grvCategoria_Auxiliar2.Rows[e.RowIndex].FindControl("cboCategoria_Auxiliar")).SelectedValue;

                DataTable dtRpta = new DataTable();
                //20190312
                //dtRpta = Log_Categoria_Auxiliar2.Actualiza_Categoria_Auxiliar2(objECategoria_Auxiliar2);
                dtRpta = controller_MntSeccion.getInstance().Actualiza_Categoria_Auxiliar2(Categoria_Auxiliar2_Id, Descripcion, Categoria_Auxiliar_Id);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    grvCategoria_Auxiliar2.EditIndex = -1;
                    Lista_Categoria_Auxiliar2();
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        //protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        /*objECategoria_Auxiliar2 = new Ent_Categoria_Auxiliar2();
        //        objECategoria_Auxiliar2.Descripcion = txtDescripcionNuevo.Text.ToUpper();
        //        objECategoria_Auxiliar2.Categoria_Auxiliar_Id = cboCategoria_AuxiliarNuevo.SelectedValue.ToString();*/
        //        string Descripcion = txtDescripcionNuevo.Text.ToUpper();
        //        string Categoria_Auxiliar_Id = cboCategoria_AuxiliarNuevo.SelectedValue.ToString();

        //        DataTable dtRpta = new DataTable();
        //        //20190312
        //        //dtRpta = Log_Categoria_Auxiliar2.Inserta_Categoria_Auxiliar2(objECategoria_Auxiliar2);
        //        dtRpta = controller_MntSeccion.getInstance().Inserta_Categoria_Auxiliar2(Descripcion, Categoria_Auxiliar_Id);

        //        string msj_rpta;
        //        msj_rpta = dtRpta.Rows[0][1].ToString();
        //        if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
        //        {
        //            txtDescripcionNuevo.Text = "";
        //            cboCategoria_AuxiliarNuevo.SelectedIndex = 0;
        //            Lista_Categoria_Auxiliar2();
        //        }
        //        dtRpta.Dispose();
        //        Utils.fc_DisplayAlert(this, msj_rpta);
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.fc_DisplayAlert(this, ex.Message);
        //    }
        //}
    }
}