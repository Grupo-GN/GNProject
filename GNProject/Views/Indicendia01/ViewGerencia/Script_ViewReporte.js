function Get_Find_ReporteIncidente(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_Find_ReporteIncidente",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            for (var i = 0; i <= Datos.length - 1; i++) {
                $('#lblReporte_Id').html(Incidente_Id);
                Incidente_Cod = Incidente_Id;
                Area_Id = Datos[i].Area_Id;
                $('#lblLocalidadUs').html(Datos[i].LocalidadUsu);
                $('#lblUsuarioReg').html(Datos[i].PersonalReg);
                $('#lblLocalidad').html(Datos[i].RH_Area);
                $('#lblArea').html(Datos[i].Cat1);
                $('#lblSeccion').html(Datos[i].Cat2);
                var actPropia = Datos[i].ActProp;
                if (actPropia == '01') {
                    $('#lblActividadProp').html('SI');
                } else if (actPropia == '02') {
                    $('#lblActividadProp').html('NO');
                }

                var actRutin = Datos[i].ActRut;
                if (actRutin == '01') {
                    $('#lblActividadRut').html('SI');
                } else if (actRutin == '02') {
                    $('#lblActividadRut').html('NO');
                }

                $('#lblIntensidad').html(Datos[i].Intensidad);
                $('#txtDescripcionInc').html(Datos[i].Descripcion);
                $('#lblFechaHoraInci').html(Datos[i].FHInc.toDateFormat());
                $('#lblFechaHoraRep').html(Datos[i].FHRep.toDateFormat());
                $('#txtLugarInc').html(Datos[i].Lugar);


                var serveridadHTML = Datos[i].Severidad;
                $('#lblSeveridad').html(serveridadHTML);
                serveridadHTML = serveridadHTML.toUpperCase();
                if (serveridadHTML.indexOf('BAJA') != -1) {
                    /*$('#lblSeveridad').css('color', 'Green');*/
                    $('#tdSeveridad').css('background-color', 'Green');
                    
                }
                if (serveridadHTML.indexOf('MEDIA') != -1) {
                    /*$('#lblSeveridad').css('color', '#F9E400');*/
                    $('#tdSeveridad').css('background-color', '#F9E400');
                }
                if (serveridadHTML.indexOf('ALTA') != -1) {
                    /*$('#lblSeveridad').css('color', 'Red');*/
                    $('#tdSeveridad').css('background-color', 'Red');
                }


                $('#txtLesiones').html(Datos[i].LesionesPer);
                $('#txtPosCausas').html(Datos[i].PosCausas);
                $('#txtAccionInmediata').html(Datos[i].AccInmediata);
                $('#lblTipoI').html(Datos[i].TipoI);
                $('#lblAfectado').html(Datos[i].Afecto);

                $('#lblTipo').html(Datos[i].Tipo);

                $('#lblOrigen').html(Datos[i].Origen);


                var infoG = Datos[i].InfoGenrencia;

                if (infoG == '01') {
                    $('#lblIformarGe').html('SI');
                } else if (infoG == '02') {
                    $('#lblIformarGe').html('NO');
                }
                var infoOs = Datos[i].InfoOsigermin;

                if (infoOs == '01') {
                    $('#lblInformarOs').html('SI');

                } else if (infoOs == '02') {
                    $('#lblInformarOs').html('NO');
                }
                Get_Reg_CausaReporte_Detalle_List(Incidente_Cod, '01');
                Get_Reg_CausaReporte_Detalle_List(Incidente_Cod, '02');

            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};



