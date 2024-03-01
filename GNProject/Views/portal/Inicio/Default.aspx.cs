using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using Capas.Portal.Entidad;
using Capas.Portal.Negocio;
using System.Web.Services;
using GNProject.Acceso.App_code_portal;
using Microsoft.Reporting.WebForms;
using GNProject.Acceso.App_code_portal.dsResultadoEncuestasTableAdapters;
using System.Data;

namespace GNProject.Views.portal.Inicio
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Get_EnlacesInteresyCertificaciones();
            }
        }
        private void Get_EnlacesInteresyCertificaciones()
        {
            //this.CargaMenu();

            #region "Carga enlaces de interes"
            BUSEnlaces objNegEnlaces = new BUSEnlaces();
            List<Enlace> oLista = new List<Enlace>();
            String User_Id = ClaseGlobal.Get_UserID();
            oLista = objNegEnlaces.GetEnlacesAll(User_Id);

            String html_Enlaces = "<div style=\"text-align:justify;\">";
            foreach (Enlace ent in oLista)
            {
                if (String.IsNullOrEmpty(ent.Direccion) || ent.Direccion == "#")
                {
                    html_Enlaces += String.Format("<p>• {0}</p>", ent.Nom_Enlace);
                }
                else
                {
                    html_Enlaces += String.Format("<p><a href=\"{0}\" target=\"_blank\">• {1}</a></p>", ent.Direccion, ent.Nom_Enlace);
                }
            }
            html_Enlaces += "</div>";
            ltrEnlacesInteres.Text = html_Enlaces;
            #endregion "Carga enlaces de interes"

            //certificaciones
            String path_Raiz = Server.MapPath("~/");
            String[] arrFiles_Collage = System.IO.Directory.GetFiles(Server.MapPath("~/Assets/images/imgPortal/collage_empresa/"));
            String[] arrFiles_Certificaciones = System.IO.Directory.GetFiles(Server.MapPath("~/Assets/images/imgPortal/certificaciones/"));
            hdfCollages.Value = String.Join(",", arrFiles_Collage).Replace(path_Raiz, "../../../");
            hdfCertificaciones.Value = String.Join(",", arrFiles_Certificaciones).Replace(path_Raiz, "../../../");
        }
        protected void btnVerBarras_Click(object sender, EventArgs e)
        {
            String Encuesta_Id = hdfEncuesta_Id.Value;
            string dominio = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Views/portal/Reportes/rptResultadoEncuestas.rdlc");

            //se cambio esta parte tenia un using namespace ahora lo hemos quitado
            dtResultadoEncuestasTableAdapter tablaResultadoEncuestas = new dtResultadoEncuestasTableAdapter();
            dsResultadoEncuestas.dtResultadoEncuestasDataTable datosResultadoEncuestas = tablaResultadoEncuestas.GetData(Encuesta_Id);

            List<dsResultadoEncuestas.dtResultadoEncuestasRow> data = datosResultadoEncuestas.ToList();
            data.RemoveAt(data.Count - 1);

            if (ReportViewer1.LocalReport.DataSources.Count > 0) ReportViewer1.LocalReport.DataSources.RemoveAt(0);

            ReportDataSource dataSource = new ReportDataSource("dtResultadoEncuestas", data);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
            lblCargandoBarras.Text = "";
        }

        public String Get_OpenModalCumpleDia()
        {
            String rpta;
            if (Session["modalCumpleDelDia"] == null)
                rpta = "1";
            else
                rpta = "0";
            Session["modalCumpleDelDia"] = rpta;
            return rpta;
        }


        //servicios default

        /////////////////////////////
        ///
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object UpdPwdUsu(String[] strParametros)
        {
            String User_Id = strParametros[0];
            String passwordActual = strParametros[1];
            String newPassword = strParametros[2];

            BUSUsuarios objNegUsers = new BUSUsuarios();
            Usuarios objEUsu = new Usuarios();
            objEUsu.User_Id = User_Id;
            DataTable dt = new DataTable();
            dt = objNegUsers.ListaUserxId(objEUsu);

            Int32 retorno = 0; String msg = "";
            if (passwordActual == dt.Rows[0]["Password"].ToString())
            {
                Int32 rpta = 0;
                BUSUsuarios objNegUsuario = new BUSUsuarios();
                Usuarios objUsu = new Usuarios();
                objUsu.User_Id = User_Id;
                objUsu.Password = newPassword;
                rpta = objNegUsuario.UpdateContrasenia(objUsu);

                if (rpta >= 1)
                {
                    retorno = 1;
                    msg = "Se actualizó correctamente.";
                }
                else
                {
                    retorno = -2;
                    msg = "Ocurrio un error al actualizar los datos.";
                }
            }
            else
            {
                retorno = -3;
                msg = "La contraseña ingresada es incorrecta.";
            }

            object response = new object[] { retorno, msg };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_CronogramaMes()
        {
            BUSCronogramaMes objNegCronogramaMes = new BUSCronogramaMes();
            System.Data.DataTable dt = objNegCronogramaMes.ListaCronogramaMes();

            String html = String.Empty;
            String fila = "<p>{0} - {1}</p>";
            String cronograma = "<a href='../Intranet/CronogramaMes.aspx?id={0}'>{1}</a>";
            foreach (System.Data.DataRow row in dt.Rows)
            {
                html += String.Format(fila, row["Fecha"], String.Format(cronograma, row["CronogramaMes_Id"], row["Titulo"]));
            }
            if (html == String.Empty) html = "No existen datos.";

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_CumpleDelDia()
        {
            BUSPersonal objDatos = new BUSPersonal();
            System.Data.DataTable dt = objDatos.ListaCumpleDelDia();

            String html = String.Empty;
            //////String path_ImgUsers = Parametros.I_VirtualServer_ImgUsers;
            String path_ImgUsers = Parametros.I_FileServer_RutaImgUsers.Replace("~", "  ");
            String fila = "<tr><td>{0}</td><td valign='top'>{1}</td></tr>";
            String fila_modal = "<tr><td style='border-bottom: 1px solid #e5e5e5;'>{0}</td><td valign='top' style='text-align:left;border-bottom: 1px solid #e5e5e5;'>{1}</td></tr>";
            String img = "<img alt='' src={0} width='20px' height='25px' />";
            String img_modal = "<img alt='' src={0} style='max-width:80px;' />";
            String a_Enlace = "<a href=../Intranet/DirColaboradores.aspx?id={0}>{1}</a>";
            String no_personal;

            String html_modal = "";

            foreach (System.Data.DataRow row in dt.Rows)
            {
                no_personal = String.Format(a_Enlace, row["Personal_Id"], row["Nombre_Completo"]);
                html += String.Format(fila, String.Format(img, path_ImgUsers + row["Ruta_Foto"]), no_personal);

                no_personal = String.Format("<p>" + a_Enlace + "</p>", row["Personal_Id"], row["Nombre_Completo"])
                    + "<p>" + Parametros.I_Texto_Localidad + ": " + row["Localidad"] + "</p>"
                    + "<p>Cargo: " + row["Cargo"] + "</p>"
                    + "<p>" + Parametros.I_Texto_CategoriaAuxiliar + ": " + row["Area"] + "</p>";
                html_modal += String.Format(fila_modal, String.Format(img_modal, path_ImgUsers + row["Ruta_Foto"]), no_personal);
            }
            if (html == String.Empty) html = "No existen datos.";
            else html = "<table>" + html + "</table>";

            if (html_modal != String.Empty) html_modal = "<table style='width:100%; cellpadding='0' cellspacing='0''>" + html_modal + "</table>";

            object response = new object[] { html, html_modal };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bienvenida()
        {
            BUSContenidos objNegContenidos = new BUSContenidos();
            System.Data.DataTable dt = new System.Data.DataTable();
            Contenidos objEContenidos = new Contenidos();
            objEContenidos.Contenido_Id = 4; //4 = Bienvenido
            dt = objNegContenidos.ListaContenidosxId(objEContenidos);
            //error qui cuando dt no tiene datos sale error
            String msg_bienvenida = dt.Rows[0]["Descripcion"].ToString();
            String ruta_img = dt.Rows[0]["Ruta_Img"].ToString().Trim();
            dt.Dispose();

            if (!String.IsNullOrEmpty(ruta_img))
            {
                ruta_img = Parametros.I_FileServer_RutaContenidos.Replace("~", "../../../") + ruta_img;
            }
            object response = new object[] { msg_bienvenida, ruta_img };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_UltAnuncios()
        {
            BUSAnuncios objNegAnuncios = new BUSAnuncios();
            System.Data.DataTable dt = objNegAnuncios.ListaAnunciosCompleto(); //obtiene los 5 ultimos

            String html = String.Empty;
            //////String path_Anuncios = Parametros.I_VirtualServer_Anuncios;
            String path_Anuncios = Parametros.I_FileServer_RutaAnuncios.Replace("~", "../../../");
            String title = "<a class='titleLink' href='../Intranet/Anuncios.aspx?id={1}'>{0}</a><Br />";
            String subtitle = "<span style='color:DarkOrange;float:left;'>por {0}</span><p style='float:clear;text-align:right;'>{1}</p>";
            String img = "<img alt='' src={0} width='70px' height='70px' style='float:left; border:solid 1px; margin-right:5px;' />";
            String imgAnuncio = "<img alt='' src='/Assets/images/imgPortal/Noticias.gif' width='70px' height='70px' style='float:left;' />";
            String texto = "<p style='float:clear;text-align:justify;'>{0}</p><Br />";
            foreach (System.Data.DataRow row in dt.Rows)
            {
                String img_anuncio_aux = String.Empty;
                img_anuncio_aux = row["Ruta_Foto"].ToString() == "" ? imgAnuncio : String.Format(img, path_Anuncios + row["Ruta_Foto"].ToString().Replace(" ", "%20"));
                html += String.Format(title, row["Titulo"], row["Anuncio_Id"])
                    + String.Format(subtitle, row["User_Name"], Convert.ToDateTime(row["Fecha"]).ToString("dd/MM/yyyy HH:mm:ss"))
                    + img_anuncio_aux
                    + String.Format(texto, row["Descripcion"])
                    + "<div style='clear:both;'></div>";
            }

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_CumpleMes()
        {
            BUSAnuncios objNegAnuncios = new BUSAnuncios();
            System.Data.DataTable dt = objNegAnuncios.ListaCumpleDelMes();

            String html = String.Empty;
            //////String path_ImgUsers = Parametros.I_VirtualServer_ImgUsers;
            String path_ImgUsers = Parametros.I_FileServer_RutaImgUsers.Replace("~", "../../../");
            String a_Enlace = "<a href=../Intranet/DirColaboradores.aspx?id={0}>{1}</a>";
            String td = "<td>{0}</td>";
            String img = "<img alt='' src={0} width='50px' height='50px' />";
            Int32 contador_columna = 0;
            String no_personal;
            foreach (System.Data.DataRow row in dt.Rows)
            {
                contador_columna++;
                if (html == String.Empty) html = "<table>";
                if (contador_columna == 1) html += "<tr>";
                no_personal = String.Format(a_Enlace, row["Personal_Id"], row["Nombre_Completo"]);
                html += String.Format(td, String.Format(img, path_ImgUsers + row["Ruta_Foto"]) + "<Br />" + no_personal + "<Br />" + row["Cumple"]);
                if (contador_columna == 2) { html += "</tr>"; contador_columna = 0; }
            }
            if (html != String.Empty) html += "</table>";

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_PreguntasFrecuentes()
        {
            BUSFaq objNegFaq = new BUSFaq();
            System.Data.DataTable dt = objNegFaq.ListaFaqAll();

            String html = String.Empty;
            String fila = "<p>• {0}</p>";
            String cronograma = "<a href='../Intranet/PreguntasFrecuentes.aspx?id={0}'>{1}</a>";
            foreach (System.Data.DataRow row in dt.Rows)
            {
                html += String.Format(fila, String.Format(cronograma, row["Faq_Id"], row["Pregunta"]));
            }
            if (html == String.Empty) html = "No existen datos.";

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_EncuestasVigentes()
        {
            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            System.Data.DataTable dt = objNegEncuesta.ListaEncuestaActivas();

            String html = String.Empty;
            String fila = "<p>• {0}</p>";
            String enlace = "<span class='link' style='color:#6CC24A !important; font-weight:bold;' onclick='fn_OpenEncuesta(&#39;{0}&#39;)'>{1}</span>";
            foreach (System.Data.DataRow row in dt.Rows)
            {
                html += String.Format(fila, String.Format(enlace, row["Encuesta_Id"], row["Titulo"]));
            }
            if (html == String.Empty) html = "No existen encuestas vigentes.";

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_EncuestasCerradas()
        {
            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            System.Data.DataTable dt = objNegEncuesta.ListaEncuestaCerradas();

            String html = String.Empty;
            String fila = "<p>• {0}</p>";
            String enlace = "<span class='link' onclick='fn_OpenEncuesta(&#39;{0}&#39;)'>{1}</span>";
            foreach (System.Data.DataRow row in dt.Rows)
            {
                html += String.Format(fila, String.Format(enlace, row["Encuesta_Id"], row["Titulo"]));
            }
            if (html == String.Empty) html = "No existen datos.";

            object response = new object[] { html };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
    }
}