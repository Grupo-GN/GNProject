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

namespace BusienssLogic.CA.oCompensaciones
{
  public  class ControllerCompensaciones
    {
        private static ControllerCompensaciones Instance = null;
        string ConStr = Presistence.Customs.Conexion.getConexion();
        public static ControllerCompensaciones Get_Instance()
        {
            return Instance == null ? Instance = new ControllerCompensaciones() : Instance;
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

        ArrayList Convert_DatatableToArraylist(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    myArrayList.Add(dt.Rows[i][j].ToString());
                }
            }
            return myArrayList;
        }

        class Genera 
        {
            public int Marcacion_Id { get; set; }
            public string Personal_Id { get; set; }
            public string Nombres { get; set; }
            public string fecha { get; set; }
            public int cantida { get; set; }
 
        }
        class CompCab
        {

            public int ID { get; set; }
            public string FECHA { get; set; }
            public string M_COMPENSADO { get; set; }
            public string HORA_COMP { get; set; }
            public string ESTADO { get; set; }
            public string MOTIVO { get; set; }
        }

        class HorasExtras
        {
            public int Asistencia_Id { get; set; }
            public string Personal_Id { get; set; }
            public string Personal { get; set; }
            public string fecha_asistencia { get; set; }
            public string HoraInicioHorario { get; set; }
            public string HoraFinalHorario { get; set; }
            public string Hora_Ingreso { get; set; }
            public string Hora_Salida { get; set; }
            public string HETotal { get; set; }
            public string HESimples { get; set; }
            public string HEAdicionales { get; set; }
            public string HEDobles { get; set; }
            public string Planilla { get; set; }
            public string Periodo { get; set; }
            public string Localidad { get; set; }
            public string Area { get; set; }
            public string CatAuxiliar2 { get; set; }
            public string Tipo { get; set; }
            public string Estado { get; set; }
            public int ID { get; set; }
            public string fecha_registro { get; set; }
            public string HETotalbk { get; set; }
        }


        ArrayList Convert_DatatableToArraylist2(DataTable dt,string flat)
        {
            ArrayList myArrayList = new ArrayList();
            List<Genera> glist = new List<Genera>();
            switch (flat)
            {
                case "T" :
                    foreach (DataRow item in dt.Rows)
                    {
                        Genera general = new Genera();
                        general.Marcacion_Id = int.Parse(item[0].ToString());
                        general.Personal_Id = item[1].ToString();
                        general.Nombres = item[2].ToString();
                        general.fecha = item[3].ToString();
                        general.cantida = int.Parse(item[4].ToString());
                        glist.Add(general);

                    }
                    break;
                case "F":
                    foreach (DataRow item in dt.Rows)
                    {
                        Genera general = new Genera();
                        general.Marcacion_Id = int.Parse(item[0].ToString());
                        general.Personal_Id = item[1].ToString();
                        general.Nombres = item[2].ToString();
                        general.fecha = item[3].ToString();
                        general.cantida = int.Parse(item[4].ToString());
                        glist.Add(general);

                    }
                    break;
                case "HL":
                    foreach (DataRow item in dt.Rows)
                    {
                        Genera general = new Genera();
                        
                        general.cantida = int.Parse(item["Can_Horas_Ex"].ToString());
                        glist.Add(general);

                    }
                    break;

            }
            

            myArrayList.AddRange(glist);

            
            return myArrayList;
        }
        ArrayList ConverComCab(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<CompCab> glist = new List<CompCab>();
            foreach (DataRow item in dt.Rows)
            {
                CompCab general = new CompCab();
                general.ID = int.Parse(item[0].ToString());
                general.FECHA = item[1].ToString();
                general.M_COMPENSADO = item[2].ToString();
                general.HORA_COMP = item[3].ToString();
                general.ESTADO =  item[4].ToString();
                general.MOTIVO =  item[5].ToString();
                glist.Add(general);

            }
            myArrayList.AddRange(glist);
            return myArrayList;

        }

