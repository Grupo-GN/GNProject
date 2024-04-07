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
    public partial class FrmMntIncidencias : System.Web.UI.Page
    {
        Ent_Incidencias objEN;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Lista_Campos_D_fijos();
                Lista_Campos_Personal();
                Lista_Campos_Personal_Activo();

            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableUpdate(false);
            enableNew(false);
            enableAdd(true);
            enableCancel(true);
            DataTable dt = new DataTable();
            dt = Log_Incidencias.Lista_Campos_D_fijos();
            chbCampos.DataTextField = "name";
            chbCampos.DataValueField = "name";
            chbCampos.DataSource = dt;
            chbCampos.DataBind();
            chbCampos.Dispose();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEN = new Ent_Incidencias();
            DataTable dt = new DataTable();
            objEN.Tabla = "D_fijos";
            string campos = "";

            for (Int32 i = 0; i <= chbCampos.Items.Count - 1; i++)
            {
                if (chbCampos.Items[i].Selected.Equals(true))
                {
                    campos += chbCampos.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
            if (dt.Rows.Count == 0)
            {
                objEN.campos = campos;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Incidencias.Inserta_Incidencias(objEN);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            else
            {
                Actualiza_Incidencias("D_fijos", campos);
            }
            enableUpdate(true);
            enableNew(true);
            enableAdd(false);
            enableCancel(false);
            Lista_Campos_D_fijos();

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableUpdate(true);
            enableNew(true);
            enableAdd(false);
            enableCancel(false);
            Lista_Campos_D_fijos();

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string campos = "";
            for (Int32 i = 0; i <= chbCampos.Items.Count - 1; i++)
            {
                if (chbCampos.Items[i].Selected.Equals(true))
                {
                    campos += chbCampos.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            Actualiza_Incidencias("D_fijos", campos);
            enableUpdate(true);
            enableNew(true);
            enableAdd(false);
            enableCancel(false);
            Lista_Campos_D_fijos();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        void Lista_Campos_D_fijos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {

                DataTable dt = new DataTable();
                dt = Log_Incidencias.Lista_Campos_D_fijos();
                chbCampos.DataTextField = "name";
                chbCampos.DataValueField = "name";
                chbCampos.DataSource = dt;
                chbCampos.DataBind();
                chbCampos.Dispose();
                dt.Clear();
                objEN = new Ent_Incidencias();
                objEN.Tabla = "D_fijos";
                dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
                if (dt.Rows.Count != 0)
                {
                    btnUpdate.Enabled = true;
                    for (Int32 i = 0; i <= chbCampos.Items.Count - 1; i++)
                    {
                        for (Int32 y = 0; y <= dt.Rows.Count - 1; y++)
                        {
                            if (chbCampos.Items[i].Value == dt.Rows[y][0].ToString())
                            {
                                chbCampos.Items[i].Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }

        }
        private void enableAdd(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnAdd.Enabled = opcion;
            // backgroundButton(btnAdd);
        }
        private void enableUpdate(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpdate.Enabled = opcion;
            // backgroundButton(btnUpdate);
        }
        private void enableDelete(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnDelete.Enabled = opcion;
            //backgroundButton(btnDelete);
        }
        private void enableNew(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnNew.Enabled = opcion;
            // backgroundButton(btnNew);
        }
        private void enableCancel(bool opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnCancel.Enabled = opcion;
            //backgroundButton(btnCancel);
        }

        protected void btnNew2_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUdt2.Enabled = false;
            btnNew2.Enabled = false;
            btnAdd2.Enabled = true;
            btnCancelar2.Enabled = true;
            DataTable dt = new DataTable();
            dt = Log_Incidencias.Lista_Campos_Personal();
            chbcamposPersonal.DataTextField = "name";
            chbcamposPersonal.DataValueField = "name";
            chbcamposPersonal.DataSource = dt;
            chbcamposPersonal.DataBind();
            chbcamposPersonal.Dispose();
        }
        protected void btnAdd2_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEN = new Ent_Incidencias();
            DataTable dt = new DataTable();
            objEN.Tabla = "Personal";
            string campos = "";

            for (Int32 i = 0; i <= chbcamposPersonal.Items.Count - 1; i++)
            {
                if (chbcamposPersonal.Items[i].Selected.Equals(true))
                {
                    campos += chbcamposPersonal.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
            if (dt.Rows.Count == 0)
            {
                objEN.campos = campos;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Incidencias.Inserta_Incidencias(objEN);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            else
            {
                Actualiza_Incidencias("Personal", campos);
            }
            btnUdt2.Enabled = true;
            btnNew2.Enabled = true;
            btnAdd2.Enabled = false;
            btnCancelar2.Enabled = false;
        }
        protected void btnCancelar2_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUdt2.Enabled = true;
            btnNew2.Enabled = true;
            btnAdd2.Enabled = false;
            btnCancelar2.Enabled = false;
            Lista_Campos_Personal();
        }
        protected void btnUdt2_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string campos = "";
            for (Int32 i = 0; i <= chbcamposPersonal.Items.Count - 1; i++)
            {
                if (chbcamposPersonal.Items[i].Selected.Equals(true))
                {
                    campos += chbcamposPersonal.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            Actualiza_Incidencias("Personal", campos);
            btnUdt2.Enabled = true;
            btnNew2.Enabled = true;
            btnAdd2.Enabled = false;
            btnCancelar2.Enabled = false;


        }
        protected void btnDel2_Click(object sender, EventArgs e)
        {

        }
        void Lista_Campos_Personal()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {

                DataTable dt = new DataTable();
                dt = Log_Incidencias.Lista_Campos_Personal();
                chbcamposPersonal.DataTextField = "name";
                chbcamposPersonal.DataValueField = "name";
                chbcamposPersonal.DataSource = dt;
                chbcamposPersonal.DataBind();
                chbcamposPersonal.Dispose();
                dt.Clear();
                objEN = new Ent_Incidencias();
                objEN.Tabla = "Personal";
                dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
                if (dt.Rows.Count != 0)
                {
                    btnUdt2.Enabled = true;
                    for (Int32 i = 0; i <= chbcamposPersonal.Items.Count - 1; i++)
                    {
                        for (Int32 y = 0; y <= dt.Rows.Count - 1; y++)
                        {
                            if (chbcamposPersonal.Items[i].Value == dt.Rows[y][0].ToString())
                            {
                                chbcamposPersonal.Items[i].Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    btnUdt2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }

        }
        void Lista_Campos_Personal_Activo()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {

                DataTable dt = new DataTable();
                dt = Log_Incidencias.Lista_Campos_Personal_Activo();
                chbPersonalActivo.DataTextField = "name";
                chbPersonalActivo.DataValueField = "name";
                chbPersonalActivo.DataSource = dt;
                chbPersonalActivo.DataBind();
                chbPersonalActivo.Dispose();
                dt.Clear();
                objEN = new Ent_Incidencias();
                objEN.Tabla = "Personal_activo";
                dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
                if (dt.Rows.Count != 0)
                {
                    btnUpd3.Enabled = true;
                    for (Int32 i = 0; i <= chbPersonalActivo.Items.Count - 1; i++)
                    {
                        for (Int32 y = 0; y <= dt.Rows.Count - 1; y++)
                        {
                            if (chbPersonalActivo.Items[i].Value == dt.Rows[y][0].ToString())
                            {
                                chbPersonalActivo.Items[i].Selected = true;
                            }
                        }
                    }
                }
                else
                {
                    btnUpd3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }

        }
        void Actualiza_Incidencias(string tabla, string campos)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEN = new Ent_Incidencias();
            objEN.Tabla = tabla;
            objEN.campos = campos;
            DataTable dtRpta = new DataTable();
            dtRpta = Log_Incidencias.Actualiza_Incidencias(objEN);
            string msj_rpta;
            msj_rpta = dtRpta.Rows[0][1].ToString();
            Utils.fc_DisplayAlert(this, msj_rpta);
        }

        protected void btnNew3_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpd3.Enabled = false;
            btnNew3.Enabled = false;
            btnAdd3.Enabled = true;
            btnCancel3.Enabled = true;
            DataTable dt = new DataTable();
            dt = Log_Incidencias.Lista_Campos_Personal_Activo();
            chbPersonalActivo.DataTextField = "name";
            chbPersonalActivo.DataValueField = "name";
            chbPersonalActivo.DataSource = dt;
            chbPersonalActivo.DataBind();
            chbPersonalActivo.Dispose();
        }
        protected void btnAdd3_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEN = new Ent_Incidencias();
            DataTable dt = new DataTable();
            objEN.Tabla = "Personal_activo";
            string campos = "";

            for (Int32 i = 0; i <= chbPersonalActivo.Items.Count - 1; i++)
            {
                if (chbPersonalActivo.Items[i].Selected.Equals(true))
                {
                    campos += chbPersonalActivo.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            dt = Log_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
            if (dt.Rows.Count == 0)
            {
                objEN.campos = campos;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Incidencias.Inserta_Incidencias(objEN);
                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                Utils.fc_DisplayAlert(this, msj_rpta);

            }
            else
            {
                Actualiza_Incidencias("Personal_activo", campos);
            }
            btnUpd3.Enabled = true;
            btnNew3.Enabled = true;
            btnAdd3.Enabled = false;
            btnCancel3.Enabled = false;
        }
        protected void btnCancel3_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            btnUpd3.Enabled = true;
            btnNew3.Enabled = true;
            btnAdd3.Enabled = false;
            btnCancel3.Enabled = false;
            Lista_Campos_Personal_Activo();
        }
        protected void btnUpd3_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string campos = "";
            for (Int32 i = 0; i <= chbPersonalActivo.Items.Count - 1; i++)
            {
                if (chbPersonalActivo.Items[i].Selected.Equals(true))
                {
                    campos += chbPersonalActivo.Items[i].Value + "|";
                }
            }
            if (campos != "")
            {
                campos = campos.Remove(campos.Length - 1);
            }
            else
            {
                Utils.fc_DisplayAlert(this, "Alerta, usted no a selecionado ningun campo a controlar, Se guarda como vacio");
                campos = "";
            }
            Actualiza_Incidencias("Personal_activo", campos);
            btnUpd3.Enabled = true;
            btnNew3.Enabled = true;
            btnAdd3.Enabled = false;
            btnCancel3.Enabled = false;
        }
    }
}