using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Transactions;

namespace CAPA_DATOS
{
    public class DAOPersonal
    {
        public DataTable ListaPersonalActivo(string Compania_Id, string NomColumna, string Param)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListarPersonalTodos", Compania_Id, NomColumna, Param);
        }

        public DataTable ListaColumnPersonal()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaColumnPersonal");
        }

        public DataTable ListaDataxPersonalId(string Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaDataxPersonalId", Personal_Id);
        }
        public DataTable ListaDataxPersonalIdAct(string Personal_Id, string Periodo_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaDataxPersonalIdAct", Personal_Id, Periodo_Id);
        }




        //---- 2. Datos Principales
        //-- Para Cargar los Datos  de los Combos
        public DataTable ListaTipoDoc()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoDoc");
        }
        public DataTable ListaNacionalidad()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaNacionalidad");
        }
        public DataTable ListaTipoSexo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoSexo");
        }
        public DataTable ListaTipoVia()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoVia");
        }
        public DataTable ListaTipoZona()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoZona");
        }
        public DataTable ListaDepartamento()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaDepartamento");
        }
        public DataTable ListaProvincia(string Departamento_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaProvincia", Departamento_Id);
        }
        public DataTable ListaDistrito(string Departamento_Id, string Provincia_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaDistrito", Departamento_Id, Provincia_Id);
        }

        // 3. Datos Secundarios
        public DataTable ListaArea()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaArea");
        }
        public DataTable ListaCCosto()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCCosto");
        }
        public DataTable ListaCategoria()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCategoria");
        }
        public DataTable ListaCategoria2()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCategoria2");
        }
        public DataTable ListaProyecto()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaProyecto");
        }
        public DataTable ListaSituacion()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaSituacion");
        }
        public DataTable ListaEstadoCivil()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaEstadoCivil");
        }
        public DataTable ListaCatAuxiliar()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCatAuxiliar");
        }
        public DataTable ListaCatAuxiliar2(string Categoria_Auxiliar_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCatAuxiliar2", Categoria_Auxiliar_Id);
        }
        public DataTable ListaAnexo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaAnexo");
        }
        public DataTable ListaAnexo2()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaAnexo2");
        }

        public DataTable ListaEstados()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaEstado");
        }
        public DataTable ListaMotivoCese()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaMotivoCese");
        }
        public DataTable ListaTipoCuenta()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoCuenta");
        }
        public DataTable ListaBancos()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaBancos");
        }
        public DataTable ListaMonedaCta()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaMonedaCta");
        }

        //-----------
        //--- 4. TRAB / PENSIONARIO
        public DataTable ListaTipoTrabajador()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoTrabajador");
        }
        public DataTable ListaRegLaboral()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaRegLaboral");
        }
        public DataTable ListaNivelEducativo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaNivelEducativo");
        }
        public DataTable ListaCargo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCargo");
        }
        public DataTable ListaRegimenPensionario()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaRegPensionario");
        }
        public DataTable ListaSCTRSalud()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaSCTRSalud");
        }
        public DataTable ListaSCTRPension()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaSCTRPension");
        }
        public DataTable ListaTipoContrato()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTipoContrato");
        }
        public DataTable ListaEPS()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaEPS");
        }
        public DataTable ListaSituacionEspecial()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaSituacionEspecial");
        }


        //---- 4ta / M.F. / Ter.
        public DataTable ListaSeguroMedico()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaSeguroMedico");
        }
        public DataTable ListaCentroFormacionProf()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaCentroFormacionProf");
        }
        public DataTable ListaModFormativa()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaModFormativa");
        }

        //---- Otros Datos
        public DataTable ListaComplexionFisica()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaComplexionFisica");
        }
        public DataTable ListaGrupoSanguineo()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaGrupoSanguineo");
        }
        public DataTable ListaTallaRopa()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaTallaRopa");
        }
        public DataTable ListaBreveteCategoria()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListaBreveteCategoria");
        }


        //----------- Insert Personal
        public DataTable GenPersonal_Id()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_GeneraPersonal_Id");
        }


        public int InsertPersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Apellido_Paterno
            , string Apellido_Materno, string Nombres, string Sexo_Id, string/*DateTime*/ Fecha_Nacimiento, string E_Civil_Id
            , string/*DateTime*/ Fecha_Ini_AporteAFP, string Tipo_Doc_Id, string Nro_Doc, string Categoria_Id, string Categoria2_Id
            , string Cargo_Id, string Situacion_Id, string Afp_Id, string Afp_cod_afiliacion, string Seguro_cod, string Ccosto_Id
            , string Dpto, string Prov, string Dist, string Direccion, string Telefono, string Telefono2, string Telefono3
            , int Nro_Hijos, string Tip_cta_Id, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Tip_cta_cts_Id, string Moneda_cta_cts_Id, string Banco_cta_cts_Id
            , string Proyecto_Id, string Tgasto_Id, string Usuario, string Pase, int lAdministrador
            , string Estado_Id, string Area_Id, string Cod_Antiguo, string email, string Nacionalidad_Id
            , bool Domiciliado, string Tipo_Via_Id, string Numero_Via, string Interior_Via, string Tipo_Zona_Id
            , string Nombre_Zona, string Referencia, string Tipo_Trabajador_Id, string Regimen_Laboral_Id
            , string Nivel_Educativo_Id, bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id
            , bool Jornada_Atipica, bool Jornada_Maxima, bool Horario_Nocturno, bool Sindicalizado, string EPS_Id
            , bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id, string RUC, string Seguro_Medico_Id, bool Madre_Resp_Fam
            , string Tipo_Centro_Form_Prof_Id, string RUC_Destaque,/*Byte Foto,*/string Foto_NombreArchivo, string Nro_Calzado
            , string Talla_Ropa_Id, string Grupo_Sanguineo_Id, double Estatura, double Peso, string Complexion_Fisica_Id, string Brevete_Nro
            , string Brevete_Categoria_Id, string/*DateTime*/ Brevete_Vigencia, string Alergias, string Codigo_Auxiliar, int Seccion_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertPersonal", Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
            , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id, Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id
            , Categoria2_Id, Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id, Dpto, Prov, Dist, Direccion, Telefono
            , Telefono2, Telefono3, Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id
            , Banco_cta_cts_Id, Proyecto_Id, Tgasto_Id, Usuario, Pase, lAdministrador, Estado_Id, Area_Id, Cod_Antiguo, email, Nacionalidad_Id
            , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id, Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
            , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id, Jornada_Atipica, Jornada_Maxima, Horario_Nocturno
            , Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id
            , RUC_Destaque,/*Foto,*/Foto_NombreArchivo, Nro_Calzado, Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id
            , Brevete_Nro, Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id);
        }


        public int InsertPersonalActivo(string Planilla_Id, string Periodo_Id, string Personal_Id, string Compania_Id, string/*DateTime*/ Fecha_ingreso
            , string/*DateTime*/ Fecha_cese, string/*DateTime*/ Fecha_ini_contrato, string/*DateTime*/ Fecha_fin_contrato, string Categoria_Id, string Cargo_Id, string Situacion_Id
            , string Afp_Id, string Ccosto_Id, string Dpto, string Prov, string Dist, string Direccion, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Moneda_cta_cts_Id, string Banco_cta_cts_Id, string Proyecto_Id, string Pry_Operacion_Id, string Pry_Categoria_Id
            , string Flag_Distribuido, string Observaciones, string Area_Id, string Categoria2_Id, string Tipo_Trabajador_Id, string Nivel_Educativo_Id
            , bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id, bool Jornada_Atipica, bool Jornada_Maxima
            , bool Horario_Nocturno, bool Sindicalizado, string EPS_Id, bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id
            , string Seguro_Medico_Id, bool Madre_Resp_Fam, string Tipo_Centro_Form_Prof_Id, string RUC_Destaque, string Motivo_Fin_Per_Lab_Id
            , string Tipo_Mod_Formativa_Id, string Nro_CITT, string Cod_Contrato, string/*DateTime*/ Fecha_Impresion_Contrato, string EPSPLAN_ID, int Cantidad_Titular
            , int Cantidad_Dependientes, int Cantidad_Hmayores, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string Personal_Anexo_Id
            , string Personal_Anexo2_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertPersonalActivo", Planilla_Id, Periodo_Id, Personal_Id, Compania_Id, Fecha_ingreso
            , Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato, Categoria_Id, Cargo_Id, Situacion_Id, Afp_Id, Ccosto_Id, Dpto, Prov, Dist, Direccion, Nro_cta
            , Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Moneda_cta_cts_Id, Banco_cta_cts_Id, Proyecto_Id, Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido
            , Observaciones, Area_Id, Categoria2_Id, Tipo_Trabajador_Id, Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
            , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, Seguro_Medico_Id
            , Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id, RUC_Destaque, Motivo_Fin_Per_Lab_Id, Tipo_Mod_Formativa_Id, Nro_CITT, Cod_Contrato, Fecha_Impresion_Contrato
            , EPSPLAN_ID, Cantidad_Titular, Cantidad_Dependientes, Cantidad_Hmayores, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id, Personal_Anexo2_Id);
        }


        public int InsertD_Fijos(string Planilla_Id, string Periodo_Id, string Personal_Id, string/*DateTime*/ Fecha_Modif)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertD_Fijos", Planilla_Id, Periodo_Id, Personal_Id, Fecha_Modif);
        }

        public int InsertD_Variables(string Planilla_Id, string Periodo_Id, string Personal_Id, string/*DateTime*/ Fecha_Modif)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertD_Variables", Planilla_Id, Periodo_Id, Personal_Id, Fecha_Modif);
        }

        public int Insert_CalculosPerm(string Planilla_Id, string Periodo_Id, string Personal_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_Insert_CalculosPerm", Planilla_Id, Periodo_Id, Personal_Id);
        }

        public int InsertD_Directos(string Periodo_Id, string Personal_Id, string/*DateTime*/ Fecha_Modif)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_InsertD_Directos", Periodo_Id, Personal_Id, Fecha_Modif);
        }

        public bool RegistraPersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Apellido_Paterno
            , string Apellido_Materno, string Nombres, string Sexo_Id, string/*DateTime*/ Fecha_Nacimiento, string E_Civil_Id
            , string/*DateTime*/ Fecha_Ini_AporteAFP, string Tipo_Doc_Id, string Nro_Doc, string Categoria_Id, string Categoria2_Id
            , string Cargo_Id, string Situacion_Id, string Afp_Id, string Afp_cod_afiliacion, string Seguro_cod, string Ccosto_Id
            , string Dpto, string Prov, string Dist, string Direccion, string Telefono, string Telefono2, string Telefono3
            , int Nro_Hijos, string Tip_cta_Id, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Tip_cta_cts_Id, string Moneda_cta_cts_Id, string Banco_cta_cts_Id
            , string Proyecto_Id, string Tgasto_Id, string Usuario, string Pase, int lAdministrador
            , string Estado_Id, string Area_Id, string Cod_Antiguo, string email, string Nacionalidad_Id
            , bool Domiciliado, string Tipo_Via_Id, string Numero_Via, string Interior_Via, string Tipo_Zona_Id
            , string Nombre_Zona, string Referencia, string Tipo_Trabajador_Id, string Regimen_Laboral_Id
            , string Nivel_Educativo_Id, bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id
            , bool Jornada_Atipica, bool Jornada_Maxima, bool Horario_Nocturno, bool Sindicalizado, string EPS_Id
            , bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id, string RUC, string Seguro_Medico_Id, bool Madre_Resp_Fam
            , string Tipo_Centro_Form_Prof_Id, string RUC_Destaque, /*Byte Foto,*/ string Foto_NombreArchivo, string Nro_Calzado
            , string Talla_Ropa_Id, string Grupo_Sanguineo_Id, double Estatura, double Peso, string Complexion_Fisica_Id, string Brevete_Nro
            , string Brevete_Categoria_Id, string/*DateTime*/ Brevete_Vigencia, string Alergias, string Codigo_Auxiliar, int Seccion_Id

            , string Periodo_Id, string/*DateTime*/ Fecha_ingreso, string/*DateTime*/ Fecha_cese, string/*DateTime*/ Fecha_ini_contrato, string/*DateTime*/ Fecha_fin_contrato
            , string Pry_Operacion_Id, string Pry_Categoria_Id, string Flag_Distribuido, string Observaciones, string Motivo_Fin_Per_Lab_Id
            , string Tipo_Mod_Formativa_Id, string Nro_CITT, string Cod_Contrato, string/*DateTime*/ Fecha_Impresion_Contrato, string EPSPLAN_ID, int Cantidad_Titular
            , int Cantidad_Dependientes, int Cantidad_Hmayores, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string Personal_Anexo_Id
            , string Personal_Anexo2_Id
            , string/*DateTime*/ Fecha_Modif_D)
        {
            TransactionScope trans = new TransactionScope();
            try
            {
                int rptaPersonal = InsertPersonal(Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
                        , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id, Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id
                        , Categoria2_Id, Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id, Dpto, Prov, Dist, Direccion, Telefono
                        , Telefono2, Telefono3, Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id
                        , Banco_cta_cts_Id, Proyecto_Id, Tgasto_Id, Usuario, Pase, lAdministrador, Estado_Id, Area_Id, Cod_Antiguo, email, Nacionalidad_Id
                        , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id, Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
                        , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id, Jornada_Atipica, Jornada_Maxima, Horario_Nocturno
                        , Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id
                        , RUC_Destaque, /*Foto,*/ Foto_NombreArchivo, Nro_Calzado, Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id
                        , Brevete_Nro, Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id);

                int rptaPersonalActivo = InsertPersonalActivo(Planilla_Id, Periodo_Id, Personal_Id, Compania_Id, Fecha_ingreso
                    , Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato, Categoria_Id, Cargo_Id, Situacion_Id, Afp_Id, Ccosto_Id, Dpto, Prov, Dist, Direccion, Nro_cta
                    , Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Moneda_cta_cts_Id, Banco_cta_cts_Id, Proyecto_Id, Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido
                    , Observaciones, Area_Id, Categoria2_Id, Tipo_Trabajador_Id, Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
                    , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, Seguro_Medico_Id
                    , Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id, RUC_Destaque, Motivo_Fin_Per_Lab_Id, Tipo_Mod_Formativa_Id, Nro_CITT, Cod_Contrato, Fecha_Impresion_Contrato
                    , EPSPLAN_ID, Cantidad_Titular, Cantidad_Dependientes, Cantidad_Hmayores, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id, Personal_Anexo2_Id);

                int rptaD_Fijos = InsertD_Fijos(Planilla_Id, Periodo_Id, Personal_Id, Fecha_Modif_D);
                int rptaD_Variables = InsertD_Variables(Planilla_Id, Periodo_Id, Personal_Id, Fecha_Modif_D);
                int rpta_CalculosPerm = Insert_CalculosPerm(Planilla_Id, Periodo_Id, Personal_Id);

                //int rptaCalculosPerm =

                bool rpta = false;
                if ((rptaPersonal == 0 || rptaPersonal == -1) && (rptaPersonalActivo == 0 || rptaPersonalActivo == -1)
                    && (rptaD_Fijos == 0 || rptaD_Fijos == -1) && (rptaD_Variables == 0 || rptaD_Variables == -1)
                    && (rpta_CalculosPerm == 0 || rpta_CalculosPerm == -1))
                {
                    trans.Dispose();
                }
                else
                {
                    trans.Complete();
                    trans.Dispose();
                    rpta = true;
                }
                return rpta;
            }
            catch (Exception ex)
            {
                trans.Dispose();
                throw ex;
            }
        }


        //------------ ACTUALIZA PERSONAL
        public int UpdatePersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Apellido_Paterno
            , string Apellido_Materno, string Nombres, string Sexo_Id, string/*DateTime*/ Fecha_Nacimiento, string E_Civil_Id
            , string/*DateTime*/ Fecha_Ini_AporteAFP, string Tipo_Doc_Id, string Nro_Doc, string Categoria_Id, string Categoria2_Id
            , string Cargo_Id, string Situacion_Id, string Afp_Id, string Afp_cod_afiliacion, string Seguro_cod, string Ccosto_Id
            , string Dpto, string Prov, string Dist, string Direccion, string Telefono, string Telefono2, string Telefono3
            , int Nro_Hijos, string Tip_cta_Id, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Tip_cta_cts_Id, string Moneda_cta_cts_Id, string Banco_cta_cts_Id
            , string Proyecto_Id//, string Tgasto_Id, string Usuario, string Pase, int lAdministrador
            , string Estado_Id, string Area_Id/*, string Cod_Antiguo*/, string email, string Nacionalidad_Id
            , bool Domiciliado, string Tipo_Via_Id, string Numero_Via, string Interior_Via, string Tipo_Zona_Id
            , string Nombre_Zona, string Referencia, string Tipo_Trabajador_Id, string Regimen_Laboral_Id
            , string Nivel_Educativo_Id, bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id
            , bool Jornada_Atipica, bool Jornada_Maxima, bool Horario_Nocturno, bool Sindicalizado, string EPS_Id
            , bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id, string RUC, string Seguro_Medico_Id, bool Madre_Resp_Fam
            , string Tipo_Centro_Form_Prof_Id, string RUC_Destaque,/*Byte Foto,string Foto_NombreArchivo,*/ string Nro_Calzado
            , string Talla_Ropa_Id, string Grupo_Sanguineo_Id, double Estatura, double Peso, string Complexion_Fisica_Id, string Brevete_Nro
            , string Brevete_Categoria_Id, string/*DateTime*/ Brevete_Vigencia, string Alergias, string Codigo_Auxiliar, int Seccion_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_UpdatePersonal", Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
            , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id, Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id
            , Categoria2_Id, Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id, Dpto, Prov, Dist, Direccion, Telefono
            , Telefono2, Telefono3, Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id
            , Banco_cta_cts_Id, Proyecto_Id, /*Tgasto_Id, Usuario, Pase, lAdministrador,*/ Estado_Id, Area_Id,/* Cod_Antiguo,*/ email, Nacionalidad_Id
            , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id, Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
            , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id, Jornada_Atipica, Jornada_Maxima, Horario_Nocturno
            , Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id
            , RUC_Destaque,/*Foto,Foto_NombreArchivo,*/ Nro_Calzado, Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id
            , Brevete_Nro, Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id);
        }

        public int UpdatePersonalActivo(string Planilla_Id, string Periodo_Id, string Personal_Id, string Compania_Id, string/*DateTime*/ Fecha_ingreso
            , string/*DateTime*/ Fecha_cese, string/*DateTime*/ Fecha_ini_contrato, string/*DateTime*/ Fecha_fin_contrato, string Categoria_Id, string Cargo_Id, string Situacion_Id
            , string Afp_Id, string Ccosto_Id, string Dpto, string Prov, string Dist, string Direccion, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Moneda_cta_cts_Id, string Banco_cta_cts_Id, string Proyecto_Id//, string Pry_Operacion_Id, string Pry_Categoria_Id
            /*, string Flag_Distribuido, string Observaciones*/, string Area_Id, string Categoria2_Id, string Tipo_Trabajador_Id, string Nivel_Educativo_Id
            , bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id, bool Jornada_Atipica, bool Jornada_Maxima
            , bool Horario_Nocturno, bool Sindicalizado, string EPS_Id, bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id
            , string Seguro_Medico_Id, bool Madre_Resp_Fam, string Tipo_Centro_Form_Prof_Id, string RUC_Destaque, string Motivo_Fin_Per_Lab_Id
            , string Tipo_Mod_Formativa_Id, string Nro_CITT, /*string Cod_Contrato, string DateTime Fecha_Impresion_Contrato,*/ string EPSPLAN_ID//, int Cantidad_Titular
            /*, int Cantidad_Dependientes, int Cantidad_Hmayores*/, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string Personal_Anexo_Id
            , string Personal_Anexo2_Id)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_UpdatePersonal_Activo", Planilla_Id, Periodo_Id, Personal_Id, Compania_Id, Fecha_ingreso
            , Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato, Categoria_Id, Cargo_Id, Situacion_Id, Afp_Id, Ccosto_Id, Dpto, Prov, Dist, Direccion, Nro_cta
            , Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Moneda_cta_cts_Id, Banco_cta_cts_Id, Proyecto_Id//, Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido
                /*, Observaciones*/, Area_Id, Categoria2_Id, Tipo_Trabajador_Id, Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
            , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, Seguro_Medico_Id
            , Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id, RUC_Destaque, Motivo_Fin_Per_Lab_Id, Tipo_Mod_Formativa_Id, Nro_CITT//, Cod_Contrato, Fecha_Impresion_Contrato
            , EPSPLAN_ID, /*Cantidad_Titular, Cantidad_Dependientes, Cantidad_Hmayores,*/ Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id, Personal_Anexo2_Id);
        }


        public bool ActualizaPersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Apellido_Paterno
            , string Apellido_Materno, string Nombres, string Sexo_Id, string/*DateTime*/ Fecha_Nacimiento, string E_Civil_Id
            , string/*DateTime*/ Fecha_Ini_AporteAFP, string Tipo_Doc_Id, string Nro_Doc, string Categoria_Id, string Categoria2_Id
            , string Cargo_Id, string Situacion_Id, string Afp_Id, string Afp_cod_afiliacion, string Seguro_cod, string Ccosto_Id
            , string Dpto, string Prov, string Dist, string Direccion, string Telefono, string Telefono2, string Telefono3
            , int Nro_Hijos, string Tip_cta_Id, string Nro_cta, string Moneda_cta_Id, string Banco_cta_Id
            , string Nro_cta_cts, string Tip_cta_cts_Id, string Moneda_cta_cts_Id, string Banco_cta_cts_Id
            , string Proyecto_Id//, string Tgasto_Id, string Usuario, string Pase, int lAdministrador
            , string Estado_Id, string Area_Id/*, string Cod_Antiguo*/, string email, string Nacionalidad_Id
            , bool Domiciliado, string Tipo_Via_Id, string Numero_Via, string Interior_Via, string Tipo_Zona_Id
            , string Nombre_Zona, string Referencia, string Tipo_Trabajador_Id, string Regimen_Laboral_Id
            , string Nivel_Educativo_Id, bool Discapacidad, string SCTR_Salud_Id, string SCTR_Pension_Id, string Tipo_Contrato_Id
            , bool Jornada_Atipica, bool Jornada_Maxima, bool Horario_Nocturno, bool Sindicalizado, string EPS_Id
            , bool Ingresos_5ta_Inafectos, string Situacion_Especial_Id, string RUC, string Seguro_Medico_Id, bool Madre_Resp_Fam
            , string Tipo_Centro_Form_Prof_Id, string RUC_Destaque,/*Byte Foto,string Foto_NombreArchivo,*/ string Nro_Calzado
            , string Talla_Ropa_Id, string Grupo_Sanguineo_Id, double Estatura, double Peso, string Complexion_Fisica_Id, string Brevete_Nro
            , string Brevete_Categoria_Id, string/*DateTime*/ Brevete_Vigencia, string Alergias, string Codigo_Auxiliar, int Seccion_Id

            , string Periodo_Id, string/*DateTime*/ Fecha_ingreso
            , string/*DateTime*/ Fecha_cese, string/*DateTime*/ Fecha_ini_contrato, string/*DateTime*/ Fecha_fin_contrato
            //, string Pry_Operacion_Id, string Pry_Categoria_Id
            /*, string Flag_Distribuido, string Observaciones*/
            , string Motivo_Fin_Per_Lab_Id
            , string Tipo_Mod_Formativa_Id, string Nro_CITT, /*string Cod_Contrato, string DateTime Fecha_Impresion_Contrato,*/ string EPSPLAN_ID//, int Cantidad_Titular
            /*, int Cantidad_Dependientes, int Cantidad_Hmayores*/, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string Personal_Anexo_Id
            , string Personal_Anexo2_Id)
        {
            TransactionScope trans = new TransactionScope();
            try
            {
                int rptaPersonal = UpdatePersonal(Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
                    , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id, Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id
                    , Categoria2_Id, Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id, Dpto, Prov, Dist, Direccion, Telefono
                    , Telefono2, Telefono3, Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id
                    , Banco_cta_cts_Id, Proyecto_Id, /*Tgasto_Id, Usuario, Pase, lAdministrador,*/ Estado_Id, Area_Id,/* Cod_Antiguo,*/ email, Nacionalidad_Id
                    , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id, Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
                    , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id, Jornada_Atipica, Jornada_Maxima, Horario_Nocturno
                    , Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id
                    , RUC_Destaque,/*Foto,Foto_NombreArchivo,*/ Nro_Calzado, Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id
                    , Brevete_Nro, Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id);

                int rptaPersonalActivo = UpdatePersonalActivo(Planilla_Id, Periodo_Id, Personal_Id, Compania_Id, Fecha_ingreso
                    , Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato, Categoria_Id, Cargo_Id, Situacion_Id, Afp_Id, Ccosto_Id, Dpto, Prov, Dist, Direccion, Nro_cta
                    , Moneda_cta_Id, Banco_cta_Id, Nro_cta_cts, Moneda_cta_cts_Id, Banco_cta_cts_Id, Proyecto_Id//, Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido
                    /*, Observaciones*/, Area_Id, Categoria2_Id, Tipo_Trabajador_Id, Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
                    , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id, Ingresos_5ta_Inafectos, Situacion_Especial_Id, Seguro_Medico_Id
                    , Madre_Resp_Fam, Tipo_Centro_Form_Prof_Id, RUC_Destaque, Motivo_Fin_Per_Lab_Id, Tipo_Mod_Formativa_Id, Nro_CITT//, Cod_Contrato, Fecha_Impresion_Contrato
                    , EPSPLAN_ID, /*Cantidad_Titular, Cantidad_Dependientes, Cantidad_Hmayores,*/ Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id, Personal_Anexo2_Id);

                bool rpta = false;
                if ((rptaPersonal == 0 || rptaPersonal == -1) && (rptaPersonalActivo == 0 || rptaPersonalActivo == -1))
                {
                    trans.Dispose();
                }
                else
                {
                    trans.Complete();
                    trans.Dispose();
                    rpta = true;
                }
                return rpta;
            }
            catch (Exception ex)
            {
                trans.Dispose();
                throw ex;
            }
        }

        public bool EliminarPersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Periodo_Id)
        {
            try
            {
                int rpta;
                rpta = SqlHelper.ExecuteNonQuery(Conex.CadCon(), "usp_DeletePersonal", Personal_Id, Compania_Id, Planilla_Id, Periodo_Id);
                if (rpta == 0 && rpta == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateFijos(string Personal_Id, string Periodo_Id, double Sueldo, double Movilidad, double ValeAlimento)
        {
            TransactionScope trans = new TransactionScope();
            try
            {
                int rptaSueldo = 0;
                int rptaMovilidad = 0;
                int rptaValeALimento = 0;
                rptaSueldo = SqlHelper.ExecuteNonQuery(Conex.CadCon(), CommandType.Text, "Update D_Fijos Set Valor = " + Sueldo + " where Concepto_Id='000001' and Personal_Id='" + Personal_Id + "' and Periodo_Id='" + Periodo_Id + "'");
                rptaMovilidad = SqlHelper.ExecuteNonQuery(Conex.CadCon(), CommandType.Text, "Update D_Fijos Set Valor = " + Movilidad + " where Concepto_Id='000850' and Personal_Id='" + Personal_Id + "' and Periodo_Id='" + Periodo_Id + "'");
                rptaValeALimento = SqlHelper.ExecuteNonQuery(Conex.CadCon(), CommandType.Text, "Update D_Fijos Set Valor = " + ValeAlimento + " where Concepto_Id='000851' and Personal_Id='" + Personal_Id + "' and Periodo_Id='" + Periodo_Id + "'");

                bool rpta = false;
                if (rptaSueldo == 1 && rptaMovilidad == 1 && rptaValeALimento == 1)
                {
                    rpta = true;
                    trans.Complete();
                    trans.Dispose();
                }
                else
                {
                    trans.Dispose();
                }
                return rpta;
            }
            catch (Exception ex)
            {
                trans.Dispose();
                throw ex;
            }
            //SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            //SqlConnection cn = new SqlConnection(Conex.CadCon());
            //cmd.CommandText = "Update D_Fijos Set Valor = " + Sueldo + " where Concepto_Id='000001' and Periodo_Id='" + Periodo_Id + "'";
            //cmd.CommandType = CommandType.Text;
            ////cmd.Connection.ConnectionString = Conex.CadCon();
            //cn.Open();
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    cn.Close();
            //    return true;
            //}
            //catch ( Exception ex) 
            //{
            //    throw ex;
            //}
            //finally 
            //{
            //    cn.Close();
            //    cmd.Dispose();
            //    da.Dispose();
            //}



        }
        /*mily*/


        /*AGREGADOS ULTIMOS*/


        public static List<CAPA_ENTIDAD.EntMs.D_Personal_Listar> Personal_Listar(string Personal_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_Datos_Persona", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@personal_id", Personal_Id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CAPA_ENTIDAD.EntMs.D_Personal_Listar> oLista = new List<CAPA_ENTIDAD.EntMs.D_Personal_Listar>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.D_Personal_Listar obj = new CAPA_ENTIDAD.EntMs.D_Personal_Listar();
                        obj.Localidad = dr.GetValue(0).ToString();
                        obj.Cargo = dr.GetValue(1).ToString();
                        obj.Seccion = dr.GetValue(2).ToString();
                        oLista.Add(obj);

                    }
                    return oLista;

                }
            }
        }

        public string GetLocalidadxPersonal(string Personal_id)
        {
            return SqlHelper.ExecuteScalar(Conex.CadCon(), "usp_Localidad_Persona", Personal_id).ToString();
        }


        public DataTable ListaPersonalActivo_Con_WPP(string Area_Id, string Planilla_Id, string Periodo_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_ListarPersonalActivo_Con_WPP", Area_Id, Planilla_Id, Periodo_Id);
        }


        public DataTable ListaCargoPersonal(string Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_ver_Cargo", Personal_Id);
        }

        public DataTable ListaDFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_sps_ver_D_Fijos]", Personal_Id, Periodo_Id);
        }

        public DataTable ListaD_MovFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_sps_ver_D_Mov_Fijos]", Personal_Id, Periodo_Id);
        }

        public DataTable ListaD_ValeFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_sps_ver_D_Vale_Fijos]", Personal_Id, Periodo_Id);
        }

        public DataTable ListaAreaPersonal(string Area_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_sps_ver_D_Area]", Area_Id);
        }

        public DataTable ListaCategoriaAuxiliar2(string CatAuxiliar_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "[fps_sps_Categoria_Auxiliar2]", "", CatAuxiliar_Id);
        }


        public DataTable ListaVerAuxiliar(string Personal_Id)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_sps_Ver_Categoria_Auxiliar", Personal_Id);
        }


        //public String Actualizar_DFijosSueldo(double Sueldo, string Personal_Id, string Periodo_Id)
        //{
        //    DataTable dt = new DataTable();
        //    dt = SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Actualizar_DFijos_Sueldo", Sueldo, Personal_Id, Periodo_Id);
        //    String ValorSueldo = dt.Rows[0][0].ToString();
        //    dt.Dispose();
        //    return ValorSueldo;
        //}

        //public String Actualizar_DFijosMov(double Mov, string Personal_Id, string Periodo_Id)
        //{
        //    DataTable dt = new DataTable();
        //    dt = SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Actualizar_DFijos_Mov", Mov, Personal_Id, Periodo_Id);
        //    String ValorMov = dt.Rows[0][0].ToString();
        //    dt.Dispose();
        //    return ValorMov;
        //}

        //public String Actualizar_DFijosVale(double Vale, string Personal_Id, string Periodo_Id)
        //{
        //    DataTable dt = new DataTable();
        //    dt = SqlHelper.ExecuteDataTable(Conex.CadCon(), "usp_Actualizar_DFijos_Vale", Vale, Personal_Id, Periodo_Id);
        //    String ValorVale = dt.Rows[0][0].ToString();
        //    dt.Dispose();
        //    return ValorVale;
        //}


    }
}
