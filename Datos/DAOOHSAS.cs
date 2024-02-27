using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Entidad;
using System.Data.SqlClient;
using System.Data;

namespace Capas.Portal.Datos
{
    public class DAOOHSAS : ClsConexion
    {
        public List<OHSAS> GetOHSASAll()
        {
            List<OHSAS> lista = new List<OHSAS>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_I_ListaOHSAS";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                OHSAS ent;
                int indice;
                while (reader.Read())
                {
                    ent = new OHSAS();
                    indice = reader.GetOrdinal("id_ohsas");
                    ent.id_ohsas = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("no_ohsas");
                    ent.no_ohsas = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);                    
                    lista.Add(ent);
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
            return lista;
        }
    }
}
