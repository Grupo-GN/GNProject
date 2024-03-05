using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSEncuestaRespuestas
    {
        Datos.DAOEncuestaRespuestas objDatos = new DAOEncuestaRespuestas();
        public Boolean ExisteVotoEncuestaxUserName(String Encuesta_Id, String User_Name)
        {
            return objDatos.ExisteVotoEncuestaxUserName(Encuesta_Id, User_Name);
        }

        public DataTable ListaEncuestaResultadosxId(EncuestaRespuestas objE)
        {
            return objDatos.ListaEncuestaResultadosxId(objE);
        }

        public DataTable ListaEncuestaRespuestasAll()
        {
            return objDatos.ListaEncuestaRespuestasAll();
        }

        public DataTable ListaEncuestaRespuestasxEncuestaId(EncuestaRespuestas objE)
        {
            return ListaEncuestaRespuestasxEncuestaId(objE);
        }

        public Int32 InsertEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return objDatos.InsertEncuestaRespuestas(objE);
        }

        public Int32 UpdateEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return objDatos.UpdateEncuestaRespuestas(objE);
        }

        public Int32 DeleteEncuestaRespuestas(EncuestaRespuestas objE)
        {
            return objDatos.DeleteEncuestaRespuestas(objE);
        }

    }
}
