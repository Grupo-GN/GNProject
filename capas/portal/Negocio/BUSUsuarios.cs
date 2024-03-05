using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Capas.Portal.Datos;
using Capas.Portal.Entidad;

namespace Capas.Portal.Negocio
{
    public class BUSUsuarios
    {
        Datos.DAOUsuarios objDatos = new DAOUsuarios();

        public Int32 GetTotalVisitas()
        {
            return objDatos.GetTotalVisitas();
        }
        public Int32 UpdateContrasenia(Usuarios objUsu)
        {
            return objDatos.UpdateContrasenia(objUsu);
        }

        public Int32 AddUsers(Usuarios objUsu)
        {
            Entidad.Usuarios u = new Usuarios();
            u.User_Name = objUsu.User_Name;

            String Personal_Id = objUsu.Personal_Id;
            if (objDatos.ListaUserxPersonal_Id(Personal_Id).Rows.Count > 0)
            {
                throw new Exception("El Personal ya tiene Usuario.");
            }
            else if (ListaUsers(u).Rows.Count > 0)
            {
                throw new Exception("El Nombre de Usuario ya Existe.");
            }
            else
            {
                return objDatos.AddUsers(objUsu);
            }

        }

        public Int32 UpdateUsers(Usuarios objUsu)
        {
            return objDatos.UpdateUsers(objUsu);
        }

        public Int32 UpdateUsersFoto(String User_Id, String Ruta_Foto)
        {
            return objDatos.UpdateUsersFoto(User_Id, Ruta_Foto);
        }

        public Int32 DeleteUsers(Usuarios objUsu)
        {
            return objDatos.DeleteUsers(objUsu);
        }

        public Boolean ValidaLogin(Usuarios objUsu)
        {
            DataTable dt = new DataTable();
            Boolean rpta = false;
            dt = objDatos.ValidaLogin(objUsu);
            if (dt.Rows.Count > 0)
            {
                rpta = true;
            }
            else
            {
                rpta = false;
            }
            dt.Dispose();
            return rpta;
        }

        public void ActualizaVisitasIntranet(String User_Id)
        {
            objDatos.ActualizaVisitasIntranet(User_Id);
        }

        public DataTable ListaUsers(Usuarios objUsu)
        {
            return objDatos.ListaUsers(objUsu);
        }

        public List<Usuarios> GetUsuariosxFiltro(Int32 TipoBusqueda, String ValorOpcional)
        {
            return objDatos.GetUsuariosxFiltro(TipoBusqueda, ValorOpcional);
        }
        public DataTable ListaUsersxFiltro(Int32 TipoBusqueda, String ValorOpcional)
        {
            return objDatos.ListaUsersxFiltro(TipoBusqueda, ValorOpcional);
        }

        public DataTable ListaUserxId(Usuarios objUsu)
        {
            return objDatos.ListaUserxId(objUsu);
        }

        public DataTable ListaUserxUserName(Usuarios objUsu)
        {
            return objDatos.ListaUserxUserName(objUsu);
        }
        public DataTable ListaUserxDNI(int dni)
        {
            return objDatos.ListaUserxDNI(dni);
        }
    }
}