function Get_AccionCorrectiva_List(Incidente_Id) {
    var accionesfiles = Get_Files_Accion_List(Incidente_Id);
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_AccionCorrectiva_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyAcciones').html('');
            $('#tbodyaccion').html('');
            for (var i = 0; i <= lengthd; i++) {
                var sttd = '';
                var esta = Datos[i].Estado_Id;
                var estadoDes = '';
                switch (esta) {
                    case '01': sttd = 'color:Green;'; break;
                    case '02': sttd = 'color:Red;'; break;
                    case '03': sttd = 'color: #777777'; break;
                    case '04': sttd = 'color: #FF7300'; break;
                    case '05': sttd = 'color: #1A4600'; break;
                    case '06': sttd = 'color: #007CFF'; break;

                }

                
                switch (esta) {
                    case '01': estadoDes = 'APROBADO'; break;
                    case '02': estadoDes = 'DESAPROBADO'; break;
                    case '03': estadoDes = 'PENDIENTE DE REVISION'; break;
                    case '04': estadoDes = 'REVISADO Y DESAPROBADO'; break;
                    case '05': estadoDes = 'REVISADO Y APROBADO'; break;
                    case '06': estadoDes = 'PENDIENTE REVISION'; break;
                }

                var estilotd = 'style="font-size: 12px;padding: 2px 3px;border-top: 1px solid #2C6B8D;border-right: 1px solid #DDDDDD;text-align: left;';


                var html = '<tr>';
                html += '<td colspan="4" ' + estilotd + sttd + '">' + Datos[i].Descripcion + '</td>';
                html += '<td colspan="3" ' + estilotd + sttd + '">' + Datos[i].ResponsableName + '</td>';
                html += '<td ' + estilotd + 'text-align:center;width:100px;' + sttd + '">' + Datos[i].FechaIni.toDateFormat() + '</td>';
                html += '<td ' + estilotd + 'text-align:center;width:100px;' + sttd + '">' + Datos[i].FechaFin.toDateFormat() + '</td>';
                html += '<td ' + estilotd + 'text-align:center;width:170px;' + sttd + '">' + estadoDes + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyAcciones');
                var subfiles = accionesfiles.filter(w => w.Accion_Id == Datos[i].Accion_Id);
                var htmlfile = '';
                for (var f = 0; f <= subfiles.length - 1; f++) {
                    htmlfile += '<a href="../../ArchivosAcciones/' + Incidente_Id + '/' + '/' + subfiles[f].Accion_Id + '/' + subfiles[f].File_NameI + '" target="_blank">' + subfiles[f].File_NameI + '</a><br/>';
                }                
                var html2 = '<tr>';
                html2 += '<td colspan="5" ' + estilotd + sttd + '">' + Datos[i].Descripcion + '</td>';
                html2 += '<td colspan="4" ' + estilotd + 'text-align:center;' + sttd + '">' + htmlfile + '</td>';
                html2 += '</tr>';
                $(html2).appendTo('#tbodyaccion');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });

};
function descarFile(file) {
    window.location = file;
};


