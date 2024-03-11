using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.oLocalidad
{
    public class controller_Localidad
    {
        private static controller_Localidad Instance = null;
        public static controller_Localidad Get_Instance()
        {
            return Instance == null ? Instance = new controller_Localidad() : Instance;
        }
        public static int FINALROWS = 12;
        public List<RH_Area> Get_Localidad_List(/*string descripcion,*/ int inicio)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                List<RH_Area> rList = new List<RH_Area>();
                rList = obj.RH_Area.OrderBy(o => o.Descripcion).Skip(inicio).Take(FINALROWS).ToList();
                return rList;
            }
        }
        public int Get_Localidad_List_MaxRows()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.RH_Area.Count();
            }
        }

        public RH_Area Get_Localidad_Find(string Area_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.RH_Area.Where(x => x.Area_Id == Area_Id).Count();
                if (existe > 0)
                {
                    return obj.RH_Area.Where(x => x.Area_Id == Area_Id).First();
                }
                else
                {
                    return null;
                }
            }
        }
        public string Get_Localidad_Add(string Descripcion, string Direccion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Area_Id = Get_PrimaryKey_Localidad();
                int existe = obj.RH_Area.Where(x => x.Area_Id == Area_Id).Count();
                if (existe == 0)
                {
                    RH_Area loc = new RH_Area();
                    loc.Area_Id = Area_Id;
                    loc.Descripcion = Descripcion;
                    loc.Direccion = Direccion;
                    obj.AddToRH_Area(loc);
                    obj.SaveChanges();
                    return "true#Registrado correctamente.";
                }
                else
                {
                    return "false#.::Error > Localidad ya registrada.";
                }
            }
        }
        public string Get_PrimaryKey_Localidad()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.RH_Area.Count();
                if (cant == 0)
                {
                    return "01";
                }
                else
                {
                    string max = obj.RH_Area.Max(m => m.Area_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(2, '0');
                    return max;
                }
            }
        }

        public string Get_Localidad_Update(string Area_Id, string Descripcion, string Direccion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.RH_Area.Where(x => x.Area_Id == Area_Id).Count();
                if (existe > 0)
                {


                    RH_Area loc = obj.RH_Area.Where(x => x.Area_Id == Area_Id).First();

                    if (loc.Descripcion != Descripcion)
                    {
                        int existereport = obj.ReporteIncidente.Where(x => x.Area_Id == Area_Id).Count();
                        if (existereport > 0)
                        {
                            return "false#.::Error > La localidad esta siendo usada, no se puede modificar el nombre la localidad.";
                        }
                    }

                    loc.Descripcion = Descripcion;
                    loc.Direccion = Direccion;
                    obj.SaveChanges();
                    return "true#Actualizado correctamente.";


                }
                else
                {
                    return "false#.::Error > Localidad no encontrada.";
                }
            }
        }
        public string Get_Localidad_Delete(string Area_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.RH_Area.Where(x => x.Area_Id == Area_Id).Count();
                if (existe > 0)
                {
                    int existereport = obj.ReporteIncidente.Where(x => x.Area_Id == Area_Id).Count();
                    if (existereport > 0)
                    {
                        return "false#.::Error > La localidad esta siendo usada, no se puede eliminar.";
                    }
                    RH_Area loca = obj.RH_Area.Where(x => x.Area_Id == Area_Id).First();
                    obj.DeleteObject(loca);
                    obj.SaveChanges();
                    return "true#Localidad eliminado correctamente.";
                }
                return "false#.::Error > Localidad no encontrada.";
            }
        }
    }
}
