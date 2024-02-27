function Get_FilesAccion_List(Incidente_Id, Accion_Id) {
    var params = { Incidente_Id: Incidente_Id, Accion_Id: Accion_Id };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sSubirFileAccion.aspx/Get_FilesAccion_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyFiles').html('');

            for (var i = 0; i <= lengthD; i++) {

                var html = '<tr >';
                html += '<td style="width:10px;"><input type="button" class="buttonDelete" id="' + Datos[i].FileA_Id + '" title="Eliminar Archivo"  /></td>';
                html += '<td>' + Datos[i].File_NameI + '</td>';
                html += '<td></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyFiles');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });


};


function Get_Delete_FileAccion(Incidente_Id, Accion_Id, FileA_Id) {
    var params = { Incidente_Id: Incidente_Id, Accion_Id: Accion_Id, FileA_Id: FileA_Id };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sSubirFileAccion.aspx/Get_Delete_FileAccion",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            if (Datos) {
                Get_FilesAccion_List(Incidente_Id, Accion_Id)
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: true
    });


};







//----------------
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