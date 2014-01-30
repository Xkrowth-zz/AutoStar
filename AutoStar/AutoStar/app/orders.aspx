<%@ Page Title="" Language="C#" MasterPageFile="~/app/AutoStar.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="AutoStar.app.orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <a  href="Default.aspx" >
        <img src="AppData/ICONOS-01.png" class="icono" alt="Default.aspx" />
     </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="Orders.aspx" >
        <img src="AppData/ICONOS-08.png" class="icono" alt="Orders.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="changeState.aspx" >
        <img src="AppData/ICONOS-09.png" class="icono" alt="State.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="changeState.aspx" >
        <img src="AppData/ICONOS-10.png" class="icono" alt="changeState.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="Order Manager.aspx" >
        <img src="AppData/ICONOS-12.png" class="icono" alt="Order Manager.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="Querys.aspx" >
        <img src="AppData/ICONOS-11.png" class="icono" alt="Querys.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="Search.aspx" >
        <img src="AppData/ICONOS-06.png" class="icono" alt="Search.aspx" />
    </a>                                                                                          <!-- LINK IMG TO PAGE -->

    <a  href="Log.aspx" >
        <img src="AppData/ICONOS-07.png" class="icono" alt="Log.aspx" />
    </a>

    <h1>Listado de Ordenes</h1>
    <hr/>


     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LevelUpConnectionString %>" SelectCommand="listarEmpleados" SelectCommandType="StoredProcedure" DeleteCommand="deleteEmpleado" DeleteCommandType="StoredProcedure" InsertCommand="createEmpleado" InsertCommandType="StoredProcedure" UpdateCommand="editEmpleado" UpdateCommandType="StoredProcedure">
         <DeleteParameters>
             <asp:Parameter Name="nombre" Type="String" />
             <asp:Parameter Name="apellido1" Type="String" />
             <asp:Parameter Name="apellido2" Type="String" />
             <asp:Parameter Name="index" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="nombre" Type="String" />
             <asp:Parameter Name="apellido1" Type="String" />
             <asp:Parameter Name="apellido2" Type="String" />
             <asp:Parameter Name="index" Type="Int32" />
         </InsertParameters>
         <UpdateParameters>
             <asp:Parameter Name="nombre" Type="String" />
             <asp:Parameter Name="apellido1" Type="String" />
             <asp:Parameter Name="apellido2" Type="String" />
             <asp:Parameter Name="index" Type="Int32" />
         </UpdateParameters>
     </asp:SqlDataSource>


    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="idEmpleado" DataSourceID="SqlDataSource1" Width="731px" style="margin-left: 279px; margin-right: 0px; margin-top: 116px">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="idEmpleado" HeaderText="idEmpleado" InsertVisible="False" ReadOnly="True" SortExpression="idEmpleado" />
            <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
            <asp:BoundField DataField="apellido1" HeaderText="apellido1" SortExpression="apellido1" />
            <asp:BoundField DataField="apellido2" HeaderText="apellido2" SortExpression="apellido2" />
        </Columns>
     </asp:GridView>


     </asp:Content>
