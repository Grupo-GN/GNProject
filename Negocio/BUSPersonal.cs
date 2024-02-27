using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Capas.Portal.Datos;
using Capas.Portal.Entidad;
using System.Data;


namespace Capas.Portal.Negocio
{    
    public class BUSPersonal
    {
        Datos.DAOPersonal objDatos = new DAOPersonal();

        public DataTable ListaCumpleDelDia()
        {
            return objDatos.ListaCumpleDelDia();
        }

        public DataTable ListaDirectorioEmp(String Nombres)
        {
            return objDatos.ListaDirectorioEmp(Nombres);
        }

        public List<Personal> GetDirectorioEmpxFiltros(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Nombres)
        {
            return objDatos.GetDirectorioEmpxFiltros(Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Nombres);
        }
        public DataTable ListaDirectorioEmpxFiltros(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Nombres)
        {
            return objDatos.ListaDirectorioEmpxFiltros(Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Nombres);
        }

        public DataTable ListaDistribucionxArea()
        {
            return objDatos.ListaDistribucionxArea();
        }

        public DataTable ListaPersonalAll()
        {
            return objDatos.ListaPersonalAll();
        }

        public DataTable ListaPersonal(String Planilla_Id, String Area_Id, String Categoria_Auxiliar_Id, String Categoria_Auxiliar2_Id)
        {
            return objDatos.ListaPersonal(Planilla_Id, Area_Id, Categoria_Auxiliar_Id, Categoria_Auxiliar2_Id);
        }

        public DataTable ListaPersonalxId(String Personal_Id)
        {
            return objDatos.ListaPersonalxId(Personal_Id);
        }

    }
}
