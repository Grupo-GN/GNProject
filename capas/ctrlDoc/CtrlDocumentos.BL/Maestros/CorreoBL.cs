using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class CorreoBL
    {
        CorreoDA oCorreoDA = new CorreoDA();
        public CorreoBEList Get_BandejaCorreos(int id_correo, string no_asunto, string fl_activo)
        {
            try
            {
                return oCorreoDA.Get_BandejaCorreos(id_correo, no_asunto, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void GuardarCorreo(CorreoBE oCorreoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oCorreoDA.GuardarCorreo(oCorreoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void EliminarCorreo(CorreoBE oCorreoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oCorreoDA.EliminarCorreo(oCorreoBE, out retorno, out msg_retorno);
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
