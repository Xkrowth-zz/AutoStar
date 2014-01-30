<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="GT_Acceso_Menu.aspx.cs" Inherits="AutoStar.app.GT_Accesso_Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:ImageButton ID="btn_acceso_menu_eliminar" class="icono" runat="server" ImageUrl="AppData/btn_eliminar.png" onclick="btn_acceso_menu_eliminar_click"/>                                                                                       <!-- LINK IMG TO PAGE -->
            <asp:ImageButton ID="btn_acceso_menu_editar" class="icono" runat="server" ImageUrl="AppData/btn_editar.png" onclick="btn_acceso_menu_editar_click" />
            <asp:ImageButton ID="btn_acceso_menu_nuevo" runat="server" class="icono" ImageUrl="AppData/btn_nuevo.png" onclick="btn_acceso_menu_nuevo_click" /> 

        <h1>Accesos a Menu</h1>
        <hr/>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString %>" DeleteCommand="deleteAcceso" DeleteCommandType="StoredProcedure" InsertCommand="insertAcceso" InsertCommandType="StoredProcedure" SelectCommand="SELECT * FROM GT_Acceso_Menu" UpdateCommand="updateAcceso" UpdateCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" />                    
                    <asp:Parameter Name="comentarios" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idAcceso" Type="int32" />
                    <asp:Parameter Name="idOpcion" Type="int32" />
                    <asp:Parameter Name="idRol" Type="Int32" /> 
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="286px" style="margin-left: 396px; margin-right: 0px; margin-top: 137px" Width="595px" BackColor="Black" ForeColor="White">
                <Columns>
                    <asp:BoundField DataField="idAcceso" HeaderText="idAcceso" SortExpression="idAcceso" />
                    <asp:BoundField DataField="idRol" HeaderText="idRol" SortExpression="idRol" />
                    <asp:BoundField DataField="comentarios" HeaderText="comentarios" SortExpression="comentarios" />                    
                    <asp:BoundField DataField="idOpcion" HeaderText="idOpcion" SortExpression="idOpcion" />
                </Columns>
            </asp:GridView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Panel ID="pnl_acceso_menu_crear" runat="server" Height="164px" Visible="False">

        <asp:Label ID="lbl_acceso_menu_pnl_crear_crear" runat="server" Font-Size="Larger" Text="Crear"></asp:Label>                
                <br />  
        <asp:Label ID="lbl_acceso_menu_pnl_crear_idOpcion" runat="server" Text="idOpcion:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_crear_idOpcion" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_crear_idRol" runat="server" Text="idRol:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_crear_idRol" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_crear_comentarios" runat="server" Text="Comentarios:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_crear_comentarios" runat="server" Height="61px" TextMode="MultiLine" Width="374px"></asp:TextBox>
        <asp:Button ID="btn_acceso_menu_pnl_crear_crear" runat="server" Text="Crear" OnClick="btn_acceso_menu_pnl_crear_crear_click" />
        <asp:Button ID="btn_acceso_menu_pnl_crear_cancelar" runat="server" Text="Cancelar" OnClick="btn_acceso_menu_pnl_crear_cancelar_Click" />
    </asp:Panel>

    <asp:Panel ID="pnl_acceso_menu_editar" runat="server" Height="150px" Visible="False">
        <asp:Label ID="lbl_acceso_menu_pnl_editar_editar" runat="server" Font-Size="Larger" Text="Editar"></asp:Label>                
                <br /> 
        <asp:Label ID="lbl_acceso_menu_pnl_editar_idAcceso" runat="server" Text="idAccesoMenu:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_editar_idAcceso" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_editar_idOpcion" runat="server" Text="idOpcion:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_editar_idOpcion" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_editar_idRol" runat="server" Text="idRol:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_editar_idRol" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_editar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_editar_comentarios" runat="server" Height="61px" TextMode="MultiLine" Width="374px"></asp:TextBox>
        <asp:Button ID="btn_acceso_menu_pnl_editar_crear" runat="server" Text="Editar" OnClick="btn_acceso_menu_pnl_editar_editar_click" />
        <asp:Button ID="btn_acceso_menu_pnl_editar_cancelar" runat="server" Text="Cancelar" OnClick="btn_acceso_menu_pnl_editar_cancelar_Click" />
    </asp:Panel>
    <asp:Panel ID="pnl_acceso_menu_eliminar" runat="server" Height="183px" Visible="False">
        <asp:Label ID="lbl_acceso_menu_pnl_eliminar_eliminar" runat="server" Font-Size="Larger" Text="Eliminar"></asp:Label>                
                <br /> 
        <asp:Label ID="lbl_acceso_menu_pnl_eliminar_idAcceso" runat="server" Text="idAcceso:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_eliminar_idAcceso" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_eliminar_idOpcion" runat="server" Text="idOpcion:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_eliminar_idOpcion" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_eliminar_idRol" runat="server" Text="idRol:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_eliminar_idRol" runat="server"></asp:TextBox>
        <asp:Label ID="lbl_acceso_menu_pnl_eliminar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
        <asp:TextBox ID="txtfld_acceso_menu_pnl_eliminar_comentarios" runat="server" Height="61px" TextMode="MultiLine" Width="374px"></asp:TextBox>
        <asp:Button ID="btn_acceso_menu_pnl_eliminar_crear" runat="server" Text="Eliminar" OnClick="btn_acceso_menu_pnl_eliminar_eliminar_Click" />
        <asp:Button ID="btn_acceso_menu_pnl_eliminar_cancelar" runat="server" Text="Cancelar" OnClick="btn_acceso_menu_pnl_eliminar_cancelar_Click" />
    </asp:Panel>

</asp:Content>
