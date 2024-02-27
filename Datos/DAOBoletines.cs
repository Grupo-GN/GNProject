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
    public class DAOBoletines : ClsConexion
    {
        public List<Boletines> GetBoletinesAll()
        {
            List<Boletines> lista = new List<Boletines>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListBoletinesAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Boletines ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Boletines();
                    indice = reader.GetOrdinal("Boletin_Id");
                    ent.Boletin_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Img_Mostrar");
                    ent.Img_Mostrar = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Ruta_Doc");
                    ent.Ruta_Doc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Tipo_Doc");
                    ent.Tipo_Doc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaBoletinesAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBoletinesAll");
        }
        public DataTable ListaBoletinesxId(Boletines objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBoletinesxId", objE.Boletin_Id);
        }

        public DataTable ListaBoletinesxArea(Boletines objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBoletinesxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertBoletines(Boletines objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertBoletines", objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Img_Mostrar, objE.Ruta_Doc, objE.Tipo_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateBoletines(Boletines objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateBoletines", objE.Boletin_Id, objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Img_Mostrar, objE.Ruta_Doc, objE.Tipo_Doc, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteBoletines(Boletines objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteBoletines", objE.Boletin_Id);
        }


    }
}
