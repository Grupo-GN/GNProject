<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sPasarPlanilla.aspx.cs" Inherits="GNProject.Views.ControlAsisten.CA.caPasarPlanilla.sPasarPlanilla" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../../jqueryui/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../../css/cssHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cssTablas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/EstiloBarraHerramientas.css" rel="stylesheet" type="text/css" />
    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />

<table class="tableDialog">
        <tr>
            <td style="text-align:right;"><label class="miLabel">Planilla : </label></td>
            <td><select class="cbo" id="cboPlanilla"></select></td>
            <td style="text-align:right;"><label class="miLabel">Periodo : </label></td>
            <td><select class="cbo" id="cboPeriodo"></select></td>
            <td style="text-align:right;"><label class="miLabel">Localidad : </label></td>
            <td><select class="cbo" id="cboLocalidad"></select></td>
        </tr>
        <tr>
            <td style="text-align:right;"><label class="miLabel">Area : </label></td>
            <td><select class="cbo" id="cboCatAux"></select></td>
            <td style="text-align:right;"><label class="miLabel">Categoria : </label></td>
            <td><select class="cbo" id="cboCategoria"></select></td>
            <td style="text-align:right;"><label class="miLabel">Personal : </label></td>
            <td><select class="cbo" id="cboPersonal"></select></td>
        </tr>
       <tr>
            <td style="text-align:right;"><label class="miLabel">Fecha Inicio : </label></td>
            <td><input type="text" class="txt" id="txtFechaInicio" /></td>
            <td style="text-align:right;"><label class="miLabel">Fecha Final : </label></td>
            <td><input type="text" class="txt"  id="txtFechaFinal"/></td>
            <td style="text-align:right;"><label class="miLabel">semana : </label></td>
            <td><select class="cbo" id="cbosemana"></select></td>
        </tr>
        <tr>
            <td colspan="4"><input type="button" class="buttonHer" value="GENERAR" id="btnGenerar" /> <input type="button" class="buttonHer" value="PASAR" id="btnseleccionar"  /> <input type="button" class="buttonHer" value="REPLICAR DATOS" id="btnreplicar"  />
                <input type="button" class="buttonHer" value="EXPORTAR EXCEL" id="btnExportar"  />
            </td>            

            <td></td>
            <td></td>
        </tr>
    </table>
    <br />
    <label class="labelError" id="lblError" ></label>
    <table class="table" id="TblPasarPlanilla">
        <thead>
            <tr>
                <th colspan="17" style="background-color:Green;">CONTROL DE ASISTENCIA</th>
                <th colspan="5" style="background-color:Orange ;">EN PLANILLA</th>
                <th colspan="3" style="background-color:Silver;">PERSONAL</th>
            </tr>
            <tr>
                <th><input type="checkbox" id="chkAll" /></th>
                <th>PLANILLA</th>
                <th>LOCALIDAD</th>
                <th>PERSONAL</th>
                <th>H.E. TOT.</th>
                <th>H.E. SIMP.</th>
                <th>H.E. ADI.</th>
                <th>H.E. DOB.</th>
                <th>FALT.</th>
                <th>TARD.</th>
               <%-- <th>DIAS PERM.</th>--%>
                <th>DIAS PERM DESCANSO MED.</th>
                <th>DIAS PERM PERSONAL</th>
                <th>DIAS PERM VAC</th>
                <th>HORAS PERM.</th>
                  <th>PERM. SIN GOCE</th>
                <th>DOMINICAL</th>
                 <th>T.ASIS</th>
                 <th>COMPENSA</th>
                <th>H. SIMP.</th>
                <th>H. ADI.</th>
                <th>H. DOB.</th>
                <th>FALT.</th>
                <th>TARD.</th>
                <th>PERIODO</th>
                <th>AREA</th>
                <th>SECCION</th>
            </tr>
        </thead>
        <tbody id="tbodyNovedades"></tbody>
    </table>

    
   <div id="dialog-form"
        style="font-size: x-small; font-family: AENOR Fontana ND;width:100%;">
      
       <fieldset style=" width: 100%;">
        <div id="HeaderDiv" style="overflow: auto; width: 100%; border: solid 1px #505050; height: 360px;">
              <table class="borde" style=" width: 100%;">
            <tr>
                <td align="center" class="titulo" colspan="4">
                    <label class="tituloModal">Mantenimiento de Parametros x Concepto</label>
                </td>
            </tr>
        </table>
            <table id="tblParametros" class="table">

                <thead class="theadth">
                    <tr>
                        <th><input type="checkbox" id="chkAll1" /></th>
                        <th class="theadth" scope="col" style="display:none;">Control_Id</th>
                        <th class="theadth" scope="col">abrev</th>
                        <th class="theadth" scope="col">Concepto</th>
                        <th class="theadth" scope="col">Parametro</th>
                        <th class="theadth" scope="col">Estado</th>
                         <th class="theadth" scope="col">semana</th>
                    </tr>
                </thead>

                <tbody class="tbody" id="tbodyParametros">
                </tbody>

            </table>
             
        </div>
     <table class="borde" style=" width: 100%;">
           <tr>
             <td colspan="4"><input type="button" class="buttonHer" value="GRABAR" id="btnPasarNovedades" />
                  <input type="button" class="buttonHer" value="CANCELAR" id="btncancelar" /></td>            
                 
            </tr>
        </table>
         

    </fieldset>

         

        <label id="lblCodigSeleccionao"></label>

    </div>




    <div id="dialog-form01"
        style="font-size: x-small; font-family: AENOR Fontana ND;width:100%;">
      
       <fieldset style=" width: 100%;">
        <div id="HeaderDiv01" style="overflow: auto; width: 100%; border: solid 1px #505050; height: 360px;">
              <table class="borde" style=" width: 100%;">
            <tr>
                <td align="center" class="titulo" colspan="4">
                    <label class="tituloModal">REPLICAR DATOS EN TABLA</label>
                </td>
            </tr>
        </table>
            <table id="tblreplica" class="table">

                <thead class="theadth">
                    <tr>
                      
                        <th class="theadth" scope="col">HE.SIMPLE</th>
                        <th class="theadth" scope="col">HE.ADISIONAL</th>
                        <th class="theadth" scope="col">HE.DOBLE</th>
                        <th class="theadth" scope="col">FALTA</th>
                        <th class="theadth" scope="col">TARDANZA</th>
                         <th class="theadth" scope="col">DESCANSO MEDICO</th>
                         <th class="theadth" scope="col">PERM.PERSONAL</th>
                         <th class="theadth" scope="col">HORAS PERMISO</th>
                         <th class="theadth" scope="col">DOMINICAL</th>
                         <th class="theadth" scope="col">T.ASIS</th>
                         <th class="theadth" scope="col">COMPENSA</th>

                    </tr>
                </thead>

                <tbody class="tbody" id="tbodyreplica">
                    <tr>
                        <td style="text-align:center;"><input type="text" id="txthesimple" class="txt" value="00:00" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtheadi" class="txt" value="00:00" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txthedoble" class="txt" value="00:00" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtfalta" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txttarde" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtdesmedico" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtpermpersonal" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txthoraspermiso" class="txt" value="0.00" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtdominical" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtasistencia" class="txt" value="0" style="width:100%;" /></td>
                        <td style="text-align:center;"><input type="text" id="txtcompensa" class="txt" value="0" style="width:100%;" /></td>
                    </tr>
                </tbody>

            </table>
             
        </div>
     <table class="borde" style=" width: 100%;">
           <tr>
             <td colspan="4"><input type="button" class="buttonHer" value="REPLICAR" id="btnreplica" />
                  <input type="button" class="buttonHer" value="CANCELAR" id="btncancel" /></td>            
                 
            </tr>
        </table>
         

    </fieldset>

 

    </div>





    <link href="../../css/StyleWilder.css" rel="stylesheet" type="text/css" />
    <script src="../../jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../jsExportExcel/ScriptExportarExcel.js"></script>
    <script src="../../jqueryui/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Script_PasarPlanilla.js" type="text/javascript"></script>

  <script type="text/javascript">
      var Personal_IdG = '<%= Session["Usuario_Id"] %>';
      var PersonalArr = [];
      var Errores = 0;
      var Correctos = 0;
      $(document).ready(function () {
          Personal_IdG = '<%= Session["Usuario_Id"] %>';
          //if (!Personal_IdG) {
          //    setTimeout('window.location="../Justificacion/Acceso.aspx"', 50);
          //}
          //if (Personal_IdG != '000454' && Personal_IdG != '000000') {
          //    setTimeout('window.location="../Justificacion/Acceso.aspx"', 50);
          //}
          //Menu_RecursosHumanos();
          $('#dialog-form').css('display', 'none');
          $('#dialog-form01').css('display', 'none');
          Get_Planilla_List();
          Get_semana_List();
          Get_Periodo_List(Get_Planilla_Find());
          Get_Localidad_List();
          Get_CategoriaAux_List();
          Get_Categoria_List();
          Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
          CrearCuadroFechas();
          Get_PeriodoCA_By_Planilla(Get_Periodo_Find());
          $('#cboPlanilla').change(function () {
              Get_Periodo_List(Get_Planilla_Find());
              Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
          });
          $('#cboPeriodo').change(function () {
              Get_PeriodoCA_By_Planilla($(this).val());
          });

          //Get_PeriodoCA_By_Planilla($(this).val());

          $('#cboLocalidad').change(function () {
              Get_Periodo_List(Get_Planilla_Find());
              Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
          });

          $('#cboCatAux').change(function () {
              Get_Periodo_List(Get_Planilla_Find());
              Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
          });

          $('#cboCategoria').change(function () {
              Get_Periodo_List(Get_Planilla_Find());
              Get_Personal_List(Get_Periodo_Find(), Get_Localidad_Find(), Get_CateAux_Find(), Get_Categoria_Find());
          });

          $('#cboPersonal').change(function () {
              PersonalArr = [];
              PersonalArr.push($(this).val());
          });
          //Get_NovedadesPasarPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalArr);
          Get_NovedadesPasarPlanilla2(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalArr, $('#txtFechaInicio').val(), $('#txtFechaFinal').val());
          $('#btnGenerar').click(function () {
              var FechaInicio = $('#txtFechaInicio').val();
              var FechaFinal = $('#txtFechaFinal').val();
              Get_NovedadesPasarPlanilla2(Get_Planilla_Find(), Get_Periodo_Find(), Get_Localidad_Find(), PersonalArr, FechaInicio, FechaFinal);
          });

          //$('#chkAll').click(function () {
          //    var c = this.checked;
          //    $(':checkbox').prop('checked', c);
          //});

          //$('#chkAll1').click(function () {
          //    var c = this.checked;
          //    $(':checkbox').prop('checked', c);
          //});

          $('#chkAll').change(function () {
              $('#tbodyNovedades input[type="checkbox"]').prop('checked', $(this).prop('checked'));
          });

          $('#chkAll1').change(function () {
              $('#tbodyParametros input[type="checkbox"]').prop('checked', $(this).prop('checked'));
          });

          $('#tbodyNovedades').on('keypress', '.txt', function () {
              $(this).css('background-color', 'White');
          });

          $('#btnseleccionar').click(function () {
              var selec = $('#cbosemana').val();
              if (selec=='') {
                  alert('SELECCIONE UNA SEMANA');
                  $('#cbosemana').focus();
                  return false;
              }
              Get_Parametros_List(selec);
              pasaModal();
          });
          $('#btncancelar').click(function () {
              closeModalDiv();
          });

          $('#btnPasarNovedades').click(function () {
              if (confirm('¿Esta seguro de continuar?')) {

                  var cant = $('#tbodyNovedades input:checkbox:checked').length;
                  if (cant == 0) {
                      alert('.::Error > No a seleccionado a ningun personal.');
                      return false;
                  }

                  $('#lblError').html(' ');
                  Errores = 0;
                  Correctos = 0;
                  var mostr = true;
                  $('#tbodyNovedades input:checkbox:checked').each(function () {
                      var personal_id = this.id.substring(3);
                      var hesimp = $('#s' + personal_id).val();
                      var headi = $('#a' + personal_id).val();
                      var hedob = $('#d' + personal_id).val();
                      var hefalt = $('#f' + personal_id).val();
                      var hetar = $('#t' + personal_id).val();

                      var per_desmed = $('#per_desmed' + personal_id).val();
                      var per_perdia = $('#per_perdia' + personal_id).val();
                      var horaspermiso = $('#hp' + personal_id).val();
                      var domingo = $('#do' + personal_id).val();
                      var asist = $('#as' + personal_id).val();
                      var comp = $('#cp' + personal_id).val();
                      var psingoce = $('#ps' + personal_id).val();

                      if (!esNumero(hesimp)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#s' + personal_id).focus();
                          $('#s' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          hesimp = hesimp.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(headi)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#a' + personal_id).focus();
                          $('#a' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          headi = headi.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(hedob)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#d' + personal_id).focus();
                          $('#d' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          hedob = hedob.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(hefalt)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#f' + personal_id).focus();
                          $('#f' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          hefalt = hefalt.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(hetar)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#t' + personal_id).focus();
                          $('#t' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          hetar = hetar.replace(':', '.');
                          mostr = true;
                      }


                      if (!esNumero(per_desmed)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#per_desmed' + personal_id).focus();
                          $('#per_desmed' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          per_desmed = per_desmed.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(per_perdia)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#per_perdia' + personal_id).focus();
                          $('#per_perdia' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          per_perdia = per_perdia.replace(':', '.');
                          mostr = true;
                      }

                      if (!esNumero(horaspermiso)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#hp' + personal_id).focus();
                          $('#hp' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          horaspermiso = horaspermiso.replace(':', '.');
                          mostr = true;
                      } 

                      if (!esNumero(psingoce)) {
                          $('#lblError').html('.::Error > No es un numero valido.');
                          $('#ps' + personal_id).focus();
                          $('#ps' + personal_id).css('background-color', '#FFC5C5');
                          mostr = false;
                          return false;
                      } else {
                          psingoce = psingoce.replace(':', '.');
                          mostr = true;
                      }

                      //recorrido de tabla de parametros vs conceptos
                      var cantid = $('#tbodyParametros input:checkbox:checked').length;
                      if (cantid == 0) {
                          alert('.::Error > No a seleccionado a ningun Concepto.');
                          return false;
                      }

                      $('#tbodyParametros input[type="checkbox"]').each(function () {
                          if ($(this).prop('checked') == true) {
                              //perso.push($(this).val()); 
                              // validamos columna 2 abreviatura
                              // colocamos columna 1 id_concepto
                              if ($(this).parents("tr").find("td").eq(2).html() == 'VHED1') { /// '000036'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, hesimp);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VHED2') { /// '000037'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, headi);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VHED') { /// '000038'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, hedob);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDFI') { /// '000031'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, hefalt);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VHTI') { /// '000421'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, hetar);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDDMCG') { /// '000027'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, per_desmed);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDPCG') { /// '000026'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, per_perdia);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDPCGH') { /// '001314'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, horaspermiso);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDD') { /// '001314'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, domingo);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'AS') { /// '001314'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, asist);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'COMP') { /// '001314'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, comp);
                              }

                              if ($(this).parents("tr").find("td").eq(2).html() == 'VDPSG') { /// '001314'
                                  ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), $(this).parents("tr").find("td").eq(1).html(), personal_id, psingoce);
                              }


                          }
                      });


                     
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000037', personal_id, headi);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000038', personal_id, hedob);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000031', personal_id, hefalt);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000421', personal_id, hetar);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000036', personal_id, hesimp);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000027', personal_id, per_desmed);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '000026', personal_id, per_perdia);
                      //ActualizarConceptoPlanilla(Get_Planilla_Find(), Get_Periodo_Find(), '001314', personal_id, horaspermiso);

                  });
                  if (mostr) {
                      alert('Proceso terminado > Correctos: ' + Correctos + ', Errores: ' + Errores);
                  }
              }
              closeModalDiv01();
          });


          $('#btncancel').click(function () {
              closeModalDiv01();
          });

          $('#btnreplicar').click(function () {
               pasaModal01();
          });

          $('#btnreplica').click(function () {
             
              replicardatos();
              Limpiardatos01();
          });

          $('#btnExportar').click(function () {
              
              exportExcel('TblPasarPlanilla', 'Pasar_Planilla');
              

          });


      });

  function esNumero(valor) {
      var valor = valor;
      valor = valor.replace(':', '.');
      if (isNaN(valor)) {
          return false;
      } else {
          return true;
      }
  }
  </script>

</asp:Content>
