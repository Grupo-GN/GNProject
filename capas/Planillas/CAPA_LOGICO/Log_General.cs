using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_General
    {
        /*FPS*/
        /*Listado de tablas pequeñas*/
        public static DataTable Lista_Estados()
        {
            return Dao_General.Lista_Estados();
        }

        public static DataTable Lista_Moneda()
        {
            return Dao_General.Lista_Moneda();
        }

        public static DataTable Lista_SCTR_Salud()
        {
            return Dao_General.Lista_SCTR_Salud();
        }

        public static DataTable Lista_SCTR_Pension()
        {
            return Dao_General.Lista_SCTR_Pension();
        }

        public static DataTable Lista_Situacion_Especial()
        {
            return Dao_General.Lista_Situacion_Especial();
        }

        public static DataTable Lista_Seguro_Medico()
        {
            return Dao_General.Lista_Seguro_Medico();
        }

        public static DataTable Lista_Tipo_Centro_Form_Prof()
        {
            return Dao_General.Lista_Tipo_Centro_Form_Prof();
        }

        public static DataTable Lista_Tipo_Mod_Formativa()
        {
            return Dao_General.Lista_Tipo_Mod_Formativa();
        }

        public static DataTable Lista_Complexion_Fisica()
        {
            return Dao_General.Lista_Complexion_Fisica();
        }

        public static DataTable Lista_Grupo_Sanguineo()
        {
            return Dao_General.Lista_Grupo_Sanguineo();
        }

        public static DataTable Lista_Talla_Ropa()
        {
            return Dao_General.Lista_Talla_Ropa();
        }

        public static DataTable Lista_Brevete_Categoria()
        {
            return Dao_General.Lista_Brevete_Categoria();
        }

    }
}
