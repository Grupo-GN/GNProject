function Get_Add_Personal(Incidente_Id, Gerente_Id, EventoComentario, Comentario) {
    var params = {
        Incidente_Id: Incidente_Id,
        Gerente_Id: Gerente_Id,
        EventoComentario: EventoComentario,
        Comentario: Comentario
        
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sComentGerencia.aspx/Get_Add_Comentario",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
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


function Get_Comentario_Historico(Incidente_Id, Gerente_Id, EventoComentario) {
    var params = {
        Incidente_Id: Incidente_Id,
        Gerente_Id: Gerente_Id,
        EventoComentario: EventoComentario

    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sComentGerencia.aspx/Get_Comentario_Historico",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                $('#txtComentario').val(Proceso);
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};










function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
};
