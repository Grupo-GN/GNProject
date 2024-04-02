using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_Categoria_Auxiliar2
    {
        /*FPS*/
        public static DataTable Lista_Categoria_Auxiliar2(Ent_Categoria_Auxiliar2 objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Categoria_Auxiliar2", objE.Categoria_Auxiliar2_Id, objE.Categoria_Auxiliar_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Categoria_Auxiliar2(Ent_Categoria_Auxiliar2 objE)
        {
            try
            {
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Categoria_Auxiliar2", objE.Descripcion, objE.Categoria_Auxiliar_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_Categoria_Auxiliar2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@vi_Descripcion", objE.Descripcion);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", objE.Categoria_Auxiliar_Id);
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

        public static DataTable Actualiza_Categoria_Auxiliar2(Ent_Categoria_Auxiliar2 objE)
        {
            try
            {
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Categoria_Auxiliar2", objE.Categoria_Auxiliar2_Id, objE.Descripcion, objE.Categoria_Auxiliar_Id);
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spu_Categoria_Auxiliar2", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", objE.Categoria_Auxiliar2_Id);
                        cmd.Parameters.AddWithValue("@vi_Descripcion", objE.Descripcion);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", objE.Categoria_Auxiliar_Id);
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

        public static DataTable Elimina_Categoria_Auxiliar2(Ent_Categoria_Auxiliar2 objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Categoria_Auxiliar2", objE.Categoria_Auxiliar2_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
