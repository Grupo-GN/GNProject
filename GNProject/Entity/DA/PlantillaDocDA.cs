using GNProject.Acceso;
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
    public class PlantillaDocDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public PlantillaDocBEList Get_ListaPlantillaDoc(PlantillaDocBE oPlantillaDocBE)
        {
            PlantillaDocBEList oPlantillaDocBEList = new PlantillaDocBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_plantilla_doc";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oPlantillaDocBE.id_plantilla_doc);
            SqlCommand.Parameters.AddWithValue("@vi_no_plantilla_doc", oPlantillaDocBE.no_plantilla_doc);
            SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPlantillaDocBE.fl_activo);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PlantillaDocBE oBE = new PlantillaDocBE();
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

                    indice = reader.GetOrdinal("ids_usuarios_responsables");
                    oBE.ids_usuarios_responsables = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("qt_dias_ant_venc_alerta");
                    oBE.qt_dias_ant_venc_alerta = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("fl_activo");
                    oBE.fl_activo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_estado");
                    oBE.no_estado = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("cods_tipo_doc_archivo");
                    oBE.cods_tipo_doc_archivo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oPlantillaDocBEList.Add(oBE);
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
            return oPlantillaDocBEList;
        }

        public PlantillaDoc_CaracteristicaBEList Get_ListaPlantillaDoc_Caracteristica(Int32 id_plantilla_doc)
        {
            PlantillaDoc_CaracteristicaBEList oPlantillaDoc_CaracteristicaBEList = new PlantillaDoc_CaracteristicaBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_plantilla_doc_caracteristica";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", id_plantilla_doc);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PlantillaDoc_CaracteristicaBE oBE = new PlantillaDoc_CaracteristicaBE();
                    indice = reader.GetOrdinal("id_plantilla_doc_caracteristica");
                    oBE.id_plantilla_doc_caracteristica = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_plantilla_doc");
                    oBE.id_plantilla_doc = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_caracteristica");
                    oBE.no_caracteristica = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("co_tipo_dato");
                    oBE.co_tipo_dato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_obligatorio");
                    oBE.fl_obligatorio = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
                    oBE.txt_obligatorio = oBE.fl_obligatorio == "1" ? "SI" : "NO";

                    indice = reader.GetOrdinal("nu_orden");
                    oBE.nu_orden = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("qt_dias_alerta");
                    oBE.qt_dias_alerta = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    oPlantillaDoc_CaracteristicaBEList.Add(oBE);
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
            return oPlantillaDoc_CaracteristicaBEList;
        }

        public PlantillaDoc_FileBEList Get_ListaPlantillaDoc_File(Int32 id_plantilla_doc)
        {
            PlantillaDoc_FileBEList oPlantillaDoc_FileBEList = new PlantillaDoc_FileBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_plantilla_doc_file";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", id_plantilla_doc);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    PlantillaDoc_FileBE oBE = new PlantillaDoc_FileBE();
                    indice = reader.GetOrdinal("id_plantilla_doc_file");
                    oBE.id_plantilla_doc_file = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("id_plantilla_doc");
                    oBE.id_plantilla_doc = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_documento");
                    oBE.no_documento = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oPlantillaDoc_FileBEList.Add(oBE);
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
            return oPlantillaDoc_FileBEList;
        }

        public void GuardarPlantillaDoc(PlantillaDocBE oPlantillaDocBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spi_plantilla_doc";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oPlantillaDocBE.id_plantilla_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_no_plantilla_doc", oPlantillaDocBE.no_plantilla_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_co_sub_grupo_doc", oPlantillaDocBE.co_sub_grupo_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_usuarios_responsables", oPlantillaDocBE.ids_usuarios_responsables);
                    SqlCommand.Parameters.AddWithValue("@vi_qt_dias_ant_venc_alerta", oPlantillaDocBE.qt_dias_ant_venc_alerta);
                    SqlCommand.Parameters.AddWithValue("@vi_fl_activo", oPlantillaDocBE.fl_activo);
                    SqlCommand.Parameters.AddWithValue("@vi_cods_tipo_doc_archivo", oPlantillaDocBE.cods_tipo_doc_archivo);

                    SqlCommand.Parameters.AddWithValue("@vi_cont_ids_caracteristica", oPlantillaDocBE.cont_ids_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_PlantillaDoccaracteristica", oPlantillaDocBE.ids_PlantillaDoccaracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_no_caracteristica", oPlantillaDocBE.cad_no_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_co_tipo_dato_caracteristica", oPlantillaDocBE.cad_co_tipo_dato_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_fl_obligatorio_caracteristica", oPlantillaDocBE.cad_fl_obligatorio_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_nu_orden_caracteristica", oPlantillaDocBE.cad_nu_orden_caracteristica);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_qt_dias_alerta_caracteristica", oPlantillaDocBE.cad_qt_dias_alerta_caracteristica);

                    SqlCommand.Parameters.AddWithValue("@vi_cont_ids_file", oPlantillaDocBE.cont_ids_file);
                    SqlCommand.Parameters.AddWithValue("@vi_ids_PlantillaDoc_File", oPlantillaDocBE.ids_PlantillaDoc_File);
                    SqlCommand.Parameters.AddWithValue("@vi_cad_no_documento", oPlantillaDocBE.cad_no_documento);

                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPlantillaDocBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPlantillaDocBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPlantillaDocBE.no_usuario_red);

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

        public void EliminarPlantillaDoc(PlantillaDocBE oPlantillaDocBE, out int retorno, out String msg_retorno)
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
                    SqlCommand.CommandText = "cdoc_spd_plantilla_doc";
                    SqlCommand.Connection = Conex;
                    SqlCommand.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    SqlCommand.Parameters.AddWithValue("@vi_id_plantilla_doc", oPlantillaDocBE.id_plantilla_doc);
                    SqlCommand.Parameters.AddWithValue("@vi_co_usuario", oPlantillaDocBE.co_usuario);
                    SqlCommand.Parameters.AddWithValue("@vi_no_estacion_red", oPlantillaDocBE.no_estacion_red);
                    SqlCommand.Parameters.AddWithValue("@vi_no_usuario_red", oPlantillaDocBE.no_usuario_red);

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
        static string ConvertEntityConnectionStringToSqlConnection(string entityConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            string providerConnectionString = entityBuilder.ProviderConnectionString;

            builder.ConnectionString = providerConnectionString;

            return builder.ConnectionString;
        }

    }
}