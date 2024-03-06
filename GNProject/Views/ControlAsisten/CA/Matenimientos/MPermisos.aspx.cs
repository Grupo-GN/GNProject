using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusienssLogic.CustomEntity;
using System.Web.Services;


namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MPermisos : System.Web.UI.Page
    {
        //string cx = ConfigurationManager.ConnectionStrings["CF"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarPermisos();
            }
        }
        [WebMethod]
        DataTable listapermisos()
        {
            DataTable dt = new DataTable();
            dt = General.ListaPermisos();
            return dt;
        }

        private void ListarPermisos()
        {
            DataTable dt = new DataTable();
            dt = listapermisos();
            gvPermisos.DataSource = dt;
            gvPermisos.DataBind();

            for (int j = 0; j < gvPermisos.Rows.Count; j++)
            {
                CheckBox chkEstado = (CheckBox)gvPermisos.Rows[j].FindControl("chkEstado");

                String estado_gv = dt.Rows[j][4].ToString();

                if (estado_gv == "1") { chkEstado.Checked = true; }

            }
        }

        protected void gvPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string cod = gvPermisos.SelectedRow.Cells[2].Text;

            int ids = gvPermisos.SelectedRow.RowIndex;
            string cod = gvPermisos.DataKeys[ids].Value.ToString();

            //string Cod = lblConceptoId.Text.ToString();
            string vtn = "window.open('IUPermisos.aspx?cod=" + cod + "','Mantenimiento de Permisos','top=250,left=300,scrollbars=no,resizable=no,height=430,width=870,directories=no,location=no,menubar=no,status=no,toolbar=no,addressbar=no')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            string vtn = "window.open('IUPermisos.aspx','Mantenimiento de Permisos','top=250,left=300,scrollbars=no,resizable=no,height=430,width=870,directories=no,location=no,menubar=no,status=no,toolbar=no,addressbar=no')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);
        }

        protected void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < gvPermisos.Rows.Count; j++)
            {
                CheckBox chkEstado = (CheckBox)gvPermisos.Rows[j].FindControl("chkEstado");

                Label lblPermiso_Id = (Label)gvPermisos.Rows[j].FindControl("lblPermiso_Id");

                string Estado_Permiso;

                if (chkEstado.Checked == true) { Estado_Permiso = "1"; } else { Estado_Permiso = "0"; }

                General.updatepermiso(lblPermiso_Id.Text.ToString(), Estado_Permiso);
            }
        }
    }
}