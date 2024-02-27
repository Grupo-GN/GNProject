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

using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantContenidos : System.Web.UI.Page
    {
        BUSContenidos objNegContenidos = new BUSContenidos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaContenidos();
                if (cboContenido.SelectedValue != "")
                    ListaContenidoxId(Convert.ToInt32(cboContenido.SelectedValue)); //Listar contenido de 1 (Bienvenido)
                else txtDescripcion.Text = " no hay datos";
            }
        }

        private void Limpiar()
        {
            txtDescripcion.Text = "";
            imgFoto.ImageUrl = "";
            lblMensaje.Text = "";
        }

        private void ListaContenidos()
        {
            DataTable dt = new DataTable();
            dt = objNegContenidos.ListaContenidos();
            cboContenido.DataSource = dt;
            cboContenido.DataTextField = "Categoria";
            cboContenido.DataValueField = "Contenido_Id";
            cboContenido.DataBind();
            dt.Dispose();
        }

        private void ListaContenidoxId(Int32 Contenido_Id)
        {
            DataTable dt = new DataTable();
            Contenidos objEContenidos = new Contenidos();
            objEContenidos.Contenido_Id = Contenido_Id;
            dt = objNegContenidos.ListaContenidosxId(objEContenidos);
            txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();

            String PathContenidos = Parametros.I_FileServer_RutaContenidos;
            if (dt.Rows[0]["Ruta_Img"].ToString().Trim() == "")
            {
                lblNombreFoto.Text = "";
                imgFoto.ImageUrl = "";
                FileUploadFoto.Visible = true;
                btnSubirFoto.Visible = true;
                btnEliminarFoto.Visible = false;
            }
            else
            {
                lblNombreFoto.Text = dt.Rows[0]["Ruta_Img"].ToString();
                imgFoto.ImageUrl = PathContenidos + dt.Rows[0]["Ruta_Img"].ToString();
                FileUploadFoto.Visible = false;
                btnSubirFoto.Visible = false;
                btnEliminarFoto.Visible = true;
            }

            dt.Dispose();
        }
        protected void cboContenido_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();
            Int32 Contenido_Id;
            Contenido_Id = Convert.ToInt32(cboContenido.SelectedValue);
            ListaContenidoxId(Contenido_Id);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateContenidos();
        }

        void UpdateContenidos()
        {
            try
            {
                Contenidos objEContenidos = new Contenidos();
                objEContenidos.Contenido_Id = Convert.ToInt32(cboContenido.SelectedValue);
                objEContenidos.Descripcion = txtDescripcion.Text;
                objEContenidos.Ruta_Img = lblNombreFoto.Text;
                Int32 rpta = 0;
                rpta = objNegContenidos.UpdateContenidosxId(objEContenidos);
                if (rpta == 1)
                {
                    ListaContenidoxId(Convert.ToInt32(cboContenido.SelectedValue));
                    lblMensaje.Text = "Contenido Actualizado Satisfactoriamente.";
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

        protected void btnSubirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile miFichero = FileUploadFoto.PostedFile;
                // Longitud en Kb
                double Kb = miFichero.ContentLength / 1024;

                if (Kb > 1024) //Maximo 1 Mb
                {
                    lblMensaje.Text = "La Imagen pasa 1 Mb";
                    return;
                }

                // Nombre del fichero
                string nombreFichero = miFichero.FileName;

                // El tipo mime
                string mimeType = miFichero.ContentType;
                if (mimeType != "image/jpeg" && mimeType != "image/gif" && mimeType != "image/bmp" && mimeType != "image/png")
                {
                    lblMensaje.Text = "Solo se pueden subir archivos JPG, Gif, Bmp, PNG.";
                    return;
                }
                String Extension;
                Extension = System.IO.Path.GetExtension(FileUploadFoto.FileName);

                // El FileStream correspondiente
                Stream stream = (Stream)miFichero.InputStream;

                // Y finalmente guardar el resultado
                String PathContenidos = Parametros.I_FileServer_RutaContenidos;
                miFichero.SaveAs(Server.MapPath(PathContenidos + System.IO.Path.GetFileName(nombreFichero)));

                imgFoto.ImageUrl = PathContenidos + System.IO.Path.GetFileName(nombreFichero);
                lblNombreFoto.Text = System.IO.Path.GetFileName(nombreFichero);

                //lblMensaje.Text = "Kb: " + Kb.ToString() + "<Br />Nom: " + nombreFichero + "<Br />mimeType :" + mimeType;
                lblMensaje.Text = "Imagen Subida al Servidor.";
                lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                btnEliminarFoto.Visible = true;
                btnSubirFoto.Visible = false;

                UpdateContenidos();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnEliminarFoto_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Server.MapPath(imgFoto.ImageUrl));
            imgFoto.ImageUrl = "";
            FileUploadFoto.Visible = true;
            btnSubirFoto.Visible = true;
            btnEliminarFoto.Visible = false;
            try
            {
                Contenidos objEContenidos = new Contenidos();
                objEContenidos.Contenido_Id = Convert.ToInt32(cboContenido.SelectedValue);
                objEContenidos.Descripcion = txtDescripcion.Text;
                objEContenidos.Ruta_Img = imgFoto.ImageUrl;
                Int32 rpta = 0;
                rpta = objNegContenidos.UpdateContenidosxId(objEContenidos);
                if (rpta == 1)
                {
                    lblMensaje.Text = "Se Elimino la imagen<br>Contenido Actualizado Satisfactoriamente.";
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
    }
}