using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Views.sistemaPlanillas.code
{
    public class ClaseGlobal
    {
        public static String getUsuarioLogin() //Login
        {
            String[] arr_Usuario_Perfil = HttpContext.Current.User.Identity.Name.Split('|');
            String login = arr_Usuario_Perfil[0].ToString();
            return login;
        }
        public static String getRUCEmpresa()
        {
            String[] arr_Usuario_Perfil = System.Web.HttpContext.Current.User.Identity.Name.Split('|');
            String rucEmpresa = String.Empty;
            if (arr_Usuario_Perfil != null && arr_Usuario_Perfil.Length > 0) { rucEmpresa = arr_Usuario_Perfil[5].ToString(); }
            return rucEmpresa;
        }
        public static String getEstacionRed()
        {
            String no_estacion_red = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_HOST"];
            return no_estacion_red;
        }
        public static String getUsuarioRed()
        {
            String no_usuario_red = System.Web.HttpContext.Current.Request.ServerVariables["LOGON_USER"];
            return no_usuario_red;
        }

        private static String getCodEmpresaConnection()
        {
            String codEmpresaConnection = String.Empty;
            String rucEmpresa = getRUCEmpresa();
            if (!String.IsNullOrEmpty(rucEmpresa)) { codEmpresaConnection = "conexion_" + rucEmpresa; }
            return codEmpresaConnection;
        }

        public static Guid Guid_Generate()
        {
            var buffer = Guid.NewGuid().ToByteArray();

            var time = new DateTime(0x76c, 1, 1);
            var now = DateTime.Now;
            var span = new TimeSpan(now.Ticks - time.Ticks);
            var timeOfDay = now.TimeOfDay;

            var bytes = BitConverter.GetBytes(span.Days);
            var array = BitConverter.GetBytes(
                (long)(timeOfDay.TotalMilliseconds / 3.333333));

            Array.Reverse(bytes);
            Array.Reverse(array);
            Array.Copy(bytes, bytes.Length - 2, buffer, buffer.Length - 6, 2);
            Array.Copy(array, array.Length - 4, buffer, buffer.Length - 4, 4);

            return new Guid(buffer);
        }

        /// <summary>
        /// Changes the database a table adapter connects to
        /// </summary>
        /// <typeparam name="TA">The type of table adater</typeparam>
        /// <param name="TableAdapter">The instance of the table adapter</param>
        /// <param name="timeout">The new timeout (In seconds)</param>
        public static void ChangeTableAdapterConnection_x_Empresa<TA>(ref TA TableAdapter)
        {
            String codEmpresaConnection = ClaseGlobal.getCodEmpresaConnection();
            System.Data.SqlClient.SqlConnection newSQLConnection = new System.Data.SqlClient.SqlConnection();
            newSQLConnection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;

            var commands = TableAdapter.GetType().InvokeMember(
                    "CommandCollection",
                    System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                    null, TableAdapter, new object[0]);
            var sqlCommand = (System.Data.SqlClient.SqlCommand[])commands;
            foreach (var cmd in sqlCommand)
            {
                cmd.Connection = newSQLConnection;
            }
        }
    }
}