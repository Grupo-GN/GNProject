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
    public partial class MntPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object getBandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBE oPersonaBE = new PersonaBE();
            oPersonaBE.co_tipo_documento = strFiltros[0];
            oPersonaBE.nu_documento = strFiltros[1];
            oPersonaBE.no_busqueda = strFiltros[2];
            oPersonaBE.fl_activo = strFiltros[3];
            PersonaBEList oPersonaBEList = oPersonaBL.Get_ListaPersonas(oPersonaBE);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oPersonaBEList.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<PersonaBE> orderedRecords = null;
            if (pSortColumn == "id_persona") orderedRecords = oPersonaBEList.OrderBy(col => col.id_persona);
            else if (pSortColumn == "co_tipo_documento") orderedRecords = oPersonaBEList.OrderBy(col => col.co_tipo_documento);
            else if (pSortColumn == "no_documento") orderedRecords = oPersonaBEList.OrderBy(col => col.no_documento);
            else if (pSortColumn == "nu_documento") orderedRecords = oPersonaBEList.OrderBy(col => col.nu_documento);
            else if (pSortColumn == "ape_paterno") orderedRecords = oPersonaBEList.OrderBy(col => col.ape_paterno);
            else if (pSortColumn == "ape_materno") orderedRecords = oPersonaBEList.OrderBy(col => col.ape_materno);
            else if (pSortColumn == "no_persona") orderedRecords = oPersonaBEList.OrderBy(col => col.no_persona);
            else if (pSortColumn == "no_razon_social") orderedRecords = oPersonaBEList.OrderBy(col => col.no_razon_social);
            else if (pSortColumn == "no_contacto") orderedRecords = oPersonaBEList.OrderBy(col => col.no_contacto);
            else if (pSortColumn == "no_busqueda") orderedRecords = oPersonaBEList.OrderBy(col => col.no_busqueda);
            else if (pSortColumn == "no_localidad") orderedRecords = oPersonaBEList.OrderBy(col => col.no_localidad);
            else if (pSortColumn == "no_area") orderedRecords = oPersonaBEList.OrderBy(col => col.no_area);
            else if (pSortColumn == "no_seccion") orderedRecords = oPersonaBEList.OrderBy(col => col.no_seccion);
            else if (pSortColumn == "nu_telefono") orderedRecords = oPersonaBEList.OrderBy(col => col.nu_telefono);
            else if (pSortColumn == "nu_celular") orderedRecords = oPersonaBEList.OrderBy(col => col.nu_celular);
            else if (pSortColumn == "no_correo") orderedRecords = oPersonaBEList.OrderBy(col => col.no_correo);
            else if (pSortColumn == "no_foto") orderedRecords = oPersonaBEList.OrderBy(col => col.no_foto);
            else if (pSortColumn == "fl_activo") orderedRecords = oPersonaBEList.OrderBy(col => col.fl_activo);
            else if (pSortColumn == "no_estado") orderedRecords = oPersonaBEList.OrderBy(col => col.no_estado);
            else if (pSortColumn == "id_cargo") orderedRecords = oPersonaBEList.OrderBy(col => col.id_cargo);
            else if (pSortColumn == "id_planilla") orderedRecords = oPersonaBEList.OrderBy(col => col.id_planilla);
            else if (pSortColumn == "id_tipo_contrato") orderedRecords = oPersonaBEList.OrderBy(col => col.id_tipo_contrato);
            else if (pSortColumn == "fe_ingreso") orderedRecords = oPersonaBEList.OrderBy(col => col.fe_ingreso);
            else if (pSortColumn == "fe_cese") orderedRecords = oPersonaBEList.OrderBy(col => col.fe_cese);
            else if (pSortColumn == "id_area") orderedRecords = oPersonaBEList.OrderBy(col => col.id_area);
            else if (pSortColumn == "id_seccion") orderedRecords = oPersonaBEList.OrderBy(col => col.id_seccion);
            else if (pSortColumn == "id_localidad") orderedRecords = oPersonaBEList.OrderBy(col => col.id_localidad);
            else if (pSortColumn == "id_jefe") orderedRecords = oPersonaBEList.OrderBy(col => col.id_jefe);
            else if (pSortColumn == "no_usuario") orderedRecords = oPersonaBEList.OrderBy(col => col.no_usuario);
            else if (pSortColumn == "id_perfil") orderedRecords = oPersonaBEList.OrderBy(col => col.id_perfil);
            else if (pSortColumn == "no_estado") orderedRecords = oPersonaBEList.OrderBy(col => col.no_estado);

            IEnumerable<PersonaBE> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oPersonaBEList.ToList();
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
            foreach (PersonaBE obj in sortedRecords)
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
                    id_persona = obj.id_persona,
                    co_tipo_documento = obj.co_tipo_documento,
                    no_documento = obj.no_documento,
                    nu_documento = obj.nu_documento,
                    ape_paterno = obj.ape_paterno,
                    ape_materno = obj.ape_materno,
                    no_persona = obj.no_persona,
                    no_razon_social = obj.no_razon_social,
                    no_contacto = obj.no_contacto,
                    no_busqueda = obj.no_busqueda,
                    no_localidad = obj.no_localidad,
                    no_area = obj.no_area,
                    no_seccion = obj.no_seccion,
                    nu_telefono = obj.nu_telefono,
                    nu_celular = obj.nu_celular,
                    no_correo = obj.no_correo,
                    no_foto = obj.no_foto,
                    fl_activo = obj.fl_activo,
                    no_estado = obj.no_estado,
                    id_cargo = obj.id_cargo,
                    id_planilla = obj.id_planilla,
                    id_tipo_contrato = obj.id_tipo_contrato,
                    fe_ingreso = obj.fe_ingreso,
                    fe_cese = obj.fe_cese,
                    id_area = obj.id_area,
                    id_seccion = obj.id_seccion,
                    id_localidad = obj.id_localidad,
                    id_jefe = obj.id_jefe,
                    no_usuario = obj.no_usuario,
                    id_perfil = obj.id_perfil
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
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBE oPersonaBE = new PersonaBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona;
                Int32.TryParse(strParametros[0].ToString(), out id_persona);

                oPersonaBE.id_persona = id_persona;
                oPersonaBE.co_tipo_documento = strParametros[1].ToString();
                oPersonaBE.nu_documento = strParametros[2].ToString();
                oPersonaBE.ape_paterno = strParametros[3].ToString();
                oPersonaBE.ape_materno = strParametros[4].ToString();
                oPersonaBE.no_persona = strParametros[5].ToString();
                oPersonaBE.no_razon_social = strParametros[6].ToString();
                oPersonaBE.no_contacto = strParametros[7].ToString();
                oPersonaBE.nu_telefono = strParametros[8].ToString();
                oPersonaBE.nu_celular = strParametros[9].ToString();
                oPersonaBE.no_correo = strParametros[10].ToString();
                //////oPersonaBE.fl_cliente = strParametros[11].ToString();
                //////oPersonaBE.fl_ayudante = strParametros[12].ToString();
                //////oPersonaBE.fl_proveedor = strParametros[13].ToString();
                oPersonaBE.fl_activo = strParametros[14].ToString();
                oPersonaBE.co_usuario = strParametros[15].ToString();
                oPersonaBE.no_usuario_red = strParametros[16].ToString();
                oPersonaBE.no_estacion_red = strParametros[17].ToString();

                //////Int32 id_proveedor;
                //////Int32.TryParse(strParametros[21].ToString(), out id_proveedor);
                oPersonaBE.no_foto = strParametros[18].ToString();
                //oPersonaBE.nu_licencia = strParametros[19].ToString();
                //oPersonaBE.co_categoria_licencia = strParametros[20].ToString();
                //////oPersonaBE.id_proveedor = id_proveedor;
                //oPersonaBE.fl_bloqueo_ingreso = strParametros[22].ToString();
                //oPersonaBE.tx_motivo_bloqueo = strParametros[23].ToString();

                //////oPersonaBE.cont_ids_adicional = Convert.ToInt32(strParametros[24].ToString());
                //////oPersonaBE.cad_co_dato_persona_adicional = strParametros[25].ToString();
                //////oPersonaBE.cad_no_valor_dato_adicional = strParametros[26].ToString();
                //////oPersonaBE.cad_no_archivo_adicional = strParametros[27].ToString();

                Int32 id_cargo;
                Int32.TryParse(strParametros[28].ToString(), out id_cargo);
                oPersonaBE.id_cargo = id_cargo;
                Int32 id_planilla;
                Int32.TryParse(strParametros[29].ToString(), out id_planilla);
                oPersonaBE.id_planilla = id_planilla;
                Int32 id_tipo_contrato;
                Int32.TryParse(strParametros[30].ToString(), out id_tipo_contrato);
                oPersonaBE.id_tipo_contrato = id_tipo_contrato;

                oPersonaBE.fe_ingreso = strParametros[31].ToString();
                oPersonaBE.fe_cese = strParametros[32].ToString();

                Int32 id_seccion;
                Int32.TryParse(strParametros[33].ToString(), out id_seccion);
                Int32 id_localidad;
                Int32.TryParse(strParametros[34].ToString(), out id_localidad);
                oPersonaBE.id_seccion = id_seccion;
                oPersonaBE.id_localidad = id_localidad;

                Int32 id_jefe;
                Int32.TryParse(strParametros[35].ToString(), out id_jefe);
                oPersonaBE.id_jefe = id_jefe;

                oPersonaBE.no_usuario = strParametros[36].ToString();
                oPersonaBE.no_clave = strParametros[37].ToString();

                Int32 id_perfil;
                Int32.TryParse(strParametros[38].ToString(), out id_perfil);
                oPersonaBE.id_perfil = id_perfil;

                oPersonaBE.fe_ini_contrato = strParametros[39].ToString();
                oPersonaBE.fe_fin_contrato = strParametros[40].ToString();
                oPersonaBE.co_tipo_cese = strParametros[41].ToString();


                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.GuardarPersona(oPersonaBE, out retorno, out msg_retorno);

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
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBE oPersonaBE = new PersonaBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona;
                Int32.TryParse(strParametros[0].ToString(), out id_persona);
                oPersonaBE.id_persona = id_persona;

                Int32 id_jefe;
                Int32.TryParse(strParametros[1].ToString(), out id_jefe);
                oPersonaBE.id_jefe = id_jefe;

                oPersonaBE.co_usuario = strParametros[2].ToString();
                oPersonaBE.no_usuario_red = strParametros[3].ToString();
                oPersonaBE.no_estacion_red = strParametros[4].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.EliminarPersona(oPersonaBE, out retorno, out msg_retorno);

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
        public static object Get_Personas_ID(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBEList oPersonaBEList = new PersonaBEList();
            PersonaBE oPersonaBE = new PersonaBE();

            Int32 id_persona; Int32.TryParse(strFiltros[0].ToString(), out id_persona);
            oPersonaBE.id_persona = id_persona;
            oPersonaBEList = oPersonaBL.Get_ListaPersonas(oPersonaBE);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oPersonaBEList);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object EliminarFoto(String[] strParametros)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaBE oPersonaBE = new PersonaBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona;
                Int32.TryParse(strParametros[0].ToString(), out id_persona);

                String no_foto = strParametros[1].ToString();
                String pathImg = Parametros.CDOC_FileServer_RutaImgPersonas;
                String ruta_conductor = pathImg + no_foto.Substring(0, 6) + "/" + no_foto;
                ruta_conductor = HttpContext.Current.Server.MapPath(ruta_conductor);
                if (System.IO.File.Exists(ruta_conductor))
                {
                    System.IO.File.Delete(ruta_conductor);
                }

                oPersonaBE.id_persona = id_persona;
                oPersonaBE.no_foto = "";
                oPersonaBE.co_usuario = strParametros[2].ToString();
                oPersonaBE.no_usuario_red = strParametros[3].ToString();
                oPersonaBE.no_estacion_red = strParametros[4].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.GuardarFotoPersona(oPersonaBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }

        #region "Métodos Dirección Persona"
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_ListaDirecciones_Persona(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaDireccionBEList oPersonaDireccionBEList = new PersonaDireccionBEList();


            Int32 id_persona;
            Int32.TryParse(strFiltros[0].ToString(), out id_persona);

            oPersonaDireccionBEList = oPersonaBL.Get_ListaDirecciones_Persona(id_persona);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oPersonaDireccionBEList);
        }


        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object GrabarDireccion(String[] strParametros)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaDireccionBE oPersonaDireccionBE = new PersonaDireccionBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona_direccion;
                Int32.TryParse(strParametros[0].ToString(), out id_persona_direccion);

                oPersonaDireccionBE.id_persona_direccion = id_persona_direccion;

                Int32 id_persona;
                Int32.TryParse(strParametros[1].ToString(), out id_persona);

                oPersonaDireccionBE.id_persona = id_persona;
                oPersonaDireccionBE.no_direccion = strParametros[2].ToString();
                oPersonaDireccionBE.co_dpto = strParametros[3].ToString();
                oPersonaDireccionBE.co_prov = strParametros[4].ToString();
                oPersonaDireccionBE.co_dist = strParametros[5].ToString();
                oPersonaDireccionBE.no_contacto = strParametros[6].ToString();
                oPersonaDireccionBE.nu_telefono = strParametros[7].ToString();
                oPersonaDireccionBE.nu_celular = strParametros[8].ToString();
                oPersonaDireccionBE.no_correo = strParametros[9].ToString();
                oPersonaDireccionBE.fl_activo = strParametros[10].ToString();
                oPersonaDireccionBE.co_usuario = strParametros[11].ToString();
                oPersonaDireccionBE.no_usuario_red = strParametros[12].ToString();
                oPersonaDireccionBE.no_estacion_red = strParametros[13].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.GuardarDireccion(oPersonaDireccionBE, out retorno, out msg_retorno);

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
        public static object EliminarDireccion(String[] strParametros)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaDireccionBE oPersonaDireccionBE = new PersonaDireccionBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona_direccion;
                Int32.TryParse(strParametros[0].ToString(), out id_persona_direccion);
                oPersonaDireccionBE.id_persona_direccion = id_persona_direccion;
                oPersonaDireccionBE.co_usuario = strParametros[1].ToString();
                oPersonaDireccionBE.no_usuario_red = strParametros[2].ToString();
                oPersonaDireccionBE.no_estacion_red = strParametros[3].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.EliminarDireccion(oPersonaDireccionBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
        #endregion "Métodos Dirección Persona"
        #region "Métodos Archivos Persona"
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object GrabarPersonaFile(String[] strParametros)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaFileBE oPersonaBE = new PersonaFileBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona;
                Int32.TryParse(strParametros[0].ToString(), out id_persona);

                Int32 qt_peso;
                Int32.TryParse(strParametros[3].ToString(), out qt_peso);


                oPersonaBE.id_persona = id_persona;
                oPersonaBE.no_documento = strParametros[1].ToString();
                oPersonaBE.no_file = strParametros[2].ToString();
                oPersonaBE.qt_peso = qt_peso;
                oPersonaBE.co_usuario = strParametros[4].ToString();
                oPersonaBE.no_usuario_red = strParametros[5].ToString();
                oPersonaBE.no_estacion_red = strParametros[6].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.GuardarPersona_File(oPersonaBE, out retorno, out msg_retorno);

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
        public static object Get_ListaPersona_Files(Int32 id_persona)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaFileBEList oPersonaFileBEList = new PersonaFileBEList();

            oPersonaFileBEList = oPersonaBL.Get_ListaPersona_Files(id_persona);

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(oPersonaFileBEList);
        }

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object EliminarPersona_File(String[] strParametros)
        {
            PersonaBL oPersonaBL = new PersonaBL();
            PersonaFileBE oPersonaBE = new PersonaFileBE();
            object[] strRetorno;
            try
            {
                Int32 id_persona_file;
                Int32.TryParse(strParametros[0].ToString(), out id_persona_file);
                oPersonaBE.id_persona_File = id_persona_file;
                oPersonaBE.co_usuario = strParametros[1].ToString();
                oPersonaBE.no_usuario_red = strParametros[2].ToString();
                oPersonaBE.no_estacion_red = strParametros[3].ToString();

                Int32 retorno = 0; String msg_retorno = String.Empty;
                oPersonaBL.EliminarPersona_File(oPersonaBE, out retorno, out msg_retorno);

                strRetorno = new object[] { retorno, msg_retorno };
            }
            catch (Exception ex)
            {
                strRetorno = new object[] { -1, "Error: " + ex.Message };
            }

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(strRetorno);
        }
        #endregion "Métodos Archivos Persona"
    }
}