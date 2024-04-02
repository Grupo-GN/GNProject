<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FrmMntConceptosShow.aspx.cs" Inherits="GNProject.Views.sistemaPlanillas.Mantenimientos.FrmMntConceptosShow" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="../Styles/EstiloKm.css" rel="stylesheet" type="text/css" />
    <link href="../Controles/miEstilo.css" rel="stylesheet" type="text/css" />
    <fieldset style="width: 100%; background-color: White; margin: 0px 0px 0px 0px; border-right: solid 1px black;border-left: solid 1px black; border-bottom: solid 1px black; min-height: 500px;overflow: hidden; border-radius: 8px 8px 0px 0px; border-top: solid 1px black;">
    <label class="miTitulo">MANTENIMIENTO DE CONCEPTOS A MOSTRAR</label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width:100%;border-collapse:collapse;">
                    <tr>
                        <td colspan="2" style="text-align:center; width:50%;background-color:#CED8F6;"><h2>Datos Dijos</h2></td>
                        <td colspan="2" style="text-align:center; width:50%;background-color:#E3F6CE;"><h2>Datos Variables</h2></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="cbodfijos" runat="server" Width="100%" CssClass="miComboBox">
                            </asp:DropDownList>
                        </td>
                        <td style="background-color:#CED8F6;"><asp:Button ID="btnAgregarF" runat="server" Text="Agregar" CssClass="elBotonAdd" 
                                onclick="btnAgregarF_Click" OnClientClick="return confirm('¿Éstá seguro(a) de continuar?');" /></td>
                        <td>
                            <asp:DropDownList ID="cbodvariable" runat="server" Width="100%" CssClass="miComboBox">
                            </asp:DropDownList>
                        </td>
                        <td style="background-color:#E3F6CE;"><asp:Button ID="btnAgregarV" runat="server" Text="Agregar" CssClass="elBotonAdd" 
                                onclick="btnAgregarV_Click" OnClientClick="return confirm('¿Éstá seguro(a) de continuar?');" /></td>
                    </tr>
                    <tr>
                        <td style="width:50%;vertical-align:top;">
                            <asp:CheckBoxList ID="chklistFijos" runat="server" Width="100%" 
                                BorderStyle="Solid" BorderWidth="1px" CssClass="lbox" Height="400px"
                                BorderColor="#CCCCCC" RepeatLayout="Flow">
                                <asp:ListItem>1</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td style="vertical-align:top;background-color:#CED8F6;">
                            <asp:Button ID="btnEliminarF" runat="server" Text="Remover" CssClass="elBotonDelete"
                                onclick="btnEliminarF_Click" OnClientClick="return confirm('¿Está seguro(a) de remover los items ?');" />
                        </td>
                        <td style="width:50%;vertical-align:top;">
                            <asp:CheckBoxList ID="chklistVariable" runat="server" Width="100%" 
                                BorderStyle="Solid" BorderWidth="1px" CssClass="lbox" Height="400px"
                                BorderColor="#CCCCCC" RepeatLayout="Flow" >
                                <asp:ListItem>1</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td style="vertical-align:top;background-color:#E3F6CE;">
                            <asp:Button ID="btnEliminarV" runat="server" Text="Remover" CssClass="elBotonDelete"
                                onclick="btnEliminarV_Click" OnClientClick="return confirm('¿Está seguro(a) de remover los items ?');"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
            <ProgressTemplate>
                <div class="UpdateProgressModalBackground"></div>
                    <center>
                        <div class="UpdateProgressPanel">Cargando...<br /><br />
                            <asp:Image ID="Image2" runat="server" alt="Procesando" ImageUrl="~/css/ajax-loader.gif" />
                        </div>
                    </center>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </fieldset>


</asp:Content>
