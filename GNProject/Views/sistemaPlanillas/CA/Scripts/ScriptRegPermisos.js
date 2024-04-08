var personalid = '', fini = '', ffin = '', periodoid = '', SessionUsuarioAcceso='';
var disNew, disGrabar, disCancel, disUpdate, disDelete;

$(document).ready(function () {
    $('#TabContainer').tabs();
    $('#TabContainer').tabs({ disabled: [1] });
    SessionUsuarioAcceso = '<%=ClaseGlobal.getUsuarioLogin()%>';
    disGrabar = window.setInterval(function () { Disable_btnGrabar(true); }, 100);
    disCancel = window.setInterval(function () { Disable_btnCancelar(true); }, 100);
    disUpdate = window.setInterval(function () { Disable_btnActualizar(true); }, 100);
    disDelete = window.setInterval(function () { Disable_btnEliminar(true); }, 100);
    ListarAreas();
    ListarCategoriaAux();
    ListarPersonalPermisos();
    ListarPersonalPermisosFind();
    personalid = $('#cbopersonal').val();
    periodoid =  document.getElementById('periodoSession').value;
    $('#ctl00_ucFiltros1_cboEmpresa').change(function () {
        ListarPersonalPermisosFind();
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#ctl00_ucFiltros1_cboPlanilla').change(function () {
        ListarPersonalPermisosFind();
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#ctl00_ucFiltros1_cboEjercicio').change(function () {
        ListarPersonalPermisosFind();
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#ctl00_ucFiltros1_cboMes').change(function () {
        ListarPersonalPermisosFind();
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#ctl00_ucFiltros1_cboPeriodo').change(function () {
        ListarPersonalPermisosFind();
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#cboPersonal1').change(function () {
        personalid = $('#cboPersonal1').val();
        periodoid = document.getElementById('periodoSession').value;
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });

    $('#cbolocalidad').change(function () {
        ListarPersonalPermisos();
    });
    $('#cbocataux').change(function () {
        ListarPersonalPermisos();
    });
    $('#cboLocalidad1').change(function () {
        ListarPersonalPermisosFind();
    });
    $('#cboArea1').change(function () {
        ListarPersonalPermisosFind();
    });
    $('#cboProyecto1').change(function () {
        ListarPersonalPermisosFind();
    });
    //$('#cbopersonal').change(function () {
    //    personalid = $(this).val();
    //});
    //FECHAS JQUERY
    $("#txtfini").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });
    $("#txtffin").datepicker({
        dateFormat: "dd/mm/yy",
        defaultDate: "+1w",
        //changeMonth: true,
        changeYear: true
    });

    $('#txtfini').change(function () {
        fini = formatFecha.ymd($(this).val());
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    $('#txtffin').change(function () {
        ffin = formatFecha.ymd($(this).val());
        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
    });
    GetFechaPorPeriodo();
    Get_Tipo_Permisos();
    //Eventos
    $('#btnNew').click(function () {
        disNew = window.setInterval(function () { Disable_btnNew(true); }, 100);
        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);

        Disable_btnGrabar(false);
        Disable_btnCancelar(false);
        hPerimisocod = 0;
        clear_NewPermiso();
        $('#btnSubirPF').hide();
        $('#aFilePF').hide();
        personalid = $('#cbopersonal').val();
        $('#TabContainer').tabs('enable');
        $('#TabContainer').tabs({ active: 1 });
    });
    $('#btnCancel').click(function () {

        window.clearInterval(disNew);
        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);
        window.clearInterval(disUpdate);
        window.clearInterval(disDelete);

        Disable_btnNew(false);
        disGrabar = window.setInterval(function () { Disable_btnGrabar(true); }, 100);
        disCancel = window.setInterval(function () { Disable_btnCancelar(true); }, 100);
        disUpdate = window.setInterval(function () { Disable_btnActualizar(true); }, 100);
        disDelete = window.setInterval(function () { Disable_btnEliminar(true); }, 100);
        hPerimisocod = 0;
        $('#TabContainer').tabs({ disabled: [1] });
        $('#TabContainer').tabs({ active: 0 });
        Lista_Personal_x_Filtro_Columna(Get_Compania(), null, Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
    });


    $('#btnUpdate').click(function () {
        if (!hPerimisocod) {
            alert('.::Error, Seleccione un personal');
        } else {
            var Permiso_Id = $('#cboTPermiso').val();
            var Descuento = $("input[type='radio'][name='aplidescuento']:checked").val();
            var FechaIni = $('#txtFechaIni').val();
            var FechaFin = $('#txtFechaFin').val();
            var TipoReg = '03';
            var Motivo = $('#txtMotivo').val();
            var NroDoc = $('#txtNroDoc').val();

            if (!Permiso_Id) {
                alert('.::Error > Tipo de permiso no definido.');
                $('#cboTPermiso').focus();
                return false;
            }
            if (!Descuento) {
                alert('.::Error > Aplica descuento [Si ó NO].');
                return false;
            }
            if (!FechaIni) {
                alert('.::Error > Fecha de inicio no definido.');
                $('#txtFechaIni').focus();
                return false;
            }
            if (!FechaFin) {
                alert('.::Error > Fecha final no definida.');
                $('#txtFechaFin').focus();
                return false;
            }
            if (!Motivo) {
                alert('.::Error > Motivo no definido.');
                $('#txtMotivo').focus();
                return false;
            }
            if (confirm('¿Está seguro(a) de continuar?')) {
                Get_AM_Permisos_Fechas(hPerimisocod, Permiso_Id, personalid, formatFecha.ymd(FechaIni), formatFecha.ymd(FechaFin), Descuento, TipoReg, Motivo.toUpperCase(), NroDoc, personalid, periodoid);
            }
        }

    });
    $('#btnSubirPF').click(function () {
        uploadFile_Permiso(hPerimisocod, $('#cbopersonal').val(), '01');
    });
    $('#btnAdd').click(function () {
        var Permiso_Id = $('#cboTPermiso').val();
        var Descuento = $("input[type='radio'][name='aplidescuento']:checked").val();
        var FechaIni = $('#txtFechaIni').val();
        var FechaFin = $('#txtFechaFin').val();
        var TipoReg = '03';
        var Motivo = $('#txtMotivo').val();
        var NroDoc = $('#txtNroDoc').val();

        if (!Permiso_Id) {
            alert('.::Error > Tipo de permiso no definido.');
            $('#cboTPermiso').focus();
            return false;
        }

        if (!Descuento) {
            alert('.::Error > Aplica descuento [Si ó NO].');
            return false;
        }
        if (!FechaIni) {
            alert('.::Error > Fecha de inicio no definido.');
            $('#txtFechaIni').focus();
            return false;
        }
        if (!FechaFin) {
            alert('.::Error > Fecha final no definida.');
            $('#txtFechaFin').focus();
            return false;
        }
        if (!Motivo) {
            alert('.::Error > Motivo no definido.');
            $('#txtMotivo').focus();
            return false;
        }
        if (confirm('¿Está seguro(a) de continuar?')) {
            Get_AM_Permisos_Fechas(hPerimisocod, Permiso_Id, personalid, formatFecha.ymd(FechaIni), formatFecha.ymd(FechaFin), Descuento, TipoReg, Motivo.toUpperCase(), NroDoc, personalid, periodoid);
        }
    });

    $('#tbodyPermisos').on('click', '.linkEditar', function () {
        Get_Permiso_Fechas_Find(this.id);

        window.clearInterval(disNew);
        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);
        window.clearInterval(disUpdate);
        window.clearInterval(disDelete);

        Disable_btnActualizar(false);
        Disable_btnCancelar(false);

        disNew = window.setInterval(function () {
            Disable_btnNew(true);
        }, 100);

        disGrabar = window.setInterval(function () {
            Disable_btnGrabar(true);
        }, 100);

        disDelete = window.setInterval(function () {
            Disable_btnEliminar(true);
        }, 100);
        $('#btnSubirPF').show();
        $('#aFilePF').show();
    });
    $('#tbodyPermisos').on('click', '.linkEliminar', function () {
        if (confirm('¿Esta seguro de cancelar la solicitud ?')) {
            Get_Cancelar_SolicitudPermisoDias(this.id, personalid, periodoid, personalid);
        }
    });
    CrearFechas();
    Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);


});

