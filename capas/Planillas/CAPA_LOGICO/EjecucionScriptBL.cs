using CAPA_DATOS;
using CAPA_ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_LOGICO
{
    public class EjecucionScriptBL
    {
        public String ES_ValidaQuery(String cadena, String codRUCEmpresa)
        {
            String valor = String.Empty;
            try
            {
                return valor = new EjecucionScriptDA().ES_ValidaQuery(cadena, codRUCEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public Int32 ES_InsertarScript(EjecucionScriptBE oEjecucionScriptBE, String codRUCEmpresa)
        {
            try
            {
                return new EjecucionScriptDA().ES_InsertarScript(oEjecucionScriptBE, codRUCEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 ES_UpdateScript(EjecucionScriptBE oEjecucionScriptBE, String codRUCEmpresa)
        {
            try
            {
                return new EjecucionScriptDA().ES_UpdateScript(oEjecucionScriptBE, codRUCEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
