using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSCronogramaMes
    {
        DAOCronogramaMes objDatos = new DAOCronogramaMes();
        public DataTable ListaCronogramaMes()
        {
            return objDatos.ListaCronogramaMes();
        }
        public List<CronogramaMes> GetCronogramaMesAll()
        {
            return objDatos.GetCronogramaMesAll();
        }
        public DataTable ListaCronogramaMesAll()
        {
            return objDatos.ListaCronogramaMesAll();
        }
        public DataTable ListaCronogramaMesxId(CronogramaMes objE)
        {
            return objDatos.ListaCronogramaMesxId(objE);
        }

        public Int32 InsertCronogramaMes(CronogramaMes objE)
        {
            return objDatos.InsertCronogramaMes(objE);
        }

        public Int32 UpdateCronogramaMes(CronogramaMes objE)
        {
            return objDatos.UpdateCronogramaMes(objE);
        }

        public Int32 DeleteCronogramaMes(CronogramaMes objE)
        {
            return objDatos.DeleteCronogramaMes(objE);
        }

        public DataTable ListaCronogramaMesxArea(CronogramaMes objE)
        {
            return objDatos.ListaCronogramaMesxArea(objE);
        }

    }
}
