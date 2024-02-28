using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.oAcceso
{
    public class controller_Acceso
    {
        private static controller_Acceso Instance = null;
        public static controller_Acceso Get_Instance()
        {
            return Instance == null ? Instance = new controller_Acceso() : Instance;
        }


    }
}
