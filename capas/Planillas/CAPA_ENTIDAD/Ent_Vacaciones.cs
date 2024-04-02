using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Vacaciones
    {
        string _Vacaciones_Id;

        public string Vacaciones_Id
        {
            get { return _Vacaciones_Id; }
            set { _Vacaciones_Id = value; }
        }

        Int32 _Item;

        public Int32 Item
        {
            get { return _Item; }
            set { _Item = value; }
        }

        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }

        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }

        string _Personal_Id;

        public string Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
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

        Int32 _Dias;

        public Int32 Dias
        {
            get { return _Dias; }
            set { _Dias = value; }
        }

        Int32 _Dias_Pagados;

        public Int32 Dias_Pagados
        {
            get { return _Dias_Pagados; }
            set { _Dias_Pagados = value; }
        }

        Int32 _Dias_Pagados_Saldo;

        public Int32 Dias_Pagados_Saldo
        {
            get { return _Dias_Pagados_Saldo; }
            set { _Dias_Pagados_Saldo = value; }
        }

        Int32 _Dias_Salida;

        public Int32 Dias_Salida
        {
            get { return _Dias_Salida; }
            set { _Dias_Salida = value; }
        }

        Int32 _Dias_Salida_Saldo;

        public Int32 Dias_Salida_Saldo
        {
            get { return _Dias_Salida_Saldo; }
            set { _Dias_Salida_Saldo = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        /*Adicionales*/
        public String Periodo_Id { get; set; }
        public String Area_Id { get; set; }
        public String CatAuxiliar_Id { get; set; }
        public DateTime fe_fin_desde { get; set; }
        public DateTime fe_fin_hasta { get; set; }

    }
}
