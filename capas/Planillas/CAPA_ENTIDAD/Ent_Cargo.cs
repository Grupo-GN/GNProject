using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Cargo
    {
        string _Cargo_Id;

        public string Cargo_Id
        {
            get { return _Cargo_Id; }
            set { _Cargo_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Estado_Id;

        public string Estado_Id
        {
            get { return _Estado_Id; }
            set { _Estado_Id = value; }
        }

        Boolean _Flag_Tareaje;

        public Boolean Flag_Tareaje
        {
            get { return _Flag_Tareaje; }
            set { _Flag_Tareaje = value; }
        }

        Boolean _Flag_Confianza;

        public Boolean Flag_Confianza
        {
            get { return _Flag_Confianza; }
            set { _Flag_Confianza = value; }
        }

        string _Ocupacion_Id;

        public string Ocupacion_Id
        {
            get { return _Ocupacion_Id; }
            set { _Ocupacion_Id = value; }
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
