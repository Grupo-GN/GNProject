
function Generar_Historial_Multiple_WPP() {
    var lengthav = aView.length - 1;
    var lengthaw = aWhere.length - 1;

    if (lengthav <= 0) {
        alert('.::Error, Campos a mostrar no definidos.');
        return false;
    }


    var SelectView = '';
    var JoinView = '';
    var WhereView = '';

    var thView = [];
    //SELEC
    for (var v = 0; v <= lengthav; v++) {
        var cad = Get_ViewCampos(aView[v]);        
        SelectView += cad.split('#')[0];
        thView.push(cad.split('#')[1]);
    }
    SelectView = SelectView.substring(0,SelectView.length - 1);
    

    //CARGANDO THEADO DE LA TABLA
    $('#theadHistorial').html('');
    var htmlthead = '<tr>';  
    for (var h = 0; h <= thView.length -1; h++) {
        htmlthead += '<th>' + thView[h] + '</th>';
    }
    htmlthead += '</tr>';
    $(htmlthead).appendTo('#theadHistorial');



    //JOIN

    for (var j = 0; j <= lengthav; j++) {
        JoinView += Get_Join(aView[j]);       
    }

    //WHERE
  
    for (var w = 0; w <= lengthaw; w++) {
        if (!WhereView) {
            WhereView = ' WHERE ';
        }
        var filtro = aWhere[w];      
        var valor='';
        if (filtro == 'f1') {
            valor=$('#txtPersoFind').val();
            WhereView+= Get_Where(filtro,valor);
        }

        if (filtro == 'f2') {
            valor = $('#cboLocalidadFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }
        }

        if (filtro == 'f3') {
            valor = $('#cboCatFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }
           
             
        }

        if (filtro == 'f4') {
            valor = $('#cboCat2Find').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }
         
            
        }

        if (filtro == 'f5') {
            valor = $('#cboAPFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }           
        }


        if (filtro == 'f6') {
            valor = $('#cboARFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }              

        }

        if (filtro == 'f7') {
            valor = $('#cboIntFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }             
        }

        if (filtro == 'f8') {
            valor = $('#cboInfGFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }  
                      
        }

        if (filtro == 'f9') {
            valor = $('#cboInfOFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }             

        }


        if (filtro == 'f10') {
            if (!$('#txtFII').val()) {
                alert('.::Error, Fecha Inicio Incidencia no definido.');
                $('#txtFII').focus();
                return false;
            }
            if (!$('#txtFFI').val()) {
                alert('.::Error, Fecha Fin Incidencia no definido.');
                $('#txtFFI').focus();
                return false;
            }
            valor = $('#txtFII').val()+'#'+$('#txtFFI').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }  
        }

        if (filtro == 'f11') {
            if (!$('#txtFIR').val()) {
                alert('.::Error, Fecha Inicio Reporte no definido.');
                $('#txtFIR').focus();
                return false;
            }
            if (!$('#txtFFR').val()) {
                alert('.::Error, Fecha Fin Reporte no definido.');
                $('#txtFFR').focus();
                return false;
            }

            valor = $('#txtFIR').val()+'#'+$('#txtFFR').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }                 

        }

        if (filtro == 'f12') {
            valor = $('#cboTipoFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }             

        }

        if (filtro == 'f13') {
            valor = $('#cboSevFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            } 
        }

        if (filtro == 'f14') {
            valor = $('#cboSenGFind').val();
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }
        }
        if (filtro == 'f15') {
            valor = $('#cboOrigen').val(); 
            if (valor) {
                WhereView += Get_Where(filtro, valor);
            }
        }
        
    }

    if (WhereView.trim() == 'WHERE') {
        WhereView = '';
    } else {
        if (WhereView) {
            WhereView = WhereView.substring(0, WhereView.length - 4);
        }
    }

        var params = {
            select: SelectView,
            joins: JoinView,
            where: WhereView
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            dataType: "json",
            url: "rHistorial.aspx/GENERAR_REPORTE_HISTORIAL_MULTIPLE_WPP",
            contentType: "application/json; chartseft:utf-8",
            success: function (response) {
                var Datos = response.d;
                var lengthD = Datos.length - 1;
                $('#tbodyHistorial').html('');
                for (var i = 0; i <= lengthD; i++) {
                    var htmlb = '<tr>';
                    for (var h = 0; h <= thView.length - 1; h++) {
                        htmlb += '<td>' + Datos[i][h] + '</td>';
                    }
                    htmlb += '</tr>';
                   
                    $(htmlb).appendTo('#tbodyHistorial');
                }

            },
            error:
                    function (XmlHttpError, error, description) {
                        $("#divError").html(XmlHttpError.responseText);
                    },
            async: false
        });
        addEstilos();
    };







function addEstilos() {


    $('#tblHistorial').css({
            'width': '100%'
    , 'border-collapse': 'collapse'
    , 'border': '1px solid #2C6B8D'
    , 'max-width': '100%'
        });



        $('#tblHistorial thead tr th').each(function (index) {
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




        $('#tblHistorial tbody tr td').each(function (index) {
            $(this).css({
                'background': 'transparent'
	            ,'font-size': '12px'
	            ,'color': '#777777'
	            ,'padding': '2px 3px'
	            ,'border-top': '1px solid #2C6B8D'
	            ,'border-right': '1px solid #DDDDDD'
	            , 'text-align': 'left'
                , 'vertical-align':'text-top'
            });

        });



    };










function Get_MostrarFiltros(filtro_id) {
    var mos = false;
    if (filtro_id == 'f1') {
        mos = $('#f1').is(':checked');
        if (mos) {
            $('<div id="dfPer" style="float:left;margin-left:10px;width:350px;height:20px;margin-top:5px;"><label class="miLabel">Apellidos y Nombres : </label><input type="text" id="txtPersoFind"  style="width:200px;" class="txt" /></div>').appendTo('#divFiltros');           
        } else {
            $('#dfPer').remove();
        }
    }

    if (filtro_id == 'f2') {
        mos = $('#f2').is(':checked');
        if (mos) {
            $('<div id="dfLoc" style="float:left;margin-left:10px;width:200px;height:20px;margin-top:5px;"><label class="miLabel">Localidad : </label><select class="cbo" id="cboLocalidadFind"></select></div>').appendTo('#divFiltros');
            Get_Localidad();
        } else {
            $('#dfLoc').remove();
        }
    }

    if (filtro_id == 'f3') {
        mos = $('#f3').is(':checked');
        if (mos) {
            $('<div id="dfCat" style="float:left;margin-left:10px;width:240px;height:20px;margin-top:5px;"><label class="miLabel">Área : </label><select class="cbo" id="cboCatFind"></select></div>').appendTo('#divFiltros');
            Get_Categoria_Auxiliar();
        } else {
            $('#dfCat').remove();
        }
    }

    if (filtro_id == 'f4') {
        mos = $('#f4').is(':checked');
        if (mos) {
            $('<div id="dfCat2" style="float:left;margin-left:10px;width:350px;height:20px;margin-top:5px;"><label class="miLabel">Sección : </label><select class="cbo" id="cboCat2Find"></select></div>').appendTo('#divFiltros');
            Get_Categoria_Auxiliar2();
        } else {
            $('#dfCat2').remove();
        }
    }

    if (filtro_id == 'f5') {
        mos = $('#f5').is(':checked');
        if (mos) {
            $('<div id="dfap" style="float:left;margin-left:10px;width:200px;height:20px;margin-top:5px;"><label class="miLabel">Actividad Propia : </label><select class="cbo" id="cboAPFind"><option value="">-TODOS-</option><option value="01">SI</option><option value="02">NO</option></select></div>').appendTo('#divFiltros');
        } else {
            $('#dfap').remove();
        }
    }


    if (filtro_id == 'f6') {
        mos = $('#f6').is(':checked');
        if (mos) {
            $('<div id="dfar" style="float:left;margin-left:10px;width:220px;height:20px;margin-top:5px;"><label class="miLabel">Actividad Rutinaria : </label><select class="cbo" id="cboARFind"><option value="">-TODOS-</option><option value="01">SI</option><option value="02">NO</option></select></div>').appendTo('#divFiltros');
        } else {
            $('#dfar').remove();
        }
    }

    if (filtro_id == 'f7') {
        mos = $('#f7').is(':checked');
        if (mos) {
            $('<div id="dfint" style="float:left;margin-left:10px;width:250px;height:20px;margin-top:5px;"><label class="miLabel">Intensidad : </label><select class="cbo" id="cboIntFind"></select></div>').appendTo('#divFiltros');
            Get_Intensidad();
        } else {
            $('#dfint').remove();
        }
    }

    if (filtro_id == 'f8') {
        mos = $('#f8').is(':checked');
        if (mos) {
            $('<div id="dfinfg" style="float:left;margin-left:10px;width:210px;height:20px;margin-top:5px;"><label class="miLabel">Informar Gerencia : </label><select class="cbo" id="cboInfGFind"><option value="">-TODOS-</option><option value="01">SI</option><option value="02">NO</option></select></div>').appendTo('#divFiltros');
        } else {
            $('#dfinfg').remove();
        }
    }

    if (filtro_id == 'f9') {
        mos = $('#f9').is(':checked');
        if (mos) {
            $('<div id="dfinfo" style="float:left;margin-left:10px;width:220px;height:20px;margin-top:5px;"><label class="miLabel">Informar Osigermin : </label><select class="cbo" id="cboInfOFind"><option value="">-TODOS-</option><option value="01">SI</option><option value="02">NO</option></select></div>').appendTo('#divFiltros');
        } else {
            $('#dfinfo').remove();
        }
    }


    if (filtro_id == 'f10') {
        mos = $('#f10').is(':checked');
        if (mos) {
            $('<div id="dfFEI" style="float:left;margin-left:10px;width:470px;height:20px;margin-top:5px;"><label class="miLabel">Fecha Ini. Inci. : </label><input type="text" class="txt" id="txtFII" /><label class="miLabel">&nbsp;&nbsp;&nbsp; Fecha Fin. Inci. : </label><input type="text" class="txt" id="txtFFI" /></div>').appendTo('#divFiltros');
            
            $('#txtFII').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false,
                onClose: function (selectedDate) {
                    $("#txtFFI").datepicker("option", "minDate", selectedDate);
                }
            });

            $('#txtFFI').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false
                
            });

        } else {
            $('#dfFEI').remove();
        }
    }

    if (filtro_id == 'f11') {
        mos = $('#f11').is(':checked');
        if (mos) {
            $('<div id="dfFER" style="float:left;margin-left:10px;width:470px;height:20px;margin-top:5px;"><label class="miLabel">Fecha Ini. Rep. : </label><input type="text" class="txt" id="txtFIR" /><label class="miLabel">&nbsp;&nbsp;&nbsp; Fecha Fin. Rep. : </label><input type="text" class="txt" id="txtFFR" /></div>').appendTo('#divFiltros');
            $('#txtFIR').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false,
                onClose: function (selectedDate) {
                    $("#txtFFR").datepicker("option", "minDate", selectedDate);
                }
            });

            $('#txtFFR').datepicker({
                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
		    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
		        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Mi&eacute;rcoles', 'Jueves', 'Viernes', 'S&aacute;bado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mi&eacute;', 'Juv', 'Vie', 'S&aacute;b'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'S&aacute;'],
                dateFormat: 'dd/mm/yy',
                isRTL: false

            });
        } else {
            $('#dfFER').remove();
        }
    }

    if (filtro_id == 'f12') {
        mos = $('#f12').is(':checked');
        if (mos) {
            $('<div id="dftipo" style="float:left;margin-left:10px;width:210px;height:20px;margin-top:5px;"><label class="miLabel">Tipo : </label><select class="cbo" id="cboTipoFind"></select></div>').appendTo('#divFiltros');
            Get_Tipo();
        } else {
            $('#dftipo').remove();
        }
    }

    if (filtro_id == 'f13') {
        mos = $('#f13').is(':checked');
        if (mos) {
            $('<div id="dfsev" style="float:left;margin-left:10px;width:200px;height:20px;margin-top:5px;"><label class="miLabel">Severidad : </label><select class="cbo" id="cboSevFind"></select></div>').appendTo('#divFiltros');
            Get_Severidad();
        } else {
            $('#dfsev').remove();
        }
    }

    if (filtro_id == 'f14') {
        mos = $('#f14').is(':checked');
        if (mos) {
            $('<div id="dfsendg" style="float:left;margin-left:10px;width:220px;height:20px;margin-top:5px;"><label class="miLabel">Send Gerencia : </label><select class="cbo" id="cboSenGFind"><option value="">-TODOS-</option><option value="01">SI</option><option value="02">NO</option></select></div>').appendTo('#divFiltros');
        } else {
            $('#dfsendg').remove();
        }
    }

    if (filtro_id == 'f15') {
        mos = $('#f15').is(':checked');
        if (mos) {
            $('<div id="dforigen" style="float:left;margin-left:10px;width:270px;height:20px;margin-top:5px;"><label class="miLabel">Origen : </label><select class="cbo" id="cboOrigen"></select></div>').appendTo('#divFiltros');
            Get_Origen();
        } else {
            $('#dforigen').remove();
        }
    }

};




