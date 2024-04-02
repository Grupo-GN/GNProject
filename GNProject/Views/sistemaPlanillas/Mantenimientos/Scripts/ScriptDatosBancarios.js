function fc_FillComboArray(idCombo, Datos, textInicial) {
    var lengthD = Datos.length - 1;
    $("#" + idCombo).html("");
    if (textInicial != "") {
        $('<option value="">' + textInicial + '</option>').appendTo("#" + idCombo);
    }
    for (var i = 0; i <= lengthD; i++) {
        var html = '<option value="' + Datos[i][0] + '">' + Datos[i][1] + '</option>';
        $(html).appendTo("#" + idCombo);
    }
}
function Lista_Personal_DatosBancarios(inicio) {
    Lista_SelectsMantDatosBancarios();
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_Personal_DatosBancarios';
    var Periodo_Id = $('#ctl00_ucFiltros1_cboPeriodo').val(), NPersonal = $('#txtBuscar').val()
        , Localidad = $('#cboLocalidad').val(), Proyecto = $('#cboProyecto').val(), Area = $('#cboArea').val();
    var params = {
        Periodo_Id: Periodo_Id,
        NPersonal: NPersonal,
        Localidad: Localidad,
        Proyecto: Proyecto,
        Area: Area,
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
            tabla = [];
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
                html += '<td ' + StyleTR + '>' + Datos[i].NPersonal + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].TDocumento + '</td>';
                html += '<td ' + StyleTR + '>' + Datos[i].Nro_Doc + '</td>';
                html += '<td id="td1' + Datos[i].Personal_Id + '" ' + StyleTR + '></td>';
                html += '<td id="td2' + Datos[i].Personal_Id + '" ' + StyleTR + '></td>';
                html += '<td id="td3' + Datos[i].Personal_Id + '" ' + StyleTR + '></td>';
                html += '<td ' + StyleTR + '><input type="text" class="ddl" id="txt1' + Datos[i].Personal_Id+'" value="' + Datos[i].Nro_cta + '" /></td>';
                html += '<td ' + StyleTR + '><input type="text" class="ddl" id="txt2' + Datos[i].Personal_Id +'" value="' + Datos[i].Nro_Cta_Inter + '" /></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyPersonal');
                tabla.push(Datos[i].Personal_Id);
                $(MostrarCombo('TC', Datos[i].Personal_Id, Datos[i].TipoCta)).appendTo('#td1' + Datos[i].Personal_Id);
                $(MostrarCombo('BA', Datos[i].Personal_Id, Datos[i].BancoCta)).appendTo('#td2' + Datos[i].Personal_Id);
                $(MostrarCombo('TM', Datos[i].Personal_Id, Datos[i].TipoMoneda)).appendTo('#td3' + Datos[i].Personal_Id);

            }
            //Lista_Personal_x_Filtro_Columna_MaxRows(Compania_Id, Periodo_Id, NomColumna, Param); //@001 I/F
            $('#txtnRegistros').val(qt_registros); //@001 I/F
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: true
    });

}

var TipoCta = [];
var Bancos = [];
var Moneda = [];
function Lista_SelectsMantDatosBancarios() {
    TipoCta = [];
    Bancos = [];
    Moneda = [];
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/Lista_SelectsMantDatosBancarios';
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            //var Datos = response.d;
            var objResponse = response.d;
            var Datos = objResponse.oBandeja; //@001 I/F
            var qt_registros = objResponse.qt_registros; //@001 I/F
            for (var i = 0; i <= Datos.length - 1; i++) {
                if (Datos[i].TDocumento == 'TC') {
                    TipoCta.push({ id: Datos[i].Personal_Id, valor: Datos[i].Nro_Doc });
                }
                if (Datos[i].TDocumento == 'BA') {
                    Bancos.push({ id: Datos[i].Personal_Id, valor: Datos[i].Nro_Doc });
                }
                if (Datos[i].TDocumento == 'TM') {
                    Moneda.push({ id: Datos[i].Personal_Id, valor: Datos[i].Nro_Doc });
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

function MostrarCombo(tipo,id, value) {
    var combo = '';
    if (tipo == 'TC') {
        combo = '<select class="ddl" style="width: 100px;" id="cboTC' + id + '">';
        for (var t = 0; t <= TipoCta.length - 1; t++) {
            var s = '';
            if (TipoCta[t].id == value) {
                s = 'selected';
            }
            combo += '<option value="' + TipoCta[t].id + '" ' + s + '>' + TipoCta[t].valor + '</option>';
        }
        combo += '</select>';
    }
    if (tipo == 'BA') {
        combo = '<select class="ddl" style="width: 150px;" id="cboBA' + id + '">';
        for (var t = 0; t <= Bancos.length - 1; t++) {
            var s = '';
            if (Bancos[t].id == value) {
                s = 'selected';
            }
            combo += '<option value="' + Bancos[t].id + '" ' + s + '>' + Bancos[t].valor + '</option>';
        }
        combo += '</select>';
    }
    if (tipo == 'TM') {
        combo = '<select class="ddl"" style="width: 110px;" id="cboTM' + id + '">';
        for (var t = 0; t <= Moneda.length - 1; t++) {
            var s = '';
            if (Moneda[t].id == value) {
                s = 'selected';
            }
            combo += '<option value="' + Moneda[t].id + '" ' + s + '>' + Moneda[t].valor + '</option>';
        }
        combo += '</select>';
    }
    return combo;
}
var tabla = [];
function Guardar() {
    var alerta = '';
    var irows = 0;
    for (var i = 0; i <= tabla.length - 1; i++) {
        var pagePath = window.location.pathname;
        var urlajax = pagePath + '/GuardarDatosBancarios';
        var PersonalId = tabla[i];
        var params = {
            PersonalId: PersonalId,
            TipoCta: $('#cboTC' + PersonalId).val(),
            Banco: $('#cboBA' + PersonalId).val(),
            Moneda: $('#cboTM' + PersonalId).val(),
            NroCta: $('#txt1' + PersonalId).val(),
            NroCtaInter: $('#txt2' + PersonalId).val()
        };
        $.ajax({
            type: "POST",
            url: urlajax,
            contentType: "application/json; chartseft:utf-8",
            data: JSON.stringify(params),
            dataType: "json",
            success: function (response) {
                var objResponse = response.d;
                if (objResponse.split('#')[0] == 'false') {
                    alerta += objResponse.split('#')[1] + '\n';
                } else {
                    irows += 1;
                }
            },
            error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
            async: false
        });
    }
    var alertatotal = irows.toString() + ' registro(s) actualizado(s).';
    if (alerta != '') {
        alertatotal += '\n' + alerta;
    }
    alert(alertatotal);
}