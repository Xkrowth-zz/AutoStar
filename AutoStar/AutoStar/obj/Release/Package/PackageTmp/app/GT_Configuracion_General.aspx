<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Configuracion_General.aspx.cs" Inherits="SGT_AutoStar.app.configGeneral" %>

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
    <hr id="hr1" />
    <asp:Image CssClass="imgLogo" ID="logoAutoStar" runat="server" ImageUrl="~/app/Images/logo.png" />
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button6" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Usuario.aspx" CssClass="botonFull" ID="ImageButton1" AlternateText="Usuarios" runat="server"  ImageUrl="~/app/Images/icons/iconUsuario.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button19" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Status_Orden.aspx" CssClass="botonFull" ID="ImageButton5" AlternateText="Estado" runat="server"  ImageUrl="~/app/Images/icons/iconStatus.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table2" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button20" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton ID="ImageButton4" runat="server" CssClass="botonFull" PostBackUrl="~/app/GT_Tiempos_Parada.aspx" AlternateText="Tiempos de Parada"  ImageUrl="~/app/Images/icons/iconTiempos.png"/>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button18" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Areas.aspx" CssClass="botonFull" ID="ImageButton7" AlternateText="Areas" runat="server"  ImageUrl="~/app/Images/icons/iconAreas.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table3" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button2" runat="server" Enabled="False" />
                    <%--<asp:ImageButton ID="ImageButton6" runat="server" CssClass="botonFull" PostBackUrl="~/app/GT_Parametros.aspx" AlternateText="Parametros"  ImageUrl="~/app/Images/icons/iconParametros.png" />--%>
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button21" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Roles.aspx" CssClass="botonFull" ID="ImageButton8" AlternateText="Roles" runat="server"  ImageUrl="~/app/Images/icons/iconRoles.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table4" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:Button CssClass="botonSemi" ID="Button1" runat="server" Enabled="False" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Acceso_Menu.aspx" CssClass="botonFull" ID="ImageButton9" AlternateText="Acceso" runat="server"  ImageUrl="~/app/Images/icons/iconAcceso.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table CssClass="table" ID="Table5" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/GT_Opcion_Menu.aspx" CssClass="botonFull" ID="ImageButton2" AlternateText="Opciones" runat="server"  ImageUrl="~/app/Images/icons/iconOpciones.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

</asp:Content>
