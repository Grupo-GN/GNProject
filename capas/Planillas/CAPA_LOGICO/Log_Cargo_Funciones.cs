using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;
using System.Collections;

namespace CAPA_LOGICO
{
    public static class Log_Cargo_Funciones
    {


        /*AGREGADOS CARGO FUNCIONES*/

        public static DataTable Lista_Cargo_Funciones(string Cargo_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.Lista_Cargo_Funciones(Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Cargo_Funciones(Ent_Cargo_Funciones objE)
        {
            try
            {
                return Dao_Cargo_Funciones.Inserta_Cargo_Funciones(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Cargo_Funciones(Ent_Cargo_Funciones objE)
        {
            try
            {
                return Dao_Cargo_Funciones.Elimina_Cargo_Funciones(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Cargo_Funciones(Ent_Cargo_Funciones objE)
        {
            try
            {
                return Dao_Cargo_Funciones.Actualiza_Cargo_Funciones(objE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        /*FPS*/

        public static DataTable List_Cargo(string Personal_Id,string Cargo_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.List_Cargo(Personal_Id,Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ArrayList getFuncionesxCargo(String Personal_Id, String Cargo_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.getFuncionesxCargo(Personal_Id, Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /*PERSONAL_FUNCIONES*/

        public static DataTable Lista_Personal_Funciones(string Personal_Id, string Cargo_Funcion_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.Lista_Personal_Funciones(Personal_Id, Cargo_Funcion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Insertar_Personal_Funciones(string Personal_Id, string Cargo_Funcion_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.Insertar_Personal_Funciones(Personal_Id, Cargo_Funcion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataTable Elimina_Personal_Funciones(string Personal_Id, string Cargo_Funcion_Id)
        {
            try
            {
                return Dao_Cargo_Funciones.Elimina_Personal_Funciones(Personal_Id, Cargo_Funcion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      
    }
}
