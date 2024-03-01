using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Presistence
{
    public class Class1
    {

        private string ConStr = Customs.Conexion.getConexion();
        private static Class1 Instance = null;
        public static Class1 GetInstance()
        {
            return Instance == null ? Instance = new Class1() : Instance;
        }
        public DataTable RUNTABLA(string NOMPRO, params object[] Lista)
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

        public int RUNPRO(string NOMPRO , params object[] Lista ) {
        SqlConnection cn =new SqlConnection(ConStr);

        // CREAR UN COMANDO PARA EJECUTAR EL PROCEDIMIENTO
        SqlCommand CMD =new SqlCommand(NOMPRO, cn);
        CMD.CommandTimeout = 0;
        CMD.CommandType = CommandType.StoredProcedure;
        cn.Open();
        //PREPARAR AL COMANDO PARA QUE RECIBA VALORES
        SqlCommandBuilder.DeriveParameters(CMD);
        //ASIGNAR LOS VALORES A LOS PARAMETERS RESPECTIVO
        var CONTADOR = 0;

        foreach (SqlParameter PRM in CMD.Parameters)
            {
            if (PRM.ParameterName != "@RETURN_VALUE" ){
                PRM.Value = Lista[CONTADOR];
                CONTADOR = CONTADOR + 1;
            }
            }
        int  RES=0 ;
        RES = CMD.ExecuteNonQuery();
        cn.Close();
        return RES;

        }

        }
    
}
