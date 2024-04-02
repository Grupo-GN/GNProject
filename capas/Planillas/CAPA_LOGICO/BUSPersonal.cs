using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPA_DATOS;

namespace CAPA_LOGICO
{
    public class BUSPersonal
    {
        CAPA_DATOS.DAOPersonal objDatos = new DAOPersonal();
        public DataTable ListaPersonalActivo(string Compania_Id, string NomColumna, string Param)
        {
            return objDatos.ListaPersonalActivo(Compania_Id, NomColumna, Param);
        }
        public DataTable ListaColumnPersonal()
        {
            return objDatos.ListaColumnPersonal();
        }

        public DataTable ListaDataxPersonalId(string Personal_Id)
        {
            return objDatos.ListaDataxPersonalId(Personal_Id);
        }

        public DataTable ListaDataxPersonalIdAct(string Personal_Id, string Periodo_Id)
        {
            return objDatos.ListaDataxPersonalIdAct(Personal_Id, Periodo_Id);
        }



        //----Carga los Combos
        public DataTable ListaTipoDoc()
        {
            return objDatos.ListaTipoDoc();
        }
        public DataTable ListaNacionalidad()
        {
            return objDatos.ListaNacionalidad();
        }
        public DataTable ListaTipoSexo()
        {
            return objDatos.ListaTipoSexo();
        }
        public DataTable ListaTipoVia()
        {
            return objDatos.ListaTipoVia();
        }
        public DataTable ListaTipoZona()
        {
            return objDatos.ListaTipoZona();
        }
        public DataTable ListaDepartamento()
        {
            return objDatos.ListaDepartamento();
        }
        public DataTable ListaProvincia(string Departamento_Id)
        {
            return objDatos.ListaProvincia(Departamento_Id);
        }
        public DataTable ListaDistrito(string Departamento_Id, string Provincia_Id)
        {
            return objDatos.ListaDistrito(Departamento_Id, Provincia_Id);
        }

        //Datos Secundarios
        public DataTable ListaArea()
        {
            return objDatos.ListaArea();
        }
        public DataTable ListaCCosto()
        {
            return objDatos.ListaCCosto();
        }
        public DataTable ListaCategoria()
        {
            return objDatos.ListaCategoria();
        }
        public DataTable ListaCategoria2()
        {
            return objDatos.ListaCategoria2();
        }
        public DataTable ListaProyecto()
        {
            return objDatos.ListaProyecto();
        }
        public DataTable ListaSituacion()
        {
            return objDatos.ListaSituacion();
        }
        public DataTable ListaEstadoCivil()
        {
            return objDatos.ListaEstadoCivil();
        }
        public DataTable ListaCatAuxiliar()
        {
            return objDatos.ListaCatAuxiliar();
        }
        public DataTable ListaCatAuxiliar2(string Categoria_Auxiliar_Id)
        {
            return objDatos.ListaCatAuxiliar2(Categoria_Auxiliar_Id);
        }
        public DataTable ListaAnexo()
        {
            return objDatos.ListaAnexo();
        }
        public DataTable ListaAnexo2()
        {
            return objDatos.ListaAnexo2();
        }

        public DataTable ListaEstados()
        {
            return objDatos.ListaEstados();
        }
        public DataTable ListaMotivoCese()
        {
            return objDatos.ListaMotivoCese();
        }
        public DataTable ListaTipoCuenta()
        {
            return objDatos.ListaTipoCuenta();
        }
        public DataTable ListaBancos()
        {
            return objDatos.ListaBancos();
        }
        public DataTable ListaMonedaCta()
        {
            return objDatos.ListaMonedaCta();
        }


        //-----------
        //--- 4. TRAB / PENSIONARIO
        public DataTable ListaTipoTrabajador()
        {
            return objDatos.ListaTipoTrabajador();
        }
        public DataTable ListaRegLaboral()
        {
            return objDatos.ListaRegLaboral();
        }
        public DataTable ListaNivelEducativo()
        {
            return objDatos.ListaNivelEducativo();
        }
        public DataTable ListaCargo()
        {
            return objDatos.ListaCargo();
        }
        public DataTable ListaRegimenPensionario()
        {
            return objDatos.ListaRegimenPensionario();
        }
        public DataTable ListaSCTRSalud()
        {
            return objDatos.ListaSCTRSalud();
        }
        public DataTable ListaSCTRPension()
        {
            return objDatos.ListaSCTRPension();
        }
        public DataTable ListaTipoContrato()
        {
            return objDatos.ListaTipoContrato();
        }
        public DataTable ListaEPS()
        {
            return objDatos.ListaEPS();
        }
        public DataTable ListaSituacionEspecial()
        {
            return objDatos.ListaSituacionEspecial();
        }


