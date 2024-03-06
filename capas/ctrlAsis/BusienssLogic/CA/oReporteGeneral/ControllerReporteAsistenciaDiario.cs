using Presistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BusienssLogic.CA.oReporteGeneral
{
    public class ControllerReporteAsistenciaDiario
    {
        private static ControllerReporteAsistenciaDiario Instance = null;
        string ConStr = Presistence.Customs.Conexion.getConexion();
        public static ControllerReporteAsistenciaDiario Get_Instance()
        {
            return Instance == null ? Instance = new ControllerReporteAsistenciaDiario() : Instance;
        }

       public  class ReporteDiario
        {
          public int Asistencia_Id { set; get; }
           public string Personal_Id  { set; get; }
            public string Planilla { set; get; }
            public string Periodo { set; get; }
            public string Localidad { set; get; }
            public string Area { set; get; }
            public string CateAux2 { set; get; }
            public string NroDoc { set; get; }
            public string Personal { set; get; }
            public float sueldo { set; get; }
            public string TotHE { set; get; }
            public string TotHESimpl { set; get; }
            public string TotHEAdi { set; get; }
            public string TotHEDob { set; get; }
            public string FALTAS { set; get; }
            public string MinTarde { set; get; }
            public string DiasPer { set; get; }
            public string HorasPer { set; get; }
            public string HESimpleFijos { set; get; }
            public string HEAdiFijos { set; get; }
            public string HEDobFijos { set; get; }
            public string FatFijos { set; get; }
            public string MinTarFijos { set; get; }
            public string DiasPer_DesMed { set; get; }
            public string DiasPer_PerDia { set; get; }
            public string DiasPer_Vac { set; get; }
            public string D1 { set; get; }
            public string D2 { set; get; }
            public string D3 { set; get; }
            public string D4 { set; get; }
            public string D5 { set; get; }
            public string D6 { set; get; }
            public string D7 { set; get; }
            public string D8 { set; get; }
            public string D9 { set; get; }
            public string D10 { set; get; }
            public string D11 { set; get; }
            public string D12 { set; get; }
            public string D13 { set; get; }
            public string D14 { set; get; }
            public string D15 { set; get; }
            public string D16 { set; get; }
            public string D17 { set; get; }
            public string D18 { set; get; }
            public string D19 { set; get; }
            public string D20 { set; get; }
            public string D21 { set; get; }
            public string D22 { set; get; }
            public string D23 { set; get; }
            public string D24 { set; get; }
            public string D25 { set; get; }
            public string D26 { set; get; }
            public string D27 { set; get; }
            public string D28 { set; get; }
            public string D29 { set; get; }
            public string D30 { set; get; }
            public string D31 { set; get; }

        }





        DataTable RUNTABLA(string NOMPRO, params object[] Lista)
        {

            var cn = new SqlConnection(ConStr);
            //CREAR UN COMANDO PARA EJECUTAR EL PROCEDIMIENTO
            SqlCommand CMD = new SqlCommand(NOMPRO, cn);
            //SqlParameter PRM=new  SqlParameter();
            CMD.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //PREPARAR AL COMANDO PARA QUE RECIBA VALORES
            SqlCommandBuilder.DeriveParameters(CMD);
            //ASIGNAR LOS VALORES A LOS PARAMETERS RESPECTIVO
            int CONTADOR = 0;
            //EXEC SPFECHA '12/11/96','10/11/98'
            //EQUIVALE LISTA(0)='12/11/96' LISTA(1)='10/11/98'
            foreach (SqlParameter PRM in CMD.Parameters)
            {
                if (PRM.ParameterName != "@RETURN_VALUE")
                {

                    PRM.Value = Lista[CONTADOR];
                    CONTADOR = CONTADOR + 1;
                }
            }

            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            cn.Close();
            return DT;

        }


        //public ArrayList ListaBolsaHorasComp(string Personal_Id)
        //{
        //    DataTable dt = new DataTable();
        //    dt = RUNTABLA("SP_LISTA_BOLSACOMP", Personal_Id);
        //    ArrayList myArrayList = new ArrayList();
        //    myArrayList = ConvertListaBolsaHorasComp(dt);
        //    return myArrayList;
        //}

        //ArrayList ConvertListaBolsaHorasComp(DataTable dt)
        //{
        //    ArrayList myArrayList = new ArrayList();
        //    List<HorasExtras> glist = new List<HorasExtras>();

        //    foreach (DataRow item in dt.Rows)
        //    {
        //        HorasExtras HE = new HorasExtras();
        //        HE.Personal = item[0].ToString();
        //        HE.fecha_asistencia = item[1].ToString();
        //        HE.HoraInicioHorario = item[2].ToString();
        //        HE.HoraFinalHorario = item[3].ToString();
        //        HE.Hora_Ingreso = item[4].ToString();
        //        HE.Hora_Salida = item[5].ToString();
        //        HE.HETotal = item[6].ToString();
        //        HE.HESimples = item[7].ToString();
        //        HE.HEAdicionales = item[8].ToString();
        //        HE.HEDobles = item[9].ToString();
        //        HE.Planilla = item[10].ToString();
        //        HE.Periodo = item[11].ToString();
        //        HE.Localidad = item[12].ToString();
        //        HE.Area = item[13].ToString();
        //        HE.CatAuxiliar2 = item[14].ToString();
        //        HE.Estado = item[15].ToString();
        //        HE.fecha_registro = item[16].ToString();
        //        HE.Tipo = item[17].ToString();
        //        glist.Add(HE);

        //    }
        //    myArrayList.AddRange(glist);
        //    return myArrayList;
        //}
 
        public   List<ReporteDiario> ListaReporteDiario(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id)
        {
          
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ReporteDiario> rlist = new List<ReporteDiario>();
                string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                    int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                    string FechaIni = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Inicio.ToString("yyyy-MM-dd");
                    string FechaFin = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Fin.ToString("yyyy-MM-dd");

                    string SPnom = string.Empty;
                    SPnom = "SP_GNRS_ResumenNuevo";
                    

                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (Personal_Id.Count() == 0)
                            {
                                cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                                cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                                cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                                cmd.Parameters.AddWithValue("@Personal_Id", "");
                                //cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                cmd.Parameters.AddWithValue("@Fecha_InicialFPS", FechaIni);
                                cmd.Parameters.AddWithValue("@Fecha_FinalFPS", FechaFin);
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    ReporteDiario nov = new ReporteDiario();
                                    nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                    nov.Personal_Id =   dr.GetValue(1).ToString();
                                    nov.Planilla =      dr.GetValue(2).ToString();
                                    nov.Periodo =       dr.GetValue(3).ToString();
                                    nov.Localidad =     dr.GetValue(4).ToString();
                                    nov.Area =          dr.GetValue(5).ToString();
                                    nov.CateAux2 =   dr.GetValue(6).ToString();
                                    nov.NroDoc =      dr.GetValue(7).ToString();
                                    nov.Personal =       dr.GetValue(8).ToString();
                                    nov.sueldo =     float.Parse(dr.GetValue(9).ToString());
                                    nov.TotHE =          dr.GetValue(10).ToString();
                                    nov.TotHESimpl =   dr.GetValue(11).ToString();
                                    nov.TotHEAdi =      dr.GetValue(12).ToString();
                                    nov.TotHEDob =       dr.GetValue(13).ToString();
                                    nov.FALTAS =     dr.GetValue(14).ToString();
                                    nov.MinTarde =     dr.GetValue(15).ToString();
                                    nov.DiasPer =          dr.GetValue(16).ToString();
                                    nov.HorasPer =   dr.GetValue(17).ToString();
                                    nov.HESimpleFijos =      dr.GetValue(18).ToString();
                                    nov.HEAdiFijos =       dr.GetValue(19).ToString();
                                    nov.HEDobFijos =     dr.GetValue(20).ToString();
                                    nov.FatFijos =          dr.GetValue(21).ToString();
                                    nov.MinTarFijos =   dr.GetValue(22).ToString();
                                    nov.DiasPer_DesMed =      dr.GetValue(23).ToString();
                                    nov.DiasPer_PerDia =       dr.GetValue(24).ToString();
                                    nov.DiasPer_Vac =     dr.GetValue(25).ToString();
                                    nov.D1 =          dr.GetValue(26).ToString();
                                    nov.D2 =   dr.GetValue(27).ToString();
                                    nov.D3 =      dr.GetValue(28).ToString();
                                    nov.D4 =       dr.GetValue(29).ToString();
                                    nov.D5 =     dr.GetValue(30).ToString();
                                    nov.D6 =          dr.GetValue(31).ToString();
                                    nov.D7 =   dr.GetValue(32).ToString();
                                    nov.D8 =      dr.GetValue(33).ToString();
                                    nov.D9 =       dr.GetValue(34).ToString();
                                    nov.D10 =     dr.GetValue(35).ToString();
                                    nov.D11 =          dr.GetValue(36).ToString();
                                    nov.D12 =   dr.GetValue(37).ToString();
                                    nov.D13 =      dr.GetValue(38).ToString();
                                    nov.D14 =       dr.GetValue(39).ToString();
                                    nov.D15 =     dr.GetValue(40).ToString();
                                    nov.D16 =          dr.GetValue(41).ToString();
                                    nov.D17 =   dr.GetValue(42).ToString();
                                    nov.D18 =      dr.GetValue(43).ToString();
                                    nov.D19 =       dr.GetValue(44).ToString();
                                    nov.D20 =     dr.GetValue(45).ToString();
                                    nov.D21 =          dr.GetValue(46).ToString();
                                    nov.D22 =   dr.GetValue(47).ToString();
                                    nov.D23 =      dr.GetValue(48).ToString();
                                    nov.D24 =       dr.GetValue(49).ToString();
                                    nov.D25 =     dr.GetValue(50).ToString();
                                    nov.D26 =          dr.GetValue(51).ToString();
                                    nov.D27 =   dr.GetValue(52).ToString();
                                    nov.D28 =      dr.GetValue(53).ToString();
                                    nov.D29 =       dr.GetValue(54).ToString();
                                    nov.D30 =     dr.GetValue(55).ToString();
                                    nov.D31 =          dr.GetValue(56).ToString();
                                  
                                    


                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();

                            }
                            else
                            {


                                for (int i = 0; i <= Personal_Id.Count() - 1; i++)
                                {


                                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                                    cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                    //cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                    cmd.Parameters.AddWithValue("@Fecha_InicialFPS", FechaIni);
                                    cmd.Parameters.AddWithValue("@Fecha_FinalFPS", FechaFin);
                                    cn.Open();
                                    SqlDataReader dr = cmd.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        ReporteDiario nov = new ReporteDiario();
                                        nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                        nov.Personal_Id = dr.GetValue(1).ToString();
                                        nov.Planilla = dr.GetValue(2).ToString();
                                        nov.Periodo = dr.GetValue(3).ToString();
                                        nov.Localidad = dr.GetValue(4).ToString();
                                        nov.Area = dr.GetValue(5).ToString();
                                        nov.CateAux2 = dr.GetValue(6).ToString();
                                        nov.NroDoc = dr.GetValue(7).ToString();
                                        nov.Personal = dr.GetValue(8).ToString();
                                        nov.sueldo = float.Parse(dr.GetValue(9).ToString());
                                        nov.TotHE = dr.GetValue(10).ToString();
                                        nov.TotHESimpl = dr.GetValue(11).ToString();
                                        nov.TotHEAdi = dr.GetValue(12).ToString();
                                        nov.TotHEDob = dr.GetValue(13).ToString();
                                        nov.FALTAS = dr.GetValue(14).ToString();
                                        nov.MinTarde = dr.GetValue(15).ToString();
                                        nov.DiasPer = dr.GetValue(16).ToString();
                                        nov.HorasPer = dr.GetValue(17).ToString();
                                        nov.HESimpleFijos = dr.GetValue(18).ToString();
                                        nov.HEAdiFijos = dr.GetValue(19).ToString();
                                        nov.HEDobFijos = dr.GetValue(20).ToString();
                                        nov.FatFijos = dr.GetValue(21).ToString();
                                        nov.MinTarFijos = dr.GetValue(22).ToString();
                                        nov.DiasPer_DesMed = dr.GetValue(23).ToString();
                                        nov.DiasPer_PerDia = dr.GetValue(24).ToString();
                                        nov.DiasPer_Vac = dr.GetValue(25).ToString();
                                        nov.D1 = dr.GetValue(26).ToString();
                                        nov.D2 = dr.GetValue(27).ToString();
                                        nov.D3 = dr.GetValue(28).ToString();
                                        nov.D4 = dr.GetValue(29).ToString();
                                        nov.D5 = dr.GetValue(30).ToString();
                                        nov.D6 = dr.GetValue(31).ToString();
                                        nov.D7 = dr.GetValue(32).ToString();
                                        nov.D8 = dr.GetValue(33).ToString();
                                        nov.D9 = dr.GetValue(34).ToString();
                                        nov.D10 = dr.GetValue(35).ToString();
                                        nov.D11 = dr.GetValue(36).ToString();
                                        nov.D12 = dr.GetValue(37).ToString();
                                        nov.D13 = dr.GetValue(38).ToString();
                                        nov.D14 = dr.GetValue(39).ToString();
                                        nov.D15 = dr.GetValue(40).ToString();
                                        nov.D16 = dr.GetValue(41).ToString();
                                        nov.D17 = dr.GetValue(42).ToString();
                                        nov.D18 = dr.GetValue(43).ToString();
                                        nov.D19 = dr.GetValue(44).ToString();
                                        nov.D20 = dr.GetValue(45).ToString();
                                        nov.D21 = dr.GetValue(46).ToString();
                                        nov.D22 = dr.GetValue(47).ToString();
                                        nov.D23 = dr.GetValue(48).ToString();
                                        nov.D24 = dr.GetValue(49).ToString();
                                        nov.D25 = dr.GetValue(50).ToString();
                                        nov.D26 = dr.GetValue(51).ToString();
                                        nov.D27 = dr.GetValue(52).ToString();
                                        nov.D28 = dr.GetValue(53).ToString();
                                        nov.D29 = dr.GetValue(54).ToString();
                                        nov.D30 = dr.GetValue(55).ToString();
                                        nov.D31 = dr.GetValue(56).ToString();
                                        rlist.Add(nov);
                                    }
                                    cmd.Parameters.Clear();
                                    cn.Close();


                                }

                            }

                        }
                    }

                }
                return rlist.OrderBy(o => o.Personal).ToList();
                
            }

        }



        public List<ReporteDiario> ListaReporteDiario2(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id,string FechaIni,string FechaFin)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ReporteDiario> rlist = new List<ReporteDiario>();
                string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                    int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                    //string FechaIni = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Inicio.ToString("yyyy-MM-dd");
                    //string FechaFin = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Fin.ToString("yyyy-MM-dd");

                    string SPnom = string.Empty;
                    SPnom = "SP_GNRS_ResumenNuevo";


                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (Personal_Id.Count() == 0)
                            {
                                cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                                cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                                cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                                cmd.Parameters.AddWithValue("@Personal_Id", "");
                                //cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                cmd.Parameters.AddWithValue("@Fecha_InicialFPS", DateTime.Parse( FechaIni).ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@Fecha_FinalFPS", DateTime.Parse(FechaFin).ToString("yyyy-MM-dd"));
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    ReporteDiario nov = new ReporteDiario();
                                    nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                    nov.Personal_Id = dr.GetValue(1).ToString();
                                    nov.Planilla = dr.GetValue(2).ToString();
                                    nov.Periodo = dr.GetValue(3).ToString();
                                    nov.Localidad = dr.GetValue(4).ToString();
                                    nov.Area = dr.GetValue(5).ToString();
                                    nov.CateAux2 = dr.GetValue(6).ToString();
                                    nov.NroDoc = dr.GetValue(7).ToString();
                                    nov.Personal = dr.GetValue(8).ToString();
                                    nov.sueldo = float.Parse(dr.GetValue(9).ToString());
                                    nov.TotHE = dr.GetValue(10).ToString();
                                    nov.TotHESimpl = dr.GetValue(11).ToString();
                                    nov.TotHEAdi = dr.GetValue(12).ToString();
                                    nov.TotHEDob = dr.GetValue(13).ToString();
                                    nov.FALTAS = dr.GetValue(14).ToString();
                                    nov.MinTarde = dr.GetValue(15).ToString();
                                    nov.DiasPer = dr.GetValue(16).ToString();
                                    nov.HorasPer = dr.GetValue(17).ToString();
                                    nov.HESimpleFijos = dr.GetValue(18).ToString();
                                    nov.HEAdiFijos = dr.GetValue(19).ToString();
                                    nov.HEDobFijos = dr.GetValue(20).ToString();
                                    nov.FatFijos = dr.GetValue(21).ToString();
                                    nov.MinTarFijos = dr.GetValue(22).ToString();
                                    nov.DiasPer_DesMed = dr.GetValue(23).ToString();
                                    nov.DiasPer_PerDia = dr.GetValue(24).ToString();
                                    nov.DiasPer_Vac = dr.GetValue(25).ToString();
                                    nov.D1 = dr.GetValue(26).ToString();
                                    nov.D2 = dr.GetValue(27).ToString();
                                    nov.D3 = dr.GetValue(28).ToString();
                                    nov.D4 = dr.GetValue(29).ToString();
                                    nov.D5 = dr.GetValue(30).ToString();
                                    nov.D6 = dr.GetValue(31).ToString();
                                    nov.D7 = dr.GetValue(32).ToString();
                                    nov.D8 = dr.GetValue(33).ToString();
                                    nov.D9 = dr.GetValue(34).ToString();
                                    nov.D10 = dr.GetValue(35).ToString();
                                    nov.D11 = dr.GetValue(36).ToString();
                                    nov.D12 = dr.GetValue(37).ToString();
                                    nov.D13 = dr.GetValue(38).ToString();
                                    nov.D14 = dr.GetValue(39).ToString();
                                    nov.D15 = dr.GetValue(40).ToString();
                                    nov.D16 = dr.GetValue(41).ToString();
                                    nov.D17 = dr.GetValue(42).ToString();
                                    nov.D18 = dr.GetValue(43).ToString();
                                    nov.D19 = dr.GetValue(44).ToString();
                                    nov.D20 = dr.GetValue(45).ToString();
                                    nov.D21 = dr.GetValue(46).ToString();
                                    nov.D22 = dr.GetValue(47).ToString();
                                    nov.D23 = dr.GetValue(48).ToString();
                                    nov.D24 = dr.GetValue(49).ToString();
                                    nov.D25 = dr.GetValue(50).ToString();
                                    nov.D26 = dr.GetValue(51).ToString();
                                    nov.D27 = dr.GetValue(52).ToString();
                                    nov.D28 = dr.GetValue(53).ToString();
                                    nov.D29 = dr.GetValue(54).ToString();
                                    nov.D30 = dr.GetValue(55).ToString();
                                    nov.D31 = dr.GetValue(56).ToString();




                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();

                            }
                            else
                            {


                                for (int i = 0; i <= Personal_Id.Count() - 1; i++)
                                {


                                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                                    cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                    //cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                                    cmd.Parameters.AddWithValue("@Fecha_InicialFPS", DateTime.Parse(FechaIni).ToString("yyyy-MM-dd"));
                                    cmd.Parameters.AddWithValue("@Fecha_FinalFPS", DateTime.Parse(FechaFin).ToString("yyyy-MM-dd"));
                                    cn.Open();
                                    SqlDataReader dr = cmd.ExecuteReader();
                                    while (dr.Read())
                                    {
                                        ReporteDiario nov = new ReporteDiario();
                                        nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                        nov.Personal_Id = dr.GetValue(1).ToString();
                                        nov.Planilla = dr.GetValue(2).ToString();
                                        nov.Periodo = dr.GetValue(3).ToString();
                                        nov.Localidad = dr.GetValue(4).ToString();
                                        nov.Area = dr.GetValue(5).ToString();
                                        nov.CateAux2 = dr.GetValue(6).ToString();
                                        nov.NroDoc = dr.GetValue(7).ToString();
                                        nov.Personal = dr.GetValue(8).ToString();
                                        nov.sueldo = float.Parse(dr.GetValue(9).ToString());
                                        nov.TotHE = dr.GetValue(10).ToString();
                                        nov.TotHESimpl = dr.GetValue(11).ToString();
                                        nov.TotHEAdi = dr.GetValue(12).ToString();
                                        nov.TotHEDob = dr.GetValue(13).ToString();
                                        nov.FALTAS = dr.GetValue(14).ToString();
                                        nov.MinTarde = dr.GetValue(15).ToString();
                                        nov.DiasPer = dr.GetValue(16).ToString();
                                        nov.HorasPer = dr.GetValue(17).ToString();
                                        nov.HESimpleFijos = dr.GetValue(18).ToString();
                                        nov.HEAdiFijos = dr.GetValue(19).ToString();
                                        nov.HEDobFijos = dr.GetValue(20).ToString();
                                        nov.FatFijos = dr.GetValue(21).ToString();
                                        nov.MinTarFijos = dr.GetValue(22).ToString();
                                        nov.DiasPer_DesMed = dr.GetValue(23).ToString();
                                        nov.DiasPer_PerDia = dr.GetValue(24).ToString();
                                        nov.DiasPer_Vac = dr.GetValue(25).ToString();
                                        nov.D1 = dr.GetValue(26).ToString();
                                        nov.D2 = dr.GetValue(27).ToString();
                                        nov.D3 = dr.GetValue(28).ToString();
                                        nov.D4 = dr.GetValue(29).ToString();
                                        nov.D5 = dr.GetValue(30).ToString();
                                        nov.D6 = dr.GetValue(31).ToString();
                                        nov.D7 = dr.GetValue(32).ToString();
                                        nov.D8 = dr.GetValue(33).ToString();
                                        nov.D9 = dr.GetValue(34).ToString();
                                        nov.D10 = dr.GetValue(35).ToString();
                                        nov.D11 = dr.GetValue(36).ToString();
                                        nov.D12 = dr.GetValue(37).ToString();
                                        nov.D13 = dr.GetValue(38).ToString();
                                        nov.D14 = dr.GetValue(39).ToString();
                                        nov.D15 = dr.GetValue(40).ToString();
                                        nov.D16 = dr.GetValue(41).ToString();
                                        nov.D17 = dr.GetValue(42).ToString();
                                        nov.D18 = dr.GetValue(43).ToString();
                                        nov.D19 = dr.GetValue(44).ToString();
                                        nov.D20 = dr.GetValue(45).ToString();
                                        nov.D21 = dr.GetValue(46).ToString();
                                        nov.D22 = dr.GetValue(47).ToString();
                                        nov.D23 = dr.GetValue(48).ToString();
                                        nov.D24 = dr.GetValue(49).ToString();
                                        nov.D25 = dr.GetValue(50).ToString();
                                        nov.D26 = dr.GetValue(51).ToString();
                                        nov.D27 = dr.GetValue(52).ToString();
                                        nov.D28 = dr.GetValue(53).ToString();
                                        nov.D29 = dr.GetValue(54).ToString();
                                        nov.D30 = dr.GetValue(55).ToString();
                                        nov.D31 = dr.GetValue(56).ToString();
                                        rlist.Add(nov);
                                    }
                                    cmd.Parameters.Clear();
                                    cn.Close();


                                }

                            }

                        }
                    }

                }
                return rlist.OrderBy(o => o.Personal).ToList();

            }

        }





        public List<ControlAsistencias> ListaControlAsistencia(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Personal_Id, string FechaIni, string FechaFin)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ControlAsistencias> rlist = new List<ControlAsistencias>();
                string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                    int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                    
                    string SPnom = string.Empty;
                    SPnom = "SP_Control_Asistencia";


                    using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;


                            if (Personal_Id.Count() == 0)
                            {
                                cmd.Parameters.AddWithValue("@planillaid", Planilla_Id);
                                cmd.Parameters.AddWithValue("@periodoid", Periodo_Id);
                                cmd.Parameters.AddWithValue("@localidad", Localidad_Id);
                                cmd.Parameters.AddWithValue("@personalid", Personal_Id);
                               
                                cmd.Parameters.AddWithValue("@fechainicio", DateTime.Parse(FechaIni).ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@fechafin", DateTime.Parse(FechaFin).ToString("yyyy-MM-dd"));
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    ControlAsistencias nov = new ControlAsistencias();
                                    nov.situacion =  dr.GetValue(0).ToString();
                                    nov.nombres = dr.GetValue(1).ToString();
                                    nov.fecha = DateTime.Parse(dr.GetValue(2).ToString()).ToString("yyyy-MM-dd") ;
                                    nov.dni = dr.GetValue(3).ToString();
                                    nov.ingreso = dr.GetValue(4).ToString();
                                    nov.salida = dr.GetValue(5).ToString();
                                    nov.ingresorefrigerio = dr.GetValue(6).ToString();
                                    nov.salidarefrigerio = dr.GetValue(7).ToString();
                                    nov.horaextra = dr.GetValue(8).ToString();
                                    nov.firma =  dr.GetValue(9).ToString();
                                    
                                    rlist.Add(nov);
                                }
                                cmd.Parameters.Clear();
                                cn.Close();

                            }
                            

                        }
                    }

                }
                return rlist.OrderBy(o => o.nombres).ToList();

            }

        }



        public class ControlAsistencias
        {
           
            public string situacion { set; get; }
            public string nombres { set; get; }
            public string fecha { set; get; }
            public string dni { set; get; }
            public string ingreso { set; get; }
            public string salida { set; get; }
            public string ingresorefrigerio { set; get; }
            public string salidarefrigerio { set; get; }
            
            public string horaextra { set; get; }
            public string firma { set; get; }
           
          

        }






    }
}
