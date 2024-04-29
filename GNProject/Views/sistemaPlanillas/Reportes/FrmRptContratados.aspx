<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRptContratados.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.FrmRptContratados" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" 
            onclick="btnImprimir_Click" />
        
        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px">
        </rsweb:ReportViewer>--%><asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="800px" Width="100%" ShowCredentialPrompts="False" ShowPromptAreaButton="False" ShowParameterPrompts="False" ShowZoomControl="False">
        </rsweb:ReportViewer>
        
        <asp:HiddenField ID="hdfPDF" runat="server" />
        
    </div>
    </form>
</body>
</html>
