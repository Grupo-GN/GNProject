using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
using System.Collections;
namespace BusienssLogic.ConsultaPersonal.oMisBoletas
{
    public class controller_MisBoletas
    {
        private static controller_MisBoletas Instance = null;
        public static controller_MisBoletas Get_Instance() {
            return Instance == null ? Instance = new controller_MisBoletas() : Instance;
        }


        public ArrayList Get_Periodos_By_Personal(string Personal_Id) {
            using(ContextMaestro obj=new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection())){
                ArrayList rList = new ArrayList();

                var query = from pa in obj.Personal_activo
                            join pe in obj.Periodo on pa.Periodo_Id equals pe.Periodo_Id
                            join pl in obj.Planilla on pa.Planilla_Id equals pl.Planilla_Id
                            where pa.Personal_Id == Personal_Id
                            select new {
                                pe.Periodo_Id,
                                Periodo=pl.Descripcion+" - "+pe.Descripcion
                            };
                rList.AddRange(query.OrderByDescending(o=> o.Periodo_Id).ToList());
                return rList;            
            }        
        }
    }
}
