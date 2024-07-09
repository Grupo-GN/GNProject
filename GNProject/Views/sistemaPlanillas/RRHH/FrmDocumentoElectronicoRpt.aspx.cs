using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.RRHH
{
    public partial class FrmDocumentoElectronicoRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int rpt = 0;
            if (!Page.IsPostBack)
            {
                string codigo = "";
                DateTime fecha = DateTime.UtcNow;

                codigo = Request.QueryString["codenv"].ToString();
                rpt = Get_Respuesta(codigo, fecha);
                if (rpt == 0) { lblMensaje.Text = "No se pudo procesar su solicitud."; }
                else { lblMensaje.Text = "Se confirmó la recepción del documento enviado, gracias."; }
            }
        }
        int Get_Respuesta(string codigo, DateTime fecha)
        {
            int rpt = 0;
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("update tbl_envio_doc_electronicos set fe_recepcion=getdate() where id_envio=@codigo", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@codigo", codigo.ToString());
                    cmd.Parameters.AddWithValue("@fecha", fecha.ToShortDateString());
                    cn.Open();
                    rpt = cmd.ExecuteNonQuery();
                }
            }
            return rpt;
        }
    }
}