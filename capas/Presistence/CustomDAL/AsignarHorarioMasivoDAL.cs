using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Presistence.Customs;

namespace Presistence.CustomDAL
{
    public class AsignarHorarioMasivoDAL
    {
        private static AsignarHorarioMasivoDAL Instance = null;
        public static AsignarHorarioMasivoDAL GetInstance()
        {
            return Instance == null ? Instance = new AsignarHorarioMasivoDAL() : Instance;
        }



        public List<string> usp_AsignaHorarioMasivo(string Personal_Id, int Horario_Id, int Cantidad, char Delimitador)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_AsignaHorarioMasivo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Horario_Id", Horario_Id);
                    cmd.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmd.Parameters.AddWithValue("@Delimitador", Delimitador);
                    List<string> rList = new List<string>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {                       
                        rList.Add(dr.GetValue(0).ToString());
                        rList.Add(dr.GetValue(1).ToString());                      

                    }
                    return rList;
                }
            }

        }

    }



    public class TbAsignarHorarioMasivo
    {
        public string Personal_Id { get; set; }
        public string Nombres { get; set; }
        public string Horario_Id { get; set; }
        public string Horario { get; set; }
        public string Localidad { get; set; }
        public string Seccion { get; set; }
        public string Area { get; set; }
    }


}
