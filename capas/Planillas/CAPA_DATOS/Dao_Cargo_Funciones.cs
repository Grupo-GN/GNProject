using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_Cargo_Funciones
    {

        /*AGREGADOS CARGO_FUNCIONES*/
        public static DataTable Lista_Cargo_Funciones(string Cargo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Lista_CargoFunciones", Cargo_Id);
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
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_spi_Insertar_CargoFunciones]", objE.Funcion, objE.Cargo_Id);
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
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Eliminar_CargoFuncion", objE.Cargo_Funcion_Id);
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
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Actualiza_CargoFuncion", objE.Cargo_Funcion_Id, objE.Funcion, objE.Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }






        /**/
        public static DataTable List_Cargo(string Personal_Id,string Cargo_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListCargos", Personal_Id,Cargo_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static ArrayList getFuncionesxCargo(String Personal_Id, String Cargo_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListCargos", cn))
                {
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Cargo_id", Cargo_Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }

        /* PERSONAL_FUNCIONES*/


        public static DataTable Lista_Personal_Funciones(string Personal_Id, string Cargo_Funcion_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Listar_Personal_Funciones", Personal_Id, Cargo_Funcion_Id);
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
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Insertar_Personal_Funciones", Personal_Id, Cargo_Funcion_Id);
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
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Elimina_Personal_Funciones", Personal_Id, Cargo_Funcion_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





       
    }
}
