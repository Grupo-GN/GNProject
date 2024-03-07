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
    public class PersonaDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public PersonaBEList Get_ListaPersonas(PersonaBE oPersonaBE)
        {
            PersonaBEList oPersonaBEList = new PersonaBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_persona";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaBE.id_persona);
            SqlCommand.Parameters.AddWithValue("@vi_ti_documento", oPersonaBE.co_tipo_documento);
            SqlCommand.Parameters.AddWithValue("@vi_nu_documento", oPersonaBE.nu_documento);
            SqlCommand.Parameters.AddWithValue("@vi_no_persona", oPersonaBE.no_busqueda);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPersonaBE.fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PersonaBE oBE = new PersonaBE();
                    indice = reader.GetOrdinal("id_persona");
                    oBE.id_persona = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("co_tipo_documento");
                    oBE.co_tipo_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_documento");
                    oBE.no_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_documento");
                    oBE.nu_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ape_paterno");
                    oBE.ape_paterno = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ape_materno");
                    oBE.ape_materno = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_persona");
                    oBE.no_persona = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_razon_social");
                    oBE.no_razon_social = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_contacto");
                    oBE.no_contacto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_busqueda");
                    oBE.no_busqueda = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_telefono");
                    oBE.nu_telefono = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_celular");
                    oBE.nu_celular = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_correo");
                    oBE.no_correo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_foto");
                    oBE.no_foto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_cargo");
                    oBE.id_cargo = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_planilla");
                    oBE.id_planilla = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_tipo_contrato");
                    oBE.id_tipo_contrato = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("fe_ingreso");
                    oBE.fe_ingreso = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fe_cese");
                    oBE.fe_cese = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_area");
                    oBE.id_area = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_area");
                    oBE.no_area = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_seccion");
                    oBE.id_seccion = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_seccion");
                    oBE.no_seccion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_localidad");
                    oBE.id_localidad = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_localidad");
                    oBE.no_localidad = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_jefe");
                    oBE.id_jefe = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_usuario");
                    oBE.no_usuario = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_perfil");
                    oBE.id_perfil = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("fe_ini_contrato");
                    oBE.fe_ini_contrato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fe_fin_contrato");
                    oBE.fe_fin_contrato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_motivo_cese");
                    oBE.co_tipo_cese = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);


                    oPersonaBEList.Add(oBE);
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
            return oPersonaBEList;
        }

        public void GuardarPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_persona";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaBE.id_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_co_tipo_documento", oPersonaBE.co_tipo_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_documento", oPersonaBE.nu_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_ape_paterno", oPersonaBE.ape_paterno);
                    SqlCommand.Parameters.AddWithValue("@vi_ape_materno", oPersonaBE.ape_materno);
                    SqlCommand.Parameters.AddWithValue("@vi_no_persona", oPersonaBE.no_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_no_razon_social", oPersonaBE.no_razon_social);
                    SqlCommand.Parameters.AddWithValue("@vi_no_contacto", oPersonaBE.no_contacto);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_telefono", oPersonaBE.nu_telefono);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_celular", oPersonaBE.nu_celular);
                    SqlCommand.Parameters.AddWithValue("@vi_no_correo", oPersonaBE.no_correo);
                    SqlCommand.Parameters.AddWithValue("@vi_no_foto", oPersonaBE.no_foto);

                    SqlCommand.Parameters.AddWithValue("@vi_id_cargo", oPersonaBE.id_cargo);
                    SqlCommand.Parameters.AddWithValue("@vi_id_planilla", oPersonaBE.id_planilla);
                    SqlCommand.Parameters.AddWithValue("@vi_id_tipo_contrato", oPersonaBE.id_tipo_contrato);

                    SqlCommand.Parameters.AddWithValue("@vi_fe_ingreso", oPersonaBE.fe_ingreso);
                    SqlCommand.Parameters.AddWithValue("@vi_fe_cese", oPersonaBE.fe_cese);

                    SqlCommand.Parameters.AddWithValue("@vi_fe_ini_contrato", oPersonaBE.fe_ini_contrato);
                    SqlCommand.Parameters.AddWithValue("@vi_fe_fin_contrato", oPersonaBE.fe_fin_contrato);
                    SqlCommand.Parameters.AddWithValue("@vi_co_motivo_cese", oPersonaBE.co_tipo_cese);

                    SqlCommand.Parameters.AddWithValue("@vi_id_seccion", oPersonaBE.id_seccion);
                    SqlCommand.Parameters.AddWithValue("@vi_id_localidad", oPersonaBE.id_localidad);

                    SqlCommand.Parameters.AddWithValue("@vi_id_jefe", oPersonaBE.id_jefe);

                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario", oPersonaBE.no_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_clave", oPersonaBE.no_clave);
                    SqlCommand.Parameters.AddWithValue("@vi_id_perfil", oPersonaBE.id_perfil);

                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPersonaBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaBE.no_usuario_red);

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

        public void GuardarFotoPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spu_persona_foto";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaBE.id_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_no_foto", oPersonaBE.no_foto);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaBE.no_usuario_red);

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

        public void EliminarPersona(PersonaBE oPersonaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_persona";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaBE.id_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_id_jefe", oPersonaBE.id_jefe);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaBE.no_usuario_red);

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

        //Direcciones
        public PersonaDireccionBEList Get_ListaDirecciones_Persona(Int32 idPersona)
        {
            PersonaDireccionBEList oPersonaDireccionBEList = new PersonaDireccionBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_direccion_x_persona";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_persona", idPersona);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PersonaDireccionBE oBE = new PersonaDireccionBE();

                    indice = reader.GetOrdinal("id_persona_direccion");
                    oBE.id_persona_direccion = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_persona");
                    oBE.id_persona = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_direccion");
                    oBE.no_direccion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_dpto");
                    oBE.co_dpto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_dpto");
                    oBE.no_dpto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_prov");
                    oBE.co_prov = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_prov");
                    oBE.no_prov = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_dist");
                    oBE.co_dist = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_dist");
                    oBE.no_dist = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_contacto");
                    oBE.no_contacto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_telefono");
                    oBE.nu_telefono = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nu_celular");
                    oBE.nu_celular = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_correo");
                    oBE.no_correo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);


                    oPersonaDireccionBEList.Add(oBE);
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
            return oPersonaDireccionBEList;
        }

        public void GuardarDireccion(PersonaDireccionBE oPersonaDireccionBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_direccion";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona_direccion", oPersonaDireccionBE.id_persona_direccion);
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaDireccionBE.id_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_no_direccion", oPersonaDireccionBE.no_direccion);
                    SqlCommand.Parameters.AddWithValue("@vi_co_dpto", oPersonaDireccionBE.co_dpto);
                    SqlCommand.Parameters.AddWithValue("@vi_co_prov", oPersonaDireccionBE.co_prov);
                    SqlCommand.Parameters.AddWithValue("@vi_co_dist", oPersonaDireccionBE.co_dist);
                    SqlCommand.Parameters.AddWithValue("@vi_no_contacto", oPersonaDireccionBE.no_contacto);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_telefono", oPersonaDireccionBE.nu_telefono);
                    SqlCommand.Parameters.AddWithValue("@vi_nu_celular", oPersonaDireccionBE.nu_celular);
                    SqlCommand.Parameters.AddWithValue("@vi_no_correo", oPersonaDireccionBE.no_correo);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPersonaDireccionBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaDireccionBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaDireccionBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaDireccionBE.no_usuario_red);

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

        public void EliminarDireccion(PersonaDireccionBE oPersonaDireccionBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_direccion";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona_direccion", oPersonaDireccionBE.id_persona_direccion);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaDireccionBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaDireccionBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaDireccionBE.no_usuario_red);

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

        //Files de persona
        public void GuardarPersona_File(PersonaFileBE oPersonaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_persona_file";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona", oPersonaBE.id_persona);
                    SqlCommand.Parameters.AddWithValue("@vi_no_documento", oPersonaBE.no_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_no_file", oPersonaBE.no_file);
                    SqlCommand.Parameters.AddWithValue("@vi_qt_tamanio", oPersonaBE.qt_peso);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaBE.no_usuario_red);

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

        public PersonaFileBEList Get_ListaPersona_Files(Int32 id_persona)
        {
            PersonaFileBEList OBEList = new PersonaFileBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_persona_files";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_persona", id_persona);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PersonaFileBE oBE = new PersonaFileBE();
                    indice = reader.GetOrdinal("id_persona_file");
                    oBE.id_persona_File = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_documento");
                    oBE.no_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_file");
                    oBE.no_file = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_folder");
                    oBE.no_folder = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_file_all");
                    oBE.no_file_all = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("qt_tamanio");
                    oBE.qt_peso = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    OBEList.Add(oBE);
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
            return OBEList;
        }

        public void EliminarPersona_File(PersonaFileBE oPersonaBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_persona_files";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona_file", oPersonaBE.id_persona_File);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPersonaBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPersonaBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPersonaBE.no_usuario_red);

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
