using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.BE;

namespace CtrlDocumentos.DA.Maestros
{
    public class DocumentoDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public DocumentoBEList Get_ListaDocumento(DocumentoBE oDocumentoBE)
        {
            DocumentoBEList oDocumentoBEList = new DocumentoBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_documento";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
            SqlCommand.Parameters.AddWithValue("@vi_co_grupo_doc", oDocumentoBE.co_grupo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_co_sub_grupo_doc", oDocumentoBE.co_sub_grupo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oDocumentoBE.id_plantilla_doc);
            SqlCommand.Parameters.AddWithValue("@vi_no_documento", oDocumentoBE.no_documento);
            SqlCommand.Parameters.AddWithValue("@vi_co_tipo_asignacion", oDocumentoBE.co_tipo_asignacion);
            SqlCommand.Parameters.AddWithValue("@vi_ids_persona_empresa", oDocumentoBE.ids_persona_empresa);
            SqlCommand.Parameters.AddWithValue("@vi_sfe_vencimiento_desde", oDocumentoBE.sfe_vencimiento_desde);
            SqlCommand.Parameters.AddWithValue("@vi_sfe_vencimiento_hasta", oDocumentoBE.sfe_vencimiento_hasta);
            SqlCommand.Parameters.AddWithValue("@vi_cods_estado", oDocumentoBE.cods_estado);
            SqlCommand.Parameters.AddWithValue("@vi_cods_tipo_doc", oDocumentoBE.cods_tipo_doc_file);
            SqlCommand.Parameters.AddWithValue("@vi_id_area", oDocumentoBE.id_area);
            SqlCommand.Parameters.AddWithValue("@vi_id_seccion", oDocumentoBE.id_seccion);
            SqlCommand.Parameters.AddWithValue("@vi_id_usuario", oDocumentoBE.id_usuario);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    DocumentoBE oBE = new DocumentoBE();
                    indice = reader.GetOrdinal("id_documento");
                    oBE.id_documento = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_plantilla_doc");
                    oBE.id_plantilla_doc = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_plantilla_doc");
                    oBE.no_plantilla_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_grupo_doc");
                    oBE.co_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_grupo_doc");
                    oBE.no_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_sub_grupo_doc");
                    oBE.co_sub_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_sub_grupo_doc");
                    oBE.no_sub_grupo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_documento");
                    oBE.no_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_asignacion");
                    oBE.co_tipo_asignacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_tipo_asignacion");
                    oBE.no_tipo_asignacion = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_persona");
                    oBE.id_persona = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_persona");
                    oBE.no_persona = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("id_empresa");
                    oBE.id_empresa = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_empresa");
                    oBE.no_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_persona_empresa");
                    oBE.no_persona_empresa = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fe_inicio");
                    oBE.fe_inicio = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);

                    indice = reader.GetOrdinal("fe_vencimiento");
                    oBE.fe_vencimiento = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);

