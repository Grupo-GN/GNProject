using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Concepto_Remunerativo
    {
        /*FPS*/
        public static DataTable Lista_Concepto_Remunerativo()
        {
            try
            {
                return Dao_Concepto_Remunerativo.Lista_Concepto_Remunerativo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para Listar Conceptos Remunerativo por el id
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static DataTable Lista_Concepto_Remunerativo(int flag)
        {
            try
            {
                return Dao_Concepto_Remunerativo.Lista_Concepto_Remunerativo(flag);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
