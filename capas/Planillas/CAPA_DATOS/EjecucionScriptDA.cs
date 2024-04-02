using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class EjecucionScriptDA
    {
        private String getConnection_QueryBD(String rucEmpresa)
        {
            //Verificar si la empresa existe "conexion"
            String codEmpresaConnection = "conexion_" + rucEmpresa;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection] == null)
            {
                throw new Exception("Empresa no configurada.");
            }
            return codEmpresaConnection;
        }
         
        public String ES_ValidaQuery(String cadena, String codRUCEmpresa)
        {
            String valor;
            try
            {
                String conex = System.Configuration.ConfigurationManager.ConnectionStrings[getConnection_QueryBD(codRUCEmpresa)].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conex))
                {
                    using (SqlCommand cmd = new SqlCommand("sps_valida_query", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@variable", cadena);

                        valor = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                valor = ex.Message;
            }
            return valor;
        }

        public Int32 ES_InsertarScript(EjecucionScriptBE oEjecucionScriptBE, String codRUCEmpresa)
        {
            Int32 retorno = 0;
            try
            {
                String conex = System.Configuration.ConfigurationManager.ConnectionStrings[getConnection_QueryBD(codRUCEmpresa)].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conex))
                {
                    using (SqlCommand cmd = new SqlCommand("spi_insertar_script", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@tx_comentario", oEjecucionScriptBE.tx_comentario);
                        cmd.Parameters.AddWithValue("@no_query", oEjecucionScriptBE.no_query);
                        cmd.Parameters.AddWithValue("@no_query_hml", oEjecucionScriptBE.no_query_html);
                        cmd.Parameters.AddWithValue("@co_token", oEjecucionScriptBE.co_token);
                        cmd.Parameters.AddWithValue("@co_usuario", oEjecucionScriptBE.co_usuario_crea);
                        cmd.Parameters.AddWithValue("@no_estacion_red", oEjecucionScriptBE.no_estacion_red);
                        cmd.Parameters.AddWithValue("@no_usuario_red", oEjecucionScriptBE.no_usuario_red);

                        retorno = Int32.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
            }
            catch
            {
                throw;
            }
            return retorno;
        }

        public Int32 ES_UpdateScript(EjecucionScriptBE oEjecucionScriptBE, String codRUCEmpresa)
        {
            Int32 retorno = 0;
            try
            {
                String conex = System.Configuration.ConfigurationManager.ConnectionStrings[getConnection_QueryBD(codRUCEmpresa)].ConnectionString;
                using (SqlConnection cn = new SqlConnection(conex))
                {
                    using (SqlCommand cmd = new SqlCommand("spu_aprobar_script", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@co_token", oEjecucionScriptBE.co_token);
                        cmd.Parameters.AddWithValue("@fl_aprobado", oEjecucionScriptBE.fl_aprobado);
                        cmd.Parameters.AddWithValue("@co_usuario", oEjecucionScriptBE.co_usuario_crea);
                        cmd.Parameters.AddWithValue("@no_estacion_red", oEjecucionScriptBE.no_estacion_red);
                        cmd.Parameters.AddWithValue("@no_usuario_red", oEjecucionScriptBE.no_usuario_red);

                        retorno = Int32.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
            }
            catch
            {
                throw;
            }
            return retorno;
        }
    }
}
