using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;
using System.Data.SqlClient;

namespace Capas.Portal.Datos
{
    public class DAOFaq:ClsConexion
    {

        public void UpdateOrden(String Faq_Id, Int32 SortOrder)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Update I_Faq SET SortOrder=" + SortOrder + " where Faq_Id='" + Faq_Id + "'");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Faq> GetFaqAll()
        {
            List<Faq> lista = new List<Faq>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListFAQAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Faq ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Faq();
                    indice = reader.GetOrdinal("Faq_Id");
                    ent.Faq_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Pregunta");
                    ent.Pregunta = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Respuesta");
                    ent.Respuesta = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Fecha");
                    ent.sFecha = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("SortOrder");
                    ent.SortOrder = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

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
        public DataTable ListaFaqAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListFAQAll");
        }
        public DataTable ListaFaqxId(Faq objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListFAQxId", objE.Faq_Id);
        }

        public DataTable ListaFaqxArea(Faq objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListFAQxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertFaq(Faq objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertFAQ", objE.Pregunta, objE.Respuesta, objE.Categoria_Auxiliar_Id, objE.Fecha);
        }

        public Int32 UpdateFaq(Faq objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateFAQ", objE.Faq_Id, objE.Pregunta, objE.Respuesta, objE.Categoria_Auxiliar_Id, objE.Fecha);
        }

        public Int32 DeleteFaq(Faq objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteFAQ", objE.Faq_Id);
        }


    }
}
