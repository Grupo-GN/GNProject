using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Maestros;

namespace CtrlDocumentos.DA.Maestros
{
    public class CargoDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public CargoBEList Get_ListaCargos(int id_Cargo, string no_Cargo, string fl_activo)
        {
            CargoBEList oCargoBEList = new CargoBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_CARGO";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_cargo", id_Cargo);
            SqlCommand.Parameters.AddWithValue("@vi_no_cargo", no_Cargo);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    CargoBE oBE = new CargoBE();
                    indice = reader.GetOrdinal("id_cargo");
                    oBE.id_cargo = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_cargo");
                    oBE.no_cargo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("de_cargo");
                    oBE.de_cargo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_homologacion");
                    oBE.co_homologacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oCargoBEList.Add(oBE);
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
            return oCargoBEList;
        }

        public void GuardarCargo(CargoBE oCargoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_CARGO";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_cargo", oCargoBE.id_cargo);
                    SqlCommand.Parameters.AddWithValue("@vi_no_cargo", oCargoBE.no_cargo);
                    SqlCommand.Parameters.AddWithValue("@vi_de_cargo", oCargoBE.de_cargo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_homologacion", oCargoBE.co_homologacion);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oCargoBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oCargoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oCargoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oCargoBE.no_usuario_red);

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

        public void EliminarCargo(CargoBE oCargoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_CARGO";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_Cargo", oCargoBE.id_cargo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oCargoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oCargoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oCargoBE.no_usuario_red);

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