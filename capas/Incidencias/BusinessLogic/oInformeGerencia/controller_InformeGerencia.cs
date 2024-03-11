using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using System.Collections;
using PersistenceI;

namespace BusinessLogic.oInformeGerencia
{
    public class controller_InformeGerencia
    {
        private static controller_InformeGerencia Instance = null;
        public static controller_InformeGerencia Get_Instance() {
            return Instance == null ? Instance = new controller_InformeGerencia() : Instance;
        }
        public ArrayList Get_Gerentes_List(string Nombres,string Estado,int inicio) { 
            using(ContextMaestro obj=new ContextMaestro()){

                ArrayList rList = new ArrayList();
                var query = from g in obj.Gerentes
                            join l in obj.RH_Area on g.Area_Id equals l.Area_Id
                            where (g.Apellido_Paterno.Trim() + g.Apellido_Materno.Trim() + g.Nombres.Trim()).Contains(Nombres)
                            && g.Estado.Contains(Estado)
                            select new { 
                                g.Gerente_Id,
                                g.Apellido_Paterno,
                                g.Apellido_Materno,
                                g.GerenciaDes,
                                g.Nombres,
                                g.Correo,
                                g.Informar,
                                g.Estado,                                
                                RH_Area=l.Descripcion
                            
                            };
                query= query.OrderBy(o=> o.Apellido_Paterno).Skip(inicio).Take(12);
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public int Get_Gerentes_List_MaxRows(string Nombres, string Estado)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                var query = from g in obj.Gerentes
                            where (g.Apellido_Paterno.Trim() + g.Apellido_Materno.Trim() + g.Nombres.Trim()).Contains(Nombres)
                            && g.Estado.Contains(Estado)
                            select g;
                return query.Count();
            }
        }


        public string Get_Add_Gerente(string Apellido_Paterno,string Apellido_Materno
            , string Nombres, string GerenciaDes, string Correo, string Area_Id, string Informar, string Codigo_LG, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    string Gerente_Id = Get_PrimaryKey();

                    int existe = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).Count();
                    if (existe == 0)
                    {
                        Gerentes gen = new Gerentes();
                        gen.Gerente_Id = Gerente_Id;
                        gen.Apellido_Paterno = Apellido_Paterno;
                        gen.Apellido_Materno = Apellido_Materno;
                        gen.Nombres = Nombres;
                        gen.GerenciaDes = GerenciaDes;
                        gen.Correo = Correo;
                        gen.Area_Id = Area_Id;
                        gen.Informar = Informar;
                        gen.Codigo_LG = Codigo_LG;
                        gen.Estado = Estado;
                        obj.AddToGerentes(gen);
                        obj.SaveChanges();
                        return "true#Registrado Correctamente.";
                    }
                    return "false#.::Erro,Intentelo luego.";
                }
            }
            catch (Exception ex)
            {
                return "false#" + ex.Message;
            }
        }


        public string Get_Update_Gerente(string Gerente_Id,string Apellido_Paterno, string Apellido_Materno
    , string Nombres, string GerenciaDes, string Correo, string Area_Id, string Informar, string Codigo_LG, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                                   
                    int existe = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).Count();
                    if (existe == 1)
                    {
                        Gerentes gen = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First();                        
                        gen.Apellido_Paterno = Apellido_Paterno;
                        gen.Apellido_Materno = Apellido_Materno;
                        gen.Nombres = Nombres;
                        gen.GerenciaDes = GerenciaDes;
                        gen.Correo = Correo;
                        gen.Area_Id = Area_Id;
                        gen.Informar = Informar;
                        gen.Codigo_LG = Codigo_LG;
                        gen.Estado = Estado;            
                        obj.SaveChanges();
                        return "true#Actualizado Correctamente.";
                    }
                    return "false#.::Erro,Intentelo luego.";
                }
            }
            catch (Exception ex)
            {
                return "false#" + ex.Message;
            }
        }

        public string Get_Delete_Estado_Gerente(string Gerente_Id,string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    int existe = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).Count();
                    if (existe == 1)
                    {
                        Gerentes gen = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First();  
                        gen.Estado = Estado;
                        obj.SaveChanges();
                        return "true#Actualizado Correctamente.";
                    }
                    return "false#.::Erro,Intentelo luego.";
                }
            }
            catch (Exception ex)
            {
                return "false#" + ex.Message;
            }
        }

        public Gerentes Get_Find_Gerente(string Gerente_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).Count();
                if (existe == 1)
                {
                    return obj.Gerentes.Where(x => x.Gerente_Id == Gerente_Id).First();
                }
                return null;
            }
        }

        public string Get_PrimaryKey() {
            using (ContextMaestro obj = new ContextMaestro()) {
                int cant = obj.Gerentes.Count();
                if (cant == 0)
                {
                    return "000001";
                }
                else {
                    string max = obj.Gerentes.Max(m=> m.Gerente_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(6, '0');
                    return max;
                }
            }
        }
    }
}

