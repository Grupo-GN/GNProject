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
    public partial class Procedimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSProcedimientos objNegProcedimientos = new BUSProcedimientos();
            List<Capas.Portal.Entidad.Procedimientos> oListaProcedimientos = new List<Capas.Portal.Entidad.Procedimientos>();
            oListaProcedimientos = objNegProcedimientos.GetProcedimientosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaProcedimientos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.Procedimientos> orderedRecords = null;
            if (pSortColumn == "Procedimiento_Id") orderedRecords = oListaProcedimientos.OrderBy(col => col.Procedimiento_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaProcedimientos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaProcedimientos.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaProcedimientos.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaProcedimientos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaProcedimientos.OrderBy(col => col.sFecha);

            IEnumerable<Capas.Portal.Entidad.Procedimientos> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaProcedimientos.ToList();
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
            String path = Parametros.I_FileServer_RutaProcedimientos.Replace("~", "../../../");
            String enlace_doc = "<a title='Ver Documento' class='link' target='_blank' href={0}{1}>{2}</a>";
            foreach (Capas.Portal.Entidad.Procedimientos obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Procedimiento_Id = obj.Procedimiento_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    Area = obj.Area,
                    Nombre_Doc = String.Format(enlace_doc, path, obj.Nombre_Doc.Replace(" ", "%20"), obj.Nombre_Doc),
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