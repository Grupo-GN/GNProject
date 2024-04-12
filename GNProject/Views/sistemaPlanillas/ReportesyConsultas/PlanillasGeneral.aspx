<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PlanillasGeneral.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.ReportesyConsultas.PlanillasGeneral" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />

    <script src="../JQuery/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../JQuery/jquery-1.8.2.js" type="text/javascript"></script>
    
    
    
         <table align="center" width="100%" style="overflow:auto;">
     <tr>
     <td>
        
        <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px;
           border-right: solid 1px black; border-left: solid 1px black; border-bottom: solid 1px black; 
            min-height:500px; border-radius:8px 8px 0px 0px; border-top: solid 1px black; overflow:auto;">
    
    <br />
<asp:Label ID="Label9" runat="server" 
                Text="EXPORTACION DE PLANILLAS" CssClass="miTitulo"></asp:Label> 
      
<br />
<br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
         
        
            <fieldset style="overflow:auto; border-style: outset; border-width: thin; background-color: 
                White; min-height:430px; width:71%; position:absolute; ">
 
            <table width="100%" style="position :absolute;">

                <tr>
                    <td colspan="8">                     
                        <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="Red" 
                            Text=""></asp:Label>
                    </td> 
                </tr>
<tr>
<td style="width:50px;text-align:right;">

    <asp:Label ID="Label10" runat="server" Text="Proceso : " 
    CssClass="miLabel" Width="100%"></asp:Label>

</td>
<td style="width:160px;">
    <asp:DropDownList ID="cboProceso" runat="server" Width="220px" CssClass="ddl">
        <asp:ListItem Value="01">General</asp:ListItem>
        <asp:ListItem Value="02">Quincena</asp:ListItem>
        <asp:ListItem Value="03">Vacaciones</asp:ListItem>
        <asp:ListItem Value="04">Gratificacion</asp:ListItem>
        <asp:ListItem Value="05">CTS</asp:ListItem>
    </asp:DropDownList>
</td>
<td style="width:50px;">
    <asp:Label ID="Label1" runat="server" Text="Periodo : " CssClass="miLabel"></asp:Label>
</td>
<td style="width:100px;">
    <asp:DropDownList ID="cboPeriodoInicial" runat="server" Width="120px" 
        CssClass="ddl">
    </asp:DropDownList>
</td>
<td style="width:100px;">
  <asp:LinkButton ID="elLink" runat="server" ForeColor="Blue" 
        onclick="elLink_Click">Refrescar Periodo</asp:LinkButton>
</td>
<td style="width:55px;">
<asp:Button ID="btnGenerar" runat="server" Text="Generar"  CssClass="submit"
                        ToolTip="Sirve Para Generar los Asientos Contables del Proceso seleccionado" 
                            onclick="btnGenerar_Click"  />
</td>
<td>
    <asp:Button ID="btnExportar" runat="server" CssClass="submit" Enabled="False" 
        onclick="btnExportar_Click" Text="Exportar Planillas" />
</td>
<td>

</td>
</tr>
<tr>
<td colspan="8">

