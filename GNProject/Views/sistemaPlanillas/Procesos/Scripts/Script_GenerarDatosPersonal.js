// FILTRO CABECERA

function Get_Compania() {
    var cboCompa = document.getElementById('ctl00_ucFiltros1_cboEmpresa');
    return cboCompa.value;
}

function Get_Periodo() {
    var cbo = document.getElementById('ctl00_ucFiltros1_cboPeriodo');
    return cbo.value;
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
                html += '<td><input id="' + Datos[i].Personal_Id + '" type="checkbox" class="chksel" ' + chec + ' /></td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Personal_Id + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Paterno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Materno + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nombres + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].TDocumento + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_Doc + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ingreso + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Ini_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Fin_Contrato + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].F_Cese + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Proyecto + '</td>';
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


var inicio = 0;
var TotalPaginador = 12;
var TOTALREGISTROS;
var PAGINAACTUAL = 1;

function initilize() {
    ListaColumnPersonal();
    Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);

    //NAVEGACION

    $('#btnUltimo').click(function () {  //metodos para actualizar

        var guardaPagina = parseInt($('#txtnRegistros').val());
        var laPaginaActual = guardaPagina / TotalPaginador;

        if (guardaPagina > 0 && guardaPagina < 10) {        //Hago un if para saber la ultima pagina
            inicio = 0;
            laPaginaActual = 1;                             //comparando el numero de pagina
        } else if (guardaPagina > 9 && guardaPagina < 100) {    //a division con el total de pagina
            inicio = (parseInt(guardaPagina.toString().substring(0, 1))) + "2";
        } else if (guardaPagina > 99 && guardaPagina < 1000) {
            inicio = guardaPagina.toString().substring(0, 2) + "2";
        } else if (guardaPagina > 999 && guardaPagina < 10000) {
            inicio = guardaPagina.toString().substring(0, 3) + "2";
        } else if (guardaPagina > 9999 && guardaPagina < 100000) {
            inicio = guardaPagina.toString().substring(0, 4) + "2";
        }

        if (inicio > guardaPagina)
            inicio = guardaPagina;

        if (guardaPagina == inicio) {
            inicio = inicio - TotalPaginador;
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            setPaginaActual(PAGINAACTUAL);

        } else if (guardaPagina != TotalPaginador) {
            PAGINAACTUAL = Math.ceil(laPaginaActual);
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            setPaginaActual(PAGINAACTUAL);
        } else {
            inicio = 0;
        }

    });

    $('#btnPrimero').click(function () {  //metodos para actualizar
        inicio = 0;         //Primer Registro
        PAGINAACTUAL = 1;   //Primera Pagina
        Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        setPaginaActual(PAGINAACTUAL);
    });

    $('#btnAnterior').click(function () {  //metodos para actualizar
        if (inicio > 0) {
            inicio = parseInt(inicio) - TotalPaginador;
            PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            setPaginaActual(PAGINAACTUAL);
        }

    });
    $('#btnSiguiente').click(function () {  //metodos para actualizar

        if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
            inicio = parseInt(inicio) + parseInt(TotalPaginador);
            PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            setPaginaActual(PAGINAACTUAL);
        }

    });

    function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
        $('#txtPaginaActual').val(nPagina);
    }


    $('#tbodyPersonal').on('click', "input[type='checkbox']", function () {
        if (this.checked) {
            seleccionados.push(this.id);
        } else {
            var pos = seleccionados.indexOf(this.id);
            if (pos > -1) {
                seleccionados.splice(pos, 1);
            }
        }
    });
    $('#cboBusquedaEn').change(function () {
        inicio = 0;
        Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
    });
    $('#txtBuscar').keyup(function () {
        if ($('#cboBusquedaEn').val() != 'Todos') {
            inicio = 0;
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        }
    });

    //======
    $('#btnProcesar').click(function () {
        //GenerarDatosPersonal();
        var msgValid = "";
        if ($('#chkTodos').prop('checked') == false && seleccionados.length <= 0) {
            alert("Debe seleccionar al menos un registro.");
            return;
        }

        var cadenacod = "";
        if (confirm("Está seguro de generar los conceptos?")) {
            if ($('#chkTodos').prop('checked') == true) {
                cadenacod = "all";
            }
            else {
                for (var i = 0; i <= seleccionados.length - 1; i++) {
                    cadenacod += seleccionados[i] + "|";
                }
                cadenacod = cadenacod.substring(0, cadenacod.length - 1);
            }
            GenerarDatos(Get_Periodo(), cadenacod);
        }
    });
    /*
    $('#btnVer').click(function () {
        $("#divresultado").dialog({
            title: 'Resultados del Proceso',
            minWidth: 900,
            minHeight: 500,
            maxHeight: 650
        });
    });
    */
};
var seleccionados = [];
/*
function GenerarDatosPersonal() {
    $("#divresultado").dialog({
        title: 'Resultados del Proceso',
        minWidth: 900,
        minHeight: 500,
        maxHeight: 650
    });

    var cadenacod = "";
    if ($('#chkTodos').prop('checked') == true) {
        cadenacod = "all";
    } else {
        for (var i = 0; i <= seleccionados.length - 1; i++) {
            cadenacod += seleccionados[i] + ",";
        }
        cadenacod = cadenacod.substring(0, cadenacod.length - 1);
    }
    Lista_Personal_x_GenerarDatos(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), cadenacod);

    var c = seleccionados.length / 50;
    if (c <= 1) {
        var cadenacod = '';
        for (var i = 0; i <= seleccionados.length - 1; i++) {
            cadenacod += seleccionados[i] + ",";
        }
        cadenacod = cadenacod.substring(0, cadenacod.length - 1);
        GenerarDatos(Get_Periodo(), cadenacod);
    } else {
        var x = c;
        var decimals = x - Math.floor(x);
        var to = Math.round(c);
        to += decimals < 5 ? 1 : 0;
        var index = 0;
        for (var i = 1; i <= to; i++) {            
            var top = (i * 50);            
            var cadenacod = '';
            top = top >= seleccionados.length ? seleccionados.length : top;
            var acu = 0;
            for (var n = index; n <= top - 1; n++) {
                cadenacod += seleccionados[n] + ",";
                acu++;
            }
            index += acu;
            cadenacod = cadenacod.substring(0, cadenacod.length - 1);
            GenerarDatos(Get_Periodo(), cadenacod);
        }
    }
}

function Lista_Personal_x_GenerarDatos(Compania_Id, Periodo_Id, NomColumna, Param, PersonalId) {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_x_GenerarDatos';

    var params = {
        Compania_Id: Compania_Id,
        Periodo_Id: Periodo_Id,
        NomColumna: NomColumna,
        Param: Param,
        PersonalId: PersonalId
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            seleccionados = [];
            $('#tbodyproceso').html('');
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
                var html = '<tr>';
                html += '<td ' + StyleTR + '>' + Datos[i].Personal_Id + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Apellido_Paterno + ' ' + Datos[i].Apellido_Materno + ', ' + Datos[i].Nombres + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].TDocumento + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_Doc + '</td>';
                html += '<td id="F' + Datos[i].Personal_Id + '" ></td>';
                html += '<td id="V' + Datos[i].Personal_Id + '" ></td>';
                html += '<td id="D' + Datos[i].Personal_Id + '" ></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyproceso');
                seleccionados.push(Datos[i].Personal_Id);
            }
            Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param);
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}
*/

