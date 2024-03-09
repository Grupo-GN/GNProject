using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Persistence;
using Persistence.eConexion;

namespace BusinessLogic.oLogin
{
    public class controller_Login
    {
        private static controller_Login Instance = null;
        public static controller_Login Get_Instance() {
            return Instance == null ? Instance = new controller_Login() : Instance;
        }

        public Personal Get_Acceso_Sistema(string Usuario,string contraseña) {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe=obj.Usuario.Where(x => x.Name == Usuario && x.Password==contraseña && x.Estado=="01").Count();
                if (existe == 1)
                {
                    string personalId = obj.Usuario.Where(x => x.Name == Usuario && x.Password == contraseña && x.Estado == "01").First().Personal_Id;
                    
                    return obj.Personal.Where(x => x.Personal_Id == personalId).First();
                }
                else {
                    return null;
                }                
            }
        }


        public Personal Get_PersonalLogin_Datos(string Personal_id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Personal.Where(x => x.Personal_Id == Personal_id).Count();
                if (existe == 1)
                {
                    return obj.Personal.Where(x => x.Personal_Id == Personal_id).First();
                }
                else
                {
                    return null;
                }
            }
        }
        public string getPersonalId(string dni)
        {
            using (SqlConnection cn = new SqlConnection(conex.getConexion()))
            {
                using (SqlCommand cmd = new SqlCommand("incidencias_get_userid", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dni", dni); // Asumiendo que 'dni' es el parámetro para el procedimiento almacenado

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return dr.GetString(0); // Devuelve el primer valor de cadena encontrado
                        }
                        else
                        {
                            return null; // Si no se encuentra ningún valor, devuelve null
                        }
                    }
                }
            }
        }
    }
}
