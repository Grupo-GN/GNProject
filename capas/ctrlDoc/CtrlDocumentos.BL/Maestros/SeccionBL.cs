using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class SeccionBL
    {
        SeccionDA oSeccionDA = new SeccionDA();
        public SeccionBEList Get_ListaSeccion(int id_seccion, string no_seccion, int id_area, string fl_activo, int id_Usuario)
        {
            try
            {
                return oSeccionDA.Get_ListaSeccion(id_seccion, no_seccion, id_area, fl_activo, id_Usuario);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarSeccion(SeccionBE oSeccionBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oSeccionDA.GuardarSeccion(oSeccionBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarSeccion(SeccionBE oSeccionBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oSeccionDA.EliminarSeccion(oSeccionBE, out retorno, out msg_retorno);
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