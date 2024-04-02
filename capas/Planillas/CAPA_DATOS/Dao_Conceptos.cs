using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using CAPA_ENTIDAD;
using System.Data.SqlClient;

namespace CAPA_DATOS
{
    public static class Dao_Conceptos
    {
        /*FPS*/
        public static DataTable Lista_Conceptos_Asiento(Ent_Conceptos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Conceptos_Asiento", objE.Cubo_Proceso, objE.Cubo_Columna, objE.Origen /*En Origen se guarda el valor de Planilla_Id*/);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*INICIO DISTRIBUCION DE BOLETAS Y CUBOS*/
        public static DataTable Lista_Ordenamiento_Conceptos(Ent_Conceptos objE)
        {
            try
            {
                /*Ordenamiento de Conceptos - Distribución por Boleta o por Cubo*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Ordenamiento_Conceptos_x_Tipo", objE.Boleta_Columna, objE.Cubo_Columna, objE.Boleta_Proceso /*Proceso_Id*/);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Ordenamiento_Conceptos_x_Tipo_Agregar(Ent_Conceptos objE)
        {
            try
            {
                /*Ordenamiento de Conceptos - agregar conceptos*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Ordenamiento_Conceptos_x_Tipo_Agregar", objE.Origen /*tipo de distribucion*/, objE.Concepto_Id, objE.Detalle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Conceptos_x_Distribucion(string Tipo_Distribucion, Ent_Conceptos objE)
        {
            try
            {
                /*Actualiza el Concepto - Distribución por Boleta o por Cubo*/
                //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Conceptos_x_Distribucion", objE.Concepto_Id, Tipo_Distribucion, objE.Detalle, objE.LMostrar_En_Boleta, objE.LMostrar_En_Cubo, objE.Boleta_nro_orden, objE.FlagAfecto);
                //20190503
                using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spu_Conceptos_x_Distribucion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();

                        cmd.Parameters.AddWithValue("@vi_Concepto_Id", objE.Concepto_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Distribucion", Tipo_Distribucion);
                        cmd.Parameters.AddWithValue("@vi_Detalle", objE.Detalle);
                        cmd.Parameters.AddWithValue("@vi_lMostrar_En_Boleta", objE.LMostrar_En_Boleta);
                        cmd.Parameters.AddWithValue("@vi_lMostrar_En_Cubo", objE.LMostrar_En_Cubo);
                        cmd.Parameters.AddWithValue("@vi_Boleta_nro_orden", objE.Boleta_nro_orden);
                        cmd.Parameters.AddWithValue("@vi_FlagAfecto", objE.FlagAfecto);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            da.Fill(dt);
                            cn.Close();
                            cn.Dispose();
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Quitar_Conceptos_x_Distribucion(string Tipo_Distribucion, Ent_Conceptos objE)
        {
            try
            {
                /*Quitar Concepto Distribucion - Distribución por Boleta o por Cubo*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Quitar_Conceptos_x_Distribucion", objE.Concepto_Id, Tipo_Distribucion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Agregar_Conceptos_x_Distribucion(string Tipo_Distribucion, Ent_Conceptos objE)
        {
            try
            {
                /*Agregar Concepto Distribucion - Distribución por Boleta o por Cubo*/
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Agregar_Conceptos_x_Distribucion", objE.Concepto_Id, Tipo_Distribucion, objE.Boleta_Columna, objE.Cubo_Columna, objE.Boleta_nro_orden);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*Atributos*/
        public static DataTable Lista_TipoAtributosConcepto()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_TipoAtributosConcepto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Lista_Conceptos_Atributos(string compania_Id, string planilla_Id, string Proceso_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Conceptos_Atributos", compania_Id, planilla_Id, Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Graba_Conceptos_Atributos(string compania_Id, string planilla_Id, string Proceso_Id, string Concepto_Id, string Atributo_Boleta)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Conceptos_Atributos", compania_Id, planilla_Id, Proceso_Id, Concepto_Id, Atributo_Boleta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Elimina_Conceptos_Atributos(string compania_Id, string planilla_Id, string Proceso_Id, string Concepto_Id)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Conceptos_Atributos", compania_Id, planilla_Id, Proceso_Id, Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /*FIN DISTRIBUCION DE BOLETAS Y CUBOS*/

        public static DataTable Lista_Columnas_Boleta()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Columnas_boleta");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Tipo_Concepto()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Concepto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Origen_Concepto()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Origen_Concepto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Grupo_Conceptos()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Grupo_conceptos");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Conceptos(Ent_Conceptos objE, Ent_Procesos objEProc)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Conceptos", objE.Concepto_Id, objE.Tipo_Dato, objE.Descripcion, objE.Comentario, objE.Estado_Id, objEProc.Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Conceptos(Ent_Conceptos objE, Ent_Periodo objEPeriodo,int estructura)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Conceptos", objE.Descripcion, objE.Detalle, objE.Origen, objE.Tipo_Dato, objE.Comentario, objE.Nombre_Abrev
                    , objE.Valor_defecto, objE.LMostrar_En_Boleta, objE.Boleta_Columna, objE.Boleta_Proceso
                    , objE.Cubo_Columna, objE.Cubo_Proceso, objE.Grupo_Id, objE.Nro_Decimales, objE.Boleta_nro_orden
                    , objE.LMostrar_En_Cubo, objE.LMostrar_Totalizado, objE.LMostrar_TotalizadoComplete
                    , objE.LMostrar_TotalizadoAnual, objE.Estado_Id, objE.Fecha_Modif, objE.Concepto_Remunerativo_Id
                    , objE.LTotal, objE.LMOSTRAR_EN_ASIENTO, objE.Codigo_Auxiliar, objE.LDoble_FF, objE.LI_Acumulados
                    , objE.LMostrar_TotalizadoAnualMinus, objE.LMostrar_TotalizadoAnualDias, objE.LMostrar_TotalizadoAnualDiasMinus
                    , objE.LMostrar_UtilidadesRemuVigente, objE.LMostrar_UtilidadesRemuVigenteMinus, objE.Afecto_5ta
                    , objE.Base_Conceptos_Id, objE.LMostrar_Base, estructura
                    /*Parametro para generar el Concepto en el Personal*/
                    , objEPeriodo.Periodo_Id, objE.FlagValorCero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Conceptos(Ent_Conceptos objE,int idEstructura)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Conceptos", objE.Concepto_Id
                    , objE.Descripcion, objE.Detalle, objE.Origen, objE.Tipo_Dato, objE.Comentario, objE.Nombre_Abrev
                    , objE.Valor_defecto, objE.LMostrar_En_Boleta, objE.Boleta_Columna, objE.Boleta_Proceso
                    , objE.Cubo_Columna, objE.Cubo_Proceso, objE.Grupo_Id, objE.Nro_Decimales, objE.Boleta_nro_orden
                    , objE.LMostrar_En_Cubo, objE.LMostrar_Totalizado, objE.LMostrar_TotalizadoComplete
                    , objE.LMostrar_TotalizadoAnual, objE.Estado_Id, objE.Fecha_Modif, objE.Concepto_Remunerativo_Id
                    , objE.LTotal, objE.LMOSTRAR_EN_ASIENTO, objE.Codigo_Auxiliar, objE.LDoble_FF, objE.LI_Acumulados
                    , objE.LMostrar_TotalizadoAnualMinus, objE.LMostrar_TotalizadoAnualDias, objE.LMostrar_TotalizadoAnualDiasMinus
                    , objE.LMostrar_UtilidadesRemuVigente, objE.LMostrar_UtilidadesRemuVigenteMinus, objE.Afecto_5ta
                    , objE.Base_Conceptos_Id, objE.LMostrar_Base, idEstructura, objE.FlagValorCero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Conceptos(Ent_Conceptos objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Conceptos", objE.Concepto_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*20180603*/
        public static DataTable Lista_Conceptosv2(Ent_Conceptos objE, Ent_Procesos objEProc)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_ConceptosV2", objE.Concepto_Id, objE.Tipo_Dato, objE.Descripcion, objE.Comentario, objE.Estado_Id, objEProc.Proceso_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
