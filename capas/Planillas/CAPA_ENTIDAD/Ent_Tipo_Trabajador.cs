using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Tipo_Trabajador
    {
        string _Tipo_Trabajador_Id;

        public string Tipo_Trabajador_Id
        {
            get { return _Tipo_Trabajador_Id; }
            set { _Tipo_Trabajador_Id = value; }
        }

        string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        string _Abreviatura;

        public string Abreviatura
        {
            get { return _Abreviatura; }
            set { _Abreviatura = value; }
        }

        Boolean _Sector_Privado;

        public Boolean Sector_Privado
        {
            get { return _Sector_Privado; }
            set { _Sector_Privado = value; }
        }

        Boolean _Sector_Publico;

        public Boolean Sector_Publico
        {
            get { return _Sector_Publico; }
            set { _Sector_Publico = value; }
        }

        Boolean _Otras_Entidades;

        public Boolean Otras_Entidades
        {
            get { return _Otras_Entidades; }
            set { _Otras_Entidades = value; }
        }
    }
}
