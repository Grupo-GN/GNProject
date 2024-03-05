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
    public class DAOBeneficios:ClsConexion
    {
        public List<Beneficios> GetBeneficiosAll()
        {
            List<Beneficios> lista = new List<Beneficios>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListBeneficioAll";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Beneficios ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Beneficios();
                    indice = reader.GetOrdinal("Beneficio_Id");
                    ent.Beneficio_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Titulo");
                    ent.Titulo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Descripcion");
                    ent.Descripcion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Archivo");
                    ent.Nombre_Archivo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
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
        public DataTable ListaBeneficioAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBeneficioAll");
        }
        public DataTable ListaBeneficioxId(Beneficios objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBeneficioxId", objE.Beneficio_Id);
        }

        public Int32 InsertBeneficio(Beneficios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertBeneficio", objE.Titulo, objE.Descripcion, objE.Nombre_Archivo, objE.User_Name, objE.Fecha);
        }

        public Int32 UpdateBeneficio(Beneficios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateBeneficio", objE.Beneficio_Id, objE.Titulo, objE.Descripcion, objE.Nombre_Archivo, objE.User_Name, objE.Fecha);
        }

        public Int32 DeleteBeneficio(Beneficios objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteBeneficio", objE.Beneficio_Id);
        }


    }
}

