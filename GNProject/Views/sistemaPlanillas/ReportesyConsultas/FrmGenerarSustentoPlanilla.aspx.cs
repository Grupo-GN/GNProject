using CAPA_ENTIDAD;
using CAPA_LOGICO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.ReportesyConsultas
{
    public partial class FrmGenerarSustentoPlanilla : System.Web.UI.Page
    {
        Ent_Reporte_Incidencias objE_RIncidencias;
        // Ent_Conceptos objEConceptos;
        Ent_Sustentos objESustentos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaGridSustentos();
            }
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-PE");
            string title = "Datos";
            DataTable dt = new DataTable();
            DataTable dtCal = new DataTable();
            objESustentos = new Ent_Sustentos();
            string TipoPlanilla = Utils.fc_obtiene_Planilla_Id_Nombre(this).ToString().Split(' ')[1];
            int cont = 0;
            CheckBox chk;
            for (Int32 y = 0; y <= grvSustentos.Rows.Count - 1; y++)
            {
                chk = (CheckBox)grvSustentos.Rows[y].Cells[2].FindControl("chkOK");
                if (chk.Checked.Equals(true))
                {
                    cont += 1;
                }
            }
            if (cont == 0)
            {
                lblerror.Text = "No seleccion ningun sustento";
                return;
            }
            else
            {
                lblerror.Text = "";
            }

            string periodo = Utils.fc_obtiene_Periodo_Id(this);
            string Plantilla_ID;
            ImageButton ibtn = new ImageButton();
            for (Int32 i = 0; i <= grvSustentos.Rows.Count - 1; i++)
            {
                ibtn = (ImageButton)grvSustentos.Rows[i].Cells[0].FindControl("IbtnSelect");
                Plantilla_ID = ibtn.CommandArgument.ToString();
                chk = (CheckBox)grvSustentos.Rows[i].Cells[2].FindControl("chkOK");
                if (chk.Checked.Equals(true))
                {
                    if (Plantilla_ID.Trim().Length <= 2)
                    {
                        objESustentos.PlantillaID = Plantilla_ID;
                        dtCal = Log_Sustentos.BuscarPlantillas(objESustentos);
                        title = objESustentos.ConceptoID = dtCal.Rows[0][1].ToString();

                        objESustentos.Planilla = Utils.fc_obtiene_Planilla_Id(this);
                        objESustentos.PeriodoId = Utils.fc_obtiene_Periodo_Id(this);
                        objESustentos.ConceptoID = dtCal.Rows[0][2].ToString();
                        objESustentos.ProcesoID = dtCal.Rows[0][3].ToString(); ;
                        objESustentos.CamposPerso = dtCal.Rows[0][4].ToString();
                        objESustentos.CamposConcep = dtCal.Rows[0][5].ToString();
                        objESustentos.DetalleConceptos = dtCal.Rows[0][6].ToString();
                        objESustentos.CantC = int.Parse(dtCal.Rows[0][7].ToString());
                        objESustentos.CantP = int.Parse(dtCal.Rows[0][8].ToString());
                        Log_Sustentos.SET_COMPATIBILITY_LEVEL(90);
                        dt = Log_Sustentos.GenerarCalculo(objESustentos);
                        Log_Sustentos.SET_COMPATIBILITY_LEVEL(80);
                        if (dt.Rows.Count != 0)
                        {
                            /*String[,] saRet5 = new String[dt.Rows.Count + 1, dt.Columns.Count];
                            for (Int32 iRow = 0; iRow < dt.Rows.Count; iRow++)
                            {
                                for (Int32 iCol = 0; iCol < dt.Columns.Count; iCol++)
                                {
                                    saRet5[0, iCol] = dt.Columns[iCol].ColumnName.ToString().Trim().ToUpper();
                                    saRet5[iRow + 1, iCol] = dt.Rows[iRow][iCol].ToString();

                                }
                            }
                            dt.Clear();*/
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            dt.Clear();
                        }

                    }
                    else if (Plantilla_ID == "0000")
                    {
                        title = "Planilla General";
                        dt = Llena_D_Fijos(periodo);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        title = "Planilla Vaciones";
                        dt = GeneraPlanilla(Plantilla_ID, periodo);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    if (GridView1.Rows.Count > 0)
                    {


                        /*Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";*/
                        StringBuilder sb = new StringBuilder();
                        StringWriter sw = new StringWriter(sb);
                        HtmlTextWriter htw = new HtmlTextWriter(sw);

                        Page page = new Page();
                        HtmlForm form = new HtmlForm();

                        GridView1.EnableViewState = false;
                        //To Export all pages
                        GridView1.AllowPaging = false;
                        //this.BindGrid();

                        GridView1.HeaderRow.BackColor = Color.White;
                        foreach (TableCell cell in GridView1.HeaderRow.Cells)
                        {
                            cell.BackColor = GridView1.HeaderStyle.BackColor;
                        }
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            row.BackColor = Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = GridView1.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }

                        string style = @"<style> .textmode {mso-number-format:\@;} </style>";
                        //// Deshabilitar la validación de eventos, sólo asp.net 2
                        page.EnableEventValidation = false;

                        //// Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
                        page.DesignerInitialize();
                        page.Controls.Add(form);
                        form.Controls.Add(GridView1);
                        page.RenderControl(htw);
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + title + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentEncoding = Encoding.Default;
                        Response.Write(style.ToString());
                        Response.Write(sb.ToString());
                        Response.End();

                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        DataTable GeneraPlanilla(string reporte, string periodo)
        {
            CAPA_DATOS.ControllerPlanillaGeneral pla = new CAPA_DATOS.ControllerPlanillaGeneral();
            return pla.Get_ExportacionPlanilas_General_Ms(reporte, "000583", periodo, "01", "%");
        }
        void LlenaGridSustentos()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("PlantillaSU_Id", typeof(string));
            dt2.Columns.Add("Nombre", typeof(string));
            string[,] Procesos = new string[,] { { "0001", "Planilla del Mes" },
                                            { "0009", "Planilla Vacaciones" },
                                            { "0010", "Gratificacion" }
                                            //,{"0000","Incidencias D_fijos"}
                                            
                                                };
            //,
            //{"0","Resumen Planilla"} };
            int cont = (Procesos.Length / 2);
            for (Int32 t = 0; t <= cont - 1; t++)
            {
                DataRow dr2 = dt2.NewRow();
                dr2["PlantillaSU_Id"] = Procesos[t, 0].ToString();
                dr2["Nombre"] = Procesos[t, 1].ToString();
                dt2.Rows.Add(dr2);
            }


            DataTable data = new DataTable();
            data = Log_Sustentos.ListPlantillas();

            for (Int32 i = 0; i <= data.Rows.Count - 1; i++)
            {
                DataRow dr4 = dt2.NewRow();
                dr4["PlantillaSU_Id"] = data.Rows[i][0];
                dr4["Nombre"] = data.Rows[i][1];
                dt2.Rows.Add(dr4);

            }
            grvSustentos.DataSource = dt2;
            grvSustentos.DataBind();
        }
        protected void IbtnSelect_Click(object sender, ImageClickEventArgs e)
        {
            string Plantilla_ID;
            ImageButton ibtn = new ImageButton();
            ibtn = (ImageButton)sender;
            Plantilla_ID = ibtn.CommandArgument.ToString();

            string FileStrean = "ModalDetallePlantilla.aspx";
            string Clientscript = "AbrirModal('" + FileStrean + "?Plantilla_ID=" + Plantilla_ID + "')";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "WOpen", Clientscript, true);
        }
        DataTable Llena_D_Fijos(string periodo)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt2.Columns.Add("Fecha", typeof(string));
            dt2.Columns.Add("Personal_ID", typeof(string));
            dt2.Columns.Add("Nombres-Apellidos", typeof(string));
            dt2.Columns.Add("Periodo", typeof(string));
            dt2.Columns.Add("Usuario", typeof(string));
            dt2.Columns.Add("Proceso", typeof(string));
            dt2.Columns.Add("concepto", typeof(string));
            dt2.Columns.Add("campo", typeof(string));
            dt2.Columns.Add("DatoHistorio", typeof(string));
            dt2.Columns.Add("DatoActual", typeof(string));
            objE_RIncidencias = new Ent_Reporte_Incidencias();
            Ent_Personal objEPersonal = new Ent_Personal();

            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            objE_RIncidencias.Tabla = "D_fijos";
            dt1 = Log_Reportes_Incidencias.Filtar_Personal(objE_RIncidencias);
            for (Int32 i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                objEPersonal._Personal_Id = dt1.Rows[i][0].ToString();
                dt = Log_Personal.Lista_Personal(objEPersonal);

                objE_RIncidencias.Periodo_Id = periodo;
                objE_RIncidencias.Personal_id = objEPersonal._Personal_Id;
                dt3 = Log_Reportes_Incidencias.Lista_Conceptos(objE_RIncidencias);
                for (Int32 x = 0; x <= dt3.Rows.Count - 1; x++)
                {
                    objE_RIncidencias.Concepto_Id = dt3.Rows[x][0].ToString();
                    dt4 = Log_Reportes_Incidencias.Lista_Incidencias_Personal_d_fijos(objE_RIncidencias);
                    if (dt4.Rows.Count != 0)
                    {
                        DataRow dr = dt2.NewRow();
                        dr["Fecha"] = dt4.Rows[0][0];
                        dr["Personal_ID"] = dt.Rows[0][0].ToString();
                        dr["Nombres-Apellidos"] = dt.Rows[0][4];
                        dr["Periodo"] = periodo;
                        dr["Usuario"] = dt4.Rows[0][1];
                        dr["Proceso"] = dt4.Rows[0][2];
                        dr["concepto"] = dt3.Rows[i][1];
                        dr["campo"] = dt4.Rows[0][3];
                        dr["DatoHistorio"] = dt4.Rows[0][4];
                        dr["DatoActual"] = dt4.Rows[0][5];

                        dt2.Rows.Add(dr);
                    }

                }

            }
            return dt2;



        }
    }
}