<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPlanillas.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.frmPlanillas" %>
<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de Planillas</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="overflow:auto; height:640px; width:1100px;">
        <CR:CrystalReportViewer ID="rpt" runat="server"
         AutoDataBind="true" PrintMode="Pdf" BorderColor="Black" BorderStyle="Solid"  
            BorderWidth="1px" />
    </div>
    </form>
</body>
</html>