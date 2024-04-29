<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPreview.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.FrmPreview" %>
<%@ Register Assembly="CrystalDecisions.Web"Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>
<head runat="server">
    <title>Untitled Page</title>
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
    <asp:Button ID="btnExporta" runat="server" Text="Exportar" CssClass="submit"
        onclick="btnExporta_Click" />&nbsp; <asp:DropDownList ID="cboTipeExport" runat="server" CssClass="ddl">
        <asp:ListItem Value="02">PDF</asp:ListItem>
        <asp:ListItem Value="03">Microsoft Excel 97-2003</asp:ListItem>
        <asp:ListItem Value="04">Microsoft Word 97-2003</asp:ListItem>
        <%--<asp:ListItem Value="05">Formato RTF</asp:ListItem>
        <asp:ListItem Value="06">Valores separados por caracteres (CSV)</asp:ListItem>
        <asp:ListItem Value="07">XML</asp:ListItem>--%>
        </asp:DropDownList>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" 
            PrintMode="Pdf" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
             onunload="CrystalReportViewer1_Unload" 
            EnableDatabaseLogonPrompt="False" />
            <%-- HasViewList => combo de Main Report / SubReporte--%>
        
    </div>
    </form>
</body>
</html>
