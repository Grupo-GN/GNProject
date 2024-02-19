using GNProject.Acceso;
using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GNProject.Entity.DA
{
    public class PerfilDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public PerfilBEList Get_ListaPerfiles(int id_perfil, string no_perfil, string fl_activo)
        {
            PerfilBEList oPerfilBEList = new PerfilBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "gn_sps_perfiles";

            SqlPara = new SqlParameter("@vi_id_perfil", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = id_perfil;
            cmd.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vi_no_perfil", SqlDbType.VarChar);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = no_perfil;
            cmd.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vi_fl_activo", SqlDbType.Char);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = fl_activo;
            cmd.Parameters.Add(SqlPara);


            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PerfilBE oBE = new PerfilBE();
                    indice = reader.GetOrdinal("id_perfil");
                    oBE.id_perfil = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_perfil");
                    oBE.no_perfil = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("tx_descripcion");
                    oBE.tx_descripcion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("usuarios");
                    oBE.nu_usuarios = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("ids_plantilla_doc");
                    oBE.ids_plantilla_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_interno");
                    oBE.fl_interno = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_proveedor");
                    oBE.fl_proveedor = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oPerfilBEList.Add(oBE);

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
            return oPerfilBEList;
        }
        static string ConvertEntityConnectionStringToSqlConnection(string entityConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            string providerConnectionString = entityBuilder.ProviderConnectionString;

            builder.ConnectionString = providerConnectionString;

            return builder.ConnectionString;
        }

        public void GuardarPerfil(PerfilBE oPerfilBE, out int retorno, out String msg_retorno)
        {

            SqlTransaction SqlTran = null;
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);


            using (SqlConnection Conex = new SqlConnection(sqlConnectionString))
            {
                try
                {
                    /* Abrir la Conexion*/
                    if (Conex.State != ConnectionState.Open)
                        Conex.Open();

                    /* Comenzamos la Transaccion*/
                    SqlTran = Conex.BeginTransaction();

                    /*Propiedades del SqlCommand*/
                    SqlCommand = new SqlCommand();
                    SqlCommand.CommandText = "gn_spi_perfil";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_perfil", oPerfilBE.id_perfil);
                    SqlCommand.Parameters.AddWithValue("@vi_no_perfil", oPerfilBE.no_perfil);
                    SqlCommand.Parameters.AddWithValue("@vi_tx_descripcion", oPerfilBE.tx_descripcion);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPerfilBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_cont_ids_menu", oPerfilBE.cont_ids_menu);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_menu", oPerfilBE.ids_menu);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_plantilla_doc", oPerfilBE.ids_plantilla_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPerfilBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPerfilBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPerfilBE.no_usuario_red);

                    SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
                    SqlPara.Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.Add(SqlPara);

                    SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
                    SqlPara.Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.Add(SqlPara);

                    /* Asignamos Transaccion al Command */
                    SqlCommand.Transaction = SqlTran;
                    /* Ejecutamos  y recuperamos valor de salida*/
                    //SqlCommand.ExecuteNonQuery();
                    SqlCommand.ExecuteScalar();

                    /* Recuperando la Variables de salida*/
                    retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();

                    /* Si todo salio bien hacemos commit los cambios */
                    if (SqlTran.Connection != null) SqlTran.Commit();
                }
                catch (Exception ex)
                {
                    if (SqlTran != null)
                    {
                        // Si algo fallo deshacemos todo
                        SqlTran.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    // Cerramos la Conexion
                    if (Conex.State != ConnectionState.Closed)
                        Conex.Close();
                    // Destruimos la conexion
                    Conex.Dispose();
                }
            }
        }

        public void EliminarPerfil(PerfilBE oPerfilBE, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);

            using (SqlConnection Conex = new SqlConnection(sqlConnectionString))
            {
                try
                {
                    /* Abrir la Conexion*/
                    if (Conex.State != ConnectionState.Open)
                        Conex.Open();

                    /* Comenzamos la Transaccion*/
                    SqlTran = Conex.BeginTransaction();

                    /*Propiedades del SqlCommand*/
                    SqlCommand = new SqlCommand();
                    SqlCommand.CommandText = "gn_spd_perfil";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_perfil", oPerfilBE.id_perfil);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPerfilBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPerfilBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPerfilBE.no_usuario_red);

                    SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
                    SqlPara.Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.Add(SqlPara);

                    SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
                    SqlPara.Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.Add(SqlPara);

                    /* Asignamos Transaccion al Command */
                    SqlCommand.Transaction = SqlTran;
                    /* Ejecutamos  y recuperamos valor de salida*/
                    //SqlCommand.ExecuteNonQuery();
                    SqlCommand.ExecuteScalar();

                    /* Recuperando la Variables de salida*/
                    retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();

                    /* Si todo salio bien hacemos commit los cambios */
                    if (SqlTran.Connection != null) SqlTran.Commit();
                }
                catch (Exception ex)
                {
                    if (SqlTran != null)
                    {
                        // Si algo fallo deshacemos todo
                        SqlTran.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    // Cerramos la Conexion
                    if (Conex.State != ConnectionState.Closed)
                        Conex.Close();
                    // Destruimos la conexion
                    Conex.Dispose();
                }
            }
        }
    }
}