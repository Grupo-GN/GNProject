using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;

namespace BusinessLogic.oCategoriaAuxiliar
{
    public class controller_CategoriaAuxiliar
    {
        private static controller_CategoriaAuxiliar Instance = null;
        public static controller_CategoriaAuxiliar Get_Instance() { 
            return Instance==null?Instance=new controller_CategoriaAuxiliar():Instance;
        }
        private static int FINALROWS = 12;
        public List<Categoria_Auxiliar> Get_CategoriaAuxliar_List(string Descripcion,int inicio) { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.Categoria_Auxiliar.Where(x => x.Descripcion.Contains(Descripcion)).OrderBy(o => o.Descripcion).
                    Skip(inicio).Take(FINALROWS).ToList();
            }
        }
        public int Get_CategoriaAuxliar_List_MaxRows(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Categoria_Auxiliar.Where(x => x.Descripcion.Contains(Descripcion)).Count();
            }
        }

        public Categoria_Auxiliar Get_CategoriaAuxliar_Find(string Categoria_Id)
        { 
            using(ContextMaestro obj=new ContextMaestro()){
                int exite = obj.Categoria_Auxiliar.Where(x => x.Categoria_Auxiliar_Id == Categoria_Id).Count();
                if (exite == 1)
                {
                    return obj.Categoria_Auxiliar.Where(x => x.Categoria_Auxiliar_Id == Categoria_Id).First();
                }
                else {
                    return null;
                }
            }
        }


        public bool Get_Add_CategoriaAuxliar(string Descripcion) {
            using(ContextMaestro obj=new ContextMaestro()){
                string codigo = Get_New_PrimaryKey_CateAux();
                int existe = obj.Categoria_Auxiliar.Where(x => x.Categoria_Auxiliar_Id == codigo).Count();

                if (existe == 0)
                {
                    Categoria_Auxiliar cat = new Categoria_Auxiliar();
                    cat.Categoria_Auxiliar_Id = codigo;
                    cat.Descripcion = Descripcion;
                    obj.AddToCategoria_Auxiliar(cat);
                    obj.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public string Get_New_PrimaryKey_CateAux() { 
            using(ContextMaestro obj=new ContextMaestro()){
                int cant = obj.Categoria_Auxiliar.Count();
                if (cant == 0)
                {
                    return "0";
                }
                else {
                    string max = obj.Categoria_Auxiliar.Max(m => m.Categoria_Auxiliar_Id);
                    max = (int.Parse(max) + 1).ToString();
                    return max;
                }
                
            }
        }

        public bool Get_Update_CategoriaAuxliar(string Categoria_Id,string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                
                int existe = obj.Categoria_Auxiliar.Where(x => x.Categoria_Auxiliar_Id == Categoria_Id).Count();

                if (existe ==1)
                {
                    Categoria_Auxiliar cat = obj.Categoria_Auxiliar.Where(x => x.Categoria_Auxiliar_Id == Categoria_Id).First();                    
                    cat.Descripcion = Descripcion;              
                    obj.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
