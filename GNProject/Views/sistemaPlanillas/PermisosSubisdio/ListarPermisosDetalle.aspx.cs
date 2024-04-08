using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.PermisosSubisdio
{
    public partial class ListarPermisosDetalle : BasePage
    {
        CAPA_DATOS.ControllerPermisoDetalle objPerDet = new CAPA_DATOS.ControllerPermisoDetalle();
        CAPA_DATOS.ControllerPermiso objPermiso = new CAPA_DATOS.ControllerPermiso();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                txtFecha_Inicio.Text = DateTime.Now.Date.ToShortDateString();
                txtFecha_Final.Text = DateTime.Now.Date.ToShortDateString();
                cargarGrilla();
                cargarPersonal();
                cargarPermisos();
                lblError.Text = "";
                TabContainer1.Tabs[1].Visible = false;
            }
            HighlightGridLine();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            limpiar(); cargarPersonal();
            enableAdd(true);
            btnAdd.Enabled = true;
            enableCancel(true);
            enableNew(false);
            TabContainer1.Tabs[1].Visible = true;
            TabContainer1.ActiveTabIndex = 1;
            cboPersonal.Enabled = true;
            cboPersonal.Focus();
        }

        private void cargarPersonal()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboPersonal.DataSource = null;
            CAPA_LOGICO.PersonalBL PersonalBL = new CAPA_LOGICO.PersonalBL();
            cboPersonal.DataTextField = "Nombres";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataSource = PersonalBL.GetPersonalActivo(Utils.fc_obtiene_Periodo_Id(this));
            cboPersonal.DataBind();
            cboPersonal.Items.Insert(0, new ListItem("--Seleccione--", "000"));
        }

        private void cargarPermisos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboPermiso.DataSource = objPermiso.Get_Permiso_MS_Listar("");
            cboPermiso.DataTextField = "descripcion";
            cboPermiso.DataValueField = "Permiso_Id";
            cboPermiso.DataBind();
            cboPermiso.Items.Insert(0, new ListItem("--Seleccione--", "000"));
        }

        private void cargarGrilla()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            DateTime fecha = DateTime.Now.Date;
            grvPermisosDetalle.DataSource = objPerDet.Get_Permisos_Detalle_MS_Listar(fecha);
            grvPermisosDetalle.DataBind();
        }

        protected void btnFindPermisos_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string PDetalle_Id = "01";
            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            string FileStrean = "DetallePermisoFind.aspx";
            string Clientscript = "AbrirModal('" + FileStrean + "?PDetalle_Id=" + PDetalle_Id + "&pTipo_Proceso=1" + "&Pperiodo=" + periodo + " ')";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
        }

        private void grabarDetallePermisos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            int tipoProceso = 1; //Grabar
            objPerDet.Get_Permisos_Detalle_MS_Mantenimiento(tipoProceso, 0, cboPersonal.SelectedValue,
                DateTime.Now.Date,
                Convert.ToDateTime(txtFecha_Inicio.Text), Convert.ToDateTime(txtFecha_Final.Text),
                int.Parse(cboPermiso.SelectedValue), txtNroDocumento.Text, int.Parse(txtdiasDiferencia.Text),
                int.Parse(txtsaldoActual.Text), int.Parse(txtsaldoAnterior.Text), Utils.fc_obtiene_Periodo_Id(this));
        }

        private void actualizarDetallePermisos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            int tipoProceso = 2; //Grabar
            objPerDet.Get_Permisos_Detalle_MS_Mantenimiento(tipoProceso, int.Parse(txtId.Text), cboPersonal.SelectedValue,
                DateTime.Now.Date,
                Convert.ToDateTime(txtFecha_Inicio.Text), Convert.ToDateTime(txtFecha_Final.Text),
                int.Parse(cboPermiso.SelectedValue), txtNroDocumento.Text, int.Parse(txtdiasDiferencia.Text),
                int.Parse(txtsaldoActual.Text), int.Parse(txtsaldoAnterior.Text), Utils.fc_obtiene_Periodo_Id(this));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grabarDetallePermisos();
            Utils.fc_DisplayAlert(this.Page, "Agregado Correctamente");
            cargarGrilla();
            enableCancel(false);
            enableAdd(false);
            enableUpdate(false);
            enableNew(true);
            TabContainer1.ActiveTabIndex = 0;
            TabContainer1.Tabs[1].Visible = false;
        }

        private void enableTab(int opcion)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            TabContainer1.ActiveTabIndex = opcion;
        }

        protected void grvPermisosDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string PDetalle_Id;
            PDetalle_Id = grvPermisosDetalle.DataKeys[e.RowIndex].Values["PDetalle_Id"].ToString();
            objPerDet.Get_Permisos_Detalle_MS_Mantenimiento(3, int.Parse(PDetalle_Id), "",
                DateTime.Now.Date, DateTime.Now.Date, DateTime.Now.Date, 0, "", 0, 0, 0, "");
            Utils.fc_DisplayAlert(this.Page, "Eliminado Correctamente");
            cargarGrilla();
        }

        protected void grvPermisosDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.ActiveTabIndex = 1;
                string PDetalle_Id;
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                PDetalle_Id = grvPermisosDetalle.DataKeys[row.RowIndex].Values["PDetalle_Id"].ToString();
                DataRow fila = objPerDet.Get_Permisos_Detalle_MS_BuscarxID(int.Parse(PDetalle_Id));
                enableTab(1);
                txtId.Text = PDetalle_Id;
                cboPersonal.SelectedValue = fila[1].ToString();
                txtFecha_Inicio.Text = fila[3].ToString();
                txtFecha_Final.Text = fila[4].ToString();
                cboPermiso.SelectedValue = fila[5].ToString();
                txtNroDocumento.Text = fila[6].ToString();
                txtdiasDiferencia.Text = fila[7].ToString();
                txtsaldoActual.Text = fila[8].ToString();
                txtsaldoAnterior.Text = fila[9].ToString();
                enableAdd(false);
                enableCancel(true);
                enableNew(false);
                enableUpdate(true);
                cboPersonal.Enabled = false;
                cboPersonal.Focus();
            }
        }

        protected void grvPermisosDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
        }


        #region barraHerramientas

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

        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            enableNew(true);
            enableAdd(false);
            enableUpdate(false);
            enableCancel(false);
            enableDelete(false);
            limpiar();
            cboPersonal.Enabled = true;
            TabContainer1.Tabs[1].Visible = false;
            TabContainer1.ActiveTabIndex = 0;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            actualizarDetallePermisos();
            Utils.fc_DisplayAlert(this.Page, "Actualizado Correctamente");
            cargarGrilla();
            enableCancel(false);
            enableAdd(false);
            enableUpdate(false);
            enableNew(true);
            TabContainer1.Tabs[1].Visible = false;
            TabContainer1.ActiveTabIndex = 0;
            cboPersonal.Enabled = true;
        }

        private void limpiar()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //cboPermiso.SelectedValue = "000";
            //cboPersonal.SelectedValue = "000";
            txtFecha_Final.Text = DateTime.Now.Date.ToShortDateString();
            txtFecha_Inicio.Text = DateTime.Now.Date.ToShortDateString();
            txtId.Text = "";
            txtNroDocumento.Text = "";
            txtdiasDiferencia.Text = "0";
            txtsaldoActual.Text = "0";
            txtsaldoAnterior.Text = "0";
        }

        protected void grvPermisosDetalle_PreRender(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cargarGrilla();
        }

        protected void ibtnFec_Inicio_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Utils.fc_DisplayAlert(this, "hola");
        }
        protected void cboPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //DateTime oldDate = new DateTime(2002, 7, 15);
            //DateTime newDate = DateTime.Now;

            TimeSpan ts = Convert.ToDateTime(txtFecha_Final.Text) - Convert.ToDateTime(txtFecha_Inicio.Text);

            // Difference in days.
            int differenceInDays = ts.Days;
            txtdiasDiferencia.Text = differenceInDays.ToString();



        }
        protected void txtdiasDiferencia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}