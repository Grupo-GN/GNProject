using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPA_DATOS;
using System.Data;

namespace CAPA_LOGICO
{
    public class BUSParametros
    {
        CAPA_DATOS.DAOParametros objDatos = new DAOParametros();
        public DataSet ListaCompania()
        {
            return objDatos.ListaCompania();
        }
        public DataSet ListaTipoPlanilla(string Compania_Id)
        {
            return objDatos.ListaTipoPlanilla(Compania_Id);
        }

        public DataSet ListaPeriodos(string Compania_Id, string Planilla_Id)
        {
            return objDatos.ListaPeriodos(Compania_Id, Planilla_Id);
        }
    }
}
