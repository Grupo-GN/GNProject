using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.ApplicationBlocks.Data;
using System.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOContenidos:ClsConexion
    {
        public DataTable ListaContenidos()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "Select Contenido_Id, Categoria, Descripcion, Ruta_Img from I_Contenidos order by Categoria");
        }

        public DataTable ListaContenidosxId(Contenidos objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, "Select Contenido_Id, Categoria, Descripcion, Ruta_Img from I_Contenidos where Contenido_Id='" + objE.Contenido_Id + "'");
        }

        public Int32 UpdateContenidosxId(Contenidos objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), CommandType.Text, "Update I_Contenidos SET Descripcion='" + objE.Descripcion + "', Ruta_Img='" + objE.Ruta_Img + "' where Contenido_Id='" + objE.Contenido_Id + "'");
        }

    }
}
