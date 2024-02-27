using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Entidad;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Capas.Portal.Datos
{
    public class DAOCorreo : ClsConexion
    {
        public List<Correo> GetCorreosAll(Int32 id_correo)
        {
            List<Correo> lista = new List<Correo>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_I_ListarCorreos";
            cmd.Parameters.AddWithValue("@id_correo", id_correo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Correo ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Correo();
                    indice = reader.GetOrdinal("id_correo");
                    ent.id_correo = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("co_correo");
                    ent.co_correo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_asunto");
                    ent.no_asunto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_para");
                    ent.no_para = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_cc");
                    ent.no_cc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_bcc");
                    ent.no_bcc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("tx_body");
                    ent.tx_body = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_images");
                    ent.no_images = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("co_usuario");
                    ent.co_usuario = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

                    lista.Add(ent);
                }
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lista;
        }
        public void GuardarCorreo(Correo oCorreo, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(Conexion()))
            {
                try
                {
                    if (Conex.State != ConnectionState.Open)
                        Conex.Open();
                    SqlTran = Conex.BeginTransaction();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "usp_I_GuardarCorreo";
                    cmd.Connection = Conex;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_correo", oCorreo.id_correo);
                    cmd.Parameters.AddWithValue("@no_asunto", oCorreo.no_asunto);
                    cmd.Parameters.AddWithValue("@no_para", oCorreo.no_para);
                    cmd.Parameters.AddWithValue("@no_cc", oCorreo.no_cc);
                    cmd.Parameters.AddWithValue("@no_bcc", oCorreo.no_bcc);
                    cmd.Parameters.AddWithValue("@tx_body", oCorreo.tx_body);
                    cmd.Parameters.AddWithValue("@no_images", oCorreo.no_images);
                    cmd.Parameters.AddWithValue("@co_usuario", oCorreo.co_usuario);
                    cmd.Parameters.Add("@vo_retorno_msg", SqlDbType.VarChar, 8000).Direction = ParameterDirection.Output;

                    cmd.Transaction = SqlTran;
                    retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    msg_retorno = cmd.Parameters["@vo_retorno_msg"].Value.ToString();
                    SqlTran.Commit();
                }
                catch (Exception ex)
                {
                    if (SqlTran != null) SqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    if (Conex.State != ConnectionState.Closed) Conex.Close();
                    Conex.Dispose();
                }
            }
        }
        public void ActualizaImagenCorreo(Int32 id_correo, String opc, String no_imagen)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(Conexion()))
            {
                try
                {
                    if (Conex.State != ConnectionState.Open)
                        Conex.Open();
                    SqlTran = Conex.BeginTransaction();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "usp_I_GuardarCorreo_Imagen";
                    cmd.Connection = Conex;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_correo", id_correo);
                    cmd.Parameters.AddWithValue("@opc", opc);
                    cmd.Parameters.AddWithValue("@no_imagen", no_imagen);
                    cmd.Transaction = SqlTran;
                    cmd.ExecuteNonQuery();                    
                    SqlTran.Commit();
                }
                catch (Exception ex)
                {
                    if (SqlTran != null) SqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    if (Conex.State != ConnectionState.Closed) Conex.Close();
                    Conex.Dispose();
                }
            }
        }

    }
}
