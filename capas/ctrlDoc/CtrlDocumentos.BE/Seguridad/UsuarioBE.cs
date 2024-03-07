using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace CtrlDocumentos.BE.Seguridad
{
    [Serializable]
    public class UsuarioBE
    {
        public Int32 id_usuario { get; set; }
        public Int32 id_perfil { get; set; }
        public String nu_dni { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public String no_usuario { get; set; }
        public String ape_paterno { get; set; }
        public String ape_materno { get; set; }
        public DateTime? fe_nacimiento { get; set; }
        public String co_sexo { get; set; }
        public String no_correo { get; set; }
        public String nu_telefono { get; set; }
        public String nu_celular { get; set; }
        public String fl_activo { get; set; }
        public String usu_crea { get; set; }
        public DateTime fe_crea { get; set; }
        public String usu_cambio { get; set; }
        public DateTime fe_cambio { get; set; }
        public String no_estacion_red { get; set; }
        public String no_usuario_red { get; set; }

        public Boolean fl_ver_doc_reservado { get; set; }
        public Boolean fl_archivar_doc { get; set; }

        /*Adicionales*/
        public String co_usuario { get; set; }
        public String nombrecompleto { get; set; }
        public String no_perfil { get; set; }
        public String no_sexo { get; set; }
        public String no_estado { get; set; }
        public String sfe_nacimiento { get; set; }
    }

    [Serializable]
    public class UsuarioBEList : List<UsuarioBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            UsuarioBEComparer dc = new UsuarioBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class UsuarioBEComparer : IComparer<UsuarioBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public UsuarioBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(UsuarioBE x, UsuarioBE y)
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
