
function Get_UsuarioPersonal(Personal_Id, PersonalFind, inicio) {
    var params = {
        Personal_Id: Personal_Id,
        PersonalFind: PersonalFind,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sChangePass.aspx/Get_UsuarioPersonal",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyUsuario').html('');
            for (var i = 0; i <= lengthd; i++) {
                var estadoper = Datos[i].Estado_Id == '01' ? 'ACTIVO' : 'INACTIVO';
                var estadousu = Datos[i].EstadoUsur == '01' ? 'ACTIVO' : 'INACTIVO';
                var html = '<tr>';
                html += '<td style="width: 5px;"><input type="button" class="buttonEdit" id="' + Datos[i].Personal_Id + '" title="Editar Personal"  /></td>';
                html += '<td>' + Datos[i].Personal + '</td>';
                html += '<td>' + estadoper + '</td>';
                html += '<td>' + Datos[i].Name + '</td>';
                html += '<td>' + Datos[i].Password + '</td>';
                html += '<td>' + estadousu + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyUsuario');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

    var params2 = {
        Personal_Id: Personal_Id,
        PersonalFind: PersonalFind
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params2),
        dataType: "json",
        url: "sChangePass.aspx/Get_UsuarioPersonal_MaxRows",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var MaxRows = response.d;
            $('#txtnRegistros').val(MaxRows);
        },
        error:
        function (XmlHttpError, error, description) {
            $("#divError").html(XmlHttpError.responseText);
        },
        async: false
    });

};






function Get_Personal_Find(Personal_Id) {
    var params = {
        Personal_Id: Personal_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sChangePass.aspx/Get_Personal_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                $('#lblUsuario').html(Proceso.Apellido_Paterno + ' ' + Proceso.Apellido_Materno + ' ' + Proceso.Nombres);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Change_Pass(Personal_Id,NewPass) {
    var params = {
        Personal_Id: Personal_Id,
        NewPass: NewPass
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sChangePass.aspx/Get_Change_Pass",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        setTimeout("location.href='../../Login/Acceso.aspx'", 5);
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



function Get_PersonalFind() {
    return $('#txtPersonalFind').val();
};

function open_Modal() {

    $('#dialog-Change').dialog({
        autoOpen: true,
        modal: true,
        width: 480,
        height: 240,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};
