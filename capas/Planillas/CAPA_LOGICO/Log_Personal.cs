using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;
using CAPA_ENTIDAD.EntMs;

namespace CAPA_LOGICO
{
    public static class Log_Personal
    {
        /*FPS*/
        /************************INICIO PAGINA IMPRIMIR REPORTES****************************/
        public static DataTable Lista_Personal_ImprimirReporte(Ent_Personal_Activo objE)
        {
            return Dao_Personal.Lista_Personal_ImprimirReporte(objE);
        }
        /***************************PAGINA IMPRIMIR REPORTES FIN****************************/

        /*Lista Personal que no está en el Periodo*/
        public static DataTable Lista_Personal_Faltante_Periodo(Ent_Personal_Activo objE)
        {
            return Dao_Personal.Lista_Personal_Faltante_Periodo(objE);
        }
        /*Agrega un Personal a un Periodo*/
        public static int Agrega_Personal_al_Periodo(Ent_Personal_Activo objE)
        {
            return Dao_Personal.Agrega_Personal_al_Periodo(objE);
        }
        /*Elimina un Personal de un Periodo*/
        public static int Elimina_Personal_de_Periodo(Ent_Personal_Activo objE)
        {
            return Dao_Personal.Elimina_Personal_de_Periodo(objE);
        }

        /*Listado de Personal en las Boletas*/
        public static DataTable Lista_Personal_Boleta(Ent_Personal_Activo objE)
        {
            return Dao_Personal.Lista_Personal_Boleta(objE);
        }

        public static DataTable ListaColumnPersonal()
        {
            return Dao_Personal.ListaColumnPersonal();
        }
        public static DataTable GenPersonal_Id()
        {
            return Dao_Personal.GenPersonal_Id();
        }
        public static DataTable ListaDataxPersonalId(Ent_Personal objE)
        {
            return Dao_Personal.ListaDataxPersonalId(objE);
        }
        //////public static DataSet ListaDataPersonalxPeriodo(Ent_Personal objE)
        //////{
        //////    return Dao_Personal.ListaDataPersonalxPeriodo(objE);
        //////}

        public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, 
            string Periodo_Id, string NomColumna, string Param)
        {
            return Dao_Personal.Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param);
        }

        public static DataTable Lista_Personal(Ent_Personal objE)
        {
            return Dao_Personal.Lista_Personal(objE);
        }

        public static DataSet Inserta_Personal(Ent_Personal objE, Ent_Personal_Activo objEPA)
        {
            return Dao_Personal.Inserta_Personal(objE, objEPA);
        }

        public static DataSet Actualiza_Personal(Ent_Personal objE, Ent_Personal_Activo objEPA)
        {
            return Dao_Personal.Actualiza_Personal(objE, objEPA);
        }

        public static DataSet Elimina_Personal(Ent_Personal objE)
        {
            return Dao_Personal.Elimina_Personal(objE);
        }


    }
}
