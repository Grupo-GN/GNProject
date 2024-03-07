using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class CargoBL
    {
        CargoDA oCargoDA = new CargoDA();
        public CargoBEList Get_ListaCargos(int id_Cargo, string no_Cargo, string fl_activo)
        {
            try
            {
                return oCargoDA.Get_ListaCargos(id_Cargo, no_Cargo, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarCargo(CargoBE oCargoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oCargoDA.GuardarCargo(oCargoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarCargo(CargoBE oCargoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oCargoDA.EliminarCargo(oCargoBE, out retorno, out msg_retorno);
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