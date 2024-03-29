﻿using GNProject.Acceso;
using GNProject.Entity;
using GNProject.Entity.BL;
using GNProject.Entity.Menu;
using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Security
{
    public partial class CPerfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_OpcionesAll()
        {
            MenuBL oMenuBL = new MenuBL();
            TreeViewBEList oTreeViewBEList = new TreeViewBEList();
            oTreeViewBEList = oMenuBL.Get_ArbolMenu();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oTreeViewBEList);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_OpcionesxPerfil(Int32 id_perfil)
        {
            MenuBL oMenuBL = new MenuBL();
            MenuBEList oMenuBEList = new MenuBEList();
            oMenuBEList = oMenuBL.Get_MenuxPerfil(id_perfil);

            String ids_menu = String.Empty;
            foreach (MenuBE obj in oMenuBEList)
            {
                ids_menu += obj.id_menu.ToString() + ",";
            }

            if (ids_menu.Length > 0) ids_menu = ids_menu.Substring(0, ids_menu.Length - 1);

            object[] strRetorno = new object[] { ids_menu };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PerfilBL oPerfilBL = new PerfilBL();

            String no_perfil = strFiltros[0];
            String fl_activo = strFiltros[1];
            Int32 id_usuario = ClaseGlobal.Get_IdUsuario_usuario();
            PerfilBEList oPerfilBEList = oPerfilBL.Get_ListaPerfiles(0, no_perfil, fl_activo);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oPerfilBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<PerfilBE> orderedRecords = null;
            if (pSortColumn == "id_perfil") orderedRecords = oPerfilBEList.OrderBy(col => col.id_perfil);
            else if (pSortColumn == "no_perfil") orderedRecords = oPerfilBEList.OrderBy(col => col.no_perfil);
            else if (pSortColumn == "no_estado") orderedRecords = oPerfilBEList.OrderBy(col => col.no_estado);

            IEnumerable<PerfilBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oPerfilBEList.ToList();
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
            foreach (PerfilBE obj in sortedRecords)
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
                    id_perfil = obj.id_perfil,
                    no_perfil = obj.no_perfil,
                    de_perfil = obj.tx_descripcion,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado,
                    ids_plantilla_doc = obj.ids_plantilla_doc
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
            PerfilBL oPerfilBL = new PerfilBL();
            PerfilBE oPerfilBE = new PerfilBE();
            object[] strRetorno;
            try
            {
                String[] arr_ids_plantillas = strParametros[5].ToString().Split(',');
                String ids_plantilla_doc = "";
                String delimit = "";
                foreach (String cod in arr_ids_plantillas)
                {
                    if (cod != "")
                    {
                        if (cod.Substring(0, 1) != "G" && cod.Substring(0, 1) != "S") //G- => Grupos | SG- => Sub Grupos
                        {
                            if (ids_plantilla_doc != "") { delimit = ","; }
                            ids_plantilla_doc += delimit + cod;
                        }
                    }
                }

                Int32 id_perfil; Int32.TryParse(strParametros[0].ToString(), out id_perfil);
                oPerfilBE.id_perfil = id_perfil;
                oPerfilBE.no_perfil = strParametros[1].ToString();
                oPerfilBE.tx_descripcion = strParametros[2].ToString();
                oPerfilBE.fl_activo = strParametros[3].ToString();
                oPerfilBE.cont_ids_menu = strParametros[4].ToString() == String.Empty ? 0 : strParametros[4].ToString().Split(',').Length;
                oPerfilBE.ids_menu = strParametros[4].ToString();
                oPerfilBE.ids_plantilla_doc = ids_plantilla_doc;
                oPerfilBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPerfilBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPerfilBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPerfilBL.GuardarPerfil(oPerfilBE, out retorno, out msg_retorno);

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
            PerfilBL oPerfilBL = new PerfilBL();
            PerfilBE oPerfilBE = new PerfilBE();
            object[] strRetorno;
            try
            {
                Int32 id_perfil;
                Int32.TryParse(strParametros[0].ToString(), out id_perfil);
                oPerfilBE.id_perfil = id_perfil;
                oPerfilBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oPerfilBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oPerfilBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPerfilBL.EliminarPerfil(oPerfilBE, out retorno, out msg_retorno);

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
        public static object Get_PlantillasDocAll()
        {
            MenuBL oMenuBL = new MenuBL();
            TreeViewBEList oTreeViewBEList = new TreeViewBEList();
            oTreeViewBEList = oMenuBL.Get_ArbolPlantillasDoc();

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oTreeViewBEList);
        }

    }
}