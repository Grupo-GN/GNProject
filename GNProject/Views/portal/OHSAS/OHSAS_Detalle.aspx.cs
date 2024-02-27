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

namespace GNProject.Views.portal.OHSAS
{
    public partial class OHSAS_Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    Response.Redirect("~/Inicio/Default.aspx");
                }

                hdfID_OHSAS.Value = Request.QueryString["id"].ToString();

                ComboBL oComboBL = new ComboBL();
                ComboBEList oCombo_OHSAS = oComboBL.Get_ListaCombo(Parametros.opcCodMaestroCombo.OHSAS, "", "");
                ComboBE ent_OHSAS = oCombo_OHSAS.Find(ent => ent.value == hdfID_OHSAS.Value);

                if (ent_OHSAS == null)
                {
                    Response.Redirect("~/Inicio/Default.aspx");
                }

                lblTitle.Text = "Listado de " + ent_OHSAS.nombre;
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            Int32 id_ohsas = Convert.ToInt32(strFiltros[0]);

            BUSOHSAS_Detalle objNeg = new BUSOHSAS_Detalle();
            List<Capas.Portal.Entidad.OHSAS_Detalle> oLista = new List<Capas.Portal.Entidad.OHSAS_Detalle>();
            oLista = objNeg.GetOHSASAll_Detalle(id_ohsas, 0);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.OHSAS_Detalle> orderedRecords = null;
            if (pSortColumn == "id_ohsas_detalle") orderedRecords = oLista.OrderBy(col => col.id_ohsas_detalle);
            else if (pSortColumn == "no_ohsas") orderedRecords = oLista.OrderBy(col => col.no_ohsas);
            else if (pSortColumn == "no_titulo") orderedRecords = oLista.OrderBy(col => col.no_titulo);
            else if (pSortColumn == "no_area") orderedRecords = oLista.OrderBy(col => col.no_area);
            else if (pSortColumn == "co_usuario") orderedRecords = oLista.OrderBy(col => col.co_usuario);
            else if (pSortColumn == "sfe_registro") orderedRecords = oLista.OrderBy(col => col.fe_registro);

            IEnumerable<Capas.Portal.Entidad.OHSAS_Detalle> sortedRecords;
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
            String path = Parametros.I_FileServer_RutaOHSAS.Replace("~", "../../../");
            String enlace_doc = "<a title='Ver Documento' class='link' target='_blank' href={0}{1}>{2}</a>";
            foreach (Capas.Portal.Entidad.OHSAS_Detalle obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    id_ohsas_detalle = obj.id_ohsas_detalle,
                    no_titulo = obj.no_titulo,
                    tx_descripcion = obj.tx_descripcion,
                    no_area = obj.no_area,
                    no_archivo = String.Format(enlace_doc, path, obj.no_archivo.Replace(" ", "%20"), obj.no_archivo),
                    sfe_registro = obj.sfe_registro
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