using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class Calculos_PermBL
    {
        public int InsertCalculos_Perm(List<Calculos_PermBE> lstCalculos_PermBE)
        {
            return Calculos_PermDA.Create().InsertCalculos_Perm(lstCalculos_PermBE);
        }
    }
}
