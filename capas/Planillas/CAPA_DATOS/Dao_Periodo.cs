using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Periodo
    {
        /*FPS*/
        public static DataTable Lista_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Periodo", objE.Periodo_Id, objE.Ejercicio_Id, objE.Planilla_Id, objE.Descripcion, objE.Estado_Id, objE.Compania_Id, objE.Mes_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Periodo", objE.Descripcion, objE.Planilla_Id, objE.Mes_Id, objE.Semana_Id, objE.Semana_enMes, objE.Fecha_Ini, objE.Fecha_Fin, objE.Tipo_Cambio, objE.Estado_Id, objE.Compania_Id, objE.Flag_PagarLiqBenef);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Periodo_Masivo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Periodo_Masivo", objE.Compania_Id, objE.Mes_Id /*Mes_Id contiene el Ejercicio_Id*/, objE.Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Periodo", objE.Periodo_Id, objE.Descripcion, objE.Planilla_Id, objE.Mes_Id, objE.Semana_Id, objE.Semana_enMes, objE.Fecha_Ini, objE.Fecha_Fin, objE.Tipo_Cambio, objE.Estado_Id, objE.Compania_Id, objE.Flag_PagarLiqBenef);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Periodo(Ent_Periodo objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Periodo", objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
