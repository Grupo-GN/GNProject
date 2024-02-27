using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

namespace Capas.Portal.Datos
{
    public class DAOLocalidad:ClsConexion 
    {
        public DataTable ListaLocalidad()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Area_Id, descripcion from RH_Area", Conexion());
            da.Fill(dt);
            da.Dispose();
            return dt;
        }
    }
}
