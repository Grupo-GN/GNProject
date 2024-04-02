using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class controller_ConcarReport
    {
        private static controller_ConcarReport instace = null;
        public static controller_ConcarReport get_Instance() {
            return instace == null ? instace = new controller_ConcarReport() : instace;
        }

        public DataTable Get_ExportacionPlanilas_General_Ms(string periodo_id, string proceso_id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_reporte_asientocontable_concarsql_det", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@v_Periodo_Id", periodo_id);
                    cmd.Parameters.AddWithValue("@v_Proceso_Id", proceso_id);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        cn.Close();
                        cn.Dispose();
                        return tabla;
                    }
                }

            }

        }
    }
}
