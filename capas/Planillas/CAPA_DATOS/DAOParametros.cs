using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.ApplicationBlocks.Data;

namespace CAPA_DATOS
{
    public class DAOParametros
    {
        public DataSet ListaCompania()
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "usp_ListaCompania");
        }

        public DataSet ListaTipoPlanilla(string Compania_Id)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "usp_ListaPlanilla", Compania_Id);
        }

        public DataSet ListaPeriodos(string Compania_Id, string Planilla_Id)
        {
            return SqlHelper.ExecuteDataset(Conex.CadCon(), "usp_ListaPeriodos", Compania_Id, Planilla_Id);
        }
    }
}
