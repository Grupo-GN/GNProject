using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using System.Data;

namespace Capas.Portal.Negocio
{
    public class BUSInducDocumento
    {
        Datos.DAOInducDocumento objDatos = new DAOInducDocumento();
        public Int32 InsertInducDocumento(String Categoria_Auxiliar_Id, String Nombre_Doc)
        {
            return objDatos.InsertInducDocumento(Categoria_Auxiliar_Id, Nombre_Doc);
        }

        public Int32 UpdateInducDocumento(String Categoria_Auxiliar_Id, String Nombre_Doc)
        {
            return objDatos.UpdateInducDocumento(Categoria_Auxiliar_Id, Nombre_Doc);
        }

        public Int32 DeleteInducDocumento(String Categoria_Auxiliar_Id)
        {
            return objDatos.DeleteInducDocumento(Categoria_Auxiliar_Id);
        }

        public DataTable ListaInducDocumentoxArea(String Categoria_Auxiliar_Id)
        {
            return objDatos.ListaInducDocumentoxArea(Categoria_Auxiliar_Id);
        }

    }
}
