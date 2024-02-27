using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;


namespace Capas.Portal.Negocio
{
    public class BUSVideos
    {
        Datos.DAOVideos objDatos = new DAOVideos();
        public Int32 InsertVideos(String Titulo, String Nombre_Video, String User_Name)
        {
            return objDatos.InsertVideos(Titulo, Nombre_Video, User_Name);
        }
        public Int32 DeleteVideos(Int32 Video_Id)
        {
            return objDatos.DeleteVideos(Video_Id);
        }
        public List<Videos> GetVideosAll()
        {
            return objDatos.GetVideosAll();
        }
        public DataTable ListVideosAll()
        {
            return objDatos.ListVideosAll();
        }
        public DataTable ListVideosxId(Int32 Video_Id)
        {
            return objDatos.ListVideosxId(Video_Id);
        }

    }
}
