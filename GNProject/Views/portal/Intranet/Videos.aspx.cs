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
    public partial class Videos : System.Web.UI.Page
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
            BUSVideos objNegVideos = new BUSVideos();
            List<Capas.Portal.Entidad.Videos> oListaVideos = new List<Capas.Portal.Entidad.Videos>();
            oListaVideos = objNegVideos.GetVideosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaVideos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.Videos> orderedRecords = null;
            if (pSortColumn == "Video_Id") orderedRecords = oListaVideos.OrderBy(col => col.Video_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaVideos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Nombre_Video") orderedRecords = oListaVideos.OrderBy(col => col.Nombre_Video);
            else if (pSortColumn == "User_Name") orderedRecords = oListaVideos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaVideos.OrderBy(col => col.sFecha);

            IEnumerable<Capas.Portal.Entidad.Videos> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaVideos.ToList();
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
            String path = Parametros.I_FileServer_RutaVideos.Replace("~", "..");
            String enlace_video = "<a title='Ver Video' class='link-tabla' target='_blank' href={0}{1}>{2}</a>";
            foreach (Capas.Portal.Entidad.Videos obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Video_Id = obj.Video_Id,
                    Titulo = obj.Titulo,
                    Nombre_Video = String.Format(enlace_video, path, obj.Nombre_Video.Replace(" ", "%20"), obj.Nombre_Video),
                    User_Name = obj.User_Name,
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