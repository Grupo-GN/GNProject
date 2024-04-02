using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class ReporteDA
    {

        public static ReporteDA oControllerInstance = null;
        public static ReporteDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new ReporteDA();
            }
            return oControllerInstance;
        }

        public Int32 InsertReporte(ReporteBE reporteBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInsertReporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Descripcion", reporteBE.Descripcion);
                    cmd.Parameters.AddWithValue("@Titulo", reporteBE.Titulo);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public Int32 UpdateReporte(ReporteBE reporteBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSUpdateReporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@ReporteID", reporteBE.ReporteID);
                    cmd.Parameters.AddWithValue("@Descripcion", reporteBE.Descripcion);
                    cmd.Parameters.AddWithValue("@Titulo", reporteBE.Titulo);

                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public DataTable GetReportes()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetReportes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
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

        public DataTable GetReporte(int ReporteID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetReporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ReporteID", ReporteID);
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

        public DataTable GenerateReporte(int ReporteID, string Periodo_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGenerateReporte", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@ReporteID", ReporteID);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
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

        public Int32 UpdateReporteOrden(ReporteBE reporteBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSUpdateReporteOrden", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@ReporteID", reporteBE.ReporteID);
                    cmd.Parameters.AddWithValue("@Orden", reporteBE.Orden);

                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }
    }
}
