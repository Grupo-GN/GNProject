using BusinessLogic.oSendOsigermin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.Indicendia01.Server.pSendOsigermin
{
    public partial class sFileOsigermin : System.Web.UI.Page
    {
        public static string Incidente_Id, Tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            Incidente_Id = Request.QueryString["iccod"];
            Tipo = Request.QueryString["tcod"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Incidente_Id != "" && Tipo != "")
            {
                string tipo_Id = Tipo;
                if (Tipo == "01")
                {
                    Tipo = "Preliminar";
                }
                else if (Tipo == "02")
                {
                    Tipo = "Final";
                }
                if (fileOsiger.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fileOsiger.FileName).ToLower();

                    string[] allExtensions = { ".rar", ".tar", ".jpg", ".pdf", ".zip" };
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
                            string newnameF = int.Parse(Incidente_Id).ToString() + Tipo + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString();
                            newnameF = newnameF + extension;
                            string rutaRaiz = "../../ArchivosOsigermin/" + Tipo + "/" + Incidente_Id + "/";
                            if (Directory.Exists(Server.MapPath(rutaRaiz)))
                            {
                                Directory.Delete(Server.MapPath(rutaRaiz), true);
                            }
                            if (!Directory.Exists(Server.MapPath(rutaRaiz)))
                            {
                                Directory.CreateDirectory(Server.MapPath(rutaRaiz));
                            }
                            bool registro = controller_SenOsigermin.Get_Instance().Get_SabeFile(Incidente_Id, newnameF, tipo_Id);
                            if (registro == true)
                            {
                                string rutaSave = Server.MapPath(rutaRaiz + fileOsiger.FileName);
                                fileOsiger.SaveAs(rutaSave);
                                System.IO.File.Move(rutaSave, Server.MapPath(rutaRaiz + newnameF));
                                fc_DisplayAlert(this, "Archivo Subido Correctamente.");
                            }
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        fc_DisplayAlert(this, ".::Error, Solo archivos rar, tar, jpg, pdf, zip");
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
    }
}