        //---- 4ta / M.F. / Ter.
        public DataTable ListaSeguroMedico()
        {
            return objDatos.ListaSeguroMedico();
        }
        public DataTable ListaCentroFormacionProf()
        {
            return objDatos.ListaCentroFormacionProf();
        }
        public DataTable ListaModFormativa()
        {
            return objDatos.ListaModFormativa();
        }


        //---- Otros Datos
        public DataTable ListaComplexionFisica()
        {
            return objDatos.ListaComplexionFisica();
        }
        public DataTable ListaGrupoSanguineo()
        {
            return objDatos.ListaGrupoSanguineo();
        }
        public DataTable ListaTallaRopa()
        {
            return objDatos.ListaTallaRopa();
        }
        public DataTable ListaBreveteCategoria()
        {
            return objDatos.ListaBreveteCategoria();
        }


        // Grabar Personal

        public DataTable GenPersonal_Id()
        {
            return objDatos.GenPersonal_Id();
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
            return objDatos.RegistraPersonal(Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
            , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id
            , Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id, Categoria2_Id
            , Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id
            , Dpto, Prov, Dist, Direccion, Telefono, Telefono2, Telefono3
            , Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id
            , Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id, Banco_cta_cts_Id
            , Proyecto_Id, Tgasto_Id, Usuario, Pase, lAdministrador
            , Estado_Id, Area_Id, Cod_Antiguo, email, Nacionalidad_Id
            , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id
            , Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
            , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
            , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id
            , Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam
            , Tipo_Centro_Form_Prof_Id, RUC_Destaque,  /*Foto,*/  Foto_NombreArchivo, Nro_Calzado
            , Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id, Brevete_Nro
            , Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id

            , Periodo_Id, Fecha_ingreso, Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato
            , Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido, Observaciones, Motivo_Fin_Per_Lab_Id
            , Tipo_Mod_Formativa_Id, Nro_CITT, Cod_Contrato, Fecha_Impresion_Contrato, EPSPLAN_ID, Cantidad_Titular
            , Cantidad_Dependientes, Cantidad_Hmayores, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id
            , Personal_Anexo2_Id
            , Fecha_Modif_D);
        }

        //ACTUALIZA PERSONAL
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
            return objDatos.ActualizaPersonal(Personal_Id, Compania_Id, Planilla_Id, Apellido_Paterno
            , Apellido_Materno, Nombres, Sexo_Id, Fecha_Nacimiento, E_Civil_Id
            , Fecha_Ini_AporteAFP, Tipo_Doc_Id, Nro_Doc, Categoria_Id, Categoria2_Id
            , Cargo_Id, Situacion_Id, Afp_Id, Afp_cod_afiliacion, Seguro_cod, Ccosto_Id
            , Dpto, Prov, Dist, Direccion, Telefono, Telefono2, Telefono3
            , Nro_Hijos, Tip_cta_Id, Nro_cta, Moneda_cta_Id, Banco_cta_Id
            , Nro_cta_cts, Tip_cta_cts_Id, Moneda_cta_cts_Id, Banco_cta_cts_Id
            , Proyecto_Id//, Tgasto_Id, Usuario, Pase, lAdministrador
            , Estado_Id, Area_Id, /*Cod_Antiguo,*/ email, Nacionalidad_Id
            , Domiciliado, Tipo_Via_Id, Numero_Via, Interior_Via, Tipo_Zona_Id
            , Nombre_Zona, Referencia, Tipo_Trabajador_Id, Regimen_Laboral_Id
            , Nivel_Educativo_Id, Discapacidad, SCTR_Salud_Id, SCTR_Pension_Id, Tipo_Contrato_Id
            , Jornada_Atipica, Jornada_Maxima, Horario_Nocturno, Sindicalizado, EPS_Id
            , Ingresos_5ta_Inafectos, Situacion_Especial_Id, RUC, Seguro_Medico_Id, Madre_Resp_Fam
            , Tipo_Centro_Form_Prof_Id, RUC_Destaque,  /*Foto,  Foto_NombreArchivo,*/ Nro_Calzado
            , Talla_Ropa_Id, Grupo_Sanguineo_Id, Estatura, Peso, Complexion_Fisica_Id, Brevete_Nro
            , Brevete_Categoria_Id, Brevete_Vigencia, Alergias, Codigo_Auxiliar, Seccion_Id

            , Periodo_Id, Fecha_ingreso, Fecha_cese, Fecha_ini_contrato, Fecha_fin_contrato
                /*, Pry_Operacion_Id, Pry_Categoria_Id, Flag_Distribuido, Observaciones*/, Motivo_Fin_Per_Lab_Id
            , Tipo_Mod_Formativa_Id, Nro_CITT, /*Cod_Contrato, Fecha_Impresion_Contrato,*/ EPSPLAN_ID//, Cantidad_Titular
                /*, Cantidad_Dependientes, Cantidad_Hmayores*/, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Personal_Anexo_Id
            , Personal_Anexo2_Id);
        }


