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
    public class DAONormativas:ClsConexion
    {
        public List<Normativas> GetNormativasAll()
        {
            List<Normativas> lista = new List<Normativas>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListNormativaAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Normativas ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Normativas();
                    indice = reader.GetOrdinal("Normativa_Id");
                    ent.Normativa_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Doc");
                    ent.Nombre_Doc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Fecha");
                    ent.sFecha = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    
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
        public DataTable ListaNormativaAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListNormativaAll");
        }
        public DataTable ListaNormativaxId(Normativas objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListNormativaxId", objE.Normativa_Id);
        }

        public DataTable ListaNormativaxArea(Normativas objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListNormativaxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertNormativa(Normativas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertNormativa", objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateNormativa(Normativas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateNormativa", objE.Normativa_Id, objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteNormativa(Normativas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteNormativa", objE.Normativa_Id);
        }


    }
}
