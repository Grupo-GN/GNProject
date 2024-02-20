using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class ParametroBL
    {
        ParametroDA oParametroDA = new ParametroDA();
        public ParametroBEList Get_BandejaParametros(int id_parametro, string no_tabla, string fl_activo)
        {
            try
            {
                return oParametroDA.Get_BandejaParametros(id_parametro, no_tabla, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void GuardarParametro(ParametroBE oParametroBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oParametroDA.GuardarParametro(oParametroBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void EliminarParametro(ParametroBE oParametroBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oParametroDA.EliminarParametro(oParametroBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        //Detalle
        public ParametroDetalleBEList Get_BandejaParametrosDetalle(int id_parametro, int id_parametro_detalle, string fl_activo)
        {
            try
            {
                return oParametroDA.Get_BandejaParametrosDetalle(id_parametro, id_parametro_detalle, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void GuardarParametroDetalle(ParametroDetalleBE oParametroDetalleBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oParametroDA.GuardarParametroDetalle(oParametroDetalleBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void EliminarParametroDetalle(ParametroDetalleBE oParametroDetalleBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oParametroDA.EliminarParametroDetalle(oParametroDetalleBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public ParametroDetalleBEList Get_BandejaParametrosDetalle_TipoDocumento(String ids_plantilla_doc, String no_tipo_doc_archivo, String fl_activo)
        {
            try
            {
                return oParametroDA.Get_BandejaParametrosDetalle_TipoDocumento(ids_plantilla_doc, no_tipo_doc_archivo, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
    }
}
