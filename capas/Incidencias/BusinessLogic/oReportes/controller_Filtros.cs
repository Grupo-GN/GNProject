using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence;
using PersistenceI;

namespace BusinessLogic.oReportes
{
    public class controller_Filtros
    {
        private static controller_Filtros Instance = null;
        public static controller_Filtros Get_Instance() { 
            return Instance==null?Instance=new controller_Filtros():Instance;
        }

        //RH_Area

        public List<RH_Area> Get_Localidad() {
            using (ContextMaestro obj = new ContextMaestro()) {
                return obj.RH_Area.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public List<Categoria_Auxiliar> Get_Categoria_Auxiliar() { 
            using(ContextMaestro obj=new ContextMaestro()){
                return obj.Categoria_Auxiliar.OrderBy(o => o.Descripcion).ToList();
            }
        }
        public List<Categoria_Auxiliar2> Get_Categoria_Auxiliar2(string Cate1)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Categoria_Auxiliar2.Where(x=> x.Categoria_Auxiliar_id.Contains(Cate1)).OrderBy(o => o.Descripcion).ToList();
            }
        }

        public List<Intensidad> Get_Intensidad() {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Intensidad.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public List<Severidad> Get_Severidad()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Severidad.OrderBy(o => o.Descripcion).ToList();
            }
        }
        public List<Tipo> Get_Tipo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Tipo.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public List<Origen> Get_Origen()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Origen.OrderBy(o => o.Descripcion).ToList();
            }
        }
    }
}
