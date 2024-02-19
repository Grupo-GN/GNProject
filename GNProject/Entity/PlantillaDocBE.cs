using GNProject.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GNProject.Entity
{
    [Serializable]
    public class PlantillaDocBE
    {
        public Int32 id_plantilla_doc { get; set; }
        public String no_plantilla_doc { get; set; }
        public String co_grupo_doc { get; set; }
        public String co_sub_grupo_doc { get; set; }
        public String ids_usuarios_responsables { get; set; }
        public Int32 qt_dias_ant_venc_alerta { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public Int32 id_usuario { get; set; }
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
        public String no_grupo_doc { get; set; }
        public String no_sub_grupo_doc { get; set; }

        public Int32 cont_ids_caracteristica { get; set; }
        public String ids_PlantillaDoccaracteristica { get; set; }
        public String cad_no_caracteristica { get; set; }
        public String cad_co_tipo_dato_caracteristica { get; set; }
        public String cad_fl_obligatorio_caracteristica { get; set; }
        public String cad_nu_orden_caracteristica { get; set; }
        public String cad_qt_dias_alerta_caracteristica { get; set; }

        public Int32 cont_ids_file { get; set; }
        public String ids_PlantillaDoc_File { get; set; }
        public String cad_no_documento { get; set; }

        public String cods_tipo_doc_archivo { get; set; }
    }

    [Serializable]
    public class PlantillaDocBEList : List<PlantillaDocBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PlantillaDocBEComparer dc = new PlantillaDocBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PlantillaDocBEComparer : IComparer<PlantillaDocBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PlantillaDocBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PlantillaDocBE x, PlantillaDocBE y)
        {

            PropertyInfo propertyX = x.GetType().GetProperty(_prop);
            PropertyInfo propertyY = y.GetType().GetProperty(_prop);

            object px = propertyX.GetValue(x, null);
            object py = propertyY.GetValue(y, null);

            if (px == null && py == null)
            {
                return 0;
            }
            else if (px != null && py == null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (px == null && py != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (px.GetType().GetInterface("IComparable") != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return ((IComparable)px).CompareTo(py);
                }
                else
                {
                    return ((IComparable)py).CompareTo(px);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}