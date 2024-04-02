using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public class Dao_Incidencias
    {
        public static DataTable Lista_Campos_D_Fijos()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_incidencias_d_fijos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Campos_Incidencia_x_Tabla(Ent_Incidencias objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "SP_CAMPOS_INCIDENCIAS",objE.Tabla);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Campos_Personal()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_capos_personal");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Incidencias(Ent_Incidencias objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_incidencias",objEN.Tabla,objEN.campos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Inserta_Incidencias(Ent_Incidencias objEN)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_incidencias", objEN.Tabla, objEN.campos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Lista_Campos_Personal_Activo()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_campos_personal_activo");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
