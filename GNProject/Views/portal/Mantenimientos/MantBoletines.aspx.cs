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
    public partial class MantBoletines : System.Web.UI.Page
    {
        BUSBoletines objNegBoletin = new BUSBoletines();
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
            lblBoletinId.Text = "";
            txtTitulo.Text = "";
            lblNomBoletin.Text = "";
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
            lblNomBoletin.Visible = false;
            IbtnEliminarArchivo.Visible = false;

            FileUpload2.Visible = true;
            lblNomImgMostrar.Visible = false;
            IbtnEliminarImgMostrar.Visible = false;
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

                String Ruta_Doc, Img_Mostrar, Tipo_Doc;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { Ruta_Doc = ""; Tipo_Doc = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "BO", ClaseGlobal.TipoArchivo.PDF, Parametros.I_FileServer_RutaBoletines, out Ruta_Doc);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir documento. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                if (FileUpload2.FileName.ToString() == "")
                { Img_Mostrar = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload2, "BO", ClaseGlobal.TipoArchivo.PNG, Parametros.I_FileServer_RutaBoletines, out Img_Mostrar);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir imagen. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                Tipo_Doc = "";

                Boletines objEBoletin = new Boletines(txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Img_Mostrar, Ruta_Doc, Tipo_Doc, User_Name, Fecha);
                rpta = objNegBoletin.InsertBoletines(objEBoletin);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                    UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    //-----Enviar Email a los Usuarios
                    String CorreosUsuariosaEnviar;
                    BUSCorreos objNCorreos = new BUSCorreos();
                    CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("BOLETINES");
                    String EnlaceDoc = Parametros.I_VirtualServer_Boletines + Ruta_Doc.Replace(" ", "%20");

                    String BodyHtml;
                    BodyHtml = "<html><head><style type='text/css'>body{font-family: Verdana;font-size: 12px;}a{color: #4682B4;	text-decoration: none;}a:hover{	color: #444; text-decoration: underline;}.title{color: #006699;	font-weight: bold;font-size: 14px;}</style> </head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'> <div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div> "
                        + "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'> "
                        + "Nuevo Boletin - " + txtTitulo.Text + "</span> <p>" + txtDescripcion.Text + "</p><a href='" + EnlaceDoc + "'>Descargar Boletin >></a> <p>Saludos</p></div></td></tr></table></div></body></html>";

                    string subject = "Nuevo Boletin - " + txtTitulo.Text;
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
                String Boletin_Id = lblBoletinId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Ruta_Doc, Img_Mostrar, Tipo_Doc;
                String msg_error;

                if (FileUpload1.Visible == false)
                {
                    Ruta_Doc = lblNomBoletin.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Ruta_Doc = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "BO", ClaseGlobal.TipoArchivo.PDF, Parametros.I_FileServer_RutaBoletines, out Ruta_Doc);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir documento. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                if (FileUpload2.Visible == false)
                {
                    Img_Mostrar = lblNomImgMostrar.Text;
                }
                else
                {
                    if (FileUpload2.FileName.ToString() == "")
                    { Img_Mostrar = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload2, "BO", ClaseGlobal.TipoArchivo.PNG, Parametros.I_FileServer_RutaBoletines, out Img_Mostrar);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir imagen. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Tipo_Doc = "";

                Boletines objEBoletin = new Boletines(Boletin_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Img_Mostrar, Ruta_Doc, Tipo_Doc, User_Name, Fecha);

                rpta = objNegBoletin.UpdateBoletines(objEBoletin);
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
                String Ruta_Doc = Parametros.I_FileServer_RutaBoletines + lblNomBoletin.Text;
                System.IO.File.Delete(Server.MapPath(Ruta_Doc));

                Ruta_Doc = "";

                String Boletin_Id = lblBoletinId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);
                String Tipo_Doc = "";

                String Img_Mostrar;
                if (FileUpload2.Visible == true)
                {
                    Img_Mostrar = "";
                }
                else
                {
                    Img_Mostrar = lblNomImgMostrar.Text;
                }

                Boletines objEBoletin = new Boletines(Boletin_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Img_Mostrar, Ruta_Doc, Tipo_Doc, User_Name, Fecha);

                rpta = objNegBoletin.UpdateBoletines(objEBoletin);
                if (rpta == 1)
                {
                    lblNomBoletin.Text = "";
                    lblNomBoletin.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Boletin<br>Boletin Actualizado Satisfactoriamente.";
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

        protected void EliminarImgMostrar()
        {
            try
            {
                String Img_Mostrar = Parametros.I_FileServer_RutaBoletines + lblNomImgMostrar.Text;
                System.IO.File.Delete(Server.MapPath(Img_Mostrar));

                Img_Mostrar = "";

                String Boletin_Id = lblBoletinId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);
                String Tipo_Doc = "";

                String Ruta_Doc;
                if (FileUpload1.Visible == true)
                {
                    Ruta_Doc = "";
                }
                else
                {
                    Ruta_Doc = lblNomBoletin.Text;
                }

                Boletines objEBoletin = new Boletines(Boletin_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Img_Mostrar, Ruta_Doc, Tipo_Doc, User_Name, Fecha);

                rpta = objNegBoletin.UpdateBoletines(objEBoletin);
                if (rpta == 1)
                {
                    lblNomImgMostrar.Text = "";
                    lblNomImgMostrar.Visible = false;
                    IbtnEliminarImgMostrar.Visible = false;
                    FileUpload2.Visible = true;

                    lblMensaje.Text = "Se Elimino la Imagen para Mostrar<br>Boletin Actualizado Satisfactoriamente.";
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
        protected void IbtnEliminarImgMostrar_Click(object sender, ImageClickEventArgs e)
        {
            EliminarImgMostrar();
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String Boletin_Id = hdfID.Value;

                //Eliminar Archivo
                Boletines objEDoc = new Boletines();
                objEDoc.Boletin_Id = Boletin_Id;
                DataTable dt = new DataTable();
                dt = objNegBoletin.ListaBoletinesxId(objEDoc);
                if (dt.Rows[0]["Ruta_Doc"].ToString().Trim() != "")
                {
                    String Ruta_Doc = Parametros.I_FileServer_RutaBoletines + dt.Rows[0]["Ruta_Doc"].ToString();
                    System.IO.File.Delete(Server.MapPath(Ruta_Doc));
                }
                if (dt.Rows[0]["Img_Mostrar"].ToString().Trim() != "")
                {
                    String Ruta_Doc = Parametros.I_FileServer_RutaBoletines + dt.Rows[0]["Img_Mostrar"].ToString();
                    System.IO.File.Delete(Server.MapPath(Ruta_Doc));
                }
                //---

                Int32 rpta = 0;
                Boletines objEBoletin = new Boletines();
                objEBoletin.Boletin_Id = Boletin_Id;
                rpta = objNegBoletin.DeleteBoletines(objEBoletin);
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

                String Boletin_Id = hdfID.Value;
                Boletines objEBoletin = new Boletines();
                objEBoletin.Boletin_Id = Boletin_Id;
                DataTable dt = new DataTable();
                dt = objNegBoletin.ListaBoletinesxId(objEBoletin);

                lblBoletinId.Text = Boletin_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();

                if (dt.Rows[0]["Ruta_Doc"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomBoletin.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomBoletin.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomBoletin.Text = dt.Rows[0]["Ruta_Doc"].ToString();
                }

                if (dt.Rows[0]["Img_Mostrar"].ToString().Trim() == "")
                {
                    FileUpload2.Visible = true;
                    lblNomImgMostrar.Visible = false;
                    IbtnEliminarImgMostrar.Visible = false;
                }
                else
                {
                    FileUpload2.Visible = false;
                    lblNomImgMostrar.Visible = true;
                    IbtnEliminarImgMostrar.Visible = true;
                    lblNomImgMostrar.Text = dt.Rows[0]["Img_Mostrar"].ToString();
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
            BUSBoletines objNegBoletines = new BUSBoletines();
            List<Boletines> oListaBoletines = new List<Boletines>();
            oListaBoletines = objNegBoletines.GetBoletinesAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaBoletines.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Boletines> orderedRecords = null;
            if (pSortColumn == "Boletin_Id") orderedRecords = oListaBoletines.OrderBy(col => col.Boletin_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaBoletines.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaBoletines.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaBoletines.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaBoletines.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaBoletines.OrderBy(col => col.sFecha);

            IEnumerable<Boletines> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaBoletines.ToList();
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
            foreach (Boletines obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Boletin_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Boletin_Id + "&#39;)'>",
                    Boletin_Id = obj.Boletin_Id,
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