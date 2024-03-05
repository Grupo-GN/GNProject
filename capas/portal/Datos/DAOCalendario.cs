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
    public class DAOCalendario:ClsConexion
    {
        public List<Calendario> GetCalendarioAll()
        {
            List<Calendario> lista = new List<Calendario>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListCalendarioAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Calendario ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Calendario();
                    indice = reader.GetOrdinal("Calendario_Id");
                    ent.Calendario_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Ubicacion");
                    ent.Ubicacion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Fecha");
                    ent.sFecha = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Hora_Inicio");
                    ent.sHora_Inicio = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Hora_Final");
                    ent.sHora_Final = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

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
        public DataTable ListaCalendarioAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCalendarioAll");
        }
        public DataTable ListaCalendarioxId(Calendario objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCalendarioxId", objE.Calendario_Id);
        }

        public Int32 InsertCalendario(Calendario objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertCalendario", objE.Titulo, objE.Descripcion, objE.Ubicacion, objE.Categoria_Auxiliar_Id, objE.Fecha, objE.Hora_Inicio, objE.Hora_Final, objE.User_Name);
        }

        public Int32 UpdateCalendario(Calendario objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateCalendario", objE.Calendario_Id, objE.Titulo, objE.Descripcion, objE.Ubicacion, objE.Categoria_Auxiliar_Id, objE.Fecha, objE.Hora_Inicio, objE.Hora_Final, objE.User_Name);
        }

        public Int32 DeleteCalendario(Calendario objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteCalendario", objE.Calendario_Id);
        }

        public DataTable ListaCalendarioxArea(Calendario objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCalendarioxArea", objE.Categoria_Auxiliar_Id);
        }

    }
}
