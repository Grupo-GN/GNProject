using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class CompaniaDA
    {
        public static CompaniaDA oControllerInstance = null;
        public static CompaniaDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new CompaniaDA();
            }
            return oControllerInstance;
        }

        public DataTable GetCompania(string Compania_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetCompania", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        cn.Dispose();
                        return dt;
                    }
                }
            }
        }

    }
}
