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
    public partial class MantEncuestas : System.Web.UI.Page
    {
        BUSEncuesta objNegEncuesta = new BUSEncuesta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblEncuestaId.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFechaInicio.Text = (DateTime.Now.Date.ToShortDateString()) + " " + DateTime.Now.ToShortTimeString();
            txtFechaCierre.Text = "";
            ckSoloUnaOpcion.Checked = true;
            txtNombreOpcion.Text = "";
            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            UtilsScript.fc_JavaScript(this, "fn_CargaCabeceraOpciones();", "__script1__");
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String Encuesta_Id = hdfID.Value;
                Int32 rpta = 0;
                Encuesta objEEncuesta = new Encuesta();
                objEEncuesta.Encuesta_Id = Encuesta_Id;
                rpta = objNegEncuesta.DeleteEncuesta(objEEncuesta);
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
                String Encuesta_Id = hdfID.Value;
                Encuesta objEEncuesta = new Encuesta();
                objEEncuesta.Encuesta_Id = Encuesta_Id;
                DataTable dt = new DataTable();
                dt = objNegEncuesta.ListaEncuestaxEncuestaId(objEEncuesta);

                lblMensaje.Text = "";
                lblEncuestaId.Text = Encuesta_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFechaInicio.Text = dt.Rows[0]["Fecha_Inicio"].ToString();
                txtFechaCierre.Text = dt.Rows[0]["Fecha_Cierre"].ToString();
                ckSoloUnaOpcion.Checked = Convert.ToBoolean(dt.Rows[0]["SoloUnaOpcion"]);

                txtNombreOpcion.Text = "";

                btnGrabar.Visible = false;
                btnUpdate.Visible = true;

                UtilsScript.fc_JavaScript(this, "fn_GetOpciones('" + Encuesta_Id + "');", "__script1__");
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

            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            List<Encuesta> oLista = new List<Encuesta>();
            oLista = objNegEncuesta.GetEncuestasAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Encuesta> orderedRecords = null;
            if (pSortColumn == "Encuesta_Id") orderedRecords = oLista.OrderBy(col => col.Encuesta_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oLista.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oLista.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "sFecha_Inicio") orderedRecords = oLista.OrderBy(col => col.sFecha_Inicio);
            else if (pSortColumn == "sFecha_Cierre") orderedRecords = oLista.OrderBy(col => col.sFecha_Cierre);
            else if (pSortColumn == "User_Name") orderedRecords = oLista.OrderBy(col => col.User_Name);

            IEnumerable<Encuesta> sortedRecords;
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
            foreach (Encuesta obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Encuesta_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Encuesta_Id + "&#39;)'>",
                    Encuesta_Id = obj.Encuesta_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    sFecha_Inicio = obj.sFecha_Inicio,
                    sFecha_Cierre = obj.sFecha_Cierre,
                    User_Name = obj.User_Name
                };
                oJQGridJsonResponseRow.Row = filas;
                responseJQGrid.Items.Add(oJQGridJsonResponseRow);
                i++;
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(responseJQGrid);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_OpcionesxEncuesta(String id_encuesta)
        {
            BUSEncuestaOpciones objNegEncOpciones = new BUSEncuestaOpciones();
            DataTable dt = new DataTable();
            EncuestaOpciones objE = new EncuestaOpciones();
            objE.Encuesta_Id = id_encuesta;
            dt = objNegEncOpciones.ListaEncuestaOpcionesxEncuestaId(objE);

            object[] objLista = new object[dt.Rows.Count];
            Int32 i = 0;
            foreach (DataRow o in dt.Rows)
            {
                object obj = new
                {
                    id_opcion = o["Opcion_Id"].ToString(),
                    no_opcion = o["Nombre_Opcion"].ToString()
                };
                objLista[i] = obj;
                i += 1;
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(objLista);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object AgregarOpcion(String[] strParametros)
        {
            BUSEncuestaOpciones objNegEncOpciones = new BUSEncuestaOpciones();
            object[] strRetorno;
            try
            {
                String Encuesta_Id = strParametros[0];
                String no_opcion = strParametros[1];
                Int32 rpta = 0;
                EncuestaOpciones objEO = new EncuestaOpciones(no_opcion, Encuesta_Id);
                rpta = objNegEncOpciones.InsertEncuestaOpciones(objEO);

                if (rpta == 1)
                    strRetorno = new object[] { 1, "Opción agregado correctamente." };
                else
                    strRetorno = new object[] { -1, "Ocurrio un error al agregar la opción." };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object EliminarOpcion(String[] strParametros)
        {
            BUSEncuestaOpciones objNegEncOpciones = new BUSEncuestaOpciones();
            object[] strRetorno;
            try
            {
                String Opcion_Id = strParametros[0];
                Int32 rpta = 0;
                EncuestaOpciones objEO = new EncuestaOpciones(Opcion_Id);
                rpta = objNegEncOpciones.DeleteEncuestaOpciones(objEO);

                if (rpta == 1)
                    strRetorno = new object[] { 1, "Opción eliminado correctamente." };
                else
                    strRetorno = new object[] { -1, "Ocurrio un error al eliminar la opción." };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        private class OpcEncuesta
        {
            public string id_opcion { get; set; }
            public string no_opcion { get; set; }
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Grabar(String[] strParametros)
        {
            Int32 rpta = 0;
            object[] strRetorno;
            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            try
            {
                Encuesta objEEncuesta;

                Boolean SoloUnaOpcion = strParametros[3] == "1" ? true : false;
                DateTime fe_inicio = Convert.ToDateTime(strParametros[4]);
                DateTime fe_cierre = Convert.ToDateTime(strParametros[5]);
                if (strParametros[0] == "")
                {
                    DataTable dtTemporal = new DataTable();
                    dtTemporal.Columns.Add("Opcion_Id", Type.GetType("System.String"));
                    dtTemporal.Columns.Add("Nombre_Opcion", Type.GetType("System.String"));
                    dtTemporal.Columns.Add("Encuesta_Id", Type.GetType("System.String"));
                    String opciones = strParametros[7].ToString();
                    System.Web.Script.Serialization.JavaScriptSerializer serializer2 = new System.Web.Script.Serialization.JavaScriptSerializer();
                    List<OpcEncuesta> ListaOpc = serializer2.Deserialize<List<OpcEncuesta>>(opciones);
                    foreach (OpcEncuesta opc in ListaOpc)
                    {
                        DataRow dr = dtTemporal.NewRow();
                        dr["Opcion_Id"] = opc.id_opcion;
                        dr["Nombre_Opcion"] = opc.no_opcion;
                        dtTemporal.Rows.Add(dr);
                    }
                    objEEncuesta = new Encuesta(strParametros[1].ToString(), strParametros[2].ToString(), SoloUnaOpcion, fe_inicio, fe_cierre, strParametros[6].ToString());
                    rpta = objNegEncuesta.InsertEncuesta(objEEncuesta, dtTemporal);
                    dtTemporal.Dispose();
                }
                else
                {
                    objEEncuesta = new Encuesta(strParametros[0].ToString(), strParametros[1].ToString(), strParametros[2].ToString(), SoloUnaOpcion, fe_inicio, fe_cierre, strParametros[6].ToString());
                    rpta = objNegEncuesta.UpdateEncuesta(objEEncuesta);
                }

                if (rpta == 1) strRetorno = new object[] { 1, "Grabado correctamente." };
                else strRetorno = new object[] { -1, "Ocurrio un error al grabar los datos." };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
    }
}