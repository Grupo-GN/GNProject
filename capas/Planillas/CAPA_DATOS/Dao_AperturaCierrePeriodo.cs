using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;
using System.Data.SqlClient;
using System.Data;
namespace CAPA_DATOS
{
    public static class Dao_AperturaCierrePeriodo
    {
        /*FPS*/
        public static DataTable btn_name_AperturaPeriodo(string Compania_Id, string Planilla_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_btn_name_AperturaPeriodo", Compania_Id, Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable btn_name_CierrePeriodo(string Compania_Id, string Planilla_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_btn_name_CierrePeriodo", Compania_Id, Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Apertura_Periodo(Ent_Periodo objE)
        {
            string caeaqui = "";
            try
            {
                string COMPANIA = "";
                string Mes = "";
                string Planilla = "";
                string Semana = "";
                string EJERCICIO = "";
                string PERIODO_ANTERIOR = "";
                
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART1", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART1";
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read()) {
                            COMPANIA = dr.GetValue(0).ToString();
                            Mes = dr.GetValue(1).ToString();
                            Planilla = dr.GetValue(2).ToString();
                            Semana = dr.GetValue(3).ToString();
                            EJERCICIO = dr.GetValue(4).ToString();
                            PERIODO_ANTERIOR = dr.GetValue(5).ToString(); 
                        }
                        
                    }                
                }
                if (PERIODO_ANTERIOR == "") {
                    return "false#Datos no encontrados.";
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@COMPANIA", COMPANIA);
                        cmd.Parameters.AddWithValue("@Mes", Mes);
                        cmd.Parameters.AddWithValue("@Planilla", Planilla);
                        cmd.Parameters.AddWithValue("@Semana", Semana);
                        cmd.Parameters.AddWithValue("@EJERCICIO", EJERCICIO);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART2";
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART3", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART3";
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART4", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@COMPANIA", COMPANIA);
                        cmd.Parameters.AddWithValue("@Planilla", Planilla);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART4";
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART5", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@COMPANIA", COMPANIA);
                        cmd.Parameters.AddWithValue("@Planilla", Planilla);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART5";
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART6", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@COMPANIA", COMPANIA);
                        cmd.Parameters.AddWithValue("@Mes", Mes);
                        cmd.Parameters.AddWithValue("@Planilla", Planilla);
                        cmd.Parameters.AddWithValue("@Semana", Semana);
                        cmd.Parameters.AddWithValue("@EJERCICIO", EJERCICIO);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART6";
                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_APERTURAPERIODO_PART7", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PERIODO", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@COMPANIA", COMPANIA);
                        cmd.Parameters.AddWithValue("@Mes", Mes);
                        cmd.Parameters.AddWithValue("@Planilla", Planilla);
                        cmd.Parameters.AddWithValue("@Semana", Semana);
                        cmd.Parameters.AddWithValue("@EJERCICIO", EJERCICIO);
                        cmd.Parameters.AddWithValue("@PERIODO_ANTERIOR", PERIODO_ANTERIOR);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        caeaqui = "SP_APERTURAPERIODO_PART7";
                        cmd.ExecuteNonQuery();
                    }
                }
                return "true#";
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Apertura_Periodo", objE.Periodo_Id, "" /*Personal_Id*/);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return "false# " + caeaqui + ex.InnerException.Message;
                }
                else {
                    return "false# " + caeaqui + ex.Message;
                }
                
            }
        }

        public static DataTable Cierre_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Cierre_Periodo", objE.Periodo_Id, "" /*Personal_Id*/);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Limpiar_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Limpiar_Periodo", objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public static int ActualizarAcumulados(string Periodo_Id)
        //{
        //    try
        //    {
        //        return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "GNRS_PROC_ACTUALIZA_ACUMULADOS", Periodo_Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        public static int ActualizarAcumulados(string Periodo_Id)
        {
            try
            {
                //return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "GNRS_PROC_ACTUALIZA_ACUMULADOS", Periodo_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("GNRS_PROC_ACTUALIZA_ACUMULADOS", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //20190228
        public static string GenerarConfiguracionAsientos(string PlanillaId,string EjercicioId)
        {
            string resultado = "false#";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("uspGenerarConfiguracionAsientos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vi_Planilla_Id", PlanillaId);
                        cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", EjercicioId);
                        cmd.CommandTimeout = 0;
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                        if (irows > 0)
                        {
                            resultado = "true#Configuración realizada satisfactoriamente.";
                        }
                        else
                        {
                            resultado = "true#Error: La configuración no se ha realizado, intente nuevamente o contacte con soporte.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "false#Error: " + ex.Message+ "\n Contacte con soporte.";
            }
            return resultado;
        }
    }
}
