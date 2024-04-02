using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Periodo
    {
        public String Ejercicio_Id { get; set; }

        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }

        string _Mes_Id;

        public string Mes_Id
        {
            get { return _Mes_Id; }
            set { _Mes_Id = value; }
        }

        string _Semana_Id;

        public string Semana_Id
        {
            get { return _Semana_Id; }
            set { _Semana_Id = value; }
        }

        Int32 _Semana_enMes;

        public Int32 Semana_enMes
        {
            get { return _Semana_enMes; }
            set { _Semana_enMes = value; }
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

        Decimal _Tipo_Cambio;

        public Decimal Tipo_Cambio
        {
            get { return _Tipo_Cambio; }
            set { _Tipo_Cambio = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }
        bool _Flag_PagarLiqBenef;

        public bool Flag_PagarLiqBenef
        {
            get { return _Flag_PagarLiqBenef; }
            set { _Flag_PagarLiqBenef = value; }
        }
    }
}
