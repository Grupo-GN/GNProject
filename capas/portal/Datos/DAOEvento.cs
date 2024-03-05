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
    public class DAOEvento:ClsConexion
    {

        public Int32 MaxEventoId()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select MAX(Evento_Id) from I_Evento");
                if (dt.Rows.Count > 0)
                {
                    dt.Dispose();
                    return Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                else
                {
                    throw new Exception("Error: No Existe Ningun Evento");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Evento> GetEventosAll()
        {
            List<Evento> lista = new List<Evento>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListEventoAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Evento ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Evento();
                    indice = reader.GetOrdinal("Evento_Id");
                    ent.Evento_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("NomFotoEvento");
                    ent.NomFotoEvento = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaEventoAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListEventoAll");
        }        
        public DataTable ListaEventoxEventoId(Evento objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListEventoxId", objE.Evento_Id);
        }
        public Int32 InsertEvento(Evento objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEvento", objE.Titulo, objE.Descripcion, objE.User_Name, objE.Fecha, objE.NomFotoEvento);
        }
        public Int32 UpdateEvento(Evento objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateEvento", objE.Evento_Id, objE.Titulo, objE.Descripcion, objE.User_Name, objE.Fecha, objE.NomFotoEvento);
        }
        public Int32 DeleteEvento(Evento objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteEvento", objE.Evento_Id);
        }

    }
}
