using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSProcedimientos
    {
        Datos.DAOProcedimientos objDatos = new DAOProcedimientos();

        public List<Procedimientos> GetProcedimientosAll()
        {
            return objDatos.GetProcedimientosAll();
        }

        public DataTable ListaProcedimientoAll()
        {
            return objDatos.ListaProcedimientoAll();
        }
        public DataTable ListaProcedimientoxId(Procedimientos objE)
        {
            return objDatos.ListaProcedimientoxId(objE);
        }

        public DataTable ListaProcedimientoxArea(Procedimientos objE)
        {
            return objDatos.ListaProcedimientoxArea(objE);
        }

        public Int32 InsertProcedimiento(Procedimientos objE)
        {
            return objDatos.InsertProcedimiento(objE);
        }

        public Int32 UpdateProcedimiento(Procedimientos objE)
        {
            return objDatos.UpdateProcedimiento(objE);
        }

        public Int32 DeleteProcedimiento(Procedimientos objE)
        {
            return objDatos.DeleteProcedimiento(objE);
        }


        #region cargaDocumentos_Michael()

        public DataTable MS_SGCO_DProcedimientos_Listar(int procedimientoId)
        {
            return objDatos.MS_SGCO_DProcedimientos_Listar(procedimientoId);
        }

        public int MS_SGCO_DProcedimientos_IAE(int tipoProceso, SGCO_DProcedimientos objE)
        {
            return objDatos.MS_SGCO_DProcedimientos_IAE(tipoProceso, objE);
        }

        public DataTable MS_SGCO_ListaDProcedimientoxId(SGCO_DProcedimientos objE)
        {
            return objDatos.MS_SGCO_ListaDProcedimientoxId(objE);
        }

        #endregion


    }
}

