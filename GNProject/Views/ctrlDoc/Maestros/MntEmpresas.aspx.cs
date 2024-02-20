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
    public partial class MntEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            EmpresaBL oEmpresaBL = new EmpresaBL();
            EmpresaBE oEmpresaBE = new EmpresaBE();
            oEmpresaBE.co_tipo_empresa = strFiltros[0];
            oEmpresaBE.nu_ruc = strFiltros[1];
            oEmpresaBE.no_razon_social = strFiltros[2];
            oEmpresaBE.fl_activo = strFiltros[3];
            List<EmpresaBE> oLista = oEmpresaBL.getEmpresas(oEmpresaBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<EmpresaBE> orderedRecords = null;
            if (pSortColumn == "id_empresa") orderedRecords = oLista.OrderBy(col => col.id_empresa);
            else if (pSortColumn == "nu_ruc") orderedRecords = oLista.OrderBy(col => col.nu_ruc);
            else if (pSortColumn == "no_razon_social") orderedRecords = oLista.OrderBy(col => col.no_razon_social);
            else if (pSortColumn == "no_tipo_empresa") orderedRecords = oLista.OrderBy(col => col.no_tipo_empresa);
            else if (pSortColumn == "no_contacto") orderedRecords = oLista.OrderBy(col => col.no_contacto);
            else if (pSortColumn == "nu_telefono") orderedRecords = oLista.OrderBy(col => col.nu_telefono);
            else if (pSortColumn == "nu_celular") orderedRecords = oLista.OrderBy(col => col.nu_celular);
            else if (pSortColumn == "no_correo") orderedRecords = oLista.OrderBy(col => col.no_correo);
            else if (pSortColumn == "no_estado") orderedRecords = oLista.OrderBy(col => col.no_estado);

            IEnumerable<EmpresaBE> sortedRecords;
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
            foreach (EmpresaBE obj in sortedRecords)
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
                    id_empresa = obj.id_empresa,
                    nu_ruc = obj.nu_ruc,
                    no_razon_social = obj.no_razon_social,
                    no_tipo_empresa = obj.no_tipo_empresa,
                    de_empresa = obj.de_empresa,
                    no_contacto = obj.no_contacto,
                    nu_telefono = obj.nu_telefono,
                    nu_celular = obj.nu_celular,
                    no_correo = obj.no_correo,
                    co_tipo_empresa = obj.co_tipo_empresa,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado
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
            EmpresaBL oEmpresaBL = new EmpresaBL();
            EmpresaBE oEmpresaBE = new EmpresaBE();
            object[] strRetorno;
            try
            {
                Int32 id_empresa; Int32.TryParse(strParametros[0].ToString(), out id_empresa);
                oEmpresaBE.id_empresa = id_empresa;
                oEmpresaBE.nu_ruc = strParametros[1].ToString();
                oEmpresaBE.no_razon_social = strParametros[2].ToString();
                oEmpresaBE.de_empresa = strParametros[3].ToString();
                oEmpresaBE.no_contacto = strParametros[4].ToString();
                oEmpresaBE.nu_telefono = strParametros[5].ToString();
                oEmpresaBE.nu_celular = strParametros[6].ToString();
                oEmpresaBE.no_correo = strParametros[7].ToString();
                oEmpresaBE.co_tipo_empresa = strParametros[8].ToString();
                oEmpresaBE.fl_activo = strParametros[9].ToString();
                oEmpresaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oEmpresaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oEmpresaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oEmpresaBL.GuardarEmpresa(oEmpresaBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
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
        public static object Eliminar(String[] strParametros)
        {
            EmpresaBL oEmpresaBL = new EmpresaBL();
            EmpresaBE oEmpresaBE = new EmpresaBE();
            object[] strRetorno;
            try
            {
                Int32 id_empresa;
                Int32.TryParse(strParametros[0].ToString(), out id_empresa);
                oEmpresaBE.id_empresa = id_empresa;
                oEmpresaBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oEmpresaBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oEmpresaBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oEmpresaBL.EliminarEmpresa(oEmpresaBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
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