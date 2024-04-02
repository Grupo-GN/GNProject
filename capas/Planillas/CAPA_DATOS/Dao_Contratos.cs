using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_Contratos
    {        
        public static List<CAPA_ENTIDAD.Ent_DiferenciaFechas> GetDiferenciaFechas(string FechaInicial, string FechaFinal)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Diferencia_Fechasl", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@FechaInicial", FechaInicial);
                    cmd.Parameters.AddWithValue("@FechaFinal", FechaFinal);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CAPA_ENTIDAD.Ent_DiferenciaFechas> oLista = new List<CAPA_ENTIDAD.Ent_DiferenciaFechas>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.Ent_DiferenciaFechas obj = new CAPA_ENTIDAD.Ent_DiferenciaFechas();
                        obj.FechaInicial = dr.GetValue(0).ToString();
                        obj.FechaFinal = dr.GetValue(1).ToString();
                        obj.Anios = int.Parse(dr.GetValue(2).ToString());
                        obj.Meses = int.Parse(dr.GetValue(3).ToString());
                        obj.Dias = int.Parse(dr.GetValue(4).ToString());
                        oLista.Add(obj);
                    }
                    return oLista;
                }
            }
        }



        public static DataTable Reporte_TiempoServicio(string Personal_Id,string FechaFinal)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ReporteTiempoServicio_Personal", Personal_Id, FechaFinal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_Correos_Contratos()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListarCorreoContratos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Renovar_Contratos(Ent_Contratos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaRenovaContrato", objE.PeriodoId, objE.Area, objE.Mes, objE.Anio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static DataTable Lista_Renovar_Contratos_Renovados(Ent_Contratos objE)
        {

            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListContratosRenovados", objE.PeriodoId, objE.Area);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_Renovar_Contratos_RenovadosPRC(Ent_Contratos objE)
        {

            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaRenovaContratoPRC", objE.PeriodoId, objE.Area, "", "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable GenerarRegistrosFinContrato_Mes(Ent_Contratos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_GeneraRegistrosFinContrato_Mes", objE.PeriodoId, objE.Mes, objE.Anio);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Empleados_Contratos(String Codigo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "WPP_EMPLEADOS_CONTRATOS", Codigo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_Contrato()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoContrato");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_Periodo_Renov_Contrato(string Personal_Id,string Periodo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Periodo_Renov_Contrato",Personal_Id,Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Insertar_Periodo_Renov_Contrato(string Personal_Id,string Periodo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Insertar_Periodo_Renov_Contrato", Personal_Id, Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Actualiza_Periodo_Renov_Contrato(DateTime FechaFin,string Personal_Id,string Periodo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Act_Periodo_Renov_Contrato", FechaFin, Personal_Id, Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Update_Ficha_Contrato( string Personal, string Compania_Id, string Planilla_Id, string ApellidoPa, string ApellidoMa, string Nombres, string Direccion,string Telefono, string Celular, string TelEmer, string Email, DateTime FechaNac, string Dni, string Banco_Id, string NroCta, string BancoCTS,string NroCtaCTS,
            string RegPensionario, string CUSP,string ECivil, string NroHijos, string Alergias, string Area_Id, string Cargo_Id, string SeguroMed, string Fiscalizado
            , String Personal_Codigo_SAP, String Ccosto_Id, String Personal_SAP_Cobranza, String Email_Personal)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_UpdateFichaContrato", Personal, Compania_Id, Planilla_Id, ApellidoPa, ApellidoMa, Nombres, Direccion, Telefono, Celular, TelEmer, Email, FechaNac, Dni, Banco_Id, NroCta, BancoCTS, NroCtaCTS,
                    RegPensionario, CUSP,ECivil, NroHijos, Alergias, Area_Id, Cargo_Id, SeguroMed, Fiscalizado
                    , Personal_Codigo_SAP, Ccosto_Id, Personal_SAP_Cobranza, Email_Personal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Update_Ficha_ContratoPA(string Personal, string Compania_Id, string Planilla_Id, string Periodo_Id,string Direccion,string Banco_Id, string NroCta, string BancoCTS, string NroCtaCTS,string RegPensionario,string Area_Id, string Cargo_Id,
            string SeguroMed, string Fiscalizado, DateTime FecIngreso,DateTime FecIniContrato,DateTime FecFinContrato,string CategoriaAux,string CategoriaAux2, string Ccosto_Id, string TipoContrato)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_UpdateFichaContratoPA", Personal, Compania_Id, Planilla_Id, Periodo_Id, Direccion, Banco_Id, NroCta, BancoCTS, NroCtaCTS, RegPensionario, Area_Id, Cargo_Id,
                SeguroMed, Fiscalizado, FecIngreso, FecIniContrato, FecFinContrato, CategoriaAux, CategoriaAux2, Ccosto_Id, TipoContrato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Seguimiento_Contratos_Renovados(Ent_Contratos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaRenovarContratoSeguimiento", objE.PeriodoId, objE.Area);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Actualiza_Seguimiento_Contratos_Renovados(String Personal_Id, String Periodo_Id
                , Boolean EntregaFirmaRepresentanteLegal, Boolean Cesado, Boolean RetornadoFirmadoRepresentanteLegal
                , String NumeroEnvioMinisterioTrabajo, Boolean Renovado, Boolean Firmado, String Usuario)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Conex.CadCon(), "spu_ActualizaPeriodoRenovacionContrato", Personal_Id, Periodo_Id
                    , EntregaFirmaRepresentanteLegal, Cesado, RetornadoFirmadoRepresentanteLegal
                    , NumeroEnvioMinisterioTrabajo, Renovado, Firmado, Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