function ListarAreas() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaArea';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;

            $('#cbolocalidad').html('');
            $('<option value="">Todos</option>').appendTo('#cbolocalidad');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cbolocalidad');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListarCategoriaAux() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListaCatAuxiliar';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;

            $('#cbocataux').html('');
            $('<option value="">Todos</option>').appendTo('#cbocataux');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cbocataux');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function ListarPersonalPermisos() {
    var periodo = document.getElementById('periodoSession').value;
    var params = {
        xperiodo: periodo,
        xlocalidad: '',
        xcategoria: '',
        xproyecto: ''
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarPersonalPermisosPlanilla';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;

            $('#cbopersonal').html('');
            //$('<option value="">Todos</option>').appendTo('#cbopersonal');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cbopersonal');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}
function ListarPersonalPermisosFind() {
    var periodo = document.getElementById('periodoSession').value;
    var params = {
        xperiodo: periodo,
        xlocalidad: $('#cboLocalidad1').val(),
        xcategoria: $('#cboArea1').val(),
        xproyecto: $('#cboProyecto1').val()
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ListarPersonalPermisosPlanilla';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;

            $('#cboPersonal1').html('');
            $('<option value="">Todos</option>').appendTo('#cboPersonal1');
            for (var i = 0; i <= lengthD; i++) {
                var html = '<option value="' + datos[i][0] + '">' + datos[i][1] + '</option>';
                $(html).appendTo('#cboPersonal1');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
}

function GetFechaPorPeriodo() {
    var periodo = document.getElementById('periodoSession').value;
    var params = {
        xperiodo: periodo
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/GetFechaPorPeriodo';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            var lengthD = datos.length - 1;
            if (lengthD >= 0) {
                $('#txtfini').datepicker('setDate', datos[0][0]);
                $('#txtffin').datepicker('setDate', datos[0][1]);
                fini = formatFecha.ymd(datos[0][0]), ffin = formatFecha.ymd(datos[0][1]);
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}

function Get_Permisos_Fecha_By_Personal(Personal_Id, FechaIni, FechaFin, PeriodoId) {
    var params = {
        Planilla_Id: document.getElementById('planillaSession').value,
        Personal_Id: Personal_Id,
        FechaIni: FechaIni,
        FechaFin: FechaFin,
        PeriodoId: PeriodoId,
        LocalidadId: $('#cboLocalidad1').val(),
        AreaId: $('#cboArea1').val(),
        ProyectoId: $('#cboProyecto1').val()
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Permisos_Fecha_By_Personal';
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#tbodyPermisos').html('');
            for (var i = 0; i <= lengthD; i++) {

                var estado = '';
                switch (Data[i].Estado) {
                    case '06': estado = 'CANCELADO'; break;
                    case '05': estado = 'PENDIENTE'; break;
                    case '04': estado = 'DESAPROBADO JEFE'; break;
                    case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;
                    case '02': estado = 'DESAPROBADO RRHH'; break;
                    case '01': estado = 'APROBADO RRHH'; break;
                }

                var fechin = Data[i][5].toDateFormat();
                var fechfin = Data[i][6].toDateFormat();
                var fecupda = Data[i][10];
                if (fecupda) {
                    fecupda = formatFecha.ymd(fecupda.toDateFormat());
                } else {
                    fecupda = '';
                }
                var Realiza = '';
                switch (Data[i][3]) {
                    case '01': Realiza = 'PERSONAL'; break;
                    case '02': Realiza = 'JEFE'; break;
                    case '03': Realiza = 'RRHH'; break;
                }

                var AproJefe = '';
                switch (Data[i][8]) {
                    case '00': AproJefe = 'PENDIENTE'; break;
                    case '01': AproJefe = 'APROBADO'; break;
                    case '02': AproJefe = 'DESAPROBADO'; break;
                }
                var AproRRHH = '';
                switch (Data[i][9]) {
                    case '00': AproRRHH = 'PENDIENTE'; break;
                    case '01': AproRRHH = 'APROBADO'; break;
                    case '02': AproRRHH = 'DESAPROBADO'; break;
                }

                var Descuento = '';
                switch (Data[i][2]) {
                    case '01': Descuento = 'SI'; break;
                    case '02': Realiza = 'NO'; break;
                }


                var btnEdit = '<input type="button" class="linkEditar" id="' + Data[i][0] + '" title="Editar Permiso" />';
                var btnCancel = '<input type="button" class="linkEliminar" id="' + Data[i][0] + '" title="Cancelar Permiso" />';

                /*switch (Data[i][4]) {
                    case '06': btnCancel = ''; break;
                    //case '05': estado = 'PENDIENTE'; break;        
                    //case '04': estado = 'DESAPROBADO JEFE'; break;        
                    //case '03': estado = 'APROBADO JEFE - PENDIENTE RRHH'; break;        
                    //case '02': estado = 'DESAPROBADO RRHH'; break;        
                    case '01': btnEdit = ''; btnCancel = ''; break;
                }*/
                var valor = '', concep = '', dias = 0;
                dias = Data[i][12];
                if (Data[i][11] == '1') {
                    //DM
                    concep = 'V_DIAS_DESCANSO_MEDICO_CON_GOCE';
                    valor = Data[i][13];
                } else if (Data[i][11] == '2') {
                    concep = 'V_DIAS_SUBSIDIO';
                    valor = Data[i][14];
                } else { 
                }


                var html = '<tr>';
                html += '<td style="text-align:center;">' + btnEdit + '</td>';
                html += '<td style="text-align:center;">' + btnCancel + '</td>';
                html += '<td>' + Data[i][15] + '</td>';
                html += '<td>' + Data[i][16] + '</td>';
                html += '<td>' + Data[i][1] + '</td>';
                html += '<td>' + Realiza + '</td>';
                html += '<td>' + estado + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.dmy(fechin) + '</td>';
                html += '<td style="text-align:center;">' + formatFecha.dmy(fechfin) + '</td>';
                html += '<td style="text-align:center;">' + Descuento + '</td>';
                html += '<td style="text-align:center;">' + Data[i][7] + '</td>';
                html += '<td style="text-align:center;">' + dias + '</td>';
                html += '<td style="text-align:center;">' + Data[i][13] + '</td>';
                html += '<td style="text-align:center;">' + Data[i][14]  + '</td>';
                html += '<td style="text-align:center;">' + fecupda + '</td>';
                html += '<td style="text-align:center;"><a href="' + Data[i][17] + '" target="_blank">VER</a></td>';
                
                html += '</tr>';
                $(html).appendTo('#tbodyPermisos');
            }
        },
        error:
               function (XmlHttpError, error, description) {
                   $('#dialog-form').html(XmlHttpError.responseText);
               },
        async: true
    });
};

function Get_Tipo_Permisos() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Tipo_Permisos';
    $.ajax({
        type: "POST",
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthD = Data.length - 1;
            $('#cboTPermiso').html('');
            //$('#cboPermisoH').html('');

            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Data[i][0] + '">' + Data[i][1] + '</option>').appendTo('#cboTPermiso');
                /*if (Data[i].Permiso_Id == "7") {
                    $('<option value="' + Data[i].Permiso_Id + '">' + Data[i].descripcion + '</option>').appendTo('#cboPermisoH');
                }*/
            }
        },
        error:
   function (XmlHttpError, error, description) {
       $('#dialog-form').html(XmlHttpError.responseText);
   },
        async: false
    });

};

