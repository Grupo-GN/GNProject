using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOEncuestaOpciones:ClsConexion
    {
        public DataTable ListaEncuestaOpcionesAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaOpcionesALL");
        }

        public DataTable ListaEncuestaOpcionesxEncuestaId(EncuestaOpciones objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaOpcionesxEncuestaId", objE.Encuesta_Id);
        }

        public Int32 InsertEncuestaOpciones(EncuestaOpciones objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEncuestaOpciones", objE.Nombre_Opcion, objE.Encuesta_Id);
        }

        public Int32 UpdateEncuestaOpciones(EncuestaOpciones objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateEncuestaOpciones", objE.Opcion_Id, objE.Nombre_Opcion);
        }

        public Int32 DeleteEncuestaOpciones(EncuestaOpciones objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteEncuestaOpciones", objE.Opcion_Id);
        }

    }
}
