using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;


namespace CAPA_DATOS
{
    public static class Dao_Plan_De_Cuentas
    {

        public static DataTable Lista_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Plan_De_Cuentas", objE.Compania_Id, objE.Ejercicio_Id, objE.Cuenta, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*FPS*/ /*MODIFICO MICHAEL A LISTA (MUY PESADO)*/
        public static List<Ent_Plan_De_Cuentas> Lista_Plan_De_Cuentas_MS(string Compania_Id, 
            string Ejercicio_Id,string Cuenta, string Descripcion)
        {
   
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_sps_Plan_De_Cuentas_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", Ejercicio_Id);
                    cmd.Parameters.AddWithValue("@vi_Cuenta", Cuenta);
                    cmd.Parameters.AddWithValue("@vi_Descripcion", Descripcion);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Ent_Plan_De_Cuentas> oLista = new List<Ent_Plan_De_Cuentas>();
                    while (dr.Read()) {
                        Ent_Plan_De_Cuentas objE = new Ent_Plan_De_Cuentas();
                        objE.Compania_Id = dr.GetValue(0).ToString();
                        objE.Ejercicio_Id = dr.GetValue(1).ToString();
                        objE.Cuenta = dr.GetValue(2).ToString();
                        objE.Descripcion = dr.GetValue(3).ToString();
                        objE.LPartida_Presupuestaria = Convert.ToBoolean(dr.GetValue(4).ToString());
                        objE.LCentro_De_Costo = Convert.ToBoolean(dr.GetValue(5).ToString());
                        objE.LAnalitica = Convert.ToBoolean(dr.GetValue(6).ToString());
                        objE.Anexo = dr.GetValue(7).ToString();
                        objE.Subanexo = dr.GetValue(8).ToString();
                        objE.CCosto_id = dr.GetValue(9).ToString();
                        objE.Area_Id = dr.GetValue(10).ToString();
                        objE.Tipo_Trabajador_Id = dr.GetValue(11).ToString();
                        objE.LArea = Convert.ToBoolean(dr.GetValue(12).ToString());
                        objE.LTipo_Trabajador = Convert.ToBoolean(dr.GetValue(13).ToString());
                        oLista.Add(objE);
                    }
                    return oLista;
                }
           }

                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Plan_De_Cuentas", objE.Compania_Id, objE.Ejercicio_Id, objE.Cuenta, objE.Descripcion);
    
        }

        public static DataTable Inserta_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Plan_De_Cuentas", objE.Compania_Id, objE.Ejercicio_Id, objE.Cuenta, objE.Descripcion, objE.LPartida_Presupuestaria, objE.LCentro_De_Costo, objE.LAnalitica, objE.Anexo, objE.Subanexo, objE.CCosto_id, objE.Area_Id, objE.Tipo_Trabajador_Id, objE.LArea, objE.LTipo_Trabajador, objE.co_tipo_agrupacion_asiento_cta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Plan_De_Cuentas", objE.Compania_Id, objE.Ejercicio_Id, objE.Cuenta, objE.Descripcion, objE.LPartida_Presupuestaria, objE.LCentro_De_Costo, objE.LAnalitica, objE.Anexo, objE.Subanexo, objE.CCosto_id, objE.Area_Id, objE.Tipo_Trabajador_Id, objE.LArea, objE.LTipo_Trabajador, objE.co_tipo_agrupacion_asiento_cta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Plan_De_Cuentas(Ent_Plan_De_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Plan_De_Cuentas", objE.Compania_Id, objE.Ejercicio_Id, objE.Cuenta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Lista Tipo de Cuentas => Debe|Haber*/
        public static DataTable Lista_Tipo_Cuenta()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Cuenta");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
