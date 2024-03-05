using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOInducDocumento:ClsConexion
    {

        public Int32 InsertInducDocumento(String Categoria_Auxiliar_Id, String Nombre_Doc)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertInducDocumento", Categoria_Auxiliar_Id, Nombre_Doc);
        }

        public Int32 UpdateInducDocumento(String Categoria_Auxiliar_Id, String Nombre_Doc)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateInducDocumento", Categoria_Auxiliar_Id, Nombre_Doc);
        }

        public Int32 DeleteInducDocumento(String Categoria_Auxiliar_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteInducDocumento", Categoria_Auxiliar_Id);
        }
        
        public DataTable ListaInducDocumentoxArea(String Categoria_Auxiliar_Id)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaInducDocumentoxArea", Categoria_Auxiliar_Id);
        }
        
    }
}
