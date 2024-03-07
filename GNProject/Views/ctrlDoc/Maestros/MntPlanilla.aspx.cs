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
    public partial class MntPlanilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PlanillaBL oPlanillaBL = new PlanillaBL();

            String no_planilla = strFiltros[0];
            String fl_activo = strFiltros[1];
            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            PlanillaBEList oPlanillaBEList = oPlanillaBL.Get_ListaPlanilla(0, no_planilla, fl_activo);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oPlanillaBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<PlanillaBE> orderedRecords = null;
            if (pSortColumn == "id_planilla") orderedRecords = oPlanillaBEList.OrderBy(col => col.id_planilla);
            else if (pSortColumn == "no_planilla") orderedRecords = oPlanillaBEList.OrderBy(col => col.no_planilla);
            else if (pSortColumn == "no_estado") orderedRecords = oPlanillaBEList.OrderBy(col => col.no_estado);

            IEnumerable<PlanillaBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oPlanillaBEList.ToList();
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
            foreach (PlanillaBE obj in sortedRecords)
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
                    id_planilla = obj.id_planilla,
                    no_planilla = obj.no_planilla,
                    de_planilla = obj.de_planilla,
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
            PlanillaBL oPlanillaBL = new PlanillaBL();
            PlanillaBE oPlanillaBE = new PlanillaBE();
            object[] strRetorno;
            try
            {
                Int32 id_planilla; Int32.TryParse(strParametros[0].ToString(), out id_planilla);
                oPlanillaBE.id_planilla = id_planilla;
                oPlanillaBE.no_planilla = strParametros[1].ToString();
                oPlanillaBE.de_planilla = strParametros[2].ToString();
                oPlanillaBE.co_homologacion = strParametros[3].ToString();
                oPlanillaBE.fl_activo = strParametros[4].ToString();
                oPlanillaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPlanillaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPlanillaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPlanillaBL.GuardarPlanilla(oPlanillaBE, out retorno, out msg_retorno);

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
            PlanillaBL oPlanillaBL = new PlanillaBL();
            PlanillaBE oPlanillaBE = new PlanillaBE();
            object[] strRetorno;
            try
            {
                Int32 id_planilla;
                Int32.TryParse(strParametros[0].ToString(), out id_planilla);
                oPlanillaBE.id_planilla = id_planilla;
                oPlanillaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPlanillaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPlanillaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPlanillaBL.EliminarPlanilla(oPlanillaBE, out retorno, out msg_retorno);

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