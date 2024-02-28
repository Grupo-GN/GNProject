using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class AsignaConceptos : System.Web.UI.Page
    {
        //string cx = ConfigurationManager.ConnectionStrings["CF"].ConnectionString;
        string cx = Presistence.Customs.Conexion.getConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Listar Tipo Proceso
                ListarTipoProceso();
                ListarBoletaColumna();

                string tp = Convert.ToString(Request.QueryString["tp"]);
                string bc = Convert.ToString(Request.QueryString["bc"]);

                if (tp != null)
                {
                    //cmbTipoProceso.SelectedValue = tp.ToString();
                    cmbTipoProceso.Items.FindByValue(tp).Selected = true;
                    cmbBoletaColumna.Items.FindByValue(bc).Selected = true;
                    MostrarGridView(cmbTipoProceso.SelectedValue, cmbBoletaColumna.SelectedValue);
                }
                else
                {
                    MostrarGridView(cmbTipoProceso.SelectedValue, cmbBoletaColumna.SelectedValue);
                }
            }
        }

        private void MostrarGridView(string proceso, string columna)
        {
            SqlConnection cnx;
            DataTable dt = new DataTable();

            cnx = new SqlConnection(cx);
            cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_ListaConceptoxProcesoColumna", cnx);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Boleta_Proceso", SqlDbType.VarChar).Value = proceso;
            da.SelectCommand.Parameters.Add("@Boleta_Columna", SqlDbType.VarChar).Value = columna;
            //ds = new DataSet();
            da.Fill(dt);

            gvConceptos.DataSource = dt;
            gvConceptos.DataBind();

            for (int j = 0; j < gvConceptos.Rows.Count; j++)
            {
                CheckBox chkQuintaCat = (CheckBox)gvConceptos.Rows[j].FindControl("chkquintacategoria");
                CheckBox chkONP = (CheckBox)gvConceptos.Rows[j].FindControl("chkonp");
                CheckBox chkAFP = (CheckBox)gvConceptos.Rows[j].FindControl("chkafp");
                CheckBox chkEsSalud = (CheckBox)gvConceptos.Rows[j].FindControl("chkessalud");
                CheckBox chkAfectoPromedio5ta = (CheckBox)gvConceptos.Rows[j].FindControl("chkAfectoPromedio");

                String estado_gvQC = dt.Rows[j][8].ToString();
                String estado_gvONP = dt.Rows[j][9].ToString();
                String estado_gvAFP = dt.Rows[j][10].ToString();
                String estado_gvEsSalud = dt.Rows[j][11].ToString();
                String estado_gvAfectoProm5ta = dt.Rows[j][12].ToString();

                if (estado_gvQC == "1") { chkQuintaCat.Checked = true; }
                if (estado_gvONP == "1") { chkONP.Checked = true; }
                if (estado_gvAFP == "1") { chkAFP.Checked = true; }
                if (estado_gvEsSalud == "1") { chkEsSalud.Checked = true; }
                if (estado_gvAfectoProm5ta == "1") { chkAfectoPromedio5ta.Checked = true; }
            }
            cnx.Close();
        }

        //Listar Tipo Proceso
        private void ListarTipoProceso()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarTipoProcesos", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmbTipoProceso.DataSource = ds;
            cmbTipoProceso.DataTextField = "Proceso";                            // FieldName of Table in DataBase
            cmbTipoProceso.DataValueField = "Proceso_Id";
            cmbTipoProceso.DataBind();
            cnx.Close();
        }

        //Listar Boleta Columna
        private void ListarBoletaColumna()
        {
            SqlConnection cnx;
            cnx = new SqlConnection(cx);
            cnx.Open();

            SqlDataAdapter da = new SqlDataAdapter("ListarBoletaColumna", cnx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmbBoletaColumna.DataSource = ds;
            cmbBoletaColumna.DataTextField = "Descripcion";                            // FieldName of Table in DataBase
            cmbBoletaColumna.DataValueField = "Columna_Id";
            cmbBoletaColumna.DataBind();
            cnx.Close();

        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarGridView(cmbTipoProceso.SelectedValue, cmbBoletaColumna.SelectedValue);

        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < gvConceptos.Rows.Count; j++)
            {
                CheckBox chkQuintaCat = (CheckBox)gvConceptos.Rows[j].FindControl("chkquintacategoria");
                CheckBox chkONP = (CheckBox)gvConceptos.Rows[j].FindControl("chkonp");
                CheckBox chkAFP = (CheckBox)gvConceptos.Rows[j].FindControl("chkafp");
                CheckBox chkEsSalud = (CheckBox)gvConceptos.Rows[j].FindControl("chkessalud");
                CheckBox chkAfectoProm5ta = (CheckBox)gvConceptos.Rows[j].FindControl("chkAfectoPromedio");

                Label lblConceptoId = (Label)gvConceptos.Rows[j].FindControl("lblcodconcepto");

                string QuintaCategoria, ONP, AFP, EsSalud, AfectoProm5ta;

                if (chkQuintaCat.Checked == true) { QuintaCategoria = "1"; } else { QuintaCategoria = "0"; }
                if (chkONP.Checked == true) { ONP = "1"; } else { ONP = "0"; }
                if (chkAFP.Checked == true) { AFP = "1"; } else { AFP = "0"; }
                if (chkEsSalud.Checked == true) { EsSalud = "1"; } else { EsSalud = "0"; }
                if (chkAfectoProm5ta.Checked == true) { AfectoProm5ta = "1"; } else { AfectoProm5ta = "0"; }

                SqlConnection cnx;
                cnx = new SqlConnection(cx);
                cnx.Open();

                SqlCommand cmd = new SqlCommand("UPDATE_CONCEPTOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Concepto_Id", SqlDbType.VarChar).Value = lblConceptoId.Text.ToString();
                cmd.Parameters.Add("@QuintaCategoria", SqlDbType.Char).Value = QuintaCategoria.ToString();
                cmd.Parameters.Add("@ONP", SqlDbType.Char).Value = ONP.ToString();
                cmd.Parameters.Add("@AFP", SqlDbType.Char).Value = AFP.ToString();
                cmd.Parameters.Add("@EsSalud", SqlDbType.Char).Value = EsSalud.ToString();
                cmd.Parameters.Add("@AfectoPromQuintaCat", SqlDbType.Char).Value = AfectoProm5ta.ToString();
                cmd.ExecuteNonQuery();
                cnx.Close();

                //Response.Write(chkQuintaCat + "<br>");
            }

            //foreach (GridViewRow item in gvConceptos.Rows)
            //{
            //    CheckBox chk = (CheckBox)item.FindControl("chkquintacategoria");
            //    if (chk != null)
            //    {
            //        if (chk.Checked)
            //        {
            //            // process selected record
            //            Response.Write(item.Cells[1].Text + "<br>");
            //        }
            //    }
            //}
        }

        private void MostrarGridViewDatosFijos()
        {
            SqlConnection cnx;
            DataTable dt = new DataTable();

            cnx = new SqlConnection(cx);
            cnx.Open();
            SqlDataAdapter da = new SqlDataAdapter("ListarConceptosDatosFijos", cnx);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            gvDatosFijos.DataSource = dt;
            gvDatosFijos.DataBind();

            for (int j = 0; j < gvDatosFijos.Rows.Count; j++)
            {
                CheckBox chkDatosFijos = (CheckBox)gvDatosFijos.Rows[j].FindControl("chkDatosFijos");

                String estado_gvDF = dt.Rows[j][2].ToString();

                if (estado_gvDF == "1") { chkDatosFijos.Checked = true; }

            }
            cnx.Close();
        }

        protected void chkDatosFijos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDatosFijos.Checked == true)
            {
                gvConceptos.DataSource = null;
                gvConceptos.DataBind();
                gvConceptos.Visible = false;
                cmbBoletaColumna.Enabled = false;
                cmbTipoProceso.Enabled = false;
                btnMostrar.Enabled = false;
                btnGrabar.Visible = false;

                gvDatosFijos.Visible = true;
                MostrarGridViewDatosFijos();
                btnGrabarDatosFijos.Visible = true;
            }
            else
            {
                gvDatosFijos.DataSource = null;
                gvDatosFijos.DataBind();
                gvDatosFijos.Visible = false;

                gvConceptos.Visible = true;
                MostrarGridView(cmbTipoProceso.SelectedValue, cmbBoletaColumna.SelectedValue);
                cmbBoletaColumna.Enabled = true;
                cmbTipoProceso.Enabled = true;
                btnMostrar.Enabled = true;
                btnGrabar.Visible = true;

                btnGrabarDatosFijos.Visible = false;
            }
        }

        protected void btnGrabarDatosFijos_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < gvDatosFijos.Rows.Count; j++)
            {
                CheckBox chkDatosFijos = (CheckBox)gvDatosFijos.Rows[j].FindControl("chkDatosFijos");

                Label lblConceptoId2 = (Label)gvDatosFijos.Rows[j].FindControl("lblConceptoId");

                string DatosFijos;

                if (chkDatosFijos.Checked == true) { DatosFijos = "1"; } else { DatosFijos = "0"; }

                SqlConnection cnx;
                cnx = new SqlConnection(cx);
                cnx.Open();

                SqlCommand cmd = new SqlCommand("UPDATE_CONCEPTOS_DATOSFIJOS", cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Concepto_Id", SqlDbType.VarChar).Value = lblConceptoId2.Text.ToString();
                cmd.Parameters.Add("@DatosFijosProyectar", SqlDbType.Char).Value = DatosFijos.ToString();
                cmd.ExecuteNonQuery();
                cnx.Close();

                //Response.Write(chkQuintaCat + "<br>");
            }
        }

        protected void gvConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblConceptoId = (Label)gvConceptos.SelectedRow.FindControl("lblcodconcepto");

            TextBox1.Text = gvConceptos.SelectedRow.Cells[2].Text;
            //TextBox1.Text = lblConceptoId.Text.ToString();
            string vtn = "window.open('UpdatePlame.aspx?cod=" + lblConceptoId.Text.ToString() + "&cod2=" + TextBox1.Text + "&tp=" + cmbTipoProceso.SelectedValue + "&bc=" + cmbBoletaColumna.SelectedValue + "','Signación Plame','top=250,left=300,scrollbars=no,resizable=no,height=230,width=870,directories=no,location=no,menubar=no,status=no,toolbar=no,addressbar=no')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", vtn, true);

            //string str;
            //str = "window.open('UpdatePlame.aspx?cod=" + TextBox1.Text + "','Titulo','top=250,left=150,width=550,height=250,directories=no,location=no,menubar=no,status=no,toolbar=no,scrollbars=no,resizable=no,addressbar=no')";
            //Response.Write("<script languaje=javascript>" + str + "</script>");
        }
    }
}