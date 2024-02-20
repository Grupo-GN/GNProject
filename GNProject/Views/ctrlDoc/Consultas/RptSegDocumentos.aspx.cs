using CtrlDocumentos.BE.Consultas;
using CtrlDocumentos.BL.Consultas;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.ctrlDoc.Consultas
{
    public partial class RptSegDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
        , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            #region "- Get variables Request"
            String co_grupo_doc = strFiltros[0];
            Int32 id_plantilla_doc; Int32.TryParse(strFiltros[1], out id_plantilla_doc);
            String no_documento = strFiltros[2];
            String co_tipo_asignacion = strFiltros[3];
            String ids_persona_empresa = strFiltros[4];
            String fe_vencimiento_desde = strFiltros[5];
            String fe_vencimiento_hasta = strFiltros[6];
            String cods_estado = strFiltros[7];
            String co_sub_grupo_doc = strFiltros[8];
            String cods_tipo_doc = strFiltros[9];
            Int32 id_area; Int32.TryParse(strFiltros[10], out id_area);
            Int32 id_seccion; Int32.TryParse(strFiltros[11], out id_seccion);
            #endregion "- Get variables Request"

            ReportesBL oReportesBL = new ReportesBL();
            RptSegDocumentosBE oRptSegDocumentosBE = new RptSegDocumentosBE();
            oRptSegDocumentosBE.co_grupo_doc = co_grupo_doc;
            oRptSegDocumentosBE.co_sub_grupo_doc = co_sub_grupo_doc;
            oRptSegDocumentosBE.id_plantilla_doc = id_plantilla_doc;
            oRptSegDocumentosBE.no_documento = no_documento;
            oRptSegDocumentosBE.co_tipo_asignacion = co_tipo_asignacion;
            oRptSegDocumentosBE.ids_persona_empresa = ids_persona_empresa;
            oRptSegDocumentosBE.sfe_vencimiento_desde = fe_vencimiento_desde;
            oRptSegDocumentosBE.sfe_vencimiento_hasta = fe_vencimiento_hasta;
            oRptSegDocumentosBE.cods_estado = cods_estado;
            oRptSegDocumentosBE.co_tipo_doc = cods_tipo_doc;
            oRptSegDocumentosBE.id_area = id_area;
            oRptSegDocumentosBE.id_seccion = id_seccion;
            oRptSegDocumentosBE.id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            List<RptSegDocumentosBE> oLista = oReportesBL.getReporte_SegDocumentos(oRptSegDocumentosBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<RptSegDocumentosBE> orderedRecords = null;
            if (pSortColumn == "id_documento") orderedRecords = oLista.OrderBy(col => col.id_documento);
            else if (pSortColumn == "no_grupo_doc") orderedRecords = oLista.OrderBy(col => col.no_grupo_doc);
            else if (pSortColumn == "no_sub_grupo_doc") orderedRecords = oLista.OrderBy(col => col.no_sub_grupo_doc);
            else if (pSortColumn == "no_plantilla_doc") orderedRecords = oLista.OrderBy(col => col.no_plantilla_doc);
            else if (pSortColumn == "no_documento") orderedRecords = oLista.OrderBy(col => col.no_documento);
            else if (pSortColumn == "fe_inicio") orderedRecords = oLista.OrderBy(col => col.fe_inicio);
            else if (pSortColumn == "fe_vencimiento") orderedRecords = oLista.OrderBy(col => col.fe_vencimiento);
            else if (pSortColumn == "qt_dias_para_vencimiento") orderedRecords = oLista.OrderBy(col => col.qt_dias_para_vencimiento);
            else if (pSortColumn == "no_tipo_asignacion") orderedRecords = oLista.OrderBy(col => col.no_tipo_asignacion);
            else if (pSortColumn == "no_persona_empresa") orderedRecords = oLista.OrderBy(col => col.no_persona_empresa);
            else if (pSortColumn == "no_estado") orderedRecords = oLista.OrderBy(col => col.no_estado);

            IEnumerable<RptSegDocumentosBE> sortedRecords;
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
            foreach (RptSegDocumentosBE obj in sortedRecords)
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
                    id_documento = obj.id_documento,
                    no_grupo_doc = obj.no_grupo_doc,
                    no_sub_grupo_doc = obj.no_sub_grupo_doc,
                    no_plantilla_doc = obj.no_plantilla_doc,
                    no_documento = obj.no_documento,
                    fe_inicio = obj.fe_inicio.ToShortDateString(),
                    fe_vencimiento = obj.sfe_vencimiento,
                    qt_dias_para_vencimiento = obj.qt_dias_para_vencimiento,
                    no_tipo_asignacion = obj.no_tipo_asignacion,
                    //id_persona_empresa = (obj.id_persona > 0 ? obj.id_persona : obj.id_empresa),
                    no_persona_empresa = obj.no_persona_empresa,
                    id_plantilla_doc = obj.id_plantilla_doc,
                    co_estado = obj.co_estado,
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
    }
}