<div id="General">
    <asp:GridView ID="gvPlanillaGeneral" runat="server" CellPadding="2" Width="500px"
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       
         <Columns>
         <asp:BoundField HeaderText="Periodo" DataField="NOMPERIODO" />
                                <asp:BoundField DataField="CodPersonal" HeaderText="Codigo" />
                                <asp:BoundField DataField="ApeNom" HeaderText="Apellidos y Nombres" >
                                    <HeaderStyle Width="220px" />
                                    <ItemStyle HorizontalAlign="Left" Width="500px" CssClass="FormatFontGridView" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FIngreso" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Ingreso" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FCese" DataFormatString="{0:dd/MM/yyyy}" 
                                   HeaderText="Fec. Cese" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo" >
                            
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodSegSocial" HeaderText="N° Autogenerado" >
                                    <HeaderStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodSeguro" HeaderText="Carne AFP" >
                                    <HeaderStyle Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecNac" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Nac" />
                                <asp:BoundField DataField="DNI" HeaderText="Doc. Ident" />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" >
                                    <HeaderStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP" HeaderText="AFP" >
                                    <HeaderStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecVacIni" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Vac. Ini" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecVacFin" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Vac. Fin" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                
                                        <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%#Eval("DiasTrab") %>'> </asp:Label>
                                 </ItemTemplate>          
                                </asp:TemplateField>
                                    
                                
                                <asp:BoundField DataField="DMedico" HeaderText="Desc. Med." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HNormales" HeaderText="H. Nor" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SubSidio" HeaderText="Subsidio" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HExtras25" HeaderText="H. E. 25" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HExtras35" HeaderText="H. E. 35" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HExtrasDobles" HeaderText="H. E. Dob." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemunBasica" HeaderText="H. Basico" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AsigFamiliar" HeaderText="Asig. Fam." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImpHrSext25" HeaderText="H. Extras 25%" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImpHrSext35" HeaderText="H. Extras 35%" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImpHrSextDob" HeaderText="H. E. Dob." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MSubsidio" HeaderText="SUBSIDIO" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Movilidad" HeaderText="Movilidad" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Refrigerio" HeaderText="Refrigerio" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifNocturna" HeaderText="Bonif. Noct." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ComisVenta" HeaderText="Comis. Venta" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifProduc" HeaderText="Bonif. Produc." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MDescanso" HeaderText="Desc. Med." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifRegular" HeaderText="Bonif. Reg." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifExtraOrd" HeaderText="Bonif. Extra" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Utilidades" HeaderText="Utilidades" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Mayo" HeaderText="Escolaridad" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Reintegro" HeaderText="Reintegro" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ValeAlimentos" HeaderText="Vale Alim." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP3" HeaderText="AFP 3%" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP1023" HeaderText="AFP 10.23 %" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SNP33" HeaderText="SNP 33" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ONP" HeaderText="ONP" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPComisVar" HeaderText="Comis. AFP" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPFondo" HeaderText="Fondo AFP" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPPrimaSeg" HeaderText="Aporte AFP" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EsSaludVida" HeaderText="IPSS Vida" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DsctoVale" HeaderText="Dscto Alim." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Adelanto" HeaderText="Adelanto" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quincena" HeaderText="Quincena" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Prestamo" HeaderText="Prestamo" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Tardanza" HeaderText="Tardanza" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Imp5taCat" HeaderText="Renta 5ta" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OtroDscto" HeaderText="Otro Dscto" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RetJudicial" HeaderText="Reten. Jud." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EPSDesc" HeaderText="EPS Desc." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DsctoCelular" HeaderText="Desc Movil." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cafeteria" HeaderText="Cafeteria" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SeguroVia" HeaderText="Seg. Rimac" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sindicato" HeaderText="Sindicato" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AporteEsSalud" HeaderText="Es Salud" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EPSAporte" HeaderText="ESP" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TIngresos" HeaderText="Tot. Ing." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDsctos" HeaderText="Tot. Dsctos" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TAportes" HeaderText="Tot. Aportes" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TNetos" HeaderText="Tot. Neto" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
        
    </asp:GridView>  
</div>

<div id="kincena">
               <asp:GridView ID="GrvPlanillaQuincena" runat="server" CssClass="mGrid" 
                            ShowFooter="True" AutoGenerateColumns="False" Width="800px" 
                   CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="CCosto" HeaderText="Moneda" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Trabajador" HeaderText="Apellidos y Nombres" >
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoCuenta" HeaderText="Tipo de Cuenta" />
                                <asp:BoundField DataField="Cuenta" HeaderText="Nro De Cuenta a Abonar" />
                                <asp:BoundField DataField="AdelQuincena" HeaderText="Bruto" 
                                    DataFormatString="{0:N}" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
</div>

