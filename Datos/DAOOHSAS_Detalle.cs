using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Entidad;
using System.Data.SqlClient;
using System.Data;

namespace Capas.Portal.Datos
{
    public class DAOOHSAS_Detalle : ClsConexion
    {
        public List<OHSAS_Detalle> GetOHSASAll_Detalle(Int32 id_ohsas, Int32 id_ohsas_detalle)
        {
            List<OHSAS_Detalle> lista = new List<OHSAS_Detalle>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_I_ListaOHSAS_Detalle";
            cmd.Parameters.AddWithValue("@id_ohsas", id_ohsas);
            cmd.Parameters.AddWithValue("@id_ohsas_detalle", id_ohsas_detalle);
            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                OHSAS_Detalle ent;
                int indice;
                while (reader.Read())
                {
                    ent = new OHSAS_Detalle();
                    indice = reader.GetOrdinal("id_ohsas_detalle");
                    ent.id_ohsas_detalle = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("no_titulo");
                    ent.no_titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("tx_descripcion");
                    ent.tx_descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_archivo");
                    ent.no_archivo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("fe_registro");
                    ent.fe_registro = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    ent.sfe_registro = reader.IsDBNull(indice) ? String.Empty : reader.GetDateTime(indice).ToShortDateString();
                    indice = reader.GetOrdinal("co_usuario");
                    ent.co_usuario = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("id_ohsas");
                    ent.id_ohsas = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("no_ohsas");
                    ent.no_ohsas = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("no_area");
                    ent.no_area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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

        public void GuardarOHSASDetalle(OHSAS_Detalle oOHSAS_Detalle, out int retorno, out String msg_retorno)
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
                    cmd.CommandText = "usp_I_GuardarOHSAS_Detalle";
                    cmd.Connection = Conex;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_ohsas_detalle", oOHSAS_Detalle.id_ohsas_detalle);
                    cmd.Parameters.AddWithValue("@id_ohsas", oOHSAS_Detalle.id_ohsas);
                    cmd.Parameters.AddWithValue("@no_titulo", oOHSAS_Detalle.no_titulo);
                    cmd.Parameters.AddWithValue("@tx_descripcion", oOHSAS_Detalle.tx_descripcion);
                    cmd.Parameters.AddWithValue("@no_archivo", oOHSAS_Detalle.no_archivo);
                    cmd.Parameters.AddWithValue("@sfe_registro", oOHSAS_Detalle.sfe_registro);
                    cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", oOHSAS_Detalle.Categoria_Auxiliar_Id);
                    cmd.Parameters.AddWithValue("@co_usuario", oOHSAS_Detalle.co_usuario);
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
        public void GuardarOHSASDetalle(Int32 id_ohsas_detalle, String no_archivo)
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
                    cmd.CommandText = "update I_OHSAS_detalle set no_archivo = '" + no_archivo + "' where id_ohsas_detalle = " + id_ohsas_detalle.ToString();
                    cmd.Connection = Conex;
                    cmd.CommandType = CommandType.Text;
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
        public void EliminarOHSASDetalle(Int32 id_ohsas_detalle, out int retorno, out String msg_retorno)
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
                    cmd.CommandText = "usp_I_EliminarOHSAS_Detalle";
                    cmd.Connection = Conex;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_ohsas_detalle", id_ohsas_detalle);
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
    }
}
