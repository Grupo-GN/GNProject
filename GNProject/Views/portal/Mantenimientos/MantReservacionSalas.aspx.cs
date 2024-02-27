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
    public partial class MantReservacionSalas : System.Web.UI.Page
    {
        BUSCalendario objNegCalendario = new BUSCalendario();
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
            lblCalendarioId.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtUbicacion.Text = "";
            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());
            txtHoraInicio.Text = "";
            txtHoraFinal.Text = "";
            cboArea.SelectedIndex = 0;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                DateTime Hora_Inicio, Hora_Final;
                Hora_Inicio = Convert.ToDateTime(txtHoraInicio.Text);
                Hora_Final = Convert.ToDateTime(txtHoraFinal.Text);

                String User_Name = ClaseGlobal.Get_UserName(this);

                Calendario objECalendario = new Calendario(txtTitulo.Text, txtDescripcion.Text, txtUbicacion.Text, cboArea.SelectedValue, Fecha, Hora_Inicio, Hora_Final, User_Name);
                rpta = objNegCalendario.InsertCalendario(objECalendario);

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
                String Calendario_Id = hdfID.Value;
                Int32 rpta = 0;
                Calendario objECalendario = new Calendario();
                objECalendario.Calendario_Id = Calendario_Id;
                rpta = objNegCalendario.DeleteCalendario(objECalendario);
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
                String Calendario_Id = hdfID.Value;
                Calendario objECalendario = new Calendario();
                objECalendario.Calendario_Id = Calendario_Id;
                DataTable dt = new DataTable();
                dt = objNegCalendario.ListaCalendarioxId(objECalendario);

                lblMensaje.Text = "";
                lblCalendarioId.Text = Calendario_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtUbicacion.Text = dt.Rows[0]["Ubicacion"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                txtHoraInicio.Text = dt.Rows[0]["Hora_Inicio"].ToString();
                txtHoraFinal.Text = dt.Rows[0]["Hora_Final"].ToString();

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
                String Calendario_Id = lblCalendarioId.Text;
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                DateTime Hora_Inicio, Hora_Final;
                Hora_Inicio = Convert.ToDateTime(txtHoraInicio.Text);
                Hora_Final = Convert.ToDateTime(txtHoraFinal.Text);

                String User_Name = ClaseGlobal.Get_UserName(this);

                Calendario objECalendario = new Calendario(Calendario_Id, txtTitulo.Text, txtDescripcion.Text, txtUbicacion.Text, cboArea.SelectedValue, Fecha, Hora_Inicio, Hora_Final, User_Name);

                rpta = objNegCalendario.UpdateCalendario(objECalendario);
                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Actualizado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
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
            BUSCalendario objNegCalendario = new BUSCalendario();
            List<Calendario> oLista = new List<Calendario>();
            oLista = objNegCalendario.GetCalendarioAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Calendario> orderedRecords = null;
            if (pSortColumn == "Calendario_Id") orderedRecords = oLista.OrderBy(col => col.Calendario_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oLista.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oLista.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Ubicacion") orderedRecords = oLista.OrderBy(col => col.Ubicacion);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "sFecha") orderedRecords = oLista.OrderBy(col => col.sFecha);
            else if (pSortColumn == "sHora_Inicio") orderedRecords = oLista.OrderBy(col => col.sHora_Inicio);
            else if (pSortColumn == "sHora_Final") orderedRecords = oLista.OrderBy(col => col.sHora_Final);
            else if (pSortColumn == "User_Name") orderedRecords = oLista.OrderBy(col => col.User_Name);

            IEnumerable<Calendario> sortedRecords;
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
            foreach (Calendario obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Calendario_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Calendario_Id + "&#39;)'>",
                    Calendario_Id = obj.Calendario_Id,
                    Titulo = obj.Titulo,
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