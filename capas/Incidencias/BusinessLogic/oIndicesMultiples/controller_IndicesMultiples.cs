using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Persistence.eConexion;
namespace BusinessLogic.oIndicesMultiples
{
    public class controller_IndicesMultiples
    {
        private static controller_IndicesMultiples Instance = null;
        public static controller_IndicesMultiples Get_Instance() {
            return Instance == null ? Instance = new controller_IndicesMultiples() : Instance;
        }

        public List<string> Get_Datos_Ejes(string Display,string tableFrom) {
            using (SqlConnection cn = new SqlConnection(conex.getConexion())) {
                using (SqlCommand cmd = new SqlCommand("GET_DATOS_EJES",cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DISPLAY", Display);
                    cmd.Parameters.AddWithValue("@FROM", tableFrom);
                    cn.Open();
                    List<string> rList = new List<string>();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        rList.Add(dr.GetValue(0).ToString());
                    }
                    return rList;
                }
                
            }
        }

        public ArrayList GENERAR_REPORTE_INCICE_MULTRIPLE(string select,string sqlSelect,string sjoin,string pin,string pFor,string pOrder)
        {
            using (SqlConnection cn = new SqlConnection(conex.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("GENERAR_REPORTE_INCICE_MULTRIPLE", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SELECT", select);
                    cmd.Parameters.AddWithValue("@sqlSELECT", sqlSelect);
                    cmd.Parameters.AddWithValue("@JOIN", sjoin);
                    cmd.Parameters.AddWithValue("@IN", pin);
                    cmd.Parameters.AddWithValue("@For", pFor);
                    cmd.Parameters.AddWithValue("@ORDER", pOrder);

                    cn.Open();
                    ArrayList rList = new ArrayList();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }

            }
        }
    }
}

