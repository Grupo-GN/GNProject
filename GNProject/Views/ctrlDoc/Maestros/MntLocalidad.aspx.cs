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
    public partial class MntLocalidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            LocalidadBL oLocalidadBL = new LocalidadBL();

            String no_localidad = strFiltros[0];
            String fl_activo = strFiltros[1];
            LocalidadBEList oLocalidadBEList = oLocalidadBL.Get_ListaLocalidades(0, no_localidad, fl_activo);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLocalidadBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<LocalidadBE> orderedRecords = null;
            if (pSortColumn == "id_localidad") orderedRecords = oLocalidadBEList.OrderBy(col => col.id_localidad);
            else if (pSortColumn == "no_localidad") orderedRecords = oLocalidadBEList.OrderBy(col => col.no_localidad);
            else if (pSortColumn == "no_estado") orderedRecords = oLocalidadBEList.OrderBy(col => col.no_estado);

            IEnumerable<LocalidadBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oLocalidadBEList.ToList();
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
            foreach (LocalidadBE obj in sortedRecords)
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
                    id_localidad = obj.id_localidad,
                    no_localidad = obj.no_localidad,
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
            LocalidadBL oLocalidadBL = new LocalidadBL();
            LocalidadBE oLocalidadBE = new LocalidadBE();
            object[] strRetorno;
            try
            {
                Int32 id_localidad;
                Int32.TryParse(strParametros[0].ToString(), out id_localidad);
                oLocalidadBE.id_localidad = id_localidad;
                oLocalidadBE.no_localidad = strParametros[1].ToString();
                oLocalidadBE.co_homologacion = strParametros[2].ToString();
                oLocalidadBE.fl_activo = strParametros[3].ToString();
                oLocalidadBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oLocalidadBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oLocalidadBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oLocalidadBL.GuardarLocalidad(oLocalidadBE, out retorno, out msg_retorno);

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
            LocalidadBL oLocalidadBL = new LocalidadBL();
            LocalidadBE oLocalidadBE = new LocalidadBE();
            object[] strRetorno;
            try
            {
                Int32 id_localidad;
                Int32.TryParse(strParametros[0].ToString(), out id_localidad);
                oLocalidadBE.id_localidad = id_localidad;
                oLocalidadBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oLocalidadBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oLocalidadBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oLocalidadBL.EliminarLocalidad(oLocalidadBE, out retorno, out msg_retorno);

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