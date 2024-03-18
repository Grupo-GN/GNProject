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

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantCorreos : System.Web.UI.Page
    {
        BUSCorreo objNegCorreo = new BUSCorreo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            Int32 id_correo = Convert.ToInt32(hdfID.Value);
            String no_archivo;
            String msg_error;
            if (fuArchivo.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuArchivo, id_correo.ToString(), ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaPlantillaCorreo, out no_archivo);
                if (msg_error != String.Empty)
                {
                    UtilsScript.fc_DisplayAlert(this, "Error al subir archivo. " + msg_error);
                    return;
                }
                else
                {
                    objNegCorreo.ActualizaImagenCorreo(id_correo, "I", no_archivo);
                }
            }
            UtilsScript.fc_JavaScript(this, "fn_Editar('" + id_correo.ToString() + "');", "__script1__");
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSCorreo objNegBUSCorreo = new BUSCorreo();
            List<Correo> oLista = new List<Correo>();
            oLista = objNegBUSCorreo.GetCorreosAll(0);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Correo> orderedRecords = null;
            if (pSortColumn == "id_correo") orderedRecords = oLista.OrderBy(col => col.id_correo);
            else if (pSortColumn == "co_correo") orderedRecords = oLista.OrderBy(col => col.co_correo);
            else if (pSortColumn == "no_asunto") orderedRecords = oLista.OrderBy(col => col.no_asunto);

            IEnumerable<Correo> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oLista.ToList();
            else
            {
                sortedRecords = orderedRecords.ToList();
                if (pSortOrder == "desc") sortedRecords = sortedRecords.Reverse();
            }
            sortedRecords = sortedRecords
                  .Skip((pageIndex - 1) * pageSize) //--- page the data
                  .Take(pageSize);

            //Retorna formato JQGrid
            JQGridJsonResponse responseJQGrid = new JQGridJsonResponse(totalPages, pageIndex, totalRecords);
            JQGridJsonResponseRow oJQGridJsonResponseRow;
            Int32 i = 0;
            foreach (Correo obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png'class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.id_correo + "&#39;)'>",
                    id_correo = obj.id_correo,
                    co_correo = obj.co_correo,
                    no_asunto = obj.no_asunto,
                    no_para = obj.no_para,
                    no_cc = obj.no_cc,
                    no_bcc = obj.no_bcc,
                    tx_body = obj.tx_body,
                    co_usuario = obj.co_usuario
                };
                oJQGridJsonResponseRow.Row = filas;
                responseJQGrid.Items.Add(oJQGridJsonResponseRow);
                i++;
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(responseJQGrid);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_DatosxID(Int32 id)
        {
            Int32 id_correo = id;
            BUSCorreo objNegBUSCorreo = new BUSCorreo();
            List<Correo> oLista = new List<Correo>();
            oLista = objNegBUSCorreo.GetCorreosAll(id_correo);
            Correo oCorreo = oLista[0];

            String imagenes_html = "";
            if (!String.IsNullOrEmpty(oCorreo.no_images))
            {
                String[] arr_images = oCorreo.no_images.Split('|');
                #region "INICIO - ARMA TABLA DE IMAGENES"
                String a_HTML = "<div class='link-tabla' style='cursor:pointer;' onclick='fn_EliminarArchivo(&#39;{0}&#39;)'>Eliminar</div>";
                String img_HTML = "<img style='border: 5px solid #FFF; width:140px; height:110px;' src={0} />";
                String table_HTML = "<table style='font-weight: bold;width: 100%;'>{0}</table>";
                String tr_HTML = "<tr>{0}</tr>";
                String td_HTML = "<td style='text-align:center;'>{0}</td><td style='text-align:center;'>{1}</td><td style='text-align:center;'>{2}</td><td style='text-align:center;'>{3}</td>";
                String enlace = "";
                String img = "";
                String cuerpo = "";
                String dato_celda_1 = "";
                String dato_celda_2 = "";
                String dato_celda_3 = "";
                String dato_celda_4 = "";
                Int32 nu_images = arr_images.Length;
                Int32 filas = nu_images <= 4 ? 1 : (nu_images / 4);
                if (nu_images > 4) if ((nu_images % 4) > 0) filas += 1;
                String path = Parametros.I_FileServer_RutaPlantillaCorreo.Replace("~", "../../../");
                Int32 nro_item = 0;
                for (Int32 i = 0; i < filas; i++)
                {
                    img = String.Format(img_HTML, path + arr_images[nro_item].Replace(" ", "%20"));
                    enlace = String.Format(a_HTML, arr_images[nro_item].ToString());
                    dato_celda_1 = img + enlace;
                    if ((nro_item + 1) < nu_images)
                    {
                        img = String.Format(img_HTML, path + arr_images[nro_item + 1].Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, arr_images[nro_item + 1].ToString());
                        dato_celda_2 = img + enlace;
                    }
                    else dato_celda_2 = "";
                    if ((nro_item + 2) < nu_images)
                    {
                        img = String.Format(img_HTML, path + arr_images[nro_item + 2].Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, arr_images[nro_item + 2].ToString());
                        dato_celda_3 = img + enlace;
                    }
                    else dato_celda_3 = "";
                    if ((nro_item + 3) < nu_images)
                    {
                        img = String.Format(img_HTML, path + arr_images[nro_item + 3].Replace(" ", "%20"));
                        enlace = String.Format(a_HTML, arr_images[nro_item + 3].ToString());
                        dato_celda_4 = img + enlace;
                    }
                    else dato_celda_4 = "";
                    cuerpo += String.Format(tr_HTML, String.Format(td_HTML, dato_celda_1, dato_celda_2, dato_celda_3, dato_celda_4));
                    nro_item += 4;
                }
                String response_HTML = String.Format(table_HTML, cuerpo);
                #endregion
                imagenes_html = response_HTML;
            }

            object obj = new
            {
                id_correo = oCorreo.id_correo,
                co_correo = oCorreo.co_correo,
                no_asunto = oCorreo.no_asunto,
                no_para = oCorreo.no_para,
                no_cc = oCorreo.no_cc,
                no_bcc = oCorreo.no_bcc,
                tx_body = oCorreo.tx_body,
                imagenes_html = imagenes_html
            };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Grabar(String[] strParametros)
        {
            object[] strRetorno;
            BUSCorreo objNegCorreo = new BUSCorreo();
            try
            {
                Int32 id_correo; Int32.TryParse(strParametros[0], out id_correo);
                Correo objECorreo = new Correo();
                objECorreo.id_correo = id_correo;
                objECorreo.no_asunto = strParametros[1];
                objECorreo.no_para = strParametros[2];
                objECorreo.no_cc = strParametros[3];
                objECorreo.no_bcc = strParametros[4];
                objECorreo.tx_body = strParametros[5];
                objECorreo.co_usuario = strParametros[6];

                Int32 retorno = 0; String msg_retorno = String.Empty;
                objNegCorreo.GuardarCorreo(objECorreo, out retorno, out msg_retorno);

                if (retorno > 0) strRetorno = new object[] { retorno, msg_retorno };
                else strRetorno = new object[] { -1, "Ocurrio un error al grabar los datos. " + msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object EliminarArchivo(String[] strParametros)
        {
            Int32 id_correo = Convert.ToInt32(strParametros[0]);
            String no_archivo = strParametros[1].ToString();

            String path = Parametros.I_FileServer_RutaPlantillaCorreo + no_archivo;
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(path));

            object[] strRetorno;
            BUSCorreo objNegCorreo = new BUSCorreo();
            try
            {
                objNegCorreo.ActualizaImagenCorreo(id_correo, "D", no_archivo);
                strRetorno = new object[] { 1, "Se actualizó correctamente" };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
    }
}