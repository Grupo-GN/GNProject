using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class TipoContratoBL
    {
        TipoContratoDA oTipoContratoDA = new TipoContratoDA();
        public TipoContratoBEList Get_ListaTipoContratos(int id_TipoContrato, string no_TipoContrato, string fl_activo)
        {
            try
            {
                return oTipoContratoDA.Get_ListaTipoContratos(id_TipoContrato, no_TipoContrato, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarTipoContrato(TipoContratoBE oTipoContratoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oTipoContratoDA.GuardarTipoContrato(oTipoContratoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarTipoContrato(TipoContratoBE oTipoContratoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oTipoContratoDA.EliminarTipoContrato(oTipoContratoBE, out retorno, out msg_retorno);
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