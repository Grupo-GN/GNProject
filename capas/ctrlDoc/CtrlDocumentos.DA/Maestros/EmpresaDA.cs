using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Maestros;

namespace CtrlDocumentos.DA.Maestros
{
    public class EmpresaDA
    {
        SqlCommand SqlCommand;        

        public List<EmpresaBE> getEmpresas(EmpresaBE oEmpresaBE)
        {
            List<EmpresaBE> oLista = new List<EmpresaBE>();
            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_empresa";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;
            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_empresa", oEmpresaBE.id_empresa);
            SqlCommand.Parameters.AddWithValue("@vi_co_tipo_empresa", oEmpresaBE.co_tipo_empresa);
            SqlCommand.Parameters.AddWithValue("@vi_nu_ruc", oEmpresaBE.nu_ruc);
            SqlCommand.Parameters.AddWithValue("@vi_no_razon_social", oEmpresaBE.no_razon_social);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oEmpresaBE.fl_activo);
            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int indice;
                    EmpresaBE oBE = new EmpresaBE();
                    indice = reader.GetOrdinal("id_empresa");
                    oBE.id_empresa = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("nu_ruc");
                    oBE.nu_ruc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_razon_social");
                    oBE.no_razon_social = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("de_empresa");
                    oBE.de_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_contacto");
                    oBE.no_contacto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_telefono");
                    oBE.nu_telefono = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_celular");
                    oBE.nu_celular = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_correo");
                    oBE.no_correo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_logo");
                    oBE.no_logo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_empresa");
                    oBE.co_tipo_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_tipo_empresa");
                    oBE.no_tipo_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oLista.Add(oBE);
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
            return oLista;
        }

        public void GuardarEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_empresa";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_empresa", oEmpresaBE.id_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_ruc", oEmpresaBE.nu_ruc);
                    SqlCommand.Parameters.AddWithValue("@vi_no_razon_social", oEmpresaBE.no_razon_social);
                    SqlCommand.Parameters.AddWithValue("@vi_de_empresa", oEmpresaBE.de_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_no_contacto", oEmpresaBE.no_contacto);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_telefono", oEmpresaBE.nu_telefono);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_celular", oEmpresaBE.nu_celular);
                    SqlCommand.Parameters.AddWithValue("@vi_no_correo", oEmpresaBE.no_correo);
                    SqlCommand.Parameters.AddWithValue("@vi_no_logo", oEmpresaBE.no_logo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_tipo_empresa", oEmpresaBE.co_tipo_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oEmpresaBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oEmpresaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oEmpresaBE.no_usuario_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oEmpresaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vo_retorno", 0).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.AddWithValue("@vo_msg_retorno", String.Empty).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters["@vo_msg_retorno"].Size = 8000;

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

        public void GuardarLogoEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spu_empresa_logo";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_empresa", oEmpresaBE.id_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_no_logo", oEmpresaBE.no_logo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oEmpresaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oEmpresaBE.no_usuario_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oEmpresaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vo_retorno", 0).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.AddWithValue("@vo_msg_retorno", String.Empty).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters["@vo_msg_retorno"].Size = 8000;

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

        public void EliminarEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_empresa";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_empresa", oEmpresaBE.id_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oEmpresaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oEmpresaBE.no_usuario_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oEmpresaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vo_retorno", 0).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters.AddWithValue("@vo_msg_retorno", String.Empty).Direction = ParameterDirection.Output;
                    SqlCommand.Parameters["@vo_msg_retorno"].Size = 8000;

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
