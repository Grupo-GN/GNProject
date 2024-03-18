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
    public partial class MantFormatos : System.Web.UI.Page
    {
        BUSNormativas objNegNormativa = new BUSNormativas();
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
            lblNormativaId.Text = "";
            txtTitulo.Text = "";
            lblNomNormativa.Text = "";
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
            lblNomNormativa.Visible = false;
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
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "FO", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaFormatos, out Nombre_Doc);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir Normativa. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                Normativas objENormativa = new Normativas(txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);
                rpta = objNegNormativa.InsertNormativa(objENormativa);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    //-----Enviar Email a los Usuarios
                    String CorreosUsuariosaEnviar;
                    BUSCorreos objNCorreos = new BUSCorreos();
                    CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("FORMATOS");
                    String EnlaceDoc = Parametros.I_VirtualServer_Formatos + Nombre_Doc.Replace(" ", "%20");

                    String BodyHtml;
                    BodyHtml = "<html><head><style type='text/css'>body{font-family: Verdana;font-size: 12px;}a{color: #4682B4;	text-decoration: none;}a:hover{	color: #444; text-decoration: underline;}.title{color: #006699;	font-weight: bold;font-size: 14px;}</style> </head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'> <div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div> "
                            + "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'> "
                            + "Nuevo Formato - " + txtTitulo.Text + "</span> <p>" + txtDescripcion.Text + "</p><a href='" + EnlaceDoc + "'>Descargar Formato >></a> <p>Saludos</p></div></td></tr></table></div></body></html>";

                    string subject = "Nuevo Normativa - " + txtTitulo.Text;
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
                String Normativa_Id = lblNormativaId.Text;
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
                    Nombre_Doc = lblNomNormativa.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Nombre_Doc = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "FO", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaFormatos, out Nombre_Doc);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir Normativa. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Normativas objENormativa = new Normativas(Normativa_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegNormativa.UpdateNormativa(objENormativa);
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
                String Nombre_Doc = Parametros.I_FileServer_RutaFormatos + lblNomNormativa.Text;
                System.IO.File.Delete(Server.MapPath(Nombre_Doc));

                Nombre_Doc = "";

                String Normativa_Id = lblNormativaId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                Normativas objENormativa = new Normativas(Normativa_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegNormativa.UpdateNormativa(objENormativa);
                if (rpta == 1)
                {
                    lblNomNormativa.Text = "";
                    lblNomNormativa.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Normativa<br>Normativa Actualizado Satisfactoriamente.";
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
                String Normativa_Id = hdfID.Value;

                //Eliminar Archivo
                Normativas objEDoc = new Normativas();
                objEDoc.Normativa_Id = Normativa_Id;
                DataTable dt = new DataTable();
                dt = objNegNormativa.ListaNormativaxId(objEDoc);
                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() != "")
                {
                    String Nombre_Doc = Parametros.I_FileServer_RutaFormatos + dt.Rows[0]["Nombre_Doc"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Doc));
                }
                //---

                Int32 rpta = 0;
                Normativas objENormativa = new Normativas();
                objENormativa.Normativa_Id = Normativa_Id;
                rpta = objNegNormativa.DeleteNormativa(objENormativa);
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

                String Normativa_Id = hdfID.Value;
                Normativas objENormativa = new Normativas();
                objENormativa.Normativa_Id = Normativa_Id;
                DataTable dt = new DataTable();
                dt = objNegNormativa.ListaNormativaxId(objENormativa);

                lblNormativaId.Text = Normativa_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();

                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomNormativa.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomNormativa.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomNormativa.Text = dt.Rows[0]["Nombre_Doc"].ToString();
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
            BUSNormativas objNegNormativas = new BUSNormativas();
            List<Normativas> oListaNormativas = new List<Normativas>();
            oListaNormativas = objNegNormativas.GetNormativasAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaNormativas.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Normativas> orderedRecords = null;
            if (pSortColumn == "Normativa_Id") orderedRecords = oListaNormativas.OrderBy(col => col.Normativa_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaNormativas.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaNormativas.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaNormativas.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaNormativas.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaNormativas.OrderBy(col => col.sFecha);

            IEnumerable<Normativas> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaNormativas.ToList();
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
            foreach (Normativas obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png' class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.Normativa_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/delete.png'class='icons-table deleteItem' width='15px' onclick='fn_Eliminar(&#39;" + obj.Normativa_Id + "&#39;)'>",
                    Normativa_Id = obj.Normativa_Id,
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