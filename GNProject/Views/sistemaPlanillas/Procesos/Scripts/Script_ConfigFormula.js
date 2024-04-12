/*
 * @001 FPS 05/10/2021 - Se agregan variables de personal
 * @002 FPS 28/01/2023, Se agrega variables de nacimiento de personal
*/

function ConfigFormulaGetProcesosSelect() {
    $.ajax({
        type: "POST",
        url: 'configFormula.aspx/ConfigFormulaGetProcesosSelect',
        contentType: "application/json; chartseft:utf-8",
        //data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboProcesoFind').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i].Proceso_Id + '">' + datos[i].Proceso + '</>').appendTo('#cboProcesoFind');
            }
            $('<option value="0">-TODOS-</>').appendTo('#cboProcesoFind');
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });
};
function ConfigFormulaGetFormulasPlanillaList() {
    var pagePath = window.location.pathname;
    var urlajax = pagePath + '/ConfigFormulaGetFormulasPlanillaList';
    var Planilla = document.getElementById('planillaSession').value, Proceso = $('#cboProcesoFind').val(), FormulaFind = $('#txtFormulaFind').val();
    if (!Planilla) {
        setTimeout(function () { ConfigFormulaGetFormulasPlanillaList(); }, 1000);
        return false;
    }
    if (Proceso == null) {
        setTimeout(function () { ConfigFormulaGetFormulasPlanillaList(); }, 1000);
        return false;
    }
    var params = {
        Planilla: Planilla,
        Proceso: Proceso,
        FormulaFind: FormulaFind
    };
    $.ajax({
        type: "POST",
        url: urlajax,
        contentType: "application/json; chartseft:utf-8",
        data: JSON.stringify(params),
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#tbodyFormula').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                var stycolor = '', color = '';
                var proc = datos[i].Proceso_Id;
                switch (proc) {
                    case '01': stycolor = ' style="background-color:#FF0000;color:#000000;"'; color = 'background-color:#FF0000;color:#000000;'; break;
                    case '02': stycolor = ' style="background-color:#FFA500;color:#000000;"'; color = 'background-color:#FFA500;color:#000000;'; break;
                    case '03': stycolor = ' style="background-color:#FFFF00;color:#000000;"'; color = 'background-color:#FFFF00;color:#000000;'; break;
                    case '04': stycolor = ' style="background-color:#32CD32;color:#000000;"'; color = 'background-color:#32CD32;color:#000000;'; break;
                    case '05': stycolor = ' style="background-color:#2F4F4F;color:#000000;"'; color = 'background-color:#2F4F4F;color:#000000;'; break;
                    case '06': stycolor = ' style="background-color:#663399;color:#000000;"'; color = 'background-color:#663399;color:#000000;'; break;
                    case '07': stycolor = ' style="background-color:#7EC0EE;color:#000000;"'; color = 'background-color:#7EC0EE;color:#000000;'; break;
                    case '08': stycolor = ' style="background-color:#00FF00;color:#000000;"'; color = 'background-color:#00FF00;color:#000000;'; break;                    
                }
                var html = '<tr>';
                html += '<td style="text-align:center;"><input type="button" class="linkEditar" id="' + datos[i].Formula_Id + '" /><input type="button" class="linkEliminar" /></td>';
                html += '<td style="text-align:center;' + color + '">' + datos[i].Nro + '</td>';
                html += '<td' + stycolor + '>' + datos[i].Descripcion + '</td>';
                html += '<td' + stycolor + '>' + datos[i].Proceso + '</td>';
                html += '<td style="text-align:center;' + color + '">' + datos[i].Fecha_Modif + '</td>';
                //html += '<td>' + datos[i].Estado_Id + '</td>';
                html += '</tr>';
                $(html).appendTo('#tbodyFormula');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });
};
function ConfigFormulaGetConceptosList() {
    $.ajax({
        type: "POST",
        url: 'configFormula.aspx/ConfigFormulaGetConceptosList',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboConcepto').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i].Concepto_Id + '">' + datos[i].Descripcion + '</>').appendTo('#cboConcepto');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });
};
function ConfigFormulaGetProcesoFuenteList() {
    $.ajax({
        type: "POST",
        url: 'configFormula.aspx/ConfigFormulaGetProcesoFuenteList',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#cboConcepto').html('');
            for (var i = 0; i <= datos.length - 1; i++) {
                $('<option value="' + datos[i].Proceso_Id + '">' + datos[i].Proceso + '</>').appendTo('#cboProcesoFuente');
                $('<option value="' + datos[i].Proceso_Id + '">' + datos[i].Proceso + '</>').appendTo('#cboProceso');
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });
}
function ConfigFormulaGetMaxPosicionFormula() {
    var PlanillaCod = document.getElementById('empresaSession').value;
    if (!PlanillaCod) {
        setTimeout(function () { ConfigFormulaGetMaxPosicionFormula(); }, 1000);
        return false;
    }
    var params = {
        PlanillaCod: PlanillaCod
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: 'configFormula.aspx/ConfigFormulaGetMaxPosicionFormula',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            $('#txtNroForm').val('');
            $('#txtNroForm').val(datos);
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: true
    });
}
function ConfigFormulaGetValidarFormula() {
    var valido = null;
    var expression = $('#txtFormula').val();
    var params = {
        expression: expression.toUpperCase()
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: 'configFormula.aspx/ConfigFormulaGetValidarFormula',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            valido = datos;
            $('#lblErrorFormula').html('');
            if (!datos) {
                $('#txtFormula').focus();
                alert('Fórmula invalida');
                $('#lblErrorFormula').html('Fórmula invalida');
            } else {
                $('#lblErrorFormula').html('Fórmula valida');
            }

        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
    return valido;
}
function ConfigFormulaGetValidarCondicion() {
    var valido = null;
    var expression = $('#txtCodicion').val();
    if (expression.trim() == '') {
        $('#lblErrorCondicion').html('');
        return true;
    }
    var params = {
        expression: expression
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: 'configFormula.aspx/ConfigFormulaGetValidarFormula',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            valido = datos;
            $('#lblErrorCondicion').html('');
            if (!datos) {
                $('#txtFormula').focus();
                alert('Condición invalida');
                $('#lblErrorCondicion').html('Condición invalida');
            } else {
                $('#lblErrorCondicion').html('Condición valida');
            }

        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
    return valido;
}
function ConfigFormulaGetLoadConceptosTreeView() {
    $('#tree').html('');
    var TipoConceptoArr = [];

    $.ajax({
        type: "POST",
        url: 'configFormula.aspx/ConfigFormulaGetTipoConceptosList',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            TipoConceptoArr = datos;
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
    
    for (var i = 0; i <= TipoConceptoArr.length - 1; i++) {
        var html = '<li><div class="hitarea expandable-hitarea"></div><span>' + TipoConceptoArr[i].Tipo_Concepto + '</span>';        
        var Tipo = TipoConceptoArr[i].TC_Id;
        var params = {
            Tipo: Tipo
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(params),
            url: 'configFormula.aspx/ConfigFormulaGetConceptosByTipoList',
            contentType: "application/json; chartseft:utf-8",
            dataType: "json",
            success: function (response) {
                var datosSub = response.d;
                html += '<ul style="display: none;">';
                for (var l = 0; l <= datosSub.length - 1; l++) {
                    html += '<li style="cursor:pointer"><span onclick="addtext(this)">' + datosSub[l].Descripcion + '</span></li>';
                }
                html += '</ul>';
            },
            error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
            async: false
        });
        
        html += '</li>';
        $(html).appendTo('#tree');
    }
   
    for (var a = 0; a <= TipoConceptoArr.length - 1; a++) {
        if (TipoConceptoArr[a].TC_Id == '04') {
            
            var html = '<li><div class="hitarea expandable-hitarea"></div><span>ACUMULADOS</span>';
            var Tipo = TipoConceptoArr[a].TC_Id;
            var params2 = {
                Tipo: Tipo
            };
            $.ajax({
                type: "POST",
                data: JSON.stringify(params2),
                url: 'configFormula.aspx/ConfigFormulaGetConceptosByTipoList',
                contentType: "application/json; chartseft:utf-8",
                dataType: "json",
                success: function (response) {
                    var datosSub = response.d;
                    html += '<ul style="display: none;">';
                    for (var l = 0; l <= datosSub.length - 1; l++) {
                        html += '<li style="cursor:pointer"><span onclick="addtext(this)">A' + datosSub[l].Descripcion + '</span></li>';
                    }
                    html += '</ul>';
                },
                error:
                     function (XmlHttpError, error, description) {
                         $("#divError").html(XmlHttpError.responseText);
                     },
                async: false
            });


            html += '</li>';
            $(html).appendTo('#tree');
        }
    }
    var htmlOther=''
    htmlOther+="<li><div class='hitarea expandable-hitarea'></div><span>FICHA DE PERSONAL</span>";
    htmlOther+="<ul style='display: none;'>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_CATEGORIA_PERSONAL</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_DOMICILIADO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_REGIMEN_LABORAL</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_REGIMEN_PENSIONARIO</span></li>"; //@001 I/F
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFECHA_INGRESO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFECHA_CESE</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFDIA_INGRESO</span></li>";
    htmlOther+="<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFANO_INGRESO</span></li>";
    htmlOther+="<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFMES_INGRESO</span></li>";
    htmlOther+="<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFDIA_CESE</span></li>";
    htmlOther+="<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFMES_CESE</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFANO_CESE</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_PDIAS_CALENDARIOS</span></li>";
    //@002 I
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFECHA_NACIMIENTO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFDIA_NACIMIENTO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFMES_NACIMIENTO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PERFANO_NACIMIENTO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_TOTAL_DIAS_NACIMIENTO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_PEREDAD</span></li>";
    //@002 F
    htmlOther+="</ul>";
    htmlOther += "</li>";

    htmlOther += "<li><div class='hitarea expandable-hitarea'></div><span>DATOS VACACION</span>";
    htmlOther += "<ul style='display: none;'>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_DIAS_VACA</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_DSALDO_VAC</span></li>"; //20211117
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_DINDEMNIZACION_VAC</span></li>"; //20211117
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_SALDO_VAC_PERIODOS_ANTERIORES</span></li>"; //20220504
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_SALDO_VAC_TRUNCA</span></li>"; //20220504
    htmlOther += "</ul>";
    htmlOther += "</li>";

    htmlOther += "<li class='last'><div class='hitarea expandable-hitarea'></div><span>CUENTAS CORRIENTES</span>";
    htmlOther += "<ul style='display: none;'>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>IF_DESCUENTO_CTACTE</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>IF_DESCUENTO_TELEFONIA</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>IF_PRESTAMO_BANCARIO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>IF_PRESTAMO_CTACTE</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>IF_TOTAL_CTACTES</span></li>";
    htmlOther += "</ul>";
    htmlOther += "</li>";


    /*+++++ QUINCENA +++++*/
    htmlOther += "<li><div class='hitarea expandable-hitarea'></div><span>PLANILLA SEMANAL</span>";
    htmlOther += "<ul style='display: none;'>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_TOTAL_ADELANTO_SEMANAS</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_CANT_DIAS_PERIODO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_TOTAL_DIAS_PERIODO</span></li>";
    htmlOther += "<li style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_INI_PERIODO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_FIN_PERIODO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_PAGAR_BENEF_SOCIALES_PERIODO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_INI_PERIODO_DIA</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_INI_PERIODO_MES</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_INI_PERIODO_ANIO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_FIN_PERIODO_DIA</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_FIN_PERIODO_MES</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_FECHA_FIN_PERIODO_ANIO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_CTS_ACUMULADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_VAC_ACUMULADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_GRAT_ACUMULADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_ESSALUD_GRAT_ACUMULADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_CTS_PAGADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_VAC_PAGADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_GRAT_PAGADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_VAC_GOZADA_ACUMULADO</span></li>";
    htmlOther += "<li class='last' style='cursor:pointer'><span onclick='addtext(this)'>T_LBS_ESSALUD_GRAT_PAGADO</span></li>";
    htmlOther += "</ul>";
    htmlOther += "</li>";

    $(htmlOther).appendTo('#tree');
    $('#tree').treeview({ collapsed: true,
        animated: 'fast',
        control: '#sidetreecontrol',
        prerendered: true,
        persist: 'location'
    });
}
var Object_Proc = '';
function ConfigFormulaProcInsertFormula() {
    var ProcesaBound = true;
    var Concepto_Id = $('#cboConcepto').val(), Planilla_Id = document.getElementById('planillaSession').value
    , Nro = parseInt($('#txtNroForm').val()), Formula_texto = $('#txtFormula').val()
    , Formula_condicion = $('#txtCodicion').val(), Fuente_Proceso_Id = $('#cboProcesoFuente').val()
    , ChangeLastNro = true, Proceso_Id = $('#cboProceso').val();
    $('#lblError').html('');
    if (!Concepto_Id) {
        $('#lblError').html('.::Concepto no definido.');
        $('#cboConcepto').focus();
        ProcesaBound = false;
        return false;
    }
    if (!Planilla_Id) {
        $('#lblError').html('.::Planilla no definida.');
        document.getElementById('planillaSession').focus;
        ProcesaBound = false;
        return false;
    }
    if (!Fuente_Proceso_Id) {
        $('#lblError').html('.::Proceso fuente no definida.');
        $('#cboProcesoFuente').focus();
        ProcesaBound = false;
        return false;
    }
    if (!Proceso_Id) {
        $('#lblError').html('.::Proceso no definido.');
        $('#cboProceso').focus();
        ProcesaBound = false;
        return false;
    }
    if (!Nro) {
        $('#lblError').html('.::Número no definido.');
        $('#txtNroForm').focus();
        ProcesaBound = false;
        return false;
    }
    if (isNaN(Nro)) {
        $('#lblError').html('.::No es un número.');
        $('#txtNroForm').focus();
        ProcesaBound = false;
        return false;
    }
    if (!Formula_texto) {
        $('#lblError').html('.::Fórmula no definida');
        $('#txtFormula').focus();
        ProcesaBound = false;
        return false;
    }
    if (!ConfigFormulaGetValidarFormula()) {
        ProcesaBound = false;
        return false;
    }
    if (!ConfigFormulaGetValidarCondicion()) {
        ProcesaBound = false;
        return false;
    }


    if (ProcesaBound) {
        if (confirm('¿Está seguro de continuar?')) {
            if (Object_Proc == '') {
                var params = {
                    Concepto_Id: Concepto_Id
                    , Planilla_Id: Planilla_Id
                    , Nro: Nro
                    , Formula_texto: Formula_texto.toUpperCase()
                    , Formula_condicion: Formula_condicion.toUpperCase()
                    , Fuente_Proceso_Id: Fuente_Proceso_Id
                    , ChangeLastNro: ChangeLastNro
                    , Proceso_Id: Proceso_Id
                };
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(params),
                    url: 'configFormula.aspx/ConfigFormulaProcInsertFormula',
                    contentType: "application/json; chartseft:utf-8",
                    dataType: "json",
                    success: function (response) {
                        var datos = response.d;
                        if (datos) {
                            var trufa = datos.split('#')[0];
                            var mesaje = datos.split('#')[1];
                            if (trufa == 'true') {
                                $('#TabContainer').tabs('option', 'active', 0);
                                clearConifurarFormula();
                                ConfigFormulaGetFormulasPlanillaList();
                                alert(mesaje);
                            } else {
                                alert(mesaje);
                            }
                        }

                    },
                    error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
                    async: false
                });
            } else {
                var params = {
                    Formula_Id: Object_Proc
                    , Concepto_Id: Concepto_Id
                    , Planilla_Id: Planilla_Id
                    , Nro: Nro
                    , Formula_texto: Formula_texto.toUpperCase()
                    , Formula_condicion: Formula_condicion.toUpperCase()
                    , Fuente_Proceso_Id: Fuente_Proceso_Id
                    , ChangeLastNro: ChangeLastNro
                    , Proceso_Id: Proceso_Id
                };
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(params),
                    url: 'configFormula.aspx/ConfigFormulaProcUpdateFormula',
                    contentType: "application/json; chartseft:utf-8",
                    dataType: "json",
                    success: function (response) {
                        var datos = response.d;
                        if (datos) {
                            var trufa = datos.split('#')[0];
                            var mesaje = datos.split('#')[1];
                            if (trufa == 'true') {
                                $('#TabContainer').tabs('option', 'active', 0);
                                clearConifurarFormula();
                                ConfigFormulaGetFormulasPlanillaList();
                                alert(mesaje);
                            } else {
                                alert(mesaje);
                            }
                        }

                    },
                    error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
                    async: false
                });
            } 
        }
    }
};
function addtext(sel) {
    var valor = $('#txtFormula').val() + $(sel).html();
    $('#txtFormula').val(valor);
};

function ConfigFormulaGetFormulaFind(FormulaID) {
    var params = {
        FormulaID: FormulaID
    };
    $.ajax({
        type: "POST",
        data: JSON.stringify(params),
        url: 'configFormula.aspx/ConfigFormulaGetFormulaFind',
        contentType: "application/json; chartseft:utf-8",
        dataType: "json",
        success: function (response) {
            var datos = response.d;
            if (datos) {
                $('#cboConcepto').val(datos.Concepto_Id);
                $('#cboProcesoFuente').val(datos.Fuente_Proceso_Id);
                $('#cboProceso').val(datos.Proceso_Id);
                $('#txtNroForm').val(datos.Nro);
                $('#txtFormula').val(datos.Formula_texto);
                $('#txtCodicion').val(datos.Formula_condicion);
                Object_Proc = datos.Formula_Id;
                $('#TabContainer').tabs('option', 'active', 1);
            } else {
                Object_Proc = '';
            }
        },
        error:
         function (XmlHttpError, error, description) {
             $("#divError").html(XmlHttpError.responseText);
         },
        async: false
    });
}
function clearConifurarFormula() {
    $('#cboConcepto').val('');
    $('#txtNroForm').val('');
    $('#txtFormula').val('');
    $('#txtCodicion').val('');
    $('#cboProcesoFuente').val('');
    $('#cboProceso').val('');
    $('#lblError').html('');
    $('#lblErrorFormula').html('');
    $('#lblErrorCondicion').html('');
}

function cargarConceptos() {
    if ($('#cboConcepto option').length == 0) {
        ConfigFormulaGetConceptosList();
        setTimeout(function () {
            cargarConceptos();
        }, 3000);       
    }
}
function initilize() {
    $('#TabContainer').tabs();
    ConfigFormulaGetProcesosSelect();
    ConfigFormulaGetFormulasPlanillaList();
    ConfigFormulaGetConceptosList();
    ConfigFormulaGetProcesoFuenteList();
    ConfigFormulaGetMaxPosicionFormula();
    ConfigFormulaGetLoadConceptosTreeView();
    cargarConceptos();
    $('#ctl00_ucFiltros1_cboPlanilla').change(function () {
        if (Object_Proc != '') {
            clearConifurarFormula();
            $('#TabContainer').tabs('option', 'active', 0);
        }
        ConfigFormulaGetFormulasPlanillaList();
    });
    $('#cboProcesoFind').change(function () {
        ConfigFormulaGetFormulasPlanillaList();
    });
    $('#txtFormulaFind').keyup(function () {
        ConfigFormulaGetFormulasPlanillaList();
    });
    $('#btnValidarFormula').click(function () {
        ConfigFormulaGetValidarFormula();
        ConfigFormulaGetValidarCondicion();
    });
    $('#btnGuardarForm').click(function () {
        ConfigFormulaProcInsertFormula();
    });
    $('#btnNewConfig').click(function () {
        clearConifurarFormula();
        $('#TabContainer').tabs('option', 'active', 1);
    });
    $('#btnCancelConfig').click(function () {
        clearConifurarFormula();
        $('#TabContainer').tabs('option', 'active', 0);
    });
    $('#tbodyFormula').on('click', '.linkEditar', function () {
        $('#lblError').html('');
        $('#lblErrorFormula').html('');
        $('#lblErrorCondicion').html('');
        ConfigFormulaGetFormulaFind(this.id);
    });
};
