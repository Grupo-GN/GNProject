using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_D_Fijos
    {
        /*FPS*/
        public static DataTable Lista_D_Fijos(Ent_D_Fijos objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return Dao_D_Fijos.Lista_D_Fijos(objE, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_D_Fijos_Genera(Ent_D_Fijos objE)
        {
            try
            {
                return Dao_D_Fijos.Inserta_D_Fijos_Genera(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //20200226
        public static DataTable Inserta_D_Fijos_Genera_x_Concepto(Ent_D_Fijos objE)
        {
            try
            {
                return Dao_D_Fijos.Inserta_D_Fijos_Genera_x_Concepto(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_D_Fijos_Masivo(Ent_D_Fijos objE, string delimitador, int cant_registros)
        {
            try
            {
                return Dao_D_Fijos.Actualiza_D_Fijos_Masivo(objE, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_D_Fijos(Ent_D_Fijos objE)
        {
            try
            {
                return Dao_D_Fijos.Elimina_D_Fijos(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ActualizarDatoPorPersona(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            try
            {
                return Dao_D_Fijos.ActualizarDatoPorPersona(PeriodoId, PersonalId, ConceptoId, Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ActualizarDatoPorPersona_Acumulados(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor, decimal Valor_Ant)
        {
            try
            {
                //20180716
                //return Dao_D_Fijos.ActualizarDatoPorPersona_Acumulados(PeriodoId, PersonalId, ConceptoId, Valor, Valor_Ant);
                return Dao_D_Fijos.ActualizarDatoPorPersona_Acumulados2(PeriodoId, PersonalId, ConceptoId, Valor, Valor_Ant);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable ActualizarDatoPorPersonaV2(string PeriodoId, string PersonalId, string ConceptoId, decimal Valor)
        {
            return Dao_D_Fijos.ActualizarDatoPorPersonaV2(PeriodoId, PersonalId, ConceptoId, Valor);
        }

        /*20180603*/
        public static DataTable Lista_D_Fijosv2(Ent_D_Fijos objE, string fl_Sin_Valor)
        {
            try
            {
                /*fl_Sin_Valor => NULL ó '':Todos|0:Con Valor|1:Sin Valor*/
                return Dao_D_Fijos.Lista_D_Fijosv2(objE, fl_Sin_Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
