using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;
using CAPA_ENTIDAD.EntMs;

namespace CAPA_DATOS
{
    public static class Dao_Personal
    {
        /*FPS*/
        /************************INICIO PAGINA IMPRIMIR REPORTES****************************/
        public static DataTable Lista_Personal_ImprimirReporte(Ent_Personal_Activo objE)
        {
            //return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Personal_ImprimirReporte", objE.Periodo_Id);
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Personal_ImprimirReporte", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", objE.Periodo_Id);
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        DataTable tabla = new DataTable();
                        tabla.Clear();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
        }
        /***************************PAGINA IMPRIMIR REPORTES FIN****************************/

        /*Lista Personal que no está en el Periodo*/
        public static DataTable Lista_Personal_Faltante_Periodo(Ent_Personal_Activo objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "Movimiento_Periodo", 1, objE.Periodo_Id, DBNull.Value);
        }
        /*Agrega un Personal a un Periodo*/
        public static int Agrega_Personal_al_Periodo(Ent_Personal_Activo objE)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "Movimiento_Periodo", 2, objE.Periodo_Id, objE.Personal_Id);
        }
        /*Elimina un Personal de un Periodo*/
        public static int Elimina_Personal_de_Periodo(Ent_Personal_Activo objE)
        {
            return SqlHelper.ExecuteNonQuery(Conex.CadCon(), "Movimiento_Periodo", 3, objE.Periodo_Id, objE.Personal_Id);
        }

        /*Listado de Personal en las Boletas*/
        public static DataTable Lista_Personal_Boleta(Ent_Personal_Activo objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_Personal_Boleta", objE.Periodo_Id, objE.Area_Id, objE.Nombre_Completo, objE.Proyecto_Id, objE.Direccion);
        }

        public static DataTable ListaColumnPersonal()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_ListaColumnPersonal");
        }
        public static DataTable GenPersonal_Id()
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_GeneraPersonal_Id");
        }
        public static DataTable ListaDataxPersonalId(Ent_Personal objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_PersonalxId", objE._Personal_Id);
        }
        //////public static DataSet ListaDataPersonalxPeriodo(Ent_Personal objE)
        //////{
        //////    return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_sps_PersonalxPeriodo", objE._Personal_Id, objE._Periodo_Id, DBNull.Value, DBNull.Value, DBNull.Value);
        //////}

        public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        {    
            using(SqlConnection cn= new SqlConnection(Conex.CadCon_String())){
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
                    while (dr.Read()) {
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
                    return oLista;
                }
            }
            //return SqlHelper.ExecuteDataTable(Conex.CadCon(),
            //    "fps_sps_Personal_x_Filtro_Columna", Compania_Id, Periodo_Id, NomColumna, Param);
        }

        public static DataTable Lista_Personal(Ent_Personal objE)
        {
            return SqlHelper.ExecuteDataTable(Conex.CadCon(), "fps_sps_PersonalxPeriodo", objE._Personal_Id, objE._Periodo_Id, objE._Area_Id, objE._Categoria_Auxiliar_Id, objE._Categoria_Auxiliar2_Id, objE._Nombres /* Todo completo o parte de Apellidos y Nombres*/);
        }

        public static DataSet Inserta_Personal(Ent_Personal objE, Ent_Personal_Activo objEPA)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spi_Personal"
                    , objE._Compania_Id   
	                , objE._Planilla_Id   
	                , objE._Apellido_Paterno 
	                , objE._Apellido_Materno 
	                , objE._Nombres 
	                , objE._Sexo_Id   
	                , objE._Fecha_Nacimiento 
	                , objE._E_Civil_Id   
	                , objE._Fecha_Ini_AporteAFP  
	                , objE._Tipo_Doc_Id   
	                , objE._Nro_Doc   
	                , objE._Categoria_Id   
	                , objE._Categoria2_Id   
	                , objE._Cargo_Id   
	                , objE._Situacion_Id   
	                , objE._Afp_Id   
	                , objE._Afp_cod_afiliacion   
	                , objE._Seguro_cod  
	                , objE._Ccosto_Id   
	                , objE._Dpto   
	                , objE._Prov   
	                , objE._Dist   
	                , objE._Direccion 
	                , objE._Telefono   
	                , objE._Telefono2   
	                , objE._Telefono3   
	                , objE._Nro_Hijos 
	                , objE._Tip_cta_Id   
	                , objE._Nro_cta   
	                , objE._Moneda_cta_Id   
	                , objE._Banco_cta_Id   
	                , objE._Nro_cta_cts   
                    , objE._Tip_cta_cts_Id   
                    , objE._Moneda_cta_cts_Id   
                    , objE._Banco_cta_cts_Id   
                    , objE._Proyecto_Id   
                    , objE._Tgasto_Id   
                    , objE._Usuario   
                    , objE._Pase   
                    , objE._LAdministrador
                    , objE._Estado_Id
                    , objE._Area_Id   
                    , objE._Cod_Antiguo  
                    , objE._Email 
                    , objE._Nacionalidad_Id  
                    , objE._Domiciliado  
                    , objE._Tipo_Via_Id   
                    , objE._Numero_Via  
                    , objE._Interior_Via  
                    , objE._Tipo_Zona_Id   
                    , objE._Nombre_Zona   
                    , objE._Referencia 
                    , objE._Tipo_Trabajador_Id   
                    , objE._Regimen_Laboral_Id   
                    , objE._Nivel_Educativo_Id   
                    , objE._Discapacidad  
                    , objE._SCTR_Salud_Id   
                    , objE._SCTR_Pension_Id   
                    , objE._Tipo_Contrato_Id   
                    , objE._Jornada_Atipica   
                    , objE._Jornada_Maxima   
                    , objE._Horario_Nocturno   
                    , objE._Sindicalizado   
                    , objE._EPS_Id   
                    , objE._Ingresos_5ta_Inafectos   
                    , objE._Situacion_Especial_Id   
                    , objE._RUC   
                    , objE._Seguro_Medico_Id   
                    , objE._Madre_Resp_Fam   
                    , objE._Tipo_Centro_Form_Prof_Id   
                    , objE._RUC_Destaque   
                    //////, objE._Foto image(16)
                    , objE._Foto_NombreArchivo   
                    , objE._Nro_Calzado 
                    , objE._Talla_Ropa_Id   
                    , objE._Grupo_Sanguineo_Id   
                    , objE._Estatura   
                    , objE._Peso   
                    , objE._Complexion_Fisica_Id   
                    , objE._Brevete_Nro   
                    , objE._Brevete_Categoria_Id 
                    , objE._Brevete_Vigencia 
                    , objE._Alergias
                    , objE._Codigo_Auxiliar   
                    , objE._Seccion_Id
                    //////, objE._Pais_Emisor_Doc_ID   
                    //////, objE._LDistancia_ID   
                    //////, objE._Departamento  
                    //////, objE._Manzana  
                    //////, objE._Lote  
                    //////, objE._Kilometro  
                    //////, objE._Block  
                    //////, objE._Etapa  
                    //////, objE._Categoria_Ocupacional_Id   
                    //////, objE._Convenio_Evita_Tributacion_ID 	
	                
                    /*Datos para la tabla Personal_Activo*/
                    , objEPA.Periodo_Id
                    , objEPA.Fecha_ingreso
                    , objEPA.Fecha_cese
                    , objEPA.Fecha_ini_contrato
                    , objEPA.Fecha_fin_contrato
                    , objEPA.Pry_Operacion_Id
                    , objEPA.Pry_Categoria_Id
                    , objEPA.Flag_Distribuido
                    , objEPA.Observaciones
                    , objEPA.Motivo_Fin_Per_Lab_Id
                    , objEPA.Tipo_Mod_Formativa_Id
                    , objEPA.Nro_CITT
                    , objEPA.Cod_Contrato
                    , objEPA.Fecha_Impresion_Contrato
                    , objEPA.EPSPLAN_ID
                    , objEPA.Cantidad_Titular
                    , objEPA.Cantidad_Dependientes
                    , objEPA.Cantidad_Hmayores
                    , objEPA.Categoria_Auxiliar_Id
                    , objEPA.Categoria_Auxiliar2_Id
                    , objEPA.Personal_Anexo_Id
                    , objEPA.Personal_Anexo2_Id);
        }

        public static DataSet Actualiza_Personal(Ent_Personal objE, Ent_Personal_Activo objEPA)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spu_Personal"
                    , objE._Personal_Id
                    , objE._Compania_Id
                    , objE._Planilla_Id
                    , objE._Apellido_Paterno
                    , objE._Apellido_Materno
                    , objE._Nombres
                    , objE._Sexo_Id
                    , objE._Fecha_Nacimiento
                    , objE._E_Civil_Id
                    , objE._Fecha_Ini_AporteAFP
                    , objE._Tipo_Doc_Id
                    , objE._Nro_Doc
                    , objE._Categoria_Id
                    , objE._Categoria2_Id
                    , objE._Cargo_Id
                    , objE._Situacion_Id
                    , objE._Afp_Id
                    , objE._Afp_cod_afiliacion
                    , objE._Seguro_cod
                    , objE._Ccosto_Id
                    , objE._Dpto
                    , objE._Prov
                    , objE._Dist
                    , objE._Direccion
                    , objE._Telefono
                    , objE._Telefono2
                    , objE._Telefono3
                    , objE._Nro_Hijos
                    , objE._Tip_cta_Id
                    , objE._Nro_cta
                    , objE._Moneda_cta_Id
                    , objE._Banco_cta_Id
                    , objE._Nro_cta_cts
                    , objE._Tip_cta_cts_Id
                    , objE._Moneda_cta_cts_Id
                    , objE._Banco_cta_cts_Id
                    , objE._Proyecto_Id
                    , objE._Tgasto_Id
                    , objE._Usuario
                    , objE._Pase
                    , objE._LAdministrador
                    , objE._Estado_Id
                    , objE._Area_Id
                    , objE._Cod_Antiguo
                    , objE._Email
                    , objE._Nacionalidad_Id
                    , objE._Domiciliado
                    , objE._Tipo_Via_Id
                    , objE._Numero_Via
                    , objE._Interior_Via
                    , objE._Tipo_Zona_Id
                    , objE._Nombre_Zona
                    , objE._Referencia
                    , objE._Tipo_Trabajador_Id
                    , objE._Regimen_Laboral_Id
                    , objE._Nivel_Educativo_Id
                    , objE._Discapacidad
                    , objE._SCTR_Salud_Id
                    , objE._SCTR_Pension_Id
                    , objE._Tipo_Contrato_Id
                    , objE._Jornada_Atipica
                    , objE._Jornada_Maxima
                    , objE._Horario_Nocturno
                    , objE._Sindicalizado
                    , objE._EPS_Id
                    , objE._Ingresos_5ta_Inafectos
                    , objE._Situacion_Especial_Id
                    , objE._RUC
                    , objE._Seguro_Medico_Id
                    , objE._Madre_Resp_Fam
                    , objE._Tipo_Centro_Form_Prof_Id
                    , objE._RUC_Destaque
                //////, objE._Foto image(16)
                    , objE._Foto_NombreArchivo
                    , objE._Nro_Calzado
                    , objE._Talla_Ropa_Id
                    , objE._Grupo_Sanguineo_Id
                    , objE._Estatura
                    , objE._Peso
                    , objE._Complexion_Fisica_Id
                    , objE._Brevete_Nro
                    , objE._Brevete_Categoria_Id
                    , objE._Brevete_Vigencia
                    , objE._Alergias
                    , objE._Codigo_Auxiliar
                    , objE._Seccion_Id
                //////, objE._Pais_Emisor_Doc_ID   
                //////, objE._LDistancia_ID   
                //////, objE._Departamento  
                //////, objE._Manzana  
                //////, objE._Lote  
                //////, objE._Kilometro  
                //////, objE._Block  
                //////, objE._Etapa  
                //////, objE._Categoria_Ocupacional_Id   
                //////, objE._Convenio_Evita_Tributacion_ID 	

                    /*Datos para la tabla Personal_Activo*/
                    , objEPA.Periodo_Id
                    , objEPA.Fecha_ingreso
                    , objEPA.Fecha_cese
                    , objEPA.Fecha_ini_contrato
                    , objEPA.Fecha_fin_contrato
                    , objEPA.Pry_Operacion_Id
                    , objEPA.Pry_Categoria_Id
                    , objEPA.Flag_Distribuido
                    , objEPA.Observaciones
                    , objEPA.Motivo_Fin_Per_Lab_Id
                    , objEPA.Tipo_Mod_Formativa_Id
                    , objEPA.Nro_CITT
                    , objEPA.Cod_Contrato
                    , objEPA.Fecha_Impresion_Contrato
                    , objEPA.EPSPLAN_ID
                    , objEPA.Cantidad_Titular
                    , objEPA.Cantidad_Dependientes
                    , objEPA.Cantidad_Hmayores
                    , objEPA.Categoria_Auxiliar_Id
                    , objEPA.Categoria_Auxiliar2_Id
                    , objEPA.Personal_Anexo_Id
                    , objEPA.Personal_Anexo2_Id);
        }

        public static DataSet Elimina_Personal(Ent_Personal objE)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "fps_spd_Personal", objE._Personal_Id);
        }

    }


}
