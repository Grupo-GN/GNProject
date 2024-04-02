using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class Reporte_DetalleDA
    {
        public static Reporte_DetalleDA oControllerInstance = null;
        public static Reporte_DetalleDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new Reporte_DetalleDA();
            }
            return oControllerInstance;
        }

        public DataTable GetReporteDetalle(int ReporteID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetReporte_Detalles", cn))
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

        public Int32 InsertReporteDetalle(Reporte_DetalleBE reporte_DetalleBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInsertReporte_Detalle", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@ReporteID", reporte_DetalleBE.ReporteID);
                    cmd.Parameters.AddWithValue("@Columna", reporte_DetalleBE.Columna);
                    cmd.Parameters.AddWithValue("@Alias", reporte_DetalleBE.Alias);
                    cmd.Parameters.AddWithValue("@Tipo", reporte_DetalleBE.Tipo);
                    cmd.Parameters.AddWithValue("@Orden", reporte_DetalleBE.Orden);

                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public Int32 UpdateReporteDetalle(Reporte_DetalleBE reporte_DetalleBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSUpdateReporte_Detalle", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Reporte_DetalleID", reporte_DetalleBE.Reporte_DetalleID);
                    cmd.Parameters.AddWithValue("@Columna", reporte_DetalleBE.Columna);
                    cmd.Parameters.AddWithValue("@Alias", reporte_DetalleBE.Alias);
                    cmd.Parameters.AddWithValue("@Tipo", reporte_DetalleBE.Tipo);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public Int32 UpDownReporteDetalle(int Reporte_DetalleID, int Valor)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSUpDownReporte_Detalle", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Reporte_DetalleID", Reporte_DetalleID);
                    cmd.Parameters.AddWithValue("@Valor", Valor);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public Int32 DeleteReporteDetalle(int Reporte_DetalleID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSDeleteReporte_Detalle", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Reporte_DetalleID", Reporte_DetalleID);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }
    }
}
