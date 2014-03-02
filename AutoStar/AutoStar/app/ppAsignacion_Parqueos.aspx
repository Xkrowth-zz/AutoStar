<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="ppAsignacion_Parqueos.aspx.cs" Inherits="AutoStar.app.ppAsignacion_Parqueos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css" class="bodyUsuarios">
        body {
            background-image: url('/app/Images/backgrounds/MB21.jpg');
            background-repeat: no-repeat;
            background-size: cover;
        }
    </style>
    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_Asignar" AlternateText="Asignar" runat="server" ImageUrl="~/app/Images/icons/iconAsignacionTiempo.png" OnClick="btn_Asignar_Click" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_Eliminar" AlternateText="Eliminar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png" OnClick="liberar" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <asp:Panel ID="Panel1" runat="server" Visible="true" class="divPopupParqueo">
        <div class="divComponentesParqueos">
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_numeroOrden" CssClass="lblCrearPlanografo" runat="server" Text="Numero de Orden:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_status" CssClass="lblCrearPlanografo" runat="server" Text="Status:"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_tecnico" CssClass="lblCrearPlanografo" runat="server" Text="Tecnico:"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_area" CssClass="lblCrearPlanografo" runat="server" Text="Area:"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_asesor" CssClass="lblCrearPlanografo" runat="server" Text="Asesor"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_placa" CssClass="lblCrearPlanografo" runat="server" Text="Placa"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="placa" DataValueField="placa" OnSelectedIndexChanged="dropdown_onSelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="divComponentesParqueos">
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_fechaIngreso" CssClass="lblCrearPlanografo" runat="server" Text="Fecha Ingreso:"></asp:Label>
                <asp:TextBox ID="TextBox7" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_comentarios" CssClass="lblCrearPlanografo" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="TextBox8" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_garantia" CssClass="lblCrearPlanografo" runat="server" Text="Garantia:"></asp:Label>
                <asp:TextBox ID="TextBox9" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_logistica" CssClass="lblCrearPlanografo" runat="server" Text="Logistica"></asp:Label>
                <asp:TextBox ID="TextBox10" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_repuestos" CssClass="lblCrearPlanografo" runat="server" Text="Repuestos:"></asp:Label>
                <asp:TextBox ID="TextBox11" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
            <div class="divParejaComponentesParqueo">
                <asp:Label ID="lbl_cliente" CssClass="lblCrearPlanografo" runat="server" Text="Cliente:"></asp:Label>
                <asp:TextBox ID="TextBox12" runat="server" CssClass="ddlCrearPlanografo"></asp:TextBox>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT * FROM [GT_Orden_Trabajo]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="ordenesBusqueda" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="vacio" Name="valor" PropertyName="SelectedValue" Type="String" />
                <asp:Parameter DefaultValue="Placa" Name="campo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
