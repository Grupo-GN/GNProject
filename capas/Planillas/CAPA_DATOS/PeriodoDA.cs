using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class PeriodoDA
    {
        public static PeriodoDA oControllerInstance = null;
        public static PeriodoDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new PeriodoDA();
            }
            return oControllerInstance;
        }

        public DataTable GetPeriodoPorPlanilla(string Planilla_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetPeriodoPorPlanilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        return dt;
                    }
                }
            }
        }

        public DataTable GetPeriodo(string Compania_Id, string Mes_Id, string Planilla_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetPeriodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@Anio", Mes_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        return dt;
                    }
                }
            }
        }
    }
}
