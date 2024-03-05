using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOAnuncios:ClsConexion
    {
        //Anuncio anidado con los empleados nuevos
        public String GetAnuncioIdMax()
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select MAX(Anuncio_Id) from I_Anuncios");
            String AnuncioIdMax = dt.Rows[0][0].ToString();
            dt.Dispose();
            return AnuncioIdMax;
        }

        public DataTable ListaAnunciosCompleto()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListAnunciosComplete");
        }

        public DataTable ListaAnunciosCompletoAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListAnunciosCompleteAll");
        }

        public List<Anuncios> GetAnunciosAll()
        {
            List<Anuncios> lista = new List<Anuncios>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListAnunciosAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Anuncios ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Anuncios();
                    indice = reader.GetOrdinal("Anuncio_Id");
                    ent.Anuncio_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Categoria_Auxiliar_Id");
                    ent.Categoria_Auxiliar_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Ruta_Foto");
                    ent.Ruta_Foto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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

        public DataTable ListaAnunciosAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListAnunciosAll");
        }
        public DataTable ListaAnunciosxId(Anuncios objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListAnunciosxId", objE.Anuncio_Id);
        }

        public DataTable ListaAnunciosxArea(Anuncios objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListAnunciosxArea", objE.Categoria_Auxiliar_Id);
        }

        public Int32 InsertAnuncios(Anuncios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertAnuncios", objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Ruta_Foto, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateAnuncios(Anuncios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateAnuncios", objE.Anuncio_Id, objE.Titulo, objE.Descripcion, objE.Categoria_Auxiliar_Id, objE.Ruta_Foto, objE.User_Name, objE.Fecha);
        }

        public bool Get_Existe_IdAnuncio(string id) {
            string sql = "select * from I_Anuncios where Anuncio_Id='" + id + "'";
            using (SqlConnection cn = new SqlConnection(Conexion())) {
                using (SqlCommand cmd = new SqlCommand(sql, cn)) {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla.Rows.Count>0 ? true: false;
                    }
                }
            }
        }

        public Int32 DeleteAnuncios(Anuncios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteAnuncios", objE.Anuncio_Id);
        }

        //---------- Cumpleanios del Mes

        public DataTable ListaCumpleDelMes()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_ListCumpleDelMes");
        }


    }
}
