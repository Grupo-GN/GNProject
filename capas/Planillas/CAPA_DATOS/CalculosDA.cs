using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class CalculosDA
    {

        public static CalculosDA oControllerInstance = null;
        public static CalculosDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new CalculosDA();
            }
            return oControllerInstance;
        }

        public Int32 InsertCalculos(List<CalculosBE> lstCalculosBE)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInsertCalculos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    int RES = 0;
                    foreach (CalculosBE item in lstCalculosBE)
                    {
                        cmd.Parameters.Clear();

                        cmd.Parameters.AddWithValue("@planilla_id", item.Planilla_id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", item.Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", item.Personal_Id);
                        cmd.Parameters.AddWithValue("@Concepto_Id", item.Concepto_Id);
                        cmd.Parameters.AddWithValue("@Proceso_Id", item.Proceso_Id);
                        cmd.Parameters.AddWithValue("@Valor", item.Valor);

                        RES = cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    cn.Dispose();
                    return RES;
                }
            }

        }

        public DataTable GetFormulasPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormulasPorPersona", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
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

        public DataTable GetFijosPorPersona(string Personal_Id, string Periodo_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFijosPorPersona", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        da.Fill(dt);
                        cn.Close();
                        cn.Dispose();
                        return dt;
                    }
                }
            }
        }

        public DataTable GetVariablesPorPersona(string Personal_Id, string Periodo_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetVariablesPorPersona", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);

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

        public DataTable GetParametrosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("usp_RSGetParametrosPorPersona", cn)){
                //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);

                using(SqlDataAdapter da = new SqlDataAdapter(cmd)){
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Close();
                cn.Dispose();
                return dt;
            }
        }
    }
 }


        public DataTable GetAcumuladosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetAcumuladosPorPersona", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);

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