function GenerarDatos(PeriodoId, PersonalIds) {
    var flGenDFijos = $("#chkGDFijos").prop("checked");
    var flGenDVariables = $("#chkGDVariables").prop("checked");
    var flGenDDirectos = $("#chkGDDirectos").prop("checked");
    var flGenAcumulativos = $("#chkGAcumulativos").prop("checked");

    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/generaDatos';
    var params = {
        Periodo_Id: PeriodoId,
        Personal_Ids: PersonalIds,
        flGenDFijos: flGenDFijos,
        flGenDVariables: flGenDVariables,
        flGenDDirectos: flGenDDirectos,
        flGenAcumulativos: flGenAcumulativos
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var res = response.d;
            alert(res);
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });
    /*
    if ($('#chkGDFijos').prop('checked') == true) {
        var urlajax = pagePath + '/Inserta_D_Fijos_Genera';
        var params = {
            Periodo_Id: PeriodoId,
            Personal_Id: PersonalId
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var resultado = response.d;
                for (var r = 0; r <= resultado.length - 1; r++) {
                    var partes = [];
                    partes = resultado[r].split('#');
                    //console.log('#F' + partes[1]);
                    if (partes[0] == 'true') {
                        $('#F' + partes[1]).html(partes[2]);
                    } else {
                        $('#F' + partes[1]).css({ "color": "Red", "font-weight": "bold" });
                        $('#F' + partes[1]).html(partes[2]);
                    }
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });
    }
    //Variables
    if ($('#chkGDVariables').prop('checked') == true) {
        var urlajax = pagePath + '/Inserta_D_Variables_Genera';
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var resultado = response.d;
                for (var r = 0; r <= resultado.length - 1; r++) {
                    var partes = [];
                    partes = resultado[r].split('#');
                    if (partes[0] == 'true') {
                        $('#V' + partes[1]).html(partes[2]);
                    } else {
                        $('#V' + partes[1]).css({ "color": "Red", "font-weight": "bold" });
                        $('#V' + partes[1]).html(partes[2]);
                    }
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });
    }
    //Directos
    if ($('#chkGDDirectos').prop('checked') == true) {
        var urlajax = pagePath + '/Inserta_D_Directos_Genera';
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var resultado = response.d;
                for (var r = 0; r <= resultado.length - 1; r++) {
                    var partes = [];
                    partes = resultado[r].split('#');
                    if (partes[0] == 'true') {
                        $('#D' + partes[1]).html(partes[2]);
                    } else {
                        $('#D' + partes[1]).css({ "color": "Red", "font-weight": "bold" });
                        $('#D' + partes[1]).html(partes[2]);
                    }
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: true
        });
    }
    */
}