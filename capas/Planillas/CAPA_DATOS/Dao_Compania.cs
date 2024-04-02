using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public static class Dao_Compania
    {
        /*FPS*/
        public static DataTable Lista_Compania(Ent_Compania objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Compania", objE.Compania_Id, objE.Descripcion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Inserta_Compania(Ent_Compania objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spi_Compania", objE.Descripcion, objE.Direccion, objE.Representante, objE.Ruc, objE.Dpto, objE.Prov, objE.Dist, objE.Codigo_tel_soles, objE.Codigo_tel_dolares, objE.Cta_soles, objE.Cta_dolares, objE.Path, objE.Reg_Patronal, objE.Num_Telf, objE.Tip_cta_Id, objE.Tipo_DocIde, objE.Nro_DocIde, objE.Area_AFP, objE.Telf_Area_AFP, objE.Nro_Libro, objE.Nro_Partida, objE.CIIU_Id, objE.Cia_Default, objE.Flag_Pool_Proceso
                    , objE.SMTP_Host, objE.SMTP_Port, objE.SMTP_SSL, objE.SMTP_Mail_Address, objE.SMTP_Display_Name, objE.SMTP_User, objE.SMTP_Clave);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Actualiza_Compania(Ent_Compania objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spu_Compania", objE.Compania_Id, objE.Descripcion, objE.Direccion, objE.Representante, objE.Ruc, objE.Dpto, objE.Prov, objE.Dist, objE.Codigo_tel_soles, objE.Codigo_tel_dolares, objE.Cta_soles, objE.Cta_dolares, objE.Path, objE.Reg_Patronal, objE.Num_Telf, objE.Tip_cta_Id, objE.Tipo_DocIde, objE.Nro_DocIde, objE.Area_AFP, objE.Telf_Area_AFP, objE.Nro_Libro, objE.Nro_Partida, objE.CIIU_Id, objE.Cia_Default, objE.Flag_Pool_Proceso, objE.LogoRuta, objE.LogoImagen,objE.FirmaImagen
                    , objE.SMTP_Host, objE.SMTP_Port, objE.SMTP_SSL, objE.SMTP_Mail_Address, objE.SMTP_Display_Name, objE.SMTP_User, objE.SMTP_Clave);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable Elimina_Compania(Ent_Compania objE)
        {
            try
            {
                return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_spd_Compania", objE.Compania_Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
