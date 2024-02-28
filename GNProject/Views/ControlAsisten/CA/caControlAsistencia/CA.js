function Get_Planilla_List() {

    $.ajax({
        type: "POST",
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Planilla_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Planilla_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPlanilla');
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });

};

function Get_Periodo_List(Planilla_Id) {

    var params = {
        Planilla_Id: Planilla_Id,
        Fecha: $('#fecha').val()
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Periodo_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            var lengthd = Data.length - 1;
            $('#cboPeriodo').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('<option value="' + Data[i].Periodo_Id + '">' + Data[i].Descripcion + '</option>').appendTo('#cboPeriodo');
            }
            if (Data) {
                
                $('#txtfechaini').val(Data.Fecha_Ini.toDateShort());
                $('#txtfechafin').val(Data.Fecha_Fin.toDateShort());
                n = new Date();
                $('#fecha').val(n.toDateShort());
            }
        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });
};

function Get_Periodo_Asistencia_List() {
    $.ajax({
        type: "POST",
        data: JSON.stringify(),
        dataType: "json",
        url: "CAImportarMarcaciones.aspx/Get_Periodo_Asistencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            if (Data) {
                $('#txtcodigo').val(Data.Periodo);
                $('#txtfi').val(Data.Date_Inicio.toDateShort());
                $('#txtft').val(Data.Date_Fin.toDateShort());
                $('#fecha').val(Data.Date_Inicio.toDateShort());
            }

        },
        error:
            function (XmlHttpError, error, description) {
                $('#dialog-form').html(XmlHttpError.responseText);
            },
        async: false
    });

}


function Get_Planilla_Find() {
    return $('#cboPlanilla').val();
};

function Get_Periodo_Find() {
    return $('#cboPeriodo').val();
};