
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

    $('#ctl00_ContentPlaceHolder1_chktodos').click(function () {
        $('.chksel').prop('checked', this.checked);
    });
    $('#tbodyPersonal').on('click', "input[type='checkbox']", function () {
        if (this.checked) {
            seleccionados.push(this.id);
        } else {
            var pos = seleccionados.indexOf(this.id);
            if (pos > -1) {
                seleccionados.splice(pos, 1);
            }
        }
        $('#ctl00_ContentPlaceHolder1_HHcodigos').val(seleccionados);
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
};
var seleccionados = [];
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
//LISTAR PERSONAL

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
                var html = '<tr>';
                var chec = '';
                if (seleccionados.indexOf(Datos[i].Personal_Id) > -1) {
                    chec = ' checked="checked"'
                }
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
                html += '<td ' + StyleTR + '>' + Datos[i].F_Cese + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Proyecto + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
            }
            if ($('#ctl00_ContentPlaceHolder1_chktodos').prop('checked') == true) {
                $('.chksel').prop('checked', true);
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
