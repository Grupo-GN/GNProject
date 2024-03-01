using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace BusienssLogic.CA.oProcesarMarcaciones
{
    public class controller_ProcesarMarcaciones
    {
        private static controller_ProcesarMarcaciones Instance = null;
        public static controller_ProcesarMarcaciones Get_Instance() {
            return Instance == null ? Instance = new controller_ProcesarMarcaciones() : Instance;
        }
        public List<tblProcesarMarc> Get_MarcacionesProcesar_By_Personal(string Planilla_Id, string Periodo_Id, string Localidad_Id, string[] Personal_Id, string FechaIni, string FechaFin)
        {
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GNRS_ReporteGeneral_WPP", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<tblProcesarMarc> rList = new List<tblProcesarMarc>();

                    for (int i = 0; i <= Personal_Id.Length - 1; i++)
                    {
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Area_Id", Localidad_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id[i]);
                        cmd.Parameters.AddWithValue("@Fecha_InicialFPS", FechaIni);
                        cmd.Parameters.AddWithValue("@Fecha_FinalFPS", FechaFin);
                        cn.Open();

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            tblProcesarMarc marc = new tblProcesarMarc();
                            marc.TRow = "f";
                            marc.Personal_Id = dr.GetValue(0).ToString();
                            marc.Fecha = dr.GetValue(1).ToString();
                            marc.Dia = dr.GetValue(2).ToString();
                            marc.Localidad = dr.GetValue(3).ToString();
                            marc.DNI = dr.GetValue(4).ToString();
                            marc.Personal = dr.GetValue(5).ToString();
                            marc.HIH = dr.GetValue(6).ToString();
                            marc.HFH = dr.GetValue(7).ToString();
                            marc.HIM = dr.GetValue(8).ToString();
                            marc.HSM = dr.GetValue(9).ToString();
                            marc.TH = dr.GetValue(10).ToString();
                            marc.HET = dr.GetValue(11).ToString();
                            marc.HES = dr.GetValue(12).ToString();
                            marc.HEA = dr.GetValue(13).ToString();
                            marc.HED = dr.GetValue(14).ToString();
                            marc.Falta = dr.GetValue(16).ToString();
                            marc.MinTarde = dr.GetValue(17).ToString();
                            marc.Obser = dr.GetValue(15).ToString();
                            marc.Upda = dr.GetValue(18).ToString();
                            marc.CateAux = dr.GetValue(19).ToString();
                            rList.Add(marc);
                        }

                        #region CALCULANDO EL TODAL DE LAS MARCACIONES
                        int SumHETotal_Horas, SumHETotal_Min, SumHETotal;
                        int SumHESimple_Horas, SumHESimple_Min, SumHESimple;
                        int SumHEAdicional_Horas, SumHEAdicional_Min, SumHEAdicional;
                        int SumHEDoble_Horas, SumHEDoble_Min, SumHEDoble;
                        int SumFalt, SumTard;

                        SumFalt = 0;
                        SumTard = 0;
                        SumHETotal = 0;
                        SumHETotal_Min = 0;
                        SumHETotal_Horas = 0;
                        SumHESimple = 0;
                        SumHESimple_Min = 0;
                        SumHESimple_Horas = 0;
                        SumHEAdicional = 0;
                        SumHEAdicional_Min = 0;
                        SumHEAdicional_Horas = 0;
                        SumHEDoble = 0;
                        SumHEDoble_Min = 0;
                        SumHEDoble_Horas = 0;
                        List<tblProcesarMarc> cList = new List<tblProcesarMarc>();
                        cList = rList.Where(x => x.Personal_Id == Personal_Id[i] && x.TRow != "t").ToList();
                        string HETot, HES, HEA, HED, FAL, TAR, LocalidadTot = "", PersonalTot = "";

                        for (int t = 0; t <= cList.Count() - 1; t++)
                        {
                            LocalidadTot = cList[t].Localidad;
                            PersonalTot = cList[t].Personal;
                            HETot = cList[t].HET.ToString();
                            HES = cList[t].HES.ToString();
                            HEA = cList[t].HEA.ToString();
                            HED = cList[t].HED.ToString();
                            FAL = cList[t].Falta.ToString();
                            TAR = cList[t].MinTarde.ToString();

                            HETot = HETot == "" ? "00:00" : HETot;
                            HES = HES == "" ? "00:00" : HES;
                            HEA = HEA == "" ? "00:00" : HEA;
                            HED = HED == "" ? "00:00" : HED;
                            FAL = FAL == "" ? "0" : "1";
                            TAR = TAR == "" ? "0" : TAR;


                            SumHETotal_Horas = SumHETotal_Horas + int.Parse(HETot.Substring(0, 2));
                            SumHETotal_Min = SumHETotal_Min + int.Parse(HETot.Substring(3, 2));
                            SumHESimple_Horas = SumHESimple_Horas + int.Parse(HES.Substring(0, 2));
                            SumHESimple_Min = SumHESimple_Min + int.Parse(HES.Substring(3, 2));
                            SumHEAdicional_Horas = SumHEAdicional_Horas + int.Parse(HEA.Substring(0, 2));
                            SumHEAdicional_Min = SumHEAdicional_Min + int.Parse(HEA.Substring(3, 2));
                            SumHEDoble_Horas = SumHEDoble_Horas + int.Parse(HED.Substring(0, 2));
                            SumHEDoble_Min = SumHEDoble_Min + int.Parse(HED.Substring(3, 2));
                            SumFalt = SumFalt + int.Parse(FAL);
                            SumTard = SumTard + int.Parse(TAR);
                        }

                        SumHETotal = (SumHETotal_Horas * 60) + SumHETotal_Min;
                        SumHESimple = (SumHESimple_Horas * 60) + SumHESimple_Min;
                        SumHEAdicional = (SumHEAdicional_Horas * 60) + SumHEAdicional_Min;
                        SumHEDoble = (SumHEDoble_Horas * 60) + SumHEDoble_Min;

                        tblProcesarMarc marcTOT = new tblProcesarMarc();
                        marcTOT.TRow = "t";
                        marcTOT.Personal_Id = Personal_Id[i];
                        marcTOT.Localidad = LocalidadTot;
                        marcTOT.DNI = "Total de H.E.";
                        marcTOT.Personal = PersonalTot;
                        marcTOT.HET = (SumHETotal / 60).ToString().PadLeft(2, '0') + ":" + (SumHETotal % 60).ToString().PadLeft(2, '0');
                        marcTOT.HES = (SumHESimple / 60).ToString().PadLeft(2, '0') + ":" + (SumHESimple % 60).ToString().PadLeft(2, '0');
                        marcTOT.HEA = (SumHEAdicional / 60).ToString().PadLeft(2, '0') + ":" + (SumHEAdicional % 60).ToString().PadLeft(2, '0');
                        marcTOT.HED = (SumHEDoble / 60).ToString().PadLeft(2, '0') + ":" + (SumHEDoble % 60).ToString().PadLeft(2, '0');
                        marcTOT.Falta = SumFalt.ToString() + " Dia(s) Falta";
                        marcTOT.MinTarde = SumTard.ToString() + " Min. Tarde";
                        rList.Add(marcTOT);
                        #endregion



                        cmd.Parameters.Clear();
                        cn.Close();
                    }

                    return rList;

                }
            }
        }


    }

    public class tblProcesarMarc
    {
        public string TRow { get; set; }
        public string Personal_Id { get; set; }
        public string Fecha { get; set; }
        public string Dia { get; set; }
        public string Localidad { get; set; }
        public string DNI { get; set; }
        public string Personal { get; set; }
        public string HIH { get; set; }
        public string HFH { get; set; }
        public string HIM { get; set; }
        public string HSM { get; set; }
        public string TH { get; set; }
        public string HET { get; set; }
        public string HES { get; set; }
        public string HEA { get; set; }
        public string HED { get; set; }
        public string Falta { get; set; }
        public string MinTarde { get; set; }
        public string Obser { get; set; }
        public string Upda { get; set; }
        public string CateAux { get; set; }
    }
}
