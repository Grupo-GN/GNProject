using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public class Dao_D_Fijos_2
    {
        private static Dao_D_Fijos_2 instance = null;
        public static Dao_D_Fijos_2 getinstance()
        {
            return instance == null ? instance = new Dao_D_Fijos_2() : instance;
        }
        public DataTable ActualizarDatoPorPersonaV2(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspActualizarDatosPorPersona", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PeriodoId", PeriodoId);
                    cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                    cmd.Parameters.AddWithValue("@ConceptoId", ConceptoId);
                    cmd.Parameters.AddWithValue("@Valor", Valor);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        cn.Dispose();
                        return dt;
                    }
                }
            }
        }
    }
}
