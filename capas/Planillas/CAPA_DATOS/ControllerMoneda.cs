using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAPA_ENTIDAD.EntMs;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS
{
    public class ControllerMoneda
    {


        /// <summary>
        /// metodo para mostrar Monedas
        /// </summary>
        /// <returns></returns>
        //public List<Moneda> Monedas_GetMostrar()
        //{
        //    using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("spu_Monedas_GetSelectAll", cn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cn.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            List<Moneda> oLista = new List<Moneda>();
        //            while (dr.Read())
        //            {
        //                Moneda m = new Moneda();
        //                m.idmoneda = dr.GetValue(0).ToString();
        //                m.moneda= dr.GetValue(1).ToString();
        //                oLista.Add(m);
        //            }
        //            return oLista;
        //        }
        //    }
        //}

    }
}
