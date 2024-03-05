using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.ApplicationBlocks.Data;
using System.Data;

namespace Capas.Portal.Datos
{
    public class DAOCorreos:ClsConexion
    {
        public String GetCorreosdeUsuriosAll(String strOpcion)
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(Conexion(), "usp_CorreosdeUsuariosAll", strOpcion);
            String Correos = dt.Rows[0][0].ToString();
            dt.Dispose();
            return Correos;
        }
    }
}
