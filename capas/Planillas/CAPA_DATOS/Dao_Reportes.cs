using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_Reportes
    {
        /*FPS*/
        /*Reporte de Boletas de Pago*/
        public static DataTable Lista_Boleta_Pago(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            try
            {
                /*Reporte para un Personal*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "Reporte_Boleta", Personal_Id, Periodo_Id, Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Boleta_Pago_Masivo(string Personal_Id_Masivo, string Periodo_Id, string Proceso_Id, Int32 cantPersonal, String Orden, String Periodo_Id_Desde, String fl_dolares
            , String fl_por_personal_periodo
            , String rucEmpresa = "")
        {
            try
            {
                //Si se le envía el RUC, se asigna la conexión que corresponde, caso contrario se obtiene de la autenticación
                String cnxConnection = String.Empty;
                if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
                else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

                /*Reporte para Personal Masivo*/
                /*Personal_Id_Masivo => '000001|000002|000003'*/
                /*cantPersonal => 3*/
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_Reporte_Boleta", Personal_Id_Masivo, Periodo_Id, Proceso_Id, cantPersonal);

                SqlConnection cn = new SqlConnection(cnxConnection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fps_Reporte_Boleta";

                cmd.Parameters.AddWithValue("@vi_Personal_Id_Masivo", Personal_Id_Masivo);
                cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                cmd.Parameters.AddWithValue("@vi_Proceso_Id", Proceso_Id);
                cmd.Parameters.AddWithValue("@vi_CantPersonal", cantPersonal);
                cmd.Parameters.AddWithValue("@vi_Orden", Orden);
                cmd.Parameters.AddWithValue("@vi_Periodo_Id_Desde", Periodo_Id_Desde);
                cmd.Parameters.AddWithValue("@vi_fl_dolares", fl_dolares);
                cmd.Parameters.AddWithValue("@vi_fl_por_personal_periodo", fl_por_personal_periodo);

                DataTable dt = new DataTable();
                SqlDataReader reader = null;
                try
                {
                    cn.Open();
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception)
                {
                    if (reader != null && !reader.IsClosed) reader.Close();
                    throw;
                }
                finally
                {
                    cn.Close();
                    cn.Dispose();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /***********************************************************************
							    PAGINA IMPRIMIR REPORTES
        ************************************************************************/
        public static DataTable Lista_Reportes()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Reportes", DBNull.Value /*Usuario_Id*/);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Reportes*/
        public static DataTable Lista_rpt_Reportes(string reporte_Id, string usuario_Id
            , string periodo_Id, string proceso_Id, string personal_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "PROC_SCIRE1_LISTAR_REPORTE"
                    , reporte_Id, "000138", periodo_Id, proceso_Id, personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable List_Report_desc( string periodo_Id, string personal_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "SP_Rep_Desc"
                    ,  periodo_Id, personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /*Reportes*/
        public static DataTable Lista_rpt_Reportes_Mensual(string reporte_Id, string usuario_Id
            , string periodo_Id, string proceso_Id, string personal_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "PROC_SCIRE1_LISTAR_MENSUAL_REPORTE"
                    , reporte_Id, "000138", periodo_Id, proceso_Id, personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_rpt_Reporte(string ejercicio_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "Listar_Reporte_Ppto2"
                    , ejercicio_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_rpt_Reporte_Resumen(string ejercicio_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "Listar_Reporte_Ppto_Res"
                    , ejercicio_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_rpt_ReporteCant(string ejercicio_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_CantidadMes"
                    , ejercicio_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //

        public static DataTable GenerarCertificadoQuinta(string PeriodoId, string PersonalId)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "uspGenerarCeritificadoQuinta", PeriodoId, PersonalId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //20181216
        public static DataTable Lista_DatosTruncos_Liquidacion(string Personal_Id, string Periodo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "uspListarDatosTruncosLiquidacion", Personal_Id, Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_rpt_LiquidaBeneSociales_Detalle(string Personal_Id, string Periodo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "pla_sps_liquida_benef_sociales_det", Periodo_Id, Personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
