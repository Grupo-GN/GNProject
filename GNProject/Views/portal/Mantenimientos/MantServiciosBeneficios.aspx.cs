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
    public partial class MantServiciosBeneficios : System.Web.UI.Page
    {
        BUSBeneficios objNegBeneficio = new BUSBeneficios();
        BUSCategoria_Auxiliar objNegCatAux = new BUSCategoria_Auxiliar();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void Limpiar()
        {
            lblMensaje.Text = "";
            lblBeneficioId.Text = "";
            txtTitulo.Text = "";
            lblNomBeneficio.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            txtFecha.Text = (DateTime.Now.Date.ToShortDateString());

            btnGrabar.Visible = true;
            btnUpdate.Visible = false;

            FileUpload1.Visible = true;
            lblNomBeneficio.Visible = false;
            IbtnEliminarArchivo.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Archivo;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { Nombre_Archivo = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "BE", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaBeneficios, out Nombre_Archivo);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir Beneficio. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                Beneficios objEBeneficio = new Beneficios(txtTitulo.Text, txtDescripcion.Text, Nombre_Archivo, User_Name, Fecha);
                rpta = objNegBeneficio.InsertBeneficio(objEBeneficio);

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
            catch (Exception ex) { lblMensaje.Text = ex.Message; lblMensaje.ForeColor = System.Drawing.Color.Red; }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                String Beneficio_Id = lblBeneficioId.Text;
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Archivo;
                String msg_error;

                if (FileUpload1.Visible == false)
                {
                    Nombre_Archivo = lblNomBeneficio.Text;
                }
                else
                {
                    if (FileUpload1.FileName.ToString() == "")
                    { Nombre_Archivo = ""; }
                    else
                    {
                        msg_error = ClaseGlobal.UploadFile(FileUpload1, "BE", ClaseGlobal.TipoArchivo.Documentos, Parametros.I_FileServer_RutaBeneficios, out Nombre_Archivo);
                        if (msg_error != String.Empty)
                        {
                            lblMensaje.Text = "Error al subir Beneficio. " + msg_error;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                Beneficios objEBeneficio = new Beneficios(Beneficio_Id, txtTitulo.Text, txtDescripcion.Text, Nombre_Archivo, User_Name, Fecha);

                rpta = objNegBeneficio.UpdateBeneficio(objEBeneficio);
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
                String Nombre_Archivo = Parametros.I_FileServer_RutaBeneficios + lblNomBeneficio.Text;
                System.IO.File.Delete(Server.MapPath(Nombre_Archivo));

                Nombre_Archivo = "";

                String Beneficio_Id = lblBeneficioId.Text;
                Int32 rpta = 0;

                DateTime Fecha;
                Fecha = Convert.ToDateTime(txtFecha.Text);//DateTime.Now.Date;

                String User_Name = ClaseGlobal.Get_UserName(this);

                Beneficios objEBeneficio = new Beneficios(Beneficio_Id, txtTitulo.Text, txtDescripcion.Text, Nombre_Archivo, User_Name, Fecha);

                rpta = objNegBeneficio.UpdateBeneficio(objEBeneficio);
                if (rpta == 1)
                {
                    lblNomBeneficio.Text = "";
                    lblNomBeneficio.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                    FileUpload1.Visible = true;

                    lblMensaje.Text = "Se Elimino el Beneficio<br>Beneficio Actualizado Satisfactoriamente.";
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
                String Beneficio_Id = hdfID.Value;

                //Eliminar Archivo
                Beneficios objEDoc = new Beneficios();
                objEDoc.Beneficio_Id = Beneficio_Id;
                DataTable dt = new DataTable();
                dt = objNegBeneficio.ListaBeneficioxId(objEDoc);
                if (dt.Rows[0]["Nombre_Archivo"].ToString().Trim() != "")
                {
                    String Nombre_Archivo = Parametros.I_FileServer_RutaBeneficios + dt.Rows[0]["Nombre_Archivo"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Archivo));
                }
                //---

                Int32 rpta = 0;
                Beneficios objEBeneficio = new Beneficios();
                objEBeneficio.Beneficio_Id = Beneficio_Id;
                rpta = objNegBeneficio.DeleteBeneficio(objEBeneficio);
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

                String Beneficio_Id = hdfID.Value;
                Beneficios objEBeneficio = new Beneficios();
                objEBeneficio.Beneficio_Id = Beneficio_Id;
                DataTable dt = new DataTable();
                dt = objNegBeneficio.ListaBeneficioxId(objEBeneficio);

                lblBeneficioId.Text = Beneficio_Id;
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtFecha.Text = dt.Rows[0]["Fecha"].ToString();
                if (dt.Rows[0]["Nombre_Archivo"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomBeneficio.Visible = false;
                    IbtnEliminarArchivo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomBeneficio.Visible = true;
                    IbtnEliminarArchivo.Visible = true;
                    lblNomBeneficio.Text = dt.Rows[0]["Nombre_Archivo"].ToString();
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
            BUSBeneficios objNegBeneficios = new BUSBeneficios();
            List<Beneficios> oListaBeneficios = new List<Beneficios>();
            oListaBeneficios = objNegBeneficios.GetBeneficiosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaBeneficios.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Beneficios> orderedRecords = null;
            if (pSortColumn == "Beneficio_Id") orderedRecords = oListaBeneficios.OrderBy(col => col.Beneficio_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaBeneficios.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Descripcion") orderedRecords = oListaBeneficios.OrderBy(col => col.Descripcion);
            else if (pSortColumn == "User_Name") orderedRecords = oListaBeneficios.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaBeneficios.OrderBy(col => col.sFecha);

            IEnumerable<Beneficios> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaBeneficios.ToList();
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
            foreach (Beneficios obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                object filas = new
                {
                    Accion = "<img title='Editar' src='/Assets/images/imgPortal/img_buttons/icono_editar.png' width='15px' onclick='fn_Editar(&#39;" + obj.Beneficio_Id + "&#39;)'> <img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Beneficio_Id + "&#39;)'>",
                    Beneficio_Id = obj.Beneficio_Id,
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