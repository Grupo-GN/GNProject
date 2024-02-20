using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class AreaBL
    {
        AreaDA oAreaDA = new AreaDA();
        public AreaBEList Get_ListaAreas(int id_area, string no_area, string fl_activo, int id_Usuario)
        {
            try
            {
                return oAreaDA.Get_ListaAreas(id_area, no_area, fl_activo, id_Usuario);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarArea(AreaBE oAreaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oAreaDA.GuardarArea(oAreaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarArea(AreaBE oAreaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oAreaDA.EliminarArea(oAreaBE, out retorno, out msg_retorno);
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