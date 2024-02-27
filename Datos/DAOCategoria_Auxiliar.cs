using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Capas.Portal.Datos
{
    public class DAOCategoria_Auxiliar:ClsConexion 
    {
        public DataTable ListaCategoria_Auxiliar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Categoria_Auxiliar_Id, case when Categoria_Auxiliar_Id = '00             ' then ' General' else Descripcion end as 'Descripcion' from Categoria_Auxiliar order by Descripcion", Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }

        public DataTable ListaCategoria_AuxiliaSinTodos()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Categoria_Auxiliar_Id, Descripcion from Categoria_Auxiliar where Categoria_Auxiliar_Id != '00             ' order by Descripcion", Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }

    }
}
