using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.BL.Maestros;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.ctrlDoc.Maestros
{
    public partial class MntParametros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            ParametroBL oParametroBL = new ParametroBL();
            String no_tabla = strFiltros[0];
            List<ParametroBE> oLista = oParametroBL.Get_BandejaParametros(0, no_tabla, "1");

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<ParametroBE> orderedRecords = null;
            if (pSortColumn == "id_parametro") orderedRecords = oLista.OrderBy(col => col.id_parametro);
            else if (pSortColumn == "no_tabla") orderedRecords = oLista.OrderBy(col => col.no_tabla);
            else if (pSortColumn == "de_tabla") orderedRecords = oLista.OrderBy(col => col.de_tabla);
            else if (pSortColumn == "fl_tabla") orderedRecords = oLista.OrderBy(col => col.fl_tabla);

            IEnumerable<ParametroBE> sortedRecords;
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
            foreach (ParametroBE obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();

                String imgEditar = "<img title='Editar' alt='Editar' src='../img/img_buttons/Editar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Editar(&#39;{0}&#39;);' />";
                String imgInactivar = "<img title='Inactivar' alt='Inactivar' src='../img/img_buttons/Cancelar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Inactivar(&#39;{0}&#39;);' />";
                String imgActivar = "<img title='Activar' alt='Activar' src='../img/img_buttons/Comprobado-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Activar(&#39;{0}&#39;);' />";
                String imgVerDetalle = "<img title='Ver' alt='Ver' src='../img/img_buttons/No_Editar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_VerDetalle(&#39;{0}&#39;);' />";

                imgEditar = String.Format(imgEditar, oJQGridJsonResponseRow.ID);
                imgInactivar = String.Format(imgInactivar, oJQGridJsonResponseRow.ID);
                imgActivar = String.Format(imgActivar, oJQGridJsonResponseRow.ID);
                imgVerDetalle = String.Format(imgVerDetalle, oJQGridJsonResponseRow.ID);

                //////String imgOpciones = "";
                //////if (flEditar && obj.codEstado == "001") imgOpciones += imgEditar;
                //////if (flCambiarEstado) imgOpciones += (obj.codEstado == "001" ? imgInactivar : imgActivar);
                //////if (flVerDetalle) imgOpciones += imgVerDetalle;

                object filas = new
                {
                    id_parametro = obj.id_parametro,
                    no_tabla = obj.no_tabla,
                    de_tabla = obj.de_tabla,
                    fl_tabla = (obj.fl_tabla == "1" ? "SI" : "NO"),
                    //imgOpciones = imgOpciones
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
        public static object Guardar(String[] strParametros)
        {
            ParametroBL oParametroBL = new ParametroBL();
            ParametroBE oParametroBE = new ParametroBE();
            object[] strRetorno;
            try
            {
                Int32 id_parametro; Int32.TryParse(strParametros[0].ToString(), out id_parametro);
                oParametroBE.id_parametro = id_parametro;
                oParametroBE.no_tabla = strParametros[1];
                oParametroBE.de_tabla = strParametros[2];
                oParametroBE.fl_tabla = (strParametros[3] == "SI" ? "1" : "0");
                oParametroBE.fl_activo = "1";
                oParametroBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oParametroBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oParametroBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oParametroBL.GuardarParametro(oParametroBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        //[System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        //[WebMethod]
        //public static object Eliminar(String[] strParametros)
        //{
        //    ParametroBL oParametroBL = new ParametroBL();
        //    ParametroBE oParametroBE = new ParametroBE();
        //    object[] strRetorno;
        //    try
        //    {
        //        Int32 id_parametro;
        //        Int32.TryParse(strParametros[0].ToString(), out id_parametro);
        //        oParametroBE.id_parametro = id_parametro;
        //        oParametroBE.co_usuario = ClaseGlobal.Get_login_usuario();
        //        oParametroBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
        //        oParametroBE.no_estacion_red = ClaseGlobal.getEstacionRed();

        //        Int32 retorno = 0; String msg_retorno = String.Empty;
        //        oParametroBL.EliminarCorreo(oParametroBE, out retorno, out msg_retorno);

        //        strRetorno = new object[] { retorno, msg_retorno };
        //    }
        //    catch (Exception ex)
        //    {
        //        strRetorno = new object[] { -1, "Error: " + ex.Message };
        //    }

        //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    return serializer.Serialize(strRetorno);
        //}

        #region "Detalle de Parámetros"
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Detalle(Int32 id)
        {
            ParametroBL oParametroBL = new ParametroBL();
            ParametroDetalleBEList oParametroDetalleBEList = new ParametroDetalleBEList();

            Int32 id_parametro = id;
            String fl_activo = "";

            oParametroDetalleBEList = oParametroBL.Get_BandejaParametrosDetalle(id_parametro, 0, fl_activo);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oParametroDetalleBEList);
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object GrabarParametroDetalle(String[] strParametros)
        {
            ParametroBL oParametroBL = new ParametroBL();
            ParametroDetalleBE oParametroDetalleBE = new ParametroDetalleBE();
            object[] strRetorno;
            try
            {
                Int32 id_parametro_detalle; Int32.TryParse(strParametros[0].ToString(), out id_parametro_detalle);
                Int32 id_parametro; Int32.TryParse(strParametros[1].ToString(), out id_parametro);
                oParametroDetalleBE.id_parametro_detalle = id_parametro_detalle;
                oParametroDetalleBE.id_parametro = id_parametro;
                //////oParametroDetalleBE.no_valor1 = "";
                oParametroDetalleBE.no_valor2 = strParametros[2].ToString();
                oParametroDetalleBE.no_valor3 = strParametros[3].ToString();
                oParametroDetalleBE.no_valor4 = strParametros[4].ToString();
                oParametroDetalleBE.no_valor5 = strParametros[5].ToString();
                oParametroDetalleBE.fl_activo = strParametros[6].ToString();
                oParametroDetalleBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oParametroDetalleBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oParametroDetalleBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oParametroBL.GuardarParametroDetalle(oParametroDetalleBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
        #endregion
    }
}