var dni = '<%=Session["dni"]%>'
var Personal_id = '<%=Session["Personal_id"]%>'
var foto = '<%=Session["Foto"]%>'
 
function getDatoEmpresa(dni, conexion) {
 
    var params = {
        nrodoc: dni,
        conexion: conexion
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Principal.aspx/ListaEmpleados3",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            lengthDatosDet = DataDet.length - 1;
            for (var i = 0; i <= lengthDatosDet; i++) {
                dni = dni
                Personal_id = DataDet[i].Personal_id
                $("#nombres").html(DataDet[i].Nombres);
                $("#tipo").html(DataDet[i].TipoT);
                $("#area").html(DataDet[i].Area);
                $("#id_persona").html(DataDet[i].Personal_id);
                $("#conexion").html(DataDet[i].conexion);
                $("#tipoconexion").html(DataDet[i].tipoconexion);
                foto = DataDet[i].Foto;
                var imgsrc = "data:image/png||jpg;base64," + btoa(String.fromCharCode.apply(null, new Uint8Array(foto)));

                document.getElementById('ItemPreview').src = imgsrc;
            }
            if (DataDet.length>0) {
                $("#pages").hide();
                $("#bod").show();
            } else {
                //alert("No se Encontraron datos de Empleado");
                MENSAJE = "No se Encontraron datos de Empleado";
                $("#mensaje").html(MENSAJE);
                $("#modalMensaje").modal('show');
                $("#txtDni").val();
            }
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
    return dni;
}


function RegistroHorario(persona,fecha,hora,tipo,conexion, tipoconexion) {

    var params = {
        persona:persona, 
        fecha:fecha, 
        hora:hora,
        tipo: tipo,
        conexion:conexion,
        tipoconexion:tipoconexion
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Principal.aspx/InsertarHora",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            DataDet = response.d;
            lengthDatosDet = DataDet.length - 1;
            var id,data
            for (var i = 0; i <= lengthDatosDet; i++) {
                id=DataDet[i].id;
                data = DataDet[i].data;
            }
         
                //alert("No se Encontraron datos de Empleado");
                MENSAJE = id+' '+data;
                $("#mensaje").html(MENSAJE);
                $("#modalMensaje").modal('show');
               
            
        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });

}




function GetMarcas(Personal_Id) {
 
    var params = {
        Personal_Id: Personal_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "Principal.aspx/ListaMarcacionesTop",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Data = response.d;
            $('#TDMarcas').html('');
            var lengthDatos = Data.length - 1;
            for (var i = 0; i <= lengthDatos; i++) {
                if (i % 2 == 0 || i !=1) {
                    var html = '<tr class="table-info">';
                    html += '<th scope="row">' + Data[i].Fecha + '</th>';
                    html += '<td>' + Data[i].Ingreso + '</td>';
                    html += '<td>' + Data[i].Salida_Refrigerio  + '</td>';
                    html += '<td>' + Data[i].Ingreso_Refrigerio + '</td>';
                    html += '<td>' + Data[i].Salida + '</td>';
                    html += '</tr>';
                }
                else {
                    var html = '<tr class="table-info">';
                    html += '<th scope="row">' + Data[i].Fecha + '</th>';
                    html += '<td>' + Data[i].Ingreso + '</td>';
                    html += '<td>' + Data[i].Salida_Refrigerio  + '</td>';
                    html += '<td>' + Data[i].Ingreso_Refrigerio + '</td>';
                    html += '<td>' + Data[i].Salida + '</td>';

                    html += '</tr>';
                }
               
                $(html).appendTo('#TDMarcas');
            }
           

        },
        error:
    function (XmlHttpError, error, description) {
        $('#dialog-form').html(XmlHttpError.responseText);
    },
        async: true
    });
}


