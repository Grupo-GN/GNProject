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
    public class DAOVideos:ClsConexion
    {
        public Int32 InsertVideos(String Titulo, String Nombre_Video, String User_Name)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "INSERT INTO I_Videos (Titulo, Nombre_Video, [User_Name], Fecha) VALUES ('" + Titulo + "','" + Nombre_Video + "','" + User_Name + "',GETDATE())");
        }
        public Int32 DeleteVideos(Int32 Video_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "DELETE FROM I_Videos WHERE Video_Id=" + Video_Id);
        }
        public List<Videos> GetVideosAll()
        {
            List<Videos> lista = new List<Videos>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Video_Id, Titulo, Nombre_Video, [User_Name], Convert(varchar(10),Fecha, 103) as Fecha FROM I_Videos";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Videos ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Videos();
                    indice = reader.GetOrdinal("Video_Id");
                    ent.Video_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Video");
                    ent.Nombre_Video = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListVideosAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "SELECT Video_Id, Titulo, Nombre_Video, [User_Name], Convert(varchar(10),Fecha, 103) as Fecha FROM I_Videos");
        }
        public DataTable ListVideosxId(Int32 Video_Id)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "SELECT Video_Id, Titulo, Nombre_Video, [User_Name], Convert(varchar(10),Fecha, 103) FROM I_Videos WHERE Video_Id=" + Video_Id);
        }

    }
}
