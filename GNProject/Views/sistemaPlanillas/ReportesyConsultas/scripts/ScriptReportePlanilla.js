function SISGNRSPeriodoPlanillaSelect() {
    var EmpresaID = document.getElementById('empresaSession').value, Anio = document.getElementById('anioSession').value, Planilla_Id = document.getElementById('planillaSession').value;
    params = {
        Compania_Id: EmpresaID,
        Anio: Anio,
        Planilla_Id: Planilla_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "rptPlanilla.aspx/Get_Periodo_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var datos = response.d;
            var _len = datos.length - 1;
            $('#cboPeriodoIni').html('');
            $('#cboPeriodoFin').html('');
            for (var i = 0; i <= _len; i++) {
                var html = '<option value="' + datos[i].Periodo_Id + '">' + datos[i].Descripcion + '</option>';
                $(html).appendTo('#cboPeriodoIni');
                $(html).appendTo('#cboPeriodoFin');
            }
            var y = document.getElementById('cboPeriodoIni').options;
            document.getElementById('cboPeriodoIni').selectedIndex = y.length - 1;
            document.getElementById('cboPeriodoFin').selectedIndex = y.length - 1;
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                },
        async: true
    });
};
function SISGNRSReporteGeneralPlanillaSISGNRSReporteGeneralPlanilla() {
    var PeriodoIni = $('#cboPeriodoIni').val(), PeriodoFin = $('#cboPeriodoFin').val(), Proceso = $('#cboProceso').val();
    params = {
        Proceso:Proceso,
        PeriodoIni: PeriodoIni,
        PeriodoFin: PeriodoFin
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "rptPlanilla.aspx/SISGNRSReporteGeneralPlanilla",
        contentType: "application/json; chartseft:utf-8",
        beforeSend: function () { $('#tbodyData').html(''); document.getElementById('barrprocess').style.display = 'block'; },
        success: function (response) {
            var datos = response.d;
            var _len = datos.length - 1;
            $('#tbodyData').html('');
            for (var i = 0; i <= _len; i++) {
                var html = '<tr>';
                html += '<td>' + datos[i].Razon_Social + '</td>';
html += '<td>' + datos[i].Direccion_cia + '</td>';
html += '<td>' + datos[i].RUC  + '</td>';
//html += '<td>' + datos[i].Reg_Patronal  + '</td>';
html += '<td>' + datos[i].Telefono  + '</td>';
html += '<td>' + datos[i].Proceso  + '</td>';
html += '<td>' + datos[i].CCosto_Id  + '</td>';
//html += '<td>' + datos[i].Planilla_Id  + '</td>';
html += '<td>' + datos[i].TipoTrabajador  + '</td>';
html += '<td>' + datos[i].Catego  + '</td>';
html += '<td>' + datos[i].Catego2  + '</td>';
html += '<td>' + datos[i].Area  + '</td>';
html += '<td>' + datos[i].Personal_Id  + '</td>';
html += '<td>' + datos[i].Nombre_Completo  + '</td>';
//html += '<td>' + datos[i].Periodo_Id  + '</td>';
html += '<td>' + datos[i].Periodo  + '</td>';
html += '<td>' + datos[i].AnoMes  + '</td>';
//html += '<td>' + datos[i].Cargo_Id  + '</td>';
html += '<td>' + datos[i].Cargo  + '</td>';
html += '<td>' + datos[i].AFP_Id  + '</td>';
html += '<td>' + datos[i].AFP  + '</td>';
html += '<td>' + datos[i].Fecha_Ingreso  + '</td>';
html += '<td>' + datos[i].Fecha_Nacimiento  + '</td>';
html += '<td>' + datos[i].Fecha_Cese  + '</td>';
//html += '<td>' + datos[i].Proceso_Id  + '</td>';
html += '<td>' + datos[i].Direccion  + '</td>';
//html += '<td>' + datos[i].Tipo_Doc_Id  + '</td>';
html += '<td>' + datos[i].Nro_Doc  + '</td>';
html += '<td>' + datos[i].Afp_Cod_Afiliacion  + '</td>';
html += '<td>' + datos[i].Seguro_Cod  + '</td>';
html += '<td>' + datos[i].HOR230  + '</td>';
html += '<td>' + datos[i].HOR35  + '</td>';
html += '<td>' + datos[i].HORDOB  + '</td>';
html += '<td>' + datos[i].Fecha_Fin_Contrato  + '</td>';
html += '<td>' + datos[i].Fecha_Ini_Periodo  + '</td>';
html += '<td>' + datos[i].Fecha_Fin_Periodo  + '</td>';
html += '<td>' + datos[i].Concepto_Id1  + '</td>';
html += '<td>' + datos[i].Valor1  + '</td>';
html += '<td>' + datos[i].Concepto_Id2  + '</td>';
html += '<td>' + datos[i].Valor2  + '</td>';
html += '<td>' + datos[i].Concepto_Id3  + '</td>';
html += '<td>' + datos[i].Valor3  + '</td>';
html += '<td>' + datos[i].NroHrsExt  + '</td>';
html += '<td>' + datos[i].NroHrsExtN  + '</td>';
html += '<td>' + datos[i].NroHrsExtT  + '</td>';
html += '<td>' + datos[i].TotHoras  + '</td>';
html += '<td>' + datos[i].TotHoras1  + '</td>';
html += '<td>' + datos[i].TotHoras2  + '</td>';
html += '<td>' + datos[i].TotHoras3  + '</td>';
html += '<td>' + datos[i].TotDM  + '</td>';
html += '<td>' + datos[i].TotDMS  + '</td>';
html += '<td>' + datos[i].FechaINIvaca  + '</td>';
html += '<td>' + datos[i].FechaFINvaca  + '</td>';
html += '<td>' + datos[i].PerFecIni  + '</td>';
html += '<td>' + datos[i].PerFecFin  + '</td>';
html += '<td>' + datos[i].Sueldo_Mes  + '</td>';
html += '<td>' + datos[i].Tipo_Cambio  + '</td>';
html += '<td>' + datos[i].Situacion  + '</td>';
html += '<td>' + datos[i].Ingresos_Afectos  + '</td>';
html += '<td>' + datos[i].Ctacte_Saldo  + '</td>';
html += '<td>' + datos[i].Ctacte_Cuotas  + '</td>';
html += '<td>' + datos[i].Ctacte_TotalDeuda  + '</td>';
html += '<td>' + datos[i].Total_Ingresos  + '</td>';
html += '<td>' + datos[i].Total_Descuentos  + '</td>';
html += '<td>' + datos[i].Total_Aportes  + '</td>';
html += '<td>' + datos[i].Total_Netos  + '</td>';
html += '<td>' + datos[i].Bancos  + '</td>';
html += '<td>' + datos[i].Cuenta  + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyData');
            }
            document.getElementById('barrprocess').style.display = 'none';
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                    document.getElementById('barrprocess').style.display = 'none';
                },
        async: true
    });
};
function SISGNRSProcesosSelect() {
    $('<option value="01">REMUNERACIONES</option>').appendTo('#cboProceso');
    $('<option value="02">QUINCENA</option>').appendTo('#cboProceso');
    $('<option value="03">VACACIONES</option>').appendTo('#cboProceso');
    $('<option value="04">GRATIFICACION</option>').appendTo('#cboProceso');
    $('<option value="05">CTS</option>').appendTo('#cboProceso');
    $('<option value="06">PROVISION</option>').appendTo('#cboProceso');
    $('<option value="07">UTILIDADES</option>').appendTo('#cboProceso');
    $('<option value="08">LIQUIDACION</option>').appendTo('#cboProceso');
}
function initialize() {
    SISGNRSProcesosSelect();
    SISGNRSPeriodoPlanillaSelect();

    $('#btngenerar').click(function () { SISGNRSReporteGeneralPlanilla(); });
    $('#btnExcel').click(function () { tableToExcel('tblDatos', 'Planilla General'); });

}
function SISGNRSReporteGeneralPlanilla() {
    var PeriodoIni = $('#cboPeriodoIni').val(), PeriodoFin = $('#cboPeriodoFin').val(), Proceso = $('#cboProceso').val(), PlanillaId = document.getElementById('planillaSession').value;
    params = {
        PlanillaId: PlanillaId,
        Proceso: Proceso,
        PeriodoIni: PeriodoIni,
        PeriodoFin: PeriodoFin
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "rptPlanilla.aspx/SISGNRSReporteGeneralPlanilla",
        contentType: "application/json; chartseft:utf-8",
        beforeSend: function () { $('#tbodyData').html(''); $('#thDatos').html(''); document.getElementById('barrprocess').style.display = 'block'; },
        success: function (response) {
            var datos = response.d;
            var _len = datos.length - 1;
            var cantoTh = 0;
            $('#thDatos').html('');
            for (var i = 0; i <= _len; i++) {
                var cr = [];
                cr = datos[i];
                var html = '';
                var tyeo = getClass(cr);
                if (tyeo == 'String') {
                    html += '<th>' + cr + '</th>';
                    cantoTh += 1;
                    $(html).appendTo('#thDatos');
                } else if (tyeo == 'Array') {
                    var datosd = cr;
                    html += '<tr>';
                    for (var g = 0; g <= datosd.length - 1; g++) {
                        html += '<td>' + datosd[g] + '</td>';
                    }
                    html += '</tr>';
                    $(html).appendTo('#tbodyData');
                }


            }
            document.getElementById('barrprocess').style.display = 'none';
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#secError").html(XmlHttpError.responseText);
                    document.getElementById('barrprocess').style.display = 'none';
                },
        async: true
    });
};
function getClass(obj) {
    if (typeof obj === "undefined")
        return "undefined";
    if (obj === null)
        return "null";
    return Object.prototype.toString.call(obj)
    .match(/^\[object\s(.*)\]$/)[1];
}



