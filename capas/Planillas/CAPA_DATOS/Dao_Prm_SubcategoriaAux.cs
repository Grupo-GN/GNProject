using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Prm_SubcategoriaAux
    {
        /*FPS*/
        public static DataTable Lista_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Prm_SubcategoriaAux", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Prm_SubcategoriaAux", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id, objE.Concepto_Id, objE.Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Prm_SubcategoriaAux_Genera(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Prm_SubcategoriaAux_Genera", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Prm_SubcategoriaAux", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id, objE.Concepto_Id, objE.Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Prm_SubcategoriaAux_Masivo(Ent_Prm_SubcategoriaAux objE, string delimitador, Int32 cant_registros)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Prm_SubcategoriaAux_Masivo", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id, objE.Concepto_Id_Masivo, objE.Valor_Masivo, delimitador, cant_registros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Prm_SubcategoriaAux(Ent_Prm_SubcategoriaAux objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Prm_SubcategoriaAux", objE.Periodo_Id, objE.Categoria_Auxiliar2_Id, objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
