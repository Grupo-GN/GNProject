using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Maestros;

namespace CtrlDocumentos.DA.Maestros
{
    public class ParametroDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public ParametroBEList Get_BandejaParametros(int id_parametro, string no_tabla, string fl_activo)
        {
            ParametroBEList oParametroBEList = new ParametroBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_parametro";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_parametro", id_parametro);
            SqlCommand.Parameters.AddWithValue("@vi_no_tabla", no_tabla);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    ParametroBE oBE = new ParametroBE();
                    indice = reader.GetOrdinal("id_parametro");
                    oBE.id_parametro = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_tabla");
                    oBE.no_tabla = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("de_tabla");
                    oBE.de_tabla = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_tabla");
                    oBE.fl_tabla = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oParametroBEList.Add(oBE);
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
            return oParametroBEList;
        }
        public void GuardarParametro(ParametroBE oParametroBE, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(DataBaseHelper.GetDbConnectionString()))
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
                    SqlCommand.CommandText = "cdoc_spi_parametro";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_parametro", oParametroBE.id_parametro);
                    SqlCommand.Parameters.AddWithValue("@vi_no_tabla", oParametroBE.no_tabla);
                    SqlCommand.Parameters.AddWithValue("@vi_de_tabla", oParametroBE.de_tabla);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_tabla", oParametroBE.fl_tabla);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oParametroBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oParametroBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oParametroBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oParametroBE.no_usuario_red);

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
        public void EliminarParametro(ParametroBE oParametroBE, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(DataBaseHelper.GetDbConnectionString()))
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
                    SqlCommand.CommandText = "cdoc_spd_parametro";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_parametro", oParametroBE.id_parametro);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oParametroBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oParametroBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oParametroBE.no_usuario_red);

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

        //Detalle
        public ParametroDetalleBEList Get_BandejaParametrosDetalle(int id_parametro, int id_parametro_detalle, string fl_activo)
        {
            ParametroDetalleBEList oParametroDetalleBEList = new ParametroDetalleBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_parametro_detalle";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_parametro", id_parametro);
            SqlCommand.Parameters.AddWithValue("@vi_id_parametro_detalle", id_parametro_detalle);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    ParametroDetalleBE oBE = new ParametroDetalleBE();
                    indice = reader.GetOrdinal("id_parametro");
                    oBE.id_parametro = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_parametro_detalle");
                    oBE.id_parametro_detalle = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_valor1");
                    oBE.no_valor1 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor2");
                    oBE.no_valor2 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor3");
                    oBE.no_valor3 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor4");
                    oBE.no_valor4 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor5");
                    oBE.no_valor5 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oParametroDetalleBEList.Add(oBE);
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
            return oParametroDetalleBEList;
        }
        public void GuardarParametroDetalle(ParametroDetalleBE oParametroDetalleBE, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(DataBaseHelper.GetDbConnectionString()))
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
                    SqlCommand.CommandText = "cdoc_spi_parametro_detalle";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_parametro_detalle", oParametroDetalleBE.id_parametro_detalle);
                    SqlCommand.Parameters.AddWithValue("@vi_id_parametro", oParametroDetalleBE.id_parametro);
                    SqlCommand.Parameters.AddWithValue("@vi_no_valor1", oParametroDetalleBE.no_valor1);
                    SqlCommand.Parameters.AddWithValue("@vi_no_valor2", oParametroDetalleBE.no_valor2);
                    SqlCommand.Parameters.AddWithValue("@vi_no_valor3", oParametroDetalleBE.no_valor3);
                    SqlCommand.Parameters.AddWithValue("@vi_no_valor4", oParametroDetalleBE.no_valor4);
                    SqlCommand.Parameters.AddWithValue("@vi_no_valor5", oParametroDetalleBE.no_valor5);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oParametroDetalleBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oParametroDetalleBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oParametroDetalleBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oParametroDetalleBE.no_usuario_red);

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
        public void EliminarParametroDetalle(ParametroDetalleBE oParametroDetalleBE, out int retorno, out String msg_retorno)
        {
            SqlTransaction SqlTran = null;
            using (SqlConnection Conex = new SqlConnection(DataBaseHelper.GetDbConnectionString()))
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
                    SqlCommand.CommandText = "cdoc_spd_parametro_detalle";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_parametro_detalle", oParametroDetalleBE.id_parametro_detalle);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oParametroDetalleBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oParametroDetalleBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oParametroDetalleBE.no_usuario_red);

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

        public ParametroDetalleBEList Get_BandejaParametrosDetalle_TipoDocumento(String ids_plantilla_doc, String no_tipo_doc_archivo, String fl_activo)
        {
            ParametroDetalleBEList oParametroDetalleBEList = new ParametroDetalleBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "CDOC_sps_parametro_detalle_tipo_documento";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_ids_plantilla_doc", ids_plantilla_doc);
            SqlCommand.Parameters.AddWithValue("@vi_no_tipo_doc_archivo", no_tipo_doc_archivo);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    ParametroDetalleBE oBE = new ParametroDetalleBE();
                    indice = reader.GetOrdinal("id_parametro");
                    oBE.id_parametro = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_parametro_detalle");
                    oBE.id_parametro_detalle = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_valor1");
                    oBE.no_valor1 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor2");
                    oBE.no_valor2 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor3");
                    oBE.no_valor3 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor4");
                    oBE.no_valor4 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor5");
                    oBE.no_valor5 = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ids_plantilla_doc");
                    oBE.ids_plantilla_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("noms_plantilla_doc");
                    oBE.noms_plantilla_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oParametroDetalleBEList.Add(oBE);
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
            return oParametroDetalleBEList;
        }
    }
}
