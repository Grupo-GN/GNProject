function Get_Localidad_List(inicio) {
    var params = {       
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyLocalidad').html('');
            for (var i = 0; i <= lengthD; i++) {
                var direccion = Datos[i].Direccion == null ? '-' : Datos[i].Direccion;
                var html = '<tr>';
                html += '<td style="width:10px;"><input type="button" class="buttonEdit" id="' + Datos[i].Area_Id + '" /></td>';
                html += '<td style="width:10px;"><input type="button" class="buttonDelete" id="' + Datos[i].Area_Id + '" /></td>';
                html += '<td>' + Datos[i].Descripcion + '</td>';
                html += '<td>' + direccion + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyLocalidad');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Localidad_List_MaxRows() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_List_MaxRows",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var MaxRows = response.d;
            $('#txtnRegistros').val(MaxRows)
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};





function Get_Localidad_Find(Area_Id) {
    var params = {
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            if (Datos) {
                $('#txtcodigo').val(Datos.Area_Id);
                $('#txtDescripcion').val(Datos.Descripcion);
                $('#txtDireccion').val(Datos.Direccion);
                LocalidaProc = Datos.Area_Id;
                open_Modal();
                TIPOPROCESO = '02';
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Localidad_Add(Descripcion, Direccion) {
    var params = {
        Descripcion: Descripcion,
        Direccion: Direccion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_Add",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                var bol = Proceso.split('#')[0];
                var mensaje = Proceso.split('#')[1];
                if (bol == 'true') {
                    Get_Localidad_List(inicio);
                    Get_Localidad_List_MaxRows();
                    $('#dialog-Localidad').dialog('close');
                    TIPOPROCESO = '01';
                    LocalidaProc = '';
                    alert(mensaje);
                } else {
                    alert(mensaje);
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


function Get_Localidad_Update(Area_Id, Descripcion, Direccion) {
    var params = {
        Area_Id: Area_Id,
        Descripcion: Descripcion,
        Direccion: Direccion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_Update",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                var bol = Proceso.split('#')[0];
                var mensaje = Proceso.split('#')[1];
                if (bol == 'true') {
                    Get_Localidad_List(inicio);
                    Get_Localidad_List_MaxRows();
                    $('#dialog-Localidad').dialog('close');
                    TIPOPROCESO = '01';
                    LocalidaProc = '';
                    alert(mensaje);
                } else {
                    alert(mensaje);
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


function Get_Localidad_Delete(Area_Id) {
    var params = {
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sLocalidad.aspx/Get_Localidad_Delete",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                var bol = Proceso.split('#')[0];
                var mensaje = Proceso.split('#')[1];
                if (bol == 'true') {
                    Get_Localidad_List(inicio)                   
                    alert(mensaje);
                } else {
                    alert(mensaje);
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


function open_Modal() {
    
    $('#dialog-Localidad').dialog({
        autoOpen: true,
        modal: true,
        width: 400,
        height: 230,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};


function clearModal() {
    $('#txtcodigo').val('??');
    $('#txtDescripcion').val('');
    $('#txtDescripcion').focus();
    $('#txtDireccion').val('');
};