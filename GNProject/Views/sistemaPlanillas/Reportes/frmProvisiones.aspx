<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProvisiones.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Reportes.frmProvisiones" %>

<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte de Provisiones</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <div style="overflow:auto; height:640px; width:1058px;">
        <CR:CrystalReportViewer ID="rpt" runat="server"
        AutoDataBind="true" PrintMode="Pdf" BorderColor="Black" BorderStyle="Solid" 
            BorderWidth="1px" onunload="rpt_Unload" />
    </div>
    </form>
</body>
</html>