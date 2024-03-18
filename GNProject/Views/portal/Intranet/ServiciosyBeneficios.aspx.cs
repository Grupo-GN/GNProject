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
    public partial class ServiciosyBeneficios : System.Web.UI.Page
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
            BUSBeneficios objNegBeneficios = new BUSBeneficios();
            List<Beneficios> oListaBeneficios = new List<Beneficios>();
            oListaBeneficios = objNegBeneficios.GetBeneficiosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaBeneficios.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Beneficios> orderedRecords = null;
            if (pSortColumn == "Beneficio_Id") orderedRecords = oListaBeneficios.OrderBy(col => col.Beneficio_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaBeneficios.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaBeneficios.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "User_Name") orderedRecords = oListaBeneficios.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaBeneficios.OrderBy(col => col.sFecha);

            IEnumerable<Beneficios> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaBeneficios.ToList();
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
            String path = Parametros.I_FileServer_RutaBeneficios.Replace("~", "../../../");
            String enlace_doc = "<a title='Ver Documento' class='link-tabla' target='_blank' href={0}{1}>{2}</a>";
            foreach (Beneficios obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Beneficio_Id = obj.Beneficio_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    Nombre_Doc = String.Format(enlace_doc, path, obj.Nombre_Archivo.Replace(" ", "%20"), obj.Nombre_Archivo),
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