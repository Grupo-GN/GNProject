using CAPA_DATOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmGenerarAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static ArrayList GetAsientosSelect(string xEjercicio, string xPlanilla)
        {
            return controller_GenerarAsientos.getInstance().GetAsientosSelect(xEjercicio, xPlanilla);
        }
    }
}