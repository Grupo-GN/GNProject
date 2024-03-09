using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Persistence;
namespace BusinessLogic.oPersonal
{
    public class controller_Personal
    {
        private static controller_Personal Instance = null;
        public static controller_Personal Get_Instance() {
            return Instance == null ? Instance = new controller_Personal() : Instance;
        }

        private static int FINALLROWS = 12;
        public ArrayList Get_Personal_List(string Nombres, string Area_Id, string Estado_Id, int inicio)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                var query = from p in obj.Personal
                            join l in obj.RH_Area on p.Area_Id equals l.Area_Id
                            join c in obj.Cargo on p.Cargo_Id equals c.Cargo_id
                            join a in obj.Categoria_Auxiliar on p.Categoria_Auxiliar_Id equals a.Categoria_Auxiliar_Id
                            join b in obj.Categoria_Auxiliar2 on p.Categoria_Auxiliar2_Id equals b.Categoria_Auxiliar2_Id
                            where (p.Apellido_Paterno.Trim() + p.Apellido_Materno.Trim() + p.Nombres.Trim()).Contains(Nombres)
                            && p.Area_Id.Contains(Area_Id)
                            && p.Estado_Id.Contains(Estado_Id)
                            select new {p.Personal_Id,
                                Nombres=p.Apellido_Paterno+" "+p.Apellido_Materno+", "+p.Nombres,
                                RH_Area=l.Descripcion,
                                Cargo=c.Descripcion,
                                CatAux=a.Descripcion,
                                CatAux2 = b.Descripcion,
                                p.Estado_Id
                            };
                query = query.OrderBy(o => o.Nombres).Skip(inicio).Take(FINALLROWS);
                rList.AddRange(query.ToList());
                return rList;
            }
        }

        public int Get_Personal_List_MaxRows(string Nombres, string Area_Id, string Estado_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                
                var query = from p in obj.Personal
                            join l in obj.RH_Area on p.Area_Id equals l.Area_Id
                            join c in obj.Cargo on p.Cargo_Id equals c.Cargo_id
                            join a in obj.Categoria_Auxiliar on p.Categoria_Auxiliar_Id equals a.Categoria_Auxiliar_Id
                            join b in obj.Categoria_Auxiliar2 on p.Categoria_Auxiliar2_Id equals b.Categoria_Auxiliar2_Id
                            where (p.Apellido_Paterno.Trim() + p.Apellido_Materno.Trim() + p.Nombres.Trim()).Contains(Nombres)
                            && p.Area_Id.Contains(Area_Id)
                            && p.Estado_Id.Contains(Estado_Id)
                            select new
                            {
                                p.Personal_Id,
                                Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                RH_Area = l.Descripcion,
                                Cargo = c.Descripcion,
                                CatAux = a.Descripcion,
                                CatAux2 = b.Descripcion,
                                p.Estado_Id
                            };
               
                return query.Count();
            }
        }

        public Personal Get_Personal_Find(string Personal_id) {
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_id).Count();
                if (existe == 1)
                {
                    return obj.Personal.Where(x => x.Personal_Id == Personal_id).First();
                }
                else {
                    return null;
                }
            
            }
        }

        public string Get_Foto_By_Personal(string Personal_id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.FotoPersonal.Where(x => x.Personal_Id == Personal_id).Count();
                if (existe > 0)
                {
                    return obj.FotoPersonal.Where(x => x.Personal_Id == Personal_id).First().NameFoto;
                }
                else {
                    return "UserNoPhoto.png";
                }
            }
        }

        public string Get_Add_Personal(string Planilla_Id, string Apellido_Paterno, string Apellido_Materno, string Nombres, DateTime Fecha_Nacimiento, string Nro_Doc,
            string email, string Cargo_Id,string Area_Id, string Categoria_Auxiliar_Id,string Categoria_Auxiliar2_Id,string CodigoLG,string Estado_Id, string RolSistema)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    string Personal_Id = Get_NewPrimaryKey();

                    int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                    if (existe == 0)
                    {
                        Personal per = new Personal();
                        per.Personal_Id = Personal_Id;
                        per.Planilla_Id = Planilla_Id;
                        per.Apellido_Paterno = Apellido_Paterno;
                        per.Apellido_Materno = Apellido_Materno;
                        per.Nombres = Nombres;
                        per.Fecha_Nacimiento = Fecha_Nacimiento;
                        per.Nro_Doc = Nro_Doc;
                        per.email = email;
                        per.Cargo_Id = Cargo_Id;
                        per.Area_Id = Area_Id;
                        per.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;
                        per.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;
                        per.CodigoLG = CodigoLG;
                        per.Estado_Id = Estado_Id;
                        per.RolSistema = RolSistema;
                        obj.AddToPersonal(per);
                        obj.SaveChanges();
                        string actuUsu = "";
                        if (RolSistema != "03")
                        {
                            string nameUsu = Apellido_Paterno.ToUpper() + Apellido_Materno.ToUpper().Substring(0, 2);
                            Get_Insert_Usuario(nameUsu, Apellido_Paterno.ToUpper() + Apellido_Materno.ToUpper().Substring(0, 2), Estado_Id, Personal_Id);
                        }
                        return "true#Registrado Correctamente." + actuUsu;
                    }
                    return "false#.::Erro,Intentelo luego.";
                }
                }catch(Exception ex){
                    return "false#"+ex.Message;
                }
            
        }


        public string Get_Update_Personal(string Personal_Id,string Planilla_Id, string Apellido_Paterno
            , string Apellido_Materno, string Nombres, DateTime Fecha_Nacimiento, string Nro_Doc,string email, string Cargo_Id
            , string Area_Id, string Categoria_Auxiliar_Id, string Categoria_Auxiliar2_Id, string CodigoLG
            , string Estado_Id, string RolSistema,string Name,string Password,string Estado_Usuario )
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {


                    int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                    if (existe == 1)
                    {
                        Personal per = obj.Personal.Where(x => x.Personal_Id == Personal_Id).First();
                        per.Planilla_Id = Planilla_Id;
                        per.Apellido_Paterno = Apellido_Paterno;
                        per.Apellido_Materno = Apellido_Materno;
                        per.Nombres = Nombres;
                        per.Fecha_Nacimiento = Fecha_Nacimiento;
                        per.Nro_Doc = Nro_Doc;
                        per.email = email;
                        per.Cargo_Id = Cargo_Id;
                        per.Area_Id = Area_Id;
                        per.Categoria_Auxiliar_Id = Categoria_Auxiliar_Id;
                        per.Categoria_Auxiliar2_Id = Categoria_Auxiliar2_Id;
                        per.CodigoLG = CodigoLG;
                        per.Estado_Id = Estado_Id;
                        per.RolSistema = RolSistema;
                        obj.SaveChanges();
                        string actuUsu = "";
                       if (RolSistema != "03")
                        {
                           string nameUsu=Apellido_Paterno.ToUpper() + Apellido_Materno.ToUpper().Substring(0, 2);
                           actuUsu = Get_Update_Usuario(nameUsu, Password, Estado_Usuario, Personal_Id);
                        }
                        return "true#Actualizado Correctamente." + actuUsu;
                    }
                    return "false#.::Error, Intentelo luego.";

                }
            }catch(Exception ex){
                return "false#" + ex.Message;
            }
        }

        
        public bool Get_DeleteEstado_Personal(string Personal_Id,string Estado_Id) { 
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe == 1) {
                    Personal per = obj.Personal.Where(x => x.Personal_Id == Personal_Id).First();
                    per.Estado_Id = Estado_Id;
                    obj.SaveChanges();                    
                    return true;
                }
                return false;
            
            }
        }

        public string Get_NewPrimaryKey() { 
            using(ContextMaestro obj=new ContextMaestro()){
                int cant = obj.Personal.Count();

                if (cant == 0)
                {
                    return "000001";
                }
                else {

                    string max = obj.Personal.Max(m => m.Personal_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(6, '0');
                    return max;
                }
            
            }        
        }


        //USUARIO PERSONAL

        public Usuario Get_Usuario_Personal(string Personal_Id) {
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.Usuario.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe == 1)
                {
                    return obj.Usuario.Where(x => x.Personal_Id == Personal_Id).First();
                }
                else {
                    return null;                
                }
            }
        
        }

        public string Get_Insert_Usuario(string Name,string Password,string Estado,string Personal_Id) { 
            using(ContextMaestro obj=new ContextMaestro()){
                int existe = obj.Usuario.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe == 0)
                {
                    if (Name.Length > 10) {
                        Name = Name.Substring(0, 10);
                    }
                    Usuario usu =new Usuario();
                    usu.Personal_Id = Personal_Id;
                    usu.Name = Name;
                    usu.Password = Password;
                    usu.Estado = Estado;
                    obj.AddToUsuario(usu);
                    obj.SaveChanges();
                    return " Usuario Insertado Correctamente.";
                }
                else {
                    return " .::Error, Usuario no insertado.";
                }
            }
        }

        public string Get_Update_Usuario(string Name, string Password, string Estado, string Personal_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Usuario.Where(x => x.Personal_Id == Personal_Id).Count();
                if (existe == 0)
                {
                    if (Name.Length > 10)
                    {
                        Name = Name.Substring(0, 10);
                    }
                    if(Password==""){
                        Password = Name;
                    }
                    Usuario usu = new Usuario();
                    usu.Name = Name;
                    usu.Personal_Id = Personal_Id;
                    usu.Password = Password;
                    usu.Estado = Estado;
                    obj.AddToUsuario(usu);
                    obj.SaveChanges();
                    return " Usuario Creado Correctamente.";
                }
                if (existe == 1)
                {
                    if (Name.Length > 10)
                    {
                        Name = Name.Substring(0, 10);
                    }
                    Usuario usu = obj.Usuario.Where(x => x.Personal_Id == Personal_Id).First();
                    usu.Name = Name;
                    //usu.Password = Password;
                    usu.Estado = Estado;
                    obj.SaveChanges();
                    return " Usuario Actualizado Correctamente.";
                }
                else
                {
                    return " .::Error, Usuario no actualizado.";
                }
            }
        }

        //SUBIR FOTO DEL PERSONAL


        public bool Get_GuardarDatosFotoPersonal(string Personal_Id,string FotoName) {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    int existe = obj.FotoPersonal.Where(x => x.Personal_Id == Personal_Id).Count();
                    if (existe > 0)
                    {
                        FotoPersonal fot = obj.FotoPersonal.Where(x => x.Personal_Id == Personal_Id).First();
                        fot.NameFoto = FotoName;
                        obj.SaveChanges();
                        return true;
                    }
                    else
                    {
                        FotoPersonal nfot = new FotoPersonal();
                        nfot.Personal_Id = Personal_Id;
                        nfot.NameFoto = FotoName;
                        nfot.UrlFot = "";
                        obj.AddToFotoPersonal(nfot);
                        obj.SaveChanges();
                        return true;
                    }
                }
            }catch(Exception ex){
                return false;
            }
        }

        public string Get_DeleteFotoPersonal(string Personal_Id)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    int existe = obj.FotoPersonal.Where(x => x.Personal_Id == Personal_Id).Count();
                    if (existe > 0)
                    {
                        FotoPersonal fot = obj.FotoPersonal.Where(x => x.Personal_Id == Personal_Id).First();
                       
                        return fot.NameFoto;
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
