function Get_AfectadoInc_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_AfectadoInc_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#lbAfectado').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Afec_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#lbAfectado');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        asyc: false
    });

};

function Get_Add_AfectadoInc(Descripcion) {
    var params = {
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Add_AfectadoInc",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_AfectadoInc_List();
                        AfecIProc_Id = '';
                        PROCESOAFEC = '01';
                        $('#txtDescripcionA').val('');
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


function Get_Update_AfectadoInc(Afec_Id, Descripcion) {
    var params = {
        Afec_Id: Afec_Id,
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Update_AfectadoInc",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_AfectadoInc_List();
                        AfecIProc_Id = '';
                        PROCESOAFEC = '01';
                        $('#txtDescripcionA').val('');
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

function Get_Delete_AfectadoInc(Afec_Id) {
    var params = {
        Afec_Id: Afec_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sMConfigReporte.aspx/Get_Delete_AfectadoInc",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var succ = Proceso.split('#')[0];
                    var msj = Proceso.split('#')[1];
                    if (succ == 'true') {
                        alert(msj);
                        Get_AfectadoInc_List();
                        AfecIProc_Id = '';
                        PROCESOAFEC = '01';
                        $('#txtDescripcionA').val('');
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