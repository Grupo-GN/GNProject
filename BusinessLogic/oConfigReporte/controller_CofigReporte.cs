using Presistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogic.oConfigReporte
{
    public class controller_CofigReporte
    {
        private static controller_CofigReporte Instance = null;
        public static controller_CofigReporte Get_Instance()
        {
            return Instance == null ? Instance = new controller_CofigReporte() : Instance;
        }

        //INTENSIDAD
        public List<Intensidad> Get_Intensidad_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Intensidad.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public string Get_Add_Intensidad(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Intensidad_Id = Get_PrimaryKey_Intensidad();
                int existe = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).Count();
                if (existe == 0)
                {
                    Intensidad inten = new Intensidad();
                    inten.Intensidad_Id = Intensidad_Id;
                    inten.Descripcion = Descripcion;
                    inten.ReportarGerencia = "02";
                    obj.AddToIntensidad(inten);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_Intensidad(string Intensidad_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).Count();
                if (existe == 1)
                {
                    Intensidad inten = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).First();
                    inten.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_PrimaryKey_Intensidad()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Intensidad.Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.Intensidad.Max(m => m.Intensidad_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;

                }
            }
        }

        public string Get_Delete_Intensidad(string Intensidad_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).Count();
                if (existe == 0)
                {
                    return "false#.::Error, La Intensidad ya no existe.";
                }
                int usado = obj.ReporteIncidente.Where(x => x.Intensidad_Id == Intensidad_Id).Count();
                if (usado > 0)
                {
                    return "false#.::Error, La Intensidad esta siendo usada, no se puede eliminar.";
                }

                Intensidad its = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).First();
                obj.DeleteObject(its);
                obj.SaveChanges();
                return "true#Eliminado Correctamente.";
            }
        }

        //SEVERIDAD
        public List<Severidad> Get_Severidad_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Severidad.OrderBy(o => o.Descripcion).ToList();
            }
        }
        public string Get_Add_Severidad(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Severidad_Id = Get_PrimaryKey_Intensidad();
                int existe = obj.Severidad.Where(x => x.Severidad_Id == Severidad_Id).Count();
                if (existe == 0)
                {
                    Severidad inten = new Severidad();
                    inten.Severidad_Id = Severidad_Id;
                    inten.Descripcion = Descripcion;

                    obj.AddToSeveridad(inten);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_Severidad(string Severidad_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.Severidad.Where(x => x.Severidad_Id == Severidad_Id).Count();
                if (existe == 1)
                {
                    Severidad inten = obj.Severidad.Where(x => x.Severidad_Id == Severidad_Id).First();
                    inten.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_PrimaryKey_Severidad()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Severidad.Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.Severidad.Max(m => m.Severidad_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;

                }
            }
        }
        public string Get_Delete_Severidad(string Severidad_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Severidad.Where(x => x.Severidad_Id == Severidad_Id).Count();
                if (existe == 0)
                {
                    return "false#.::Error, La Severidad ya no existe.";
                }
                int usado = obj.ReporteIncidente.Where(x => x.Severidad_Id == Severidad_Id).Count();
                if (usado > 0)
                {
                    return "false#.::Error, La Severidad esta siendo usada, no se puede eliminar.";
                }

                Severidad its = obj.Severidad.Where(x => x.Severidad_Id == Severidad_Id).First();
                obj.DeleteObject(its);
                obj.SaveChanges();
                return "true#Eliminado Correctamente.";
            }
        }


        //ALERTA GERENTES

        public List<Intensidad> Get_Intensidad_Out_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Intensidad.Where(x => x.ReportarGerencia == "02").OrderBy(o => o.Descripcion).ToList();
            }
        }
        public List<Intensidad> Get_Intensidad_In_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Intensidad.Where(x => x.ReportarGerencia == "01").OrderBy(o => o.Descripcion).ToList();
            }
        }
        public void Get_Clear_AlertGeren()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string cmd = "UPDATE Intensidad SET ReportarGerencia='02'";
                obj.ExecuteStoreCommand(cmd);
            }

        }
        public bool Get_Intensidad_Add_Alert(string Intensidad_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).Count();
                if (existe == 1)
                {
                    Intensidad its = obj.Intensidad.Where(x => x.Intensidad_Id == Intensidad_Id).First();
                    its.ReportarGerencia = "01";
                    obj.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public string Get_GrabarCorreo_Osigermin(string Correo)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).Count();
                if (existe == 1)
                {
                    Parametros_Sistema parm = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 1).First();
                    parm.Valor = Correo;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Parametro no encontrado.";
                }
            }
        }
        public string Get_Grabar_MiCorreo(string Correo)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 2).Count();
                if (existe == 1)
                {
                    Parametros_Sistema parm = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 2).First();
                    parm.Valor = Correo;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Parametro no encontrado.";
                }
            }
        }


        //TIPO 

        public List<Tipo> Get_Tipo_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Tipo.OrderBy(o => o.Descripcion).ToList();
            }
        }
        public string Get_Add_Tipo(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Tipo_Id = PrimaryKey_Tipo();
                int existe = obj.Tipo.Where(x => x.Tipo_Id == Tipo_Id).Count();
                if (existe == 0)
                {
                    Tipo tip = new Tipo();
                    tip.Tipo_Id = Tipo_Id;
                    tip.Descripcion = Descripcion;
                    obj.AddToTipo(tip);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_Tipo(string Tipo_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.Tipo.Where(x => x.Tipo_Id == Tipo_Id).Count();
                if (existe == 1)
                {
                    Tipo tip = obj.Tipo.Where(x => x.Tipo_Id == Tipo_Id).First();
                    tip.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Delete_Tipo(string Tipo_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int del = obj.ReporteIncidente.Where(x => x.Tipo == Tipo_Id).Count();
                if (del > 0)
                {
                    return "false#.::Error, el tipo ya esta en uso no se puede eliminar.";
                }


                int existe = obj.Tipo.Where(x => x.Tipo_Id == Tipo_Id).Count();
                if (existe == 1)
                {
                    Tipo tip = obj.Tipo.Where(x => x.Tipo_Id == Tipo_Id).First();
                    obj.DeleteObject(tip);
                    obj.SaveChanges();
                    return "true#Eliminado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string PrimaryKey_Tipo()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Tipo.Count();
                if (cant == 0)
                {
                    return "01";
                }
                else
                {
                    string max = obj.Tipo.Max(m => m.Tipo_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(2, '0');
                    return max;
                }
            }
        }

        //ORIGEN  

        public List<Origen> Get_Origen_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Origen.OrderBy(o => o.Descripcion).ToList();
            }
        }
        public string Get_Add_Origen(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Origen_Id = PrimaryKey_Origen();
                int existe = obj.Origen.Where(x => x.Origen_Id == Origen_Id).Count();
                if (existe == 0)
                {
                    Origen ori = new Origen();
                    ori.Origen_Id = Origen_Id;
                    ori.Descripcion = Descripcion;
                    obj.AddToOrigen(ori);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_Origen(string Origen_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.Origen.Where(x => x.Origen_Id == Origen_Id).Count();
                if (existe == 1)
                {
                    Origen ori = obj.Origen.Where(x => x.Origen_Id == Origen_Id).First();
                    ori.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Delete_Origen(string Origen_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int del = obj.ReporteIncidente.Where(x => x.Origen == Origen_Id).Count();
                if (del > 0)
                {
                    return "false#.::Error, el origen ya esta en uso no se puede eliminar.";
                }


                int existe = obj.Origen.Where(x => x.Origen_Id == Origen_Id).Count();
                if (existe == 1)
                {
                    Origen ori = obj.Origen.Where(x => x.Origen_Id == Origen_Id).First();
                    obj.DeleteObject(ori);
                    obj.SaveChanges();
                    return "true#Eliminado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string PrimaryKey_Origen()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.Origen.Count();
                if (cant == 0)
                {
                    return "01";
                }
                else
                {
                    string max = obj.Origen.Max(m => m.Origen_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(2, '0');
                    return max;
                }
            }
        }

        //PARAMETROS

        //LISTA DE PARAMENTROS
        public List<Parametros_Sistema> Get_Paramentros_All()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.Parametros_Sistema.ToList();
            }
        }
        //CUENTA DE CORREO
        public string Get_Cofig_Cuenta_Correo(string Email, string Contraseña)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 6).Count();
                if (existe == 1)
                {
                    Parametros_Sistema parEma = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 6).First();
                    parEma.Valor = Email;

                    Parametros_Sistema parPas = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 7).First();
                    parPas.Valor = Contraseña;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, parametro no encontrado.";
                }
            }
        }
        //TEXTO ADICIONAL EN LOS CORREOS
        public string Get_ParaGerentes(string Contenido)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 3).Count();
                if (existe == 1)
                {
                    Parametros_Sistema par = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 3).First();
                    par.Valor = Contenido;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, parametro no encontrado.";
                }
            }
        }
        public string Get_ParaResponsables(string Contenido)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 4).Count();
                if (existe == 1)
                {
                    Parametros_Sistema par = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 4).First();
                    par.Valor = Contenido;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, parametro no encontrado.";
                }
            }
        }
        public string Get_ParaAdministracion(string Contenido)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 5).Count();
                if (existe == 1)
                {
                    Parametros_Sistema par = obj.Parametros_Sistema.Where(x => x.Parametro_Id == 5).First();
                    par.Valor = Contenido;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, parametro no encontrado.";
                }
            }
        }

        #region CAUSAS DEL INCIDENTE

        //CAUSAS

        public List<CausaIncidente> Get_Causas_Incidentes_List(string Name, string Tipo, string Estado, int inicio)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.CausaIncidente.Where(x => x.Causa_Name.Contains(Name)
                    && x.Tipo.Contains(Tipo)
                    && x.Estado.Contains(Estado)).OrderBy(o => o.Causa_Name).Skip(inicio).Take(12).ToList();

            }
        }
        public int Get_Causas_Incidentes_MaxRows(string Name, string Tipo, string Estado)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.CausaIncidente.Where(x => x.Causa_Name.Contains(Name) && x.Tipo.Contains(Tipo) && x.Estado.Contains(Estado)).Count();

            }
        }

        public CausaIncidente Get_Causa_Find(string Causa_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).Count();
                if (existe == 1)
                {
                    return obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).First();
                }
                else
                {
                    return null;
                }
            }
        }
        public string Get_Causas_Add(string Causa_Name, string Descripcion, string Tipo, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {
                    string Causa_Id = Get_PrimaryKey_Causa();
                    int existe = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).Count();
                    if (existe == 0)
                    {
                        CausaIncidente causa = new CausaIncidente();
                        causa.Causa_Id = Causa_Id;
                        causa.Causa_Name = Causa_Name;
                        causa.Descripcion = Descripcion;
                        causa.Tipo = Tipo;
                        causa.Estado = Estado;
                        obj.AddToCausaIncidente(causa);
                        obj.SaveChanges();
                        return "true#Registrado Correctamente";
                    }
                    else
                    {

                        return "false#.::Error, Intentelo luego.";
                    }

                }

            }
            catch (Exception ex)
            {
                return "false#.::Error : " + ex.Message;
            }
        }
        public string Get_PrimaryKey_Causa()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.CausaIncidente.Count();
                if (cant == 0)
                {
                    return "0001";
                }
                else
                {
                    string max = obj.CausaIncidente.Max(m => m.Causa_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(4, '0');
                    return max;

                }

            }
        }
        public string Get_Causas_Update(string Causa_Id, string Causa_Name, string Descripcion, string Tipo, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    int existe = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).Count();
                    if (existe == 1)
                    {
                        CausaIncidente causa = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).First();

                        if (causa.Tipo != Tipo)
                        {

                            return "false#Error";
                        }
                        else
                        {
                            causa.Causa_Name = Causa_Name;
                            causa.Descripcion = Descripcion;
                            causa.Estado = Estado;
                            obj.SaveChanges();
                            return "true#Actualizado Correctamente";
                        }

                    }
                    else
                    {

                        return "false#.::Error, Intentelo luego.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error : " + ex.Message;
            }
        }
        public string Get_Causas_Delete(string Causa_Id, string Estado)
        {
            try
            {
                using (ContextMaestro obj = new ContextMaestro())
                {

                    int existe = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).Count();
                    if (existe == 1)
                    {
                        CausaIncidente causa = obj.CausaIncidente.Where(x => x.Causa_Id == Causa_Id).First();
                        causa.Estado = Estado;
                        obj.SaveChanges();
                        return "true#Actualizado Correctamente";
                    }
                    else
                    {

                        return "false#.::Error, Intentelo luego.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error : " + ex.Message;
            }
        }


        public List<CausaIncidente> Get_CausasTipo_Report(string Tipo)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.CausaIncidente.Where(x => x.Tipo == Tipo && x.Estado == "01").ToList();
            }
        }
        #endregion

        #region TIPO DE INCIDENTE

        public List<TipoIncidente> Get_TipoIncidente_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.TipoIncidente.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public string Get_Add_TipoIncidente(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string TipoI_Id = Get_PrimaryKey_TipoIncidente();
                int existe = obj.TipoIncidente.Where(x => x.TipoI_Id == TipoI_Id).Count();
                if (existe == 0)
                {
                    TipoIncidente tipo = new TipoIncidente();
                    tipo.TipoI_Id = TipoI_Id;
                    tipo.Descripcion = Descripcion;
                    obj.AddToTipoIncidente(tipo);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_TipoIncidente(string TipoI_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.TipoIncidente.Where(x => x.TipoI_Id == TipoI_Id).Count();
                if (existe == 1)
                {
                    TipoIncidente tipo = obj.TipoIncidente.Where(x => x.TipoI_Id == TipoI_Id).First();
                    tipo.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_PrimaryKey_TipoIncidente()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.TipoIncidente.Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.TipoIncidente.Max(m => m.TipoI_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }

        public string Get_Delete_TipoIncidente(string TipoI_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.TipoIncidente.Where(x => x.TipoI_Id == TipoI_Id).Count();
                if (existe == 0)
                {
                    return "false#.::Error, El Tipo de incidente ya no existe.";
                }
                int usado = obj.ReporteIncidente.Where(x => x.TipoI_Id == TipoI_Id).Count();
                if (usado > 0)
                {
                    return "false#.::Error, El Tipo de incidente esta siendo usada, no se puede eliminar.";
                }

                TipoIncidente its = obj.TipoIncidente.Where(x => x.TipoI_Id == TipoI_Id).First();
                obj.DeleteObject(its);
                obj.SaveChanges();
                return "true#Eliminado Correctamente.";
            }
        }

        #endregion

        #region AFECTADO EN EL INCIDENTE

        public List<AfectadoInc> Get_AfectadoInc_List()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                return obj.AfectadoInc.OrderBy(o => o.Descripcion).ToList();
            }
        }

        public string Get_Add_AfectadoInc(string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                string Afec_Id = Get_PrimaryKey_AfectadoInc();
                int existe = obj.AfectadoInc.Where(x => x.Afec_Id == Afec_Id).Count();
                if (existe == 0)
                {
                    AfectadoInc afec = new AfectadoInc();
                    afec.Afec_Id = Afec_Id;
                    afec.Descripcion = Descripcion;
                    obj.AddToAfectadoInc(afec);
                    obj.SaveChanges();
                    return "true#Registrado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_Update_AfectadoInc(string Afec_Id, string Descripcion)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {

                int existe = obj.AfectadoInc.Where(x => x.Afec_Id == Afec_Id).Count();
                if (existe == 1)
                {
                    AfectadoInc afec = obj.AfectadoInc.Where(x => x.Afec_Id == Afec_Id).First();
                    afec.Descripcion = Descripcion;
                    obj.SaveChanges();
                    return "true#Actualizado Correctamente.";
                }
                else
                {
                    return "false#.::Error, Intentelo luego.";
                }
            }
        }
        public string Get_PrimaryKey_AfectadoInc()
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int cant = obj.AfectadoInc.Count();
                if (cant == 0)
                {
                    return "001";
                }
                else
                {
                    string max = obj.AfectadoInc.Max(m => m.Afec_Id);
                    max = (int.Parse(max) + 1).ToString().PadLeft(3, '0');
                    return max;
                }
            }
        }

        public string Get_Delete_AfectadoInc(string Afec_Id)
        {
            using (ContextMaestro obj = new ContextMaestro())
            {
                int existe = obj.AfectadoInc.Where(x => x.Afec_Id == Afec_Id).Count();
                if (existe == 0)
                {
                    return "false#.::Error, El tipo de afectado ya no existe.";
                }
                int usado = obj.ReporteIncidente.Where(x => x.Afec_Id == Afec_Id).Count();
                if (usado > 0)
                {
                    return "false#.::Error,El tipo de afectado esta siendo usada, no se puede eliminar.";
                }

                AfectadoInc afec = obj.AfectadoInc.Where(x => x.Afec_Id == Afec_Id).First();
                obj.DeleteObject(afec);
                obj.SaveChanges();
                return "true#Eliminado Correctamente.";
            }
        }

        #endregion

    }
}
