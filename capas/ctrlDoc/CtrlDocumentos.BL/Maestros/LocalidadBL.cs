using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class LocalidadBL
    {
        LocalidadDA oLocalidadDA = new LocalidadDA();
        public LocalidadBEList Get_ListaLocalidades(int id_localidad, string no_localidad, string fl_activo)
        {
            try
            {
                return oLocalidadDA.Get_ListaLocalidades(id_localidad, no_localidad, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarLocalidad(LocalidadBE oLocalidadBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oLocalidadDA.GuardarLocalidad(oLocalidadBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarLocalidad(LocalidadBE oLocalidadBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oLocalidadDA.EliminarLocalidad(oLocalidadBE, out retorno, out msg_retorno);
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