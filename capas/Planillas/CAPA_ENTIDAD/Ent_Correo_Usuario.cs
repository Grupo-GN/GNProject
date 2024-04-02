using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_Correo_Usuario
    {

        public string Compania_Id { get; set; }
        public string Personal_Id { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Permiso { get; set; }
        public Boolean Adm_Contratos { get; set; }
        public Boolean Adm_Vacaciones { get; set; }
        public Boolean H_Extras { get; set; }
    }
}
