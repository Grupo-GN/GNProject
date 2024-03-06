using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using System.Data.SqlClient;
using System.Data;
namespace BusienssLogic.CA.oAsignarHVariable
{
    public class controller_AsignarHVariable
    {
        private static controller_AsignarHVariable Instance = null;
        public static controller_AsignarHVariable Get_Instance() {
            return Instance == null ? Instance = new controller_AsignarHVariable() : Instance;
        }
        public List<tblPersonalHV> Get_Personal_HorarioVariable(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria)
        { 
            using(SqlConnection cn=new SqlConnection(Presistence.Customs.Conexion.getConexion())){
                using (SqlCommand cmd = new SqlCommand("Get_PersonalHorarioVariable",cn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo_Id",Periodo_Id);
                    cmd.Parameters.AddWithValue("@Localidad_Id", Localidad_Id);
                    cmd.Parameters.AddWithValue("@CategoriaAux", CategoriaAux);
                    cmd.Parameters.AddWithValue("@CategoriaAux2", CategoriaAux2);
                    cmd.Parameters.AddWithValue("@Categoria", Categoria);
                    List<tblPersonalHV> rList = new List<tblPersonalHV>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        tblPersonalHV vari = new tblPersonalHV();
                        vari.Personal_Id = dr.GetValue(0).ToString();
                        vari.Periodo_Id = dr.GetValue(1).ToString();
                        vari.Localidad = dr.GetValue(2).ToString();
                        vari.Area = dr.GetValue(3).ToString();
                        vari.PersonalName = dr.GetValue(4).ToString();
                        vari.HVariable = dr.GetValue(5).ToString();
                        rList.Add(vari);
                    }


                    return rList;                    
                }            
            }
        }

        public string Get_AsignarHorarioVariable(List<PersonalHV> PersonalVariable,string Periodo_Id) {
            try
            {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    string DescripcionPer = obj.Periodo.Where(x => x.Periodo_Id == Periodo_Id).First().Descripcion;
                    int PeriodoCa = obj.Periodo_Asistencia.Where(x => x.Periodo == DescripcionPer).First().Periodo_Asistencia_Id;
                    for (int i = 0; i <= PersonalVariable.Count - 1; i++)
                    {

                        string Personal_Id = PersonalVariable[i].Personal_Id;
                        int existe = obj.HorarioVariable.Where(x => x.Periodo_Id == Periodo_Id && x.PeriodoCA_Id == PeriodoCa && x.Personal_Id == Personal_Id).Count();
                        if (existe != 0)
                        {
                            HorarioVariable hvPer = obj.HorarioVariable.Where(x => x.Periodo_Id == Periodo_Id && x.PeriodoCA_Id == PeriodoCa && x.Personal_Id == Personal_Id).First();
                            hvPer.Variable = PersonalVariable[i].Variable;
                            obj.SaveChanges();
                        }
                        else
                        {
                            HorarioVariable hvPer = new HorarioVariable();
                            hvPer.Periodo_Id = Periodo_Id;
                            hvPer.PeriodoCA_Id = PeriodoCa;
                            hvPer.Personal_Id = Personal_Id;
                            hvPer.Variable = PersonalVariable[i].Variable;
                            obj.AddToHorarioVariable(hvPer);
                            obj.SaveChanges();
                        }
                    }
                    return "true#Actualizado ";
                }
            }catch(Exception ex){
                return "false#.::Error > " + ex.Message;
            }
        
        }

    }
    public class tblPersonalHV {
        public string Personal_Id { get; set; }
        public string Periodo_Id { get; set; }
        public string Localidad { get; set; }
        public string Area { get; set; }
        public string PersonalName { get; set; }
        public string HVariable { get; set; }
    }
    public class PersonalHV{
        public string Personal_Id { get; set; }
        public string Variable { get; set; }
    }
}


