using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence.Customs;
using System.Data;
using System.Data.SqlClient;
namespace Presistence.CustomDAL
{
    public class customParamentroPersonal
    {
        private static customParamentroPersonal Instance = null;
        public static customParamentroPersonal GetInstance(){
            return Instance == null ? Instance = new customParamentroPersonal() : Instance;
        }

        public List<eParamentros> Get_Parametros_Personal(string Personal_Id) { 
            using(SqlConnection cn=new SqlConnection(Conexion.getConexion())){
                using(SqlCommand cmd=new SqlCommand("usp_SelectParametrosxPersona_Faltantes",cn)){

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id",Personal_Id);
                    List<eParamentros> rList = new List<eParamentros>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read()){
                        eParamentros obj = new eParamentros();
                        obj.Parametro_Id = dr.GetValue(0).ToString();   
                        obj.Descripcion = dr.GetValue(1).ToString();
                        obj.Variable = dr.GetValue(2).ToString();
                        obj.Valor = dr.GetValue(3).ToString();
                        obj.Tipo = dr.GetValue(4).ToString();
                        rList.Add(obj);
                    }


                    return rList;
                }  
            }
        }

        
    }

    public class eParamentros{
        public string Parametro_Id { get; set; }
        public string Descripcion { get; set; }
        public string Variable { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
    }
}
