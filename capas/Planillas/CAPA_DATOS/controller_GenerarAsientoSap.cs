using CAPA_ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_GenerarAsientoSap
    {
        private static controller_GenerarAsientoSap instace = null;
        public static controller_GenerarAsientoSap getInstance()
        {
            return instace == null ? instace = new controller_GenerarAsientoSap() : instace;
        }
        public List<Ent_ReporteAsientoSap> GenerarAsientosAgrupadoSap(string PeriodoId)
        {
            List<Ent_ReporteAsientoSap> rList = new List<Ent_ReporteAsientoSap>();
            rList.AddRange(GenerarAsientosAgrupadoSap_Unit(PeriodoId, "01").ToList());
            rList.AddRange(GenerarAsientosAgrupadoSap_Unit(PeriodoId, "03").ToList());
            rList.AddRange(GenerarAsientosAgrupadoSap_Unit(PeriodoId, "08").ToList());
            return rList;
        }

        public List<Ent_ReporteAsientoStarSoft> GenerarAsientosAgrupadoStarSoft(string PeriodoId)
        {
            List<Ent_ReporteAsientoStarSoft> rList = new List<Ent_ReporteAsientoStarSoft>();
            rList.AddRange(GenerarAsientosAgrupadoStarSoft_Unit(PeriodoId, "01").ToList());
            rList.AddRange(GenerarAsientosAgrupadoStarSoft_Unit(PeriodoId, "03").ToList());
            rList.AddRange(GenerarAsientosAgrupadoStarSoft_Unit(PeriodoId, "08").ToList());
            return rList;
        }

        private List<Ent_ReporteAsientoSap> GenerarAsientosAgrupadoSap_Unit(string periodoid, string procesoid)
        {
            List<Ent_ReporteAsientoSap> rList = new List<Ent_ReporteAsientoSap>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_AsientosContablesAgrupadosGlosa_Contable_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@periodo", periodoid);
                    cmd.Parameters.AddWithValue("@proceso_id", procesoid);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_ReporteAsientoSap obj = new Ent_ReporteAsientoSap();

                        obj.Proceso = dr.GetValue(2).ToString();
                        obj.CodigoSap = dr.GetValue(3).ToString();
                        obj.NPersonal = dr.GetValue(4).ToString();
                        obj.Cuenta = dr.GetValue(5).ToString();
                        obj.CCosto = dr.GetValue(6).ToString();
                        obj.Codigo = dr.GetValue(7).ToString();
                        obj.Glosa = dr.GetValue(8).ToString();
                        obj.Cargo = decimal.Parse(dr.GetValue(9).ToString());
                        obj.Abono = decimal.Parse(dr.GetValue(10).ToString());
                        rList.Add(obj);
                    }
                }
            }
            return rList;
        }


        private List<Ent_ReporteAsientoStarSoft> GenerarAsientosAgrupadoStarSoft_Unit(string periodoid, string procesoid)
        {
            List<Ent_ReporteAsientoStarSoft> rList = new List<Ent_ReporteAsientoStarSoft>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("spu_AsientosContablesAgrupadosGlosa_Contable_MS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@periodo", periodoid);
                    cmd.Parameters.AddWithValue("@proceso_id", procesoid);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_ReporteAsientoStarSoft obj = new Ent_ReporteAsientoStarSoft();
                        obj.Periodo_Id = dr.GetValue(0).ToString();
                        obj.Planilla = dr.GetValue(1).ToString();
                        obj.Proceso = dr.GetValue(2).ToString();
                        obj.Personal_Id = dr.GetValue(3).ToString();
                        obj.Trabajador = dr.GetValue(4).ToString();
                        obj.CuentaContable = dr.GetValue(5).ToString();
                        obj.CentroCosto = dr.GetValue(6).ToString();
                        obj.Dni = dr.GetValue(7).ToString();
                        obj.Glosa = dr.GetValue(8).ToString();
                        obj.Cargo = double.Parse(dr.GetValue(9).ToString());
                        obj.Abono = double.Parse(dr.GetValue(10).ToString());
                        //20180731
                        obj.EJERCICIO = dr.GetValue(11).ToString();
                        obj.SUBDIARIO = dr.GetValue(12).ToString();
                        obj.COMPROBANTE = dr.GetValue(13).ToString();
                        obj.FECHADOC = dr.GetValue(14).ToString();
                        obj.TIPO_ANEXO = dr.GetValue(15).ToString();
                        obj.CODIGO_ANEXO = dr.GetValue(16).ToString();
                        obj.TIPO_DOC = dr.GetValue(17).ToString();
                        obj.NRO_DOC = dr.GetValue(18).ToString();
                        obj.FECHA_VENC = dr.GetValue(19).ToString();
                        obj.MONEDA = dr.GetValue(20).ToString();
                        obj.CONV = dr.GetValue(21).ToString();
                        obj.FECHA_REG = dr.GetValue(22).ToString();
                        obj.TC = dr.GetValue(23).ToString();
                        obj.GLOSA2 = dr.GetValue(24).ToString();
                        obj.DOC_ANULADO = dr.GetValue(25).ToString();
                        obj.DH = dr.GetValue(26).ToString();
                        obj.MED_PAGO = dr.GetValue(27).ToString();
                        obj.NRO_FILE = dr.GetValue(28).ToString();
                        obj.FLUJO_EFEC = dr.GetValue(29).ToString();
                        obj.MONTO = double.Parse(dr.GetValue(30).ToString());
                        rList.Add(obj);
                    }
                }
            }
            return rList;
        }
    }
}
