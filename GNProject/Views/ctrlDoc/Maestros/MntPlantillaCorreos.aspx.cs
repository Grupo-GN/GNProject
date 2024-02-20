using CtrlDocumentos.BE.Maestros;
using CtrlDocumentos.BL.Maestros;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.ctrlDoc.Maestros
{
    public partial class MntPlantillaCorreos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getCorreoxID(Int32 id)
        {
            Int32 id_correo = id;
            CorreoBL oCorreoBL = new CorreoBL();
            CorreoBE oCorreoBE = oCorreoBL.Get_BandejaCorreos(id_correo, "", "1")[0];

            object objCorreo = new
            {
                id_correo = oCorreoBE.id_correo,
                no_asunto = oCorreoBE.no_asunto,
                no_para = oCorreoBE.no_para,
                no_cc = oCorreoBE.no_cc,
                no_bcc = oCorreoBE.no_bcc,
                no_detalle = oCorreoBE.no_detalle

            };


            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(objCorreo);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            CorreoBL oCorreoBL = new CorreoBL();
            String no_asunto = strFiltros[0];
            List<CorreoBE> oLista = oCorreoBL.Get_BandejaCorreos(0, no_asunto, "1");

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<CorreoBE> orderedRecords = null;
            if (pSortColumn == "id_correo") orderedRecords = oLista.OrderBy(col => col.id_correo);
            else if (pSortColumn == "no_asunto") orderedRecords = oLista.OrderBy(col => col.no_asunto);
            else if (pSortColumn == "no_para") orderedRecords = oLista.OrderBy(col => col.no_para);
            else if (pSortColumn == "no_cc") orderedRecords = oLista.OrderBy(col => col.no_cc);
            else if (pSortColumn == "no_bcc") orderedRecords = oLista.OrderBy(col => col.no_bcc);

            IEnumerable<CorreoBE> sortedRecords;
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
            foreach (CorreoBE obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();

                String imgEditar = "<img title='Editar' alt='Editar' src='../img/img_buttons/Editar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Editar(&#39;{0}&#39;);' />";
                String imgInactivar = "<img title='Inactivar' alt='Inactivar' src='../img/img_buttons/Cancelar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Inactivar(&#39;{0}&#39;);' />";
                String imgActivar = "<img title='Activar' alt='Activar' src='../img/img_buttons/Comprobado-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_Activar(&#39;{0}&#39;);' />";
                String imgVerDetalle = "<img title='Ver' alt='Ver' src='../img/img_buttons/No_Editar-48.png' style='width: 20px; height: 20px;' onclick='javascript: fn_VerDetalle(&#39;{0}&#39;);' />";

                imgEditar = String.Format(imgEditar, oJQGridJsonResponseRow.ID);
                imgInactivar = String.Format(imgInactivar, oJQGridJsonResponseRow.ID);
                imgActivar = String.Format(imgActivar, oJQGridJsonResponseRow.ID);
                imgVerDetalle = String.Format(imgVerDetalle, oJQGridJsonResponseRow.ID);

                //////String imgOpciones = "";
                //////if (flEditar && obj.codEstado == "001") imgOpciones += imgEditar;
                //////if (flCambiarEstado) imgOpciones += (obj.codEstado == "001" ? imgInactivar : imgActivar);
                //////if (flVerDetalle) imgOpciones += imgVerDetalle;

                object filas = new
                {
                    id_correo = obj.id_correo,
                    no_asunto = obj.no_asunto,
                    no_para = obj.no_para,
                    no_cc = obj.no_cc,
                    no_bcc = obj.no_bcc,
                    no_detalle = obj.no_detalle
                    //imgOpciones = imgOpciones
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
        public static object Guardar(String[] strParametros)
        {
            CorreoBL oCorreoBL = new CorreoBL();
            CorreoBE oCorreoBE = new CorreoBE();
            object[] strRetorno;
            try
            {
                Int32 id_correo; Int32.TryParse(strParametros[0].ToString(), out id_correo);
                oCorreoBE.id_correo = id_correo;
                oCorreoBE.no_asunto = strParametros[1].ToString();
                oCorreoBE.no_para = strParametros[2].ToString();
                oCorreoBE.no_cc = strParametros[3].ToString();
                oCorreoBE.no_bcc = strParametros[4].ToString();
                oCorreoBE.no_detalle = strParametros[5].ToString();
                oCorreoBE.fl_activo = "1";
                oCorreoBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oCorreoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oCorreoBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oCorreoBL.GuardarCorreo(oCorreoBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        //[System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        //[WebMethod]
        //public static object Eliminar(String[] strParametros)
        //{
        //    CorreoBL oCorreoBL = new CorreoBL();
        //    CorreoBE oCorreoBE = new CorreoBE();
        //    object[] strRetorno;
        //    try
        //    {
        //        Int32 id_correo;
        //        Int32.TryParse(strParametros[0].ToString(), out id_correo);
        //        oCorreoBE.id_correo = id_correo;
        //        oCorreoBE.co_usuario = ClaseGlobal.Get_login_usuario();
        //        oCorreoBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
        //        oCorreoBE.no_estacion_red = ClaseGlobal.getEstacionRed();

        //        Int32 retorno = 0; String msg_retorno = String.Empty;
        //        oCorreoBL.EliminarCorreo(oCorreoBE, out retorno, out msg_retorno);

        //        strRetorno = new object[] { retorno, msg_retorno };
        //    }
        //    catch (Exception ex)
        //    {
        //        strRetorno = new object[] { -1, "Error: " + ex.Message };
        //    }

        //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    return serializer.Serialize(strRetorno);
        //}
    }
}