function Get_ViewCampos(campo_id) {
    var campo = '', display = '';
    switch (campo_id) {
        case 'v1': campo = 'R.Incidente_Id'; display = 'CODIGO'; break;
        case 'v2': campo = "P.Apellido_Paterno+' '+P.Apellido_Materno+', '+P.Nombres"; display = 'PERSONAL'; break;
        case 'v3': campo = 'L.Descripcion'; display = 'LOCALIDAD'; break;
        case 'v4': campo = 'CA.Descripcion'; display = 'AREA'; break;
        case 'v5': campo = "ISNULL(CA2.Descripcion,'NO ESPECIFICADO')"; display = 'SECCION'; break;
        case 'v6': campo = "CASE R.Actividad_Propia WHEN '01' THEN 'SI' ELSE 'NO' END"; display = 'ACT. PROPIA'; break;
        case 'v7': campo = "CASE R.Actividad_Rutinaria WHEN '01' THEN 'SI' ELSE 'NO' END"; display = 'ACT. RUTINARIA'; break;
        case 'v8': campo = 'I.Descripcion'; display = 'INTENSIDAD'; break;
        case 'v9': campo = 'R.Descripcion'; display = 'DESCRIPCION'; break;
        case 'v10': campo = "CASE R.Informar_Gerencia WHEN '01' THEN 'SI' ELSE 'NO' END"; display = 'INF. GERENCIA'; break;
        case 'v11': campo = "CASE R.Informar_Osigermin WHEN '01' THEN 'SI' ELSE 'NO' END"; display = 'INF. OSIGERMIN'; break;
        case 'v12': campo = 'CONVERT(VARCHAR, R.FechaHora_Incidente, 120) '; display = 'FECHA INCIDENTE'; break;
        case 'v13': campo = 'CONVERT(VARCHAR, R.FechaHora_Reporte, 120) '; display = 'FECHA REPORTE'; break;
        case 'v14': campo = 'R.Lugar_Incidente'; display = 'LUGAR'; break;
        case 'v15': campo = 'TI.Descripcion'; display = 'TIPO'; break;
        case 'v16': campo = 'S.Descripcion'; display = 'SEVERIDAD'; break;
        case 'v17': campo = 'LesionesPerdidas'; display = 'LESIONES'; break;
        case 'v18': campo = 'PosiblesCausas'; display = 'CAUSAS'; break;
        case 'v19': campo = 'AccionInmediata'; display = 'ACCION INMEDIATA'; break;
        case 'v20': campo = "CASE R.Estado_Id WHEN '01' THEN 'FINALIZADO' WHEN '03' THEN 'EN CURSO' WHEN '04' THEN 'REPORTADO' END"; display = 'ESTADO'; break;
        case 'v21': campo = "CASE R.SendMailGerencia WHEN '01' THEN 'ENVIADO' ELSE 'NO ENVIADO' END"; display = 'CORREO GERENCIA'; break;
        case 'v22': campo = "CASE R.SendPreliminar WHEN '01' THEN 'ENVIADO' ELSE 'NO ENVIADO' END"; display = 'OSIG. PRELIMINAR'; break;
        case 'v23': campo = "CASE R.SendFinal WHEN '01' THEN 'ENVIADO' ELSE 'NO ENVIADO' END"; display = 'OSIG. FINAL'; break;
        case 'v24': campo = 'ORI.Descripcion'; display = 'ORIGEN'; break;
        case 'v25': campo = 'ACO.Descripcion'; display = 'ACCIÓN'; break;
    }
    return campo + ' [' + display + '],#' + display;
};



