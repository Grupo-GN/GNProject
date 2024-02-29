using GNProject.Entity.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Entity.BL
{
    public class ComboBL
    {
        ComboDA oComboDA = new ComboDA();
        public ComboBEList Get_Combo(String codigo, String co_padre = "", Int32 id_usuario = 0)
        {
            try
            {
                ComboBEList oComboBEList = oComboDA.Get_Combo(codigo, co_padre, id_usuario);
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
        public ComboBEList Get_Combogn(String codigo, String co_padre = "", Int32 id_usuario = 0)
        {
            try
            {
                ComboBEList oComboBEList = oComboDA.Get_Combogn(codigo, co_padre, id_usuario);
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