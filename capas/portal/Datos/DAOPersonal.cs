using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Entidad;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Capas.Portal.Datos
{
    public class DAOPersonal:ClsConexion 
    {

        public DataTable ListaCumpleDelDia()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaCumpleDelDia");
        }

        public DataTable ListaDirectorioEmp(String Nombres)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaDirectorioEmp", Nombres);
        }

        public List<Personal> GetDirectorioEmpxFiltros(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Nombres)
        {
            List<Personal> lista = new List<Personal>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListaDirectorioEmpxFiltros";
            cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
            cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
            cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
            cmd.Parameters.AddWithValue("@FiltroNombres", Nombres);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Personal ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Personal();
                    indice = reader.GetOrdinal("Personal_Id");
                    ent.Personal_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Ruta_Foto");
                    ent.Ruta_Foto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Completo");
                    ent.Nombre_Completo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Telefono");
                    ent.Telefono = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Telefono2");
                    ent.Telefono2 = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Telefono3");
                    ent.Telefono3 = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nro_Doc");
                    ent.Nro_Doc = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Planilla_Id");
                    ent.Planilla_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Periodo_Id");
                    ent.Periodo_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Email");
                    ent.Email = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Localidad");
                    ent.Localidad = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Seccion");
                    ent.Seccion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);

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
        public DataTable ListaDirectorioEmpxFiltros(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Nombres)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaDirectorioEmpxFiltros", Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Nombres);
        }

        public DataTable ListaDistribucionxArea()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IDistribucioxArea");
        }

        public DataTable ListaPersonalAll()
        {
            String Script;
            Script = "select Personal_Id, (Apellido_Paterno+' '+Apellido_Materno+', '+Nombres) as [Nombre_Completo] from Personal where Estado_Id='01' order by Nombre_Completo ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Script, Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }

        public DataTable ListaPersonal(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Categoria_Auxiliar2_Id)
        {
            String Script;
            Script = "select personal_id,lower(Nombre_Completo) as [Nombre_Completo],Nro_Doc,Periodo_Id,Localidad,Area,Seccion from vwFPS_Personal_Periodo " +
                " where Planilla_id='" + Planilla_Id + "' and Periodo_Id=(select max(Periodo_Id) from vwFPS_Personal_Periodo where Planilla_id='" + Planilla_Id + "') " +
                " and area_id='" + Area_Id + "' and Categoria_Auxiliar_id='" + Categoria_Auxiliar_Id + "' and Categoria_Auxiliar2_Id ='" + Categoria_Auxiliar2_Id + "' " +
                " order by Nombre_Completo ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(Script, Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }

        public DataTable ListaPersonalxId(String Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaPersonalxId", Personal_Id);
        }

    }
}
