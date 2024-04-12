using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Datos
{
    public partial class FrmImportCalculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string GuardarCalculo(string pPeriodo, string pConcepto, string pPersonal, string pProceso, decimal pValor)
        {
            return controllerImportCalculos.getInstance().GuardarCalculo(pPeriodo, pConcepto, pPersonal, pProceso, pValor);
        }
    }
}