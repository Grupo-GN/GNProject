﻿using System;
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
    public partial class MantProcedimientos : System.Web.UI.Page
    {
        BUSProcedimientos objNegProcedimiento = new BUSProcedimientos();
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
            lblProcedimientoId.Text = "";
            txtTitulo.Text = "";
            lblNomProcedimiento.Text = "";
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
            lblNomProcedimiento.Visible = false;
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
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "PR", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaProcedimientos, out Nombre_Doc);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir Procedimiento. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                Procedimientos objEProcedimiento = new Procedimientos(txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);
                rpta = objNegProcedimiento.InsertProcedimiento(objEProcedimiento);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    //-----Enviar Email a los Usuarios
                    String CorreosUsuariosaEnviar;
                    BUSCorreos objNCorreos = new BUSCorreos();
                    CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("PROCEDIMIENTOS");
                    String EnlaceDoc = Parametros.I_VirtualServer_Procedimientos + Nombre_Doc.Replace(" ", "%20");

                    String BodyHtml;
                    BodyHtml = "<html><head><style type='text/css'>body{font-family: Verdana;font-size: 12px;}a{color: #4682B4;	text-decoration: none;}a:hover{	color: #444; text-decoration: underline;}.title{color: #006699;	font-weight: bold;font-size: 14px;}</style> </head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'> <div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div> "
                        + "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'> "
                        + "Nuevo Procedimiento - " + txtTitulo.Text + "</span> <p>" + txtDescripcion.Text + "</p><a href='" + EnlaceDoc + "'>Descargar Procedimiento >></a> <p>Saludos</p></div></td></tr></table></div></body></html>";

                    string subject = "Nuevo Procedimiento - " + txtTitulo.Text;
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
                String Procedimiento_Id = lblProcedimientoId.Text;
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
                    Nombre_Doc = lblNomProcedimiento.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Nombre_Doc = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "PR", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaProcedimientos, out Nombre_Doc);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir Procedimiento. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Procedimientos objEProcedimiento = new Procedimientos(Procedimiento_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegProcedimiento.UpdateProcedimiento(objEProcedimiento);
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
                String Nombre_Doc = Parametros.I_FileServer_RutaProcedimientos + lblNomProcedimiento.Text;
                System.IO.File.Delete(Server.MapPath(Nombre_Doc));

                Nombre_Doc = "";

                String Procedimiento_Id = lblProcedimientoId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                Procedimientos objEProcedimiento = new Procedimientos(Procedimiento_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Nombre_Doc, User_Name, Fecha);

                rpta = objNegProcedimiento.UpdateProcedimiento(objEProcedimiento);
                if (rpta == 1)
                {
                    lblNomProcedimiento.Text = "";
                    lblNomProcedimiento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Procedimiento<br>Procedimiento Actualizado Satisfactoriamente.";
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
                String Procedimiento_Id = hdfID.Value;

                //Eliminar Archivo
                Procedimientos objEDoc = new Procedimientos();
                objEDoc.Procedimiento_Id = Procedimiento_Id;
                DataTable dt = new DataTable();
                dt = objNegProcedimiento.ListaProcedimientoxId(objEDoc);
                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() != "")
                {
                    String Nombre_Doc = Parametros.I_FileServer_RutaProcedimientos + dt.Rows[0]["Nombre_Doc"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Doc));
                }
                //---

                Int32 rpta = 0;
                Procedimientos objEProcedimiento = new Procedimientos();
                objEProcedimiento.Procedimiento_Id = Procedimiento_Id;
                rpta = objNegProcedimiento.DeleteProcedimiento(objEProcedimiento);
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

                String Procedimiento_Id = hdfID.Value;
                Procedimientos objEProcedimiento = new Procedimientos();
                objEProcedimiento.Procedimiento_Id = Procedimiento_Id;
                DataTable dt = new DataTable();
                dt = objNegProcedimiento.ListaProcedimientoxId(objEProcedimiento);

                lblProcedimientoId.Text = Procedimiento_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();

                if (dt.Rows[0]["Nombre_Doc"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomProcedimiento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomProcedimiento.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomProcedimiento.Text = dt.Rows[0]["Nombre_Doc"].ToString();
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
            BUSProcedimientos objNegProcedimientos = new BUSProcedimientos();
            List<Procedimientos> oListaProcedimientos = new List<Procedimientos>();
            oListaProcedimientos = objNegProcedimientos.GetProcedimientosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaProcedimientos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Procedimientos> orderedRecords = null;
            if (pSortColumn == "Procedimiento_Id") orderedRecords = oListaProcedimientos.OrderBy(col => col.Procedimiento_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaProcedimientos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaProcedimientos.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaProcedimientos.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaProcedimientos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaProcedimientos.OrderBy(col => col.sFecha);

            IEnumerable<Procedimientos> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaProcedimientos.ToList();
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
            foreach (Procedimientos obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png'class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.Procedimiento_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/delete.png'class='icons-table deleteItem' width='15px' onclick='fn_Eliminar(&#39;" + obj.Procedimiento_Id + "&#39;)'>",
                    Procedimiento_Id = obj.Procedimiento_Id,
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