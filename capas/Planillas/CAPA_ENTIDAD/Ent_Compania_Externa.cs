using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Compania_Externa
    {
        string _Compania_Externa_Id;

        public string Compania_Externa_Id
        {
            get { return _Compania_Externa_Id; }
            set { _Compania_Externa_Id = value; }
        }

        string _Razon_Social;

        public string Razon_Social
        {
            get { return _Razon_Social; }
            set { _Razon_Social = value; }
        }

        string _RUC;

        public string RUC
        {
            get { return _RUC; }
            set { _RUC = value; }
        }

        string _CIIU_Id;

        public string CIIU_Id
        {
            get { return _CIIU_Id; }
            set { _CIIU_Id = value; }
        }

        Boolean _Destaque_Envio;

        public Boolean Destaque_Envio
        {
            get { return _Destaque_Envio; }
            set { _Destaque_Envio = value; }
        }

        Boolean _Destaque_Recibo;

        public Boolean Destaque_Recibo
        {
            get { return _Destaque_Recibo; }
            set { _Destaque_Recibo = value; }
        }

        string _Fecha_Ini;

        public string Fecha_Ini
        {
            get { return _Fecha_Ini; }
            set { _Fecha_Ini = value; }
        }

        string _Fecha_Fin;

        public string Fecha_Fin
        {
            get { return _Fecha_Fin; }
            set { _Fecha_Fin = value; }
        }
    }
}
