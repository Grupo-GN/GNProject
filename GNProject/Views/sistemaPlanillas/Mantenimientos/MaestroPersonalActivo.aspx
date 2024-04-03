<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="MaestroPersonalActivo.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.MaestroPersonalActivo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <link href="../jqueriUI/css/custom-theme/jquery-ui-1.10.3.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../css/StyleWilder.css" rel="stylesheet" type="text/css" />

    <fieldset style="width:100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; overflow:hidden; border-radius:8px 8px 0px 0px; border-top: solid 1px black;">
    <input type="hidden" id="empresaSession" value="<%= Session["EmpresaPlanilla"] %>" />
    <input type="hidden" id="periodoSession" value="<%= Session["PeriodoPlanilla"] %>" />
    <input type="hidden" id="planillaSession" value="<%= Session["planillaPlanilla"] %>" />
    <label class="miLabel" id="lblNombrePersonal"></label>
    <fieldset>
        <table width="100%">
            <tr>
                <td style="width:90%;">
                    <asp:Label ID="Label9" runat="server" Text="MANTENIMIENTO DE PERSONAL POR PERIODO" CssClass="miTitulo" Width="300px"></asp:Label>
                </td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonNew" id="btnNew" value="Nuevo" title="Para Agregar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonAdd" id="btnAdd" value="Grabar" title="Para Grabar un Nuevo Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonCancel" id="btnCancel" value="Cancelar" title="Para Cancelar la Informacion" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonUpdate" id="btnUpdate" value="Actualizar" title="Para Modificar el Registro" /></td>
                <td style="text-align:right;width:28px;"><input type="button" class="elBotonDelete" id="btnDelete" value="Eliminar" title="" /></td>
            </tr>
            
        </table>
    </fieldset>
    
    <label class="miLabelError" id="lblError" style="font-size:14px;" ></label>
    <div id="TabContainer" style="height:415px;width:100%;">
        <ul>
            <li><a href="#Tab1">Lista</a></li>
            <li><a href="#Tab2">Datos Principales</a></li>
            <li><a href="#Tab3">Datos Secundarios</a></li>
            <li><a href="#Tab4">Tab / Pensionista</a></li>
            <li><a href="#Tab5">4Ta / M.F. / Ter.</a></li>
            <li><a href="#Tab6">Otros Datos</a></li>            
        </ul>
    
    <div id="Tab1">
        <fieldset>
            <legend>BUSQUEDA</legend>
            <label class="miLabel">Filtrar Por:</label>
            <select id="cboBusquedaEn" class="ddl" style="width:150px;"> </select>
            <label class="miLabel">Digite la Persona a Buscar:</label>
            <input type="text" class="miTextBox" id="txtBuscar" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" id="btnAdicionar" class="submit" value="Adicionar" />
        </fieldset>
        <div  style="overflow: hidden; width: 100%; border: solid 1px #505050;height: 260px;">
        <table class="gridSmall" style="width:100%;">
            <thead>
                <tr>
                    <th></th>
                    <th></th>
                    <th>ID</th>
                    <th>AP. PATERNO</th>
                    <th>AP. MATERNO</th>
                    <th>NOMBRES</th>
                    <th>TIPO DOC</th>
                    <th>NRO. DOC</th>
                    <th>F. INGRESO</th>
                    <th>F. INI. CONTRATO</th>
                    <th>F. FIN</th>
                    <th>F. CESE</th>
                    <th>PROYECTO</th>
                    <th>NRO CTA</th>
                    <th>NRO CTA CTS</th>
                    <th>TELÉFONO</th>        
                </tr>
            </thead>
            <tbody id="tbodyPersonal" class="tbodyPer">
            
            
            </tbody>
        </table>
        </div>
         <div style="overflow: hidden; width: 100%; border: solid 1px #505050;">
            <table class="table">
                 <tfoot>
                <tr>
                <td class="tfoottd"  colspan="3">

                    <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >TOTAL REGISTROS: </label> &nbsp
                    <input id="txtnRegistros" type="text" value="0" class="TextPage" readonly="true" /> &nbsp &nbsp
                    <label style="font-family: 'AENOR Fontana ND'; font-weight: bold; font-size: 1.1em;" >PAGE: </label> &nbsp
                    <input id="txtPaginaActual" type="text" value="1" class="TextPage" readonly="true" />
                     <input id="btnPrimero" type="button" value="|<" class="submitPager" />
                     <input id="btnAnterior" type="button" value="<<" class="submitPager" />
                     <input id="btnSiguiente" type="button" value=">>" class="submitPager" />
                     <input id="btnUltimo" type="button" value=">|" class="submitPager"/>
                </td>
                </tr>
                </tfoot>
            </table>
            </div>
            
    </div>
    <div id="Tab2" style="overflow:auto;height:363px;">
    <fieldset>
        <legend><label class="miTituloOnTab">Datos Principales</label></legend>
    
    <table style="width:100%;">
        <tr>
            <td style="text-align:left;width:90px;">Codigo:</td>
            <td style="width:200px;"><input type="text" class="ddl" id="txtPersonal_Id" readonly="readonly" /></td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
            <td> &nbsp;</td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td><input type="text" class="ddl" id="txtNombre" /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Apellido Paterno</td>
            <td><input type="text" class="ddl" id="txtApePaterno" /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Apellido Materno</td>
            <td><input type="text" class="ddl" id="txtApeMaterno" /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Fecha de Nacim.</td>
            <td><input type="text" class="ddl" id="txtFecNacim" /></td>
            <td style="width:60px;">Sexo</td>
            <td style="width:140px;"><select id="cboSexo" class="ddl"></select></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Tipo Doc.</td>
            <td><select id="cboTipoDoc" class="ddl"></select></td>
            <td>Nro. Doc</td>
            <td><input type="text" class="ddl" id="txtNroDoc" /></td>
            <td></td>
            <td></td>
        </tr>
 
        <tr>
            <td>Nacionalidad</td>
            <td><select id="cboNacionalidad" class="ddl"></select></td>
            <td>Teléfono</td>
            <td><input type="text" class="ddl" id="txtTelf" /></td>
            <td></td>
            <td></td>
        </tr> 

        <tr>
            <td>Teléfono 2</td>
            <td><input type="text" class="ddl" id="txtTelf2" /></td>
            <td>Teléfono 3</td>
            <td><input type="text" class="ddl" id="txtTelf3" /></td>
            <td></td>
            <td></td>
        </tr> 
  
        <tr>
            <td>Email Corporativo</td>
            <td colspan="2"><input type="text" class="ddl" id="txtEmail" style="width:180px;" /></td>            
            <td><input type="checkbox" id="ckDomiciliado"/>Domiciliado?</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Email Personal</td>
            <td><input type="text" class="ddl" id="txtemailp" style="width:180px;" /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Código Interno</td>
            <td><input type="text" class="ddl" id="txtCodigoInterno" style="width:100px;" /></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr> 
   
    </table>
    </fieldset>
    <fieldset>
        <legend><label class="miTituloOnTab">Direccion</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:90px;">Tipo Vía</td>
                <td style="width:182px;"><select id="cboTipoVia" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nombre Vía</td>
                <td><input type="text" id="txtNomVia" class="ddl" style="width:180px;" /></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Número Vía</td>
                <td><input type="text" id="txtNumVia" class="ddl" /></td>
                <td style="width:65px;">Interior Vía</td>
                <td><input type="text" id="txtInteriorVia" class="ddl" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Tipo Zona</td>
                <td><select id="cboTipoZona" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nombre Zona</td>
                <td><input type="text" id="txtNomZona" class="ddl" style="width:180px;"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Referencia</td>
                <td><input type="text" id="txtReferencia" class="ddl" style="width:180px;"/></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
    <legend><label class="miTituloOnTab">Ubigeo</label></legend>
    <table style="width:100%;">
        <tr>
            <td style="width:90px;">Departamento</td>
            <td><select id="cboDep" class="ddl" style="width:180px;"></select></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Provincia</td>
            <td><select id="cboProv" class="ddl" style="width:180px;"></select></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>Distrito</td>
            <td><select id="cboDist" class="ddl" style="width:180px;"></select></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>

    </table>
    </fieldset>
    </div>
    <div id="Tab3" style="overflow:auto;height:363px;">
    <fieldset>
        <legend><label class="miTituloOnTab">Datos Secundarios</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Compania</td>
                <td style="width:200px;"><select id="cboCompania" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>PlanPlanilla</td>
                <td><select id="cboTipoPlanilla" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Localidad</td>
                <td><select id="cboArea" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Centro Costo>
                <td><select id="cboCCosto" class="ddl" style="width:280px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>CateCategoría</td>
                <td><select id="cboCategoria" class="ddl" style="width:180px;"></select></td>
                <td style="width:100px;">Área</td>
                <td><select id="cboCatAuxiliar" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Categoría 2</td>
                <td><select id="cboCategoria2" class="ddl" style="width:180px;"></select></td>
                <td>Sección</td>
                <td><select id="cboCatAuxiliar2" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Gerencia / Proyecto</td>
                <td><select id="cboProyecto" class="ddl" style="width:180px;"></select></td>
                <td>Anexo>
                <td><select id="cboAnexo" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Situación</td>
                <td><select id="cboSituacion" class="ddl" style="width:180px;"></select></td>
                <td>Anexo 2</td>
                <td><select id="cboAnexo2" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Estado Civil</td>
                <td><select id="cboEstadoCivil" class="ddl" style="width:180px;"></select></td>
                <td>Fecha de Ingreso</td>
                <td><input id="txtFecIngreso" class="ddl" type="text" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Cod. Seg. Social</td>
                <td><input id="txtCodSegSocial" class="ddl" type="text" /></td>
                <td>Inicio de Contrato</td>
                <td><input id="txtFecIniContrato" class="ddl" type="text" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Num Hijos</td>
                <td><input id="txtNumHijos" class="ddl" type="text" /></td>
                <td>Fin de Contrato</td>
                <td><input id="txtFecFinContrato" class="ddl" type="text" /></td>
                <td></td>
                <td></td>
            </tr>   
            <tr>
                <td>Estado</td>
                <td><select id="cboEstado" class="ddl" style="width:180px;"></select></td>
                <td>Fecha de Cese</td>
                <td><input id="txtFecCese" class="ddl" type="text" /></td>
                <td></td>
                <td></td>
            </tr> 
            <tr>
                <td>Motivo Cese</td>
                <td><select id="cboMotivoCese" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr> 
                    
        </table>
    </fieldset>
    <fieldset>
        <legend><label class="miTituloOnTab">Datos Bancarios</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Tipo Cuenta</td>
                <td style="width:200px;"><select id="cboTipoCuenta" class="ddl" style="width:180px;"></select></td>
                <td style="width:100px;">Tipo Cuenta CTS</td>
                <td style="width:200px;"><select id="cboTipoCuentaCTS" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr> 
            <tr>
                <td>Banco Cuenta</td>
                <td><select id="cboBancoCuenta" class="ddl" style="width:180px;"></select></td>
                <td>Banco Cuenta CTS</td>
                <td><select id="cboBancoCuentaCTS" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>  
            <tr>
                <td>Moneda Cuenta</td>
                <td><select id="cboMonedaCuenta" class="ddl" style="width:180px;"></select></td>
                <td>Moneda Cuenta CTS</td>
                <td><select id="cboMonedaCuentaCTS" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nro Cuenta</td>
                <td><input id="txtNroCuenta" class="ddl" style="width:180px;"/></td>
                <td>Nro Cuenta CTS</td>
                <td><input id="txtNroCuentaCTS" class="ddl" style="width:180px;"/></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nro Cuenta Interbancaria</td>
                <td><input id="txtNroCuentaInterbancaria" class="ddl" style="width:180px;"/></td>
                <td>Banco de Pago CTS de Compañia - MN</td>
                <td><select id="cboBancoPagoCTS_Cia" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Banco de Pago de Compañia - MN</td>
                <td><select id="cboBancoPago_Cia" class="ddl" style="width:180px;"></select></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </fieldset>
    
    
    </div>
    <div id="Tab4" style="overflow:auto;height:363px;">
    <fieldset>
        <legend><label class="miTituloOnTab">Datos del Trabajador</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Tipo Trabajador</td>
                <td colspan="3"><select id="cboTipoTrabajador" class="ddl" ></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Régimen Laboral</td>
                <td colspan="3"><select id="cboRegLaboral" class="ddl" ></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Nivel Educativo</td>
                <td colspan="3"><select id="cboNivelEduca" class="ddl" ></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Cargo</td>
                <td colspan="2"><select id="cboCargo" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Rol</td>
                <td colspan="2">
                    <select id="cboRol" class="ddl">
                        <option value="" selected="selected">-Ninguno-</option>
                        <option value="01">Jefe</option>
                        <option value="02">Coordinador</option>
                        <option value="03">Gerente</option>
                    </select>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <%--@002 I--%>
            <tr>
                <td>Contraseña</td>
                <td><input id="txtContrasenia" /></td>
                <td style="text-align:right;">Nivel Acceso</td>
                <td><select id="cboNivelAcceso" class="ddl"></select></td>     
                <td></td>                           
            </tr>
            <%--@002 F--%>
            <tr>
                <td><input type="checkbox" class="ck" />Discapacitado?</td>
                <td style="width:150px;text-align:right;">Régimen Pensionario</td>
                <td><select id="cboRegPensionario" class="ddl" ></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Fec Ini Aportación</td>
                <td><input type="text" id="txtFecIniAportacion" class="ddl" /></td>
                <td style="width:60px;text-align:right;"">C.U.S.P.P.</td>
                <td><input type="text" id="txtCUSPP" class="ddl" /></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>SCTR Salud</td>
                <td><select id="cboSCTRSalud" class="ddl" ></select></td>
                <td style="text-align:right;">SCTR Pension</td>
                <td><select id="cboSCTRPension" class="ddl" ></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Tipo Contrato</td>
                <td colspan="3"><select id="cboTipoContrato" class="ddl" ></select></td>               
                <td></td>
                <td></td>
            </tr>
           <tr>
                <td colspan="4"><input type="checkbox" id="ckJorAtipica" class="ck" />Jornada Atípica?&nbsp;&nbsp;&nbsp;
                <input type="checkbox" id="ckJorMaxima" class="ck" />Jornada Máxima?&nbsp;&nbsp;&nbsp;
                <input type="checkbox" id="ckHorarioNoctu" class="ck" />Horario Nocturno?&nbsp;&nbsp;&nbsp;
                <input type="checkbox" id="ckSindicalizado" class="ck" />Sindicalizado?
                </td>                 
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>EPS</td>
                <td  colspan="3"><select id="cboEPS" class="ddl"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><input type="checkbox" id="ckIng5taInaf" class="ck" />Ing. 5ta Inaf.?</td>
                <td style="text-align:right;">Situación Especial</td>
                <td colspan="2"><select id="cboSituacionEspec" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="fieldDatosPen">
        <legend><label class="miTituloOnTab">Datos del Pensionista</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Tipo Pensionista</td>
                <td colspan="3"><select id="cboTipoPensionista" class="ddl"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td >Reg. Pensionario</td>
                <td colspan="3"><select id="cboRegPensionista" class="ddl"></select></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Fec Ini Aportación</td>
                <td style="text-align:right;">C.U.S.P.P.</td>
                <td><input type="text" id="txtCUSPP2" class="ddl"/></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            
        </table>
    </fieldset>
    </div>
    <div id="Tab5" style="overflow:auto;height:363px;">
    <fieldset id="fielPrestador">
        <legend><label class="miTituloOnTab">Prestador de Servicios - Cuarta Categoría</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">RUC</td>
                <td style="width:180px;"><input type="text" id="txtRUC" class="ddl" /></td>
                <td style="width:100px;">&nbsp;</td>
                <td style="width:180px;">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="fielPrestServi">
        <legend><label class="miTituloOnTab">Prestador de Servicios - Modalidad Formativa</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Seguro Médico</td>
                <td colspan="2"><select id="cboSeguroMed" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Nivel Educativo</td>
                <td colspan="2"><select id="cboNivelEduca2" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cargo</td>
                <td colspan="2"><select id="cboCargo2" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5"><input type="checkbox" id="ckMadreconResFam" class="ck" />Madre con Resp. Familiar?&nbsp;&nbsp;&nbsp;
                <input type="checkbox" id="ckDiscapacidad2" class="ck"/>Discapacidad?&nbsp;&nbsp;&nbsp;
                <input type="checkbox" id="ckHorarioNoctu2" class="ck"/>Horario Nocturno?</td>                
            </tr>
            <tr>
                <td>Tipo Cen. F. Prof</td>
                <td colspan="2"><select id="cboTipoCenFProf" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>                
            </tr>
            <tr>
                <td>Tipo Mod. Format.</td>
                <td colspan="2"><select id="cboTipoModFormat" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="fielPersonalTer">
        <legend><label class="miTituloOnTab">Personal de Terceros</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">RUC Cia. Dest.</td>
                <td><input type="text" id="txtRUCDest" class="ddl" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>SCTR Salud</td>
                <td  style="width:100px;"><select id="cboSCTRSalud2" class="ddl"></select></td>
                <td  style="width:100px;">SCTR Pension</td>
                <td><select id="cboSCTRPension2" class="ddl"></select></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend><label class="miTituloOnTab">SubSidios</label></legend>
        <table style="width;100%;">
            <tr>
                <td style="width:100px;">Nro CITT</td>
                <td><input type="text" id="txtNroCITT" class="ddl"/></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    </div>
    <div id="Tab6" style="overflow:auto;height:363px;">
    <fieldset>
        <legend><label class="miTituloOnTab">Datos  Fisicos</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Estatura</td>
                <td style="width:150px;"><input type="text" id="txtEstatura" class="ddl" style="width:50px;" value="0.00" />&nbsp;Mts.</td>
                <td style="width:200px;">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Peso</td>
                <td><input type="text" id="txtPeso" class="ddl" style="width:50px;" value="0.00" />&nbsp;Kgs.</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Complexión</td>
                <td><select id="cboCompexion" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Grupo Sanguíneo</td>
                <td><select id="cboGrupoSanguineo" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="vertical-align:top;">Alergias</td>
                <td colspan="2"><textarea id="txtAlergias" style="width:740px;height:50px;"></textarea></td>
                <td>&nbsp;</td>                
            </tr>
            
        </table>
    </fieldset>
    <fieldset>
        <legend><label class="miTituloOnTab">Vestimenta</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Nro Calzado</td>
                <td><input type="text" id="txtNroCalzado" class="ddl" style="width:50px;" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Talla de Ropa</td>
                <td><select id="cboTallaRopa" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
        </table>
    </fieldset>
    <fieldset>
        <legend><label class="miTituloOnTab">Brevete</label></legend>
        <table style="width:100%;">
            <tr>
                <td style="width:100px;">Nro Brevete</td>
                <td style="width:100px;"><input type="text" id="txtNroBrevete" class="ddl" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Categoría</td>
                <td><select id="cboCategoriaBrevete" class="ddl"></select></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Vigencia</td>
                <td><input type="text" id="txtVigencia" class="ddl" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Codigo Auxiliar</td>
                <td><input type="text" id="txtCodAuxiliar" class="ddl" /></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
        </table>
    </fieldset>
    </div>
    </div>
    
    
    </fieldset>

