using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Contrato_RRHH
{
    public partial class FrmArchivoContratos : System.Web.UI.Page
    {
        BUSPersonal objNegPersonal = new BUSPersonal();
        private void MasterUcFiltros_PeriodoChangedEvent(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            llenatree();
            treContratos.Visible = true;
            VER.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!Page.IsPostBack)
            {
                //  Filtros();

                llenatree();
                treContratos.Visible = true;
                VER.Visible = false;
            }
        }

        void llenatree()
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;

            //treContratos.Nodes.Clear();
            if ((Utils.fc_obtiene_Planilla_Id_Nombre(this)) != "-Seleccione-")
            {
                TreeNode node = new TreeNode("<font color=black>" + Utils.fc_obtiene_Planilla_Id_Nombre(this) + "</font>", Utils.fc_obtiene_Planilla_Id(this));
                //node.Text = Utils.fc_obtiene_Planilla_Id_Nombre(this);
                //node.Value = Utils.fc_obtiene_Planilla_Id(this);
                node.Target = "";
                node.Expanded = true;
                treContratos.Nodes.Add(node);
                //Llenando las localidades

                DataTable dt = new DataTable();

                dt = objNegPersonal.ListaArea();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeNode childLocalidad = new TreeNode("<font color=black> " + dt.Rows[i][1].ToString() + "</font>", dt.Rows[i][0].ToString());
                    //childLocalidad.Text = dt.Rows[i][1].ToString();
                    //childLocalidad.Value = dt.Rows[i][0].ToString();
                    childLocalidad.Target = "";
                    node.ChildNodes.Add(childLocalidad);
                    //Llenando los empleados por localidad

                    DataTable dt2 = new DataTable();

                    dt2 = objNegPersonal.ListaPersonalActivo_Con_WPP(dt.Rows[i][0].ToString(), Utils.fc_obtiene_Planilla_Id(this), Utils.fc_obtiene_Periodo_Id(this));

                    for (int y = 0; y < dt2.Rows.Count; y++)
                    {
                        TreeNode childEmpleados = new TreeNode("<font color=blue>" + dt2.Rows[y][2].ToString() + "</font>", dt2.Rows[y][0].ToString());
                        //childEmpleados.Text = dt2.Rows[y][2].ToString();
                        //childEmpleados.Value = dt2.Rows[y][0].ToString();
                        childEmpleados.Target = "";
                        childLocalidad.ChildNodes.Add(childEmpleados);
                    }
                    childLocalidad.Expanded = false;
                }

            }
        }


        protected void treContratos_SelectedNodeChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            string val = treContratos.SelectedNode.Value.ToString();
            if (val.Length == 6) //Personal_Id
            {
                lblpersonal.Text = treContratos.SelectedNode.Text;
                lblcodigo.Text = val;
                DataTable dt = new DataTable();
                dt = Log_Contratos.Lista_Empleados_Contratos(val);
                gvcontratos.DataSource = dt;
                gvcontratos.DataBind();
                FUpdf.Enabled = false;
                btnsubir.Enabled = false;
                VER.Visible = false;
                lblnombrepdf.Text = "";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "mostrardiv();", true);
                contdoc.Visible = true;
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "cerrardiv();", true);
                contdoc.Visible = false;
            }

        }

        void fc_DisplayAlert(Page c, string Msj)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            Msj = Msj.Replace("\'", "\\'");
            Msj = Msj.Replace("\r", "\\r");
            Msj = Msj.Replace("\n", "\\n");
            string ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + Msj + "');</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertRpta", ScriptAlertRpta, false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "mostrardiv();", true);
            contdoc.Visible = true;
        }

        public String fechSplit(string cad)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            cad.Trim();
            string[] ret = cad.Split('/');
            cad = "";
            for (int i = 0; i < ret.Count(); i++)
            {
                cad += ret[i].ToString() + "-";
            }
            cad = cad.Remove(cad.Length - 1);
            return cad;
        }

        protected void btnsubir_Click(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                if (FUpdf.FileName == "")
                {
                    fc_DisplayAlert(this, "Seleccione un archivo pdf");
                    return;

                }
                else
                {
                    if ((archivosel.Text.Trim()) != "")
                    {
                        string ext;
                        ext = FUpdf.FileName.Substring(FUpdf.FileName.Length - 3, 3);
                        if (ext.ToLower() != "pdf")
                        {
                            fc_DisplayAlert(this, "Seleccione solo Archivos .pdf");
                            return;
                        }
                        string namefile = "";
                        namefile = FUpdf.FileName;
                        namefile = namefile.Substring(namefile.Length - 5, 5);
                        if (gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[4].Text == "Existe")
                        {


                            //File.Delete(Server.MapPath("Contratos/") + namefile);
                            File.Delete(Server.MapPath("Contratos/") + archivosel.Text.Trim() + ".pdf");
                            FUpdf.SaveAs(Server.MapPath("Contratos/") + namefile);
                            //  File.Copy(namefile, archivosel.Text.Trim() + ".pdf");
                            File.Copy(Server.MapPath("Contratos/") + namefile, Server.MapPath("Contratos/") + archivosel.Text.Trim() + ".pdf");
                            //   File.Delete(Server.MapPath(namefile));
                            File.Delete(Server.MapPath("Contratos/") + namefile);
                            //Computer.FileSystem.RenameFile(Server.MapPath("Contratos/") + namefile, (archivosel.Text + ".pdf"));

                            fc_DisplayAlert(this, "Archivo Modificado correctamente");
                        }
                        else
                        {
                            FUpdf.SaveAs(Server.MapPath("Contratos/") + namefile);
                            File.Copy(Server.MapPath("Contratos/") + namefile, Server.MapPath("Contratos/") + archivosel.Text.Trim() + ".pdf");
                            File.Delete(Server.MapPath("Contratos/") + namefile);
                            fc_DisplayAlert(this, "Archivo Subido correctamente");
                        }

                        string val = lblcodigo.Text;
                        DataTable dt = new DataTable();
                        dt = Log_Contratos.Lista_Empleados_Contratos(val);
                        gvcontratos.DataSource = dt;
                        gvcontratos.DataBind();
                        lblnombrepdf.Text = "";
                        FUpdf.Enabled = false;
                        btnsubir.Enabled = false;
                        VER.Visible = false;

                    }
                    else
                    {
                        fc_DisplayAlert(this, "Seleccione un perido de contrato");
                        return;
                    }
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "mostrardiv();", true);
                contdoc.Visible = true;
            }

            catch

            { }

        }

        protected void gvcontratos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            String tipoContrato = HttpUtility.HtmlDecode(gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[3].Text); //Para que funcione con acento
            archivosel.Text = (lblcodigo.Text.Trim()) + "_" + (fechSplit(gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[0].Text)) + "_" + (fechSplit(gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[1].Text)) + "_" + (fechSplit(gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[2].Text)) + "_" + (tipoContrato);
            if (gvcontratos.Rows[gvcontratos.SelectedIndex].Cells[4].Text == "Existe")
            {
                lblnombrepdf.Text = archivosel.Text;
                VER.Visible = true;
                btnsubir.Text = "Cambiar";
                VER.NavigateUrl = "~/Contrato_RRHH/Contratos/" + lblnombrepdf.Text + ".pdf";
                VER.Visible = true;
            }
            else
            {
                lblnombrepdf.Text = "Sin Nombre";
                VER.Visible = false;
                btnsubir.Text = "Subir";
            }
            FUpdf.Enabled = true;
            btnsubir.Enabled = true;
            VER.Enabled = true;
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "mostrardiv();", true);
            contdoc.Visible = true;
        }
        protected void gvcontratos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            try
            {
                string archivoempleado;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    String tipoContrato = HttpUtility.HtmlDecode(e.Row.Cells[3].Text); //Para que funcione con acento
                    archivoempleado = (lblcodigo.Text.Trim()) + "_" + fechSplit(e.Row.Cells[0].Text) + "_" + fechSplit(e.Row.Cells[1].Text) + "_" + fechSplit(e.Row.Cells[2].Text) + "_" + tipoContrato;
                    if (File.Exists(Server.MapPath("Contratos/") + archivoempleado + ".pdf"))
                    { e.Row.Cells[4].Text = "Existe"; }

                    else
                    {
                        e.Row.Cells[4].Text = "No Existe";
                    }
                }
            }
            catch (Exception oe)
            {
                // MsgBox(oe.Message, MsgBoxStyle.Critical)
            }
        }
    }
}