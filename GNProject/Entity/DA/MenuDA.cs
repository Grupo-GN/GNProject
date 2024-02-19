using GNProject.Acceso;
using GNProject.Entity.Menu;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GNProject.Entity.DA
{
    public class MenuDA
    {
        //SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public MenuBEList Get_Menu()
        {
            MenuBEList lista = new MenuBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "gn_sps_menu";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(CrearEntidad_ListarMenu(reader));
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
        static string ConvertEntityConnectionStringToSqlConnection(string entityConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            string providerConnectionString = entityBuilder.ProviderConnectionString;

            builder.ConnectionString = providerConnectionString;

            return builder.ConnectionString;
        }
        public MenuBEList Get_MenuxPerfil(Int32 id_perfil, String fl_con_padres = "")
        {
            MenuBEList lista = new MenuBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "gn_sps_menuxPerfil";

            SqlPara = new SqlParameter("@vi_id_perfil", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = id_perfil;
            cmd.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vi_fl_con_padres", SqlDbType.Char, 1);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = fl_con_padres;
            cmd.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(CrearEntidad_ListarMenu(reader));
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

        private MenuBE CrearEntidad_ListarMenu(IDataReader DReader)
        {
            MenuBE oMenuBE = new MenuBE();
            int indice;

            indice = DReader.GetOrdinal("id_menu");
            oMenuBE.id_menu = DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice);

            indice = DReader.GetOrdinal("tx_descripcion");
            oMenuBE.tx_descripcion = DReader.IsDBNull(indice) ? string.Empty : DReader.GetString(indice);

            indice = DReader.GetOrdinal("url_pagina");
            oMenuBE.url_pagina = DReader.IsDBNull(indice) ? string.Empty : DReader.GetString(indice);

            indice = DReader.GetOrdinal("id_padre");
            oMenuBE.id_padre = DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice);

            indice = DReader.GetOrdinal("nu_orden");
            oMenuBE.nu_orden = DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice);

            indice = DReader.GetOrdinal("id_seccion");
            oMenuBE.id_seccion = DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice);

            return oMenuBE;
        }

        public MenuBEList Get_MenuCtrlAsisxPerfi(Int32 id_perfil, String fl_con_padres = "")
        {
            MenuBEList lista = new MenuBEList();
            string ruc = ClaseGlobal.Get_RUC_usuario();
            String codEmpresaConnection = "ContextMaestro_" + ruc;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            SqlConnection cn = new SqlConnection(sqlConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "gn_sps_menuxPerfil";

            SqlPara = new SqlParameter("@vi_id_perfil", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = id_perfil;
            cmd.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vi_fl_con_padres", SqlDbType.Char, 1);
            SqlPara.Direction = ParameterDirection.Input;
            SqlPara.Value = fl_con_padres;
            cmd.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(CrearEntidad_ListarMenu(reader));
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
    }
}