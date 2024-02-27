function Get_CategoriaAuxliar2_List(CateAux1,Descripcion, inicio) {
    var params = {
        CateAux1: CateAux1,
        Descripcion: Descripcion,
        inicio: inicio
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_CategoriaAuxliar2_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyCategoriaA').html('');
            for (var i = 0; i <= lengthD; i++) {
                var direccion = Datos[i].Direccion == null ? '-' : Datos[i].Direccion;
                var html = '<tr>';
                html += '<td style="width:10px;"><input type="button" class="buttonEdit" id="' + Datos[i].Categoria_Auxiliar2_Id + '"  /></td>';
                html += '<td style="width:49%;">' + Datos[i].CategoriaAux2 + '</td>';
                html += '<td style="width:49%;">' + Datos[i].CategoriaAux + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyCategoriaA');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};


function Get_CategoriaAuxliar2_List_MaxRows(CateAux1, Descripcion) {
    var params = {
        CateAux1: CateAux1,
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_CategoriaAuxliar2_List_MaxRows",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var MaxRows = response.d;
            $('#txtnRegistros').val(MaxRows)
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });

};


function Get_CategoriaAuxliar2_Find(Categoria2_Id) {
    var params = {
        Categoria2_Id: Categoria2_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_CategoriaAuxliar2_Find",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var categoria = response.d;
            if (categoria) {
                $('#txtcodigo').val(categoria.Categoria_Auxiliar2_Id);
                $('#txtDescripcion').val(categoria.Descripcion);
                $('#cboCateAux').val(categoria.Categoria_Auxiliar_id);
                Categoria_Proc = Categoria2_Id;
                TIPOPROCESO = '02';
                open_Modal();
            } else {
                Categoria_Id = '';
                TIPOPROCESO = '';
                alert('.::Error, Categoria Auxiliar no encontrada.')
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function Get_Add_CategoriaAuxliar2(Categoria_Id, Descripcion) {
    var params = {
        Categoria_Id: Categoria_Id,
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_Add_CategoriaAuxliar2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var proceso = response.d;
            if (proceso) {
                alert('Registrado Correctamente.');
                $('#dialog-Categoria').dialog('close');
                TIPOPROCESO = '';
                Categoria_Proc = '';
            } else {
                alert('.::Error, Intentelo nuevamente.');

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Update_CategoriaAuxliar2(Categoria2_Id, Categoria_Id, Descripcion) {
    var params = {
        Categoria2_Id: Categoria2_Id,
        Categoria_Id: Categoria_Id,
        Descripcion: Descripcion
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_Update_CategoriaAuxliar2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var proceso = response.d;
            if (proceso) {
                alert('Actualizado Correctamente.');
                $('#dialog-Categoria').dialog('close');
                TIPOPROCESO = '';
                Categoria_Id = '';
            } else {
                alert('.::Error, Intentelo nuevamente.');

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });


};


function Get_CategoriaAuxliar_Combo() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "sCategoriaAuxiliar2.aspx/Get_CategoriaAuxliar_Combo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCateAuxFind').html('');
            $('#cboCateAux').html('');
            $('<option value="">TODOS</option>').appendTo('#cboCateAuxFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCateAuxFind');
                $('<option value="' + Datos[i].Categoria_Auxiliar_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCateAux');
                
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });


};

function open_Modal() {

    $('#dialog-Categoria').dialog({
        autoOpen: true,
        modal: true,
        width: 400,
        height: 210,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};


function clearModal() {
    $('#txtcodigo').val('????');
    $('#txtDescripcion').val('');
    $('#cboCateAux').val('');
}

function get_FindDescrip() {
    return $('#txtFindDescip').val().toUpperCase();
};


function get_FindCateAux() {
    return $('#cboCateAuxFind').val() == null ? '' : $('#cboCateAuxFind').val();
};


