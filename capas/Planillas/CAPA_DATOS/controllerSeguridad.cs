using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class controllerSeguridad
    {
        private static controllerSeguridad instance = null;
        public static controllerSeguridad getinstance() {
            return instance == null ? instance = new controllerSeguridad() : instance;
        }
        public string ObtenerLlave()
        {
            string llave = "", razon = "", ruc = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Descripcion,Ruc FROM Compania WHERE Compania_Id='01'";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        razon = dr.GetValue(0).ToString();
                        ruc = dr.GetValue(1).ToString();
                    }
                }
            }
            llave = ruc.Substring(0, 3).Trim();
            llave += razon.Substring(razon.Length - 4, 4).Trim();
            llave += ruc.Substring(ruc.Length - 3, 2).Trim();
            llave += razon.Substring(0, 3).Trim();
            llave = llave.ToUpper();
            return llave;
        }
        public string ObtenerUsuario(string usu)
        {
            string resultado = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "select * from Usuarios_GN where NombreUsuario='" + usu + "'";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        resultado = dr.GetValue(1).ToString();
                    }
                }
            }
            return resultado;
        }
    }
}
