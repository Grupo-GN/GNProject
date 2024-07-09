using CAPA_DATOS;
using CAPA_DATOS.oRRHH;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.RRHH
{
    public partial class GenDocumentoOnline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string token_envio = "";
                string encryptRUC = "";
                DateTime fecha = DateTime.UtcNow;
                if (Request.QueryString["c"] == null)
                {
                    lblMensaje.Text = "No se pudo procesar su solicitud. Código inválido. Nulos";
                    lblMensaje.ForeColor = Color.Red;
                }
                else
                {
                    token_envio = Request.QueryString["c"].ToString();
                    //encryptRUC => Desde la bandeja viene vacío, desde el correo viene encriptado
                    encryptRUC = (Request.QueryString["r"] == null ? "" : Request.QueryString["r"].ToString());

                    String rucEmpresa = "";
                    if (encryptRUC != "")
                    {
                        try
                        {
                            rucEmpresa = Encryptar.Desencripta(encryptRUC);
                        }
                        catch (Exception ex)
                        {
                            lblMensaje.Text = "No se pudo procesar su solicitud. Código inválido." + ex.Message;
                            lblMensaje.ForeColor = Color.Red;
                            return;
                        }
                    }

                    String cnxConnection = String.Empty;
                    if (String.IsNullOrEmpty(rucEmpresa)) { cnxConnection = Conex.CadCon_String(); }
                    else { cnxConnection = Conex.CadCon_String(rucEmpresa); }

                    DataTable dt_Envio = new DataTable();
                    #region "Obtiene datos del envío"
                    string comando = "select d.id_persona, d.id_documento, d.id_proceso, d.id_periodo";
                    comando += " , d.fl_imp_usd, d.fl_tot_usd, d.id_periodo_desde";
                    comando += " , m.Ejercicio_Id";
                    comando += " from tbl_envio_doc_electronicos d";
                    comando += " inner join Periodo p on p.Periodo_Id = d.id_periodo";
                    comando += " inner join Mes m on m.Mes_Id = p.Mes_Id";
                    comando += " where d.token_envio = @TokenEnvio";

                    using (SqlConnection cn = new SqlConnection(cnxConnection))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@TokenEnvio", token_envio);
                            cn.Open();
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd)) { da.Fill(dt_Envio); }
                        }
                    }
                    #endregion "Obtiene datos del envío"
                    if (dt_Envio.Rows.Count <= 0)
                    {
                        lblMensaje.Text = "No se pudo procesar su solicitud. Documento no existe.";
                        lblMensaje.ForeColor = Color.Red;
                        return;
                    }
                    string Personal_Id = dt_Envio.Rows[0]["id_persona"].ToString();
                    string Id_Documento = dt_Envio.Rows[0]["id_documento"].ToString();
                    string Proceso_Id = dt_Envio.Rows[0]["id_proceso"].ToString();
                    string Periodo_Id = dt_Envio.Rows[0]["id_periodo"].ToString();
                    string fl_dolares = (Convert.ToBoolean(dt_Envio.Rows[0]["fl_imp_usd"]) == true ? "1" : "0");
                    string fl_add_total_USD = (Convert.ToBoolean(dt_Envio.Rows[0]["fl_tot_usd"]) == true ? "1" : "0");
                    string Periodo_Id_Desde = dt_Envio.Rows[0]["id_periodo_desde"].ToString();
                    string Ejercicio_Id = dt_Envio.Rows[0]["Ejercicio_Id"].ToString();

                    #region "Genera documento PDF"
                    Boolean retorno = false; String msg_retorno; String out_FilePDF_Array; String out_nomFilePDF;

                    if (Id_Documento == "BP")
                    {
                        controllerDocumentoElectronico.getinstance().genFileBoletaPDF(Periodo_Id, Personal_Id, Proceso_Id
                            , fl_dolares, fl_add_total_USD, Periodo_Id_Desde
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    else if (Id_Documento == "CTS")
                    {
                        controllerDocumentoElectronico.getinstance().genFileCTSPDF("0002", "000001", Periodo_Id, Personal_Id, Proceso_Id
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    else if (Id_Documento == "CUTIL")
                    {
                        controllerDocumentoElectronico.getinstance().genFileUtilidadPDF("0003", "000001", Periodo_Id, Personal_Id, Proceso_Id
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    else if (Id_Documento == "CQTA")
                    {
                        controllerDocumentoElectronico.getinstance().genFileQuintaPDF("0004", "000001", Ejercicio_Id, Periodo_Id, Personal_Id, Proceso_Id
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    else if (Id_Documento == "CBC")
                    {
                        controllerDocumentoElectronico.getinstance().genFileBancoCTSPDF("", "", Periodo_Id, Personal_Id, Proceso_Id
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    else if (Id_Documento == "CT")
                    {
                        controllerDocumentoElectronico.getinstance().genFileCertTrabajoPDF("", "", Periodo_Id, Personal_Id, Proceso_Id
                            , rucEmpresa
                            , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    }
                    //////PENDIENTE DE DESARROLLO
                    //////else if (Id_Documento == "CL2")
                    //////{
                    //////    controllerDocumentoElectronico.getinstance().genFileCertLiquida2PDF("", "", Periodo_Id, Personal_Id, Proceso_Id
                    //////        , rucEmpresa
                    //////        , out retorno, out msg_retorno, out out_FilePDF_Array, out out_nomFilePDF);
                    //////}
                    else
                    {
                        lblMensaje.Text = "Documento inválido.";
                        lblMensaje.ForeColor = Color.Red;
                        return;
                    }
                    #endregion "Genera documento PDF"

                    String filename = out_nomFilePDF;
                    Byte[] FilePDF_Array = Convert.FromBase64String(out_FilePDF_Array);

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "inline; filename=" + filename);
                    //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

                    HttpContext.Current.Response.BinaryWrite(FilePDF_Array);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}