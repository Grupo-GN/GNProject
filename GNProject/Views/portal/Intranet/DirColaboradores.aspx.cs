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
    public partial class DirColaboradores : System.Web.UI.Page
    {
        BUSPersonal objNegPersonal = new BUSPersonal();
        BUSCategoria_Auxiliar objNegCatAux = new BUSCategoria_Auxiliar();
        BUSLocalidad objNegLocalidad = new BUSLocalidad();

        BUSPlanilla objNegPlanilla = new BUSPlanilla();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarLocalidad();
                ListaCategoria_Auxiliar();

                ListaPlanilla();
            }
        }

        private void ListaCategoria_Auxiliar()
        {
            cboArea.DataSource = objNegCatAux.ListaCategoria_AuxiliaSinTodos();
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Categoria_Auxiliar_Id";
            cboArea.DataBind();
            cboArea.Items.Insert(0, new ListItem("-Todos-", "0"));
        }

        private void ListarLocalidad()
        {
            cboLocalidad.DataSource = objNegLocalidad.ListaLocalidad();
            cboLocalidad.DataTextField = "Descripcion";
            cboLocalidad.DataValueField = "Area_Id";
            cboLocalidad.DataBind();
            cboLocalidad.Items.Insert(0, new ListItem("-Todos-", "0"));
        }

        private void ListaPlanilla()
        {
            cboPlanilla.DataSource = objNegPlanilla.BUSListaPlanillaActivos().Tables[0];
            //DataTable d = objNegPlanilla.BUSListaPlanillaActivos().Tables[0];
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
            cboPlanilla.Items.Insert(0, new ListItem("-Todos-", "00"));

        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            String Personal_Id = hdfID.Value;
            DataTable dt = objNegPersonal.ListaPersonalxId(Personal_Id);
            lblApePaterno.Text = dt.Rows[0]["Apellido_Paterno"].ToString();
            lblApeMaterno.Text = dt.Rows[0]["Apellido_Materno"].ToString();
            lblNombres.Text = dt.Rows[0]["Nombres"].ToString();
            lblLocalidad.Text = dt.Rows[0]["Localidad"].ToString();
            lblArea.Text = dt.Rows[0]["Area"].ToString();
            lblSeccion.Text = dt.Rows[0]["Seccion"].ToString();
            lblCargo.Text = dt.Rows[0]["Cargo"].ToString();
            lblTelefono.Text = dt.Rows[0]["Telefono"].ToString();
            lblTelefono2.Text = dt.Rows[0]["Telefono2"].ToString();
            lblTelefono3.Text = dt.Rows[0]["Telefono3"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblFechaNacimiento.Text = dt.Rows[0]["Cumple"].ToString();
            imgFoto.ImageUrl = Parametros.I_FileServer_RutaImgUsers + dt.Rows[0]["Ruta_Foto"].ToString();
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {

            String Planilla_Id = strFiltros[0].ToString();
            String Area_Id = strFiltros[1].ToString();
            String Categoria_Auxiliar_Id = strFiltros[2].ToString();
            String Nombres = strFiltros[3].ToString();

            BUSPersonal objNegPersonal = new BUSPersonal();
            List<Personal> oLista = new List<Personal>();
            oLista = objNegPersonal.GetDirectorioEmpxFiltros(Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Nombres);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Personal> orderedRecords = null;
            if (pSortColumn == "Personal_Id") orderedRecords = oLista.OrderBy(col => col.Personal_Id);
            else if (pSortColumn == "Nombre_Completo") orderedRecords = oLista.OrderBy(col => col.Nombre_Completo);
            else if (pSortColumn == "Telefono") orderedRecords = oLista.OrderBy(col => col.Telefono);
            else if (pSortColumn == "Telefono2") orderedRecords = oLista.OrderBy(col => col.Telefono2);
            else if (pSortColumn == "Telefono3") orderedRecords = oLista.OrderBy(col => col.Telefono3);
            else if (pSortColumn == "Email") orderedRecords = oLista.OrderBy(col => col.Email);
            else if (pSortColumn == "Localidad") orderedRecords = oLista.OrderBy(col => col.Localidad);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "Seccion") orderedRecords = oLista.OrderBy(col => col.Seccion);

            IEnumerable<Personal> sortedRecords;
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
            //////String pathUser = Parametros.I_VirtualServer_ImgUsers;
            String pathUser = Parametros.I_FileServer_RutaImgUsers.Replace("~", "..");
            foreach (Personal obj in sortedRecords)
            {
                //&#39;
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Foto = String.Format("<img alt='' src='{0}' width='25px' />", pathUser + obj.Ruta_Foto),
                    Personal_Id = obj.Personal_Id,
                    Nombre_Completo = String.Format("<span class='link-tabla' title='Ver Detalle' onclick='fn_VerDetalle(&#39;{0}&#39;)'>{1}</span>", obj.Personal_Id, obj.Nombre_Completo),
                    Telefono = obj.Telefono,
                    Telefono2 = obj.Telefono2,
                    Telefono3 = obj.Telefono3,
                    Email = obj.Email,
                    Localidad = obj.Localidad,
                    Area = obj.Area,
                    Seccion = obj.Seccion
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