using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CAPA_DATOS.oFormulas
{
    public class controller_ConfigFormula
    {
        private static controller_ConfigFormula instance = null;
        public static controller_ConfigFormula Get_Instance()
        {
            return instance == null ? instance = new controller_ConfigFormula() : instance;
        }
        public ArrayList ConfigFormulaGetProcesosSelect()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetProcesos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new { Proceso_Id = dataRow[0].ToString(), Proceso = dataRow[1].ToString() };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }
        public ArrayList ConfigFormulaGetFormulasPlanillaList(string Planilla,string Proceso,string FormulaFind)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormulas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso);
                    cmd.Parameters.AddWithValue("@FormulaFind", FormulaFind);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            Formula_Id = dataRow[0].ToString(),
                            Concepto_Id = dataRow[1].ToString(),
                            Planilla_Id = dataRow[2].ToString(),
                            Nro = dataRow[3].ToString(),
                            Formula_texto = dataRow[4].ToString(),
                            Formula_condicion = dataRow[5].ToString(),
                            Fuente_Proceso_Id = dataRow[6].ToString(),
                            Estado_Id = dataRow[7].ToString(),
                            Fecha_Modif = dataRow[8].ToString(), 
                           
                            Descripcion = dataRow[10].ToString(),
                            Comentario = dataRow[11].ToString(),
                            Proceso = dataRow[12].ToString(),
                            Proceso_Id = dataRow[13].ToString()
                        };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }

        #region CONFIGURAR FORMULA
        public ArrayList ConfigFormulaGetConceptosList()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptos_Formulas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            Concepto_Id = dataRow[0].ToString(),
                            Descripcion = dataRow[1].ToString()
                        };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }
        public ArrayList ConfigFormulaGetProcesoFuenteList()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetProcesos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            Proceso_Id = dataRow[0].ToString(),
                            Proceso = dataRow[1].ToString()
                        };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }
        public int ConfigFormulaGetMaxPosicionFormula(string PlanillaCod)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetLastNroFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Planilla_Id", PlanillaCod);
                    cn.Open();
                    int cant=int.Parse(cmd.ExecuteScalar().ToString());
                    return cant;
                }
            }
        }
        public ArrayList ConfigFormulaGetTipoConceptosList()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetTipoConceptos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            TC_Id = dataRow[0].ToString(),
                            Tipo_Concepto = dataRow[1].ToString()
                        };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }
        public ArrayList ConfigFormulaGetConceptosByTipoList(string Tipo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetConceptosPorTipo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo_Dato", Tipo);
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            Concepto_Id = dataRow[0].ToString(),
                            Descripcion = dataRow[1].ToString()
                        };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }

        public string ConfigFormulaProcInsertFormula(string Concepto_Id, string Planilla_Id, int Nro, string Formula_texto, string Formula_condicion
            , string Fuente_Proceso_Id, bool ChangeLastNro, string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInsertFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@Nro", Nro);
                    cmd.Parameters.AddWithValue("@Formula_texto", Formula_texto.Trim());
                    cmd.Parameters.AddWithValue("@Formula_condicion", Formula_condicion.Trim());
                    cmd.Parameters.AddWithValue("@Fuente_Proceso_Id", Fuente_Proceso_Id);
                    cmd.Parameters.AddWithValue("@Estado_Id", "01");
                    cmd.Parameters.AddWithValue("@Fecha_Modif", DateTime.Now);
                    cmd.Parameters.AddWithValue("@GRUPO_ID", "00");
                    cmd.Parameters.AddWithValue("@ChangeLastNro", ChangeLastNro);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);

                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                    if (RES > 0)
                    {
                        return "true#Fórmula registrada correctamente.";
                    }
                    else
                    {
                        return "false#Fórmula no fue registrada correctamente.";
                    }
                }
            }

        }

        public string ConfigFormulaProcUpdateFormula(string Formula_Id, string Concepto_Id, string Planilla_Id, int Nro, string Formula_texto, string Formula_condicion
            , string Fuente_Proceso_Id, bool ChangeLastNro, string Proceso_Id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_RSUpdateFormula", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        cmd.Parameters.AddWithValue("@Formula_Id", Formula_Id);
                        cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Nro", Nro);
                        cmd.Parameters.AddWithValue("@Formula_texto", Formula_texto.Trim());
                        cmd.Parameters.AddWithValue("@Formula_condicion", Formula_condicion.Trim());
                        cmd.Parameters.AddWithValue("@Fuente_Proceso_Id", Fuente_Proceso_Id);
                        cmd.Parameters.AddWithValue("@Estado_Id", "01");
                        cmd.Parameters.AddWithValue("@Fecha_Modif", DateTime.Now);
                        cmd.Parameters.AddWithValue("@GRUPO_ID", "00");
                        cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);

                        int RES;
                        RES = cmd.ExecuteNonQuery();
                        cn.Close();
                        if (RES > 0)
                        {
                            return "true#Fórmula actualizada correctamente.";
                        }
                        else
                        {
                            return "false#La fórmula no pudo ser actualizada.";
                        }
                    }
                }
            }
            catch (Exception ex) {
                if (ex.InnerException != null)
                {
                    return "false#.::Error: el proceso fue interrumpido.\n Detalle del error: " + ex.InnerException.Message;
                }
                else {
                    return "false#.::Error: el proceso fue interrumpido.\n Detalle del error: " + ex.Message;
                }
            }

        }


        public object ConfigFormulaGetFormulaFind(string FormulaID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetFormula", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Formula_Id", FormulaID);
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new
                        {
                            Formula_Id = dataRow[0].ToString(),
                            Concepto_Id = dataRow[1].ToString(),
                            Planilla_Id = dataRow[2].ToString(),
                            Nro = dataRow[3].ToString(),
                            Formula_texto = dataRow[4].ToString(),
                            Formula_condicion = dataRow[5].ToString(),
                            Fuente_Proceso_Id = dataRow[6].ToString(),
                            Proceso_Id = dataRow[7].ToString(),
                            Estado_Id = dataRow[8].ToString(),
                            Fecha_Modif = dataRow[9].ToString(),
                            Descripcion = dataRow[11].ToString(),
                            Comentario = dataRow[12].ToString()
                        };
                        rows.Add(dat);
                    }
                    if (rows.Count == 0) {
                        return null;
                    }
                    return rows[0];
                }
            }
        }
        #endregion
    }
}