        ArrayList ConverComDet(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<CompCab> glist = new List<CompCab>();
            foreach (DataRow item in dt.Rows)
            {
                CompCab general = new CompCab();
                general.ID = int.Parse(item[2].ToString());
                general.FECHA = item[0].ToString();
                general.HORA_COMP =  item[1].ToString();

                glist.Add(general);

            }
            myArrayList.AddRange(glist);
            return myArrayList;

        }
        ArrayList ConvertDetLstHoraExtra(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<HorasExtras> glist = new List<HorasExtras>();
           
            foreach (DataRow item in dt.Rows)
            {
                HorasExtras HE = new HorasExtras();
                HE.Asistencia_Id =      int.Parse(item[0].ToString());
                HE.Personal_Id =        item[1].ToString();
                HE.Personal =           item[2].ToString();
                HE.fecha_asistencia =   item[3].ToString();
                HE.HoraInicioHorario =  item[4].ToString();
                HE.HoraFinalHorario =   item[5].ToString();
                HE.Hora_Ingreso =       item[6].ToString();
                HE.Hora_Salida =        item[7].ToString();
                HE.HETotal =            item[8].ToString();
                HE.HESimples =          item[9].ToString();
                HE.HEAdicionales =      item[10].ToString();
                HE.HEDobles =           item[11].ToString();
                HE.Planilla =           item[12].ToString();
                HE.Periodo =            item[13].ToString();
                HE.Localidad =          item[14].ToString();
                HE.Area =               item[15].ToString();
                HE.CatAuxiliar2 =       item[16].ToString();
                glist.Add(HE);

            }
            myArrayList.AddRange(glist);
            return myArrayList;
        }

        public ArrayList Lista_HoraExtra(string Planilla_Id, string Periodo_Id, string Localidad_Id, string id_personal)
        {
            ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection());

