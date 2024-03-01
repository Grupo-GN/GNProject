using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
using System.Data;
using System.Data.SqlClient;
using BusienssLogic.Utils;

namespace BusienssLogic.CA.oInfoMarcaciones
{
    public class controller_InfoMarcaciones
    {
        private static controller_InfoMarcaciones Instance = null;
        public static controller_InfoMarcaciones Get_Instance() {
            return Instance == null ? Instance = new controller_InfoMarcaciones() : Instance;
        }
        public ArrayList Get_Personal_By_Filtros(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria, string PersonalFind, string Jefe_Id="")
        {
           using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                if (PersonalFind.Trim() != "") {
                    PersonalFind = PersonalFind.Replace(" ", "");
                }
                if (Jefe_Id == "000000")
                {
                    Jefe_Id = "";
                }

                 
                string rol = "";
               
                if (Jefe_Id=="")
                {
                    rol = "02";
                }
                else
                {
                    rol = obj.UsuarioPlanilla.Where(x => x.Personal_Id == Jefe_Id.Trim()).First().NivelAcceso;
                }
                ArrayList rList = new ArrayList();
                if (rol.ToString()=="01")
                {
                    rList = new ArrayList();
                    var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            //join jp in obj.Jefe_Personal on p.Personal_Id equals jp.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && pa.Categoria_Auxiliar_Id.Contains(CategoriaAux)
                            && pa.Categoria_Auxiliar2_Id.Contains(CategoriaAux2)
                            && pa.Categoria2_Id.Contains(Categoria)
                            && (p.Apellido_Paterno+" " + p.Apellido_Materno+" " + p.Nombres).ToUpper().Contains(PersonalFind)
                            //&& jp.Jefe_Id.Contains(Jefe_Id)
                            select new
                            {
                                pa.Personal_Id,
                                PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                            };
                query = query.OrderBy(o => o.PersonalName);
                rList.AddRange(query.ToList());
                }
                else
                {
                    rList = new ArrayList();
                    var query = from p in obj.Personal
                                join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                                join jp in obj.Jefe_Personal on p.Personal_Id equals jp.Personal_Id
                                where pa.Periodo_Id == Periodo_Id
                                && pa.Area_Id.Contains(Localidad_Id)
                                && pa.Categoria_Auxiliar_Id.Contains(CategoriaAux)
                                && pa.Categoria_Auxiliar2_Id.Contains(CategoriaAux2)
                                && pa.Categoria2_Id.Contains(Categoria)
                                && (p.Apellido_Paterno + " " + p.Apellido_Materno + " " + p.Nombres).ToUpper().Contains(PersonalFind)
                                && jp.Jefe_Id.Contains(Jefe_Id)
                                select new
                                {
                                    pa.Personal_Id,
                                    PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                                };
                    query = query.OrderBy(o => o.PersonalName);
                    rList.AddRange(query.ToList());

                }

                
               
                return rList;
            } 
        }


        public string Get_SendMarcaciones_Informacion(string[] Personal_Cods) {
            try
            {
                List<mensajes> lcorreso = new List<mensajes>();
                using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_JOB_SEND_MARCACIONES_PERSONAL", cn))
                    {
                        int correct = 0, erro = 0;
                        string personal = "";
                        for (int i = 0; i <= Personal_Cods.Length - 1; i++)
                        {
                            personal+=Personal_Cods[i]+",";
                        }
                        if (personal.Length > 0)
                        {
                            personal = personal.Remove(personal.Length - 1, 1);
                        }
                        /*cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i <= Personal_Cods.Length - 1; i++)
                        {
                            cmd.Parameters.AddWithValue("@Personal_Send", Personal_Cods[i]);
                            cn.Open();
                            int cant = int.Parse(cmd.ExecuteScalar().ToString());
                            if (cant > 1)
                            {
                                correct++;
                            }
                            else
                            {
                                erro++;
                            }
                            cmd.Parameters.Clear();
                            cn.Close();
                        }*/
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Personal_Send", personal);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            mensajes corr = new mensajes();
                            corr.asunto = dr.GetValue(0).ToString();
                            corr.correo = dr.GetValue(1).ToString();
                            corr.bodyhtml = dr.GetValue(2).ToString();
                            lcorreso.Add(corr);
                        }
                        string erroraa = "";
                        List<string> bcclis = new List<string>();
                        for (int i = 0; i <= lcorreso.Count() - 1; i++)
                        {
                            if (lcorreso[i].correo.Trim() != "")
                            {
                                string retu = controller_SendSMTP.get_instance().sendMail(lcorreso[i].correo, lcorreso[i].asunto, lcorreso[i].bodyhtml, bcclis);
                                if (retu.Split('#')[0] == "true")
                                {
                                    correct++;
                                }
                                else { erro++; erroraa = retu.Split('#')[1]; }
                            }
                        }

                        return "true#Información Enviada> Correctas: " + correct.ToString() + ", Errores: " + erro.ToString() + " " + erroraa;

                    }
                }
            }catch(Exception ex){
                return "false#.::Error > " + ex.Message;
            }

        }

    }
    public class mensajes {
        public string asunto { get; set; }
        public string correo { get; set; }
        public string bodyhtml { get; set; }
    }
}
