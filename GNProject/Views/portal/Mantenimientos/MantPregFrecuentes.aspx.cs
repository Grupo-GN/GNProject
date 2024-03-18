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
    public partial class MantPregFrecuentes : System.Web.UI.Page
    {
        BUSFaq objNegFaq = new BUSFaq();
        BUSCategoria_Auxiliar objNegCatAux = new BUSCategoria_Auxiliar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaArea();
            }
        }

        private void ListaArea()
        {
            DataTable dt = new DataTable();
            dt = objNegCatAux.ListaCategoria_Auxiliar();
            cboArea.DataSource = dt;
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Categoria_Auxiliar_Id";
            cboArea.DataBind();
            dt.Dispose();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblFaqId.Text = "";
            txtPregunta.Text = "";
            txtRespuesta.Text = "";
            cboArea.SelectedIndex = 0;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = DateTime.Now.Date;
                Faq objEFaq = new Faq(txtPregunta.Text, txtRespuesta.Text, Categoria_Auxiliar_Id, Fecha);


                rpta = objNegFaq.InsertFaq(objEFaq);

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
                String Faq_Id = hdfID.Value;
                Int32 rpta = 0;
                Faq objEFaq = new Faq();
                objEFaq.Faq_Id = Faq_Id;
                rpta = objNegFaq.DeleteFaq(objEFaq);
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
                String Faq_Id = hdfID.Value;
                Faq objEFaq = new Faq();
                objEFaq.Faq_Id = Faq_Id;
                DataTable dt = new DataTable();
                dt = objNegFaq.ListaFaqxId(objEFaq);

                lblMensaje.Text = "";
                lblFaqId.Text = Faq_Id;
                txtPregunta.Text = dt.Rows[0]["Pregunta"].ToString();
                txtRespuesta.Text = dt.Rows[0]["Respuesta"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();

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
                String Faq_Id = lblFaqId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = DateTime.Now.Date;

                Faq objEFaq = new Faq(Faq_Id, txtPregunta.Text, txtRespuesta.Text, Categoria_Auxiliar_Id, Fecha);

                rpta = objNegFaq.UpdateFaq(objEFaq);
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

        //////protected void btnUpdateOrden_Click(object sender, EventArgs e)
        //////{
        //////    try
        //////    {
        //////        Int32 SortOrder = 0;
        //////        Int32 SortOrder2 = 0;
        //////        Boolean repite = false;
        //////        Int32 cantRepite = 0;
        //////        foreach (GridViewRow gr in grvLista.Rows)
        //////        {
        //////            TextBox txtSortOrder = (TextBox)gr.FindControl("txtSortOrder");
        //////            SortOrder = Convert.ToInt32(txtSortOrder.Text);
        //////            SortOrder2 = 0;
        //////            cantRepite = 0;
        //////            foreach (GridViewRow gr2 in grvLista.Rows)
        //////            {
        //////                TextBox txtSortOrder2 = (TextBox)gr2.FindControl("txtSortOrder");
        //////                SortOrder2 = Convert.ToInt32(txtSortOrder2.Text);
        //////                if (SortOrder == SortOrder2)
        //////                {
        //////                    cantRepite++;
        //////                    if (cantRepite > 1)
        //////                    {
        //////                        repite = true;
        //////                        break;
        //////                    }
        //////                }
        //////            }
        //////        }

        //////        if (repite == true)
        //////        {
        //////            lblMensaje.Text = "El número de orden no puede repetir.";
        //////            lblMensaje.ForeColor = System.Drawing.Color.Red;
        //////        }
        //////        else
        //////        {
        //////            String Faq_Id;
        //////            foreach (GridViewRow gr in grvLista.Rows)
        //////            {
        //////                TextBox txtSortOrder = (TextBox)gr.FindControl("txtSortOrder");
        //////                Faq_Id = txtSortOrder.ToolTip.ToString();
        //////                SortOrder = Convert.ToInt32(txtSortOrder.Text);
        //////                objNegFaq.UpdateOrden(Faq_Id, SortOrder);
        //////            }
        //////            ListaFaqAll();
        //////            lblMensaje.Text = "Orden Actualizado Satisfactoriamente.";
        //////            lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
        //////        }
        //////    }
        //////    catch (Exception ex)
        //////    {
        //////        lblMensaje.Text = ex.Message;
        //////        lblMensaje.ForeColor = System.Drawing.Color.Red;
        //////    }
        //////}

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {

            BUSFaq objNegFaq = new BUSFaq();
            List<Faq> oLista = new List<Faq>();
            oLista = objNegFaq.GetFaqAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Faq> orderedRecords = null;
            if (pSortColumn == "Faq_Id") orderedRecords = oLista.OrderBy(col => col.Faq_Id);
            else if (pSortColumn == "Pregunta") orderedRecords = oLista.OrderBy(col => col.Pregunta);
            else if (pSortColumn == "Respuesta") orderedRecords = oLista.OrderBy(col => col.Respuesta);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "sFecha") orderedRecords = oLista.OrderBy(col => col.sFecha);
            else if (pSortColumn == "SortOrder") orderedRecords = oLista.OrderBy(col => col.SortOrder);

            IEnumerable<Faq> sortedRecords;
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
            foreach (Faq obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png' class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.Faq_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/delete.png' class='icons-table deleteItem' width='15px' onclick='fn_Eliminar(&#39;" + obj.Faq_Id + "&#39;)'>",
                    Faq_Id = obj.Faq_Id,
                    Pregunta = obj.Pregunta,
                    Respuesta = obj.Respuesta,
                    Area = obj.Area,
                    sFecha = obj.sFecha,
                    SortOrder = obj.SortOrder
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