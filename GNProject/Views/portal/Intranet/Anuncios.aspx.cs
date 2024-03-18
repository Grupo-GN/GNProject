using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Capas.Portal.Negocio;
using Capas.Portal.Entidad;
using System.Data;
using System.Web.Services;
using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Intranet
{
    public partial class Anuncios : System.Web.UI.Page
    {
        BUSAnuncios objNegAnuncios = new BUSAnuncios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            String Anuncio_Id = hdfID.Value;
            Capas.Portal.Entidad.Anuncios objEAnuncios = new Capas.Portal.Entidad.Anuncios(Anuncio_Id);
            DataTable dt = objNegAnuncios.ListaAnunciosxId(objEAnuncios);
            lblTitulo.Text = dt.Rows[0]["Titulo"].ToString();
            lblDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
            if (dt.Rows[0]["Ruta_Foto"].ToString() != "")
            {
                Image1.Visible = true;
                Image1.ImageUrl = Parametros.I_FileServer_RutaAnuncios + dt.Rows[0]["Ruta_Foto"].ToString();
            }
            else
            {
                Image1.Visible = false;
                Image1.ImageUrl = "";
            }
            lblArea.Text = dt.Rows[0]["Area"].ToString();
            lblHoraFinal.Text = dt.Rows[0]["Fecha"].ToString();
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSAnuncios objNegAnuncios = new BUSAnuncios();
            List<Capas.Portal.Entidad.Anuncios> oListaAnuncios = new List<Capas.Portal.Entidad.Anuncios>();
            oListaAnuncios = objNegAnuncios.GetAnunciosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaAnuncios.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.Anuncios> orderedRecords = null;
            if (pSortColumn == "Anuncio_Id") orderedRecords = oListaAnuncios.OrderBy(col => col.Anuncio_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaAnuncios.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Area") orderedRecords = oListaAnuncios.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaAnuncios.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaAnuncios.OrderBy(col => col.sFecha);

            IEnumerable<Capas.Portal.Entidad.Anuncios> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaAnuncios.ToList();
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
            foreach (Capas.Portal.Entidad.Anuncios obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Anuncio_Id = obj.Anuncio_Id,
                    Titulo = String.Format("<span class='link-tabla' title='Ver Detalle' onclick='fn_VerDetalle(&#39;{0}&#39;)'>{1}</span>", obj.Anuncio_Id, obj.Titulo),
                    Area = obj.Area,
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