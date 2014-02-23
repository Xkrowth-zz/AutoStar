<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="ppAsignacion_Parqueos.aspx.cs" Inherits="AutoStar.app.ppAsignacion_Parqueos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Table CssClass="table" ID="Table1" runat="server">
            <asp:TableRow CssClass="tableRow">
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton PostBackUrl="~/app/Default.aspx" CssClass="botonFull" ID="ImageButton3" AlternateText="Home" runat="server" ImageUrl="~/app/Images/icons/iconInicio.png" />
                </asp:TableCell>
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_Asignar" AlternateText="Asignar" runat="server" ImageUrl="~/app/Images/icons/iconAsignacionTiempo.png" OnClick="btn_Asignar_Click" />
                </asp:TableCell>                
                <asp:TableCell CssClass="tableCell">
                    <asp:ImageButton CssClass="botonFull" ID="btn_Eliminar" AlternateText="Eliminar" runat="server" ImageUrl="~/app/Images/icons/iconBorrar.png"  />
                </asp:TableCell>                
            </asp:TableRow>
        </asp:Table>
    </div>
    <asp:Panel ID="Panel1" runat="server" Visible="true" Width="550" class="temporal" >
        <asp:Label ID="lbl_numeroOrden" CssClass="busquedalbl" runat="server" Text="Numero de Orden:"></asp:Label>
        <asp:TextBox ID="TextBox1"  runat="server" ></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" AutoPostBack="true" DataSourceID="SqlDataSource1" DataTextField="numeroOrden" DataValueField="numeroOrden" OnSelectedIndexChanged="dropdown_onSelectedIndexChanged" ></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="SELECT * FROM [GT_Orden_Trabajo]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString2 %>" SelectCommand="ordenesBusqueda" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" DefaultValue="vacio" Name="valor" PropertyName="SelectedValue" Type="String" />
                <asp:Parameter DefaultValue="Numero de Orden" Name="campo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="lbl_status" CssClass="busquedalbl" runat="server" Text="Status:"></asp:Label>
        <asp:TextBox ID="TextBox2"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_tecnico" CssClass="busquedalbl" runat="server" Text="Tecnico:"></asp:Label>
        <asp:TextBox ID="TextBox3"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_area" CssClass="busquedalbl" runat="server" Text="Area:"></asp:Label>
        <asp:TextBox ID="TextBox4"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_asesor" CssClass="busquedalbl" runat="server" Text="Asesor"></asp:Label>
        <asp:TextBox ID="TextBox5"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_placa" CssClass="busquedalbl" runat="server" Text="Placa"></asp:Label>
        <asp:TextBox ID="TextBox6"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_fechaIngreso" CssClass="busquedalbl" runat="server" Text="Fecha Ingreso:"></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_comentarios" CssClass="busquedalbl"  runat="server" Text="Comentarios:"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_garantia" CssClass="busquedalbl" runat="server" Text="Garantia:"></asp:Label>
        <asp:TextBox ID="TextBox9" runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_logistica" CssClass="busquedalbl" runat="server" Text="Logistica"></asp:Label>
        <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_repuestos" CssClass="busquedalbl" runat="server" Text="Repuestos:"></asp:Label>
        <asp:TextBox ID="TextBox11"  runat="server" ></asp:TextBox>
        <asp:Label ID="lbl_cliente" CssClass="busquedalbl" runat="server" Text="Cliente:"></asp:Label>
        <asp:TextBox ID="TextBox12" runat="server" ></asp:TextBox>
        
    </asp:Panel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
