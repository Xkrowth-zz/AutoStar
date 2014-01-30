<%@ Page Title="" Language="C#" MasterPageFile="~/app/AutoStar.Master" AutoEventWireup="true" CodeBehind="GT_Opcion_Menu.aspx.cs" Inherits="AutoStar.app.GT_Opcion_Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ImageButton ID="btn_opcion_menu_eliminar" class="icono" runat="server" ImageUrl="AppData/btn_eliminar.png" onclick="btn_opcion_menu_eliminar_click"/>                                                                                       <!-- LINK IMG TO PAGE -->
        <asp:ImageButton ID="btn_opcion_menu_editar" class="icono" runat="server" ImageUrl="AppData/btn_editar.png" onclick="btn_opcion_menu_editar_click" />
        <asp:ImageButton ID="btn_opcion_menu_nuevo" runat="server" class="icono" ImageUrl="AppData/btn_nuevo.png" onclick="btn_opcion_menu_nuevo_click" />

        <h1>Opciones de Menu</h1>
        <hr/>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString %>" DeleteCommand="deleteOpcion" DeleteCommandType="StoredProcedure" InsertCommand="updateOpcion" InsertCommandType="StoredProcedure" SelectCommand="SELECT * FROM GT_Opcion_Menu" UpdateCommand="updateOpcion" UpdateCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idOpcion" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                    
                </DeleteParameters>
                <InsertParameters>
                    
                    <asp:Parameter Name="idOpcion" Type="Int32" />
                    
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idOpcion" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="286px" style="margin-left: 396px; margin-right: 0px; margin-top: 137px" Width="595px">
                <Columns>
                    <asp:BoundField DataField="idOpcion" HeaderText="idOpcion" SortExpression="idOpcion" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="comentarios" HeaderText="comentarios" SortExpression="comentarios" />
                   
                </Columns>
            </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="pnl_opcion_menu_crear" runat="server" BorderColor="AliceBlue" BorderStyle="Solid" BorderWidth="2px" Width="1389px" Height="252px" EnableViewState="False" Wrap="False" Visible="False">
                
                <asp:Label ID="lbl_opcion_menu_pnl_crear_crear" runat="server" Font-Size="Larger" Text="Crear"></asp:Label>
                
                <br />              
                <asp:Label ID="lbl_opcion_menu_pnl_crear_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_crear_descripcion" runat="server" Height="78px" style="margin-left: 77px" TextMode="MultiLine" Width="442px" Wrap="False"></asp:TextBox>
                <asp:Label ID="lbl_opcion_menu_pnl_crear_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_crear_comentarios" runat="server" Height="77px" TextMode="MultiLine" Width="391px"></asp:TextBox>
                <asp:Button ID="btn_opcion_menu_pnl_crear_crear" runat="server" Text="Crear" OnClick="btn_opcion_pnl_crear_crear_click" />
                <asp:Button ID="btn_opcion_menu_pnl_crear_cancelar" runat="server" Text="Cancelar" OnClick="btn_opcion_pnl_crear_cancelar_Click" />
            </asp:Panel>

            <asp:Panel ID="pnl_opcion_menu_editar" runat="server" Height="249px" Visible="False" Width="1365px">
                <asp:Label ID="lbl_opcion_menu_pnl_editar_editar" runat="server" Font-Size="Larger" Text="Editar"></asp:Label>
                <asp:Label ID="lbl_opcion_menu_pnl_editar_idOpcion" runat="server" Text="idOpcion:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_editar_idOpcion" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_opcion_menu_pnl_editar_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_editar_descripcion" runat="server" Height="78px" style="margin-left: 77px" TextMode="MultiLine" Width="442px" Wrap="False"></asp:TextBox>
                <asp:Label ID="lbl_opcion_menu_pnl_editar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_editar_comentarios" runat="server" Height="77px" TextMode="MultiLine" Width="391px"></asp:TextBox>
                <asp:Button ID="btn_opcion_menu_pnl_editar_crear" runat="server" Text="Editar" OnClick="btn_opcion_pnl_editar_editar_click" />
                <asp:Button ID="btn_opcion_menu_pnl_editar_cancelar" runat="server" Text="Cancelar" OnClick="btn_opcion_pnl_editar_cancelar_Click" />
            </asp:Panel>
            <asp:Panel ID="pnl_opcion_menu_eliminar" runat="server" Height="178px" Visible="False">
                <asp:Label ID="lbl_opcion_menu_pnl_eliminar_eliminar" runat="server" Font-Size="Larger" Text="Eliminar"></asp:Label>
                <asp:Label ID="lbl_opcion_menu_pnl_eliminar_idOpcion" runat="server" Text="idOpcion:"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Label ID="txtfld_opcion_menu_pnl_eliminar_idOpcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_eliminar_descripcion" runat="server" Height="78px" style="margin-left: 77px" TextMode="MultiLine" Width="442px" Wrap="False"></asp:TextBox>
                <asp:Label ID="lbl_opcion_menu_pnl_eliminar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_opcion_menu_pnl_eliminar_comentarios" runat="server" Height="77px" TextMode="MultiLine" Width="391px"></asp:TextBox>
                <asp:Button ID="btn_opcion_menu_pnl_eliminar_crear" runat="server" Text="Eliminar" OnClick="btn_opcion_pnl_eliminar_eliminar_Click" />
                <asp:Button ID="btn_opcion_menu_pnl_eliminar_cancelar" runat="server" Text="Cancelar" OnClick="btn_opcion_pnl_eliminar_cancelar_Click" />
            </asp:Panel>
</asp:Content>
