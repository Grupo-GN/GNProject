using GNProject.Entity.DA;
using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Entity.BL
{
    public class UsuarioBL
    {
        UsuarioDA oUsuarioDA = new UsuarioDA();
        public UsuarioBE Get_UsuarioxLogin(String login, out int retorno, out String retorno_msg)
        {
            try
            {
                return oUsuarioDA.Get_UsuarioxLogin(login, out retorno, out retorno_msg);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public UsuarioBEList Get_ListaUsuarios(UsuarioBE oUsuarioBE)
        {
            try
            {
                return oUsuarioDA.Get_ListaUsuarios(oUsuarioBE);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarUsuario(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oUsuarioDA.GuardarUsuario(oUsuarioBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarUsuario(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oUsuarioDA.EliminarUsuario(oUsuarioBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public CorreoBE setRestablecePassword(UsuarioBE oUsuarioBE, out int retorno, out String retorno_msg)
        {
            try
            {
                return oUsuarioDA.setRestablecePassword(oUsuarioBE, out retorno, out retorno_msg);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarUsuario_Master(UsuarioBE oUsuarioBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oUsuarioDA.GuardarUsuario_Master(oUsuarioBE, out retorno, out msg_retorno);
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