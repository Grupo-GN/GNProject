using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;


namespace Capas.Portal.Negocio
{
    public class BUSEnlaces
    {
        Datos.DAOEnlaces objDatos = new DAOEnlaces();
        public List<Enlace> GetEnlacesAll(String User_Id)
        {
            return objDatos.GetEnlacesAll(User_Id);
        }
        public DataTable ListaEnlacesAll()
        {
            return objDatos.ListaEnlacesAll();
        }
        public DataTable ListaEnlacesxId(Int32 Enlace_Id)
        {
            return objDatos.ListaEnlacesxId(Enlace_Id);
        }
        public Int32 InsertEnlace(String Nom_Enlace, String Direccion, Boolean fl_VisibleSoloAdmin)
        {
            return objDatos.InsertEnlace(Nom_Enlace, Direccion, fl_VisibleSoloAdmin);
        }
        public Int32 UpdateEnlace(Int32 Enlace_Id, String Nom_Enlace, String Direccion, Boolean fl_VisibleSoloAdmin)
        {
            return objDatos.UpdateEnlace(Enlace_Id, Nom_Enlace, Direccion, fl_VisibleSoloAdmin);
        }
        public Int32 DeleteEnlace(Int32 Enlace_Id)
        {
            return objDatos.DeleteEnlace(Enlace_Id);
        }

    }
}
