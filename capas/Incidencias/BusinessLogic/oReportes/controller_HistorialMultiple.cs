using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.eConexion;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace BusinessLogic.oReportes
{
    public class controller_HistorialMultiple
    {
        private static controller_HistorialMultiple Instance = null;
        public static controller_HistorialMultiple Get_Instance() {
            return Instance == null ? Instance = new controller_HistorialMultiple() : Instance;
        }

        public ArrayList GENERAR_REPORTE_HISTORIAL_MULTIPLE_WPP(string select,string joins,string where)
        {
            using (SqlConnection cn = new SqlConnection(conex.getConexion())) {
                using (SqlCommand cmd = new SqlCommand("SP_GENERAR_REPORTE_HISTORIAL_MULTIPLE_WPP", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SELECT", select);
                    cmd.Parameters.AddWithValue("@JOIN", joins);
                    cmd.Parameters.AddWithValue("@WHERE", where);
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
