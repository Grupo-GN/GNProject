using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class PersonalDA
    {
        public static PersonalDA oControllerInstance = null;
        public static PersonalDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new PersonalDA();
            }
            return oControllerInstance;
        }

        public DataTable GetPersonalActivo(string Periodo_Id, string Area_Id = "", string Categoria_Auxiliar_Id = "")
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_RSPersonalActivo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
                    cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);

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

        public DataTable GetPersonalActivoxProceso(string Periodo_Id, string Area_Id, string Categoria_Auxiliar_Id, string Proceso_Id,string Proyecto_Id, string Personal_Ids
            , string flIncluyeCesados)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_RSPersonalActivoxProceso", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
                    cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                    cmd.Parameters.AddWithValue("@Proyecto_Id", Proyecto_Id);
                    cmd.Parameters.AddWithValue("@vi_Personal_Ids", Personal_Ids);
                    cmd.Parameters.AddWithValue("@vi_fl_incluye_cesados", flIncluyeCesados);

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
