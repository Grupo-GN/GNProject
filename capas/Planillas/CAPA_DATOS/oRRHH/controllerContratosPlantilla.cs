using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS.oRRHH
{
    public class controllerContratosPlantilla
    {
        private static controllerContratosPlantilla instance = null;
        public static controllerContratosPlantilla getinstance()
        {
            return instance == null ? instance = new controllerContratosPlantilla() : instance;
        }
        public object Get_Inicial()
        {
            object response;
            ComboBEList oTipoContratos = Get_ListaCombo("TIPO_CONTRATO");
            ComboBEList oCargo = Get_ListaCombo("CARGO");

            response = new { oTipoContratos = oTipoContratos, oCargo = oCargo };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        public object Get_Bandeja(String[] strParametros)
        {
            List<object> oResponse = new List<object>();
            //-----
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                /*Propiedades del SqlCommand*/
                using (SqlCommand cmd = new SqlCommand("sps_plantilla_contrato", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    cmd.Parameters.AddWithValue("@vi_tipo_contrato_id", strParametros[0]);
                    cmd.Parameters.AddWithValue("@vi_Cargo_Id", strParametros[1]);

                    SqlDataReader reader = null;
                    try
                    {
                        cn.Open();
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int indice;

                            indice = reader.GetOrdinal("tipo_contrato_id");
                            String tipo_contrato_id = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            indice = reader.GetOrdinal("tipo_contrato");
                            String tipo_contrato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            indice = reader.GetOrdinal("Cargo_Id");
                            String cargo_id = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            indice = reader.GetOrdinal("Cargo");
                            String cargo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            indice = reader.GetOrdinal("tx_plantilla_contrato");
                            String tx_plantilla_contrato = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            object oEntidad = new
                            {
                                tipo_contrato_id = tipo_contrato_id,
                                tipo_contrato = tipo_contrato,
                                cargo_id = cargo_id,
                                cargo = cargo,
                                tx_plantilla_contrato = tx_plantilla_contrato
                            };
                            oResponse.Add(oEntidad);
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
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oResponse);
        }
        public String getPlantillaContrato_HTML(String Tipo_Contrato_Id, String Cargo_Id)
        {
            String plantillaContrato_HTML = String.Empty;
            //-----
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                /*Propiedades del SqlCommand*/
                using (SqlCommand cmd = new SqlCommand("sps_plantilla_contrato", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    /*Agregar Parametros al SqlCommand */
                    cmd.Parameters.AddWithValue("@vi_tipo_contrato_id", Tipo_Contrato_Id);
                    cmd.Parameters.AddWithValue("@vi_Cargo_Id", Cargo_Id);

                    SqlDataReader reader = null;
                    try
                    {
                        cn.Open();
                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            int indice;
                            indice = reader.GetOrdinal("tx_plantilla_contrato");
                            plantillaContrato_HTML = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);
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
                }
            }
            
            return plantillaContrato_HTML;
        }

        public object GuardarPlantilla(String[] strParametros)
        {
            Int32 retorno;
            String msg_retorno;
            object response;

            String tx_plantilla_contrato = strParametros[2];
            List<String> lstPalabrasClave = new List<string>();
            lstPalabrasClave.Add("[TIPO_RENOVACION]");
            lstPalabrasClave.Add("[NOMBRE_TRABAJADOR]");
            lstPalabrasClave.Add("[DNI_TRABAJADOR]");
            lstPalabrasClave.Add("[DIRECCION_TRABAJADOR]");
            lstPalabrasClave.Add("[CARGO_TRABAJADOR]");
            lstPalabrasClave.Add("[FISCALIZACION]");
            lstPalabrasClave.Add("[FUNCIONES_CARGO]");
            lstPalabrasClave.Add("[FE_INICIO_CONTRATO]");
            lstPalabrasClave.Add("[FE_FINAL_CONTRATO]");
            lstPalabrasClave.Add("[PERIODO_PRUEBA]");
            lstPalabrasClave.Add("[SUELDO_TRABAJADOR_NUMERO]");
            lstPalabrasClave.Add("[SUELDO_TRABAJADOR_LETRA]");
            lstPalabrasClave.Add("[FECHA_FIRMA_CONTRATO]");

            Int32 index_ini_caracter = 0;
            Int32 index_fin_caracter = 0;
            Int32 length_caracter = 0;
            String cadena_clave = "";
            for (int i = 0; i <= tx_plantilla_contrato.Length; i++)
            {
                index_ini_caracter = tx_plantilla_contrato.IndexOf("[", index_ini_caracter);
                if (index_ini_caracter > 0)
                {
                    index_fin_caracter = tx_plantilla_contrato.IndexOf("]", index_ini_caracter);
                    length_caracter = (index_fin_caracter - index_ini_caracter) + 1;
                    cadena_clave = tx_plantilla_contrato.Substring(index_ini_caracter, length_caracter);
                    if (lstPalabrasClave.Find(cad => cad.ToString() == cadena_clave) == null)
                    {
                        response = new { retorno = -1, msg_retorno = "No se puede utilizar la palabra clave " + cadena_clave + " ya que no está configurado en el sistema." };
                        System.Web.Script.Serialization.JavaScriptSerializer serializer_aux = new System.Web.Script.Serialization.JavaScriptSerializer();
                        return serializer_aux.Serialize(response);
                    }
                    index_ini_caracter = index_fin_caracter;
                    i = index_fin_caracter;
                }
                else
                {
                    break;
                }
            }

            SqlTransaction SqlTran = null;
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                try
                {
                    /* Abrir la Conexion*/
                    if (cn.State != ConnectionState.Open)
                        cn.Open();

                    /* Comenzamos la Transaccion*/
                    SqlTran = cn.BeginTransaction();

                    /*Propiedades del SqlCommand*/
                    using (SqlCommand cmd = new SqlCommand("spi_plantilla_contrato", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        /*Agregar Parametros al SqlCommand */
                        cmd.Parameters.AddWithValue("@vi_tipo_contrato_id", strParametros[0]);
                        cmd.Parameters.AddWithValue("@vi_Cargo_Id", strParametros[1]);
                        cmd.Parameters.AddWithValue("@vi_tx_plantilla_contrato", strParametros[2]);
                        cmd.Parameters.AddWithValue("@vi_fl_activo", strParametros[3]);
                        cmd.Parameters.AddWithValue("@vi_co_usuario", strParametros[4]);
                        cmd.Parameters.AddWithValue("@vi_no_estacion_red", strParametros[5]);
                        cmd.Parameters.AddWithValue("@vi_no_usuario_red", strParametros[6]);
                        cmd.Parameters.AddWithValue("@vo_retorno", 0).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@vo_msg_retorno", DBNull.Value).Direction = ParameterDirection.Output;
                        cmd.Parameters["@vo_msg_retorno"].Size = 8000;

                        /* Asignamos Transaccion al Command */
                        cmd.Transaction = SqlTran;
                        /* Ejecutamos  y recuperamos valor de salida*/
                        //SqlCommand.ExecuteNonQuery();
                        cmd.ExecuteScalar();

                        /* Recuperando la Variables de salida*/
                        retorno = Int32.Parse(cmd.Parameters["@vo_retorno"].Value.ToString());
                        msg_retorno = cmd.Parameters["@vo_msg_retorno"].Value.ToString();

                        /* Si todo salio bien hacemos commit los cambios */
                        if (SqlTran.Connection != null) SqlTran.Commit();
                    }
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
                    if (cn.State != ConnectionState.Closed)
                        cn.Close();
                    // Destruimos la conexion
                    cn.Dispose();
                }
            }

            response = new { retorno = retorno, msg_retorno = msg_retorno };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        private ComboBEList Get_ListaCombo(String co_maestro, String co_padre = "", String co_usuario = "")
        {
            ComboBEList oComboBEList = new ComboBEList();

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                /*Propiedades del SqlCommand*/
                using (SqlCommand cmd = new SqlCommand("I_sps_combo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    /*Agregar Parametros al SqlCommand */
                    cmd.Parameters.AddWithValue("@vi_codigo", co_maestro);
                    cmd.Parameters.AddWithValue("@vi_co_padre", co_padre);
                    cmd.Parameters.AddWithValue("@vi_co_usuario", co_usuario);
                    SqlDataReader reader = null;
                    try
                    {
                        cn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int indice;
                            ComboBE oBE = new ComboBE();
                            indice = reader.GetOrdinal("value");
                            oBE.value = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            indice = reader.GetOrdinal("nombre");
                            oBE.nombre = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                            oComboBEList.Add(oBE);
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
                }
            }
            return oComboBEList;
        }
    }

    #region ENTIDAD
    [Serializable]
    public class ComboBE
    {
        public String value { get; set; }
        public String nombre { get; set; }
    }
    [Serializable]
    public class ComboBEList : List<ComboBE>
    {
    }
    #endregion
    
}
