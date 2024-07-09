using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class controller_GenerarAsientos
    {
        private static controller_GenerarAsientos instance = null;
        public static controller_GenerarAsientos getInstance()
        {
            return instance == null ? instance = new controller_GenerarAsientos() : instance;
        }
        public ArrayList GetAsientosSelect(string xEjercicio, string xPlanilla)
        {
            Dictionary<string, string> rlist = new Dictionary<string, string>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Asiento_Id,Descripcion FROM Asiento ";
                comando += "WHERE Estado_Id='01' AND Ejercicio_Id=@Ejercicio_Id and Planilla_Id=@Planilla_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Ejercicio_Id",xEjercicio);
                    cmd.Parameters.AddWithValue("@Planilla_Id", xPlanilla);
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
        public string GetNombreAsiento(string xAsientoId)
        {
            string nombre = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Descripcion FROM ASIENTO WHERE ASIENTO_ID=@ASIENTO_ID";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ASIENTO_ID", xAsientoId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nombre = dr.GetValue(0).ToString();
                    }
                    return nombre;
                }
            }
        }
        public string GetNombrePeriodo(string xPeriodoId)
        {
            string nombre = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Descripcion FROM Periodo WHERE Periodo_Id=@Periodo_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Periodo_Id", xPeriodoId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nombre = dr.GetValue(0).ToString();
                    }
                    return nombre;
                }
            }
        }


        public ArrayList GetVerificarConceptosNoIncluidos(string xAsiento, string xEjercicio, string xPlanilla,string xPeriodo)
        {
            if (xAsiento == "01")
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    string comando = "uspVerificarConceptosNoIncluidosAsientosPorProceso";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", xAsiento);
                        cmd.Parameters.AddWithValue("@Ejercicio_Id", xEjercicio);
                        cmd.Parameters.AddWithValue("@PeriodoId", xPeriodo);
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
            else
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    string comando = "uspVerificarConceptosNoIncluidosAsientos";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AsientoId", xAsiento);
                        cmd.Parameters.AddWithValue("@PeriodoId", xPeriodo);
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
        }
        //GuardarAsientos
        public string RegistrarAsientos(string xPeriodoId, string xAsientoId, string xCodTipoAsiento)
        {
            string resultado = "false#";
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    string comando = "pla_spi_registrar_asiento";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PeriodoId", xPeriodoId);
                        cmd.Parameters.AddWithValue("@AsientoId", xAsientoId);
                        cmd.Parameters.AddWithValue("@CodTipoAsiento", xCodTipoAsiento);
                        cn.Open();
                        int irow = cmd.ExecuteNonQuery();
                        if (irow > 0) { resultado = "true#Los asientos se registraron correctamente."; }
                        else { resultado = "false#No se registró ninguna información, verifique los datos."; }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "false#Error:" + ex.Message;
            }
            return resultado;
        }
        //public string RegistrarAsientosSap(string xPeriodoId)
        //{
        //    string resultado = "false#";
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
        //        {
        //            string comando = "uspRegistrarAsientosAgrupadosGlosa_Contable";
        //            using (SqlCommand cmd = new SqlCommand(comando, cn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PeriodoId", xPeriodoId);
        //                cn.Open();
        //                int irow = cmd.ExecuteNonQuery();
        //                if (irow > 0) { resultado = "true#Los asientos se registraron correctamente."; }
        //                else { resultado = "false#No se registró ninguna información, verifique los datos."; }
        //            }
        //        }
        //    }catch(Exception ex)
        //    {
        //        resultado = "false#Error:" + ex.Message;
        //    }
        //    return resultado;
        //}
        //public string RegistrarAsientosStarSoft(string xPeriodoId)
        //{
        //    string resultado = "false#";
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
        //        {
        //            string comando = "uspRegistrarAsientosAgrupadosGlosa_Contable_StarSoft";
        //            using (SqlCommand cmd = new SqlCommand(comando, cn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PeriodoId", xPeriodoId);
        //                cn.Open();
        //                int irow = cmd.ExecuteNonQuery();
        //                if (irow > 0) { resultado = "true#Los asientos se registraron correctamente."; }
        //                else { resultado = "false#No se registró ninguna información, verifique los datos."; }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = "false#Error:" + ex.Message;
        //    }
        //    return resultado;
        //}
        //public string RegistrarAsientosGeneral(string xPeriodoId,string xAsientoId)
        //{
        //    string resultado = "false#";
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
        //        {
        //            string comando = "uspRegistrarAsientosGeneral";
        //            using (SqlCommand cmd = new SqlCommand(comando, cn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@PeriodoId", xPeriodoId);
        //                cmd.Parameters.AddWithValue("@AsientoId", xPeriodoId);
        //                cn.Open();
        //                int irow = cmd.ExecuteNonQuery();
        //                if (irow > 0) { resultado = "true#Los asientos se registraron correctamente."; }
        //                else { resultado = "false#No se registró ninguna información, verifique los datos."; }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = "false#Error:" + ex.Message;
        //    }
        //    return resultado;
        //}
    }
}
