using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controllerGenerarTRegistro
    {
        private static controllerGenerarTRegistro instance = null;
        public static controllerGenerarTRegistro getInstance()
        {
            return instance == null ? instance = new controllerGenerarTRegistro() : instance;
        }
        public string RetornarNombreArchivo(string Ejercicio, string PeriodoId)
        {
            string nombre = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT RUC FROM COMPANIA WHERE Compania_Id='01'", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cn.Open();
                    nombre = cmd.ExecuteScalar().ToString();
                }
            }
            //nombre += Ejercicio;
            //using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            //{
            //    using (SqlCommand cmd = new SqlCommand("SELECT MONTH(Fecha_Ini) [MES] FROM Periodo WHERE Periodo_Id='"+ PeriodoId + "'", cn))
            //    {
            //        cmd.CommandType = CommandType.Text;
            //        cn.Open();
            //        nombre += cmd.ExecuteScalar().ToString().PadLeft(2, '0');
            //    }
            //}
            return nombre;
        }
    }
}
