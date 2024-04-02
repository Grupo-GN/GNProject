using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
     public class Ent_Ocupacion
    {
        string _Ocupacion_Id;

        public string Ocupacion_Id
        {
            get { return _Ocupacion_Id; }
            set { _Ocupacion_Id = value; }
        }
        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        string _Regimen_Laboral_Id;

        public string Regimen_Laboral_Id
        {
            get { return _Regimen_Laboral_Id; }
            set { _Regimen_Laboral_Id = value; }
        }
        Boolean _Ejecutivo;

        public Boolean Ejecutivo
        {
            get { return _Ejecutivo; }
            set { _Ejecutivo = value; }
        }
        Boolean _Empleado;

        public Boolean Empleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }
        Boolean _Obrero;

        public Boolean Obrero
        {
            get { return _Obrero; }
            set { _Obrero = value; }
        }
    }
}