        public bool EliminarPersonal(string Personal_Id, string Compania_Id, string Planilla_Id, string Periodo_Id)
        {
            return objDatos.EliminarPersonal(Personal_Id, Compania_Id, Planilla_Id, Periodo_Id);
        }

        public bool UpdateFijos(string Personal_Id, string Periodo_Id, double Sueldo, double Movilidad, double ValeAlimento)
        {
            return objDatos.UpdateFijos(Personal_Id, Periodo_Id, Sueldo, Movilidad, ValeAlimento);
        }

        /*mily*/

        /*AGREGADOS ULTIMOS*/


        public static List<CAPA_ENTIDAD.EntMs.D_Personal_Listar> PersonalListar(string Personal_Id)
        {

            return DAOPersonal.Personal_Listar(Personal_Id);
        }


        public string GetLocalidadxPersonal(string Personal_id)
        {
            return objDatos.GetLocalidadxPersonal(Personal_id).ToString();
        }

        public DataTable ListaPersonalActivo_Con_WPP(string Area_Id, string Planilla_Id, string Periodo_Id)
        {
            return objDatos.ListaPersonalActivo_Con_WPP(Area_Id, Planilla_Id, Periodo_Id);
        }


        public DataTable ListaCargoPersonal(string Personal_Id)
        {
            return objDatos.ListaCargoPersonal(Personal_Id);
        }

        public DataTable ListaDFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return objDatos.ListaDFijoPersonal(Personal_Id, Periodo_Id);
        }

        public DataTable ListaD_MovFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return objDatos.ListaD_MovFijoPersonal(Personal_Id, Periodo_Id);
        }

        public DataTable ListaD_ValeFijoPersonal(string Personal_Id, string Periodo_Id)
        {
            return objDatos.ListaD_ValeFijoPersonal(Personal_Id, Periodo_Id);
        }

        public DataTable ListaAreaPersonal(string Area_Id)
        {
            return objDatos.ListaAreaPersonal(Area_Id);
        }

        public DataTable ListaCategoriaAuxiliar2(string CatAuxiliar_Id)
        {
            return objDatos.ListaCategoriaAuxiliar2(CatAuxiliar_Id);
        }




        public DataTable ListaVerAuxiliar(string Personal_Id)
        {
            return objDatos.ListaVerAuxiliar(Personal_Id);
        }


        //public String Actualizar_DFijosSueldo(double Sueldo, string Personal_Id, string Periodo_Id)
        //{
        //    return objDatos.Actualizar_DFijosSueldo(Sueldo, Personal_Id, Periodo_Id);
        //}

        //public String Actualizar_DFijosMov(double Mov, string Personal_Id, string Periodo_Id)
        //{
        //    return objDatos.Actualizar_DFijosMov(Mov, Personal_Id, Periodo_Id);
        //}

        //public String Actualizar_DFijosVale(double Vale, string Personal_Id, string Periodo_Id)
        //{
        //    return objDatos.Actualizar_DFijosVale(Vale, Personal_Id, Periodo_Id);
        //}


    }
}
