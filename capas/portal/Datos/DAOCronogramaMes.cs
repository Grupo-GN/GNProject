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
    public class DAOCronogramaMes:ClsConexion
    {
        public DataTable ListaCronogramaMes()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCronogramaMes");
        }
        public List<CronogramaMes> GetCronogramaMesAll()
        {
            List<CronogramaMes> lista = new List<CronogramaMes>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListCronogramaMesAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                CronogramaMes ent;
                int indice;
                while (reader.Read())
                {
                    ent = new CronogramaMes();
                    indice = reader.GetOrdinal("CronogramaMes_Id");
                    ent.CronogramaMes_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
                    indice = reader.GetOrdinal("Nombre_Foto");
                    ent.Nombre_Foto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaCronogramaMesAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCronogramaMesAll");
        }
        public DataTable ListaCronogramaMesxId(CronogramaMes objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCronogramaMesxId", objE.CronogramaMes_Id);
        }

        public Int32 InsertCronogramaMes(CronogramaMes objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertCronogramaMes", objE.Titulo, objE.Descripcion, objE.Ubicacion, objE.Categoria_Auxiliar_Id, objE.Fecha, objE.Hora_Inicio, objE.Hora_Final, objE.Nombre_Foto, objE.User_Name);
        }

        public Int32 UpdateCronogramaMes(CronogramaMes objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateCronogramaMes", objE.CronogramaMes_Id, objE.Titulo, objE.Descripcion, objE.Ubicacion, objE.Categoria_Auxiliar_Id, objE.Fecha, objE.Hora_Inicio, objE.Hora_Final, objE.Nombre_Foto, objE.User_Name);
        }

        public Int32 DeleteCronogramaMes(CronogramaMes objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteCronogramaMes", objE.CronogramaMes_Id);
        }

        public DataTable ListaCronogramaMesxArea(CronogramaMes objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListCronogramaMesxArea", objE.Categoria_Auxiliar_Id);
        }

    }
}
