using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_CambiarPlanilla
    {
        private static controller_CambiarPlanilla instance = null;
        public static controller_CambiarPlanilla getInstance()
        {
            return instance == null ? instance = new controller_CambiarPlanilla() : instance;
        }
        public ArrayList ListaTipoPlanilla()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Planilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", "01");
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "01");
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
        public ArrayList ListaEjercicio()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Ejercicio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
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
        public ArrayList ListaMes(string EjercicioId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Mes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Mes_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", EjercicioId);
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
        public ArrayList ListaPeriodo(string EjercicioId, string Planilla_Id,string MesId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", EjercicioId);
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "02");
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", "01");
                    cmd.Parameters.AddWithValue("@vi_Mes_Id", MesId);
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
        public ArrayList ListaPersonalCambioPlanilla(string[] PersonalId)
        {
            string codigos = "";
            for (int i = 0; i <= PersonalId.Count() - 1; i++)
            {
                codigos += "'" + PersonalId[i] + "',";
            }
            if (codigos.Length > 0)
            {
                codigos = codigos.Remove(codigos.Length - 1, 1);
            }
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {

                string comando = "SELECT P.Personal_Id,P.Apellido_Paterno+' '+P.Apellido_Materno+', '+P.Nombres [ApellidosNombres] ";
                comando += ", PL.Planilla_Id,PL.Descripcion [NPlanilla],PA.Periodo_Id,PE.Descripcion [NPeriodo] ";
                comando += "FROM Personal P LEFT JOIN Personal_activo PA ON P.Personal_Id = PA.Personal_Id ";
                comando += "INNER JOIN Periodo PE ON PA.Periodo_Id = PE.Periodo_Id ";
                comando += "INNER JOIN Planilla PL ON PE.Planilla_Id = PL.Planilla_Id ";
                comando += "WHERE P.Personal_Id IN("+ codigos + ") ";
                comando += "AND(P.Personal_Id + PA.Periodo_Id) IN(SELECT Personal_Id + MAX(Periodo_Id)[per] ";
                comando += "FROM Personal_activo WHERE Personal_Id IN (" + codigos + ") ";
                comando += "GROUP BY Personal_Id) ";
                comando += "ORDER BY 2";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
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


        public string ProcesarCambioPlanilla(string PersonalId, string PlanillaIdAct, string PlanillaIdNew, string PeriodoIdAct, string PeriodoIdNew)
        {
            string resultado = "false#";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("uspCambiarTipoPlanillaPersonal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonalId", PersonalId);
                        cmd.Parameters.AddWithValue("@PlanillaIdAct", PlanillaIdAct);
                        cmd.Parameters.AddWithValue("@PlanillaIdNew", PlanillaIdNew);
                        cmd.Parameters.AddWithValue("@PeriodoIdAct", PeriodoIdAct);
                        cmd.Parameters.AddWithValue("@PeriodoIdNew", PeriodoIdNew);
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                        if (irows > 0)
                        {
                            resultado = "true#Proceso realizado correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "false#Error:" + ex.Message;
            }
            return resultado;
        }
    }
}
