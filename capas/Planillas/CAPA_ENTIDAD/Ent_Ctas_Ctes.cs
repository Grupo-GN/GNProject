using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Ctas_Ctes
    {
        string _Cta_Cte_Id;

        public string Cta_Cte_Id
        {
            get { return _Cta_Cte_Id; }
            set { _Cta_Cte_Id = value; }
        }

        string _Personal_Id;

        public string Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
        }

        string _Operacion_Id;

        public string Operacion_Id
        {
            get { return _Operacion_Id; }
            set { _Operacion_Id = value; }
        }

        string _Motivo_Id;

        public string Motivo_Id
        {
            get { return _Motivo_Id; }
            set { _Motivo_Id = value; }
        }

        Int32 _Nro_Cuotas;

        public Int32 Nro_Cuotas
        {
            get { return _Nro_Cuotas; }
            set { _Nro_Cuotas = value; }
        }

        Decimal _Monto;

        public Decimal Monto
        {
            get { return _Monto; }
            set { _Monto = value; }
        }

        string _Moneda_Id;

        public string Moneda_Id
        {
            get { return _Moneda_Id; }
            set { _Moneda_Id = value; }
        }

        DateTime _Fecha_Sistema;

        public DateTime Fecha_Sistema
        {
            get { return _Fecha_Sistema; }
            set { _Fecha_Sistema = value; }
        }

        DateTime _Fecha_Ini;

        public DateTime Fecha_Ini
        {
            get { return _Fecha_Ini; }
            set { _Fecha_Ini = value; }
        }

        DateTime _Fecha_Fin;

        public DateTime Fecha_Fin
        {
            get { return _Fecha_Fin; }
            set { _Fecha_Fin = value; }
        }

        string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        Decimal _Interes_Anual;

        public Decimal Interes_Anual
        {
            get { return _Interes_Anual; }
            set { _Interes_Anual = value; }
        }

        Decimal _Interes_Cantidad_Periodos;

        public Decimal Interes_Cantidad_Periodos
        {
            get { return _Interes_Cantidad_Periodos; }
            set { _Interes_Cantidad_Periodos = value; }
        }
        String _Cuota_Id;

        public String Cuota_Id
        {
            get { return _Cuota_Id; }
            set { _Cuota_Id = value; }
        }

        public String fl_quincenal { get; set; }
    }
}
