<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="ppLogin.aspx.cs" Inherits="AutoStar.app.ppLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" LoginButtonText="Ingresar" PasswordLabelText="Contraseña:" RememberMeText="Recordarme la proxima vez." TitleText="" UserNameLabelText="Usuario:"></asp:Login>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
