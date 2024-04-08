// FILTRO CABECERA

function Get_Compania() {
    var cboCompa = document.getElementById('empresaSession').value;
    return cboCompa;
}

function Get_Periodo() {
    var cbo = document.getElementById('periodoSession').value;
    return cbo;
}
//OTROS FILTROS

function Get_ColumnaBusqueda() {
    var cbo = document.getElementById('cboBusquedaEn');
    return cbo.value;
}


function Get_TextoBusqueda() {
    var objetoRet = document.getElementById('txtBuscar');
    return objetoRet.value;
}
//FILTRO BUSCAR POR
function ListaColumnPersonal() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaColumnPersonal';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;

            $('#cboBusquedaEn').html('');
            $('<option value="Todos">Todos</option>').appendTo('#cboBusquedaEn');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][1] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboBusquedaEn');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function Lista_Personal_x_Filtro_Columna(Compania_Id, Periodo_Id, NomColumna, Param, inicio) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_x_Filtro_Columna';

    var params = {
        Compania_Id: Compania_Id,
        Periodo_Id: Periodo_Id,
        NomColumna: NomColumna,
        Param: Param,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            //var Datos = response.d;
            var objResponse = response.d;
            var Datos = objResponse.oBandeja; //@001 I/F
            var qt_registros = objResponse.qt_registros; //@001 I/F
            var lengthD = Datos.length - 1;
            $('#tbodyPersonal').html('');
            for (var i = 0; i <= lengthD; i++) {
                var StyleTR = '';
                var Estado = Datos[i].Estado_Id;
                if (Estado == '01') {
                    Estado = 'ACTIVO';
                    StyleTR = '';
                } else {
                    Estado = 'INACTIVO';
                    StyleTR = 'style="color:Red;"';
                }
                var chec = '';
                if (seleccionados.indexOf(Datos[i].Personal_Id) > -1) {
                    chec = ' checked="checked"'
                }
                var html = '<tr>';
                html += '<td><input id="' + Datos[i].Personal_Id + '" type="checkbox" class="chksel" ' + chec +' /></td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Personal_Id + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Paterno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Materno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nombres + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].TDocumento + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_Doc + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ingreso + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ini_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Fin_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Proyecto + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Telefono + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
            }
            //Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
            $('#txtnRegistros').val(qt_registros);
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}

function Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param) {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_x_Filtro_Columna_MaxRows';

    var params = {
        Compania_Id: Compania_Id,
        Periodo_Id: Periodo_Id,
        NomColumna: NomColumna,
        Param: Param,
        inicio: inicio
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            $('#txtnRegistros').val(Datos);


        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}


var seleccionados = [];
var xprocesar = [];

function PersonalCambio(PersonalId, PlanillaIdAct, PlanillaIdNew, PeriodoIdAct, PeriodoIdNew) {
    this.PersonalId = PersonalId;
    this.PlanillaIdAct = PlanillaIdAct;
    this.PlanillaIdNew = PlanillaIdNew;
    this.PeriodoIdAct = PeriodoIdAct;
    this.PeriodoIdNew = PeriodoIdNew;
}



//CAMBIO DE PLANILLA
function ListaTipoPlanillaChange() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaTipoPlanilla';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboPlanillaChange').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboPlanillaChange');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function ListaEjercicioChange() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaEjercicio';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboEjercicioChange').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboEjercicioChange');
            }
            $('#cboEjercicioChange option:last').attr('selected', 'selected');
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function ListaMesChange() {
    var EjercicioId = $('#cboEjercicioChange').val();
    var params = {
        EjercicioId: EjercicioId
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaMes';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboMesChange').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboMesChange');
            }
            $('#cboMesChange option:last').attr('selected', 'selected');
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
function ListaPeriodoChange() {
    var EjercicioId = $('#cboEjercicioChange').val(), Planilla_Id = $('#cboPlanillaChange').val(), MesId = $('#cboMesChange').val();
    var params = {
        EjercicioId: EjercicioId,
        Planilla_Id: Planilla_Id,
        MesId: MesId
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaPeriodo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboPeriodoChange').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
                $(html).appendTo('#cboPeriodoChange');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
    $('#cboMesChange option:last').attr('selected', 'selected');
}


function Lista_Personal_x_CambiarPlanilla() {

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaPersonalCambioPlanilla';

    var params = {
        PersonalId: seleccionados
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            xprocesar = [];
            $('#tbodycambio').html('');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<tr id="tr' + datos[i][0] + '">';
                html += '<td>' + datos[i][0] + '</td>';
                html += '<td>' + datos[i][1] + '</td>';
                html += '<td>' + datos[i][3] + '</td>';
                html += '<td>' + datos[i][5] + '</td>';
                html += '<td id="td' + datos[i][0]+'"></td>';
                html += '</tr>';
                $(html).appendTo('#tbodycambio');
                var item = new PersonalCambio(datos[i][0], datos[i][2], '', datos[i][4], '');
                xprocesar.push(item);
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}


function ProcesarCambio() {
    for (var i = 0; i <= xprocesar.length - 1; i++) {
        xprocesar[i].PlanillaIdNew = $('#cboPlanillaChange').val();
        xprocesar[i].PeriodoIdNew = $('#cboPeriodoChange').val();
    }
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ProcesarCambioPlanilla';
    for (var i = 0; i <= xprocesar.length - 1; i++) {
        var cambio = xprocesar[i];
        var params = {
            PersonalId: cambio.PersonalId,
            PlanillaIdAct: cambio.PlanillaIdAct,
            PlanillaIdNew: cambio.PlanillaIdNew,
            PeriodoIdAct: cambio.PeriodoIdAct,
            PeriodoIdNew: cambio.PeriodoIdNew
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var datos = response.d;
                var result = datos.toString();
                if (result.split('#')[0] == 'true') {
                    $('#tr' + cambio.PersonalId).css('background-color', '#96E0AB');
                } else {
                    $('#tr' + cambio.PersonalId).css('background-color', '#FA9B88');
                }
                $('#td' + cambio.PersonalId).html(datos.split('#')[1]);
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#td" + cambio.PersonalId).html(XmlHttpError.responseText);
                },
            async: true
        });
    }
}