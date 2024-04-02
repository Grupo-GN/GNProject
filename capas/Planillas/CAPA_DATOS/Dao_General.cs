using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_General
    {
        /*FPS*/
        /*Listado de tablas pequeñas*/
        public static DataTable Lista_Estados()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Estados");
        }

        public static DataTable Lista_Moneda()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Moneda");
        }

        public static DataTable Lista_SCTR_Salud()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_SCTR_Salud");
        }
        
        public static DataTable Lista_SCTR_Pension()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_SCTR_Pension");
        }

        public static DataTable Lista_Situacion_Especial()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Situacion_Especial");
        }

        public static DataTable Lista_Seguro_Medico()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Seguro_Medico");
        }

        public static DataTable Lista_Tipo_Centro_Form_Prof()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Centro_Form_Prof");
        }

        public static DataTable Lista_Tipo_Mod_Formativa()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Mod_Formativa");
        }

        public static DataTable Lista_Complexion_Fisica()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Complexion_Fisica");
        }

        public static DataTable Lista_Grupo_Sanguineo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Grupo_Sanguineo");
        }

        public static DataTable Lista_Talla_Ropa()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Talla_Ropa");
        }

        public static DataTable Lista_Brevete_Categoria()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Brevete_Categoria");
        }

    }
}
