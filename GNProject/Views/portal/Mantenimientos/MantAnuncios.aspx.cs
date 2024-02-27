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
    public partial class MantAnuncios : System.Web.UI.Page
    {
        BUSAnuncios objNegAnuncios = new BUSAnuncios();
        BUSCategoria_Auxiliar objNegCatAux = new BUSCategoria_Auxiliar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaArea();
                IbtnEliminarFoto.Visible = false;
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
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblAnuncioId.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());
            cboArea.SelectedIndex = 0;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            IbtnEliminarFoto.Visible = false;
            imgFoto.Visible = false;
            imgFoto.ImageUrl = "";
            lblNombrFoto.Text = "";
            FileUpload1.Visible = true;
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

                String Ruta_Img;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { Ruta_Img = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "AN", ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaAnuncios, out Ruta_Img);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir imagen. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                String User_Name = ClaseGlobal.Get_UserName(this);

                if (Ruta_Img == "" || Ruta_Img.Substring(0, 5) != "Error")
                {

                    Anuncios objEAnuncios = new Anuncios(txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Ruta_Img, User_Name, Fecha);
                    rpta = objNegAnuncios.InsertAnuncios(objEAnuncios);

                    if (rpta == 1)
                    {
                        UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                        UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                        lblMensaje.Text = "Grabado Satisfactoriamente";
                        lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                        //-----Enviar Email a los Usuarios
                        String CorreosUsuariosaEnviar;
                        BUSCorreos objNCorreos = new BUSCorreos();
                        CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("ANUNCIOS");
                        String AnuncioIdMax = objNegAnuncios.GetAnuncioIdMax();
                        String Ruta_Img_Anuncios;
                        String Dominio = Parametros.I_RutaServidor;
                        if (Ruta_Img.Trim() == "")
                        {
                            Ruta_Img_Anuncios = Dominio + "Assets/images/imgPortal/Noticias.gif";
                        }
                        else
                        {
                            Ruta_Img_Anuncios = Parametros.I_VirtualServer_Anuncios + Ruta_Img.Replace(" ", "%20");
                        }
                        String BodyHtml;
                        BodyHtml = "<html><head><style type='text/css'>body{	font-family: Verdana;	font-size: 12px;}a{	color: #4682B4;	text-decoration: none;}a:hover{	color: #444;	text-decoration: underline;}.title{	color: #006699;	font-weight: bold;	font-size: 14px;}</style> " +
                        "</head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'>" +
                        "<div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div>" +
                        "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'>Nuevo Anuncio - " + txtTitulo.Text + "</span>" +
                        "<p>" + txtDescripcion.Text + "</p>" +
                        "<a href='" + Dominio + "Intranet/Anuncios.aspx?id=" + AnuncioIdMax + "'>Ver Anuncio >></a> " +
                        "<p>Saludos</p></div></td><td style='text-align:center;background:AliceBlue;width:120px;'><div> " +
                        "<IMG SRC='" + Ruta_Img_Anuncios + "' WIDTH='100px' HEIGHT='100px' /></div></td></tr></table></div></body></html>";

                        string subject = "Nuevo Anuncio - " + txtTitulo.Text;

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
                else
                {
                    lblMensaje.Text = Ruta_Img;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String Anuncios_Id = lblAnuncioId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String Ruta_Img;
                String msg_error;
                if (FileUpload1.Visible == false)
                {
                    Ruta_Img = System.IO.Path.GetFileName(imgFoto.ImageUrl);
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Ruta_Img = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "AN", ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaAnuncios, out Ruta_Img);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir imagen. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                String User_Name = ClaseGlobal.Get_UserName(this);

                if (Ruta_Img == "" || Ruta_Img.Substring(0, 5) != "Error")
                {
                    Anuncios objEAnuncios = new Anuncios(Anuncios_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Ruta_Img, User_Name, Fecha);

                    rpta = objNegAnuncios.UpdateAnuncios(objEAnuncios);
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
                else
                {
                    lblMensaje.Text = Ruta_Img;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void IbtnEliminarFoto_Click(object sender, ImageClickEventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(imgFoto.ImageUrl));
            lblNombrFoto.Text = "";
            imgFoto.ImageUrl = "";
            IbtnEliminarFoto.Visible = false;

            string lblid = lblAnuncioId.Text == "" ? "-" : lblAnuncioId.Text;

            if (objNegAnuncios.Get_Existe_IdAnuncio(lblid))
            {
                try
                {
                    String Anuncios_Id = lblAnuncioId.Text;
                    Int32 rpta = 0;
                    String Categoria_Auxiliar_Id;
                    Categoria_Auxiliar_Id = cboArea.SelectedValue;

                    DateTime Fecha;
                    Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                    String Ruta_Img = imgFoto.ImageUrl;
                    String User_Name = ClaseGlobal.Get_UserName(this);

                    Anuncios objEAnuncios = new Anuncios(Anuncios_Id, txtTitulo.Text, txtDescripcion.Text, Categoria_Auxiliar_Id, Ruta_Img, User_Name, Fecha);

                    rpta = objNegAnuncios.UpdateAnuncios(objEAnuncios);
                    if (rpta == 1)
                    {
                        FileUpload1.Visible = true;
                        imgFoto.Visible = false;
                        IbtnEliminarFoto.Visible = false;
                        lblMensaje.Text = "Se Elimino la imagen<br>Anuncio Actualizado Satisfactoriamente.";
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
            else
            { //Se elimino la imagen solo de la carpeta
                lblMensaje.Text = "Se Elimino la imagen.";
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
            }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Int32 rpta = 0;
                Anuncios objEAnuncios = new Anuncios();

                String Anuncios_Id = hdfID.Value;

                //Eliminar Archivo            
                objEAnuncios.Anuncio_Id = Anuncios_Id;
                DataTable dt = new DataTable();
                dt = objNegAnuncios.ListaAnunciosxId(objEAnuncios);
                if (dt.Rows[0]["Ruta_Foto"].ToString().Trim() != "")
                {
                    String Ruta_Foto = dt.Rows[0]["Ruta_Foto"].ToString();
                    System.IO.File.Delete(Server.MapPath(Parametros.I_FileServer_RutaAnuncios + Ruta_Foto));
                }
                //---

                objEAnuncios.Anuncio_Id = Anuncios_Id;
                rpta = objNegAnuncios.DeleteAnuncios(objEAnuncios);
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
                String Anuncios_Id = hdfID.Value;
                Anuncios objEAnuncios = new Anuncios();
                objEAnuncios.Anuncio_Id = Anuncios_Id;
                DataTable dt = new DataTable();
                dt = objNegAnuncios.ListaAnunciosxId(objEAnuncios);

                lblMensaje.Text = "";
                lblAnuncioId.Text = Anuncios_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();
                if (dt.Rows[0]["Ruta_Foto"].ToString().Trim() == "")
                {
                    imgFoto.ImageUrl = "";
                    lblNombrFoto.Text = "";
                    FileUpload1.Visible = true;
                    imgFoto.Visible = false;
                    IbtnEliminarFoto.Visible = false;
                }
                else
                {
                    lblNombrFoto.Text = dt.Rows[0]["Ruta_Foto"].ToString();
                    imgFoto.ImageUrl = Parametros.I_FileServer_RutaAnuncios + dt.Rows[0]["Ruta_Foto"].ToString();
                    FileUpload1.Visible = false;
                    imgFoto.Visible = true;
                    IbtnEliminarFoto.Visible = true;
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
            BUSAnuncios objNegAnuncios = new BUSAnuncios();
            List<Anuncios> oListaAnuncios = new List<Anuncios>();
            oListaAnuncios = objNegAnuncios.GetAnunciosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaAnuncios.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Anuncios> orderedRecords = null;
            if (pSortColumn == "Anuncio_Id") orderedRecords = oListaAnuncios.OrderBy(col => col.Anuncio_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaAnuncios.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaAnuncios.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Area") orderedRecords = oListaAnuncios.OrderBy(col => col.Area);
            else if (pSortColumn == "User_Name") orderedRecords = oListaAnuncios.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaAnuncios.OrderBy(col => col.sFecha);

            IEnumerable<Anuncios> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaAnuncios.ToList();
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
            foreach (Anuncios obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Anuncio_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Anuncio_Id + "&#39;)'>",
                    Anuncio_Id = obj.Anuncio_Id,
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