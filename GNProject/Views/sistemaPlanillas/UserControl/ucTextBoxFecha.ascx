<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTextBoxFecha.ascx.cs" Inherits="GNProject.Views.sistemaPlanillas.UserControl.ucTextBoxFecha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:TextBox ID="txtFecha" runat="server" Width="70px"></asp:TextBox>
<asp:Image ID="btnFecha" runat="server" ImageUrl="~/Views/sitemaPlanillas/Imgs/buttons/img_Calendar.png" ImageAlign="TextTop" ToolTip="Click para mostrar el Calendario"  />

<cc1:CalendarExtender ID="ceFecha" runat="server"
    CssClass="calendar_Theme1" Enabled="True" Format="dd/MM/yyyy" 
    TargetControlID="txtFecha" PopupButtonID="btnFecha">
</cc1:CalendarExtender>
<cc1:MaskedEditExtender ID="meFecha" runat="server" 
    CultureAMPMPlaceholder="a.m.;p.m." CultureCurrencySymbolPlaceholder="S/." 
    CultureDateFormat="DMY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." 
    CultureName="es-PE" CultureThousandsPlaceholder="," CultureTimePlaceholder="" 
    Enabled="True" Mask="99/99/9999" MaskType="Date" 
    TargetControlID="txtFecha" UserDateFormat="DayMonthYear">
</cc1:MaskedEditExtender>