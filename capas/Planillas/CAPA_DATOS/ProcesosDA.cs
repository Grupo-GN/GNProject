using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CAPA_DATOS
{
    public class ProcesosDA
    {
        public static ProcesosDA oControllerInstance = null;
        public static ProcesosDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new ProcesosDA();
            }
            return oControllerInstance;
        }

        public DataTable GetProcesos()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetProcesos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}
