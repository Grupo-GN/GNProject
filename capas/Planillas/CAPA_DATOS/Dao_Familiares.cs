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
    public static class Dao_Familiares
    {
        /*FPS*/
        public static DataTable Lista_Vinculo_Familiar()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Vinculo_Familiar");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Tipo_Doc_Paternidad()
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Tipo_Doc_Paternidad");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Lista_Familiares(Ent_Familiares objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Familiares", objE.Familiar_Id, objE.Personal_Id, objE.Apellido_Paterno /*nombre Completo*/, objE.Estado_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Familiares(Ent_Familiares objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Familiares"
                    , objE.Personal_Id, objE.Apellido_Paterno, objE.Apellido_Materno, objE.Nombres
                    , objE.Sexo_Id, objE.Tipo_Vinculo_Id, objE.Fecha_Nacimiento, objE.Tipo_Doc_Id
                    , objE.Nro_Doc, objE.Tipo_Carta_Id, objE.Nro_Carta_Atencion, objE.Domicilio_Propio
                    , objE.Dpto, objE.Prov, objE.Dist, objE.Motivo_Baja_Id, objE.Estado_Id, objE.Tipo_Doc_Paternidad_Id
                    , objE.Nro_Doc_Paternidad, objE.Fecha_Alta, objE.Fecha_Baja, objE.Tipo_Baja_DH_Id
                    , objE.Nro_RD_Incapacidad, objE.Tipo_Via_Id, objE.Nombre_Via, objE.Numero_Via
                    , objE.Interior_Via, objE.Tipo_Zona_Id, objE.Nombre_Zona, objE.Referencia
                    , objE.Afiliado_eps, objE.PAIS_EMISOR_DOC_ID, objE.MES_CONCEPCION, objE.DEPARTAMENTO
                    , objE.MANZANA, objE.LOTE, objE.KILOMETRO, objE.BLOCK, objE.ETAPA, objE.LDISTANCIA_ID
                    , objE.TELEFONO, objE.CORREO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Familiares(Ent_Familiares objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Familiares"
                    , objE.Familiar_Id, objE.Personal_Id, objE.Apellido_Paterno, objE.Apellido_Materno, objE.Nombres
                    , objE.Sexo_Id, objE.Tipo_Vinculo_Id, objE.Fecha_Nacimiento, objE.Tipo_Doc_Id
                    , objE.Nro_Doc, objE.Tipo_Carta_Id, objE.Nro_Carta_Atencion, objE.Domicilio_Propio
                    , objE.Dpto, objE.Prov, objE.Dist, objE.Motivo_Baja_Id, objE.Estado_Id, objE.Tipo_Doc_Paternidad_Id
                    , objE.Nro_Doc_Paternidad, objE.Fecha_Alta, objE.Fecha_Baja, objE.Tipo_Baja_DH_Id
                    , objE.Nro_RD_Incapacidad, objE.Tipo_Via_Id, objE.Nombre_Via, objE.Numero_Via
                    , objE.Interior_Via, objE.Tipo_Zona_Id, objE.Nombre_Zona, objE.Referencia
                    , objE.Afiliado_eps, objE.PAIS_EMISOR_DOC_ID, objE.MES_CONCEPCION, objE.DEPARTAMENTO
                    , objE.MANZANA, objE.LOTE, objE.KILOMETRO, objE.BLOCK, objE.ETAPA, objE.LDISTANCIA_ID
                    , objE.TELEFONO, objE.CORREO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Familiares(Ent_Familiares objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Familiares", objE.Familiar_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
