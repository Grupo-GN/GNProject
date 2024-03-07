using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Maestros;

namespace CtrlDocumentos.DA.Maestros
{
    public class SeccionDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public SeccionBEList Get_ListaSeccion(int id_seccion, string no_seccion, int id_area, string fl_activo, int id_Usuario)
        {
            SeccionBEList oSeccionBEList = new SeccionBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_SECCION";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_seccion", id_seccion);
            SqlCommand.Parameters.AddWithValue("@vi_id_area", id_area);
            SqlCommand.Parameters.AddWithValue("@vi_no_seccion", no_seccion);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", fl_activo);
            SqlCommand.Parameters.AddWithValue("@vi_id_usuario", id_Usuario);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    SeccionBE oBE = new SeccionBE();
                    indice = reader.GetOrdinal("id_seccion");
                    oBE.id_seccion = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_seccion");
                    oBE.no_seccion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("de_seccion");
                    oBE.de_seccion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_area");
                    oBE.id_area = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_area");
                    oBE.no_area = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_homologacion");
                    oBE.co_homologacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oSeccionBEList.Add(oBE);
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
            return oSeccionBEList;
        }

        public void GuardarSeccion(SeccionBE oSeccionBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_SECCION";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_seccion", oSeccionBE.id_seccion);
                    SqlCommand.Parameters.AddWithValue("@vi_no_seccion", oSeccionBE.no_seccion);
                    SqlCommand.Parameters.AddWithValue("@vi_de_seccion", oSeccionBE.de_seccion);
                    SqlCommand.Parameters.AddWithValue("@vi_id_area", oSeccionBE.id_area);
                    SqlCommand.Parameters.AddWithValue("@vi_co_homologacion", oSeccionBE.co_homologacion);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oSeccionBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oSeccionBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oSeccionBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oSeccionBE.no_usuario_red);

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

        public void EliminarSeccion(SeccionBE oSeccionBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_SECCION";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_seccion", oSeccionBE.id_seccion);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oSeccionBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oSeccionBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oSeccionBE.no_usuario_red);

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