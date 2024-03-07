using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtrlDocumentos.BE;
using CtrlDocumentos.DA;

namespace CtrlDocumentos.BL
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
    }
}
