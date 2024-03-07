using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlDocumentos.DA
{
    public static class DataBaseHelper
    {
        public static string GetDbProvider()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            string codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            return System.Configuration.ConfigurationManager.ConnectionStrings[sqlConnectionString].ProviderName;
        }
        public static string GetDbConnectionString()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            string codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            return sqlConnectionString;
        }
        public static SqlConnection GetDbSqlConnection()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            string codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[sqlConnectionString].ConnectionString);
        }
        static string ConvertEntityConnectionStringToSqlConnection(string entityConnectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(entityConnectionString);
            string providerConnectionString = entityBuilder.ProviderConnectionString;

            builder.ConnectionString = providerConnectionString;

            return builder.ConnectionString;
        }
    }
}
