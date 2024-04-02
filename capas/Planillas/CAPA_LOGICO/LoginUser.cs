using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_LOGICO
{
    public class LoginUser
    {

        public bool verificarUser(string user, string pass, String rucEmpresa)
        {
            CAPA_DATOS.ControllerUser u = new CAPA_DATOS.ControllerUser();
            return u.verificarUser(user, pass, rucEmpresa);
        }
    }
}
