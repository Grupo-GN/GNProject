using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Consultas;

namespace CtrlDocumentos.DA.Consultas
{
    public class ReportesDA
    {
        SqlCommand SqlCommand;

        #region "Reporte de Seguimiendo de Documentos"
        public List<RptSegDocumentosBE> getReporte_SegDocumentos(RptSegDocumentosBE oRptSegDocumentosBE)
        {
            List<RptSegDocumentosBE> oListaReporte = new List<RptSegDocumentosBE>();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_rep_seg_documento";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento", oRptSegDocumentosBE.id_documento);
            SqlCommand.Parameters.AddWithValue("@vi_co_grupo_doc", oRptSegDocumentosBE.co_grupo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_co_sub_grupo_doc", oRptSegDocumentosBE.co_sub_grupo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oRptSegDocumentosBE.id_plantilla_doc);
            SqlCommand.Parameters.AddWithValue("@vi_no_documento", oRptSegDocumentosBE.no_documento);
            SqlCommand.Parameters.AddWithValue("@vi_co_tipo_asignacion", oRptSegDocumentosBE.co_tipo_asignacion);
            SqlCommand.Parameters.AddWithValue("@vi_ids_persona_empresa", oRptSegDocumentosBE.ids_persona_empresa);
            SqlCommand.Parameters.AddWithValue("@vi_sfe_vencimiento_desde", oRptSegDocumentosBE.sfe_vencimiento_desde);
            SqlCommand.Parameters.AddWithValue("@vi_sfe_vencimiento_hasta", oRptSegDocumentosBE.sfe_vencimiento_hasta);
            SqlCommand.Parameters.AddWithValue("@vi_cods_estado", oRptSegDocumentosBE.cods_estado);
            SqlCommand.Parameters.AddWithValue("@vi_cods_tipo_doc", oRptSegDocumentosBE.co_tipo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_id_area", oRptSegDocumentosBE.id_area);
            SqlCommand.Parameters.AddWithValue("@vi_id_seccion", oRptSegDocumentosBE.id_seccion);
            SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oRptSegDocumentosBE.id_usuario);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    RptSegDocumentosBE oBE = new RptSegDocumentosBE();
                    indice = reader.GetOrdinal("id_documento");
                    oBE.id_documento = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_plantilla_doc");
                    oBE.id_plantilla_doc = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_plantilla_doc");
                    oBE.no_plantilla_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_grupo_doc");
                    oBE.co_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_grupo_doc");
                    oBE.no_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_sub_grupo_doc");
                    oBE.co_sub_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_sub_grupo_doc");
                    oBE.no_sub_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_documento");
                    oBE.no_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_asignacion");
                    oBE.co_tipo_asignacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_tipo_asignacion");
                    oBE.no_tipo_asignacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_persona");
                    oBE.id_persona = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_persona");
                    oBE.no_persona = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_empresa");
                    oBE.id_empresa = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_empresa");
                    oBE.no_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_persona_empresa");
                    oBE.no_persona_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fe_inicio");
                    oBE.fe_inicio = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);

                    indice = reader.GetOrdinal("fe_vencimiento");
                    oBE.fe_vencimiento = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    oBE.sfe_vencimiento = reader.IsDBNull(indice) ? "" : oBE.fe_vencimiento.ToShortDateString();

                    indice = reader.GetOrdinal("qt_dias_para_vencimiento");
                    oBE.qt_dias_para_vencimiento = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("co_estado");
                    oBE.co_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oListaReporte.Add(oBE);
                }
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return oListaReporte;
        }
        #endregion

    }
}
