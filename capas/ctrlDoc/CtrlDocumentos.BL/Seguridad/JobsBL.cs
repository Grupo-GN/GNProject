using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CtrlDocumentos.DA.Seguridad;
using CtrlDocumentos.BE.Seguridad;
using CtrlDocumentos.BE;

namespace CtrlDocumentos.BL.Seguridad
{
    public class JobBL
    {
        JobDA oJobDA = new JobDA();
        public JobBEList Get_Job()
        {
            try
            {
                return oJobDA.Get_ListaJob();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public void EjecutarTarea(JobBE oCargoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oJobDA.EjecutarTarea(oCargoBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        public List<EnviarMailBE> EjecutarTarea_Lista(JobBE oCargoBE, out int retorno, out String msg_retorno)
        {
            try
            {
                return oJobDA.EjecutarTarea_Lista(oCargoBE, out retorno, out msg_retorno);
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
