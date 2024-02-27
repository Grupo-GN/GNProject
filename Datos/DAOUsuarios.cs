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
    public class DAOUsuarios : ClsConexion
    {
        public Int32 GetTotalVisitas()
        {
            DataTable dt = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select sum(isnull(nu_ingresos, 0)) as [total_visitas] from I_Users");
            return Convert.ToInt32(dt.Rows[0]["total_visitas"]);
        }
        public Int32 UpdateContrasenia(Usuarios objUsu)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateUserClave", objUsu.User_Id, objUsu.Password);
        }

        public Int32 AddUsers(Usuarios objUsu)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IAddUsers", objUsu.Planilla_Id, objUsu.Personal_Id, objUsu.User_Name, objUsu.Password, objUsu.Ruta_Foto, objUsu.Permiso_Id, objUsu.Email, objUsu.Categoria_Auxiliar_Id, objUsu.Categoria_Auxiliar2_Id, objUsu.Estado_Id);
        }

        public Int32 UpdateUsers(Usuarios objUsu)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateUsers", objUsu.User_Id, objUsu.Password, objUsu.Ruta_Foto, objUsu.Permiso_Id, objUsu.Email, objUsu.Estado_Id);
        }

        public Int32 UpdateUsersFoto(String User_Id, String Ruta_Foto)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Update I_Users Set Ruta_Foto='" + Ruta_Foto + "' where User_Id='" + User_Id + "'");
        }

        public Int32 DeleteUsers(Usuarios objUsu)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteUsers", objUsu.User_Id);
        }

        public DataTable ValidaLogin(Usuarios objUsu)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IValidaLogin", objUsu.User_Name, objUsu.Password);
        }

        public void ActualizaVisitasIntranet(String User_Id)
        {
            SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "update I_Users set nu_ingresos = isnull(nu_ingresos,0) + 1 where User_Id = '" + User_Id + "'");
        }

        public DataTable ListaUsers(Usuarios objUsu)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaUsers", objUsu.User_Name);
        }

        public List<Usuarios> GetUsuariosxFiltro(Int32 TipoBusqueda, String ValorOpcional)
        {
            List<Usuarios> lista = new List<Usuarios>();

            SqlConnection cn = new SqlConnection(Conexion());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_IListaUsersxFiltro";
            cmd.Parameters.AddWithValue("@TipoBusqueda", TipoBusqueda);
            cmd.Parameters.AddWithValue("@ValorOpcional", ValorOpcional);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();
                Usuarios ent;
                int indice;
                while (reader.Read())
                {
                    ent = new Usuarios();
                    indice = reader.GetOrdinal("User_Id");
                    ent.User_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("User_Name");
                    ent.User_Name = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Password");
                    ent.Password = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Nombre_Completo");
                    ent.Nombre_Completo = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Permiso_Id");
                    ent.Permiso_Id = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);
                    indice = reader.GetOrdinal("Permiso");
                    ent.Permiso = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Email");
                    ent.Email = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Ruta_Foto");
                    ent.Ruta_Foto = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Periodo_Id");
                    ent.Periodo_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Planilla_Id");
                    ent.Planilla_Id = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Tipo_Trabajador");
                    ent.Tipo_Trabajador = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Localidad");
                    ent.Localidad = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Area");
                    ent.Area = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("Seccion");
                    ent.Seccion = reader.IsDBNull(indice) ? String.Empty : reader.GetString(indice);
                    indice = reader.GetOrdinal("nu_ingresos");
                    ent.nu_ingresos = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

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

        public DataTable ListaUsersxFiltro(Int32 TipoBusqueda, String ValorOpcional)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaUsersxFiltro", TipoBusqueda, ValorOpcional);
        }

        public DataTable ListaUserxId(Usuarios objUsu)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaUserxId", objUsu.User_Id);
        }

        public DataTable ListaUserxUserName(Usuarios objUsu)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaUserxUserName", objUsu.User_Name);
        }

        public DataTable ListaUserxPersonal_Id(String Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select * from I_Users where Personal_Id='" + Personal_Id + "'");
        }



    }
}
