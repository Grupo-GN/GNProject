using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSFaq
    {
        Datos.DAOFaq objDatos = new DAOFaq();

        public void UpdateOrden(String Faq_Id, Int32 SortOrder)
        {
            try
            {
                objDatos.UpdateOrden(Faq_Id, SortOrder);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Faq> GetFaqAll()
        {
            return objDatos.GetFaqAll();
        }
        public DataTable ListaFaqAll()
        {
            return objDatos.ListaFaqAll();
        }

        public DataTable ListaFaqxId(Faq objE)
        {
            return objDatos.ListaFaqxId(objE);
        }

        public DataTable ListaFaqxArea(Faq objE)
        {
            return objDatos.ListaFaqxArea(objE);
        }

        public Int32 InsertFaq(Faq objE)
        {
            return objDatos.InsertFaq(objE);
        }

        public Int32 UpdateFaq(Faq objE)
        {
            return objDatos.UpdateFaq(objE);
        }

        public Int32 DeleteFaq(Faq objE)
        {
            return objDatos.DeleteFaq(objE);
        }

    }
}