function Get_Join(campo_id) {
    var join = '';
    switch (campo_id) {
        case 'v2': join = ' INNER JOIN Personal P ON R.Personal_Registro=P.Personal_Id '; break;
        case 'v3': join = ' INNER JOIN RH_Area L ON R.Area_Id=L.Area_Id ';break;
        case 'v4': join = ' INNER JOIN Categoria_Auxiliar CA ON R.Categoria_Auxiliar_Id=CA.Categoria_Auxiliar_Id '; break;
        case 'v5': join = ' LEFT JOIN Categoria_Auxiliar2 CA2 ON R.Categoria_Auxiliar2_Id=CA2.Categoria_Auxiliar2_Id '; break;
        case 'v8': join = ' INNER JOIN Intensidad I ON R.Intensidad_Id=I.Intensidad_Id '; break;
        case 'v15': join = ' INNER JOIN Tipo TI ON R.Tipo=TI.Tipo_Id '; break;
        case 'v16': join = ' INNER JOIN Severidad S ON R.Severidad_Id=S.Severidad_Id '; break;
        case 'v24': join = ' INNER JOIN Origen ORI ON R.Origen=ORI.Origen_Id '; break;
        case 'v25': join = ' LEFT JOIN AccionCorrectiva ACO ON R.Incidente_Id=ACO.Incidente_Id '; break;
        
    }
    return join;
};

