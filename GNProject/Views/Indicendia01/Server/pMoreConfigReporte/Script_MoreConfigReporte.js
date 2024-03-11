function Get_Causas_Incidentes_List(Name, Tipo, Estado, inicio) {
    var params = {
        Name: Name,
        Tipo: Tipo,
        Estado: Estado,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causas_Incidentes_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyCausas').html('');
            for (var i = 0; i <= lengthD; i++) {
                var EstadoId = Datos[i].Estado;
                var tipo = Datos[i].Tipo == '01' ? 'CAUSAS BÁSICAS' : 'CAUSAS INMEDIATAS';
                var estado = EstadoId == '01' ? 'ACTIVO' : 'INACTIVO';
                var btitle = EstadoId == '01' ? 'Desactivar Causa' : 'Activar Causa';
                var bclass = EstadoId == '01' ? 'buttonDesactiva' : 'buttonActiva';
                var html = '<tr>';
                html += '<td style="width:10px;"><input type="button" class="buttonEdit" id="e' + Datos[i].Causa_Id + '" title="Editar Causa"  /></td>';
                html += '<td style="width:10px;"><input type="button" class="' + bclass + '"  id="d' + Datos[i].Causa_Id + '" title="' + btitle + '" /></td>';
                html += '<td style="width:40%;">' + Datos[i].Causa_Name + '</td>';
                html += '<td style="width:15%;">' + tipo + '</td>';
                html += '<td style="width:40%;">' + Datos[i].Descripcion + '</td>';
                html += '<td style="width:5%;">' + estado + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyCausas');
            }
            Get_Causas_Incidentes_MaxRows(Name, Tipo, Estado);
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });
};


function Get_Causas_Incidentes_MaxRows(Name, Tipo, Estado) {
    var params = {
        Name: Name,
        Tipo: Tipo,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causas_Incidentes_MaxRows",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var MaxRows = response.d;
            $('#txtnRegistros').val(MaxRows);
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });
};


function Get_Causas_Add(Causa_Name, Descripcion, Tipo, Estado) {
    var params = {
        Causa_Name: Causa_Name,
        Descripcion: Descripcion,
        Tipo: Tipo,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causas_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        TIPOPROCESO = '01';
                        CausaProc_Id = '';
                        Get_Causas_Incidentes_List(get_CausaFind(),get_TipoCFind(), get_EstadoCFind(), inicio);
                        $('#dialog-Causa').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Causas_Update(Causa_Id, Causa_Name, Descripcion, Tipo, Estado) {
    var params = {
        Causa_Id: Causa_Id,
        Causa_Name: Causa_Name,
        Descripcion: Descripcion,
        Tipo: Tipo,
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causas_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        TIPOPROCESO = '01';
                        CausaProc_Id = '';
                        Get_Causas_Incidentes_List(get_CausaFind(),get_TipoCFind(), get_EstadoCFind(), inicio);
                        $('#dialog-Causa').dialog('close');
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Causas_Delete(Causa_Id, Estado){
    var params = {
        Causa_Id: Causa_Id,       
        Estado: Estado
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causas_Delete",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        TIPOPROCESO = '01';
                        CausaProc_Id = '';
                        Get_Causas_Incidentes_List(get_CausaFind(),get_TipoCFind(), get_EstadoCFind(), inicio);
                    } else {
                        alert(mensaje);
                    }
                }
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Causa_Find(Causa_Id) {
    var params = {
        Causa_Id: Causa_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Causa_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var CausaObj = response.d;
            if (CausaObj) {
                $('#txtCodigo').val(CausaObj.Causa_Id);
                $('#txtCausaNombre').val(CausaObj.Causa_Name);
                $('#txtDescripcionC').val(CausaObj.Descripcion);
                $('#cboTipoC').val(CausaObj.Tipo);
                $('#cboEstadoC').val(CausaObj.Estado);
                TIPOPROCESO = '02';
                CausaProc_Id = Causa_Id;
                open_Modal_Causa();              
            } else {
                alert('.::Error > Causa seleccionada no encontrada.');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};



//OTROS

function get_CausaFind() {
    return $('#txtCausasFind').val();
}

function get_EstadoCFind() {
    return $('#cboEstadoCFind').val();
}
function get_TipoCFind() {
    return $('#cboTipoCFind').val();
}


function clear_ModalCausa() {
    $('#txtCodigo').val('????');
    $('#txtCausaNombre').val('');
    $('#txtDescripcionC').val('');
    $('#cboTipoC').val('01');
    $('#cboEstadoC').val('01');
    $('#lblErrorC').html('&nbsp;');

}

function open_Modal_Causa() {
    $('#dialog-Causa').dialog({
        autoOpen: true,
        modal: true,
        width: 450,
        height: 290,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });
};
