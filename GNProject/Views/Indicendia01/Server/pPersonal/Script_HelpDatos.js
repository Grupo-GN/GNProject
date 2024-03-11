

function Get_Planilla_Combo() {
    $.ajax({
        type: "POST",       
        dataType: "json",
        url: "sPersonal.aspx/Get_Planilla_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboPlanilla').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Planilla_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboPlanilla');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};

function Get_Cargo_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPersonal.aspx/Get_Cargo_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCargo').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Cargo_id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCargo');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};

function Get_Localidad_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPersonal.aspx/Get_Localidad_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboLocalidad').html('');
            $('#cboLocalidadFind').html('');
            $('<option value="">TODOS</option>').appendTo('#cboLocalidadFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidad');
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidadFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};

function Get_Categoria_Auxiliar_Combo() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: "sPersonal.aspx/Get_Categoria_Auxiliar_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCategoriaAuxiliar').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCategoriaAuxiliar');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};

function Get_Categoria_Auxiliar2_Combo() {
    var Categoria_Auxiliar_id = $('#cboCategoriaAuxiliar').val();
    var params = {
        Categoria_Auxiliar_id: Categoria_Auxiliar_id
    };

    $.ajax({
        type: "POST",
         data: JSON.stringify(params),
        dataType: "json",
        url: "sPersonal.aspx/Get_Categoria_Auxiliar2_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCategoriaAuxiliar2').html('');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar2_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCategoriaAuxiliar2');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};