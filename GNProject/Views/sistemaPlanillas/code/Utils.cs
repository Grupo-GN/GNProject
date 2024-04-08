using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Utils
{
    public Utils()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string fc_obtiene_Planilla_Id(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboPlanilla = new DropDownList();
        cboPlanilla = (DropDownList)ucFiltros1.FindControl("cboPlanilla");
        return cboPlanilla.SelectedValue;
    }
    public static string fc_obtiene_Planilla_Id_Nombre(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboPlanilla = new DropDownList();
        cboPlanilla = (DropDownList)ucFiltros1.FindControl("cboPlanilla");
        return cboPlanilla.SelectedItem.Text;
    }
    public static string fc_obtiene_Ejercicio_Id(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboEjericio = new DropDownList();
        cboEjericio = (DropDownList)ucFiltros1.FindControl("cboEjercicio");
        return cboEjericio.SelectedValue;
    }
    public static string fc_obtiene_Periodo_Id(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboPeriodo = new DropDownList();
        cboPeriodo = (DropDownList)ucFiltros1.FindControl("cboPeriodo");
        return cboPeriodo.SelectedValue;
    }
    public static int fc_obtiene_Periodo_SelectedIndex(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboPeriodo = new DropDownList();
        cboPeriodo = (DropDownList)ucFiltros1.FindControl("cboPeriodo");
        return cboPeriodo.SelectedIndex + 1;
    }
    public static string fc_obtiene_Periodo_Id_Nombre(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboPeriodo = new DropDownList();
        cboPeriodo = (DropDownList)ucFiltros1.FindControl("cboPeriodo");
        return cboPeriodo.SelectedItem.Text;
    }

    public static string fc_obtiene_Mes_Id_Nombre(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboMes = new DropDownList();
        cboMes = (DropDownList)ucFiltros1.FindControl("cboMes");
        return cboMes.SelectedItem.Text;
    }

    public static string fc_obtiene_Compania_Id(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboEmpresa = new DropDownList();
        cboEmpresa = (DropDownList)ucFiltros1.FindControl("cboEmpresa");
        return cboEmpresa.SelectedValue;
        //return "01";
    }

    public static string fc_obtiene_Compania_Id_Nombre(Page pagina)
    {
        UserControl ucFiltros1 = new UserControl();
        ucFiltros1 = (UserControl)pagina.Master.FindControl("ucFiltros1");
        DropDownList cboEmpresa = new DropDownList();
        cboEmpresa = (DropDownList)ucFiltros1.FindControl("cboEmpresa");
        return cboEmpresa.SelectedItem.Text;
    }

    public static string fc_Compania_Id
    {
        get { return "01"; }
        set { fc_Compania_Id = value; }
    }

    public static Boolean fc_ValidaFiltros(Page pagina)
    {
        if (fc_obtiene_Planilla_Id(pagina) == "" || fc_obtiene_Ejercicio_Id(pagina) == "" || fc_obtiene_Periodo_Id(pagina) == ""
            || fc_obtiene_Planilla_Id(pagina) == null || fc_obtiene_Ejercicio_Id(pagina) == null || fc_obtiene_Periodo_Id(pagina) == null)
            return false;
        else
            return true;
    }

    private static Int32 fc_Cantidad_Filas_Grid
    {
        get { return 200; }
    }

    /*Si El GridView contiene mas de la cantidad de filas configurada, 
        entonces se pagina, caso contrario se queda con el Scroll*/
    public static void fc_Adecua_GridView(GridView grv, int Cant_Rows)
    {
        if (Cant_Rows > fc_Cantidad_Filas_Grid)
            grv.AllowPaging = true;
        else
            grv.AllowPaging = false;
    }

    public static string fc_Left(string param, int length)
    {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        string result = param.Substring(0, length);
        //return the result of the operation
        return result;
    }
    public static string fc_Right(string param, int length)
    {
        //start at the index based on the lenght of the sting minus
        //the specified lenght and assign it a variable
        string result = param.Substring(param.Length - length, length);
        //return the result of the operation
        return result;
    }

    public static void fc_DisplayAlert(Page c, String Msj)
    {
        /*Dentro de un ScriptManager*/
        Msj = Msj.Replace("\'", "\\'");
        Msj = Msj.Replace("\r", "\\r");
        Msj = Msj.Replace("\n", "\\n");
        String ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + Msj + "');</script>";
        ScriptManager.RegisterStartupScript(c, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
    }

    public static void fc_JavaScript(Page c, String script)
    {
        /*Dentro de un ScriptManager*/
        //script = script.Replace("\'", "\\'");
        //script = script.Replace("\r", "\\r");
        //script = script.Replace("\n", "\\n");
        String Script = "<script languaje='javascript' type='text/javascript'>" + script + "</script>";
        ScriptManager.RegisterStartupScript(c, typeof(Page), "Script", Script, false);
    }

    public static void fc_Select_Fila_GridView(GridView grv, Int32 fila)
    {
        int i;
        i = 0;
        foreach (GridViewRow row in grv.Rows)
        {
            if ((i % 2) == 0)
                row.BackColor = System.Drawing.Color.FromName("#F7F6F3");
            else
                row.BackColor = System.Drawing.Color.White;
            i = i + 1;
        }
        grv.Rows[fila].BackColor = System.Drawing.Color.SkyBlue;
    }

    /*Convertir una Ruta de Imagen a Byte*/
    public static byte[] fc_ConversionImagen(string rutanombrearchivo)
    {
        byte[] imagen;
        if (File.Exists(rutanombrearchivo))
        {
            //Declaramos fs para poder abrir la imagen.
            FileStream fs = new FileStream(rutanombrearchivo, FileMode.Open);

            // Declaramos un lector binario para pasar la imagen
            // a bytes
            BinaryReader br = new BinaryReader(fs);
            imagen = new byte[(int)fs.Length];
            br.Read(imagen, 0, (int)fs.Length);
            br.Close();
            fs.Close();
        }
        else
        {
            imagen = null;
        }
        return imagen;
    }

    /*Convierte Bytes a Imagen*/
    public static System.Drawing.Image Bytes2Image(byte[] bytes)
    {
        if (bytes == null) return null;
        MemoryStream ms = new MemoryStream(bytes);
        Bitmap bm = null;
        try
        {
            bm = new Bitmap(ms);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        return bm;
    }

    public static void exportDataTableToExcel(DataTable dt, String nomExcel)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pagina = new Page();
        GridView grilla = new GridView();
        // Deshabilitar la validación de eventos, sólo asp.net 2
        grilla.EnableViewState = false;
        grilla.AllowPaging = false;
        grilla.DataSource = dt;
        grilla.DataBind();
        // grilla.Columns(0).Visible = False
        var form = new System.Web.UI.HtmlControls.HtmlForm();
        pagina.EnableEventValidation = false;
        pagina.DesignerInitialize();
        pagina.Controls.Add(form);

        form.Controls.Add(grilla);
        pagina.RenderControl(htw);

        System.Web.HttpResponse Response = HttpContext.Current.Response;
        Response.Clear();
        Response.Buffer = true;
        // Response.ContentType = "application/vnd.word"
        // Response.AddHeader("Content-Disposition", "attachment;filename=data.doc")
        Response.ContentType = "application/vnd.ms-excel";
        //Response.ContentType = "application/vnd.xlsx";
        nomExcel = nomExcel + ".xls";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + nomExcel);
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Default;
        // Dim style As String = "<style> .text { mso-number-format:\@; } </script> "
        // Response.Write(style)
        Response.Write(sb.ToString());
        Response.End();
    }
}