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

using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantCronogramaMes : System.Web.UI.Page
    {
        BUSCronogramaMes objNegCronogramaMes = new BUSCronogramaMes();
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblCronogramaMesId.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtUbicacion.Text = "";
            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());
            txtHoraInicio.Text = "";
            txtHoraFinal.Text = "";
            cboArea.SelectedIndex = 0;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            FileUpload1.Visible = true;
            lblNomFoto.Visible = false;
            IbtnEliminarArchivo.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                DateTime Hora_Inicio, Hora_Final;
                Hora_Inicio = Convert.ToDateTime(txtHoraInicio.Text);
                Hora_Final = Convert.ToDateTime(txtHoraFinal.Text);

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Foto;
                if (FileUpload1.FileName.ToString() == "")
                { Nombre_Foto = ""; }
                else
                {
                    Nombre_Foto = SubirFile();
                }

                if (Nombre_Foto == "" || Nombre_Foto.Substring(0, 5) != "Error")
                {
                    CronogramaMes objE = new CronogramaMes(txtTitulo.Text, txtDescripcion.Text, txtUbicacion.Text, cboArea.SelectedValue, Fecha, Hora_Inicio, Hora_Final, Nombre_Foto, User_Name);
                    rpta = objNegCronogramaMes.InsertCronogramaMes(objE);

                    if (rpta == 1)
                    {
                        UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                        UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");
                        lblMensaje.Text = "Grabado Satisfactoriamente";
                        lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrio un Error al intentar grabar.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = Nombre_Foto;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String CronogramaMes_Id = hdfID.Value;

                //Eliminar Foto
                CronogramaMes objE = new CronogramaMes();
                objE.CronogramaMes_Id = CronogramaMes_Id;
                DataTable dt = new DataTable();
                dt = objNegCronogramaMes.ListaCronogramaMesxId(objE);

                String PathImagen = Parametros.I_FileServer_RutaCronogramaMes;
                if (dt.Rows[0]["Nombre_Foto"].ToString().Trim() != "")
                {
                    String Ruta_Doc = PathImagen + dt.Rows[0]["Nombre_Foto"].ToString();
                    System.IO.File.Delete(Server.MapPath(Ruta_Doc));
                }
                //---

                Int32 rpta = 0;
                CronogramaMes objECronogramaMes = new CronogramaMes();
                objECronogramaMes.CronogramaMes_Id = CronogramaMes_Id;
                rpta = objNegCronogramaMes.DeleteCronogramaMes(objECronogramaMes);
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
                String CronogramaMes_Id = hdfID.Value;
                CronogramaMes objECronogramaMes = new CronogramaMes();
                objECronogramaMes.CronogramaMes_Id = CronogramaMes_Id;
                DataTable dt = new DataTable();
                dt = objNegCronogramaMes.ListaCronogramaMesxId(objECronogramaMes);

                lblMensaje.Text = "";
                lblCronogramaMesId.Text = CronogramaMes_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtUbicacion.Text = dt.Rows[0]["Ubicacion"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                txtHoraInicio.Text = dt.Rows[0]["Hora_Inicio"].ToString();
                txtHoraFinal.Text = dt.Rows[0]["Hora_Final"].ToString();

                if (dt.Rows[0]["Nombre_Foto"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomFoto.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomFoto.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomFoto.Text = dt.Rows[0]["Nombre_Foto"].ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String CronogramaMes_Id = lblCronogramaMesId.Text;
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                DateTime Hora_Inicio, Hora_Final;
                Hora_Inicio = Convert.ToDateTime(txtHoraInicio.Text);
                Hora_Final = Convert.ToDateTime(txtHoraFinal.Text);

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Foto;

                if (FileUpload1.Visible == false)
                {
                    Nombre_Foto = lblNomFoto.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Nombre_Foto = ""; }
                    else
                    {
                        Nombre_Foto = SubirFile();
                    }
                }

                if (Nombre_Foto == "" || Nombre_Foto.Substring(0, 5) != "Error")
                {
                    CronogramaMes objECronogramaMes = new CronogramaMes(CronogramaMes_Id, txtTitulo.Text, txtDescripcion.Text, txtUbicacion.Text, cboArea.SelectedValue, Fecha, Hora_Inicio, Hora_Final, Nombre_Foto, User_Name);

                    rpta = objNegCronogramaMes.UpdateCronogramaMes(objECronogramaMes);
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
                    lblMensaje.Text = Nombre_Foto;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected String SubirFile()
        {
            try
            {
                HttpPostedFile miFichero = FileUpload1.PostedFile;
                // Longitud en Kb
                double Kb = miFichero.ContentLength / 1024;

                //if (Kb > 1024) //Maximo 1 Mb
                //{
                //    //lblMensaje.Text = "La Archivo debe pesar menos de 1 Mb";
                //    return "La Archivo debe pesar menos de 1 Mb";
                //}

                // Nombre del fichero
                string nombreFichero = miFichero.FileName;

                String Extension;
                Extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                // El tipo mime
                string mimeType = miFichero.ContentType;
                //if (Extension != ".doc" && Extension != ".docx" && Extension != ".xls" && Extension != ".xlsx" && Extension != ".pdf")
                //{
                //    //lblMensaje.Text = "Solo se pueden subir archivos word, excel, pdf.";
                //    return "Solo se pueden subir archivos word, excel, pdf."; ;
                //}

                if (Extension == ".exe")
                {
                    return "Error";
                }

                // El FileStream correspondiente
                Stream stream = (Stream)miFichero.InputStream;

                // Y finalmente guardar el resultado
                String PathImagen = Parametros.I_FileServer_RutaCronogramaMes;
                miFichero.SaveAs(Server.MapPath(PathImagen + System.IO.Path.GetFileName(nombreFichero)));


                //imgFoto.ImageUrl = "~/Mant/DocDocumento/" + nombreFichero;

                //lblMensaje.Text = "Kb: " + Kb.ToString() + "<Br />Nom: " + nombreFichero + "<Br />mimeType :" + mimeType;

                //lblMensaje.Text = "Archivo Subido al Servidor.";
                //lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                return System.IO.Path.GetFileName(nombreFichero);
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = ex.Message;
                //lblMensaje.ForeColor = System.Drawing.Color.Red;
                return "Error: " + ex.Message;
            }
        }

        protected void EliminarFile()
        {
            try
            {
                String PathImagen = Parametros.I_FileServer_RutaCronogramaMes;
                String Ruta_Doc = PathImagen + lblNomFoto.Text;
                System.IO.File.Delete(Server.MapPath(Ruta_Doc));

                Ruta_Doc = "";

                String CronogramaMes_Id = lblCronogramaMesId.Text;
                Int32 rpta = 0;
                String Categoria_Auxiliar_Id;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                CronogramaMes objE = new CronogramaMes(CronogramaMes_Id, txtTitulo.Text, txtDescripcion.Text, txtUbicacion.Text, Categoria_Auxiliar_Id, Fecha, Convert.ToDateTime(txtHoraInicio.Text), Convert.ToDateTime(txtHoraFinal.Text), Ruta_Doc, User_Name);

                rpta = objNegCronogramaMes.UpdateCronogramaMes(objE);
                if (rpta == 1)
                {
                    lblNomFoto.Text = "";
                    lblNomFoto.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se eliminó la imagen<br>Registro actualizado satisfactoriamente.";
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

        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        [WebMethod]
        public static object Get_Bandeja(String[] strFiltros
            , int pPageSize, int pCurrentPage, string pSortColumn, string pSortOrder)
        {
             BUSCronogramaMes objNegCronogramaMes = new BUSCronogramaMes();
            List<CronogramaMes> oLista = new List<CronogramaMes>();
            oLista = objNegCronogramaMes.GetCronogramaMesAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<CronogramaMes> orderedRecords = null;
            if (pSortColumn == "CronogramaMes_Id") orderedRecords = oLista.OrderBy(col => col.CronogramaMes_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oLista.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oLista.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "Ubicacion") orderedRecords = oLista.OrderBy(col => col.Ubicacion);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "sFecha") orderedRecords = oLista.OrderBy(col => col.sFecha);
            else if (pSortColumn == "sHora_Inicio") orderedRecords = oLista.OrderBy(col => col.sHora_Inicio);
            else if (pSortColumn == "sHora_Final") orderedRecords = oLista.OrderBy(col => col.sHora_Final);
            else if (pSortColumn == "User_Name") orderedRecords = oLista.OrderBy(col => col.User_Name);

            IEnumerable<CronogramaMes> sortedRecords;
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
            foreach (CronogramaMes obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/edit.png'class='icons-table editItem' width='15px' onclick='fn_Editar(&#39;" + obj.CronogramaMes_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/delete.png'class='icons-table deleteItem' width='15px' onclick='fn_Eliminar(&#39;" + obj.CronogramaMes_Id + "&#39;)'>",
                    CronogramaMes_Id = obj.CronogramaMes_Id,
                    Titulo = obj.Titulo,
                    Descripcion = obj.Descripcion,
                    Ubicacion = obj.Ubicacion,
                    Area = obj.Area,
                    sFecha = obj.sFecha,
                    sHora_Inicio = obj.sHora_Inicio,
                    sHora_Final = obj.sHora_Final,
                    User_Name = obj.User_Name
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