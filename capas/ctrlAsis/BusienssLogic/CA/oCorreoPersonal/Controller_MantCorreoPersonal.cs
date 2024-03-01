using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Presistence;
using System.Collections;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using Presistence.Customs;
using System.Data;
using System.Data.Linq.Mapping;

namespace BusienssLogic.CA.oCorreoPersonal
{
    public class Controller_MantCorreoPersonal
    {
        private static Controller_MantCorreoPersonal Instance = null;
        public static Controller_MantCorreoPersonal GetInstance()
        {
            return Instance == null ? Instance = new Controller_MantCorreoPersonal() : Instance;
        }




        public ArrayList Get_Planillas_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Planilla
                            where p.Estado_Id=="01"
                           // where p.Planilla_Id == "01" || p.Planilla_Id == "04"
                            select new { p.Planilla_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public ArrayList Get_Localidades_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.RH_Area // areas_planillas_sofya
                            select new { p.Area_Id, p.Descripcion };


                rlist.AddRange(query.ToList());
                return rlist;
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }

        public ArrayList Get_Secciones_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rList = new ArrayList();
                var query = from c in obj.Categoria_Auxiliar
                            where c.Categoria_Auxiliar_Id.Trim() != "00"
                            select new { c.Categoria_Auxiliar_Id, c.Descripcion };
                rList.AddRange(query.ToList());
                return rList;

            }
        }

        public List<Categoria2> Get_Categorias_List()
        {

            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                return obj.Categoria2.Where(x => x.Categoria2_Id == "01" || x.Categoria2_Id == "00" || x.Categoria2_Id == "02").ToList();
                //return obj.Planilla.OrderBy(o => o.Planilla_Id).Skip(inicio).Take(FINALLROWS).ToList();

            }
        }


     
        internal class Projectos
        {
            
            public    String Personal_Id { get; set; }
          
            public   String Area { get; set; }
            
            public   String Nombres { get; set; }
            
            public   String email { get; set; }
            // Declarations of other members suppressed for readability.
        }


        private static int FINALLROWS = 12;
        public ArrayList Get_CorreoPersonal_List_OLD(string planilla, string area_id, string seccion, string categoria2_Id, int inicio)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();

                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            join a in obj.RH_Area on pa.Area_Id equals a.Area_Id //areas_planillas_sofya
                            where /*pa.Fecha_cese == fechaCese && */p.Estado_Id == "01"
                            //&& pa.Planilla_Id.Contains(planilla)

                           && SqlMethods.Like(pa.Planilla_Id, "%" + planilla.Trim() + "%")
                           //&& pa.Area_Id.Contains(area_id)
                           && SqlMethods.Like(pa.Area_Id, "%" + area_id.Trim() + "%")
                            //&& pa.Categoria_Auxiliar_Id.Contains(seccion.Trim())
                            && SqlMethods.Like(pa.Categoria_Auxiliar_Id, "%" + seccion.Trim() + "%")
                            //&& pa.Categoria2_Id.Contains(categoria2_Id)
                            && SqlMethods.Like(pa.Categoria2_Id, "%" + categoria2_Id.Trim() + "%")
                            //&& (from paa in obj.Personal_activo
                            //    where paa.Personal_Id == p.Personal_Id
                            //    select paa.Periodo_Id).OrderByDescending(o => o).FirstOrDefault() == pa.Periodo_Id
                            select new
                           {
                               p.Personal_Id,
                               Area = a.Descripcion,
                               Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                               p.email
                           };

                query = query.OrderBy(o => o.Nombres).Skip(inicio).Take(FINALLROWS);

                rlist.AddRange(query.Distinct().ToList());
                return rlist;

            }
        }

        public ArrayList Get_CorreoPersonal_List(string planilla, string area_id, string seccion, string categoria2_Id, int inicio,string nombre)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.getConexion()))
            {
                //using (SqlCommand cmd = new SqlCommand("fps_sps_Asistencias", cn))
                using (SqlCommand cmd = new SqlCommand("SP_ListarPersonalCorreo", cn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@planilla_id", planilla);
                    cmd.Parameters.AddWithValue("@area_id", area_id);
                    cmd.Parameters.AddWithValue("@categoria_aux", seccion);
                    cmd.Parameters.AddWithValue("@categoria2", categoria2_Id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    cn.Open();
                    ArrayList rlist = new ArrayList();

                    var dt1 = new DataTable();
                    dt1.Columns.Add("Personal_Id", typeof(string));
                    dt1.Columns.Add("Area", typeof(string));
                    dt1.Columns.Add("Nombres", typeof(string));
                    dt1.Columns.Add("email", typeof(string));

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    List<Projectos> prjs = new List<Projectos>();
                    foreach (DataRow item in dt.Rows)
                    {
                        Projectos prjn = new Projectos
                        {
                            Personal_Id=(string)item[0],
                            Area = (string)item[1],
                            Nombres = (string)item[2],
                            email = (string)item[3]


                        };
                        prjs.Add(prjn);
                    }
                    rlist.AddRange(prjs);
                    //var lists = dt.AsEnumerable().ToList();
                    //rlist.AddRange(lists);
                    cn.Close();
                    return rlist;

                }
            }
        }

        public int Get_CorreoPersonal_List_MaxRows(string planilla, string area_id, string seccion, string categoria2_Id)
        {


            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                ArrayList rlist = new ArrayList();
                var query = from p in obj.Personal
                            join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                            join a in obj.RH_Area on pa.Area_Id equals a.Area_Id //areas_planillas_sofya
                            where /*pa.Fecha_cese == fechaCese && */p.Estado_Id == "01"
                            && pa.Planilla_Id.Contains(planilla)
                            && pa.Area_Id.Contains(area_id)
                            && pa.Categoria_Auxiliar_Id.Contains(seccion)
                            && pa.Categoria2_Id.Contains(categoria2_Id)
                            && (from paa in obj.Personal_activo
                                where paa.Personal_Id == p.Personal_Id
                                select paa.Periodo_Id).OrderByDescending(o => o).FirstOrDefault() == pa.Periodo_Id
                            select new
                            {
                                p.Personal_Id,
                                Area = a.Descripcion,
                                Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + ", " + p.Nombres,
                                p.email
                            };
               
                rlist.AddRange(query.Distinct().ToList());
                return rlist.Count;

            }
        }
        
            ///Metodo para Buscar

        public ArrayList Get_CorreoPersonal_Find(string codigo)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
            ArrayList rlist = new ArrayList();


            var query = from p in obj.Personal
                        join pa in obj.Personal_activo on p.Personal_Id equals pa.Personal_Id
                        join a in obj.RH_Area on pa.Area_Id equals a.Area_Id //areas_planillas_sofya
                        where p.Personal_Id.Contains(codigo)
                        select new
                        {
                            p.Personal_Id,
                            Nombres = p.Apellido_Paterno + " " + p.Apellido_Materno + " " + p.Nombres,
                            p.email
                        };



            query = query.OrderBy(o => o.Personal_Id).Take(FINALLROWS);
            rlist.AddRange(query.Distinct().ToList());

            return rlist;
        }
     }




        ///////////////////////////////////
        public bool Get_CorreoPersonal_Update(string codigo, string correo)
        {
            try
            {
                using (ContextMaestro objeto = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    //var Opcion_Nombre = "";
                    int lineas = objeto.Personal.Where(obj => obj.Personal_Id == codigo).Count();
                    if (lineas != 0)
                    {
                        Personal p = objeto.Personal.Where(o => o.Personal_Id == codigo).First();
                        p.email = correo;

                        objeto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}
