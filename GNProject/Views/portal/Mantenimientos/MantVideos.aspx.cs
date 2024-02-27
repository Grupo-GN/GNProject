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
    public partial class MantVideos : System.Web.UI.Page
    {
        BUSVideos objNegVideo = new BUSVideos();
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
            lblVideoId.Text = "";
            txtTitulo.Text = "";
            lblNomVideo.Text = "";
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

            btnGrabar.Visible = true;

            FileUpload1.Visible = true;
            lblNomVideo.Visible = false;
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 rpta = 0;

                String User_Name = ClaseGlobal.Get_UserName(this);

                String Nombre_Video;
                String msg_error;
                if (FileUpload1.FileName.ToString() == "")
                { Nombre_Video = ""; }
                else
                {
                    msg_error = ClaseGlobal.UploadFile(FileUpload1, "VI", ClaseGlobal.TipoArchivo.Videos, Parametros.I_FileServer_RutaVideos, out Nombre_Video);
                    if (msg_error != String.Empty)
                    {
                        lblMensaje.Text = "Error al subir Video. " + msg_error;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                rpta = objNegVideo.InsertVideos(txtTitulo.Text.Trim(), Nombre_Video, User_Name);

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

        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Int32 Video_Id = Convert.ToInt32(hdfID.Value);

                //Eliminar Archivo            
                DataTable dt = new DataTable();
                dt = objNegVideo.ListVideosxId(Video_Id);
                if (dt.Rows[0]["Nombre_Video"].ToString().Trim() != "")
                {
                    String Nombre_Video = Parametros.I_FileServer_RutaVideos + dt.Rows[0]["Nombre_Video"].ToString();
                    System.IO.File.Delete(Server.MapPath(Nombre_Video));
                }
                //---

                Int32 rpta = 0;
                rpta = objNegVideo.DeleteVideos(Video_Id);
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

                Int32 Video_Id = Convert.ToInt32(hdfID.Value);
                DataTable dt = new DataTable();
                dt = objNegVideo.ListVideosxId(Video_Id);

                lblVideoId.Text = Video_Id.ToString();
                txtTitulo.Text = dt.Rows[0]["Titulo"].ToString();
                if (dt.Rows[0]["Nombre_Video"].ToString().Trim() == "")
                {
                    FileUpload1.Visible = true;
                    lblNomVideo.Visible = false;
                }
                else
                {
                    FileUpload1.Visible = false;
                    lblNomVideo.Visible = true;
                    lblNomVideo.Text = dt.Rows[0]["Nombre_Video"].ToString();
                }

                btnGrabar.Visible = false;
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
            BUSVideos objNegVideos = new BUSVideos();
            List<Videos> oListaVideos = new List<Videos>();
            oListaVideos = objNegVideos.GetVideosAll();

            //--- setup calculations
            int pageIndex = pCurrentPage == null ? 1 : pCurrentPage; //--- current page
            int pageSize = pPageSize == null ? 10 : pPageSize; //--- number of rows to show per page
            int totalRecords = oListaVideos.Count; //--- number of total items from query
            int totalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize); //--- number of pages

            //--- filter dataset for paging and sorting
            IOrderedEnumerable<Videos> orderedRecords = null;
            if (pSortColumn == "Video_Id") orderedRecords = oListaVideos.OrderBy(col => col.Video_Id);
            else if (pSortColumn == "Titulo") orderedRecords = oListaVideos.OrderBy(col => col.Titulo);
            else if (pSortColumn == "Nombre_Video") orderedRecords = oListaVideos.OrderBy(col => col.Nombre_Video);
            else if (pSortColumn == "User_Name") orderedRecords = oListaVideos.OrderBy(col => col.User_Name);
            else if (pSortColumn == "sFecha") orderedRecords = oListaVideos.OrderBy(col => col.sFecha);

            IEnumerable<Videos> sortedRecords;
            if (pSortColumn == "0") sortedRecords = oListaVideos.ToList();
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
            foreach (Videos obj in sortedRecords)
            {
                oJQGridJsonResponseRow = new JQGridJsonResponseRow();
                oJQGridJsonResponseRow.ID = (i + 1).ToString();
                String enlace_video = "<a class='link' target='_blank' href={0}{1}>{2}</a>";
                object filas = new
                {
                    Accion = "<img title='Eliminar' src='/Assets/images/imgPortal/img_buttons/icono_cerrar.png' width='15px' onclick='fn_Eliminar(&#39;" + obj.Video_Id + "&#39;)'>",
                    Video_Id = obj.Video_Id,
                    Titulo = obj.Titulo,
                    Nombre_Video = String.Format(enlace_video, Parametros.I_VirtualServer_Videos, obj.Nombre_Video.Replace(" ", "%20"), obj.Nombre_Video),
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