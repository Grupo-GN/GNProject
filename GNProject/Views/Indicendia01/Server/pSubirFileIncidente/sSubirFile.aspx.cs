using BusinessLogic.oReporteIncidente;
using PersistenceInci;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pSubirFileIncidente
{
    public partial class sSubirFile : System.Web.UI.Page
    {
        public static string Codi = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string CodigoGen = Request.QueryString["i"];
            Codi = CodigoGen;

        }

        protected void btnSubirFile_Click(object sender, EventArgs e)
        {
            if (Codi != "")
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
                            string newnameF = Codi + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Second.ToString();
                            newnameF = newnameF + extension;
                            if (!Directory.Exists(Server.MapPath("../../ArchivosIncidentes" + "/" + Codi)))
                            {
                                Directory.CreateDirectory(Server.MapPath("../../ArchivosIncidentes" + "/" + Codi));
                            }

                            string rutaSave = Server.MapPath("../../ArchivosIncidentes" + "/" + Codi + "/" + fileInc.FileName);
                            fileInc.SaveAs(rutaSave);
                            System.IO.File.Move(rutaSave, Server.MapPath("../../ArchivosIncidentes" + "/" + Codi + "/" + newnameF));


                            bool proce = controller_ReporteIncidente.Get_Instance().Get_Add_DataFile(Codi, newnameF, "ArchivosIncidentes/" + Codi + "/" + newnameF);
                            if (proce == false)
                            {
                                System.IO.File.Delete(Server.MapPath("../../ArchivosIncidentes" + "/" + Codi + "/" + newnameF));
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
        public static List<File_Incidencia> Get_Files_List(string Cogido_Gen)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Files_List(Cogido_Gen);
        }

        [WebMethod]
        public static bool Get_Delte_DataFile_Generado(string FileI_Id, string Cogido_Gen)
        {
            File_Incidencia fileIn = controller_ReporteIncidente.Get_Instance().Get_Find_File(FileI_Id, Cogido_Gen);
            bool proce = controller_ReporteIncidente.Get_Instance().Get_Delte_DataFile_Generado(FileI_Id, Cogido_Gen);
            if (proce)
            {
                if (fileIn != null)
                {
                    string rutaDel = HttpContext.Current.Server.MapPath("../../ArchivosIncidentes" + "/" + Codi + "/" + fileIn.File_NameI);
                    System.IO.File.Delete(rutaDel);
                }
            }
            return proce;
        }
    }
}