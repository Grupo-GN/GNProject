using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Reportes
{
    public partial class frmProvisiones : System.Web.UI.Page
    {
        ReportDocument rptSource;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Func<string, string> GetDescripcionReporte = (a) => {
                    string retorno = "";
                    if (a.Equals("0031"))
                        retorno = "Vacaciones";
                    else if (a.Equals("0030"))
                        retorno = "Gratificacion";
                    else if (a.Equals("0029"))
                        retorno = "Cts";
                    return retorno;
                };
                Func<string, string> GetNameReporte = (a) =>
                {
                    string retorno = "";
                    if (a.Equals("0031"))
                        retorno = "Provision_Vac.rpt";
                    else if (a.Equals("0030"))
                        retorno = "Provision_Grat.rpt";
                    else if (a.Equals("0029"))
                        retorno = "Provision_CTS.rpt";
                    return retorno;
                };


                string tipoReporte = Request.QueryString["Reporte_Id"].ToString();
                string periodo = Request.QueryString["Periodo_Id"].ToString();
                string personal = Request.QueryString["Personal_Id"].ToString();
                //string tipoReporte = "0031";
                //string periodo = "0140";

                Get_Provisiones(tipoReporte, personal, periodo, "01", "%     "); //Ejecutando el Procedimiento

                ParameterFields p1 = new ParameterFields();
                ParameterField p2 = new ParameterField();
                ParameterDiscreteValue p3 = new ParameterDiscreteValue();
                rptSource = new ReportDocument();


                rptSource.Load(Server.MapPath(GetNameReporte(tipoReporte)));
                //rptSource.SetDatabaseLogon("sa", "123456", "GNRS-SRV01", "SISGNRS_WEB_LG");

                string titulo = ("Provicion " + GetDescripcionReporte(tipoReporte) + " - " + Get_DescripcionPeriodo((periodo))).ToUpper();

                p2.ParameterFieldName = "titulo";
                p3.Value = titulo;
                p2.CurrentValues.Add(p3);
                p1.Add(p2);
                rpt.ParameterFieldInfo = p1;

                rptSource.SetDatabaseLogon("", "", ".", "DB_9CC54A_SISGNRSWEBLG");
                rpt.DisplayGroupTree = false;

                rpt.ReportSource = rptSource;
                rpt.Visible = true;
                //  rpt.Dispose();
            }
        }
        protected void rpt_Unload(object sender, EventArgs e)
        {
            //rptSource.Close();
            //rptSource.Dispose();
        }

        public void Get_Provisiones(string reporte, string usuario, string periodo, string proceso, string personal)
        {
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_LISTAR_REPORTE_MS", cn))
                {
                    cn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cReporte", reporte);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@cPeriodo", periodo);
                    cmd.Parameters.AddWithValue("@cProceso", proceso);
                    cmd.Parameters.AddWithValue("@Personal ", personal);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string Get_DescripcionPeriodo(string periodo)
        {
            string sql = "select Descripcion from Periodo where Periodo_Id =" + periodo;
            using (SqlConnection cn = new SqlConnection(CAPA_DATOS.Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);
                        if (tabla.Rows.Count > 0)
                            return tabla.Rows[0][0].ToString();
                        return "";
                    }
                }
            }
        }
    }
}