var formatFecha = {
    ymd: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = fecha.split('/');
                return arr[2] + '/' + arr[1] + '/' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    },
    dmy: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1.split('/');
                return arr[0] + '/' + arr[1] + '/' + arr[2];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1.split('-');
                return arr[0] + '-' + arr[1] + '-' + arr[2];
            }
        }
    },
    ymdEN: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = arr1[0].split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = arr1[0].split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }

        } else {
            var arr = [];
            if (fecha.indexOf('/') != -1) {
                arr = fecha.split('/');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            } else if (fecha.indexOf('-') != -1) {
                arr = fecha.split('-');
                return arr[2] + '-' + arr[1] + '-' + arr[0];
            }
        }

    }

};

//DISABLE BOTONES

function Disable_btnNew(ope) {
    document.getElementById('btnNew').disabled = ope;
}
function Disable_btnGrabar(ope) {
    document.getElementById('btnAdd').disabled = ope;
}
function Disable_btnCancelar(ope) {
    document.getElementById('btnCancel').disabled = ope;
}
function Disable_btnActualizar(ope) {
    document.getElementById('btnUpdate').disabled = ope;
}
function Disable_btnEliminar(ope) {
    document.getElementById('btnDelete').disabled = ope;
}

function CrearFechas() {
    $('#txtFechaIni').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false,
        /*minDate: -0,*/
        onClose: function (selectedDate) {
            $("#txtFechaFin").datepicker("option", "minDate", selectedDate);
        }
    });
    $('#txtFechaFin').datepicker({
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
        dateFormat: 'dd/mm/yy',
        isRTL: false,
        /*minDate: -0,*/
        onClose: function (selectedDate) {
            $("#txtFechaIni").datepicker("option", "maxDate", selectedDate);
        }
    });
};


