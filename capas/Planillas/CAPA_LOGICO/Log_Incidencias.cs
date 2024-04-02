using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;
namespace CAPA_LOGICO
{
    public class Log_Incidencias
    {
        public static DataTable Lista_Campos_D_fijos()
        {
            try
            {
                return Dao_Incidencias.Lista_Campos_D_Fijos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Campos_Incidencia_x_Tabla(Ent_Incidencias objEN)
        {
            try
            {
                return Dao_Incidencias.Lista_Campos_Incidencia_x_Tabla(objEN);
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
                return Dao_Incidencias.Lista_Campos_Personal();
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
                return Dao_Incidencias.Actualiza_Incidencias(objEN);
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
                return Dao_Incidencias.Inserta_Incidencias(objEN);
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
                return Dao_Incidencias.Lista_Campos_Personal_Activo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
