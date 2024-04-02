using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    [Serializable]
    public class Ent_Personal
    {
        string Personal_Id;

        public string _Personal_Id
        {
            get { return Personal_Id; }
            set { Personal_Id = value; }
        }
        string Compania_Id;

        public string _Compania_Id
        {
            get { return Compania_Id; }
            set { Compania_Id = value; }
        }
        string Planilla_Id;

        public string _Planilla_Id
        {
            get { return Planilla_Id; }
            set { Planilla_Id = value; }
        }
        string Apellido_Paterno;

        public string _Apellido_Paterno
        {
            get { return Apellido_Paterno; }
            set { Apellido_Paterno = value; }
        }
        string Apellido_Materno;

        public string _Apellido_Materno
        {
            get { return Apellido_Materno; }
            set { Apellido_Materno = value; }
        }
        string Nombres;

        public string _Nombres
        {
            get { return Nombres; }
            set { Nombres = value; }
        }
        string Sexo_Id;

        public string _Sexo_Id
        {
            get { return Sexo_Id; }
            set { Sexo_Id = value; }
        }
        DateTime Fecha_Nacimiento;

        public DateTime _Fecha_Nacimiento
        {
            get { return Fecha_Nacimiento; }
            set { Fecha_Nacimiento = value; }
        }
        string E_Civil_Id;

        public string _E_Civil_Id
        {
            get { return E_Civil_Id; }
            set { E_Civil_Id = value; }
        }
        DateTime Fecha_Ini_AporteAFP;

        public DateTime _Fecha_Ini_AporteAFP
        {
            get { return Fecha_Ini_AporteAFP; }
            set { Fecha_Ini_AporteAFP = value; }
        }
        string Tipo_Doc_Id;

        public string _Tipo_Doc_Id
        {
            get { return Tipo_Doc_Id; }
            set { Tipo_Doc_Id = value; }
        }
        string Nro_Doc;

        public string _Nro_Doc
        {
            get { return Nro_Doc; }
            set { Nro_Doc = value; }
        }
        string Categoria_Id;

        public string _Categoria_Id
        {
            get { return Categoria_Id; }
            set { Categoria_Id = value; }
        }
        string Categoria2_Id;

        public string _Categoria2_Id
        {
            get { return Categoria2_Id; }
            set { Categoria2_Id = value; }
        }
        string Cargo_Id;

        public string _Cargo_Id
        {
            get { return Cargo_Id; }
            set { Cargo_Id = value; }
        }
        string Situacion_Id;

        public string _Situacion_Id
        {
            get { return Situacion_Id; }
            set { Situacion_Id = value; }
        }
        string Afp_Id;

        public string _Afp_Id
        {
            get { return Afp_Id; }
            set { Afp_Id = value; }
        }
        string Afp_cod_afiliacion;

        public string _Afp_cod_afiliacion
        {
            get { return Afp_cod_afiliacion; }
            set { Afp_cod_afiliacion = value; }
        }
        string Seguro_cod;

        public string _Seguro_cod
        {
            get { return Seguro_cod; }
            set { Seguro_cod = value; }
        }
        string Ccosto_Id;

        public string _Ccosto_Id
        {
            get { return Ccosto_Id; }
            set { Ccosto_Id = value; }
        }
        string Dpto;

        public string _Dpto
        {
            get { return Dpto; }
            set { Dpto = value; }
        }
        string Prov;

        public string _Prov
        {
            get { return Prov; }
            set { Prov = value; }
        }
        string Dist;

        public string _Dist
        {
            get { return Dist; }
            set { Dist = value; }
        }
        string Direccion;

        public string _Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        string Telefono;

        public string _Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        string Telefono2;

        public string _Telefono2
        {
            get { return Telefono2; }
            set { Telefono2 = value; }
        }
        string Telefono3;

        public string _Telefono3
        {
            get { return Telefono3; }
            set { Telefono3 = value; }
        }
        int Nro_Hijos;

        public int _Nro_Hijos
        {
            get { return Nro_Hijos; }
            set { Nro_Hijos = value; }
        }
        string Tip_cta_Id;

        public string _Tip_cta_Id
        {
            get { return Tip_cta_Id; }
            set { Tip_cta_Id = value; }
        }
        string Nro_cta;

        public string _Nro_cta
        {
            get { return Nro_cta; }
            set { Nro_cta = value; }
        }
        string Moneda_cta_Id;

        public string _Moneda_cta_Id
        {
            get { return Moneda_cta_Id; }
            set { Moneda_cta_Id = value; }
        }
        string Banco_cta_Id;

        public string _Banco_cta_Id
        {
            get { return Banco_cta_Id; }
            set { Banco_cta_Id = value; }
        }
        string Nro_cta_cts;

        public string _Nro_cta_cts
        {
            get { return Nro_cta_cts; }
            set { Nro_cta_cts = value; }
        }
        string Tip_cta_cts_Id;

        public string _Tip_cta_cts_Id
        {
            get { return Tip_cta_cts_Id; }
            set { Tip_cta_cts_Id = value; }
        }
        string Moneda_cta_cts_Id;

        public string _Moneda_cta_cts_Id
        {
            get { return Moneda_cta_cts_Id; }
            set { Moneda_cta_cts_Id = value; }
        }
        string Banco_cta_cts_Id;

        public string _Banco_cta_cts_Id
        {
            get { return Banco_cta_cts_Id; }
            set { Banco_cta_cts_Id = value; }
        }
        string Proyecto_Id;

        public string _Proyecto_Id
        {
            get { return Proyecto_Id; }
            set { Proyecto_Id = value; }
        }
        string Tgasto_Id;

        public string _Tgasto_Id
        {
            get { return Tgasto_Id; }
            set { Tgasto_Id = value; }
        }
        string Usuario;

        public string _Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        string Pase;

        public string _Pase
        {
            get { return Pase; }
            set { Pase = value; }
        }
        int lAdministrador;

        public int _LAdministrador
        {
            get { return lAdministrador; }
            set { lAdministrador = value; }
        }
        string Estado_Id;

        public string _Estado_Id
        {
            get { return Estado_Id; }
            set { Estado_Id = value; }
        }
        string Area_Id;

        public string _Area_Id
        {
            get { return Area_Id; }
            set { Area_Id = value; }
        }
        string Cod_Antiguo;

        public string _Cod_Antiguo
        {
            get { return Cod_Antiguo; }
            set { Cod_Antiguo = value; }
        }
        string email;

        public string _Email
        {
            get { return email; }
            set { email = value; }
        }
        string Nacionalidad_Id;

        public string _Nacionalidad_Id
        {
            get { return Nacionalidad_Id; }
            set { Nacionalidad_Id = value; }
        }
        Boolean Domiciliado;

        public Boolean _Domiciliado
        {
            get { return Domiciliado; }
            set { Domiciliado = value; }
        }
        string Tipo_Via_Id;

        public string _Tipo_Via_Id
        {
            get { return Tipo_Via_Id; }
            set { Tipo_Via_Id = value; }
        }
        string Numero_Via;

        public string _Numero_Via
        {
            get { return Numero_Via; }
            set { Numero_Via = value; }
        }
        string Interior_Via;

        public string _Interior_Via
        {
            get { return Interior_Via; }
            set { Interior_Via = value; }
        }
        string Tipo_Zona_Id;

        public string _Tipo_Zona_Id
        {
            get { return Tipo_Zona_Id; }
            set { Tipo_Zona_Id = value; }
        }
        string Nombre_Zona;

        public string _Nombre_Zona
        {
            get { return Nombre_Zona; }
            set { Nombre_Zona = value; }
        }
        string Referencia;

        public string _Referencia
        {
            get { return Referencia; }
            set { Referencia = value; }
        }
        string Tipo_Trabajador_Id;

        public string _Tipo_Trabajador_Id
        {
            get { return Tipo_Trabajador_Id; }
            set { Tipo_Trabajador_Id = value; }
        }
        string Regimen_Laboral_Id;

        public string _Regimen_Laboral_Id
        {
            get { return Regimen_Laboral_Id; }
            set { Regimen_Laboral_Id = value; }
        }
        string Nivel_Educativo_Id;

        public string _Nivel_Educativo_Id
        {
            get { return Nivel_Educativo_Id; }
            set { Nivel_Educativo_Id = value; }
        }
        Boolean Discapacidad;

        public Boolean _Discapacidad
        {
            get { return Discapacidad; }
            set { Discapacidad = value; }
        }
        string SCTR_Salud_Id;

        public string _SCTR_Salud_Id
        {
            get { return SCTR_Salud_Id; }
            set { SCTR_Salud_Id = value; }
        }
        string SCTR_Pension_Id;

        public string _SCTR_Pension_Id
        {
            get { return SCTR_Pension_Id; }
            set { SCTR_Pension_Id = value; }
        }
        string Tipo_Contrato_Id;

        public string _Tipo_Contrato_Id
        {
            get { return Tipo_Contrato_Id; }
            set { Tipo_Contrato_Id = value; }
        }
        Boolean Jornada_Atipica;

        public Boolean _Jornada_Atipica
        {
            get { return Jornada_Atipica; }
            set { Jornada_Atipica = value; }
        }
        Boolean Jornada_Maxima;

        public Boolean _Jornada_Maxima
        {
            get { return Jornada_Maxima; }
            set { Jornada_Maxima = value; }
        }
        Boolean Horario_Nocturno;

        public Boolean _Horario_Nocturno
        {
            get { return Horario_Nocturno; }
            set { Horario_Nocturno = value; }
        }
        Boolean Sindicalizado;

        public Boolean _Sindicalizado
        {
            get { return Sindicalizado; }
            set { Sindicalizado = value; }
        }
        string EPS_Id;

        public string _EPS_Id
        {
            get { return EPS_Id; }
            set { EPS_Id = value; }
        }
        Boolean Ingresos_5ta_Inafectos;

        public Boolean _Ingresos_5ta_Inafectos
        {
            get { return Ingresos_5ta_Inafectos; }
            set { Ingresos_5ta_Inafectos = value; }
        }
        string Situacion_Especial_Id;

        public string _Situacion_Especial_Id
        {
            get { return Situacion_Especial_Id; }
            set { Situacion_Especial_Id = value; }
        }
        string RUC;

        public string _RUC
        {
            get { return RUC; }
            set { RUC = value; }
        }
        string Seguro_Medico_Id;

        public string _Seguro_Medico_Id
        {
            get { return Seguro_Medico_Id; }
            set { Seguro_Medico_Id = value; }
        }
        Boolean Madre_Resp_Fam;

        public Boolean _Madre_Resp_Fam
        {
            get { return Madre_Resp_Fam; }
            set { Madre_Resp_Fam = value; }
        }
        string Tipo_Centro_Form_Prof_Id;

        public string _Tipo_Centro_Form_Prof_Id
        {
            get { return Tipo_Centro_Form_Prof_Id; }
            set { Tipo_Centro_Form_Prof_Id = value; }
        }
        string RUC_Destaque;

        public string _RUC_Destaque
        {
            get { return RUC_Destaque; }
            set { RUC_Destaque = value; }
        }
        //@Foto image,
        /// ///////////////////////////////////////////////////////////////////
        string Foto_NombreArchivo;

        public string _Foto_NombreArchivo
        {
            get { return Foto_NombreArchivo; }
            set { Foto_NombreArchivo = value; }
        }
        string Nro_Calzado;

        public string _Nro_Calzado
        {
            get { return Nro_Calzado; }
            set { Nro_Calzado = value; }
        }
        string Talla_Ropa_Id;

        public string _Talla_Ropa_Id
        {
            get { return Talla_Ropa_Id; }
            set { Talla_Ropa_Id = value; }
        }
        string Grupo_Sanguineo_Id;

        public string _Grupo_Sanguineo_Id
        {
            get { return Grupo_Sanguineo_Id; }
            set { Grupo_Sanguineo_Id = value; }
        }
        Double Estatura;

        public Double _Estatura
        {
            get { return Estatura; }
            set { Estatura = value; }
        }
        Double Peso;

        public Double _Peso
        {
            get { return Peso; }
            set { Peso = value; }
        }
        string Complexion_Fisica_Id;

        public string _Complexion_Fisica_Id
        {
            get { return Complexion_Fisica_Id; }
            set { Complexion_Fisica_Id = value; }
        }
        string Brevete_Nro;

        public string _Brevete_Nro
        {
            get { return Brevete_Nro; }
            set { Brevete_Nro = value; }
        }
        string Brevete_Categoria_Id;

        public string _Brevete_Categoria_Id
        {
            get { return Brevete_Categoria_Id; }
            set { Brevete_Categoria_Id = value; }
        }
        DateTime Brevete_Vigencia;

        public DateTime _Brevete_Vigencia
        {
            get { return Brevete_Vigencia; }
            set { Brevete_Vigencia = value; }
        }
        string Alergias;

        public string _Alergias
        {
            get { return Alergias; }
            set { Alergias = value; }
        }
        string Codigo_Auxiliar;

        public string _Codigo_Auxiliar
        {
            get { return Codigo_Auxiliar; }
            set { Codigo_Auxiliar = value; }
        }
        int Seccion_Id;

        public int _Seccion_Id
        {
            get { return Seccion_Id; }
            set { Seccion_Id = value; }
        }
        string Pais_Emisor_Doc_ID;

        public string _Pais_Emisor_Doc_ID
        {
            get { return Pais_Emisor_Doc_ID; }
            set { Pais_Emisor_Doc_ID = value; }
        }
        string LDistancia_ID;

        public string _LDistancia_ID
        {
            get { return LDistancia_ID; }
            set { LDistancia_ID = value; }
        }
        string Departamento;

        public string _Departamento
        {
            get { return Departamento; }
            set { Departamento = value; }
        }
        string Manzana;

        public string _Manzana
        {
            get { return Manzana; }
            set { Manzana = value; }
        }
        string Lote;

        public string _Lote
        {
            get { return Lote; }
            set { Lote = value; }
        }
        string Kilometro;

        public string _Kilometro
        {
            get { return Kilometro; }
            set { Kilometro = value; }
        }
        string Block;

        public string _Block
        {
            get { return Block; }
            set { Block = value; }
        }
        string Etapa;

        public string _Etapa
        {
            get { return Etapa; }
            set { Etapa = value; }
        }
        string Categoria_Ocupacional_Id;

        public string _Categoria_Ocupacional_Id
        {
            get { return Categoria_Ocupacional_Id; }
            set { Categoria_Ocupacional_Id = value; }
        }
        string Convenio_Evita_Tributacion_ID;

        public string _Convenio_Evita_Tributacion_ID
        {
            get { return Convenio_Evita_Tributacion_ID; }
            set { Convenio_Evita_Tributacion_ID = value; }
        }

        /*FPS*/
        string Periodo_Id;

        public string _Periodo_Id
        {
            get { return Periodo_Id; }
            set { Periodo_Id = value; }
        }

        string Categoria_Auxiliar_Id;
        public string _Categoria_Auxiliar_Id
        {
            get { return Categoria_Auxiliar_Id; }
            set { Categoria_Auxiliar_Id = value; }
        }

        string Categoria_Auxiliar2_Id;
        public string _Categoria_Auxiliar2_Id
        {
            get { return Categoria_Auxiliar2_Id; }
            set { Categoria_Auxiliar2_Id = value; }
        }

        /*Para algunos Filtros*/
        string _Nombre_Completo;

        public string Nombre_Completo
        {
            get { return _Nombre_Completo; }
            set { _Nombre_Completo = value; }
        }
        string _Email_Personal;
        public string Email_Personal
        {
            get { return _Email_Personal; }
            set { _Email_Personal = value; }
        }

        DateTime _FechaIngreso;
        public DateTime FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }
        DateTime _Fecha_Ini_Contrato;
        public DateTime Fecha_Ini_Contrato
        {
            get { return _Fecha_Ini_Contrato; }
            set { _Fecha_Ini_Contrato = value; }
        }
        DateTime _Fecha_Fin_Contrato;
        public DateTime Fecha_Fin_Contrato
        {
            get { return _Fecha_Fin_Contrato; }
            set { _Fecha_Fin_Contrato = value; }
        }
        //20181105
        DateTime _xFechaCese;
        public DateTime xFechaCese
        {
            get { return _xFechaCese; }
            set { _xFechaCese = value; }
        }
        string _xMotivo_Fin_Per_Lab_Id;
        public string xMotivo_Fin_Per_Lab_Id
        {
            get { return _xMotivo_Fin_Per_Lab_Id; }
            set { _xMotivo_Fin_Per_Lab_Id = value; }
        }
    }
}
