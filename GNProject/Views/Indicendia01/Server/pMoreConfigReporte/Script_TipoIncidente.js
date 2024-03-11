function Get_TipoIncidente_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_TipoIncidente_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#lbTipoI').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].TipoI_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#lbTipoI');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        asyc: false
    });

};

function Get_Add_TipoIncidente(Descripcion) {
    var params = {
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Add_TipoIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_TipoIncidente_List();
                        TipoIProc_Id = '';
                        PROCESOTIPO = '01';
                        $('#txtDescipcionTI').val('');
                    } else {
                        alert(msj);
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


function Get_Update_TipoIncidente(TipoI_Id, Descripcion) {
    var params = {
        TipoI_Id: TipoI_Id,
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Update_TipoIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_TipoIncidente_List();
                        TipoIProc_Id = '';
                        PROCESOTIPO = '01';
                        $('#txtDescipcionTI').val('');
                    } else {
                        alert(msj);
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

function Get_Delete_TipoIncidente(TipoI_Id) {
    var params = {
        TipoI_Id: TipoI_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Delete_TipoIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_TipoIncidente_List();
                        TipoIProc_Id = '';
                        PROCESOTIPO = '01';
                        $('#txtDescipcionTI').val('');
                    } else {
                        alert(msj);
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