using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Capas.Portal.Negocio;
using Capas.Portal.Entidad;
using System.IO;
using System.Web.Services;

using GNProject.Acceso.App_code_portal;

namespace GNProject.Views.portal.Mantenimientos
{
    public partial class MantUsuarios : System.Web.UI.Page
    {
        BUSPlanilla objNegPlanilla = new BUSPlanilla();
        BUSLocalidad objNegLocalidad = new BUSLocalidad();
        BUSCategoria_Auxiliar objNegCatAux = new BUSCategoria_Auxiliar();
        BUSCategoria_Auxiliar2 objNegCatAux2 = new BUSCategoria_Auxiliar2();
        BUSPersonal objNegPersonal = new BUSPersonal();
        BUSPermisos objNegPermisos = new BUSPermisos();

        BUSUsuarios objNegUsers = new BUSUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblTotalVisitas.Text = objNegUsers.GetTotalVisitas().ToString();
                ListaPlanilla();
                ListaLocalidad();
                ListaCatAuxiliar();
                ListaCatAuxiliar2(cboArea.SelectedValue);
                ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
                ListaPermisos();
            }
        }

        #region Metodos

        private void ListaPermisos()
        {
            cboPermiso.DataSource = objNegPermisos.ListaPermisos();
            cboPermiso.DataTextField = "Nivel";
            cboPermiso.DataValueField = "Permiso_Id";
            cboPermiso.DataBind();
        }
        private void ListaPlanilla()
        {
            cboPlanilla.DataSource = objNegPlanilla.BUSListaPlanilla().Tables[0];
            cboPlanilla.DataTextField = "Descripcion";
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
        }
        private void ListaLocalidad()
        {
            cboLocalidad.DataSource = objNegLocalidad.ListaLocalidad();
            cboLocalidad.DataTextField = "Descripcion";
            cboLocalidad.DataValueField = "Area_Id";
            cboLocalidad.DataBind();
        }
        private void ListaCatAuxiliar()
        {
            cboArea.DataSource = objNegCatAux.ListaCategoria_Auxiliar();
            cboArea.DataTextField = "Descripcion";
            cboArea.DataValueField = "Categoria_Auxiliar_Id";
            cboArea.DataBind();
        }
        private void ListaCatAuxiliar2(String Categoria_Auxiliar_Id)
        {
            cboSeccion.DataSource = objNegCatAux2.ListaCategoria_Auxiliar2(Categoria_Auxiliar_Id);
            cboSeccion.DataTextField = "Descripcion";
            cboSeccion.DataValueField = "Categoria_Auxiliar2_Id";
            cboSeccion.DataBind();
        }
        private void ListaPersonal(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Categoria_Auxiliar2_Id)
        {
            cboPersonal.DataSource = objNegPersonal.ListaPersonal(Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id);
            cboPersonal.DataTextField = "Nombre_Completo";
            cboPersonal.DataValueField = "Personal_Id";
            cboPersonal.DataBind();
        }
        #endregion Metodos


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

                System.IO.FileInfo archiinfo = new System.IO.FileInfo(
                        this.FileUpload1.FileName);

                String Extension;
                Extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                // El tipo mime
                string mimeType = miFichero.ContentType;
                //if (Extension != ".doc" && Extension != ".docx" && Extension != ".xls" && Extension != ".xlsx" && Extension != ".pdf")
                //{
                //    //lblMensaje.Text = "Solo se pueden subir archivos word, excel, pdf.";
                //    return "Solo se pueden subir archivos word, excel, pdf."; ;
                //}

                if (Extension == ".exe" || Extension == ".doc" || Extension == ".xls" || Extension == ".pdf" || Extension == ".docx" || Extension == ".xlsx" || Extension == ".ppt" || Extension == ".pptx")
                {
                    return "Error";
                }

                // El FileStream correspondiente
                Stream stream = (Stream)miFichero.InputStream;

                // Y finalmente guardar el resultado
                String PathImgUsuario = Parametros.I_FileServer_RutaImgUsers;
                miFichero.SaveAs(Server.MapPath(PathImgUsuario + System.IO.Path.GetFileName(nombreFichero)));

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

        protected void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
        }
        protected void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
        }
        protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaCatAuxiliar2(cboArea.SelectedValue);
            ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
        }
        protected void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblMensaje.Text = "Las Contraseñas no coinciden.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                //String User_Id = "U00001";
                String Planilla_Id, Personal_Id, User_Name, Password, Ruta_Foto, Email, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Estado_Id;
                Planilla_Id = cboPlanilla.SelectedValue;
                Personal_Id = cboPersonal.SelectedValue;
                Categoria_Auxiliar_Id = cboArea.SelectedValue;
                Categoria_Auxiliar2_Id = cboSeccion.SelectedValue;
                User_Name = txtUsuario.Text;
                Password = txtPassword.Text;

                Email = txtEmail.Text;
                Estado_Id = "01";

                Int32 Permiso_Id;
                Permiso_Id = Convert.ToInt32(cboPermiso.SelectedValue);

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFechaIngreso.Text);//DateTime.Now.Date;

                //Ruta_Foto = imgFoto.ImageUrl; //FileUploadFoto.FileName;

                if (FileUpload1.FileName.ToString() == "")
                { Ruta_Foto = ""; }
                else
                {
                    Ruta_Foto = SubirFile();
                }

                if (Ruta_Foto == "" || Ruta_Foto.Substring(0, 5) != "Error")
                {
                    Usuarios objEUsers = new Usuarios(Planilla_Id, Personal_Id, User_Name, Password, Ruta_Foto, Permiso_Id, Email, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id, Estado_Id,Fecha);

                    Int32 rpta;
                    rpta = objNegUsers.AddUsers(objEUsers)-3;
                    if (rpta == 1)
                    {
                        UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                        UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                        lblMensaje.Text = "Usuario Registrado Satisfactoriamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;

                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrio un error al momento de grabar.<Br> Vuelta a intentarlo mas tarde.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = Ruta_Foto;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Desbloquear();
            btnUpdate.Visible = false;

            FileUpload1.Visible = true;
            imgFoto.Visible = false;
            IbtnEliminarArchivo.Visible = false;

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;
        }

        private void Bloquear()
        {
            cboPlanilla.Enabled = false;
            cboLocalidad.Enabled = false;
            cboArea.Enabled = false;
            cboSeccion.Enabled = false;
            cboPersonal.Enabled = false;

            txtUsuario.Enabled = false;

        }

        private void Desbloquear()
        {
            cboPlanilla.Enabled = true;
            cboLocalidad.Enabled = true;
            cboArea.Enabled = true;
            cboSeccion.Enabled = true;
            cboPersonal.Enabled = true;

            txtUsuario.Enabled = true;

        }

        private void Limpiar()
        {
            lblMensaje.Text = "";
            lblUserId.Text = "";
            cboPlanilla.SelectedIndex = 0;
            cboLocalidad.SelectedIndex = 0;
            cboArea.SelectedIndex = 0;
            ListaCatAuxiliar2(cboArea.SelectedValue);
            cboPersonal.Items.Clear();
            imgFoto.ImageUrl = "";
            txtFechaIngreso.Text = (DateTime.Now.Date.ToShortDateString());

            txtEmail.Text = "";
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cboPermiso.SelectedIndex = 0;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblMensaje.Text = "Las contraseñas no coinciden.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                String User_Id = lblUserId.Text;
                Int32 rpta = 0;

                String Ruta_Foto;

                String Estado_Id = "01";

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFechaIngreso.Text);//DateTime.Now.Date;

                if (FileUpload1.Visible == false)
                {
                    Ruta_Foto = System.IO.Path.GetFileName(imgFoto.ImageUrl);
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Ruta_Foto = ""; }
                    else
                    {
                        Ruta_Foto = SubirFile();
                    }
                }

                if (Ruta_Foto == "" || Ruta_Foto.Substring(0, 5) != "Error")
                {
                    Usuarios objEUser = new Usuarios(User_Id, txtPassword.Text, Ruta_Foto, Convert.ToInt32(cboPermiso.SelectedValue), txtEmail.Text, Estado_Id,Fecha);

                    rpta = objNegUsers.UpdateUsers(objEUser);
                    if (rpta == 1)
                    {
                        UtilsScript.fc_JavaScript(this, "fn_Buscar();", "__script1__");
                        UtilsScript.fc_JavaScript(this, "fn_Volver();", "__script2__");

                        lblMensaje.Text = "Actualizado Satisfactoriamente";
                        lblMensaje.ForeColor = System.Drawing.Color.DarkOrange;
                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrio un error al intentar Actualizar";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = Ruta_Foto;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void EliminarFoto()
        {

            try
            {
                String Ruta_Foto = imgFoto.ImageUrl;
                System.IO.File.Delete(Server.MapPath(Ruta_Foto));

                Ruta_Foto = "";

                String User_Id = lblUserId.Text;
                Int32 rpta = 0;

                rpta = objNegUsers.UpdateUsersFoto(User_Id, Ruta_Foto);
                if (rpta == 1)
                {
                    imgFoto.ImageUrl = "";
                    imgFoto.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino la Foto<br>Usuario Actualizado Satisfactoriamente.";
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
            EliminarFoto();
        }


        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                String User_Id = hdfUserID.Value;

                //Eliminar Archivo
                Usuarios objEUsu = new Usuarios();
                objEUsu.User_Id = User_Id;
                DataTable dt = new DataTable();
                dt = objNegUsers.ListaUserxId(objEUsu);
                if (dt.Rows[0]["Ruta_Foto"].ToString().Trim() != "")
                {
                    String Ruta_Foto = dt.Rows[0]["Ruta_Foto"].ToString();
                    System.IO.File.Delete(Server.MapPath(Parametros.I_FileServer_RutaImgUsers + Ruta_Foto));
                }
                //---

                Int32 rpta = 0;
                Usuarios objEUser = new Usuarios();
                objEUser.User_Id = User_Id;
                rpta = objNegUsers.DeleteUsers(objEUser);
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

                String User_Id = hdfUserID.Value;
                Usuarios objEUsu = new Usuarios();
                objEUsu.User_Id = User_Id;
                DataTable dt = new DataTable();
                dt = objNegUsers.ListaUserxId(objEUsu);

                lblUserId.Text = User_Id;
                cboPlanilla.SelectedValue = dt.Rows[0]["Planilla_Id"].ToString();
                cboLocalidad.SelectedValue = dt.Rows[0]["Area_Id"].ToString();
                cboArea.SelectedValue = dt.Rows[0]["Categoria_Auxiliar_Id"].ToString();
                ListaCatAuxiliar2(cboArea.SelectedValue);
                cboSeccion.SelectedValue = dt.Rows[0]["Categoria_Auxiliar2_Id"].ToString();
                ListaPersonal(cboPlanilla.SelectedValue, cboLocalidad.SelectedValue, cboArea.SelectedValue, cboSeccion.SelectedValue);
                cboPersonal.SelectedValue = dt.Rows[0]["Personal_Id"].ToString();

                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtUsuario.Text = dt.Rows[0]["User_Name"].ToString();
                txtPassword.Text = dt.Rows[0]["Password"].ToString();
                txtConfirmPassword.Text = dt.Rows[0]["Password"].ToString();

                cboPermiso.SelectedValue = dt.Rows[0]["Permiso_Id"].ToString();
                txtFechaIngreso.Text = dt.Rows[0]["Fecha_Ingreso"].ToString();

                if (dt.Rows[0]["Ruta_Foto"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    imgFoto.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    imgFoto.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    String PathImgUsuario = Parametros.I_FileServer_RutaImgUsers;
                    imgFoto.ImageUrl = PathImgUsuario + dt.Rows[0]["Ruta_Foto"].ToString();
                }

                btnGrabar.Visible = false;
                btnUpdate.Visible = true;
                Bloquear();
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

            Int32 TipoBusqueda = Convert.ToInt32(strFiltros[0].ToString());
            String ValorOpcional = strFiltros[1].ToString();

            BUSUsuarios objNegUsers = new BUSUsuarios();
            List<Usuarios> oLista = new List<Usuarios>();
            oLista = objNegUsers.GetUsuariosxFiltro(TipoBusqueda, ValorOpcional);

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oLista.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Usuarios> orderedRecords = null;
            if (pSortColumn == "User_Id") orderedRecords = oLista.OrderBy(col => col.User_Id);
            else if (pSortColumn == "Nombre_Completo") orderedRecords = oLista.OrderBy(col => col.Nombre_Completo);
            else if (pSortColumn == "User_Name") orderedRecords = oLista.OrderBy(col => col.User_Name);
            else if (pSortColumn == "Email") orderedRecords = oLista.OrderBy(col => col.Email);
            else if (pSortColumn == "Localidad") orderedRecords = oLista.OrderBy(col => col.Localidad);
            else if (pSortColumn == "Area") orderedRecords = oLista.OrderBy(col => col.Area);
            else if (pSortColumn == "Seccion") orderedRecords = oLista.OrderBy(col => col.Seccion);
            else if (pSortColumn == "nu_ingresos") orderedRecords = oLista.OrderBy(col => col.nu_ingresos);

            IEnumerable<Usuarios> sortedRecords;
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
            foreach (Usuarios obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.User_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.User_Id + "&#39;)'>",
                    User_Id = obj.User_Id,
                    Nombre_Completo = obj.Nombre_Completo,
                    User_Name = obj.User_Name,
                    Email = obj.Email,
                    Localidad = obj.Localidad,
                    Area = obj.Area,
                    Seccion = obj.Seccion,
                    nu_ingresos = obj.nu_ingresos
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