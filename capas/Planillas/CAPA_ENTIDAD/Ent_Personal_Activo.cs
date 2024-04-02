using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    [Serializable]
    public class Ent_Personal_Activo
    {
        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }
        string _Periodo_Id;

        public string Periodo_Id
        {
            get { return _Periodo_Id; }
            set { _Periodo_Id = value; }
        }
        string _Personal_Id;

        public string Personal_Id
        {
            get { return _Personal_Id; }
            set { _Personal_Id = value; }
        }
        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }
        DateTime _Fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _Fecha_ingreso; }
            set { _Fecha_ingreso = value; }
        }
        DateTime _Fecha_cese;

        public DateTime Fecha_cese
        {
            get { return _Fecha_cese; }
            set { _Fecha_cese = value; }
        }
        DateTime _Fecha_ini_contrato;

        public DateTime Fecha_ini_contrato
        {
            get { return _Fecha_ini_contrato; }
            set { _Fecha_ini_contrato = value; }
        }
        DateTime _Fecha_fin_contrato;

        public DateTime Fecha_fin_contrato
        {
            get { return _Fecha_fin_contrato; }
            set { _Fecha_fin_contrato = value; }
        }
        string _Categoria_Id;

        public string Categoria_Id
        {
            get { return _Categoria_Id; }
            set { _Categoria_Id = value; }
        }
        string _Cargo_Id;

        public string Cargo_Id
        {
            get { return _Cargo_Id; }
            set { _Cargo_Id = value; }
        }
        string _Situacion_Id;

        public string Situacion_Id
        {
            get { return _Situacion_Id; }
            set { _Situacion_Id = value; }
        }
        string _Afp_Id;

        public string Afp_Id
        {
            get { return _Afp_Id; }
            set { _Afp_Id = value; }
        }
        string _Ccosto_Id;

        public string Ccosto_Id
        {
            get { return _Ccosto_Id; }
            set { _Ccosto_Id = value; }
        }
        string _Dpto;

        public string Dpto
        {
            get { return _Dpto; }
            set { _Dpto = value; }
        }
        string _Prov;

        public string Prov
        {
            get { return _Prov; }
            set { _Prov = value; }
        }
        string _Dist;

        public string Dist
        {
            get { return _Dist; }
            set { _Dist = value; }
        }
        string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        string _Nro_cta;

        public string Nro_cta
        {
            get { return _Nro_cta; }
            set { _Nro_cta = value; }
        }
        string _Moneda_cta_Id;

        public string Moneda_cta_Id
        {
            get { return _Moneda_cta_Id; }
            set { _Moneda_cta_Id = value; }
        }
        string _Banco_cta_Id;

        public string Banco_cta_Id
        {
            get { return _Banco_cta_Id; }
            set { _Banco_cta_Id = value; }
        }
        string _Nro_cta_cts;

        public string Nro_cta_cts
        {
            get { return _Nro_cta_cts; }
            set { _Nro_cta_cts = value; }
        }
        string _Moneda_cta_cts_Id;

        public string Moneda_cta_cts_Id
        {
            get { return _Moneda_cta_cts_Id; }
            set { _Moneda_cta_cts_Id = value; }
        }
        string _Banco_cta_cts_Id;

        public string Banco_cta_cts_Id
        {
            get { return _Banco_cta_cts_Id; }
            set { _Banco_cta_cts_Id = value; }
        }
        string _Proyecto_Id;

        public string Proyecto_Id
        {
            get { return _Proyecto_Id; }
            set { _Proyecto_Id = value; }
        }
        string _Pry_Operacion_Id;

        public string Pry_Operacion_Id
        {
            get { return _Pry_Operacion_Id; }
            set { _Pry_Operacion_Id = value; }
        }
        string _Pry_Categoria_Id;

        public string Pry_Categoria_Id
        {
            get { return _Pry_Categoria_Id; }
            set { _Pry_Categoria_Id = value; }
        }
        string _Flag_Distribuido;

        public string Flag_Distribuido
        {
            get { return _Flag_Distribuido; }
            set { _Flag_Distribuido = value; }
        }
        string _Observaciones;

        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        string _Area_Id;

        public string Area_Id
        {
            get { return _Area_Id; }
            set { _Area_Id = value; }
        }
        string _Categoria2_Id;

        public string Categoria2_Id
        {
            get { return _Categoria2_Id; }
            set { _Categoria2_Id = value; }
        }
        string _Tipo_Trabajador_Id;

        public string Tipo_Trabajador_Id
        {
            get { return _Tipo_Trabajador_Id; }
            set { _Tipo_Trabajador_Id = value; }
        }
        string _Nivel_Educativo_Id;

        public string Nivel_Educativo_Id
        {
            get { return _Nivel_Educativo_Id; }
            set { _Nivel_Educativo_Id = value; }
        }
        Boolean _Discapacidad;

        public Boolean Discapacidad
        {
            get { return _Discapacidad; }
            set { _Discapacidad = value; }
        }
        string _SCTR_Salud_Id;

        public string SCTR_Salud_Id
        {
            get { return _SCTR_Salud_Id; }
            set { _SCTR_Salud_Id = value; }
        }
        string _SCTR_Pension_Id;

        public string SCTR_Pension_Id
        {
            get { return _SCTR_Pension_Id; }
            set { _SCTR_Pension_Id = value; }
        }
        string _Tipo_Contrato_Id;

        public string Tipo_Contrato_Id
        {
            get { return _Tipo_Contrato_Id; }
            set { _Tipo_Contrato_Id = value; }
        }
        Boolean _Jornada_Atipica;

        public Boolean Jornada_Atipica
        {
            get { return _Jornada_Atipica; }
            set { _Jornada_Atipica = value; }
        }
        Boolean _Jornada_Maxima;

        public Boolean Jornada_Maxima
        {
            get { return _Jornada_Maxima; }
            set { _Jornada_Maxima = value; }
        }
        Boolean _Horario_Nocturno;

        public Boolean Horario_Nocturno
        {
            get { return _Horario_Nocturno; }
            set { _Horario_Nocturno = value; }
        }
        Boolean _Sindicalizado;

        public Boolean Sindicalizado
        {
            get { return _Sindicalizado; }
            set { _Sindicalizado = value; }
        }
        string _EPS_Id;

        public string EPS_Id
        {
            get { return _EPS_Id; }
            set { _EPS_Id = value; }
        }
        Boolean Ingresos_5ta_Inafectos;

        public Boolean Ingresos_5ta_Inafectos1
        {
            get { return Ingresos_5ta_Inafectos; }
            set { Ingresos_5ta_Inafectos = value; }
        }
        string _Situacion_Especial_Id;

        public string Situacion_Especial_Id
        {
            get { return _Situacion_Especial_Id; }
            set { _Situacion_Especial_Id = value; }
        }
        string _Seguro_Medico_Id;

        public string Seguro_Medico_Id
        {
            get { return _Seguro_Medico_Id; }
            set { _Seguro_Medico_Id = value; }
        }
        Boolean _Madre_Resp_Fam;

        public Boolean Madre_Resp_Fam
        {
            get { return _Madre_Resp_Fam; }
            set { _Madre_Resp_Fam = value; }
        }
        string _Tipo_Centro_Form_Prof_Id;

        public string Tipo_Centro_Form_Prof_Id
        {
            get { return _Tipo_Centro_Form_Prof_Id; }
            set { _Tipo_Centro_Form_Prof_Id = value; }
        }
        string _RUC_Destaque;

        public string RUC_Destaque
        {
            get { return _RUC_Destaque; }
            set { _RUC_Destaque = value; }
        }
        string _Motivo_Fin_Per_Lab_Id;

        public string Motivo_Fin_Per_Lab_Id
        {
            get { return _Motivo_Fin_Per_Lab_Id; }
            set { _Motivo_Fin_Per_Lab_Id = value; }
        }
        string _Tipo_Mod_Formativa_Id;

        public string Tipo_Mod_Formativa_Id
        {
            get { return _Tipo_Mod_Formativa_Id; }
            set { _Tipo_Mod_Formativa_Id = value; }
        }
        string _Nro_CITT;

        public string Nro_CITT
        {
            get { return _Nro_CITT; }
            set { _Nro_CITT = value; }
        }
        string _Cod_Contrato;

        public string Cod_Contrato
        {
            get { return _Cod_Contrato; }
            set { _Cod_Contrato = value; }
        }
        DateTime _Fecha_Impresion_Contrato;

        public DateTime Fecha_Impresion_Contrato
        {
            get { return _Fecha_Impresion_Contrato; }
            set { _Fecha_Impresion_Contrato = value; }
        }
        string _EPSPLAN_ID;

        public string EPSPLAN_ID
        {
            get { return _EPSPLAN_ID; }
            set { _EPSPLAN_ID = value; }
        }
        Int32 _Cantidad_Titular;

        public Int32 Cantidad_Titular
        {
            get { return _Cantidad_Titular; }
            set { _Cantidad_Titular = value; }
        }
        Int32 _Cantidad_Dependientes;

        public Int32 Cantidad_Dependientes
        {
            get { return _Cantidad_Dependientes; }
            set { _Cantidad_Dependientes = value; }
        }
        Int32 _Cantidad_Hmayores;

        public Int32 Cantidad_Hmayores
        {
            get { return _Cantidad_Hmayores; }
            set { _Cantidad_Hmayores = value; }
        }
        string _Categoria_Auxiliar_Id;

        public string Categoria_Auxiliar_Id
        {
            get { return _Categoria_Auxiliar_Id; }
            set { _Categoria_Auxiliar_Id = value; }
        }
        string _Categoria_Auxiliar2_Id;

        public string Categoria_Auxiliar2_Id
        {
            get { return _Categoria_Auxiliar2_Id; }
            set { _Categoria_Auxiliar2_Id = value; }
        }
        string _Personal_Anexo_Id;

        public string Personal_Anexo_Id
        {
            get { return _Personal_Anexo_Id; }
            set { _Personal_Anexo_Id = value; }
        }
        string _Personal_Anexo2_Id;

        public string Personal_Anexo2_Id
        {
            get { return _Personal_Anexo2_Id; }
            set { _Personal_Anexo2_Id = value; }
        }

        /*Para algunos Filtros*/
        string _Nombre_Completo;

        public string Nombre_Completo
        {
            get { return _Nombre_Completo; }
            set { _Nombre_Completo = value; }
        }

        //Se agrega campos 14/07/2022
        public String Nro_cta_interbancaria { get; set; }
        public String Localidad { get; set; }
        public String Area { get; set; }
        public String Seccion { get; set; }
        public String Proyecto { get; set; }
        public String Banco_pago_cia_id { get; set; }
        public String Banco_pago_cia { get; set; }
        public String Banco_pago_cts_cia_id { get; set; }
        public String Banco_pago_cts_cia { get; set; }
        public String Banco_cta { get; set; }
    }
}
