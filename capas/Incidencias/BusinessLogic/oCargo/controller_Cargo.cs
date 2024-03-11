using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
namespace BusinessLogic.oCargo
{
    public class controller_Cargo
    {
        private static controller_Cargo Instance = null;
        public static controller_Cargo Get_Instance() {
            return Instance == null ? Instance = new controller_Cargo() : Instance;
        }
        private static int FINALROWS = 12;
        public List<Cargo> Get_Cargo_List(string Descripcion,string Estado,int inicio) { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.Cargo.Where(x => x.Descripcion.Contains(Descripcion) && x.Estado_id == Estado).
                    OrderBy(o => o.Descripcion).Skip(inicio).Take(FINALROWS).ToList();
            }
        }

        public int Get_Cargo_List_MaxRows(string Descripcion, string Estado)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Cargo.Where(x => x.Descripcion.Contains(Descripcion) && x.Estado_id == Estado).Count();                    
            }
        }

        public bool Get_Add_Cargo(string Descripcion,string Estado) {
            using(ContextMaestro obj=new ContextMaestro()){
                string cargo_id = Get_PrimaryKey_Cargo();

                int existe = obj.Cargo.Where(x => x.Cargo_id == cargo_id).Count();

                if (existe == 0) {
                    Cargo car = new Cargo();
                    car.Cargo_id = cargo_id;
                    car.Descripcion = Descripcion;
                    car.Estado_id = Estado;
                    obj.AddToCargo(car);
                    obj.SaveChanges();                    
                    return true;
                }   
                return false;
               
            }        
        }

        public bool Get_Update_Cargo(string Cargo_Id,string Descripcion, string Estado)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string cargo_id = Get_PrimaryKey_Cargo();

                int existe = obj.Cargo.Where(x => x.Cargo_id == cargo_id).Count();
                if (existe == 1)
                {
                    Cargo car = obj.Cargo.Where(x => x.Cargo_id == cargo_id).First();
                    car.Descripcion = Descripcion;
                    car.Estado_id = Estado;
                    obj.SaveChanges();
                    return true;
                }
                return false;

            }
        }

        public bool Get_Delete_Estado_Cargo(string Cargo_Id, string Estado)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {


                int existe = obj.Cargo.Where(x => x.Cargo_id == Cargo_Id).Count();
                if (existe == 1)
                {
                    Cargo car = obj.Cargo.Where(x => x.Cargo_id == Cargo_Id).First();                    
                    car.Estado_id = Estado;
                    obj.SaveChanges();
                    return true;
                }
                return false;

            }
        }

        public Cargo Get_Find_Cargo(string Cargo_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {


                int existe = obj.Cargo.Where(x => x.Cargo_id == Cargo_Id).Count();
                if (existe == 1)
                {
                    return obj.Cargo.Where(x => x.Cargo_id == Cargo_Id).First();
                    
                }
                return null;

            }
        }

        public string Get_PrimaryKey_Cargo() { 
            using(ContextMaestro obj=new ContextMaestro()){
                int cant = obj.Cargo.Count();
                if (cant == 0)
                {
                    return "000";
                }
                else {
                    string max = obj.Cargo.Max(m => m.Cargo_id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }

    }
}