function Get_Files_Incidencia_List(Incidente_Id) {
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_Files_Incidencia_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthd = Datos.length - 1;
            $('#tbodyFiles').html('');
            for (var i = 0; i <= lengthd; i++) {
                var html = '<tr>';
                var linkdescarga = 'onClick = ';
                linkdescarga += '"descarFile(';
                linkdescarga += "'../../ArchivosIncidentes/";
                linkdescarga += Incidente_Id + '/' + Datos[i].File_NameI;
                linkdescarga += "'",
                linkdescarga += ')"';

                var estilotd = 'style="font-size: 12px;padding: 2px 3px;border-top: 1px solid #2C6B8D;border-right: 1px solid #DDDDDD;text-align: left;"';

                html += '<td colspan="4" ' + estilotd + '>' + Datos[i].File_NameI + '</td>';
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



//Get DataList

function Get_DataList_Responsable(Nombres, Usuario, Area_Id) {
    var params = {
        Nombres: Nombres,
        Usuario: Usuario,
        Area_Id: Area_Id
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_DataList_Responsable",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboResponsable').html('');
            $('<option value="">-SELECCIONE-</option>').appendTo('#cboResponsable');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Personal_Id + '">' + Datos[i].Apellido_Paterno + ' ' + Datos[i].Apellido_Materno + ',' + Datos[i].Nombres + '</option>').appendTo('#cboResponsable');
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
        url: "ViewReporte.aspx/Get_Find_AccionCorrectiva",
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





function Get_Reg_CausaReporte_Detalle_List(Incidente_Id, Tipo) {
    var params = {
        Incidente_Id: Incidente_Id,
        Tipo: Tipo
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_Reg_CausaReporte_Detalle_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            if (Tipo == '01') {
                CausasBa = 0;
                $('#tbodyCB').html('');
                for (var i = 0; i <= lengthD; i++) {
                    CausasBa += 1;
                    var html = '<tr>';
                    html += '<td colspan="3">' + Datos[i].Causa_Name + '</td>';
                    html += '<td colspan="4">' + Datos[i].Descripcion + '</td>';   
                    html += '</tr>';
                    $(html).appendTo('#tbodyCB');
                }
            } else if (Tipo = '02') {
                CausasIn = 0;
                $('#tbodyCI').html('');
                for (var i = 0; i <= lengthD; i++) {
                    CausasIn += 1;
                    var html = '<tr>';
                    html += '<td colspan="3">' + Datos[i].Causa_Name + '</td>';
                    html += '<td colspan="4">' + Datos[i].Descripcion + '</td>';                    
                    html += '</tr>';
                    $(html).appendTo('#tbodyCI');
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

/* 20190215 */
function Get_Files_Accion_List(Incidente_Id) {
    var datos = [];
    var params = {
        Incidente_Id: Incidente_Id
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "ViewReporte.aspx/Get_Files_Accion_List",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            datos = response.d;
        },
        error:
            function (XmlHttpError, error, description) {
                $("#divError").html(XmlHttpError.responseText);
            },
        async: false
    });
    return datos;
};

function open_Modal() {

    $('#dialog-Accion').dialog({
        autoOpen: true,
        modal: true,
        width: 700,
        height: 370,
        show: { effect: "fade", duration: 800 },
        hide: { effect: "explode", duration: 800 }
    });

};


function clearModal() {
    $('#txtResponsableFind').val('');
    $('#cboResponsable').val('');
    $('#txtAccionDescrip').val('');
    $('#txtFechaIni').val('');
    $('#txtFechaFin').val('');
};




//FECHAS

Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + days);
    return this;
};


String.prototype.toDateFormat = function () {

    if (this) {
        var dte = eval("new " + this.replace(/\//g, '') + ";");

        dte.setMinutes(dte.getMinutes() - dte.getTimezoneOffset());
        //  dateFormat(dte, "yyyy-MM-dd HH:mm:ss");
        var ret = dateDemo(dte);
        //return dte;
        return ret;
    } else {
        return '';
    }
};

function dateDemo(fecha) {



    var Dia = fecha.getUTCDate();
    var Mes = (fecha.getUTCMonth() + 1);
    var Anio = fecha.getUTCFullYear();

    Dia = Dia.toString().padLeft("0", 2);
    Mes = Mes.toString().padLeft("0", 2);

    var Hora = fecha.getUTCHours();
    Hora = Hora.toString().padLeft("0", 2);

    var Min = fecha.getUTCMinutes();
    Min = Min.toString().padLeft("0", 2);


    var fechaWPP = Dia + "/" + Mes + "/" + Anio + " " + Hora + ":" + Min;


    return fechaWPP;
};



String.prototype.padLeft = function (paddingChar, length) {

    var s = new String(this);

    if ((this.length < length) && (paddingChar.toString().length > 0)) {
        for (var i = 0; i < (length - this.length); i++)
            s = paddingChar.toString().charAt(0).concat(s);
    }

    return s;
};



var formatFecha = {
    ymd: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        } else {
            var arr = fecha.split('/');
            return arr[2] + '-' + arr[1] + '-' + arr[0];
        }

    },
    dmy: function (fecha) {
        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '-' + arr[1] + '-' + arr[2];
        }
    },
    dmyE: function (fecha) {

        if (fecha.indexOf(' ') != -1) {
            var arr1 = fecha.split(' ');
            var arr = arr1[0].split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        } else {
            var arr = fecha.split('/');
            return arr[0] + '/' + arr[1] + '/' + arr[2];
        }
    }
};
var DateDiff = {

    inDays: function (d1, d2) {
        var t2 = d2; //.getTime();
        var t1 = d1; //.getTime();

        return parseInt(((t2 - t1) / (24 * 3600 * 1000)) + 1);
    },

    inWeeks: function (d1, d2) {
        var t2 = d2.getTime();
        var t1 = d1.getTime();
        return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
    },

    inMonths: function (d1, d2) {
        var d1Y = d1.getFullYear();
        var d2Y = d2.getFullYear();
        var d1M = d1.getMonth();
        var d2M = d2.getMonth();

        return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
    },

    inYears: function (d1, d2) {
        return d2.getFullYear() - d1.getFullYear();
    }
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






//STYLOS

function Change_Estilos() {

    $('#serTableRe').css({ 
    'width': '100%'
    ,'border-collapse':'collapse'
    ,'border':'1px solid #2C6B8D'
    ,'max-width':'100%'});



    $('#tbl1 thead tr th').each(function (index) {
        $(this).css({
             'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight':'bold'
	        , 'padding':'0px 7px'
	        , 'margin':'20px 0px 0px'
	        , 'text-align':' left'
	        , 'text-align':'center'
        });
     });

     $('#tbl2').css({
         'width': '100%'
    , 'border-collapse': 'collapse'
    , 'border': '1px solid #2C6B8D'
    , 'max-width': '100%'
     });

     $('#tbl2 thead tr th').each(function (index) {
         $(this).css({
             'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight': 'bold'
	        , 'padding': '0px 7px'
	        , 'margin': '20px 0px 0px'
	        , 'text-align': ' left'
	        , 'text-align': 'center'
         });
     });


     $('#tbl15').css({
         'width': '100%'
    , 'border-collapse': 'collapse'
    , 'border': '1px solid #2C6B8D'
    , 'max-width': '100%'
     });

     $('#tbl15 thead tr th').each(function (index) {
         $(this).css({
             'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight': 'bold'
	        , 'padding': '0px 7px'
	        , 'margin': '20px 0px 0px'
	        , 'text-align': ' left'
	        , 'text-align': 'center'
         });
     });

     $('#tbl16').css({
         'width': '100%'
    , 'border-collapse': 'collapse'
    , 'border': '1px solid #2C6B8D'
    , 'max-width': '100%'
     });

     $('#tbl16 thead tr th').each(function (index) {
         $(this).css({
             'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight': 'bold'
	        , 'padding': '0px 7px'
	        , 'margin': '20px 0px 0px'
	        , 'text-align': ' left'
	        , 'text-align': 'center'
         });
     });
     

     $('#serTableRe tbody tr td label').each(function (index) {
         $(this).css({
             'background': 'transparent'
	, 'font-weight': 'normal'
	, 'line-height': '10px'
	, 'font': ' 12px/21px "HelveticaNeue", "Helvetica Neue", Helvetica, Arial, sans-serif'
	, 'color': '#444'
	, '-webkit-font-smoothing': 'antialiased'
	, '-moz-font-smoothing': 'antialiased'
	, '-webkit-text-size-adjust': '100%'
	, '-moz-text-size-adjust': '100%'
        , 'font-weight': 'bold'
        , 'font-size': '12px'
        , 'color': '#336699'
        , 'text-decoration': 'none'
         });
     
     });


     $('.tdlabel').each(function (index) {
         $(this).css({
             'background': 'transparent'
	, 'font-weight': 'normal'
	, 'line-height': '10px'
	, 'font': ' 12px/21px "HelveticaNeue", "Helvetica Neue", Helvetica, Arial, sans-serif'
	, 'color': '#444'
	, '-webkit-font-smoothing': 'antialiased'
	, '-moz-font-smoothing': 'antialiased'
	, '-webkit-text-size-adjust': '100%'
	, '-moz-text-size-adjust': '100%'
        , 'font-weight': 'bold'
        , 'font-size': '12px'
        , 'color': '#336699'
        , 'text-decoration': 'none'
         });

     });
 $('.tdtxt').each(function (index) {
         $(this).css({
     	   'background':'white repeat-x bottom left'
	    , 'min-height':'18px'
	    , 'border':'#B1B1B1 1px solid'
	    , 'text-transform':'uppercase'
	    , 'font-size':'14px'
	    , 'text-align':'left'	
	    , 'font-weight':'normal'
	    , 'line-height':'10px'
	    , 'font':'12px/21px "HelveticaNeue", "Helvetica Neue", Helvetica, Arial, sans-serif'
	    , 'color':'#444'
	    , '-webkit-font-smoothing':'antialiased'
	    , '-moz-font-smoothing':'antialiased'
	    , '-webkit-text-size-adjust':'100%'
	    , '-moz-text-size-adjust':'100%'
         });

     });

    $('#tblaccion').css({
        'width': '100%'
        , 'border-collapse': 'collapse'
        , 'border': '1px solid #2C6B8D'
        , 'max-width': '100%'
    });

    $('#tblaccion thead tr th').each(function (index) {
        $(this).css({
            'background-color': '#2C6B8D'
            , 'height': '28px'
            , 'font-family': 'AENOR Fontana ND'
            , 'text-transform:': 'uppercase'
            , 'color': '#FFFFFF'
            , 'font-size': '1em'
            , 'font-weight': 'bold'
            , 'padding': '0px 7px'
            , 'margin': '20px 0px 0px'
            , 'text-align': ' left'
            , 'text-align': 'center'
        });
    });

};
