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

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantEnlaces : System.Web.UI.Page
    {
        BUSEnlaces objNegEnlaces = new BUSEnlaces();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblEnlacesId.Text = "";
            txtEnlace.Text = "";
            txtDireccionURL.Text = "";
            chkSoloAdmin.Checked = false;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;
                rpta = objNegEnlaces.InsertEnlace(txtEnlace.Text.Trim(), txtDireccionURL.Text.Trim(), chkSoloAdmin.Checked);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un Error al intentar grabar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Int32 Enlace_Id = Convert.ToInt32(hdfID.Value);
                Int32 rpta = 0;

                rpta = objNegEnlaces.DeleteEnlace(Enlace_Id);
                if (rpta == 1)
                {
                    lblMensaje.Text = "Eliminado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un error al intentar eliminar";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Int32 Enlace_Id = Convert.ToInt32(hdfID.Value);

                DataTable dt = new DataTable();
                dt = objNegEnlaces.ListaEnlacesxId(Enlace_Id);

                lblMensaje.Text = "";
                lblEnlacesId.Text = Enlace_Id.ToString();
                txtEnlace.Text = dt.Rows[0]["Nom_Enlace"].ToString();
                txtDireccionURL.Text = dt.Rows[0]["Direccion"].ToString();
                chkSoloAdmin.Checked = Convert.ToBoolean(dt.Rows[0]["fl_visible_admin"]);

                btnGrabar.Visible = false;
                btnUpdate.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Enlace_Id = Convert.ToInt32(lblEnlacesId.Text);
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = DateTime.Now.Date;

                rpta = objNegEnlaces.UpdateEnlace(Enlace_Id, txtEnlace.Text.Trim(), txtDireccionURL.Text.Trim(), chkSoloAdmin.Checked);
                if (rpta == 1)
                {
                    lblMensaje.Text = "Actualizado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un error al intentar Actualizar";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {

            BUSEnlaces objNegEnlaces = new BUSEnlaces();
            List<Enlace> oLista = new List<Enlace>();
            String User_Id = ClaseGlobal.Get_UserID();
            oLista = objNegEnlaces.GetEnlacesAll(User_Id);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Enlace> orderedRecords = null;
            if (pSortColumn == "Enlace_Id") orderedRecords = oLista.OrderBy(col => col.Enlace_Id);
            else if (pSortColumn == "Nom_Enlace") orderedRecords = oLista.OrderBy(col => col.Nom_Enlace);
            else if (pSortColumn == "Direccion") orderedRecords = oLista.OrderBy(col => col.Direccion);

            IEnumerable<Enlace> sortedRecords;
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
            foreach (Enlace obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png'class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.Enlace_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/delete.png'class='icons-table deleteItem' width='15px' onclick='fn_Eliminar(&#39;" + obj.Enlace_Id + "&#39;)'>",
                    Enlace_Id = obj.Enlace_Id,
                    Nom_Enlace = obj.Nom_Enlace,
                    Direccion = obj.Direccion,
                    tx_visible_admin = (obj.fl_visible_admin ? "SI" : "Todos")
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