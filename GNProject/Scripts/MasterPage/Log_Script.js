
var lengthDatosDet
var DataDet
var RazonSoc = '';

function getConex(ruc) {

    var params = {
        ruc: ruc
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "~/Views/Login/Login.aspx/ListaDatos",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            lengthDatosDet = DataDet.length - 1;
            for (var i = 0; i <= lengthDatosDet; i++) {
                var html = '<tr>';
                RazonSoc = DataDet[i].razon;
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: true
    });
    return RazonSoc;
}


var razoc = '';
function getDatoEmpresa(ruc, fl) {

    var params = {
        ruc: ruc
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "~/Views/Login/Login.aspx/ListDatosEmpresa",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            lengthDatosDet = DataDet.length - 1;
            for (var i = 0; i <= lengthDatosDet; i++) {

                if (fl == '1') {
                    razoc = DataDet[i].RazonSocial;
                } else {
                    $("#lblEmpresa").html(DataDet[i].RazonSocial);
                    $("#lblRuc").html(DataDet[i].Ruc);
                    document.getElementById("ItemPreview").src = "data:image/png;base64," + DataDet[i].Image;

                }


            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: true
    });
    return razoc;
}

function getDatoEmpresa1(ruc, fl) {

    var params = {
        ruc: ruc
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "~/Views/Login/Login.aspx/ListDatosEmpresa",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            lengthDatosDet = DataDet.length - 1;
            for (var i = 0; i <= lengthDatosDet; i++) {
                razoc = DataDet[i].RazonSocial;
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: true
    });
    return razoc;
}

