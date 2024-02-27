using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class ComboDA : ClsConexion
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public ComboBEList Get_ListaCombo(String codigo, String co_padre = "", String co_usuario = "")
        {
            ComboBEList oComboBEList = new ComboBEList();

            SqlConnection cn = new SqlConnection(Conexion());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "I_sps_combo";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_codigo", codigo);
            SqlCommand.Parameters.AddWithValue("@vi_co_padre", co_padre);
            SqlCommand.Parameters.AddWithValue("@vi_co_usuario", co_usuario);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

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
            return oComboBEList;
        }

    }
}
