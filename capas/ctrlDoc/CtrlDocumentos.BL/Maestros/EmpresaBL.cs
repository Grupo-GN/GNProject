using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.DA.Maestros;

namespace CtrlDocumentos.BL.Maestros
{
    public class EmpresaBL
    {
        EmpresaDA oEmpresaDA = new EmpresaDA();
        public List<EmpresaBE> getEmpresas(EmpresaBE oEmpresaBE)
        {
            try
            {
                return oEmpresaDA.getEmpresas(oEmpresaBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oEmpresaDA.GuardarEmpresa(oEmpresaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarLogoEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oEmpresaDA.GuardarLogoEmpresa(oEmpresaBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarEmpresa(EmpresaBE oEmpresaBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oEmpresaDA.EliminarEmpresa(oEmpresaBE, out retorno, out msg_retorno);
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