<div id="gratificacion">
        <asp:GridView ID="GrvPlanillaGrati" runat="server" CssClass="mGrid" 
                            ShowFooter="True" AutoGenerateColumns="False" 
            Width="2800px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="CodPersonal" HeaderText="Codigo" />
                                <asp:BoundField DataField="ApeNom" HeaderText="Apellidos y Nombres" >
                                    <HeaderStyle Width="230px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DNI" HeaderText="DNI" >
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecNac" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Nac." >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo" >
                                    <HeaderStyle Width="230px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FIngreso" HeaderText="Fec. Ingreso" 
                                    DataFormatString="{0:dd/MM/yyyy}" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FCese" HeaderText="Fec. Cese" 
                                    DataFormatString="{0:dd/MM/yyyy}" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CuspP" HeaderText="CuspP" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MesesComp" HeaderText="Meses Comp." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DiasNoComp" HeaderText="Dias Comp." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemunBasica" HeaderText="Rem. Basica" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AsigFamiliar" HeaderText="Asig. Familiar" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP3" HeaderText="AFP 3" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP1023" HeaderText="AFP 1023" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BTS" HeaderText="Bonif." DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PromHE" HeaderText="Prom. H.E." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PromCV" HeaderText="Prom. CV" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PromBN" HeaderText="Prom. BN" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PromBP" HeaderText="Prom. BP" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SNP" HeaderText="SNP 33" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Gratificacion" HeaderText="Gratificacion" 
                                    DataFormatString="{0:N}">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle Font-Bold="True" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ONP" HeaderText="ONP" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPFondo" HeaderText="Fondo" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPComisVar" HeaderText="Comis. Var." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPPrimaSeg" HeaderText="Prima Seg." 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RetJudicial" HeaderText="Ret. Judicial" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Adelanto" HeaderText="Adelanto" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotIng" HeaderText="T. Ingresos" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotDesc" HeaderText="T. Descto" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Neto" HeaderText="T. Neto" DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AporteEsSalud" HeaderText="EsSalud" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AporteSCTR" HeaderText="SCTR" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AporteSenati" HeaderText="Senati" 
                                    DataFormatString="{0:N}" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
</div>

<div id="cts">
    <asp:GridView ID="GrvPlanillaCTS" runat="server" CssClass="mGrid" 
                            ShowFooter="True" AutoGenerateColumns="False" 
        Width="2000px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="CCosto" HeaderText="Centro Costo" >
                                    <HeaderStyle Width="300px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Trabajador" HeaderText="Nombres" >
                                    <HeaderStyle Width="230px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecIng" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fecha Ingreso" />
                                <asp:BoundField DataField="DocIde" HeaderText="Nro. Doc" />
                                <asp:BoundField DataField="FecNac" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fecha Nacimiento" />
                                <asp:BoundField DataField="DiasCTS" DataFormatString="{0:N}" 
                                    HeaderText="Dias CTS" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Basico" DataFormatString="{0:N}" 
                                    HeaderText="Basico" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SextoGrati" DataFormatString="{0:N}" 
                                    HeaderText="Gratif." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AsigFam" DataFormatString="{0:N}" 
                                    HeaderText="Asig. Fam" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifProd" DataFormatString="{0:N}" 
                                    HeaderText="Bonif. Trab." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SobreTiempo" DataFormatString="{0:N}" 
                                    HeaderText="H. Extras" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Refrigerio" DataFormatString="{0:N}" 
                                    HeaderText="Refrigerio" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BonifNoct" DataFormatString="{0:N}" 
                                    HeaderText="Bonif. Comis." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalComp" DataFormatString="{0:N}" 
                                    HeaderText="Tot. Comp." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RetJudicial" DataFormatString="{0:N}" 
                                    HeaderText="Ret. Jud." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Monto" DataFormatString="{0:N}" 
                                    HeaderText="Dep. S/." >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Dolares" DataFormatString="{0:N}" 
                                    HeaderText="Dep. $" >
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DesBanco" HeaderText="Banco" />
                                <asp:BoundField DataField="CtaCte" HeaderText="Cta. Bancaria" />
                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                              <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
</div>

