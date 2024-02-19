using GNProject.Acceso;
using GNProject.Entity.BL;
using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Security
{
    public partial class CUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            UsuarioBL oUsuarioBL = new UsuarioBL();
            UsuarioBE oUsuarioBE = new UsuarioBE();
            oUsuarioBE.ape_paterno = strFiltros[0];
            oUsuarioBE.ape_materno = strFiltros[1];
            oUsuarioBE.no_usuario = strFiltros[2];
            oUsuarioBE.login = strFiltros[3];
            Int32 id_perfil; Int32.TryParse(strFiltros[4], out id_perfil);
            oUsuarioBE.id_perfil = id_perfil;
            oUsuarioBE.fl_activo = strFiltros[5];
            UsuarioBEList oUsuarioBEList = oUsuarioBL.Get_ListaUsuarios(oUsuarioBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oUsuarioBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<UsuarioBE> orderedRecords = null;
            if (pSortColumn == "id_usuario") orderedRecords = oUsuarioBEList.OrderBy(col => col.id_usuario);
            else if (pSortColumn == "ape_paterno") orderedRecords = oUsuarioBEList.OrderBy(col => col.ape_paterno);
            else if (pSortColumn == "ape_materno") orderedRecords = oUsuarioBEList.OrderBy(col => col.ape_materno);
            else if (pSortColumn == "no_usuario") orderedRecords = oUsuarioBEList.OrderBy(col => col.no_usuario);
            else if (pSortColumn == "login") orderedRecords = oUsuarioBEList.OrderBy(col => col.login);
            else if (pSortColumn == "no_perfil") orderedRecords = oUsuarioBEList.OrderBy(col => col.no_perfil);
            else if (pSortColumn == "no_estado") orderedRecords = oUsuarioBEList.OrderBy(col => col.no_estado);

            IEnumerable<UsuarioBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oUsuarioBEList.ToList();
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
            foreach (UsuarioBE obj in sortedRecords)
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
                    id_usuario = obj.id_usuario,
                    ape_paterno = obj.ape_paterno,
                    ape_materno = obj.ape_materno,
                    no_usuario = obj.no_usuario,
                    login = obj.login,
                    no_perfil = obj.no_perfil,
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
        public static object Get_UsuarioxID(Int32 id)
        {
            UsuarioBE ent = new UsuarioBE();
            ent.id_usuario = id;
            UsuarioBEList oUsuarioBEList = new UsuarioBL().Get_ListaUsuarios(ent);
            UsuarioBE oUsuarioBE = new UsuarioBE();
            oUsuarioBE = oUsuarioBEList[0];

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oUsuarioBE);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Guardar(object[] strParametros)
        {
            UsuarioBL oUsuarioBL = new UsuarioBL();
            UsuarioBE oUsuarioBE = new UsuarioBE();
            object[] strRetorno;
            try
            {
                Int32 id_usuario; Int32.TryParse(strParametros[0].ToString(), out id_usuario);
                Int32 id_perfil; Int32.TryParse(strParametros[12].ToString(), out id_perfil);
                oUsuarioBE.id_usuario = id_usuario;
                oUsuarioBE.ape_paterno = strParametros[1].ToString();
                oUsuarioBE.ape_materno = strParametros[2].ToString();
                oUsuarioBE.no_usuario = strParametros[3].ToString();
                oUsuarioBE.nu_dni = strParametros[4].ToString();
                oUsuarioBE.no_correo = strParametros[5].ToString();
                oUsuarioBE.co_sexo = strParametros[6].ToString();
                if (strParametros[7] != "")
                {
                    oUsuarioBE.fe_nacimiento = Convert.ToDateTime(strParametros[7].ToString());
                }
                oUsuarioBE.nu_telefono = strParametros[8].ToString();
                oUsuarioBE.nu_celular = strParametros[9].ToString();
                oUsuarioBE.login = strParametros[10].ToString();
                String clave = strParametros[11].ToString();
                if (!String.IsNullOrEmpty(clave)) clave = Encryptar.GetMD5(clave);
                oUsuarioBE.password = clave;
                oUsuarioBE.id_perfil = id_perfil;
                oUsuarioBE.fl_activo = strParametros[13].ToString();
                oUsuarioBE.fl_ver_doc_reservado = Convert.ToBoolean(strParametros[14]);
                oUsuarioBE.fl_archivar_doc = Convert.ToBoolean(strParametros[15]);
                oUsuarioBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oUsuarioBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oUsuarioBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oUsuarioBL.GuardarUsuario(oUsuarioBE, out retorno, out msg_retorno);

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
            UsuarioBL oUsuarioBL = new UsuarioBL();
            UsuarioBE oUsuarioBE = new UsuarioBE();
            object[] strRetorno;
            try
            {
                Int32 id_usuario;
                Int32.TryParse(strParametros[0].ToString(), out id_usuario);
                oUsuarioBE.id_usuario = id_usuario;
                oUsuarioBE.co_usuario = ClaseGlobal.Get_login_usuario();
                oUsuarioBE.no_usuario_red = ClaseGlobal.getUsuarioRed();
                oUsuarioBE.no_estacion_red = ClaseGlobal.getEstacionRed();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oUsuarioBL.EliminarUsuario(oUsuarioBE, out retorno, out msg_retorno);

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