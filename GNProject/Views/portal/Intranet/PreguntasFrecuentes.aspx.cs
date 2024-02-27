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
    public partial class PreguntasFrecuentes : System.Web.UI.Page
    {
        BUSFaq objNegFaq = new BUSFaq();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    String Faq_Id = (Request.QueryString["id"].ToString());
                    Faq objEFaq = new Faq(Faq_Id);
                    DataTable dt = objNegFaq.ListaFaqxId(objEFaq);
                    lblPregunta.Text = dt.Rows[0]["Pregunta"].ToString();
                    lblRespuesta.Text = dt.Rows[0]["Respuesta"].ToString();
                    lblArea.Text = dt.Rows[0]["Area"].ToString();
                }
                else
                {
                    this.CargarFaqAll();
                }
            }
        }

        private void CargarFaqAll()
        {
            DataTable dt = new DataTable();
            dt = objNegFaq.ListaFaqAll();

            TreeNode nodo1 = new TreeNode();
            TreeNode nodo2 = new TreeNode();
            String Pregunta, Respuesta;
            Pregunta = "";
            Respuesta = "";

            if (dt.Rows.Count <= 0)
            {
                lblMsjFaq.Visible = true;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow fila1 = dt.Rows[i];

                if (Pregunta != fila1[1].ToString())
                {
                    Respuesta = fila1[2].ToString();
                    nodo2 = new TreeNode(Respuesta, fila1[0].ToString());

                    Pregunta = fila1[1].ToString();
                    nodo1 = new TreeNode(Pregunta, fila1[0].ToString());

                    //nodo2.ChildNodes.Add(new TreeNode(fila1[5].ToString(), fila1[4].ToString(), "", fila1[6].ToString(), "_self"));
                    nodo1.ChildNodes.Add(nodo2);
                    TreeViewFaq.Nodes.Add(nodo1);

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.None;
                }
                else
                {
                    if (Respuesta != fila1[2].ToString())
                    {
                        Respuesta = fila1[2].ToString();
                        nodo2 = new TreeNode(Respuesta, fila1[0].ToString());
                        nodo1.ChildNodes.Add(nodo2);
                    }
                    //nodo2.ChildNodes.Add(new TreeNode(fila1[5].ToString(), fila1[4].ToString(), "", fila1[6].ToString(), "_self"));

                    nodo1.Expanded = false;
                    nodo2.Expanded = false;
                    nodo1.SelectAction = TreeNodeSelectAction.Expand;
                    nodo2.SelectAction = TreeNodeSelectAction.None;
                }
            }
            dt.Dispose();
        }
    }
}