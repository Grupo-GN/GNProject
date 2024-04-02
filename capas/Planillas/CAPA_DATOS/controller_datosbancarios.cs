using CAPA_ENTIDAD.EntMs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_datosbancarios
    {
        private static controller_datosbancarios instance = null;
        public static controller_datosbancarios getInstance()
        {
            return instance == null ? instance = new controller_datosbancarios() : instance;
        }
        private static int FINALROWS = 12;
        public List<ListaPersonal> Lista_Personal_DatosBancarios(string Periodo_Id, string NPersonal, string Localidad, string Proyecto,string Area, int inicio, out Int32 qt_registros)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalDatosBancarios", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Periodo", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_NPersonal", NPersonal);
                    cmd.Parameters.AddWithValue("@vi_Localidad", Localidad);
                    cmd.Parameters.AddWithValue("@vi_Proyecto", Proyecto);
                    cmd.Parameters.AddWithValue("@vi_Area", Area); 
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ListaPersonal> oLista = new List<ListaPersonal>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.ListaPersonal objPer = new CAPA_ENTIDAD.EntMs.ListaPersonal();
                        objPer.Personal_Id = dr.GetValue(0).ToString();
                        objPer.NPersonal = dr.GetValue(1).ToString();
                        objPer.TDocumento = dr.GetValue(2).ToString();
                        objPer.Nro_Doc = dr.GetValue(3).ToString();
                        objPer.TipoCta = dr.GetValue(4).ToString();
                        objPer.BancoCta = dr.GetValue(5).ToString();
                        objPer.TipoMoneda = dr.GetValue(6).ToString();
                        objPer.Nro_cta = dr.GetValue(7).ToString();
                        objPer.Nro_Cta_Inter = dr.GetValue(8).ToString();
                        objPer.Estado_Id = dr.GetValue(9).ToString();
                        oLista.Add(objPer);
                    }
                    qt_registros = oLista.Count();
                    return oLista.OrderBy(o => o.Apellido_Paterno).Skip(inicio).Take(FINALROWS).ToList();
                }
            }

        }
        public List<ListaPersonal> Lista_SelectsMantDatosBancarios()
        {
            string comando = "SELECT 'TC' [Tipo],TCB_Id [Id],Descripcion FROM Tipo_Cta_Bancaria UNION ALL ";
            comando += "SELECT 'BA',Banco_Id,Descripcion FROM Bancos UNION ALL ";
            comando += "SELECT 'TM',Moneda_Id,Descripcion FROM Moneda ";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ListaPersonal> oLista = new List<ListaPersonal>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.ListaPersonal objPer = new CAPA_ENTIDAD.EntMs.ListaPersonal();                        
                        objPer.TDocumento = dr.GetValue(0).ToString();
                        objPer.Personal_Id = dr.GetValue(1).ToString();
                        objPer.Nro_Doc = dr.GetValue(2).ToString();
                        oLista.Add(objPer);
                    }
                    return oLista.ToList();
                }
            }

        }
        public string GuardarDatosBancarios(string PersonalId, string TipoCta, string Banco, string Moneda, string NroCta, string NroCtaInter)
        {
            try
            {
                string comando = "UPDATE Personal SET Tip_cta_Id=@Tip_cta_Id,Banco_cta_Id=@Banco_cta_Id, ";
                comando += "Moneda_cta_Id =@Moneda_cta_Id,Nro_cta=@Nro_cta,Nro_cta_interbancaria=@Nro_cta_interbancaria ";
                comando += "WHERE Personal_Id = @Personal_Id";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@Tip_cta_Id", TipoCta);
                        cmd.Parameters.AddWithValue("@Banco_cta_Id", Banco);
                        cmd.Parameters.AddWithValue("@Moneda_cta_Id", Moneda);
                        cmd.Parameters.AddWithValue("@Nro_cta", NroCta);
                        cmd.Parameters.AddWithValue("@Nro_cta_interbancaria", NroCtaInter);
                        cmd.Parameters.AddWithValue("@Personal_Id", PersonalId);
                        int irows = cmd.ExecuteNonQuery();
                        return "true#" + irows.ToString() + " registro(s) actualizado(s).";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#Error: " + ex.Message;
            }
        }
    }
}
