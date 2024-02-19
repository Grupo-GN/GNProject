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
    public class UsuarioDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public UsuarioBE Get_UsuarioxLogin(String login, out int retorno, out String retorno_msg)
        {
            UsuarioBE oUsuarioBE = new UsuarioBE();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "cdoc_sps_GetUsuarioxLogin";

            SqlPara = new SqlParameter("@vi_login", SqlDbType.VarChar, 25);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = login;
            cmd.Parameters.Add(SqlPara);

            SqlParameter param;
            param = new SqlParameter("@vo_retorno", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            SqlParameter param2;
            param2 = new SqlParameter("@vo_retorno_msg", SqlDbType.VarChar, 8000);
            param2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param2);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    indice = reader.GetOrdinal("id_usuario");
                    oUsuarioBE.id_usuario = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("nu_dni");
                    oUsuarioBE.nu_dni = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_perfil");
                    oUsuarioBE.id_perfil = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_perfil");
                    oUsuarioBE.no_perfil = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("login");
                    oUsuarioBE.login = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("password");
                    oUsuarioBE.password = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nombrecompleto");
                    oUsuarioBE.nombrecompleto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                }
                reader.Close();

                /* Recuperando la Variables de salida*/
                retorno = Int32.Parse(cmd.Parameters["@vo_retorno"].Value.ToString());
                retorno_msg = cmd.Parameters["@vo_retorno_msg"].Value.ToString();
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
            return oUsuarioBE;
        }
        static string ConvertEntityConnectionStringToSqlConnection(string entityConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            string providerConnectionString = entityBuilder.ProviderConnectionString;

            builder.ConnectionString = providerConnectionString;

            return builder.ConnectionString;
        }
        public UsuarioBEList Get_ListaUsuarios(UsuarioBE oUsuarioBE)
        {
            UsuarioBEList oUsuarioBEList = new UsuarioBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "gn_sps_usuarios";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oUsuarioBE.id_usuario);
            SqlCommand.Parameters.AddWithValue("@vi_ape_paterno", oUsuarioBE.ape_paterno);
            SqlCommand.Parameters.AddWithValue("@vi_ape_materno", oUsuarioBE.ape_materno);
            SqlCommand.Parameters.AddWithValue("@vi_no_usuario", oUsuarioBE.no_usuario);
            SqlCommand.Parameters.AddWithValue("@vi_login", oUsuarioBE.login);
            SqlCommand.Parameters.AddWithValue("@vi_id_perfil", oUsuarioBE.id_perfil);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oUsuarioBE.fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    UsuarioBE oBE = new UsuarioBE();
                    indice = reader.GetOrdinal("id_usuario");
                    oBE.id_usuario = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("nu_dni");
                    oBE.nu_dni = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ape_paterno");
                    oBE.ape_paterno = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ape_materno");
                    oBE.ape_materno = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_usuario");
                    oBE.no_usuario = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_usuario");
                    oBE.login = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_perfil");
                    oBE.id_perfil = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_perfil");
                    oBE.no_perfil = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fe_nacimiento");
                    oBE.fe_nacimiento = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    if (!reader.IsDBNull(indice)) oBE.sfe_nacimiento = reader.GetDateTime(indice).ToShortDateString();

                    indice = reader.GetOrdinal("co_sexo");
                    oBE.co_sexo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_correo");
                    oBE.no_correo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_telefono");
                    oBE.nu_telefono = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_celular");
                    oBE.nu_celular = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_ver_doc_reservado");
                    oBE.fl_ver_doc_reservado = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);

                    indice = reader.GetOrdinal("fl_archivar_doc");
                    oBE.fl_archivar_doc = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);

                    oUsuarioBEList.Add(oBE);
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
            return oUsuarioBEList;
        }

        public void GuardarUsuario(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "gn_spi_usuario";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oUsuarioBE.id_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_id_perfil", oUsuarioBE.id_perfil);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_dni", oUsuarioBE.nu_dni);
                    SqlCommand.Parameters.AddWithValue("@vi_login", oUsuarioBE.login);
                    SqlCommand.Parameters.AddWithValue("@vi_password", oUsuarioBE.password);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario", oUsuarioBE.no_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_ape_paterno", oUsuarioBE.ape_paterno);
                    SqlCommand.Parameters.AddWithValue("@vi_ape_materno", oUsuarioBE.ape_materno);
                    SqlCommand.Parameters.AddWithValue("@vi_fe_nacimiento", oUsuarioBE.fe_nacimiento);
                    SqlCommand.Parameters.AddWithValue("@vi_co_sexo", oUsuarioBE.co_sexo);
                    SqlCommand.Parameters.AddWithValue("@vi_no_correo", oUsuarioBE.no_correo);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_telefono", oUsuarioBE.nu_telefono);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_celular", oUsuarioBE.nu_celular);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_ver_doc_reservado", oUsuarioBE.fl_ver_doc_reservado);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_archivar_doc", oUsuarioBE.fl_archivar_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oUsuarioBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oUsuarioBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oUsuarioBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oUsuarioBE.no_usuario_red);

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

        public void EliminarUsuario(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "gn_spd_usuario";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oUsuarioBE.id_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oUsuarioBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oUsuarioBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oUsuarioBE.no_usuario_red);

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

        public CorreoBE setRestablecePassword(UsuarioBE oUsuarioBE, out int retorno, out String retorno_msg)
        {
            CorreoBE oCorreoBE = null;
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "cdoc_spu_usuario_restablece_pwd";
            cmd.Parameters.AddWithValue("@vi_login", oUsuarioBE.login);
            cmd.Parameters.AddWithValue("@vi_co_usuario", oUsuarioBE.co_usuario);
            cmd.Parameters.AddWithValue("@vi_no_usuario_red", oUsuarioBE.no_usuario_red);
            cmd.Parameters.AddWithValue("@vi_no_estacion_red", oUsuarioBE.no_estacion_red);
            cmd.Parameters.AddWithValue("@vo_retorno", 0).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@vo_msg_retorno", String.Empty).Direction = ParameterDirection.Output;
            cmd.Parameters["@vo_msg_retorno"].Size = 8000;

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCorreoBE = new CorreoBE();
                    int indice;

                    indice = reader.GetOrdinal("no_para");
                    oCorreoBE.no_para = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_cc");
                    oCorreoBE.no_cc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_bcc");
                    oCorreoBE.no_bcc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_asunto");
                    oCorreoBE.no_asunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("tx_body");
                    oCorreoBE.no_detalle = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    //////indice = reader.GetOrdinal("no_adjunto");
                    //////oCorreoBE.no_adjunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                }
                reader.Close();

                /* Recuperando la Variables de salida*/
                retorno = Int32.Parse(cmd.Parameters["@vo_retorno"].Value.ToString());
                retorno_msg = cmd.Parameters["@vo_msg_retorno"].Value.ToString();
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
            return oCorreoBE;
        }

        public void GuardarUsuario_Master(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_usuario_master";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oUsuarioBE.id_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_password", oUsuarioBE.password);
                    SqlCommand.Parameters.AddWithValue("@vi_no_correo", oUsuarioBE.no_correo);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_telefono", oUsuarioBE.nu_telefono);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_celular", oUsuarioBE.nu_celular);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oUsuarioBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oUsuarioBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oUsuarioBE.no_usuario_red);

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