using CAPA_DATOS;
using CAPA_ENTIDAD.EntMs;
using GNProject.Views.sistemaPlanillas.code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNProject.Views.sistemaPlanillas.Procesos
{
    public partial class FrmGenerarTRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarTXT_Click(object sender, EventArgs e)
        {
            string TEjercicio = Utils.fc_obtiene_Ejercicio_Id(this);
            string TPeriodo = Utils.fc_obtiene_Periodo_Id(this);
            string Tnombre = "RP_" + controllerGenerarTRegistro.getInstance().RetornarNombreArchivo(TEjercicio, TPeriodo);
            string codigos = "";
            if (HHcodigos.Value == "")
            {
                codigos = "all";
            }
            else
            {
                codigos = HHcodigos.Value;
            }
            if (chktodos.Checked == true)
            {
                codigos = "all";
            }
            string periodoId = Utils.fc_obtiene_Periodo_Id(this).ToString();
            string formato = cboTRegistro.SelectedValue.ToString();
            if (formato == "E4")
            {
                code.dsTRegistroTableAdapters.uspGenerarFormatoE4TRegistroTableAdapter tabe4 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE4TRegistroTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe4);
                dsTRegistro.uspGenerarFormatoE4TRegistroDataTable tabe4b = tabe4.GetData(periodoId, codigos);

                //DataTable ordenado = new DataTable();
                for (int c = 0; c <= tabe4b.Columns.Count - 1; c++)
                {
                    string nombre = tabe4b.Columns[c].ColumnName;
                    switch (nombre)
                    {
                        case "iRow": tabe4b.Columns[c].SetOrdinal(0); break;
                        case "TIPO": tabe4b.Columns[c].SetOrdinal(1); break;
                        case "NUMERO": tabe4b.Columns[c].SetOrdinal(2); break;
                        case "PAIS": tabe4b.Columns[c].SetOrdinal(3); break;
                        case "FECHA_NACIMIENTO": tabe4b.Columns[c].SetOrdinal(4); break;
                        case "APELLIDO_PATERNO": tabe4b.Columns[c].SetOrdinal(5); break;
                        case "APELLIDO_MATERNO": tabe4b.Columns[c].SetOrdinal(6); break;
                        case "NOMBRES": tabe4b.Columns[c].SetOrdinal(7); break;
                        case "SEXO": tabe4b.Columns[c].SetOrdinal(8); break;
                        case "NACIONALIDAD_ID": tabe4b.Columns[c].SetOrdinal(9); break;
                        case "COD_LD": tabe4b.Columns[c].SetOrdinal(10); break;
                        case "TELEFONO": tabe4b.Columns[c].SetOrdinal(11); break;
                        case "EMAIL": tabe4b.Columns[c].SetOrdinal(12); break;
                        case "TIPO_VIA": tabe4b.Columns[c].SetOrdinal(13); break;
                        case "NOMBRE_VIA": tabe4b.Columns[c].SetOrdinal(14); break;
                        case "NUMERO_VIA": tabe4b.Columns[c].SetOrdinal(15); break;
                        case "DEPARTAMENTO": tabe4b.Columns[c].SetOrdinal(16); break;
                        case "INTERIOR": tabe4b.Columns[c].SetOrdinal(17); break;
                        case "MANZANA": tabe4b.Columns[c].SetOrdinal(18); break;
                        case "LOTE": tabe4b.Columns[c].SetOrdinal(19); break;
                        case "KM": tabe4b.Columns[c].SetOrdinal(20); break;
                        case "BLOCK": tabe4b.Columns[c].SetOrdinal(21); break;
                        case "ETAPA": tabe4b.Columns[c].SetOrdinal(22); break;
                        case "TIPO_ZONA": tabe4b.Columns[c].SetOrdinal(23); break;
                        case "NOMBRE_ZONA": tabe4b.Columns[c].SetOrdinal(24); break;
                        case "REFERENCIA": tabe4b.Columns[c].SetOrdinal(25); break;
                        case "UBIGEO": tabe4b.Columns[c].SetOrdinal(26); break;
                        case "ESSALUD": tabe4b.Columns[c].SetOrdinal(27); break;
                    }
                }

                //ExportarArchivoToDataTable("FormatoE4", tabe4b, ".ide");
                ExportarArchivoToDataTable(Tnombre, tabe4b, ".ide");
            }
            if (formato == "E5")
            {
                code.dsTRegistroTableAdapters.uspGenerarFormatoE5TRegistroTableAdapter tabe5 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE5TRegistroTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe5);
                dsTRegistro.uspGenerarFormatoE5TRegistroDataTable tabe5b = tabe5.GetData(periodoId, codigos);
                for (int c = 0; c <= tabe5b.Columns.Count - 1; c++)
                {
                    string nombre = tabe5b.Columns[c].ColumnName;
                    switch (nombre)
                    {
                        case "iRow": tabe5b.Columns[c].SetOrdinal(0); break;
                        case "TIPO": tabe5b.Columns[c].SetOrdinal(1); break;
                        case "NUMERO": tabe5b.Columns[c].SetOrdinal(2); break;
                        case "PAIS": tabe5b.Columns[c].SetOrdinal(3); break;
                        case "REGIMEN_LABORAL": tabe5b.Columns[c].SetOrdinal(4); break;
                        case "NIVEL_EDUCATIVO": tabe5b.Columns[c].SetOrdinal(5); break;
                        case "OCUPACION": tabe5b.Columns[c].SetOrdinal(6); break;
                        case "DISCAPACIDAD": tabe5b.Columns[c].SetOrdinal(7); break;
                        case "CUSPP": tabe5b.Columns[c].SetOrdinal(8); break;
                        case "SCTR": tabe5b.Columns[c].SetOrdinal(9); break;
                        case "TIPO_CONTRATO": tabe5b.Columns[c].SetOrdinal(10); break;
                        case "SUJETO_REG_ATIPICO": tabe5b.Columns[c].SetOrdinal(11); break;
                        case "JORNADA_MAXIMA": tabe5b.Columns[c].SetOrdinal(12); break;
                        case "HORARIO_NOCTURNO": tabe5b.Columns[c].SetOrdinal(13); break;
                        case "SINDICATO": tabe5b.Columns[c].SetOrdinal(14); break;
                        case "PERIODO_REMUNERACION": tabe5b.Columns[c].SetOrdinal(15); break;
                        case "SUELDO": tabe5b.Columns[c].SetOrdinal(16); break;
                        case "SITUACION": tabe5b.Columns[c].SetOrdinal(17); break;
                        case "EXO_RENTA5TA": tabe5b.Columns[c].SetOrdinal(18); break;
                        case "SITUACION_ESPECIAL": tabe5b.Columns[c].SetOrdinal(19); break;
                        case "TIPO_PAGO": tabe5b.Columns[c].SetOrdinal(20); break;
                        case "TIPO_TRABAJADOR": tabe5b.Columns[c].SetOrdinal(21); break;
                        case "CONVENIO_DOBLE": tabe5b.Columns[c].SetOrdinal(22); break;
                        case "RUC": tabe5b.Columns[c].SetOrdinal(23); break;
                    }
                }
                //ExportarArchivoToDataTable("FormatoE5", tabe5b, ".tra");
                ExportarArchivoToDataTable(Tnombre, tabe5b, ".tra");
            }
            if (formato == "E11")
            {
                code.dsTRegistroTableAdapters.uspGenerarFormatoE11TRegistroTableAdapter tabe11 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE11TRegistroTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe11);
                dsTRegistro.uspGenerarFormatoE11TRegistroDataTable tabe11b = tabe11.GetData(periodoId, codigos);
                for (int c = 0; c <= tabe11b.Columns.Count - 1; c++)
                {
                    string nombre = tabe11b.Columns[c].ColumnName;
                    switch (nombre)
                    {
                        case "iRow": tabe11b.Columns[c].SetOrdinal(0); break;
                        case "TIPO": tabe11b.Columns[c].SetOrdinal(1); break;
                        case "NUMERO": tabe11b.Columns[c].SetOrdinal(2); break;
                        case "PAIS": tabe11b.Columns[c].SetOrdinal(3); break;
                        case "CATEGORIA": tabe11b.Columns[c].SetOrdinal(4); break;
                        case "FECHA_INICIO": tabe11b.Columns[c].SetOrdinal(5); break;
                        case "FECHA_FIN": tabe11b.Columns[c].SetOrdinal(6); break;
                        case "MOTIVO_BAJA": tabe11b.Columns[c].SetOrdinal(7); break;
                        case "FECHA_INICIO2": tabe11b.Columns[c].SetOrdinal(8); break;
                        case "FECHA_FIN2": tabe11b.Columns[c].SetOrdinal(9); break;
                        case "TIPO_TRABAJADOR": tabe11b.Columns[c].SetOrdinal(10); break;
                        case "FECHA_INICIO3": tabe11b.Columns[c].SetOrdinal(11); break;
                        case "FECHA_FIN3": tabe11b.Columns[c].SetOrdinal(12); break;
                        case "REGIMEN_SALUD": tabe11b.Columns[c].SetOrdinal(13); break;
                        case "EPS": tabe11b.Columns[c].SetOrdinal(14); break;
                        case "FECHA_INICIO4": tabe11b.Columns[c].SetOrdinal(15); break;
                        case "FECHA_FIN4": tabe11b.Columns[c].SetOrdinal(16); break;
                        case "REGIMEN_PEN": tabe11b.Columns[c].SetOrdinal(17); break;
                        case "FECHA_INICIO5": tabe11b.Columns[c].SetOrdinal(18); break;
                        case "FECHA_FIN5": tabe11b.Columns[c].SetOrdinal(19); break;
                        case "SCTR_SALUD": tabe11b.Columns[c].SetOrdinal(20); break;

                    }
                }
                //ExportarArchivoToDataTable("FormatoE11", tabe11b, ".per");
                ExportarArchivoToDataTable(Tnombre, tabe11b, ".per");
            }
            if (formato == "E17")
            {
                code.dsTRegistroTableAdapters.uspGenerarFormatoE17TRegistroTableAdapter tabe17 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE17TRegistroTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe17);
                dsTRegistro.uspGenerarFormatoE17TRegistroDataTable tabe17b = tabe17.GetData(periodoId, codigos);
                for (int c = 0; c <= tabe17b.Columns.Count - 1; c++)
                {
                    string nombre = tabe17b.Columns[c].ColumnName;
                    switch (nombre)
                    {
                        case "iRow": tabe17b.Columns[c].SetOrdinal(0); break;
                        case "TIPO": tabe17b.Columns[c].SetOrdinal(1); break;
                        case "NUMERO": tabe17b.Columns[c].SetOrdinal(2); break;
                        case "PAIS": tabe17b.Columns[c].SetOrdinal(3); break;
                        case "RUC": tabe17b.Columns[c].SetOrdinal(4); break;
                        case "ESTABLECIMIENTO": tabe17b.Columns[c].SetOrdinal(5); break;
                    }
                }
                //ExportarArchivoToDataTable("FormatoE17", tabe17b, ".est");
                ExportarArchivoToDataTable(Tnombre, tabe17b, ".est");
            }
            if (formato == "E29")
            {
                code.dsTRegistroTableAdapters.uspGenerarFormatoE29TRegistroTableAdapter tabe29 = new code.dsTRegistroTableAdapters.uspGenerarFormatoE29TRegistroTableAdapter();
                ClaseGlobal.ChangeTableAdapterConnection_x_Empresa(ref tabe29);
                dsTRegistro.uspGenerarFormatoE29TRegistroDataTable tabe29b = tabe29.GetData(periodoId, codigos);
                for (int c = 0; c <= tabe29b.Columns.Count - 1; c++)
                {
                    string nombre = tabe29b.Columns[c].ColumnName;
                    switch (nombre)
                    {
                        case "iRow": tabe29b.Columns[c].SetOrdinal(0); break;
                        case "TIPO": tabe29b.Columns[c].SetOrdinal(1); break;
                        case "NUMERO": tabe29b.Columns[c].SetOrdinal(2); break;
                        case "PAIS": tabe29b.Columns[c].SetOrdinal(3); break;
                        case "FORMACION_SUPERIOR": tabe29b.Columns[c].SetOrdinal(4); break;
                        case "INDICADOR_EDUCACION": tabe29b.Columns[c].SetOrdinal(5); break;
                        case "CODIGO_INSTITUCION": tabe29b.Columns[c].SetOrdinal(6); break;
                        case "CODIGO_CARRERA": tabe29b.Columns[c].SetOrdinal(7); break;
                        case "ANIO_EGRESO": tabe29b.Columns[c].SetOrdinal(8); break;

                    }
                }

                //ExportarArchivoToDataTable("FormatoE29", tabe29b, ".edu");
                ExportarArchivoToDataTable(Tnombre, tabe29b, ".edu");
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string codigos = "";
            if (HHcodigos.Value == "")
            {
                codigos = "all";
            }
            else
            {
                codigos = HHcodigos.Value;
            }
            if (chktodos.Checked == true)
            {
                codigos = "all";
            }

            string parametros = "TREGISTRO" + cboTRegistro.SelectedValue.ToString() + "&prm=" + Utils.fc_obtiene_Periodo_Id(this).ToString() + ":" + codigos;
            string script;
            script = "window.open('../Reportes/FrmPrint.aspx?Reporte_Id=" + parametros + "','Reportes','width=900,height=800,scrollbars=yes');";
            Utils.fc_JavaScript(this, script);
        }
        private bool ExportarArchivoToDataTable(string sFilename, DataTable tabla, string extension)
        {

            StringBuilder str = new StringBuilder();
            string s = "";
            System.Data.DataTable oLista = new System.Data.DataTable();
            oLista = tabla;

            if (oLista == null || oLista.Rows.Count <= 0)
                return false;
            else
                for (int i = 0; i < oLista.Rows.Count; i++)
                {
                    string miCadena = "";
                    for (int c = 1; c <= oLista.Columns.Count - 1; c++)
                    {
                        string valor = oLista.Rows[i][c].ToString();
                        if (valor.IndexOf("12:00:00") > -1)
                        {
                            valor = valor.Substring(0, 10);
                        }
                        if (valor.IndexOf("01/01/1900") > -1)
                        {
                            valor = "";
                        }
                        miCadena += valor + "|";
                    }
                    if (miCadena.Length > 0)
                    {
                        miCadena = miCadena.Remove(miCadena.Length - 1, 1);
                    }
                    s = s + HttpUtility.HtmlDecode(miCadena);
                    //sw.WriteLine(s);
                    str.Append(s);
                    str.AppendLine();
                    s = "";
                }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + sFilename + extension);
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.text";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            Response.Write(str.ToString());
            Response.End();
            return true;
        }


        //GET COLUMNAS FILTRO PERSONAL
        [WebMethod]
        public static ArrayList ListaColumnPersonal()
        {
            return ControllerMaestroPersonal.GetInstance().ListaColumnPersonal();
        }
        //GET PERSONAL X FILTRO
        //[WebMethod]
        //public static List<ListaPersonal> Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        //{
        //    return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio);
        //}
        [WebMethod]
        public static object Lista_Personal_x_Filtro_Columna(string Compania_Id, string Periodo_Id, string NomColumna, string Param, int inicio)
        {
            //return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id,Periodo_Id,NomColumna,Param,inicio);
            Int32 qt_registros;
            List<ListaPersonal> oBandeja = ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio, out qt_registros);
            object response = new { oBandeja = oBandeja, qt_registros = qt_registros };
            return response;
        }
        //GET  MAX ROWS
        [WebMethod]
        public static int Lista_Personal_x_Filtro_Columna_MaxRows(string Compania_Id, string Periodo_Id, string NomColumna, string Param)
        {
            return ControllerMaestroPersonal.GetInstance().Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
        }
    }
}