using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class PersonalBL
    {
        public DataTable GetPersonalActivo(string Periodo_Id, string Area_Id = "", string Categoria_Auxiliar_Id = "")
        {
            return PersonalDA.Create().GetPersonalActivo(Periodo_Id, Area_Id, Categoria_Auxiliar_Id);
        }
        public DataTable GetPersonalActivoxProceso(string Periodo_Id, string Area_Id, string Categoria_Auxiliar_Id, string Proceso_Id, string Proyecto_Id, string Personal_Ids)
        {
            return PersonalDA.Create().GetPersonalActivoxProceso(Periodo_Id, Area_Id, Categoria_Auxiliar_Id, Proceso_Id, Proyecto_Id, Personal_Ids,
                ""); //no se envía prm "incluye cesados, es solo para opcion de registro de pagos de liquidacion"
        }
        public DataTable GetPersonalActivoxProceso_PagoLiquida(string Periodo_Id, string Area_Id, string Categoria_Auxiliar_Id, string Proceso_Id, string Proyecto_Id, string Personal_Ids
            , string flIncluyeCesados)
        {
            return PersonalDA.Create().GetPersonalActivoxProceso(Periodo_Id, Area_Id, Categoria_Auxiliar_Id, Proceso_Id, Proyecto_Id, Personal_Ids
                , flIncluyeCesados);
        }
    }
}
