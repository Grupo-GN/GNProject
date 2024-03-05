using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;
using System.Data.SqlClient;

namespace Capas.Portal.Datos
{
    public class ControllerUpdateIntranet : ClsConexion 
    {
     
        public bool MS_INTRANET_UPDATE(string sql,string rutaFuente, int bandera,
            string terminadorColumna,string terminadorFila,int maximoErrores)
        {
            using (SqlConnection cn = new SqlConnection(Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_cargaMasiva_Update_Intranet", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@SQL", sql);
                    cmd.Parameters.AddWithValue("@rutaFuente", rutaFuente);
                    cmd.Parameters.AddWithValue("@banderaRestriccion", bandera);
                    cmd.Parameters.AddWithValue("@terminadorColumna", terminadorColumna);
                    cmd.Parameters.AddWithValue("@terminadorFila", terminadorFila);
                    cmd.Parameters.AddWithValue("@maximoErrores", maximoErrores);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }

        }


        public void  MS_INTRANET_UPDATE_ERROR()
        {
            using (SqlConnection cn = new SqlConnection(Conexion()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_cargaMasiva_Update_Intranet_Error", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