function clear_NewPermiso() {
    $('#cboTPermiso').val('');
    /*  $('#rdSI').prop('checked', false);
    $('#rdNo').prop('checked', false);*/
    $("input[type='radio'][name='aplidescuento']").prop('checked', false);
    $('#txtFechaIni').val('');
    $('#txtFechaFin').val('');
    $('#txtNroDoc').val('');
    $('#txtMotivo').val('');


    $('#lblEJefe').html('');
    $('#txtComentJefe').val('');
    $('#lblERRHH').html('');
    $('#txtComentRRHH').val('');
    $('#tdDetalleVac').html('');
};

function uploadFile_Permiso(Permiso_Id, Personal_Id, Tipo) {
    if (Tipo == '01') {

        var archivosF = document.getElementById("filePFecha");
        var archivoF = archivosF.files;

        for (var i = 0; i < archivoF.length; i = i + 2) {

            var xhr = new XMLHttpRequest();
            var fd = new FormData();

            fd.append('file', archivoF[i]);
            fd.append('permi', Permiso_Id);
            fd.append('perso', Personal_Id);
            fd.append('tipo', Tipo);

            xhr.open('POST', 'AjaxUploadFilePermiso.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc != '0') {
                        $('#aFilePF').prop('href', rsc);
                        alert('Archivo Guardado correctamente.');
                    } else {
                        alert(this.responseText);
                    }
                } else {
                    alert(this.responseText);
                }
            };

            xhr.onreadystatechange = function (oEvent) {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {

                    } else {
                        alert("Error : " + xhr.statusText);
                    }
                }
            };

            xhr.send(fd);

        }

        document.getElementById("filePFecha").value = null;

    } else if (Tipo == '02') {
        var archivosH = document.getElementById("filePHora");
        var archivoH = archivosH.files;

        for (var i = 0; i < archivoH.length; i = i + 2) {
            var xhr = new XMLHttpRequest();
            var fd = new FormData();
            fd.append('file', archivoH[i]);
            fd.append('permi', Permiso_Id);
            fd.append('perso', Personal_Id);
            fd.append('tipo', Tipo);

            xhr.open('POST', 'AjaxUploadFilePermiso.ashx/ProcessRequest', false);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText;
                    if (rsc != '0') {
                        $('#aFilePH').prop('href', rsc);
                        alert('Archivo Guardado correctamente.');
                    } else {
                        alert(this.responseText);
                    }
                } else {
                    alert(this.responseText);
                }
            };
            xhr.onreadystatechange = function (oEvent) {
                if (xhr.readyState === 4) {
                    if (xhr.status === 200) {

                    } else {
                        alert("Error : " + xhr.statusText);
                    }
                }
            };
            xhr.send(fd);
        }
        document.getElementById("filePHora").value = null;
    }
}


