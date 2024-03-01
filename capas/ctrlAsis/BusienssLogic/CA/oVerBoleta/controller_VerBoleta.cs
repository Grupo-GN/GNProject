using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Presistence;
namespace BusienssLogic.CA.oVerBoleta
{
    public class controller_VerBoleta
    {
        private static controller_VerBoleta Instance = null;
        public static controller_VerBoleta Get_Instance() {
            return Instance == null ? Instance = new controller_VerBoleta() : Instance;
        }

        public ArrayList Get_Personal_All_By_Periodo(string Periodo_Id, string Localidad_Id, string CategoriaAux, string CategoriaAux2, string Categoria,string PersonalFind)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                if (PersonalFind.Trim() != "") {
                    PersonalFind = PersonalFind.Replace(" ", "");
                }

                ArrayList rList = new ArrayList();
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && pa.Categoria_Auxiliar_Id.Contains(CategoriaAux)
                            && pa.Categoria_Auxiliar2_Id.Contains(CategoriaAux2)
                            && pa.Categoria2_Id.Contains(Categoria)
                            && (p.Apellido_Paterno + p.Apellido_Materno + p.Nombres).ToUpper().Contains(PersonalFind)
                            select new
                            {
                                pa.Personal_Id,
                                PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                            };
                query = query.OrderBy(o => o.PersonalName);
                rList.AddRange(query.ToList());
                return rList;
            } 
        }

        public ArrayList Get_Personal_All_By_Jefe(string Periodo_Id, string Localidad_Id, string PersonalFind, string Jefe_Id)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                if (PersonalFind.Trim() != "")
                {
                    PersonalFind = PersonalFind.Replace(" ", "");
                }

                ArrayList rList = new ArrayList();
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            join jp in obj.Jefe_Personal on pa.Personal_Id equals jp.Personal_Id
                            where pa.Periodo_Id == Periodo_Id
                            && jp.Jefe_Id == Jefe_Id
                            && pa.Area_Id.Contains(Localidad_Id)
                            && (p.Apellido_Paterno + p.Apellido_Materno + p.Nombres).ToUpper().Contains(PersonalFind)
                            select new
                            {
                                pa.Personal_Id,
                                PersonalName = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres
                            };
                query = query.OrderBy(o => o.PersonalName);
                rList.AddRange(query.ToList());
                return rList;
            }
        }

    }
}