                    indice = reader.GetOrdinal("qt_dias_para_vencimiento");
                    oBE.qt_dias_para_vencimiento = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("co_estado");
                    oBE.co_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("ids_usuarios_responsables");
                    oBE.ids_usuarios_responsables = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("qt_dias_ant_venc_alerta");
                    oBE.qt_dias_ant_venc_alerta = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("fl_reservado");
                    oBE.fl_reservado = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);

                    oDocumentoBEList.Add(oBE);
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
            return oDocumentoBEList;
        }

        public Documento_CaracteristicaBEList Get_ListaDocumento_Caracteristica(Int32 id_documento)
        {
            Documento_CaracteristicaBEList oDocumento_CaracteristicaBEList = new Documento_CaracteristicaBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_documento_caracteristica";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento", id_documento);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    Documento_CaracteristicaBE oBE = new Documento_CaracteristicaBE();
                    indice = reader.GetOrdinal("id_documento_caracteristica");
                    oBE.id_documento_caracteristica = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_documento");
                    oBE.id_documento = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_caracteristica");
                    oBE.no_caracteristica = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_dato");
                    oBE.co_tipo_dato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_valor_dato");
                    oBE.no_valor_dato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_obligatorio");
                    oBE.fl_obligatorio = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                    oBE.txt_obligatorio = oBE.fl_obligatorio == "1" ? "SI" : "NO";

                    indice = reader.GetOrdinal("nu_orden");
                    oBE.nu_orden = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_archivo");
                    oBE.no_archivo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oDocumento_CaracteristicaBEList.Add(oBE);
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
            return oDocumento_CaracteristicaBEList;
        }

        public void GuardarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_documento";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oDocumentoBE.id_plantilla_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_no_documento", oDocumentoBE.no_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_co_tipo_asignacion", oDocumentoBE.co_tipo_asignacion);
                    SqlCommand.Parameters.AddWithValue("@vi_id_persona_empresa", oDocumentoBE.id_persona_empresa);
                    SqlCommand.Parameters.AddWithValue("@vi_fe_inicio", oDocumentoBE.fe_inicio);
                    SqlCommand.Parameters.AddWithValue("@vi_fe_vencimiento", oDocumentoBE.fe_vencimiento);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_usuarios_responsables", oDocumentoBE.ids_usuarios_responsables);
                    SqlCommand.Parameters.AddWithValue("@vi_qt_dias_ant_venc_alerta", oDocumentoBE.qt_dias_ant_venc_alerta);
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento_ori", oDocumentoBE.id_documento_ori);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_reservado", oDocumentoBE.fl_reservado);
                    SqlCommand.Parameters.AddWithValue("@vi_co_estado", oDocumentoBE.co_estado);

                    SqlCommand.Parameters.AddWithValue("@vi_cont_ids_caracteristica", oDocumentoBE.cont_ids_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_documento_caracteristica", oDocumentoBE.ids_documento_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_no_caracteristica", oDocumentoBE.cad_no_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_co_tipo_dato_caracteristica", oDocumentoBE.cad_co_tipo_dato_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_no_valor_dato_caracteristica", oDocumentoBE.cad_no_valor_dato_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_fl_obligatorio_caracteristica", oDocumentoBE.cad_fl_obligatorio_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_nu_orden_caracteristica", oDocumentoBE.cad_nu_orden_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_no_archivo_caracteristica", oDocumentoBE.cad_no_archivo_caracteristica);

                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public void Archivar(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            string strEnvioMailBD = System.Configuration.ConfigurationManager.AppSettings["EnvioMailBD"].ToString();
            msg_retorno = "";

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_spu_documento_archivar";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
            SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
            SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
            SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

            SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                if (strEnvioMailBD == "0")
                {
                    while (reader.Read())
                    {
                        int indice;

                        EnviarMailDA mailDA = new EnviarMailDA();
                        EnviarMailBE oMailBE = new EnviarMailBE();

                        indice = reader.GetOrdinal("no_para");
                        oMailBE.no_para = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_cc");
                        oMailBE.no_copia = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_bcc");
                        oMailBE.no_copia_oculta = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_asunto");
                        oMailBE.no_asunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("tx_body");
                        oMailBE.no_cuerpo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        //Enviar Email
                        bool estadoMail;
                        string strError = "";
                        estadoMail = mailDA.EnviarEmail(oMailBE, out strError);
                        if (!estadoMail)
                        {
                            retorno = oDocumentoBE.id_documento;
                            msg_retorno = "Se ejecutó correctamente. \n" + strError.ToString();
                        }
                    }

                }
                reader.Close();
                retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                if (string.IsNullOrEmpty(msg_retorno.ToString()))
                {
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = ex.Message.ToString();

                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        public void Desarchivar(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spu_documento_desarchivar";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public void EliminarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_documento";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public void ActivarDocumento(DocumentoBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spu_documento_activar";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public void GuardarDocumentoFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_documento_file";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento_file", oDocumentoBE.id_documento_file);
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoBE.id_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_no_documento", oDocumentoBE.no_documento);
                    SqlCommand.Parameters.AddWithValue("@vi_no_file", oDocumentoBE.no_file);
                    SqlCommand.Parameters.AddWithValue("@vi_qt_tamanio", oDocumentoBE.qt_peso);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_principal", oDocumentoBE.fl_principal);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activar_alerta", oDocumentoBE.fl_activar_alerta);
                    SqlCommand.Parameters.AddWithValue("@vi_sfe_inicio", oDocumentoBE.sfe_inicio);
                    SqlCommand.Parameters.AddWithValue("@vi_sfe_vencimiento", oDocumentoBE.sfe_vencimiento);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_usuarios_responsables", oDocumentoBE.ids_usuarios_responsables);
                    SqlCommand.Parameters.AddWithValue("@vi_qt_dias_ant_venc_alerta", oDocumentoBE.qt_dias_ant_venc_alerta);
                    SqlCommand.Parameters.AddWithValue("@vi_co_tipo_doc", oDocumentoBE.co_tipo_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento_file_ori", oDocumentoBE.id_documento_file_ori);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_reservado", oDocumentoBE.fl_reservado);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public void ArchivarFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
        {
            string strEnvioMailBD = System.Configuration.ConfigurationManager.AppSettings["EnvioMailBD"].ToString();
            msg_retorno = "";

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_spu_documento_file_archivar";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento_file", oDocumentoBE.id_documento_file);
            SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
            SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
            SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

            SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                if (strEnvioMailBD == "0")
                {
                    while (reader.Read())
                    {
                        int indice;

                        EnviarMailDA mailDA = new EnviarMailDA();
                        EnviarMailBE oMailBE = new EnviarMailBE();

                        indice = reader.GetOrdinal("no_para");
                        oMailBE.no_para = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_cc");
                        oMailBE.no_copia = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_bcc");
                        oMailBE.no_copia_oculta = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_asunto");
                        oMailBE.no_asunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("tx_body");
                        oMailBE.no_cuerpo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        //Enviar Email
                        bool estadoMail;
                        string strError = "";
                        estadoMail = mailDA.EnviarEmail(oMailBE, out strError);
                        if (!estadoMail)
                        {
                            retorno = oDocumentoBE.id_documento;
                            msg_retorno = "Se ejecutó correctamente. \n" + strError.ToString();
                        }
                    }

                }
                reader.Close();
                retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                if (string.IsNullOrEmpty(msg_retorno.ToString()))
                {
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = ex.Message.ToString();

                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        public void DesarchivarFile(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spu_documento_file_desarchivar";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento_file", oDocumentoBE.id_documento_file);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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

        public Documento_FileBEList Get_ListaDocumento_Files(Documento_FileBE oDocumentoFileBE, Int32 id_usuario)
        {
            Documento_FileBEList OBEList = new Documento_FileBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_documento_files";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_documento", oDocumentoFileBE.id_documento);
            SqlCommand.Parameters.AddWithValue("@vi_cods_tipo_doc", oDocumentoFileBE.co_tipo_doc);
            SqlCommand.Parameters.AddWithValue("@vi_id_usuario", id_usuario);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    Documento_FileBE oBE = new Documento_FileBE();
                    indice = reader.GetOrdinal("id_documento_file");
                    oBE.id_documento_file = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

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

                    indice = reader.GetOrdinal("fl_principal");
                    oBE.fl_principal = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                    //indice = reader.GetOrdinal("tx_principal");
                    //oBE.tx_principal = oBE.fl_principal == "1" ? "SI" : "NO";

                    indice = reader.GetOrdinal("fl_activar_alerta");
                    oBE.fl_activar_alerta = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                    //indice = reader.GetOrdinal("tx_activar_alerta");
                    //oBE.tx_activar_alerta = oBE.fl_activar_alerta == "1" ? "SI" : "NO";

                    indice = reader.GetOrdinal("fe_inicio");
                    oBE.fe_inicio = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    oBE.sfe_inicio = reader.IsDBNull(indice) ? string.Empty : oBE.fe_inicio.ToShortDateString();

                    indice = reader.GetOrdinal("fe_vencimiento");
                    oBE.fe_vencimiento = reader.IsDBNull(indice) ? DateTime.MinValue : reader.GetDateTime(indice);
                    oBE.sfe_vencimiento = reader.IsDBNull(indice) ? string.Empty : oBE.fe_vencimiento.ToShortDateString();

                    indice = reader.GetOrdinal("ids_usuarios_responsables");
                    oBE.ids_usuarios_responsables = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("qt_dias_ant_venc_alerta");
                    oBE.qt_dias_ant_venc_alerta = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("co_estado");
                    oBE.co_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_doc");
                    oBE.co_tipo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_tipo_doc");
                    oBE.no_tipo_doc = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_reservado");
                    oBE.fl_reservado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

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

        public void EliminarDocumento_File(Documento_FileBE oDocumentoBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_documento_files";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_documento_file", oDocumentoBE.id_documento_file);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oDocumentoBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oDocumentoBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oDocumentoBE.no_usuario_red);

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