function Get_AM_Permisos_Fechas(PermisoD_Id, TPermiso_Id, Personal_ID, FechaIni, FechaFin, Descuento, TipoReg, Motivo, NroDoc, PersoModif, PeriodoId) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        TPermiso_Id: TPermiso_Id,
        Personal_ID: Personal_ID,
        FechaIni: FechaIni,
        FechaFin: FechaFin,
        Descuento: Descuento,
        TipoReg: TipoReg,
        Motivo: Motivo,
        NroDoc: NroDoc,
        PersoModif: PersoModif,
        PeriodoId: PeriodoId
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_AM_Permisos_Fechas';
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);
                        clear_NewPermiso();
                        var perId = Proceso.split('#')[2];
                        uploadFile_Permiso(perId, personalid, '01');
                        PermisoD_Proc = 0;
                        $('#btnSubirPF').hide();
                        $('#aFilePF').hide();

                        window.clearInterval(disNew);
                        window.clearInterval(disGrabar);
                        window.clearInterval(disCancel);
                        window.clearInterval(disUpdate);
                        window.clearInterval(disDelete);

                        Disable_btnNew(false);
                        disGrabar = window.setInterval(function () { Disable_btnGrabar(true); }, 100);
                        disCancel = window.setInterval(function () { Disable_btnCancelar(true); }, 100);
                        disUpdate = window.setInterval(function () { Disable_btnActualizar(true); }, 100);
                        disDelete = window.setInterval(function () { Disable_btnEliminar(true); }, 100);

                        $('#TabContainer').tabs({ disabled: [1] });
                        $('#TabContainer').tabs({ active: 0 });
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });



};


