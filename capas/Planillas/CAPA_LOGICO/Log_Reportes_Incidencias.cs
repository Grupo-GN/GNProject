using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;
namespace CAPA_LOGICO
{
    public class Log_Reportes_Incidencias
    {
        public static DataTable Lista_Incidencias_Personal_d_fijos(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return Dao_Reporte_Incidencias.Lista_Incidencias_Personal_d_fijos(objE);
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
                return Dao_Reporte_Incidencias.Lista_Conceptos(objE);
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
                return Dao_Reporte_Incidencias.Lista_Incidencias_Personal(objE);
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
                return Dao_Reporte_Incidencias.Lista_Incidencias_Personal_Activo(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Filtar_Personal(Ent_Reporte_Incidencias objE)
        {
            try
            {
                return Dao_Reporte_Incidencias.Filtrar_Personal(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
