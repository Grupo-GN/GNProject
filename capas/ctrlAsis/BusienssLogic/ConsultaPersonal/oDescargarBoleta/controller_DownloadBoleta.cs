using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace BusienssLogic.ConsultaPersonal.oDescargarBoleta
{
    public class controller_DownloadBoleta
    {
        private static controller_DownloadBoleta Instance = null;
        public static controller_DownloadBoleta Get_Instance() {
            return Instance == null ? Instance = new controller_DownloadBoleta() : Instance;
        }

        public DataTable Get_Boleta_By_Personal(string Personal_Id,string Periodo_Id,string Proceso) {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion())) {
                using (SqlCommand cmd = new SqlCommand("Reporte_Boleta", cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal",Personal_Id);
                    cmd.Parameters.AddWithValue("@cPeriodo", Periodo_Id);
                    cmd.Parameters.AddWithValue("@cProceso", Proceso);
                    cn.Open();
                    DataTable dtRetur = new DataTable();
                    SqlDataAdapter dr=new SqlDataAdapter(cmd);
                    dr.Fill(dtRetur);
                    return dtRetur;                
                }
            
            }
        }

        public DataTable Get_Boleta_By_Persona_Masivo(string Personal_Id, string Periodo_Id, string Proceso,int cantidad)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_Reporte_Boleta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id_Masivo", Personal_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_Proceso_Id", Proceso);
                    cmd.Parameters.AddWithValue("@vi_CantPersonal", cantidad);
                    cn.Open();
                    DataTable dtRetur = new DataTable();
                    SqlDataAdapter dr = new SqlDataAdapter(cmd);
                    dr.Fill(dtRetur);
                    return dtRetur;
                }

            }
        }
    }
}
