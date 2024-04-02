using CAPA_DATOS;
using CAPA_ENTIDAD.EntMs;
using GNProject.Views.sistemaPlanillas.code;
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
    public partial class MaestroPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String Compania_Id = Utils.fc_obtiene_Compania_Id(this);
                this.Inicializa(Compania_Id);
            }
        }
        private void Inicializa(String Compania_Id)
        {
            #region Combos de Pestaña Datos Principales"
            ArrayList oComboSexo = ControllerMaestroPersonal.GetInstance().ListaTipoSexo();
            ArrayList oComboTipoDoc = ControllerMaestroPersonal.GetInstance().ListaTipoDoc();
            ArrayList oComboNacionalidad = ControllerMaestroPersonal.GetInstance().ListaNacionalidad();
            ArrayList oComboTipoVia = ControllerMaestroPersonal.GetInstance().ListaTipoVia();
            ArrayList oComboTipoZona = ControllerMaestroPersonal.GetInstance().ListaTipoZona();
            ArrayList oComboDepartamento = ControllerMaestroPersonal.GetInstance().ListaDepartamento();
            #endregion Combos de Pestaña Datos Principales"
            #region Combos de Pestaña Datos Secundarios"
            ArrayList oComboCompania = ControllerMaestroPersonal.GetInstance().ListaCompania();
            ArrayList oComboTipoPlanilla = ControllerMaestroPersonal.GetInstance().ListaTipoPlanilla(Compania_Id);
            ArrayList oComboArea = ControllerMaestroPersonal.GetInstance().ListaArea();
            ArrayList oComboCCosto = ControllerMaestroPersonal.GetInstance().ListaCCosto();
            ArrayList oComboCategoria = ControllerMaestroPersonal.GetInstance().ListaCategoria();
            ArrayList oComboCategoria2 = ControllerMaestroPersonal.GetInstance().ListaCategoria2();
            ArrayList oComboProyecto = ControllerMaestroPersonal.GetInstance().ListaProyecto();
            ArrayList oComboSituacion = ControllerMaestroPersonal.GetInstance().ListaSituacion();
            ArrayList oComboEstadoCivil = ControllerMaestroPersonal.GetInstance().ListaEstadoCivil();
            ArrayList oComboEstado = ControllerMaestroPersonal.GetInstance().ListaEstados();
            ArrayList oComboMotivoCese = ControllerMaestroPersonal.GetInstance().ListaMotivoCese();
            ArrayList oComboCatAuxiliar = ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();
            ArrayList oComboAnexo = ControllerMaestroPersonal.GetInstance().ListaAnexo();
            ArrayList oComboAnexo2 = ControllerMaestroPersonal.GetInstance().ListaAnexo2();
            ArrayList oComboTipoCuenta = ControllerMaestroPersonal.GetInstance().ListaTipoCuenta();
            ArrayList oComboBanco = ControllerMaestroPersonal.GetInstance().ListaBancos();
            ArrayList oComboMonedaCta = ControllerMaestroPersonal.GetInstance().ListaMonedaCta();
            //@002 I
            List<eCta_Compania> oLista_CtaCia = controllerCtaCompania.getinstance().ListarCtasCompania(Compania_Id);
            ArrayList oComboBanco_Cia = new ArrayList();
            foreach (eCta_Compania ent in oLista_CtaCia)
            {
                if (ent.Moneda_Id == "MN") /*soles*/
                {
                    object[] values = new object[2];
                    values[0] = ent.Banco_Id;
                    values[1] = ent.Banco;
                    oComboBanco_Cia.Add(values);
                }
            }
            //@002 F
            #endregion Combos de Pestaña Datos Secundarios"
            #region Combos de Pestaña Datos Tab/Pensionista"
            ArrayList oComboTipoTrabajador = ControllerMaestroPersonal.GetInstance().ListaTipoTrabajador();
            ArrayList oComboRegLaboral = ControllerMaestroPersonal.GetInstance().ListaRegLaboral();
            ArrayList oComboNivelEducativo = ControllerMaestroPersonal.GetInstance().ListaNivelEducativo();
            ArrayList oComboCargo = ControllerMaestroPersonal.GetInstance().ListaCargo();
            ArrayList oComboRegPensionario = ControllerMaestroPersonal.GetInstance().ListaRegimenPensionario();
            ArrayList oComboNivelAcceso = ControllerMaestroPersonal.GetInstance().ListaNivelAcceso(); //@003 I/F
            ArrayList oComboSCTRSalud = ControllerMaestroPersonal.GetInstance().ListaSCTRSalud();
            ArrayList oComboSCTRPension = ControllerMaestroPersonal.GetInstance().ListaSCTRPension();
            ArrayList oComboTipoContrato = ControllerMaestroPersonal.GetInstance().ListaTipoContrato();
            ArrayList oComboEPS = ControllerMaestroPersonal.GetInstance().ListaEPS();
            ArrayList oComboSituacionEspecial = ControllerMaestroPersonal.GetInstance().ListaSituacionEspecial();
            #endregion Combos de Pestaña Datos Tab/Pensionista"
            #region Combos de Pestaña Datos 4ta/M.F./Ter."
            ArrayList oComboSeguroMedico = ControllerMaestroPersonal.GetInstance().ListaSeguroMedico();
            ArrayList oComboTipoCentroFormacionProf = ControllerMaestroPersonal.GetInstance().ListaCentroFormacionProf();
            ArrayList oComboTipoModFormativa = ControllerMaestroPersonal.GetInstance().ListaModFormativa();
            #endregion Combos de Pestaña Datos 4ta/M.F./Ter."
            #region Combos de Pestaña Datos Otros Datos"
            ArrayList oComboComplexionFisica = ControllerMaestroPersonal.GetInstance().ListaComplexionFisica();
            ArrayList oComboGrupoSanguineo = ControllerMaestroPersonal.GetInstance().ListaGrupoSanguineo();
            ArrayList oComboTallaRopa = ControllerMaestroPersonal.GetInstance().ListaTallaRopa();
            ArrayList oComboCategoriaBrevete = ControllerMaestroPersonal.GetInstance().ListaBreveteCategoria();
            #endregion Combos de Pestaña Datos Otros Datos"

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            String js = String.Format("fc_FillComboArray('cboSexo', {0}, '--Seleccione--');", serializer.Serialize(oComboSexo));
            js += String.Format("fc_FillComboArray('cboTipoDoc', {0}, '--Seleccione--');", serializer.Serialize(oComboTipoDoc));
            js += String.Format("fc_FillComboArray('cboNacionalidad', {0}, '--Seleccione--');", serializer.Serialize(oComboNacionalidad));
            js += String.Format("fc_FillComboArray('cboTipoVia', {0}, '');", serializer.Serialize(oComboTipoVia));
            js += String.Format("fc_FillComboArray('cboTipoZona', {0}, '');", serializer.Serialize(oComboTipoZona));
            js += String.Format("fc_FillComboArray('cboDep', {0}, '--Seleccione--');", serializer.Serialize(oComboDepartamento));
            js += String.Format("fc_FillComboArray('cboProv', {0}, '--Seleccione--');", serializer.Serialize(new ArrayList()));
            js += String.Format("fc_FillComboArray('cboDist', {0}, '--Seleccione--');", serializer.Serialize(new ArrayList()));
            //--Datos Secundarios
            js += String.Format("fc_FillComboArray('cboCompania', {0}, '--Seleccione--');", serializer.Serialize(oComboCompania));
            js += String.Format("fc_FillComboArray('cboTipoPlanilla', {0}, '--Seleccione--');", serializer.Serialize(oComboCompania));
            js += String.Format("fc_FillComboArray('cboArea', {0}, '--Seleccione--');", serializer.Serialize(oComboArea));
            js += String.Format("fc_FillComboArray('cboCCosto', {0}, '--Seleccione--');", serializer.Serialize(oComboCCosto));
            js += String.Format("fc_FillComboArray('cboCategoria', {0}, '--Seleccione--');", serializer.Serialize(oComboCategoria));
            js += String.Format("fc_FillComboArray('cboCategoria2', {0}, '');", serializer.Serialize(oComboCategoria2));
            js += String.Format("fc_FillComboArray('cboProyecto', {0}, '--Seleccione--');", serializer.Serialize(oComboProyecto));
            js += String.Format("fc_FillComboArray('cboSituacion', {0}, '--Seleccione--');", serializer.Serialize(oComboSituacion));
            js += String.Format("fc_FillComboArray('cboEstadoCivil', {0}, '--Seleccione--');", serializer.Serialize(oComboEstadoCivil));
            js += String.Format("fc_FillComboArray('cboEstado', {0}, '');", serializer.Serialize(oComboEstado));
            js += String.Format("fc_FillComboArray('cboMotivoCese', {0}, '--Seleccione--');", serializer.Serialize(oComboMotivoCese));
            js += String.Format("fc_FillComboArray('cboCatAuxiliar', {0}, '--Seleccione--');", serializer.Serialize(oComboCatAuxiliar));
            js += String.Format("fc_FillComboArray('cboCatAuxiliar2', {0}, '--Seleccione--');", serializer.Serialize(new ArrayList()));
            js += String.Format("fc_FillComboArray('cboAnexo', {0}, '');", serializer.Serialize(oComboAnexo));
            js += String.Format("fc_FillComboArray('cboAnexo2', {0}, '');", serializer.Serialize(oComboAnexo2));
            js += String.Format("fc_FillComboArray('cboTipoCuenta', {0}, '');", serializer.Serialize(oComboTipoCuenta));
            js += String.Format("fc_FillComboArray('cboTipoCuentaCTS', {0}, '');", serializer.Serialize(oComboTipoCuenta));
            js += String.Format("fc_FillComboArray('cboBancoCuenta', {0}, '');", serializer.Serialize(oComboBanco));
            js += String.Format("fc_FillComboArray('cboBancoCuentaCTS', {0}, '');", serializer.Serialize(oComboBanco));
            js += String.Format("fc_FillComboArray('cboMonedaCuenta', {0}, '');", serializer.Serialize(oComboMonedaCta));
            js += String.Format("fc_FillComboArray('cboMonedaCuentaCTS', {0}, '');", serializer.Serialize(oComboMonedaCta));
            //@002 I
            js += String.Format("fc_FillComboArray('cboBancoPago_Cia', {0}, '--Seleccione--');", serializer.Serialize(oComboBanco_Cia));
            js += String.Format("fc_FillComboArray('cboBancoPagoCTS_Cia', {0}, '--Seleccione--');", serializer.Serialize(oComboBanco_Cia));
            //@002 F
            //Tab/Pensionista
            js += String.Format("fc_FillComboArray('cboTipoTrabajador', {0}, '--Seleccione--');", serializer.Serialize(oComboTipoTrabajador));
            js += String.Format("fc_FillComboArray('cboRegLaboral', {0}, '--Seleccione--');", serializer.Serialize(oComboRegLaboral));
            js += String.Format("fc_FillComboArray('cboNivelEduca', {0}, '');", serializer.Serialize(oComboNivelEducativo));
            js += String.Format("fc_FillComboArray('cboCargo', {0}, '');", serializer.Serialize(oComboCargo));
            js += String.Format("fc_FillComboArray('cboRegPensionario', {0}, '');", serializer.Serialize(oComboRegPensionario));
            js += String.Format("fc_FillComboArray('cboNivelAcceso', {0}, '--Seleccione--');", serializer.Serialize(oComboNivelAcceso)); //@003 I/F
            js += String.Format("fc_FillComboArray('cboSCTRSalud', {0}, '');", serializer.Serialize(oComboSCTRSalud));
            js += String.Format("fc_FillComboArray('cboSCTRPension', {0}, '');", serializer.Serialize(oComboSCTRPension));
            js += String.Format("fc_FillComboArray('cboTipoContrato', {0}, '');", serializer.Serialize(oComboTipoContrato));
            js += String.Format("fc_FillComboArray('cboEPS', {0}, '');", serializer.Serialize(oComboEPS));
            js += String.Format("fc_FillComboArray('cboSituacionEspec', {0}, '');", serializer.Serialize(oComboSituacionEspecial));
            js += String.Format("fc_FillComboArray('cboTipoPensionista', {0}, '');", serializer.Serialize(oComboTipoTrabajador));
            js += String.Format("fc_FillComboArray('cboRegPensionista', {0}, '');", serializer.Serialize(oComboRegPensionario));
            //4ta/M.F./Ter.
            js += String.Format("fc_FillComboArray('cboSeguroMed', {0}, '');", serializer.Serialize(oComboSeguroMedico));
            js += String.Format("fc_FillComboArray('cboNivelEduca2', {0}, '');", serializer.Serialize(oComboNivelEducativo));
            js += String.Format("fc_FillComboArray('cboCargo2', {0}, '');", serializer.Serialize(oComboCargo));
            js += String.Format("fc_FillComboArray('cboTipoCenFProf', {0}, '');", serializer.Serialize(oComboTipoCentroFormacionProf));
            js += String.Format("fc_FillComboArray('cboTipoModFormat', {0}, '');", serializer.Serialize(oComboTipoModFormativa));
            js += String.Format("fc_FillComboArray('cboSCTRSalud2', {0}, '');", serializer.Serialize(oComboSCTRSalud));
            js += String.Format("fc_FillComboArray('cboSCTRPension2', {0}, '');", serializer.Serialize(oComboSCTRPension));
            //Otros Datos
            js += String.Format("fc_FillComboArray('cboCompexion', {0}, '--Seleccione--');", serializer.Serialize(oComboComplexionFisica));
            js += String.Format("fc_FillComboArray('cboGrupoSanguineo', {0}, '--Seleccione--');", serializer.Serialize(oComboGrupoSanguineo));
            js += String.Format("fc_FillComboArray('cboTallaRopa', {0}, '--Seleccione--');", serializer.Serialize(oComboTallaRopa));
            js += String.Format("fc_FillComboArray('cboCategoriaBrevete', {0}, '--Seleccione--');", serializer.Serialize(oComboCategoriaBrevete));
            this.fc_JavaScript(this.Page, js);
        }
        public void fc_JavaScript(Page c, String script, String strKey = "__Script__")
        {
            /*Dentro de un ScriptManager*/
            //script = script.Replace("\'", "\\'");
            //script = script.Replace("\r", "\\r");
            //script = script.Replace("\n", "\\n");
            String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), strKey, Script, false);
        }
        //@001 F

        //GET COLUMNAS FILTRO PERSONAL
        [WebMethod]
        public static ArrayList ListaColumnPersonal()
        {
            return ControllerMaestroPersonal.GetInstance().ListaColumnPersonal();
        }

        //@001 I
        //GET PERSONAL X FILTRO
        [WebMethod]
        //public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param,int inicio)
        public static object Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        {
            //return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id,Periodo_Id,NomColumna,Param,inicio);
            Int32 qt_registros;
            List<ListaPersonal> oBandeja = ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }

        ////GET  MAX ROWS
        //[WebMethod]
        //public static int Lista_Personal_x_Filtro_Columna_MaxRows(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        //{
        //    return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
        //}
        //@001 F

        //GET PERSONAL
        [WebMethod]
        public static ArrayList Lista_Personal(string Personal_Id, string Periodo_Id)
        {
            return ControllerMaestroPersonal.GetInstance().Lista_Personal(Personal_Id, Periodo_Id);
        }

        [WebMethod]
        public static List<string> Insert_Personal(
                string Compania_Id
                , string Planilla_Id
                , string Apellido_Paterno
                , string Apellido_Materno
                , string Nombres
                , string Sexo_Id
                , DateTime Fecha_Nacimiento
                , string E_Civil_Id
                , DateTime Fecha_Ini_AporteAFP
                , string Tipo_Doc_Id
                , string Nro_Doc
                , string Categoria_Id
                , string Categoria2_Id
                , string Cargo_Id
                , string Situacion_Id
                , string Afp_Id
                , string Afp_cod_afiliacion
                , string Seguro_cod
                , string Ccosto_Id
                , string Dpto
                , string Prov
                , string Dist
                , string Direccion
                , string Telefono
                , string Telefono2
                , string Telefono3
                , int Nro_Hijos
                , string Tip_cta_Id
                , string Nro_cta
                , string Moneda_cta_Id
                , string Banco_cta_Id
                , string Nro_cta_cts
                , string Tip_cta_cts_Id
                , string Moneda_cta_cts_Id
                , string Banco_cta_cts_Id
                , string Proyecto_Id
                , string Tgasto_Id
                , string Usuario
                , string Pase
                , int LAdministrador
                , string Estado_Id
                , string Area_Id
                , string Cod_Antiguo
                , string Email
                , string Nacionalidad_Id
                , Boolean Domiciliado
                , string Tipo_Via_Id
                , string Numero_Via
                , string Interior_Via
                , string Tipo_Zona_Id
                , string Nombre_Zona
                , string Referencia
                , string Tipo_Trabajador_Id
                , string Regimen_Laboral_Id
                , string Nivel_Educativo_Id
                , Boolean Discapacidad
                , string SCTR_Salud_Id
                , string SCTR_Pension_Id
                , string Tipo_Contrato_Id
                , Boolean Jornada_Atipica
                , Boolean Jornada_Maxima
                , Boolean Horario_Nocturno
                , Boolean Sindicalizado
                , string EPS_Id
                , Boolean Ingresos_5ta_Inafectos
                , string Situacion_Especial_Id
                , string RUC
                , string Seguro_Medico_Id
                , Boolean Madre_Resp_Fam
                , string Tipo_Centro_Form_Prof_Id
                , string RUC_Destaque

                , string Foto_NombreArchivo
                , string Nro_Calzado
                , string Talla_Ropa_Id
                , string Grupo_Sanguineo_Id
                , Double Estatura
                , Double Peso
                , string Complexion_Fisica_Id
                , string Brevete_Nro
                , string Brevete_Categoria_Id
                , DateTime Brevete_Vigencia
                , string Alergias
                , string Codigo_Auxiliar
                , string Seccion_Id
                , string Co_Trabajador_Id
                /*Datos para la tabla Personal_Activo*/
                , string Periodo_Id
                , DateTime Fecha_ingreso
                , DateTime Fecha_cese
                , DateTime Fecha_ini_contrato
                , DateTime Fecha_fin_contrato
                , string Pry_Operacion_Id
                , string Pry_Categoria_Id
                , string Flag_Distribuido
                , string Observaciones
                , string Motivo_Fin_Per_Lab_Id
                , string Tipo_Mod_Formativa_Id
                , string Nro_CITT
                , string Cod_Contrato
                , DateTime Fecha_Impresion_Contrato
                , string EPSPLAN_ID
                , int Cantidad_Titular
                , int Cantidad_Dependientes
                , int Cantidad_Hmayores
                , string Categoria_Auxiliar_Id
                , string Categoria_Auxiliar2_Id
                , string Personal_Anexo_Id
                , string Personal_Anexo2_Id
                , string Nro_cta_interbancaria
                , string co_rol
                , string emailp
                , string Banco_pago_cia_Id //@002 I/F
                , string Banco_pago_cts_cia_Id //@002 I/F
                , string Password //@003 I/F
                , string NivelAcceso //@003 I/F
            )
        {
            List<String> rpta = ControllerMaestroPersonal.GetInstance().Insert_Personal(
                           Compania_Id
                        , Planilla_Id
                        , Apellido_Paterno
                        , Apellido_Materno
                        , Nombres
                        , Sexo_Id
                        , Fecha_Nacimiento
                        , E_Civil_Id
                        , Fecha_Ini_AporteAFP
                        , Tipo_Doc_Id
                        , Nro_Doc
                        , Categoria_Id
                        , Categoria2_Id
                        , Cargo_Id
                        , Situacion_Id
                        , Afp_Id
                        , Afp_cod_afiliacion
                        , Seguro_cod
                        , Ccosto_Id
                        , Dpto
                        , Prov
                        , Dist
                        , Direccion
                        , Telefono
                        , Telefono2
                        , Telefono3
                        , Nro_Hijos
                        , Tip_cta_Id
                        , Nro_cta
                        , Moneda_cta_Id
                        , Banco_cta_Id
                        , Nro_cta_cts
                        , Tip_cta_cts_Id
                        , Moneda_cta_cts_Id
                        , Banco_cta_cts_Id
                        , Proyecto_Id
                        , Tgasto_Id
                        , Usuario
                        , Pase
                        , LAdministrador
                        , Estado_Id
                        , Area_Id
                        , Cod_Antiguo
                        , Email
                        , Nacionalidad_Id
                        , Domiciliado
                        , Tipo_Via_Id
                        , Numero_Via
                        , Interior_Via
                        , Tipo_Zona_Id
                        , Nombre_Zona
                        , Referencia
                        , Tipo_Trabajador_Id
                        , Regimen_Laboral_Id
                        , Nivel_Educativo_Id
                        , Discapacidad
                        , SCTR_Salud_Id
                        , SCTR_Pension_Id
                        , Tipo_Contrato_Id
                        , Jornada_Atipica
                        , Jornada_Maxima
                        , Horario_Nocturno
                        , Sindicalizado
                        , EPS_Id
                        , Ingresos_5ta_Inafectos
                        , Situacion_Especial_Id
                        , RUC
                        , Seguro_Medico_Id
                        , Madre_Resp_Fam
                        , Tipo_Centro_Form_Prof_Id
                        , RUC_Destaque

                        , Foto_NombreArchivo
                        , Nro_Calzado
                        , Talla_Ropa_Id
                        , Grupo_Sanguineo_Id
                        , Estatura
                        , Peso
                        , Complexion_Fisica_Id
                        , Brevete_Nro
                        , Brevete_Categoria_Id
                        , Brevete_Vigencia
                        , Alergias
                        , Codigo_Auxiliar
                        , Seccion_Id
                        , Co_Trabajador_Id
                        /*Datos para la tabla Personal_Activo*/
                        , Periodo_Id
                        , Fecha_ingreso
                        , Fecha_cese
                        , Fecha_ini_contrato
                        , Fecha_fin_contrato
                        , Pry_Operacion_Id
                        , Pry_Categoria_Id
                        , Flag_Distribuido
                        , Observaciones
                        , Motivo_Fin_Per_Lab_Id
                        , Tipo_Mod_Formativa_Id
                        , Nro_CITT
                        , Cod_Contrato
                        , Fecha_Impresion_Contrato
                        , EPSPLAN_ID
                        , Cantidad_Titular
                        , Cantidad_Dependientes
                        , Cantidad_Hmayores
                        , Categoria_Auxiliar_Id
                        , Categoria_Auxiliar2_Id
                        , Personal_Anexo_Id
                        , Personal_Anexo2_Id
                        , Nro_cta_interbancaria
                        , co_rol
                        , emailp
                        , Banco_pago_cia_Id //@002 I/F
                        , Banco_pago_cts_cia_Id //@002 I/F
                );

            //@003 I        
            if (rpta[1] != "-1")
            {
                String Personal_Id = rpta[1];
                ControllerMaestroPersonal.GetInstance().InsertUpdate_UsuarioPlanilla(Personal_Id, Nro_Doc, Password, NivelAcceso, Email, emailp);
            }
            //@003 F
            return rpta;
        }
        [WebMethod]
        public static List<string> Update_Personal(
            string Personal_Id
                        , string Compania_Id
                        , string Planilla_Id
                        , string Apellido_Paterno
                        , string Apellido_Materno
                        , string Nombres
                        , string Sexo_Id
                        , DateTime Fecha_Nacimiento
                        , string E_Civil_Id
                        , DateTime Fecha_Ini_AporteAFP
                        , string Tipo_Doc_Id
                        , string Nro_Doc
                        , string Categoria_Id
                        , string Categoria2_Id
                        , string Cargo_Id
                        , string Situacion_Id
                        , string Afp_Id
                        , string Afp_cod_afiliacion
                        , string Seguro_cod
                        , string Ccosto_Id
                        , string Dpto
                        , string Prov
                        , string Dist
                        , string Direccion
                        , string Telefono
                        , string Telefono2
                        , string Telefono3
                        , int Nro_Hijos
                        , string Tip_cta_Id
                        , string Nro_cta
                        , string Moneda_cta_Id
                        , string Banco_cta_Id
                        , string Nro_cta_cts
                        , string Tip_cta_cts_Id
                        , string Moneda_cta_cts_Id
                        , string Banco_cta_cts_Id
                        , string Proyecto_Id
                        , string Tgasto_Id
                        , string Usuario
                        , string Pase
                        , int LAdministrador
                        , string Estado_Id
                        , string Area_Id
                        , string Cod_Antiguo
                        , string Email
                        , string Nacionalidad_Id
                        , Boolean Domiciliado
                        , string Tipo_Via_Id
                        , string Numero_Via
                        , string Interior_Via
                        , string Tipo_Zona_Id
                        , string Nombre_Zona
                        , string Referencia
                        , string Tipo_Trabajador_Id
                        , string Regimen_Laboral_Id
                        , string Nivel_Educativo_Id
                        , Boolean Discapacidad
                        , string SCTR_Salud_Id
                        , string SCTR_Pension_Id
                        , string Tipo_Contrato_Id
                        , Boolean Jornada_Atipica
                        , Boolean Jornada_Maxima
                        , Boolean Horario_Nocturno
                        , Boolean Sindicalizado
                        , string EPS_Id
                        , Boolean Ingresos_5ta_Inafectos
                        , string Situacion_Especial_Id
                        , string RUC
                        , string Seguro_Medico_Id
                        , Boolean Madre_Resp_Fam
                        , string Tipo_Centro_Form_Prof_Id
                        , string RUC_Destaque

                        , string Foto_NombreArchivo
                        , string Nro_Calzado
                        , string Talla_Ropa_Id
                        , string Grupo_Sanguineo_Id
                        , Double Estatura
                        , Double Peso
                        , string Complexion_Fisica_Id
                        , string Brevete_Nro
                        , string Brevete_Categoria_Id
                        , DateTime Brevete_Vigencia
                        , string Alergias
                        , string Codigo_Auxiliar
                        , string Seccion_Id
                        , string Co_Trabajador_Id
                        /*Datos para la tabla Personal_Activo*/
                        , string Periodo_Id
                        , DateTime Fecha_ingreso
                        , DateTime Fecha_cese
                        , DateTime Fecha_ini_contrato
                        , DateTime Fecha_fin_contrato
                        , string Pry_Operacion_Id
                        , string Pry_Categoria_Id
                        , string Flag_Distribuido
                        , string Observaciones
                        , string Motivo_Fin_Per_Lab_Id
                        , string Tipo_Mod_Formativa_Id
                        , string Nro_CITT
                        , string Cod_Contrato
                        , DateTime Fecha_Impresion_Contrato
                        , string EPSPLAN_ID
                        , int Cantidad_Titular
                        , int Cantidad_Dependientes
                        , int Cantidad_Hmayores
                        , string Categoria_Auxiliar_Id
                        , string Categoria_Auxiliar2_Id
                        , string Personal_Anexo_Id
                        , string Personal_Anexo2_Id
                        , string UsuarioSess
                        , string Nro_cta_interbancaria
                        , string co_rol
                        , string emailp
                        , string Banco_pago_cia_Id //@002 I/F
                        , string Banco_pago_cts_cia_Id //@002 I/F
                        , string Password //@003 I/F
                        , string NivelAcceso //@003 I/F
                )
        {
            List<String> rpta = ControllerMaestroPersonal.GetInstance().Update_Personal(
                        Personal_Id
                        , Compania_Id
                        , Planilla_Id
                        , Apellido_Paterno
                        , Apellido_Materno
                        , Nombres
                        , Sexo_Id
                        , Fecha_Nacimiento
                        , E_Civil_Id
                        , Fecha_Ini_AporteAFP
                        , Tipo_Doc_Id
                        , Nro_Doc
                        , Categoria_Id
                        , Categoria2_Id
                        , Cargo_Id
                        , Situacion_Id
                        , Afp_Id
                        , Afp_cod_afiliacion
                        , Seguro_cod
                        , Ccosto_Id
                        , Dpto
                        , Prov
                        , Dist
                        , Direccion
                        , Telefono
                        , Telefono2
                        , Telefono3
                        , Nro_Hijos
                        , Tip_cta_Id
                        , Nro_cta
                        , Moneda_cta_Id
                        , Banco_cta_Id
                        , Nro_cta_cts
                        , Tip_cta_cts_Id
                        , Moneda_cta_cts_Id
                        , Banco_cta_cts_Id
                        , Proyecto_Id
                        , Tgasto_Id
                        , Usuario
                        , Pase
                        , LAdministrador
                        , Estado_Id
                        , Area_Id
                        , Cod_Antiguo
                        , Email
                        , Nacionalidad_Id
                        , Domiciliado
                        , Tipo_Via_Id
                        , Numero_Via
                        , Interior_Via
                        , Tipo_Zona_Id
                        , Nombre_Zona
                        , Referencia
                        , Tipo_Trabajador_Id
                        , Regimen_Laboral_Id
                        , Nivel_Educativo_Id
                        , Discapacidad
                        , SCTR_Salud_Id
                        , SCTR_Pension_Id
                        , Tipo_Contrato_Id
                        , Jornada_Atipica
                        , Jornada_Maxima
                        , Horario_Nocturno
                        , Sindicalizado
                        , EPS_Id
                        , Ingresos_5ta_Inafectos
                        , Situacion_Especial_Id
                        , RUC
                        , Seguro_Medico_Id
                        , Madre_Resp_Fam
                        , Tipo_Centro_Form_Prof_Id
                        , RUC_Destaque

                        , Foto_NombreArchivo
                        , Nro_Calzado
                        , Talla_Ropa_Id
                        , Grupo_Sanguineo_Id
                        , Estatura
                        , Peso
                        , Complexion_Fisica_Id
                        , Brevete_Nro
                        , Brevete_Categoria_Id
                        , Brevete_Vigencia
                        , Alergias
                        , Codigo_Auxiliar
                        , Seccion_Id
                        , Co_Trabajador_Id
                        /*Datos para la tabla Personal_Activo*/
                        , Periodo_Id
                        , Fecha_ingreso
                        , Fecha_cese
                        , Fecha_ini_contrato
                        , Fecha_fin_contrato
                        , Pry_Operacion_Id
                        , Pry_Categoria_Id
                        , Flag_Distribuido
                        , Observaciones
                        , Motivo_Fin_Per_Lab_Id
                        , Tipo_Mod_Formativa_Id
                        , Nro_CITT
                        , Cod_Contrato
                        , Fecha_Impresion_Contrato
                        , EPSPLAN_ID
                        , Cantidad_Titular
                        , Cantidad_Dependientes
                        , Cantidad_Hmayores
                        , Categoria_Auxiliar_Id
                        , Categoria_Auxiliar2_Id
                        , Personal_Anexo_Id
                        , Personal_Anexo2_Id
                        , UsuarioSess
                        , Nro_cta_interbancaria
                        , co_rol
                        , emailp
                        , Banco_pago_cia_Id //@002 I/F
                        , Banco_pago_cts_cia_Id //@002 I/F
                );

            ControllerMaestroPersonal.GetInstance().InsertUpdate_UsuarioPlanilla(Personal_Id, Nro_Doc, Password, NivelAcceso, Email, emailp); //@003 I/F
            return rpta;

        }

        //ELIMINA PERSONAL
        [WebMethod]
        public static List<string> Delete_Personal(string Personal_Id)
        {
            return ControllerMaestroPersonal.GetInstance().Delete_Personal(Personal_Id);
        }


        #region CARGAR COMBOS
        //---- 2. Datos Principales
        [WebMethod]
        public static ArrayList ListaTipoDoc()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoDoc();
        }
        [WebMethod]
        public static ArrayList ListaNacionalidad()
        {
            return ControllerMaestroPersonal.GetInstance().ListaNacionalidad();
        }
        [WebMethod]
        public static ArrayList ListaTipoSexo()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoSexo();
        }
        [WebMethod]
        public static ArrayList ListaTipoVia()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoVia();
        }
        [WebMethod]
        public static ArrayList ListaTipoZona()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoZona();
        }
        [WebMethod]
        public static ArrayList ListaDepartamento()
        {
            return ControllerMaestroPersonal.GetInstance().ListaDepartamento();
        }
        [WebMethod]
        public static ArrayList ListaProvincia(string Departamento_Id)
        {
            return ControllerMaestroPersonal.GetInstance().ListaProvincia(Departamento_Id);
        }
        [WebMethod]
        public static ArrayList ListaDistrito(string Departamento_Id, string Provincia_Id)
        {
            return ControllerMaestroPersonal.GetInstance().ListaDistrito(Departamento_Id, Provincia_Id);
        }


        // 3. Datos Secundarios
        [WebMethod]
        public static ArrayList ListaCompania()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCompania();
        }
        [WebMethod]
        public static ArrayList ListaTipoPlanilla(string Compania_Id)
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoPlanilla(Compania_Id);
        }
        [WebMethod]
        public static ArrayList ListaArea()
        {
            return ControllerMaestroPersonal.GetInstance().ListaArea();
        }
        [WebMethod]
        public static ArrayList ListaCCosto()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCCosto();
        }
        [WebMethod]
        public static ArrayList ListaCategoria()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCategoria();
        }
        [WebMethod]
        public static ArrayList ListaCategoria2()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCategoria2();
        }
        [WebMethod]
        public static ArrayList ListaProyecto()
        {
            return ControllerMaestroPersonal.GetInstance().ListaProyecto();
        }
        [WebMethod]
        public static ArrayList ListaSituacion()
        {
            return ControllerMaestroPersonal.GetInstance().ListaSituacion();
        }
        [WebMethod]
        public static ArrayList ListaEstadoCivil()
        {
            return ControllerMaestroPersonal.GetInstance().ListaEstadoCivil();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar();
        }
        [WebMethod]
        public static ArrayList ListaCatAuxiliar2(string Categoria_Auxiliar_Id)
        {
            return ControllerMaestroPersonal.GetInstance().ListaCatAuxiliar2(Categoria_Auxiliar_Id);
        }
        [WebMethod]
        public static ArrayList ListaAnexo()
        {
            return ControllerMaestroPersonal.GetInstance().ListaAnexo();
        }
        [WebMethod]
        public static ArrayList ListaAnexo2()
        {
            return ControllerMaestroPersonal.GetInstance().ListaAnexo2();
        }
        [WebMethod]
        public static ArrayList ListaEstados()
        {
            return ControllerMaestroPersonal.GetInstance().ListaEstados();
        }
        [WebMethod]
        public static ArrayList ListaMotivoCese()
        {
            return ControllerMaestroPersonal.GetInstance().ListaMotivoCese();
        }
        [WebMethod]
        public static ArrayList ListaTipoCuenta()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoCuenta();
        }
        [WebMethod]
        public static ArrayList ListaBancos()
        {
            return ControllerMaestroPersonal.GetInstance().ListaBancos();
        }
        [WebMethod]
        public static ArrayList ListaMonedaCta()
        {
            return ControllerMaestroPersonal.GetInstance().ListaMonedaCta();
        }

        //--- 4. TRAB / PENSIONARIO
        [WebMethod]
        public static ArrayList ListaTipoTrabajador()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoTrabajador();
        }
        [WebMethod]
        public static ArrayList ListaRegLaboral()
        {
            return ControllerMaestroPersonal.GetInstance().ListaRegLaboral();
        }
        [WebMethod]
        public static ArrayList ListaNivelEducativo()
        {
            return ControllerMaestroPersonal.GetInstance().ListaNivelEducativo();
        }
        [WebMethod]
        public static ArrayList ListaCargo()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCargo();
        }
        [WebMethod]
        public static ArrayList ListaRegimenPensionario()
        {
            return ControllerMaestroPersonal.GetInstance().ListaRegimenPensionario();
        }
        [WebMethod]
        public static ArrayList ListaSCTRSalud()
        {
            return ControllerMaestroPersonal.GetInstance().ListaSCTRSalud();
        }
        [WebMethod]
        public static ArrayList ListaSCTRPension()
        {
            return ControllerMaestroPersonal.GetInstance().ListaSCTRPension();
        }
        [WebMethod]
        public static ArrayList ListaTipoContrato()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTipoContrato();
        }
        [WebMethod]
        public static ArrayList ListaEPS()
        {
            return ControllerMaestroPersonal.GetInstance().ListaEPS();
        }
        [WebMethod]
        public static ArrayList ListaSituacionEspecial()
        {
            return ControllerMaestroPersonal.GetInstance().ListaSituacionEspecial();
        }

        //---- 4ta / M.F. / Ter.
        [WebMethod]
        public static ArrayList ListaSeguroMedico()
        {
            return ControllerMaestroPersonal.GetInstance().ListaSeguroMedico();
        }
        [WebMethod]
        public static ArrayList ListaCentroFormacionProf()
        {
            return ControllerMaestroPersonal.GetInstance().ListaCentroFormacionProf();
        }
        [WebMethod]
        public static ArrayList ListaModFormativa()
        {
            return ControllerMaestroPersonal.GetInstance().ListaModFormativa();
        }

        //---- Otros Datos
        [WebMethod]
        public static ArrayList ListaComplexionFisica()
        {
            return ControllerMaestroPersonal.GetInstance().ListaComplexionFisica();
        }
        [WebMethod]
        public static ArrayList ListaGrupoSanguineo()
        {
            return ControllerMaestroPersonal.GetInstance().ListaGrupoSanguineo();
        }
        [WebMethod]
        public static ArrayList ListaTallaRopa()
        {
            return ControllerMaestroPersonal.GetInstance().ListaTallaRopa();
        }
        [WebMethod]
        public static ArrayList ListaBreveteCategoria()
        {
            return ControllerMaestroPersonal.GetInstance().ListaBreveteCategoria();
        }
        #endregion
    }
}