function Get_Permiso_Fechas_Find(PermisoD_Id) {
    var params = {
        PermisoD_Id: PermisoD_Id
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Permiso_Fechas_Find';
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso.length == 1) {
                hPerimisocod = PermisoD_Id;
                $('#cbopersonal').val(Proceso[0][3]);
                $('#cboTPermiso').val(Proceso[0][2]);
                if (Proceso[0][6] == '01') {
                    $('#rdSI').prop('checked', true);
                    $('#rdNo').prop('checked', false);
                } else {
                    $('#rdSI').prop('checked', false);
                    $('#rdNo').prop('checked', true);
                }
                $('#txtFechaIni').val(formatFecha.dmy(Proceso[0][4].toDateFormat()));
                $('#txtFechaFin').val(formatFecha.dmy(Proceso[0][5].toDateFormat()));
                $('#txtNroDoc').val(Proceso[0][9]);
                $('#txtMotivo').val(Proceso[0][8]);

                if (Proceso[0][10] == '01') {
                    $('#lblEJefe').html('SI');
                } else {
                    $('#lblEJefe').html('NO');
                }
                $('#txtComentJefe').val(Proceso[0][11]);

                if (Proceso[0][12] == '01') {
                    $('#lblERRHH').html('SI');
                } else {
                    $('#lblERRHH').html('NO');
                }
                $('#txtComentRRHH').val(Proceso[0][13]);

                $('#TabContainer').tabs('enable');
                $('#TabContainer').tabs({ active: 1 });


                if (Proceso[0][2] == '6') {
                    $('#tdDetalleVac').html('<label>Ver Detalle Vacaciones : </label><input type="button" class="buttonDetalle" id="btnDetalleVac" />');
                } else {
                    $('#tdDetalleVac').html('');
                }

                $('#aFilePF').prop('href', Proceso[0][19]);

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Cancelar_SolicitudPermisoDias(PermisoD_Id, PersoModif, PeriodoId, Personal_ID) {
    var params = {
        PermisoD_Id: PermisoD_Id,
        PersoModif: PersoModif,
        PeriodoId: PeriodoId,
        Personal_ID: Personal_ID
    };
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Get_Cancelar_SolicitudPermisoDias';
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        Get_Permisos_Fecha_By_Personal(personalid, fini, ffin, periodoid);

                        clear_NewPermiso();
                        hPerimisocod = 0;

                        window.clearInterval(disNew);
                        window.clearInterval(disGrabar);
                        window.clearInterval(disCancel);
                        window.clearInterval(disUpdate);
                        window.clearInterval(disDelete);

                        Disable_btnNew(false);
                        disGrabar = window.setInterval(function () { Disable_btnGrabar(true); }, 100);
                        disCancel = window.setInterval(function () { Disable_btnCancelar(true); }, 100);
                        disUpdate = window.setInterval(function () { Disable_btnActualizar(true); }, 100);
                        disDelete = window.setInterval(function () { Disable_btnEliminar(true); }, 100);
                        hPerimisocod = 0;
                        $('#TabContainer').tabs({ disabled: [1] });
                        $('#TabContainer').tabs({ active: 0 });

                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#dialog-form").html(XmlHttpError.responseText);
                },
        async: false
    });
};

String.prototype.toDateFormat = function () {
    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};


function dateDemo(fecha) {
    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);
    var fechaWPP = Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Min;
    return fechaWPP;
};



String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
};