using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Views.sistemaPlanillas.code
{
    public class ControlMantenimientos
    {
        public ControlMantenimientos()
        {
            //
            // ESTA CLASE SIRVE PARA PREGUNTAR SI SE CARGARON LOS DATOS DEL PERSONAL EN MANTENIMIENTO
            //
        }

        public static int nCargar = 0;  //variable para no cargar doble vez los datos del mantenimiento Personal

        public static int nPosback;
    }
}