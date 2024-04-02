using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Concepto_Remunerativo
    {
        /*FPS*/
        public static DataTable Lista_Concepto_Remunerativo()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Concepto_Remunerativo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Listar el Concepto Remunerativo Por un Flag (Para Conceptos)
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static DataTable Lista_Concepto_Remunerativo(int flag)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "spu_Concepto_Remunerativo_Buscar", flag);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
