<%@ WebHandler Language="C#" Class="FileUpload" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

public class FileUpload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            if (context.Request.Files.Count > 0)
            {
                string fechaHoraActual = DateTime.Now.ToString("yyyyMMddHHmmss_");
                string strCarpeta = DateTime.Now.ToString("yyyyMM") + "/";
                string nomArchivo = context.Request["name"].ToString();
                string strRuta = context.Request["ruta"] + strCarpeta.ToString();

                string path = context.Server.MapPath(strRuta);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }


                var file = context.Request.Files[0];

                string fileName;

                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    string[] files = file.FileName.Split(new char[] { '\\' });
                    fileName = files[files.Length - 1];
                }
                else
                {
                    fileName = file.FileName;
                }

                fileName = fileName.Replace(" ", "").Replace("..", ".");
                string strFileName = fechaHoraActual + fileName;
                fileName = Path.Combine(path, strFileName);
                file.SaveAs(fileName);

                string strRespuesta = "1|" + strFileName;

                context.Response.Write(strRespuesta);
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("0|" + ex.ToString());
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}