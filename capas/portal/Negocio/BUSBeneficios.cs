using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Entidad;
using Capas.Portal.Datos;


namespace Capas.Portal.Negocio
{
    public class BUSBeneficios
    {
        Datos.DAOBeneficios objDatos = new DAOBeneficios();
        public List<Beneficios> GetBeneficiosAll()
        {
            return objDatos.GetBeneficiosAll();
        }
        public DataTable ListaBeneficioAll()
        {
            return objDatos.ListaBeneficioAll();
        }
        public DataTable ListaBeneficioxId(Beneficios objE)
        {
            return objDatos.ListaBeneficioxId(objE);
        }

        public Int32 InsertBeneficio(Beneficios objE)
        {
            return objDatos.InsertBeneficio(objE);
        }

        public Int32 UpdateBeneficio(Beneficios objE)
        {
            return objDatos.UpdateBeneficio(objE);
        }

        public Int32 DeleteBeneficio(Beneficios objE)
        {
            return objDatos.DeleteBeneficio(objE);
        }

    }
}
