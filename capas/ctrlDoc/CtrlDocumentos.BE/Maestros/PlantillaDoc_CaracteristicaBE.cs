using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CtrlDocumentos.BE.Maestros
{
    [Serializable]
    public class PlantillaDoc_CaracteristicaBE
    {
        public Int32 id_plantilla_doc_caracteristica { get; set; }
        public Int32 id_plantilla_doc { get; set; }
        public String no_caracteristica { get; set; }
        public String co_tipo_dato { get; set; }
        public String fl_obligatorio { get; set; }
        public String txt_obligatorio { get; set; }
        public Int32 nu_orden { get; set; }
        public Int32 qt_dias_alerta { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        /*Adicionales*/
        public String no_estado { get; set; }
        public String co_usuario { get; set; }
    }

    [Serializable]
    public class PlantillaDoc_CaracteristicaBEList : List<PlantillaDoc_CaracteristicaBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            PlantillaDoc_CaracteristicaBEComparer dc = new PlantillaDoc_CaracteristicaBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class PlantillaDoc_CaracteristicaBEComparer : IComparer<PlantillaDoc_CaracteristicaBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public PlantillaDoc_CaracteristicaBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(PlantillaDoc_CaracteristicaBE x, PlantillaDoc_CaracteristicaBE y)
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