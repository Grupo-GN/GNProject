using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class CompaniaBL
    {
        public DataTable GetCompania(string Compania_Id)
        {
            return CompaniaDA.Create().GetCompania(Compania_Id);
        }
    }
}
