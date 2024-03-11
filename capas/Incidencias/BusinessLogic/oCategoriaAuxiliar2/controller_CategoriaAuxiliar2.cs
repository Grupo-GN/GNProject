using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PersistenceI;
using System.Collections;
namespace BusinessLogic.oCategoriaAuxiliar2
{
    public class controller_CategoriaAuxiliar2
    {
        private static controller_CategoriaAuxiliar2 Instance = null;
        public static controller_CategoriaAuxiliar2 Get_Instance()
        {
            return Instance == null ? Instance = new controller_CategoriaAuxiliar2() : Instance;
        }
        private static int FINALROWS = 12;
        public ArrayList Get_CategoriaAuxliar2_List(string CateAux1,string Descripcion, int inicio)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                rList.AddRange(obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar_id.Contains(CateAux1) &&
                           x.Descripcion.Contains(Descripcion)).Join(obj.Categoria_Auxiliar, a => a.Categoria_Auxiliar_id, b => b.Categoria_Auxiliar_Id,
                           (a, b) => new
                           {
                               a.Categoria_Auxiliar2_Id
                               ,CategoriaAux2 = a.Descripcion
                               ,CategoriaAux = b.Descripcion
                           }).OrderBy(o => o.CategoriaAux).Skip(inicio).Take(FINALROWS).ToList());

                return rList;
               /* return obj.Categoria_Auxiliar2.Where(x =>x.Categoria_Auxiliar_id.Contains(CateAux1) &&
                        x.Descripcion.Contains(Descripcion)).OrderBy(o => o.Descripcion).
                    Skip(inicio).Take(FINALROWS).ToList();*/
            }
        }

        public List<Categoria_Auxiliar> Get_CategoriaAuxliar_Combo() { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.Categoria_Auxiliar.OrderBy(o=> o.Descripcion).ToList();
            }
        }
        public int Get_CategoriaAuxliar2_List_MaxRows(string CateAux1, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                ArrayList rList = new ArrayList();
                rList.AddRange(obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar_id.Contains(CateAux1) &&
                           x.Descripcion.Contains(Descripcion)).Join(obj.Categoria_Auxiliar, a => a.Categoria_Auxiliar_id, b => b.Categoria_Auxiliar_Id,
                           (a, b) => new
                           {
                               a.Categoria_Auxiliar2_Id                               
                           }).ToList());

                return rList.Count;

            }
        }

        public Categoria_Auxiliar2 Get_CategoriaAuxliar2_Find(string Categoria2_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int exite = obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar2_Id == Categoria2_Id).Count();
                if (exite == 1)
                {
                    return obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar2_Id == Categoria2_Id).First();
                }
                else
                {
                    return null;
                }
            }
        }


        public bool Get_Add_CategoriaAuxliar2(string Categoria_Id,string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string codigo = Get_New_PrimaryKey_CateAux2();
                int existe = obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar2_Id == codigo).Count();

                if (existe == 0)
                {
                    Categoria_Auxiliar2 cat = new Categoria_Auxiliar2();
                    cat.Categoria_Auxiliar_id = Categoria_Id;
                    cat.Categoria_Auxiliar2_Id = codigo;
                    cat.Descripcion = Descripcion;
                    obj.AddToCategoria_Auxiliar2(cat);
                    obj.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string Get_New_PrimaryKey_CateAux2()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Categoria_Auxiliar2.Count();
                if (cant == 0)
                {
                    return "0";
                }
                else
                {
                    string max = obj.Categoria_Auxiliar2.Max(m => m.Categoria_Auxiliar2_Id);
                    max = (int.Parse(max) + 1).ToString();
                    return max;
                }

            }
        }

        public bool Get_Update_CategoriaAuxliar2(string Categoria2_Id, string Categoria_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar2_Id == Categoria2_Id).Count();

                if (existe == 1)
                {
                    Categoria_Auxiliar2 cat = obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar2_Id == Categoria2_Id).First();
                    cat.Categoria_Auxiliar_id = Categoria_Id;
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
