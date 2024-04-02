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
    public static class Dao_D_Variables
    {
        /*FPS*/
        public static DataTable Lista_D_Variables(Ent_D_Variables objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_D_Variables", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_D_Variables_Genera(Ent_D_Variables objE)
        {
            try
            {
                //20180718
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_D_Variables_Genera", objE.Periodo_Id, objE.Personal_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_D_Variables_Genera", cn))
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
        //20200226
        public static DataTable Inserta_D_Variables_Genera_x_Concepto(Ent_D_Variables objE)
        {
            try
            {
                //20180718
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_D_Variables_Genera", objE.Periodo_Id, objE.Personal_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_D_Variables_Genera_x_Concepto", cn))
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
        public static DataTable Actualiza_D_Variables_Masivo(Ent_D_Variables objE, string delimitador, Int32 cant_registros)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_D_Variables_Masivo", objE.Periodo_Id, objE.Personal_Id_Masivo, objE.ComentarioValor_Masivo, objE.Concepto_Id_Masivo, objE.Valor_Masivo, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_D_Variables(Ent_D_Variables objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_D_Variables", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*20180603*/
        public static DataTable Lista_D_Variablesv2(Ent_D_Variables objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_D_VariablesV2", objE.Periodo_Id, objE.Personal_Id, objE.Concepto_Id, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
