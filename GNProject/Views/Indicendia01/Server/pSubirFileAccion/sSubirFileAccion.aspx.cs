using BusinessLogic.oRepPendientes;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pSubirFileAccion
{
    public partial class sSubirFileAccion : System.Web.UI.Page
    {
        public static string Incidente_Id, Accion_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            Incidente_Id = Request.QueryString["iccod"];
            Accion_Id = Request.QueryString["accod"];
        }

        protected void btnSubirFile_Click(object sender, EventArgs e)
        {
            if (Incidente_Id != "" && Accion_Id != "")
            {
                if (fileInc.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fileInc.FileName).ToLower();

                    string[] allExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };
                    bool fileOk = false;
                    for (int i = 0; i < allExtensions.Length; i++)
                    {
                        if (extension == allExtensions[i])
                        {
                            fileOk = true;
                        }
                    }

                    if (fileOk)
                    {
                        try
                        {
                            string newnameF = int.Parse(Incidente_Id).ToString() + int.Parse(Accion_Id).ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Second.ToString();
                            newnameF = newnameF + extension;
                            if (!Directory.Exists(Server.MapPath("../../ArchivosAcciones" + "/" + Incidente_Id + "/" + Accion_Id)))
                            {
                                Directory.CreateDirectory(Server.MapPath("../../ArchivosAcciones" + "/" + Incidente_Id + "/" + Accion_Id));
                            }

                            string rutaRaiz = "../../ArchivosAcciones" + "/" + Incidente_Id + "/" + Accion_Id + "/";

                            string rutaSave = Server.MapPath(rutaRaiz + fileInc.FileName);
                            fileInc.SaveAs(rutaSave);
                            System.IO.File.Move(rutaSave, Server.MapPath(rutaRaiz + newnameF));


                            bool proce = controller_RepPendientes.Get_Instance().Get_Add_FileAccion(Incidente_Id, Accion_Id, newnameF, "");
                            if (proce == false)
                            {
                                System.IO.File.Delete(Server.MapPath(rutaRaiz + newnameF));
                            }
                            else
                            {
                                fc_DisplayAlert(this, "Archivo Subido Correctamente.");
                            }
                        }
                        catch
                        {

                        }


                    }
                    else
                    {
                        fc_DisplayAlert(this, ".::Error, Solo archivos gif, png, jpeg, jpg, pdf");
                    }
                }

            }
        }

        public void fc_DisplayAlert(Page c, String Msj)
        {
            /*Dentro de un ScriptManager*/
            Msj = Msj.Replace("\'", "\\'");
            Msj = Msj.Replace("\r", "\\r");
            Msj = Msj.Replace("\n", "\\n");
            String ScriptAlertRpta = "<script languaje='javascript' type='text/javascript'>alert('" + Msj + "');</script>";
            ScriptManager.RegisterStartupScript(c, typeof(Page), "AlertRpta", ScriptAlertRpta, false);
        }

        [WebMethod]
        public static List<File_Accion> Get_FilesAccion_List(string Incidente_Id, string Accion_Id)
        {
            return controller_RepPendientes.Get_Instance().Get_FilesAccion_List(Incidente_Id, Accion_Id);
        }

        [WebMethod]
        public static bool Get_Delete_FileAccion(string Incidente_Id, string Accion_Id, string FileA_Id)
        {
            File_Accion fileIn = controller_RepPendientes.Get_Instance().Get_Find_FileAccion(Incidente_Id, Accion_Id, FileA_Id);
            bool proce = controller_RepPendientes.Get_Instance().Get_Delete_FileAccion(Incidente_Id, Accion_Id, FileA_Id);
            if (proce)
            {
                if (fileIn != null)
                {
                    string rutaRaiz = "../../ArchivosAcciones" + "/" + Incidente_Id + "/" + Accion_Id + "/";
                    string rutaDel = HttpContext.Current.Server.MapPath(rutaRaiz + fileIn.File_NameI);
                    System.IO.File.Delete(rutaDel);
                }
            }
            return proce;
        }
    }
}