function Get_Where(campo_id, valor) {
    var where = '';
    var fi = '', ff = '';
    if (valor.indexOf('#') != -1) {
        fi = valor.split('#')[0];
        ff = valor.split('#')[1];
    }

    switch (campo_id) {
        case 'f1': where = " UPPER(P.Apellido_Paterno)+UPPER(P.Apellido_Materno)+' '+UPPER(P.Nombres) LIKE '%" + valor.toUpperCase() + "%' "; break;
        case 'f2': where = " R.Area_Id='" + valor + "'"; break;
        case 'f3': where = " R.Categoria_Auxiliar_Id='" + valor + "' "; break;
        case 'f4': where = " R.Categoria_Auxiliar2_Id='" + valor + "' "; break;
        case 'f5': where = " R.Actividad_Propia='" + valor + "' "; break;
        case 'f6': where = " R.Actividad_Rutinaria='" + valor + "' "; break;
        case 'f7': where = " R.Intensidad_Id='" + valor + "' "; break;
        case 'f8': where = " R.Informar_Gerencia='" + valor + "' "; break;
        case 'f9': where = " R.Informar_Osigermin='" + valor + "' "; break;
        case 'f10': where = " R.FechaHora_Incidente BETWEEN '" + formatFecha.ymd(fi) + "' AND '" + formatFecha.ymd(ff) + ' 23:59:00.000' + "' "; break;
        case 'f11': where = " R.FechaHora_Reporte BETWEEN '" + formatFecha.ymd(fi) + "' AND '" + formatFecha.ymd(ff) + ' 23:59:00.000' + "' "; break;
        case 'f12': where = " R.Tipo='" + valor + "'"; break;
        case 'f13': where = " R.Severidad_Id='" + valor + "' "; break;
        case 'f14': where = " R.Informar_Gerencia='" + valor + "' "; break;
        case 'f15': where = " R.Origen='" + valor + "' "; break;
    }
    return where + ' AND';

};










