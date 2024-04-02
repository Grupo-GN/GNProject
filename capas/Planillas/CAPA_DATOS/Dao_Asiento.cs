using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;

namespace CAPA_DATOS
{
    public static class Dao_Asiento
    {
        /*FPS*/
        public static DataTable Lista_Asiento(Ent_Asiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Asiento", objE.Asiento_Id, objE.Compania_Id, objE.Ejercicio_Id, objE.Descripcion, objE.Planilla_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Asiento(Ent_Asiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Asiento", objE.Compania_Id, objE.Ejercicio_Id, objE.Planilla_Id, objE.Descripcion, objE.Glosa, objE.Libro, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Asiento(Ent_Asiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Asiento", objE.Asiento_Id, objE.Compania_Id, objE.Ejercicio_Id, objE.Planilla_Id, objE.Descripcion, objE.Glosa, objE.Libro, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Asiento(Ent_Asiento objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Asiento", objE.Asiento_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void Get_CuentasContablesMs_Mantenimiento(string tipoMant,string Planilla_Id, 
            string Proceso_Id,string Concepto_Id, int Correlativo, string CuentaContable, string Glosa,
            string Cargo) 
        {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("spu_CuentasContablesMs_Mantenimiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                            cn.Open();
                            cmd.Parameters.AddWithValue("@tipoMant", tipoMant);
                            cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                            cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                            cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                            cmd.Parameters.AddWithValue("@Correlativo", Correlativo);
                            cmd.Parameters.AddWithValue("@CuentaContable", CuentaContable);
                            cmd.Parameters.AddWithValue("@Glosa", Glosa);
                            cmd.Parameters.AddWithValue("@Cargo", Cargo);
                            cmd.ExecuteNonQuery();
                    }
                }
        }

        public static DataTable  Get_CuentasContablesMs_Listado(string Planilla_Id,
           string Proceso_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_CuentasContablesMs_Listar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@Proceso_Id", Proceso_Id);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }


    }
}
