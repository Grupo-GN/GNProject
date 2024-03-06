using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using Presistence;

namespace BusienssLogic.CA.oRegistrarMarcaciones
{
    public class Controller_RegistrarMarcaciones
    {
       public static Controller_RegistrarMarcaciones Instance = null;
       public static Controller_RegistrarMarcaciones GetInstance() {
            return Instance == null ? Instance = new Controller_RegistrarMarcaciones() : Instance; 
        }
        
        public Periodo_Asistencia Get_Periodo_Asistencia_List()
        {
            try {
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    Periodo_Asistencia rlista = new Periodo_Asistencia();
                    rlista = obj.Periodo_Asistencia.Where(a => a.Estado == true).OrderBy(o => o.Periodo).First();
                    return rlista;

                }                          
            }
            catch (Exception ex) {
                throw ex;
            }        
        
        }

        public class MarcasN
        {
            public string Nombres { get; set; }
            public string CODPER { get; set; }
            public string FECHA { get; set; }
            public DateTime HORAINGRESO { get; set; }
            public DateTime HORASALIDA { get; set; }
            public string resultado { get; set; }
             


        }



        public List<ServRef_Marcaciones.eMarcacion> ImportarMarcaciones(DateTime i_FechaIni, DateTime i_FechaFin, string i_Personal)
        {
            List<ServRef_Marcaciones.eMarcacion> rList = new List<ServRef_Marcaciones.eMarcacion>();
            List<MarcasN> rListN = new List<MarcasN>();
            using (ServRef_Marcaciones.MarcacionesClient ws = new ServRef_Marcaciones.MarcacionesClient())
            {
                rList = ws.GetMarcaciones(i_FechaIni, i_FechaFin, i_Personal).ToList();
         
            }
            return rList;
        }

