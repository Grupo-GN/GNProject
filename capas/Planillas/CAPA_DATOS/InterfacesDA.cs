using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class InterfacesDA
    {
        public static InterfacesDA oControllerInstance = null;
        public static InterfacesDA Create()
        {
            if (oControllerInstance == null)
            {
                oControllerInstance = new InterfacesDA();
            }
            return oControllerInstance;
        }

        public DataTable GetInterfaces(int Tipo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetInterfaces", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Tipo", Tipo);
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

        public DataTable GetInterface(int Interface_ID)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSGetInterface", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Interface_ID", Interface_ID);
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

        public DataTable GetInterface1(string Compania_ID)   //visto
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RSInterface1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@CIA", Compania_ID);
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

        public DataTable GetInterface2(string Periodo_Id)  //no se encontro Proc
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_02_EMPLEADORES_DESTACO_PERSONAL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
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

        public DataTable GetInterface2_1(string Periodo_Id)  //visto
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_02_1_ESTAB_EMPLEADORES_DESTACO_PERSONAL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
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

        public DataTable GetInterface3(string Periodo_Id)  //visto
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_03_EMPLEADORES_ME_DESTACAN_PERSONAL", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
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

        public DataTable GetInterface4(string Periodo_Id)       //ACTUALIZO MICHAEL
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_04_DATOS_PERSONAL_MS", cn))
                {//SqlCommand cmd = new SqlCommand("usp_RSInterface4", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", "");
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

        public DataTable GetInterface5(string Periodo_Id, string codigo) //ACTUALIZO MICHAEL
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_05_DATOS_TRABAJADORES_MS", cn))
                { //SqlCommand cmd = new SqlCommand("usp_RSInterface5", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
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

        public DataTable GetInterface6(string Periodo_Id,string codigo)  //visto
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_06_DATOS_PENSIONISTA", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
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

        public DataTable GetInterface9(string Periodo_Id) //ACTUALIZO MICHAEL
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_09_DATOS_PS_MODFORMATIVA_MS", cn))
                {//SqlCommand cmd = new SqlCommand("usp_RSInterface9", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", "");
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

        public DataTable GetInterface10(string Periodo_Id)      //Actualizo Michael
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_10_DATOS_PERSONAL_TERCEROS_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", "");
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

        public DataTable GetInterface11(string Periodo_Id)   //visto
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("RS_TREGISTRO_11_PERIODOS_MS", cn))
                { //SqlCommand cmd = new SqlCommand("usp_RSInterface11", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    // cmd.Parameters.AddWithValue("@CODIGO", "");
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




        #region mantenimientoMichael

        /// <summary>
        /// metodo para llamar a la Interface17
        /// </summary>
        /// <param name="Periodo_Id"></param>
        /// <returns></returns>
        public DataTable GetInterface17(string Periodo_Id) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_17_ESTABLECIMIENTOS_TRABAJADOR", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", "");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        /// <summary>
        /// metodo Para llamar a la Interface23
        /// </summary>
        /// <param name="Periodo_Id"></param>
        /// <returns></returns>
        public DataTable GetInterface23(string Periodo_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RS_TREGISTRO_23_MODALIDAD_FORMATIVA_TRABAJADOR", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@PERIODO", Periodo_Id);
                    cmd.Parameters.AddWithValue("@CODIGO", "");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }


        public System.Data.DataTable GetInterfaceTelecredito(
            string cia,string periodo,string concepto,string moneda,string planilla,
            string fechaInicial,string fechaFinal,string codigo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_TELECREDITO", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                     cmd.Parameters.AddWithValue("@Cia", cia);
                    cmd.Parameters.AddWithValue("@UN_PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@Concepto", concepto);
                   cmd.Parameters.AddWithValue("@Moneda", moneda);
                    cmd.Parameters.AddWithValue("@Planilla", planilla);
                    cmd.Parameters.AddWithValue("@FechaIniVaca", fechaInicial);
                    cmd.Parameters.AddWithValue("@fechaFinVaca", fechaFinal);
                    cmd.Parameters.AddWithValue("@CODIGO", codigo);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable tabla = new System.Data.DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }

        #endregion

    }
}
