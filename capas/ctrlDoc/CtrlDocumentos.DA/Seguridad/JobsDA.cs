using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CtrlDocumentos.BE.Seguridad;
using CtrlDocumentos.BE;
using System.Configuration;

namespace CtrlDocumentos.DA.Seguridad
{
    public class JobDA
    {
        SqlCommand SqlCommand;
        SqlParameter SqlPara;

        public JobBEList Get_ListaJob()
        {
            JobBEList lista = new JobBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "cdoc_sps_LISTA_PROCESOS_BD";

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    JobBE oBE = new JobBE();
                    indice = reader.GetOrdinal("id_proceso");
                    oBE.id_proceso = reader.IsDBNull(indice) ? 0 : reader.GetInt32(indice);

                    indice = reader.GetOrdinal("no_proceso");
                    oBE.no_proceso = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("no_detalle");
                    oBE.no_detalle = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("fl_proceso");
                    oBE.fl_proceso = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    lista.Add(oBE);
                }
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return lista;
        }
        public void EjecutarTarea(JobBE oBE, out int retorno, out String msg_retorno)
        {
            string strEnvioMailBD = ConfigurationManager.AppSettings["EnvioMailBD"].ToString();
            msg_retorno = "";

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_EJECUTA_PROCESOS_BD";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_proceso", oBE.id_proceso);
            SqlCommand.Parameters.AddWithValue("@vi_fl_envio_mail_bd", strEnvioMailBD);

            SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                if (strEnvioMailBD == "0")
                {
                    while (reader.Read())
                    {
                        int indice;

                        EnviarMailDA mailDA = new EnviarMailDA();
                        EnviarMailBE oMailBE = new EnviarMailBE();

                        indice = reader.GetOrdinal("no_para");
                        oMailBE.no_para = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_cc");
                        oMailBE.no_copia = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_bcc");
                        oMailBE.no_copia_oculta = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_asunto");
                        oMailBE.no_asunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("tx_body");
                        oMailBE.no_cuerpo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        //Enviar Email
                        bool estadoMail;
                        string strError = "";
                        estadoMail = mailDA.EnviarEmail(oMailBE, out strError);
                        if (!estadoMail)
                        {
                            retorno = oBE.id_proceso;
                            msg_retorno = "Se ejecutó correctamente. \n" + strError.ToString();
                        }
                    }

                }
                reader.Close();
                retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                if (string.IsNullOrEmpty(msg_retorno.ToString()))
                {
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = ex.Message.ToString();

                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }

        }
        public List<EnviarMailBE> EjecutarTarea_Lista(JobBE oBE, out int retorno, out String msg_retorno)
        {
            List<EnviarMailBE> oLista = new List<EnviarMailBE>();
            string strEnvioMailBD = ConfigurationManager.AppSettings["EnvioMailBD"].ToString();
            msg_retorno = "";

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "cdoc_sps_EJECUTA_PROCESOS_BD";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_id_proceso", oBE.id_proceso);
            SqlCommand.Parameters.AddWithValue("@vi_fl_envio_mail_bd", strEnvioMailBD);

            SqlPara = new SqlParameter("@vo_retorno", SqlDbType.Int);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlPara = new SqlParameter("@vo_msg_retorno", SqlDbType.VarChar, 8000);
            SqlPara.Direction = ParameterDirection.Output;
            SqlCommand.Parameters.Add(SqlPara);

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                if (strEnvioMailBD == "0")
                {
                    while (reader.Read())
                    {
                        int indice;

                        EnviarMailDA mailDA = new EnviarMailDA();
                        EnviarMailBE oMailBE = new EnviarMailBE();

                        indice = reader.GetOrdinal("no_para");
                        oMailBE.no_para = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_cc");
                        oMailBE.no_copia = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_bcc");
                        oMailBE.no_copia_oculta = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("no_asunto");
                        oMailBE.no_asunto = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        indice = reader.GetOrdinal("tx_body");
                        oMailBE.no_cuerpo = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                        oLista.Add(oMailBE);
                        ////////Enviar Email
                        //////bool estadoMail;
                        //////string strError = "";
                        //////estadoMail = mailDA.EnviarEmail(oMailBE, out strError);
                        //////if (!estadoMail)
                        //////{
                        //////    retorno = oBE.id_proceso;
                        //////    msg_retorno = "Se ejecutó correctamente. \n" + strError.ToString();
                        //////}
                    }

                }
                reader.Close();
                retorno = Int32.Parse(SqlCommand.Parameters["@vo_retorno"].Value.ToString());
                if (string.IsNullOrEmpty(msg_retorno.ToString()))
                {
                    msg_retorno = SqlCommand.Parameters["@vo_msg_retorno"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = -1;
                msg_retorno = ex.Message.ToString();

                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return oLista;
        }

    }
}
