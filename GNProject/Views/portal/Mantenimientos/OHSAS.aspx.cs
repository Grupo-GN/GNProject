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
    public partial class OHSAS : System.Web.UI.Page
    {
        BUSOHSAS_Detalle objNegOHSAS_Detalle = new BUSOHSAS_Detalle();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            Int32 id_ohsas_detalle = Convert.ToInt32(hdfID.Value);
            String no_archivo;
            String msg_error;
            if (fuArchivo.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuArchivo, id_ohsas_detalle.ToString(), ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaOHSAS, out no_archivo);
                if (msg_error != String.Empty)
                {
                    lblMensaje.Text = "Error al subir documento. " + msg_error;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    objNegOHSAS_Detalle.GuardarOHSASDetalle(id_ohsas_detalle, no_archivo);
                }
            }
            UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            Int32 id_ohsas;
            Int32.TryParse(strFiltros[0], out id_ohsas);

            BUSOHSAS_Detalle objNegBUSOHSAS_Detalle = new BUSOHSAS_Detalle();
            List<OHSAS_Detalle> oLista = new List<OHSAS_Detalle>();
            oLista = objNegBUSOHSAS_Detalle.GetOHSASAll_Detalle(id_ohsas, 0);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<OHSAS_Detalle> orderedRecords = null;
            if (pSortColumn == "id_ohsas_detalle") orderedRecords = oLista.OrderBy(col => col.id_ohsas_detalle);
            else if (pSortColumn == "no_ohsas") orderedRecords = oLista.OrderBy(col => col.no_ohsas);
            else if (pSortColumn == "no_titulo") orderedRecords = oLista.OrderBy(col => col.no_titulo);
            else if (pSortColumn == "no_area") orderedRecords = oLista.OrderBy(col => col.no_area);
            else if (pSortColumn == "co_usuario") orderedRecords = oLista.OrderBy(col => col.co_usuario);
            else if (pSortColumn == "sfe_registro") orderedRecords = oLista.OrderBy(col => col.fe_registro);

            IEnumerable<OHSAS_Detalle> sortedRecords;
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
            foreach (OHSAS_Detalle obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.id_ohsas_detalle + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.id_ohsas_detalle + "&#39;)'>",
                    id_ohsas_detalle = obj.id_ohsas_detalle,
                    id_ohsas = obj.id_ohsas,
                    no_ohsas = obj.no_ohsas,
                    no_titulo = obj.no_titulo,
                    tx_descripcion = obj.tx_descripcion,
                    no_archivi = obj.no_archivo,
                    no_area = obj.no_area,
                    co_usuario = obj.co_usuario,
                    sfe_registro = obj.sfe_registro
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

            Int32 id_ohsas_detalle = id;
            BUSOHSAS_Detalle objNegBUSOHSAS_Detalle = new BUSOHSAS_Detalle();
            List<OHSAS_Detalle> oLista = new List<OHSAS_Detalle>();
            oLista = objNegBUSOHSAS_Detalle.GetOHSASAll_Detalle(0, id_ohsas_detalle);
            OHSAS_Detalle oOHSAS_Detalle = oLista[0];

            object obj = new
            {
                id_ohsas_detalle = oOHSAS_Detalle.id_ohsas_detalle,
                id_ohsas = oOHSAS_Detalle.id_ohsas
                ,
                no_titulo = oOHSAS_Detalle.no_titulo,
                tx_descripcion = oOHSAS_Detalle.tx_descripcion,
                no_archivo = oOHSAS_Detalle.no_archivo
                ,
                sfe_registro = oOHSAS_Detalle.sfe_registro,
                id_area = oOHSAS_Detalle.Categoria_Auxiliar_Id
            };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Grabar(String[] strParametros)
        {
            object[] strRetorno;
            BUSOHSAS_Detalle objNegOHSAS_Detalle = new BUSOHSAS_Detalle();
            try
            {
                Int32 id_ohsas_detalle; Int32.TryParse(strParametros[0], out id_ohsas_detalle);
                Int32 id_ohsas; Int32.TryParse(strParametros[1], out id_ohsas);
                OHSAS_Detalle objEOHSAS_Detalle = new OHSAS_Detalle();
                objEOHSAS_Detalle.id_ohsas_detalle = id_ohsas_detalle;
                objEOHSAS_Detalle.id_ohsas = id_ohsas;
                objEOHSAS_Detalle.no_titulo = strParametros[2];
                objEOHSAS_Detalle.tx_descripcion = strParametros[3];
                objEOHSAS_Detalle.no_archivo = strParametros[4];
                objEOHSAS_Detalle.sfe_registro = strParametros[5];
                objEOHSAS_Detalle.Categoria_Auxiliar_Id = strParametros[6];
                objEOHSAS_Detalle.co_usuario = strParametros[7];

                Int32 retorno = 0; String msg_retorno = String.Empty;
                objNegOHSAS_Detalle.GuardarOHSASDetalle(objEOHSAS_Detalle, out retorno, out msg_retorno);

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
        public static object Actualizar(String[] strParametros)
        {
            object[] strRetorno;
            BUSOHSAS_Detalle objNegOHSAS_Detalle = new BUSOHSAS_Detalle();
            try
            {
                Int32 id_ohsas_detalle; Int32.TryParse(strParametros[0], out id_ohsas_detalle);
                Int32 id_ohsas; Int32.TryParse(strParametros[1], out id_ohsas);
                OHSAS_Detalle objEOHSAS_Detalle = new OHSAS_Detalle();
                objEOHSAS_Detalle.id_ohsas_detalle = id_ohsas_detalle;
                objEOHSAS_Detalle.id_ohsas = id_ohsas;
                objEOHSAS_Detalle.no_titulo = strParametros[2];
                objEOHSAS_Detalle.tx_descripcion = strParametros[3];
                objEOHSAS_Detalle.no_archivo = strParametros[4];
                objEOHSAS_Detalle.sfe_registro = strParametros[5];
                objEOHSAS_Detalle.Categoria_Auxiliar_Id = strParametros[6];
                objEOHSAS_Detalle.co_usuario = strParametros[7];

                Int32 retorno = 0; String msg_retorno = String.Empty;
                //objNegOHSAS_Detalle.GuardarOHSASDetalle(objEOHSAS_Detalle, out retorno, out msg_retorno);

                if (retorno > 0) strRetorno = new object[] { retorno, msg_retorno };
                else strRetorno = new object[] { -1, "Ocurrio un error al actualizar los datos. " + msg_retorno };
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
        public static object Eliminar(Int32 id)
        {
            Int32 id_ohsas_detalle = id;

            object[] strRetorno;
            BUSOHSAS_Detalle objNegOHSAS_Detalle = new BUSOHSAS_Detalle();
            try
            {
                String no_archivo = objNegOHSAS_Detalle.GetOHSASAll_Detalle(0, id_ohsas_detalle)[0].no_archivo;
                if (no_archivo != "")
                {
                    String path = Parametros.I_FileServer_RutaOHSAS + no_archivo;
                    try
                    {
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(path));
                    }
                    catch { }
                }


                Int32 retorno = 0; String msg_retorno = String.Empty;
                objNegOHSAS_Detalle.EliminarOHSASDetalle(id_ohsas_detalle, out retorno, out msg_retorno);

                if (retorno > 0) strRetorno = new object[] { 1, msg_retorno };
                else strRetorno = new object[] { -1, "Ocurrio un error al eliminar. " + msg_retorno };
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
            Int32 id_ohsas_detalle = Convert.ToInt32(strParametros[0]);
            String no_archivo = strParametros[1].ToString();

            String path = Parametros.I_FileServer_RutaOHSAS + no_archivo;
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(path));
            no_archivo = "";

            object[] strRetorno;
            BUSOHSAS_Detalle objNegOHSAS_Detalle = new BUSOHSAS_Detalle();
            try
            {
                objNegOHSAS_Detalle.GuardarOHSASDetalle(id_ohsas_detalle, no_archivo);
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