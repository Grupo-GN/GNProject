using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Conceptos
    {
        string _Concepto_Id;

        public string Concepto_Id
        {
            get { return _Concepto_Id; }
            set { _Concepto_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Detalle;

        public string Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }

        string _Origen;

        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        string _Tipo_Dato;

        public string Tipo_Dato
        {
            get { return _Tipo_Dato; }
            set { _Tipo_Dato = value; }
        }

        string _Comentario;

        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }

        string _Nombre_Abrev;

        public string Nombre_Abrev
        {
            get { return _Nombre_Abrev; }
            set { _Nombre_Abrev = value; }
        }

        Decimal _Valor_defecto;

        public Decimal Valor_defecto
        {
            get { return _Valor_defecto; }
            set { _Valor_defecto = value; }
        }

        Int32 _lMostrar_En_Boleta;

        public Int32 LMostrar_En_Boleta
        {
            get { return _lMostrar_En_Boleta; }
            set { _lMostrar_En_Boleta = value; }
        }

        string _Boleta_Columna;

        public string Boleta_Columna
        {
            get { return _Boleta_Columna; }
            set { _Boleta_Columna = value; }
        }

        string _Boleta_Proceso;

        public string Boleta_Proceso
        {
            get { return _Boleta_Proceso; }
            set { _Boleta_Proceso = value; }
        }

        string _Cubo_Columna;

        public string Cubo_Columna
        {
            get { return _Cubo_Columna; }
            set { _Cubo_Columna = value; }
        }

        string _Cubo_Proceso;

        public string Cubo_Proceso
        {
            get { return _Cubo_Proceso; }
            set { _Cubo_Proceso = value; }
        }

        string _Grupo_Id;

        public string Grupo_Id
        {
            get { return _Grupo_Id; }
            set { _Grupo_Id = value; }
        }

        Int32 _Nro_Decimales;

        public Int32 Nro_Decimales
        {
            get { return _Nro_Decimales; }
            set { _Nro_Decimales = value; }
        }

        Int32 _Boleta_nro_orden;

        public Int32 Boleta_nro_orden
        {
            get { return _Boleta_nro_orden; }
            set { _Boleta_nro_orden = value; }
        }

        Boolean _lMostrar_En_Cubo;

        public Boolean LMostrar_En_Cubo
        {
            get { return _lMostrar_En_Cubo; }
            set { _lMostrar_En_Cubo = value; }
        }

        Boolean _lMostrar_Totalizado;

        public Boolean LMostrar_Totalizado
        {
            get { return _lMostrar_Totalizado; }
            set { _lMostrar_Totalizado = value; }
        }

        Boolean _lMostrar_TotalizadoComplete;

        public Boolean LMostrar_TotalizadoComplete
        {
            get { return _lMostrar_TotalizadoComplete; }
            set { _lMostrar_TotalizadoComplete = value; }
        }

        Boolean _lMostrar_TotalizadoAnual;

        public Boolean LMostrar_TotalizadoAnual
        {
            get { return _lMostrar_TotalizadoAnual; }
            set { _lMostrar_TotalizadoAnual = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        DateTime _Fecha_Modif;

        public DateTime Fecha_Modif
        {
            get { return _Fecha_Modif; }
            set { _Fecha_Modif = value; }
        }

        string _Concepto_Remunerativo_Id;

        public string Concepto_Remunerativo_Id
        {
            get { return _Concepto_Remunerativo_Id; }
            set { _Concepto_Remunerativo_Id = value; }
        }

        Boolean _lTotal;

        public Boolean LTotal
        {
            get { return _lTotal; }
            set { _lTotal = value; }
        }

        Boolean _LMOSTRAR_EN_ASIENTO;

        public Boolean LMOSTRAR_EN_ASIENTO
        {
            get { return _LMOSTRAR_EN_ASIENTO; }
            set { _LMOSTRAR_EN_ASIENTO = value; }
        }

        string _Codigo_Auxiliar;

        public string Codigo_Auxiliar
        {
            get { return _Codigo_Auxiliar; }
            set { _Codigo_Auxiliar = value; }
        }

        Boolean _lDoble_FF;

        public Boolean LDoble_FF
        {
            get { return _lDoble_FF; }
            set { _lDoble_FF = value; }
        }

        Boolean _lI_Acumulados;

        public Boolean LI_Acumulados
        {
            get { return _lI_Acumulados; }
            set { _lI_Acumulados = value; }
        }

        Boolean _lMostrar_TotalizadoAnualMinus;

        public Boolean LMostrar_TotalizadoAnualMinus
        {
            get { return _lMostrar_TotalizadoAnualMinus; }
            set { _lMostrar_TotalizadoAnualMinus = value; }
        }

        Boolean _lMostrar_TotalizadoAnualDias;

        public Boolean LMostrar_TotalizadoAnualDias
        {
            get { return _lMostrar_TotalizadoAnualDias; }
            set { _lMostrar_TotalizadoAnualDias = value; }
        }

        Boolean _lMostrar_TotalizadoAnualDiasMinus;

        public Boolean LMostrar_TotalizadoAnualDiasMinus
        {
            get { return _lMostrar_TotalizadoAnualDiasMinus; }
            set { _lMostrar_TotalizadoAnualDiasMinus = value; }
        }

        Boolean _lMostrar_UtilidadesRemuVigente;

        public Boolean LMostrar_UtilidadesRemuVigente
        {
            get { return _lMostrar_UtilidadesRemuVigente; }
            set { _lMostrar_UtilidadesRemuVigente = value; }
        }

        Boolean _lMostrar_UtilidadesRemuVigenteMinus;

        public Boolean LMostrar_UtilidadesRemuVigenteMinus
        {
            get { return _lMostrar_UtilidadesRemuVigenteMinus; }
            set { _lMostrar_UtilidadesRemuVigenteMinus = value; }
        }

        Boolean _Afecto_5ta;

        public Boolean Afecto_5ta
        {
            get { return _Afecto_5ta; }
            set { _Afecto_5ta = value; }
        }

        string _Base_Conceptos_Id;

        public string Base_Conceptos_Id
        {
            get { return _Base_Conceptos_Id; }
            set { _Base_Conceptos_Id = value; }
        }

        Boolean _lMostrar_Base;

        public Boolean LMostrar_Base
        {
            get { return _lMostrar_Base; }
            set { _lMostrar_Base = value; }
        }
        Boolean _MostrarMant;

        public Boolean MostrarMant
        {
            get { return _MostrarMant; }
            set { _MostrarMant = value; }
        }

        

        //20190503
        Boolean _FlagAfecto;
        public bool FlagAfecto { get { return _FlagAfecto; }  set {  _FlagAfecto = value; } }

        //20190807
        Boolean _FlagValorCero;
        public bool FlagValorCero { get { return _FlagValorCero; } set { _FlagValorCero = value; } }
    }
}
