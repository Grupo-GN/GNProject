using GNProject.Entity.DA;
using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Entity.BL
{
    public class PerfilBL
    {
        PerfilDA oPerfilDA = new PerfilDA();
        public PerfilBEList Get_ListaPerfiles(int id_perfil, string no_perfil, string fl_activo)
        {
            try
            {
                return oPerfilDA.Get_ListaPerfiles(id_perfil, no_perfil, fl_activo);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void GuardarPerfil(PerfilBE oPerfilBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPerfilDA.GuardarPerfil(oPerfilBE, out retorno, out msg_retorno);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

        public void EliminarPerfil(PerfilBE oPerfilBE, out int retorno, out String msg_retorno)
        {
            try
            {
                oPerfilDA.EliminarPerfil(oPerfilBE, out retorno, out msg_retorno);
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