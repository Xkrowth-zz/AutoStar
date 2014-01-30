<%@ Page Title="" Language="C#" MasterPageFile="~/app/AutoStar.Master" AutoEventWireup="true" CodeBehind="GT_Tareas.aspx.cs" Inherits="AutoStar.app.GT_Tareas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:ImageButton ID="btn_usuarios_eliminar" class="icono" runat="server" ImageUrl="AppData/btn_eliminar.png" onclick="btn_tareas_eliminar_click"/>                                                                                       <!-- LINK IMG TO PAGE -->
            <asp:ImageButton ID="btn_usuarios_editar" class="icono" runat="server" ImageUrl="AppData/btn_editar.png" onclick="btn_tareas_editar_click" />
            <asp:ImageButton ID="btn_usuarios_nuevo" runat="server" class="icono" ImageUrl="AppData/btn_nuevo.png" onclick="btn_tareas_nuevo_click" />                                                                                          <!-- LINK IMG TO PAGE -->



        <h1>Tareas</h1>
        <hr/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" style="margin-left: 385px; margin-top: 137px" Width="670px">
        <Columns>
            <asp:BoundField DataField="idTarea" HeaderText="idTarea" SortExpression="idTarea" />
            <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
            <asp:BoundField DataField="comentarios" HeaderText="comentarios" SortExpression="comentarios" />
            <asp:BoundField DataField="costo" HeaderText="costo" SortExpression="costo" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString %>" DeleteCommand="deleteTareas" DeleteCommandType="StoredProcedure" InsertCommand="insertTareas" InsertCommandType="StoredProcedure" SelectCommand="SELECT * FROM GT_Tareas" UpdateCommand="updateTareas" UpdateCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="idTarea" Type="String" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="costo" Type="double" />
            <asp:Parameter Name="comentarios" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="idTarea" Type="Int32" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="costo" Type="double" />            
            <asp:Parameter Name="comentarios" Type="String" />
        </InsertParameters>

        <UpdateParameters>
            <asp:Parameter Name="idTarea" Type="Int32" />
            <asp:Parameter Name="descripcion" Type="String" />
            <asp:Parameter Name="costo" Type="double" />
            <asp:Parameter Name="comentarios" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    

    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

        
            
                        
            <asp:Panel ID="pnl_tareas_crear" runat="server" BorderColor="AliceBlue" BorderStyle="Solid" BorderWidth="2px" Width="1613px" Height="252px" EnableViewState="False" Wrap="False" Visible="False">
                
                <asp:Label ID="lbl_tareas_pnl_crear_crear" runat="server" Font-Size="Larger" Text="Crear"></asp:Label>                
                <br />              
                <asp:Label ID="lbl_tareas_pnl_crear_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_crear_descripcion" runat="server" Height="78px" style="margin-left: 77px" TextMode="MultiLine" Width="442px" Wrap="False"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_crear_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_crear_comentarios" runat="server" Height="83px" TextMode="MultiLine" Width="258px"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_crear_costo" runat="server" Text="Costo:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_crear_costo" runat="server" ></asp:TextBox>
                <asp:Button ID="btn_tareas_pnl_crear_crear" runat="server" Text="Crear" OnClick="btn_tareas_pnl_crear_crear_click" />
                <asp:Button ID="btn_tareas_pnl_crear_cancelar" runat="server" Text="Cancelar" OnClick="btn_tareas_pnl_crear_cancelar_Click" />
            </asp:Panel>

            <asp:Panel ID="pnl_tareas_editar" runat="server" Height="249px" Visible="False" Width="1617px">
                <asp:Label ID="lbl_tareas_pnl_editar" runat="server" Font-Size="Larger" Text="Editar"></asp:Label>                
                <br />                
                <asp:Label ID="lbl_tareas_pnl_editar_idTarea" runat="server" Text="idTarea:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_editar_idTarea" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_editar_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_editar_descripcion" runat="server" Height="71px" TextMode="MultiLine" Width="432px"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_editar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_editar_comentarios" runat="server" Height="71px" TextMode="MultiLine" Width="208px"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_editar_costo" runat="server" Text="Costo:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_editar_costo" runat="server"></asp:TextBox>
                <asp:Button ID="btn_tareas_pnl_editar_editar" runat="server" Text="Editar" OnClick="btn_tareas_pnl_editar_editar_click" />
                <asp:Button ID="btn_tareas_pnl_editar_cancelar" runat="server" Text="Cancelar" OnClick="btn_tareas_pnl_editar_cancelar_Click" />
            </asp:Panel>
            <asp:Panel ID="pnl_tareas_eliminar" runat="server" Height="178px" Visible="False" Width="1609px">
                <asp:Label ID="lbl_tareas_pnl_eliminar" runat="server" Font-Size="Larger" Text="Eliminar"></asp:Label>                
                <br />                
                <asp:Label ID="lbl_tareas_pnl_eliminar_idTarea" runat="server" Text="IdTarea:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_eliminar_idTarea" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_eliminar_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_eliminar_descripcion" runat="server" Height="70px" TextMode="MultiLine" Width="424px"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_eliminar_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_eliminar_comentarios" runat="server" Height="68px" TextMode="MultiLine" Width="209px"></asp:TextBox>
                <asp:Label ID="lbl_tareas_pnl_eliminar_costo" runat="server" Text="Costo:"></asp:Label>
                <asp:TextBox ID="txtfld_tareas_pnl_eliminar_costo" runat="server"></asp:TextBox>
                <asp:Button ID="btn_tareas_pnl_eliminar_Eliminar" runat="server" Text="Eliminar" OnClick="btn_tareas_pnl_eliminar_eliminar_Click" />
                <asp:Button ID="btn_tareas_pnl_eliminar_cancelar" runat="server" Text="Cancelar" OnClick="btn_tareas_pnl_eliminar_cancelar_Click" />
            </asp:Panel>

</asp:Content>