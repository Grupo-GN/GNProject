using CAPA_ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CAPA_DATOS
{
    public class controller_GenerarArchivoEstado
    {
        private static controller_GenerarArchivoEstado instance = null;
        public static controller_GenerarArchivoEstado get_Instance()
        {
            return instance == null ? instance = new controller_GenerarArchivoEstado() : instance;
        }
        public List<Ent_GenerarArchivoEstado> ListarEstadosArchivo(int Codigo,string Planilla, string Periodo_Id, string Personal_Id = "")
        {
            List<Ent_GenerarArchivoEstado> rList = new List<Ent_GenerarArchivoEstado>();
            using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
            {
                string comando = "SELECT Planilla_Id,Periodo_Id,Personal_Id,Codigo_Id,Estado_Id,Observaciones,FechReg,";
                comando += "UsuarioReg,ISNULL(FechaAct,'19000101') [FechaAct],UsuarioAct ";
                comando += "FROM GenerarArchivoEstado ";
                comando += "WHERE Codigo_Id=@Codigo_Id AND Planilla_Id=@Planilla_Id AND Periodo_Id=@Periodo_Id ";
                if (Personal_Id != "")
                {
                    comando += " AND Personal_Id=@Personal_Id";
                }
                using (SqlCommand cmd = new SqlCommand(comando, cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Codigo_Id", Codigo);
                    cmd.Parameters.AddWithValue("@Planilla_Id", Planilla);
                    cmd.Parameters.AddWithValue("@Periodo_Id", Periodo_Id);
                    cmd.Parameters.AddWithValue("@Personal_Id", Personal_Id);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Ent_GenerarArchivoEstado obj = new Ent_GenerarArchivoEstado();
                        obj.Planilla_Id = dr.GetValue(0).ToString();
                        obj.Periodo_Id = dr.GetValue(1).ToString();
                        obj.Personal_Id = dr.GetValue(2).ToString();
                        obj.Codigo_Id = int.Parse(dr.GetValue(3).ToString());
                        obj.Estado_Id = dr.GetValue(4).ToString();
                        obj.Observaciones = dr.GetValue(5).ToString();
                        obj.FechReg = DateTime.Parse(dr.GetValue(6).ToString());
                        obj.UsuarioReg = dr.GetValue(7).ToString();
                        obj.FechaAct = DateTime.Parse(dr.GetValue(8).ToString());
                        obj.UsuarioAct = dr.GetValue(9).ToString();
                        if (obj.FechaAct.Year == 1900)
                        {
                            obj.FechaAct = obj.FechReg;
                        }

                        rList.Add(obj);
                    }
                }
            }
            return rList;
        }
        public string ProcesarEstadosArchivo(Ent_GenerarArchivoEstado obj)
        {
            string resultado = "false#";
            try
            {
                int existe = 0;
                using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                {
                    string comandox = "SELECT Planilla_Id,Periodo_Id,Personal_Id,Codigo_Id ";
                    comandox += "FROM GenerarArchivoEstado ";
                    comandox += "WHERE Codigo_Id=@Codigo_Id AND Planilla_Id=@Planilla_Id AND Periodo_Id=@Periodo_Id ";
                    comandox += " AND Personal_Id=@Personal_Id";

                    using (SqlCommand cmd = new SqlCommand(comandox, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Codigo_Id", obj.Codigo_Id);
                        cmd.Parameters.AddWithValue("@Planilla_Id", obj.Planilla_Id);
                        cmd.Parameters.AddWithValue("@Periodo_Id", obj.Periodo_Id);
                        cmd.Parameters.AddWithValue("@Personal_Id", obj.Personal_Id);
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            existe += 1;
                        }
                    }
                }

                if (existe == 0)
                {
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        string comando = "INSERT INTO [dbo].[GenerarArchivoEstado] ";
                        comando += "([Planilla_Id],[Periodo_Id],[Personal_Id],[Codigo_Id],[Estado_Id],[Observaciones],[FechReg],[UsuarioReg]) ";
                        comando += "VALUES ";
                        comando += "(@Planilla_Id, @Periodo_Id, @Personal_Id, @Codigo_Id ";
                        comando += ", @Estado_Id, @Observaciones, GETDATE(), @UsuarioReg) ";
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Planilla_Id", obj.Planilla_Id);
                            cmd.Parameters.AddWithValue("@Periodo_Id", obj.Periodo_Id);
                            cmd.Parameters.AddWithValue("@Personal_Id", obj.Personal_Id);
                            cmd.Parameters.AddWithValue("@Codigo_Id", obj.Codigo_Id);
                            cmd.Parameters.AddWithValue("@Estado_Id", obj.Estado_Id);
                            cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                            cmd.Parameters.AddWithValue("@UsuarioReg", obj.UsuarioReg);
                            cn.Open();
                            int irows = cmd.ExecuteNonQuery();
                            if (irows > 0)
                            {
                                resultado = "true#Registrado correctamente";
                            }
                            else
                            {
                                resultado = "false#No se registró la información";
                            }
                        }
                    }
                }
                else
                {
                    using (SqlConnection cn = new SqlConnection(Conex.CadCon_String()))
                    {
                        string comando = "UPDATE [dbo].[GenerarArchivoEstado] ";
                        comando += "SET [Estado_Id] = @Estado_Id,[Observaciones] = @Observaciones ";
                        comando += ",[FechaAct] = GETDATE() ";
                        comando += ",[UsuarioAct] = @UsuarioAct ";
                        comando += "WHERE[Planilla_Id] = @Planilla_Id ";
                        comando += "AND [Periodo_Id] = @Periodo_Id ";
                        comando += "AND [Personal_Id] = @Personal_Id ";
                        comando += "AND [Codigo_Id] = @Codigo_Id ";
                        using (SqlCommand cmd = new SqlCommand(comando, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Planilla_Id", obj.Planilla_Id);
                            cmd.Parameters.AddWithValue("@Periodo_Id", obj.Periodo_Id);
                            cmd.Parameters.AddWithValue("@Personal_Id", obj.Personal_Id);
                            cmd.Parameters.AddWithValue("@Codigo_Id", obj.Codigo_Id);
                            cmd.Parameters.AddWithValue("@Estado_Id", obj.Estado_Id);
                            cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                            cmd.Parameters.AddWithValue("@UsuarioAct", obj.UsuarioReg);
                            cn.Open();
                            int irows = cmd.ExecuteNonQuery();
                            if (irows > 0)
                            {
                                resultado = "true#Actualizado correctamente";
                            }
                            else
                            {
                                resultado = "false#No se actualizó la información";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = "false#Error: " + ex.Message;
            }
            return resultado;
        }
    }
}
