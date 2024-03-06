using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace BusienssLogic.CA.Marcas
{
   public class Marcas
    {
        private static Marcas Instance = null;
        string ConStr = Presistence.Customs.Conexion.getConexion();
        public static Marcas Get_Instance()
        {
            return Instance == null ? Instance = new Marcas() : Instance;
        }

          public class DatoEmpleado
        {
            public string Personal_id { set; get; }
            public string Nombres { set; get; }
            public string TipoT { set; get; }
            public string Area { set; get; }
            public byte[] Foto { set; get; }
            public string conexion { set; get; }
            public int tipoconexion { get; set; }

        }

        public class DatosMarcas
        {
            public string Fecha { set; get; }
            public string Ingreso { set; get; }
            public string Salida { set; get; }
            public string Ingreso_Refrigerio { set; get; }

            public string Salida_Refrigerio { set; get; }
 

        }


        public List<DatoEmpleado> ListaEmpleado(string nrodoc,string conexion)
        {
            List<DatoEmpleado> rlist = new List<DatoEmpleado>();
            string SPnom = string.Empty;
            SPnom = "usp_DataEmpleado";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nrodoc", nrodoc);//@conexion
                    cmd.Parameters.AddWithValue("@conexion", conexion);//@conexion
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DatoEmpleado nov = new DatoEmpleado();
                        nov.Personal_id = dr.GetValue(0).ToString();
                        nov.Nombres = dr.GetValue(1).ToString();
                        nov.TipoT = dr.GetValue(2).ToString();
                        nov.Area = dr.GetValue(3).ToString();
                        byte[] imgData = (byte[])dr.GetValue(4);
                        nov.Foto = imgData;
                        nov.conexion= dr.GetValue(5).ToString();
                        nov.tipoconexion = int.Parse( dr.GetValue(6).ToString());
                        rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.Nombres).ToList();
        }


        public List<DatosMarcas> ListaMarcacionesTop(string Personal_Id)
        {
            List<DatosMarcas> rlist = new List<DatosMarcas>();
            string SPnom = string.Empty;
            SPnom = "Sp_ListaMarcasTop10";
            using (SqlConnection cn = new SqlConnection(Presistence.Customs.Conexion.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand(SPnom, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@personal_Id", Personal_Id);//@conexion
                    
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DatosMarcas nov = new DatosMarcas();
                        nov.Fecha = dr.GetValue(0).ToString();
                        nov.Ingreso = dr.GetValue(1).ToString();
                        nov.Salida = dr.GetValue(2).ToString();
                        nov.Salida_Refrigerio = dr.GetValue(3).ToString();
                        nov.Ingreso_Refrigerio = dr.GetValue(4).ToString();
                         
                        rlist.Add(nov);
                    }
                    cmd.Parameters.Clear();
                    cn.Close();
                }
            }

            return rlist.OrderBy(o => o.Fecha).ToList();
        }


        public class Datas
        {
            public string id { get; set; }
            public string data { get; set; }
        }
        public  List<Datas> InsertarHora(string persona,DateTime fecha,DateTime hora, string tipo,string conexion,string tipoconexion)
        {
            List<Datas> horario = new List<Datas>();
            DataTable dt = new DataTable();
            dt = RUNTABLA("fps_spi_marcaciones_NW", persona,fecha.ToString("yyyy-MM-dd"),hora,tipo);

            int iid = 0;
            foreach (DataRow item in dt.Rows)
            {
                Datas nn = new Datas();
                iid = 0;
                iid = int.Parse(item[0].ToString());
                nn.id = item[0].ToString();
                nn.data = item[1].ToString();
                horario.Add(nn);
            }
            if (iid>0)
            {
                DataTable dtt = new DataTable();
                dtt = RUNTABLA("Sp_InsertarPersonalMarc", persona, fecha.ToString("yyyy-MM-dd"), hora, tipo,conexion,int.Parse(tipoconexion));
            }
            return horario;
        }



        DataTable RUNTABLA(string NOMPRO, params object[] Lista)
        {

            var cn = new SqlConnection(ConStr);
            //CREAR UN COMANDO PARA EJECUTAR EL PROCEDIMIENTO
            SqlCommand CMD = new SqlCommand(NOMPRO, cn);
            //SqlParameter PRM=new  SqlParameter();
            CMD.CommandType = CommandType.StoredProcedure;
            cn.Open();
            //PREPARAR AL COMANDO PARA QUE RECIBA VALORES
            SqlCommandBuilder.DeriveParameters(CMD);
            //ASIGNAR LOS VALORES A LOS PARAMETERS RESPECTIVO
            int CONTADOR = 0;
            //EXEC SPFECHA '12/11/96','10/11/98'
            //EQUIVALE LISTA(0)='12/11/96' LISTA(1)='10/11/98'
            foreach (SqlParameter PRM in CMD.Parameters)
            {
                if (PRM.ParameterName != "@RETURN_VALUE")
                {

                    PRM.Value = Lista[CONTADOR];
                    CONTADOR = CONTADOR + 1;
                }
            }

            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            cn.Close();
            return DT;

        }

        ArrayList converEmpleado(DataTable dt)
        {
            ArrayList myArrayList = new ArrayList();
            List<DatoEmpleado> glist = new List<DatoEmpleado>();

            foreach (DataRow item in dt.Rows)
            {
                DatoEmpleado HE = new DatoEmpleado();
                HE.Personal_id = item[0].ToString();
                HE.Nombres = item[1].ToString();
                HE.TipoT = item[2].ToString();
                HE.Area = item[3].ToString();
                HE.Foto = Encoding.ASCII.GetBytes(item[4].ToString());
  
                glist.Add(HE);

            }
            myArrayList.AddRange(glist);
            return myArrayList;
        }
        public ArrayList  Listaempleado2(string nrodoc)
        {
            ArrayList myArrayList = new ArrayList();
            DataTable dt = new DataTable();
            dt = RUNTABLA("usp_DataEmpleado", nrodoc);


            myArrayList = converEmpleado(dt);
            //foreach (DataRow dataRow in dt.Rows)  myArrayList.Add(string.Join(";", dataRow.ItemArray.Select(item =>  item.ToString())));

            return myArrayList;
        }

   IPGlobalProperties PROPIEDADES = IPGlobalProperties.GetIPGlobalProperties();

        string IpPublica()
        {
            String IPPUBLICA = "";
            WebClient ip = new WebClient();
            IPPUBLICA = ip.DownloadString("http://checkip.dyndns.org/").Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "").Replace("</body></html>", "") + "<br/>";
            return IPPUBLICA;
        }


            ArrayList DIRECCIONESIPV4 = new ArrayList();
            ArrayList DIRECCIONESIPV6 = new ArrayList();
        
        List<string> Listmac()
        {
            List<string> macl = new List<string>();
            string host = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostAddresses(host);
            NetworkInterface[] INTERFACES = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var INTERFAZ in INTERFACES)
            {
                macl.Add( INTERFAZ.GetPhysicalAddress().ToString());
            }
            return macl;
        }

        List<string> Lisip4()
        {
            List<string> listip4 = new List<string>();
            // 'IP PRIVADAS
             UnicastIPAddressInformationCollection DIRECCIONES = PROPIEDADES.GetUnicastAddresses();
            //TextBox1.Text = TextBox1.Text + "DIRECCIONES UNICAST EQUIPO LOCAL " + "\r\n";
            foreach (var item in DIRECCIONES)
            {
                if (item.Address.IsIPv6Teredo == true)
                {
                    //TextBox1.Text = TextBox1.Text + item.Address.ToString() + "   :  "
                    //+ item.Address.AddressFamily.ToString() + "  TEREDO  " +"<br/>";
                }
                if (item.Address.ToString().Contains(":"))
                {

                    DIRECCIONESIPV6.Add(item.Address.ToString());
                }
                else
                {
                    DIRECCIONESIPV4.Add(item.Address.ToString());
                }

            }

            if (DIRECCIONESIPV4.Count > 0)
            {
                    for (int i = 0; i < DIRECCIONESIPV4.Count - 1; i++)
                {
                    if (DIRECCIONESIPV4[i].ToString().Contains("169.254."))
                    {
                        //TextBox1.Text = TextBox1.Text + DIRECCIONESIPV4[i] + "  DHCP" + "<br/>";
                    }
                    else
                    {
                        listip4.Add( DIRECCIONESIPV4[i].ToString()) ;
                    }
                }
            }

            return listip4;
        }


 















    }
}