//CARGAR FILTROS


function Get_Localidad() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Localidad",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboLocalidadFind').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboLocalidadFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Area_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboLocalidadFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Categoria_Auxiliar() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Categoria_Auxiliar",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCatFind').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboCatFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCatFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Categoria_Auxiliar2() {
    var Cate1 = '';
    var  mos = $('#f3').is(':checked');
    if (mos) {
        Cate1 = $('#cboCatFind').val();        
    } else {
        Cate1 = '';
    }


    var params = {
        Cate1: Cate1
    };


    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "rHistorial.aspx/Get_Categoria_Auxiliar2",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboCat2Find').html('');
            $('<option value="">SIN ESPECIFICAR</option>').appendTo('#cboCat2Find');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Categoria_Auxiliar2_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboCat2Find');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};




function Get_Intensidad() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Intensidad",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboIntFind').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboIntFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Intensidad_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboIntFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


function Get_Severidad() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Severidad",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboSevFind').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboSevFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Severidad_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboSevFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};



function Get_Tipo() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Tipo",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboTipoFind').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboTipoFind');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Tipo_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboTipoFind');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};

function Get_Origen() {

    $.ajax({
        type: "POST",

        dataType: "json",
        url: "rHistorial.aspx/Get_Origen",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Datos = response.d;
            var lengthD = Datos.length - 1;
            $('#cboOrigen').html('');
            $('<option value="">-TODOS-</option>').appendTo('#cboOrigen');
            for (var i = 0; i <= lengthD; i++) {
                $('<option value="' + Datos[i].Origen_Id + '">' + Datos[i].Descripcion + '</option>').appendTo('#cboOrigen');
            }
        },
        error:
                function (XmlHttpError, error, description) {
                    $("#divError").html(XmlHttpError.responseText);
                },
        async: false
    });
};


