using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Reportes
    {
        /*FPS*/
        /*Reporte de Boletas de Pago*/
        public static DataTable Lista_Boleta_Pago(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            try
            {
                return Dao_Reportes.Lista_Boleta_Pago(Personal_Id, Periodo_Id, Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Boleta_Pago_Masivo(string Personal_Id_Masivo, string Periodo_Id, string Proceso_Id, int cantPersonal, string Orden, string Periodo_Id_Desde, String fl_dolares, String fl_por_personal_periodo)
        {
            try
            {
                /*Reporte para Personal Masivo*/
                /*Personal_Id_Masivo => '000001|000002|000003'*/
                /*cantPersonal => 3*/
                return Dao_Reportes.Lista_Boleta_Pago_Masivo(Personal_Id_Masivo, Periodo_Id, Proceso_Id, cantPersonal, Orden, Periodo_Id_Desde, fl_dolares, fl_por_personal_periodo);
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
                return Dao_Reportes.Lista_Reportes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Reporte*/
        public static DataTable Lista_rpt_Reportes(string reporte_Id, string usuario_Id
            , string periodo_Id, string proceso_Id, string personal_Id)
        {
            try
            {
                return Dao_Reportes.Lista_rpt_Reportes(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable List_Report_desc( string periodo_Id , string personal_Id)
        {
            try
            {
                return Dao_Reportes.List_Report_desc( periodo_Id, personal_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_rpt_Reportes_Mensual(string reporte_Id, string usuario_Id
            , string periodo_Id, string proceso_Id, string personal_Id)
        {
            try
            {
                return Dao_Reportes.Lista_rpt_Reportes_Mensual(reporte_Id, usuario_Id, periodo_Id, proceso_Id, personal_Id);
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
                return Dao_Reportes.Lista_rpt_Reporte(ejercicio_Id);
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
                return Dao_Reportes.Lista_rpt_Reporte_Resumen(ejercicio_Id);
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
                return Dao_Reportes.Lista_rpt_ReporteCant(ejercicio_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //===
        public static DataTable GenerarCertificadoQuinta(string PeriodoId, string PersonalId)
        {
            try
            {
                return Dao_Reportes.GenerarCertificadoQuinta(PeriodoId, PersonalId);
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
                return Dao_Reportes.Lista_DatosTruncos_Liquidacion(Personal_Id, Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_rpt_LiquidaBeneSociales_Detalle(string periodo_Id, string personal_Id)
        {
            try
            {
                return Dao_Reportes.Lista_rpt_LiquidaBeneSociales_Detalle(personal_Id, periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
