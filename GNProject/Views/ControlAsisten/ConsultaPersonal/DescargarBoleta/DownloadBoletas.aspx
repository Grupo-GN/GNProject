<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadBoletas.aspx.cs" Inherits="Presentacion.ConsultaPersonal.DescargarBoleta.DownloadBoletas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" ToolPanelView="None" 
            onunload="CrystalReportViewer1_Unload" />
    <label style="font-family: Arial, Helvetica, sans-serif; font-size: 40px; font-weight: bold; font-style: italic; font-variant: normal; color: #008000; text-align: center; width: 100%; top: 50%">DESCARGADO CORRECTAMENTE</label>
    </div>
    </form>
</body>
</html>
