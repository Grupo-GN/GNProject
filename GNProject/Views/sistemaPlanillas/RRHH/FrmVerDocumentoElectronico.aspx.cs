using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.RRHH
{
    public partial class FrmVerDocumentoElectronico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nomDocumento = "";
            if (!Page.IsPostBack)
            {
                string token_envio = "";
                string encryptRUC = "";
                DateTime fecha = DateTime.UtcNow;
                if (Request.QueryString["c"] == null || Request.QueryString["r"] == null)
                {
                    lblMensaje.Text = "No se pudo procesar su solicitud. Código inválido. Nulos";
                    lblMensaje.ForeColor = Color.Red;
                }
                else
                {
                    token_envio = Request.QueryString["c"].ToString();
                    encryptRUC = Request.QueryString["r"].ToString();
                    String rucEmpresa = "";
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

                    if (rucEmpresa != "")
                    {
                        Int32 retorno = 0; String msg_retorno = "";
                        nomDocumento = Get_Respuesta(token_envio, rucEmpresa, fecha, out retorno, out msg_retorno);
                        if (retorno == -3) /*Documento no existe*/
                        {
                            Response.Redirect("GenDocumentoOnline.aspx?c=" + token_envio + "&r=" + encryptRUC);
                        }
                        else if (retorno <= 0)
                        {
                            lblMensaje.Text = msg_retorno;
                            lblMensaje.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblMensaje.Text = msg_retorno;
                            lblMensaje.ForeColor = Color.DarkBlue;

                            String virtualServer_RutaDocumentos = ConfigurationManager.AppSettings["RutaServidor"].ToString()
                                + ConfigurationManager.AppSettings["FileServerPath"].ToString().Replace("{RUC}", rucEmpresa).Replace("~/", "")
                                + ConfigurationManager.AppSettings["RutaDocumentos"].ToString();

                            Response.Redirect(virtualServer_RutaDocumentos + nomDocumento);
                        }
                    }
                }
            }
        }
        private String Get_Respuesta(string token_envio, String rucEmpresa, DateTime fecha, out Int32 retorno, out String msg_retorno)
        {
            retorno = 0; msg_retorno = "";

            string nomDocumento = "";

            string comando = "if not exists(select * from tbl_envio_doc_electronicos where token_envio = @token_envio)";
            comando += " begin";
            comando += " select '' as [no_documento];";
            comando += " return;";
            comando += " end;";
            comando += "update tbl_envio_doc_electronicos set fe_recepcion=getdate() where token_envio=@token_envio;";
            comando += "select isnull(no_documento,'') as [no_documento] from tbl_envio_doc_electronicos where token_envio=@token_envio;";
            try
            {
                String codEmpresaConnection = "conexion_" + rucEmpresa;
                if (System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection] == null)
                {
                    retorno = -2;
                    msg_retorno = "La URL de acceso ha caducado o el archivo no se encuentra disponible.";
                    nomDocumento = "";
                    return nomDocumento;
                }
                else
                {
                    String conn = System.Configuration.ConfigurationManager.ConnectionStrings[codEmpresaConnection].ConnectionString;

                    using (SqlConnection cn = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@token_envio", token_envio.ToString());
                            cn.Open();
                            nomDocumento = cmd.ExecuteScalar().ToString();
                        }
                    }

                    if (String.IsNullOrEmpty(nomDocumento))
                    {
                        retorno = -3;
                        msg_retorno = "No se pudo procesar su solicitud. Documento no existe.";
                        return nomDocumento;
                    }
                    else
                    {
                        retorno = 1;
                        msg_retorno = "Se confirmó la recepción del documento. Mostrando documento...";
                        return nomDocumento;
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = "Lo sentimos, ocurrió un error al procesar.";
                nomDocumento = "";
                return nomDocumento;
            }
        }
    }
}