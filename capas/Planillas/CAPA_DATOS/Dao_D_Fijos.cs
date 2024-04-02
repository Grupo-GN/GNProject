using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_D_Fijos
    {
        /*FPS*/
        public static DataTable Lista_D_Fijos(Ent_D_Fijos objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_D_Fijos", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_D_Fijos_Genera(Ent_D_Fijos objE)
        {
            try
            {
                //20180718
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_D_Fijos_Genera", objE.Periodo_Id, objE.Personal_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_D_Fijos_Genera", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Ids", objE.Personal_Id);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_D_Fijos_Genera_x_Concepto(Ent_D_Fijos objE)
        {
            try
            {
                //20180718
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_D_Fijos_Genera", objE.Periodo_Id, objE.Personal_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_D_Fijos_Genera_x_Concepto", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", objE.Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Id", objE.Personal_Id);
                        cmd.Parameters.AddWithValue("@vi_Concepto_Id", objE.Concepto_Id);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Actualiza_D_Fijos_Masivo(Ent_D_Fijos objE, string delimitador, Int32 cant_registros)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_D_Fijos_Masivo", objE.Periodo_Id, objE.Personal_Id_Masivo, objE.ComentarioValor_Masivo, objE.Concepto_Id_Masivo, objE.Valor_Masivo, delimitador, cant_registros, objE.Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_D_Fijos(Ent_D_Fijos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_D_Fijos", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Actualizar Datos por Persona
        public static DataTable ActualizarDatoPorPersona(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "uspActualizarDatosPorPersona", PeriodoId, PersonalId, ConceptoId, Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ActualizarDatoPorPersona_Acumulados(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor, decimal Valor_Ant)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "uspActualizarDatosPorPersona_Acumulados", PeriodoId, PersonalId, ConceptoId, Valor, Valor_Ant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //20180716
        public static DataTable ActualizarDatoPorPersona_Acumulados2(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor, decimal Valor_Ant)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspActualizarDatosPorPersona_Acumulados", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PeriodoId", PeriodoId);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                    cmd.Parameters.AddWithValue("@ConceptoId", ConceptoId);
                    cmd.Parameters.AddWithValue("@Valor", Valor);
                    cmd.Parameters.AddWithValue("@Valor_Anterior", Valor_Ant);
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


        //20180311
        public static DataTable ActualizarDatoPorPersonaV2(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspActualizarDatosPorPersona", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PeriodoId", PeriodoId);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                    cmd.Parameters.AddWithValue("@ConceptoId", ConceptoId);
                    cmd.Parameters.AddWithValue("@Valor", Valor);
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


        /*20180603*/
        public static DataTable Lista_D_Fijosv2(Ent_D_Fijos objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_D_FijosV2", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
