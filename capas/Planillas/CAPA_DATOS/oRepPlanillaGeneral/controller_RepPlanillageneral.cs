using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using CAPA_ENTIDAD;
using Microsoft.ApplicationBlocks.Data;
using System.Reflection;

namespace CAPA_DATOS.oRepPlanillaGeneral
{
    public class controller_RepPlanillageneral
    {
        public static controller_RepPlanillageneral instance = null;
        public static controller_RepPlanillageneral GetInstance() {
            return instance == null ? instance = new controller_RepPlanillageneral() : instance;
        }
        public List<dtPeriodo> Get_Periodo_Combo(string Compania_Id, string Anio, string Planilla_Id)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("fps_sps_Periodo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vi_Compania_Id", Compania_Id);
                    cmd.Parameters.AddWithValue("@vi_Ejercicio_Id", Anio);
                    cmd.Parameters.AddWithValue("@vi_Planilla_Id", Planilla_Id);
                    cmd.Parameters.AddWithValue("@vi_Estado_Id", "02");
                    List<dtPeriodo> rList = new List<dtPeriodo>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dtPeriodo obj = new dtPeriodo();
                        obj.Periodo_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }

            }
        }
        public ArrayList SISGNRSReporteGeneralPlanilla(string PlanillaId,string Proceso,string PeriodoIni,string PeriodoFin) {
            ArrayList rows = new ArrayList();
           /* string Personal_Id_Masivo = "";
            string Periodo_Id = "";
            string Proceso_Id = "";
            int cantPersonal = 0;
            
            #region ant
            if (PeriodoIni == PeriodoFin)
            {
                List<string> perList = new List<string>();
                perList = SISGNRSReporteGeneralPlanilla_GetPersonal("01", PeriodoIni, "");
                for (int p = 0; p <= perList.Count - 1; p++) {
                    Personal_Id_Masivo +=perList[p]+ "|";
                }
                if (Personal_Id_Masivo.Trim() != "") {
                    Personal_Id_Masivo = Personal_Id_Masivo.Remove(Personal_Id_Masivo.Length -1 , 1);
                }
                Periodo_Id = PeriodoIni;
                Proceso_Id = Proceso;
                cantPersonal = perList.Count;
                Lista_ActivarLevel80();
               
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand("fps_Reporte_Boleta", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@vi_Personal_Id_Masivo", Personal_Id_Masivo);
                            cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                            cmd.Parameters.AddWithValue("@vi_Proceso_Id", Proceso_Id);
                            cmd.Parameters.AddWithValue("@vi_CantPersonal", cantPersonal);
                            cmd.CommandTimeout = 5000;
                            cn.Open();

                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                object dat = new
                                {
                                    Razon_Social = dr.GetValue(0).ToString(),
                                    Direccion_cia = dr.GetValue(1).ToString(),
                                    RUC = dr.GetValue(2).ToString(),
                                    Reg_Patronal = dr.GetValue(3).ToString(),
                                    Telefono = dr.GetValue(4).ToString(),
                                    Proceso = dr.GetValue(5).ToString(),
                                    CCosto_Id = dr.GetValue(6).ToString(),
                                    Planilla_Id = dr.GetValue(7).ToString(),
                                    TipoTrabajador = dr.GetValue(8).ToString(),
                                    Catego = dr.GetValue(9).ToString(),
                                    Catego2 = dr.GetValue(10).ToString(),
                                    Area = dr.GetValue(11).ToString(),
                                    Personal_Id = dr.GetValue(12).ToString(),
                                    Nombre_Completo = dr.GetValue(13).ToString(),
                                    Periodo_Id = dr.GetValue(14).ToString(),
                                    Periodo = dr.GetValue(15).ToString(),
                                    AnoMes = dr.GetValue(16).ToString(),
                                    Cargo_Id = dr.GetValue(17).ToString(),
                                    Cargo = dr.GetValue(18).ToString(),
                                    AFP_Id = dr.GetValue(19).ToString(),
                                    AFP = dr.GetValue(20).ToString(),
                                    Fecha_Ingreso = dr.GetValue(21).ToString(),
                                    Fecha_Nacimiento = dr.GetValue(22).ToString(),
                                    Fecha_Cese = dr.GetValue(23).ToString(),
                                    Proceso_Id = dr.GetValue(24).ToString(),
                                    Direccion = dr.GetValue(25).ToString(),
                                    Tipo_Doc_Id = dr.GetValue(26).ToString(),
                                    Nro_Doc = dr.GetValue(27).ToString(),
                                    Afp_Cod_Afiliacion = dr.GetValue(28).ToString(),
                                    Seguro_Cod = dr.GetValue(29).ToString(),
                                    HOR230 = dr.GetValue(30).ToString(),
                                    HOR35 = dr.GetValue(31).ToString(),
                                    HORDOB = dr.GetValue(32).ToString(),
                                    Fecha_Fin_Contrato = dr.GetValue(33).ToString(),
                                    Fecha_Ini_Periodo = dr.GetValue(34).ToString(),
                                    Fecha_Fin_Periodo = dr.GetValue(35).ToString(),
                                    Concepto_Id1 = dr.GetValue(36).ToString(),
                                    Valor1 = dr.GetValue(37).ToString(),
                                    Concepto_Id2 = dr.GetValue(38).ToString(),
                                    Valor2 = dr.GetValue(39).ToString(),
                                    Concepto_Id3 = dr.GetValue(40).ToString(),
                                    Valor3 = dr.GetValue(41).ToString(),
                                    NroHrsExt = dr.GetValue(42).ToString(),
                                    NroHrsExtN = dr.GetValue(43).ToString(),
                                    NroHrsExtT = dr.GetValue(44).ToString(),
                                    TotHoras = dr.GetValue(45).ToString(),
                                    TotHoras1 = dr.GetValue(46).ToString(),
                                    TotHoras2 = dr.GetValue(47).ToString(),
                                    TotHoras3 = dr.GetValue(48).ToString(),
                                    TotDM = dr.GetValue(49).ToString(),
                                    TotDMS = dr.GetValue(50).ToString(),
                                    FechaINIvaca = dr.GetValue(51).ToString(),
                                    FechaFINvaca = dr.GetValue(52).ToString(),
                                    PerFecIni = dr.GetValue(53).ToString(),
                                    PerFecFin = dr.GetValue(54).ToString(),
                                    Sueldo_Mes = dr.GetValue(55).ToString(),
                                    Tipo_Cambio = dr.GetValue(56).ToString(),
                                    Situacion = dr.GetValue(57).ToString(),
                                    Ingresos_Afectos = dr.GetValue(58).ToString(),
                                    Ctacte_Saldo = dr.GetValue(59).ToString(),
                                    Ctacte_Cuotas = dr.GetValue(60).ToString(),
                                    Ctacte_TotalDeuda = dr.GetValue(61).ToString(),
                                    Total_Ingresos = dr.GetValue(62).ToString(),
                                    Total_Descuentos = dr.GetValue(63).ToString(),
                                    Total_Aportes = dr.GetValue(64).ToString(),
                                    Total_Netos = dr.GetValue(65).ToString(),
                                    Bancos = dr.GetValue(66).ToString(),
                                    Cuenta = dr.GetValue(67).ToString()
                                    
                                    
                                };
                                rList.Add(dat);
                            }
                            return rList;
                        }
                    }
            }
            else {
                
                List<string> pList = new List<string>();
                pList = SISGNRSReporteGeneralPlanilla_GetPersonal("02", PeriodoIni, PeriodoFin);
                for (int g = 0; g <= pList.Count - 1; g++)
                {

                    string periodoAct = pList[g];
                    Personal_Id_Masivo = "";
                    List<string> perList = new List<string>();
                    perList = SISGNRSReporteGeneralPlanilla_GetPersonal("01", periodoAct, "");
                    for (int p = 0; p <= perList.Count - 1; p++)
                    {
                        Personal_Id_Masivo += perList[p] + "|";
                    }
                    if (Personal_Id_Masivo.Trim() != "")
                    {
                        Personal_Id_Masivo = Personal_Id_Masivo.Remove(Personal_Id_Masivo.Length - 1, 1);
                    }
                    Periodo_Id = PeriodoIni;
                    Proceso_Id = Proceso;
                    cantPersonal = perList.Count;
                    Lista_ActivarLevel80();
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand("fps_Reporte_Boleta", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@vi_Personal_Id_Masivo", Personal_Id_Masivo);
                            cmd.Parameters.AddWithValue("@vi_Periodo_Id", Periodo_Id);
                            cmd.Parameters.AddWithValue("@vi_Proceso_Id", Proceso_Id);
                            cmd.Parameters.AddWithValue("@vi_CantPersonal", cantPersonal);
                            cmd.CommandTimeout = 5000;
                            cn.Open();

                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                object dat = new
                                {
                                    Razon_Social = dr.GetValue(0).ToString(),
                                    Direccion_cia = dr.GetValue(1).ToString(),
                                    RUC = dr.GetValue(2).ToString(),
                                    Reg_Patronal = dr.GetValue(3).ToString(),
                                    Telefono = dr.GetValue(4).ToString(),
                                    Proceso = dr.GetValue(5).ToString(),
                                    CCosto_Id = dr.GetValue(6).ToString(),
                                    Planilla_Id = dr.GetValue(7).ToString(),
                                    TipoTrabajador = dr.GetValue(8).ToString(),
                                    Catego = dr.GetValue(9).ToString(),
                                    Catego2 = dr.GetValue(10).ToString(),
                                    Area = dr.GetValue(11).ToString(),
                                    Personal_Id = dr.GetValue(12).ToString(),
                                    Nombre_Completo = dr.GetValue(13).ToString(),
                                    Periodo_Id = dr.GetValue(14).ToString(),
                                    Periodo = dr.GetValue(15).ToString(),
                                    AnoMes = dr.GetValue(16).ToString(),
                                    Cargo_Id = dr.GetValue(17).ToString(),
                                    Cargo = dr.GetValue(18).ToString(),
                                    AFP_Id = dr.GetValue(19).ToString(),
                                    AFP = dr.GetValue(20).ToString(),
                                    Fecha_Ingreso = dr.GetValue(21).ToString(),
                                    Fecha_Nacimiento = dr.GetValue(22).ToString(),
                                    Fecha_Cese = dr.GetValue(23).ToString(),
                                    Proceso_Id = dr.GetValue(24).ToString(),
                                    Direccion = dr.GetValue(25).ToString(),
                                    Tipo_Doc_Id = dr.GetValue(26).ToString(),
                                    Nro_Doc = dr.GetValue(27).ToString(),
                                    Afp_Cod_Afiliacion = dr.GetValue(28).ToString(),
                                    Seguro_Cod = dr.GetValue(29).ToString(),
                                    HOR230 = dr.GetValue(30).ToString(),
                                    HOR35 = dr.GetValue(31).ToString(),
                                    HORDOB = dr.GetValue(32).ToString(),
                                    Fecha_Fin_Contrato = dr.GetValue(33).ToString(),
                                    Fecha_Ini_Periodo = dr.GetValue(34).ToString(),
                                    Fecha_Fin_Periodo = dr.GetValue(35).ToString(),
                                    Concepto_Id1 = dr.GetValue(36).ToString(),
                                    Valor1 = dr.GetValue(37).ToString(),
                                    Concepto_Id2 = dr.GetValue(38).ToString(),
                                    Valor2 = dr.GetValue(39).ToString(),
                                    Concepto_Id3 = dr.GetValue(40).ToString(),
                                    Valor3 = dr.GetValue(41).ToString(),
                                    NroHrsExt = dr.GetValue(42).ToString(),
                                    NroHrsExtN = dr.GetValue(43).ToString(),
                                    NroHrsExtT = dr.GetValue(44).ToString(),
                                    TotHoras = dr.GetValue(45).ToString(),
                                    TotHoras1 = dr.GetValue(46).ToString(),
                                    TotHoras2 = dr.GetValue(47).ToString(),
                                    TotHoras3 = dr.GetValue(48).ToString(),
                                    TotDM = dr.GetValue(49).ToString(),
                                    TotDMS = dr.GetValue(50).ToString(),
                                    FechaINIvaca = dr.GetValue(51).ToString(),
                                    FechaFINvaca = dr.GetValue(52).ToString(),
                                    PerFecIni = dr.GetValue(53).ToString(),
                                    PerFecFin = dr.GetValue(54).ToString(),
                                    Sueldo_Mes = dr.GetValue(55).ToString(),
                                    Tipo_Cambio = dr.GetValue(56).ToString(),
                                    Situacion = dr.GetValue(57).ToString(),
                                    Ingresos_Afectos = dr.GetValue(58).ToString(),
                                    Ctacte_Saldo = dr.GetValue(59).ToString(),
                                    Ctacte_Cuotas = dr.GetValue(60).ToString(),
                                    Ctacte_TotalDeuda = dr.GetValue(61).ToString(),
                                    Total_Ingresos = dr.GetValue(62).ToString(),
                                    Total_Descuentos = dr.GetValue(63).ToString(),
                                    Total_Aportes = dr.GetValue(64).ToString(),
                                    Total_Netos = dr.GetValue(65).ToString(),
                                    Bancos = dr.GetValue(66).ToString(),
                                    Cuenta = dr.GetValue(67).ToString()
                                };
                                rList.Add(dat);
                            }
                        }
                    }

                }
            }
                #endregion*/
                string concetosA = "";
                string concetosB = "";
                string concetosC = "";
                int cantC = 0;
                List<string> conList = new List<string>();
                conList = SISGNRSReporteGeneralPlanilla_GetPersonal("03", PeriodoIni, "",Proceso);
                cantC = conList.Count;
                if (cantC == 0) {
                    return rows;
                }
                for (int h = 0; h <= conList.Count - 1; h++) {
                    concetosA += conList[h].Split('-')[0].ToString()+",";
                    concetosB += conList[h].Split('-')[1].ToString() + ",";
                    concetosC += conList[h].Split('-')[2].ToString() + ",";
                }
                concetosA = concetosA.Remove(concetosA.Length - 1, 1);
                concetosB = concetosB.Remove(concetosB.Length - 1, 1);
                concetosC = concetosC.Remove(concetosC.Length - 1, 1);
                DataTable dt = new DataTable();
                Ent_Sustentos objESustentos = new Ent_Sustentos();

                objESustentos.Planilla = PlanillaId;
                objESustentos.PeriodoId = PeriodoIni;
                objESustentos.ConceptoID = concetosA;
                objESustentos.ProcesoID = Proceso;
                objESustentos.CamposPerso = "Planilla_Id,Apellido_Paterno,Apellido_Materno,Nombres";
                objESustentos.CamposConcep = concetosB;
                objESustentos.DetalleConceptos = concetosC;
                objESustentos.CantC = cantC;
                objESustentos.CantP = 4;
                SET_COMPATIBILITY_LEVEL(90);
                dt = GenerarCalculo(objESustentos);
                SET_COMPATIBILITY_LEVEL(80);
                
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    rows.Add(dt.Columns[i].ColumnName);
                }
                foreach (DataRow dataRow in dt.Rows)
                {
                    rows.Add((object)dataRow.ItemArray);
                }
                return rows;
           
        }

        private List<string> SISGNRSReporteGeneralPlanilla_GetPersonal(string Proceso,string PeriodoId,string PeriodoFin,string ProcesoDatos) {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SISGNRSUtilDatosReportePlanillaGeneral", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Proc", Proceso);
                    cmd.Parameters.AddWithValue("@PeriodoIni", PeriodoId);
                    cmd.Parameters.AddWithValue("@PeriodoFin", PeriodoFin);
                    cmd.Parameters.AddWithValue("@Proceso", ProcesoDatos);
                    List<string> rList = new List<string>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rList.Add(dr.GetValue(0).ToString());
                    }
                    return rList;
                }
            }
        }
        public void Lista_ActivarLevel80()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EjecutarLevel80", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    int RES;
                    RES = cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        public ArrayList SISGNRSReportePrueba()
        {
            DataTable dt = new DataTable();
            Ent_Sustentos objESustentos = new Ent_Sustentos();



            objESustentos.Planilla = "01";
            objESustentos.PeriodoId = "0011";
            objESustentos.ConceptoID = "000001,000007,000072";
            objESustentos.ProcesoID = "01";
            objESustentos.CamposPerso = "Planilla_Id,Apellido_Paterno,Apellido_Materno,Nombres";
            objESustentos.CamposConcep = "D_BASICO,D_FLAG_ASIGNACION_FAMILIAR,D_FLAG_SEGURO_SALUD";
            objESustentos.DetalleConceptos = "BASICO,FLAG ASIG FAMILIAR,nD_FLAG_SEGURO_SALUD";
            objESustentos.CantC = 3;
            objESustentos.CantP = 4;
            SET_COMPATIBILITY_LEVEL(90);
            dt = GenerarCalculo(objESustentos);
            SET_COMPATIBILITY_LEVEL(80);
            ArrayList rows = new ArrayList();
            for (int i = 0; i <= dt.Columns.Count - 1; i++) {
                rows.Add(dt.Columns[i].ColumnName);
            }
                foreach (DataRow dataRow in dt.Rows)
                {
                    rows.Add((object)dataRow.ItemArray);
                }

            return rows;
        }
        public static void SET_COMPATIBILITY_LEVEL(int level)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(Conex.CadCon(), "fps_alter_BDCompatibilityLevel", level);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable GenerarCalculo(Ent_Sustentos objEN)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Calculos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@planillaID", objEN.Planilla);
                        cmd.Parameters.AddWithValue("@periodoID", objEN.PeriodoId);
                        cmd.Parameters.AddWithValue("@conceptoID", objEN.ConceptoID);
                        cmd.Parameters.AddWithValue("@procesoID", objEN.ProcesoID);
                        cmd.Parameters.AddWithValue("@CamposPerso", objEN.CamposPerso);
                        cmd.Parameters.AddWithValue("@camposConcepto", objEN.CamposConcep);
                        cmd.Parameters.AddWithValue("@DescripcionConceptos", objEN.DetalleConceptos);
                        cmd.Parameters.AddWithValue("@CANTC", objEN.CantC);
                        cmd.Parameters.AddWithValue("@CANTP", objEN.CantP);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }

                /*return SqlHelper.ExecuteDataTable(Conex.CadCon(), "sp_Calculos",
                    objEN.Planilla,
                    objEN.PeriodoId,
                    objEN.ConceptoID,
                    objEN.ProcesoID,
                    objEN.CamposPerso,
                    objEN.CamposConcep,
                    objEN.DetalleConceptos,
                    objEN.CantC,
                    objEN.CantP);*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
    public class dtPeriodo {
        public string Periodo_Id { get; set; }
        public string Descripcion { get; set; }
    }

}
