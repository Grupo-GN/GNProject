using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.oPersonal
{
    public class controller_DatosPersonal
    {
        private static controller_DatosPersonal Instance = null;
        public static controller_DatosPersonal Get_Instance()
        {
            return Instance == null ? Instance = new controller_DatosPersonal() : Instance;
        }

        //PLANILLA 
        public List<Planilla> Get_Planilla_Combo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Planilla.Where(x => x.Estado_Id == "01").ToList();
            }
        }
        //CARGO 
        public List<Cargo> Get_Cargo_Combo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Cargo.Where(x => x.Estado_id == "01").ToList();
            }
        }
        //LOCALIDAD 
        public List<RH_Area> Get_Localidad_Combo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.RH_Area.OrderBy(o => o.Descripcion).ToList();
            }
        }

        //CATEGORIA AUXILIAR  
        public List<Categoria_Auxiliar> Get_Categoria_Auxiliar_Combo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Categoria_Auxiliar.OrderBy(o => o.Descripcion).ToList();
            }
        }
        //CATEGORIA AUXILIAR 2
        public List<Categoria_Auxiliar2> Get_Categoria_Auxiliar2_Combo(string Categoria_Auxiliar_id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Categoria_Auxiliar2.Where(x => x.Categoria_Auxiliar_id == Categoria_Auxiliar_id).OrderBy(o => o.Descripcion).ToList();
            }
        }
    }
}
