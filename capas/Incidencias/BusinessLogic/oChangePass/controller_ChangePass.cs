using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using System.Collections;
namespace BusinessLogic.oChangePass
{
    public class controller_ChangePass
    {
        private static controller_ChangePass Instance = null;
        public static controller_ChangePass Get_Instance()
        {
            return Instance == null ? Instance = new controller_ChangePass() : Instance;
        }
        private static int FINALROWS = 12;
        public ArrayList Get_UsuarioPersonal(string Personal_Id,string PersonalFind,int inicio) { 
            using(ContextMaestro obj=new ContextMaestro()){
                ArrayList rList = new ArrayList();
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe > 0) {
                    string Rol = obj.Personal.Where(x => x.Personal_Id == Personal_Id).First().RolSistema;
                    if (Rol == "01") {
                        var query = from u in obj.Usuario
                                    join p in obj.Personal on u.Personal_Id equals p.Personal_Id
                                    where (p.Apellido_Paterno + p.Apellido_Materno + p.Nombres).ToUpper().Contains(PersonalFind)
                                    select new { 
                                        p.Personal_Id,
                                        Personal=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                        p.Estado_Id,
                                        u.Name,
                                        u.Password,
                                        EstadoUsur=u.Estado
                                    };
                        query = query.OrderBy(o => o.Personal).Skip(inicio).Take(FINALROWS);
                        rList.AddRange(query.ToList());
                    }
                    else if (Rol == "02") {
                        var queryper = from u in obj.Usuario
                                    join p in obj.Personal on u.Personal_Id equals p.Personal_Id
                                       where p.Personal_Id == Personal_Id
                                    select new
                                    {
                                        p.Personal_Id,
                                        Personal = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                        p.Estado_Id,
                                        u.Name,
                                        u.Password,
                                        EstadoUsur = u.Estado
                                    };
                        queryper = queryper.OrderBy(o => o.Personal).Skip(inicio).Take(FINALROWS);
                        rList.AddRange(queryper.ToList());
                    }
                    
                }

                return rList;
            }
        }

        public int Get_UsuarioPersonal_MaxRows(string Personal_Id, string PersonalFind)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cantidad = 0;
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe > 0)
                {
                    string Rol = obj.Personal.Where(x => x.Personal_Id == Personal_Id).First().RolSistema;
                    if (Rol == "01")
                    {
                        var query = from u in obj.Usuario
                                    join p in obj.Personal on u.Personal_Id equals p.Personal_Id
                                    where (p.Apellido_Paterno + p.Apellido_Materno + p.Nombres).ToUpper().Contains(PersonalFind)
                                    select new
                                    {
                                        Personal = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                        p.Estado_Id,
                                        u.Name,
                                        u.Password,
                                        EstadoUsur = u.Estado
                                    };
                        cantidad=query.Count();
                    }
                    else if (Rol == "02")
                    {
                        var queryper = from u in obj.Usuario
                                       join p in obj.Personal on u.Personal_Id equals p.Personal_Id
                                       where p.Personal_Id == Personal_Id
                                       select new
                                       {
                                           Personal = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                           p.Estado_Id,
                                           u.Name,
                                           u.Password,
                                           EstadoUsur = u.Estado
                                       };
                        cantidad = queryper.Count();
                    }

                }

                return cantidad;
            }
        }

        public Personal Get_Personal_Find(string Personal_Id) {
            using (ContextMaestro obj = new ContextMaestro()) {
                return obj.Personal.Where(x => x.Personal_Id == Personal_Id).First();
            }
        }

        public string Get_Change_Pass(string Personal_Id,string NewPass)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    Usuario per = obj.Usuario.Where(x => x.Personal_Id == Personal_Id).First();
                    per.Password = NewPass;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
            }catch(Exception ex){
                return "false#.::Error > " + ex.Message;
            }
        }
    }
}
