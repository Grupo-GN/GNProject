<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPrint.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.FrmPrint" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="false"
            onclick="btnImprimir_Click" />
        
        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px">
        </rsweb:ReportViewer>--%>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="600px" Width="100%" ShowCredentialPrompts="False" ShowPromptAreaButton="False" ShowParameterPrompts="False" ShowZoomControl="False">
        </rsweb:ReportViewer>
        
        <asp:HiddenField ID="hdfPDF" runat="server" />
        
    </div>
    </form>
</body>
</html>
