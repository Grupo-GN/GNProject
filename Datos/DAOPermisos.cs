using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Capas.Portal.Datos
{
    public class DAOPermisos:ClsConexion 
    {
        public DataTable ListaPermisos()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "select Permiso_Id, Nivel, Descripcion, Estado_Id from I_Permisos");
        }
    }
}
