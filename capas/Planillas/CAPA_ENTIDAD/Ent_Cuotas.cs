using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Cuotas
    {
        string _Cuotas_Id;

        public string Cuotas_Id
        {
            get { return _Cuotas_Id; }
            set { _Cuotas_Id = value; }
        }

        string _Cuota_Desc;

        public string Cuota_Desc
        {
            get { return _Cuota_Desc; }
            set { _Cuota_Desc = value; }
        }

        string _Cta_Cte_Id;

        public string Cta_Cte_Id
        {
            get { return _Cta_Cte_Id; }
            set { _Cta_Cte_Id = value; }
        }

        string _Proceso_Id;

        public string Proceso_Id
        {
            get { return _Proceso_Id; }
            set { _Proceso_Id = value; }
        }

        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }

        Decimal _Monto;

        public Decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        string _Estado_Pago_Id;

        public string Estado_Pago_Id
        {
            get { return _Estado_Pago_Id; }
            set { _Estado_Pago_Id = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        Decimal _Monto_Dolares;

        public Decimal Monto_Dolares
        {
            get { return _Monto_Dolares; }
            set { _Monto_Dolares = value; }
        }
    }
}
