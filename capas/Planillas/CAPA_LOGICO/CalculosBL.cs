using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class CalculosBL
    {
        public int InsertCalculos(List<CalculosBE> lstCalculosBE)
        {
            return CalculosDA.Create().InsertCalculos(lstCalculosBE);
        }
        public DataTable GetFormulasPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            return CalculosDA.Create().GetFormulasPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
        }
        public DataTable GetFijosPorPersona(string Personal_Id, string Periodo_Id)
        {
            return CalculosDA.Create().GetFijosPorPersona(Personal_Id, Periodo_Id);
        }
        public DataTable GetVariablesPorPersona(string Personal_Id, string Periodo_Id)
        {
            return CalculosDA.Create().GetVariablesPorPersona(Personal_Id, Periodo_Id);
        }
        public DataTable GetParametrosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            return CalculosDA.Create().GetParametrosPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
        }
        public DataTable GetAcumuladosPorPersona(string Personal_Id, string Periodo_Id, string Proceso_Id)
        {
            return CalculosDA.Create().GetAcumuladosPorPersona(Personal_Id, Periodo_Id, Proceso_Id);
        }
    }
}
