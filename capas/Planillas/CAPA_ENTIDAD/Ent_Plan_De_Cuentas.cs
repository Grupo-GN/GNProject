using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
   [Serializable]
    public class Ent_Plan_De_Cuentas
    {
        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }

        string _Ejercicio_Id;

        public string Ejercicio_Id
        {
            get { return _Ejercicio_Id; }
            set { _Ejercicio_Id = value; }
        }

        string _Cuenta;

        public string Cuenta
        {
            get { return _Cuenta; }
            set { _Cuenta = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public String co_tipo_agrupacion_asiento_cta { get; set; }

        Boolean _lPartida_Presupuestaria;

        public bool LPartida_Presupuestaria
        {
            get { return _lPartida_Presupuestaria; }
            set { _lPartida_Presupuestaria = value; }
        }

        bool _lCentro_De_Costo;

        public bool LCentro_De_Costo
        {
            get { return _lCentro_De_Costo; }
            set { _lCentro_De_Costo = value; }
        }

        bool _lAnalitica;

        public bool LAnalitica
        {
            get { return _lAnalitica; }
            set { _lAnalitica = value; }
        }

        string _Anexo;

        public string Anexo
        {
            get { return _Anexo; }
            set { _Anexo = value; }
        }

        string _Subanexo;

        public string Subanexo
        {
            get { return _Subanexo; }
            set { _Subanexo = value; }
        }

        string _CCosto_id;

        public string CCosto_id
        {
            get { return _CCosto_id; }
            set { _CCosto_id = value; }
        }

        string _Area_Id;

        public string Area_Id
        {
            get { return _Area_Id; }
            set { _Area_Id = value; }
        }

        string _Tipo_Trabajador_Id;

        public string Tipo_Trabajador_Id
        {
            get { return _Tipo_Trabajador_Id; }
            set { _Tipo_Trabajador_Id = value; }
        }

        bool _lArea;

        public bool LArea
        {
            get { return _lArea; }
            set { _lArea = value; }
        }

        bool _lTipo_Trabajador;

        public bool LTipo_Trabajador
        {
            get { return _lTipo_Trabajador; }
            set { _lTipo_Trabajador = value; }
        }
    }
}
