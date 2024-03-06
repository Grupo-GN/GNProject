using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presistence;
namespace BusienssLogic.CA.oParametros
{
    public class Controller_MantParametros
    {


        private static Controller_MantParametros Instance = null;
        public static Controller_MantParametros GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantParametros() : Instance;
        }

        private static int FINALLROWS = 12;
        public List<ParametrosControlAsistencia> Get_Parametros_List(int inicio)
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {

                return obj.ParametrosControlAsistencia.OrderBy(o => o.Parametro_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }


        ///////////////////////////////////
        public bool Get_Parametros_Update(int codigo, string descripcion, string variable,  string valor,  string tipo, string abrev, string estado)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.ParametrosControlAsistencia.Where(obj => obj.Parametro_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        ParametrosControlAsistencia para = objeto.ParametrosControlAsistencia.Where(o => o.Parametro_Id == codigo).First();
                        para.Parametro_Id = codigo;
                        para.Descripcion = descripcion;
                        para.Variable = variable;
                        para.Valor = valor;
                        para.Tipo = tipo;
                        para.C_abrev = abrev;
                        para.C_estado = estado;
                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }



        ///Metodo para Buscar

        public ParametrosControlAsistencia Get_Parametros_Find(int codigo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    int lineas = objeto.ParametrosControlAsistencia.Where(obj => obj.Parametro_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        ParametrosControlAsistencia para = objeto.ParametrosControlAsistencia.Where(obj => obj.Parametro_Id == codigo).First();
                        if (para != null)
                            return para;
                    }
                    return null;
                }
            }

            catch (Exception ex) { throw ex; }
        }


        public int Get_Parametros_MaxRegistro()
        {
            using (ContextMaestro objContexto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                List<ParametrosControlAsistencia> oLista = new List<ParametrosControlAsistencia>();
                oLista.Clear();
                oLista = objContexto.ParametrosControlAsistencia.ToList();
                return oLista.Count;
            }
        }





        ///Metodo para Insertar
        public bool Get_Parametros_Add(string descripcion, string variable, string valor, string tipo,string abrev, string estado)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {

                    int lineasafectadas = objeto.ParametrosControlAsistencia.Count();

                    ParametrosControlAsistencia para = new ParametrosControlAsistencia();

                    para.Descripcion = descripcion;
                    para.Variable = variable;
                    para.Valor = valor;
                    para.Tipo = tipo;
                    para.C_abrev = abrev;
                    para.C_estado = estado;
                    objeto.AddToParametrosControlAsistencia(para);
                    objeto.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex) { throw ex; }

        }

    }

}
