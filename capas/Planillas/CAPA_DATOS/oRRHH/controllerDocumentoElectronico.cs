using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

using iTextSharp.text.pdf;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using Org.BouncyCastle.X509;

/*
 * @001 FPS 13/09/2022 - Ajuste en certif. CTS - Texto de acuerdo a regimen laboral 
 * @002 FPS 15/11/2022 - Ajuste en certif. CTS - Se cambia formato de exto de acuerdo a regimen laboral 
 * @003 FPS 26/11/2022 - Ajuste en Boleta - Se cambia formato fecha de inicio y fin de vacaciones
 * @004 FPS 28/12/2022 - Ajuste en envío de correos - envío asíncrono 
*/

namespace CAPA_DATOS.oRRHH
{
    public class controllerDocumentoElectronico
    {
        private static controllerDocumentoElectronico instance = null;
        public static controllerDocumentoElectronico getinstance()
        {
            return instance == null ? instance = new controllerDocumentoElectronico() : instance;
        }

        //@004 I
        Int32 qt_corte_correo_delay = 10;
        Int32 qt_segundos_delay = 30; //30 seg
        //@004 F

        public object Get_Combos()
        {
            object response;

            ArrayList lstPlanilla = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Planilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "01");
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var Planilla = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstPlanilla.Add(Planilla);
                    }
                }
            }

            ArrayList lstEjercicio = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Ejercicio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var Planilla = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstEjercicio.Add(Planilla);
                    }
                }
            }

            ArrayList lstLocalidad = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_RH_Area", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var Planilla = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstLocalidad.Add(Planilla);
                    }
                }
            }


            ArrayList lstCatAuxiliar = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Categoria_Auxiliar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var Planilla = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstCatAuxiliar.Add(Planilla);
                    }
                }
            }
            //20190701
            ArrayList lstProyecto = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaProyecto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var Proyecto = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstProyecto.Add(Proyecto);
                    }
                }
            }


            response = new
            {
                oPlanilla = lstPlanilla,
                oEjercicio = lstEjercicio,
                oLocalidad = lstLocalidad,
                oCatAuxiliar = lstCatAuxiliar,
                oProyecto = lstProyecto
            };
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(response);
            return serializedResult;
        }

        public object Get_Periodo(object strParametros)
        {

            ArrayList lstPeriodo = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Periodo", cn))
                {
                    Dictionary<string, string> prms = new Dictionary<string, string>();
                    foreach (object ol in (IDictionary)strParametros)
                    {
                        prms.Add(((DictionaryEntry)ol).Key.ToString(), ((DictionaryEntry)ol).Value.ToString());
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", "01");
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", prms.First(f => f.Key == "co_ejercicio").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", prms.First(f => f.Key == "co_planilla").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "02");
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var xitem = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstPeriodo.Add(xitem);
                    }
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(lstPeriodo);
            return serializedResult;
        }

        public object Get_CatAuxiliar2(object strParametros)
        {

            ArrayList lstCatAuxiliar2 = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Categoria_Auxiliar2", cn))
                {
                    Dictionary<string, string> prms = new Dictionary<string, string>();
                    foreach (object ol in (IDictionary)strParametros)
                    {
                        prms.Add(((DictionaryEntry)ol).Key.ToString(), ((DictionaryEntry)ol).Value.ToString());
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", prms.First(f => f.Key == "co_catAuxiliar").Value.ToString());

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var xitem = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstCatAuxiliar2.Add(xitem);
                    }
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(lstCatAuxiliar2);
            return serializedResult;
        }

        public object Get_Personal(object strParametros)
        {
            ArrayList lstPersonal = new ArrayList();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_ComboPersonal", cn))
                {

                    Dictionary<string, string> prms = new Dictionary<string, string>();
                    foreach (object ol in (IDictionary)strParametros)
                    {
                        prms.Add(((DictionaryEntry)ol).Key.ToString(), ((DictionaryEntry)ol).Value.ToString());
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", prms.First(f => f.Key == "co_Ejercicio").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", prms.First(f => f.Key == "co_Planilla").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Periodo_Id", prms.First(f => f.Key == "co_Periodo").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Area_Id", prms.First(f => f.Key == "co_Area").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar_Id", prms.First(f => f.Key == "co_catAuxiliar").Value.ToString());
                    cmd.Parameters.AddWithValue("@vi_Categoria_Auxiliar2_Id", prms.First(f => f.Key == "co_catAuxiliar2").Value.ToString());
                    //20190701
                    cmd.Parameters.AddWithValue("@vi_Proyecto_Id", prms.First(f => f.Key == "co_Proyecto").Value.ToString());

                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var xitem = new { value = dr.GetValue(0).ToString(), nombre = dr.GetValue(1).ToString() };
                        lstPersonal.Add(xitem);
                    }
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(lstPersonal);
            return serializedResult;
        }

        public object Get_GrillaPersonal(object strParametros)
        {
            ArrayList lstPersonal = new ArrayList();
            string comando = "", comandosinenv = "";
            Dictionary<string, string> prms = new Dictionary<string, string>();
            foreach (object ol in (IDictionary)strParametros)
            {
                prms.Add(((DictionaryEntry)ol).Key.ToString(), ((DictionaryEntry)ol).Value.ToString());
            }
            if (prms.First(f => f.Key == "fl_personal_sin_envios").Value.ToString() == "1")
            {
                comandosinenv += " and not exists (select top 1 * from tbl_envio_doc_electronicos env where isnull(env.fl_error_envio,'0')='0' and env.id_persona = pa.Personal_Id and env.id_periodo = pa.Periodo_Id and env.id_proceso='" + prms.First(f => f.Key == "id_proceso").Value.ToString() + "' and env.id_documento='" + prms.First(f => f.Key == "id_documento").Value.ToString() + "')";
            }
            if (prms.First(f => f.Key == "fl_personal_con_correo").Value.ToString() == "1")
            {
                comandosinenv += " and (isnull(email_personal,'')!='' or isnull(email,'')!='')";
            }

            String querySoloVacaciones = "";
            if (prms.First(f => f.Key == "id_documento").Value.ToString() == "BP" && prms.First(f => f.Key == "id_proceso").Value.ToString() == "03") //BOLETA | VACACIONES
            {
                querySoloVacaciones += " and exists (" 
                    + " select vp.Vacaciones_pagadas_id from Vacaciones v " 
                    + " inner join Vacaciones_Pagadas vp on vp.Vacaciones_id = v.Vacaciones_id " 
                    + " where v.Personal_id = pa.personal_id And vp.Periodo_id = pa.Periodo_Id " 
                    + ")";
            }

            comando = "SELECT pa.Personal_Id, pa.Nombre_Completo as [nom_personal], case when isnull(pa.email_personal,'')!='' and pa.email_personal!=pa.email then + (pa.email_personal+'; ') else '' end + isnull(pa.email,'') as [email_personal] FROM vwFPS_Personal_Periodo pa ";
            comando += " where pa.Periodo_Id=@Periodo_Id and pa.Planilla_Id=@Planilla_Id ";
            comando += " and (isnull(@Localidad_Id,'')='' or pa.Area_Id=@Localidad_Id)";
            comando += " and (isnull(@Cat_Auxiliar_Id,'')='' or pa.Categoria_Auxiliar_id=@Cat_Auxiliar_Id)";
            comando += " and (isnull(@Cat_Auxiliar2_Id,'')='' or pa.Categoria_Auxiliar2_id=@Cat_Auxiliar2_Id)";
            comando += " and (isnull(@Proyecto_Id,'')='' or pa.Proyecto_id=@Proyecto_Id)";
            comando += " and pa.Personal_Id = case when rtrim(ltrim(@idpersonal)) ='' then pa.Personal_Id else rtrim(ltrim(@idpersonal)) end ";
            comando += comandosinenv;
            comando += querySoloVacaciones;
            comando += " order by pa.Nombre_Completo";

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idpersonal", prms.First(f => f.Key == "id_personal").Value.ToString());
                    cmd.Parameters.AddWithValue("@Periodo_Id", prms.First(f => f.Key == "Periodo_Id").Value.ToString());
                    cmd.Parameters.AddWithValue("@Planilla_Id", prms.First(f => f.Key == "Planilla_Id").Value.ToString());
                    cmd.Parameters.AddWithValue("@Localidad_Id", prms.First(f => f.Key == "Localidad_Id").Value.ToString());
                    cmd.Parameters.AddWithValue("@Cat_Auxiliar_Id", prms.First(f => f.Key == "Cat_Auxiliar_Id").Value.ToString());
                    cmd.Parameters.AddWithValue("@Cat_Auxiliar2_Id", prms.First(f => f.Key == "Cat_Auxiliar2_Id").Value.ToString());
                    cmd.Parameters.AddWithValue("@Proyecto_Id", prms.First(f => f.Key == "Proyecto_Id").Value.ToString());
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        var xitem = new
                        { Personal_Id = dr.GetValue(0).ToString().ToString(), nom_personal = dr.GetValue(1).ToString().ToString(), email_personal = dr.GetValue(2).ToString().ToString() };
                        lstPersonal.Add(xitem);
                    }
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(lstPersonal);
            return serializedResult;
        }

        public object Get_GrillaHistorialEnvio(object strParametros)
        {
            ArrayList lstPersonal = new ArrayList();
            Dictionary<string, string> prms = new Dictionary<string, string>();
            foreach (object ol in (IDictionary)strParametros)
            {
                prms.Add(((DictionaryEntry)ol).Key.ToString(), ((DictionaryEntry)ol).Value.ToString());
            }
            string virtualServerRutaDocumentos = ParametrosDA.VirtualServer_RutaDocumentos;
            string enlaceVerDocumento = "<a href='{0}' target='_blank'><img width='20px' src='../Images/Buscar.png' title='Ver Documento' /></a>";
            string enlaceGenDocumento = "<a href='#'><img width='20px' src='../Images/Buscar.png' title='Generar Documento' onclick='fn_genDocumento(\"{0}\");' /></a>";

            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("ups_sel_historial_envio", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@In_Planilla_Id", prms.First(f => f.Key == "co_planilla").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_Ejercicio_Id", prms.First(f => f.Key == "co_ejercicio").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_Periodo_Id", prms.First(f => f.Key == "co_periodo").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_Localidad_Id", prms.First(f => f.Key == "id_localidad").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_CatAuxiliar_Id", prms.First(f => f.Key == "id_cat_aux").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_CatAuxiliar2_Id", prms.First(f => f.Key == "id_cat_aux2").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_Proyecto_Id", prms.First(f => f.Key == "id_proyecto").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_id_persona", prms.First(f => f.Key == "id_persona").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_id_documento", prms.First(f => f.Key == "id_documento").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_fec_inicial", prms.First(f => f.Key == "fec_inicial").Value.ToString());
                    cmd.Parameters.AddWithValue("@In_fec_final", prms.First(f => f.Key == "fec_final").Value.ToString());
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        String imgVerPDFGuardado = String.Empty;
                        String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                        if (File.Exists(Path.Combine(pathDocumentoPDF, dr.GetValue(9).ToString())))
                        {
                            imgVerPDFGuardado = String.Format(enlaceVerDocumento, virtualServerRutaDocumentos + dr.GetValue(9).ToString());
                        }

                        var xitem = new
                        {
                            Localidad = dr.GetValue(0).ToString(),
                            personal = dr.GetValue(1).ToString(),
                            documento = dr.GetValue(2).ToString(),
                            fe_envio = dr.GetValue(3).ToString(),
                            fe_recepcion = dr.GetValue(4).ToString(),
                            id_envio = dr.GetValue(5).ToString(),
                            periodo = dr.GetValue(6).ToString(),
                            proceso = dr.GetValue(7).ToString(),
                            no_correo_enviado = dr.GetValue(8).ToString(),
                            img_ver = imgVerPDFGuardado,
                            img_genDocumento = String.Format(enlaceGenDocumento, dr.GetValue(10).ToString())
                        };
                        lstPersonal.Add(xitem);
                    }
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(lstPersonal);
            return serializedResult;
        }
        
        //boleta de pago
        public string Get_ImprimeBoleta_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario
            
            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileBoletaPDF(Periodo_Id, Personal_Id, Proceso_Id
                        , fl_dolares, fl_add_total_USD, Periodo_Id_Desde
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }

                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Boleta de Pago de " + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileBoletaPDF(String Periodo_Id, String Personal_Id, String Proceso_Id
            , String fl_dolares, String fl_add_total_USD, String Periodo_Id_Desde
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "Boleta_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                String fl_por_personal_periodo = "0";

                DataTable dtBoleta = new DataTable();
                Int32 cantPersonal = 1;
                dtBoleta = Dao_Reportes.Lista_Boleta_Pago_Masivo(Personal_Id.ToString(), Periodo_Id, Proceso_Id, cantPersonal, "", Periodo_Id_Desde, fl_dolares
                    , fl_por_personal_periodo
                    , rucEmpresa);
                //////using (SqlConnection cn = new SqlConnection(cnxConnection))
                //////{
                //////    using (SqlCommand cmd = new SqlCommand("Reporte_Boleta", cn))
                //////    {
                //////        cmd.CommandType = CommandType.StoredProcedure;
                //////        cmd.Parameters.AddWithValue("@cPeriodo", prms[2].ToString());
                //////        cmd.Parameters.AddWithValue("@cProceso", prms[3].ToString());
                //////        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                //////        cn.Open();
                //////        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtBoleta); }
                //////    }
                //////}

                if (dtBoleta.Rows.Count <= 0)
                {
                    retorno = false;
                    msg_retorno = "- " + Nombre_Completo + " no tiene datos.";
                    return;
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaBoleta.html";
                String Planilla_Id = dtBoleta.Rows[0]["Planilla_Id"].ToString();
                if (Planilla_Id == "02")
                {
                    nombrePlantilla_HTML = "PlantillaBoleta_Obrero.html";
                }
                string strRutaPlantilla_Boleta = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_Boleta, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    String simboloMoneda = "S/";
                    if (fl_dolares == "1") { simboloMoneda = "$"; }

                    linea = linea.Replace("[_SimboloMoneda_]", simboloMoneda);
                    linea = linea.Replace("[_Codigo_]", dtBoleta.Rows[0][12].ToString());
                    linea = linea.Replace("[_RazonSocial_]", dtBoleta.Rows[0]["Razon_Social"].ToString());
                    linea = linea.Replace("[_RucEmpresa_]", dtBoleta.Rows[0]["RUC"].ToString());
                    linea = linea.Replace("[_Ejercicio_]", dtBoleta.Rows[0][15].ToString());
                    linea = linea.Replace("[_Trabajador_]", dtBoleta.Rows[0][13].ToString());
                    linea = linea.Replace("[_Cargo_]", dtBoleta.Rows[0][18].ToString());
                    linea = linea.Replace("[_NroDoc_]", dtBoleta.Rows[0][27].ToString());
                    linea = linea.Replace("[_Sede_]", dtBoleta.Rows[0][11].ToString());
                    linea = linea.Replace("[_AfpOnp_]", dtBoleta.Rows[0][20].ToString()); //Solo los 17 primeros caracteres entran al cuadro de boleta;
                    linea = linea.Replace("[_CUSPP_]", dtBoleta.Rows[0][28].ToString());
                    //linea = linea.Replace("[_Essalud_]", "");
                    linea = linea.Replace("[_SueldoBas_]", decimal.Parse(dtBoleta.Rows[0][55].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Banco_]", dtBoleta.Rows[0][66].ToString());
                    linea = linea.Replace("[_NroCuenta_]", dtBoleta.Rows[0][67].ToString());
                    linea = linea.Replace("[_FecIngreso_]", DateTime.Parse(dtBoleta.Rows[0][21].ToString()).ToShortDateString());

                    if (DateTime.Parse(dtBoleta.Rows[0][23].ToString()).Year == 1900) { linea = linea.Replace("[_FecCese_]", ""); }
                    else { linea = linea.Replace("[_FecCese_]", DateTime.Parse(dtBoleta.Rows[0][23].ToString()).ToShortDateString()); }
                    linea = linea.Replace("[_Observacion_]", dtBoleta.Rows[0][10].ToString());

                    if (dtBoleta.Rows[0][51] == DBNull.Value) { linea = linea.Replace("[_FSalvac_]", ""); }
                    //@003 I
                    //else { linea = linea.Replace("[_FSalvac_]", DateTime.Parse(dtBoleta.Rows[0][51].ToString()).ToShortDateString()); }
                    else { linea = linea.Replace("[_FSalvac_]", dtBoleta.Rows[0][51].ToString()); }
                    //@003 F

                    if (dtBoleta.Rows[0][52] == DBNull.Value) { linea = linea.Replace("[_FRetVac_]", ""); }
                    //@003 I
                    //else { linea = linea.Replace("[_FRetVac_]", DateTime.Parse(dtBoleta.Rows[0][52].ToString()).ToShortDateString()); }
                    else { linea = linea.Replace("[_FRetVac_]", dtBoleta.Rows[0][52].ToString()); }
                    //@003 F

                    linea = linea.Replace("[_DiasTrab_]", decimal.Parse(dtBoleta.Rows[0][45].ToString()).ToString("###,##0.00"));

                    if (Planilla_Id == "02")
                    {
                        Decimal HN = dtBoleta.Rows[0]["HORAS_NOCTURNO"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HORAS_NOCTURNO"]);
                        Decimal HA = dtBoleta.Rows[0]["HORAS_ALTURA"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HORAS_ALTURA"]);
                        Decimal HD = dtBoleta.Rows[0]["HORAS_DIURNO"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HORAS_DIURNO"]);
                        HD = HD - (HN + HA);

                        if (dtBoleta.Rows[0]["HORAS_DIURNO"] == DBNull.Value) { linea = linea.Replace("[_HD_]", "0.000"); }
                        else { linea = linea.Replace("[_HD_]", HD.ToString("###,##0.00")); }

                        if (dtBoleta.Rows[0]["HORAS_NOCTURNO"] == DBNull.Value) { linea = linea.Replace("[_HN_]", "0.000"); }
                        else { linea = linea.Replace("[_HN_]", HN.ToString("###,##0.00")); }

                        if (dtBoleta.Rows[0]["HORAS_ALTURA"] == DBNull.Value) { linea = linea.Replace("[_HA_]", "0.000"); }
                        else { linea = linea.Replace("[_HA_]", HA.ToString("###,##0.00")); }

                        Decimal HED = Convert.ToDecimal(dtBoleta.Rows[0]["HOR20"]) + Convert.ToDecimal(dtBoleta.Rows[0]["HOR35"]) + Convert.ToDecimal(dtBoleta.Rows[0]["HORDOB"]);
                        linea = linea.Replace("[_HED_]", HED.ToString("###,##0.00"));

                        Decimal HE_60_NOCTURNA = dtBoleta.Rows[0]["HE_60_NOCTURNA"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HE_60_NOCTURNA"]);
                        Decimal HE_100_NOCTURNA = dtBoleta.Rows[0]["HE_100_NOCTURNA"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HE_100_NOCTURNA"]);
                        Decimal HEN = HE_60_NOCTURNA + HE_100_NOCTURNA;
                        linea = linea.Replace("[_HEN_]", HEN.ToString("###,##0.00"));

                        Decimal HE_60_ALTURA = dtBoleta.Rows[0]["HE_60_ALTURA"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HE_60_ALTURA"]);
                        Decimal HE_100_ALTURA = dtBoleta.Rows[0]["HE_100_ALTURA"] == DBNull.Value ? 0 : Convert.ToDecimal(dtBoleta.Rows[0]["HE_100_ALTURA"]);
                        Decimal HEA = HE_60_ALTURA + HE_100_ALTURA;
                        linea = linea.Replace("[_HEA_]", HEA.ToString("###,##0.00"));
                    }
                    else
                    {
                        //linea = linea.Replace("[_HorasTrab_]", (decimal.Parse(dtBoleta.Rows[0][45].ToString()) * 8).ToString("###,##0.00"));
                        if (dtBoleta.Rows[0]["HORAS_DIURNO"] == DBNull.Value) { linea = linea.Replace("[_HorasTrab_]", "0.000"); }
                        else { linea = linea.Replace("[_HorasTrab_]", decimal.Parse(dtBoleta.Rows[0]["HORAS_DIURNO"].ToString()).ToString("###,##0.00")); }

                        if (dtBoleta.Rows[0][30] == DBNull.Value) { linea = linea.Replace("[_HES_]", "0.000"); }
                        else { linea = linea.Replace("[_HES_]", decimal.Parse(dtBoleta.Rows[0][30].ToString()).ToString("###,##0.00")); }

                        if (dtBoleta.Rows[0][31] == DBNull.Value) { linea = linea.Replace("[_HEA_]", "0.000"); }
                        else { linea = linea.Replace("[_HEA_]", decimal.Parse(dtBoleta.Rows[0][31].ToString()).ToString("###,##0.00")); }

                        if (dtBoleta.Rows[0][32] == DBNull.Value) { linea = linea.Replace("[_HED_]", "0.000"); }
                        else { linea = linea.Replace("[_HED_]", decimal.Parse(dtBoleta.Rows[0][32].ToString()).ToString("###,##0.00")); }
                    }

                    //Ingresos/Descuentos/Aportes
                    string cadNomConceptosIngresos = "", cadMontoIngresos = "", cadNomConceptosDsctos = "", cadMontoDsctos = ""
                        , cadNomConceptosAportes = "", cadMontoAportes = "";
                    int filas_index = 0;

                    string saltoLinea_HTML = "<br />";
                    foreach (DataRow drowBoleta in dtBoleta.Rows)
                    {
                        string saltoLinea = "";
                        if (drowBoleta["Concepto_Id1"].ToString() != "")
                        {
                            if (filas_index > 0) { saltoLinea = saltoLinea_HTML; }
                            cadNomConceptosIngresos = cadNomConceptosIngresos + saltoLinea + drowBoleta["Concepto_Id1"].ToString();
                            cadMontoIngresos = cadMontoIngresos + saltoLinea + decimal.Parse(drowBoleta["Valor1"].ToString()).ToString("###,##0.00");
                        }
                        saltoLinea = "";
                        if (drowBoleta["Concepto_Id2"].ToString() != "")
                        {
                            if (filas_index > 0) { saltoLinea = saltoLinea_HTML; }
                            cadNomConceptosDsctos = cadNomConceptosDsctos + saltoLinea + drowBoleta["Concepto_Id2"].ToString();
                            cadMontoDsctos = cadMontoDsctos + saltoLinea + decimal.Parse(drowBoleta["Valor2"].ToString()).ToString("###,##0.00");
                        }
                        saltoLinea = "";
                        if (drowBoleta["Concepto_Id3"].ToString() != "")
                        {
                            if (filas_index > 0)
                            {
                                saltoLinea = saltoLinea_HTML;
                            }
                            cadNomConceptosAportes = (cadNomConceptosAportes + (saltoLinea + drowBoleta["Concepto_Id3"]));
                            cadMontoAportes = (cadMontoAportes + (saltoLinea + decimal.Parse(drowBoleta["Valor3"].ToString()).ToString("###,##0.00")));
                        }
                        filas_index = filas_index + 1;
                    }
                    linea = linea.Replace("[_ConceptoIngresos_]", cadNomConceptosIngresos);
                    linea = linea.Replace("[_MontoIngresos_]", cadMontoIngresos);
                    linea = linea.Replace("[_ConceptoDsctos_]", cadNomConceptosDsctos);
                    linea = linea.Replace("[_MontoDsctos_]", cadMontoDsctos);
                    linea = linea.Replace("[_ConceptoAportes_]", cadNomConceptosAportes);
                    linea = linea.Replace("[_MontoAportes_]", cadMontoAportes);

                    if (dtBoleta.Rows[0][62] == DBNull.Value) { linea = linea.Replace("[_TotalIng_]", "0.000"); }
                    else { linea = linea.Replace("[_TotalIng_]", decimal.Parse(dtBoleta.Rows[0][62].ToString()).ToString("###,##0.00")); }

                    if (dtBoleta.Rows[0][63] == DBNull.Value) { linea = linea.Replace("[_TotalDesc_]", decimal.Parse("0").ToString("###,##0.00")); }
                    else { linea = linea.Replace("[_TotalDesc_]", decimal.Parse(dtBoleta.Rows[0][63].ToString()).ToString("###,##0.00")); }

                    String cad_PagoNeto = "NETO A PAGAR " + simboloMoneda + " " + decimal.Parse(dtBoleta.Rows[0][65].ToString()).ToString("###,##0.00");
                    if (fl_add_total_USD == "1")
                    {
                        String saltoLinea_PDF = "\r\n";
                        cad_PagoNeto += saltoLinea_PDF + "T.C. " + decimal.Parse(dtBoleta.Rows[0]["Tipo_Cambio"].ToString()).ToString("###,##0.000");
                        cad_PagoNeto += saltoLinea_PDF + "$ " + (decimal.Parse(dtBoleta.Rows[0][65].ToString()) / decimal.Parse(dtBoleta.Rows[0]["Tipo_Cambio"].ToString())).ToString("###,##0.00");
                    }

                    //linea = linea.Replace("[_NetoPago_]", simboloMoneda + " " + decimal.Parse(dtBoleta.Rows[0][65].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_NetoPago_]", cad_PagoNeto);

                    if (dtBoleta.Rows[0][68] == DBNull.Value) { linea = linea.Replace("[_Faltas_]", "0.000"); }
                    else { linea = linea.Replace("[_Faltas_]", decimal.Parse(dtBoleta.Rows[0][68].ToString()).ToString("###,##0.00")); }

                    if (dtBoleta.Rows[0][69] == DBNull.Value) { linea = linea.Replace("[_Licsingoce_]", "0.000"); }
                    else { linea = linea.Replace("[_Licsingoce_]", decimal.Parse(dtBoleta.Rows[0][69].ToString()).ToString("###,##0.00")); }

                    if (dtBoleta.Rows[0][70] == DBNull.Value) { linea = linea.Replace("[_Liccongoce_]", "0.000"); }
                    else { linea = linea.Replace("[_Liccongoce_]", decimal.Parse(dtBoleta.Rows[0][70].ToString()).ToString("###,##0.00")); }

                    if (dtBoleta.Rows[0][71] == DBNull.Value) { linea = linea.Replace("[_DesMedico_]", "0.000"); }
                    else { linea = linea.Replace("[_DesMedico_]", decimal.Parse(dtBoleta.Rows[0][71].ToString()).ToString("###,##0.00")); }

                    if (dtBoleta.Rows[0][72] == DBNull.Value) { linea = linea.Replace("[_Subsidios_]", "0.000"); }
                    else { linea = linea.Replace("[_Subsidios_]", decimal.Parse(dtBoleta.Rows[0][72].ToString()).ToString("###,##0.00")); }
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                
                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtBoleta.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //1era boleta
                document.Add(imgLogo);

                imgLogo.SetAbsolutePosition(25, 400); //2da boleta
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtBoleta.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                imgFirma.SetAbsolutePosition(240, 490); //1era boleta
                canvas.AddImage(imgFirma);

                imgFirma.SetAbsolutePosition(240, 105); //2da boleta
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
                //--Firma digital
                /*
                //String CERT_PATH = @"C:\Users\fpumaylle_externo\Downloads\Prueba_Certificado.pfx";
                String CERT_PATH = @"C:\Users\fpumaylle_externo\Downloads\LLAMA-PE-CERTIFICADO-DEMO-10000000001.pfx";
                String CERT_PASSW = "123456";
                String PDF_Destino = @"C:\Users\fpumaylle_externo\Downloads\Doc_Certificado_prueba_Llama.pdf";
                signPdfFile(FilePDFArray, PDF_Destino, CERT_PATH, CERT_PASSW, "", "");

                byte[] bytes = System.IO.File.ReadAllBytes(PDF_Destino);
                out_FilePDF = Convert.ToBase64String(bytes);
                out_nomFilePDF = nomFilePDF;

                //FileStream fs = new FileStream(CERT_PATH, FileMode.Open);
                //Org.BouncyCastle.Pkcs.Pkcs12Store ks = new Org.BouncyCastle.Pkcs.Pkcs12Store(fs, CERT_PASSW.ToCharArray());
                */
                //--Firma digital
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }            
        }
        
        //cts
        public string Get_ImprimeCTS_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Reporte_Id = prms[0].ToString();
            String Usuario = prms[1].ToString();
            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario

            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileCTSPDF(Reporte_Id, Usuario, Periodo_Id, Personal_Id, Proceso_Id
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }
                
                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado CTS de " + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileCTSPDF(String Reporte_Id, String Usuario, String Periodo_Id, String Personal_Id, String Proceso_Id
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "CTS_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                DataTable dtReporte = new DataTable();
                DataTable dtLogo = new DataTable();
                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_LISTAR_REPORTE", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cReporte", Reporte_Id);
                        cmd.Parameters.AddWithValue("@Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@cPeriodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@cProceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtReporte); }
                    }
                }

                if (dtReporte.Rows.Count <= 0)
                {
                    retorno = false;
                    msg_retorno = "- " + Nombre_Completo + " no tiene datos.";
                    return;
                }

                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                    {
                        cmds.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                    }
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaCTS.html";
                string strRutaPlantilla_CTS = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_CTS, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    StringBuilder cabecera = new StringBuilder();
                    cabecera.Append("" + dtReporte.Rows[0][2].ToString() + " con RUC N° " + dtReporte.Rows[0][19].ToString() + ", con domicilio en " + dtReporte.Rows[0][3].ToString() + ", ");
                    cabecera.Append("representado por el Sr. " + dtReporte.Rows[0][4].ToString() + ", en aplicación  del  artículo  24 del  TUO  del  D.Leg.  650,  Ley  de  Compensación  por  Tiempo  de ");
                    cabecera.Append("Servicios  aprobado  mediante  el  D.S.No  001-97-TR,  otorga  al  Sr.(a) " + dtReporte.Rows[0][5].ToString());
                    cabecera.Append(" la  presente  constancia  del  depósito  de  su Compensación  por  Tiempo  de  Servicios,  en  la  cuenta  CTS  de  moneda  Soles  N° ");
                    cabecera.Append("" + dtReporte.Rows[0][12].ToString() + ",  del  BANCO  " + dtReporte.Rows[0][11].ToString() + ",  por  los  siguientes  montos  y periodos:");

                    string txPeriodo = "";
                    if (dtReporte.Rows[0]["NroMes"].ToString() == "11") { txPeriodo = "Mayo - Octubre "; }
                    else { txPeriodo = "Noviembre - Abril "; }
                    txPeriodo = txPeriodo + dtReporte.Rows[0][16].ToString();

                    //Llenando valores al PDF
                    linea = linea.Replace("[_Cabecera_]", cabecera.ToString());
                    //linea = linea.Replace("[_Periodo_]", dtReporte.Rows[0][13].ToString());
                    linea = linea.Replace("[_Periodo_]", txPeriodo);
                    linea = linea.Replace("[_FecIngreso_]", DateTime.Parse(dtReporte.Rows[0][18].ToString()).ToShortDateString());
                    linea = linea.Replace("[_Basico_]", decimal.Parse(dtReporte.Rows[0][20].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Asignacion_]", decimal.Parse(dtReporte.Rows[0][17].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Sobretiempo_]", decimal.Parse(dtReporte.Rows[0][22].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_BoniNocturna_]", decimal.Parse(dtReporte.Rows[0][28].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Comision_]", decimal.Parse(dtReporte.Rows[0][31].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_BoniTrabajo_]", decimal.Parse(dtReporte.Rows[0][32].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Refrigerio_]", decimal.Parse(dtReporte.Rows[0][33].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Gratificacion_]", decimal.Parse(dtReporte.Rows[0][7].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Total_]", decimal.Parse(dtReporte.Rows[0][8].ToString()).ToString("###,##0.00"));
                    //@001 I
                    //string txFormaCalulo = String.Format("({0} / 2) * ({1} / 180) =", decimal.Parse(dtReporte.Rows[0][8].ToString()).ToString("###,##0.00"), decimal.Parse(dtReporte.Rows[0][21].ToString()).ToString("###,##0.00"));
                    //@002 I
                    //string txFormaCalulo = String.Format("({0} / 2) * ({1} / 180) =", decimal.Parse(dtReporte.Rows[0]["TOTALCOMP_FormaCalc"].ToString()).ToString("###,##0.00"), decimal.Parse(dtReporte.Rows[0][21].ToString()).ToString("###,##0.00"));
                    Int32 Regimen_Laboral_Id = Convert.ToInt32(dtReporte.Rows[0]["REGIMEN_LABORAL_ID"].ToString());
                    string txFormaCalulo = String.Format("({0}) / 360 * {1} =", decimal.Parse(dtReporte.Rows[0]["TOTALCOMP"].ToString()).ToString("###,##0.00"), decimal.Parse(dtReporte.Rows[0][21].ToString()).ToString("###,##0.00"));
                    if (Regimen_Laboral_Id == 16 || Regimen_Laboral_Id == 17) /*Microempresa o Pequeña empresa*/
                    {
                        txFormaCalulo = String.Format("({0} / 2) / 360 * {1} =", decimal.Parse(dtReporte.Rows[0]["TOTALCOMP"].ToString()).ToString("###,##0.00"), decimal.Parse(dtReporte.Rows[0][21].ToString()).ToString("###,##0.00"));
                    }
                    //@002 F
                    //@001 F
                    linea = linea.Replace("[_FormaCalculo_MesesCompleto_]", txFormaCalulo);
                    linea = linea.Replace("[_CompletoMeses_]", decimal.Parse(dtReporte.Rows[0][23].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_RetJuridica_]", decimal.Parse(dtReporte.Rows[0][25].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_MontoCts_]", decimal.Parse(dtReporte.Rows[0][23].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_TipoCambio_]", decimal.Parse(dtReporte.Rows[0][14].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_MontoDeposita_]", decimal.Parse(dtReporte.Rows[0][26].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_TipoMonedaCTS_]", dtReporte.Rows[0][13].ToString() == "MN" ? "Soles" : "Dólares");
                    linea = linea.Replace("[_Empleador_]", dtReporte.Rows[0][2].ToString());
                    linea = linea.Replace("[_Trabajador_]", dtReporte.Rows[0][5].ToString());
                    linea = linea.Replace("[_Dni_]", "Nro DOC. IDE. : " + dtReporte.Rows[0][24].ToString());
                    linea = linea.Replace("[_Fecha_]", dtReporte.Rows[0][9].ToString() + " 13 de " + dtReporte.Rows[0][30].ToString());
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                Int32 qt_filas_ocultas = 0;
                #region "Oculta líneas sin importe"
                if(decimal.Parse(dtReporte.Rows[0][20].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Basico");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][17].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Asignacion");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][22].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Sobretiempo");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][28].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_BoniNocturna");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][31].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Comision");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][32].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_BoniTrabajo");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][33].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Refrigerio");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][7].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Gratificacion");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][8].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_Total");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][23].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_CompletoMeses");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][25].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_RetJuridica");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][23].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_MontoCts");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][14].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_TipoCambio");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][26].ToString()) == 0)
                {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "tr_MontoDeposita");
                    qt_filas_ocultas++;
                }
                #endregion "Oculta líneas sin importe"
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //Parte superior izquierda
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                //imgFirma.SetAbsolutePosition(110, 235); //Ubicación de Firma
                Int32 pos_Y_firma = 235;
                if (qt_filas_ocultas > 0) { pos_Y_firma = pos_Y_firma + (qt_filas_ocultas * 15); }
                imgFirma.SetAbsolutePosition(110, pos_Y_firma); //Ubicación de Firma
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }
        }

        //utilidades
        public string Get_ImprimeUtilidad_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Reporte_Id = prms[0].ToString();
            String Usuario = prms[1].ToString();
            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario

            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileUtilidadPDF(Reporte_Id, Usuario, Periodo_Id, Personal_Id, Proceso_Id
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }
                
                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado de Utilidad de " + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileUtilidadPDF(String Reporte_Id, String Usuario, String Periodo_Id, String Personal_Id, String Proceso_Id
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "Utilidades_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                DataTable dtReporte = new DataTable();
                DataTable dtLogo = new DataTable();
                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_LISTAR_REPORTE", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cReporte", Reporte_Id);
                        cmd.Parameters.AddWithValue("@Usuario", Usuario);
                        cmd.Parameters.AddWithValue("@cPeriodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@cProceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtReporte); }
                    }
                }

                if (dtReporte.Rows.Count <= 0)
                {
                    retorno = false;
                    msg_retorno = "- " + Nombre_Completo + " no tiene datos.";
                    return;
                }

                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                    {
                        cmds.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                    }
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaUtilidad.html";
                string strRutaPlantilla_CTS = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_CTS, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    StringBuilder cabecera = new StringBuilder();
                    cabecera.Append("" + dtReporte.Rows[0][1].ToString() + " con RUC N° " + dtReporte.Rows[0][2].ToString() + ", domiciliado en " + dtReporte.Rows[0][3].ToString() + ", ");
                    cabecera.Append("representado por el Sr. " + dtReporte.Rows[0][4].ToString() + ", en su ");
                    cabecera.Append("calidad de empleador y en cumplimiento de lo dispuesto por el D.Leg. N° 892 y el D.S. N° 009-98-TR, deja ");
                    cabecera.Append("constancia de la determinación, distribución y pago de la participación en las utilidades del trabajador");
                    cabecera.Append("" + dtReporte.Rows[0][5].ToString() + ", correspondiente al ejercicio " + dtReporte.Rows[0][18].ToString() + "");

                    //Llenando valores al PDF
                    linea = linea.Replace("[_Cabecera_]", cabecera.ToString());
                                        
                    linea = linea.Replace("[_Renta_]", "S/. " + decimal.Parse(dtReporte.Rows[0][6].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Porcentaje_]", decimal.Parse(dtReporte.Rows[0][7].ToString()).ToString("###,##0.00") + " %");
                    linea = linea.Replace("[_Monto_]", "S/. " + decimal.Parse(dtReporte.Rows[0][8].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_TotalDias_]", decimal.Parse(dtReporte.Rows[0][9].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_DiasLaborados_]", decimal.Parse(dtReporte.Rows[0][11].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Participacion_]", "S/. " + decimal.Parse(dtReporte.Rows[0][12].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Ejercicio_]", dtReporte.Rows[0][18].ToString());
                    linea = linea.Replace("[_Remuneracion_]", "S/. " + decimal.Parse(dtReporte.Rows[0][13].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_RemComputable_]", "S/. " + decimal.Parse(dtReporte.Rows[0][15].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_ParticipacionRem_]", "S/. " + decimal.Parse(dtReporte.Rows[0][16].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_TotParticipacion_]", "S/. " + decimal.Parse(dtReporte.Rows[0][17].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_NetaParticipacion_]", "S/. " + decimal.Parse(dtReporte.Rows[0][17].ToString()).ToString("###,##0.00"));
                    DateTime fecha = DateTime.UtcNow;
                    //linea = linea.Replace("[_Fecha_]", "Callao, 31 de Marzo del" + " " + fecha.Year.ToString());
                    linea = linea.Replace("[_Fecha_]", "Fecha de Emisión: Marzo del" + " " + fecha.Year.ToString());
                    linea = linea.Replace("[_Trabajador_]", dtReporte.Rows[0][5].ToString());
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                //Int32 qt_filas_ocultas = 0;
                #region "Oculta líneas sin importe"
                /*
                if(decimal.Parse(dtReporte.Rows[0][6].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trRenta");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][7].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trPorcentaje");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][8].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trMonto");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][9].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trTotalDias");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][11].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trDiasLaborados");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][12].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trParticipacion");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][13].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trRemuneracion");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][15].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trRemComputable");
                    qt_filas_ocultas++;
                }
                if (decimal.Parse(dtReporte.Rows[0][16].ToString()) == 0) {
                    strPlantillaHTML = ocultarEtiqueta(strPlantillaHTML, "tr", "trParticipacionRem");
                    qt_filas_ocultas++;
                }
                */
                #endregion "Oculta líneas sin importe"
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //Parte superior izquierda
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                imgFirma.SetAbsolutePosition(365, 235); //Ubicación de Firma
                /*Int32 pos_Y_firma = 235;
                if (qt_filas_ocultas > 0) { pos_Y_firma = pos_Y_firma + (qt_filas_ocultas * 18); }
                imgFirma.SetAbsolutePosition(365, pos_Y_firma); //Ubicación de Firma*/
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }
        }

        //quinta categoria
        public string Get_ImprimeQuinta_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Reporte_Id = prms[0].ToString();
            String Usuario = prms[1].ToString();
            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String Ejercicio_Id = prms[6].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario

            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileQuintaPDF(Reporte_Id, Usuario, Ejercicio_Id, Periodo_Id, Personal_Id, Proceso_Id
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }
                
                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado de Retención de 5ta de " + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileQuintaPDF(String Reporte_Id, String Usuario, String Ejercicio_Id, String Periodo_Id, String Personal_Id, String Proceso_Id
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "Quinta_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                DataTable dtReporte = new DataTable();
                DataTable dtLogo = new DataTable();
                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("uspGenerarCeritificadoQuinta", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@PersonalId", Personal_Id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtReporte); }
                    }
                }

                if (dtReporte.Rows.Count <= 0)
                {
                    retorno = false;
                    msg_retorno = "- " + Nombre_Completo + " no tiene datos.";
                    return;
                }

                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                    {
                        cmds.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                    }
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaQuinta.html";
                string strRutaPlantilla_CTS = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_CTS, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    StringBuilder cabecera = new StringBuilder();
                    cabecera.Append("Que a don (doña) : " + dtReporte.Rows[0][4] + " con D.N.I. N°  " + dtReporte.Rows[0][5]);
                    cabecera.Append(",  se le ha retenido por concepto ");
                    cabecera.Append("del Impuesto a la Renta de 5ta. Categoría, correspondiente al ejercicio gravable ");
                    cabecera.Append(Ejercicio_Id + " (" + dtReporte.Rows[0][13] + "), calculado en base a las siguientes remuneraciones:");

                    //Llenando valores al PDF
                    linea = linea.Replace("[_Cabecera_]", cabecera.ToString());
                    linea = linea.Replace("[_Periodo_]", dtReporte.Rows[0][13].ToString());
                    linea = linea.Replace("[_Ejercicio_]", DateTime.Parse(dtReporte.Rows[0][1].ToString()).Year.ToString());
                    linea = linea.Replace("[_Empresa_]", dtReporte.Rows[0]["CIA"].ToString());
                    linea = linea.Replace("[_Ruc_]", dtReporte.Rows[0]["RUC"].ToString());

                    DateTime fecha = DateTime.Parse(dtReporte.Rows[0][1].ToString());
                    linea = linea.Replace("[_Fecha_]", "LIMA" + " " + String.Format("{0:D}", fecha));
                    linea = linea.Replace("[_Representante_]", dtReporte.Rows[0][11].ToString());
                    linea = linea.Replace("[_Sueldo_]", Decimal.Parse(dtReporte.Rows[0][6].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Remuneracion_]", "S/. " + Decimal.Parse(dtReporte.Rows[0][6].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Deduccion_]", "S/. " + Decimal.Parse(dtReporte.Rows[0][8].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Renta_]", "S/. " + (Decimal.Parse(dtReporte.Rows[0][6].ToString()) - Decimal.Parse(dtReporte.Rows[0][8].ToString())).ToString("###,##0.00"));
                    linea = linea.Replace("[_Impuesto_]", Decimal.Parse(dtReporte.Rows[0][9].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_Credito_]", "S/. " + Decimal.Parse(dtReporte.Rows[0][10].ToString()).ToString("###,##0.00"));
                    linea = linea.Replace("[_ImpuestoReten_]", "S/. " + Decimal.Parse(dtReporte.Rows[0][16].ToString()).ToString("###,##0.00"));
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //Parte superior izquierda
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                imgFirma.SetAbsolutePosition(110, 170); //Ubicación de Firma
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }
        }

        //certificado de trabajo
        public string Get_ImprimeCertTrabajo_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Reporte_Id = prms[0].ToString();
            String Usuario = prms[1].ToString();
            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario

            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileCertTrabajoPDF(Reporte_Id, Usuario, Periodo_Id, Personal_Id, Proceso_Id
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }
                
                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado de trabajo" + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileCertTrabajoPDF(String Reporte_Id, String Usuario, String Periodo_Id, String Personal_Id, String Proceso_Id
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "CertificadoTrabajo_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                DataTable dtReporte = new DataTable();
                DataTable dtLogo = new DataTable();
                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_CTrabajo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@personal_id", Personal_Id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtReporte); }
                    }
                }

                if (dtReporte.Rows.Count <= 0)
                {
                    retorno = false;
                    msg_retorno = "- " + Nombre_Completo + " no tiene datos.";
                    return;
                }

                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                    {
                        cmds.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                    }
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaCertificadoTrabajo.html";
                string strRutaPlantilla_CTS = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_CTS, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    //Llenando valores al PDF

                    String txtLaborado_1 = "";
                    String txtLaborado_2 = "";
                    String txtFinActualidad = "";
                    String fechaImpresion = "";
                    if (dtReporte.Rows[0]["Estado_Id"].ToString() == "01")
                    {
                        txtLaborado_1 = "Labora";
                        txtLaborado_2 = "hasta la";
                        txtFinActualidad = "actualidad";
                        fechaImpresion = DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy");
                    }
                    else
                    {
                        txtLaborado_1 = "Ha laborado";
                        txtLaborado_2 = "hasta el";
                        txtFinActualidad = Convert.ToDateTime(dtReporte.Rows[0][8]).ToString("dd/MM/yyyy");
                        fechaImpresion = Convert.ToDateTime(dtReporte.Rows[0][8]).ToString("dd 'de' MMMM 'de' yyyy");
                    }
                    String distritoEmpresa = dtReporte.Rows[0]["Dpto"].ToString();
                    distritoEmpresa= distritoEmpresa.Substring(0, 1).ToUpper() + distritoEmpresa.Substring(1).ToLower();
                                        
                    linea = linea.Replace("[_Empresa_]", dtReporte.Rows[0][2].ToString());
                    linea = linea.Replace("[_Trabajador_]", dtReporte.Rows[0][0].ToString());
                    linea = linea.Replace("[_txtLaborado_1_]", txtLaborado_1);
                    linea = linea.Replace("[_txtLaborado_2_]", txtLaborado_2);
                    linea = linea.Replace("[_NroDoc_]", dtReporte.Rows[0][10].ToString());
                    linea = linea.Replace("[_Cargo_]", dtReporte.Rows[0][1].ToString());
                    linea = linea.Replace("[_FecIngreso_]", Convert.ToDateTime(dtReporte.Rows[0][7]).ToString("dd/MM/yyyy"));
                    linea = linea.Replace("[_FecFin_]", txtFinActualidad);
                    linea = linea.Replace("[_Trabajador_]", dtReporte.Rows[0]["ApePaterno"].ToString());
                    linea = linea.Replace("[_FecImpresion_]", distritoEmpresa + " " + fechaImpresion);
                    linea = linea.Replace("[_RepLegal_]", dtReporte.Rows[0]["Rep"].ToString());
                    linea = linea.Replace("[_RucEmpresa_]", dtReporte.Rows[0]["Ruc"].ToString());
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //Parte superior izquierda
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                imgFirma.SetAbsolutePosition(110, 435); //Ubicación de Firma
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }
        }

        //Certificado de CTS a Banco
        public string Get_ImprimeBancoCTS_HTML(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String Reporte_Id = prms[0].ToString();
            String Usuario = prms[1].ToString();
            String Periodo_Id = prms[2].ToString();
            String Proceso_Id = prms[3].ToString();
            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();
            String rucEmpresa = ""; //Se obtiene al obtener la boleta desde la autenticación del usuario

            Int32 qt_envios = 0; //@004 I/F
            foreach (string Personal_Id in (object[])prms[4])
            {
                String nomFilePDF = String.Empty;
                if (fl_guardar_archivo == "1")
                {
                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    genFileBancoCTSPDF(Reporte_Id, Usuario, Periodo_Id, Personal_Id, Proceso_Id
                        , rucEmpresa
                        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);

                    if (retorno == false)
                    {
                        strPersonalSinEnviar += msg_retorno + "\n";
                        continue;
                    }

                    //Crea directorio donde se almacenan los archivos
                    String pathDocumentoPDF = ParametrosDA.FileServer_RutaDocumentos;
                    if (!System.IO.Directory.Exists(pathDocumentoPDF))
                    {
                        System.IO.Directory.CreateDirectory(pathDocumentoPDF);
                    }
                    String rutaArchivoPDF = Path.Combine(pathDocumentoPDF, out_nomFilePDF);
                    Byte[] FilePDF = Convert.FromBase64String(out_FilePDF_Array);

                    File.WriteAllBytes(rutaArchivoPDF, FilePDF);

                    nomFilePDF = out_nomFilePDF; //Se asigna nombre para enviarlo por correo
                    #endregion "Genera documento PDF"
                }

                DataTable dt_Email = new DataTable();
                #region "Obtiene Email del Personal"
                string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }
                #endregion "Obtiene Email del Personal"
                string email_per = dt_Email.Rows[0][0].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }
                
                #region "Inserta envío de documento y envía correo"
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string AsuntoCorreo = "", cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", Personal_Id);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", Proceso_Id);
                        cmd.Parameters.AddWithValue("@In_id_periodo", Periodo_Id);
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nomFilePDF);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);

                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                            AsuntoCorreo = dr.GetValue(4).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nomFilePDF;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = AsuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado de retiro de CTS" + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                #endregion "Inserta envío de documento y envía correo"
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
                //@004 F
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
        public void genFileBancoCTSPDF(String Reporte_Id, String Usuario, String Periodo_Id, String Personal_Id, String Proceso_Id
            , String rucEmpresa
            , out Boolean retorno, out String msg_retorno, out String out_FilePDF, out String out_nomFilePDF)
        {
            out_FilePDF = null;
            out_nomFilePDF = null;

            String cnxConnection = String.Empty;
            if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
            else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

            DataTable dt_Email = new DataTable();
            #region "Obtiene Email del Personal"
            string comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
            comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
            comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
            comando += " from Personal where Personal_Id=@Personal";
            using (SqlConnection cn = new SqlConnection(cnxConnection))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal", Personal_Id.ToString());
                    cn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                }
            }
            #endregion "Obtiene Email del Personal"
            string email_per = dt_Email.Rows[0][0].ToString();
            string Nro_Doc = dt_Email.Rows[0][1].ToString();
            string NomIniciales = dt_Email.Rows[0][2].ToString();
            string Nombre_Completo = dt_Email.Rows[0][3].ToString();
            if (email_per.Trim() == "")
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no tiene email configurado.";
                return;
            }

            //Genera PDF
            string nomFilePDF = string.Format("{0}{1}{2}.pdf", "CertificadoCTSBanco_", DateTime.Now.ToString("yyyyMMdd_HHmmss"), NomIniciales);
            try
            {
                DataTable dtBoleta = new DataTable();
                DataTable dtLogo = new DataTable();
                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_CTrabajo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@personal_id", Personal_Id);
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtBoleta); }
                    }
                }

                using (SqlConnection cn = new SqlConnection(cnxConnection))
                {
                    using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                    {
                        cmds.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                    }
                }

                #region "Genera documento PDF"
                #region "Obtiene plantilla HTML y reemplaza datos"
                string nombrePlantilla_HTML = "PlantillaBancoCTS.html";
                string strRutaPlantilla_CTS = ParametrosDA.FileServer_RutaPlantillas + nombrePlantilla_HTML;
                //Obtiene texto de Plantilla PDF
                System.Text.StringBuilder strPlantillaHTML = new System.Text.StringBuilder();
                FileStream stream = new FileStream(strRutaPlantilla_CTS, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    #region "Reemplaza valores de plantilla"
                    //Llenando valores al PDF
                    DateTime fecha = DateTime.Today;
                    linea = linea.Replace("[_FecImpresion_]", dtBoleta.Rows[0][4].ToString() + " " + String.Format("{0:D}", fecha));
                    linea = linea.Replace("[_Banco_]", dtBoleta.Rows[0]["Banco_CTS"].ToString());
                    linea = linea.Replace("[_Empresa_]", dtBoleta.Rows[0][2].ToString());
                    linea = linea.Replace("[_Ruc_]", dtBoleta.Rows[0][6].ToString());
                    linea = linea.Replace("[_Trabajador_]", dtBoleta.Rows[0][0].ToString());
                    linea = linea.Replace("[_NroDoc_]", dtBoleta.Rows[0][10].ToString());
                    linea = linea.Replace("[_Cargo_]", dtBoleta.Rows[0][1].ToString());
                    linea = linea.Replace("[_FecIngreso_]", Convert.ToDateTime(dtBoleta.Rows[0][7]).ToString("dd/MM/yyyy"));
                    linea = linea.Replace("[_FecFin_]", Convert.ToDateTime(dtBoleta.Rows[0][8]).ToString("dd/MM/yyyy"));
                    linea = linea.Replace("[NroCuenta_CTS]", dtBoleta.Rows[0]["NroCuenta_CTS"].ToString());
                    linea = linea.Replace("[_RepLegal_]", dtBoleta.Rows[0]["Rep"].ToString());
                    linea = linea.Replace("[_RucEmpresa_]", dtBoleta.Rows[0]["Ruc"].ToString());
                    #endregion "Reemplaza valores de plantilla"
                    strPlantillaHTML.Append(linea);
                }
                reader.Close();
                #endregion "Obtiene plantilla HTML y reemplaza datos"

                MemoryStream memoryStream = null;
                //Crea PDF
                Document document = new Document(PageSize.A4, 30.0F, 30.0F, 30.0F, 0.0F);
                memoryStream = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                //Agrega contraseña al PDF
                string nro_doc_personal = Nro_Doc;
                writer.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                document.Open();

                //Agrega texto de plantilla HTML
                HTMLWorker hw = new HTMLWorker(document);
                StringReader sr = new StringReader(strPlantillaHTML.ToString());
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                #region "Inserta logo empresa"
                Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                imgLogo.ScaleAbsolute(120, 40);
                imgLogo.SetAbsolutePosition(25, 785); //Parte superior izquierda
                document.Add(imgLogo);
                #endregion "Inserta logo empresa"

                PdfContentByte canvas = writer.DirectContentUnder;
                canvas.SaveState(); //Para que agregue las imágenes encima de otro (tipo transparente)

                #region "Inserta imagen firma empleador"
                Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                imgFirma.ScaleAbsolute(120, 40);
                imgFirma.SetAbsolutePosition(110, 420); //Ubicación de Firma
                canvas.AddImage(imgFirma);
                #endregion "Inserta imagen firma empleador"

                #region "Agrega imagen de fondo transparente"
                Byte[] byte_imgLogoFondo = byte_imgLogo;
                iTextSharp.text.Image imgLogoFondo = iTextSharp.text.Image.GetInstance(byte_imgLogoFondo);

                imgLogoFondo.ScaleAbsoluteWidth(350F);
                imgLogoFondo.ScaleAbsoluteHeight(350F);

                float positionY = (document.PageSize.Top / 2) - (imgLogoFondo.Width / 2);
                float positionX = (document.PageSize.Right / 2) - (imgLogoFondo.Height / 2);
                imgLogoFondo.SetAbsolutePosition(positionX - 100, positionY - 100);

                PdfGState state = new PdfGState();
                state.FillOpacity = 0.10f;
                canvas.SetGState(state);
                canvas.AddImage(imgLogoFondo);
                #endregion "Agrega imagen de fondo transparente"

                canvas.RestoreState();

                document.Close();

                Byte[] FilePDFArray = memoryStream.ToArray();
                memoryStream.Close();
                #endregion "Genera documento PDF"

                retorno = true;
                msg_retorno = "";
                out_FilePDF = Convert.ToBase64String(FilePDFArray);
                out_nomFilePDF = nomFilePDF;
            }
            catch (Exception ex)
            {
                retorno = false;
                msg_retorno = "- " + Nombre_Completo + " no se pudo generar el documento: " + ex.Message;
            }
        }

        //Certificado de Liquida beneficios
        public string Get_ImprimeLiquida2(object strParametros, String encryptRUC)
        {
            string rpt = "", strPersonalEnviado = "", strPersonalSinEnviar = "";
            object[] prms = new object[] { };
            prms = (object[])strParametros;

            String fl_dolares = prms[9].ToString();
            String fl_add_total_USD = prms[10].ToString();
            String Periodo_Id_Desde = prms[11].ToString();
            String fl_guardar_archivo = prms[12].ToString();

            string comando = "";
            Int32 qt_envios = 0; //@004 I/F
            foreach (object personalid in (object[])prms[4])
            {
                DataTable dt_Email = new DataTable();
                comando = "select case when isnull(email_personal,'')!='' and email_personal!=email then + (email_personal+'; ') else '' end + isnull(email,'') as [email_personal],";
                comando += " Nro_Doc, LEFT(Apellido_Paterno, 1)+LEFT(Apellido_Materno, 1)+LEFT(Nombres, 1) as [Iniciales]";
                comando += ", (Apellido_Paterno+' '+Apellido_Materno+' '+Nombres) as [Nombre_Completo] ";
                comando += " from Personal where Personal_Id=@Personal";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal", personalid.ToString());
                        cn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Email); }
                    }
                }

                string email_per = dt_Email.Rows[0][0].ToString();
                string Nro_Doc = dt_Email.Rows[0][1].ToString();
                string NomIniciales = dt_Email.Rows[0][2].ToString();
                string Nombre_Completo = dt_Email.Rows[0][3].ToString();
                if (email_per.Trim() == "")
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no tiene email configurado.\n";
                    continue;
                }

                //Genera Boleta PDF
                string rptFecha = Get_Fecha();
                string nuevoDocumento = "Liquidacion_" + rptFecha + NomIniciales + ".pdf";
                string asuntoCorreo = "DOCUMENTO: CERTIFICADO DE RETIRO DE CTS " + prms[8].ToString();
                string nombrePlantillas = "PlantillaLiquida2.pdf";
                string ejercicio = prms[6].ToString();

                try
                {
                    DataTable dtLiquidaBeneSociales = new DataTable();
                    DataTable dtBoleta = new DataTable();

                    DataTable dtLogo = new DataTable();
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand("PROC_SCIRE1_LISTAR_REPORTE", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@cReporte", "0041");
                            cmd.Parameters.AddWithValue("@Usuario", "000138");
                            cmd.Parameters.AddWithValue("@cPeriodo", prms[2].ToString());
                            cmd.Parameters.AddWithValue("@cProceso", "08");
                            cmd.Parameters.AddWithValue("@Personal", personalid.ToString());
                             
                            cn.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtLiquidaBeneSociales); }
                        }


                        //dtBoleta= SqlHelper.ExecuteDataTable(Conex.CadCon(), "PROC_SCIRE1_LISTAR_REPORTE"
                        //                    , "0041", "000138", prms[2].ToString(), "08", personalid.ToString());


                    }


                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand("Reporte_Boleta", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Personal", personalid.ToString());
                            cmd.Parameters.AddWithValue("@cPeriodo", prms[2].ToString());
                            cmd.Parameters.AddWithValue("@cProceso", "08");
                          

                            cn.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dtBoleta); }
                        }

                    }


                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {

                        using (SqlCommand cmds = new SqlCommand("SP_LOGO_FIRMA", cn))
                        {
                            cmds.CommandType = CommandType.StoredProcedure;
                            cn.Open();
                            using (SqlDataAdapter dat = new SqlDataAdapter(cmds)) { dat.Fill(dtLogo); }
                        }
                    }


                    //RUTA DE PLANTILLAS
                    string pdfTemplate = ParametrosDA.FileServer_RutaPlantillas + nombrePlantillas;
                    //VALIDAR SI DIRECTORIO DONDE SE ALMACENAN LOS ARCHIVOS EXISTEN
                    if (!System.IO.Directory.Exists(ParametrosDA.FileServer_RutaDocumentos))
                    {
                        System.IO.Directory.CreateDirectory(ParametrosDA.FileServer_RutaDocumentos);
                    }
                    PdfReader pdfReader = new PdfReader(pdfTemplate);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(ParametrosDA.FileServer_RutaDocumentos + nuevoDocumento, FileMode.Create));
                    //AGREGAR CONTRASEÑA A LOS PDF
                    string nro_doc_personal = Nro_Doc;
                    pdfStamper.SetEncryption(true, nro_doc_personal, nro_doc_personal, PdfWriter.AllowCopy | PdfWriter.AllowPrinting);

                    //Inserta imagen
                    PdfContentByte content = pdfStamper.GetOverContent(1);
                    PdfContentByte cb = pdfStamper.GetOverContent(1);


                    Byte[] byte_imgLogo = (Byte[])(dtLogo.Rows[0]["Logo"]);
                    iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(byte_imgLogo);
                    imgLogo.ScaleAbsolute(120, 40);
                    imgLogo.SetAbsolutePosition(20f, 740f); //1era boleta
                    content.AddImage(imgLogo);



                    //imgLogo.SetAbsolutePosition(20, 370); //2da boleta
                    //content.AddImage(imgLogo);

                    Byte[] byte_imgFirma = (Byte[])(dtLogo.Rows[0]["Firma"]);
                    iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(byte_imgFirma);
                    imgFirma.ScaleAbsolute(120, 40);
                    imgFirma.SetAbsolutePosition(85f, 85f); //1era boleta
                    content.AddImage(imgFirma);


                    imgLogo.ScaleAbsoluteWidth(350F);
                    imgLogo.ScaleAbsoluteHeight(350F);

                    float positionY = (pdfStamper.Writer.PageSize.Top / 2) - (imgLogo.Width / 2);
                    float positionX = (pdfStamper.Writer.PageSize.Right / 2) - (imgLogo.Height / 2);


                    imgLogo.SetAbsolutePosition(positionX - 100, positionY - 100);


                    PdfGState state = new PdfGState();
                    state.FillOpacity = 0.20f;
                    cb.SetGState(state);
                    cb.AddImage(imgLogo);


                    //Llenando valores al PDF
                    //StringBuilder cabecera = new StringBuilder();
                    //cabecera.Append("Que a don (doña) : " + dtBoleta.Rows[0][4] + " con D.N.I. N°  " + dtBoleta.Rows[0][5]);
                    //cabecera.Append(",  se le ha retenido por concepto ");
                    //cabecera.Append("del Impuesto a la Renta de 5ta. Categoría, correspondiente al ejercicio gravable ");
                    //cabecera.Append(ejercicio + "(" + dtBoleta.Rows[0][13] + ")");

                    //pdfStamper.AcroFields.SetField("tbCabecera", cabecera.ToString());
                    DateTime fecha = DateTime.Today;
                    //primera parte
                    pdfStamper.AcroFields.SetField("txtnombre", dtLiquidaBeneSociales.Rows[0]["TRABAJADOR"].ToString());
                    pdfStamper.AcroFields.SetField("txtfechaI", String.Format("{0:d}", DateTime.Parse(dtLiquidaBeneSociales.Rows[0]["FINGRESO"].ToString()))  );
                    pdfStamper.AcroFields.SetField("txtfechaF", String.Format("{0:d}", DateTime.Parse(dtLiquidaBeneSociales.Rows[0]["FCESE"].ToString())));
                    pdfStamper.AcroFields.SetField("txtcargo", dtLiquidaBeneSociales.Rows[0]["CARGO"].ToString());
                    pdfStamper.AcroFields.SetField("txtservicio", dtLiquidaBeneSociales.Rows[0]["TIEMPOSERVICIO"].ToString());
                    pdfStamper.AcroFields.SetField("txtmotivo", dtLiquidaBeneSociales.Rows[0]["MOTIVOCESE"].ToString());

                    // segunda parte
                    //CTS
                    pdfStamper.AcroFields.SetField("txtCRP", dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPS", dtLiquidaBeneSociales.Rows[0]["STIEMPOCTS"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPC", dtLiquidaBeneSociales.Rows[0]["COMVENCTS"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPR", dtLiquidaBeneSociales.Rows[0]["REFRIGERIOCTS"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPBN", dtLiquidaBeneSociales.Rows[0]["BONNOCTCTS"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPBP", dtLiquidaBeneSociales.Rows[0]["BONPRODCTS"].ToString());
                    pdfStamper.AcroFields.SetField("txtCPBT", dtLiquidaBeneSociales.Rows[0]["BONIFTRAB"].ToString());
                    pdfStamper.AcroFields.SetField("txtCGSP", dtLiquidaBeneSociales.Rows[0]["PROMGRATI"].ToString());
                    float totalCTS = 0;
                    totalCTS = float.Parse(dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["STIEMPOCTS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["COMVENCTS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["REFRIGERIOCTS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["BONNOCTCTS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["BONPRODCTS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["BONIFTRAB"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["PROMGRATI"].ToString());

                    pdfStamper.AcroFields.SetField("txtTotalC", totalCTS.ToString());

                    //vacaciones
                    pdfStamper.AcroFields.SetField("txtVRP", dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPS", dtLiquidaBeneSociales.Rows[0]["PROMHE"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPC", dtLiquidaBeneSociales.Rows[0]["PROMCV"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPR", dtLiquidaBeneSociales.Rows[0]["REFRIGERIO"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPBN", dtLiquidaBeneSociales.Rows[0]["PROMBN"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPBP", dtLiquidaBeneSociales.Rows[0]["PROMBP"].ToString());
                    pdfStamper.AcroFields.SetField("txtVPBT", dtLiquidaBeneSociales.Rows[0]["BONIFTRAB"].ToString());

                    float totalvac = 0;
                    totalvac = float.Parse(dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["PROMHE"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["PROMCV"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["REFRIGERIO"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["PROMBN"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["PROMBP"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["BONIFTRAB"].ToString());

                    pdfStamper.AcroFields.SetField("txtTotalV", totalvac.ToString());

                    //gratificacion
                    pdfStamper.AcroFields.SetField("txtGRP", dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString());
                    pdfStamper.AcroFields.SetField("txtGPS", dtLiquidaBeneSociales.Rows[0]["LIQPROMSOBRE"].ToString());
                    pdfStamper.AcroFields.SetField("txtGPC", dtLiquidaBeneSociales.Rows[0]["LIQPROMCOMIS"].ToString());
                    pdfStamper.AcroFields.SetField("txtGPR", dtLiquidaBeneSociales.Rows[0]["LIQREFRIGERIO"].ToString());
                    pdfStamper.AcroFields.SetField("txtGPBN", dtLiquidaBeneSociales.Rows[0]["LIQBONIFTRAB"].ToString());
                    float totalgat = 0;
                    totalgat = float.Parse(dtLiquidaBeneSociales.Rows[0]["REMPERMANENTE"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["LIQPROMSOBRE"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["LIQPROMCOMIS"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["LIQREFRIGERIO"].ToString()) +
                        float.Parse(dtLiquidaBeneSociales.Rows[0]["LIQBONIFTRAB"].ToString());

                    pdfStamper.AcroFields.SetField("txtTotalG", totalgat.ToString());
                    float b1, b2, b3;

                    if (dtBoleta.Rows.Count > 0)
                    {
                        b1 = 0;
                        b2 = 0;
                        b3 = 0;
                        foreach (DataRow item in dtBoleta.Rows)
                        {
                            pdfStamper.AcroFields.SetField("txtb1", item["Concepto_Id1"].ToString() +"                                                                        "+ item["Valor1"].ToString());
                            b1 = b1 +float.Parse( item["Valor1"].ToString());
                            pdfStamper.AcroFields.SetField("txtb2", item["Concepto_Id2"].ToString() + "                                                                        " + item["Valor2"].ToString());
                            b2 = b2 + float.Parse(item["Valor2"].ToString());
                            pdfStamper.AcroFields.SetField("txtb3", item["Concepto_Id3"].ToString() + "                                                                        " + item["Valor3"].ToString());
                            b3 = b3 + float.Parse(item["Valor3"].ToString());
                        }
                        //totales
                        pdfStamper.AcroFields.SetField("txtTotalIngreso", b1.ToString());
                        pdfStamper.AcroFields.SetField("txtTotalDeducciones", b2.ToString());
                        pdfStamper.AcroFields.SetField("txtTotalNeto", b3.ToString());
                    }
                    else
                    {
                        pdfStamper.AcroFields.SetField("txtb1", "");
                        pdfStamper.AcroFields.SetField("txtb2","");
                        pdfStamper.AcroFields.SetField("txtb3", "");
                        //totales
                        pdfStamper.AcroFields.SetField("txtTotalIngreso","0.00");
                        pdfStamper.AcroFields.SetField("txtTotalDeducciones", "0.00");
                        pdfStamper.AcroFields.SetField("txtTotalNeto", "0.00");
                    }
                   


                    // ultima parte

                    pdfStamper.AcroFields.SetField("txtdni", dtLiquidaBeneSociales.Rows[0]["DNI"].ToString());
                    pdfStamper.AcroFields.SetField("txtempresa2", dtLogo.Rows[0]["descripcion"].ToString());
                    pdfStamper.AcroFields.SetField("txtimpresion",   "Lima " + String.Format("{0:D}", fecha));

                    //DateTime fecha = DateTime.Parse(dtBoleta.Rows[0][1].ToString());
                    //pdfStamper.AcroFields.SetField("tbFecha", "LIMA" + " " + String.Format("{0:D}", fecha));
                    //pdfStamper.AcroFields.SetField("tbRepresentante", dtBoleta.Rows[0][11].ToString());
                    //pdfStamper.AcroFields.SetField("tbSueldo", Decimal.Parse(dtBoleta.Rows[0][6].ToString()).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbRemuneracion", Decimal.Parse(dtBoleta.Rows[0][6].ToString()).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbDeduccion", Decimal.Parse(dtBoleta.Rows[0][8].ToString()).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbRenta", (Decimal.Parse(dtBoleta.Rows[0][6].ToString()) - Decimal.Parse(dtBoleta.Rows[0][8].ToString())).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbImpuesto", Decimal.Parse(dtBoleta.Rows[0][9].ToString()).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbCredito", Decimal.Parse(dtBoleta.Rows[0][10].ToString()).ToString("###,##0.00"));
                    //pdfStamper.AcroFields.SetField("tbImpuestoReten", Decimal.Parse(dtBoleta.Rows[0][16].ToString()).ToString("###,##0.00"));

                    pdfStamper.FormFlattening = false;
                    pdfStamper.Close();

                }
                catch (Exception ex)
                {
                    strPersonalSinEnviar += "- " + Nombre_Completo + " no se pudo generar el documento" + ex.Message + ".\n";
                    continue;
                }

                //Inserta envío de documento
                DateTime fecha_reg = DateTime.Today;
                int cod_envio = 0;
                string cuerpoCorreo = "", copiaCorreo = "", copiaOcultaCorreo = "";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ins_envio_doc_electronicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@In_id_persona", personalid);
                        cmd.Parameters.AddWithValue("@In_id_documento", prms[7].ToString());
                        cmd.Parameters.AddWithValue("@In_id_proceso", prms[3].ToString());
                        cmd.Parameters.AddWithValue("@In_id_periodo", prms[2].ToString());
                        cmd.Parameters.AddWithValue("@In_fe_envio", fecha_reg.ToShortDateString());
                        cmd.Parameters.AddWithValue("@In_fe_recepcion", fecha_reg);
                        cmd.Parameters.AddWithValue("@In_fl_inactivo", 0);
                        cmd.Parameters.AddWithValue("@vi_no_documento", nuevoDocumento);
                        cmd.Parameters.AddWithValue("@vi_encrypt_RUC", encryptRUC);
                        cmd.Parameters.AddWithValue("@vi_fl_guardar_archivo", fl_guardar_archivo);
                        cmd.Parameters.AddWithValue("@vi_fl_imp_usd", fl_dolares);
                        cmd.Parameters.AddWithValue("@vi_fl_tot_usd", fl_add_total_USD);
                        cmd.Parameters.AddWithValue("@vi_id_periodo_desde", Periodo_Id_Desde);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            cod_envio = int.Parse(dr.GetValue(0).ToString());
                            cuerpoCorreo = dr.GetValue(5).ToString();
                            copiaCorreo = dr.GetValue(2).ToString();
                            copiaOcultaCorreo = dr.GetValue(3).ToString();
                        }
                    }
                }
                string[] oParamEnvio = new string[9];
                oParamEnvio[0] = nuevoDocumento;
                oParamEnvio[1] = email_per;
                oParamEnvio[2] = asuntoCorreo;
                oParamEnvio[3] = Nombre_Completo;
                oParamEnvio[4] = cod_envio.ToString();
                oParamEnvio[5] = "Certificado de retiro de CTS" + prms[8].ToString();
                oParamEnvio[6] = cuerpoCorreo;
                oParamEnvio[7] = copiaCorreo;
                oParamEnvio[8] = copiaOcultaCorreo;
                string rptaCorreo = Get_EnvioCorreo(oParamEnvio);
                if (rptaCorreo == "") { strPersonalEnviado += "- " + Nombre_Completo + " OK enviado correctamente.\n"; }
                
                //@004 I
                qt_envios++;
                if (qt_envios >= qt_corte_correo_delay)
                {
                    System.Threading.Thread.Sleep(qt_segundos_delay * 1000); //Milisegundos
                    qt_envios = 0;
                }
            }
            rpt = strPersonalSinEnviar;
            return rpt;
        }
                       
        public string Get_Fecha() {
            DateTime hoy = DateTime.UtcNow;
            string fecha = hoy.ToString("yyyyMMdd");
            string hora = hoy.ToString("HHmmss");
            return fecha + hora;
        } 

        public string Get_EnvioCorreo(string[] oParametros)
        {
            string rpt = "";
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            string[] Arr_Correos = oParametros[1].Split(';');
            foreach(string para in Arr_Correos)
            {
                if (para.Trim() != "") { msg.To.Add(para.Trim()); }
            }

            string[] Arr_CorreosCopia= oParametros[7].Split(';');
            foreach (string copia in Arr_CorreosCopia)
            {
                if (copia.Trim() != "") { msg.CC.Add(copia.Trim()); }
            }

            string[] Arr_CorreosCopiaOculta = oParametros[8].Split(';');
            foreach (string copiaOculta in Arr_CorreosCopiaOculta)
            {
                if (copiaOculta.Trim() != "") { msg.Bcc.Add(copiaOculta.Trim()); }
            }

            CompaniaSMTP oCompaniaSMTP = ParametrosDA.getCompania_SMTP();
            msg.From = new System.Net.Mail.MailAddress(oCompaniaSMTP.MailAddress, oCompaniaSMTP.DisplayName, System.Text.Encoding.UTF8);
            msg.Subject = oParametros[2].ToString();
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = oParametros[6];

            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            //Aquí es donde se hace lo especial
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(oCompaniaSMTP.Usuario, oCompaniaSMTP.Clave);
            client.Port = oCompaniaSMTP.Port;
            client.Host = oCompaniaSMTP.Host;
            client.EnableSsl = oCompaniaSMTP.SSL;

            //AddHandler client.SendCompleted, AddressOf SendCompletedCallback
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            List<object> obj = new List<object>();
            obj.Add(msg);
            obj.Add(oParametros[4].ToString());
            object userState = obj;
            try
            {
                client.SendAsync(msg, userState);
                rpt = "";
            }
            catch(Exception ex)
            {
                rpt = ex.Message;
            }
            return rpt;
        }

        static  bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            List<object> obj = new List<object>();
            obj = (List<object>)e.UserState;
            MailMessage mail = (MailMessage)obj[0];
            string codEnvio = obj[1].ToString();

            string no_asunto = mail.Subject;
            string Email_Destino = mail.To[0].ToString(); //Email del personal enviado
            string Error_Envio = "";
            if (e.Error != null)
            {
                //Console.WriteLine("Error {1} ocurrido mientras se enviaba el correo [{0}] ", no_asunto, e.Error.ToString());
                mailSent = false;
                try
                {
                    Error_Envio = "Error al enviar correo: " + e.Error.ToString();
                }
                catch (Exception ex) { Error_Envio = "Error al enviar correo: " + ex.Message.ToString(); }
            }
            else if (e.Cancelled)
            {
                mailSent = false;
                //Console.WriteLine("Envio cancelado de correo con asunto [{0}].", no_asunto);
                Error_Envio = "Correo cancelado";
            }
            else
            {
                //Console.WriteLine("Mensaje [{1}] enviado.", no_asunto);
                mailSent = true;
            }
            if (mailSent == false)
            {
                //Graba error de envio de correo 
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("update tbl_envio_doc_electronicos set fl_error_envio='1',no_correo_enviado='', no_error_envio=@no_error_envio where id_envio=@id_envio", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@no_error_envio", Error_Envio);
                        cmd.Parameters.AddWithValue("@id_envio", codEnvio);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Signs a PDF document using iTextSharp library
        /// </summary>
        /// <param name=”sourceDocument”>The path of the source pdf document which is to be signed</param>
        /// <param name=”destinationPath”>The path at which the signed pdf document should be generated</param>
        /// <param name=”privateKeyStream”>A Stream containing the private/public key in .pfx format which would be used to sign the document</param>
        /// <param name=”keyPassword”>The password for the private key</param>
        /// <param name=”reason”>String describing the reason for signing, would be embedded as part of the signature</param>
        /// <param name=”location”>Location where the document was signed, would be embedded as part of the signature</param>
        public static void signPdfFile(string sourceDocument, string destinationPath, String sourcePFX, string keyPassword, string reason, string location)
        {
            FileStream fileStreamPFX = new FileStream(sourcePFX, FileMode.Open);

            Org.BouncyCastle.Pkcs.Pkcs12Store pk12 = new Org.BouncyCastle.Pkcs.Pkcs12Store(fileStreamPFX, keyPassword.ToCharArray());

            fileStreamPFX.Dispose();

            //then Iterate throught certificate entries to find the private key entry
            string alias = null;
            foreach (string tAlias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(tAlias))
                {
                    alias = tAlias;
                    break;
                }
            }
            var pk = pk12.GetKey(alias).Key;
            // reader and stamper
            PdfReader reader = new PdfReader(sourceDocument);
            using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0'))
                {
                    // appearance
                    PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                    //appearance.Image = new iTextSharp.text.pdf.PdfImage();
                    appearance.Reason = reason;
                    appearance.Location = location;
                    appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, "Icsi - Vendor");
                    // digital signature
                    iTextSharp.text.pdf.security.IExternalSignature es = new iTextSharp.text.pdf.security.PrivateKeySignature(pk, "SHA-256");
                    iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, es, new X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);

                    stamper.Close();
                }
            }
        }

        /// <summary>
        /// Signs a PDF document using iTextSharp library
        /// </summary>
        /// <param name=”sourceByteDocument”>The path of the source pdf document which is to be signed</param>
        /// <param name=”destinationPath”>The path at which the signed pdf document should be generated</param>
        /// <param name=”privateKeyStream”>A Stream containing the private/public key in .pfx format which would be used to sign the document</param>
        /// <param name=”keyPassword”>The password for the private key</param>
        /// <param name=”reason”>String describing the reason for signing, would be embedded as part of the signature</param>
        /// <param name=”location”>Location where the document was signed, would be embedded as part of the signature</param>
        public static void signPdfFile(Byte[] sourceByteDocument, string destinationPath, String sourcePFX, string keyPassword, string reason, string location)
        {
            FileStream fileStreamPFX = new FileStream(sourcePFX, FileMode.Open);

            Org.BouncyCastle.Pkcs.Pkcs12Store pk12 = new Org.BouncyCastle.Pkcs.Pkcs12Store(fileStreamPFX, keyPassword.ToCharArray());

            fileStreamPFX.Dispose();

            //then Iterate throught certificate entries to find the private key entry
            string alias = null;
            foreach (string tAlias in pk12.Aliases)
            {
                if (pk12.IsKeyEntry(tAlias))
                {
                    alias = tAlias;
                    break;
                }
            }
            var pk = pk12.GetKey(alias).Key;
            // reader and stamper
            //byte[] clavePDF = System.Text.Encoding.UTF8.GetBytes("76027228");
            //PdfReader reader = new PdfReader(sourceByteDocument, clavePDF);
            PdfReader reader = new PdfReader(sourceByteDocument);
            using (FileStream fout = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite))
            {
                PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0');
                //using (PdfStamper stamper = PdfStamper.CreateSignature(reader, fout, '\0'))
                //{
                // appearance
                    PdfSignatureAppearance appearance = stamper.SignatureAppearance;
                    //appearance.Image = new iTextSharp.text.pdf.PdfImage();
                    appearance.Reason = reason;
                    appearance.Location = location;
                    appearance.SetVisibleSignature(new iTextSharp.text.Rectangle(20, 10, 170, 60), 1, "Icsi - Vendor");
                    // digital signature
                    iTextSharp.text.pdf.security.IExternalSignature es = new iTextSharp.text.pdf.security.PrivateKeySignature(pk, "SHA-256");
                    iTextSharp.text.pdf.security.MakeSignature.SignDetached(appearance, es, new X509Certificate[] { pk12.GetCertificate(alias).Certificate }, null, null, null, 0, iTextSharp.text.pdf.security.CryptoStandard.CMS);

                    stamper.Close();
                reader.Close();
                fout.Close();
                //}
            }
        }

        /// <summary>
        /// Verifies the signature of a prevously signed PDF document using the specified public key
        /// </summary>
        /// <param name=”pdfFile”>a Previously signed pdf document</param>
        /// <param name=”publicKeyStream”>Public key to be used to verify the signature in .cer format</param>
        /// <exception cref=”System.InvalidOperationException”>Throw System.InvalidOperationException if the document is not signed or the signature could not be verified</exception>
        public static void verifyPdfSignature(string pdfFile, Stream publicKeyStream)
        {
            var parser = new X509CertificateParser();
            var certificate = parser.ReadCertificate(publicKeyStream);
            publicKeyStream.Dispose();

            PdfReader reader = new PdfReader(pdfFile);
            AcroFields af = reader.AcroFields;
            var names = af.GetSignatureNames();

            if (names.Count == 0)
            {
                throw new InvalidOperationException("No Signature present in pdf file.");
            }

            foreach (string name in names)
            {
                if (!af.SignatureCoversWholeDocument(name))
                {
                    throw new InvalidOperationException(string.Format("The signature: {0} does not covers the whole document.", name));
                }

                iTextSharp.text.pdf.security.PdfPKCS7 pk = af.VerifySignature(name);
                var cal = pk.SignDate;
                var pkc = pk.Certificates;

                if (!pk.Verify())
                {
                    throw new InvalidOperationException("The signature could not be verified.");
                }
                if (!pk.VerifyTimestampImprint())
                {
                    throw new InvalidOperationException("The signature timestamp could not be verified.");
                }

                //Object[] fails =
                IList<iTextSharp.text.pdf.security.VerificationException> fails = iTextSharp.text.pdf.security.CertificateVerification.VerifyCertificates(pkc, new X509Certificate[] { certificate }, null, cal);
                if (fails != null)
                {
                    throw new InvalidOperationException("The file is not signed using the specified key - pair.");
                }
            }
        }

        private StringBuilder ocultarEtiqueta(StringBuilder bodyHTML, string tipo, string id)
        {
            string _str1 = bodyHTML.ToString().Substring(bodyHTML.ToString().IndexOf("<" + tipo + " id=\"" + id + "\""));
            string _str2 = _str1.Substring(0, _str1.IndexOf("" + tipo + ">") + 5);
            return bodyHTML.Replace(_str2, "");
        }
    }

}
