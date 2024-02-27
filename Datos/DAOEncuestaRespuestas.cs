using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using Capas.Portal.Entidad;

namespace Capas.Portal.Datos
{
    public class DAOEncuestaRespuestas:ClsConexion
    {
        public Boolean ExisteVotoEncuestaxUserName(String Encuesta_Id, String User_Name)
        {
            String Script = "select * from I_EncuestaRespuestas where Encuesta_Id='" + Encuesta_Id + "' and [User_Name]='" + User_Name + "'";
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(Conexion(), CommandType.Text, Script);
            Boolean rpta = false;
            if (dt.Rows.Count <= 0)
            {
                rpta = false;
            }
            else
            {
                rpta = true;
            }
            dt.Dispose();
            return rpta;
        }

        public DataTable ListaEncuestaResultadosxId(EncuestaRespuestas objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IEncuestaResultadosxEncuestaId", objE.Encuesta_Id);
        }

        public DataTable ListaEncuestaRespuestasAll()
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaRptaALL");
        }

        public DataTable ListaEncuestaRespuestasxEncuestaId(EncuestaRespuestas objE)
        {
            return SqlHelper.ExecuteDataTable(Conexion(), "usp_IListaEncuestaRptaxEncuestaId", objE.Encuesta_Id);
        }

        public Int32 InsertEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IInsertEncuestaRpta", objE.Encuesta_Id, objE.User_Name, objE.Opcion_Id);
        }

        public Int32 UpdateEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IUpdateEncuestaRpta", objE.Encuesta_Id, objE.User_Name, objE.Opcion_Id);
        }

        public Int32 DeleteEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return SqlHelper.ExecuteNonQuery(Conexion(), "usp_IDeleteEncuestaRpta", objE.Encuesta_Id, objE.User_Name);
        }

    }
}
