using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPA_ENTIDAD
{
    public class Ent_PptoPersonal
    {
        /*Valores para realizar operaciones Masiva*/
        string _Categoria_Id_Masivo;

        public string Categoria_Id_Masivo
        {
            get { return _Categoria_Id_Masivo; }
            set { _Categoria_Id_Masivo = value; }
        }


        string _Mes_Id_Masivo;

        public string Mes_Id_Masivo
        {
            get { return _Mes_Id_Masivo; }
            set { _Mes_Id_Masivo = value; }
        }

        string _Valor_Masivo;

        public string Valor_Masivo
        {
            get { return _Valor_Masivo; }
            set { _Valor_Masivo = value; }
        }
        //

        string _Ejercicio_Id;

        public string Ejercicio_Id
        {
            get { return _Ejercicio_Id; }
            set { _Ejercicio_Id = value; }
        }
     

    }
        

}
