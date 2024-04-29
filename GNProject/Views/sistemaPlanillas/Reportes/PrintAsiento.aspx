<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintAsiento.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.PrintAsiento" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exportar Asientos Contables</title>
        <style type="text/css">
    .submit{
    font-weight: bold;
    cursor: pointer;
    padding: 5px;
    /*border: 1px solid #ccc;*/
    border: 1px solid #708090;
    font-family: 'Droid Sans', 'Trebuchet MS', Helvetica, Arial, sans-serif;
    font-size:x-small;
    text-transform:uppercase;
    /*background: #eee;*/
    /*background:#e1fcfc;*/
    background: #cde7ff; /*COLOR DEL BOTON CIERRE DE APERTURA*/
   border-radius: 8px 8px 8px 8px;
	margin-left: 0;
	margin-right: 0px;
	margin-top: 0;
}

.submit:hover {
    /*background: #ddd;*/
    /*background: #F0F8FF;*/
    background:#e1fcfc;
    /*color:#0066FF;*/
   /*color:#4682B4;*/
    color:#B22222;
    border: 1px solid #4169E1;
}
.ddl
{	
	border: 1px solid #B1B1B1;
	font-weight: normal;
	font-family: Arial;
	font-size: 12px;
	font-style: normal;
	color: #000000;
	text-transform:uppercase;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button ID="btnExport" runat="server" Text=" Exportar "  CssClass="submit" 
        onclick="btnExport_Click"/>
        <asp:GridView ID="gridAsiento" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Campo" />
                <asp:BoundField DataField="DSUBDIA" HeaderText="Sub Diario" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCOMPRO" HeaderText="Número de Comprobante" 
                    DataFormatString="{0:N}" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFECCOM" HeaderText="Fecha de Comprobante"  >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCODMON" HeaderText="Código de Moneda" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="CGLOSA" HeaderText="Glosa Principal" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DTIPCAM" HeaderText="Tipo de Cambio" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DTPCONV" HeaderText="Tipo de Conversión" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFLAG" HeaderText="Flag de Conversión de Moneda" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFECCAMB" HeaderText="Fecha Tipo de Cambio" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCUENTA" HeaderText="Cuenta Contable" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCODANE" HeaderText="Código de Anexo" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCENCOS" HeaderText="Código de Centro de Costo" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DDH" HeaderText="Debe / Haber" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DIMPORT" HeaderText="Importe Original" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DUSIMPOR" HeaderText="Importe en Dólares" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DMNIMPOR" HeaderText="Importe en Soles" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DTIPDOC" HeaderText="Tipo de Documento" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DNUMDOC" HeaderText="Número de Documento" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFECDOC" HeaderText="Fecha de Documento" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFECVEN" HeaderText="Fecha de Vencimiento" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DAREA" HeaderText="Código de Area" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DXGLOSA" HeaderText="Glosa Detalle" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCODANEA" HeaderText="Código de Anexo Auxiliar" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DMEDPAG" HeaderText="Medio de Pago" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DTIDREF" HeaderText="Tipo de Documento de Referencia" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DNDOREF" HeaderText="Número de Documento Referencia" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DFECREF" HeaderText="Fecha Documento Referencia" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DBIMREF" HeaderText="Base Imponible Documento Referencia" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DIGVREF" HeaderText="IGV Documento Provisión" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DTIDREFQM" HeaderText="Tipo Referencia en estado MQ" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCODARC" HeaderText="Número Serie Caja Registradora" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DCODANE2" HeaderText="Fecha de Operación" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DMONCOM" HeaderText="Tipo de Tasa" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DBASCOM" HeaderText="Tasa Detracción/Percepción" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DINACOM" 
                    HeaderText="Importe Base Detracción/Percepción Dólares" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
                <asp:BoundField DataField="DIGVCOM" 
                    HeaderText="Importe Base Detracción/Percepción Soles" >
                    <ItemStyle CssClass="text" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

<SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </form>
</body>
</html>
