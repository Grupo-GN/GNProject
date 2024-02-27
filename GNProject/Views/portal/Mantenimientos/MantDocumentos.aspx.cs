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
using System.Collections;

using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantDocumentos : System.Web.UI.Page
    {
        BUSDocumentos objNegDocumento = new BUSDocumentos();
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
        protected void Limpiar()
        {
            lblMensaje.Text = "";
            lblDocumentoId.Text = "";
            txtTitulo.Text = "";
            lblNomDocumento.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
            cboArea.SelectedIndex = 0;
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            FileUpload1.Visible = true;
            lblNomDocumento.Visible = false;
            IbtnEliminarArchivo.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Doc;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { Nombre_Doc = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "DO", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaDocumentos, out Nombre_Doc);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir documento. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                Documentos objEDocumento = new Documentos(txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);
                rpta = objNegDocumento.InsertDocumento(objEDocumento);
                Console.WriteLine(rpta);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    //-----Enviar Email a los Usuarios
                    String CorreosUsuariosaEnviar;
                    BUSCorreos objNCorreos = new BUSCorreos();
                    CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("DOCUMENTOS");
                    String EnlaceDoc = Parametros.I_VirtualServer_Documentos + Nombre_Doc.Replace(" ", "%20");

                    String BodyHtml;
                    BodyHtml = "<html><head><style type='text/css'>body{font-family: Verdana;font-size: 12px;}a{color: #4682B4;	text-decoration: none;}a:hover{	color: #444; text-decoration: underline;}.title{color: #006699;	font-weight: bold;font-size: 14px;}</style> </head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'> <div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div> "
                        + "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'> "
                        + "Nuevo Manual - " + txtTitulo.Text + "</span> <p>" + txtDescripcion.Text + "</p><a href='" + EnlaceDoc + "'>Descargar Manual >></a> <p>Saludos</p></div></td></tr></table></div></body></html>";

                    string subject = "Nuevo Documento - " + txtTitulo.Text;
                    CorreoElectronico oEmail = new CorreoElectronico();
                    bool rptaEmail = false;
                    rptaEmail = oEmail.EnviarCorreo(CorreosUsuariosaEnviar, subject, BodyHtml);
                    String error_email = oEmail.no_error;
                    if (rptaEmail == true) lblMensaje.Text = "Grabado y Email Enviado a los Usuarios Satisfactoriamente";
                    else lblMensaje.Text = "Grabado pero ocurrio error al enviar los correos. <BR />" + error_email;
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un Error al intentar grabar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String Documento_Id = lblDocumentoId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Doc;
                String msg_error;

                if (FileUpload1.Visible == false)
                {
                    Nombre_Doc = lblNomDocumento.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Nombre_Doc = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "DO", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaDocumentos, out Nombre_Doc);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir documento. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Documentos objEDocumento = new Documentos(Documento_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegDocumento.UpdateDocumento(objEDocumento);
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

        protected void EliminarFile()
        {
            try
            {
                String Nombre_Doc = Parametros.I_FileServer_RutaDocumentos + lblNomDocumento.Text;
                System.IO.File.Delete(Server.MapPath(Nombre_Doc));

                Nombre_Doc = "";

                String Documento_Id = lblDocumentoId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                Documentos objEDocumento = new Documentos(Documento_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegDocumento.UpdateDocumento(objEDocumento);
                if (rpta == 1)
                {
                    lblNomDocumento.Text = "";
                    lblNomDocumento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Documento<br>Documento Actualizado Satisfactoriamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un error al momento de actualizar.<Br> Vuelta a intentarlo mas tarde.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void IbtnEliminarArchivo_Click(object sender, ImageClickEventArgs e)
        {
            EliminarFile();
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String Documento_Id = hdfID.Value;

                //Eliminar Archivo
                Documentos objEDoc = new Documentos();
                objEDoc.Documento_Id = Documento_Id;
                DataTable dt = new DataTable();
                dt = objNegDocumento.ListaDocumentoxId(objEDoc);
                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() != "")
                {
                    String Nombre_Doc = Parametros.I_FileServer_RutaDocumentos + dt.Rows[0]["Nombre_Doc"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Doc));
                }
                //---

                Int32 rpta = 0;
                Documentos objEDocumento = new Documentos();
                objEDocumento.Documento_Id = Documento_Id;
                rpta = objNegDocumento.DeleteDocumento(objEDocumento);
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
                Limpiar();

                String Documento_Id = hdfID.Value;
                Documentos objEDocumento = new Documentos();
                objEDocumento.Documento_Id = Documento_Id;
                DataTable dt = new DataTable();
                dt = objNegDocumento.ListaDocumentoxId(objEDocumento);

                lblDocumentoId.Text = Documento_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();

                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomDocumento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomDocumento.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomDocumento.Text = dt.Rows[0]["Nombre_Doc"].ToString();
                }

                btnGrabar.Visible = false;
                btnUpdate.Visible = true;
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
            BUSDocumentos objNegDocumentos = new BUSDocumentos();
            List<Documentos> oListaDocumentos = new List<Documentos>();
            oListaDocumentos = objNegDocumentos.GetDocumentosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaDocumentos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Documentos> orderedRecords = null;
            if (pSortColumn == "Documento_Id") orderedRecords = oListaDocumentos.OrderBy(col => col.Documento_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaDocumentos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaDocumentos.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaDocumentos.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaDocumentos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaDocumentos.OrderBy(col => col.sFecha);

            IEnumerable<Documentos> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaDocumentos.ToList();
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
            foreach (Documentos obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Documento_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Documento_Id + "&#39;)'>",
                    Documento_Id = obj.Documento_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    Area = obj.Area,
                    User_Name = obj.User_Name,
                    sFecha = obj.sFecha
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