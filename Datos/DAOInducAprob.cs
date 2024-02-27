using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOInducAprob:ClsConexion
    {
        public Int32 InsertInducAprob(InducAprob objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertInducAprob", objE.Categoria_Auxiliar_Id, objE.Personal_Id);
        }

        public Int32 UpdateInducAprob(InducAprob objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateInducAprob", objE.Categoria_Auxiliar_Id, objE.Personal_Id);
        }

        public Int32 DeleteInducAprob(InducAprob objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteInducAprob", objE.Categoria_Auxiliar_Id, objE.Personal_Id);
        }

        public DataTable ListaInducAprobAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListInducAprobALL");
        }

        public DataTable ListaInducAprobxArea(InducAprob objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListInducAprobxArea", objE.Categoria_Auxiliar_Id);
        }

    }
}
