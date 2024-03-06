using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Presistence.Customs;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class RegistrarPermisos : System.Web.UI.Page
    {
        Conexion bl = new Conexion();
        //string cx = ConfigurationManager.ConnectionStrings["CF"].ConnectionString;
        string cx = Presistence.Customs.Conexion.getConexion();
        //SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion());


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ListarPlanilla();
                ListarArea();
                ListarLocalidad();
                ListarCategoria();

                string planilla = Convert.ToString(Request.QueryString["p"]);
                string area = Convert.ToString(Request.QueryString["a"]);
                string seccion = Convert.ToString(Request.QueryString["s"]);
                string localidad = Convert.ToString(Request.QueryString["l"]);
                string categoria = Convert.ToString(Request.QueryString["c"]);

                if (planilla != null)
                {
                    //cmbTipoProceso.SelectedValue = tp.ToString();
                    cboPlanilla.Items.FindByValue(planilla).Selected = true;
                    cboArea.Items.FindByValue(area).Selected = true;
                    ListarSeccionxArea();
                    cboSeccion.Items.FindByValue(seccion).Selected = true;
                    cboLocalidad.Items.FindByValue(localidad).Selected = true;
                    cboCategoria.Items.FindByValue(categoria).Selected = true;

                    ListarParaAsignacionJefes();
                    ListarParaAsignacionCoordinador();
                    ListarParaAsignacionGerentes();
                    ListarNivelAcceso();

                    MostrarPeriodo(cboPlanilla.SelectedValue);
                    MostrarPermisos();
                }


            }
        }

        private void MostrarPeriodo(string PlanillaId)
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("SP_PeriodoxPlanilla", cnx);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Planilla_Id", SqlDbType.Char).Value = PlanillaId.ToString();
            da.Fill(dt);
            lblPeriodo.Text = dt.Rows[0][1].ToString();
            lblPeriodoId.Text = dt.Rows[0][0].ToString();
            cnx.Close();
        }

        //Listar Planilla
        private void ListarPlanilla()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarPlanilla", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboPlanilla.DataSource = ds;
            cboPlanilla.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cboPlanilla.DataValueField = "Planilla_Id";
            cboPlanilla.DataBind();
            cboPlanilla.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        private void ListarArea()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarArea", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboArea.DataSource = ds;
            cboArea.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cboArea.DataValueField = "Categoria_Auxiliar_Id";
            cboArea.DataBind();
            cboArea.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        private void ListarSeccionxArea()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarSeccionxArea", cnx);
            DataSet ds = new DataSet();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Categoria_Auxiliar_id", SqlDbType.Char).Value = cboArea.SelectedValue;
            da.Fill(ds);

            cboSeccion.DataSource = ds;
            cboSeccion.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cboSeccion.DataValueField = "Categoria_Auxiliar2_Id";
            cboSeccion.DataBind();
            cboSeccion.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        private void ListarLocalidad()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarLocalidad", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboLocalidad.DataSource = ds;
            cboLocalidad.DataTextField = "descripcion";                            // FieldName of Table in DataBase
            cboLocalidad.DataValueField = "Area_id";
            cboLocalidad.DataBind();
            cboLocalidad.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        private void ListarCategoria()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarCategoria", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboCategoria.DataSource = ds;
            cboCategoria.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cboCategoria.DataValueField = "Categoria2_Id";
            cboCategoria.DataBind();
            cboCategoria.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        private void ListarParaAsignacionJefes()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_ListarAsignarJefe2", cnx);
            DataSet ds = new DataSet();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Planilla", SqlDbType.Char).Value = cboPlanilla.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion", SqlDbType.VarChar).Value = cboArea.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion2", SqlDbType.VarChar).Value = cboSeccion.SelectedValue;
            da.SelectCommand.Parameters.Add("@area_id", SqlDbType.VarChar).Value = cboLocalidad.SelectedValue;
            da.SelectCommand.Parameters.Add("@Categoria", SqlDbType.Char).Value = cboCategoria.SelectedValue;
            da.Fill(ds);

            /*llenar jefes*/
            cboAsigJefe.DataSource = ds;
            cboAsigJefe.DataTextField = "Personal";                            // FieldName of Table in DataBase
            cboAsigJefe.DataValueField = "Personal_Id";
            cboAsigJefe.DataBind();
            cboAsigJefe.Items.Insert(0, "-Seleccione-");

            cnx.Close();
        }

        private void ListarParaAsignacionCoordinador()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_ListarAsignarCoordinador2", cnx);
            DataSet ds = new DataSet();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Planilla", SqlDbType.Char).Value = cboPlanilla.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion", SqlDbType.VarChar).Value = cboArea.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion2", SqlDbType.VarChar).Value = cboSeccion.SelectedValue;
            da.SelectCommand.Parameters.Add("@area_id", SqlDbType.VarChar).Value = cboLocalidad.SelectedValue;
            da.SelectCommand.Parameters.Add("@Categoria", SqlDbType.Char).Value = cboCategoria.SelectedValue;
            da.Fill(ds);

            /*llenar cordinador*/
            cboAsigCoordinador.DataSource = ds;
            cboAsigCoordinador.DataTextField = "Personal";                            // FieldName of Table in DataBase
            cboAsigCoordinador.DataValueField = "Personal_Id";
            cboAsigCoordinador.DataBind();
            cboAsigCoordinador.Items.Insert(0, "-Seleccione-");

            cnx.Close();
        }

        private void ListarParaAsignacionGerentes()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_ListarAsignarGerente2", cnx);
            DataSet ds = new DataSet();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Planilla", SqlDbType.Char).Value = cboPlanilla.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion", SqlDbType.VarChar).Value = cboArea.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion2", SqlDbType.VarChar).Value = cboSeccion.SelectedValue;
            da.SelectCommand.Parameters.Add("@area_id", SqlDbType.VarChar).Value = cboLocalidad.SelectedValue;
            da.SelectCommand.Parameters.Add("@Categoria", SqlDbType.Char).Value = cboCategoria.SelectedValue;
            da.Fill(ds);

            /*llenar gerente*/
            cboAsigGerente.DataSource = ds;
            cboAsigGerente.DataTextField = "Personal";                            // FieldName of Table in DataBase
            cboAsigGerente.DataValueField = "Personal_Id";
            cboAsigGerente.DataBind();
            cboAsigGerente.Items.Insert(0, "-Seleccione-");

            cnx.Close();
        }

        private void ListarNivelAcceso()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarNivelAcceso", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cboNivelAcceso.DataSource = ds;
            cboNivelAcceso.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cboNivelAcceso.DataValueField = "NivelAcceso_Id";
            cboNivelAcceso.DataBind();
            cboNivelAcceso.Items.Insert(0, "-Seleccione-");
            cnx.Close();
        }

        protected void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArea.SelectedValue == "99")
            {
                cboSeccion.Items.Clear();
                cboSeccion.Enabled = false;
            }
            else
            {
                cboSeccion.Enabled = true;
                ListarSeccionxArea();
                lblerror.Visible = false;
            }

        }

        private void MostrarPermisos()
        {
            SqlConnection cnx;
            DataTable dt = new DataTable();

            cnx = new SqlConnection(cx);
            cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("MostrarPermisos", cnx);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Planilla", SqlDbType.Char).Value = cboPlanilla.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion", SqlDbType.VarChar).Value = cboArea.SelectedValue;
            da.SelectCommand.Parameters.Add("@seccion2", SqlDbType.VarChar).Value = cboSeccion.SelectedValue;
            da.SelectCommand.Parameters.Add("@area_id", SqlDbType.VarChar).Value = cboLocalidad.SelectedValue;
            da.SelectCommand.Parameters.Add("@Categoria", SqlDbType.Char).Value = cboCategoria.SelectedValue;
            da.SelectCommand.Parameters.Add("@Periodo_Id", SqlDbType.Char).Value = lblPeriodoId.Text;
            //ds = new DataSet();
            da.Fill(dt);

            gvMostrarPermisos.DataSource = dt;
            gvMostrarPermisos.DataBind();
        }

        protected void btnVerPersonal_Click(object sender, EventArgs e)
        {
            if (cboPlanilla.SelectedIndex == 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione Planilla";
            }
            else if (cboArea.SelectedIndex == 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione Area";
            }
            else if (cboSeccion.SelectedIndex == 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione Sección";
            }
            else if (cboLocalidad.SelectedIndex == 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione Localidad";
            }
            else if (cboCategoria.SelectedIndex == 0)
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione Categoria";
            }
            else
            {
                lblerror.Visible = false;
                ListarParaAsignacionJefes();
                ListarParaAsignacionCoordinador();
                ListarParaAsignacionGerentes();
                ListarNivelAcceso();
                MostrarPermisos();
            }

        }

        protected void cboPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            MostrarPeriodo(cboPlanilla.SelectedValue);
        }

        protected void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void cboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void cboNivelAcceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblerror.Visible = false;
        }

        protected void gvMostrarPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblPersonalId = (Label)gvMostrarPermisos.SelectedRow.FindControl("lblPersonalId");

            string usuario, clave, nivelacceso;

            usuario = gvMostrarPermisos.SelectedRow.Cells[7].Text;
            clave = gvMostrarPermisos.SelectedRow.Cells[8].Text;
            nivelacceso = gvMostrarPermisos.SelectedRow.Cells[9].Text;

            //TextBox1.Text = lblConceptoId.Text.ToString();
            string vtn = "window.open('UpdatePermisos.aspx?cod=" + lblPersonalId.Text.ToString() + "&p=" + cboPlanilla.SelectedValue + "&a=" + cboArea.SelectedValue + "&s=" + cboSeccion.SelectedValue + "&l=" + cboLocalidad.SelectedValue + "&c=" + cboCategoria.SelectedValue + "','Permisos','top=250,left=350,scrollbars=no,resizable=no,height=270,width=700,directories=no,location=no,menubar=no,status=no,toolbar=no,addressbar=no')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);

        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            int Seleccion = 0;

            for (int j = 0; j < gvMostrarPermisos.Rows.Count; j++)
            {
                CheckBox chkSeleccionar = (CheckBox)gvMostrarPermisos.Rows[j].FindControl("chkSeleccion");

                Label lblPersonalId = (Label)gvMostrarPermisos.Rows[j].FindControl("lblPersonalId");

                if (chkSeleccionar.Checked == true)
                {
                    lblerrorSeleccion.Visible = false;
                    //Seleccion = "1";




                    if ((cboAsigGerente.SelectedValue == "-Seleccione-") || (cboAsigJefe.SelectedValue == "-Seleccione-") || (cboAsigCoordinador.SelectedValue == "-Seleccione-"))
                    {
                        lblerrorSeleccion.Visible = true;
                        lblerrorSeleccion.Text = "Debe Asignar un Jefe, Coordinador o Gerente";
                    }
                    else
                    {
                        lblerrorSeleccion.Visible = false;
                        SqlConnection cnx;
                        cnx = new SqlConnection(cx);
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand("UpdateInsertAsigJefesGerenteCoordinador", cnx);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Gerente_Id", SqlDbType.Char).Value = cboAsigGerente.SelectedValue;
                        cmd.Parameters.Add("@Jefe_Id", SqlDbType.Char).Value = cboAsigJefe.SelectedValue;
                        cmd.Parameters.Add("@Personal_Id", SqlDbType.Char).Value = lblPersonalId.Text.ToString();
                        cmd.Parameters.Add("@Coordinador_Id", SqlDbType.Char).Value = cboAsigCoordinador.SelectedValue;
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                    }

                }
                else
                {
                    Seleccion = Seleccion + 1;
                }
            }

            if (gvMostrarPermisos.Rows.Count == Seleccion)
            {
                lblerrorSeleccion.Visible = true;
                lblerrorSeleccion.Text = "Debe Seleccionar 1 o más Personal";
            }

            MostrarPermisos();
        }

        private void MostrarPermisosInactivos()
        {
            SqlConnection cnx;
            DataTable dt = new DataTable();

            cnx = new SqlConnection(cx);
            cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("MostrarPermisosInactivos", cnx);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            gvMostrarCesados.DataSource = dt;
            gvMostrarCesados.DataBind();
            cnx.Close();
        }


        protected void chkCesados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCesados.Checked == true)
            {
                lblPeriodo.Enabled = false;
                cboPlanilla.Enabled = false;
                cboArea.Enabled = false;
                cboSeccion.Enabled = false;
                cboLocalidad.Enabled = false;
                cboCategoria.Enabled = false;
                btnVerPersonal.Enabled = false;
                cboAsigGerente.Enabled = false;
                cboAsigCoordinador.Enabled = false;
                cboAsigJefe.Enabled = false;
                cboNivelAcceso.Enabled = false;
                btnAsignar.Enabled = false;

                gvMostrarPermisos.DataSource = null;
                gvMostrarPermisos.DataBind();
                gvMostrarPermisos.Visible = false;

                gvMostrarCesados.Visible = true;
                MostrarPermisosInactivos();
            }
            else
            {
                if ((cboPlanilla.SelectedIndex > 0) && (cboArea.SelectedIndex > 0) && (cboSeccion.SelectedIndex > 0) && (cboLocalidad.SelectedIndex > 0) && (cboCategoria.SelectedIndex > 0))
                {
                    cboPlanilla.Enabled = true;
                    cboArea.Enabled = true;
                    cboSeccion.Enabled = true;
                    cboLocalidad.Enabled = true;
                    cboCategoria.Enabled = true;
                    btnVerPersonal.Enabled = true;
                    cboAsigGerente.Enabled = true;
                    cboAsigCoordinador.Enabled = true;
                    cboAsigJefe.Enabled = true;
                    cboNivelAcceso.Enabled = true;
                    btnAsignar.Enabled = true;

                    gvMostrarCesados.DataSource = null;
                    gvMostrarCesados.DataBind();
                    gvMostrarCesados.Visible = false;

                    lblPeriodo.Enabled = true;
                    //MostrarPeriodo(cboPlanilla.SelectedValue);
                    gvMostrarPermisos.Visible = true;
                    MostrarPermisos();
                }
                else
                {
                    cboPlanilla.Enabled = true;
                    cboArea.Enabled = true;
                    cboSeccion.Enabled = true;
                    cboLocalidad.Enabled = true;
                    cboCategoria.Enabled = true;
                    btnVerPersonal.Enabled = true;
                    cboAsigGerente.Enabled = true;
                    cboAsigCoordinador.Enabled = true;
                    cboAsigJefe.Enabled = true;
                    cboNivelAcceso.Enabled = true;
                    btnAsignar.Enabled = true;

                    gvMostrarCesados.DataSource = null;
                    gvMostrarCesados.DataBind();
                    gvMostrarCesados.Visible = false;

                    gvMostrarPermisos.Visible = true;
                }

            }
        }
    }
}