using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using CAPA_ENTIDAD;
using CAPA_ENTIDAD.EntMs;

namespace CAPA_DATOS
{
    public class controllerImportarDatosPersonal
    {
        private static controllerImportarDatosPersonal instance = null;
        public static controllerImportarDatosPersonal getinstance()
        {
            return instance == null ? instance = new controllerImportarDatosPersonal() : instance;
        }
        public List<Ent_Planilla> ListarPlanilla()
        {
            string comando = "SELECT Planilla_Id,Descripcion FROM Planilla WHERE Estado_Id='01'";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    List<Ent_Planilla> rList = new List<Ent_Planilla>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Planilla obj = new Ent_Planilla();
                        obj.Planilla_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_AFP> ListarAfp()
        {
            string comando = "SELECT Afp_Id,Descripcion FROM Afp WHERE Estado_id='01'";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    List<Ent_AFP> rList = new List<Ent_AFP>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_AFP obj = new Ent_AFP();
                        obj.Afp_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Ccosto> ListarCentroCosto()
        {
            string comando = "SELECT ccosto_id,Descripcion FROM Ccosto WHERE Estado_id='01' ORDER BY Descripcion";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    List<Ent_Ccosto> rList = new List<Ent_Ccosto>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Ccosto obj = new Ent_Ccosto();
                        obj.Ccosto_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Proyecto> ListaProyecto()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaProyecto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Proyecto> rList = new List<Ent_Proyecto>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Proyecto obj = new Ent_Proyecto();
                        obj.Proyecto_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Categoria_Auxiliar> ListaCatAuxiliar()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCatAuxiliar", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Categoria_Auxiliar> rList = new List<Ent_Categoria_Auxiliar>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Categoria_Auxiliar obj = new Ent_Categoria_Auxiliar();
                        obj.Categoria_Auxiliar_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Categoria_Auxiliar2> ListaCatAuxiliar2()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Categoria_Auxiliar2_Id,Descripcion FROM Categoria_Auxiliar2 ORDER BY Descripcion", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    List<Ent_Categoria_Auxiliar2> rList = new List<Ent_Categoria_Auxiliar2>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Categoria_Auxiliar2 obj = new Ent_Categoria_Auxiliar2();
                        obj.Categoria_Auxiliar2_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        public List<Ent_Tipo_Cta_Bancaria> ListaTipoCuenta()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoCuenta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Tipo_Cta_Bancaria> rList = new List<Ent_Tipo_Cta_Bancaria>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Tipo_Cta_Bancaria obj = new Ent_Tipo_Cta_Bancaria();
                        obj.TCB_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Bancos> ListaBancos()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaBancos", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Bancos> rList = new List<Ent_Bancos>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Bancos obj = new Ent_Bancos();
                        obj.Banco_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Moneda> ListaMonedaCta()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaMonedaCta", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Moneda> rList = new List<Moneda>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Moneda obj = new Moneda();
                        obj.idmoneda = dr.GetValue(0).ToString();
                        obj.moneda = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        public List<Ent_Sexos> ListaTipoSexo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoSexo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Sexos> rList = new List<Ent_Sexos>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Sexos obj = new Ent_Sexos();
                        obj.Sexo_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_E_Civil> ListaEstadoCivil()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaEstadoCivil", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_E_Civil> rList = new List<Ent_E_Civil>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_E_Civil obj = new Ent_E_Civil();
                        obj.E_Civil_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Tipo_Via> ListaTipoVia()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoVia", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Tipo_Via> rList = new List<Ent_Tipo_Via>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Tipo_Via obj = new Ent_Tipo_Via();
                        obj.Tipo_Via_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Tipo_Zona> ListaTipoZona()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoZona", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Tipo_Zona> rList = new List<Ent_Tipo_Zona>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Tipo_Zona obj = new Ent_Tipo_Zona();
                        obj.Tipo_Zona_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        public List<Ent_Tipo_Trabajador> ListaTipoTrabajador()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoTrabajador", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Tipo_Trabajador> rList = new List<Ent_Tipo_Trabajador>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Tipo_Trabajador obj = new Ent_Tipo_Trabajador();
                        obj.Tipo_Trabajador_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Regimen_Laboral> ListaRegLaboral()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaRegLaboral", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Regimen_Laboral> rList = new List<Ent_Regimen_Laboral>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Regimen_Laboral obj = new Ent_Regimen_Laboral();
                        obj.Regimen_Laboral_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Nivel_Educativo> ListaNivelEducativo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaNivelEducativo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Nivel_Educativo> rList = new List<Ent_Nivel_Educativo>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Nivel_Educativo obj = new Ent_Nivel_Educativo();
                        obj.Nivel_Educativo_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Cargo> ListaCargo()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCargo", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Cargo> rList = new List<Ent_Cargo>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Cargo obj = new Ent_Cargo();
                        obj.Cargo_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_AFP> ListaRegimenPensionario()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaRegPensionario", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_AFP> rList = new List<Ent_AFP>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_AFP obj = new Ent_AFP();
                        obj.Afp_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_EPS> ListaSCTRSalud()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSCTRSalud", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_EPS> rList = new List<Ent_EPS>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_EPS obj = new Ent_EPS();
                        obj.EPS_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_EPS> ListaSCTRPension()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSCTRPension", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_EPS> rList = new List<Ent_EPS>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_EPS obj = new Ent_EPS();
                        obj.EPS_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Tipo_Contrato> ListaTipoContrato()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaTipoContrato", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Tipo_Contrato> rList = new List<Ent_Tipo_Contrato>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Tipo_Contrato obj = new Ent_Tipo_Contrato();
                        obj.Tipo_Contrato_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_EPS> ListaEPS()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaEPS", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_EPS> rList = new List<Ent_EPS>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_EPS obj = new Ent_EPS();
                        obj.EPS_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Situacion> ListaSituacionEspecial()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaSituacionEspecial", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Situacion> rList = new List<Ent_Situacion>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Situacion obj = new Ent_Situacion();
                        obj.Situacion_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        public List<Ent_Categoria> ListaCategoria()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCategoria", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Categoria> rList = new List<Ent_Categoria>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Categoria obj = new Ent_Categoria();
                        obj.Categoria_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }
        public List<Ent_Categoria2> ListaCategoria2()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaCategoria2", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_Categoria2> rList = new List<Ent_Categoria2>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_Categoria2 obj = new Ent_Categoria2();
                        obj.Categoria2_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        public List<Ent_RH_Area> ListaArea()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ListaArea", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Ent_RH_Area> rList = new List<Ent_RH_Area>();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_RH_Area obj = new Ent_RH_Area();
                        obj.Area_Id = dr.GetValue(0).ToString();
                        obj.Descripcion = dr.GetValue(1).ToString();
                        rList.Add(obj);
                    }
                    return rList;
                }
            }
        }

        //Datos Generales 
        public ArrayList GetDatosGeneralesImportacionPersonal()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarDatosParaImportPersonal", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    ArrayList rList = new ArrayList();
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        rList.Add(values);
                    }
                    return rList;

                }
            }

        }
    }
}
