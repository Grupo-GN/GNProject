using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


using System.Web.Configuration;

namespace Capas.Portal.Datos
{
    public class ClsConexion
    {

        protected String Conexion()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            string codEmpresaConnection = "ContextMaestro_" + rucEmpresa;
            string connectionString = ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;
            string sqlConnectionString = ConvertEntityConnectionStringToSqlConnection(connectionString);

            //String Conexion;
            //Conexion = WebConfigurationManager.ConnectionStrings["ContextMaestro_20604740097"].ConnectionString;
            return sqlConnectionString;     
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
