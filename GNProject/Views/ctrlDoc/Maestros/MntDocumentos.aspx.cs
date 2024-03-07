using CtrlDocumentos.BE;
using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.BE.Seguridad;
using CtrlDocumentos.BL;
using CtrlDocumentos.BL.Maestros;
using CtrlDocumentos.BL.Seguridad;
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
    public partial class MntDocumentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Int32 idUsuario = ClaseGlobal.Get_IdUsuario_usuario();
                UsuarioBE ent = new UsuarioBE();
                ent.id_usuario = idUsuario;
                UsuarioBEList oUsuarioBEList = new UsuarioBL().Get_ListaUsuarios(ent);
                UsuarioBE oUsuarioBE = new UsuarioBE();
                oUsuarioBE = oUsuarioBEList[0];
                if (!oUsuarioBE.fl_archivar_doc)
                {
                    btnArchivar.Visible = false;
                    btnDesarchivar.Visible = false;

                    btnArchivarArchivo.Visible = false;
                    btnDesarchivarArchivo.Visible = false;
                }
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_DatosPlantilla(Int32 id_plantilla_doc)
        {
            PlantillaDocBL oPlantillaDocBL = new PlantillaDocBL();
            PlantillaDocBE oPlantillaDocBE = new PlantillaDocBE();
            PlantillaDoc_CaracteristicaBEList oPlantillaDoc_CaracteristicaBEList = new PlantillaDoc_CaracteristicaBEList();
            PlantillaDoc_FileBEList oPlantillaDoc_FileBEList = new PlantillaDoc_FileBEList();

            PlantillaDocBE ent = new PlantillaDocBE();
            ent.id_plantilla_doc = id_plantilla_doc;

            //Obtiene datos
            oPlantillaDocBE = oPlantillaDocBL.Get_ListaPlantillaDoc(ent)[0];
            oPlantillaDoc_CaracteristicaBEList = oPlantillaDocBL.Get_ListaPlantillaDoc_Caracteristica(id_plantilla_doc);
            oPlantillaDoc_FileBEList = oPlantillaDocBL.Get_ListaPlantillaDoc_File(id_plantilla_doc);

            object[] objListaCaracteristicas = new object[oPlantillaDoc_CaracteristicaBEList.Count];
            int i = 0;
            Int32 id_documento_caracteristica;
            foreach (PlantillaDoc_CaracteristicaBE o in oPlantillaDoc_CaracteristicaBEList)
            {
                i += 1;
                id_documento_caracteristica = i * -1;
                object objCaracteristica = new
                {
                    id_documento_caracteristica = id_documento_caracteristica,
                    no_caracteristica = o.no_caracteristica,
                    co_tipo_dato = o.co_tipo_dato,
                    no_valor_dato = "",
                    txt_obligatorio = o.txt_obligatorio,
                    nu_orden = o.nu_orden,
                    no_archivo = ""
                };
                objListaCaracteristicas[i - 1] = objCaracteristica;
            }

            object[] objListaFiles = new object[oPlantillaDoc_FileBEList.Count];
            i = 0;
            Int32 id_documento_file;
            foreach (PlantillaDoc_FileBE o in oPlantillaDoc_FileBEList)
            {
                i += 1;
                id_documento_file = i * -1;
                object objFile = new
                {
                    id_documento_file = id_documento_file,
                    co_tipo_doc = "",
                    no_tipo_doc = "",
                    no_documento = o.no_documento,
                    no_file = "",
                    qt_peso = "",
                    no_folder = "",
                    no_file_all = "",
                    tx_principal = "",
                    fl_principal = "",
                    tx_activar_alerta = "",
                    fl_activar_alerta = "",
                    sfe_inicio = "",
                    sfe_vencimiento = "",
                    ids_usuarios_responsables = "",
                    qt_dias_ant_venc_alerta = "",
                    fl_reservado = "",
                    co_estado = "",
                    no_estado = ""
                };
                objListaFiles[i - 1] = objFile;
            }

            ComboBL oComboBL = new ComboBL();
            String prmXML = "<prm IDPlantillaDoc='" + id_plantilla_doc + "' />";
            ComboBEList oComboTipoDocArchivo = oComboBL.Get_Combo(Parametros.Combo.CDOC_TipoDoc_Archivos, prmXML);

            object obj = new
            {
                objCaracteristicas = objListaCaracteristicas
                ,
                ids_usuarios_responsables = oPlantillaDocBE.ids_usuarios_responsables
                ,
                qt_dias_ant_venc_alerta = oPlantillaDocBE.qt_dias_ant_venc_alerta
                ,
                objFiles = objListaFiles
                ,
                oComboTipoDocArchivo = oComboTipoDocArchivo
            };
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Documento_Caracteristica(Int32 id_documento)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_CaracteristicaBEList oDocumento_CaracteristicaBEList = new Documento_CaracteristicaBEList();

            oDocumento_CaracteristicaBEList = oDocumentoBL.Get_ListaDocumento_Caracteristica(id_documento);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oDocumento_CaracteristicaBEList);
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

            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            oDocumentoBE.co_grupo_doc = co_grupo_doc;
            oDocumentoBE.co_sub_grupo_doc = co_sub_grupo_doc;
            oDocumentoBE.id_plantilla_doc = id_plantilla_doc;
            oDocumentoBE.no_documento = no_documento;
            oDocumentoBE.co_tipo_asignacion = co_tipo_asignacion;
            oDocumentoBE.ids_persona_empresa = ids_persona_empresa;
            oDocumentoBE.sfe_vencimiento_desde = fe_vencimiento_desde;
            oDocumentoBE.sfe_vencimiento_hasta = fe_vencimiento_hasta;
            oDocumentoBE.cods_estado = cods_estado;
            oDocumentoBE.cods_tipo_doc_file = cods_tipo_doc;
            oDocumentoBE.id_area = id_area;
            oDocumentoBE.id_seccion = id_seccion;
            oDocumentoBE.id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            List<DocumentoBE> oLista = oDocumentoBL.Get_ListaDocumento(oDocumentoBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<DocumentoBE> orderedRecords = null;
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

            IEnumerable<DocumentoBE> sortedRecords;
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
            foreach (DocumentoBE obj in sortedRecords)
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
                    fe_vencimiento = (obj.fe_vencimiento.ToString("dd/MM/yyyy") == "01/01/1900" ? "" : obj.fe_vencimiento.ToShortDateString()),
                    qt_dias_para_vencimiento = obj.qt_dias_para_vencimiento,
                    no_tipo_asignacion = obj.no_tipo_asignacion,
                    no_persona_empresa = obj.no_persona_empresa,
                    id_plantilla_doc = obj.id_plantilla_doc,
                    co_estado = obj.co_estado,
                    no_estado = obj.no_estado,
                    co_tipo_asignacion = obj.co_tipo_asignacion,
                    id_persona_empresa = (obj.id_persona > 0 ? obj.id_persona : obj.id_empresa),
                    ids_usuarios_responsables = obj.ids_usuarios_responsables,
                    qt_dias_ant_venc_alerta = obj.qt_dias_ant_venc_alerta,
                    co_grupo_doc = obj.co_grupo_doc,
                    co_sub_grupo_doc = obj.co_sub_grupo_doc
                    //imgOpciones = imgOpciones
                };
                oJQGridJsonResponseRow.Row = filas;
                responseJQGrid.Items.Add(oJQGridJsonResponseRow);
                i++;
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(responseJQGrid);
        }

        [WebMethod]
        public static object getBandeja_SubGrid_Files(String[] strParametros)
        {
            Int32 id_documento = Convert.ToInt32(strParametros[0]);
            String cods_tipo_documento = strParametros[1];

            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBEList oDocumento_FileBEList = new Documento_FileBEList();

            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();

            Documento_FileBE oDocumentoFileBE = new Documento_FileBE();
            oDocumentoFileBE.id_documento = id_documento;
            oDocumentoFileBE.co_tipo_doc = cods_tipo_documento;
            oDocumento_FileBEList = oDocumentoBL.Get_ListaDocumento_Files(oDocumentoFileBE, id_usuario);

            object response = new
            {
                oBandeja = oDocumento_FileBEList
            };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Documento(Int32 id_documento)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE ent = new DocumentoBE();
            ent.id_documento = id_documento;
            ent.id_usuario = ClaseGlobal.Get_IdUsuario_usuario();

            //Obtiene datos
            List<DocumentoBE> oLista = oDocumentoBL.Get_ListaDocumento(ent);
            DocumentoBE oDocumentoBE = oLista[0];

            ComboBL oComboBL = new ComboBL();
            String prmXML = "<prm IDPlantillaDoc='" + oDocumentoBE.id_plantilla_doc + "' />";
            ComboBEList oComboTipoDocArchivo = oComboBL.Get_Combo(Parametros.Combo.CDOC_TipoDoc_Archivos, prmXML);

            object objDocumento = new
            {
                id_documento = oDocumentoBE.id_documento,
                co_grupo_doc = oDocumentoBE.co_grupo_doc,
                no_grupo_doc = oDocumentoBE.no_grupo_doc,
                co_sub_grupo_doc = oDocumentoBE.co_sub_grupo_doc,
                no_sub_grupo_doc = oDocumentoBE.no_sub_grupo_doc,
                id_plantilla_doc = oDocumentoBE.id_plantilla_doc,
                no_plantilla_doc = oDocumentoBE.no_plantilla_doc,
                no_documento = oDocumentoBE.no_documento,
                fe_inicio = oDocumentoBE.fe_inicio.ToShortDateString(),
                fe_vencimiento = (oDocumentoBE.fe_vencimiento.ToString("dd/MM/yyyy") == "01/01/1900" ? "" : oDocumentoBE.fe_vencimiento.ToShortDateString()),
                co_estado = oDocumentoBE.co_estado,
                co_tipo_asignacion = oDocumentoBE.co_tipo_asignacion,
                id_persona_empresa = (oDocumentoBE.id_persona > 0 ? oDocumentoBE.id_persona : oDocumentoBE.id_empresa),
                ids_usuarios_responsables = oDocumentoBE.ids_usuarios_responsables,
                qt_dias_ant_venc_alerta = oDocumentoBE.qt_dias_ant_venc_alerta,
                fl_reservado = oDocumentoBE.fl_reservado,
                oComboTipoDocArchivo = oComboTipoDocArchivo
            };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(objDocumento);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Guardar(object[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento; Int32.TryParse(strParametros[0].ToString(), out id_documento);
                Int32 id_plantilla_doc; Int32.TryParse(strParametros[1].ToString(), out id_plantilla_doc);
                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.id_plantilla_doc = id_plantilla_doc;
                oDocumentoBE.no_documento = strParametros[2].ToString();
                oDocumentoBE.co_tipo_asignacion = strParametros[3].ToString();
                oDocumentoBE.id_persona_empresa = Convert.ToInt32(strParametros[4].ToString());
                oDocumentoBE.fe_inicio = Convert.ToDateTime(strParametros[5].ToString());
                String sfe_vencimiento = strParametros[6].ToString();
                if (String.IsNullOrEmpty(sfe_vencimiento)) { sfe_vencimiento = "01/01/1900"; }
                oDocumentoBE.fe_vencimiento = Convert.ToDateTime(sfe_vencimiento);
                oDocumentoBE.ids_usuarios_responsables = strParametros[7].ToString();
                Int32 qt_dias_ant_venc_alerta; Int32.TryParse(strParametros[8].ToString(), out qt_dias_ant_venc_alerta);
                oDocumentoBE.qt_dias_ant_venc_alerta = qt_dias_ant_venc_alerta;
                oDocumentoBE.co_estado = strParametros[9].ToString();
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                oDocumentoBE.cont_ids_caracteristica = Convert.ToInt32(strParametros[10].ToString());
                oDocumentoBE.ids_documento_caracteristica = strParametros[11].ToString();
                oDocumentoBE.cad_no_caracteristica = strParametros[12].ToString();
                oDocumentoBE.cad_co_tipo_dato_caracteristica = strParametros[13].ToString();
                oDocumentoBE.cad_no_valor_dato_caracteristica = strParametros[14].ToString();
                oDocumentoBE.cad_fl_obligatorio_caracteristica = strParametros[15].ToString();
                oDocumentoBE.cad_nu_orden_caracteristica = strParametros[16].ToString();
                oDocumentoBE.cad_no_archivo_caracteristica = strParametros[17].ToString();

                Int32 idRenov; Int32.TryParse(strParametros[18].ToString(), out idRenov);
                oDocumentoBE.id_documento_ori = idRenov;

                oDocumentoBE.fl_reservado = Convert.ToBoolean(strParametros[19]);

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.GuardarDocumento(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [WebMethod]
        public static object Archivar(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento; Int32.TryParse(strParametros[0].ToString(), out id_documento);

                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();
                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.Archivar(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [WebMethod]
        public static object Desarchivar(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento; Int32.TryParse(strParametros[0].ToString(), out id_documento);

                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();
                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.Desarchivar(oDocumentoBE, out retorno, out msg_retorno);

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
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento;
                Int32.TryParse(strParametros[0].ToString(), out id_documento);
                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.EliminarDocumento(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [WebMethod]
        public static object Activar(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            DocumentoBE oDocumentoBE = new DocumentoBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento;
                Int32.TryParse(strParametros[0].ToString(), out id_documento);
                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.ActivarDocumento(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        #region "Métodos Archivos Documento"
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object GrabarDocumentoFile(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBE oDocumentoBE = new Documento_FileBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento; Int32.TryParse(strParametros[0].ToString(), out id_documento);
                Int32 qt_peso; Int32.TryParse(strParametros[3].ToString(), out qt_peso);
                Int32 id_documento_file; Int32.TryParse(strParametros[10].ToString(), out id_documento_file);
                Int32 qt_dias_ant_venc_alerta; Int32.TryParse(strParametros[12].ToString(), out qt_dias_ant_venc_alerta);
                Int32 id_documento_file_ori; Int32.TryParse(strParametros[13].ToString(), out id_documento_file_ori);

                oDocumentoBE.id_documento = id_documento;
                oDocumentoBE.no_documento = strParametros[1].ToString();
                oDocumentoBE.no_file = strParametros[2].ToString();
                oDocumentoBE.qt_peso = qt_peso;
                oDocumentoBE.co_usuario = strParametros[4].ToString();
                oDocumentoBE.no_usuario_red = strParametros[5].ToString();
                oDocumentoBE.no_estacion_red = strParametros[6].ToString();
                oDocumentoBE.fl_activar_alerta = strParametros[7].ToString();
                oDocumentoBE.sfe_inicio = strParametros[8].ToString();
                oDocumentoBE.sfe_vencimiento = strParametros[9].ToString();
                oDocumentoBE.id_documento_file = id_documento_file;
                oDocumentoBE.fl_principal = strParametros[11].ToString();
                oDocumentoBE.ids_usuarios_responsables = strParametros[15].ToString();
                oDocumentoBE.qt_dias_ant_venc_alerta = qt_dias_ant_venc_alerta;
                oDocumentoBE.co_tipo_doc = strParametros[14].ToString();
                oDocumentoBE.fl_reservado = strParametros[16].ToString();
                oDocumentoBE.id_documento_file_ori = id_documento_file_ori;

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.GuardarDocumentoFile(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [WebMethod]
        public static object ArchivarFile(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBE oDocumentoBE = new Documento_FileBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento_file; Int32.TryParse(strParametros[0].ToString(), out id_documento_file);

                oDocumentoBE.id_documento_file = id_documento_file;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();
                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.ArchivarFile(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [WebMethod]
        public static object DesarchivarFile(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBE oDocumentoBE = new Documento_FileBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento_file; Int32.TryParse(strParametros[0].ToString(), out id_documento_file);

                oDocumentoBE.id_documento_file = id_documento_file;
                oDocumentoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oDocumentoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oDocumentoBE.no_estacion_red = ClaseGlobal.getEstacionRed();
                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.DesarchivarFile(oDocumentoBE, out retorno, out msg_retorno);

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
        public static object Get_ListaDocumento_Files(Int32 id_documento)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBEList oDocumento_FileBEList = new Documento_FileBEList();

            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();

            Documento_FileBE oDocumentoFileBE = new Documento_FileBE();
            oDocumentoFileBE.id_documento = id_documento;
            oDocumento_FileBEList = oDocumentoBL.Get_ListaDocumento_Files(oDocumentoFileBE, id_usuario);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oDocumento_FileBEList);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object EliminarDocumento_File(String[] strParametros)
        {
            DocumentoBL oDocumentoBL = new DocumentoBL();
            Documento_FileBE oDocumentoBE = new Documento_FileBE();
            object[] strRetorno;
            try
            {
                Int32 id_documento_file;
                Int32.TryParse(strParametros[0].ToString(), out id_documento_file);
                oDocumentoBE.id_documento_file = id_documento_file;
                oDocumentoBE.co_usuario = strParametros[1].ToString();
                oDocumentoBE.no_usuario_red = strParametros[2].ToString();
                oDocumentoBE.no_estacion_red = strParametros[3].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oDocumentoBL.EliminarDocumento_File(oDocumentoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
        #endregion "Métodos Archivos Documento"

        [WebMethod]
        public static object getDatosPersona(Int32 id_persona)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBE oPersonaBE = new PersonaBE();
            oPersonaBE.id_persona = id_persona;
            PersonaBE ent = oPersonaBL.Get_ListaPersonas(oPersonaBE)[0];

            TipoContratoBL oTipoContratoBL = new TipoContratoBL();
            String no_tipo_contrato = oTipoContratoBL.Get_ListaTipoContratos(ent.id_tipo_contrato, "", "")[0].no_tipo_contrato;
            Boolean fl_indeterminado = false;
            if (no_tipo_contrato.ToUpper().IndexOf("INDETERMINADO") > 0)
            {
                fl_indeterminado = true;
            }

            object objPersona = new
            {
                fe_ingreso = (ent.fe_ingreso == "01/01/1900" ? "" : ent.fe_ingreso),
                fe_fin_contrato = (ent.fe_fin_contrato == "01/01/1900" ? "" : ent.fe_fin_contrato),
                fl_indeterminado = (fl_indeterminado ? "1" : "0")
            };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(objPersona);
        }
    }
}