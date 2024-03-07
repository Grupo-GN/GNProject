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
    public partial class MntAreas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
        , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            AreaBL oAreaBL = new AreaBL();

            String no_area = strFiltros[0];
            String fl_activo = strFiltros[1];
            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            AreaBEList oAreaBEList = oAreaBL.Get_ListaAreas(0, no_area, fl_activo, id_usuario);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oAreaBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<AreaBE> orderedRecords = null;
            if (pSortColumn == "id_area") orderedRecords = oAreaBEList.OrderBy(col => col.id_area);
            else if (pSortColumn == "no_area") orderedRecords = oAreaBEList.OrderBy(col => col.no_area);
            else if (pSortColumn == "no_estado") orderedRecords = oAreaBEList.OrderBy(col => col.no_estado);

            IEnumerable<AreaBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oAreaBEList.ToList();
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
            foreach (AreaBE obj in sortedRecords)
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
                    id_area = obj.id_area,
                    no_area = obj.no_area,
                    co_homologacion = obj.co_homologacion,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado,
                    ids_usuario_responsable = obj.ids_usuario_responsable
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
            AreaBL oAreaBL = new AreaBL();
            AreaBE oAreaBE = new AreaBE();
            object[] strRetorno;
            try
            {
                Int32 id_area;
                Int32.TryParse(strParametros[0].ToString(), out id_area);
                oAreaBE.id_area = id_area;
                oAreaBE.no_area = strParametros[1].ToString();
                oAreaBE.co_homologacion = strParametros[2].ToString();
                oAreaBE.fl_activo = strParametros[3].ToString();
                oAreaBE.ids_usuario_responsable = strParametros[4].ToString();
                oAreaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oAreaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oAreaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oAreaBL.GuardarArea(oAreaBE, out retorno, out msg_retorno);

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
            AreaBL oAreaBL = new AreaBL();
            AreaBE oAreaBE = new AreaBE();
            object[] strRetorno;
            try
            {
                Int32 id_area;
                Int32.TryParse(strParametros[0].ToString(), out id_area);
                oAreaBE.id_area = id_area;
                oAreaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oAreaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oAreaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oAreaBL.EliminarArea(oAreaBE, out retorno, out msg_retorno);

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