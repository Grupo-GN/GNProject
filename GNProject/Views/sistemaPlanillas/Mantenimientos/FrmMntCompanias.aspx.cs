using CAPA_ENTIDAD;
using CAPA_LOGICO;
using GNProject.Acceso;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Mantenimientos
{
    public partial class FrmMntCompanias : System.Web.UI.Page
    {
        Ent_Provincias objEProvincia;
        Ent_Distritos objEDistrito;
        Ent_Compania objECompania;

        const String constNombreIMGLogoEmpresa = "LogoEmpresa.png";
        const String constNombreIMGFirma = "Firma.png";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                Carga_Tipos_Doc_Identidad();
                Carga_CIUU();
                Carga_Departamentos();
                Lista_Compania(txtCompaniaBuscar.Text);

                btnActualizar.Visible = false;
                TabContainer1.ActiveTabIndex = 0;

            }
        }

        void Carga_Tipos_Doc_Identidad()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Ent_TDoc_Identidad objTDoc_Identidad = new Ent_TDoc_Identidad();
            cboTipo_Documento.DataSource = Log_TDoc_Identidad.Lista_TDoc_Identidad(objTDoc_Identidad);
            cboTipo_Documento.DataTextField = "Descripcion";
            cboTipo_Documento.DataValueField = "Tipo_Doc_Id";
            cboTipo_Documento.DataBind();
        }

        void Carga_CIUU()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboCIIU.DataSource = Log_CIIU.Lista_CIIU();
            cboCIIU.DataTextField = "Descripcion";
            cboCIIU.DataValueField = "CIIU_Id";
            cboCIIU.DataBind();
        }

        void Carga_Departamentos()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cboDepartamento.DataSource = Log_Departamentos.Lista_Departamentos();
            cboDepartamento.DataTextField = "Descripcion";
            cboDepartamento.DataValueField = "Codigo";
            cboDepartamento.DataBind();
            cboDepartamento.Items.Insert(0, new ListItem("--Seleccione--"));
        }
        void Carga_Provincias(String Departamento_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEProvincia = new Ent_Provincias();
            objEProvincia.Sub_Filtro = Departamento_Id;
            cboProvincia.DataSource = Log_Provincias.Lista_Provincias(objEProvincia);
            cboProvincia.DataTextField = "Descripcion";
            cboProvincia.DataValueField = "Codigo";
            cboProvincia.DataBind();
            cboProvincia.Items.Insert(0, new ListItem("--Seleccione--"));
        }
        void Carga_Distritos(String Departamento_Id, String Provincia_Id)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            objEDistrito = new Ent_Distritos();
            objEDistrito.Sub_Filtro = Departamento_Id + Provincia_Id;
            cboDistrito.DataSource = Log_Distritos.Lista_Distritos(objEDistrito);
            cboDistrito.DataTextField = "Descripcion";
            cboDistrito.DataValueField = "Codigo";
            cboDistrito.DataBind();
            cboDistrito.Items.Insert(0, new ListItem("--Seleccione--"));
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Lista_Compania(txtCompaniaBuscar.Text);
        }

        void Lista_Compania(String no_Compania)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                objECompania = new Ent_Compania();
                if (no_Compania.Trim() != String.Empty)
                    objECompania.Descripcion = no_Compania;
                DataTable dtCompania = new DataTable();
                dtCompania = Log_Compania.Lista_Compania(objECompania);
                Utils.fc_Adecua_GridView(grvCompania, dtCompania.Rows.Count);
                grvCompania.DataSource = dtCompania;
                grvCompania.DataBind();
                dtCompania.Dispose();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void grvCompania_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            grvCompania.PageIndex = e.NewPageIndex;
            Lista_Compania(txtCompaniaBuscar.Text);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            LimpiarCajasTexto();
            TabContainer1.ActiveTabIndex = 1;
            txtDescripcion.Focus();
            btnActualizar.Visible = false;
            btnGrabar.Visible = true;
        }

        void LimpiarCajasTexto()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            lblCompania_Id.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtRUC.Text = String.Empty;
            txtReg_Patronal.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtRepresentante.Text = String.Empty;
            cboTipo_Documento.SelectedIndex = 0;
            txtNro_Doc.Text = String.Empty;
            txtArea_AFP.Text = String.Empty;
            txtTelf_Area_AFP.Text = String.Empty;
            cboDistrito.Items.Clear();
            cboProvincia.Items.Clear();
            cboDepartamento.SelectedIndex = 0;
            txtCod_tel_soles.Text = String.Empty;
            txtCod_tel_dolares.Text = String.Empty;
            txtNro_Libro.Text = String.Empty;
            txtNro_Partida.Text = String.Empty;
            cboCIIU.SelectedIndex = 0;
            ckCia_Default.Checked = false;
            #region "Tab - Configuración Correo"
            txtSMTP_Host.Text = String.Empty;
            txtSMTP_Port.Text = String.Empty;
            chkSMTP_SSL.Checked = false;
            txtSMTP_MailAddress.Text = String.Empty;
            txtSMTP_DisplayName.Text = String.Empty;
            txtSMTP_User.Text = String.Empty;
            txtSMTP_Pwd.Text = String.Empty;
            #endregion "Tab - Configuración Correo"
        }

        protected void grvCompania_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String Compania_Id = grvCompania.DataKeys[e.Row.RowIndex].Values["Compania_Id"].ToString();

                if (Compania_Id == "01")
                {
                    ImageButton imgSelect = (ImageButton)e.Row.FindControl("ibtnSelect");
                    imgSelect.Visible = true;
                }
            }
        }
        protected void grvCompania_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (e.CommandName == "Select")
            {
                try
                {
                    string Compania_Id;
                    string departamento_Id;
                    string provincia_Id;
                    string distrito_Id;

                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Compania_Id = grvCompania.DataKeys[row.RowIndex].Values["Compania_Id"].ToString();

                    LimpiarCajasTexto();

                    lblCompania_Id.Text = Compania_Id;

                    objECompania = new Ent_Compania();
                    objECompania.Compania_Id = Compania_Id;
                    DataTable dtCompania = new DataTable();
                    dtCompania = Log_Compania.Lista_Compania(objECompania);

                    departamento_Id = dtCompania.Rows[0]["Dpto"].ToString();
                    provincia_Id = dtCompania.Rows[0]["Prov"].ToString();
                    distrito_Id = dtCompania.Rows[0]["Dist"].ToString();

                    /*Carga Departamento*/
                    if (departamento_Id != String.Empty)
                    {
                        cboDepartamento.SelectedValue = departamento_Id;
                        /*Carga Provincia*/
                        if (cboDepartamento.SelectedIndex != 0 && provincia_Id != String.Empty)
                        {
                            Carga_Provincias(departamento_Id);
                            cboProvincia.SelectedValue = provincia_Id;
                            /*Carga Distrito*/
                            if (cboDepartamento.SelectedIndex != 0 && cboProvincia.SelectedIndex != 0 && distrito_Id != String.Empty)
                            {
                                Carga_Distritos(departamento_Id, provincia_Id);
                                cboDistrito.SelectedValue = distrito_Id;
                            }
                            else
                            {
                                Carga_Distritos(departamento_Id, provincia_Id);
                                cboDistrito.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            Carga_Provincias(departamento_Id);
                            cboProvincia.SelectedIndex = 0;
                        }
                    }
                    else
                        cboDepartamento.SelectedIndex = 0;

                    ckCia_Default.Checked = Convert.ToBoolean(dtCompania.Rows[0]["Cia_Default"]);
                    txtDescripcion.Text = dtCompania.Rows[0]["Descripcion"].ToString();
                    txtRUC.Text = dtCompania.Rows[0]["Ruc"].ToString();
                    txtReg_Patronal.Text = dtCompania.Rows[0]["Reg_Patronal"].ToString();
                    txtDireccion.Text = dtCompania.Rows[0]["Direccion"].ToString();
                    txtTelefono.Text = dtCompania.Rows[0]["Num_Telf"].ToString();
                    txtRepresentante.Text = dtCompania.Rows[0]["Representante"].ToString();
                    cboTipo_Documento.SelectedValue = dtCompania.Rows[0]["Tipo_DocIde"].ToString();
                    txtNro_Doc.Text = dtCompania.Rows[0]["Nro_DocIde"].ToString();
                    txtArea_AFP.Text = dtCompania.Rows[0]["Area_AFP"].ToString();
                    txtTelf_Area_AFP.Text = dtCompania.Rows[0]["Telf_Area_AFP"].ToString(); ;
                    txtCod_tel_soles.Text = dtCompania.Rows[0]["Codigo_tel_soles"].ToString();
                    txtCod_tel_dolares.Text = dtCompania.Rows[0]["Codigo_tel_dolares"].ToString();
                    txtNro_Libro.Text = dtCompania.Rows[0]["Nro_Libro"].ToString();
                    txtNro_Partida.Text = dtCompania.Rows[0]["Nro_Partida"].ToString();
                    cboCIIU.SelectedValue = dtCompania.Rows[0]["CIIU_Id"].ToString();

                    String virtualFolder = Parametros.VirtualServer_RutaEmpresa;
                    imgLogoEmpresa.ImageUrl = virtualFolder + constNombreIMGLogoEmpresa + "?" + DateTime.Now.ToString("yyMMddHHmmss");
                    imgFirmaEmpresa.ImageUrl = virtualFolder + constNombreIMGFirma + "?" + DateTime.Now.ToString("yyMMddHHmmss");

                    #region "Tab - Configuración Correo"
                    txtSMTP_Host.Text = dtCompania.Rows[0]["SMTP_Host"].ToString();
                    txtSMTP_Port.Text = dtCompania.Rows[0]["SMTP_Port"].ToString();
                    chkSMTP_SSL.Checked = Convert.ToBoolean(dtCompania.Rows[0]["SMTP_SSL"]);
                    txtSMTP_MailAddress.Text = dtCompania.Rows[0]["SMTP_Mail_Address"].ToString();
                    txtSMTP_DisplayName.Text = dtCompania.Rows[0]["SMTP_Display_Name"].ToString();
                    txtSMTP_User.Text = dtCompania.Rows[0]["SMTP_User"].ToString();
                    txtSMTP_Pwd.Text = dtCompania.Rows[0]["SMTP_Pwd"].ToString();
                    #endregion "Tab - Configuración Correo"

                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                    TabContainer1.ActiveTabIndex = 1;
                    txtDescripcion.Focus();
                }
                catch (Exception ex)
                {
                    Utils.fc_DisplayAlert(this, ex.Message);
                }
            }
        }
        protected void grvCompania_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string Compania_Id;
                Compania_Id = grvCompania.DataKeys[e.RowIndex].Values["Compania_Id"].ToString();
                objECompania = new Ent_Compania();
                objECompania.Compania_Id = Compania_Id;

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania.Elimina_Compania(objECompania);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    LimpiarCajasTexto();
                    btnActualizar.Visible = false;
                    Lista_Compania(txtCompaniaBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {

                objECompania = new Ent_Compania();
                objECompania.Descripcion = txtDescripcion.Text.ToUpper();
                objECompania.Direccion = txtDireccion.Text.ToUpper();
                objECompania.Representante = txtRepresentante.Text.ToUpper();
                objECompania.Ruc = txtRUC.Text;
                objECompania.Dpto = cboDepartamento.SelectedValue;
                objECompania.Prov = cboProvincia.SelectedValue;
                objECompania.Dist = cboDistrito.SelectedValue;
                objECompania.Codigo_tel_soles = txtCod_tel_soles.Text;
                objECompania.Codigo_tel_dolares = txtCod_tel_dolares.Text;
                //////objECompania.Cta_soles = 
                //////objECompania.Cta_dolares =
                objECompania.Path = FileUpload_RutaReportes.FileName.ToString();
                objECompania.Reg_Patronal = txtReg_Patronal.Text.ToUpper();
                objECompania.Num_Telf = txtTelefono.Text;
                //////objECompania.Tip_cta_Id = 
                objECompania.Tipo_DocIde = cboTipo_Documento.SelectedValue;
                objECompania.Nro_DocIde = txtNro_Doc.Text;
                objECompania.Area_AFP = txtArea_AFP.Text.ToUpper();
                objECompania.Telf_Area_AFP = txtTelf_Area_AFP.Text;
                objECompania.Nro_Libro = txtNro_Libro.Text;
                objECompania.Nro_Partida = txtNro_Partida.Text;
                objECompania.CIIU_Id = cboCIIU.SelectedValue;
                objECompania.Cia_Default = ckCia_Default.Checked;
                //////objECompania.Flag_Pool_Proceso =

                #region "Tab - Configuración Correo"
                objECompania.SMTP_Host = txtSMTP_Host.Text;
                objECompania.SMTP_Port = Convert.ToInt32(txtSMTP_Port.Text);
                objECompania.SMTP_SSL = chkSMTP_SSL.Checked;
                //objECompania.SMTP_Mail_Address = txtSMTP_MailAddress.Text;
                objECompania.SMTP_Mail_Address = txtSMTP_User.Text; //Se asigna mismo valor que usuario
                objECompania.SMTP_Display_Name = txtSMTP_DisplayName.Text;
                objECompania.SMTP_User = txtSMTP_User.Text;
                objECompania.SMTP_Clave = txtSMTP_Pwd.Text;
                #endregion "Tab - Configuración Correo"

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania.Inserta_Compania(objECompania);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    lblCompania_Id.Text = dtRpta.Rows[0][0].ToString();
                    Lista_Compania(txtCompaniaBuscar.Text);
                    btnGrabar.Visible = false;
                    btnActualizar.Visible = true;
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
                TabContainer1.ActiveTabIndex = 0;
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (lblCompania_Id.Text.Trim() == String.Empty)
            {
                Utils.fc_DisplayAlert(this, "Seleccionar Una Compañia.");
                TabContainer1.ActiveTabIndex = 0;
                return;
            }
            try
            {
                //20180822 GUARDAR LOGO
                Boolean fileOK = false;
                string FileRuta = "", FileFolder = "";
                FileFolder = Parametros.FileServer_RutaEmpresa;
                if (!Directory.Exists(FileFolder))
                {
                    Directory.CreateDirectory(FileFolder);
                }

                if (FileLogo.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileLogo.FileName).ToLower();
                    String[] allowedExtensions = { ".png" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }
                if (fileOK)
                {
                    File.Delete(FileFolder + constNombreIMGLogoEmpresa);
                    FileLogo.PostedFile.SaveAs(FileFolder + FileLogo.FileName);
                    FileRuta = FileFolder + FileLogo.FileName;
                    File.Move(FileRuta, FileFolder + constNombreIMGLogoEmpresa);
                }
                if (System.IO.File.Exists(FileFolder + constNombreIMGLogoEmpresa) == false)
                {
                    Utils.fc_DisplayAlert(this, "El Logo de la empresa no esta definido.");
                    return;
                }
                //20180822
                //20190724 GUARDAR FIRMA
                fileOK = false;
                FileRuta = "";
                FileFolder = "";
                FileFolder = Parametros.FileServer_RutaEmpresa;
                if (FileFirma.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileFirma.FileName).ToLower();
                    String[] allowedExtensions = { ".png" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            fileOK = true;
                        }
                    }
                }
                if (fileOK)
                {
                    File.Delete(FileFolder + constNombreIMGFirma);
                    FileFirma.PostedFile.SaveAs(FileFolder + FileFirma.FileName);
                    FileRuta = FileFolder + FileFirma.FileName;
                    File.Move(FileRuta, FileFolder + constNombreIMGFirma);
                }
                if (System.IO.File.Exists(FileFolder + constNombreIMGFirma) == false)
                {
                    Utils.fc_DisplayAlert(this, "La firma no está definida.");
                    return;
                }
                //20180822

                objECompania = new Ent_Compania();
                objECompania.Compania_Id = lblCompania_Id.Text;
                objECompania.Descripcion = txtDescripcion.Text.ToUpper();
                objECompania.Direccion = txtDireccion.Text.ToUpper();
                objECompania.Representante = txtRepresentante.Text.ToUpper();
                objECompania.Ruc = txtRUC.Text;
                objECompania.Dpto = cboDepartamento.SelectedValue;
                objECompania.Prov = cboProvincia.SelectedValue;
                objECompania.Dist = cboDistrito.SelectedValue;
                objECompania.Codigo_tel_soles = txtCod_tel_soles.Text;
                objECompania.Codigo_tel_dolares = txtCod_tel_dolares.Text;
                //////objECompania.Cta_soles = 
                //////objECompania.Cta_dolares =
                objECompania.Path = FileUpload_RutaReportes.FileName.ToString();
                objECompania.Reg_Patronal = txtReg_Patronal.Text.ToUpper();
                objECompania.Num_Telf = txtTelefono.Text;
                //////objECompania.Tip_cta_Id = 
                objECompania.Tipo_DocIde = cboTipo_Documento.SelectedValue;
                objECompania.Nro_DocIde = txtNro_Doc.Text;
                objECompania.Area_AFP = txtArea_AFP.Text.ToUpper();
                objECompania.Telf_Area_AFP = txtTelf_Area_AFP.Text;
                objECompania.Nro_Libro = txtNro_Libro.Text;
                objECompania.Nro_Partida = txtNro_Partida.Text;
                objECompania.CIIU_Id = cboCIIU.SelectedValue;
                objECompania.Cia_Default = ckCia_Default.Checked;
                //////objECompania.Flag_Pool_Proceso =
                if (System.IO.File.Exists(FileFolder + constNombreIMGLogoEmpresa))
                {
                    objECompania.LogoRuta = constNombreIMGLogoEmpresa;
                    objECompania.LogoImagen = File.ReadAllBytes(FileFolder + constNombreIMGLogoEmpresa);
                }
                if (System.IO.File.Exists(FileFolder + constNombreIMGFirma))
                {
                    objECompania.FirmaImagen = File.ReadAllBytes(FileFolder + constNombreIMGFirma);
                }

                #region "Tab - Configuración Correo"
                objECompania.SMTP_Host = txtSMTP_Host.Text;
                objECompania.SMTP_Port = Convert.ToInt32(txtSMTP_Port.Text);
                objECompania.SMTP_SSL = chkSMTP_SSL.Checked;
                //objECompania.SMTP_Mail_Address = txtSMTP_MailAddress.Text;
                objECompania.SMTP_Mail_Address = txtSMTP_User.Text; //Se asigna mismo valor que usuario
                objECompania.SMTP_Display_Name = txtSMTP_DisplayName.Text;
                objECompania.SMTP_User = txtSMTP_User.Text;
                objECompania.SMTP_Clave = txtSMTP_Pwd.Text;
                #endregion "Tab - Configuración Correo"

                DataTable dtRpta = new DataTable();
                dtRpta = Log_Compania.Actualiza_Compania(objECompania);

                string msj_rpta;
                msj_rpta = dtRpta.Rows[0][1].ToString();
                if (Convert.ToInt32(dtRpta.Rows[0][0].ToString()) > 0)
                {
                    String virtualFolder = Parametros.VirtualServer_RutaEmpresa;
                    imgLogoEmpresa.ImageUrl = virtualFolder + constNombreIMGLogoEmpresa + "?" + DateTime.Now.ToString("yyMMddHHmmss");

                    Image imgLogoMaster = (Image)this.Master.FindControl("imgLogoMaster");
                    imgLogoMaster.ImageUrl = virtualFolder + constNombreIMGLogoEmpresa + "?" + DateTime.Now.ToString("yyMMddHHmmss");

                    imgFirmaEmpresa.ImageUrl = virtualFolder + constNombreIMGFirma + "?" + DateTime.Now.ToString("yyMMddHHmmss");

                    Lista_Compania(txtCompaniaBuscar.Text);
                }
                dtRpta.Dispose();
                Utils.fc_DisplayAlert(this, msj_rpta);
                LimpiarCajasTexto();
                TabContainer1.ActiveTabIndex = 0;
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }


        protected void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (cboDepartamento.SelectedIndex != 0)
                    Carga_Provincias(cboDepartamento.SelectedValue);
                else
                    cboProvincia.Items.Clear();
                cboDistrito.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }
        protected void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (cboProvincia.SelectedIndex != 0)
                    Carga_Distritos(cboDepartamento.SelectedValue, cboProvincia.SelectedValue);
                else
                    cboDistrito.Items.Clear();
            }
            catch (Exception ex)
            {
                Utils.fc_DisplayAlert(this, ex.Message);
            }
        }

        protected void ibtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }
    }
}