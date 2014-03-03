<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SGT_AutoStar.app.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="crossfade">
        <img src="Images/backgrounds/MB5.jpg" alt="Image 1" />
        <img src="Images/backgrounds/J1.jpg" alt="Image 2" />
        <img src="Images/backgrounds/MB12.jpg" alt="Image 3" />
        <img src="Images/backgrounds/FL1.jpg" alt="Image 4" />
        <img src="Images/backgrounds/MB14.jpg" alt="Image 5" />
    </div>


    <asp:Panel ID="panel_login" CssClass="panelLogin" runat="server">
        <div class="divLogin">
            <div class="divLoginParejas">
                <asp:Label ID="label_usuario" runat="server" CssClass="lblLogin" Text="Usuario:" Width="48%"></asp:Label>
                <asp:TextBox ID="usuario" runat="server" CssClass="tbLogin" Width="48%"></asp:TextBox>
            </div>
            <div class="divLoginParejas">
                <asp:Label ID="label_contraseña" runat="server" CssClass="lblLogin" Text="Contraseña:" Width="48%"></asp:Label>
                <asp:TextBox ID="contraseña" runat="server" CssClass="tbLogin" Width="48%"></asp:TextBox>
            </div>
            <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Login1_Authenticate" />
        </div>
    </asp:Panel>


    <hr id="hr1" />
    <asp:Image CssClass="imgLogo" ID="logoAutoStar" runat="server" ImageUrl="~/app/Images/logo.png" />
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="home" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button1" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button2" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button3" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="login" AlternateText="Login" runat="server" ImageUrl="~/app/Images/icons/iconLogin.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table2" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button4" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button8" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Planografo_Digital.aspx" CssClass="botonDoble" ID="planografoDigital" AlternateText="Planografo Digital" runat="server" Enabled="false" ImageUrl="~/app/Images/icons/iconPlanografoDigital.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table3" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Orden_Trabajo.aspx" CssClass="botonFull" ID="ordenTrabajo" AlternateText="Orden de Trabajo" runat="server" Enabled="false" ImageUrl="~/app/Images/icons/iconOrdenTrabajo.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button5" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button6" runat="server" Enabled="False" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table4" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button7" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Asignacion_Parqueo.aspx" CssClass="botonFull" ID="ImageButton1" AlternateText="Asignacion de Parqueos" runat="server" Enabled="false" ImageUrl="~/app/Images/icons/iconAsignacionParqueo.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table5" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Configuracion_General.aspx" CssClass="botonFull" ID="configGeneral" runat="server" Enabled="false" ImageUrl="~/app/Images/icons/iconConfigGeneral.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>
