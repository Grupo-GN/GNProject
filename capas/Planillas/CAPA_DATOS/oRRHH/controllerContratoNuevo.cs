using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace CAPA_DATOS.oRRHH
{
    public class controllerContratoNuevo
    {
        private static controllerContratoNuevo instance = null;
        public static controllerContratoNuevo getInstance()
        {
            return instance == null ? instance = new controllerContratoNuevo() : instance;
        }
        public ArrayList ListaTipoPlanilla()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Planilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", "01");
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "01");
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaPeriodo(string EjercicioId, string Planilla_Id, string MesId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", "");
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", EjercicioId);
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@vi_Descripcion", "");
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "02");
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", "01");
                    cmd.Parameters.AddWithValue("@vi_Mes_Id", MesId);
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaBanco()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaBancos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaRegPensionario()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaRegPensionario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaEstadoCivil()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaEstadoCivil", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaTipoContrato()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TIPO_CONTRATO_ID,DESCRIPCION FROM TIPO_CONTRATO WHERE TIPO_CONTRATO_ID IN('01','04','03','14','15')", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaCargo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCargo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        
        public ArrayList ListaArea()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaArea", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaCatAuxiliar()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CATEGORIA_AUXILIAR_ID, DESCRIPCION FROM CATEGORIA_AUXILIAR", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaCatAuxiliar2(string xCatAuxiliar)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CATEGORIA_AUXILIAR2_ID, DESCRIPCION FROM CATEGORIA_AUXILIAR2 WHERE CATEGORIA_AUXILIAR_ID=@Cat1", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Cat1", xCatAuxiliar);
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListarCombos(string xOp, string xCodigo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("I_sps_combo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_codigo", xOp);
                    cmd.Parameters.AddWithValue("@vi_co_padre", xCodigo);
                    cmd.Parameters.AddWithValue("@vi_co_usuario", "");
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }
        public ArrayList ListaSeguroMedico()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSeguroMedico", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;
                }
            }
        }

        public String ActualizaFinContrato_Renovacion(String Personal_Id, String Planilla_Id, String Periodo_Id, DateTime dt_fe_ini_contrato, DateTime dt_fe_fin_contrato)
        {
            String fecInicioContrato = dt_fe_ini_contrato.ToString("dd/MM/yyyy");
            String fecFinalContrato = dt_fe_fin_contrato.ToString("dd/MM/yyyy");
            string comando = "Update Personal_Activo Set Fecha_ini_contrato=convert(Datetime,'" + fecInicioContrato + "',103), Fecha_fin_contrato=convert(Datetime,'" + fecFinalContrato + "',103) ";
            comando += " where Personal_Id='" + Personal_Id + "' and Periodo_Id='" + Periodo_Id + "' and Planilla_Id='" + Planilla_Id + "'";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                }
            }

            EnviarCorreoContrato_NuevoRenovado(Personal_Id, Periodo_Id);

            return "OK";
        }

        public string GuardarPersonalNuevo(string Planilla_Id, string Periodo_Id, string Fecha_ingreso,
            string Fecha_ini_contrato, string Fecha_fin_contrato, string Cargo_Id, string Afp_Id
            , string Direccion, string Nro_cta, string Banco_cta_Id, string Nro_cta_cts, string Banco_cta_cts_Id
            , string Observaciones, string Area_Id, string Categoria2_Id, string Tipo_Contrato_Id, string Seguro_Medico_Id
            , string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, DateTime Fecha_Nacimiento, string ECivil
            , string Apellido_Paterno, string Apellido_Materno, string Nombres, string Telefono, string Telefono2, string Telefono3
            , string CorreoCorp, string CorreoPer, string NroDoc, string CUSP, int NroHijos
            , string Alergias, string CodigoSap, string CodigoSapDeudor, string JefeId, string GerenteId, string CoodinadorId
            , decimal Sueldo, decimal Movilidad, decimal ValeAlimento, String Cargo_Funcion_Ids)
        {
            string resultado = "false#";
            try
            {
                string Personal_Id = "";
                string Compania_Id = "01";
                string Estado_Id = "01";
                string Sexo = "01";
                //ECivil = "01";
                string TipoDoc = "01";
                string TipoCuentaId = "1";
                string BreveteCategoriaId = "00";
                string NroBrevete = "";
                string TipoViaId = "00";
                string TipoZonaId = "00";
                string NombreZona = "";
                string Dpto = "15"; //Lima por defecto
                string Prov = "01";// Lima por defecto
                string Dist = "01";// Lima por defecto

                string Categoria_Id = "01";
                string Situacion_Id = "01";
                string Ccosto_Id = "000000"; //txtCcostoSap.Text.Trim()   'Empresa
                string Afp_cod_afiliacion = CUSP;

                string Moneda_cta_Id = "MN";
                string BancoCtaId = Banco_cta_Id;

                string TipoCuentaCtsId = "1 ";
                string Moneda_cta_cts_Id = "MN";
                string BancoCtaCtsId = Banco_cta_cts_Id;


                string Proyecto_Id = "0000000000";
                string NacionalidadId = "9589";


                string Tipo_Trabajador_Id = "";
                if (Planilla_Id == "01")
                { //Empleado
                    Tipo_Trabajador_Id = "21";
                } //empleado
                else if (Planilla_Id == "04")
                {//Obrero
                    Tipo_Trabajador_Id = "20";
                } //obrero

                string RegimenLaboralId = "1";
                string Nivel_Educativo_Id = "05";// 'Primaria completa por defecto
                string SCTR_Salud_Id = "0";
                string SCTR_Pension_Id = "0";
                string TipoContratoId = Tipo_Contrato_Id;
                string EPS_Id = "0";
                string Situacion_Especial_Id = "0";
                string Ruc = "";
                string TipoCentroFormProfId = "0";
                string TallaRopaId = "00";
                string GrupoSanguineoId = "00";
                string ComplexionFisicaId = "00";

                string Flag_Distribuido = "";
                string MotivoFinPerLabId = "00";
                string TipoModFormativaId = "00";

                string PersonalAnexoId = "00000000";
                string PersonalAnexo2Id = "00000000";


                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GeneraPersonal_Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        Personal_Id = cmd.ExecuteScalar().ToString();
                    }
                }

                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertPersonal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Apellido_Paterno", Apellido_Paterno.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@Apellido_Materno", Apellido_Materno.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@Nombres", Nombres.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@Sexo_Id", Sexo);
                        cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Fecha_Nacimiento);
                        cmd.Parameters.AddWithValue("@E_Civil_Id", ECivil);
                        cmd.Parameters.AddWithValue("@Fecha_Ini_AporteAFP", DateTime.Parse(Fecha_ingreso));
                        cmd.Parameters.AddWithValue("@Tipo_Doc_Id", TipoDoc);
                        cmd.Parameters.AddWithValue("@Nro_Doc", NroDoc);
                        cmd.Parameters.AddWithValue("@Categoria_Id", Categoria_Id);
                        cmd.Parameters.AddWithValue("@Categoria2_Id", Categoria2_Id);
                        cmd.Parameters.AddWithValue("@Cargo_Id", Cargo_Id);
                        cmd.Parameters.AddWithValue("@Situacion_Id", Situacion_Id);
                        cmd.Parameters.AddWithValue("@Afp_Id", Afp_Id);
                        cmd.Parameters.AddWithValue("@Afp_cod_afiliacion", Afp_cod_afiliacion);
                        cmd.Parameters.AddWithValue("@Seguro_cod", "");
                        cmd.Parameters.AddWithValue("@Ccosto_Id", Ccosto_Id);
                        cmd.Parameters.AddWithValue("@Dpto", Dpto);
                        cmd.Parameters.AddWithValue("@Prov", Prov);
                        cmd.Parameters.AddWithValue("@Dist", Dist);
                        cmd.Parameters.AddWithValue("@Direccion", Direccion.ToUpper().Trim());
                        cmd.Parameters.AddWithValue("@Telefono", Telefono.Trim());
                        cmd.Parameters.AddWithValue("@Telefono2", Telefono2.Trim());
                        cmd.Parameters.AddWithValue("@Telefono3", Telefono3.Trim());
                        cmd.Parameters.AddWithValue("@Nro_Hijos", NroHijos);
                        cmd.Parameters.AddWithValue("@Tip_cta_Id", TipoCuentaId);
                        cmd.Parameters.AddWithValue("@Nro_cta", Nro_cta.Trim());
                        cmd.Parameters.AddWithValue("@Moneda_cta_Id", Moneda_cta_Id);
                        cmd.Parameters.AddWithValue("@Banco_cta_Id", BancoCtaId);
                        cmd.Parameters.AddWithValue("@Nro_cta_cts", Nro_cta_cts);
                        cmd.Parameters.AddWithValue("@Tip_cta_cts_Id", TipoCuentaCtsId);
                        cmd.Parameters.AddWithValue("@Moneda_cta_cts_Id", Moneda_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@Banco_cta_cts_Id", BancoCtaCtsId);
                        cmd.Parameters.AddWithValue("@Proyecto_Id", Proyecto_Id);
                        cmd.Parameters.AddWithValue("@Tgasto_Id", "");
                        cmd.Parameters.AddWithValue("@Usuario", "");
                        cmd.Parameters.AddWithValue("@Pase", "");
                        cmd.Parameters.AddWithValue("@lAdministrador", 0);
                        cmd.Parameters.AddWithValue("@Estado_Id", Estado_Id);
                        cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
                        cmd.Parameters.AddWithValue("@Cod_Antiguo", "");
                        cmd.Parameters.AddWithValue("@email", CorreoCorp);
                        cmd.Parameters.AddWithValue("@Nacionalidad_Id", NacionalidadId);
                        cmd.Parameters.AddWithValue("@Domiciliado", true);
                        cmd.Parameters.AddWithValue("@Tipo_Via_Id", TipoViaId);
                        cmd.Parameters.AddWithValue("@Numero_Via", "");
                        cmd.Parameters.AddWithValue("@Interior_Via", "");
                        cmd.Parameters.AddWithValue("@Tipo_Zona_Id", TipoZonaId);
                        cmd.Parameters.AddWithValue("@Nombre_Zona", NombreZona);
                        cmd.Parameters.AddWithValue("@Referencia", "");
                        cmd.Parameters.AddWithValue("@Tipo_Trabajador_Id", Tipo_Trabajador_Id);
                        cmd.Parameters.AddWithValue("@Regimen_Laboral_Id", RegimenLaboralId);
                        cmd.Parameters.AddWithValue("@Nivel_Educativo_Id", Nivel_Educativo_Id);
                        cmd.Parameters.AddWithValue("@Discapacidad", false);
                        cmd.Parameters.AddWithValue("@SCTR_Salud_Id", SCTR_Salud_Id);
                        cmd.Parameters.AddWithValue("@SCTR_Pension_Id", SCTR_Pension_Id);
                        cmd.Parameters.AddWithValue("@Tipo_Contrato_Id", TipoContratoId);
                        cmd.Parameters.AddWithValue("@Jornada_Atipica", false);
                        cmd.Parameters.AddWithValue("@Jornada_Maxima", true);
                        cmd.Parameters.AddWithValue("@Horario_Nocturno", false);
                        cmd.Parameters.AddWithValue("@Sindicalizado", false);
                        cmd.Parameters.AddWithValue("@EPS_Id", EPS_Id);
                        cmd.Parameters.AddWithValue("@Ingresos_5ta_Inafectos", false);
                        cmd.Parameters.AddWithValue("@Situacion_Especial_Id", Situacion_Especial_Id);
                        cmd.Parameters.AddWithValue("@RUC", Ruc);
                        cmd.Parameters.AddWithValue("@Seguro_Medico_Id", Seguro_Medico_Id);
                        cmd.Parameters.AddWithValue("@Madre_Resp_Fam", false);
                        cmd.Parameters.AddWithValue("@Tipo_Centro_Form_Prof_Id", TipoCentroFormProfId);
                        cmd.Parameters.AddWithValue("@RUC_Destaque", "");
                        cmd.Parameters.AddWithValue("@Foto_NombreArchivo", "");
                        cmd.Parameters.AddWithValue("@Nro_Calzado", "");
                        cmd.Parameters.AddWithValue("@Talla_Ropa_Id", TallaRopaId);
                        cmd.Parameters.AddWithValue("@Grupo_Sanguineo_Id", GrupoSanguineoId);
                        cmd.Parameters.AddWithValue("@Estatura", 0);
                        cmd.Parameters.AddWithValue("@Peso", 0);
                        cmd.Parameters.AddWithValue("@Complexion_Fisica_Id", ComplexionFisicaId);
                        cmd.Parameters.AddWithValue("@Brevete_Nro", NroBrevete);
                        cmd.Parameters.AddWithValue("@Brevete_Categoria_Id", BreveteCategoriaId);
                        cmd.Parameters.AddWithValue("@Brevete_Vigencia", "1900/01/01");
                        cmd.Parameters.AddWithValue("@Alergias", Alergias);
                        cmd.Parameters.AddWithValue("@Codigo_Auxiliar", "");
                        cmd.Parameters.AddWithValue("@Seccion_Id", Categoria_Auxiliar_Id);
                        cmd.Parameters.AddWithValue("@Personal_Codigo_SAP", CodigoSap);
                        cmd.Parameters.AddWithValue("@Personal_Sap_Cobranza", CodigoSapDeudor);
                        cmd.Parameters.AddWithValue("@Email_Personal", CorreoPer);

                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertPersonalActivo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
                        cmd.Parameters.AddWithValue("@Fecha_ingreso", DateTime.Parse(Fecha_ingreso));
                        cmd.Parameters.AddWithValue("@Fecha_cese", DateTime.Parse("1900/01/01"));
                        cmd.Parameters.AddWithValue("@Fecha_ini_contrato",DateTime.Parse( Fecha_ini_contrato));
                        cmd.Parameters.AddWithValue("@Fecha_fin_contrato", DateTime.Parse(Fecha_fin_contrato));
                        cmd.Parameters.AddWithValue("@Categoria_Id", Categoria_Id);
                        cmd.Parameters.AddWithValue("@Cargo_Id", Cargo_Id);
                        cmd.Parameters.AddWithValue("@Situacion_Id", Situacion_Id);
                        cmd.Parameters.AddWithValue("@Afp_Id", Afp_Id);
                        cmd.Parameters.AddWithValue("@Ccosto_Id", Ccosto_Id);
                        cmd.Parameters.AddWithValue("@Dpto", Dpto);
                        cmd.Parameters.AddWithValue("@Prov", Prov);
                        cmd.Parameters.AddWithValue("@Dist", Dist);
                        cmd.Parameters.AddWithValue("@Direccion", Direccion);
                        cmd.Parameters.AddWithValue("@Nro_cta", Nro_cta);
                        cmd.Parameters.AddWithValue("@Moneda_cta_Id", Moneda_cta_Id);
                        cmd.Parameters.AddWithValue("@Banco_cta_Id", Banco_cta_Id);
                        cmd.Parameters.AddWithValue("@Nro_cta_cts", Nro_cta_cts);
                        cmd.Parameters.AddWithValue("@Moneda_cta_cts_Id", Moneda_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@Banco_cta_cts_Id", Banco_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@Proyecto_Id", Proyecto_Id);
                        cmd.Parameters.AddWithValue("@Pry_Operacion_Id", "");
                        cmd.Parameters.AddWithValue("@Pry_Categoria_Id", "");
                        cmd.Parameters.AddWithValue("@Flag_Distribuido", Flag_Distribuido);
                        cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                        cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
                        cmd.Parameters.AddWithValue("@Categoria2_Id", Categoria2_Id);
                        cmd.Parameters.AddWithValue("@Tipo_Trabajador_Id", Tipo_Trabajador_Id);
                        cmd.Parameters.AddWithValue("@Nivel_Educativo_Id", Nivel_Educativo_Id);
                        cmd.Parameters.AddWithValue("@Discapacidad", false);
                        cmd.Parameters.AddWithValue("@SCTR_Salud_Id", SCTR_Salud_Id);
                        cmd.Parameters.AddWithValue("@SCTR_Pension_Id", SCTR_Pension_Id);
                        cmd.Parameters.AddWithValue("@Tipo_Contrato_Id", Tipo_Contrato_Id);
                        cmd.Parameters.AddWithValue("@Jornada_Atipica", false);
                        cmd.Parameters.AddWithValue("@Jornada_Maxima", false);
                        cmd.Parameters.AddWithValue("@Horario_Nocturno", false);
                        cmd.Parameters.AddWithValue("@Sindicalizado", false);
                        cmd.Parameters.AddWithValue("@EPS_Id", EPS_Id);
                        cmd.Parameters.AddWithValue("@Ingresos_5ta_Inafectos", false);
                        cmd.Parameters.AddWithValue("@Situacion_Especial_Id", Situacion_Especial_Id);
                        cmd.Parameters.AddWithValue("@Seguro_Medico_Id", Seguro_Medico_Id);
                        cmd.Parameters.AddWithValue("@Madre_Resp_Fam", false);
                        cmd.Parameters.AddWithValue("@Tipo_Centro_Form_Prof_Id", "");
                        cmd.Parameters.AddWithValue("@RUC_Destaque", "");
                        cmd.Parameters.AddWithValue("@Motivo_Fin_Per_Lab_Id", MotivoFinPerLabId);
                        cmd.Parameters.AddWithValue("@Tipo_Mod_Formativa_Id", TipoModFormativaId);
                        cmd.Parameters.AddWithValue("@Nro_CITT", "");
                        cmd.Parameters.AddWithValue("@Cod_Contrato", "");
                        cmd.Parameters.AddWithValue("@Fecha_Impresion_Contrato", "1900/01/01");
                        cmd.Parameters.AddWithValue("@EPSPLAN_ID", "00");
                        cmd.Parameters.AddWithValue("@Cantidad_Titular", 0);
                        cmd.Parameters.AddWithValue("@Cantidad_Dependientes", 0);
                        cmd.Parameters.AddWithValue("@Cantidad_Hmayores", 0);
                        cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                        cmd.Parameters.AddWithValue("@Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
                        cmd.Parameters.AddWithValue("@Personal_Anexo_Id", "");
                        cmd.Parameters.AddWithValue("@Personal_Anexo2_Id", "");

                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertD_Fijos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Fecha_Modif", "1900/01/01");
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertD_Variables", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Fecha_Modif", "1900/01/01");
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_Insert_CalculosPerm", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_AsignarJefe", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Jefe_Id", JefeId);
                        cmd.Parameters.AddWithValue("@Gerente_Id", GerenteId);
                        cmd.Parameters.AddWithValue("@Coordinador_Id", CoodinadorId);
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }

                string comando = "Update D_Fijos Set Valor = " + Sueldo.ToString();
                comando += " where Concepto_Id='000001' and Personal_Id='" + Personal_Id + "'";
                comando += " and Periodo_Id='" + Periodo_Id + "'";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }

                comando = "Update D_Fijos Set Valor = " + Movilidad.ToString();
                comando += " where Concepto_Id='000850' and Personal_Id='" + Personal_Id + "'";
                comando += " and Periodo_Id='" + Periodo_Id + "'";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }

                comando = "Update D_Fijos Set Valor = " + ValeAlimento.ToString();
                comando += " where Concepto_Id='000851' and Personal_Id='" + Personal_Id + "'";
                comando += " and Periodo_Id='" + Periodo_Id + "'";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }

                //I - Agrega funciones
                comando = "delete from Personal_Funciones where Personal_Id = '" + Personal_Id + "';";
                comando += " insert into Personal_Funciones(Personal_Id, Cargo_Funcion_Id)";
                comando += " select '" + Personal_Id + "', valor from gn_fn_table_split('" + Cargo_Funcion_Ids + "', ',');";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        int irows = cmd.ExecuteNonQuery();
                    }
                }
                //F - Agrega funciones

                EnviarCorreoNuevoTrabajador(Personal_Id);
                EnviarCorreoContrato_NuevoRenovado(Personal_Id, Periodo_Id);
                resultado = "true#Datos del nuevo trabajador grabados correctamente";
            }
            catch (Exception ex)
            {
                resultado = "false#Error: " + ex.Message;
            }
            return resultado;
        }







        public string GuardarPersonalActualizar(string Planilla_Id, string Periodo_Id, string Personal_Id
            , string Compania_Id, string Fecha_ingreso, string Fecha_cese,
            string Fecha_ini_contrato, string Fecha_fin_contrato, string Categoria_Id
            , string Cargo_Id, string Situacion_Id, string Afp_Id, string Ccosto_Id
            , string Dpto, string Prov, string Dist, string Direccion, string Nro_cta,
            string Moneda_cta_Id, string Banco_cta_Id, string Nro_cta_cts, string Moneda_cta_cts_Id, string Banco_cta_cts_Id
            , string Proyecto_Id, string Pry_Operacion_Id, string Pry_Categoria_Id, string Flag_Distribuido
            , string Observaciones, string Area_Id, string Categoria2_Id,
            string Tipo_Trabajador_Id, string Nivel_Educativo_Id, bool Discapacidad, string SCTR_Salud_Id
            , string SCTR_Pension_Id, string Tipo_Contrato_Id,
            bool Jornada_Atipica, bool Jornada_Maxima, bool Horario_Nocturno, bool Sindicalizado, string EPS_Id
            , bool Ingresos_5ta_Inafectos,
            string Situacion_Especial_Id, string Seguro_Medico_Id, bool Madre_Resp_Fam, string Tipo_Centro_Form_Prof_Id
            , string RUC_Destaque, string Motivo_Fin_Per_Lab_Id,
            string Tipo_Mod_Formativa_Id, string Nro_CITT, string Cod_Contrato, string Fecha_Impresion_Contrato
            , string EPSPLAN_ID, int Cantidad_Titular,
            int Cantidad_Dependientes, int Cantidad_Hmayores, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id
            , string Personal_Anexo_Id, string Personal_Anexo2_Id, DateTime Fecha_Nacimiento, string ECivil, string Categoria2
            , string Apellido_Paterno,string Apellido_Materno,string Nombres,string Telefono,string Telefono2,string Telefono3
            ,string CorreoCorp,string CorreoPer,string NroDoc,string RegPensionario_Id,string CUSP,int NroHijos
            ,string Alergias,string CodigoSap,string CodigoSapDeudor)
        {
            string resultado = "false#";

            Compania_Id = "01";
            string Estado_Id = "01";
            string Sexo = "01";
            //ECivil = "01";
            string TipoDoc = "01";
            string TipoCuentaId = "1";
            string BreveteCategoriaId = "00";
            string NroBrevete = "";
            string TipoViaId = "00";
            string TipoZonaId = "00";
            string NombreZona = "";
            string DptoId = "15"; //Lima por defecto
            string ProvId = "01";// Lima por defecto
            string DistId = "01";// Lima por defecto

            string Categoria1 = "01";
            string SituacionId = "01";
            Ccosto_Id = "000000"; //txtCcostoSap.Text.Trim()   'Empresa


            string MonedaCtaId = "MN";
            string BancoCtaId = Banco_cta_Id;

            string TipoCuentaCtsId = "1 ";
            string MonedaCtaCtsId = "MN";
            string BancoCtaCtsId = Banco_cta_cts_Id;


            string ProyectoId = "0000000000";
            string NacionalidadId = "9589";


            string TipoTrabajadorId = "";
            if (Planilla_Id == "01")
            { //Empleado
                TipoTrabajadorId = "21";
            } //empleado
            else if (Planilla_Id == "04")
            {//Obrero
                TipoTrabajadorId = "20";
            } //obrero

            string RegimenLaboralId = "1";
            string NivelEducativoId = "05";// 'Primaria completa por defecto
            string SCTRSaludId = "0";
            string SCTRPendionId = "0";
            string TipoContratoId = Tipo_Contrato_Id;
            string EPSId = "0";
            string SituacionEspecialId = "0";
            string Ruc = "";
            string TipoCentroFormProfId = "0";
            string TallaRopaId = "00";
            string GrupoSanguineoId = "00";
            string ComplexionFisicaId = "00";

            string MotivoFinPerLabId = "00";
            string TipoModFormativaId = "00";

            string PersonalAnexoId = "00000000";
            string PersonalAnexo2Id = "00000000";


            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ActivaPersonalFichaContrato", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@Apellido_Paterno", Apellido_Paterno);
                    cmd.Parameters.AddWithValue("@Apellido_Materno", Apellido_Materno);
                    cmd.Parameters.AddWithValue("@Nombres", Nombres);
                    cmd.Parameters.AddWithValue("@Direccion", Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.Parameters.AddWithValue("@Telefono2", Telefono2);
                    cmd.Parameters.AddWithValue("@Telefono3", Telefono3);
                    cmd.Parameters.AddWithValue("@email", CorreoCorp);
                    cmd.Parameters.AddWithValue("@Fecha_Nacimiento", Fecha_Nacimiento);
                    cmd.Parameters.AddWithValue("@Nro_Doc", NroDoc);
                    cmd.Parameters.AddWithValue("@Banco_cta_Id", Banco_cta_Id);
                    cmd.Parameters.AddWithValue("@Nro_cta", Nro_cta);
                    cmd.Parameters.AddWithValue("@Banco_cta_cts_Id", Banco_cta_cts_Id);
                    cmd.Parameters.AddWithValue("@Nro_cta_cts", Nro_cta_cts);
                    cmd.Parameters.AddWithValue("@Afp_Id", RegPensionario_Id);
                    cmd.Parameters.AddWithValue("@Afp_cod_afiliacion", CUSP);
                    cmd.Parameters.AddWithValue("@E_Civil_Id", ECivil);
                    cmd.Parameters.AddWithValue("@Nro_Hijos", NroHijos);
                    cmd.Parameters.AddWithValue("@Alergias", Alergias);
                    cmd.Parameters.AddWithValue("@Area_Id", Area_Id);
                    cmd.Parameters.AddWithValue("@Cargo_Id", Cargo_Id);
                    cmd.Parameters.AddWithValue("@Seguro_Medico_Id", Seguro_Medico_Id);
                    cmd.Parameters.AddWithValue("@Categoria2_Id", Categoria2_Id);
                    cmd.Parameters.AddWithValue("@Estado_Id", Estado_Id);
                    cmd.Parameters.AddWithValue("@Ccosto_Id", Ccosto_Id);
                    cmd.Parameters.AddWithValue("@Personal_Codigo_Sap", CodigoSap);
                    cmd.Parameters.AddWithValue("@Personal_Sap_Cobranza", CodigoSapDeudor);
                    cmd.Parameters.AddWithValue("@Email_Personal", CorreoPer);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ActivaPersonalFichaContrato", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Planilla_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Compania_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Fecha_ingreso", Personal_Id);
                    cmd.Parameters.AddWithValue("@Fecha_cese", Personal_Id);
                    cmd.Parameters.AddWithValue("@Fecha_ini_contrato", Personal_Id);
                    cmd.Parameters.AddWithValue("@Fecha_fin_contrato", Personal_Id);
                    cmd.Parameters.AddWithValue("@Categoria_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Cargo_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Situacion_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Afp_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Ccosto_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Dpto", Personal_Id);
                    cmd.Parameters.AddWithValue("@Prov", Personal_Id);
                    cmd.Parameters.AddWithValue("@Dist", Personal_Id);
                    cmd.Parameters.AddWithValue("@Direccion", Personal_Id);
                    cmd.Parameters.AddWithValue("@Nro_cta", Personal_Id);
                    cmd.Parameters.AddWithValue("@Moneda_cta_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Banco_cta_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Nro_cta_cts", Personal_Id);
                    cmd.Parameters.AddWithValue("@Moneda_cta_cts_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Banco_cta_cts_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Proyecto_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Pry_Operacion_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Pry_Categoria_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Flag_Distribuido", Personal_Id);
                    cmd.Parameters.AddWithValue("@Observaciones", Personal_Id);
                    cmd.Parameters.AddWithValue("@Area_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Categoria2_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Tipo_Trabajador_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Nivel_Educativo_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Discapacidad", Personal_Id);
                    cmd.Parameters.AddWithValue("@SCTR_Salud_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@SCTR_Pension_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Tipo_Contrato_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@Jornada_Atipica", Personal_Id);
                    cmd.Parameters.AddWithValue("@Jornada_Maxima", Personal_Id);
                    cmd.Parameters.AddWithValue("@Horario_Nocturno", Personal_Id);
                    cmd.Parameters.AddWithValue("@Sindicalizado", Personal_Id);
                    cmd.Parameters.AddWithValue("@EPS_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cmd.Parameters.AddWithValue("", Personal_Id);
                    cn.Open();
                    int irows = cmd.ExecuteNonQuery();
                }
            }

            return resultado;
        }


        public string EnviarCorreoNuevoTrabajador(string PersonalId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("sps_correo_nuevo_trabajador", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id", PersonalId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string[] oPara = dr.GetValue(0).ToString().Split(';');
                        string[] oCopia= dr.GetValue(1).ToString().Split(';');
                        string[] oCopiaOculta = dr.GetValue(2).ToString().Split(';');
                        string oAsunto = dr.GetValue(3).ToString();
                        string oCuerpo = dr.GetValue(4).ToString();
                        string oAdjuntos = dr.GetValue(5).ToString();
                        Get_EnvioCorreo(oPara, oCopia, oCopiaOculta, oAsunto, oCuerpo);
                    }
                    
                }
            }
            return "";
        }
        public string EnviarCorreoContrato_NuevoRenovado(string PersonalId,string PeriodoId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("sps_correo_contrato_nuevo_renovado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id", PersonalId);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", PeriodoId);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string[] oPara = dr.GetValue(0).ToString().Split(';');
                        string[] oCopia = dr.GetValue(1).ToString().Split(';');
                        string[] oCopiaOculta = dr.GetValue(2).ToString().Split(';');
                        string oAsunto = dr.GetValue(3).ToString();
                        string oCuerpo = dr.GetValue(4).ToString();
                        string oAdjuntos = dr.GetValue(5).ToString();
                        Get_EnvioCorreo(oPara, oCopia, oCopiaOculta, oAsunto, oCuerpo);
                    }

                }
            }
            return "";
        }
        public string Get_EnvioCorreo(string[] Arr_Correos, string[] Arr_CorreosCopia, string[] Arr_CorreosCopiaOculta,string oAsunto
            ,string oCuerpo)
        {
            string rpt = "";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            foreach (string para in Arr_Correos)
            {
                if (para.Trim() != "") { msg.To.Add(para.Trim()); }
            }            
            foreach (string copia in Arr_CorreosCopia)
            {
                if (copia.Trim() != "") { msg.CC.Add(copia.Trim()); }
            }
            foreach (string copiaOculta in Arr_CorreosCopiaOculta)
            {
                if (copiaOculta.Trim() != "") { msg.Bcc.Add(copiaOculta.Trim()); }
            }

            CompaniaSMTP oCompaniaSMTP = ParametrosDA.getCompania_SMTP();
            msg.From = new System.Net.Mail.MailAddress(oCompaniaSMTP.MailAddress, oCompaniaSMTP.DisplayName, System.Text.Encoding.UTF8);
            msg.Subject = oAsunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = oCuerpo;

            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //Aquí es donde se hace lo especial
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(oCompaniaSMTP.Usuario, oCompaniaSMTP.Clave);
            client.Port = oCompaniaSMTP.Port;
            client.Host = oCompaniaSMTP.Host;
            client.EnableSsl = oCompaniaSMTP.SSL;

            try
            {
                client.Send(msg);
                rpt = "";
            }
            catch (Exception ex)
            {
                rpt = ex.Message;
            }
            return rpt;
        }

    }
}
