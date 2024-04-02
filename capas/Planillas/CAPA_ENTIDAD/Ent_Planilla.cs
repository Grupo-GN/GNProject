using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Planilla
    {
        string _Planilla_Id;

        public string Planilla_Id
        {
            get { return _Planilla_Id; }
            set { _Planilla_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        string _Compania_Id;

        public string Compania_Id
        {
            get { return _Compania_Id; }
            set { _Compania_Id = value; }
        }
        string _Periodicidad_Id;

        public string Periodicidad_Id
        {
            get { return _Periodicidad_Id; }
            set { _Periodicidad_Id = value; }
        }
        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }
        string _Planilla_Master_Id;

        public string Planilla_Master_Id
        {
            get { return _Planilla_Master_Id; }
            set { _Planilla_Master_Id = value; }
        }
    }
}
