using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class ConceptosDA
    {
        public static ConceptosDA oControllerInstance = null;
        public static ConceptosDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new ConceptosDA();
            }
            return oControllerInstance;
        }

        public DataTable GetConceptosFormulas()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptos_Formulas", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
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

        public DataTable GetConceptosPorTipo(string Tipo_Dato)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptosPorTipo", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Tipo_Dato", Tipo_Dato);
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

        public DataTable GetConceptos()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptos", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
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

        public DataTable GetConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptosPorPersona", cn))
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

        public DataTable GetConceptosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id, string Proceso_Fuente_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptosPorPersona", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Fuente_Id", Proceso_Fuente_Id);

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

        public DataTable GetConcepto(string Concepto_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConcepto", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
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

        public DataTable GetConceptoDirecto(string Personal_Id, string Periodo_Id, string Concepto_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptoDirecto", cn))
                {
                    //Dim cmd As New SqlCommand("usp_GetConceptos", cn)
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
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
        //
    }
}
