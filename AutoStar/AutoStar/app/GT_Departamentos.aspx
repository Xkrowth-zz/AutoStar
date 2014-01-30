<%@ Page Title="" Language="C#" MasterPageFile="~/app/AutoStar.Master" AutoEventWireup="true" CodeBehind="GT_Departamentos.aspx.cs" Inherits="AutoStar.app.GT_Departamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ImageButton ID="btn_departamentos_eliminar" class="icono" runat="server" ImageUrl="AppData/btn_eliminar.png" onclick="btn_departamentos_eliminar_click"/>                                                                                       <!-- LINK IMG TO PAGE -->
        <asp:ImageButton ID="btn_departamentos_editar" class="icono" runat="server" ImageUrl="AppData/btn_editar.png" onclick="btn_departamentos_editar_click" />
        <asp:ImageButton ID="btn_departamentos_nuevo" runat="server" class="icono" ImageUrl="AppData/btn_nuevo.png" onclick="btn_departamentos_nuevo_click" />

        <h1>Departamentos</h1>
        <hr/>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GT_AutoStarConnectionString %>" DeleteCommand="insertDepartamento" DeleteCommandType="StoredProcedure" InsertCommand="insertDepartamento" InsertCommandType="StoredProcedure" SelectCommand="SELECT * FROM GT_Departamento" UpdateCommand="updateDepartamento" UpdateCommandType="StoredProcedure">
                <DeleteParameters>
                    <asp:Parameter Name="idDepartamento" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                
                </DeleteParameters>
                <InsertParameters>               
                    <asp:Parameter Name="idDepartamento" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="idDepartamento" Type="Int32" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="comentarios" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>



        
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="286px" style="margin-left: 396px; margin-right: 0px; margin-top: 137px" Width="595px">
                <Columns>
                    <asp:BoundField DataField="idDepartamento" HeaderText="idDepartamento" SortExpression="idDepartamento" />
                    <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                    <asp:BoundField DataField="comentarios" HeaderText="comentarios" SortExpression="comentarios" />                    
                </Columns>
            </asp:GridView>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Panel ID="pnl_departamentos_crear" runat="server" BorderColor="AliceBlue" BorderStyle="Solid" BorderWidth="2px" Width="1612px" Height="252px" EnableViewState="False" Wrap="False" Visible="False">
                
            <asp:Label ID="lbl_departamentos_pnl_crear_crear" runat="server" Font-Size="Larger" Text="Crear"></asp:Label>
                
                <br />              
                <asp:Label ID="lbl_departamentos_pnl_crear_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_crear_descripcion" runat="server" Height="78px" style="margin-left: 77px" TextMode="MultiLine" Width="442px" Wrap="False"></asp:TextBox>
                <asp:Label ID="lbl_departamentos_pnl_crear_comentarios" runat="server" Text="Comentarios:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_crear_comentarios" runat="server" Height="78px" style="margin-top: 0px" TextMode="MultiLine" Width="435px"></asp:TextBox>
                <asp:Button ID="btn_departamentos_pnl_crear_crear" runat="server" Text="Crear" OnClick="btn_departamentos_pnl_crear_crear_click" />
                <asp:Button ID="btn_departamentos_pnl_crear_cancelar" runat="server" Text="Cancelar" OnClick="btn_roles_pnl_crear_cancelar_Click" />
            </asp:Panel>

            <asp:Panel ID="pnl_departamentos_editar" runat="server" Height="249px" Visible="False">
                <asp:Label ID="lbl_departamentos_pnl_editar_editar" runat="server" Font-Size="Larger" Text="Editar"></asp:Label>
                
                <br /> 
                
                <asp:Label ID="lbl_departamentos_pnl_editar_idDepartamento" runat="server" Text="idDepartamento:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_editar_idDepartamento" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_departamentos_pnl_editar_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_editar_descripcion" runat="server" Height="71px" TextMode="MultiLine" Width="432px"></asp:TextBox>
                <asp:Label ID="lbl_departamentos_pnl_editar_comentarios" runat="server" Text="Comentario:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_editar_comentarios" runat="server" Height="72px" Width="323px"></asp:TextBox>
                <asp:Button ID="btn_departamentos_pnl_editar_editar" runat="server" Text="Editar" Width="75px" OnClick="btn_departamentos_pnl_editar_editar_click" />
                <asp:Button ID="btn_departamentos_pnl_editar_cancelar" runat="server" Text="Cancelar" OnClick="btn_departamentos_pnl_editar_cancelar_Click" />
            </asp:Panel>
            <asp:Panel ID="pnl_departamentos_eliminar" runat="server" Height="215px" Visible="False">
                <asp:Label ID="lbl_departamentos_pnl_eliminar_eliminar" runat="server" Font-Size="Larger" Text="Eliminar"></asp:Label>
                
                <br /> 
                
                <asp:Label ID="lbl_departamentos_pnl_eliminar_idDepartamento" runat="server" Text="IdDepartamento:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_eliminar_idDepartamento" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_departamentos_pnl_eliminar_descripcion" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_eliminar_descripcion" runat="server" Height="70px" TextMode="MultiLine" Width="424px"></asp:TextBox>
                <asp:Label ID="lbl_departamentos_pnl_eliminar_comentarios" runat="server" Text="Comentario:"></asp:Label>
                <asp:TextBox ID="txtfld_departamentos_pnl_eliminar_comentarios" runat="server" Height="66px" TextMode="MultiLine" Width="319px"></asp:TextBox>
                <asp:Button ID="btn_departamentos_pnl_eliminar_eliminar" runat="server" Text="Eliminar" OnClick="btn_departamentos_pnl_eliminar_eliminar_Click" />
                <asp:Button ID="btn_departamentos_pnl_eliminar_cancelar" runat="server" Text="Cancelar" OnClick="btn_departamentos_pnl_eliminar_cancelar_Click" />
            </asp:Panel>


</asp:Content>
