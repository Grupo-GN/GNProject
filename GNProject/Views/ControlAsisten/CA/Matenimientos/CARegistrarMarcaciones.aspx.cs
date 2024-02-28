using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services;
using Presistence;
using System.IO;
using System.Data;
using BusienssLogic.CA.oRegistrarMarcaciones;
using System.Data.OleDb;
using System.Collections.Specialized;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class CARegistrarMarcaciones : System.Web.UI.Page
    {
        //public Class1 cl ;
        [WebMethod]
        public static Periodo_Asistencia Get_Periodo_Asistencia_List()
        {
            return Controller_RegistrarMarcaciones.GetInstance().Get_Periodo_Asistencia_List();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtcodigo.Value = Convert.ToString(Get_Periodo_Asistencia_List().Periodo);
            //txtft.Value = Convert.ToString(Get_Periodo_Asistencia_List().Date_Fin);
            //txtfi.Value = Convert.ToString(Get_Periodo_Asistencia_List().Date_Inicio);

            if (this.IsPostBack == false)
            {
                DataTable ar = Class1.GetInstance().RUNTABLA("sp_GetPeriodo_Asistencia", "");
                txtcodigo.Value = ar.Rows[0][0].ToString();
                txtfi.Value = ar.Rows[0][1].ToString();
                txtft.Value = ar.Rows[0][2].ToString();
                Panel1.Visible = false;
                Panel2.Visible = false;
                string fi = Convert.ToDateTime(txtfi.Value).ToString("yyy-MM-dd");
                string ff = Convert.ToDateTime(txtft.Value).ToString("yyy-MM-dd");
                //string fi = Convert.ToDateTime(txtfi.Value).ToString("yyyMMdd");
                //string ff = Convert.ToDateTime(txtft.Value).ToString("yyyMMdd");
                DataTable cantAma = Class1.GetInstance().RUNTABLA("sp_GetCantAmanecidaPeriodo", fi, ff);
                if (cantAma.Rows.Count == 0)
                {
                    lblError.Text = "No ha registrado amanecidas en el periodo";
                }
                else
                {
                    lblError.Text = cantAma.Rows.Count + " Amanecidas en el Periodo";
                }
            }

        }
        protected void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("UploadMarcacionExcel")))
                {
                    Directory.CreateDirectory(Server.MapPath("UploadMarcacionExcel"));
                }

                string tipo = rbtipo.SelectedValue.ToString();

                HttpPostedFile archivo = fileUpd.PostedFile;

                var Nombre = "";
                Nombre = Path.GetFileName(archivo.FileName);
                //Cargar Excel
                var extension = "";
                extension = Path.GetExtension(archivo.FileName).ToLower();

                var dtMarcaciones = new DataTable();
                dtMarcaciones.Columns.Add(new DataColumn("ID", typeof(string)));
                dtMarcaciones.Columns.Add(new DataColumn("Fecha", typeof(string)));//cambio de dato de datetime a string
                dtMarcaciones.Columns.Add(new DataColumn("Ingreso", typeof(string)));//Columnas para datos de ingreso
                dtMarcaciones.Columns.Add(new DataColumn("Salida", typeof(string)));//Columnas para datos de salida
                dtMarcaciones.Columns.Add(new DataColumn("Tipo", typeof(string)));
                dtMarcaciones.Columns.Add(new DataColumn("Mensaje", typeof(string)));

                if (extension == ".xls" || extension == ".xlsx")
                {
                    if (File.Exists(Server.MapPath("UploadMarcacionExcel/" + Nombre)))
                    {
                        File.Delete(Server.MapPath("UploadMarcacionExcel/" + Nombre));
                    }
                    fileUpd.SaveAs(Server.MapPath("UploadMarcacionExcel/" + Nombre));
                    var strPathXLS = "";
                    var strConnXLS = "";
                    strPathXLS = Server.MapPath("UploadMarcacionExcel/" + Nombre);
                    if (extension == ".xls")
                    {
                        strConnXLS = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPathXLS + ";Extended Properties=" + '"' + "Excel 8.0;HDR=Yes;IMEX=2" + '"';
                    }
                    else if (extension == ".xlsx")
                    {
                        strConnXLS = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPathXLS + ";Extended Properties=" + '"' + "Excel 12.0;HDR=Yes;IMEX=2" + '"';
                    }

                    OleDbConnection conn = new OleDbConnection(strConnXLS);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        string hoja = "select * from [Hoja1$]";
                        if (tipo == "1") hoja = "select * from [Hoja1$]";
                        if (tipo == "2") hoja = "select * from [Hoja1$]";
                        if (tipo == "3") hoja = "select * from [detallado$]";
                        var consulta = hoja; //"select * from [Hoja1$]";
                        var cmd = new OleDbCommand(consulta, conn);
                        var da = new OleDbDataAdapter(cmd);

                        //da.Fill(dtExcel)
                        var dtre = new DataTable();
                        da.Fill(dtre);
                        var dtExcel = new DataTable();
                        dtExcel.Columns.Add(new DataColumn("AC-No.", typeof(string)));
                        dtExcel.Columns.Add(new DataColumn("Cedula No.", typeof(String)));
                        dtExcel.Columns.Add(new DataColumn("Nombre", typeof(String)));
                        dtExcel.Columns.Add(new DataColumn("Horario", typeof(DateTime)));
                        dtExcel.Columns.Add(new DataColumn("Estado", typeof(String)));
                        dtExcel.Columns.Add(new DataColumn("NvoEstado", typeof(String)));

                        dtExcel.Columns.Add(new DataColumn("Excepción", typeof(String)));
                        dtExcel.Columns.Add(new DataColumn("Operación", typeof(String)));


                        foreach (DataRow dr in dtre.Rows)
                        {
                            var fi = Get_Periodo_Asistencia_List().Date_Inicio;
                            var ft = Get_Periodo_Asistencia_List().Date_Fin;

                            if (tipo == "1")
                            {
                                var ec = dr[3].ToString();
                                if (ec.Trim() != "" && ec.Trim() != "Fecha")
                                {
                                    var fecha = dr[3].ToString().Substring(0, 10);
                                    var fecha1 = Convert.ToDateTime(fecha);

                                    if (fecha1 >= fi && fecha1 <= ft)
                                    {
                                        DataRow row;
                                        row = dtExcel.NewRow();
                                        string horario = dr[3].ToString().ToLower().Replace("a.m.", "am").Replace("p.m.", "pm");

                                        row["AC-No."] = dr[0].ToString().PadLeft(8, '0');
                                        row["Cedula No."] = dr[1];
                                        row["Nombre"] = dr[2];
                                        row["Horario"] = DateTime.Parse(horario);
                                        row["Estado"] = dr[4];
                                        row["NvoEstado"] = dr[5];
                                        row["Excepción"] = dr[6];
                                        row["Operación"] = dr[7];
                                        dtExcel.Rows.Add(row);

                                    }
                                }
                            }
                            if (tipo == "2")
                            {
                                var ec = dr[3].ToString();
                                if (ec.Trim() != "" && ec.Trim() != "Date" && ec.Trim() != "Fecha")
                                {
                                    var tiempo = dr[4].ToString();

                                    var fecha = dr[3].ToString().Substring(0, Math.Min(dr[3].ToString().Length, 10));
                                    // Asegurar que la cadena de fecha tenga al menos 10 caracteres
                                    if (fecha.Length == 9)
                                    {
                                        fecha = "0" + fecha;
                                    }

                                    //var fecha = dr[3].ToString().Substring(0, 10);
                                    var fecha1 = Convert.ToDateTime(fecha);

                                    if (fecha1 >= fi && fecha1 <= ft)
                                    {
                                        DataRow row;
                                        row = dtExcel.NewRow();
                                        string horario = dr[3].ToString().ToLower().Replace("a.m.", "am").Replace("p.m.", "pm");
                                        var lasthorario = DateTime.Parse(horario);
                                        var lastdni = dr[1].ToString().PadLeft(8, '0');
                                        DataRow[] matchingRows = dtExcel.Select($"Horario = '{lasthorario}' AND [AC-No.] = '{lastdni}'");
                                        row["AC-No."] = dr[1].ToString().PadLeft(8, '0');
                                        row["Cedula No."] = dr[0];
                                        row["Nombre"] = dr[2];
                                        row["Horario"] = DateTime.Parse(horario);
                                        row["Excepción"] = dr[4];
                                        row["Operación"] = dr[7];
                                        if (tiempo == "Morning")
                                        {
                                            row["Estado"] = dr[7];
                                        }
                                        if (tiempo == "Afternoon" && matchingRows.Length > 0)
                                        {
                                            //dtExcel.Rows[dtExcel.Rows.Count - 1]["NvoEstado"] = dr[8];
                                            matchingRows[0]["NvoEstado"] = dr[8];
                                            //row["NvoEstado"] = dr[8];
                                        }
                                        else
                                        {
                                            dtExcel.Rows.Add(row);
                                        }


                                    }
                                }


                                //var fecha = dr["Fecha/Hora"].ToString();
                                //if (fecha.Trim() != "")
                                //{
                                //    fecha = DateTime.Parse(fecha).ToString("dd/MM/yyyy");
                                //    string hora = DateTime.Parse(fecha).ToString("HH:mm:ss tt");
                                //    if (DateTime.Parse(fecha) >= fi && DateTime.Parse(fecha) <= ft)
                                //    {
                                //        DataRow row;
                                //        row = dtExcel.NewRow();
                                //        string fechahora = fecha + " " + hora;
                                //        string horario = fechahora.ToString().ToLower().Replace("a.m.", "am").Replace("p.m.", "pm");

                                //        row["AC-No."] = dr["No#"].ToString();
                                //        row["Cedula No."] = dr["No#"].ToString();
                                //        row["Nombre"] = "";
                                //        row["Horario"] = DateTime.Parse(horario);
                                //        row["Estado"] = "";
                                //        row["NvoEstado"] = "";
                                //        row["Excepción"] = "";
                                //        row["Operación"] = "";
                                //        dtExcel.Rows.Add(row);
                                //    }
                                //}
                            }
                            if (tipo == "3")
                            {
                                var fecha = dr["fecha"].ToString();
                                if (fecha.Trim() != "" && fecha.IndexOf('/') > -1 && dr["entrada1"].ToString().Trim() != "")
                                {
                                    fecha = DateTime.Parse(fecha).ToString("dd/MM/yyyy");
                                    string hora = DateTime.Parse(dr["entrada1"].ToString()).ToString("HH:mm:ss tt");

                                    if (DateTime.Parse(fecha) >= fi && DateTime.Parse(fecha) <= ft)
                                    {
                                        DataRow row;
                                        row = dtExcel.NewRow();
                                        string fechahora = fecha + " " + hora;
                                        string horario = fechahora.ToString().ToLower().Replace("a.m.", "am").Replace("p.m.", "pm");

                                        row["AC-No."] = dr["codigo"].ToString();
                                        row["Cedula No."] = dr["codigo"].ToString();
                                        row["Nombre"] = "";
                                        row["Horario"] = DateTime.Parse(horario);
                                        row["Estado"] = "";
                                        row["NvoEstado"] = "";
                                        row["Excepción"] = "";
                                        row["Operación"] = "";
                                        dtExcel.Rows.Add(row);

                                        string vsalida = "", vsalida1 = dr["salida1"].ToString()
                                            , vsalida2 = dr["entrada2"].ToString(), vsalida3 = dr["salida2"].ToString()
                                            , vsalida4 = dr["entrada3"].ToString(), vsalida5 = dr["salida3"].ToString();

                                        if (vsalida5 != "")
                                        {
                                            vsalida = vsalida5;
                                        }
                                        else if (vsalida4 != "")
                                        {
                                            vsalida = vsalida4;
                                        }
                                        else if (vsalida3 != "")
                                        {
                                            vsalida = vsalida3;
                                        }
                                        else if (vsalida2 != "")
                                        {
                                            vsalida = vsalida2;
                                        }
                                        else
                                        {
                                            vsalida = vsalida1;
                                        }

                                        fechahora = fecha + " " + vsalida;
                                        horario = fechahora.ToString().ToLower().Replace("a.m.", "am").Replace("p.m.", "pm");
                                        DataRow rowsalida;
                                        rowsalida = dtExcel.NewRow();
                                        rowsalida["AC-No."] = dr["codigo"].ToString();
                                        rowsalida["Cedula No."] = dr["codigo"].ToString();
                                        rowsalida["Nombre"] = "";
                                        rowsalida["Horario"] = DateTime.Parse(horario);
                                        rowsalida["Estado"] = "";
                                        rowsalida["NvoEstado"] = "";
                                        rowsalida["Excepción"] = "";
                                        rowsalida["Operación"] = "";
                                        dtExcel.Rows.Add(rowsalida);
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                        {
                            if (dtExcel.Rows[i][5].ToString() == "")
                            {
                                var fecha = "";
                                var hora = "";
                                fecha = dtExcel.Rows[i][3].ToString().Substring(0, 10);

                                int pos = i + 1;
                                if (pos < dtExcel.Rows.Count)
                                {
                                    var nextfecha = dtExcel.Rows[pos][3].ToString().Substring(0, 10);
                                    if (fecha == nextfecha)
                                    {
                                        string horarioColumnValue = dtExcel.Rows[i][3].ToString();
                                        if (horarioColumnValue.Length >= 24) // Asegurar que la cadena sea lo suficientemente larga
                                        {
                                            hora = horarioColumnValue.Substring(20, 4).Trim();
                                            dtExcel.Rows[i][5] = (hora == "p.m.") ? "Sal Hrs Ext" : "Ent Hrs Ext";
                                        }
                                    }
                                    else
                                    {
                                        string horarioColumnValue = dtExcel.Rows[i][3].ToString();
                                        if (horarioColumnValue.Length >= 24) // Asegurar que la cadena sea lo suficientemente larga
                                        {
                                            hora = horarioColumnValue.Substring(20, 4).Trim();
                                            dtExcel.Rows[i][5] = (hora == "p.m.") ? "Sal Hrs Ext" : "Ent Hrs Ext";
                                        }
                                    }
                                }
                            }
                        }

                        foreach (DataRow dr in dtExcel.Rows)
                        {
                            DataRow row = dtMarcaciones.NewRow();
                            row["ID"] = dr[0].ToString();
                            //row["Fecha"] = Convert.ToDateTime(dr[3]);
                            // Formatear la fecha en el formato deseado (MM/dd/yyyy)
                            row["Fecha"] = Convert.ToDateTime(dr[3]).ToString("dd/MM/yyyy");
                            row["Ingreso"] = dr[4].ToString();
                            row["Salida"] = dr[5].ToString();
                            if (dr[5].ToString() == "Sal Hrs Ext")
                            {
                                row["Tipo"] = "Salida"; //Salida => Sal Hrs Ext
                            }
                            else
                            {
                                if (dr[5].ToString() == "" || dr[5].ToString() == "Ent Hrs Ext")
                                {
                                    row["Tipo"] = "Entrada"; //Entrada => Ent Hrs Ext ó Vacío
                                }
                            }

                            if (dr[5].ToString() == "M/Sal")
                            {
                                row["Tipo"] = "Salida";
                            }
                            row["Mensaje"] = String.Empty;

                            dtMarcaciones.Rows.Add(row);
                        }

                        dtExcel.Dispose();
                        da.Dispose();
                        conn.Close();
                        conn.Dispose();
                        File.Delete(strPathXLS);

                    }
                    else
                    {
                        var stream = archivo.InputStream;
                        var objReader = new StreamReader(stream);

                        var sLine = "";
                        var arrText = new ArrayList();

                        var DNI = "";


                        do
                        {
                            sLine = objReader.ReadLine();
                            if (sLine != null)
                            {
                                if (sLine.Contains("DNI"))
                                {
                                    DNI = sLine.Substring(sLine.IndexOf(":") + 1, 8);
                                    arrText.Add(sLine);
                                }
                                if (sLine.Length > 10)
                                {

                                    DataRow row;
                                    row = dtMarcaciones.NewRow();
                                    var ID = "";
                                    try
                                    {
                                        ID = sLine.Substring(5, 5);
                                    }
                                    catch (Exception ex)
                                    {
                                        ID = "";
                                        throw ex;
                                    }

                                    var Fecha = new DateTime();
                                    try
                                    {
                                        Fecha = Convert.ToDateTime(sLine.Substring(21, 10));
                                    }
                                    catch (Exception ex)
                                    {
                                        Fecha = new DateTime(1900, 1, 1);
                                        throw ex;
                                    }

                                    var Hora = new DateTime();
                                    try
                                    {
                                        Hora = Convert.ToDateTime(sLine.Substring(32, 8));
                                    }
                                    catch (Exception ex)
                                    {
                                        Hora = new DateTime(1900, 1, 1);
                                        throw ex;
                                    }

                                    Fecha = new DateTime(Fecha.Year, Fecha.Month, Fecha.Day, Hora.Hour, Hora.Minute, Hora.Second);

                                    var Tipo = "";
                                    try
                                    {
                                        Tipo = sLine.Substring(41, 1);
                                    }
                                    catch (Exception ex)
                                    {
                                        Tipo = "";
                                        throw ex;
                                    }

                                    row[0] = ID;
                                    row[1] = Fecha;
                                    //row(2) = Tipo 'Hora
                                    if (Tipo == "1")
                                    {
                                        row[2] = "Entrada";
                                    }
                                    else if (Tipo == "2")
                                    {
                                        row[2] = "Salida";
                                    }

                                    //If Not Existe(dtMarcaciones, Fecha, row(0)) Then
                                    dtMarcaciones.Rows.Add(row);
                                    //End If
                                }
                            }

                            //arrText.Add(sLine)
                        } while (sLine == null);
                        objReader.Close();
                    }
                }

                grvMarcaciones.DataSource = dtMarcaciones;
                grvMarcaciones.DataBind();
                lblMsj.Text = dtMarcaciones.Rows.Count.ToString() + " registros.";
                Panel1.Visible = true;
                Panel2.Visible = false;

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = System.Drawing.Color.Red;
                Panel1.Visible = false;
                Panel2.Visible = false;

            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //int con1  = 0;
                //int con2  = 0;
                var co_trabajador = "";
                DateTime fecha = new DateTime();
                DateTime hora = new DateTime();
                var tipo = "";
                DataTable dtResult = new DataTable();
                Int32 rpta;
                var msj = "";
                //update
                string hfecha = "";
                string hSalida = "";
                string hEntrada = "";
                string formatoFecha = "dd/MM/yyyy";
                string formatoHora = "HH:mm";

                foreach (GridViewRow gridrow in grvMarcaciones.Rows)
                {
                    co_trabajador = gridrow.Cells[0].Text;
                    fecha = Convert.ToDateTime(gridrow.Cells[1].Text).Date;
                    hora = Convert.ToDateTime(gridrow.Cells[1].Text);
                    //update
                    hEntrada = gridrow.Cells[2].Text;
                    hSalida = gridrow.Cells[3].Text;
                    hfecha = gridrow.Cells[1].Text;
                    if (hEntrada == "&nbsp;")
                    {
                        hEntrada = "00:00";
                    }
                    if (hSalida == "&nbsp;")
                    {
                        hSalida = "00:00";
                    }

                    // Combina la fecha y la hora de entrada
                    DateTime fechaHoraEntrada = DateTime.ParseExact($"{hfecha} {hEntrada}", $"{formatoFecha} {formatoHora}", null);
                    // Combina la fecha y la hora de salida
                    DateTime fechaHoraSalida = DateTime.ParseExact($"{hfecha} {hSalida}", $"{formatoFecha} {formatoHora}", null);

                    if (gridrow.Cells[2].Text == "Entrada")
                    {
                        tipo = "1";
                    }
                    else if (gridrow.Cells[2].Text == "Salida")
                    {
                        tipo = "2";
                    }
                    if (co_trabajador == "01295942")
                    {
                        co_trabajador = "01295942";
                    }
                    if (tipo == "")
                    {
                        tipo = "1";
                        dtResult = Class1.GetInstance().RUNTABLA("fps_spi_marcaciones", co_trabajador, fechaHoraEntrada, fechaHoraEntrada, tipo);
                        tipo = "2";
                        dtResult = Class1.GetInstance().RUNTABLA("fps_spi_marcaciones", co_trabajador, fechaHoraSalida, fechaHoraSalida, tipo);
                        tipo = "";
                    }


                    rpta = Convert.ToInt32(dtResult.Rows[0][0].ToString());
                    msj = dtResult.Rows[0][1].ToString();
                    gridrow.Cells[3].Text = msj;
                    if (rpta < 0)
                    {
                        gridrow.Cells[3].ForeColor = System.Drawing.Color.Red;
                    }
                }

                grvMarcaciones.Columns[3].Visible = true; //Se muestra la columna Mensaje

                lblMsj.Text = "Marcaciones Registrados Correctamente.";
                lblMsj.ForeColor = System.Drawing.Color.DarkOrange;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                lblMsj.ForeColor = System.Drawing.Color.Red;

            }
            //Procesar las marcaciones'
            //Panel1.Visible = False
            //Panel2.Visible = True
            cargarMarcacionesNoProcesadas();

            try
            {
                Class1.GetInstance().RUNPRO("fps_sps_procesa_marcaciones");

                var ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('Se registraron las Marcaciones pendientes en el Control de Asistencia.');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
                cargarMarcacionesNoProcesadas();

            }
            catch (Exception ex)
            {
                var ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + ex.Message + "');</script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
            }


            //foreach( GridViewRow row in grvPersonal.Rows)
            //{
            //var Personal_Id=grvPersonal.DataKeys[row.RowIndex].Values["Personal_Id"].ToString();
            //    var Fecha = row.Cells[3].Text;

            //    var HINI = row.Cells[4].Text;
            //    var HFIN = row.Cells[5].Text;

            //    var HINI_HORARIO = row.Cells[6].Text;
            //    var HFIN_HORARIO = row.Cells[7].Text;
            //    var HT = row.Cells[8].Text;
            //    var HES = row.Cells[9].Text;
            //    var HEA = row.Cells[10].Text;
            //    var HED = row.Cells[11].Text;

            //    DateTime HoraInicio;
            //    DateTime HoraFin;

            //    if (HINI == "&nbsp;" && HFIN == "&nbsp;") {
            //        HoraInicio = Convert.ToDateTime(HINI_HORARIO);
            //        HoraFin = Convert.ToDateTime(HINI_HORARIO).AddHours(Convert.ToDouble(HT.Substring(0,2)));
            //        HoraFin = HoraFin.AddMinutes(Convert.ToDouble(HT.Substring(3,2)));
            //    }
            //    else{
            //        try{
            //            HoraInicio = Convert.ToDateTime(HINI);
            //        }catch(Exception ex) {
            //            HoraFin = new DateTime(1900, 1, 1);
            //             }
            //        try{HoraFin = Convert.ToDateTime(HFIN);
            //            }
            //        catch(Exception ex) {
            //            HoraFin = new DateTime(1900, 1, 1); }
            //    }
            //try{
            //    cl.RUNPRO("usp_InsertC_A", Personal_Id, Fecha,HoraInicio.Hour, HoraInicio.Minute, HoraFin.Hour, HoraFin.Minute,
            //        HES.Substring(0, 2), HES.Substring(3, 2), HEA.Substring(0, 2), HEA.Substring(3,2), HED.Substring(0,2), HED.Substring(3,2));
            //    }
            //catch(Exception ex){ throw ex;  }        

            //}
        }
        private void cargarMarcacionesNoProcesadas()
        {
            DataTable dt = new DataTable();
            dt = Class1.GetInstance().RUNTABLA("fps_sps_marcaciones_sin_procesar");
            grvPersonal.DataSource = dt;
            grvPersonal.DataBind();

            lblMsj.Text = dt.Rows.Count.ToString() + " Marcaciones que no han sido procesadas";
            lblMsj.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            // Ruta al archivo que deseas descargar
            string rutaArchivo = Server.MapPath("~/CA/Matenimientos/UploadMarcacionExcel/plantilla.xlsx"); // Ajusta la ruta y el nombre del archivo

            // Nombre del archivo que se mostrará al usuario al descargar
            string nombreArchivo = "plantilla.xlsx";

            // Descargar el archivo
            DescargarArchivo(rutaArchivo, nombreArchivo);
        }

        private void DescargarArchivo(string rutaArchivo, string nombreArchivo)
        {
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain"; // Ajusta el tipo de contenido según el tipo de archivo
            response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo + ";");
            response.TransmitFile(rutaArchivo);
            response.Flush();
            response.End();
        }
    }
}