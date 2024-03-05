using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSAnuncios
    {
        Datos.DAOAnuncios objDatos = new DAOAnuncios();

        //Anuncio anidado con los empleados nuevos
        public String GetAnuncioIdMax()
        {
            return objDatos.GetAnuncioIdMax();
        }
        public DataTable ListaAnunciosCompleto()
        {
            return objDatos.ListaAnunciosCompleto();
        }

        public DataTable ListaAnunciosCompletoAll()
        {
            return objDatos.ListaAnunciosCompletoAll();
        }

        public List<Anuncios> GetAnunciosAll()
        {
            return objDatos.GetAnunciosAll();
        }
        public DataTable ListaAnunciosAll()
        {
            return objDatos.ListaAnunciosAll();
        }

        public DataTable ListaAnunciosxId(Anuncios objE)
        {
            return objDatos.ListaAnunciosxId(objE);
        }

        public DataTable ListaAnunciosxArea(Anuncios objE)
        {
            return objDatos.ListaAnunciosxArea(objE);
        }

        public Int32 InsertAnuncios(Anuncios objE)
        {
            return objDatos.InsertAnuncios(objE);
        }

        public Int32 UpdateAnuncios(Anuncios objE)
        {
            return objDatos.UpdateAnuncios(objE);
        }

        public bool Get_Existe_IdAnuncio(string id)
        {
            return objDatos.Get_Existe_IdAnuncio(id);
        }

        public Int32 DeleteAnuncios(Anuncios objE)
        {
            return objDatos.DeleteAnuncios(objE);
        }

        //---------- Cumpleanios del Mes

        public DataTable ListaCumpleDelMes()
        {
            return objDatos.ListaCumpleDelMes();
        }

    }
}
