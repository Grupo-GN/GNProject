using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class PlanillaBL
    {
        PlanillaDA oPlanillaDA = new PlanillaDA();
        public PlanillaBEList Get_ListaPlanilla(int id_Planilla, string no_Planilla, string fl_activo)
        {
            try
            {
                return oPlanillaDA.Get_ListaPlanilla(id_Planilla, no_Planilla, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarPlanilla(PlanillaBE oPlanillaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPlanillaDA.GuardarPlanilla(oPlanillaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarPlanilla(PlanillaBE oPlanillaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPlanillaDA.EliminarPlanilla(oPlanillaBE, out retorno, out msg_retorno);
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