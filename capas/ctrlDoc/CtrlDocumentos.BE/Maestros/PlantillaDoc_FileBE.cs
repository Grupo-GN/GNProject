using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlDocumentos.BE.Maestros
{
    public class PlantillaDoc_FileBE
    {
        public Int32 id_plantilla_doc_file { get; set; }
        public Int32 id_plantilla_doc { get; set; }
        public String no_documento { get; set; }
    }

    public class PlantillaDoc_FileBEList : List<PlantillaDoc_FileBE>
    {
    }
}
