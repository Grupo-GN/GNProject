using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using System.Data.SqlClient;
using System.Data;
namespace BusienssLogic.CA.oIndicadoresMultiples
{
    public class controller_IndicadoresMultiples
    {
        private static controller_IndicadoresMultiples Instance = null;
        public static controller_IndicadoresMultiples Get_Instance() {
            return Instance == null ? Instance = new controller_IndicadoresMultiples() : Instance;
        }



        public ArrayList Get_IndicesMultiplesControlAsistencia(string[] Dimensiones,string[] Sumas,string FechaInicio,string FechaFinal) {
            string Display = "";
            string Suma = "";
            string InnerJoin = "";   
            string Where = "";            
            string Group = "";
            string OrderBy = "";
            int AgregaAnio = 0;
            for (int d = 0; d <= Dimensiones.Length - 1; d++) {
                Display += Get_Diplay(Dimensiones[d]) + " ,";
                if (Dimensiones[d] == "D3")
                {
                    AgregaAnio = 1;
                }
            }
            if (Display != "") {
                Display = Display.Remove(Display.Length - 1);
            }

            for (int d = 0; d <= Dimensiones.Length - 1; d++)
            {
                InnerJoin += Get_InnerJoin(Dimensiones[d]) + " ";
            }
            

            for (int s = 0; s <= Sumas.Length - 1; s++)
            {
                Suma += Get_SumaDimensional(Sumas[s]) + " ,";
            }
            if (Suma != "")
            {
                Suma = Suma.Remove(Suma.Length - 1);
            }
            for (int d = 0; d <= Dimensiones.Length - 1; d++)
            {
                Group += Get_GroupBy(Dimensiones[d]) + " ,";
            }
            if (Group != "")
            {
                Group = Group.Remove(Group.Length - 1);
            }
            for (int d = 0; d <= Dimensiones.Length - 1; d++)
            {
                OrderBy += (d +1).ToString()+ " ,";
            }
            if (OrderBy != "")
            {
                OrderBy = OrderBy.Remove(OrderBy.Length - 1);
            }

            int cant = Dimensiones.Length + Sumas.Length+AgregaAnio;

            object[] valuesTitle = new object[cant] ;

            for (int t = 0; t <= cant-1; t++) {
                for (int d = 0; d <= Dimensiones.Length - 1; d++) {
                    string title = Get_Diplay_Tabla(Dimensiones[d]);
                    if (title.IndexOf(",") != -1)
                    {
                        valuesTitle[t] = title.Split(',')[0];
                        t++;
                        valuesTitle[t] = title.Split(',')[1];
                        t++;
                    }
                    else {
                        valuesTitle[t] = title;
                        t++;
                    }
                }

                for (int s = 0; s <= Sumas.Length - 1; s++)
                {
                   
                    valuesTitle[t] = Get_SumaDimensional_Tabla(Sumas[s]);
                    t++;
                }

            }




                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GNRS_GenerarReporteIndicesMultiples_WPP", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Dimen", Display);
                        cmd.Parameters.AddWithValue("@Suma", Suma);
                        cmd.Parameters.AddWithValue("@Inner", InnerJoin);
                        cmd.Parameters.AddWithValue("@Where", Where);
                        cmd.Parameters.AddWithValue("@GroupBy", Group);
                        cmd.Parameters.AddWithValue("@OrderBy", OrderBy);
                        cmd.Parameters.AddWithValue("@FechaIni", FechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", FechaFinal);
                        cn.Open();
                        ArrayList rList = new ArrayList();
                        rList.Add(valuesTitle);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            object[] values = new object[dr.FieldCount];
                            dr.GetValues(values);
                            rList.Add(values);
                        }
                        return rList;
                    }

                }
        
        }





        #region DATOS PARA GENERAR LOS INDICES

        public static ArrayList lDimensiones = new ArrayList();        
        public ArrayList Get_Dimensiones() {
            lDimensiones.Clear();
            lDimensiones.Add(new { Dimen_Id="D1",   Descripcion="PLANILLA" });
            lDimensiones.Add(new { Dimen_Id = "D2", Descripcion = "AÑO" });
            lDimensiones.Add(new { Dimen_Id = "D3", Descripcion = "MES" });
            lDimensiones.Add(new { Dimen_Id = "D4", Descripcion = "LOCALIDAD" });
            lDimensiones.Add(new { Dimen_Id = "D5", Descripcion = "AREA" });
            lDimensiones.Add(new { Dimen_Id = "D6", Descripcion = "SECCION" });
            lDimensiones.Add(new { Dimen_Id = "D7", Descripcion = "PERSONAL" });
            /*lDimensiones.Add(new { Dimen_Id = "D7", Descripcion = "PLANILLA" });*/

            return lDimensiones;
        }
        public static ArrayList lSumProc = new ArrayList();
        public ArrayList Get_SumaCamposCA()
        {
            lSumProc.Clear();
            lSumProc.Add(new { Sum_Id = "S1", Descripcion = "TARDANAZA" });
            lSumProc.Add(new { Sum_Id = "S2", Descripcion = "H.EXTRAS SIMPLES" });
            lSumProc.Add(new { Sum_Id = "S3", Descripcion = "H.EXTRAS ADICIONALES" });
            lSumProc.Add(new { Sum_Id = "S4", Descripcion = "H.EXTRAS DOBLES" });
            lSumProc.Add(new { Sum_Id = "S5", Descripcion = "FALTAS" });

            /*lDimensiones.Add(new { Dimen_Id = "D7", Descripcion = "PLANILLA" });*/

            return lSumProc;
        }



        private string Get_Diplay(string Dim_Id) {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "D1": DisReturn = "PL.Descripcion [PLANILLA]"; break;
                case "D2": DisReturn = "YEAR(CA.fecha_asistencia) [ANIO]"; break;
                case "D3": DisReturn = "YEAR(CA.fecha_asistencia) [ANIO],CASE MONTH(CA.fecha_asistencia) WHEN 1 THEN 'ENERO' WHEN 2 THEN 'FEBRERO' WHEN 3 THEN 'MARZO' WHEN 4 THEN 'ABRIL' WHEN 5 THEN 'MAYO' WHEN 6 THEN 'JUNIO' WHEN 7 THEN 'JULIO' WHEN 8 THEN 'AGOSTO' WHEN 9 THEN 'SETIEMBRE' WHEN 10 THEN 'OCTUBRE' WHEN 11 THEN 'NOVIEMBRE' WHEN 12 THEN 'DICIEMBRE' END [MES]"; break;
                case "D4": DisReturn = "A.descripcion [LOCALIDAD]"; break;
                case "D5": DisReturn = "CAX.descripcion [AREA]"; break;
                case "D6": DisReturn = "CAX2.Descripcion [SECCION]"; break;
                case "D7": DisReturn = "P.Apellido_Paterno+''+P.Apellido_Materno+', '+P.Nombres [PERSONAL]"; break;
            }
            return DisReturn;
        }

        private string Get_SumaDimensional(string Dim_Id)
        {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "S1": DisReturn = "CAST((SUM(CASE  WHEN (CA.DifMinutosInicio*-1)>@TOLE THEN (CA.DifMinutosInicio*-1) ELSE 0 END )/60) AS VARCHAR(20))+ ':' +CAST((SUM(CASE  WHEN (CA.DifMinutosInicio*-1)>@TOLE THEN (CA.DifMinutosInicio*-1) ELSE 0 END )%60) AS VARCHAR(2)) [TARDANZA]"; break;
                case "S2": DisReturn = "CAST((SUM(ISNULL(CA.MinutosHESimple,0))/60) AS VARCHAR(20)) + ':' + CAST((SUM(ISNULL(CA.MinutosHESimple,0))%60)AS VARCHAR(2))  [HES]"; break;
                case "S3": DisReturn = "CAST((SUM(ISNULL(CA.MinutosHEAdicional,0))/60) AS VARCHAR(20)) + ':' + CAST((SUM(ISNULL(CA.MinutosHEAdicional,0))%60)AS VARCHAR(2)) [HEA]"; break;
                case "S4": DisReturn = "CAST((SUM(ISNULL(CA.MinutosHEDoble,0))/60) AS VARCHAR(20)) + ':' + CAST((SUM(ISNULL(CA.MinutosHEDoble,0))%60)AS VARCHAR(2)) [HED]"; break;
                case "S5": DisReturn = "SUM(CAST(CA.fl_falta AS INT)) [FALTAS]"; break;
            }
            return DisReturn;
        }
        //cambio 02.10.2020
        private string Get_InnerJoin(string Dim_Id)
        {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "D1": DisReturn = " INNER JOIN Planilla PL ON PL.Planilla_Id=PA.Planilla_Id"; break;
                case "D4": DisReturn = " INNER JOIN RH_Area A ON PA.Area_Id=A.Area_Id"; break;
                case "D5": DisReturn = " INNER JOIN Categoria_Auxiliar CAX ON PA.Categoria_Auxiliar_Id=CAX.Categoria_Auxiliar_Id"; break;
                case "D6": DisReturn = " INNER JOIN Categoria_Auxiliar2 CAX2 ON PA.Categoria_Auxiliar2_Id=CAX2.Categoria_Auxiliar2_Id"; break;
                case "D7": DisReturn = " INNER JOIN Personal P ON CA.Personal_Id=P.Personal_Id"; break;
            }
            return DisReturn;
        }

        private string Get_GroupBy(string Dim_Id)
        {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "D1": DisReturn = "PL.Descripcion"; break;
                case "D2": DisReturn = "YEAR(CA.fecha_asistencia)"; break;
                case "D3": DisReturn = "YEAR(CA.fecha_asistencia),CASE MONTH(CA.fecha_asistencia) WHEN 1 THEN 'ENERO' WHEN 2 THEN 'FEBRERO' WHEN 3 THEN 'MARZO' WHEN 4 THEN 'ABRIL' WHEN 5 THEN 'MAYO' WHEN 6 THEN 'JUNIO' WHEN 7 THEN 'JULIO' WHEN 8 THEN 'AGOSTO' WHEN 9 THEN 'SETIEMBRE' WHEN 10 THEN 'OCTUBRE' WHEN 11 THEN 'NOVIEMBRE' WHEN 12 THEN 'DICIEMBRE' END"; break;
                case "D4": DisReturn = "A.descripcion"; break;
                case "D5": DisReturn = "CAX.descripcion"; break;
                case "D6": DisReturn = "CAX2.Descripcion"; break;
                case "D7": DisReturn = "P.Apellido_Paterno+''+P.Apellido_Materno+', '+P.Nombres"; break;
            }
            return DisReturn;
        }



        private string Get_Diplay_Tabla(string Dim_Id)
        {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "D1": DisReturn = "PLANILLA"; break;
                case "D2": DisReturn = "AÑO"; break;
                case "D3": DisReturn = "AÑO,MES"; break;
                case "D4": DisReturn = "LOCALIDAD"; break;
                case "D5": DisReturn = "AREA"; break;
                case "D6": DisReturn = "SECCION"; break;
                case "D7": DisReturn = "PERSONAL"; break;
            }
            return DisReturn;
        }

        private string Get_SumaDimensional_Tabla(string Dim_Id)
        {
            string DisReturn = "";
            switch (Dim_Id)
            {
                case "S1": DisReturn = "TARDANZA"; break;
                case "S2": DisReturn = "H.E.S"; break;
                case "S3": DisReturn = "H.E.A."; break;
                case "S4": DisReturn = "H.E.D."; break;
                case "S5": DisReturn = "FALTAS"; break;
            }
            return DisReturn;
        }








        #endregion

        #region FILTROS

        public ArrayList Get_Planilla_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Planilla
                            where p.Estado_Id == "01"
                            select new { p.Planilla_Id, p.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public List<string> Get_Anios() { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                List<string> rList = new List<string>();
                var query = from a in obj.Ejercicio
                            select  a.Ejercicio_Id ;

                rList.AddRange(query.OrderByDescending(o=> o).ToList());
                return rList;
            }
        
        }


        public ArrayList Get_Periodo_Activo_By_CA(string Planilla_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Periodo
                            join pa in obj.Periodo_Asistencia on p.Descripcion equals pa.Periodo
                            where /*p.Estado_Id == "02"
                            && */p.Planilla_Id == Planilla_Id
                            select new
                            {
                                p.Periodo_Id,
                                p.Descripcion,
                                p.Fecha_Ini,
                                p.Fecha_Fin,
                                p.Estado_Id
                            };
                query = query.OrderByDescending(o => o.Fecha_Ini);
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Periodos_Planilla(string Planilla_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Periodo
                            where p.Estado_Id == "02"
                            && p.Planilla_Id == Planilla_Id
                            select new
                            {
                                p.Periodo_Id,
                                p.Descripcion,
                                p.Fecha_Ini,
                                p.Fecha_Fin,
                                p.Estado_Id
                            };
                query = query.OrderByDescending(o => o.Fecha_Ini);
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        //public List<areas_planillas_sofya> Get_Localidad_List()
        //{
        //    using (ContextMaestro obj = new ContextMaestro())
        //    {
        //        return obj.areas_planillas_sofya.Where(x => x.Area_Id != "14").ToList();
        //    }
        //}


        public ArrayList Get_Localidad_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.RH_Area //modificado 1.10.2020  obj.areas_planillas_sofy, descripcion
                            select new { p.Area_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }


        public ArrayList Get_Categoria_Auxiliar_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria_Auxiliar
                            where c.Categoria_Auxiliar_Id.Trim() != "00"
                            select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Categoria_Auxiliar2_List(string Cat_Aux)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria_Auxiliar2
                            where c.Categoria_Auxiliar2_Id.Trim() != "00"
                            && c.Categoria_Auxiliar_id.Contains(Cat_Aux)
                            select new { c.Categoria_Auxiliar2_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_Categoria_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria2
                            where c.Categoria2_Id == "01" || c.Categoria2_Id == "02"
                            select new { c.Categoria2_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;
            }
        }
        public ArrayList Get_PeriodoCA_By_Planilla(string Periodo_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                if (Periodo_Id != "")
                {
                    string Descrip = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                    var query = from p in obj.Periodo_Asistencia
                                where p.Periodo.Contains(Descrip)
                                select new
                                {
                                    p.Periodo_Asistencia_Id,
                                    p.Periodo,
                                    p.Date_Inicio,
                                    p.Date_Fin
                                };

                    rList.AddRange(query.ToList());
                }
                return rList;
            }
        }
        public ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && pa.Categoria_Auxiliar_Id.Contains(CategoriaAux)
                            && pa.Categoria_Auxiliar2_Id.Contains(CategoriaAux2)
                            && pa.Categoria2_Id.Contains(Categoria)
                            select new
                            {
                                pa.Personal_Id,
                                PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                            };
                query = query.OrderBy(o => o.PersonalName);
                rList.AddRange(query.ToList());
                return rList;
            }
        }


        #endregion
    }
    
}