//ADD ARRAY AND REMOVE




Array.prototype.add = function (newIntem) {
    var lengthA = this.length - 1;
    var existe = false;
    for (var i = 0; i <= lengthA; i++) {
        if (this[i] == newIntem) {
            existe = true;
        }
    }
    if (!existe) {
        this.push(newIntem);
    }
};


Array.prototype.remov = function (remIntem) {
    var lengthA = this.length - 1;
    var existe = false;
    for (var i = 0; i <= lengthA; i++) {
        if (this[i] == remIntem) {
            this.splice(i, 1);
        }
    }

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




function SendMail_SMTP(emailDestino, Asunto, HTMLcont) {
    var params = {
        emailDestino: emailDestino,
        Asunto: Asunto,
        HTMLcont: HTMLcont
    };

    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        dataType: "json",
        url: "rHistorial.aspx/SendMail_SMTP",
        contentType: "application/json; chartseft:utf-8",
        success: function (response) {
            var Proceso = response.d;
            if (Proceso) {
                if (Proceso.indexOf('#') != -1) {
                    var Resultado = Proceso.split('#')[0];
                    var mensaje = Proceso.split('#')[1];
                    if (Resultado == 'true') {
                        alert(mensaje);
                        $('#dialog-SendEmail').dialog('close');
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