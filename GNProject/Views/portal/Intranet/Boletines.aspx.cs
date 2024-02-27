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



namespace GNProject.Views.portal.Intranet
{
    public partial class Boletines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaDistribucionxArea(TreeView1);
            }
        }

        private void ListaDistribucionxArea(TreeView tvw)
        {
            BUSBoletines objNegBoletines = new BUSBoletines();
            List<Capas.Portal.Entidad.Boletines> oListaBoletines = new List<Capas.Portal.Entidad.Boletines>();
            oListaBoletines = objNegBoletines.GetBoletinesAll();

            var listaAreas = oListaBoletines.GroupBy(s => s.Area).ToList();

            TreeNode nodo1 = new TreeNode();
            TreeNode nodo2 = new TreeNode();

            String path = Parametros.I_FileServer_RutaBoletines.Replace("~", "..");

            foreach (var Area in listaAreas)
            {
                String area = Area.Key;

                List<Capas.Portal.Entidad.Boletines> oDetalle = oListaBoletines.FindAll(b => b.Area == area);

                nodo1 = new TreeNode(area + " (" + oDetalle.Count + ")", area);

                foreach (Capas.Portal.Entidad.Boletines boletin in oDetalle)
                {
                    nodo2 = new TreeNode(boletin.Titulo, boletin.Boletin_Id, "", path + boletin.Ruta_Doc, "_blank");
                    nodo2.Expanded = false;
                    nodo2.SelectAction = TreeNodeSelectAction.Expand;
                    nodo1.ChildNodes.Add(nodo2);
                }
                nodo1.Expanded = false;
                nodo1.SelectAction = TreeNodeSelectAction.Expand;
                tvw.Nodes.Add(nodo1);
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSBoletines objNegBoletines = new BUSBoletines();
            List<Capas.Portal.Entidad.Boletines> oListaBoletines = new List<Capas.Portal.Entidad.Boletines>();
            oListaBoletines = objNegBoletines.GetBoletinesAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaBoletines.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.Boletines> orderedRecords = null;
            if (pSortColumn == "Boletin_Id") orderedRecords = oListaBoletines.OrderBy(col => col.Boletin_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaBoletines.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaBoletines.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaBoletines.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaBoletines.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaBoletines.OrderBy(col => col.sFecha);

            IEnumerable<Capas.Portal.Entidad.Boletines> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaBoletines.ToList();
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
            String path = Parametros.I_FileServer_RutaBoletines.Replace("~", "../../../");
            String enlace_doc = "<a title='Ver Boletin' class='link' target='_blank' href={0}{1}>{2}</a>";
            foreach (Capas.Portal.Entidad.Boletines obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Boletin_Id = obj.Boletin_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    Area = obj.Area,
                    Nombre_Doc = String.Format(enlace_doc, path, obj.Ruta_Doc.Replace(" ", "%20"), obj.Ruta_Doc),
                    sFecha = obj.sFecha
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