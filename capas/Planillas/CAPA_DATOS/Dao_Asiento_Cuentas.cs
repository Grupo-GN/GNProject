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
    public static class Dao_Asiento_Cuentas
    {

        public static DataRow Get_Buscar_Asiento_MS(string asientoCuentaId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Asiento_Cuentas_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@asientocuentaId", asientoCuentaId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        DataRow fila = tabla.Rows[0];
                        return fila;
                    }
                }
            }
        }



        /*FPS*/
        public static DataTable Lista_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Asiento_Cuentas", objE.Asiento_Cuenta_Id, objE.Asiento_Id, objE.Glosa, objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Asiento_Cuentas", objE.Asiento_Id, objE.Concepto_Id, objE.Proceso_Id, objE.Cuenta_Id, objE.Cuenta_Tipo, objE.Glosa, objE.co_Tipo_agrupacion_asiento_cta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Asiento_Cuentas", objE.Asiento_Cuenta_Id, objE.Asiento_Id, objE.Concepto_Id, objE.Proceso_Id, objE.Cuenta_Id, objE.Cuenta_Tipo, objE.Glosa, objE.co_Tipo_agrupacion_asiento_cta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Asiento_Cuentas(Ent_Asiento_Cuentas objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Asiento_Cuentas", objE.Asiento_Cuenta_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_TipoAgrupacionAsientoCta()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "pla_sps_tipo_agrupacion_asiento_cta");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
