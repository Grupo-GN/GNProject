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

namespace GNProject.Views.Indicendia01.Server.pEditFileIncidente
{
    public partial class sEditFileIncidente : System.Web.UI.Page
    {
        public static string Incidencia_Id = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string cod = Request.QueryString["i"];
            Incidencia_Id = cod;

        }
        protected void btnSubirFile_Click(object sender, EventArgs e)
        {
            if (Incidencia_Id != "")
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
                            string newnameF = Incidencia_Id + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Second.ToString();
                            newnameF = newnameF + extension;
                            if (!Directory.Exists(Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id)))
                            {
                                Directory.CreateDirectory(Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id));
                            }

                            string rutaSave = Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id + "/" + fileInc.FileName);
                            fileInc.SaveAs(rutaSave);
                            System.IO.File.Move(rutaSave, Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id + "/" + newnameF));


                            bool proce = controller_ReporteIncidente.Get_Instance().Get_Add_DataFile_Inc(Incidencia_Id, newnameF, "ArchivosIncidentes/" + Incidencia_Id + "/" + newnameF);
                            if (proce == false)
                            {
                                System.IO.File.Delete(Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id + "/" + newnameF));
                            }
                        }
                        catch
                        {

                        }


                    }
                }

            }
        }


        [WebMethod]
        public static List<File_Incidencia> Get_Files_List_Indicencia(string Incidencia_Id)
        {
            return controller_ReporteIncidente.Get_Instance().Get_Files_List_Indicencia(Incidencia_Id);
        }

        [WebMethod]
        public static bool Get_Delte_DataFile(string FileI_Id, string Incidencia_Id)
        {
            File_Incidencia fileIn = controller_ReporteIncidente.Get_Instance().Get_Find_File_Incidencia(FileI_Id, Incidencia_Id);
            bool proce = controller_ReporteIncidente.Get_Instance().Get_Delte_DataFile(FileI_Id, Incidencia_Id);
            if (proce)
            {
                if (fileIn != null)
                {
                    string rutaDel = HttpContext.Current.Server.MapPath("../../ArchivosIncidentes" + "/" + Incidencia_Id + "/" + fileIn.File_NameI);
                    System.IO.File.Delete(rutaDel);
                }
            }
            return proce;
        }
    }
}