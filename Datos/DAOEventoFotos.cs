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
    public class DAOEventoFotos:ClsConexion
    {
        public List<EventoFotos> GetEventoFotosxEventoID(Int32 Evento_Id)
        {
            List<EventoFotos> lista = new List<EventoFotos>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListEventoFotosxEventoId";
            cmd.Parameters.AddWithValue("@Evento_Id", Evento_Id);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                EventoFotos ent;
                int indice;
                while (reader.Read())
                {
                    ent = new EventoFotos();
                    indice = reader.GetOrdinal("EventoFotos_Id");
                    ent.EventoFotos_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Evento_Id");
                    ent.Evento_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Nombre_Foto");
                    ent.Nombre_Foto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaEventoFotosxEventoId(EventoFotos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListEventoFotosxEventoId", objE.Evento_Id);
        }
        public Int32 InsertEventoFotos(EventoFotos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEventoFotos", objE.Nombre_Foto, objE.Evento_Id);
        }
        public Int32 DeleteEventoFotos(EventoFotos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteEventoFotos", objE.EventoFotos_Id);
        }
    }
}
