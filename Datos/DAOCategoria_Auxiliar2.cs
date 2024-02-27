using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Capas.Portal.Datos
{
    public class DAOCategoria_Auxiliar2:ClsConexion 
    {
        public DataTable ListaCategoria_Auxiliar2(String Categoria_Auxiliar_Id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Categoria_Auxiliar2_Id, Descripcion from Categoria_Auxiliar2 where Categoria_Auxiliar_Id=" + Categoria_Auxiliar_Id + " order by Descripcion", Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
    }
}
