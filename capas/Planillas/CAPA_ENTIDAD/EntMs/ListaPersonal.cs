using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD.EntMs
{
    [Serializable]
    public class ListaPersonal
    {
       
        public string Personal_Id { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombres { get; set; }
        public string Nro_Doc { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public string Nro_cta { get; set; }
        public string Nro_cta_cts { get; set; }
        public string Nombre_Zona { get; set; }
        public string Estado_Id { get; set; }

        //20190217
        public string TDocumento { get; set; }
        public string F_Ingreso { get; set; }
        public string F_Ini_Contrato { get; set; }
        public string F_Fin_Contrato { get; set; }
        public string Proyecto { get; set; }
        public string F_Cese { get; set; }
        //20191023
        public string TipoCta { get; set; }
        public string BancoCta { get; set; }
        public string TipoMoneda { get; set; }
        public string Nro_Cta_Inter { get; set; }
        public string NPersonal { get; set; }
    }

    public class D_Personal_Listar
    {
        public string Localidad { get; set; }
        public string Cargo { get; set; }
        public string Seccion { get; set; }

    }
}
