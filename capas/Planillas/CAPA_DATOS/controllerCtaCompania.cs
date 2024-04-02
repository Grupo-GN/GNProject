using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CAPA_DATOS
{
    public class controllerCtaCompania
    {
        private static controllerCtaCompania instance = null;
        public static controllerCtaCompania getinstance()
        {
            return instance == null ? instance = new controllerCtaCompania() : instance;
        }

        public List<eCta_Compania> ListarCtasCompania(string xcompania)
        {
            List<eCta_Compania> rList = new List<eCta_Compania>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "SELECT C.Compania_Id+'|'+C.Banco_Id+'|'+C.Moneda_Id [Codigo],B.Descripcion [Banco],M.Descripcion [Moneda],C.Nro_Cuenta, C.Banco_Id , C.Moneda_Id ";
                comando += "FROM Compania_Ctas_Bancarias C INNER JOIN BANCOS B ON C.Banco_Id=B.Banco_Id ";
                comando += "INNER JOIN MONEDA M ON C.Moneda_Id=m.Moneda_Id ";
                comando += "WHERE C.Compania_Id='" + xcompania + "' ";
                comando += "ORDER BY 1 ASC,2 DESC";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        eCta_Compania obj = new eCta_Compania();
                        obj.Codigo = dr.GetValue(0).ToString();
                        obj.Banco = dr.GetValue(1).ToString();
                        obj.Moneda = dr.GetValue(2).ToString();
                        obj.NroCta = dr.GetValue(3).ToString();
                        obj.Banco_Id = dr.GetValue(4).ToString();
                        obj.Moneda_Id = dr.GetValue(5).ToString();
                        rList.Add(obj);
                    }
                }
            }
            return rList;
        }

        public Dictionary<string,string> ListarBancos() {
            Dictionary<string, string> rlist = new Dictionary<string, string>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Banco_Id,Descripcion FROM Bancos ORDER BY Descripcion";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rlist.Add(dr.GetValue(0).ToString(), dr.GetValue(1).ToString());
                    }
                    return rlist;
                }
            }        
        }
        public Dictionary<string, string> ListarMoneda()
        {
            Dictionary<string, string> rlist = new Dictionary<string, string>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Moneda_Id,Descripcion FROM MONEDA ORDER BY Descripcion";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rlist.Add(dr.GetValue(0).ToString(), dr.GetValue(1).ToString());
                    }
                    return rlist;
                }
            }
        }

        public eCta_Compania GetCuentaEdit(string xcompania,string xbanco,string xmoneda)
        {
            eCta_Compania obj = null;
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                string comando = "SELECT Compania_Id,Banco_Id,Moneda_Id,Nro_Cuenta FROM Compania_Ctas_Bancarias ";
                comando += "WHERE Compania_Id=@Compania_Id AND Banco_Id=@Banco_Id AND Moneda_Id=@Moneda_Id ";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Compania_Id", xcompania);
                    cmd.Parameters.AddWithValue("@Banco_Id", xbanco);
                    cmd.Parameters.AddWithValue("@Moneda_Id", xmoneda);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj = new eCta_Compania();
                        obj.Compania_Id = dr.GetValue(0).ToString();
                        obj.Banco_Id = dr.GetValue(1).ToString();
                        obj.Moneda_Id = dr.GetValue(2).ToString();
                        obj.NroCta = dr.GetValue(3).ToString();
                        
                    }
                }
            }
            return obj;
        }

        public string RegistrarNumeroCta(string xcompania,string xbanco,string xmoneda,string xnrocta) {
            string resultado = "false#";
            if (GetCuentaEdit(xcompania, xbanco, xmoneda) != null)
            {
                resultado = "false#Ya existe una cuenta para el banco y moneda seleccionado.";
            }
            else {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    string comando = "INSERT INTO Compania_Ctas_Bancarias (Compania_Id,Banco_Id,Moneda_Id,Nro_Cuenta) ";
                    comando += "VALUES (@Compania_Id,@Banco_Id,@Moneda_Id,@Nro_Cuenta)";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Compania_Id", xcompania);
                        cmd.Parameters.AddWithValue("@Banco_Id", xbanco);
                        cmd.Parameters.AddWithValue("@Moneda_Id", xmoneda);
                        cmd.Parameters.AddWithValue("@Nro_Cuenta", xnrocta);
                        cn.Open();
                        int iros = cmd.ExecuteNonQuery();
                        if (iros > 0)
                        {
                            resultado = "true#Información registrada correctamente.";
                        }
                        else {
                            resultado = "true#La información no fue registrada, intentelo nuevamente o contacte con el área de soporte.";
                        }
                    }
                }
            }
            return resultado;
        }
        public string ActualizarNumeroCta(string xcompania, string xbanco, string xmoneda, string xnrocta)
        {
            string resultado = "false#";
            
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    string comando = "UPDATE Compania_Ctas_Bancarias SET Nro_Cuenta=@Nro_Cuenta ";
                    comando += "WHERE Compania_Id=@Compania_Id AND Banco_Id=@Banco_Id AND Moneda_Id=@Moneda_Id ";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Compania_Id", xcompania);
                        cmd.Parameters.AddWithValue("@Banco_Id", xbanco);
                        cmd.Parameters.AddWithValue("@Moneda_Id", xmoneda);
                        cmd.Parameters.AddWithValue("@Nro_Cuenta", xnrocta);
                        cn.Open();
                        int iros = cmd.ExecuteNonQuery();
                        if (iros > 0)
                        {
                            resultado = "true#Información actualizada correctamente.";
                        }
                        else
                        {
                            resultado = "true#La información no fue actualizada, intentelo nuevamente o contacte con el área de soporte.";
                        }
                    }
                }
            
            return resultado;
        }
    }

    public class eCta_Compania{
        public string Compania_Id { get; set; }
        public string Codigo { get; set; }
        public string Banco_Id { get; set; }
        public string Banco { get; set; }
        public string Moneda_Id { get; set; }
        public string Moneda { get; set; }
        public string NroCta { get; set; }
    }
}
