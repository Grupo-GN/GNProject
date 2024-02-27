using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class ComboBL
    {
        ComboDA oComboDA = new ComboDA();
        public ComboBEList Get_ListaCombo(String codigo, String co_padre = "", String co_usuario = "")
        {
            try
            {
                ComboBEList oComboBEList = oComboDA.Get_ListaCombo(codigo, co_padre, co_usuario);
                return oComboBEList;
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
