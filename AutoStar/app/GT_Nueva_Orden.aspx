<%@ Page Title="" Language="C#" MasterPageFile="~/app/AutoStar.Master" AutoEventWireup="true" CodeBehind="GT_Nueva_Orden.aspx.cs" Inherits="AutoStar.app.GT_Nueva_Orden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Label ID="lbl_Nueva_Orden" runat="server" Text="Nueva Orden"></asp:Label>

    <br/>

    <asp:Label ID="lbl_numero_orden" runat="server" Text="Numero de  Orden:"></asp:Label>

    <asp:TextBox ID="txtfld_numero_orden" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv_numero_orden" runat="server"  ErrorMessage="Numero de Orden es un campo obligatario" ControlToValidate="txtfld_numero_orden" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_prioridad" runat="server" Text="Prioridad:"></asp:Label>

    <asp:TextBox ID="txtfld_prioridad" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_prioridad" runat="server"  ErrorMessage="Prioridad es un campo obligatario" ControlToValidate="txtfld_prioridad" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_departamento" runat="server" Text="Departamento:"></asp:Label>

    <asp:TextBox ID="txtfld_departamento" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_departamento" runat="server"  ErrorMessage="Departamento es un campo obligatario" ControlToValidate="txtfld_departamento" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_rol" runat="server" Text="Cliente"></asp:Label>

    <asp:TextBox ID="txtfld_rol" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_rol" runat="server"  ErrorMessage="Rol es un campo obligatario" ControlToValidate="txtfld_rol" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_placa" runat="server" Text="Placa:"></asp:Label>

    <asp:TextBox ID="txtfld_placa" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_placa" runat="server"  ErrorMessage="Placa es un campo obligatario" ControlToValidate="txtfld_placa" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_Asesor" runat="server" Text="Asesor:"></asp:Label>

    <asp:TextBox ID="txtfld_Asesor" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_asesor" runat="server"  ErrorMessage="Asesor es un campo obligatario" ControlToValidate="txtfld_asesor" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_tecnico" runat="server" Text="Técnico:"></asp:Label>

    <asp:TextBox ID="txtfld_tecnico" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_tecnico" runat="server"  ErrorMessage="Tecnico es un campo obligatario" ControlToValidate="txtfld_tecnico" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_fecha_ingreso" runat="server" Text="Fecha Ingreso:"></asp:Label>

    <asp:Calendar ID="clndr_fecha_ingreso" runat="server"></asp:Calendar>

     <%--<asp:RequiredFieldValidator ID="rfv_fecha_ingreso" runat="server" ErrorMessage="Fecha de Ingreso es un campo obligatario" ControlToValidate="clndr_fecha_ingreso" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>

    <asp:Label ID="lbl_estado" runat="server" Text="Estado:"></asp:Label>

    <asp:TextBox ID="txtfld_estado" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_estado" runat="server"  ErrorMessage="Estado de Ingreso es un campo obligatario" ControlToValidate="txtfld_estado" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Label ID="lbl_comentarios" runat="server" Text="Comentarios:"></asp:Label>

    <asp:TextBox ID="txtfld_comentarios" runat="server"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfv_comentarios" runat="server"  ErrorMessage="Comentarios de Ingreso es un campo obligatario" ControlToValidate="txtfld_comentarios" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>

    <asp:Button ID="btn_nueva_orden" runat="server" Text="Guardar" OnClick="btn_nueva_orden_click" />

    <asp:ValidationSummary ID="ValidationSummary1"  ForeColor="Red" runat="server" />


</asp:Content>
