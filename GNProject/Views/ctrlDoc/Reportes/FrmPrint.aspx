<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPrint.aspx.cs" Inherits="GNProject.Views.ctrlDoc.Reportes.FrmPrint" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
                Height="100%" Width="100%" ShowCredentialPrompts="False" ShowPromptAreaButton="False"
                ShowParameterPrompts="False" ShowZoomControl="False"
                AsyncRendering="False" SizeToReportContent="True">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
