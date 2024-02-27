using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOInducCategoria:ClsConexion
    {
        public Int32 InsertInducCategoria(InducCategoria objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertInducCategoria", objE.NomCategoria, objE.Categoria_Auxiliar_Id);
        }

        public Int32 UpdateInducCategoria(InducCategoria objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateInducCategoria", objE.CatInduccion_Id, objE.Categoria_Auxiliar_Id);
        }

        public Int32 DeleteInducCategoria(InducCategoria objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteInducCategoria", objE.CatInduccion_Id);
        }

        public DataTable ListaInducCategoriaAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListInducCategoriaALL");
        }

        public DataTable ListaInducCategoriaxArea(InducCategoria objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListInducCategoriaxArea", objE.Categoria_Auxiliar_Id);
        }

    }
}
