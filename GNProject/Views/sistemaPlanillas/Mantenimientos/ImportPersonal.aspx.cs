using CAPA_DATOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class ImportPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> ProcesarImportPersonal(string xPeriodo, string xUsuario, string[] prm)
        {
            List<string> resultado = new List<string>();
            try
            {
                Boolean Domiciliado = true, Discapacidad = false, Jornada_Atipica = false
                , Jornada_Maxima = false, Horario_Nocturno = false
                , Sindicalizado = false, Ingresos_5ta_Inafectos = false, Madre_Resp_Fam = false;

                string Compania_Id = "01", Planilla_Id = prm[0]
                , Tipo_Doc_Id = prm[1]
                , Nro_Doc = prm[2]
                , Apellido_Paterno = prm[3]
                , Apellido_Materno = prm[4]
                , Nombres = prm[5]
                , Sexo_Id = prm[6];
                DateTime Fecha_Nacimiento = DateTime.Parse(prm[7]);
                string E_Civil_Id = prm[8];
                DateTime Fecha_Ini_AporteAFP = DateTime.Parse(prm[9])
                , Brevete_Vigencia = DateTime.Parse("01/01/1900");
                String Afp_Id = prm[10]
                , Afp_cod_afiliacion = prm[11]
                , Ccosto_Id = prm[12]
                , Proyecto_Id = prm[13]
                , Categoria_Auxiliar_Id = prm[14]
                , Categoria_Auxiliar2_Id = prm[15]
                , Telefono = prm[16]
                , Telefono2 = prm[17]
                , Telefono3 = prm[18];
                int Nro_Hijos = int.Parse(prm[19]);
                string Banco_cta_Id = prm[20]
               , Moneda_cta_Id = prm[21]
               , Tip_cta_Id = prm[22]
               , Nro_cta = prm[23]
               , Nro_cta_interbancaria = prm[24]
               , Banco_cta_cts_Id = prm[25]
               , Moneda_cta_cts_Id = prm[26]
               , Tip_cta_cts_Id = prm[27]
               , Nro_cta_cts = prm[28]
               , Email = prm[29]
               , Nacionalidad_Id = prm[30]
               , Direccion = prm[31];
                string Tipo_Via_Id = prm[32]
                , Numero_Via = prm[33]
                , Interior_Via = ""
                , Tipo_Zona_Id = prm[34]
                , Nombre_Zona = prm[35]
                , Regimen_Laboral_Id = prm[36]
                , Nivel_Educativo_Id = prm[37]
                , SCTR_Salud_Id = prm[38]
                , SCTR_Pension_Id = prm[39]
                , Tipo_Contrato_Id = prm[40]
                , EPS_Id = prm[41]
                , Email_Personal = prm[42];
                String Categoria_Id = prm[43]
                , Categoria2_Id = prm[44]
                , Area_Id = prm[45]
                , Cargo_Id = prm[46]
                , Situacion_Id = "00"
                , Seguro_cod = ""
                , Dpto = "15"
                , Prov = "01"
                , Dist = "01"
                , Tipo_Trabajador_Id = prm[47];

                String Tgasto_Id = "", Usuario = "", Pase = "";
                int LAdministrador = 0;
                //20181105
                string Cod_Antiguo = "";

                string Situacion_Especial_Id = "0"
                , RUC = ""
                , Seguro_Medico_Id = "0"
                , Tipo_Centro_Form_Prof_Id = "0"
                , RUC_Destaque = ""
                , Foto_NombreArchivo = ""
                , Nro_Calzado = "0"
                , Talla_Ropa_Id = "00"
                , Grupo_Sanguineo_Id = ""
                , Referencia = "";


                Double Estatura = 0, Peso = 0;
                string Complexion_Fisica_Id = "00", Brevete_Nro = "", Brevete_Categoria_Id = "", Alergias = "", Codigo_Auxiliar = "", Seccion_Id = "";

                /*Datos para la tabla Personal_Activo*/
                string Periodo_Id = xPeriodo;
                DateTime Fecha_ingreso = DateTime.Parse(prm[48])
                , Fecha_cese = DateTime.Parse("01/01/1900")
                , Fecha_ini_contrato = DateTime.Parse(prm[49])
                , Fecha_fin_contrato = DateTime.Parse(prm[50]);
                string Estado_Id = prm[51];


                string Pry_Operacion_Id = ""
                , Pry_Categoria_Id = "", Flag_Distribuido = "00"
                , Observaciones = ""
                , Motivo_Fin_Per_Lab_Id = ""
                , Tipo_Mod_Formativa_Id = "00"
                , Nro_CITT = "", Cod_Contrato = "";

                DateTime Fecha_Impresion_Contrato = DateTime.Parse("01/01/1900");
                string EPSPLAN_ID = "00";
                int Cantidad_Titular = 0, Cantidad_Dependientes = 0, Cantidad_Hmayores = 0;

                String Personal_Anexo_Id = "00000000"
                , Personal_Anexo2_Id = "00000000"
                , co_rol = "";
                //20181105
                if (Estado_Id == "02")
                {
                    Fecha_cese = DateTime.Parse(prm[52]);
                    Motivo_Fin_Per_Lab_Id = prm[53];
                }

                string personalcod = ControllerMaestroPersonal.GetInstance().GetPersonalIdxNroDoc(Nro_Doc);

                if (Numero_Via == "&nbsp;") Numero_Via = "";

                if (personalcod == "")
                {
                    resultado = ControllerMaestroPersonal.GetInstance().Insert_Personal_Import(
                               Compania_Id.Trim().Replace("&nbsp;", " ")
                            , Planilla_Id.Trim().Replace("&nbsp;", " ")
                            , Apellido_Paterno.Trim().Replace("&nbsp;", " ")
                            , Apellido_Materno.Trim().Replace("&nbsp;", " ")
                            , Nombres.Trim().Replace("&nbsp;", " ")
                            , Sexo_Id.Trim().Replace("&nbsp;", " ")
                            , Fecha_Nacimiento
                            , E_Civil_Id.Trim().Replace("&nbsp;", " ")
                            , Fecha_Ini_AporteAFP
                            , Tipo_Doc_Id.Trim().Replace("&nbsp;", " ")
                            , Nro_Doc.Trim().Replace("&nbsp;", " ")
                            , Categoria_Id.Trim().Replace("&nbsp;", " ")
                            , Categoria2_Id.Trim().Replace("&nbsp;", " ")
                            , Cargo_Id.Trim().Replace("&nbsp;", " ")
                            , Situacion_Id.Trim().Replace("&nbsp;", " ")
                            , Afp_Id.Trim().Replace("&nbsp;", " ")
                            , Afp_cod_afiliacion.Trim().Replace("&nbsp;", " ")
                            , Seguro_cod.Trim().Replace("&nbsp;", " ")
                            , Ccosto_Id.Trim().Replace("&nbsp;", " ")
                            , Dpto.Trim().Replace("&nbsp;", " ")
                            , Prov.Trim().Replace("&nbsp;", " ")
                            , Dist.Trim().Replace("&nbsp;", " ")
                            , Direccion.Trim().Replace("&nbsp;", " ")
                            , Telefono.Trim().Replace("&nbsp;", " ")
                            , Telefono2.Trim().Replace("&nbsp;", " ")
                            , Telefono3.Trim().Replace("&nbsp;", " ")
                            , Nro_Hijos
                            , Tip_cta_Id.Trim().Replace("&nbsp;", " ")
                            , Nro_cta.Trim().Replace("&nbsp;", " ")
                            , Moneda_cta_Id.Trim().Replace("&nbsp;", " ")
                            , Banco_cta_Id.Trim().Replace("&nbsp;", " ")
                            , Nro_cta_cts.Trim().Replace("&nbsp;", " ")
                            , Tip_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                            , Moneda_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                            , Banco_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                            , Proyecto_Id.Trim().Replace("&nbsp;", " ")
                            , Tgasto_Id.Trim().Replace("&nbsp;", " ")
                            , Usuario.Trim().Replace("&nbsp;", " ")
                            , Pase.Trim().Replace("&nbsp;", " ")
                            , LAdministrador
                            , Estado_Id.Trim().Replace("&nbsp;", " ")
                            , Area_Id.Trim().Replace("&nbsp;", " ")
                            , Cod_Antiguo.Trim().Replace("&nbsp;", " ")
                            , Email.Trim().Replace("&nbsp;", " ")
                            , Nacionalidad_Id.Trim().Replace("&nbsp;", " ")
                            , Domiciliado
                            , Tipo_Via_Id.Trim().Replace("&nbsp;", " ")
                            , Numero_Via.Trim().Replace("&nbsp;", " ")
                            , Interior_Via.Trim().Replace("&nbsp;", " ")
                            , Tipo_Zona_Id.Trim().Replace("&nbsp;", " ")
                            , Nombre_Zona.Trim().Replace("&nbsp;", " ")
                            , Referencia.Trim().Replace("&nbsp;", " ")
                            , Tipo_Trabajador_Id.Trim().Replace("&nbsp;", " ")
                            , Regimen_Laboral_Id.Trim().Replace("&nbsp;", " ")
                            , Nivel_Educativo_Id.Trim().Replace("&nbsp;", " ")
                            , Discapacidad
                            , SCTR_Salud_Id.Trim().Replace("&nbsp;", " ")
                            , SCTR_Pension_Id.Trim().Replace("&nbsp;", " ")
                            , Tipo_Contrato_Id.Trim().Replace("&nbsp;", " ")
                            , Jornada_Atipica
                            , Jornada_Maxima
                            , Horario_Nocturno
                            , Sindicalizado
                            , EPS_Id.Trim().Replace("&nbsp;", " ")
                            , Ingresos_5ta_Inafectos
                            , Situacion_Especial_Id.Trim().Replace("&nbsp;", " ")
                            , RUC.Trim().Replace("&nbsp;", " ")
                            , Seguro_Medico_Id.Trim().Replace("&nbsp;", " ")
                            , Madre_Resp_Fam
                            , Tipo_Centro_Form_Prof_Id.Trim().Replace("&nbsp;", " ")
                            , RUC_Destaque.Trim().Replace("&nbsp;", " ")

                            , Foto_NombreArchivo.Trim().Replace("&nbsp;", " ")
                            , Nro_Calzado.Trim().Replace("&nbsp;", " ")
                            , Talla_Ropa_Id.Trim().Replace("&nbsp;", " ")
                            , Grupo_Sanguineo_Id.Trim().Replace("&nbsp;", " ")
                            , Estatura
                            , Peso
                            , Complexion_Fisica_Id.Trim().Replace("&nbsp;", " ")
                            , Brevete_Nro.Trim().Replace("&nbsp;", " ")
                            , Brevete_Categoria_Id.Trim().Replace("&nbsp;", " ")
                            , Brevete_Vigencia
                            , Alergias.Trim().Replace("&nbsp;", " ")
                            , Codigo_Auxiliar.Trim().Replace("&nbsp;", " ")
                            , Seccion_Id.Trim().Replace("&nbsp;", " ")

                            /*Datos para la tabla Personal_Activo*/
                            , Periodo_Id.Trim().Replace("&nbsp;", " ")
                            , Fecha_ingreso
                            , Fecha_cese
                            , Fecha_ini_contrato
                            , Fecha_fin_contrato
                            , Pry_Operacion_Id.Trim().Replace("&nbsp;", " ")
                            , Pry_Categoria_Id.Trim().Replace("&nbsp;", " ")
                            , Flag_Distribuido.Trim().Replace("&nbsp;", " ")
                            , Observaciones.Trim().Replace("&nbsp;", " ")
                            , Motivo_Fin_Per_Lab_Id.Trim().Replace("&nbsp;", " ")
                            , Tipo_Mod_Formativa_Id.Trim().Replace("&nbsp;", " ")
                            , Nro_CITT.Trim().Replace("&nbsp;", " ")
                            , Cod_Contrato.Trim().Replace("&nbsp;", " ")
                            , Fecha_Impresion_Contrato
                            , EPSPLAN_ID.Trim().Replace("&nbsp;", " ")
                            , Cantidad_Titular
                            , Cantidad_Dependientes
                            , Cantidad_Hmayores
                            , Categoria_Auxiliar_Id.Trim().Replace("&nbsp;", " ")
                            , Categoria_Auxiliar2_Id.Trim().Replace("&nbsp;", " ")
                            , Personal_Anexo_Id.Trim().Replace("&nbsp;", " ")
                            , Personal_Anexo2_Id.Trim().Replace("&nbsp;", " ")
                            , Nro_cta_interbancaria.Trim().Replace("&nbsp;", " ")
                            , co_rol.Trim().Replace("&nbsp;", " ")
                            , Email_Personal
                    );
                }
                else
                {
                    ArrayList rPersonal = new ArrayList();
                    rPersonal = ControllerMaestroPersonal.GetInstance().Lista_Personal(personalcod, "");
                    object[] pdatos = (object[])rPersonal[0];

                    resultado = ControllerMaestroPersonal.GetInstance().Update_Personal(
                    personalcod
                    , Compania_Id.Trim().Replace("&nbsp;", " ")
                    , Planilla_Id.Trim().Replace("&nbsp;", " ")
                    , Apellido_Paterno.Trim().Replace("&nbsp;", " ")
                    , Apellido_Materno.Trim().Replace("&nbsp;", " ")
                    , Nombres.Trim().Replace("&nbsp;", " ")
                    , Sexo_Id.Trim().Replace("&nbsp;", " ")
                    , Fecha_Nacimiento
                    , E_Civil_Id.Trim().Replace("&nbsp;", " ")
                    , Fecha_Ini_AporteAFP
                    , Tipo_Doc_Id.Trim().Replace("&nbsp;", " ")
                    , Nro_Doc.Trim().Replace("&nbsp;", " ")
                    , Categoria_Id.Trim().Replace("&nbsp;", " ")
                    , Categoria2_Id.Trim().Replace("&nbsp;", " ")
                    , Cargo_Id.Trim().Replace("&nbsp;", " ")
                    , Situacion_Id.Trim().Replace("&nbsp;", " ")
                    , Afp_Id.Trim().Replace("&nbsp;", " ")
                    , Afp_cod_afiliacion.Trim().Replace("&nbsp;", " ")
                    , Seguro_cod.Trim().Replace("&nbsp;", " ")
                    , Ccosto_Id.Trim().Replace("&nbsp;", " ")
                    , Dpto.Trim().Replace("&nbsp;", " ")
                    , Prov.Trim().Replace("&nbsp;", " ")
                    , Dist.Trim().Replace("&nbsp;", " ")
                    , Direccion.Trim().Replace("&nbsp;", " ")
                    , Telefono.Trim().Replace("&nbsp;", " ")
                    , Telefono2.Trim().Replace("&nbsp;", " ")
                    , Telefono3.Trim().Replace("&nbsp;", " ")
                    , Nro_Hijos
                    , Tip_cta_Id.Trim().Replace("&nbsp;", " ")
                    , Nro_cta.Trim().Replace("&nbsp;", " ")
                    , Moneda_cta_Id.Trim().Replace("&nbsp;", " ")
                    , Banco_cta_Id.Trim().Replace("&nbsp;", " ")
                    , Nro_cta_cts.Trim().Replace("&nbsp;", " ")
                    , Tip_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                    , Moneda_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                    , Banco_cta_cts_Id.Trim().Replace("&nbsp;", " ")
                    , Proyecto_Id.Trim().Replace("&nbsp;", " ")
                    , Tgasto_Id.Trim().Replace("&nbsp;", " ")
                    , Usuario.Trim().Replace("&nbsp;", " ")
                    , Pase.Trim().Replace("&nbsp;", " ")
                    , LAdministrador
                    , Estado_Id.Trim().Replace("&nbsp;", " ")
                    , Area_Id.Trim().Replace("&nbsp;", " ")
                    , Cod_Antiguo.Trim().Replace("&nbsp;", " ")
                    , Email.Trim().Replace("&nbsp;", " ")
                    , Nacionalidad_Id.Trim().Replace("&nbsp;", " ")
                    , Domiciliado
                    , Tipo_Via_Id.Trim().Replace("&nbsp;", " ")
                    , Numero_Via.Trim().Replace("&nbsp;", " ")
                    , Interior_Via.Trim().Replace("&nbsp;", " ")
                    , Tipo_Zona_Id.Trim().Replace("&nbsp;", " ")
                    , Nombre_Zona.Trim().Replace("&nbsp;", " ")
                    , Referencia.Trim().Replace("&nbsp;", " ")
                    , Tipo_Trabajador_Id.Trim().Replace("&nbsp;", " ")
                    , Regimen_Laboral_Id.Trim().Replace("&nbsp;", " ")
                    , Nivel_Educativo_Id.Trim().Replace("&nbsp;", " ")
                    , Discapacidad
                    , SCTR_Salud_Id.Trim().Replace("&nbsp;", " ")
                    , SCTR_Pension_Id.Trim().Replace("&nbsp;", " ")
                    , Tipo_Contrato_Id.Trim().Replace("&nbsp;", " ")
                    , Jornada_Atipica
                    , Jornada_Maxima
                    , Horario_Nocturno
                    , Sindicalizado
                    , EPS_Id.Trim().Replace("&nbsp;", " ")
                    , Ingresos_5ta_Inafectos
                    , Situacion_Especial_Id.Trim().Replace("&nbsp;", " ")
                    , RUC.Trim().Replace("&nbsp;", " ")
                    , Seguro_Medico_Id.Trim().Replace("&nbsp;", " ")
                    , Madre_Resp_Fam
                    , Tipo_Centro_Form_Prof_Id.Trim().Replace("&nbsp;", " ")
                    , RUC_Destaque.Trim().Replace("&nbsp;", " ")

                    , Foto_NombreArchivo.Trim().Replace("&nbsp;", " ")
                    , Nro_Calzado.Trim().Replace("&nbsp;", " ")
                    , Talla_Ropa_Id.Trim().Replace("&nbsp;", " ")
                    , Grupo_Sanguineo_Id.Trim().Replace("&nbsp;", " ")
                    , Estatura
                    , Peso
                    , Complexion_Fisica_Id.Trim().Replace("&nbsp;", " ")
                    , Brevete_Nro.Trim().Replace("&nbsp;", " ")
                    , Brevete_Categoria_Id.Trim().Replace("&nbsp;", " ")
                    , Brevete_Vigencia
                    , Alergias.Trim().Replace("&nbsp;", " ")
                    , Codigo_Auxiliar.Trim().Replace("&nbsp;", " ")
                    , Seccion_Id.Trim().Replace("&nbsp;", " ")
                    , "" //co_trabajador_id
                    /*Datos para la tabla Personal_Activo*/
                    , Periodo_Id.Trim().Replace("&nbsp;", " ")
                    , Fecha_ingreso
                    , Fecha_cese
                    , Fecha_ini_contrato
                    , Fecha_fin_contrato
                    , Pry_Operacion_Id.Trim().Replace("&nbsp;", " ")
                    , Pry_Categoria_Id.Trim().Replace("&nbsp;", " ")
                    , Flag_Distribuido.Trim().Replace("&nbsp;", " ")
                    , Observaciones.Trim().Replace("&nbsp;", " ")
                    , Motivo_Fin_Per_Lab_Id.Trim().Replace("&nbsp;", " ")
                    , Tipo_Mod_Formativa_Id.Trim().Replace("&nbsp;", " ")
                    , Nro_CITT.Trim().Replace("&nbsp;", " ")
                    , Cod_Contrato.Trim().Replace("&nbsp;", " ")
                    , Fecha_Impresion_Contrato
                    , EPSPLAN_ID.Trim().Replace("&nbsp;", " ")
                    , Cantidad_Titular
                    , Cantidad_Dependientes
                    , Cantidad_Hmayores
                    , Categoria_Auxiliar_Id.Trim().Replace("&nbsp;", " ")
                    , Categoria_Auxiliar2_Id.Trim().Replace("&nbsp;", " ")
                    , Personal_Anexo_Id.Trim().Replace("&nbsp;", " ")
                    , Personal_Anexo2_Id.Trim().Replace("&nbsp;", " ")
                    , xUsuario
                    , Nro_cta_interbancaria.Trim().Replace("&nbsp;", " ")
                    , co_rol.Trim().Replace("&nbsp;", " ")
                    //, pdatos[102].ToString().Trim().Replace("&nbsp;", " ")
                    , Email_Personal
                    , pdatos[104].ToString() //@001 I/F
                    , pdatos[105].ToString() //@001 I/F
                );
                }

                return resultado;
            }
            catch (Exception ex)
            {
                resultado.Add("false");
                resultado.Add(prm[2]);
                resultado.Add(ex.Message);
                resultado.Add(prm[2]);
                return resultado;
            }

        }
    }
}