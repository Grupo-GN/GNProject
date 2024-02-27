using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
namespace Capas.Portal.Negocio
{
    public class BUSCorreo
    {
        DAOCorreo oDAOCorreo = new DAOCorreo();
        public List<Correo> GetCorreosAll(Int32 id_correo)
        {
            return oDAOCorreo.GetCorreosAll(id_correo);
        }
        public void GuardarCorreo(Correo oCorreo, out int retorno, out String msg_retorno)
        {
            oDAOCorreo.GuardarCorreo(oCorreo, out retorno, out msg_retorno);
        }
        public void ActualizaImagenCorreo(Int32 id_correo, String opc, String no_imagen)
        {
            oDAOCorreo.ActualizaImagenCorreo(id_correo, opc, no_imagen);
        }
    }
}
