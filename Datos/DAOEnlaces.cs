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
    public class DAOEnlaces:ClsConexion
    {
        public List<Enlace> GetEnlacesAll(String User_Id)
        {
            List<Enlace> lista = new List<Enlace>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "declare @Permiso_Id int; select @Permiso_Id = Permiso_Id from I_Users where User_Id = '" + User_Id + "'; " +
                " if(@Permiso_Id = 1) begin select Enlace_Id, Nom_Enlace, Direccion, fl_visible_admin from I_Enlaces order by Nom_Enlace ASC; end" +
                " else begin select Enlace_Id, Nom_Enlace, Direccion, fl_visible_admin from I_Enlaces where fl_visible_admin = 0 order by Nom_Enlace ASC; end";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Enlace ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Enlace();
                    indice = reader.GetOrdinal("Enlace_Id");
                    ent.Enlace_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Nom_Enlace");
                    ent.Nom_Enlace = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Direccion");
                    ent.Direccion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("fl_visible_admin");
                    ent.fl_visible_admin = reader.IsDBNull(indice) ? false : reader.GetBoolean(indice);
                    
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
        public DataTable ListaEnlacesAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select Enlace_Id, Nom_Enlace, Direccion from I_Enlaces order by Nom_Enlace ASC");
        }
        public DataTable ListaEnlacesxId(Int32 Enlace_Id)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select Enlace_Id, Nom_Enlace, Direccion, fl_visible_admin from I_Enlaces where Enlace_Id = " + Enlace_Id);
        }
        public Int32 InsertEnlace(String Nom_Enlace, String Direccion, Boolean fl_VisibleSoloAdmin)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Insert into I_Enlaces (Nom_Enlace, Direccion, fl_visible_admin) values ('" + Nom_Enlace + "','" + Direccion + "', " + (fl_VisibleSoloAdmin ? 1 : 0) + ")");
        }
        public Int32 UpdateEnlace(Int32 Enlace_Id, String Nom_Enlace, String Direccion, Boolean fl_VisibleSoloAdmin)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Update I_Enlaces SET Nom_Enlace='" + Nom_Enlace + "', Direccion='" + Direccion + "', fl_visible_admin=" + (fl_VisibleSoloAdmin ? 1 : 0) + " where Enlace_Id=" + Enlace_Id);
        }
        public Int32 DeleteEnlace(Int32 Enlace_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Delete from I_Enlaces where Enlace_Id=" + Enlace_Id);
        }

    }
}
