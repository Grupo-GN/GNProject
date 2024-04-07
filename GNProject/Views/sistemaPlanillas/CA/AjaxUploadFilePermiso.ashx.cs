using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNProject.Views.sistemaPlanillas.CA
{
    /// <summary>
    /// Descripción breve de AjaxUploadFilePermiso
    /// </summary>
    public class AjaxUploadFilePermiso : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    string Personal_Id = context.Request["perso"].ToString();
                    string permiso_id = context.Request["permi"].ToString();
                    string tipo = context.Request["tipo"].ToString();

                    string NewFileName = Personal_Id + permiso_id + tipo;

                    string path = context.Server.MapPath("~/CA/ArchivoPermiso/");
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }

                    var file = context.Request.Files[0];

                    string fileName;
                    string TypeArchivo = "";//file.ContentType;

                    //TypeArchivo = TypeArchivo.Substring((TypeArchivo.IndexOf('/') + 1));

                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = file.FileName.Split(new char[] { '\\' });
                        fileName = files[files.Length - 1];
                    }
                    else
                    {
                        fileName = file.FileName;
                    }
                    string[] desglose = fileName.Split('.');
                    TypeArchivo = desglose[desglose.Length - 1];
                    NewFileName += "." + TypeArchivo;

                    //ELIMINAR ARCHIVO SI EXISTE
                    string nameDelete = CAPA_DATOS.oCA.controllerPermisos.getInstance().Delete_ArchivoPermiso(int.Parse(permiso_id), Personal_Id, tipo);


                    string strFileName = fileName;
                    bool Inserto = CAPA_DATOS.oCA.controllerPermisos.getInstance().Insert_ArchivoPermiso(int.Parse(permiso_id), Personal_Id, tipo, NewFileName, path + NewFileName);
                    if (Inserto)
                    {
                        if (nameDelete != "")
                        {
                            string fileEleiminar = System.IO.Path.Combine(path, nameDelete);
                            System.IO.File.Delete(fileEleiminar);
                        }
                        fileName = System.IO.Path.Combine(path, fileName);
                        file.SaveAs(fileName);
                        string FullNewPath = System.IO.Path.Combine(path, NewFileName);

                        System.IO.File.Move(fileName, FullNewPath);

                        context.Response.Write("../CA/ArchivoPermiso/" + NewFileName);
                    }
                    else
                    {

                        context.Response.Write("0");
                    }
                }
            }
            catch (Exception ex)
            {

                context.Response.Write(ex.Message);
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