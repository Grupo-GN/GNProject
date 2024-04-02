using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class Calculos_PermDA
    {
        public static Calculos_PermDA oControllerInstance = null;
        public Calculos_PermDA(){}
        public static Calculos_PermDA Create()
        {
            if (oControllerInstance == null)
            {  
                oControllerInstance = new Calculos_PermDA();
            }
            return  oControllerInstance;
        }

        public Int32 InsertCalculos_Perm(List<Calculos_PermBE> lstCalculos_PermBE)
        {
            using(SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString)){

                using (SqlCommand cmd = new SqlCommand("usp_RSInsertCalculos_Perm", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    int RES = 0;
                    foreach (Calculos_PermBE item in lstCalculos_PermBE)
                    {
                        cmd.Parameters.Clear();

                        if (item.Concepto_Id == "001042")
                        {
                            string ff = "";
                            ff = "ddd";
                        }

                        cmd.Parameters.AddWithValue("@planilla_id", item.Planilla_id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", item.Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", item.Personal_Id);
                        cmd.Parameters.AddWithValue("@Concepto_Id", item.Concepto_Id);
                        cmd.Parameters.AddWithValue("@Proceso_Id", item.Proceso_Id);
                        cmd.Parameters.AddWithValue("@Valor", item.Valor);

                        RES += cmd.ExecuteNonQuery();
                    }

                    cn.Close();
                    cn.Dispose();
                    return RES;
                }
        }

        }
    }
}