<div id="dialog-PersonalOut">
    <fieldset>
        <legend><label class="miTituloOnTab">BUSCAR </label></legend>
        <label class="miLabel">Personal Id :</label> <input type="text" id="txtCodigoFind" class="ddl" />
        <label class="miLabel">Nombre y Apellidos :</label><input type="text" id="txtPersonalFind" class="ddl" />
    </fieldset>
    
    <fieldset style="height:275px;width:95%;overflow:auto;">
    <table class="gridSmall" style="width:100%;">
    <thead>
            <tr>
                <th></th>
                <th>Personal Id</th>
                <th>Apellidos y Nombres</th>
            </tr>
            </thead>
            <tbody id="tbodyAgregaPer">
            
            </tbody>
    </table>
    
    </fieldset>
</div>

<div id="divError"></div>


    
    <script src="../JQuery/jquery-1.10.1.min.js" type="text/javascript"></script>
<script src="../jqueriUI/js/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Script_MantenimientoPersonal.js?v0.1.2" type="text/javascript"></script>
    <script src="Scripts/Script_HelperMaestroPersonal.js?v0.1.1" type="text/javascript"></script>

    <script src="Scripts/Script_MantenimientoPersonalActivo.js" type="text/javascript"></script>
<script type="text/javascript">
    var inicio = 0;
    var PROCESO = '';
    
    var DatosP = 0;
    var DatosS = 0;
    var TabPensio = 0;
    var CuartaMF = 0;
    var OtrosD = 0;

    var Personal = [];
    var Personal_IdProceso = '';
    var PDatosP = 0;
    var PDatosS = 0;
    var PTabPensio = 0;
    var PCuartaMF = 0;
    var POtrosD = 0;

    var disNew = null;
    var disGrabar;
    var disCancel;
    var disUpdate;
    var disDelete;
    
    var TotalPaginador = 12;
    var TOTALREGISTROS;
    var PAGINAACTUAL = 1;

    var PeriodoCab = '';
    var SessionUsuarioAcceso = '';
    $(document).ready(function () {
        
        $('#TabContainer').tabs();
        $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
        $('#dialog-PersonalOut').hide();
        //VARIABLES DISABLED
        var I_Compania;
        I_Compania = setInterval(function () {
            document.getElementById('cboCompania').disabled = true;
            //////document.getElementById('cboTipoPlanilla').disabled = true;
            document.getElementById('fieldDatosPen').disabled = true;
            document.getElementById('fielPrestador').disabled = true;
            document.getElementById('fielPrestServi').disabled = true;
            document.getElementById('fielPersonalTer').disabled = true;

        }, 1000);


        window.setInterval(function () {
            Disable_btnNew(true);
        }, 100);

        disGrabar = window.setInterval(function () {
            Disable_btnGrabar(true);
        }, 100);

        disCancel = window.setInterval(function () {
            Disable_btnCancelar(true);
        }, 100);

        disUpdate = window.setInterval(function () {
            Disable_btnActualizar(true);
        }, 100);

        disDelete = window.setInterval(function () {
            Disable_btnEliminar(true);
        }, 100);

        //FECHAS JQUERY
        $("#txtFecNacim").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });


        $("#txtFecIngreso").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });
        $("#txtFecIniContrato").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });
        $("#txtFecFinContrato").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });

        $("#txtFecCese").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });
        $("#Fecha_Ini_AporteAFP").datepicker({
            dateFormat: "dd/mm/yy",
            defaultDate: "+1w",
            //changeMonth: true,
            changeYear: true
        });


        ListaColumnPersonal();
        Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);

        $('#cboBusquedaEn').change(function () {
            inicio = 0;
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        });
        $('#txtBuscar').keyup(function () {
            if ($('#cboBusquedaEn').val() != 'Todos') {
                inicio = 0;
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            }
        });
        //20180611
        /*$('#TabContainer').on("tabsactivate", function(event, ui) {
        var curTab = $('.ui-tabs-active');
        var curTabIndex = curTab.index();
        switch (curTabIndex) {
        case 1: if (DatosP == 0) { CargarCombosDatosPrincipales(); DatosP = 1 }; break;
        case 2: if (DatosS == 0) { CargarCombosDatosSecundarios(); DatosS = 1 }; break;
        case 3: if (TabPensio == 0) { CargarCombosTrabPensionario(); TabPensio = 1 }; break;
        case 4: if (CuartaMF == 0) { CargarCombosCuartaMF(); CuartaMF = 1 }; break;
        case 5: if (OtrosD == 0) { CargarComboOtrosDatos(); OtrosD = 1 }; break;
        }

        if (Personal_IdProceso) {

        switch (curTabIndex) {
        case 1: if (PDatosP == 0) { CargarDatosPrincipales_Personal(); PDatosP = 1; }; break;
        case 2: if (PDatosS == 0) { CargarDatosSecundarios_Personal(); PDatosS = 1 }; break;
        case 3: if (PTabPensio == 0) { CargarDatosTrabPensionista_Personal(); PTabPensio = 1 }; break;
        case 4: if (PCuartaMF == 0) { CargarCombosCuartaMF(); PCuartaMF = 1 }; break;
        case 5: if (POtrosD == 0) { CargarComboOtrosDatos(); POtrosD = 1 }; break;
        }
        }
        });*/

        $('#tbodyPersonal').on('click', '.linkEditar', function () {
            var personal_id = this.id.substring(3);
            Personal_IdProceso = personal_id;
            PDatosP = 0;
            PDatosS = 0;
            PTabPensio = 0;
            PCuartaMF = 0;
            POtrosD = 0;
            //20180611
            //CargarDatos();
            clearDocumento();

            Lista_Personal(personal_id, null);


            window.clearInterval(disGrabar);
            window.clearInterval(disCancel);
            window.clearInterval(disUpdate);
            window.clearInterval(disDelete);

            Disable_btnActualizar(false);
            Disable_btnCancelar(false);



            disGrabar = window.setInterval(function () {
                Disable_btnGrabar(true);
            }, 100);

            disDelete = window.setInterval(function () {
                Disable_btnEliminar(true);
            }, 100);


            PROCESO = '02';
            $('#TabContainer').tabs('enable');
            $('#TabContainer').tabs({ active: 1 });


        });

        //CHANGE CATEGORIA AUXLIAR
        $('#cboCatAuxiliar').change(function () {
            ListaCatAuxiliar2($('#cboCatAuxiliar').val());
            if (Personal.length > 0) {
                $('#cboCatAuxiliar2').val(Personal[0][93]);
            }
        });
        $('#cboDep').change(function () {
            ListaProvincia($('#cboDep').val());
            ListaDistrito($('#cboDep').val(), $('#cboProv').val());
        });
        $('#cboProv').change(function () {
            ListaDistrito($('#cboDep').val(), $('#cboProv').val());
        });

        //EVENTOS

        $('#btnNew').click(function () {


            window.clearInterval(disGrabar);
            window.clearInterval(disCancel);

            Disable_btnGrabar(false);
            Disable_btnCancelar(false);

            Personal_IdProceso = '';
            Personal = [];
            PROCESO = '01';
            Personal = [];

            $('#TabContainer').tabs('enable');
            $('#TabContainer').tabs({ active: 1 });
            clearDocumento();
            //CargarDatos(); //@001 I/F
        });

        $('#btnCancel').click(function () {


            window.clearInterval(disGrabar);
            window.clearInterval(disCancel);
            window.clearInterval(disUpdate);
            window.clearInterval(disDelete);


            disGrabar = window.setInterval(function () {
                Disable_btnGrabar(true);
            }, 100);

            disCancel = window.setInterval(function () {
                Disable_btnCancelar(true);
            }, 100);

            disUpdate = window.setInterval(function () {
                Disable_btnActualizar(true);
            }, 100);

            disDelete = window.setInterval(function () {
                Disable_btnEliminar(true);
            }, 100);
            Personal_IdProceso = '';
            Personal = [];
            PROCESO = '';
            $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
            $('#TabContainer').tabs({ active: 0 });
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        });



        $('#btnUpdate').click(function () {
            if (PROCESO == '02') {
                if (!Personal_IdProceso) {
                    Set_Error('.::Error, Seleccione un personal', null, 0);
                } else {
                    if (Valida_Datos()) {
                        Update_Personal();
                    }
                }
            }

        });
        $('#tbodyPersonal').on('click', '.linkEliminar', function () {

            if (confirm('¿Esta seguro de quitar al personal?')) {
                var personal_id = this.id.substring(3);
                Elimina_Personal_de_Periodo(Get_Periodo(), personal_id);

            }

        });
        $('#btnAdicionar').click(function () {
            Lista_Personal_Faltante_Periodo(Get_Periodo(), '');
            $("#dialog-PersonalOut").dialog({
                height: 400, width: 600, modal: true, autoOpen: true,
                appendTo: "form", title: "AGREGAR PERSONAL AL PERIODO",
                show: { effect: "fade", duration: 800 },
                hide: { effect: "fold", duration: 800 }
            });

        });
        $('#tbodyAgregaPer').on('click', 'label', function () {
            var PersonalCodigo = this.id.substring(3);
            Agrega_Personal_al_Periodo(Get_Periodo(), PersonalCodigo);
        });


        //NAVEGACION

        $('#btnUltimo').click(function () {  //metodos para actualizar

            var guardaPagina = parseInt($('#txtnRegistros').val());
            var laPaginaActual = guardaPagina / TotalPaginador;

            if (guardaPagina > 0 && guardaPagina < 10) {        //Hago un if para saber la ultima pagina
                inicio = 0;
                laPaginaActual = 1;                             //comparando el numero de pagina
            } else if (guardaPagina > 9 && guardaPagina < 100) {    //a division con el total de pagina
                inicio = (parseInt(guardaPagina.toString().substring(0, 1))) + "2";
            } else if (guardaPagina > 99 && guardaPagina < 1000) {
                inicio = guardaPagina.toString().substring(0, 2) + "2";
            } else if (guardaPagina > 999 && guardaPagina < 10000) {
                inicio = guardaPagina.toString().substring(0, 3) + "2";
            } else if (guardaPagina > 9999 && guardaPagina < 100000) {
                inicio = guardaPagina.toString().substring(0, 4) + "2";
            }

            if (inicio > guardaPagina)
                inicio = guardaPagina;

            if (guardaPagina == inicio) {
                inicio = inicio - TotalPaginador;
                PAGINAACTUAL = Math.ceil(laPaginaActual);
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                setPaginaActual(PAGINAACTUAL);

            } else if (guardaPagina != TotalPaginador) {
                PAGINAACTUAL = Math.ceil(laPaginaActual);
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                setPaginaActual(PAGINAACTUAL);
            } else {
                inicio = 0;
            }

        });

        $('#btnPrimero').click(function () {  //metodos para actualizar
            inicio = 0;         //Primer Registro
            PAGINAACTUAL = 1;   //Primera Pagina
            Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
            setPaginaActual(PAGINAACTUAL);
        });

        $('#btnAnterior').click(function () {  //metodos para actualizar
            if (inicio > 0) {
                inicio = parseInt(inicio) - TotalPaginador;
                PAGINAACTUAL = parseInt(PAGINAACTUAL) - 1;
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                setPaginaActual(PAGINAACTUAL);
            }

        });
        $('#btnSiguiente').click(function () {  //metodos para actualizar

            if (parseInt($('#txtnRegistros').val()) > (parseInt(inicio) + parseInt(TotalPaginador))) {
                inicio = parseInt(inicio) + parseInt(TotalPaginador);
                PAGINAACTUAL = parseInt(PAGINAACTUAL) + 1;
                Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
                setPaginaActual(PAGINAACTUAL);
            }

        });

        function setPaginaActual(nPagina) { //Pintar la pagina actual visitada
            $('#txtPaginaActual').val(nPagina);
        }

        //20180611
        //@001 I
        //CargarDatos(); 
        //if (PCuartaMF == 0) { CargarCombosCuartaMF(); PCuartaMF = 1 };
        //if (POtrosD == 0) { CargarComboOtrosDatos(); POtrosD = 1 };
        //@001 F

    });
    function CargarChangeCab() {
        window.clearInterval(disNew);
        window.clearInterval(disGrabar);
        window.clearInterval(disCancel);
        window.clearInterval(disUpdate);
        window.clearInterval(disDelete);

        Disable_btnNew(false);

        disGrabar = window.setInterval(function() {
            Disable_btnGrabar(true);
        }, 100);

        disCancel = window.setInterval(function() {
            Disable_btnCancelar(true);
        }, 100);

        disUpdate = window.setInterval(function() {
            Disable_btnActualizar(true);
        }, 100);

        disDelete = window.setInterval(function() {
            Disable_btnEliminar(true);
        }, 100);
        Personal_IdProceso = '';
        Personal = [];
        PROCESO = '';
        $('#TabContainer').tabs({ disabled: [1, 2, 3, 4, 5] });
        $('#TabContainer').tabs({ active: 0 });
        inicio = 0;
        PAGINAACTUAL = 1;   //Primera Pagina
        Lista_Personal_x_Filtro_Columna(Get_Compania(), Get_Periodo(), Get_ColumnaBusqueda(), Get_TextoBusqueda(), inicio);
        
    }

    window.setInterval(function() {
        var Period = document.getElementById('periodoSession').value;
        if (!PeriodoCab) {
            PeriodoCab = Period;
        }
        if (PeriodoCab != Period) {
            CargarChangeCab();
            PeriodoCab = Period;
        }

        
    }, 1000);

    
   

</script>

</asp:Content>


