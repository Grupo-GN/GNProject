function Get_Find_ReporteIncidente(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Find_ReporteIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            for (var i = 0; i <= Datos.length - 1; i++) {


                $('#lblReporte_Id').html(Incidente_Id);
                Incidente_Cod = Incidente_Id;
                Localidad_Cod = Datos[i].Area_Id;
                $('#lblUsuarioReg').html(Datos[i].PersonalReg);
                $('#lblLocalidadUs').html(Datos[i].RH_Area_Usu);
                //$('#lblLocalidad').html('Localidad : ' + Datos[i].Localidad + ' , Area : ' + Datos[i].Cat1 + ' , Sub - Area : ' + Datos[i].Cat2);

                $('#cboLocalidad').val(Localidad_Cod);
                var actPropia = Datos[i].ActProp;
                if (actPropia == '01') {
                    $('#rdAPSI').prop('checked', true); ;
                } else if (actPropia == '02') {
                    $('#rdAPNO').prop('checked', true); ;
                }

                var actRutin = Datos[i].ActRut;
                if (actRutin == '01') {
                    $('#rdARSI').prop('checked', true); ;
                } else if (actRutin == '02') {
                    $('#rdARNO').prop('checked', true); ;
                }

                $('#cboIntensidad').val(Datos[i].Intensidad);
                $('#txtDescripcionInc').val(Datos[i].Descripcion);
                var fechIncidente = Datos[i].FHInc.toDateFormat();
                var fe = fechIncidente.split(' ')[0];
                var homin = fechIncidente.split(' ')[1];
                var h = homin.split(':')[0];
                var m = homin.split(':')[1];
                $('#txtFechaInc').val(fe);
                $('#cboHoraInc').val(h);
                $('#cboMinInc').val(m);



                $('#lblFechaHoraRep').html(Datos[i].FHRep.toDateFormat());
                $('#txtLugarInc').val(Datos[i].Lugar);

                var tipo = Datos[i].Tipo;
                $('#cboTipo').val(tipo);
                $('#cboOrigen').val(Datos[i].Origen);

                $('#cboSeveridad').val(Datos[i].Severidad);
                $('#txtLesiones').val(Datos[i].LesionesPer);
                $('#txtDañosMat').val(Datos[i].PosCausas);
                $('#txtAccionInmediata').val(Datos[i].AccInmediata);

                var infoG = Datos[i].InfoGenrencia;

                if (infoG == '01') {
                    $('#lblIformarGe').html('SI');
                } else if (infoG == '02') {
                    $('#lblIformarGe').html('NO');
                }

                var infoOs = Datos[i].InfoOsigermin;

                if (infoOs == '01') {
                    $('#rbOsiSI').prop('checked', true);
                } else if (infoOs == '02') {
                    $('#rbOsiNO').prop('checked', true);
                }



                Get_LocalidadyArea(Datos[i].Area_Id, '');
                $('#cboCategoriaAuxiliar').val(Datos[i].Cat1);
                Get_Categoria_Auxiliar2_Combo();
                $('#cboCategoriaAuxiliar2').val(Datos[i].Cat2);
                Get_AccionCorrectiva_List(Incidente_Id);
                Get_Files_Incidencia_List(Incidente_Id);

                $('#cboTipoInc').val(Datos[i].TipoI_Id);
               

                $('#cboAfectadoInc').val(Datos[i].Afec_Id);
               
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};





function Get_Files_Incidencia_List(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Files_Incidencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyFiles').html('');
            for (var i = 0; i <= lengthd; i++) {
                $('#btnArchivos').val('Ver Archivos');
                var html = '<tr>';
                var linkdescarga = 'onClick = ';
                linkdescarga += '"descarFile(';
                linkdescarga += "'../../ArchivosIncidentes/";
                linkdescarga += Incidente_Id + '/' + Datos[i].File_NameI;
                linkdescarga += "'",
                linkdescarga += ')"';

                var estilotd = 'style="font-size: 12px;padding: 2px 3px;border-top: 1px solid #2C6B8D;border-right: 1px solid #DDDDDD;text-align: left;"';

                html += '<td ' + estilotd + '>' + Datos[i].File_NameI + '</td>';
                html += '<td ' + estilotd + '><a href="../../ArchivosIncidentes/' + Incidente_Id + '/' + Datos[i].File_NameI + '" target="_blank">VER</a></td>';
                html += '</tr>';
                $(html).appendTo('#tbodyFiles');

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};


function Get_Find_AccionCorrectiva(Incidente_Id, Accion_Id) {
    var params = {
        Incidente_Id: Incidente_Id,
        Accion_Id: Accion_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "sEditReporteIncidente.aspx/Get_Find_AccionCorrectiva",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            if (Datos) {
                TIPOPROCESOA = '02';
                Accion_Cod = Accion_Id;
                $('#txtResponsableFind').val('');
                $('#cboResponsable').val(Datos.Responsable_Id);
                $('#txtAccionDescrip').val(Datos.Descripcion);
                $('#txtFechaIni').datepicker("setDate", formatFecha.dmyE(Datos.FechaIni.toDateFormat()));
                $('#txtFechaFin').datepicker("setDate", formatFecha.dmyE(Datos.FechaFin.toDateFormat()));

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};