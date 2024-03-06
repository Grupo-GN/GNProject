using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using System.Data;
using System.Data.SqlClient;

namespace BusienssLogic.CA.oPasarPlanilla
{
    public class controller_PasarPlanilla
    {
        private static controller_PasarPlanilla Instance = null;
        public static controller_PasarPlanilla Get_Instance() {
            return Instance == null ? Instance = new controller_PasarPlanilla() : Instance;
        }
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
        public ArrayList Get_Periodo_List(string Planilla_Id) {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())) {
                var query = from p in obj.Periodo
                            where p.Planilla_Id == Planilla_Id
                            && p.Estado_Id=="02" && p.Fecha_Ini.Year==DateTime.Now.Year
                            select new {p.Periodo_Id,p.Descripcion,p.Fecha_Ini };
                ArrayList rList = new ArrayList();
                //rList.AddRange(query.OrderByDescending(o => o.Fecha_Ini).Take(1).ToList());
                rList.AddRange(query.OrderByDescending(o => o.Fecha_Ini).ToList());
                return rList;
            }
        
        }
        public ArrayList Get_CategoriaAux_List()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                var query = from c in obj.Categoria_Auxiliar
                            where c.Categoria_Auxiliar_Id != "00"
                            select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                ArrayList rList = new ArrayList();
                rList.AddRange(query.ToList());
                return rList;
            }

        }
        //nuevo 02.10.2020
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
      



        //antiguo 02.10.2020
        public List<areas_planillas_sofya> Get_Localidad_List_OLD()
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                return obj.areas_planillas_sofya.Where(x => x.Area_Id != "14").ToList();
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
        public ArrayList Get_Personal_List(string Periodo_Id,string Localidad_Id,string CateAux,string Categoria ) { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && pa.Categoria_Auxiliar2_Id.Contains(CateAux)
                            && pa.Categoria2_Id.Contains(Categoria)
                            select new { p.Personal_Id,Personal=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+ p.Nombres, Nro_Doc=p.co_trabajador_id };
                //select new { p.Personal_Id, Personal = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres, Nro_Doc = p.Nro_Doc };
                ArrayList rList = new ArrayList();
                rList.AddRange(query.OrderBy(o=>o.Personal).ToList());
                return rList;
            }
        }
        public List<Novedades> Get_NovedadesPasarPlanilla(string Planilla_Id, string Periodo_Id, string Localidad_Id,string Flat, string[] Personal_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                List<Novedades> rlist = new List<Novedades>();
                    string PeriodoDe=obj.Periodo.Where(x=> x.Periodo_Id==Periodo_Id).First().Descripcion;
                    int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                    if (exiteperiodo == 1)
                    {
                        int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                        string FechaIni = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Inicio.ToString("yyyy-MM-dd");
                        string FechaFin = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Fin.ToString("yyyy-MM-dd");

                    string SPnom = string.Empty;
                    if (Flat=="0")
                    {
                        SPnom = "SP_GNRS_ResumenPasarPlanilla2";
                    }
                    else
                    {
                        SPnom = "SP_GNRS_ResumenPasarPlanilla";
                    }

                        using(SqlConnection cn=new SqlConnection(Presistence.Customs.Conexion.getConexion())){
                            using (SqlCommand cmd = new SqlCommand(SPnom,cn)) {
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
                                    Novedades nov = new Novedades();
                                    nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                    nov.Personal_Id = dr.GetValue(1).ToString();
                                    nov.Planilla = dr.GetValue(2).ToString();
                                    nov.Periodo = dr.GetValue(3).ToString();
                                    nov.Localidad = dr.GetValue(4).ToString();
                                    nov.Area = dr.GetValue(5).ToString();
                                    nov.CateAux = dr.GetValue(6).ToString();
                                    nov.PersonalNom = dr.GetValue(7).ToString();
                                    nov.TotHE = dr.GetValue(8).ToString();
                                    nov.TotHESimples = dr.GetValue(9).ToString();
                                    nov.TotHEAdi = dr.GetValue(10).ToString();
                                    nov.TotHEDob = dr.GetValue(11).ToString();
                                    nov.Faltas = dr.GetValue(12).ToString();
                                    nov.MinTarde = dr.GetValue(13).ToString();
                                    nov.DiasPer = dr.GetValue(14).ToString();
                                    nov.HorasPer = dr.GetValue(15).ToString();
                                    nov.TotHESimpleFijos = dr.GetValue(16).ToString();
                                    nov.TotHEAdiFijos = dr.GetValue(17).ToString();
                                    nov.TotHEDobFijos = dr.GetValue(18).ToString();
                                    nov.FaltasFijos = dr.GetValue(19).ToString();
                                    nov.MinTardeFijos = dr.GetValue(20).ToString();
                                    nov.DiasPer_DesMed = dr.GetValue(21).ToString();
                                    nov.DiasPer_PerDia = dr.GetValue(22).ToString();
                                    nov.DiasPer_Vac = dr.GetValue(23).ToString();
                                    nov.Dominical = dr.GetValue(24).ToString();
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
                                        Novedades nov = new Novedades();
                                        nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                        nov.Personal_Id = dr.GetValue(1).ToString();
                                        nov.Planilla = dr.GetValue(2).ToString();
                                        nov.Periodo = dr.GetValue(3).ToString();
                                        nov.Localidad = dr.GetValue(4).ToString();
                                        nov.Area = dr.GetValue(5).ToString();
                                        nov.CateAux = dr.GetValue(6).ToString();
                                        nov.PersonalNom = dr.GetValue(7).ToString();
                                        nov.TotHE = dr.GetValue(8).ToString();
                                        nov.TotHESimples = dr.GetValue(9).ToString();
                                        nov.TotHEAdi = dr.GetValue(10).ToString();
                                        nov.TotHEDob = dr.GetValue(11).ToString();
                                        nov.Faltas = dr.GetValue(12).ToString();
                                        nov.MinTarde = dr.GetValue(13).ToString();
                                        nov.DiasPer = dr.GetValue(14).ToString();
                                        nov.HorasPer = dr.GetValue(15).ToString();
                                        nov.TotHESimpleFijos = dr.GetValue(16).ToString();
                                        nov.TotHEAdiFijos = dr.GetValue(17).ToString();
                                        nov.TotHEDobFijos = dr.GetValue(18).ToString();
                                        nov.FaltasFijos = dr.GetValue(19).ToString();
                                        nov.MinTardeFijos = dr.GetValue(20).ToString();
                                        nov.DiasPer_DesMed = dr.GetValue(21).ToString();
                                        nov.DiasPer_PerDia = dr.GetValue(22).ToString();
                                        nov.DiasPer_Vac = dr.GetValue(23).ToString();
                                        nov.Dominical = dr.GetValue(24).ToString();
                                        rlist.Add(nov);
                                    }
                                    cmd.Parameters.Clear();
                                    cn.Close();


                                }

                            }

                        }                        
                        }                        
                        
                }
                    return rlist.OrderBy(o => o.PersonalNom).ToList();
            }       
        
        }


        public List<Novedades> Get_NovedadesPasarPlanilla2(string Planilla_Id, string Periodo_Id, string Localidad_Id, string Flat, string[] Personal_Id,string FechaIni, string  FechaFin)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<Novedades> rlist = new List<Novedades>();
                string PeriodoDe = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                int exiteperiodo = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).Count();
                if (exiteperiodo == 1)
                {
                    int periodoca = obj.Periodo_Asistencia.Where(x => x.Periodo == PeriodoDe).First().Periodo_Asistencia_Id;
                    //string FechaIni = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Inicio.ToString("yyyy-MM-dd");
                    //string FechaFin = obj.Periodo_Asistencia.Where(x => x.Periodo_Asistencia_Id == periodoca).First().Date_Fin.ToString("yyyy-MM-dd");

                    string SPnom = string.Empty;
                    if (Flat == "0")
                    {
                        SPnom = "SP_GNRS_ResumenPasarPlanilla2";
                    }
                    else
                    {
                        SPnom = "SP_GNRS_ResumenPasarPlanilla";
                    }

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
                                cmd.Parameters.AddWithValue("@Fecha_InicialFPS", DateTime.Parse(FechaIni).ToString("yyyy-MM-dd"));
                                cmd.Parameters.AddWithValue("@Fecha_FinalFPS", DateTime.Parse( FechaFin).ToString("yyyy-MM-dd"));
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    Novedades nov = new Novedades();
                                    nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                    nov.Personal_Id = dr.GetValue(1).ToString();
                                    nov.Planilla = dr.GetValue(2).ToString();
                                    nov.Periodo = dr.GetValue(3).ToString();
                                    nov.Localidad = dr.GetValue(4).ToString();
                                    nov.Area = dr.GetValue(5).ToString();
                                    nov.CateAux = dr.GetValue(6).ToString();
                                    nov.PersonalNom = dr.GetValue(7).ToString();
                                    nov.TotHE = dr.GetValue(8).ToString();
                                    nov.TotHESimples = dr.GetValue(9).ToString();
                                    nov.TotHEAdi = dr.GetValue(10).ToString();
                                    nov.TotHEDob = dr.GetValue(11).ToString();
                                    nov.Faltas = dr.GetValue(12).ToString();
                                    nov.MinTarde = dr.GetValue(13).ToString();
                                    nov.DiasPer = dr.GetValue(14).ToString();
                                    nov.HorasPer = dr.GetValue(15).ToString();
                                    nov.TotHESimpleFijos = dr.GetValue(16).ToString();
                                    nov.TotHEAdiFijos = dr.GetValue(17).ToString();
                                    nov.TotHEDobFijos = dr.GetValue(18).ToString();
                                    nov.FaltasFijos = dr.GetValue(19).ToString();
                                    nov.MinTardeFijos = dr.GetValue(20).ToString();
                                    nov.DiasPer_DesMed = dr.GetValue(21).ToString();
                                    nov.DiasPer_PerDia = dr.GetValue(22).ToString();
                                    nov.DiasPer_Vac = dr.GetValue(23).ToString();
                                    nov.Dominical = dr.GetValue(24).ToString();
                                    nov.asist = dr.GetValue(25).ToString();
                                    nov.comp = dr.GetValue(26).ToString();
                                    nov.PERSINGOCE= dr.GetValue(27).ToString();
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
                                        Novedades nov = new Novedades();
                                        nov.Asistencia_Id = int.Parse(dr.GetValue(0).ToString());
                                        nov.Personal_Id = dr.GetValue(1).ToString();
                                        nov.Planilla = dr.GetValue(2).ToString();
                                        nov.Periodo = dr.GetValue(3).ToString();
                                        nov.Localidad = dr.GetValue(4).ToString();
                                        nov.Area = dr.GetValue(5).ToString();
                                        nov.CateAux = dr.GetValue(6).ToString();
                                        nov.PersonalNom = dr.GetValue(7).ToString();
                                        nov.TotHE = dr.GetValue(8).ToString();
                                        nov.TotHESimples = dr.GetValue(9).ToString();
                                        nov.TotHEAdi = dr.GetValue(10).ToString();
                                        nov.TotHEDob = dr.GetValue(11).ToString();
                                        nov.Faltas = dr.GetValue(12).ToString();
                                        nov.MinTarde = dr.GetValue(13).ToString();
                                        nov.DiasPer = dr.GetValue(14).ToString();
                                        nov.HorasPer = dr.GetValue(15).ToString();
                                        nov.TotHESimpleFijos = dr.GetValue(16).ToString();
                                        nov.TotHEAdiFijos = dr.GetValue(17).ToString();
                                        nov.TotHEDobFijos = dr.GetValue(18).ToString();
                                        nov.FaltasFijos = dr.GetValue(19).ToString();
                                        nov.MinTardeFijos = dr.GetValue(20).ToString();
                                        nov.DiasPer_DesMed = dr.GetValue(21).ToString();
                                        nov.DiasPer_PerDia = dr.GetValue(22).ToString();
                                        nov.DiasPer_Vac = dr.GetValue(23).ToString();
                                        nov.Dominical = dr.GetValue(24).ToString();
                                        nov.asist = dr.GetValue(25).ToString();
                                        nov.comp = dr.GetValue(26).ToString();
                                        nov.PERSINGOCE = dr.GetValue(27).ToString();

                                        rlist.Add(nov);
                                    }
                                    cmd.Parameters.Clear();
                                    cn.Close();


                                }

                            }

                        }
                    }

                }
                return rlist.OrderBy(o => o.PersonalNom).ToList();
            }

        }







        public string ActualizarConceptoPlanilla(string Planilla_Id,string Periodo_Id,string Concepto_Id,string Personal_Id,decimal Valor) {
            try {
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion())) {
                    using (SqlCommand cmd = new SqlCommand("PasarHEPlanilla",cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Planilla_Id", Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                        cmd.Parameters.AddWithValue("@Concepto_Id", Concepto_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Valor", Valor);
                        cn.Open();
                        int cant = cmd.ExecuteNonQuery();
                        if (cant > 0)
                        {
                            return "true#Actualizado correctamente.";
                        }
                        else {
                            return "false#No se actualizo correctamente.";
                        }
                    }                
                }
            }catch(Exception ex){
                return "false#.::Error > " + ex.Message;
            }
        }
    }
    public class Novedades {
        public int Asistencia_Id { get; set; }
        public string Personal_Id { get; set; }
        public string Planilla { get; set; }
        public string Periodo { get; set; }
        public string Localidad { get; set; }
        public string Area { get; set; }
        public string CateAux { get; set; }
        public string PersonalNom { get; set; }
        public string TotHE { get; set; }
        public string TotHESimples { get; set; }
        public string TotHEAdi { get; set; }
        public string TotHEDob { get; set; }
        public string Faltas { get; set; }
        public string MinTarde { get; set; }
        public string DiasPer { get; set; }
        public string HorasPer { get; set; }
        public string TotHESimpleFijos { get; set; }
        public string TotHEAdiFijos { get; set; }
        public string TotHEDobFijos { get; set; }
        public string FaltasFijos { get; set; }
        public string MinTardeFijos { get; set; }

        public string DiasPer_DesMed { get; set; }
        public string DiasPer_PerDia { get; set; }
        public string DiasPer_Vac { get; set; }
        public string Dominical { get; set; }
        public string asist { get; set; }
        public string comp { get; set; }
        public string PERSINGOCE { get; set; }
    }
}