                int periodoca = 0;
                string FechaIni = "";
                string FechaFin = "";
            ArrayList myArrayList = new ArrayList();
            string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                      periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                      FechaIni = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Inicio.ToString("yyyy-MM-dd");
                      FechaFin = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Fin.ToString("yyyy-MM-dd");
                } else { return myArrayList; }
            


            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_GNRS_ResumenHorasExtras", Planilla_Id,Periodo_Id,Localidad_Id,id_personal,FechaIni,FechaFin);

        
            myArrayList = ConvertDetLstHoraExtra(dt);
            //foreach (DataRow dataRow in dt.Rows)  myArrayList.Add(string.Join(";", dataRow.ItemArray.Select(item =>  item.ToString())));

            return myArrayList;
        }

        //listar tardanzas
        public ArrayList Lista_PersonalTardanza(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_Lista_Tardanza", Personal_Id);
           
            ArrayList myArrayList = new ArrayList();
            myArrayList = Convert_DatatableToArraylist2(dt,"T");
            //foreach (DataRow dataRow in dt.Rows)  myArrayList.Add(string.Join(";", dataRow.ItemArray.Select(item =>  item.ToString())));
          
            return myArrayList;
        }

        public ArrayList Lista_HorasLab(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_ListaHorasEx", Personal_Id);

            ArrayList myArrayList = new ArrayList();
            myArrayList = Convert_DatatableToArraylist2(dt,"HL");
            //foreach (DataRow dataRow in dt.Rows)  myArrayList.Add(string.Join(";", dataRow.ItemArray.Select(item =>  item.ToString())));

            return myArrayList;
        }


        //listar tardanzas
        public ArrayList Lista_PersonalFaltas(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_ListarFaltas", Personal_Id);
          
            ArrayList myArrayList = new ArrayList();
            myArrayList = Convert_DatatableToArraylist2(dt,"F");
            return myArrayList;
        }
   
        DataTable Insercompcab(string id_personal,string fecha_compensacion,string mod_conpensacion,int can_compensadas,string motivo,string estado)
        {
            DataTable dt = new DataTable();
            
            dt = RUNTABLA("Sp_InsertCompensaciones", id_personal,fecha_compensacion,mod_conpensacion,can_compensadas,motivo,estado);
            return dt;
        }

        DataTable Insercompdet(int id_compensacion, string fecha_compensada, string fecha_falta, int can_horas_compensadas, int Asistencia_Id)
        {
            DataTable dt = new DataTable();

            dt = RUNTABLA("Sp_CompDet", id_compensacion, fecha_compensada, fecha_falta, can_horas_compensadas, Asistencia_Id);
            return dt;
        }

       // proceso de marcas y actualizacion de he
        DataTable ProcesoHE( string personal_id, string fecha, string modcomp, int horacomp)
        {
            DataTable dt = new DataTable();

            dt = RUNTABLA("SP_ProcesaCompensacion", personal_id, fecha, modcomp, horacomp);
            return dt;
        }

        // cambia de estado
   
        DataTable CambiaEstado(int id_comp, string estado)
        {
            DataTable dt = new DataTable();

            dt = RUNTABLA("sp_Cambia_Estado", id_comp,estado);
            return dt;
        }

        public string UpdateEstado(int id_comp, string estado)
        {
            string str = "";
            DataTable dt = new DataTable();
            dt = CambiaEstado(id_comp, estado);
            foreach (DataRow item in dt.Rows)
            {
                str = item[0].ToString();
            }
            if (estado=="03")
            {
                DataTable dtcd = new DataTable();
                dtcd = cabdetallecomp(id_comp);
                foreach (DataRow dr in dtcd.Rows)
                {
                    DataTable dtd = new DataTable();
                    dtd = ProcesoHE(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse( dr[4].ToString()));
                }
            }
            if (int.Parse(str)>=1)
            {
                return "Exito";
            }
            else
            {
                return "Sin Exito";
            }


        }




        public string Insert_Compensacion(string id_personal, string fecha_compensacion, string mod_conpensacion, int can_compensadas, string motivo, string estado, List<string> Rlist)
        {
            string msg = "";
            DataTable dts = new DataTable();
            dts = Insercompcab(id_personal, fecha_compensacion, mod_conpensacion, can_compensadas, motivo, estado);
            string codcomp = "";
            foreach (DataRow item in dts.Rows)
            {
                codcomp = item[0].ToString();

            }
            if (codcomp=="")
            {
                msg = "Se Cancelo la operación, intente nuevamente";
                return msg;
            }
            else
            {
                string s1;
                string fecha_compensada="";
                string fecha_falta="";
                int can_horas_compensadas=0;
                int Asistencia_Id=0;
                int contador = -1;
                string ms = "";
                DataTable dt = new DataTable();
                foreach (var item in Rlist)
                {
                    contador = -1;
                    s1 = item.ToString();
                    dt = SplitData(s1);
                    foreach (DataRow rw in dt.Rows)
                    {
                        contador = contador + 1;
                        if (contador==0)
                        {
                            can_horas_compensadas = int.Parse( rw[0].ToString());
                        }
                        if (contador == 1)
                        {
                            Asistencia_Id = int.Parse(rw[0].ToString());
                        }
                        if (contador == 2)
                        {
                            fecha_falta =  rw[0].ToString();
                            fecha_compensada = rw[0].ToString();
                        }

                      
                    }
                    DataTable dtdet = new DataTable();
                    dtdet = Insercompdet(int.Parse(codcomp), fecha_compensada, fecha_falta, can_horas_compensadas, Asistencia_Id);
                    foreach (DataRow drs in dtdet.Rows)
                    {
                        ms = drs[0].ToString();
                    }
                    if (estado=="02")
                    {
                    DataTable dtPRoc = new DataTable();
                    dtPRoc = ProcesoHE(id_personal, fecha_compensada, mod_conpensacion, can_compensadas);
                    }
                                    

                }

            }




            return msg;
        }

        DataTable SplitData(string valor)
        {
            DataTable dt = new DataTable();

            dt = RUNTABLA("delimitador", valor);
            return dt;
        }


        public DataTable FunDT(List<string> Rlist)
        {
            
            string s1;
            DataTable dt = new DataTable();
            foreach (var item in Rlist)
            {
                s1 = item.ToString();

                dt = SplitData(s1);

            }
                 return dt;

        }

       


        public ArrayList ListaCompCab(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_ListarCabComp", Personal_Id);

            ArrayList myArrayList = new ArrayList();
            myArrayList = ConverComCab(dt);
            return myArrayList;
        }

        public ArrayList ListaCompdet(int id_comp)
        {
            DataTable dt = new DataTable();
            dt = detallecomp(id_comp);

            ArrayList myArrayList = new ArrayList();
            myArrayList = ConverComDet(dt);
            return myArrayList;
        }

        DataTable detallecomp(int id_comp)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_ListarDetalle", id_comp);
            return dt;

        }

        DataTable cabdetallecomp(int id_comp)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("sp_ListDetCabComp", id_comp);
            return dt;

        }


        /// insert horas en bolsa
        /// 

        public string Insert_Bolsa_HE( List<string> Rlist)
        {
                string msg = "";
                string s1;
               
                int contador = -1;
                string ms = "";
                DataTable dt = new DataTable();
            List<HorasExtras> glistHorasExtras = new List<HorasExtras>();
            if (Rlist.Count <=0)
            {
                return msg ="0";
            }
                foreach (var item in Rlist)
                {
                    contador = -1;
                    s1 = item.ToString();
                    dt = SplitData(s1);
                HorasExtras HE = new HorasExtras();
                foreach (DataRow rw in dt.Rows)
                    {

                    contador = contador + 1;
                 
                   
                    switch (contador)
                    {
                        case 0:
                            // code block
                            HE.Asistencia_Id = int.Parse(rw[0].ToString());
                            break;
                        case 1:
                            // code block
                            HE.Personal_Id = rw[0].ToString();
                            break;
                        case 2:
                            // code block
                            HE.Personal = rw[0].ToString();
                            break;
                        case 3:
                            // code block
                            HE.fecha_asistencia = rw[0].ToString();
                            break;
                        case 4:
                            // code block
                            HE.HoraInicioHorario = rw[0].ToString();
                            break;
                        case 5:
                            // code block
                            HE.HoraFinalHorario = rw[0].ToString();
                            break;
                        case 6:
                            // code block
                            HE.Hora_Ingreso = rw[0].ToString();
                            break;
                        case 7:
                            // code block
                            HE.Hora_Salida = rw[0].ToString();
                            break;
                        case 8:
                            // code block
                            HE.HETotal = rw[0].ToString();
                            break;
                        case 9:
                            // code block
                            HE.HESimples = rw[0].ToString();
                            break;
                        case 10:
                            // code block
                            HE.HEAdicionales = rw[0].ToString();
                            break;
                        case 11:
                            // code block
                            HE.HEDobles = rw[0].ToString();
                            break;
                        case 12:
                            // code block
                            HE.Planilla = rw[0].ToString();
                            break;
                        case 13:
                            // code block
                            HE.Periodo = rw[0].ToString();
                            break;
                        case 14:
                            // code block
                            HE.Localidad = rw[0].ToString();
                            break;
                        case 15:
                            // code block
                            HE.Area = rw[0].ToString();
                            break;
                        case 16:
                            // code block
                            HE.CatAuxiliar2 = rw[0].ToString();
                            break;
                        case 17:
                            // code block
                            HE.Tipo = rw[0].ToString();
                            break;
                    }

                    

                }
                glistHorasExtras.Add(HE);
            }
            if (glistHorasExtras.Count<=0)
            {
                return msg = "0";
            }



            DataTable dtdet = new DataTable();
            dtdet = InsertHE(glistHorasExtras);
            foreach (DataRow drs in dtdet.Rows)
            {
                ms = drs[0].ToString();
            }
            




            return msg;
        }

        DataTable InsertHE(List<HorasExtras> GHE)
        {
            DataTable dt = new DataTable();
            foreach (var item in GHE)
            {
                dt = RUNTABLA("Sp_tbl_Bolsa_Insert", item.Asistencia_Id,item.Personal_Id, item.Personal, item.fecha_asistencia, 
                    item.HoraInicioHorario, item.HoraFinalHorario, item.Hora_Ingreso, item.Hora_Salida, item.HETotal, item.HESimples,
                    item.HEAdicionales, item.HEDobles, item.Planilla, item.Periodo, item.Localidad, item.Area, item.CatAuxiliar2, "01", item.Tipo);
            }

          
            return dt;
        }

        public ArrayList ListaBolsaHorasComp(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("SP_LISTA_BOLSACOMP", Personal_Id);
            ArrayList myArrayList = new ArrayList();
            myArrayList = ConvertListaBolsaHorasComp(dt);
            return myArrayList;
        }

        ArrayList ConvertListaBolsaHorasComp(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<HorasExtras> glist = new List<HorasExtras>();

            foreach (DataRow item in dt.Rows)
            {
                HorasExtras HE = new HorasExtras();
                HE.Personal =           item[0].ToString();
                HE.fecha_asistencia =   item[1].ToString();
                HE.HoraInicioHorario =  item[2].ToString();
                HE.HoraFinalHorario =   item[3].ToString();
                HE.Hora_Ingreso =       item[4].ToString();
                HE.Hora_Salida =        item[5].ToString();
                HE.HETotal =            item[6].ToString();
                HE.HESimples =          item[7].ToString();
                HE.HEAdicionales =      item[8].ToString();
                HE.HEDobles =           item[9].ToString();
                HE.Planilla =           item[10].ToString();
                HE.Periodo =            item[11].ToString();
                HE.Localidad =          item[12].ToString();
                HE.Area =               item[13].ToString();
                HE.CatAuxiliar2 =       item[14].ToString();
                HE.Estado =             item[15].ToString();
                HE.fecha_registro =     item[16].ToString();
                HE.Tipo =               item[17].ToString();
                glist.Add(HE);

            }
            myArrayList.AddRange(glist);
            return myArrayList;
        }

        public ArrayList ListHETotal(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_BolHExtra_Comp", Personal_Id);
            ArrayList myArrayList = new ArrayList();
            myArrayList = ConvertListHETotal(dt);
            return myArrayList;
        }


        ArrayList ConvertListHETotal(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<HorasExtras> glist = new List<HorasExtras>();

            foreach (DataRow item in dt.Rows)
            {
                HorasExtras HE = new HorasExtras();
                HE.Personal = item[4].ToString();
                HE.HETotal = item[0].ToString();
                glist.Add(HE);

            }
            myArrayList.AddRange(glist);
            return myArrayList;
        }

        public ArrayList ListBolDetHE(string Personal_Id)
        {
            DataTable dt = new DataTable();
            dt = RUNTABLA("Sp_DetBolsa", Personal_Id);
            ArrayList myArrayList = new ArrayList();
            myArrayList = ConvertListBolDetHE(dt);
            return myArrayList;
        }

        ArrayList ConvertListBolDetHE(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<HorasExtras> glist = new List<HorasExtras>();

            foreach (DataRow item in dt.Rows)
            {
                HorasExtras HE = new HorasExtras();
                HE.ID = int.Parse(item[0].ToString());
                HE.Personal_Id = item[1].ToString();
                HE.fecha_asistencia= item[2].ToString();
                HE.HETotal = item[3].ToString();
                glist.Add(HE);

            }
            myArrayList.AddRange(glist);
            return myArrayList;
        }







        /// update horas en bolsa
        /// 

        public string Update_Bolsa_HE(List<string> Rlist)
        {
            string msg = "";
            string s1;

            int contador = -1;
            string ms = "";
            DataTable dt = new DataTable();
            List<HorasExtras> glistHorasExtras = new List<HorasExtras>();
            if (Rlist.Count <= 0)
            {
                return msg = "0";
            }
            foreach (var item in Rlist)
            {
                contador = -1;
                s1 = item.ToString();
                dt = SplitData(s1);
                HorasExtras HE = new HorasExtras();
                foreach (DataRow rw in dt.Rows)
                {

                    contador = contador + 1;


                    switch (contador)
                    {
                        case 0:
                            // code block
                            HE.ID = int.Parse(rw[0].ToString());
                            break;
                        case 1:
                            // code block
                            HE.Personal_Id = rw[0].ToString();
                            break;
                        
                        case 2:
                            // code block
                            HE.fecha_asistencia = rw[0].ToString();
                            break;
                         
                        case 3:
                            // code block
                            HE.HETotal = rw[0].ToString();
                            break;
       
                        case 4:
                            // code block
                            HE.Estado = rw[0].ToString();
                            break;
                    }



                }
                glistHorasExtras.Add(HE);
            }
            if (glistHorasExtras.Count <= 0)
            {
                return msg = "0";
            }



            DataTable dtdet = new DataTable();
            dtdet = UpdateHEbolsa(glistHorasExtras);
            foreach (DataRow drs in dtdet.Rows)
            {
                ms = drs[0].ToString();
            }





            return msg;
        }

        DataTable UpdateHEbolsa(List<HorasExtras> GHE)
        {
            DataTable dt = new DataTable();
            foreach (var item in GHE)
            {
                dt = RUNTABLA("Sp_tbl_Bolsa_Insert", item.Asistencia_Id, item.Personal_Id, item.Personal, item.fecha_asistencia,
                    item.HoraInicioHorario, item.HoraFinalHorario, item.Hora_Ingreso, item.Hora_Salida, item.HETotal, item.HESimples,
                    item.HEAdicionales, item.HEDobles, item.Planilla, item.Periodo, item.Localidad, item.Area, item.CatAuxiliar2, "01", item.Tipo);
            }


            return dt;
        }

        public  string Get_Variables(string flat)
        {
            string msg="";
            DataTable dt = new DataTable();

            dt = RUNTABLA("sp_variables_HeComp", flat);
            foreach (DataRow item in dt.Rows)
            {
                msg = item[0].ToString()+"#"+ item[0].ToString();
                 
            }
            return msg;
        }


    } // fin de clase
}






/* 
 
    Personal,
fecha_asistencia,
HoraInicioHorario,
HoraFinalHorario,
Hora_Ingreso,
Hora_Salida,
HETotal,
HESimples,
HEAdicionales,
HEDobles,
Planilla,
Periodo,
Localidad,
Area,
CatAuxiliar2,
CASE Estado WHEN '01'THEN 'PENDIENTE' WHEN '02'THEN 'TERMINADA' END  AS 'Estado' ,
Fecha_Reg,
case tipo when '01' then 'HE.PAGADAS' WHEN '02' THEN 'COMPENSADAS' END AS 'tipo'

 */
