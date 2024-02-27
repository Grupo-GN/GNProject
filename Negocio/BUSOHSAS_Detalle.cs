using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
namespace Capas.Portal.Negocio
{
    public class BUSOHSAS_Detalle
    {
        public List<OHSAS_Detalle> GetOHSASAll_Detalle(Int32 id_ohsas, Int32 id_ohsas_detalle)
        {
            return new DAOOHSAS_Detalle().GetOHSASAll_Detalle(id_ohsas, id_ohsas_detalle);
        }
        public void GuardarOHSASDetalle(OHSAS_Detalle oOHSAS_Detalle, out int retorno, out String msg_retorno)
        {
            new DAOOHSAS_Detalle().GuardarOHSASDetalle(oOHSAS_Detalle, out retorno, out msg_retorno);
        }
        public void GuardarOHSASDetalle(Int32 id_ohsas_detalle, String no_archivo)
        {
            new DAOOHSAS_Detalle().GuardarOHSASDetalle(id_ohsas_detalle, no_archivo);
        }
        public void EliminarOHSASDetalle(Int32 id_ohsas_detalle, out int retorno, out String msg_retorno)
        {
            new DAOOHSAS_Detalle().EliminarOHSASDetalle(id_ohsas_detalle, out retorno, out msg_retorno);
        }
    }
}
