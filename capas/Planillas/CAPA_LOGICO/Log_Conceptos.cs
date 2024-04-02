using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CAPA_DATOS;
using CAPA_ENTIDAD;

namespace CAPA_LOGICO
{
    public static class Log_Conceptos
    {
        /*FPS*/
        public static DataTable Lista_Conceptos_Asiento(Ent_Conceptos objE)
        {
            try
            {
                return Dao_Conceptos.Lista_Conceptos_Asiento(objE);
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
                return Dao_Conceptos.Lista_Ordenamiento_Conceptos(objE);
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
                return Dao_Conceptos.Lista_Ordenamiento_Conceptos_x_Tipo_Agregar(objE);
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
                return Dao_Conceptos.Actualiza_Conceptos_x_Distribucion(Tipo_Distribucion, objE);
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
                return Dao_Conceptos.Quitar_Conceptos_x_Distribucion(Tipo_Distribucion, objE);
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
                return Dao_Conceptos.Agregar_Conceptos_x_Distribucion(Tipo_Distribucion, objE);
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
                return Dao_Conceptos.Lista_TipoAtributosConcepto();
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
                return Dao_Conceptos.Lista_Conceptos_Atributos(compania_Id, planilla_Id, Proceso_Id);
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
                return Dao_Conceptos.Graba_Conceptos_Atributos(compania_Id, planilla_Id, Proceso_Id, Concepto_Id, Atributo_Boleta);
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
                return Dao_Conceptos.Elimina_Conceptos_Atributos(compania_Id, planilla_Id, Proceso_Id, Concepto_Id);
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
                return Dao_Conceptos.Lista_Columnas_Boleta();
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
                return Dao_Conceptos.Lista_Tipo_Concepto();
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
                return Dao_Conceptos.Lista_Origen_Concepto();
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
                return Dao_Conceptos.Lista_Grupo_Conceptos();
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
                return Dao_Conceptos.Lista_Conceptos(objE, objEProc);
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
                return Dao_Conceptos.Inserta_Conceptos(objE, objEPeriodo,estructura);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Conceptos(Ent_Conceptos objE, int idEstructura)
        {
            try
            {
                return Dao_Conceptos.Actualiza_Conceptos(objE,idEstructura);
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
                return Dao_Conceptos.Elimina_Conceptos(objE);
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
                return Dao_Conceptos.Lista_Conceptosv2(objE, objEProc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
