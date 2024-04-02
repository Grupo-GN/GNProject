using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public class FormulasDA
    {
        public static FormulasDA oControllerInstance = null;
        public static FormulasDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new FormulasDA();
            }
            return oControllerInstance;
        }

        public DataTable GetFormulas(string PlanillaID, string Proceso_Id)
        {

            using(SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString)){
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormulas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Planilla_Id", PlanillaID);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
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

        public Int32 InsertFormula(FormulasBE formulasBE, bool ChangeLastNro, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInsertFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    cmd.Parameters.AddWithValue("@Concepto_Id", formulasBE.Concepto_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", formulasBE.Planilla_Id);
                    cmd.Parameters.AddWithValue("@Nro", formulasBE.Nro);
                    cmd.Parameters.AddWithValue("@Formula_texto", formulasBE.Formula_texto);
                    cmd.Parameters.AddWithValue("@Formula_condicion", formulasBE.Formula_condicion);
                    cmd.Parameters.AddWithValue("@Fuente_Proceso_Id", formulasBE.Fuente_Proceso_Id);
                    cmd.Parameters.AddWithValue("@Estado_Id", formulasBE.Estado_Id);
                    cmd.Parameters.AddWithValue("@Fecha_Modif", formulasBE.Fecha_Modif);
                    cmd.Parameters.AddWithValue("@GRUPO_ID", formulasBE.GRUPO_ID);
                    cmd.Parameters.AddWithValue("@ChangeLastNro", ChangeLastNro);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);

                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }

        }

        public Int32 UpdateFormula(FormulasBE formulasBE, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSUpdateFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Formula_Id", formulasBE.Formula_Id);
                    cmd.Parameters.AddWithValue("@Concepto_Id", formulasBE.Concepto_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", formulasBE.Planilla_Id);
                    cmd.Parameters.AddWithValue("@Nro", formulasBE.Nro);
                    cmd.Parameters.AddWithValue("@Formula_texto", formulasBE.Formula_texto);
                    cmd.Parameters.AddWithValue("@Formula_condicion", formulasBE.Formula_condicion);
                    cmd.Parameters.AddWithValue("@Fuente_Proceso_Id", formulasBE.Fuente_Proceso_Id);
                    cmd.Parameters.AddWithValue("@Estado_Id", formulasBE.Estado_Id);
                    cmd.Parameters.AddWithValue("@Fecha_Modif", formulasBE.Fecha_Modif);
                    cmd.Parameters.AddWithValue("@GRUPO_ID", formulasBE.GRUPO_ID);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public DataTable GetFormula(string FormulaID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Formula_Id", FormulaID);
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

        public Int32 GetLastNro(string PlanillaID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand("usp_RSGetLastNroFormula", cn)){
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.Parameters.AddWithValue("@Planilla_Id", PlanillaID);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cn.Close();
                    int result = Convert.ToInt32(dt.Rows[0][0]);
                    return result;
                }
                } 
            }
        }

        public Int32 DeleteFormula(string FormulaID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSDeleteFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Formula_Id", FormulaID);
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    return RES;
                }
            }
        }

        public DataTable GetFormulasPorProceso(string Proceso_Id, string Planilla_Id)
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormulasPorProceso", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
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

        public DataTable GetProcesoPorFormula(string Formula_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetProcesoporFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Formula_Id", Formula_Id);
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
