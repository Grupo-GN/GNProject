using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presistence;
using BusienssLogic.CA.oHorarios;
using System.Web.Services;
using System.Collections;

namespace GNProject.Views.ControlAsisten.CA.Matenimientos
{
    public partial class MHorarios : System.Web.UI.Page
    {
        [WebMethod]
        //public static List<Horarios_Detalle> Get_DetalleHorarios_List(int Horario_Id)
        public static ArrayList Get_DetalleHorarios_List(int Horario_Id)
        {
            return Controller_MantHorarios.GetInstance().Get_DetalleHorarios_List(Horario_Id);
        }

        //modidga//
        [WebMethod]
        public static bool Get_Horarios_Deta_Update(int Horario_Id, string Dia, string hi, string hir, string hfr, string hf)
        {
            return Controller_MantHorarios.GetInstance().Get_Horarios_Deta_Update(Horario_Id, Dia, hi, hir, hfr, hf);
        }
        //2
        [WebMethod]
        public static bool Get_DetalleHorarios_Add(DateTime HoraInicio, DateTime HoraInicioRefrigerio, DateTime HoraFinRefrigerio, DateTime HoraFin)
        {
            return Controller_MantHorarios.GetInstance().Get_DetalleHorarios_Add(HoraInicio, HoraInicioRefrigerio, HoraFinRefrigerio, HoraFin);
        }

        [WebMethod]
        public static List<Horarios> Get_Horarios_List(int inicio)
        {
            return Controller_MantHorarios.GetInstance().Get_Horarios_List(inicio);
        }



        [WebMethod]
        public static bool Get_Horarios_Update(int codigo, string nombre)
        {
            return Controller_MantHorarios.GetInstance().Get_Horarios_Update(codigo, nombre);
        }

        [WebMethod]
        public static int Get_Horarios_MaximoRegistros()
        {
            return Controller_MantHorarios.GetInstance()
                .Get_Horarios_MaximoRegistros();
        }

        [WebMethod]
        public static bool Get_Horarios_Add(string nombre)
        {
            return Controller_MantHorarios.GetInstance().Get_Horarios_Add(nombre);
        }

        [WebMethod]
        public static Horarios Get_Horarios_Find(int codigo)
        {
            return Controller_MantHorarios.GetInstance().Get_Horarios_Find(codigo);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }



    }
}