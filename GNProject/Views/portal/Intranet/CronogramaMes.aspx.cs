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
using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Intranet
{
    public partial class CronogramaMes : System.Web.UI.Page
    {
        BUSCronogramaMes objNegCronogramaMes = new BUSCronogramaMes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            String CronogramaMes_Id = hdfID.Value;
            Capas.Portal.Entidad.CronogramaMes objECronogramaMes = new Capas.Portal.Entidad.CronogramaMes(CronogramaMes_Id);
            DataTable dt = objNegCronogramaMes.ListaCronogramaMesxId(objECronogramaMes);
            lblTitulo.Text = dt.Rows[0]["Titulo"].ToString();
            lblUbicacion.Text = dt.Rows[0]["Ubicacion"].ToString();
            lblDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
            if (dt.Rows[0]["Nombre_Foto"].ToString() != "")
            {
                Image1.Visible = true;
                Image1.ImageUrl = Parametros.I_FileServer_RutaCronogramaMes + dt.Rows[0]["Nombre_Foto"].ToString();
            }
            else
            {
                Image1.Visible = false;
                Image1.ImageUrl = "";
            }
            lblArea.Text = dt.Rows[0]["Area"].ToString();
            lblFecha.Text = dt.Rows[0]["Fecha"].ToString();
            lblHoraInicio.Text = dt.Rows[0]["Hora_Inicio"].ToString();
            lblHoraFinal.Text = dt.Rows[0]["Hora_Final"].ToString();
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSCronogramaMes objNegCronogramaMes = new BUSCronogramaMes();
            List<Capas.Portal.Entidad.CronogramaMes> oLista = new List<Capas.Portal.Entidad.CronogramaMes>();
            oLista = objNegCronogramaMes.GetCronogramaMesAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Capas.Portal.Entidad.CronogramaMes> orderedRecords = null;
            if (pSortColumn == "CronogramaMes_Id") orderedRecords = oLista.OrderBy(col => col.CronogramaMes_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oLista.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oLista.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Ubicacion") orderedRecords = oLista.OrderBy(col => col.Ubicacion);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "sFecha") orderedRecords = oLista.OrderBy(col => col.sFecha);
            else if (pSortColumn == "sHora_Inicio") orderedRecords = oLista.OrderBy(col => col.sHora_Inicio);
            else if (pSortColumn == "sHora_Final") orderedRecords = oLista.OrderBy(col => col.sHora_Final);
            else if (pSortColumn == "User_Name") orderedRecords = oLista.OrderBy(col => col.User_Name);

            IEnumerable<Capas.Portal.Entidad.CronogramaMes> sortedRecords;
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
            foreach (Capas.Portal.Entidad.CronogramaMes obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    CronogramaMes_Id = obj.CronogramaMes_Id,
                    Titulo = String.Format("<span class='link' title='Ver Detalle' onclick='fn_VerDetalle(&#39;{0}&#39;)'>{1}</span>", obj.CronogramaMes_Id, obj.Titulo),
                    Descripcion = obj.Descripcion,
                    Ubicacion = obj.Ubicacion,
                    Area = obj.Area,
                    sFecha = obj.sFecha,
                    sHora_Inicio = obj.sHora_Inicio,
                    sHora_Final = obj.sHora_Final,
                    User_Name = obj.User_Name
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