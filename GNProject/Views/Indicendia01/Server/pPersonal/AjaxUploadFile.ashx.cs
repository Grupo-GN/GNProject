using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using BusinessLogic.oPersonal;
namespace Presentacion.Server.pPersonal
{
    /// <summary>
    /// Summary description for AjaxUploadFile
    /// </summary>
    public class AjaxUploadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                if (context.Request.Files.Count > 0)
                {
                    string Personal_Id = context.Request["name"].ToString();
                    string NewFileName = Personal_Id;
                    
                    string path = context.Server.MapPath("~/FotosPersonal/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var file = context.Request.Files[0];

                    string fileName;
                    string TypeArchivo = file.ContentType;
                    TypeArchivo = TypeArchivo.Substring((TypeArchivo.IndexOf('/') + 1));
                    NewFileName += "." + TypeArchivo;
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = file.FileName.Split(new char[] { '\\' });
                        fileName = files[files.Length - 1];
                    }
                    else
                    {
                        fileName = file.FileName;
                    }
                    
                    //ELIMINAR ARCHIVO SI EXISTE
                    string nameDelete = controller_Personal.Get_Instance().Get_DeleteFotoPersonal(Personal_Id);


                    string strFileName = fileName;
                    bool Inserto = controller_Personal.Get_Instance().Get_GuardarDatosFotoPersonal(Personal_Id, NewFileName);
                    if (Inserto)
                    {
                        if (nameDelete!="")
                        {
                           string fileEleiminar = Path.Combine(path, nameDelete);
                           File.Delete(fileEleiminar);
                        }
                        fileName = Path.Combine(path, fileName);
                        file.SaveAs(fileName);
                        string FullNewPath = Path.Combine(path, NewFileName);

                        File.Move(fileName, FullNewPath);

                        context.Response.Write(NewFileName);
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
            }
            catch (Exception ex)
            {

                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}