        public List<MarcasN> ImportarMarcaciones2(DateTime i_FechaIni, DateTime i_FechaFin, string i_Personal)
        {
            List<ServRef_Marcaciones.eMarcacion> rList = new List<ServRef_Marcaciones.eMarcacion>();
            List<MarcasN> rListN = new List<MarcasN>();
            using (ServRef_Marcaciones.MarcacionesClient ws = new ServRef_Marcaciones.MarcacionesClient())
            {
                rList = ws.GetMarcaciones(i_FechaIni, i_FechaFin, i_Personal).ToList();
                foreach (var item in rList)
                {
                    ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection());
                    var nombre = obj.Personal.Where(s => s.Nro_Doc == item.CODPER)
                              .Select(s => s)
                              .Where(st => st.Nro_Doc == item.CODPER)
                              .Select(s => s.Nombres + " " + s.Apellido_Paterno + " " + s.Apellido_Materno);
                    MarcasN marca = new MarcasN();
                    marca.CODPER = item.CODPER;
                    marca.Nombres = nombre.ToString();
                    marca.FECHA = DateTime.Parse(item.FECHA.ToString()).ToString("yyyy-MM-dd");
                    marca.HORAINGRESO = item.HORAINGRESO;
                    marca.HORASALIDA = item.HORASALIDA;
                    marca.resultado = item.ExtensionData.ToString();
                    rListN.Add(marca);

                }
            }
            return rListN;
        }


        public ArrayList Get_Periodo_List(string Planilla_Id, DateTime fecha)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int mes = fecha.Month;
                retorna:
                var query = from p in obj.Periodo
                            where p.Planilla_Id == Planilla_Id
                            && p.Estado_Id == "02"
                            && p.Fecha_Ini.Year == fecha.Year
                            && p.Fecha_Ini.Month == mes
                            select new { p.Periodo_Id, p.Descripcion, p.Fecha_Ini,p.Fecha_Fin };
                ArrayList rList = new ArrayList();
                rList.AddRange(query.OrderByDescending(o => o.Fecha_Ini).Take(1).ToList());
                if (rList.Count == 0)
                {
                    mes = mes - 1;
                    goto retorna;
                }

                return rList;

            }

        }

        public List<Periodo> Get_Periodo_New(string Planilla_Id,DateTime fecha)
        {
            using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
            {
                int mes = fecha.Month;
                retorna:
                List<Periodo> rList = new List<Periodo>();
                rList = obj.Periodo.Where(p => p.Planilla_Id == Planilla_Id && p.Estado_Id == "02" && p.Fecha_Ini.Year == fecha.Year  && p.Fecha_Ini.Month == mes).ToList();          
                //rList=query.OrderByDescending(o => o.Fecha_Ini).First();
                if (rList.Count == 0)
                {
                    mes = mes - 1;
                    goto retorna;
                }

                return rList;

            }
        }

        public List<string> RegistrarMarcaciones(List<string> i_list)
        {
            List<string> rList = new List<string>();
            try
            {
                //int con1  = 0;
                //int con2  = 0;

                var co_trabajador = "";
                DateTime fecha = new DateTime();
                DateTime hora = new DateTime();
                var tipo = "";

                Int32 rpta;
                var msj = "";
                for (int i = 0; i <= i_list.Count - 1; i++)
                {
                    string[] valores = i_list[i].Split('|');
                    string cadena = "";
                    co_trabajador = valores[0];
                    fecha = Convert.ToDateTime(valores[1]).Date;
                    hora = Convert.ToDateTime(valores[1] + " " + valores[2]);
                    tipo = "1";
                 
                    cadena = co_trabajador + "|" + fecha.ToString("ddMMyyyy");
                    //DataTable dtdel = new DataTable();
                    //dtdel = Class1.GetInstance().RUNTABLA("Usp_DelMarcas", co_trabajador, fecha);
                    // 08- 02- 2021
                    DataTable dtResult = new DataTable();
                    if (valores[2] != "")
                    {
                        dtResult = Class1.GetInstance().RUNTABLA("fps_spi_marcaciones", co_trabajador, fecha, hora, tipo);
                        rpta = Convert.ToInt32(dtResult.Rows[0][0].ToString());
                        msj = dtResult.Rows[0][1].ToString();
                        if (rpta < 0)
                        {
                            cadena += "|Ingreso:|false|<label class='labelError'>" + msj + "</label>";
                        }
                        else
                        {
                            cadena += "|Ingreso:|true|" + msj;
                           
                        }
                    }
                    if (valores[3] != "")
                    {
                        hora = Convert.ToDateTime(valores[1] + " " + valores[3]);
                        tipo = "2";
                        dtResult = new DataTable();
                        dtResult = Class1.GetInstance().RUNTABLA("fps_spi_marcaciones", co_trabajador, fecha, hora, tipo);
                        rpta = Convert.ToInt32(dtResult.Rows[0][0].ToString());
                        msj = dtResult.Rows[0][1].ToString();
                        if (rpta < 0)
                        {
                            cadena += "|Salida:|false|<label class='labelError'>" + msj + "</label>";
                        }
                        else
                        { 
                            cadena += "|Salida:|true|" + msj;
                            
                        }

                    }
                    rList.Add(cadena);
                    ActualizarFaltas("", "2", co_trabajador);
                }

            }
            catch (Exception ex)
            {
                string error121 = ex.Message;
            }
            return rList;
        }


        public DataTable ActualizarFaltas(string Personal_id,string tipo, string trabajador_id)
        {
            DataTable dt = new DataTable();
            try
            {
               
                using (ContextMaestro obj = new ContextMaestro("name=" + Presistence.Customs.Conexion.getCodEmpresaConnection()))
                {
                    
                    dt = Class1.GetInstance().RUNTABLA("SP_Updatefalta", Personal_id,DateTime.Today.ToShortDateString(),tipo,trabajador_id);

                   
                }
                return dt;
            }
            catch (Exception ex) { //throw ex
                    string ss = "";
                    ss = ex.Message;
                return dt;
                    }

        }


    }
}
