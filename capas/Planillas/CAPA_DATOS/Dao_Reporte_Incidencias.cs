using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
namespace CAPA_DATOS
{
    public class Dao_Reporte_Incidencias
    {
        public static DataTable Lista_Incidencias_Personal_d_fijos(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Listar_Incidencias_x_Personal_d_fijos",objE.Personal_id,objE.Periodo_Id,objE.Concepto_Id );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Conceptos(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Lista_Concepto_Todo",objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Incidencias_Personal(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Listar_Incidencias_x_Personal", objE.Personal_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Incidencias_Personal_Activo(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Listar_Incidencias_x_Personal_activo", objE.Personal_id, objE.Periodo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Filtrar_Personal(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_getPersonalIncidencia", objE.Tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
