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
    public class DAODocumentos:ClsConexion
    {
        public List<Documentos> GetDocumentosAll()
        {
            List<Documentos> lista = new List<Documentos>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListDocumentoAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Documentos ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Documentos();
                    indice = reader.GetOrdinal("Documento_Id");
                    ent.Documento_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaDocumentoAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListDocumentoAll");
        }
        public DataTable ListaDocumentoxId(Documentos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListDocumentoxId", objE.Documento_Id);
        }

        public DataTable ListaDocumentoxArea(Documentos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListDocumentoxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertDocumento(Documentos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertDocumento", objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateDocumento(Documentos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateDocumento", objE.Documento_Id, objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Nombre_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteDocumento(Documentos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteDocumento", objE.Documento_Id);
        }


    }
}