<div id="Vacaciones">
    <asp:GridView ID="GrvPlanillaVacacion" runat="server" CssClass="mGrid" 
                            ShowFooter="True" AutoGenerateColumns="False" 
        Width="3000px" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="CodPersonal" HeaderText="Codigo" />
                                <asp:BoundField DataField="ApeNom" HeaderText="Apellidos y Nombres">
                                    <HeaderStyle Width="230px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DNI" HeaderText="Doc. Ident" />
                                <asp:BoundField DataField="Cargo" HeaderText="Cargo" >
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecNac" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="F. Nac." />
                                <asp:BoundField DataField="DiasV" DataFormatString="{0:N0}" 
                                    HeaderText="Dias Vaca">
                                    <HeaderStyle Width="50px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FIngreso" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="F. Ingreso">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FCese" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="F. Cese">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecVacIni" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Vac. Ini">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecVacFin" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Fec. Vac. Fin">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFP" HeaderText="AFP">
                                    <HeaderStyle Width="180px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CodSeguro" HeaderText="Carne AFP" />
                                <asp:BoundField DataField="Vacaciones" DataFormatString="{0:N}" 
                                    HeaderText="Vacaciones">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AsigFamiliar" DataFormatString="{0:N}" 
                                    HeaderText="Asig. Fam.">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Movilidad" DataFormatString="{0:N}" 
                                    HeaderText="SobreTiempo">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Utilidades" DataFormatString="{0:N}" 
                                    HeaderText="Bonif. Noct.">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SegRimac" DataFormatString="{0:N}" 
                                    HeaderText="Bonif. Prod.">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HExtras" DataFormatString="{0:N}" 
                                    HeaderText="H. Extras">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RefrigerioVaca" DataFormatString="{0:N}" 
                                    HeaderText="Refrigerio">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ONP" DataFormatString="{0:N}" HeaderText="ONP">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPFondo" DataFormatString="{0:N}" 
                                    HeaderText="Aporte AFP">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPComisVar" DataFormatString="{0:N}" 
                                    HeaderText="Comis. AFP">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AFPPrimaSeg" DataFormatString="{0:N}" 
                                    HeaderText="Seguro AFP">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Prestamo" DataFormatString="{0:N}" 
                                    HeaderText="Prestamo">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RetJudicial" DataFormatString="{0:N}" 
                                    HeaderText="Ret. Judicial">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Refrigerio" DataFormatString="{0:N}" 
                                    HeaderText="Refrigerio">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MontoEPS" DataFormatString="{0:N}" 
                                    HeaderText="Desc. EPS">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quincena" DataFormatString="{0:N}" 
                                    HeaderText="Otros Dsctos">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Adelanto" DataFormatString="{0:N}" 
                                    HeaderText="Adelanto">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Imp5taCat" DataFormatString="{0:N}" 
                                    HeaderText="Renta 5ta">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EsSaludVida" DataFormatString="{0:N}" 
                                    HeaderText="EsSalud Vida">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AporteEsSalud" DataFormatString="{0:N}" 
                                    HeaderText="EsSalud">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EPS" DataFormatString="{0:N}" HeaderText="EPS">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TIngresos" DataFormatString="{0:N}" 
                                    HeaderText="Tot. Ingresos">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TEgresos" DataFormatString="{0:N}" 
                                    HeaderText="Tot. Egresos">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TNeto" DataFormatString="{0:N}" 
                                    HeaderText="Tot. Neto">
                                    <HeaderStyle Width="70px" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
</div>

</td>
</tr>
  </table>


</fieldset>
   
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="btnExportar" />
            </Triggers>
            </asp:UpdatePanel>
            
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
                <ProgressTemplate>
        <div class="UpdateProgressModalBackground"></div>
        <center>                                            
            <div class="UpdateProgressPanel">
                Cargando...<br /><br />
            <asp:Image ID="Image2" runat="server" 
            alt="Procesando" ImageUrl="~/Views/sistemaPlanillas/css/ajax-loader.gif" /> 
            </div> 
        </center>
    </ProgressTemplate>
                                        
</asp:UpdateProgress>
    
    </fieldset>
    
         </td>
     </tr>
     </table>


</asp:Content>




