using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;
using CAPA_ENTIDAD.EntMs;
namespace CAPA_LOGICO
{
    public static class Log_Contratos
    {

        
        public static List<CAPA_ENTIDAD.Ent_DiferenciaFechas> DiferenciaFechas(string FechaInicial,string FechaFinal)
        {

            return Dao_Contratos.GetDiferenciaFechas(FechaInicial,FechaFinal);
        }
      

        public static DataTable Reporte_TiempoServicio(string Personal_Id,  string FechaFinal)
        {
            try
            {
                return Dao_Contratos.Reporte_TiempoServicio(Personal_Id,FechaFinal);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static DataTable Lista_Correos_Contratos()
        {
            try
            {
                return Dao_Contratos.Lista_Correos_Contratos();
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
                return Dao_Contratos.Lista_Renovar_Contratos(objE);
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
                return Dao_Contratos.Lista_Renovar_Contratos_Renovados(objE);
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
                return Dao_Contratos.Lista_Renovar_Contratos_RenovadosPRC(objE);
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
                return Dao_Contratos.GenerarRegistrosFinContrato_Mes(objE);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static DataTable Lista_Empleados_Contratos(string Codigo_Id)
        {
            try
            {
                return Dao_Contratos.Lista_Empleados_Contratos(Codigo_Id);
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
                return Dao_Contratos.Lista_Contrato();
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
                return Dao_Contratos.Lista_Periodo_Renov_Contrato(Personal_Id,Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        public static DataTable Insertar_Periodo_Renov_Contrato(string Personal_Id, string Periodo_Id)
        {
            try
            {
                return Dao_Contratos.Insertar_Periodo_Renov_Contrato(Personal_Id,Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         }


        public static DataTable Actualiza_Periodo_Renov_Contrato(DateTime FechaFin, string Personal_Id, string Periodo_Id)
        {
            try
            {
                return Dao_Contratos.Actualiza_Periodo_Renov_Contrato(FechaFin,Personal_Id, Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }



        public static DataTable Update_Ficha_Contrato(string Personal, string Compania_Id, string Planilla_Id, string ApellidoPa, string ApellidoMa, string Nombres, string Direccion, string Telefono, string Celular, string TelEmer, string Email, DateTime FechaNac, string Dni, string Banco_Id, string NroCta, string BancoCTS, string NroCtaCTS,
            string RegPensionario, string CUSP, string ECivil, string NroHijos, string Alergias, string Area_Id, string Cargo_Id, string SeguroMed, string Fiscalizado
            , String Personal_Codigo_SAP, String Ccosto_Id, String Personal_SAP_Cobranza, String Email_Personal)
        {
            try
            {
                return Dao_Contratos.Update_Ficha_Contrato(Personal, Compania_Id, Planilla_Id, ApellidoPa, ApellidoMa, Nombres, Direccion, Telefono, Celular, TelEmer, Email, FechaNac, Dni, Banco_Id, NroCta, BancoCTS, NroCtaCTS,
                RegPensionario, CUSP, ECivil, NroHijos, Alergias, Area_Id, Cargo_Id, SeguroMed, Fiscalizado
                , Personal_Codigo_SAP, Ccosto_Id, Personal_SAP_Cobranza, Email_Personal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          }


        public static DataTable Update_Ficha_ContratoPA(string Personal, string Compania_Id, string Planilla_Id, string Periodo_Id, string Direccion, string Banco_Id, string NroCta, string BancoCTS, string NroCtaCTS, string RegPensionario, string Area_Id, string Cargo_Id,
            string SeguroMed, string Fiscalizado, DateTime FecIngreso, DateTime FecIniContrato, DateTime FecFinContrato, string CategoriaAux, string CategoriaAux2, string Ccosto_Id, string TipoContrato)
        {
            try
            {
                return Dao_Contratos.Update_Ficha_ContratoPA(Personal, Compania_Id, Planilla_Id, Periodo_Id, Direccion, Banco_Id, NroCta, BancoCTS, NroCtaCTS, RegPensionario, Area_Id, Cargo_Id,
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
                return Dao_Contratos.Lista_Seguimiento_Contratos_Renovados(objE);
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
                Dao_Contratos.Actualiza_Seguimiento_Contratos_Renovados(Personal_Id, Periodo_Id
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