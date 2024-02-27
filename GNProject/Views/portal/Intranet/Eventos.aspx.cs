using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Capas.Portal.Entidad;
using Capas.Portal.Negocio;
using System.IO;
using System.Web.Services;
using System.Collections;

using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Intranet
{
    public partial class Eventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Eventos(String[] strFiltros)
        {
            BUSEvento objNegEventos = new BUSEvento();
            List<Evento> oListaEventos = new List<Evento>();
            oListaEventos = objNegEventos.GetEventosAll();

            String path = Parametros.I_FileServer_RutaEventos.Replace("~", "../../../");
            String a_HTML = "<div class='link' style='cursor:pointer;' onclick='fn_VerDetalle(&#39;{0}&#39;)'>{1}</div>";
            String img_HTML = "<img style='border: 5px solid #FFF; width:140px; height:110px;' src={0} />";
            String table_HTML = "<table style='font-weight: bold; width: 100%;'>{0}</table>";
            String tr_HTML = "<tr>{0}</tr>";
            String td_HTML = "<td style='text-align:center;'>{0}</td><td style='text-align:center;'>{1}</td><td style='text-align:center;'>{2}</td>";
            String enlace = "";
            String img = "";
            String cuerpo = "";
            String dato_celda_1 = "";
            String dato_celda_2 = "";
            String dato_celda_3 = "";
            Int32 nu_eventos = oListaEventos.Count;
            if (nu_eventos > 0)
            {
                Int32 filas = oListaEventos.Count <= 3 ? 1 : (oListaEventos.Count / 3);
                if (oListaEventos.Count > 3) if ((oListaEventos.Count % 3) > 0) filas += 1;
                Int32 nro_item = 0;
                for (Int32 i = 0; i < filas; i++)
                {
                    img = String.Format(img_HTML, path + oListaEventos[nro_item].NomFotoEvento.Replace(" ", "%20"));
                    enlace = String.Format(a_HTML, oListaEventos[nro_item].Evento_Id.ToString(), img + "<br />" + oListaEventos[nro_item].Titulo);
                    dato_celda_1 = enlace;
                    if ((nro_item + 1) < nu_eventos)
                    {
                        img = String.Format(img_HTML, path + oListaEventos[nro_item + 1].NomFotoEvento.Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, oListaEventos[nro_item + 1].Evento_Id.ToString(), img + "<br />" + oListaEventos[nro_item + 1].Titulo);
                        dato_celda_2 = enlace;
                    }
                    else dato_celda_2 = "";
                    if ((nro_item + 2) < nu_eventos)
                    {
                        img = String.Format(img_HTML, path + oListaEventos[nro_item + 2].NomFotoEvento.Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, oListaEventos[nro_item + 2].Evento_Id.ToString(), img + "<br />" + oListaEventos[nro_item + 2].Titulo);
                        dato_celda_3 = enlace;
                    }
                    else dato_celda_3 = "";
                    cuerpo += String.Format(tr_HTML, String.Format(td_HTML, dato_celda_1, dato_celda_2, dato_celda_3));
                    nro_item += 3;
                }
            }
            else
            {
                cuerpo = "<tr><td>No existen eventos registrados.</td></tr>";
            }

            String response_HTML = String.Format(table_HTML, cuerpo);

            object[] response = new object[] { response_HTML };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_EventosDetalle(Int32 id)
        {
            Int32 Evento_Id = id;
            BUSEventoFotos objNegEventosFotos = new BUSEventoFotos();
            List<EventoFotos> oListaEventosFotos = new List<EventoFotos>();
            oListaEventosFotos = objNegEventosFotos.GetEventoFotosxEventoID(Evento_Id);

            String path = Parametros.I_FileServer_RutaEventos.Replace("~", "../../../");
            //////String a_HTML = "<div class='link' style='cursor:pointer;' onclick='fn_OpenEvento(&#39;{0}&#39;)'>{1}</div>";
            String a_HTML = "<a class='link' href='" + path + "{0}' title='{0}' rel='lightbox[roadtrip]' style='cursor:pointer;'>{1}</a> <div><a href='#' class='b_ampliar'>ampliar &nbsp; +</a></div>";
            String img_HTML = "<img style='border: 5px solid #FFF; width:140px; height:110px;' src={0} />";
            String table_HTML = "<table style='font-weight: bold;width: 100%;'>{0}</table>";
            String tr_HTML = "<tr>{0}</tr>";
            String td_HTML = "<td style='text-align:center;width:20%;'>{0}</td><td style='text-align:center;width:20%;'>{1}</td><td style='text-align:center;width:20%;'>{2}</td><td style='text-align:center;width:20%;'>{3}</td>";
            String enlace = "";
            String img = "";
            String cuerpo = "";
            String dato_celda_1 = "";
            String dato_celda_2 = "";
            String dato_celda_3 = "";
            String dato_celda_4 = "";

            //se tiene que validar aqui
            Int32 nu_eventos = oListaEventosFotos.Count;

            if (nu_eventos > 0)
            {
                Int32 filas = oListaEventosFotos.Count <= 4 ? 1 : (oListaEventosFotos.Count / 4);
                if (oListaEventosFotos.Count > 4) if ((oListaEventosFotos.Count % 4) > 0) filas += 1;
                Int32 nro_item = 0;
                //////se agregó esta inea de codigo

                ////
                for (Int32 i = 0; i < filas; i++)
                {
                    img = String.Format(img_HTML, path + oListaEventosFotos[nro_item].Nombre_Foto.Replace(" ", "%20"));
                    enlace = String.Format(a_HTML, oListaEventosFotos[nro_item].Nombre_Foto.ToString(), img);
                    dato_celda_1 = enlace;
                    if ((nro_item + 1) < nu_eventos)
                    {
                        img = String.Format(img_HTML, path + oListaEventosFotos[nro_item + 1].Nombre_Foto.Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, oListaEventosFotos[nro_item + 1].Nombre_Foto.ToString(), img);
                        dato_celda_2 = enlace;
                    }
                    else dato_celda_2 = "";
                    if ((nro_item + 2) < nu_eventos)
                    {
                        img = String.Format(img_HTML, path + oListaEventosFotos[nro_item + 2].Nombre_Foto.Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, oListaEventosFotos[nro_item + 2].Nombre_Foto.ToString(), img);
                        dato_celda_3 = enlace;
                    }
                    else dato_celda_3 = "";
                    if ((nro_item + 3) < nu_eventos)
                    {
                        img = String.Format(img_HTML, path + oListaEventosFotos[nro_item + 3].Nombre_Foto.Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, oListaEventosFotos[nro_item + 3].Nombre_Foto.ToString(), img);
                        dato_celda_4 = enlace;
                    }
                    else dato_celda_4 = "";
                    cuerpo += String.Format(tr_HTML, String.Format(td_HTML, dato_celda_1, dato_celda_2, dato_celda_3, dato_celda_4));
                    nro_item += 4;
                }
                String response_HTML = String.Format(table_HTML, cuerpo);

                object[] response = new object[] { oListaEventosFotos[0].Titulo.ToUpper(), oListaEventosFotos[0].Descripcion, oListaEventosFotos[0].sFecha, response_HTML };
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                return serializer.Serialize(response);
            }
            else
            {
                cuerpo = "<tr><td>No existen eventos registrados.</td></tr>";
                String response_HTML = String.Format(table_HTML, cuerpo);

                object[] response = new object[] { response_HTML };
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                return serializer.Serialize(response);
            }




        }
    }
}