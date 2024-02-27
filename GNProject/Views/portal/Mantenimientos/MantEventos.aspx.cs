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
    public partial class MantEventos : System.Web.UI.Page
    {
        BUSEvento objNegEvento = new BUSEvento();
        BUSEventoFotos objNEventoFotos = new BUSEventoFotos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void Limpiar()
        {
            lblMensaje.Text = "";
            lblEventoId.Text = "";
            txtTitulo.Text = "";
            lblNomEvento.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
            DataListFotos.DataBind();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            FileUpload1.Visible = true;
            lblNomEvento.Visible = false;
            IbtnEliminarArchivo.Visible = false;

            //Detalle Evento
            lblAgregarFotosEvento1.Visible = false;
            lblAgregarFotosEvento2.Visible = false;
            btnSubirImagenes.Visible = false;
            fuFoto1.Visible = false;
            fuFoto2.Visible = false;
            fuFoto3.Visible = false;
            fuFoto4.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String NomFotoEvento;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { NomFotoEvento = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "E", ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFotoEvento);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir Evento. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                Evento objEEvento = new Evento(txtTitulo.Text, txtDescripcion.Text, User_Name, Fecha, NomFotoEvento);
                rpta = objNegEvento.InsertEvento(objEEvento);

                if (rpta == 1)
                {
                    UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");

                    //Detalle Evento
                    lblAgregarFotosEvento1.Visible = true;
                    lblAgregarFotosEvento2.Visible = true;
                    btnSubirImagenes.Visible = true;
                    fuFoto1.Visible = true;
                    fuFoto2.Visible = true;
                    fuFoto3.Visible = true;
                    fuFoto4.Visible = true;
                    //---

                    lblMensaje.Text = "Grabado Satisfactoriamente";
                    lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    //-----Enviar Email a los Usuarios
                    String CorreosUsuariosaEnviar;
                    BUSCorreos objNCorreos = new BUSCorreos();
                    CorreosUsuariosaEnviar = objNCorreos.GetCorreosdeUsuriosAll("EVENTOS");
                    Int32 EventoIdMax = objNegEvento.MaxEventoId();
                    String Enlace = Parametros.I_RutaServidor + "Views/portal/Intranet/Eventos.aspx?id=" + EventoIdMax.ToString();

                    String BodyHtml;
                    BodyHtml = "<html><head><style type='text/css'>body{font-family: Verdana;font-size: 12px;}a{color: #4682B4;	text-decoration: none;}a:hover{	color: #444; text-decoration: underline;}.title{color: #006699;	font-weight: bold;font-size: 14px;}</style> </head><body><div style='width:600px;border: solid 1px #000; padding: 0px;margin:5px;'> <div style='padding:5px 5px 5px 10px;background: #006699;color:#FFF;font-weight: bold;font-size: 14px;'>" + Parametros.I_NombreProyecto + " " + Parametros.I_NombreEmpresa + "</div> "
                        + "<table cellspacing='0px' cellpadding='10px' style='font-family: Verdana;font-size:12px;width:100%;'><tr><td><div><span style='color: #006699;font-weight: bold;font-size: 14px;'> "
                        + "Nuevo Evento - " + txtTitulo.Text + "</span> <p>" + txtDescripcion.Text + "</p><a href='" + Enlace + "'>Ver Evento >></a> <p>Saludos</p></div></td></tr></table></div></body></html>";

                    string subject = "Nuevo Evento - " + txtTitulo.Text;
                    CorreoElectronico oEmail = new CorreoElectronico();
                    bool rptaEmail = false;
                    rptaEmail = oEmail.EnviarCorreo(CorreosUsuariosaEnviar, subject, BodyHtml);
                    String error_email = oEmail.no_error;
                    if (rptaEmail == true) lblMensaje.Text = "Grabado y Email Enviado a los Usuarios Satisfactoriamente";
                    else lblMensaje.Text = "Grabado pero ocurrio error al enviar los correos. <BR />" + error_email;

                    UtilsScript.fc_JavaScript(this, "fn_Editar('" + EventoIdMax.ToString() + "');", "__script2__");
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un Error al intentar grabar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnSubirImagenes_Click(object sender, EventArgs e)
        {
            EventoFotos objE1;
            String msg_error;
            String NomFoto;

            if (fuFoto1.FileName.ToString() == "" && fuFoto2.FileName.ToString() == ""
                && fuFoto3.FileName.ToString() == "" && fuFoto4.FileName.ToString() == "")
            {
                lblMensaje.Text = "Debe seleccionar algún archivo";
                lblMensaje.ForeColor = System.Drawing.Color.Red;

                UtilsScript.fc_JavaScript(this, "fn_IrTab2();", "__script1__");
                return;
            }

            String Prefijo = lblEventoId.Text;

            if (fuFoto1.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuFoto1, Prefijo, ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFoto);
                if (msg_error != String.Empty)
                {
                    lblMensaje.Text = "Error al subir Evento. " + msg_error;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    objE1 = new EventoFotos(NomFoto, Convert.ToInt32(lblEventoId.Text));
                    objNEventoFotos.InsertEventoFotos(objE1);
                }
            }

            if (fuFoto2.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuFoto2, Prefijo, ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFoto);
                if (msg_error != String.Empty)
                {
                    lblMensaje.Text = "Error al subir Evento. " + msg_error;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    objE1 = new EventoFotos(NomFoto, Convert.ToInt32(lblEventoId.Text));
                    objNEventoFotos.InsertEventoFotos(objE1);
                }
            }

            if (fuFoto3.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuFoto3, Prefijo, ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFoto);
                if (msg_error != String.Empty)
                {
                    lblMensaje.Text = "Error al subir Evento. " + msg_error;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    objE1 = new EventoFotos(NomFoto, Convert.ToInt32(lblEventoId.Text));
                    objNEventoFotos.InsertEventoFotos(objE1);
                }
            }

            if (fuFoto4.FileName.ToString() != "")
            {
                msg_error = ClaseGlobal.UploadFile(fuFoto4, Prefijo, ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFoto);
                if (msg_error != String.Empty)
                {
                    lblMensaje.Text = "Error al subir Evento. " + msg_error;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    objE1 = new EventoFotos(NomFoto, Convert.ToInt32(lblEventoId.Text));
                    objNEventoFotos.InsertEventoFotos(objE1);
                }
            }
            ListaEventoFotosxEvento_Id(Convert.ToInt32(lblEventoId.Text));
            UtilsScript.fc_JavaScript(this, "fn_IrTab2();", "__script1__");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 Evento_Id = Convert.ToInt32(lblEventoId.Text);
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String NomFotoEvento;
                String msg_error;

                if (FileUpload1.Visible == false)
                {
                    NomFotoEvento = lblNomEvento.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { NomFotoEvento = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "E", ClaseGlobal.TipoArchivo.Imagenes, Parametros.I_FileServer_RutaEventos, out NomFotoEvento);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir Evento. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Evento objEEvento = new Evento(Evento_Id, txtTitulo.Text, txtDescripcion.Text, User_Name, Fecha, NomFotoEvento);

                rpta = objNegEvento.UpdateEvento(objEEvento);
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
                String NomFotoEvento = Parametros.I_FileServer_RutaEventos + lblNomEvento.Text;
                System.IO.File.Delete(Server.MapPath(NomFotoEvento));

                NomFotoEvento = "";

                Int32 Evento_Id = Convert.ToInt32(lblEventoId.Text);
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                Evento objEEvento = new Evento(Evento_Id, txtTitulo.Text, txtDescripcion.Text, User_Name, Fecha, NomFotoEvento);

                rpta = objNegEvento.UpdateEvento(objEEvento);
                if (rpta == 1)
                {
                    lblNomEvento.Text = "";
                    lblNomEvento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Evento<br>Evento Actualizado Satisfactoriamente.";
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

        protected void lbEliminarFotoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta;
                LinkButton btn = new LinkButton();
                btn = (LinkButton)sender;
                Int32 EventoFotos_Id = Convert.ToInt32(btn.CommandArgument.ToString());

                String Nombre_Foto = Parametros.I_FileServer_RutaEventos + btn.CommandName.ToString();
                System.IO.File.Delete(Server.MapPath(Nombre_Foto));

                EventoFotos obj = new EventoFotos();
                obj.EventoFotos_Id = EventoFotos_Id;
                rpta = objNEventoFotos.DeleteEventoFotos(obj);
                //if (rpta == 1)
                //{
                lblMensaje.Text = "Se eliminó la Imagen.";
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                ListaEventoFotosxEvento_Id(Convert.ToInt32(lblEventoId.Text));
                //}
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Int32 Evento_Id = Convert.ToInt32(hdfID.Value);

                //Eliminar Archivo
                Evento objEDoc = new Evento();
                objEDoc.Evento_Id = Evento_Id;
                DataTable dt = new DataTable();
                dt = objNegEvento.ListaEventoxEventoId(objEDoc);
                if (dt.Rows[0]["NomFotoEvento"].ToString().Trim() != "")
                {
                    String NomFotoEvento = Parametros.I_FileServer_RutaEventos + dt.Rows[0]["NomFotoEvento"].ToString();
                    System.IO.File.Delete(Server.MapPath(NomFotoEvento));
                }
                //---
                //Eliminar fotos del evento
                EventoFotos objEEventoFotos = new EventoFotos();
                objEEventoFotos.Evento_Id = Evento_Id;
                DataTable dtEventoFotos = new DataTable();
                dtEventoFotos = objNEventoFotos.ListaEventoFotosxEventoId(objEEventoFotos);
                foreach (DataRow dr in dtEventoFotos.Rows)
                {
                    String Nombre_Foto = Parametros.I_FileServer_RutaEventos + dr["Nombre_Foto"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Foto));

                    EventoFotos objEEventoFotos2 = new EventoFotos();
                    objEEventoFotos2.EventoFotos_Id = Convert.ToInt32(dr["EventoFotos_Id"].ToString());
                    objNEventoFotos.DeleteEventoFotos(objEEventoFotos2);
                }
                //---

                Int32 rpta = 0;
                Evento objEEvento = new Evento();
                objEEvento.Evento_Id = Evento_Id;
                rpta = objNegEvento.DeleteEvento(objEEvento);
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

                Int32 Evento_Id = Convert.ToInt32(hdfID.Value);
                Evento objEEvento = new Evento();
                objEEvento.Evento_Id = Evento_Id;
                DataTable dt = new DataTable();
                dt = objNegEvento.ListaEventoxEventoId(objEEvento);

                lblEventoId.Text = Evento_Id.ToString();
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();

                if (dt.Rows[0]["NomFotoEvento"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomEvento.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomEvento.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomEvento.Text = dt.Rows[0]["NomFotoEvento"].ToString();
                }

                btnGrabar.Visible = false;
                btnUpdate.Visible = true;

                //Detalle Evento
                lblAgregarFotosEvento1.Visible = true;
                lblAgregarFotosEvento2.Visible = true;
                btnSubirImagenes.Visible = true;
                fuFoto1.Visible = true;
                fuFoto2.Visible = true;
                fuFoto3.Visible = true;
                fuFoto4.Visible = true;

                this.ListaEventoFotosxEvento_Id(Evento_Id);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
        void ListaEventoFotosxEvento_Id(Int32 Evento_Id)
        {
            EventoFotos objEEventoFotos = new EventoFotos();
            objEEventoFotos.Evento_Id = Evento_Id;
            DataTable dtEventoFotos = new DataTable();
            dtEventoFotos = objNEventoFotos.ListaEventoFotosxEventoId(objEEventoFotos);
            DataListFotos.DataSource = dtEventoFotos;
            DataListFotos.DataBind();
            dtEventoFotos.Dispose();
        }
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
            BUSEvento objNegEventos = new BUSEvento();
            List<Evento> oListaEventos = new List<Evento>();
            oListaEventos = objNegEventos.GetEventosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaEventos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Evento> orderedRecords = null;
            if (pSortColumn == "Evento_Id") orderedRecords = oListaEventos.OrderBy(col => col.Evento_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaEventos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaEventos.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "User_Name") orderedRecords = oListaEventos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaEventos.OrderBy(col => col.sFecha);

            IEnumerable<Evento> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaEventos.ToList();
            else
            {
                sortedRecords = orderedRecords.ToList();
                if (pSortOrder == "desc") sortedRecords = sortedRecords.Reverse();
            }
            sortedRecords = sortedRecords
                  .Skip((pageIndex - 1) * pageSize) //--- page the data
                  .Take(pageSize);

            //Retorna Evento JQGrid
            JQGridJsonResponse responseJQGrid = new JQGridJsonResponse(totalPages, pageIndex, totalRecords);
            JQGridJsonResponseRow oJQGridJsonResponseRow;
            Int32 i = 0;
            foreach (Evento obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Evento_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Evento_Id + "&#39;)'>",
                    Evento_Id = obj.Evento_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
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