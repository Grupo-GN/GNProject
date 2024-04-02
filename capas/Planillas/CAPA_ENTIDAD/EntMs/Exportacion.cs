using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// @001 FPS 10/01/2022 - Ajustes régimen por planilla para "Interface AFP - 2015"
/// </summary>

namespace CAPA_ENTIDAD.EntMs
{
    [Serializable]
    public class Exportacion
    {

        public Exportacion() { }

        public string NSecuencia { get; set; }
        public string CUSPP { get; set; }
        public string nDocumento { get; set; }
        public string apePar { get; set; }
        public string apeMar { get; set; }
        public string Nombre { get; set; }
        public string tipoMov { get; set; }
        public string fechMov { get; set; }
        public double valor { get; set; }
        public double M_APOVOL { get; set; }
        public double M_APOLVOLS { get; set; }
        public double M_APOEMPL { get; set; }
        public string Rubro { get; set; }
        public string Datos_afp { get; set; }
    }
    [Serializable]
    public class Exportacion2015
    {

        public Exportacion2015() { }

        public string NSecuencia { get; set; }
        public string CUSPP { get; set; }
        public string nDocumento { get; set; }
        public string apePar { get; set; }
        public string apeMar { get; set; }
        public string Nombre { get; set; }
        //public string tipoMov { get; set; }
        //public string fechMov { get; set; }
        public string rl { get; set; }
        public string irl { get; set; }
        public string crl { get; set; }
        public string eap { get; set; }
        public double valor { get; set; }
        public double M_APOVOL { get; set; }
        public double M_APOLVOLS { get; set; }
        public double M_APOEMPL { get; set; }
        public string Rubro { get; set; }
        public string Datos_afp { get; set; }
        public string TDoc { get; set; }
        public string CodRegimenAFP { get; set; } //@001 I/F
    }
}
