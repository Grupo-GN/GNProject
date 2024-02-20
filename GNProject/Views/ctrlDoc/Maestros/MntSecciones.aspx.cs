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
    public partial class MntSecciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            SeccionBL oSeccionBL = new SeccionBL();

            Int32 id_area; Int32.TryParse(strFiltros[0], out id_area);
            String no_seccion = strFiltros[1];
            String fl_activo = strFiltros[2];
            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            SeccionBEList oSeccionBEList = oSeccionBL.Get_ListaSeccion(0, no_seccion, id_area, fl_activo, id_usuario);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oSeccionBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<SeccionBE> orderedRecords = null;
            if (pSortColumn == "id_seccion") orderedRecords = oSeccionBEList.OrderBy(col => col.id_seccion);
            else if (pSortColumn == "no_seccion") orderedRecords = oSeccionBEList.OrderBy(col => col.no_seccion);
            else if (pSortColumn == "no_area") orderedRecords = oSeccionBEList.OrderBy(col => col.no_area);
            else if (pSortColumn == "no_estado") orderedRecords = oSeccionBEList.OrderBy(col => col.no_estado);

            IEnumerable<SeccionBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oSeccionBEList.ToList();
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
            foreach (SeccionBE obj in sortedRecords)
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
                    id_seccion = obj.id_seccion,
                    no_seccion = obj.no_seccion,
                    de_seccion = obj.de_seccion,
                    id_area = obj.id_area,
                    no_area = obj.no_area,
                    co_homologacion = obj.co_homologacion,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado
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
            SeccionBL oSeccionBL = new SeccionBL();
            SeccionBE oSeccionBE = new SeccionBE();
            object[] strRetorno;
            try
            {
                Int32 id_seccion; Int32.TryParse(strParametros[0].ToString(), out id_seccion);
                Int32 id_area; Int32.TryParse(strParametros[3].ToString(), out id_area);
                oSeccionBE.id_seccion = id_seccion;
                oSeccionBE.no_seccion = strParametros[1].ToString();
                oSeccionBE.de_seccion = strParametros[2].ToString();
                oSeccionBE.id_area = id_area;
                oSeccionBE.co_homologacion = strParametros[4].ToString();
                oSeccionBE.fl_activo = strParametros[5].ToString();
                oSeccionBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oSeccionBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oSeccionBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oSeccionBL.GuardarSeccion(oSeccionBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
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
        public static object Eliminar(String[] strParametros)
        {
            SeccionBL oSeccionBL = new SeccionBL();
            SeccionBE oSeccionBE = new SeccionBE();
            object[] strRetorno;
            try
            {
                Int32 id_seccion;
                Int32.TryParse(strParametros[0].ToString(), out id_seccion);
                oSeccionBE.id_seccion = id_seccion;
                oSeccionBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oSeccionBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oSeccionBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oSeccionBL.EliminarSeccion(oSeccionBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
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