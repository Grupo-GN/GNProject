using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS.oFormulas
{
    public class controller_RepGeneral
    {
        private static controller_RepGeneral instance = null;
        public static controller_RepGeneral Get_Instance()
        {
            return instance == null ? instance = new controller_RepGeneral() : instance;
        }
        public ArrayList ListaPlanilla()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Planilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "01");
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object dat = new { Planilla_Id = dr.GetValue(0).ToString(), Descripcion = dr.GetValue(1).ToString() };
                        rList.Add(dat);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaEjercicio()
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Ejercicio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object dat = new { Ejercicio_Id = dr.GetValue(0).ToString(), Descripcion = dr.GetValue(1).ToString() };
                        rList.Add(dat);
                    }
                    return rList;
                }
            }

        }
        public ArrayList Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", Anio);
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "02");
                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ArrayList rows = new ArrayList();
                    foreach (DataRow dataRow in dt.Rows)
                    {
                        object dat = new { Periodo_Id = dataRow["Periodo_Id"].ToString(), Descripcion = dataRow["DescripcionPeriodoMes"].ToString() };
                        rows.Add(dat);
                    }
                    return rows;
                }
            }
        }
        public ArrayList ListaArea()
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaArea", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
        public ArrayList ListaCatAuxiliar()
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCatAuxiliar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public ArrayList ListaPersonalActivoReporteGeneral(string PlanillaId,string PeriodoIni,string PeriodoFin)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalActivoReporteGeneral", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Planilla_Id", PlanillaId);
                    cmd.Parameters.AddWithValue("@PeriodoIni", PeriodoIni);
                    cmd.Parameters.AddWithValue("@PeriodoFin", PeriodoFin);
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

        public ArrayList getCombo(String codigo, String xml_parametros)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("pla_sps_combo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_codigo", codigo);
                    cmd.Parameters.AddWithValue("@vi_parametros_xml", xml_parametros);
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
        public ArrayList ListaProyecto()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaProyecto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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


        public ArrayList Lista_reporte_planilla(string Planilla_Id, string Periodo_Id, string localidad, string proyecto, string catAuxiliar_Id, string personal
            //, string ejercicio, string flPeriodo
            , string PeriodoIni_Datos, string PeriodoFin_Datos, string estado)
        {
            // proceso Liquidacion
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Genera_Planilla", cn))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@localidad", localidad);
                    cmd.Parameters.AddWithValue("@proyecto", proyecto);
                    cmd.Parameters.AddWithValue("@CatAuxiliar_Id", catAuxiliar_Id);
                    cmd.Parameters.AddWithValue("@personal", personal);
                    //cmd.Parameters.AddWithValue("@ejercicio", ejercicio);
                    //cmd.Parameters.AddWithValue("@flPeriodo", flPeriodo);
                    cmd.Parameters.AddWithValue("@v_Periodo_Id_Ini_Datos", PeriodoIni_Datos);
                    cmd.Parameters.AddWithValue("@v_Periodo_Id_Fin_Datos", PeriodoFin_Datos);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    object[] values = new object[dr.FieldCount];

                    //    dr.GetValues(values);
                    //    rList.Add(values);

                    //}
                    while (dr.Read())
                    {
                        object dat = new {
                            personal_id = dr.GetValue(0).ToString(),
                            Nombre_Completo = dr.GetValue(1).ToString(),
                            Mes = dr.GetValue(2).ToString(),
                            Periodo = dr.GetValue(3).ToString(),
                            Periodo_Id = dr.GetValue(4).ToString(),
                            FInicio = dr.GetValue(5).ToString(),
                            FFinal = dr.GetValue(6).ToString(),
                            vacaciones = dr.GetValue(7).ToString(),
                            FechaV = dr.GetValue(8).ToString(),
                            EstadoV = dr.GetValue(9).ToString(),
                            Periodo_Id_Pago_V = dr.GetValue(10).ToString(),
                            Cts = dr.GetValue(11).ToString(),
                            FechaC = dr.GetValue(12).ToString(),
                            EstadoC = dr.GetValue(13).ToString(),
                            Periodo_Id_Pago_C = dr.GetValue(14).ToString(),
                            Gratificacion = dr.GetValue(15).ToString(),
                            FechaG = dr.GetValue(16).ToString(),
                            EstadoG = dr.GetValue(17).ToString(),
                            Periodo_Id_Pago_G = dr.GetValue(18).ToString(),
                            Essalud = dr.GetValue(19).ToString(),
                            FechaE = dr.GetValue(20).ToString(),
                            EstadoE = dr.GetValue(21).ToString(),
                            Periodo_Id_Pago_E = dr.GetValue(22).ToString(),
                            OtrosIngresos = dr.GetValue(23).ToString(),
                            OtrosDscto = dr.GetValue(24).ToString(),
                            DsctoPenciones = dr.GetValue(25).ToString(),
                            Netos = dr.GetValue(26).ToString(),
                            Estado = dr.GetValue(27).ToString(),
                            //Observacion = dr.GetValue(28).ToString()
                        };
                        rList.Add(dat);
                    }
                    return rList;
                }
            }
        }

        //DataTable SplitData(string valor)
        //{
        //    DataTable dt = new DataTable();
        //    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("delimitador", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@valor",valor);
        //            cn.Open();
        //            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
        //            {
        //                a.Fill(dt);
        //            }
        //            return dt;
        //        }
        //    }
        //}

        public String InsertDetLiquidacion(List<string> Rlist, string Periodo_Id_Pago, out Boolean flError)
        {
            Int32 retorno = 0; String msg_retorno = String.Empty;
            flError = false;
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string personal_id = "", periodo_id = "", estado = "", observacion = "", concepto_id = "";
                cn.Open();
                using (SqlTransaction transaction = cn.BeginTransaction())
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = transaction;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SP_insertTbl_DetLiquidacion";
                        cmd.Parameters.Add("@personal_id", SqlDbType.VarChar);
                        cmd.Parameters.Add("@periodo_id", SqlDbType.VarChar);
                        cmd.Parameters.Add("@estado", SqlDbType.VarChar);
                        cmd.Parameters.Add("@observacion", SqlDbType.VarChar);
                        cmd.Parameters.Add("@concepto_id", SqlDbType.Char);
                        cmd.Parameters.Add("@vi_Periodo_Id_Pago", SqlDbType.Char);

                        try
                        {
                            foreach (string item in Rlist)
                            {
                                string[] items = item.Split(',');
                                personal_id = items[0];
                                periodo_id = items[1];
                                estado = items[2];
                                observacion = items[3];
                                concepto_id = items[4];

                                cmd.Parameters["@personal_id"].Value = personal_id;
                                cmd.Parameters["@periodo_id"].Value = periodo_id;
                                cmd.Parameters["@estado"].Value = estado;
                                cmd.Parameters["@observacion"].Value = observacion;
                                cmd.Parameters["@concepto_id"].Value = concepto_id;
                                cmd.Parameters["@vi_Periodo_Id_Pago"].Value = Periodo_Id_Pago;

                                String str_Retorno = cmd.ExecuteScalar().ToString();
                                retorno = Convert.ToInt32(str_Retorno.Split('|')[0]);
                                msg_retorno = str_Retorno.Split('|')[1].ToString();

                                if (retorno <= 0)
                                {
                                    flError = true;
                                    break;
                                }
                            }

                            if (flError == false)
                            {
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                            return msg_retorno;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            transaction.Rollback();
                            cn.Close();
                           
                            return e.Message; throw;
                        }
                    }
                }
            }
        }
    }

}
