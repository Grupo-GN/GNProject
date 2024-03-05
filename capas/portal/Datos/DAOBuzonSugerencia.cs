using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOBuzonSugerencia:ClsConexion
    {
        public DataTable ListaBuzonSugerenciaAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListBuzonSugerenciaAll");
        }

        public Int32 InsertBuzonSugerencia(BuzonSugerencia objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertBuzonSugerencia", objE.Titulo, objE.Sugerencia, objE.Fecha, objE.User_Name);
        }

    }
}
