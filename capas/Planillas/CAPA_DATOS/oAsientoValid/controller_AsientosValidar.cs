using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace CAPA_DATOS.oAsientoValid
{
    public class controller_AsientosValidar
    {
        private static controller_AsientosValidar instace = null;
        public static controller_AsientosValidar getinstance()
        {
            return instace == null ? instace = new controller_AsientosValidar() : instace;
        }
        public int AsientoCuentasValidarConceptos(string anio) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String())) {
                using (SqlCommand cmd = new SqlCommand("GNRS_AsientoConceptosCuentasValidar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Anio", anio);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int cant = 0;
                    while (dr.Read()) {
                        cant += 1;
                    }
                    return cant;
                }            
            }

        }
    }
}
