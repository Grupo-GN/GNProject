using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CAPA_DATOS.oCA
{
    public class controllerPermisos
    {
        private static controllerPermisos instance = null;
        public static controllerPermisos getInstance()
        {
            return instance == null ? instance = new controllerPermisos() : instance;
        }
        public ArrayList ListarPersonalPermisosPlanilla(string xperiodo, string xlocalidad, string xcategoria,string xproyecto)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand("uspListarPersonalPermisoPlanilla", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Periodo", xperiodo);
                    cmd.Parameters.AddWithValue("@Localidad_Id", xlocalidad);
                    cmd.Parameters.AddWithValue("@CategoriaAuxiliar", xcategoria);
                    cmd.Parameters.AddWithValue("@Proyecto", xproyecto);

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
        public ArrayList GetFechaPorPeriodo(string xperiodo)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT CONVERT(VARCHAR(10),FECHA_INI,103) [FECHA_INI],CONVERT(VARCHAR(10),FECHA_FIN,103)[FECHA_FIN] FROM PERIODO WHERE PERIODO_ID=@periodo";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@periodo", xperiodo);
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
        public ArrayList Get_Permisos_Fecha_By_Personal(string Planilla_Id,string Personal_Id, DateTime FechaIni, DateTime FechaFin, string PeriodoId,string LocalidadId,string AreaId,string ProyectoId)
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                //string comando = "SELECT P.PermisoD_Id,T.descripcion [Permiso],P.Descuento,P.TipoReg,P.Estado,";
                //comando += "P.FechaIni,P.FechaFin,P.NroDoc,P.AproJefe,P.AproRRHH,P.FechaModif ";
                //comando += ",T.Permiso_Id,(DATEDIFF(DAY,P.FechaIni,P.FechaFin)+1) [DIAS] ";
                //comando += ",ISNULL((SELECT VALOR FROM D_VARIABLES WHERE CONCEPTO_ID='000027' AND PERSONAL_ID=p.Personal_Id  AND PERIODO_ID=@Periodo_Id),0) [DM] ";
                //comando += ",ISNULL((SELECT VALOR FROM D_VARIABLES WHERE CONCEPTO_ID='000557' AND PERSONAL_ID=p.Personal_Id  AND PERIODO_ID=@Periodo_Id),0) [SUB] ";
                //comando += ",PE.Personal_Id,PE.Apellido_Paterno + ' ' + PE.Apellido_Materno + ', ' + PE.Nombres[PERSONAL]";
                //comando += ",ISNULL('../CA/ArchivoPermiso/'+ FP.Name,'') [Archivo] ";
                //comando += "FROM Permisos_Fecha_CA P INNER JOIN Permisos_MS T ON P.TPermiso_Id=T.Permiso_Id ";
                //comando += "INNER JOIN PERSONAL PE ON P.Personal_ID=PE.Personal_Id ";
                //comando += "LEFT JOIN FilePermiso FP ON P.PermisoD_Id=FP.Permiso_Id ";
                ////comando += "WHERE P.Personal_ID=@personal AND P.FechaIni BETWEEN @fini AND @ffin AND P.Estado='01'";
                //comando += "WHERE P.FechaIni BETWEEN @fini AND @ffin AND P.Estado='01' ";
                //comando += "ORDER BY 16 ";

                string comando = "uspListarPersonalPermisoSubsidio";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Planilla", Planilla_Id);
                    cmd.Parameters.AddWithValue("@Periodo_Id", PeriodoId);
                    cmd.Parameters.AddWithValue("@fini", FechaIni);
                    cmd.Parameters.AddWithValue("@ffin", FechaFin);
                    cmd.Parameters.AddWithValue("@v_Area_Id", LocalidadId);
                    cmd.Parameters.AddWithValue("@v_Categoria_Auxiliar_Id", AreaId);
                    cmd.Parameters.AddWithValue("@v_Proyecto_Id", ProyectoId);
                    cmd.Parameters.AddWithValue("@v_Personal_Id", Personal_Id);
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

        public ArrayList Get_Tipo_Permisos()
        {
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Permiso_Id,descripcion FROM Permisos_MS WHERE Permiso_Id IN (1,2,6,7,8) ORDER BY descripcion";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
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

        //Archivos
        public string Delete_ArchivoPermiso(int Permiso_Id, string Personal_Id, string Tipo)
        {
            string nombre = "";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT TOP 1 Name FROM FilePermiso WHERE Permiso_Id=@permiso AND Personal_Id=@personal AND Tipo=@tipo";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@permiso", Permiso_Id);
                    cmd.Parameters.AddWithValue("@personal", Personal_Id);
                    cmd.Parameters.AddWithValue("@tipo", Tipo);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        nombre = dr.GetValue(0).ToString();
                    }
                    return nombre;
                }
            }
        }
        public bool Insert_ArchivoPermiso(int Permiso_Id, string Personal_Id, string Tipo, string Name, string Url)
        {
            string comando = "";
            int existe = 0;

            comando = "SELECT COUNT(Name) [Cant] FROM FilePermiso WHERE Permiso_Id=@permiso AND Personal_Id=@personal AND Tipo=@tipo";
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@permiso", Permiso_Id);
                    cmd.Parameters.AddWithValue("@personal", Personal_Id);
                    cmd.Parameters.AddWithValue("@tipo", Tipo);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        existe = int.Parse(dr.GetValue(0).ToString());
                    }
                }
            }
            if (existe == 1)
            {
                comando = "UPDATE FilePermiso SET Name=@name, Url=@url WHERE Permiso_Id=@permiso AND Personal_Id=@personal AND Tipo=@tipo";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@permiso", Permiso_Id);
                        cmd.Parameters.AddWithValue("@personal", Personal_Id);
                        cmd.Parameters.AddWithValue("@tipo", Tipo);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@url", Url);
                        cn.Open();
                        int xrows = cmd.ExecuteNonQuery();
                        if (xrows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else if (existe == 0)
            {
                comando = "INSERT INTO [dbo].[FilePermiso] ([Permiso_Id],[Personal_Id],[Tipo],[Name],[Url]) ";
                comando += "VALUES (@Permiso_Id,@Personal_Id,@Tipo,@Name,@Url)";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Permiso_Id", Permiso_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                        cmd.Parameters.AddWithValue("@Tipo", Tipo);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Url", Url);
                        cn.Open();
                        int xrows = cmd.ExecuteNonQuery();
                        if (xrows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public string Get_AM_Permisos_Fechas(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif, string PeriodoId)
        {
            string comando = "";
            try
            {
                if (PermisoD_Id == 0)
                {
                    comando = "INSERT INTO [dbo].[Permisos_Fecha_CA] ";
                    comando += "([TPermiso_Id],[Personal_ID],[FechaIni],[FechaFin],[Descuento],[TipoReg],[Motivo],[NroDoc],[AproJefe],[ComentariosJefe] ";
                    comando += ",[AproRRHH],[ComentariosRRHH],[TipoModif],[FechaModif],[PersonalModig],[FechaRegistro],[Estado]) ";
                    comando += "VALUES (@TPermiso_Id,@Personal_ID,@FechaIni,@FechaFin,@Descuento,@TipoReg,@Motivo,@NroDoc,@AproJefe ";
                    comando += ",@ComentariosJefe,@AproRRHH,@ComentariosRRHH,NULL,NULL,NULL,GETDATE(),@Estado)";
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@TPermiso_Id", TPermiso_Id);
                            cmd.Parameters.AddWithValue("@Personal_ID", Personal_ID);
                            cmd.Parameters.AddWithValue("@FechaIni", FechaIni);
                            cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                            cmd.Parameters.AddWithValue("@Descuento", Descuento);
                            cmd.Parameters.AddWithValue("@TipoReg", TipoReg);
                            cmd.Parameters.AddWithValue("@Motivo", Motivo);
                            cmd.Parameters.AddWithValue("@NroDoc", NroDoc);
                            cmd.Parameters.AddWithValue("@AproJefe", "01");
                            cmd.Parameters.AddWithValue("@ComentariosJefe", "Registrado por el Sistema de Planilla");
                            cmd.Parameters.AddWithValue("@AproRRHH", "01");
                            cmd.Parameters.AddWithValue("@ComentariosRRHH", "Registrado por el Sistema de Planilla");
                            cmd.Parameters.AddWithValue("@Estado", "01");

                            cn.Open();
                            int xrow = cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("SELECT @@IDENTITY", cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            int NewPermisoD_Id = int.Parse(cmd.ExecuteScalar().ToString());
                            ActualizarDatosVariables(PeriodoId, Personal_ID, false, 0);
                            return "true#Registrado correctamente.#" + NewPermisoD_Id.ToString();
                        }
                    }
                }
                else
                {
                    comando = "UPDATE [dbo].[Permisos_Fecha_CA] ";
                    comando += "SET [Personal_ID] = Personal_ID,[FechaIni] = @FechaIni,[FechaFin] = @FechaFin,[Descuento] = @Descuento ";
                    comando += ",[Motivo] = @Motivo,[NroDoc] = @NroDoc,[TipoModif] = '01',[FechaModif] = GETDATE()";
                    comando += ",[PersonalModig] = @PersonalModig WHERE [PermisoD_Id] = @PermisoD_Id ";
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                            cmd.Parameters.AddWithValue("@FechaIni", FechaIni);
                            cmd.Parameters.AddWithValue("@FechaFin", FechaFin);
                            cmd.Parameters.AddWithValue("@Descuento", Descuento);
                            cmd.Parameters.AddWithValue("@Motivo", Motivo);
                            cmd.Parameters.AddWithValue("@NroDoc", NroDoc);
                            cmd.Parameters.AddWithValue("@PersonalModig", PersoModif);
                            cn.Open();
                            int xrow = cmd.ExecuteNonQuery();
                            if (xrow > 0)
                            {
                                ActualizarDatosVariables(PeriodoId, Personal_ID, false, 0);
                                return "true#Actualizado correctamente.";
                            }
                            else
                            {
                                return "false#.::Error > Permiso no encontrado.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }
        public ArrayList Get_Permiso_Fechas_Find(int PermisoD_Id)
        {
            string comando = "";
            int existe = 0;
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                comando = "SELECT COUNT(PERMISOD_ID) [E] FROM Permisos_Fecha_CA WHERE PermisoD_Id=@PermisoD_Id";
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                    cn.Open();
                    existe = int.Parse(cmd.ExecuteScalar().ToString());
                }
                if (existe == 1)
                {
                    comando = "SELECT ";
                    comando += "per.Apellido_Paterno + ' ' + per.Apellido_Materno + ', ' + per.Nombres [PersonalName],P.PermisoD_Id,P.TPermiso_Id ";
                    comando += ",P.Personal_ID,P.FechaIni,P.FechaFin,P.Descuento,P.TipoReg,P.Motivo,P.NroDoc,P.AproJefe,P.ComentariosJefe,P.AproRRHH ";
                    comando += ",P.ComentariosRRHH,P.TipoModif,P.FechaModif,P.PersonalModig,P.FechaRegistro,P.Estado ";
                    comando += ",ISNULL((SELECT '../CA/ArchivoPermiso/'+F.Name [Ruta] FROM FilePermiso F WHERE F.Permiso_Id=P.PermisoD_Id),'#') [Archivo] ";
                    comando += "FROM Permisos_Fecha_CA P INNER JOIN Personal PER ON P.Personal_ID=PER.Personal_Id ";
                    comando += "WHERE P.PermisoD_Id=@PermisoD_Id ";
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                        ArrayList rList = new ArrayList();
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
                else
                {
                    return null;
                }
            }
        }

        public string Get_Cancelar_SolicitudPermisoDias(int PermisoD_Id, string PersoModif, string PeriodoId, string Personal_ID)
        {
            string resultado = "";
            try
            {
                string comando = "UPDATE Permisos_Fecha_CA SET Estado='06',TipoModif='03',PersonalModig=@PersonalModig,FechaModif=GETDATE() ";
                comando += "WHERE PermisoD_Id=@PermisoD_Id";
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand(comando, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                        cmd.Parameters.AddWithValue("@PersonalModig", PersoModif);
                        cn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            ActualizarDatosVariables(PeriodoId, Personal_ID, true, PermisoD_Id);
                            resultado= "true#Permiso cancelado correctamente.";
                        }
                        else
                        {
                            resultado= "false#.::Error > No se encontro el permiso intentelo luego.";
                        }
                    }
                }
                return resultado;

            }
            catch (Exception ex)
            {
                return "false#.::Error > " + ex.Message;
            }
        }
        public string ProcesarRegistroPermisos(int PermisoD_Id, int TPermiso_Id, string Personal_ID, DateTime FechaIni, DateTime FechaFin, string Descuento, string TipoReg, string Motivo, string NroDoc, string PersoModif, string PeriodoId)
        {
            int dias = (int)(FechaFin - FechaIni).TotalDays;
            dias += 1;
            if (PermisoD_Id == 0 && TPermiso_Id == 1 && dias > 20)
            {
                DateTime nfechafin = FechaIni.AddDays(19);
                string res1 = Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, nfechafin, Descuento, TipoReg, Motivo, NroDoc, PersoModif, PeriodoId);

                nfechafin = nfechafin.AddDays(1);
                return Get_AM_Permisos_Fechas(PermisoD_Id, 2, Personal_ID, nfechafin, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif, PeriodoId);
            }
            else
            {
                return Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif, PeriodoId);
            }
        }
        public string ActualizarDatosVariables(string PeriodoId, string Personal_ID,bool resta,int xPermisoId)
        {
            for (int t = 1; t <= 2; t++)
            {
                List<int> codigos = new List<int>();
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    using (SqlCommand cmd = new SqlCommand("uspListarPermisoxPersonalCalculo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PeriodoId", PeriodoId);
                        cmd.Parameters.AddWithValue("@PersonalId", Personal_ID);
                        cmd.Parameters.AddWithValue("@Tipo", t);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            codigos.Add(int.Parse(dr.GetValue(0).ToString()));
                        }
                    }
                }
                if (resta == true)
                {
                    codigos.Clear();
                    codigos.Add(xPermisoId);
                }

                string comando = "";
                int tipo = 0;
                int cantidad = 0;
                string ConceptoId = "";
                string NTipo = "";
                //Dictionary<int, int> source = new Dictionary<int, int>();
                for (int x = 0; x <= codigos.Count - 1; x++)
                {
                    DateTime fechaini = DateTime.Now, fechafin = DateTime.Now;
                    int PermisoD_Id = codigos[x];
                    
                    comando = "SELECT P.TPermiso_Id,P.Personal_Id,P.FechaIni,P.FechaFin,ISNULL(PM.Concepto_Id,''),PM.descripcion ";
                    comando += "FROM Permisos_Fecha_CA P LEFT JOIN Permisos_MS PM ON P.TPermiso_Id=PM.Permiso_Id ";
                    comando += "WHERE P.PermisoD_Id=@PermisoD_Id ";
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@PermisoD_Id", PermisoD_Id);
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                tipo = int.Parse(dr.GetValue(0).ToString());
                                Personal_ID = dr.GetValue(1).ToString();
                                fechaini = DateTime.Parse(dr.GetValue(2).ToString());
                                fechafin = DateTime.Parse(dr.GetValue(3).ToString());
                                ConceptoId = dr.GetValue(4).ToString();
                                NTipo = dr.GetValue(5).ToString();
                            }
                        }
                    }
                    //if (tipo == 1 || tipo == 2)
                    //{
                        DateTime pfechaini = DateTime.Now, pfechafin = DateTime.Now;
                        comando = "SELECT FECHA_INI,FECHA_FIN FROM Periodo WHERE PERIODO_ID=@PERIODO_ID";
                        using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                        {
                            using (SqlCommand cmd = new SqlCommand(comando, cn))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@PERIODO_ID", PeriodoId);
                                cn.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    pfechaini = DateTime.Parse(dr.GetValue(0).ToString());
                                    pfechafin = DateTime.Parse(dr.GetValue(1).ToString());
                                }
                            }
                        }

                        DateTime tfecha = fechaini;
                        while (tfecha <= fechafin)
                        {
                            if (tfecha >= pfechaini && tfecha <= pfechafin)
                            {
                                cantidad++;
                            }
                            tfecha = tfecha.AddDays(1);
                        }
                    //}
                }
                if (cantidad > 0)
                {

                    comando = "UPDATE D_VARIABLES SET VALOR=@VALOR,FECHA_MODIF=GETDATE() WHERE ";
                    comando += " PERIODO_ID=@PERIODO_ID AND PERSONAL_ID=@PERSONAL_ID ";
                    if (resta==true)
                    {
                        comando = "UPDATE D_variables SET Valor=CASE WHEN (Valor-@VALOR)<0 THEN 0 ELSE (Valor-@VALOR) END,FECHA_MODIF=GETDATE() ";
                        comando += "WHERE PERIODO_ID=@PERIODO_ID AND PERSONAL_ID=@PERSONAL_ID ";
                    }
                    /*if (tipo == 1)
                    {
                        comando += " AND Concepto_Id='000027'";
                    }
                    else
                    {
                        comando += " AND Concepto_Id='000557'";
                    }*/
                    comando += " AND Concepto_Id='" + ConceptoId + "'";
                    if (ConceptoId == "")
                    {
                        return "false#El tipo de permiso:"+ NTipo + " no tiene un concepto asociado. Debe actualizar la información.";
                    }
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@VALOR", cantidad);
                            cmd.Parameters.AddWithValue("@PERIODO_ID", PeriodoId);
                            cmd.Parameters.AddWithValue("@PERSONAL_ID", Personal_ID);

                            cn.Open();
                            int xrow = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            return "true#Registrado correctamente.";
        }
    }
}
