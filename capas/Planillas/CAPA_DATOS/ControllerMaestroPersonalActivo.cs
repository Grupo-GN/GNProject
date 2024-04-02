using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace CAPA_DATOS
{
    public class ControllerMaestroPersonalActivo
    {
        private static ControllerMaestroPersonalActivo Instance = null;
        public static ControllerMaestroPersonalActivo GetInstance()
        {
            return Instance == null ? Instance = new ControllerMaestroPersonalActivo() : Instance;
        }
        public ArrayList Lista_Personal_Faltante_Periodo( string Periodo, string Personal)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("Movimiento_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nro", 1);
                    cmd.Parameters.AddWithValue("@Periodo", Periodo);
                    cmd.Parameters.AddWithValue("@Personal", Personal);
                    
                    ArrayList rList = new ArrayList();
                    cn.Open();
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
        public int Agrega_Personal_al_Periodo(string Periodo, string Personal)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("Movimiento_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nro", 2);
                    cmd.Parameters.AddWithValue("@Periodo", Periodo);
                    cmd.Parameters.AddWithValue("@Personal", Personal);

                    
                    cn.Open();
                    
                    return cmd.ExecuteNonQuery();

                }
            }
        }
        public int Elimina_Personal_de_Periodo(string Periodo, string Personal)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("Movimiento_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nro", 3);
                    cmd.Parameters.AddWithValue("@Periodo", Periodo);
                    cmd.Parameters.AddWithValue("@Personal", Personal);
                  
                    cn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
