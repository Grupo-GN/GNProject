using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using CAPA_ENTIDAD.EntMs;
using CAPA_ENTIDAD;

/*
    @001 FPS 14/07/2022 - Ajustes bancos de pago de empresa
    @002 FPS 09/12/2022 - Se agrega clave y nivel acceso para tabla UsuarioPlanilla
*/

namespace CAPA_DATOS
{
    public class ControllerMaestroPersonal
    {
        private static ControllerMaestroPersonal Instance = null;
        public static ControllerMaestroPersonal GetInstance() {
            return Instance == null ? Instance = new ControllerMaestroPersonal() : Instance;
        }
        private static int FINALROWS = 12;
        //FILTRO BUSCAR POR
        public ArrayList ListaColumnPersonal() {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_ListaColumnPersonal",cn))
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
        //public List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        public List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio, out Int32 qt_registros)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Personal_x_Filtro_Columna", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_NomColumna", NomColumna);
                    cmd.Parameters.AddWithValue("@vi_Param", Param);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ListaPersonal> oLista = new List<ListaPersonal>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.ListaPersonal objPer = new CAPA_ENTIDAD.EntMs.ListaPersonal();
                        objPer.Personal_Id = dr.GetValue(0).ToString();
                        objPer.Apellido_Paterno = dr.GetValue(1).ToString();
                        objPer.Apellido_Materno = dr.GetValue(2).ToString();
                        objPer.Nombres = dr.GetValue(3).ToString();
                        objPer.Nro_Doc = dr.GetValue(4).ToString();
                        objPer.Telefono = dr.GetValue(5).ToString();
                        objPer.Telefono2 = dr.GetValue(6).ToString();
                        objPer.Nro_cta = dr.GetValue(7).ToString();
                        objPer.Nro_cta_cts = dr.GetValue(8).ToString();
                        objPer.Nombre_Zona = dr.GetValue(9).ToString();
                        objPer.Estado_Id = dr.GetValue(10).ToString();

                        objPer.TDocumento = dr.GetValue(11).ToString();
                        objPer.F_Ingreso = dr.GetValue(12).ToString();
                        objPer.F_Ini_Contrato = dr.GetValue(13).ToString();
                        objPer.F_Fin_Contrato = dr.GetValue(14).ToString();
                        objPer.Proyecto = dr.GetValue(15).ToString();
                        objPer.F_Cese = dr.GetValue(16).ToString();
                        if (objPer.F_Cese.IndexOf("1900") > -1) objPer.F_Cese = "";
                        oLista.Add(objPer);
                    }
                    qt_registros = oLista.Count();
                    return oLista.OrderBy(o => o.Apellido_Paterno).Skip(inicio).Take(FINALROWS).ToList();
                }
            }

        }
        public int Lista_Personal_x_Filtro_Columna_MaxRows(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Personal_x_Filtro_Columna", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cn.Open();
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_NomColumna", NomColumna);
                    cmd.Parameters.AddWithValue("@vi_Param", Param);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ListaPersonal> oLista = new List<ListaPersonal>();
                    while (dr.Read())
                    {
                        CAPA_ENTIDAD.EntMs.ListaPersonal objPer = new CAPA_ENTIDAD.EntMs.ListaPersonal();
                        objPer.Personal_Id = dr.GetValue(0).ToString();
                        objPer.Apellido_Paterno = dr.GetValue(1).ToString();
                        objPer.Apellido_Materno = dr.GetValue(2).ToString();
                        objPer.Nombres = dr.GetValue(3).ToString();
                        objPer.Nro_Doc = dr.GetValue(4).ToString();
                        objPer.Telefono = dr.GetValue(5).ToString();
                        objPer.Telefono2 = dr.GetValue(6).ToString();
                        objPer.Nro_cta = dr.GetValue(7).ToString();
                        objPer.Nro_cta_cts = dr.GetValue(8).ToString();
                        objPer.Nombre_Zona = dr.GetValue(9).ToString();
                        objPer.Estado_Id = dr.GetValue(10).ToString();
                        oLista.Add(objPer);
                    }
                    return oLista.ToList().Count();
                }
            }
        }
        //@001 I
        public List<Ent_Personal_Activo> getPersonalxPeriodo_Bandeja(Ent_Personal_Activo oPersonalActivo)
        {
            List<Ent_Personal_Activo> oLista = new List<Ent_Personal_Activo>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("pla_sps_personal_periodo_bandeja", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id", oPersonalActivo.Personal_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", oPersonalActivo.Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_Area_Id", oPersonalActivo.Area_Id);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", oPersonalActivo.Categoria_Auxiliar_Id);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", oPersonalActivo.Categoria_Auxiliar2_Id);
                    cmd.Parameters.AddWithValue("@vi_Proyecto_Id", oPersonalActivo.Proyecto_Id);

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Ent_Personal_Activo oEnt = null;
                    Int32 indice = 0;
                    while (dr.Read())
                    {
                        oEnt = new Ent_Personal_Activo();
                        indice = dr.GetOrdinal("Personal_Id");
                        oEnt.Personal_Id = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Periodo_Id");
                        oEnt.Periodo_Id = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Nombre_Completo");
                        oEnt.Nombre_Completo = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Localidad");
                        oEnt.Localidad = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Area");
                        oEnt.Area = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Seccion");
                        oEnt.Seccion = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Proyecto");
                        oEnt.Proyecto = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Banco_pago_cia");
                        oEnt.Banco_pago_cia = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Nro_cta");
                        oEnt.Nro_cta = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Nro_cta_interbancaria");
                        oEnt.Nro_cta_interbancaria = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Banco_pago_cia");
                        oEnt.Banco_pago_cia = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Banco_pago_cts_cia");
                        oEnt.Banco_pago_cts_cia = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        indice = dr.GetOrdinal("Banco_cta");
                        oEnt.Banco_cta = dr.GetValue(indice) == null ? string.Empty : dr.GetValue(indice).ToString();

                        oLista.Add(oEnt);
                    }
                }
            }
            return oLista;
        }
        public void setAsigBancoPago_Cia(String Periodo_Id, String Personal_Ids, String Banco_Pago_Cia_Id, Boolean fl_CTS, out Int32 retorno, out String msg_retorno)
        {
            try
            {
                retorno = 0; msg_retorno = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("pla_spi_asig_banco_pago_cia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Ids", Personal_Ids);
                        cmd.Parameters.AddWithValue("@vi_Banco_Pago_Cia_Id", Banco_Pago_Cia_Id);
                        cmd.Parameters.AddWithValue("@vi_fl_cts", fl_CTS);
                        cmd.Parameters.AddWithValue("@vo_retorno", retorno).Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@vo_msg_retorno", msg_retorno).Direction = ParameterDirection.Output;
                        cmd.Parameters["@vo_msg_retorno"].Size = 8000;

                        cn.Open();
                        Int32 rpta = Int32.Parse(cmd.ExecuteScalar().ToString());

                        retorno = Convert.ToInt32(cmd.Parameters["@vo_retorno"].Value);
                        msg_retorno = cmd.Parameters["@vo_msg_retorno"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = ex.Message;
            }
        }
        //@001 F
        public ArrayList Lista_Personal(string Personal_Id, string Periodo_Id) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_PersonalxPeriodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@vi_Area_Id", null);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", null);
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", null);
                    cmd.Parameters.AddWithValue("@vi_Apellidos_y_Nombres", null);                    
                    
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
        //INSERTAR NUEVO PERSONAL

        public List<string> Insert_Personal(
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
                //@001 I
                , string Banco_pago_cia_Id
                , string Banco_pago_cts_cia_Id
                //@001 F
            ) {
            List<string> rLit = new List<string>();
            try {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_Personal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                        cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Paterno", Apellido_Paterno);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Materno", Apellido_Materno);     
                        cmd.Parameters.AddWithValue("@vi_Nombres", Nombres);     
                        cmd.Parameters.AddWithValue("@vi_Sexo_Id", Sexo_Id);      
                        cmd.Parameters.AddWithValue("@vi_Fecha_Nacimiento", Fecha_Nacimiento);
                        cmd.Parameters.AddWithValue("@vi_E_Civil_Id", E_Civil_Id);      
                        cmd.Parameters.AddWithValue("@vi_Fecha_Ini_AporteAFP", Fecha_Ini_AporteAFP);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Doc_Id", Tipo_Doc_Id);      
                        cmd.Parameters.AddWithValue("@vi_Nro_Doc", Nro_Doc);      
                        cmd.Parameters.AddWithValue("@vi_Categoria_Id", Categoria_Id);      
                        cmd.Parameters.AddWithValue("@vi_Categoria2_Id", Categoria2_Id);
                        cmd.Parameters.AddWithValue("@vi_Cargo_Id", Cargo_Id);      
                        cmd.Parameters.AddWithValue("@vi_Situacion_Id", Situacion_Id);      
                        cmd.Parameters.AddWithValue("@vi_Afp_Id", Afp_Id);      
                        cmd.Parameters.AddWithValue("@vi_Afp_cod_afiliacion", Afp_cod_afiliacion);      
                        cmd.Parameters.AddWithValue("@vi_Seguro_cod", Seguro_cod);      
                        cmd.Parameters.AddWithValue("@vi_Ccosto_Id", Ccosto_Id);     
                        cmd.Parameters.AddWithValue("@vi_Dpto", Dpto);      
                        cmd.Parameters.AddWithValue("@vi_Prov", Prov);      
                        cmd.Parameters.AddWithValue("@vi_Dist", Dist);      
                        cmd.Parameters.AddWithValue("@vi_Direccion", Direccion);     
                        cmd.Parameters.AddWithValue("@vi_Telefono", Telefono);
                        cmd.Parameters.AddWithValue("@vi_Telefono2", Telefono2);
                        cmd.Parameters.AddWithValue("@vi_Telefono3", Telefono3);      
                        cmd.Parameters.AddWithValue("@vi_Nro_Hijos", Nro_Hijos);  
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_Id", Tip_cta_Id);      
                        cmd.Parameters.AddWithValue("@vi_Nro_cta", Nro_cta);
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_Id", Moneda_cta_Id);      
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_Id", Banco_cta_Id);      
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_cts", Nro_cta_cts);      
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_cts_Id", Tip_cta_cts_Id);      
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_cts_Id", Moneda_cta_cts_Id);      
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_cts_Id", Banco_cta_cts_Id);      
                        cmd.Parameters.AddWithValue("@vi_Proyecto_Id", Proyecto_Id);      
                        cmd.Parameters.AddWithValue("@vi_Tgasto_Id", Tgasto_Id);     
                        cmd.Parameters.AddWithValue("@vi_Usuario", Usuario);    
                        cmd.Parameters.AddWithValue("@vi_Pase", Pase);  
                        cmd.Parameters.AddWithValue("@vi_lAdministrador", LAdministrador); 
                        cmd.Parameters.AddWithValue("@vi_Estado_Id", Estado_Id);  
                        cmd.Parameters.AddWithValue("@vi_Area_Id", Area_Id);     
                        cmd.Parameters.AddWithValue("@vi_Cod_Antiguo", Cod_Antiguo);    
                        cmd.Parameters.AddWithValue("@vi_email", Email);     
                        cmd.Parameters.AddWithValue("@vi_Nacionalidad_Id", Nacionalidad_Id);      
                        cmd.Parameters.AddWithValue("@vi_Domiciliado", Domiciliado);      
                        cmd.Parameters.AddWithValue("@vi_Tipo_Via_Id", Tipo_Via_Id);      
                        cmd.Parameters.AddWithValue("@vi_Numero_Via", Numero_Via);      
                        cmd.Parameters.AddWithValue("@vi_Interior_Via", Interior_Via);      
                        cmd.Parameters.AddWithValue("@vi_Tipo_Zona_Id", Tipo_Zona_Id);      
                        cmd.Parameters.AddWithValue("@vi_Nombre_Zona", Nombre_Zona);      
                        cmd.Parameters.AddWithValue("@vi_Referencia", Referencia);     
                        cmd.Parameters.AddWithValue("@vi_Tipo_Trabajador_Id", Tipo_Trabajador_Id);      
                        cmd.Parameters.AddWithValue("@vi_Regimen_Laboral_Id", Regimen_Laboral_Id);      
                        cmd.Parameters.AddWithValue("@vi_Nivel_Educativo_Id", Nivel_Educativo_Id);      
                        cmd.Parameters.AddWithValue("@vi_Discapacidad", Discapacidad);      
                        cmd.Parameters.AddWithValue("@vi_SCTR_Salud_Id", SCTR_Salud_Id);      
                        cmd.Parameters.AddWithValue("@vi_SCTR_Pension_Id", SCTR_Pension_Id);   
                        cmd.Parameters.AddWithValue("@vi_Tipo_Contrato_Id", Tipo_Contrato_Id);      
                        cmd.Parameters.AddWithValue("@vi_Jornada_Atipica", Jornada_Atipica);    
                        cmd.Parameters.AddWithValue("@vi_Jornada_Maxima", Jornada_Maxima);      
                        cmd.Parameters.AddWithValue("@vi_Horario_Nocturno", Horario_Nocturno); 
                        cmd.Parameters.AddWithValue("@vi_Sindicalizado", Sindicalizado);       
                        cmd.Parameters.AddWithValue("@vi_EPS_Id", EPS_Id);      
                        cmd.Parameters.AddWithValue("@vi_Ingresos_5ta_Inafectos", Ingresos_5ta_Inafectos);       
                        cmd.Parameters.AddWithValue("@vi_Situacion_Especial_Id", Situacion_Especial_Id);      
                        cmd.Parameters.AddWithValue("@vi_RUC", RUC);      
                        cmd.Parameters.AddWithValue("@vi_Seguro_Medico_Id", Seguro_Medico_Id);       
                        cmd.Parameters.AddWithValue("@vi_Madre_Resp_Fam", Madre_Resp_Fam);       
                        cmd.Parameters.AddWithValue("@vi_Tipo_Centro_Form_Prof_Id", Tipo_Centro_Form_Prof_Id);    
                        cmd.Parameters.AddWithValue("@vi_RUC_Destaque", RUC_Destaque);      
                        cmd.Parameters.AddWithValue("@vi_Foto_NombreArchivo", Foto_NombreArchivo);    
                        cmd.Parameters.AddWithValue("@vi_Nro_Calzado", Nro_Calzado);     
                        cmd.Parameters.AddWithValue("@vi_Talla_Ropa_Id", Talla_Ropa_Id);      
                        cmd.Parameters.AddWithValue("@vi_Grupo_Sanguineo_Id", Grupo_Sanguineo_Id);      
                        cmd.Parameters.AddWithValue("@vi_Estatura", Estatura);     
                        cmd.Parameters.AddWithValue("@vi_Peso", Peso);    
                        cmd.Parameters.AddWithValue("@vi_Complexion_Fisica_Id", Complexion_Fisica_Id);      
                        cmd.Parameters.AddWithValue("@vi_Brevete_Nro", Brevete_Nro);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Categoria_Id", Brevete_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Vigencia", Brevete_Vigencia);   
                        cmd.Parameters.AddWithValue("@vi_Alergias", Alergias);      
                        cmd.Parameters.AddWithValue("@vi_Codigo_Auxiliar", Codigo_Auxiliar);      
                        cmd.Parameters.AddWithValue("@vi_Seccion_Id", Seccion_Id);
                        cmd.Parameters.AddWithValue("@vi_Co_Trabajador_Id", Co_Trabajador_Id);
                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ingreso", Fecha_ingreso);
                        cmd.Parameters.AddWithValue("@vi_Fecha_cese", Fecha_cese);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ini_contrato", Fecha_ini_contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_fin_contrato", Fecha_fin_contrato);
                        cmd.Parameters.AddWithValue("@vi_Pry_Operacion_Id", Pry_Operacion_Id);
                        cmd.Parameters.AddWithValue("@vi_Pry_Categoria_Id", Pry_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Flag_Distribuido", Flag_Distribuido);
                        cmd.Parameters.AddWithValue("@vi_Observaciones", Observaciones);
                        cmd.Parameters.AddWithValue("@vi_Motivo_Fin_Per_Lab_Id", Motivo_Fin_Per_Lab_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Mod_Formativa_Id", Tipo_Mod_Formativa_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_CITT", Nro_CITT);
                        cmd.Parameters.AddWithValue("@vi_Cod_Contrato", Cod_Contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Impresion_Contrato", Fecha_Impresion_Contrato);
                        cmd.Parameters.AddWithValue("@vi_EPSPLAN_ID", EPSPLAN_ID);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Titular", Cantidad_Titular);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Dependientes", Cantidad_Dependientes);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Hmayores", Cantidad_Hmayores);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo_Id", Personal_Anexo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo2_Id", Personal_Anexo2_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_interbancaria", Nro_cta_interbancaria);
                        cmd.Parameters.AddWithValue("@vi_co_rol", co_rol);
                        cmd.Parameters.AddWithValue("@email_personal", emailp);
                        //@001 I
                        cmd.Parameters.AddWithValue("@vi_Banco_pago_cia_Id", Banco_pago_cia_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_pago_cts_cia_Id", Banco_pago_cts_cia_Id);
                        //@001 F
                        cmd.CommandTimeout = 600000;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        rLit.Clear();

                        while (dr.Read())
                        {
                            rLit.Add("true");
                            rLit.Add(dr.GetValue(0).ToString());
                            rLit.Add(dr.GetValue(1).ToString());
                            //20190622
                            rLit.Add(Nro_Doc);
                        }
                        return rLit;
                    }
                }
            }
            catch (Exception ex)
            {
                rLit.Clear();
                rLit.Add("false");
                rLit.Add("-1");
                rLit.Add(ex.Message);
            }
            return rLit;

        }


        public List<string> Update_Personal(
                    string Personal_Id
                    ,string Compania_Id
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
                    //@001 I
                    , string Banco_pago_cia_Id
                    , string Banco_pago_cts_cia_Id
                    //@001 F
            )
        {
            List<string> rLit = new List<string>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spu_Personal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vi_Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                        cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Paterno", Apellido_Paterno);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Materno", Apellido_Materno);
                        cmd.Parameters.AddWithValue("@vi_Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@vi_Sexo_Id", Sexo_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Nacimiento", Fecha_Nacimiento);
                        cmd.Parameters.AddWithValue("@vi_E_Civil_Id", E_Civil_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Ini_AporteAFP", Fecha_Ini_AporteAFP);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Doc_Id", Tipo_Doc_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_Doc", Nro_Doc);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Id", Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Categoria2_Id", Categoria2_Id);
                        cmd.Parameters.AddWithValue("@vi_Cargo_Id", Cargo_Id);
                        cmd.Parameters.AddWithValue("@vi_Situacion_Id", Situacion_Id);
                        cmd.Parameters.AddWithValue("@vi_Afp_Id", Afp_Id);
                        cmd.Parameters.AddWithValue("@vi_Afp_cod_afiliacion", Afp_cod_afiliacion);
                        cmd.Parameters.AddWithValue("@vi_Seguro_cod", Seguro_cod);
                        cmd.Parameters.AddWithValue("@vi_Ccosto_Id", Ccosto_Id);
                        cmd.Parameters.AddWithValue("@vi_Dpto", Dpto);
                        cmd.Parameters.AddWithValue("@vi_Prov", Prov);
                        cmd.Parameters.AddWithValue("@vi_Dist", Dist);
                        cmd.Parameters.AddWithValue("@vi_Direccion", Direccion);
                        cmd.Parameters.AddWithValue("@vi_Telefono", Telefono);
                        cmd.Parameters.AddWithValue("@vi_Telefono2", Telefono2);
                        cmd.Parameters.AddWithValue("@vi_Telefono3", Telefono3);
                        cmd.Parameters.AddWithValue("@vi_Nro_Hijos", Nro_Hijos);
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_Id", Tip_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta", Nro_cta);
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_Id", Moneda_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_Id", Banco_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_cts", Nro_cta_cts);
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_cts_Id", Tip_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_cts_Id", Moneda_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_cts_Id", Banco_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Proyecto_Id", Proyecto_Id);
                        cmd.Parameters.AddWithValue("@vi_Tgasto_Id", Tgasto_Id);
                        cmd.Parameters.AddWithValue("@vi_Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@vi_Pase", Pase);
                        cmd.Parameters.AddWithValue("@vi_lAdministrador", LAdministrador);
                        cmd.Parameters.AddWithValue("@vi_Estado_Id", Estado_Id);
                        cmd.Parameters.AddWithValue("@vi_Area_Id", Area_Id);
                        cmd.Parameters.AddWithValue("@vi_Cod_Antiguo", Cod_Antiguo);
                        cmd.Parameters.AddWithValue("@vi_email", Email);
                        cmd.Parameters.AddWithValue("@vi_Nacionalidad_Id", Nacionalidad_Id);
                        cmd.Parameters.AddWithValue("@vi_Domiciliado", Domiciliado);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Via_Id", Tipo_Via_Id);
                        cmd.Parameters.AddWithValue("@vi_Numero_Via", Numero_Via);
                        cmd.Parameters.AddWithValue("@vi_Interior_Via", Interior_Via);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Zona_Id", Tipo_Zona_Id);
                        cmd.Parameters.AddWithValue("@vi_Nombre_Zona", Nombre_Zona);
                        cmd.Parameters.AddWithValue("@vi_Referencia", Referencia);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Trabajador_Id", Tipo_Trabajador_Id);
                        cmd.Parameters.AddWithValue("@vi_Regimen_Laboral_Id", Regimen_Laboral_Id);
                        cmd.Parameters.AddWithValue("@vi_Nivel_Educativo_Id", Nivel_Educativo_Id);
                        cmd.Parameters.AddWithValue("@vi_Discapacidad", Discapacidad);
                        cmd.Parameters.AddWithValue("@vi_SCTR_Salud_Id", SCTR_Salud_Id);
                        cmd.Parameters.AddWithValue("@vi_SCTR_Pension_Id", SCTR_Pension_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Contrato_Id", Tipo_Contrato_Id);
                        cmd.Parameters.AddWithValue("@vi_Jornada_Atipica", Jornada_Atipica);
                        cmd.Parameters.AddWithValue("@vi_Jornada_Maxima", Jornada_Maxima);
                        cmd.Parameters.AddWithValue("@vi_Horario_Nocturno", Horario_Nocturno);
                        cmd.Parameters.AddWithValue("@vi_Sindicalizado", Sindicalizado);
                        cmd.Parameters.AddWithValue("@vi_EPS_Id", EPS_Id);
                        cmd.Parameters.AddWithValue("@vi_Ingresos_5ta_Inafectos", Ingresos_5ta_Inafectos);
                        cmd.Parameters.AddWithValue("@vi_Situacion_Especial_Id", Situacion_Especial_Id);
                        cmd.Parameters.AddWithValue("@vi_RUC", RUC);
                        cmd.Parameters.AddWithValue("@vi_Seguro_Medico_Id", Seguro_Medico_Id);
                        cmd.Parameters.AddWithValue("@vi_Madre_Resp_Fam", Madre_Resp_Fam);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Centro_Form_Prof_Id", Tipo_Centro_Form_Prof_Id);
                        cmd.Parameters.AddWithValue("@vi_RUC_Destaque", RUC_Destaque);
                        //, @vi_Foto image(16)    
                        cmd.Parameters.AddWithValue("@vi_Foto_NombreArchivo", Foto_NombreArchivo);
                        cmd.Parameters.AddWithValue("@vi_Nro_Calzado", Nro_Calzado);
                        cmd.Parameters.AddWithValue("@vi_Talla_Ropa_Id", Talla_Ropa_Id);
                        cmd.Parameters.AddWithValue("@vi_Grupo_Sanguineo_Id", Grupo_Sanguineo_Id);
                        cmd.Parameters.AddWithValue("@vi_Estatura", Estatura);
                        cmd.Parameters.AddWithValue("@vi_Peso", Peso);
                        cmd.Parameters.AddWithValue("@vi_Complexion_Fisica_Id", Complexion_Fisica_Id);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Nro", Brevete_Nro);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Categoria_Id", Brevete_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Vigencia", Brevete_Vigencia);
                        cmd.Parameters.AddWithValue("@vi_Alergias", Alergias);
                        cmd.Parameters.AddWithValue("@vi_Codigo_Auxiliar", Codigo_Auxiliar);
                        cmd.Parameters.AddWithValue("@vi_Seccion_Id", Seccion_Id);
                        cmd.Parameters.AddWithValue("@vi_Co_Trabajador_Id", Co_Trabajador_Id);

                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ingreso", Fecha_ingreso);
                        cmd.Parameters.AddWithValue("@vi_Fecha_cese", Fecha_cese);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ini_contrato", Fecha_ini_contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_fin_contrato", Fecha_fin_contrato);
                        cmd.Parameters.AddWithValue("@vi_Pry_Operacion_Id", Pry_Operacion_Id);
                        cmd.Parameters.AddWithValue("@vi_Pry_Categoria_Id", Pry_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Flag_Distribuido", Flag_Distribuido);
                        cmd.Parameters.AddWithValue("@vi_Observaciones", Observaciones);
                        cmd.Parameters.AddWithValue("@vi_Motivo_Fin_Per_Lab_Id", Motivo_Fin_Per_Lab_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Mod_Formativa_Id", Tipo_Mod_Formativa_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_CITT", Nro_CITT);
                        cmd.Parameters.AddWithValue("@vi_Cod_Contrato", Cod_Contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Impresion_Contrato", Fecha_Impresion_Contrato);
                        cmd.Parameters.AddWithValue("@vi_EPSPLAN_ID", EPSPLAN_ID);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Titular", Cantidad_Titular);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Dependientes", Cantidad_Dependientes);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Hmayores", Cantidad_Hmayores);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo_Id", Personal_Anexo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo2_Id", Personal_Anexo2_Id);
                        cmd.Parameters.AddWithValue("@usuario", UsuarioSess);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_interbancaria", Nro_cta_interbancaria);
                        cmd.Parameters.AddWithValue("@vi_co_rol", co_rol);
                        cmd.Parameters.AddWithValue("@vi_emailp", emailp);
                        //@001 I
                        cmd.Parameters.AddWithValue("@vi_Banco_pago_cia_Id", Banco_pago_cia_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_pago_cts_cia_Id", Banco_pago_cts_cia_Id);
                        //@001 F
                        cmd.CommandTimeout = 600000;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        rLit.Clear();
                     
                        while (dr.Read())
                        {
                            rLit.Add("true");
                            rLit.Add(dr.GetValue(0).ToString());
                            rLit.Add(dr.GetValue(1).ToString());
                            //20190622
                            rLit.Add(Nro_Doc);
                            
                        }
                        return rLit;
                    }
                }
            }
            catch (Exception ex)
            {
                rLit.Clear();
                rLit.Add("false");
                rLit.Add("-1");
                rLit.Add(ex.Message);
            }
            return rLit;

        }

        public List<string> Delete_Personal(string Personal_Id)
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_spd_Personal", cn))
                {
                    List<string> rLit = new List<string>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Personal_Id", Personal_Id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    rLit.Clear();

                    while (dr.Read())
                    {
                        rLit.Add("true");
                        rLit.Add(dr.GetValue(0).ToString());
                        rLit.Add(dr.GetValue(1).ToString());

                    }
                    return rLit;
                }
            }
        }

        //@002 I
        public void InsertUpdate_UsuarioPlanilla(string Personal_Id, String UsuarioName, String Password, String NivelAcceso, String EmailCorporativo, String EmailPersonal)
        {

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateInsertUsuPlanilla", cn))
                {
                    List<string> rLit = new List<string>();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cmd.Parameters.AddWithValue("@UsuarioName", UsuarioName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@NivelAcceso", NivelAcceso);
                    cmd.Parameters.AddWithValue("@EmailCorporativo", EmailCorporativo);
                    cmd.Parameters.AddWithValue("@EmailPersonal", EmailPersonal);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        //@002 F

        #region CARGAR COMBOS

        //---- 2. Datos Principales
        //-- Para Cargar los Datos  de los Combos
        public ArrayList ListaTipoDoc() {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoDoc", cn))
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
        public ArrayList ListaNacionalidad()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaNacionalidad", cn))
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
        public ArrayList ListaTipoSexo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoSexo", cn))
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
        public ArrayList ListaTipoVia()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoVia", cn))
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
        public ArrayList ListaTipoZona()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoZona", cn))
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
        public ArrayList ListaDepartamento()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaDepartamento", cn))
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
        public ArrayList ListaProvincia(string Departamento_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaProvincia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Departamento_Id", Departamento_Id);
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
        public ArrayList ListaDistrito(string Departamento_Id, string Provincia_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaDistrito", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Departamento_Id", Departamento_Id);
                    cmd.Parameters.AddWithValue("@Provincia_Id", Provincia_Id);
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

        // 3. Datos Secundarios
        public ArrayList ListaCompania()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCompania", cn))
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
        public ArrayList ListaTipoPlanilla(string Compania_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaPlanilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Compania_Id", Compania_Id);
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
        public ArrayList ListaCCosto()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCCosto", cn))
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
        public ArrayList ListaCategoria()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCategoria", cn))
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
        public ArrayList ListaCategoria2()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCategoria2", cn))
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
        public ArrayList ListaProyecto()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaProyecto", cn))
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
        public ArrayList ListaSituacion()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSituacion", cn))
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
        public ArrayList ListaCatAuxiliar()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCatAuxiliar", cn))
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
        public ArrayList ListaCatAuxiliar2(string Categoria_Auxiliar_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCatAuxiliar2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
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
        public ArrayList ListaAnexo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaAnexo", cn))
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
        public ArrayList ListaAnexo2()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaAnexo2", cn))
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
        public ArrayList ListaEstados()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaEstado", cn))
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
        public ArrayList ListaMotivoCese()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaMotivoCese", cn))
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
        public ArrayList ListaTipoCuenta()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoCuenta", cn))
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
        public ArrayList ListaBancos()
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
        public ArrayList ListaMonedaCta()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaMonedaCta", cn))
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

        //-----------
        //--- 4. TRAB / PENSIONARIO
        public ArrayList ListaTipoTrabajador()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoTrabajador", cn))
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
        public ArrayList ListaRegLaboral()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaRegLaboral", cn))
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
        public ArrayList ListaNivelEducativo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaNivelEducativo", cn))
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
        public ArrayList ListaRegimenPensionario()
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
        //@002 I
        public ArrayList ListaNivelAcceso()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("ListarNivelAcceso", cn))
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
        //@002 F
        public ArrayList ListaSCTRSalud()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSCTRSalud", cn))
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
        public ArrayList ListaSCTRPension()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSCTRPension", cn))
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
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoContrato", cn))
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
        public ArrayList ListaEPS()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaEPS", cn))
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
        public ArrayList ListaSituacionEspecial()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSituacionEspecial", cn))
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

        //---- 4ta / M.F. / Ter.
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
        public ArrayList ListaCentroFormacionProf()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCentroFormacionProf", cn))
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
        public ArrayList ListaModFormativa()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaModFormativa", cn))
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

        //---- Otros Datos
        public ArrayList ListaComplexionFisica()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaComplexionFisica", cn))
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
        public ArrayList ListaGrupoSanguineo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaGrupoSanguineo", cn))
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
        public ArrayList ListaTallaRopa()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTallaRopa", cn))
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
        public ArrayList ListaBreveteCategoria()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaBreveteCategoria", cn))
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
        #endregion
        //20180711
        public string GetPersonalIdxNroDoc(string xNroDoc)
        {
            string codigo = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PERSONAL_ID FROM PERSONAL WHERE NRO_DOC=@NRO_DOC", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NRO_DOC",xNroDoc);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        codigo = dr.GetValue(0).ToString();
                    }
                }
            }
            return codigo;
        }


        //IMPORTACION PERSONAL REGISTRO Y ACTUALIZACION
        public List<string> Insert_Personal_Import(

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
    )
        {
            List<string> rLit = new List<string>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("fps_spi_Personal_ImportPersonal", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                        cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Paterno", Apellido_Paterno);
                        cmd.Parameters.AddWithValue("@vi_Apellido_Materno", Apellido_Materno);
                        cmd.Parameters.AddWithValue("@vi_Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@vi_Sexo_Id", Sexo_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Nacimiento", Fecha_Nacimiento);
                        cmd.Parameters.AddWithValue("@vi_E_Civil_Id", E_Civil_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Ini_AporteAFP", Fecha_Ini_AporteAFP);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Doc_Id", Tipo_Doc_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_Doc", Nro_Doc);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Id", Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Categoria2_Id", Categoria2_Id);
                        cmd.Parameters.AddWithValue("@vi_Cargo_Id", Cargo_Id);
                        cmd.Parameters.AddWithValue("@vi_Situacion_Id", Situacion_Id);
                        cmd.Parameters.AddWithValue("@vi_Afp_Id", Afp_Id);
                        cmd.Parameters.AddWithValue("@vi_Afp_cod_afiliacion", Afp_cod_afiliacion);
                        cmd.Parameters.AddWithValue("@vi_Seguro_cod", Seguro_cod);
                        cmd.Parameters.AddWithValue("@vi_Ccosto_Id", Ccosto_Id);
                        cmd.Parameters.AddWithValue("@vi_Dpto", Dpto);
                        cmd.Parameters.AddWithValue("@vi_Prov", Prov);
                        cmd.Parameters.AddWithValue("@vi_Dist", Dist);
                        cmd.Parameters.AddWithValue("@vi_Direccion", Direccion);
                        cmd.Parameters.AddWithValue("@vi_Telefono", Telefono);
                        cmd.Parameters.AddWithValue("@vi_Telefono2", Telefono2);
                        cmd.Parameters.AddWithValue("@vi_Telefono3", Telefono3);
                        cmd.Parameters.AddWithValue("@vi_Nro_Hijos", Nro_Hijos);
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_Id", Tip_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta", Nro_cta);
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_Id", Moneda_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_Id", Banco_cta_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_cts", Nro_cta_cts);
                        cmd.Parameters.AddWithValue("@vi_Tip_cta_cts_Id", Tip_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Moneda_cta_cts_Id", Moneda_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Banco_cta_cts_Id", Banco_cta_cts_Id);
                        cmd.Parameters.AddWithValue("@vi_Proyecto_Id", Proyecto_Id);
                        cmd.Parameters.AddWithValue("@vi_Tgasto_Id", Tgasto_Id);
                        cmd.Parameters.AddWithValue("@vi_Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@vi_Pase", Pase);
                        cmd.Parameters.AddWithValue("@vi_lAdministrador", LAdministrador);
                        cmd.Parameters.AddWithValue("@vi_Estado_Id", Estado_Id);
                        cmd.Parameters.AddWithValue("@vi_Area_Id", Area_Id);
                        cmd.Parameters.AddWithValue("@vi_Cod_Antiguo", Cod_Antiguo);
                        cmd.Parameters.AddWithValue("@vi_email", Email);
                        cmd.Parameters.AddWithValue("@vi_Nacionalidad_Id", Nacionalidad_Id);
                        cmd.Parameters.AddWithValue("@vi_Domiciliado", Domiciliado);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Via_Id", Tipo_Via_Id);
                        cmd.Parameters.AddWithValue("@vi_Numero_Via", Numero_Via);
                        cmd.Parameters.AddWithValue("@vi_Interior_Via", Interior_Via);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Zona_Id", Tipo_Zona_Id);
                        cmd.Parameters.AddWithValue("@vi_Nombre_Zona", Nombre_Zona);
                        cmd.Parameters.AddWithValue("@vi_Referencia", Referencia);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Trabajador_Id", Tipo_Trabajador_Id);
                        cmd.Parameters.AddWithValue("@vi_Regimen_Laboral_Id", Regimen_Laboral_Id);
                        cmd.Parameters.AddWithValue("@vi_Nivel_Educativo_Id", Nivel_Educativo_Id);
                        cmd.Parameters.AddWithValue("@vi_Discapacidad", Discapacidad);
                        cmd.Parameters.AddWithValue("@vi_SCTR_Salud_Id", SCTR_Salud_Id);
                        cmd.Parameters.AddWithValue("@vi_SCTR_Pension_Id", SCTR_Pension_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Contrato_Id", Tipo_Contrato_Id);
                        cmd.Parameters.AddWithValue("@vi_Jornada_Atipica", Jornada_Atipica);
                        cmd.Parameters.AddWithValue("@vi_Jornada_Maxima", Jornada_Maxima);
                        cmd.Parameters.AddWithValue("@vi_Horario_Nocturno", Horario_Nocturno);
                        cmd.Parameters.AddWithValue("@vi_Sindicalizado", Sindicalizado);
                        cmd.Parameters.AddWithValue("@vi_EPS_Id", EPS_Id);
                        cmd.Parameters.AddWithValue("@vi_Ingresos_5ta_Inafectos", Ingresos_5ta_Inafectos);
                        cmd.Parameters.AddWithValue("@vi_Situacion_Especial_Id", Situacion_Especial_Id);
                        cmd.Parameters.AddWithValue("@vi_RUC", RUC);
                        cmd.Parameters.AddWithValue("@vi_Seguro_Medico_Id", Seguro_Medico_Id);
                        cmd.Parameters.AddWithValue("@vi_Madre_Resp_Fam", Madre_Resp_Fam);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Centro_Form_Prof_Id", Tipo_Centro_Form_Prof_Id);
                        cmd.Parameters.AddWithValue("@vi_RUC_Destaque", RUC_Destaque);
                        cmd.Parameters.AddWithValue("@vi_Foto_NombreArchivo", Foto_NombreArchivo);
                        cmd.Parameters.AddWithValue("@vi_Nro_Calzado", Nro_Calzado);
                        cmd.Parameters.AddWithValue("@vi_Talla_Ropa_Id", Talla_Ropa_Id);
                        cmd.Parameters.AddWithValue("@vi_Grupo_Sanguineo_Id", Grupo_Sanguineo_Id);
                        cmd.Parameters.AddWithValue("@vi_Estatura", Estatura);
                        cmd.Parameters.AddWithValue("@vi_Peso", Peso);
                        cmd.Parameters.AddWithValue("@vi_Complexion_Fisica_Id", Complexion_Fisica_Id);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Nro", Brevete_Nro);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Categoria_Id", Brevete_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Brevete_Vigencia", Brevete_Vigencia);
                        cmd.Parameters.AddWithValue("@vi_Alergias", Alergias);
                        cmd.Parameters.AddWithValue("@vi_Codigo_Auxiliar", Codigo_Auxiliar);
                        cmd.Parameters.AddWithValue("@vi_Seccion_Id", Seccion_Id);
                        cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ingreso", Fecha_ingreso);
                        cmd.Parameters.AddWithValue("@vi_Fecha_cese", Fecha_cese);
                        cmd.Parameters.AddWithValue("@vi_Fecha_ini_contrato", Fecha_ini_contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_fin_contrato", Fecha_fin_contrato);
                        cmd.Parameters.AddWithValue("@vi_Pry_Operacion_Id", Pry_Operacion_Id);
                        cmd.Parameters.AddWithValue("@vi_Pry_Categoria_Id", Pry_Categoria_Id);
                        cmd.Parameters.AddWithValue("@vi_Flag_Distribuido", Flag_Distribuido);
                        cmd.Parameters.AddWithValue("@vi_Observaciones", Observaciones);
                        cmd.Parameters.AddWithValue("@vi_Motivo_Fin_Per_Lab_Id", Motivo_Fin_Per_Lab_Id);
                        cmd.Parameters.AddWithValue("@vi_Tipo_Mod_Formativa_Id", Tipo_Mod_Formativa_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_CITT", Nro_CITT);
                        cmd.Parameters.AddWithValue("@vi_Cod_Contrato", Cod_Contrato);
                        cmd.Parameters.AddWithValue("@vi_Fecha_Impresion_Contrato", Fecha_Impresion_Contrato);
                        cmd.Parameters.AddWithValue("@vi_EPSPLAN_ID", EPSPLAN_ID);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Titular", Cantidad_Titular);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Dependientes", Cantidad_Dependientes);
                        cmd.Parameters.AddWithValue("@vi_Cantidad_Hmayores", Cantidad_Hmayores);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", Categoria_Auxiliar_Id);
                        cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", Categoria_Auxiliar2_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo_Id", Personal_Anexo_Id);
                        cmd.Parameters.AddWithValue("@vi_Personal_Anexo2_Id", Personal_Anexo2_Id);
                        cmd.Parameters.AddWithValue("@vi_Nro_cta_interbancaria", Nro_cta_interbancaria);
                        cmd.Parameters.AddWithValue("@vi_co_rol", co_rol);
                        cmd.Parameters.AddWithValue("@email_personal", emailp);
                        cmd.CommandTimeout = 600000;
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        rLit.Clear();

                        while (dr.Read())
                        {
                            rLit.Add("true");
                            rLit.Add(dr.GetValue(0).ToString());
                            rLit.Add(dr.GetValue(1).ToString());
                            //20190622
                            rLit.Add(Nro_Doc);
                        }
                        return rLit;
                    }
                }
            }
            catch (Exception ex)
            {
                rLit.Clear();
                rLit.Add("false");
                rLit.Add("-1");
                rLit.Add(ex.Message);
            }
            return rLit;

        }

    }
}
