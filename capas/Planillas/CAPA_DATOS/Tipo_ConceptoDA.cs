using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class Tipo_ConceptoDA
    {
        public static Tipo_ConceptoDA oControllerInstance = null;
        public static Tipo_ConceptoDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new Tipo_ConceptoDA();
            }
            return oControllerInstance;
        }

        public DataTable GetTipo_Conceptos()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetTipoConceptos", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cn.Close();
                        return dt;
                    }
                }
            }
        }
    }
}
