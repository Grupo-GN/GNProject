using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Procesos
    {
        string _Proceso_Id;

        public string Proceso_Id
        {
            get { return _Proceso_Id; }
            set { _Proceso_Id = value; }
        }
        string _Proceso;

        public string Proceso
        {
            get { return _Proceso; }
            set { _Proceso = value; }
        }
        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }
        string _Proc_Reintegro_Id;

        public string Proc_Reintegro_Id
        {
            get { return _Proc_Reintegro_Id; }
            set { _Proc_Reintegro_Id = value; }
        }
    }
}
