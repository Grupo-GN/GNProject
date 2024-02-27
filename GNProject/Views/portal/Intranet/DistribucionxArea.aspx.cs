using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Capas.Portal.Negocio;
using Capas.Portal.Entidad;
using System.Data;

namespace GNProject.Views.portal.Intranet
{
    public partial class DistribucionxArea : System.Web.UI.Page
    {
        BUSPersonal objNegPersonal = new BUSPersonal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaDistribucionxArea(TreeView1);
            }
        }

        private void ListaDistribucionxArea(TreeView tvw)
        {
            DataTable dt = new DataTable();
            dt = objNegPersonal.ListaDistribucionxArea();

            String Area, Seccion, Personal_Id;
            Area = "";
            Seccion = "";
            Personal_Id = "";

            TreeNode nodo1 = new TreeNode();
            TreeNode nodo2 = new TreeNode();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow fila1 = dt.Rows[i];

                if (Area != fila1[1].ToString())
                {
                    Seccion = fila1[3].ToString();
                    nodo2 = new TreeNode(Seccion, fila1[2].ToString());

                    Area = fila1[1].ToString();
                    nodo1 = new TreeNode(Area, fila1[0].ToString());

                    nodo2.ChildNodes.Add(new TreeNode(fila1[5].ToString(), fila1[4].ToString(), "", fila1[6].ToString(), "_self"));
                    nodo1.ChildNodes.Add(nodo2);
                    tvw.Nodes.Add(nodo1);

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.Expand;
                }
                else
                {
                    if (Seccion != fila1[3].ToString())
                    {
                        Seccion = fila1[3].ToString();
                        nodo2 = new TreeNode(Seccion, fila1[2].ToString());
                        nodo1.ChildNodes.Add(nodo2);
                    }
                    nodo2.ChildNodes.Add(new TreeNode(fila1[5].ToString(), fila1[4].ToString(), "", fila1[6].ToString(), "_self"));

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.Expand;
                }
            }
            dt.Dispose();
            dt = null;
        }
    }
}