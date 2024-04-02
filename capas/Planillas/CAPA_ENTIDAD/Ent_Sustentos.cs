using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Sustentos
    {
        string _planilla;

        public string Planilla
        {
            get { return _planilla; }
            set { _planilla = value; }
        }
        string _periodoId;

        public string PeriodoId
        {
            get { return _periodoId; }
            set { _periodoId = value; }
        }
        string _conceptoID;

        public string ConceptoID
        {
            get { return _conceptoID; }
            set { _conceptoID = value; }
        }
        string _procesoID;

        public string ProcesoID
        {
            get { return _procesoID; }
            set { _procesoID = value; }
        }
        string _camposPerso;

        public string CamposPerso
        {
            get { return _camposPerso; }
            set { _camposPerso = value; }
        }
        string _camposConcep;

        public string CamposConcep
        {
            get { return _camposConcep; }
            set { _camposConcep = value; }
        }
        int _cantC;

        public int CantC
        {
            get { return _cantC; }
            set { _cantC = value; }
        }
        int _cantP;

        public int CantP
        {
            get { return _cantP; }
            set { _cantP = value; }
        }

        string _plantillaID;

        public string PlantillaID
        {
            get { return _plantillaID; }
            set { _plantillaID = value; }
        }
        string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        string _detalleConceptos;

        public string DetalleConceptos
        {
            get { return _detalleConceptos; }
            set { _detalleConceptos = value; }
        }

    }
}
