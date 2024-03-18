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
using Microsoft.Reporting.WebForms;
using GNProject.Acceso.App_code_portal.dsResultadoEncuestasTableAdapters;
using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Intranet
{
    public partial class Encuestas : System.Web.UI.Page
    {
        BUSEncuesta objNegEncuesta = new BUSEncuesta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnVerBarras_Click(object sender, EventArgs e)
        {
            String Encuesta_Id = hdfID.Value;

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Views/portal/Reportes/rptResultadoEncuestas.rdlc");

            dtResultadoEncuestasTableAdapter tablaResultadoEncuestas = new dtResultadoEncuestasTableAdapter();
            dsResultadoEncuestas.dtResultadoEncuestasDataTable datosResultadoEncuestas = tablaResultadoEncuestas.GetData(Encuesta_Id);

            List<dsResultadoEncuestas.dtResultadoEncuestasRow> data = datosResultadoEncuestas.ToList();
            data.RemoveAt(data.Count - 1);

            if (ReportViewer1.LocalReport.DataSources.Count > 0) ReportViewer1.LocalReport.DataSources.RemoveAt(0);

            ReportDataSource dataSource = new ReportDataSource("dtResultadoEncuestas", data);
            ReportViewer1.LocalReport.DataSources.Add(dataSource);
            lblCargandoBarras.Text = "";
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            List<Encuesta> oListaEncuesta = new List<Encuesta>();
            oListaEncuesta = objNegEncuesta.GetEncuestasVigentesyCerradas();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaEncuesta.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Encuesta> orderedRecords = null;
            if (pSortColumn == "Encuesta_Id") orderedRecords = oListaEncuesta.OrderBy(col => col.Encuesta_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaEncuesta.OrderBy(col => col.Titulo);
            else if (pSortColumn == "sFecha_Inicio") orderedRecords = oListaEncuesta.OrderBy(col => col.Fecha_Inicio);
            else if (pSortColumn == "sFecha_Cierre") orderedRecords = oListaEncuesta.OrderBy(col => col.Fecha_Cierre);

            IEnumerable<Encuesta> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaEncuesta.ToList();
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
                    Encuesta_Id = obj.Encuesta_Id,
                    Titulo = String.Format("<span class='link-tabla' title='Ver Detalle' onclick='fn_VerDetalle(&#39;{0}&#39;)'>{1}</span>", obj.Encuesta_Id, obj.Titulo),
                    sFecha_Inicio = obj.sFecha_Inicio,
                    sFecha_Cierre = obj.sFecha_Cierre,
                    no_estado = obj.no_estado
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
        public static object Get_EncuestaxID(String[] strParametros)
        {
            System.Threading.Thread.Sleep(2000);
            String Encuesta_Id = strParametros[0];
            Encuesta objE = new Encuesta(Encuesta_Id);
            BUSEncuesta objNegEncuesta = new BUSEncuesta();
            System.Data.DataTable dt = objNegEncuesta.ListaEncuestaxEncuestaId(objE);

            Boolean fl_existe_voto = false; String User_Name = strParametros[1];
            BUSEncuestaRespuestas objNegEncRpta = new BUSEncuestaRespuestas();

            EncuestaRespuestas objER = new EncuestaRespuestas(Encuesta_Id);

            object[] response_ListaResultados = null;
            object[] response_Lista = null;

            if (dt.Rows[0]["fl_cerrado"].ToString() == "1")
            {
                System.Data.DataTable dtResultados = objNegEncRpta.ListaEncuestaResultadosxId(objER);

                response_ListaResultados = new object[dtResultados.Rows.Count];
                Int32 i = 0;
                foreach (System.Data.DataRow row in dtResultados.Rows)
                {
                    object obj = new
                    {
                        no_opcion = row["Nombre_Opcion"].ToString(),
                        nu_votos = row["CantVotos"].ToString(),
                        po_votos = row["PorcentajeVotos"].ToString()
                    };
                    response_ListaResultados[i] = obj;
                    i++;
                }
            }
            else
            {
                fl_existe_voto = objNegEncRpta.ExisteVotoEncuestaxUserName(Encuesta_Id, User_Name);

                BUSEncuestaOpciones objNegEncOpc = new BUSEncuestaOpciones();
                EncuestaOpciones objEOpc = new EncuestaOpciones();
                objEOpc.Encuesta_Id = Encuesta_Id;
                System.Data.DataTable dtOpciones = objNegEncOpc.ListaEncuestaOpcionesxEncuestaId(objEOpc);

                response_Lista = new object[dtOpciones.Rows.Count];
                Int32 i = 0;
                foreach (System.Data.DataRow row in dtOpciones.Rows)
                {
                    object obj = new
                    {
                        no_opcion = row["Nombre_Opcion"].ToString(),
                        id_opcion = row["Opcion_Id"].ToString()
                    };
                    response_Lista[i] = obj;
                    i++;
                }
            }

            object response = new
            {
                fl_cerrado = dt.Rows[0]["fl_cerrado"].ToString(),
                no_titulo = dt.Rows[0]["Titulo"].ToString().ToUpper(),
                tx_descripcion = dt.Rows[0]["Descripcion"].ToString(),
                tx_vigencia = "Vigencia: Del " + Convert.ToDateTime(dt.Rows[0]["Fecha_Inicio"]).ToShortDateString() + "  " + Convert.ToDateTime(dt.Rows[0]["Fecha_Inicio"]).ToShortTimeString() + " al " + Convert.ToDateTime(dt.Rows[0]["Fecha_Cierre"]).ToShortDateString() + " " + Convert.ToDateTime(dt.Rows[0]["Fecha_Cierre"]).ToShortTimeString(),
                fl_existe_voto = fl_existe_voto ? "1" : "0",
                fl_una_opc = Convert.ToBoolean(dt.Rows[0]["SoloUnaOpcion"]) == true ? "1" : "0",
                opciones = response_Lista,
                resultados = response_ListaResultados
            };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object GrabarVotoEncuesta(String[] strParametros)
        {
            String Encuesta_Id = strParametros[0];
            String User_Name = strParametros[1];

            System.Web.Script.Serialization.JavaScriptSerializer serializer2 = new System.Web.Script.Serialization.JavaScriptSerializer();
            String[] arr_opciones;
            arr_opciones = serializer2.Deserialize<String[]>(strParametros[2]);

            String Opcion_Id;
            BUSEncuestaRespuestas objNegEncRpta = new BUSEncuestaRespuestas();
            foreach (String id_opc in arr_opciones)
            {
                Opcion_Id = id_opc;
                EncuestaRespuestas objE = new EncuestaRespuestas(Encuesta_Id, User_Name, Opcion_Id);
                objNegEncRpta.InsertEncuestaRespuestas(objE);
            }

            object response = new object[] { "Voto realizado con éxito.\nGracias por participar en la encuesta." };

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(response);
        }
    }
}