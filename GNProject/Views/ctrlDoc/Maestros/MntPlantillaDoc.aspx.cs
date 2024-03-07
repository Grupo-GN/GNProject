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
    public partial class MntPlantillaDoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDocBE oPlantillaDocBE = new PlantillaDocBE();
            oPlantillaDocBE.no_plantilla_doc = strFiltros[0];
            oPlantillaDocBE.fl_activo = strFiltros[1];
            List<PlantillaDocBE> oLista = oPlantillaDocBL.Get_ListaPlantillaDoc(oPlantillaDocBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<PlantillaDocBE> orderedRecords = null;
            if (pSortColumn == "id_plantilla_doc") orderedRecords = oLista.OrderBy(col => col.id_plantilla_doc);
            else if (pSortColumn == "no_plantilla_doc") orderedRecords = oLista.OrderBy(col => col.no_plantilla_doc);
            else if (pSortColumn == "no_grupo_doc") orderedRecords = oLista.OrderBy(col => col.no_grupo_doc);
            else if (pSortColumn == "no_sub_grupo_doc") orderedRecords = oLista.OrderBy(col => col.no_sub_grupo_doc);
            else if (pSortColumn == "no_estado") orderedRecords = oLista.OrderBy(col => col.no_estado);

            IEnumerable<PlantillaDocBE> sortedRecords;
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
            foreach (PlantillaDocBE obj in sortedRecords)
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
                    id_plantilla_doc = obj.id_plantilla_doc,
                    no_plantilla_doc = obj.no_plantilla_doc,
                    co_grupo_doc = obj.co_grupo_doc,
                    no_grupo_doc = obj.no_grupo_doc,
                    co_sub_grupo_doc = obj.co_sub_grupo_doc,
                    no_sub_grupo_doc = obj.no_sub_grupo_doc,
                    ids_usuarios_responsables = obj.ids_usuarios_responsables,
                    qt_dias_ant_venc_alerta = obj.qt_dias_ant_venc_alerta,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado,
                    cods_tipo_doc_archivo = obj.cods_tipo_doc_archivo
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
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDocBE oPlantillaDocBE = new PlantillaDocBE();
            object[] strRetorno;
            try
            {
                Int32 id_plantilla_doc; Int32.TryParse(strParametros[0].ToString(), out id_plantilla_doc);
                oPlantillaDocBE.id_plantilla_doc = id_plantilla_doc;
                oPlantillaDocBE.no_plantilla_doc = strParametros[1].ToString();
                oPlantillaDocBE.co_sub_grupo_doc = strParametros[2].ToString();
                oPlantillaDocBE.fl_activo = strParametros[3].ToString();
                oPlantillaDocBE.cods_tipo_doc_archivo = strParametros[4].ToString();

                oPlantillaDocBE.cont_ids_caracteristica = Convert.ToInt32(strParametros[5].ToString());
                oPlantillaDocBE.ids_PlantillaDoccaracteristica = strParametros[6].ToString();
                oPlantillaDocBE.cad_no_caracteristica = strParametros[7].ToString();
                oPlantillaDocBE.cad_co_tipo_dato_caracteristica = strParametros[8].ToString();
                oPlantillaDocBE.cad_fl_obligatorio_caracteristica = strParametros[9].ToString();
                oPlantillaDocBE.cad_nu_orden_caracteristica = strParametros[10].ToString();
                oPlantillaDocBE.cad_qt_dias_alerta_caracteristica = strParametros[11].ToString();
                oPlantillaDocBE.ids_usuarios_responsables = strParametros[12].ToString();
                Int32 qt_dias_ant_venc_alerta; Int32.TryParse(strParametros[13].ToString(), out qt_dias_ant_venc_alerta);
                oPlantillaDocBE.qt_dias_ant_venc_alerta = qt_dias_ant_venc_alerta;

                oPlantillaDocBE.cont_ids_file = Convert.ToInt32(strParametros[14].ToString());
                oPlantillaDocBE.ids_PlantillaDoc_File = strParametros[15].ToString();
                oPlantillaDocBE.cad_no_documento = strParametros[16].ToString();

                oPlantillaDocBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPlantillaDocBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPlantillaDocBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPlantillaDocBL.GuardarPlantillaDoc(oPlantillaDocBE, out retorno, out msg_retorno);

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
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDocBE oPlantillaDocBE = new PlantillaDocBE();
            object[] strRetorno;
            try
            {
                Int32 id_plantilla_doc;
                Int32.TryParse(strParametros[0].ToString(), out id_plantilla_doc);
                oPlantillaDocBE.id_plantilla_doc = id_plantilla_doc;
                oPlantillaDocBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPlantillaDocBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPlantillaDocBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPlantillaDocBL.EliminarPlantillaDoc(oPlantillaDocBE, out retorno, out msg_retorno);

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
        public static object Get_PlantillaDoc_Caracteristica(Int32 id_plantilla_doc)
        {
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDoc_CaracteristicaBEList oPlantillaDoc_CaracteristicaBEList = new PlantillaDoc_CaracteristicaBEList();

            oPlantillaDoc_CaracteristicaBEList = oPlantillaDocBL.Get_ListaPlantillaDoc_Caracteristica(id_plantilla_doc);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oPlantillaDoc_CaracteristicaBEList);
        }

        [WebMethod]
        public static object Get_PlantillaDoc_File(Int32 id_plantilla_doc)
        {
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDoc_FileBEList oPlantillaDoc_FileBEList = new PlantillaDoc_FileBEList();

            oPlantillaDoc_FileBEList = oPlantillaDocBL.Get_ListaPlantillaDoc_File(id_plantilla_doc);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oPlantillaDoc_FileBEList);
        }
    }
}