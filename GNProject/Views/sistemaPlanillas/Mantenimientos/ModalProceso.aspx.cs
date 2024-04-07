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
    public partial class ModalProceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carga_Estados();
                string pTipoProceso = Request.QueryString["pTipo_Proceso"].ToString();
                if (pTipoProceso == "2")
                {
                    string Proceso_Id = Request.QueryString["Proceso_Id"].ToString();
                    buscarProceso(Proceso_Id);
                }
            }
        }

        private void buscarProceso(string ProcesoId)
        {
            txtProcesoId.Text = ProcesoId.ToString();
            DataRow fila = Log_Procesos.Buscar_Procesos_ById(ProcesoId).Rows[0];
            txtDescripcion.Text = fila[1].ToString();
            cboEstado.SelectedValue = fila[2].ToString();
        }

        private void Carga_Estados()
        {
            cboEstado.DataSource = Log_General.Lista_Estados();
            cboEstado.DataTextField = "Descripcion";
            cboEstado.DataValueField = "Codigo";
            cboEstado.DataBind();
        }

        private void limpia()
        {
            txtDescripcion.Text = "";
        }

        public void CerrarVenta()
        {
            string CierraVentana = "<script>CerrarConEvento();</script>";
            if (!this.IsStartupScriptRegistered("WClose"))
            {
                this.RegisterStartupScript("WClose", CierraVentana);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            string pTipoProceso = Request.QueryString["pTipo_Proceso"].ToString();

            if (pTipoProceso == "1")
            {
                Ent_Procesos objEProcesos = new Ent_Procesos();
                objEProcesos.Proceso = txtDescripcion.Text.ToUpper();
                objEProcesos.Estado_Id = cboEstado.SelectedValue;
                DataTable dtRpta = new DataTable();
                dtRpta = Log_Procesos.Inserta_Procesos(objEProcesos);
                Utils.fc_DisplayAlert(this.Page, "Insertado Correctamente");
                CerrarVenta();
            }
            else if (pTipoProceso == "2")
            {
                string Proceso_Id = Request.QueryString["Proceso_Id"].ToString();
                Ent_Procesos objEProcesos = new Ent_Procesos();
                objEProcesos.Proceso_Id = Proceso_Id;
                objEProcesos.Proceso = txtDescripcion.Text;
                objEProcesos.Estado_Id = cboEstado.SelectedValue;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Procesos.Actualiza_Procesos(objEProcesos);
                Utils.fc_DisplayAlert(this.Page, "Actualizado Correctamente");
                CerrarVenta();
            }

        }
    }
}