function Get_Files_List(Cogido_Gen) {
    var params = { Cogido_Gen: Cogido_Gen };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sSubirFile.aspx/Get_Files_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#tbodyFiles').html('');

            for (var i = 0; i <= lengthD; i++) {               

                var html = '<tr >';
                html += '<td style="width:10px;"><input type="button" class="buttonDelete" id="' + Datos[i].FileI_Id + '" title="Eliminar Archivo"  /></td>';
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


function Get_Delte_DataFile_Generado(FileI_Id, Cogido_Gen) {
    var params = { FileI_Id: FileI_Id, Cogido_Gen: Cogido_Gen };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sSubirFile.aspx/Get_Delte_DataFile_Generado",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            if (Datos) {
                Get_Files_List(Cogido_Gen)
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