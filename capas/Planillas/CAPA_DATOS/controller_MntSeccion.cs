using CAPA_ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_MntSeccion
    {
        private static controller_MntSeccion instance = null;
        public static controller_MntSeccion getInstance()
        {
            return instance == null ? instance = new controller_MntSeccion() : instance;
        }
        public DataTable Lista_Categoria_Auxiliar2(string Descripcion,string Categoria_Auxiliar_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Categoria_Auxiliar2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Descripcion);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
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
        public DataTable Inserta_Categoria_Auxiliar2(string Descripcion, string Categoria_Auxiliar_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spi_Categoria_Auxiliar2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
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
        public DataTable Actualiza_Categoria_Auxiliar2(string Categoria_Auxiliar2_Id, string Descripcion, string Categoria_Auxiliar_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spu_Categoria_Auxiliar2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
                    cmd.Parameters.AddWithValue("@vi_Descripcion", Descripcion);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
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
        public DataTable Elimina_Categoria_Auxiliar2(string Categoria_Auxiliar2_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spd_Categoria_Auxiliar2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
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


        public DataTable Lista_Categoria_Auxiliar(string Categoria_Auxiliar_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Categoria_Auxiliar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
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
