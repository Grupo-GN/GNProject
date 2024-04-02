using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Personal_Establecimientos
    {
        string _Personal_Id;

        public string Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
        }

        string _Establecimiento_Id;

        public string Establecimiento_Id
        {
            get { return _Establecimiento_Id; }
            set { _Establecimiento_Id = value; }
        }

        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }

        Decimal _Tasa;

        public Decimal Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }

        Boolean _Destacado_Enviado;

        public Boolean Destacado_Enviado
        {
            get { return _Destacado_Enviado; }
            set { _Destacado_Enviado = value; }
        }

        Boolean _Destacado_Recibido;

        public Boolean Destacado_Recibido
        {
            get { return _Destacado_Recibido; }
            set { _Destacado_Recibido = value; }
        }
    }
}
