using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.oLogin
{
    public class controller_Login
    {
        private static controller_Login Instance = null;
        public static controller_Login Get_Instance()
        {
            return Instance == null ? Instance = new controller_Login() : Instance;
        }

        public Personal Get_Acceso_Sistema(string Usuario, string contraseña)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Usuario.Where(x => x.Name == Usuario && x.Password == contraseña && x.Estado == "01").Count();
                if (existe == 1)
                {
                    string personalId = obj.Usuario.Where(x => x.Name == Usuario && x.Password == contraseña && x.Estado == "01").First().Personal_Id;

                    return obj.Personal.Where(x => x.Personal_Id == personalId).First();
                }
                else
                {
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
    }
}
